using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Repositories.Entities;

public partial class KoiPondDbContext : DbContext
{
    public KoiPondDbContext()
    {
    }

    public KoiPondDbContext(DbContextOptions<KoiPondDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DuAnThiCong> DuAnThiCongs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienThamGium> NhanVienThamGia { get; set; }

    public virtual DbSet<TaiKhoanKhachHang> TaiKhoanKhachHangs { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<TienDoThiCong> TienDoThiCongs { get; set; }

    public virtual DbSet<VatLieu> VatLieus { get; set; }

    public virtual DbSet<VatLieuSuDung> VatLieuSuDungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=KoiPondDB;Integrated Security=True;User iD=sa;Password=12345678;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DuAnThiCong>(entity =>
        {
            entity.HasKey(e => e.DuAnId).HasName("PK__DuAnThiC__2007B3CB3B15EB71");

            entity.ToTable("DuAnThiCong");

            entity.Property(e => e.DuAnId)
                .HasMaxLength(50)
                .HasColumnName("DuAnID");
            entity.Property(e => e.DiaDiem).HasMaxLength(255);
            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("KhachHangID");
            entity.Property(e => e.TenDuAn).HasMaxLength(100);
            entity.Property(e => e.TongChiPhi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.KhachHang).WithMany(p => p.DuAnThiCongs)
                .HasForeignKey(d => d.KhachHangId)
                .HasConstraintName("FK__DuAnThiCo__Khach__398D8EEE");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.KhachHangId).HasName("PK__KhachHan__880F211B46E27F94");

            entity.ToTable("KhachHang");

            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("KhachHangID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.NhanVienId).HasName("PK__NhanVien__E27FD7EAE413CC0B");

            entity.ToTable("NhanVien");

            entity.Property(e => e.NhanVienId)
                .HasMaxLength(50)
                .HasColumnName("NhanVienID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ViTri).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVienThamGium>(entity =>
        {
            entity.HasKey(e => e.ThamGiaId).HasName("PK__NhanVien__658978BC141640F2");

            entity.Property(e => e.ThamGiaId)
                .HasMaxLength(50)
                .HasColumnName("ThamGiaID");
            entity.Property(e => e.DuAnId)
                .HasMaxLength(50)
                .HasColumnName("DuAnID");
            entity.Property(e => e.NhanVienId)
                .HasMaxLength(50)
                .HasColumnName("NhanVienID");

            entity.HasOne(d => d.DuAn).WithMany(p => p.NhanVienThamGia)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__NhanVienT__DuAnI__46E78A0C");

            entity.HasOne(d => d.NhanVien).WithMany(p => p.NhanVienThamGia)
                .HasForeignKey(d => d.NhanVienId)
                .HasConstraintName("FK__NhanVienT__NhanV__47DBAE45");
        });

        modelBuilder.Entity<TaiKhoanKhachHang>(entity =>
        {
            entity.HasKey(e => e.TaiKhoanId).HasName("PK__TaiKhoan__9A124B65C6CC826B");

            entity.ToTable("TaiKhoanKhachHang");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0CF73F7B0").IsUnique();

            entity.Property(e => e.TaiKhoanId)
                .HasMaxLength(50)
                .HasColumnName("TaiKhoanID");
            entity.Property(e => e.KhachHangId)
                .HasMaxLength(50)
                .HasColumnName("KhachHangID");
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.KhachHang).WithMany(p => p.TaiKhoanKhachHangs)
                .HasForeignKey(d => d.KhachHangId)
                .HasConstraintName("FK__TaiKhoanK__Khach__4E88ABD4");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.ThanhToanId).HasName("PK__ThanhToa__24A8D6849639F247");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.ThanhToanId)
                .HasMaxLength(50)
                .HasColumnName("ThanhToanID");
            entity.Property(e => e.DuAnId)
                .HasMaxLength(50)
                .HasColumnName("DuAnID");
            entity.Property(e => e.HinhThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.DuAn).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__ThanhToan__DuAnI__4AB81AF0");
        });

        modelBuilder.Entity<TienDoThiCong>(entity =>
        {
            entity.HasKey(e => e.TienDoId).HasName("PK__TienDoTh__BC6176415174EB21");

            entity.ToTable("TienDoThiCong");

            entity.Property(e => e.TienDoId)
                .HasMaxLength(50)
                .HasColumnName("TienDoID");
            entity.Property(e => e.DuAnId)
                .HasMaxLength(50)
                .HasColumnName("DuAnID");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.DuAn).WithMany(p => p.TienDoThiCongs)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__TienDoThi__DuAnI__3C69FB99");
        });

        modelBuilder.Entity<VatLieu>(entity =>
        {
            entity.HasKey(e => e.VatLieuId).HasName("PK__VatLieu__2EBFB85B804E0BEC");

            entity.ToTable("VatLieu");

            entity.Property(e => e.VatLieuId)
                .HasMaxLength(50)
                .HasColumnName("VatLieuID");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.GiaDonVi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenVatLieu).HasMaxLength(100);
        });

        modelBuilder.Entity<VatLieuSuDung>(entity =>
        {
            entity.HasKey(e => e.SuDungId).HasName("PK__VatLieuS__AF189E2002E7DD81");

            entity.ToTable("VatLieuSuDung");

            entity.Property(e => e.SuDungId)
                .HasMaxLength(50)
                .HasColumnName("SuDungID");
            entity.Property(e => e.DuAnId)
                .HasMaxLength(50)
                .HasColumnName("DuAnID");
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatLieuId)
                .HasMaxLength(50)
                .HasColumnName("VatLieuID");

            entity.HasOne(d => d.DuAn).WithMany(p => p.VatLieuSuDungs)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__VatLieuSu__DuAnI__412EB0B6");

            entity.HasOne(d => d.VatLieu).WithMany(p => p.VatLieuSuDungs)
                .HasForeignKey(d => d.VatLieuId)
                .HasConstraintName("FK__VatLieuSu__VatLi__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
