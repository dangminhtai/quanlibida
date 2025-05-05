using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLLBill
{
    public class TinhTongTienPhaiTraResult
    {
        public int maKH { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public int TongPhutChoi { get; set; }
        public decimal TienBan { get; set; }
        public decimal TongTienDV { get; set; }
        public decimal TongTienPhaiTra { get; set; }
    }



    public class BillBLL
    {
        private MyDbContext db = new MyDbContext();
        public TinhTongTienPhaiTraResult GetBillInfo(int maKH)
        {
            var param = new SqlParameter("@maKH", maKH);
            var result = db.Database.SqlQuery<TinhTongTienPhaiTraResult>("sp_TinhTongTienPhaiTra @maKH", param).FirstOrDefault();
            return result;
        }


    }
}
