using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class VaiTro
{
    public long Id { get; set; }

    public string? TenVaiTro { get; set; }

    public long? IdPhong { get; set; }

    public virtual Phong? IdPhongNavigation { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
