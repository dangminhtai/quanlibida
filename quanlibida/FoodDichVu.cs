using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLLDichVu;
using DAL;

namespace quanlibida
{
    public partial class FoodDichVu : Form
    {
        DichVuBLL bllDV = new DichVuBLL();
        public FoodDichVu()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                List<DichVu> danhsachdichvu = bllDV.LayDichVuTheoThucAn();
                dgvFood.DataSource = danhsachdichvu; // Đổ dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FoodDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
