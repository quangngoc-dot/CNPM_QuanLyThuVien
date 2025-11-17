using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


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
    [JsonIgnore]
    public virtual NhanVien? MaNvNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual PhieuMuon? MaPhieuMuonNavigation { get; set; } = null!;
}
