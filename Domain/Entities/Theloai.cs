using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Theloai
{
    public int MaTheLoai { get; set; }

    public string TenTheLoai { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<TaiLieu> MaTaiLieus { get; set; } = new List<TaiLieu>();
}
