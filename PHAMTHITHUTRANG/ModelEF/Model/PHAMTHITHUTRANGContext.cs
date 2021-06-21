namespace ModelEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PHAMTHITHUTRANGContext : DbContext
    {
        public PHAMTHITHUTRANGContext()
            : base("name=PHAMTHITHUTRANGContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CategoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
