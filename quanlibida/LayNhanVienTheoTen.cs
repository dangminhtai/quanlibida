using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLStaff;
namespace quanlibida
{
    public partial class LayNhanVienTheoTen : Form
    {
        private string name;
        private StaffBLL bllNhanVien = new StaffBLL();
        public LayNhanVienTheoTen(string name)
        {
            InitializeComponent();
            this.name = name;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var ds = bllNhanVien.LayNhanVienTheoTen(name);
                dgvNam.DataSource = ds; // Đổ dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LayNhanVienTheoTen_Load(object sender, EventArgs e)
        {

        }
    }
}
