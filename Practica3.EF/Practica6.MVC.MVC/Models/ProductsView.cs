using Practica6.MVC.MVC.Models.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica6.MVC.MVC.Models
{
    public class ProductsView
    {
        [Key]
        public int ProductID { get; set; }

        [CapitalizeAttr]
        [UpperCaseAttr]
        [SymbolsAttr]
        [StringLength(40)]
        [Required(ErrorMessage = "The Company name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "The Unit Price is required.")]
        public decimal UnitPrice { get; set; }
    }
}