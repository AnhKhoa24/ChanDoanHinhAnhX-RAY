using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class ShareLichSu
{
    public long Id { get; set; }

    public long? IdBacSiChiaSe { get; set; }

    public long? IdBacSiNhan { get; set; }

    public long? IdChanDoan { get; set; }

    public virtual NhanVien? IdBacSiChiaSeNavigation { get; set; }

    public virtual NhanVien? IdBacSiNhanNavigation { get; set; }

    public virtual ChanDoan? IdChanDoanNavigation { get; set; }
}
