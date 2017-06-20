using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class StockDbContext : DbContext
    {
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<DataSource> DataSource { get; set; }
        public virtual DbSet<ImportData> ImportData { get; set; }
        public virtual DbSet<Interval> Interval { get; set; }
        public virtual DbSet<Symbol> Symbol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"data source=LENOVO-PC;initial catalog=StockDb;persist security info=True;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;App=adshost");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Interval>(entity =>
            {
                entity.Property(e => e.Days)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/(((CONVERT([float],(24))*(60))*(60))*(10000000))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Hours)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/((CONVERT([float],(60))*(60))*(10000000))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Minutes)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/((60)*(10000000))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Months)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/((((CONVERT([float],(30))*(24))*(60))*(60))*(10000000))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Seconds)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/(10000000)")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Weeks)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/((((CONVERT([float],(7))*(24))*(60))*(60))*(10000000))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Years)
                    .HasComputedColumnSql("CONVERT([float],[TimeSpan])/((((CONVERT([float],(365))*(24))*(60))*(60))*(10000000))")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Symbol>(entity =>
            {
                entity.HasIndex(e => new { e.Lcurr, e.Rcurr })
                    .HasName("UK_Symbol_LCurr_RCurr")
                    .IsUnique();
            });
        }
    }
}