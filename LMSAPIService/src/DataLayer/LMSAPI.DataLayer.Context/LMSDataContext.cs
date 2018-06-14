using LMSAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSAPI.DataLayer
{
    public class LMSDataContext : DbContext, ILMSContext
    {
        protected IConfiguration _configuration;

        public DbSet<LeaveBalanceEntity> LeaveBalance { get; set; }
        public DbSet<LeaveStatusMasterEntity> LeaveStatusMaster { get; set; }
        public DbSet<LeaveTypeMasterEntity> LeaveTypeMaster { get; set; }
        public DbSet<ManageLeaveTransactionEntity> ManageLeaveTransaction { get; set; }
        public DbSet<UserMasterEntity> UserMaster { get; set; }
        public DbSet<YearMasterEntity> YearMaster { get; set; }

        public LMSDataContext(IConfiguration configuration, DbContextOptions<LMSDataContext> options) : base(options)
        {
            _configuration = configuration;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=tcp:lmsdata.database.windows.net,1433;Initial Catalog=LMSData;Persist Security Info=False;User ID=rupalim;Password=Meena@2604;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //        //optionsBuilder.UseSqlServer(_configuration["Data:DefaultConnection:ConnectionString"]);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveBalanceEntity>(entity =>
            {
                entity.HasKey(e => e.PkLeaveBalance);

                entity.Property(e => e.PkLeaveBalance).HasColumnName("pkLeaveBalance");

                entity.Property(e => e.BActive).HasColumnName("bActive");

                entity.Property(e => e.DtAdded)
                    .HasColumnName("dtAdded")
                    .HasColumnType("date");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dtUpdated")
                    .HasColumnType("date");

                entity.Property(e => e.FkLeaveType).HasColumnName("fkLeaveType");

                entity.Property(e => e.FkUser).HasColumnName("fkUser");

                entity.Property(e => e.FkYear).HasColumnName("fkYear");

                entity.Property(e => e.NLeaveBalance)
                    .HasColumnName("nLeaveBalance")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.NLeaveConsumed)
                    .HasColumnName("nLeaveConsumed")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.NLeaveCredit)
                    .HasColumnName("nLeaveCredit")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.SAddedBy)
                    .HasColumnName("sAddedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SUpdatedBy)
                    .HasColumnName("sUpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkLeaveTypeNavigation)
                    .WithMany(p => p.LeaveBalance)
                    .HasForeignKey(d => d.FkLeaveType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveBala__fkLea__1920BF5C");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.LeaveBalance)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveBala__fkUse__1A14E395");

                entity.HasOne(d => d.FkYearNavigation)
                    .WithMany(p => p.LeaveBalance)
                    .HasForeignKey(d => d.FkYear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaveBala__fkYea__1B0907CE");
            });

            modelBuilder.Entity<LeaveStatusMasterEntity>(entity =>
            {
                entity.HasKey(e => e.PkLeaveStatus);

                entity.Property(e => e.PkLeaveStatus).HasColumnName("pkLeaveStatus");

                entity.Property(e => e.BActive).HasColumnName("bActive");

                entity.Property(e => e.DtAdded)
                    .HasColumnName("dtAdded")
                    .HasColumnType("date");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dtUpdated")
                    .HasColumnType("date");

                entity.Property(e => e.SAddedBy)
                    .HasColumnName("sAddedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SLeaveStatus)
                    .HasColumnName("sLeaveStatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SUpdatedBy)
                    .HasColumnName("sUpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeaveTypeMasterEntity>(entity =>
            {
                entity.HasKey(e => e.PkLeaveType);

                entity.Property(e => e.PkLeaveType).HasColumnName("pkLeaveType");

                entity.Property(e => e.BActive).HasColumnName("bActive");

                entity.Property(e => e.DtAdded)
                    .HasColumnName("dtAdded")
                    .HasColumnType("date");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dtUpdated")
                    .HasColumnType("date");

                entity.Property(e => e.SAddedBy)
                    .HasColumnName("sAddedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SLeaveType)
                    .HasColumnName("sLeaveType")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SUpdatedBy)
                    .HasColumnName("sUpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManageLeaveTransactionEntity>(entity =>
            {
                entity.HasKey(e => e.PkManageleave);

                entity.Property(e => e.PkManageleave).HasColumnName("pkManageleave");

                entity.Property(e => e.BActive).HasColumnName("bActive");

                entity.Property(e => e.DtAdded)
                    .HasColumnName("dtAdded")
                    .HasColumnType("date");

                entity.Property(e => e.DtLeaveFrom)
                    .HasColumnName("dtLeaveFrom")
                    .HasColumnType("date");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dtUpdated")
                    .HasColumnType("date");

                entity.Property(e => e.DtleaveTo)
                    .HasColumnName("dtleaveTo")
                    .HasColumnType("date");

                entity.Property(e => e.FkLeaveStatus).HasColumnName("fkLeaveStatus");

                entity.Property(e => e.FkUser).HasColumnName("fkUser");

                entity.Property(e => e.FkYear).HasColumnName("fkYear");

                entity.Property(e => e.SAddedBy)
                    .HasColumnName("sAddedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SApprovedBy)
                    .HasColumnName("sApprovedBy")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.SUpdatedBy)
                    .HasColumnName("sUpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveReason).HasColumnName("sLeaveReason");

                entity.Property(e => e.LeaveDaysCount).HasColumnName("iLeaveDaysCount");

                entity.Property(e => e.FkLeaveType).HasColumnName("fkLeaveType");

                entity.HasOne(d => d.FkLeaveStatusNavigation)
                    .WithMany(p => p.ManageLeaveTransaction)
                    .HasForeignKey(d => d.FkLeaveStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ManageLea__fkLea__21B6055D");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.ManageLeaveTransaction)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ManageLea__fkUse__1FCDBCEB");

                entity.HasOne(d => d.FkYearNavigation)
                    .WithMany(p => p.ManageLeaveTransaction)
                    .HasForeignKey(d => d.FkYear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ManageLea__fkYea__20C1E124");

                entity.HasOne(d => d.FkLeaveTypeNavigation)
                   .WithMany(p => p.ManageLeaveTransaction)
                   .HasForeignKey(d => d.FkLeaveType)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_LeaveTYpe");
            });

            modelBuilder.Entity<UserMasterEntity>(entity =>
            {
                entity.HasKey(e => e.PkUser);

                entity.Property(e => e.PkUser).HasColumnName("pkUser");

                entity.Property(e => e.BActive).HasColumnName("bActive");

                entity.Property(e => e.DtAdded)
                    .HasColumnName("dtAdded")
                    .HasColumnType("date");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dtUpdated")
                    .HasColumnType("date");

                entity.Property(e => e.SAddedBy)
                    .HasColumnName("sAddedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SPassword)
                    .HasColumnName("sPassword")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SUpdatedBy)
                    .HasColumnName("sUpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SUserName)
                    .HasColumnName("sUserName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<YearMasterEntity>(entity =>
            {
                entity.HasKey(e => e.PkYear);

                entity.Property(e => e.PkYear).HasColumnName("pkYear");

                entity.Property(e => e.BActive).HasColumnName("bActive");

                entity.Property(e => e.DtAdded)
                    .HasColumnName("dtAdded")
                    .HasColumnType("date");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dtUpdated")
                    .HasColumnType("date");

                entity.Property(e => e.SAddedBy)
                    .HasColumnName("sAddedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SUpdatedBy)
                    .HasColumnName("sUpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SYearCode)
                    .HasColumnName("sYearCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SYearEnd)
                    .HasColumnName("sYearEnd")
                    .HasColumnType("date");

                entity.Property(e => e.SYearStart)
                    .HasColumnName("sYearStart")
                    .HasColumnType("date");
            });
        }
    }
}
