﻿using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Practica6.MVC.MVC.Models.CustomValidations
{
    public class SymbolsAttr : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string symbols = "!\"·$%&/()=¿¡?'_:;,|@#€*+.1234567890";
            string wordSymbols = value.ToString();
            bool match = (symbols.Intersect(wordSymbols).Count() > 0);
            if (match == true)
            {
                return new ValidationResult("You cannot enter symbols or numbers in this field");
            }
            return ValidationResult.Success;
        }
    }
}