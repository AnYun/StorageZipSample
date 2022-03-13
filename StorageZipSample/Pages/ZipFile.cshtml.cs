using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageZipSample.Service;

namespace StorageZipSample.Pages
{
    public class ZipFileModel : PageModel
    {
        private readonly IStorageService _storageService;

        public ZipFileModel(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public IActionResult OnGet(List<string> fileName)
        {
            var zipFile = _storageService.ZipBlobs(fileName);
            return File(zipFile, "application/octet-stream", "ZipFile.zip");
        }
    }
}
