using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class KhachHang
{
    public int KhachHangId { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public DateOnly? NgayDangKy { get; set; }

    public virtual ICollection<DuAnThiCong> DuAnThiCongs { get; set; } = new List<DuAnThiCong>();
}
