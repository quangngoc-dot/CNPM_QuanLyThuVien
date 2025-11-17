using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TheBanDoc
{
    public int MaSoThe { get; set; }

    public int MaDocGia { get; set; }

    public string? TinhTrangThe { get; set; }

    public DateOnly? NgayCap { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public virtual DocGia? MaDocGiaNavigation { get; set; } = null!;

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();
}
