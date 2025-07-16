using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        public required string MaHTPP { get; set; }
        public required string TenHTPP { get; set; }
    }
}
