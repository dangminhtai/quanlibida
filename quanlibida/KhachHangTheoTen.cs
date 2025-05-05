using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLCustomer;
namespace quanlibida
{
    public partial class KhachHangTheoTen : Form
    {
        private string name;
        private CustomerBLL bllKhachHang = new CustomerBLL();
        public KhachHangTheoTen(string name)
        {

            InitializeComponent();
            this.name = name;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var ds = bllKhachHang.LayKhachHangTheoTen(name);
                dgvAddress.DataSource = ds;// Đổ dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhachHangTheoTen_Load(object sender, EventArgs e)
        {

        }
    }
}
