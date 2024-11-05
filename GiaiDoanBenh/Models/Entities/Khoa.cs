using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class Khoa
{
    public long Id { get; set; }

    public string? TenKhoa { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
