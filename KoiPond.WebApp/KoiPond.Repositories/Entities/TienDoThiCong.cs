using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Entities;

public partial class TienDoThiCong
{
    public string TienDoId { get; set; } = null!;

    public string? DuAnId { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public string? MoTa { get; set; }

    public string? TrangThai { get; set; }

    public virtual DuAnThiCong? DuAn { get; set; }
}
