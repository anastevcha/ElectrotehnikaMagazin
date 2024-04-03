namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Otzyvy")]
    public partial class Otzyvy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Otzyva { get; set; }

        public int ID_Klienta { get; set; }

        [Required]
        [StringLength(250)]
        public string Tekst_Otzyva { get; set; }

        public int Reyting { get; set; }

        public virtual Klienty Klienty { get; set; }
    }
}
