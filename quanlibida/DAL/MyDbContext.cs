using DAl;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=Quanlybida_db") { }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
    }
}
