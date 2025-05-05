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
using BLLStaff;
namespace quanlibida
{
    public partial class LuongNhanVienNhoHon : Form
    {
        private decimal luongMax;
        private StaffBLL bllNhanVien = new StaffBLL();
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
                var ds = bllNhanVien.LayNhanVienTheoLuongMax(luongMax);
                dgvNam.DataSource = ds; // Đổ dữ liệu vào DataGridView
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
