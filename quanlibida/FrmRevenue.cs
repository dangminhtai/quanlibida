using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class FrmRevenue : Form
    {
        BAL dbst;
        // Đối tượng đưa dữ liệu vào DataTable dtRevenue 
        public static DataTable dtRevenue { get; set; }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public FrmRevenue()
        {
            InitializeComponent();
            dbst = new BAL();
        }
        void LoadData()
        {
            try
            {
               
                // Vận chuyển dữ liệu vào DataTable dtRevenue 
                dtRevenue = new DataTable();
                dtRevenue.Clear();
                dtRevenue = dbst.LayDoanhThu().Tables[0];
                // Đưa dữ liệu lên DataGridView  
                dgvRevenue.DataSource = dtRevenue;

                // Xóa trống các đối tượng trong Panel 

                this.txtRevenueID.ResetText();
                this.txtRevenueDate.ResetText();
                this.txtTableRevenue.ResetText();
                this.txtDrinkRevenue.ResetText();
                this.txtFoodRevenue.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                dgvRevenue_CellClick(null, null);
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
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmRevenue_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvRevenue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRevenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvRevenue.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtRevenueID.Text = dgvRevenue.Rows[r].Cells["RevenueID"].Value.ToString();
            this.txtRevenueDate.Text = Convert.ToDateTime(dgvRevenue.Rows[r].Cells["RevenueDate"].Value)
                            .ToString("MM-dd-yyyy");
            this.txtTableRevenue.Text = dgvRevenue.Rows[r].Cells["TableRevenue"].Value.ToString();
            this.txtFoodRevenue.Text = dgvRevenue.Rows[r].Cells["FoodRevenue"].Value.ToString();
            this.txtDrinkRevenue.Text = dgvRevenue.Rows[r].Cells["DrinkRevenue"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Them
            Them = true;

            // Xóa trống các đối tượng trong Panel
            this.txtRevenueID.ResetText();
            this.txtRevenueDate.ResetText();
            this.txtTableRevenue.ResetText();
            this.txtDrinkRevenue.ResetText();
            this.txtFoodRevenue.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;

            // Đưa con trỏ đến TextField txtRevenueID
            this.txtRevenueID.Enabled = true;
            this.txtRevenueID.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            if (Them)
            {
                try
                {
                    // Thêm mới doanh thu
                    bool f = dbst.ThemDoanhThu(ref err,
                        int.Parse(this.txtRevenueID.Text),
                        DateTime.Parse(this.txtRevenueDate.Text),
                        decimal.Parse(this.txtTableRevenue.Text),
                        decimal.Parse(this.txtFoodRevenue.Text),
                        decimal.Parse(this.txtDrinkRevenue.Text)
                    );

                    if (f)
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Chưa thêm xong!\n\r" + "Lỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thêm được, lỗi rồi!\nThông báo: {ex.Message}\nChi tiết: {ex.StackTrace}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    // Cập nhật doanh thu
                    bool f = dbst.CapNhatDoanhThu(ref err,
                        int.Parse(this.txtRevenueID.Text),
                        DateTime.Parse(this.txtRevenueDate.Text),
                        decimal.Parse(this.txtTableRevenue.Text),
                        decimal.Parse(this.txtFoodRevenue.Text),
                        decimal.Parse(this.txtDrinkRevenue.Text)
                    );

                    if (f)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chưa xong!\n\r" + "Lỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được, lỗi rồi!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;

            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvRevenue_CellClick(null, null);

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
            this.txtRevenueID.Enabled = false; // Không cho sửa mã doanh thu
            this.txtRevenueDate.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvRevenue.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi doanh thu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy RevenueID từ dòng đang chọn
            int revenueId;
            if (!int.TryParse(dgvRevenue.CurrentRow.Cells["RevenueID"].Value.ToString(), out revenueId))
            {
                MessageBox.Show("Mã doanh thu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hỏi xác nhận người dùng
            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa doanh thu có mã {revenueId}?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string err = "";
                bool success = dbst.XoaDoanhThu(ref err, revenueId);

                if (success)
                {
                    LoadData(); // Cập nhật lại danh sách
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi xóa: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các ô nhập liệu trong Panel
            this.txtRevenueID.ResetText();
            this.txtRevenueDate.ResetText();
            this.txtTableRevenue.ResetText();
            this.txtDrinkRevenue.ResetText();
            this.txtFoodRevenue.ResetText();

            // Bật lại các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;

            // Vô hiệu hóa nút Lưu / Hủy và Panel
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;

            // Cập nhật lại giao diện DataGridView
            dgvRevenue_CellClick(null, null);
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

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã Cập nhật mọi dữ liệu.");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Revenuequery frm = new Revenuequery();
            frm.ShowDialog();
        }
    }
}
