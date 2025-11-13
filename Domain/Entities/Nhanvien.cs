using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public int MaDocGia { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public string? ChucVu { get; set; }

    public virtual ICollection<DatMuonTruoc> DatMuonTruocs { get; set; } = new List<DatMuonTruoc>();

    public virtual DocGia? MaDocGiaNavigation { get; set; } = null!;

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();

    public virtual ICollection<PhieuPhat> PhieuPhats { get; set; } = new List<PhieuPhat>();

    public virtual ICollection<XuLyGiaHan> XuLyGiaHans { get; set; } = new List<XuLyGiaHan>();
}
