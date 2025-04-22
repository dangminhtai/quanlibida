using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class BAL
    {
        DAL db = null;

        public BAL()
        {
            db = new DAL();
        }
        public DataSet LayKhachHang()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM customer", CommandType.Text);
        }
        // 📌 Lấy danh sách nhân viên
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Staff", CommandType.Text);
        }
        public DataSet LayDoanhThu()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Revenue", CommandType.Text);
        }
        public DataSet LayDichVu()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM DichVu", CommandType.Text);
        }
        public DataSet LayBooking()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Booking", CommandType.Text);
        }
        public DataSet LayNhanVienTheoNam(int nam)
        {
            return db.ExecuteQueryDataSet("spTimNhanVienTheoNam", CommandType.StoredProcedure,
                new SqlParameter("@Nam", nam));
        }

        public DataSet LayNhanVienTheoLuongMin(decimal luongMin)
        {
            return db.ExecuteQueryDataSet("spTimNhanVienTheoLuongTren", CommandType.StoredProcedure,
                new SqlParameter("@LuongMin", luongMin));
        }
        public DataSet LayNhanVienTheoLuongMax(decimal luongMax)
        {
            return db.ExecuteQueryDataSet("spTimNhanVienTheoLuongDuoi", CommandType.StoredProcedure,
                new SqlParameter("@LuongMax", luongMax));
        }
        public DataSet LayNhanVienTheoTen(string name)
        {
            return db.ExecuteQueryDataSet("spTimNhanVienTheoTen", CommandType.StoredProcedure,
                new SqlParameter("@Name", name));
        }
        //Tìm khách hàng theo địa chỉ
        public DataSet KhachHangTheoDiaChi(string keyword)
        {
            return db.ExecuteQueryDataSet("spTimKhachHangTheoDiaChi", CommandType.StoredProcedure,
                new SqlParameter("@Keyword", keyword));
        }
        public DataSet LayKhachHangTheoTen(string name)
        {
            return db.ExecuteQueryDataSet("spTimKhachHangTheoTen", CommandType.StoredProcedure,
                new SqlParameter("@Name", name));
        }
        public DataSet TinhTongDoanhThuThueBan(DateTime startDate, DateTime endDate)
        {
            return db.ExecuteQueryDataSet("spTinhTongDoanhThuThueBan", CommandType.StoredProcedure,
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }
        public DataSet TinhTongDoanhThuThueDoAn(DateTime startDate, DateTime endDate)
        {
            return db.ExecuteQueryDataSet("sp_TinhTongDoanhThuThueDoAn", CommandType.StoredProcedure,
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }
        public DataSet TinhTongDoanhThuThueThucUong(DateTime startDate, DateTime endDate)
        {
            return db.ExecuteQueryDataSet("sp_TinhTongDoanhThuThueThucUong", CommandType.StoredProcedure,
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }
        public DataSet TinhTongTienTatCaDichVu(DateTime startDate, DateTime endDate)
        {
            return db.ExecuteQueryDataSet("sp_TinhTongTienTatCaDichVu", CommandType.StoredProcedure,
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }
        public DataSet DoanhThuNgay(DateTime Date)
        {
            return db.ExecuteQueryDataSet("sp_DoanhThuTrongNgay", CommandType.StoredProcedure,
           
                new SqlParameter("@Ngay", Date));
        }
        public DataSet LayDichVuTheoThucAn()
        {
            return db.ExecuteQueryDataSet("spLayDichVuTheoThucAn", CommandType.StoredProcedure);
        }
        public DataSet LayDichVuTheoThucUong()
        {
            return db.ExecuteQueryDataSet("spLayDichVuTheoThucUong",CommandType.StoredProcedure);
        }
        public DataSet LayDichVuTheoGia(decimal giaMin, decimal giaMax)
        {
            return db.ExecuteQueryDataSet("spLayDichVuTheoGia", CommandType.StoredProcedure,
                new SqlParameter("@GiaMin", giaMin),
                new SqlParameter("@GiaMax", giaMax));
        }
        public DataTable TimDichVuCoGiaTienLonNhat()
        {
            return db.ExecuteQueryDataSet("spTimDichVuCoGiaTienLonNhat", CommandType.StoredProcedure).Tables[0];
        }
        public DataTable TimDichVuCoGiaTienThapNhat()
        {
            return db.ExecuteQueryDataSet("spTimDichVuCoGiaTienThapNhat", CommandType.StoredProcedure).Tables[0];
        }
        public DataSet TimDichVuTheoTen(string tenDV)
        {
            return db.ExecuteQueryDataSet("spTimDichVuTheoTen", CommandType.StoredProcedure,
                new SqlParameter("@TenDV", tenDV));
        }



        // 📌 Thêm nhân viên
        public bool ThemNhanVien(ref string err, int MaNV, string Name, decimal Salary, DateTime Enter, string Email)
        {
            return db.MyExecuteNonQuery("spThemNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Salary", Salary),
                new SqlParameter("@Enter", Enter),
                new SqlParameter("@Email", Email));
        }

        // 📌 Cập nhật nhân viên
        public bool CapNhatNhanVien(ref string err, int MaNV, string Name, decimal Salary, DateTime Enter, string Email)
        {
            return db.MyExecuteNonQuery("spCapNhatNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Salary", Salary),
                new SqlParameter("@Enter", Enter),
                new SqlParameter("@Email", Email));
        }

        // 📌 Xóa nhân viên
        public bool XoaNhanVien(ref string err, int MaNV)
        {
            SqlParameter outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            bool result = db.MyExecuteNonQuery("spXoaNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNV", MaNV), outputParam);

            // Kiểm tra nếu không tìm thấy nhân viên
            if (result && (int)outputParam.Value == 0)
            {
                err = "Không tìm thấy nhân viên có MaNV này!";
                return false;
            }

            return result;
        }
        // 📌 Thêm khách hàng
        public bool ThemKhachHang(ref string err, int maKH, string hoTen, string soDienThoai, string diaChi, decimal tienTichLuy)
        {
            return db.MyExecuteNonQuery("spThemKhachHang", CommandType.StoredProcedure, ref err,
                new SqlParameter("@maKH", maKH),
                new SqlParameter("@hoTen", hoTen),
                new SqlParameter("@soDienThoai", soDienThoai),
                new SqlParameter("@diaChi", diaChi),
                new SqlParameter("@tienTichLuy", tienTichLuy));
        }

        // 📌 Cập nhật khách hàng
        public bool CapNhatKhachHang(ref string err, int maKH, string hoTen, string soDienThoai, string diaChi, decimal tienTichLuy)
        {
            return db.MyExecuteNonQuery("spCapNhatKhachHang", CommandType.StoredProcedure, ref err,
                new SqlParameter("@maKH", maKH),
                new SqlParameter("@hoTen", hoTen),
                new SqlParameter("@soDienThoai", soDienThoai),
                new SqlParameter("@diaChi", diaChi),
                new SqlParameter("@tienTichLuy", tienTichLuy));
        }

        // 📌 Xóa khách hàng
        public bool XoaKhachHang(ref string err, int maKH)
        {
            SqlParameter outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            bool result = db.MyExecuteNonQuery("spXoaKhachHang", CommandType.StoredProcedure, ref err,
                new SqlParameter("@maKH", maKH), outputParam);

            // Kiểm tra nếu không tìm thấy khách hàng
            if (result && (int)outputParam.Value == 0)
            {
                err = "Không tìm thấy khách hàng có maKH này!";
                return false;
            }

            return result;
        }
        // 📌 Tìm nhân viên làm việc lâu nhất
        public DataTable TimNhanVienLauNhat()
        {
            return db.ExecuteQueryDataSet("spTimNhanVienLauNhat", CommandType.StoredProcedure).Tables[0];
        }
        // 📌 Tìm nhân viên sớm nhất
        public DataTable TimNhanVienMoiLam()   
        {
            return db.ExecuteQueryDataSet("spTimNhanVienMoiLam", CommandType.StoredProcedure).Tables[0];
        }
        // 📌 Tìm khách hàng có nhiều tiền nhất
        public DataTable KhachHangNhieuTienNhat()
        {
            return db.ExecuteQueryDataSet("spKhachHangNhieuTienNhat", CommandType.StoredProcedure).Tables[0];
        }
        // 📌 Tìm khách hàng có ít tiền nhất
        public DataTable KhachHangItTienNhat()
        {
            return db.ExecuteQueryDataSet("spKhachHangItTienNhat", CommandType.StoredProcedure).Tables[0];
        }

        public bool ThemDoanhThu(ref string err, int revenueID, DateTime revenueDate,
                         decimal tableRevenue, decimal foodRevenue, decimal drinkRevenue)
        {
            return db.MyExecuteNonQuery("spThemDoanhThu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@RevenueID", revenueID),
                new SqlParameter("@RevenueDate", revenueDate),
                new SqlParameter("@TableRevenue", tableRevenue),
                new SqlParameter("@FoodRevenue", foodRevenue),
                new SqlParameter("@DrinkRevenue", drinkRevenue));
        }

        public bool CapNhatDoanhThu(ref string err, int revenueID, DateTime revenueDate,
                                    decimal tableRevenue, decimal foodRevenue, decimal drinkRevenue)
        {
            return db.MyExecuteNonQuery("spCapNhatDoanhThu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@RevenueID", revenueID),
                new SqlParameter("@RevenueDate", revenueDate),
                new SqlParameter("@TableRevenue", tableRevenue),
                new SqlParameter("@FoodRevenue", foodRevenue),
                new SqlParameter("@DrinkRevenue", drinkRevenue));
        }
        public bool XoaDoanhThu(ref string err, int RevenueID)
        {
            return db.MyExecuteNonQuery("spXoaDoanhThu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@RevenueID", RevenueID));
        }
        // 📌 Thêm dịch vụ
        public bool ThemDichVu(ref string err, string TenDV, string LoaiDV, decimal GiaTien)
        {
            return db.MyExecuteNonQuery("spThemDichVu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenDV", TenDV),
                new SqlParameter("@LoaiDV", LoaiDV),
                new SqlParameter("@GiaTien", GiaTien));
        }

        // 📌 Cập nhật dịch vụ
        public bool CapNhatDichVu(ref string err, string TenDV, string LoaiDV, decimal GiaTien)
        {
            return db.MyExecuteNonQuery("spCapNhatDichVu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenDV", TenDV),
                new SqlParameter("@LoaiDV", LoaiDV),
                new SqlParameter("@GiaTien", GiaTien));
        }

        // 📌 Xóa dịch vụ
        public bool XoaDichVu(ref string err, string TenDV, string LoaiDV)
        {
            SqlParameter outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            bool result = db.MyExecuteNonQuery("spXoaDichVu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenDV", TenDV),
                new SqlParameter("@LoaiDV", LoaiDV),
                outputParam);

            if (result && (int)outputParam.Value == 0)
            {
                err = "Không tìm thấy dịch vụ cần xóa!";
                return false;
            }

            return result;
        }
        // 📌 Thêm Booking
        public bool ThemBooking(ref string err, string BookingID, int maKH, DateTime BookingTimeStart, DateTime BookingTimeEnd, decimal MoneyDV, string TableType)
        {
            return db.MyExecuteNonQuery("spThemBooking", CommandType.StoredProcedure, ref err,
                new SqlParameter("@BookingID", BookingID),
                new SqlParameter("@maKH", maKH),
                new SqlParameter("@BookingTimeStart", BookingTimeStart),
                new SqlParameter("@BookingTimeEnd", BookingTimeEnd),
                new SqlParameter("@MoneyDV", MoneyDV),
                new SqlParameter("@TableType", TableType));
        }

        // 📌 Sửa Booking
        public bool SuaBooking(ref string err, string BookingID, int maKH, DateTime BookingTimeStart, DateTime BookingTimeEnd, decimal MoneyDV, string TableType)
        {
            return db.MyExecuteNonQuery("spSuaBooking", CommandType.StoredProcedure, ref err,
                new SqlParameter("@BookingID", BookingID),
                new SqlParameter("@maKH", maKH),
                new SqlParameter("@BookingTimeStart", BookingTimeStart),
                new SqlParameter("@BookingTimeEnd", BookingTimeEnd),
                new SqlParameter("@MoneyDV", MoneyDV),
                new SqlParameter("@TableType", TableType));
        }

        // 📌 Xóa Booking
        public bool XoaBooking(ref string err, string BookingID)
        {
            SqlParameter outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            bool result = db.MyExecuteNonQuery("spXoaBooking", CommandType.StoredProcedure, ref err,
                new SqlParameter("@BookingID", BookingID), outputParam);

            // Kiểm tra nếu không tìm thấy booking
            if (result && (int)outputParam.Value == 0)
            {
                err = "Không tìm thấy Booking có BookingID này!";
                return false;
            }

            return result;
        }
        //Lọc khách hàng theo bàn
        public DataSet LocKhachHangTheoBan(string loaiBan)
        {
            return db.ExecuteQueryDataSet("sp_LocKhachHangTheoBan", CommandType.StoredProcedure,
                new SqlParameter("@LoaiBan", loaiBan));
        }
        public DataSet LocKhachHangTheoDichVuLonHon(decimal loaiDichVu)
        {
            return db.ExecuteQueryDataSet("sp_KhachHangTheoDichVuLonHon", CommandType.StoredProcedure,
                new SqlParameter("@LoaiDichVu", loaiDichVu));
        }
        public DataSet LocKhachHangTheoDichVuNhoHon(decimal loaiDichVu)
        {
            return db.ExecuteQueryDataSet("sp_KhachHangTheoDichVuNhoHon", CommandType.StoredProcedure,
                new SqlParameter("@LoaiDichVu", loaiDichVu));
        }
        public DataTable TinhThoiGianChoiKH(int maKH)
        {
            return db.ExecuteQueryDataSet("sp_TinhThoiGianChoiKH", CommandType.StoredProcedure,
                new SqlParameter("@maKH", maKH)).Tables[0];
        }
        public DataSet LocKhachHangChoiHonKPhut(int soPhut)
        {
            return db.ExecuteQueryDataSet("sp_LocKhachHangChoiHonKPhut", CommandType.StoredProcedure,
                new SqlParameter("@soPhut", soPhut));
        }
        public DataSet LocKhachHangChoiNhoHonKPhut(int soPhut)
        {
            return db.ExecuteQueryDataSet("sp_LocKhachHangChoiNhoHonKPhut", CommandType.StoredProcedure,
                new SqlParameter("@soPhut", soPhut));
        }

        //Tính tổng tiền phải trả của 1 khách hàng
        public DataTable TinhTongTienPhaiTra(int maKH)
        {
            return db.ExecuteQueryDataSet("sp_TinhTongTienPhaiTra", CommandType.StoredProcedure,
                new SqlParameter("@maKH", maKH)).Tables[0];
        }

        //Hóa đơn nhiều tiền nhất
        public DataTable HoaDonCoTienLonNhat()
        {
            return db.ExecuteQueryDataSet("sp_HoaDonCoTienLonNhat", CommandType.StoredProcedure).Tables[0];
        }
        //Hóa đơn ít tiền nhất
        public DataTable HoaDonCoTienNhoNhat()
        {
            return db.ExecuteQueryDataSet("sp_HoaDonCoTienNhoNhat", CommandType.StoredProcedure).Tables[0];
        }
        //In ra tất cả hóa đơn 
        public DataSet InTatCaHoaDon()
        {
            return db.ExecuteQueryDataSet("sp_InTatCaHoaDon", CommandType.StoredProcedure);
        }

    }
}
