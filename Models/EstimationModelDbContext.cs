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

        public virtual DbSet<CustomerTable> CustomerTables { get; set; } = null!;
        public virtual DbSet<OtherLabour> OtherLabours { get; set; } = null!;
        public virtual DbSet<PaintingLabour> PaintingLabours { get; set; } = null!;
        public virtual DbSet<PartsCost> PartsCosts { get; set; } = null!;
        public virtual DbSet<RrLabour> RrLabours { get; set; } = null!;
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
            modelBuilder.Entity<CustomerTable>(entity =>
            {
                entity.ToTable("CustomerTable");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OtherLabour>(entity =>
            {
                entity.ToTable("OtherLabour");

                entity.Property(e => e.CarBodyPanel).HasMaxLength(255);
            });

            modelBuilder.Entity<PaintingLabour>(entity =>
            {
                entity.ToTable("PaintingLabour");

               entity.Property(e => e.PanelDescription).HasMaxLength(255);

                entity.Property(e => e.VehicleVariantCode).HasMaxLength(10);

                entity.Property(e => e.Expense);                             

               
            });

            modelBuilder.Entity<PartsCost>(entity =>
            {
                entity.ToTable("PartsCost");

                entity.Property(e => e.Alto800Lxi).HasColumnName("Alto800LXI");

                entity.Property(e => e.Alto800Std).HasColumnName("Alto800STD");

                entity.Property(e => e.Alto800Vxi).HasColumnName("Alto800VXI");

                entity.Property(e => e.AltoK10lx).HasColumnName("AltoK10LX");

                entity.Property(e => e.AltoK10lxi).HasColumnName("AltoK10LXI");

                entity.Property(e => e.AltoK10vsi).HasColumnName("AltoK10VSI");

                entity.Property(e => e.AltoK10vxi).HasColumnName("AltoK10VXI ");

                entity.Property(e => e.BodyPart).HasMaxLength(255);

                entity.Property(e => e.SwiftDzireLxi).HasColumnName("SwiftDzireLXI");

                entity.Property(e => e.SwiftDzireVxi).HasColumnName("SwiftDzireVXI");

                entity.Property(e => e.SwiftDzireZxi).HasColumnName("SwiftDzireZXI");

                entity.Property(e => e.SwiftLxi).HasColumnName("SwiftLXI");

                entity.Property(e => e.SwiftVxi).HasColumnName("SwiftVXI");

                entity.Property(e => e.SwiftZxi).HasColumnName("SwiftZXI");

                entity.Property(e => e.WagonRlxi).HasColumnName("WagonRLXI");

                entity.Property(e => e.WagonRvxi).HasColumnName("WagonRVXI");

                entity.Property(e => e.WagonRzxi).HasColumnName("WagonRZXI");

                entity.Property(e => e.VehicleVariantCode).HasMaxLength(255);

            });

            modelBuilder.Entity<RrLabour>(entity =>
            {
                entity.ToTable("RrLabour");

                entity.Property(e => e.BodyPart).HasMaxLength(255);

            });

            modelBuilder.Entity<VehicleRecord>(entity =>
            {
                entity.ToTable("VehicleRecord");
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

                entity.Property(e => e.VehicleVariant)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleVariantCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleTypeCode)
                  .HasMaxLength(8)
                  .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
