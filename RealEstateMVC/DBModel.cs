namespace RealEstateMVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<features> features { get; set; }
        public virtual DbSet<properties> properties { get; set; }
        public virtual DbSet<rooms> rooms { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<features>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<features>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<properties>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<properties>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<properties>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<properties>()
                .Property(e => e.built_year)
                .IsUnicode(false);

            modelBuilder.Entity<properties>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<rooms>()
                .Property(e => e.property_id)
                .IsFixedLength();

            modelBuilder.Entity<rooms>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<rooms>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.birth_date)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
