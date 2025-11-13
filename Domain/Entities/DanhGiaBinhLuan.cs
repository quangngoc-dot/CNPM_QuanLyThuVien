using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DanhGiaBinhLuan
{
    public int MaDanhGia { get; set; }

    public int MaDocGia { get; set; }

    public int MaTaiLieu { get; set; }

    public byte? DiemDanhGia { get; set; }

    public string? BinhLuan { get; set; }

    public DateTime? NgayDanhGia { get; set; }

    public virtual DocGia MaDocGiaNavigation { get; set; } = null!;

    public virtual TaiLieu MaTaiLieuNavigation { get; set; } = null!;
}
