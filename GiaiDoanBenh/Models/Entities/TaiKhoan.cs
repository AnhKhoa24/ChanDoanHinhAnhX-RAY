using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class TaiKhoan
{
    public long Id { get; set; }

    public string? TenTaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public long? IdNhanVien { get; set; }

    public long? IdQuyen { get; set; }

    public virtual NhanVien? IdNhanVienNavigation { get; set; }

    public virtual Quyen? IdQuyenNavigation { get; set; }
}
