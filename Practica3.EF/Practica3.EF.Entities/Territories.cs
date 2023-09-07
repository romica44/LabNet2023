namespace Practica6.MVC.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Territories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Territories()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [Required(ErrorMessage = "La descripción de la Región es obligatoria. ")]
        [StringLength(50, ErrorMessage = "La descripción no puede tener más de 50 caracteres. ")]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
