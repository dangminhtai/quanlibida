using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DAL;

namespace BLLBooking
{
    public class BookingBLL
    {
        private MyDbContext db = new MyDbContext();

        // 📌 Thêm Booking
        public bool ThemBooking(ref string err, Booking booking)
        {
            try
            {
                db.Database.ExecuteSqlCommand(
                    "EXEC spThemBooking @BookingID, @maKH, @BookingTimeStart, @BookingTimeEnd, @MoneyDV, @TableType",
                    new SqlParameter("@BookingID", booking.BookingID),
                    new SqlParameter("@maKH", booking.MaKH),
                    new SqlParameter("@BookingTimeStart", booking.BookingTimeStart),
                    new SqlParameter("@BookingTimeEnd", booking.BookingTimeEnd),
                    new SqlParameter("@MoneyDV", booking.MoneyDV),
                    new SqlParameter("@TableType", booking.TableType)
                );
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 📌 Sửa Booking
        public bool SuaBooking(ref string err, Booking booking)
        {
            try
            {
                db.Database.ExecuteSqlCommand(
                    "EXEC spSuaBooking @BookingID, @maKH, @BookingTimeStart, @BookingTimeEnd, @MoneyDV, @TableType",
                    new SqlParameter("@BookingID", booking.BookingID),
                    new SqlParameter("@maKH", booking.MaKH),
                    new SqlParameter("@BookingTimeStart", booking.BookingTimeStart),
                    new SqlParameter("@BookingTimeEnd", booking.BookingTimeEnd),
                    new SqlParameter("@MoneyDV", booking.MoneyDV),
                    new SqlParameter("@TableType", booking.TableType)
                );
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }


        // 📌 Xóa Booking
        public bool XoaBooking(ref string err, string bookingID)
        {
            try
            {
                int result = db.Database.ExecuteSqlCommand(
                    "EXEC spXoaBooking @BookingID",
                    new SqlParameter("@BookingID", bookingID)
                );

                if (result == 0)
                {
                    err = "Không tìm thấy booking để xóa!";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }




        // 📌 Lọc Booking theo loại bàn
        public List<Booking> LocKhachHangTheoBan(string loaiBan)
        {
            var param = new SqlParameter("@LoaiBan", loaiBan);
            return db.Database.SqlQuery<Booking>("sp_LocKhachHangTheoBan @LoaiBan", param).ToList();
        }

        // 📌 Lọc Booking chơi hơn K phút
        public List<Booking> LocKhachHangChoiHonKPhut(int soPhut)
        {
            var param = new SqlParameter("@soPhut", soPhut);
            return db.Database.SqlQuery<Booking>("sp_LocKhachHangChoiHonKPhut @soPhut", param).ToList();
        }

        // 📌 Lọc Booking chơi nhỏ hơn K phút
        public List<Booking> LocKhachHangChoiNhoHonKPhut(int soPhut)
        {
            var param = new SqlParameter("@soPhut", soPhut);
            return db.Database.SqlQuery<Booking>("sp_LocKhachHangChoiNhoHonKPhut @soPhut", param).ToList();
        }
        public int TinhThoiGianChoiKH(int maKH)
        {
            var param = new SqlParameter("@maKH", maKH);
            var result = db.Database.SqlQuery<int>("sp_TinhThoiGianChoiKH @maKH", param).FirstOrDefault();
            return result;
        }
      

        // 📌 Lọc khách hàng theo dịch vụ lớn hơn giá trị cho trước
        public List<Booking> LocKhachHangTheoDichVuLonHon(decimal loaiDichVu)
        {
            var param = new SqlParameter("@LoaiDichVu", loaiDichVu);
            return db.Database.SqlQuery<Booking>("sp_KhachHangTheoDichVuLonHon @LoaiDichVu", param).ToList();
        }

        // 📌 Lọc khách hàng theo dịch vụ nhỏ hơn giá trị cho trước
        public List<Booking> LocKhachHangTheoDichVuNhoHon(decimal loaiDichVu)
        {
            var param = new SqlParameter("@LoaiDichVu", loaiDichVu);
            return db.Database.SqlQuery<Booking>("sp_KhachHangTheoDichVuNhoHon @LoaiDichVu", param).ToList();
        }
        public List<Booking> LayBooking()
        {
            return db.Database.SqlQuery<Booking>("SELECT * FROM Booking").ToList();
        }
    }
}