namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Magazin_Elektrotehniki")]
    public partial class Magazin_Elektrotehniki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Magazina { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazvanie { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }

        public decimal Kontaktnye_Dannye { get; set; }

        public int ID_Directora { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
