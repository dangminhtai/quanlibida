using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class DichVuTheoTen : Form
    {
        BAL bllDV=new BAL();
        string name;
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
                DataSet ds = bllDV.TimDichVuTheoTen(name);
                dgvname.DataSource = ds.Tables[0]; // Đổ dữ liệu vào DataGridView
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
