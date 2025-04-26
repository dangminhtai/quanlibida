using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DAL;

namespace BLL
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
    }
}
