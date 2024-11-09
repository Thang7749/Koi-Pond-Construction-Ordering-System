using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class VatLieuSuDung
{
    public string SuDungId { get; set; } = null!;

    public string? DuAnId { get; set; }

    public string? VatLieuId { get; set; }

    public decimal? SoLuong { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual DuAnThiCong? DuAn { get; set; }

    public virtual VatLieu? VatLieu { get; set; }
}
