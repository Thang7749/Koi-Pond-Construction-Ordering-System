using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class VatLieu
{
    public int VatLieuId { get; set; }

    public string? TenVatLieu { get; set; }

    public string? DonViTinh { get; set; }

    public decimal? GiaDonVi { get; set; }

    public virtual ICollection<VatLieuSuDung> VatLieuSuDungs { get; set; } = new List<VatLieuSuDung>();
}
