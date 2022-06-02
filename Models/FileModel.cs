using FileCustomAttribute.CustomFileAttribute;
using System.ComponentModel.DataAnnotations;

namespace FileCustomAttribute.Models
{
    public class FileModel
    {
        [Required]
        [FileAllowedExtention(new string[] {".pdf",".docx",".png"})]
        public IFormFile formFile { get; set; }
    }
}
