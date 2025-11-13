using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class PhieuMuon
{
    public int MaPhieuMuon { get; set; }

    public int MaNv { get; set; }

    public int MaSoThe { get; set; }

    public DateTime? NgayMuon { get; set; }

    public DateTime NgayTra { get; set; }

    public DateTime? NgayThucTra { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<ChiTietPhieuMuon>();

    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    public virtual TheBanDoc MaSoTheNavigation { get; set; } = null!;

    public virtual ICollection<PhieuPhat> PhieuPhats { get; set; } = new List<PhieuPhat>();

    public virtual ICollection<XuLyGiaHan> XuLyGiaHans { get; set; } = new List<XuLyGiaHan>();
}
