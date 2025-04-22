using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class TableType : Form
    {
        private BAL db = new BAL();

        public TableType()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TableType_Load(object sender, EventArgs e)
        {

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Lấy giá trị loại bàn từ combobox
            string loaiBan = cboxtype.SelectedItem.ToString();

            // Gọi BLL để lấy danh sách khách hàng theo loại bàn
            DataSet ds = db.LocKhachHangTheoBan(loaiBan);

            // Hiển thị lên DataGridView
            dgvtype.DataSource = ds.Tables[0];
        }

        private void dgvtype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
