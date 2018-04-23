namespace RADProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VehicleModel : DbContext
    {
        public VehicleModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<RADProject.Models.Make> Makes { get; set; }

        public System.Data.Entity.DbSet<RADProject.Models.Model> Models { get; set; }

        public System.Data.Entity.DbSet<RADProject.Models.VehicleType> VehicleTypes { get; set; }
    }
}
