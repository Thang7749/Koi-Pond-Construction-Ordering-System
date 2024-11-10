using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class DuAnThiCong
{
    public string DuAnId { get; set; } = null!;

    public string? KhachHangId { get; set; }

    public string? TenDuAn { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayHoanThanhDuKien { get; set; }

    public string? TrangThai { get; set; }

    public string? DiaDiem { get; set; }

    public decimal? TongChiPhi { get; set; }

    public virtual KhachHang? KhachHang { get; set; }

    public virtual ICollection<NhanVienThamGium> NhanVienThamGia { get; set; } = new List<NhanVienThamGium>();

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();

    public virtual ICollection<TienDoThiCong> TienDoThiCongs { get; set; } = new List<TienDoThiCong>();

    public virtual ICollection<VatLieuSuDung> VatLieuSuDungs { get; set; } = new List<VatLieuSuDung>();
}
