namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Klienty")]
    public partial class Klienty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klienty()
        {
            Otzyvy = new HashSet<Otzyvy>();
            Zakazy = new HashSet<Zakazy>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Klienta { get; set; }

        [Required]
        [StringLength(50)]
        public string Imya { get; set; }

        [Required]
        [StringLength(50)]
        public string Familiya { get; set; }

        [StringLength(50)]
        public string Otchestvo { get; set; }

        public decimal Kontaktnye_dannye { get; set; }

        public int Pol { get; set; }

        public virtual Pol Pol1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otzyvy> Otzyvy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakazy> Zakazy { get; set; }
    }
}
