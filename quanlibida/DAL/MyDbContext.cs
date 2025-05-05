using DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Quanlybida_db") { }

        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<DichVu> DichVu { get; set; }
        public DbSet<Revenue> Revenue { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}
