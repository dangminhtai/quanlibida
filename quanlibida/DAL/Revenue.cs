using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Revenue")]
    public class Revenue
    {
        [Key]
        // Không có DatabaseGeneratedOption.Identity vì RevenueID sẽ nhập tay
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RevenueID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RevenueDate { get; set; }

        [Column(TypeName = "decimal")]
        public decimal TableRevenue { get; set; }

        [Column(TypeName = "decimal")]
        public decimal FoodRevenue { get; set; }

        [Column(TypeName = "decimal")]
        public decimal DrinkRevenue { get; set; }
    }
}
