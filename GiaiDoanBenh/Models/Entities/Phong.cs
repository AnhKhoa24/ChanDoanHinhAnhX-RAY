using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class Phong
{
    public long Id { get; set; }

    public string? TenPhong { get; set; }

    public long? IdMaKhoa { get; set; }

    public virtual Khoa? IdMaKhoaNavigation { get; set; }

    public virtual ICollection<VaiTro> VaiTros { get; set; } = new List<VaiTro>();
}
