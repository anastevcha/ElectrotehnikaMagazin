namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Vid_Uslugi")]
    public partial class Vid_Uslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vid_Uslugi()
        {
            Uslugi_Magazina = new HashSet<Uslugi_Magazina>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Vida_Uslugi { get; set; }

        [Column("Vid_Uslugi")]
        [Required]
        [StringLength(100)]
        public string Vid_Uslugi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uslugi_Magazina> Uslugi_Magazina { get; set; }
    }
}
