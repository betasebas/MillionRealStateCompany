using Microsoft.AspNetCore.Http;
using MillionRealStateCompany.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Shared.Validations
{
    public class AllowedExtensionsAttributee : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var extension = Path.GetExtension(file.FileName);
            if (file != null)
            {
                if (!Constasts.ALLOWED_FILE_EXTENTIONS.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Your image's filetype is not valid.";
        }
    }
}
