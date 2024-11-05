using System;
using System.Collections.Generic;

namespace GiaiDoanBenh.Models.Entities;

public partial class NhanVien
{
    public long Id { get; set; }

    public string? MaNhanVien { get; set; }

    public string? TenNhanVien { get; set; }

    public string? Cccd { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public string? DienThoai { get; set; }

    public long? MaVaiTro { get; set; }

    public virtual ICollection<ChanDoan> ChanDoans { get; set; } = new List<ChanDoan>();

    public virtual VaiTro? MaVaiTroNavigation { get; set; }

    public virtual ICollection<ShareLichSu> ShareLichSuIdBacSiChiaSeNavigations { get; set; } = new List<ShareLichSu>();

    public virtual ICollection<ShareLichSu> ShareLichSuIdBacSiNhanNavigations { get; set; } = new List<ShareLichSu>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
