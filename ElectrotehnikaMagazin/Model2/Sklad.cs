namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Sklad")]
    public partial class Sklad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Sklada { get; set; }

        public int ID_Tovara { get; set; }

        public int Kolichestvo_Na_Sklade { get; set; }

        public virtual Tovary Tovary { get; set; }
    }
}
