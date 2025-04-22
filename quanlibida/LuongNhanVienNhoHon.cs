using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class LuongNhanVienNhoHon : Form
    {
        private decimal luongMax;
        private BAL bllNhanVien = new BAL();
        public LuongNhanVienNhoHon(decimal luongMax)
        {
            InitializeComponent();
            this.luongMax = luongMax;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                DataSet ds = bllNhanVien.LayNhanVienTheoLuongMax(luongMax);
                dgvNam.DataSource = ds.Tables[0]; // Đổ dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LuongNhanVienNhoHon_Load(object sender, EventArgs e)
        {

        }

        private void dgvNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
