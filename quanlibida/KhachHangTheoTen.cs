using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class KhachHangTheoTen : Form
    {
        private string name;
        private BAL bllKhachHang = new BAL();
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
                DataSet ds = bllKhachHang.LayKhachHangTheoTen(name);
                dgvAddress.DataSource = ds.Tables[0]; // Đổ dữ liệu vào DataGridView
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
