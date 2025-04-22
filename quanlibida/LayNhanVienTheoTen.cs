using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class LayNhanVienTheoTen : Form
    {
        private string name;
        private BAL bllNhanVien = new BAL();
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
                DataSet ds = bllNhanVien.LayNhanVienTheoTen(name);
                dgvNam.DataSource = ds.Tables[0]; // Đổ dữ liệu vào DataGridView
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
