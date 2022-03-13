using System.ComponentModel.DataAnnotations;

namespace StorageZipSample.Models
{
    public class BlobFIleinfo
    {
        /// <summary>
        /// File Name
        /// </summary>
        [Display(Name = "File Name")]
        public string Name { get; set; }
        /// <summary>
        /// File Size
        /// </summary>
        [Display(Name = "File Size")]
        public long? Size { get; set; }
        /// <summary>
        /// ContentType
        /// </summary>
        [Display(Name = "ContentType")]
        public string ContentType { get; set; }
    }
}
