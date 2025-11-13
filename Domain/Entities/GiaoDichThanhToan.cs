using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class GiaoDichThanhToan
{
    public int MaGd { get; set; }

    public int MaDocGia { get; set; }

    public string LoaiGiaoDich { get; set; } = null!;

    public decimal SoTien { get; set; }

    public DateTime? NgayGiaoDich { get; set; }

    public int? MaLienQuan { get; set; }

    public string? GhiChu { get; set; }

    public virtual DocGia MaDocGiaNavigation { get; set; } = null!;
}
