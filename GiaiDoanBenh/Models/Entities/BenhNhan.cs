using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class BenhNhan
{
    public long Id { get; set; }

    public string? MaBenhNhan { get; set; }

    public string? TenBenhNhan { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Cccd { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<ChanDoan> ChanDoans { get; set; } = new List<ChanDoan>();
}
