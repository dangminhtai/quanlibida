using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Column("maKH")]
        public int MaKH { get; set; }

        [Column("hoTen")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Column("soDienThoai")]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Column("diaChi")]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Column("tienTichLuy")]
        public decimal TienTichLuy { get; set; }
    }
}
