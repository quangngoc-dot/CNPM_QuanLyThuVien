using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class XuLyGiaHan
{
    public int MaGiaHan { get; set; }

    public int MaPhieuMuon { get; set; }

    public DateTime? NgayYeuCau { get; set; }

    public DateTime NgayGiaHanMoi { get; set; }

    public int? SoLanGiaHan { get; set; }

    public string? TrangThaiDuyet { get; set; }

    public int? MaNvduyet { get; set; }

    public virtual NhanVien? MaNvduyetNavigation { get; set; }

    public virtual PhieuMuon MaPhieuMuonNavigation { get; set; } = null!;
}
