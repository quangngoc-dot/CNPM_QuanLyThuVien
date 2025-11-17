using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class ChiTietDatTruoc
{
    public int MaDatTruoc { get; set; }

    public int MaTaiLieu { get; set; }

    public int? SoLuong { get; set; }
    [JsonIgnore]
    public virtual DatMuonTruoc? MaDatTruocNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual TaiLieu? MaTaiLieuNavigation { get; set; } = null!;
}
