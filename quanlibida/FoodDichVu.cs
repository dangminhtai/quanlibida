using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class FoodDichVu : Form
    {
        BAL bllDV=new BAL();
        public FoodDichVu()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                DataSet ds = bllDV.LayDichVuTheoThucAn();
                dgvFood.DataSource = ds.Tables[0]; // Đổ dữ liệu vào DataGridView
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
