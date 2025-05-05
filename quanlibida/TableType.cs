using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLBooking;
namespace quanlibida
{
    public partial class TableType : Form
    {
        private BookingBLL db = new BookingBLL();

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
            var ds = db.LocKhachHangTheoBan(loaiBan);

            // Hiển thị lên DataGridView
            dgvtype.DataSource = ds;
        }

        private void dgvtype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
