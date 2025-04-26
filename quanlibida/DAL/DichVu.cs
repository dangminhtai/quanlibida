
namespace DAL
{
    public class DichVu
    {
        public string TenDV { get; set; }
        public string LoaiDV { get; set; }
        public decimal GiaTien { get; set; }

        public DichVu() { }

        public DichVu(string tenDV, string loaiDV, decimal giaTien)
        {
            TenDV = tenDV;
            LoaiDV = loaiDV;
            GiaTien = giaTien;
        }

        public override string ToString()
        {
            return $"Tên dịch vụ: {TenDV}, Loại dịch vụ: {LoaiDV}, Giá tiền: {GiaTien} VNĐ";
        }
    }
}
