using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class TaiKhoanKhachHang
{
    public string TaiKhoanId { get; set; } = null!;

    public string? KhachHangId { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public DateOnly? NgayTao { get; set; }

    public string? TrangThai { get; set; }

    public virtual KhachHang? KhachHang { get; set; }
}
