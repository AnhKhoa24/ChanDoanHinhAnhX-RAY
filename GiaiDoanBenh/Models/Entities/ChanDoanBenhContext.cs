using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GiaiDoanBenh.Models.Entities;

public partial class ChanDoanBenhContext : DbContext
{
    public ChanDoanBenhContext()
    {
    }

    public ChanDoanBenhContext(DbContextOptions<ChanDoanBenhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BenhNhan> BenhNhans { get; set; }

    public virtual DbSet<ChanDoan> ChanDoans { get; set; }

    public virtual DbSet<HinhAnh> HinhAnhs { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<ShareLichSu> ShareLichSus { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BenhNhan>(entity =>
        {
            entity.ToTable("BenhNhan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cccd)
                .HasMaxLength(18)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(250);
            entity.Property(e => e.MaBenhNhan).HasMaxLength(50);
            entity.Property(e => e.TenBenhNhan).HasMaxLength(50);
        });

        modelBuilder.Entity<ChanDoan>(entity =>
        {
            entity.ToTable("ChanDoan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdbacSiChanDoan).HasColumnName("IDBacSiChanDoan");
            entity.Property(e => e.IdbenhNhan).HasColumnName("IDBenhNhan");
            entity.Property(e => e.KetQua).HasMaxLength(250);
            entity.Property(e => e.NgayChanDoan).HasColumnType("datetime");

            entity.HasOne(d => d.IdbacSiChanDoanNavigation).WithMany(p => p.ChanDoans)
                .HasForeignKey(d => d.IdbacSiChanDoan)
                .HasConstraintName("FK_ChanDoan_NhanVien");

            entity.HasOne(d => d.IdbenhNhanNavigation).WithMany(p => p.ChanDoans)
                .HasForeignKey(d => d.IdbenhNhan)
                .HasConstraintName("FK_ChanDoan_BenhNhan");
        });

        modelBuilder.Entity<HinhAnh>(entity =>
        {
            entity.ToTable("HinhAnh");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdChanDoan).HasColumnName("idChanDoan");
            entity.Property(e => e.LinkHinhAnh).HasMaxLength(250);
            entity.Property(e => e.NgayChup).HasColumnType("datetime");

            entity.HasOne(d => d.IdChanDoanNavigation).WithMany(p => p.HinhAnhs)
                .HasForeignKey(d => d.IdChanDoan)
                .HasConstraintName("FK_HinhAnh_ChanDoan");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.ToTable("Khoa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.ToTable("NhanVien");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .HasColumnName("CCCD");
            entity.Property(e => e.DienThoai).HasMaxLength(12);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);

            entity.HasOne(d => d.MaVaiTroNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaVaiTro)
                .HasConstraintName("FK_NhanVien_VaiTro");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.ToTable("Phong");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMaKhoa).HasColumnName("idMaKhoa");
            entity.Property(e => e.TenPhong).HasMaxLength(50);

            entity.HasOne(d => d.IdMaKhoaNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdMaKhoa)
                .HasConstraintName("FK_Phong_Khoa");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.ToTable("Quyen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
        });

        modelBuilder.Entity<ShareLichSu>(entity =>
        {
            entity.ToTable("ShareLichSu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBacSiChiaSe).HasColumnName("idBacSiChiaSe");
            entity.Property(e => e.IdBacSiNhan).HasColumnName("idBacSiNhan");
            entity.Property(e => e.IdChanDoan).HasColumnName("idChanDoan");

            entity.HasOne(d => d.IdBacSiChiaSeNavigation).WithMany(p => p.ShareLichSuIdBacSiChiaSeNavigations)
                .HasForeignKey(d => d.IdBacSiChiaSe)
                .HasConstraintName("FK_ShareLichSu_NhanVien");

            entity.HasOne(d => d.IdBacSiNhanNavigation).WithMany(p => p.ShareLichSuIdBacSiNhanNavigations)
                .HasForeignKey(d => d.IdBacSiNhan)
                .HasConstraintName("FK_ShareLichSu_NhanVien1");

            entity.HasOne(d => d.IdChanDoanNavigation).WithMany(p => p.ShareLichSus)
                .HasForeignKey(d => d.IdChanDoan)
                .HasConstraintName("FK_ShareLichSu_ChanDoan");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdNhanVien).HasColumnName("idNhanVien");
            entity.Property(e => e.IdQuyen).HasColumnName("idQuyen");
            entity.Property(e => e.MatKhau).HasMaxLength(250);
            entity.Property(e => e.TenTaiKhoan).HasMaxLength(50);

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK_TaiKhoan_NhanVien");

            entity.HasOne(d => d.IdQuyenNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdQuyen)
                .HasConstraintName("FK_TaiKhoan_Quyen");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.ToTable("VaiTro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPhong).HasColumnName("idPhong");
            entity.Property(e => e.TenVaiTro).HasMaxLength(50);

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.VaiTros)
                .HasForeignKey(d => d.IdPhong)
                .HasConstraintName("FK_VaiTro_Phong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
