﻿using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class DaiLy
    {
        [Key]
        public required string MaDaiLy { get; set; }
            public required string TenDaiLy { get; set; }
            public required string DiaChi { get; set; }
            public required string NguoiDaiDien { get; set; }
            public required string DienThoai { get; set; }
            public required string MaHTPP { get; set; }
            public required HeThongPhanPhoi HeThongPhanPhoi { get; set; }
    }
    
}

