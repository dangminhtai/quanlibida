using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLCustomer;
using System.Linq;
namespace quanlibida
{
    public partial class Userquery : Form
    {
        CustomerBLL dbst2 = new CustomerBLL();
        public Userquery()
        {
            InitializeComponent();
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi phương thức để lấy danh sách khách hàng có tiền tích lũy lớn nhất
                var khachHangs = dbst2.KhachHangNhieuTienNhat();

                if (khachHangs != null && khachHangs.Count > 0)
                {
                    var khachHang = khachHangs.First(); // Lấy khách hàng đầu tiên trong danh sách

                    string maKH = khachHang.MaKH.ToString();
                    string tenKH = khachHang.HoTen;
                    decimal amount = khachHang.TienTichLuy;

                    MessageBox.Show($"Khách hàng có tiền tích lũy lớn nhất\n\n"
                                  + $"🆔 Mã khách hàng: {maKH}\n"
                                  + $"👤 Tên khách hàng: {tenKH}\n"
                                  + $"💰 Số tiền tích lũy: {amount:C}",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng có tiền tích lũy lớn nhất!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }



        private void btntimkiem4_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi phương thức để lấy danh sách khách hàng có ít tiền tích lũy nhất
                var khachHangs = dbst2.KhachHangItTienNhat();

                if (khachHangs != null && khachHangs.Count > 0)
                {
                    var khachHang = khachHangs.First(); // Lấy khách hàng đầu tiên trong danh sách

                    string maKH = khachHang.MaKH.ToString();
                    string tenKH = khachHang.HoTen;
                    decimal amount = khachHang.TienTichLuy;

                    MessageBox.Show($"Khách hàng có số tiền tích lũy ít nhất\n\n"
                                  + $"🆔 Mã khách hàng: {maKH}\n"
                                  + $"👤 Tên khách hàng: {tenKH}\n"
                                  + $"💰 Số tiền tích lũy: {amount:C}",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng có số tiền tích lũy ít nhất!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntimkiem2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtAddress.Text)) // Kiểm tra xem người dùng có nhập địa chỉ không
            {
                string keyword = txtAddress.Text; // Lấy từ khóa tìm kiếm là chuỗi
                KhachHangTheoDiaChi frm = new KhachHangTheoDiaChi(keyword);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập địa chỉ hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btntimkiem6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtname.Text)) // Kiểm tra xem người dùng có nhập địa chỉ không
            {
                string keyword = txtname.Text; // Lấy từ khóa tìm kiếm là chuỗi
                KhachHangTheoTen frm = new KhachHangTheoTen(keyword);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      

        private void Userquery_Load(object sender, EventArgs e)
        {

        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUser frm = new FrmUser();   
            frm.ShowDialog();
            this.Show();
        }
    }
    
}
