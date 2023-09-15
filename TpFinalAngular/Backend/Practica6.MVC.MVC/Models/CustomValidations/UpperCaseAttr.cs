using System.ComponentModel.DataAnnotations;


namespace Practica7.WebApi.MVC.Models.CustomValidations
{
    public class UpperCaseAttr : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var word = value.ToString();
            if (word != null && word.Length > 0)
            {
                if (word == word.ToUpper())
                {
                    return new ValidationResult("Capitalized format only.");
                }
            }
            return ValidationResult.Success;
        }
    }
}