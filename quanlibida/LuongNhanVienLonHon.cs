using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class LuongNhanVienLonHon : Form
    {
        private decimal luongMin;
        private BAL bllNhanVien = new BAL();
        public LuongNhanVienLonHon(decimal luongMin)
        {
            InitializeComponent();
            this.luongMin= luongMin;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                DataSet ds = bllNhanVien.LayNhanVienTheoLuongMin(luongMin);
                dgvLuongLonHon.DataSource = ds.Tables[0]; // Đổ dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LuongNhanVienNhoNhat_Load(object sender, EventArgs e)
        {
        
        }

        private void dgvNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNam_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
