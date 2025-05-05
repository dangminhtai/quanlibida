using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLRevenue;
using System.Linq;
using DAL;

namespace quanlibida
{
    public partial class Revenuequery : Form
    {
        RevenueBLL dbst2= new RevenueBLL();
        public Revenuequery()
        {
            InitializeComponent();
     
        }

        private void Revenuequery_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTable_start.Text) || string.IsNullOrWhiteSpace(txtTable_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(txtTable_start.Text, out DateTime startDate) || !DateTime.TryParse(txtTable_end.Text, out DateTime endDate))
                {
                    MessageBox.Show("Ngày nhập vào không hợp lệ. Vui lòng nhập đúng định dạng mm/dd/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tongDoanhThu = dbst2.TinhTongDoanhThuThueBan(startDate, endDate);

                if (tongDoanhThu > 0)
                {
                    MessageBox.Show($"Tổng doanh thu từ thuê bàn: {tongDoanhThu:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtTable_start_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập dữ liệu chưa
                if (string.IsNullOrWhiteSpace(txtFood_start.Text) || string.IsNullOrWhiteSpace(txtFood_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi TextBox thành DateTime
                if (!DateTime.TryParse(txtFood_start.Text, out DateTime startDate) || !DateTime.TryParse(txtFood_end.Text, out DateTime endDate))
                {
                    MessageBox.Show("Ngày nhập vào không hợp lệ. Vui lòng nhập đúng định dạng mm/dd/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra nếu ngày bắt đầu lớn hơn ngày kết thúc
                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gọi phương thức từ lớp BLL (trả về 1 số, không còn là danh sách nữa)
                decimal tongDoanhThu = dbst2.TinhTongDoanhThuThueDoAn(startDate, endDate);

                if (tongDoanhThu > 0)
                {
                    MessageBox.Show($"Tổng doanh thu từ thuê đồ ăn: {tongDoanhThu:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDrink_start.Text) || string.IsNullOrWhiteSpace(txtDrink_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(txtDrink_start.Text, out DateTime startDate) || !DateTime.TryParse(txtDrink_end.Text, out DateTime endDate))
                {
                    MessageBox.Show("Ngày nhập vào không hợp lệ. Vui lòng nhập đúng định dạng mm/dd/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tongDoanhThu = dbst2.TinhTongDoanhThuThueThucUong(startDate, endDate);

                if (tongDoanhThu > 0)
                {
                    MessageBox.Show($"Tổng doanh thu từ thuê thức uống: {tongDoanhThu:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRevenue_start.Text) || string.IsNullOrWhiteSpace(txtRevenue_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(txtRevenue_start.Text, out DateTime startDate) || !DateTime.TryParse(txtRevenue_end.Text, out DateTime endDate))
                {
                    MessageBox.Show("Ngày nhập vào không hợp lệ. Vui lòng nhập đúng định dạng mm/dd/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tongDoanhThu = dbst2.TinhTongTienTatCaDichVu(startDate, endDate);

                if (tongDoanhThu > 0)
                {
                    MessageBox.Show($"Tổng doanh thu là: {tongDoanhThu:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btn5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRevenueday.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(txtRevenueday.Text, out DateTime date))
                {
                    MessageBox.Show("Ngày nhập vào không hợp lệ. Vui lòng nhập đúng định dạng mm/dd/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tongDoanhThu = dbst2.DoanhThuNgay(date);

                if (tongDoanhThu > 0)
                {
                    MessageBox.Show($"Tổng doanh thu trong ngày {date:MM/dd/yyyy} là: {tongDoanhThu:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong ngày này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btntimkiem1_Click(object sender, EventArgs e)
        {

        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRevenue frm = new FrmRevenue();
            frm.ShowDialog();
            this.Show();
        }
    }
}
