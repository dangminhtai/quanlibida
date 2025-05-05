using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLLDichVu;
using DAL;

namespace quanlibida
{
    public partial class DichVuTheoGia : Form
    {
        DichVuBLL bllDV = new DichVuBLL();
        public DichVuTheoGia()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                // Chuyển đổi giá trị nhập vào từ TextBox sang decimal
                decimal giaMin = Convert.ToDecimal(txtstart.Text);
                decimal giaMax = Convert.ToDecimal(txtend.Text);

                // Gọi phương thức lấy dữ liệu
                List<DichVu> danhSachDichVu = bllDV.LayDichVuTheoGia(giaMin, giaMax);

                // Đổ dữ liệu vào DataGridView
                dgvPrice.DataSource = danhSachDichVu;
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho khoảng giá.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DichVuTheoGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
