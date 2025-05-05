using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLStaff;
namespace quanlibida
{
    public partial class NhanVienTheoNam : Form
    {
        private int nam;
        private StaffBLL bllNhanVien = new StaffBLL(); 
        public NhanVienTheoNam(int nam)
        {
            InitializeComponent();
            this.nam = nam;
           
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var ds = bllNhanVien.LayNhanVienTheoNam(nam);
                dgvNam.DataSource = ds; // Đổ dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvNam_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NhanVienTheoNam_Load(object sender, EventArgs e)
        {

        }
    }
}
