namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Otdely_Magazina")]
    public partial class Otdely_Magazina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Otdela { get; set; }

        [Required]
        [StringLength(50)]
        public string Naimenovanie_Otdela { get; set; }

        public int ID_Menedjera { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
