using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class DatMuonTruoc
{
    public int MaDatTruoc { get; set; }

    public int MaDocGia { get; set; }

    public DateTime? NgayDat { get; set; }

    public string? TrangThai { get; set; }

    public DateTime? HanLaySach { get; set; }

    public int? MaNvduyet { get; set; }

    public virtual ICollection<ChiTietDatTruoc> ChiTietDatTruocs { get; set; } = new List<ChiTietDatTruoc>();

    public virtual DocGia MaDocGiaNavigation { get; set; } = null!;

    public virtual NhanVien? MaNvduyetNavigation { get; set; }
}
