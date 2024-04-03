namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Sotrudniki")]
    public partial class Sotrudniki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudniki()
        {
            Dostavka_Zakaza = new HashSet<Dostavka_Zakaza>();
            Magazin_Elektrotehniki = new HashSet<Magazin_Elektrotehniki>();
            Otdely_Magazina = new HashSet<Otdely_Magazina>();
            Users = new HashSet<Users>();
            Uslugi_Magazina = new HashSet<Uslugi_Magazina>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Sotrudnika { get; set; }

        [Required]
        [StringLength(50)]
        public string Imya { get; set; }

        [Required]
        [StringLength(50)]
        public string Familiya { get; set; }

        [StringLength(50)]
        public string Otchestvo { get; set; }

        public int Doljnost { get; set; }

        public int Pol { get; set; }

        public int? Rol { get; set; }

        public virtual Doljnost_Sotrudnika Doljnost_Sotrudnika { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostavka_Zakaza> Dostavka_Zakaza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Magazin_Elektrotehniki> Magazin_Elektrotehniki { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otdely_Magazina> Otdely_Magazina { get; set; }

        public virtual Pol Pol1 { get; set; }

        public virtual Roly Roly { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uslugi_Magazina> Uslugi_Magazina { get; set; }
    }
}
