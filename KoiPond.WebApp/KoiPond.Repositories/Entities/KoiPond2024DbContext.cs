using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Repositories.Entities;

public partial class KoiPond2024DbContext : DbContext
{
    public KoiPond2024DbContext()
    {
    }

    public KoiPond2024DbContext(DbContextOptions<KoiPond2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountKoiPond> AccountKoiPonds { get; set; }

    public virtual DbSet<DuAnThiCong> DuAnThiCongs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienThamGium> NhanVienThamGia { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<TienDoThiCong> TienDoThiCongs { get; set; }

    public virtual DbSet<VatLieu> VatLieus { get; set; }

    public virtual DbSet<VatLieuSuDung> VatLieuSuDungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=KoiPond2024DB;Integrated Security=True;User iD=sa;Password=12345;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountKoiPond>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("Account_KoiPond");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
        });

        modelBuilder.Entity<DuAnThiCong>(entity =>
        {
            entity.HasKey(e => e.DuAnId).HasName("PK__DuAnThiC__2007B3CBB8F1AF96");

            entity.ToTable("DuAnThiCong");

            entity.Property(e => e.DuAnId)
                .ValueGeneratedNever()
                .HasColumnName("DuAnID");
            entity.Property(e => e.DiaDiem).HasMaxLength(255);
            entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");
            entity.Property(e => e.TenDuAn).HasMaxLength(100);
            entity.Property(e => e.TongChiPhi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.KhachHang).WithMany(p => p.DuAnThiCongs)
                .HasForeignKey(d => d.KhachHangId)
                .HasConstraintName("FK__DuAnThiCo__Khach__398D8EEE");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.KhachHangId).HasName("PK__KhachHan__880F211B1C8F434E");

            entity.ToTable("KhachHang");

            entity.Property(e => e.KhachHangId)
                .ValueGeneratedNever()
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
            entity.HasKey(e => e.NhanVienId).HasName("PK__NhanVien__E27FD7EACD9B73A7");

            entity.ToTable("NhanVien");

            entity.Property(e => e.NhanVienId)
                .ValueGeneratedNever()
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
            entity.HasKey(e => e.ThamGiaId).HasName("PK__NhanVien__658978BC15856CCB");

            entity.Property(e => e.ThamGiaId)
                .ValueGeneratedNever()
                .HasColumnName("ThamGiaID");
            entity.Property(e => e.DuAnId).HasColumnName("DuAnID");
            entity.Property(e => e.NhanVienId).HasColumnName("NhanVienID");

            entity.HasOne(d => d.DuAn).WithMany(p => p.NhanVienThamGia)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__NhanVienT__DuAnI__46E78A0C");

            entity.HasOne(d => d.NhanVien).WithMany(p => p.NhanVienThamGia)
                .HasForeignKey(d => d.NhanVienId)
                .HasConstraintName("FK__NhanVienT__NhanV__47DBAE45");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.ThanhToanId).HasName("PK__ThanhToa__24A8D684005C81EA");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.ThanhToanId)
                .ValueGeneratedNever()
                .HasColumnName("ThanhToanID");
            entity.Property(e => e.DuAnId).HasColumnName("DuAnID");
            entity.Property(e => e.HinhThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.DuAn).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__ThanhToan__DuAnI__4AB81AF0");
        });

        modelBuilder.Entity<TienDoThiCong>(entity =>
        {
            entity.HasKey(e => e.TienDoId).HasName("PK__TienDoTh__BC617641FE28A9B0");

            entity.ToTable("TienDoThiCong");

            entity.Property(e => e.TienDoId)
                .ValueGeneratedNever()
                .HasColumnName("TienDoID");
            entity.Property(e => e.DuAnId).HasColumnName("DuAnID");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.DuAn).WithMany(p => p.TienDoThiCongs)
                .HasForeignKey(d => d.DuAnId)
                .HasConstraintName("FK__TienDoThi__DuAnI__3C69FB99");
        });

        modelBuilder.Entity<VatLieu>(entity =>
        {
            entity.HasKey(e => e.VatLieuId).HasName("PK__VatLieu__2EBFB85BD0881BEC");

            entity.ToTable("VatLieu");

            entity.Property(e => e.VatLieuId)
                .ValueGeneratedNever()
                .HasColumnName("VatLieuID");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.GiaDonVi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenVatLieu).HasMaxLength(100);
        });

        modelBuilder.Entity<VatLieuSuDung>(entity =>
        {
            entity.HasKey(e => e.SuDungId).HasName("PK__VatLieuS__AF189E206DFB0ED2");

            entity.ToTable("VatLieuSuDung");

            entity.Property(e => e.SuDungId)
                .ValueGeneratedNever()
                .HasColumnName("SuDungID");
            entity.Property(e => e.DuAnId).HasColumnName("DuAnID");
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatLieuId).HasColumnName("VatLieuID");

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
