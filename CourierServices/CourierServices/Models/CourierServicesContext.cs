using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CourierServices.Models
{
    public partial class CourierServicesContext : DbContext
    {
        public CourierServicesContext()
        {
        }

        public CourierServicesContext(DbContextOptions<CourierServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Couriers> Couriers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Shipments> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JKA7ODF;Initial Catalog=CourierServices;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Couriers>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobPossition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ShipmentNumberNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ShipmentNumber)
                    .HasConstraintName("FK_CustomerShipment");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK__History__Shipmen__2E1BDC42");
            });

            modelBuilder.Entity<Shipments>(entity =>
            {
                entity.Property(e => e.FromAddress)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToAddress)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CourierId)
                    .HasConstraintName("FK__Shipments__Couri__2A4B4B5E");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.ShipmentsReceiverNavigation)
                    .HasForeignKey(d => d.Receiver)
                    .HasConstraintName("FK__Shipments__Recei__29572725");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.ShipmentsSenderNavigation)
                    .HasForeignKey(d => d.Sender)
                    .HasConstraintName("FK__Shipments__Sende__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
