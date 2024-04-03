namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Dostavka_Zakaza")]
    public partial class Dostavka_Zakaza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Dostavki { get; set; }

        public int ID_Zakaza { get; set; }

        public int ID_Sotrudnika { get; set; }

        [Required]
        [StringLength(100)]
        public string Adres_Dostavki { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }

        public virtual Zakazy Zakazy { get; set; }
    }
}
