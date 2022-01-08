namespace Clase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Appointments { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Ora_inceput { get; set; }

        public int Ora_sfarsit { get; set; }

        public int Id_Clients { get; set; }

        public int Id_Courts { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Courts Courts { get; set; }
    }
}
