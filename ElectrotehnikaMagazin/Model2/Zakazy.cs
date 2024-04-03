namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Zakazy")]
    public partial class Zakazy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zakazy()
        {
            Dostavka_Zakaza = new HashSet<Dostavka_Zakaza>();
            Oplata = new HashSet<Oplata>();
            Uslugi_Magazina = new HashSet<Uslugi_Magazina>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Zakaza { get; set; }

        public int ID_Tovara { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Zakaza { get; set; }

        public int Status_Zakaza { get; set; }

        public int ID_Klienta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostavka_Zakaza> Dostavka_Zakaza { get; set; }

        public virtual Klienty Klienty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oplata> Oplata { get; set; }

        public virtual Status_Zakaza Status_Zakaza1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uslugi_Magazina> Uslugi_Magazina { get; set; }
    }
}
