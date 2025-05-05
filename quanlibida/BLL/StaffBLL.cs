using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DAL;

namespace BLLStaff
{
    public class StaffBLL
    {
        private MyDbContext db = new MyDbContext();

        // 📌 Lấy tất cả nhân viên
        public List<Staff> LayNhanVien()
        {
            return db.Database.SqlQuery<Staff>("SELECT * FROM Staff").ToList();
        }

        // 📌 Lấy nhân viên theo năm
        public List<Staff> LayNhanVienTheoNam(int nam)
        {
            var param = new SqlParameter("@Nam", nam);
            return db.Database.SqlQuery<Staff>("EXEC spTimNhanVienTheoNam @Nam", param).ToList();
        }

        // 📌 Lấy nhân viên theo lương tối thiểu
        public List<Staff> LayNhanVienTheoLuongMin(decimal luongMin)
        {
            var param = new SqlParameter("@LuongMin", luongMin);
            return db.Database.SqlQuery<Staff>("EXEC spTimNhanVienTheoLuongTren @LuongMin", param).ToList();
        }

        // 📌 Lấy nhân viên theo lương tối đa
        public List<Staff> LayNhanVienTheoLuongMax(decimal luongMax)
        {
            var param = new SqlParameter("@LuongMax", luongMax);
            return db.Database.SqlQuery<Staff>("EXEC spTimNhanVienTheoLuongDuoi @LuongMax", param).ToList();
        }

        // 📌 Lấy nhân viên theo tên
        public List<Staff> LayNhanVienTheoTen(string name)
        {
            var param = new SqlParameter("@Name", name);
            return db.Database.SqlQuery<Staff>("EXEC spTimNhanVienTheoTen @Name", param).ToList();
        }

        // 📌 Thêm nhân viên
        public bool ThemNhanVien(Staff staff, ref string err)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@MaNV", staff.MaNV),
                    new SqlParameter("@Name", staff.Name),
                    new SqlParameter("@Salary", staff.Salary),
                    new SqlParameter("@Enter", staff.Enter),
                    new SqlParameter("@Email", staff.Email)
                };

                db.Database.ExecuteSqlCommand("EXEC spThemNhanVien @MaNV, @Name, @Salary, @Enter, @Email", parameters);
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 📌 Cập nhật nhân viên
        public bool CapNhatNhanVien(Staff staff, ref string err)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@MaNV", staff.MaNV),
                    new SqlParameter("@Name", staff.Name),
                    new SqlParameter("@Salary", staff.Salary),
                    new SqlParameter("@Enter", staff.Enter),
                    new SqlParameter("@Email", staff.Email)
                };

                db.Database.ExecuteSqlCommand("EXEC spCapNhatNhanVien @MaNV, @Name, @Salary, @Enter, @Email", parameters);
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 📌 Xóa nhân viên
        public bool XoaNhanVien(int maNV, ref string err)
        {
            try
            {
                var param = new SqlParameter("@MaNV", maNV);
                db.Database.ExecuteSqlCommand("EXEC spXoaNhanVien @MaNV", param);
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 📌 Tìm nhân viên làm việc lâu nhất
        public Staff TimNhanVienLauNhat()
        {
            return db.Database.SqlQuery<Staff>("EXEC spTimNhanVienLauNhat").FirstOrDefault();
        }

        // 📌 Tìm nhân viên mới vào
        public Staff TimNhanVienMoiLam()
        {
            return db.Database.SqlQuery<Staff>("EXEC spTimNhanVienMoiLam").FirstOrDefault();
        }

        // 📌 Tìm khách hàng nhiều tiền nhất (nếu cần dùng Staff thì chỉnh SP lại nhé)
        public Staff KhachHangNhieuTienNhat()
        {
            return db.Database.SqlQuery<Staff>("EXEC spKhachHangNhieuTienNhat").FirstOrDefault();
        }
    }
}
