namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Skidki")]
    public partial class Skidki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Skidki { get; set; }

        public int ID_Tovara { get; set; }

        [Column("Razmer_Skidki(procenty)")]
        public int Razmer_Skidki_procenty_ { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Nachala { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Konca { get; set; }

        public virtual Tovary Tovary { get; set; }
    }
}
