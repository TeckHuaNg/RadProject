namespace RADProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Data : DbContext
    {
        public Data()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>()
                .Property(e => e.makeName)
                .IsUnicode(false);

            modelBuilder.Entity<Make>()
                .HasMany(e => e.Vehicles)
                .WithRequired(e => e.Make)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.EngineSize)
                .HasPrecision(2, 1);

            modelBuilder.Entity<Model>()
                .Property(e => e.Colour)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Vehicles)
                .WithRequired(e => e.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.typeName)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.Models)
                .WithRequired(e => e.VehicleType)
                .WillCascadeOnDelete(false);
        }
    }
}
