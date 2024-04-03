namespace ElectrotehnikaMagazin.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Razresheniya")]
    public partial class Razresheniya
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Razresheniya { get; set; }

        public int Rol { get; set; }

        public int Operaciya { get; set; }

        public virtual Operacii Operacii { get; set; }

        public virtual Roly Roly { get; set; }
    }
}
