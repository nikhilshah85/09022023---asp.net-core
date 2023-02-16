using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_DevelopmentDemo.Models.EF;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deptinfo> Deptinfos { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=employeeDB;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deptinfo>(entity =>
        {
            entity.HasKey(e => e.DNo).HasName("PK__deptinfo__D8770CC491F04125");

            entity.ToTable("deptinfo");

            entity.Property(e => e.DNo)
                .ValueGeneratedNever()
                .HasColumnName("dNo");
            entity.Property(e => e.DEmail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dEmail");
            entity.Property(e => e.DLocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dLocation");
            entity.Property(e => e.DName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dName");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__employee__AFB3359277CE2F51");

            entity.ToTable("employeeDetails");

            entity.Property(e => e.EmpNo)
                .ValueGeneratedNever()
                .HasColumnName("empNo");
            entity.Property(e => e.Dept).HasColumnName("dept");
            entity.Property(e => e.EmpDesigantion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empDesigantion");
            entity.Property(e => e.EmpIsPermenant).HasColumnName("empIsPermenant");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary).HasColumnName("empSalary");

            entity.HasOne(d => d.DeptNavigation).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.Dept)
                .HasConstraintName("fk_dept");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
