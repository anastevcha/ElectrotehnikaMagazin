namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Polzovately")]
    public partial class Polzovately
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iD_Polzovatelya { get; set; }

        [Required]
        [StringLength(50)]
        public string Imya_Polzovatelya { get; set; }

        [Required]
        [StringLength(100)]
        public string Parol { get; set; }

        public int Rol { get; set; }

        public virtual Roly Roly { get; set; }
    }
}
