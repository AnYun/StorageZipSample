using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageZipSample.Service;

namespace StorageZipSample.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly IStorageService _storageService;

        public DownloadModel(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public IActionResult OnGet(string blobName)
        {
            var blob = _storageService.DownloadBlob(blobName);
            return File(blob.File, blob.ContentType, blobName);
        }
    }
}
