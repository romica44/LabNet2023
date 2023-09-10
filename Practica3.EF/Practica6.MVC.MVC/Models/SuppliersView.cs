using Practica6.MVC.MVC.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace Practica6.MVC.MVC.Models
{
    public class SuppliersView
    {
        [Key]
        public int SupplierID { get; set; }

        [CapitalizeAttr]
        [UpperCaseAttr]
        [SymbolsAttr]
        [StringLength(40)]
        [Required(ErrorMessage = "The Company name is required.")]
        public string CompanyName { get; set; }

        [CapitalizeAttr]
        [UpperCaseAttr]
        [SymbolsAttr]
        [StringLength(20)]
        [Required(ErrorMessage = "The Contact name is required.")]
        public string ContactName { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The Phone is required.")]
        [MinLength(10, ErrorMessage = "You must enter 10 numbers, example: '3415757575'")]
        [MaxLength(10, ErrorMessage = "You must enter 10 numbers, example: '1157575756'")]
        public string Phone { get; set; }

    }
}