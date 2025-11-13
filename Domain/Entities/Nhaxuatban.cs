using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class NhaXuatBan
{
    public int MaNxb { get; set; }

    public string TenNxb { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<TaiLieu> TaiLieus { get; set; } = new List<TaiLieu>();
}
