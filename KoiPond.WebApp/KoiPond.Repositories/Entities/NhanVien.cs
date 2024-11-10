using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class NhanVien
{
    public string NhanVienId { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? ViTri { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<NhanVienThamGium> NhanVienThamGia { get; set; } = new List<NhanVienThamGium>();
}
