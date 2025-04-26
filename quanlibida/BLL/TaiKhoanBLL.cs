using DAL;
using System.Linq;

namespace BLL
{
    public class TaiKhoanBLL
    {
        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            using (var db = new MyDbContext())
            {
                return db.TaiKhoans.Any(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau);
            }
        }
        public bool TonTaiTenDangNhap(string tenDangNhap)
        {
            using (var db = new MyDbContext())
            {
                return db.TaiKhoans.Any(tk => tk.TenDangNhap == tenDangNhap);
            }
        }

    }
}
