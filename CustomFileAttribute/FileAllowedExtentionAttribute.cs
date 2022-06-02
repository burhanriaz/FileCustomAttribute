using System.ComponentModel.DataAnnotations;

namespace FileCustomAttribute.CustomFileAttribute
{
    public class FileAllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public FileAllowedExtentionAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult("Your Document type is not valid Allowed Only .PDF or .DOC!");
                }
            }
            return ValidationResult.Success;
        }


    }
}
