using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ICSharpCode.SharpZipLib.Zip;
using StorageZipSample.Models;

namespace StorageZipSample.Service
{
    /// <summary>
    /// Storage Service
    /// </summary>
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private const string containerName = "samplefile";
        public StorageService(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("StorageKey");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }
        /// <summary>
        /// Get Blob List
        /// </summary>
        /// <returns></returns>
        public List<BlobFIleinfo> GetBlobList()
        {
            var blobList = new List<BlobFIleinfo>();
            BlobContainerClient container = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobPages = container.GetBlobs(BlobTraits.None).AsPages();

            foreach (var blobPage in blobPages)
            {
                foreach (BlobItem blobItem in blobPage.Values)
                {
                    blobList.Add(new BlobFIleinfo()
                    {
                        Name = blobItem.Name,
                        Size = blobItem.Properties.ContentLength,
                        ContentType = blobItem.Properties.ContentType
                    });
                }
            }

            return blobList;
        }
        /// <summary>
        /// Download Blob
        /// </summary>
        /// <param name="blobName">Blob Name</param>
        public (byte[] File, string ContentType) DownloadBlob(string blobName)
        {
            BlobContainerClient container = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blob = container.GetBlobClient(blobName);

            if (blob.Exists())
            {
                MemoryStream file = new MemoryStream();
                BlobDownloadInfo download = blob.Download();
                download.Content.CopyTo(file);
                return (file.ToArray(), blob.GetProperties().Value.ContentType);
            }
            else
                return (null, null);
        }
        /// <summary>
        /// Zip Blobs
        /// </summary>
        /// <param name="fileNames">File Name</param>
        /// <returns></returns>
        public byte[] ZipBlobs(List<string> fileNames)
        {
            using (var output = new MemoryStream())
            using (var zipOutputStream = new ZipOutputStream(output))
            {
                zipOutputStream.SetLevel(9);
                foreach (var fileName in fileNames)
                {
                    BlobContainerClient container = _blobServiceClient.GetBlobContainerClient(containerName);
                    BlobClient blob = container.GetBlobClient(fileName);
                    var entry = new ZipEntry(fileName);
                    zipOutputStream.PutNextEntry(entry);
                    blob.DownloadTo(zipOutputStream);
                }

                zipOutputStream.Finish();
                zipOutputStream.Close();

                return output.ToArray();
            }
        }
    }
}
