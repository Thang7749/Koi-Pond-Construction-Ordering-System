using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class ThanhToan
{
    public string ThanhToanId { get; set; } = null!;

    public string? DuAnId { get; set; }

    public DateOnly? NgayThanhToan { get; set; }

    public decimal? SoTien { get; set; }

    public string? HinhThucThanhToan { get; set; }

    public string? TrangThai { get; set; }

    public virtual DuAnThiCong? DuAn { get; set; }
}
