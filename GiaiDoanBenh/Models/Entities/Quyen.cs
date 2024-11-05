using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class Quyen
{
    public long Id { get; set; }

    public string? TenQuyen { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
