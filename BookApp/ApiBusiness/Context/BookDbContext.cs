using System;
using Microsoft.EntityFrameworkCore;
using ApiBusiness.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiBusiness.Context
{
    public partial class BookDbContext : DbContext
    {
        public BookDbContext()
        {
        }

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<PurchaseInvoiceDt> PurchaseInvoiceDt { get; set; }
        public virtual DbSet<PurchaseInvoiceHd> PurchaseInvoiceHd { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(e => e.ItemCategoryCode);

                entity.Property(e => e.ItemCategoryCode).HasMaxLength(10);

                entity.Property(e => e.ItemCategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseInvoiceDt>(entity =>
            {
                entity.HasKey(e => e.PurchaseInvoiceDtCode);

                entity.Property(e => e.PurchaseInvoiceDtCode).HasMaxLength(20);

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ItemCategory)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PurchaseInvoiceCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PurchaseInvoiceExt1).HasMaxLength(50);

                entity.Property(e => e.PurchaseInvoiceExt2).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.PurchaseInvoiceCodeNavigation)
                    .WithMany(p => p.PurchaseInvoiceDt)
                    .HasForeignKey(d => d.PurchaseInvoiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoiceHd_PurchaseInvoiceDt");
            });

            modelBuilder.Entity<PurchaseInvoiceHd>(entity =>
            {
                entity.HasKey(e => e.PurchaseInvoiceCode);

                entity.Property(e => e.PurchaseInvoiceCode).HasMaxLength(20);

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.PurchaseInvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.PurchaseInvoiceExt1).HasMaxLength(50);

                entity.Property(e => e.PurchaseInvoiceExt2).HasMaxLength(50);

                entity.Property(e => e.StatusApprove).HasComment("9 : Unapprove 10:Approve 15: Void");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
