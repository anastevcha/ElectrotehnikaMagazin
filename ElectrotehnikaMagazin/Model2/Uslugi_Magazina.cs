namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Uslugi_Magazina")]
    public partial class Uslugi_Magazina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Uslugi { get; set; }

        public int Vid_Uslugi { get; set; }

        public int ID_Sotrudnika { get; set; }

        public int ID_Zakaza { get; set; }

        public int Status_Uslugi { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }

        public virtual Status_Uslugi Status_Uslugi1 { get; set; }

        public virtual Zakazy Zakazy { get; set; }

        public virtual Vid_Uslugi Vid_Uslugi1 { get; set; }
    }
}
