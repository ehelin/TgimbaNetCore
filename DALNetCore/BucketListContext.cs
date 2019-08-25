using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DALNetCore.Models;
using Shared.misc;

namespace DALNetCore
{
    public partial class BucketListContext : DbContext
    {
        public BucketListContext()
        {
        }

        public BucketListContext(DbContextOptions<BucketListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BrowserCapability> BrowserCapability { get; set; }
        public virtual DbSet<BrowserLog> BrowserLog { get; set; }
        public virtual DbSet<BucketListItem> BucketListItem { get; set; }
        public virtual DbSet<BucketListUser> BucketListUser { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<SystemStatistics> SystemStatistics { get; set; }
        //public virtual DbSet<BuildStatistics> BuildStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Utilities.GetDbSetting());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BrowserCapability>(entity =>
            {
                entity.ToTable("BrowserCapability", "Bucket");

                entity.Property(e => e.Key)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tett)
                    .HasColumnName("tett")
                    .HasColumnType("text");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BrowserLog>(entity =>
            {
                entity.HasKey(e => e.BrowserLogId);

                entity.ToTable("BrowserLog", "Bucket");

                entity.Property(e => e.ActiveXcontrols).HasColumnName("ActiveXControls");

                entity.Property(e => e.Aol).HasColumnName("AOL");

                entity.Property(e => e.Browser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cdf).HasColumnName("CDF");

                entity.Property(e => e.ClrVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EcmaScriptVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GatewayVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InputType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JscriptVersion)
                    .HasColumnName("JScriptVersion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MinorVersionString)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileDeviceManufacturer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileDeviceModel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MsdomVersion)
                    .HasColumnName("MSDomVersion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfSoftkeys)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Platform)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredImageMime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredRenderingMime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredRenderingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredRequestEncoding)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredResponseEncoding)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequiredMetaTagNameValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequiresDbcscharacter).HasColumnName("RequiresDBCSCharacter");

                entity.Property(e => e.SupportsImodeSymbols).HasColumnName("SupportsIModeSymbols");

                entity.Property(e => e.SupportsInputIstyle).HasColumnName("SupportsInputIStyle");

                entity.Property(e => e.SupportsJphoneMultiMediaAttribute).HasColumnName("SupportsJPhoneMultiMediaAttribute");

                entity.Property(e => e.SupportsJphoneSymbols).HasColumnName("SupportsJPhoneSymbols");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vbscript).HasColumnName("VBScript");

                entity.Property(e => e.Version)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.W3cdomVersion)
                    .HasColumnName("W3CDomVersion")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BucketListItem>(entity =>
            {
                entity.ToTable("BucketListItem", "Bucket");

                entity.Property(e => e.Category).HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 10)");
            });

            modelBuilder.Entity<BucketListUser>(entity =>
            {
                entity.ToTable("BucketListUser", "Bucket");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log", "Bucket");

                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Bucket");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Token).HasMaxLength(1000);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });
        }
    }
}
