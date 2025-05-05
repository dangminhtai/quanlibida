using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Staff")] // Map đúng bảng trong DB
    public class Staff
    {
        [Key]
        public int MaNV { get; set; }

        [Required]
        [StringLength(100)] // Name là nvarchar(100)
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Salary decimal(18,2)
        public decimal Salary { get; set; }

        [Required]
        [Column(TypeName = "date")] // Enter là kiểu date
        public DateTime Enter { get; set; }

        [Required]
        [StringLength(100)] // Email nvarchar(100)
        public string Email { get; set; }
    }
}
