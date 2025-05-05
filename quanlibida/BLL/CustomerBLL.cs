using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using DAL;

namespace BLLCustomer
{
    public class CustomerBLL
    {
        private MyDbContext db = new MyDbContext();

        // 📌 Tìm khách hàng có nhiều tiền tích lũy nhất
        public List<Customer> KhachHangNhieuTienNhat()
        {
            return db.Database.SqlQuery<Customer>("EXEC spKhachHangNhieuTienNhat").ToList();
        }

        // 📌 Tìm khách hàng có ít tiền tích lũy nhất
        public List<Customer> KhachHangItTienNhat()
        {
            return db.Database.SqlQuery<Customer>("EXEC spKhachHangItTienNhat").ToList();
        }

        // 📌 Thêm khách hàng
        public bool ThemKhachHang(ref string err, int maKH, string hoTen, string soDienThoai, string diaChi, decimal tienTichLuy)
        {
            try
            {
                db.Database.ExecuteSqlCommand(
                    "EXEC spThemKhachHang @maKH, @hoTen, @soDienThoai, @diaChi, @tienTichLuy",
                    new SqlParameter("@maKH", maKH),
                    new SqlParameter("@hoTen", hoTen),
                    new SqlParameter("@soDienThoai", soDienThoai),
                    new SqlParameter("@diaChi", diaChi),
                    new SqlParameter("@tienTichLuy", tienTichLuy)
                );
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 📌 Cập nhật khách hàng
        public bool CapNhatKhachHang(ref string err, int maKH, string hoTen, string soDienThoai, string diaChi, decimal tienTichLuy)
        {
            try
            {
                db.Database.ExecuteSqlCommand(
                    "EXEC spCapNhatKhachHang @maKH, @hoTen, @soDienThoai, @diaChi, @tienTichLuy",
                    new SqlParameter("@maKH", maKH),
                    new SqlParameter("@hoTen", hoTen),
                    new SqlParameter("@soDienThoai", soDienThoai),
                    new SqlParameter("@diaChi", diaChi),
                    new SqlParameter("@tienTichLuy", tienTichLuy)
                );
                return true;
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                return false;
            }
        }


        // 📌 Xóa khách hàng
        public bool XoaKhachHang(ref string err, int maKH)
        {
            try
            {
                int rowsAffected = db.Database.ExecuteSqlCommand(
                    "EXEC spXoaKhachHang @maKH",
                    new SqlParameter("@maKH", maKH)
                );

                if (rowsAffected == 0)
                {
                    err = "Không tìm thấy khách hàng để xóa!";
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

        // 📌 Tìm khách hàng theo địa chỉ
        public List<Customer> KhachHangTheoDiaChi(string keyword)
        {
            return db.Database.SqlQuery<Customer>(
                "EXEC spTimKhachHangTheoDiaChi @Keyword",
                new SqlParameter("@Keyword", keyword)
            ).ToList();
        }

        // 📌 Tìm khách hàng theo tên
        public List<Customer> LayKhachHangTheoTen(string name)
        {
            return db.Database.SqlQuery<Customer>(
                "EXEC spTimKhachHangTheoTen @Name",
                new SqlParameter("@Name", name)
            ).ToList();
        }

        // 📌 Lấy toàn bộ khách hàng (không cần SP, dùng SELECT trực tiếp)
        public List<Customer> LayKhachHang()
        {
            return db.Database.SqlQuery<Customer>("SELECT * FROM Customer").ToList();
        }
    }
}
