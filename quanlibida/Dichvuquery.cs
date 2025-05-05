using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLLDichVu;
using DAL;

namespace quanlibida
{
    public partial class Dichvuquery : Form
    {
        DichVuBLL dbst2 = new DichVuBLL();
        public Dichvuquery()
        {
            InitializeComponent();
          
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
                DichVu dichVu = dbst2.TimDichVuCoGiaTienLonNhat(); // Gọi stored procedure

                if (dichVu != null)
                {
                    // Hiển thị thông tin bằng MessageBox
                    MessageBox.Show($"📌 Dịch vụ có giá cao nhất\n\n"
                                  + $"🛎️ Tên dịch vụ: {dichVu.TenDV}\n"
                                  + $"📌 Loại dịch vụ: {dichVu.LoaiDV}\n"
                                  + $"💰 Giá tiền: {dichVu.GiaTien:N0} VND",
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
                DichVu dichVu = dbst2.TimDichVuCoGiaTienThapNhat(); // Gọi stored procedure

                if (dichVu != null)
                {
                    // Hiển thị thông tin bằng MessageBox
                    MessageBox.Show($"📌 Dịch vụ có giá thấp nhất\n\n"
                                  + $"🛎️ Tên dịch vụ: {dichVu.TenDV}\n"
                                  + $"📌 Loại dịch vụ: {dichVu.LoaiDV}\n"
                                  + $"💰 Giá tiền: {dichVu.GiaTien:N0} VND",
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
