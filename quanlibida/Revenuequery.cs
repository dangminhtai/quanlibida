using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class Revenuequery : Form
    {
        BAL dbst2;
        public Revenuequery()
        {
            InitializeComponent();
            dbst2 = new BAL();
        }

        private void Revenuequery_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập dữ liệu chưa
                if (string.IsNullOrWhiteSpace(txtTable_start.Text) || string.IsNullOrWhiteSpace(txtTable_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi TextBox thành DateTime
                DateTime startDate, endDate;
                if (!DateTime.TryParse(txtTable_start.Text, out startDate) || !DateTime.TryParse(txtTable_end.Text, out endDate))
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

                // Gọi phương thức từ lớp BLL
                DataSet ds = dbst2.TinhTongDoanhThuThueBan(startDate, endDate);

                // Kiểm tra nếu có dữ liệu
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    object value = ds.Tables[0].Rows[0]["TongDoanhThuThueBan"];

                    // Kiểm tra nếu giá trị là DBNull thì gán thành 0
                    decimal tongDoanhThu = value == DBNull.Value ? 0 : Convert.ToDecimal(value);

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
                DateTime startDate, endDate;
                if (!DateTime.TryParse(txtFood_start.Text, out startDate) || !DateTime.TryParse(txtFood_end.Text, out endDate))
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

                // Gọi phương thức từ lớp BLL
                DataSet ds = dbst2.TinhTongDoanhThuThueDoAn(startDate, endDate);

                // Kiểm tra nếu có dữ liệu
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    object value = ds.Tables[0].Rows[0]["TongDoanhThuThueDoAn"];

                    // Kiểm tra nếu giá trị là DBNull thì gán thành 0
                    decimal tongDoanhThu = value == DBNull.Value ? 0 : Convert.ToDecimal(value);

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
                // Kiểm tra xem người dùng đã nhập dữ liệu chưa
                if (string.IsNullOrWhiteSpace(txtDrink_start.Text) || string.IsNullOrWhiteSpace(txtDrink_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi TextBox thành DateTime
                DateTime startDate, endDate;
                if (!DateTime.TryParse(txtDrink_start.Text, out startDate) || !DateTime.TryParse(txtDrink_end.Text, out endDate))
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

                // Gọi phương thức từ lớp BLL
                DataSet ds = dbst2.TinhTongDoanhThuThueThucUong(startDate, endDate);

                // Kiểm tra nếu có dữ liệu
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    object value = ds.Tables[0].Rows[0]["TongDoanhThuThueThucUong"];

                    // Kiểm tra nếu giá trị là DBNull thì gán thành 0
                    decimal tongDoanhThu = value == DBNull.Value ? 0 : Convert.ToDecimal(value);

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
                // Kiểm tra xem người dùng đã nhập dữ liệu chưa
                if (string.IsNullOrWhiteSpace(txtRevenue_start.Text) || string.IsNullOrWhiteSpace(txtRevenue_end.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi TextBox thành DateTime
                DateTime startDate, endDate;
                if (!DateTime.TryParse(txtRevenue_start.Text, out startDate) || !DateTime.TryParse(txtRevenue_end.Text, out endDate))
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

                // Gọi phương thức từ lớp BLL
                DataSet ds = dbst2.TinhTongTienTatCaDichVu(startDate, endDate);

                // Kiểm tra nếu có dữ liệu
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    object value = ds.Tables[0].Rows[0]["TongDoanhThu"];

                    // Kiểm tra nếu giá trị là DBNull thì gán thành 0
                    decimal tongDoanhThu = value == DBNull.Value ? 0 : Convert.ToDecimal(value);

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
                // Kiểm tra xem người dùng đã nhập dữ liệu chưa
                if (string.IsNullOrWhiteSpace(txtRevenueday.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi TextBox thành DateTime
                DateTime Date;
                if (!DateTime.TryParse(txtRevenueday.Text, out Date))
                {
                    MessageBox.Show("Ngày nhập vào không hợp lệ. Vui lòng nhập đúng định dạng mm/dd/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

     

                // Gọi phương thức từ lớp BLL
                DataSet ds = dbst2.DoanhThuNgay(Date);

                // Kiểm tra nếu có dữ liệu
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    object value = ds.Tables[0].Rows[0]["DoanhThuNgay"];

                    // Kiểm tra nếu giá trị là DBNull thì gán thành 0
                    decimal tongDoanhThu = value == DBNull.Value ? 0 : Convert.ToDecimal(value);

                    MessageBox.Show($"Tổng doanh thu trong ngày {txtRevenueday.Text} là: {tongDoanhThu:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
