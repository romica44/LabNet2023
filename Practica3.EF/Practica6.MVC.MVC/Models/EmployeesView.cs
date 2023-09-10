using Practica6.MVC.MVC.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;


namespace Practica6.MVC.MVC.Models
{
    public class EmployeesView
    {
        [Key]
        public int EmployeeID { get; set; }

        [CapitalizeAttr]
        [UpperCaseAttr]
        [SymbolsAttr]
        [StringLength(20)]
        [Required(ErrorMessage = "The FirstName is required.")]
        public string FirstName { get; set; }

        [CapitalizeAttr]
        [UpperCaseAttr]
        [SymbolsAttr]
        [StringLength(20)]
        [Required(ErrorMessage = "The LastName is required.")]
        public string LastName { get; set; }

        [CapitalizeAttr]
        [UpperCaseAttr]
        [SymbolsAttr]
        [StringLength(40)]
        [Required(ErrorMessage = "The Title is required.")]
        public string Title { get; set; }
    }
}