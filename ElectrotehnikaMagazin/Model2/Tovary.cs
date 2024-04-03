namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Tovary")]
    public partial class Tovary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovary()
        {
            Skidki = new HashSet<Skidki>();
            Sklad = new HashSet<Sklad>();
            Zakaz_Tovara_Na_Sklad = new HashSet<Zakaz_Tovara_Na_Sklad>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Tovara { get; set; }

        [Required]
        [StringLength(100)]
        public string Naimenovanie_Tovara { get; set; }

        [Required]
        [StringLength(200)]
        public string Opisanie_Tovara { get; set; }

        public int Kategoriya_Tovara { get; set; }

        public virtual Kategorii_Tovarov Kategorii_Tovarov { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skidki> Skidki { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sklad> Sklad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakaz_Tovara_Na_Sklad> Zakaz_Tovara_Na_Sklad { get; set; }
    }
}
