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
    }
}
