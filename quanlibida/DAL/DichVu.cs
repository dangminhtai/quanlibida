using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("DichVu")] // Map đúng bảng trong DB
    public class DichVu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string TenDV { get; set; }
        public string LoaiDV { get; set; }

        [Required]
        [Column(TypeName = "decimal")] // Ghi đúng kiểu decimal
        public decimal GiaTien { get; set; }

        public DichVu() { }

        public DichVu(string tenDV, string loaiDV, decimal giaTien)
        {
            TenDV = tenDV;
            LoaiDV = loaiDV;
            GiaTien = giaTien;
        }
    }
}
