using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cs_Api.Models
{
    public partial class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext()
        {
        }

        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPay> TblPays { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblSale> TblSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source= localhost;Initial Catalog=CoffeeShopDb; User ID=sa;Password=Rootkg12%");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
