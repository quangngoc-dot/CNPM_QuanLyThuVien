using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class ChiTietPhieuMuon
{
    public int MaPhieuMuon { get; set; }

    public int MaTaiLieu { get; set; }

    public int? SoLuong { get; set; }

    public decimal? PhiMuonTaiThoiDiem { get; set; }
    [JsonIgnore]
    public virtual PhieuMuon? MaPhieuMuonNavigation { get; set; } = null!;

    public virtual TaiLieu? MaTaiLieuNavigation { get; set; } = null!;
}
