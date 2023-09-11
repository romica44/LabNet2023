﻿using System.ComponentModel.DataAnnotations;

namespace Practica7.WebApi.MVC.Models.CustomValidations
{
    public class CapitalizeAttr: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("The first letter must be uppercase");
            }
            return ValidationResult.Success;
        }
    }
}