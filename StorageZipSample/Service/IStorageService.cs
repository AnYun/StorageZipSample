using StorageZipSample.Models;

namespace StorageZipSample.Service
{
    public interface IStorageService
    {
        /// <summary>
        /// Get Blob List
        /// </summary>
        /// <returns></returns>
         List<BlobFIleinfo> GetBlobList();
        /// <summary>
        /// Download Blob
        /// </summary>
        /// <param name="blobName">Blob Name</param>
        (byte[] File, string ContentType) DownloadBlob(string blobName);
        /// <summary>
        /// Zip Blobs
        /// </summary>
        /// <param name="fileNames">File Name</param>
        /// <returns></returns>
        byte[] ZipBlobs(List<string> fileNames);
    }
}
