using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Booking")] // Map đúng tên bảng trong SQL Server
    public class Booking
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string BookingID { get; set; }

        [Required]
        public int MaKH { get; set; } // FK tới Customer (maKH)

        [Required]
        public DateTime BookingTimeStart { get; set; }

        public DateTime? BookingTimeEnd { get; set; } // Cho phép NULL theo database

        public decimal? MoneyDV { get; set; } // Cho phép NULL theo database

        [StringLength(10)] // Vì TableType là varchar(10)
        public string TableType { get; set; }
    }
}
