using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class ChanDoan
{
    public long Id { get; set; }

    public DateTime? NgayChanDoan { get; set; }

    public string? KetQua { get; set; }

    public long? IdbacSiChanDoan { get; set; }

    public long? IdbenhNhan { get; set; }

    public bool? DaChanDoan { get; set; }

    public virtual ICollection<HinhAnh> HinhAnhs { get; set; } = new List<HinhAnh>();

    public virtual NhanVien? IdbacSiChanDoanNavigation { get; set; }

    public virtual BenhNhan? IdbenhNhanNavigation { get; set; }

    public virtual ICollection<ShareLichSu> ShareLichSus { get; set; } = new List<ShareLichSu>();
}
