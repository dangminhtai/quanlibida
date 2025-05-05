using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLLDichVu;
using DAL;

namespace quanlibida
{
    public partial class DichVuTheoTen : Form
    {
       DichVuBLL bllDV = new DichVuBLL();
        private string name;
        public DichVuTheoTen(string name)
        {
            InitializeComponent();
            this.name = name;
            LoadData();
             
        }
        private void LoadData()
        {
            try
            {
                // Gọi phương thức lấy dữ liệu
                List<DichVu> danhSachDichVu = bllDV.TimDichVuTheoTen(name);

                // Đổ dữ liệu vào DataGridView
                dgvname.DataSource = danhSachDichVu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DichVuTheoTen_Load(object sender, EventArgs e)
        {

        }

        private void dgvname_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
