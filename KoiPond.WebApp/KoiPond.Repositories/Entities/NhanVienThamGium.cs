using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class NhanVienThamGium
{
    public int ThamGiaId { get; set; }

    public int? DuAnId { get; set; }

    public int? NhanVienId { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public virtual DuAnThiCong? DuAn { get; set; }

    public virtual NhanVien? NhanVien { get; set; }
}
