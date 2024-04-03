namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Postavshiki")]
    public partial class Postavshiki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postavshiki()
        {
            Zakaz_Tovara_Na_Sklad = new HashSet<Zakaz_Tovara_Na_Sklad>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Postavshika { get; set; }

        [Required]
        [StringLength(50)]
        public string Naimenovanie { get; set; }

        [Required]
        [StringLength(50)]
        public string Contaktnye_Dannye { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakaz_Tovara_Na_Sklad> Zakaz_Tovara_Na_Sklad { get; set; }
    }
}
