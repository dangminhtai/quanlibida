using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLBooking;
using DAL;
using System.Collections.Generic;
namespace quanlibida
{
    public partial class Bookingquery : Form
    {
        BookingBLL dbst2 = new BookingBLL();
        public Bookingquery()
        {
            InitializeComponent();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã khách hàng từ TextBox
                int maKH = int.Parse(txtID.Text.Trim());

                // Gọi Stored Procedure để lấy tổng thời gian chơi (trả về số phút)
                int tongThoiGianPhut = dbst2.TinhThoiGianChoiKH(maKH);

                if (tongThoiGianPhut > 0)
                {
                    // Nếu bạn cần thêm tên, địa chỉ,... thì phải có SP khác trả ra đủ thông tin
                    MessageBox.Show($"🆔 Mã khách hàng: {maKH}\n"
                                  + $"⏳ Tổng thời gian chơi: {tongThoiGianPhut} phút",
                                  "Thông tin khách hàng",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng hoặc chưa có dữ liệu thời gian chơi!",
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


        private void btnquery_Click(object sender, EventArgs e)
        {
            TimePlay frm= new TimePlay();
            frm.ShowDialog();
        }

        private void Bookingquery_Load(object sender, EventArgs e)
        {
           
        }

       

        private void btn1_Click(object sender, EventArgs e)
        {
            TableType frm= new TableType();
            frm.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                decimal soTien;
                if (!decimal.TryParse(txtMoneyDVhigh.Text.Trim(), out soTien))
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Booking> bookings = dbst2.LocKhachHangTheoDichVuNhoHon(soTien);
                if (bookings.Count > 0)
                {
                    // Kiểm tra nếu Form2 đã mở
                    TimePlay frm2 = Application.OpenForms["TimePlay"] as TimePlay;
                    if (frm2 != null)
                    {
                        frm2.UpdateDataGrid(bookings); // UpdateDataGrid nhận List<Booking>
                    }
                    else
                    {
                        frm2 = new TimePlay();
                        frm2.UpdateDataGrid(bookings);
                        frm2.Show();
                    }
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng thỏa mãn",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal soTien;
                if (!decimal.TryParse(txtMoneyDVhigh.Text.Trim(), out soTien))
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Booking> bookings = dbst2.LocKhachHangTheoDichVuLonHon(soTien);
                if (bookings.Count > 0)
                {
                    // Kiểm tra nếu Form2 đã mở
                    TimePlay frm2 = Application.OpenForms["TimePlay"] as TimePlay;
                    if (frm2 != null)
                    {
                        frm2.UpdateDataGrid(bookings); // UpdateDataGrid nhận List<Booking>
                    }
                    else
                    {
                        frm2 = new TimePlay();
                        frm2.UpdateDataGrid(bookings);
                        frm2.Show();
                    }
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng thỏa mãn",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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


        private void txtNam_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntimkiem2_Click(object sender, EventArgs e)
        {

        }

        private void btntimkiem3_Click(object sender, EventArgs e)
        {
            try
            {
                int soPhut;
                if (!int.TryParse(txt1.Text, out soPhut) || soPhut < 0)
                {
                    MessageBox.Show("Vui lòng nhập số phút hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<Booking> bookings = dbst2.LocKhachHangChoiHonKPhut(soPhut);

                if (bookings.Count > 0)
                {
                    // Kiểm tra nếu Form2 đã mở
                    TimePlay frm2 = Application.OpenForms["TimePlay"] as TimePlay;
                    if (frm2 != null)
                    {
                        frm2.UpdateDataGrid(bookings); // Cập nhật List<Booking>
                    }
                    else
                    {
                        frm2 = new TimePlay();
                        frm2.UpdateDataGrid(bookings);
                        frm2.Show();
                    }
                }
                else
                {
                    MessageBox.Show($"❌ Không tìm thấy khách hàng nào chơi hơn {soPhut} phút!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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
            try
            {
                int soPhut;
                if (!int.TryParse(txt2.Text, out soPhut) || soPhut < 0)
                {
                    MessageBox.Show("Vui lòng nhập số phút hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lọc khách hàng chơi ít hơn số phút
                List<Booking> bookings = dbst2.LocKhachHangChoiNhoHonKPhut(soPhut);

                if (bookings.Count > 0)
                {
                    // Kiểm tra nếu Form2 đã mở
                    TimePlay frm2 = Application.OpenForms["TimePlay"] as TimePlay;
                    if (frm2 != null)
                    {
                        frm2.UpdateDataGrid(bookings); // Cập nhật dữ liệu vào dgvTime
                    }
                    else
                    {
                        // Nếu Form2 chưa mở, tạo mới và truyền dữ liệu
                        frm2 = new TimePlay();
                        frm2.UpdateDataGrid(bookings);
                        frm2.Show();
                    }
                }
                else
                {
                    MessageBox.Show($"❌ Không tìm thấy khách hàng nào chơi ít hơn {soPhut} phút!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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


        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBooking frm = new FrmBooking();
            frm.ShowDialog();
            this.Show();
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
