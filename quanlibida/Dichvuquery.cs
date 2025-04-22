using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class Dichvuquery : Form
    {
        BAL dbst2;
        public Dichvuquery()
        {
            InitializeComponent();
            dbst2 = new BAL();
        }

        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            FoodDichVu frm=new FoodDichVu();
            frm.ShowDialog();
        }

        private void btntimkiem2_Click(object sender, EventArgs e)
        {
            DrinkDichVu frm=new DrinkDichVu();
            frm.ShowDialog();
        }

        private void btntimkiem3_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dbst2.TimDichVuCoGiaTienLonNhat(); // Gọi stored procedure

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên (dịch vụ có giá cao nhất)
                    string tenDV = row["TenDV"].ToString();
                    string loaiDV = row["LoaiDV"].ToString();
                    decimal giaTien = Convert.ToDecimal(row["GiaTien"]);

                    // Hiển thị thông tin bằng MessageBox
                    MessageBox.Show($"📌 Dịch vụ có giá cao nhất\n\n"
                                  + $"🛎️ Tên dịch vụ: {tenDV}\n"
                                  + $"📌 Loại dịch vụ: {loaiDV}\n"
                                  + $"💰 Giá tiền: {giaTien:N0} VND",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy dịch vụ có giá cao nhất!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void btntimkiem4_Click(object sender, EventArgs e)
        {
            DichVuTheoGia frm = new DichVuTheoGia();
            frm.ShowDialog();
        }

        private void btntimkiem6_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dbst2.TimDichVuCoGiaTienThapNhat(); // Gọi stored procedure

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên (dịch vụ có giá thấp nhất)
                    string tenDV = row["TenDV"].ToString();
                    string loaiDV = row["LoaiDV"].ToString();
                    decimal giaTien = Convert.ToDecimal(row["GiaTien"]);

                    // Hiển thị thông tin bằng MessageBox
                    MessageBox.Show($"📌 Dịch vụ có giá thấp nhất\n\n"
                                  + $"🛎️ Tên dịch vụ: {tenDV}\n"
                                  + $"📌 Loại dịch vụ: {loaiDV}\n"
                                  + $"💰 Giá tiền: {giaTien:N0} VND",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy dịch vụ có giá thấp nhất!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btntimkiem5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNam.Text)) 
            {
                string keyword = txtNam.Text; 
                DichVuTheoTen frm = new DichVuTheoTen(keyword);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void btnTroVe_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void Dichvuquery_Load(object sender, EventArgs e)
        {

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDichVu frm = new FrmDichVu();
            frm.ShowDialog();
            this.Show();
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
