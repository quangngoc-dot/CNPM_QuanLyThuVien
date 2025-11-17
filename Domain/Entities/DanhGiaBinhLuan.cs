using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class DanhGiaBinhLuan
{
    public int MaDanhGia { get; set; }

    public int MaDocGia { get; set; }

    public int MaTaiLieu { get; set; }

    public byte? DiemDanhGia { get; set; }

    public string? BinhLuan { get; set; }

    public DateTime? NgayDanhGia { get; set; }
    [JsonIgnore]
    public virtual DocGia? MaDocGiaNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual TaiLieu? MaTaiLieuNavigation { get; set; } = null!;
}
