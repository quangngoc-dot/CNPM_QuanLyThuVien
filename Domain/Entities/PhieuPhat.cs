using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class PhieuPhat
{
    public int MaPhieuPhat { get; set; }

    public int MaPhieuMuon { get; set; }

    public int MaNv { get; set; }

    public decimal? PhiPhat { get; set; }

    public string? LyDoPhat { get; set; }

    public DateTime? NgayLap { get; set; }

    public bool? TrangThaiThanhToan { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    public virtual PhieuMuon MaPhieuMuonNavigation { get; set; } = null!;
}
