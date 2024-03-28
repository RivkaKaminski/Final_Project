//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace HealthFundCoronaSystemServer.Models
//{
//    public partial class HealthFundCoronaSystemDBContext : DbContext
//    {
//        public HealthFundCoronaSystemDBContext()
//        {
//        }

//        public HealthFundCoronaSystemDBContext(DbContextOptions<HealthFundCoronaSystemDBContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<CoronaStatus> CoronaStatuses { get; set; } = null!;
//        public virtual DbSet<DailyActivatePatient> DailyActivatePatients { get; set; } = null!;
//        public virtual DbSet<Member> Members { get; set; } = null!;
//        public virtual DbSet<MemberPhoto> MemberPhotos { get; set; } = null!;
//        public virtual DbSet<Vaccination> Vaccinations { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-UBNVF4F\\SQLEXPRESS;Database = HealthFundCoronaSystemDB;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<CoronaStatus>(entity =>
//            {
//                entity.ToTable("CoronaStatus");

//                entity.HasIndex(e => e.CoronaStatusId, "IX_CoronaStatus");

//                entity.Property(e => e.CoronaStatusId).HasColumnName("corona_status_id");

//                entity.Property(e => e.MemberId).HasColumnName("member_id");

//                entity.Property(e => e.PositiveResultDate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("positive_result_date");

//                entity.Property(e => e.RecoveryDate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("recovery_date");

//                entity.HasOne(d => d.Member)
//                    .WithMany(p => p.CoronaStatuses)
//                    .HasForeignKey(d => d.MemberId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_CoronaStatus_Members");
//            });

//            modelBuilder.Entity<DailyActivatePatient>(entity =>
//            {
//                entity.HasKey(e => e.Date);

//                entity.Property(e => e.Date)
//                    .HasColumnType("datetime")
//                    .HasColumnName("date");

//                entity.Property(e => e.ActivePatientCount).HasColumnName("active_patient_count");
//            });

//            modelBuilder.Entity<Member>(entity =>
//            {
//                entity.Property(e => e.MemberId).HasColumnName("member_id");

//                entity.Property(e => e.City)
//                    .HasMaxLength(15)
//                    .HasColumnName("city")
//                    .IsFixedLength();

//                entity.Property(e => e.DateOfBirth)
//                    .HasColumnType("datetime")
//                    .HasColumnName("date_of_birth");

//                entity.Property(e => e.Email)
//                    .HasMaxLength(30)
//                    .HasColumnName("email")
//                    .IsFixedLength();

//                entity.Property(e => e.FirstName)
//                    .HasMaxLength(15)
//                    .HasColumnName("first_name")
//                    .IsFixedLength();

//                entity.Property(e => e.IdentityCard)
//                    .HasMaxLength(10)
//                    .HasColumnName("identity_card")
//                    .IsFixedLength();

//                entity.Property(e => e.LastName)
//                    .HasMaxLength(10)
//                    .HasColumnName("last_name")
//                    .IsFixedLength();

//                entity.Property(e => e.MobilePhone)
//                    .HasMaxLength(10)
//                    .HasColumnName("mobile_phone")
//                    .IsFixedLength();

//                entity.Property(e => e.Street)
//                    .HasMaxLength(10)
//                    .HasColumnName("street")
//                    .IsFixedLength();

//                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

//                entity.Property(e => e.Telephone)
//                    .HasMaxLength(10)
//                    .HasColumnName("telephone")
//                    .IsFixedLength();
//            });

//            modelBuilder.Entity<MemberPhoto>(entity =>
//            {
//                entity.HasKey(e => e.PhotoId);

//                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

//                entity.Property(e => e.MemberId).HasColumnName("member_id");

//                entity.Property(e => e.PhotoUrl)
//                    .HasMaxLength(20)
//                    .HasColumnName("photo_url")
//                    .IsFixedLength();

//                entity.HasOne(d => d.Member)
//                    .WithMany(p => p.MemberPhotos)
//                    .HasForeignKey(d => d.MemberId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_MemberPhotos_Members");
//            });

//            modelBuilder.Entity<Vaccination>(entity =>
//            {
//                entity.Property(e => e.VaccinationId).HasColumnName("vaccination_id");

//                entity.Property(e => e.MemberId).HasColumnName("member_id");

//                entity.Property(e => e.VaccineDate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("vaccine_date");

//                entity.Property(e => e.VaccineManufactor)
//                    .HasMaxLength(15)
//                    .HasColumnName("vaccine_manufactor")
//                    .IsFixedLength();

//                entity.HasOne(d => d.Member)
//                    .WithMany(p => p.Vaccinations)
//                    .HasForeignKey(d => d.MemberId)
//                    .HasConstraintName("FK_Vaccinations_Members");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
