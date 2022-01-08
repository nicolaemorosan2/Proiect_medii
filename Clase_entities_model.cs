using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Clase
{
    public partial class Clase_entities_model : DbContext
    {
        public Clase_entities_model()
            : base("name=Clase_entities_model")
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Courts> Courts { get; set; }
        //public object Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
