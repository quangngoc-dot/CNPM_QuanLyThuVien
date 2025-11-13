using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ChiTietDatTruoc
{
    public int MaDatTruoc { get; set; }

    public int MaTaiLieu { get; set; }

    public int? SoLuong { get; set; }

    public virtual DatMuonTruoc MaDatTruocNavigation { get; set; } = null!;

    public virtual TaiLieu MaTaiLieuNavigation { get; set; } = null!;
}
