using Practica7.WebApi.MVC.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace Practica7.WebApi.MVC.Models
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
        public string QuantityPerUnit { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
    }
}