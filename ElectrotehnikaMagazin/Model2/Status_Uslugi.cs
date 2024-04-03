namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Status_Uslugi")]
    public partial class Status_Uslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status_Uslugi()
        {
            Uslugi_Magazina = new HashSet<Uslugi_Magazina>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Statusa_Uslugi { get; set; }

        [Column("Status_Uslugi")]
        [Required]
        [StringLength(50)]
        public string Status_Uslugi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uslugi_Magazina> Uslugi_Magazina { get; set; }
    }
}
