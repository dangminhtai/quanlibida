using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DAL;

namespace BLLRevenue
{
    public class RevenueBLL
    {
        private MyDbContext db = new MyDbContext();

        public List<Revenue> LayDoanhThu()
        {
            return db.Database.SqlQuery<Revenue>("SELECT * FROM Revenue").ToList();
        }
        // Tính tổng doanh thu thuê bàn trong khoảng thời gian
        public decimal TinhTongDoanhThuThueBan(DateTime startDate, DateTime endDate)
        {
            var startParam = new SqlParameter("@StartDate", startDate);
            var endParam = new SqlParameter("@EndDate", endDate);

            var result = db.Database.SqlQuery<decimal>(
                "spTinhTongDoanhThuThueBan @StartDate, @EndDate",
                startParam, endParam
            ).FirstOrDefault();

            return result;
        }


        // Tính tổng doanh thu thuê đồ ăn trong khoảng thời gian
        public decimal TinhTongDoanhThuThueDoAn(DateTime startDate, DateTime endDate)
        {
            var startParam = new SqlParameter("@StartDate", startDate);
            var endParam = new SqlParameter("@EndDate", endDate);

            var result = db.Database.SqlQuery<decimal>("sp_TinhTongDoanhThuThueDoAn @StartDate, @EndDate", startParam, endParam).FirstOrDefault();
            return result;
        }

        // Tính tổng doanh thu thuê thức uống trong khoảng thời gian
        public decimal TinhTongDoanhThuThueThucUong(DateTime startDate, DateTime endDate)
        {
            var startParam = new SqlParameter("@StartDate", startDate);
            var endParam = new SqlParameter("@EndDate", endDate);

            var result = db.Database.SqlQuery<decimal>(
                "sp_TinhTongDoanhThuThueThucUong @StartDate, @EndDate",
                startParam, endParam
            ).FirstOrDefault();

            return result;
        }

        // Tính doanh thu trong 1 ngày cụ thể
        public decimal DoanhThuNgay(DateTime date)
        {
            var dateParam = new SqlParameter("@Ngay", date);

            var result = db.Database.SqlQuery<decimal>("sp_DoanhThuTrongNgay @Ngay", dateParam).FirstOrDefault();
            return result;
        }

        // Tính tổng tiền tất cả dịch vụ trong khoảng thời gian
        public decimal TinhTongTienTatCaDichVu(DateTime startDate, DateTime endDate)
        {
            var startParam = new SqlParameter("@StartDate", startDate);
            var endParam = new SqlParameter("@EndDate", endDate);

            var result = db.Database.SqlQuery<decimal>(
                "sp_TinhTongTienTatCaDichVu @StartDate, @EndDate",
                startParam, endParam
            ).FirstOrDefault();

            return result;
        }




        // Thêm Revenue mới
        public bool ThemRevenue(Revenue revenue, out string errorMessage)
        {
            try
            {
                // Kiểm tra RevenueID có bị trùng không
                bool exists = db.Revenue.Any(r => r.RevenueID == revenue.RevenueID);
                if (exists)
                {
                    errorMessage = $"RevenueID {revenue.RevenueID} đã tồn tại.";
                    return false;
                }

                db.Revenue.Add(revenue);
                db.SaveChanges();
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                return false;
            }
        }




        // Sửa Revenue
        public bool SuaRevenue(Revenue revenue)
        {
            try
            {
                var existingRevenue = db.Revenue.Find(revenue.RevenueID);
                if (existingRevenue == null) return false;

                existingRevenue.RevenueDate = revenue.RevenueDate;
                existingRevenue.TableRevenue = revenue.TableRevenue;
                existingRevenue.FoodRevenue = revenue.FoodRevenue;
                existingRevenue.DrinkRevenue = revenue.DrinkRevenue;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa Revenue
        public bool XoaRevenue(int revenueID, out string errorMessage)
        {
            try
            {
                var revenue = db.Revenue.Find(revenueID);
                if (revenue == null)
                {
                    errorMessage = "Không tìm thấy doanh thu với mã đã chọn.";
                    return false;
                }

                db.Revenue.Remove(revenue);
                db.SaveChanges();
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

    }
}
