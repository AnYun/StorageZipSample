using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageZipSample.Models;
using StorageZipSample.Service;

namespace StorageZipSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStorageService _storageService;

        public IndexModel(ILogger<IndexModel> logger, IStorageService storageService)
        {
            _logger = logger;
            _storageService = storageService;
        }

        public IActionResult OnGet()
        {
            BlobFIleinfos = _storageService.GetBlobList();
            return Page();
        }

        public List<BlobFIleinfo> BlobFIleinfos { get; set; }
    }
}