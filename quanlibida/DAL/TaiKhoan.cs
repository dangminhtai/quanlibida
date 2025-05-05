using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("TaiKhoan")] // Map đúng bảng
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)] // Bạn có thể chỉnh 100 thành đúng độ dài thực tế nếu cần
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; }
    }
}
