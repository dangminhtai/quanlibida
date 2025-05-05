using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLStaff;
namespace quanlibida
{
    public partial class LuongNhanVienLonHon : Form
    {
        private decimal luongMin;
        private StaffBLL bllNhanVien = new StaffBLL();
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
               var ds = bllNhanVien.LayNhanVienTheoLuongMin(luongMin);
                dgvLuongLonHon.DataSource = ds; // Đổ dữ liệu vào DataGridView
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
