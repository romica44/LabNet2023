using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica6.MVC.MVC.Models.CustomValidations
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