using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Domain.Entities;

public partial class TacGia
{
    public int MaTacGia { get; set; }

    public string TenTacGia { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<TaiLieu> MaTaiLieus { get; set; } = new List<TaiLieu>();
}
