using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLBooking;
using DAL;
using System.Collections.Generic;
namespace quanlibida
{
    public partial class FrmBooking : Form
    {
       BookingBLL dbst= new BookingBLL();
        // Đối tượng đưa dữ liệu vào DataTable dtBooking 
        public static DataTable dtBooking { get; set; }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public FrmBooking()
        {
            InitializeComponent();
        
        }
        void LoadData()
        {
            try
            {
                
                // Vận chuyển dữ liệu vào DataTable dtBooking 
                dtBooking = new DataTable();
                dtBooking.Clear();
                List<Booking> listBooking = dbst.LayBooking();
                dgvBooking.DataSource = listBooking;


                // Xóa trống các đối tượng trong Panel 

                this.txtBookingID.ResetText();
                this.txtIDKH.ResetText();
                this.txt_timeStart.ResetText();
                this.txt_timeEnd.ResetText();
                this.txt_OrderDV.ResetText();
                this.txt_tableType.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                dgvBooking_CellClick(null, null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL!\nMã lỗi: {ex.Number}\nThông báo: {ex.Message}\nChi tiết: {ex.StackTrace}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định!\nThông báo: {ex.Message}\nChi tiết: {ex.StackTrace}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmBooking_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng không click vào tiêu đề cột
           
                // Lấy chỉ mục dòng hiện tại
                int r = dgvBooking.CurrentCell.RowIndex;

                // Chuyển thông tin lên các ô nhập liệu trên panel
                this.txtBookingID.Text = dgvBooking.Rows[r].Cells["BookingID"].Value.ToString();
                this.txtIDKH.Text = dgvBooking.Rows[r].Cells["maKH"].Value.ToString();
                this.txt_timeStart.Text = Convert.ToDateTime(dgvBooking.Rows[r].Cells["BookingTimeStart"].Value).ToString("yyyy-MM-dd HH:mm:ss");
                this.txt_timeEnd.Text = dgvBooking.Rows[r].Cells["BookingTimeEnd"].Value != DBNull.Value
                    ? Convert.ToDateTime(dgvBooking.Rows[r].Cells["BookingTimeEnd"].Value).ToString("yyyy-MM-dd HH:mm:ss")
                    : "";
                this.txt_OrderDV.Text = dgvBooking.Rows[r].Cells["MoneyDV"].Value.ToString();
                this.txt_tableType.Text = dgvBooking.Rows[r].Cells["TableType"].Value.ToString();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.panel.Enabled = true;
            this.txtBookingID.ResetText();
            this.txtIDKH.ResetText();
            this.txt_timeStart.ResetText();
            this.txt_timeEnd.ResetText();
            this.txt_OrderDV.ResetText();
            this.txt_tableType.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.btnThem.Enabled = false;  
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.txtBookingID.Enabled = true;
            this.txtIDKH.Enabled = true;
            this.txtBookingID.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvBooking_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtBookingID.Enabled = false;
            this.txtIDKH.Enabled = false;
            this.txt_timeStart.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBooking.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một booking để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookingID = dgvBooking.CurrentRow.Cells["BookingID"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa booking có mã {bookingID}?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string err = string.Empty;
                bool success = dbst.XoaBooking(ref err, bookingID);

                if (success)
                {
                    //dgvBooking.Rows.Remove(dgvBooking.CurrentRow);
                    var list = dgvBooking.DataSource as List<Booking>;
                    var selectedItem = (Booking)dgvBooking.CurrentRow.DataBoundItem;

                    list.Remove(selectedItem);
                    dgvBooking.DataSource = null;
                    dgvBooking.DataSource = list;

                    MessageBox.Show("✅ Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"❌ Không thể xóa booking!\nLỗi: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string bookingID = txtBookingID.Text.Trim();
                int maKH = int.Parse(txtIDKH.Text);
                DateTime bookingTimeStart = DateTime.Parse(txt_timeStart.Text);
                DateTime bookingTimeEnd = DateTime.Parse(txt_timeEnd.Text);
                decimal moneyDV = decimal.Parse(txt_OrderDV.Text);
                string tableType = txt_tableType.Text.Trim();

                if (bookingTimeEnd < bookingTimeStart)
                {
                    MessageBox.Show("Thời gian vào không được phép lớn hơn thời gian ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Booking booking = new Booking
                {
                    BookingID = bookingID,
                    MaKH = maKH,
                    BookingTimeStart = bookingTimeStart,
                    BookingTimeEnd = bookingTimeEnd,
                    MoneyDV = moneyDV,
                    TableType = tableType
                };

                string err = string.Empty;
                bool success = false;

                if (Them)
                {
                    success = dbst.ThemBooking(ref err, booking);
                    if (success)
                        MessageBox.Show("✅ Đã thêm booking thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"❌ Thêm booking thất bại!\nLỗi: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    success = dbst.SuaBooking(ref err, booking);
                    if (success)
                        MessageBox.Show("✅ Đã cập nhật booking thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"❌ Cập nhật booking thất bại!\nLỗi: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (success)
                    LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã cập nhật mọi dữ liệu");
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 

            this.txtBookingID.ResetText();
            this.txtIDKH.ResetText();
            this.txt_timeStart.ResetText();
            this.txt_timeEnd.ResetText();
            this.txt_OrderDV.ResetText();
            this.txt_tableType.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvBooking_CellClick(null, null);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn trở về không?",
                                                "Xác nhận",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Bookingquery frm = new Bookingquery();
            frm.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
