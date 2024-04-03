namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Oplata")]
    public partial class Oplata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Oplaty { get; set; }

        public int ID_Zakaza { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Oplaty { get; set; }

        public int Tip_Oplaty { get; set; }

        public virtual Zakazy Zakazy { get; set; }

        public virtual Tip_Oplaty Tip_Oplaty1 { get; set; }
    }
}
