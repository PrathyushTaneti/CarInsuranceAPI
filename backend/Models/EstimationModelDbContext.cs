using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeenFieldAPI.Models
{
    public partial class EstimationModelDbContext : DbContext
    {
        public EstimationModelDbContext()
        {
        }

        public EstimationModelDbContext(DbContextOptions<EstimationModelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerRecord> CustomerRecords { get; set; } = null!;
        public virtual DbSet<OtherLabourCost> OtherLabourCosts { get; set; } = null!;
        public virtual DbSet<PaintingCost> PaintingCosts { get; set; } = null!;
        public virtual DbSet<PartsCost> PartsCosts { get; set; } = null!;
        public virtual DbSet<RepairRefitCost> RepairRefitCosts { get; set; } = null!;
        public virtual DbSet<VehicleRecord> VehicleRecords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=EstimationModelDb; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRecord>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OtherLabourCost>(entity =>
            {
                entity.ToTable("OtherLabourCost");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.CarBodyPanel).HasMaxLength(255);
            });

            modelBuilder.Entity<PaintingCost>(entity =>
            {
                entity.ToTable("PaintingCost");

                entity.Property(e => e.PanelDescription).HasMaxLength(255);

                entity.Property(e => e.VehicleVariantCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartsCost>(entity =>
            {
                entity.ToTable("PartsCost");

                entity.Property(e => e.BodyPart).HasMaxLength(255);

                entity.Property(e => e.VehicleVariantCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RepairRefitCost>(entity =>
            {
                entity.ToTable("RepairRefitCost");

                entity.Property(e => e.BodyPart).HasMaxLength(255);

                entity.Property(e => e.VehicleTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleRecord>(entity =>
            {
                entity.Property(e => e.VehicleMake)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleMakeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleModelCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleVariant)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleVariantCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
