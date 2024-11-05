using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class HinhAnh
{
    public long Id { get; set; }

    public string? LinkHinhAnh { get; set; }

    public DateTime? NgayChup { get; set; }

    public long? IdChanDoan { get; set; }

    public virtual ChanDoan? IdChanDoanNavigation { get; set; }
}
