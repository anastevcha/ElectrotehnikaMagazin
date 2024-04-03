namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Zakaz_Tovara_Na_Sklad")]
    public partial class Zakaz_Tovara_Na_Sklad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Zakaza_Na_Sklad { get; set; }

        public int ID_Postavshika { get; set; }

        public int ID_Tovara { get; set; }

        public int Kolichestvo_Tovara { get; set; }

        public virtual Postavshiki Postavshiki { get; set; }

        public virtual Tovary Tovary { get; set; }
    }
}
