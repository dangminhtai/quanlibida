using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL;

namespace BLLDichVu
{
    public class DichVuBLL
    {
        private MyDbContext db = new MyDbContext();

        // Lấy dịch vụ theo Thức Ăn
        public List<DichVu> LayDichVuTheoThucAn()
        {
            return db.Database.SqlQuery<DichVu>("spLayDichVuTheoThucAn").ToList();
        }

        // Lấy dịch vụ theo Thức Uống
        public List<DichVu> LayDichVuTheoThucUong()
        {
            return db.Database.SqlQuery<DichVu>("spLayDichVuTheoThucUong").ToList();
        }

        // Lấy dịch vụ theo giá
        public List<DichVu> LayDichVuTheoGia(decimal giaMin, decimal giaMax)
        {
            var giaMinParam = new SqlParameter("@GiaMin", giaMin);
            var giaMaxParam = new SqlParameter("@GiaMax", giaMax);

            return db.Database.SqlQuery<DichVu>("spLayDichVuTheoGia @GiaMin, @GiaMax", giaMinParam, giaMaxParam).ToList();
        }

        // Tìm dịch vụ có giá tiền lớn nhất (chỉ lấy 1 dịch vụ)
        public DichVu TimDichVuCoGiaTienLonNhat()
        {
            return db.Database.SqlQuery<DichVu>("spTimDichVuCoGiaTienLonNhat").FirstOrDefault();
        }

        // Tìm dịch vụ có giá tiền thấp nhất (chỉ lấy 1 dịch vụ)
        public DichVu TimDichVuCoGiaTienThapNhat()
        {
            return db.Database.SqlQuery<DichVu>("spTimDichVuCoGiaTienThapNhat").FirstOrDefault();
        }

        // Tìm dịch vụ theo tên (trả về nhiều dịch vụ nếu trùng tên)
        public List<DichVu> TimDichVuTheoTen(string tenDV)
        {
            var tenDVParam = new SqlParameter("@TenDV", tenDV);

            return db.Database.SqlQuery<DichVu>("spTimDichVuTheoTen @TenDV", tenDVParam).ToList();
        }
        public bool ThemDichVu(string TenDV, string LoaiDV, decimal GiaTien)
        {
            try
            {
                var tenDVParam = new SqlParameter("@TenDV", TenDV);
                var loaiDVParam = new SqlParameter("@LoaiDV", LoaiDV);
                var giaTienParam = new SqlParameter("@GiaTien", GiaTien);

                db.Database.ExecuteSqlCommand(
                    "EXEC spThemDichVu @TenDV, @LoaiDV, @GiaTien",
                    tenDVParam, loaiDVParam, giaTienParam
                );

                return true; // Nếu không có lỗi thì return true
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm dịch vụ: " + ex.Message);
                return false;
            }
        }



        // 📌 Cập nhật dịch vụ
        public bool CapNhatDichVu(string TenDV, string LoaiDV, decimal GiaTien)
        {
            try
            {
                var tenDVParam = new SqlParameter("@TenDV", TenDV);
                var loaiDVParam = new SqlParameter("@LoaiDV", LoaiDV);
                var giaTienParam = new SqlParameter("@GiaTien", GiaTien);

                db.Database.ExecuteSqlCommand(
                    "EXEC spCapNhatDichVu @TenDV, @LoaiDV, @GiaTien",
                    tenDVParam, loaiDVParam, giaTienParam
                );

                return true; // Không lỗi thì coi như thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật dịch vụ: " + ex.Message);
                return false;
            }
        }


        // 📌 Xóa dịch vụ
        public bool XoaDichVu(string TenDV, string LoaiDV)
        {
            try
            {
                var tenDVParam = new SqlParameter("@TenDV", TenDV);
                var loaiDVParam = new SqlParameter("@LoaiDV", LoaiDV);
                var rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                db.Database.ExecuteSqlCommand(
                    "EXEC spXoaDichVu @TenDV, @LoaiDV, @RowsAffected OUTPUT",
                    tenDVParam, loaiDVParam, rowsAffectedParam
                );

                int rowsAffected = (int)rowsAffectedParam.Value;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa dịch vụ: " + ex.Message);
                return false;
            }
        }

        public List<DichVu> LayDichVu()
        {
            using (var context = new MyDbContext())
            {
                return context.DichVu.ToList(); // đơn giản, chuẩn Entity Framework
            }
        }

    }
}
