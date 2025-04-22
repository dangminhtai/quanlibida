using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class FrmUser : Form
    {
        BAL dbst;
        // Đối tượng đưa dữ liệu vào DataTable dtUser 
        public static DataTable dtUser { get; set; }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public FrmUser()
        {

            InitializeComponent();
            dbst = new BAL();
        }
        void LoadData()
        {
            try
            {
               
                // Vận chuyển dữ liệu vào DataTable dtUser 
                dtUser = new DataTable();
                dtUser.Clear();
                dtUser = dbst.LayKhachHang().Tables[0];
                // Đưa dữ liệu lên DataGridView  
                dgvUser.DataSource = dtUser;

                // Xóa trống các đối tượng trong Panel 

                this.txtNameKH.ResetText();
                this.txtMaKH.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                dgvUser_CellClick(null, null);
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

        private void FrmUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmUser_Click(object sender, EventArgs e)
        {

        }

        

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvUser.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaKH.Text = dgvUser.Rows[r].Cells["maKH"].Value.ToString();
            this.txtNameKH.Text=dgvUser.Rows[r].Cells["hoTen"].Value.ToString();
            this.txtSDT.Text = dgvUser.Rows[r].Cells["soDienThoai"].Value.ToString();
            this.txtAddress.Text = dgvUser.Rows[r].Cells["diaChi"].Value.ToString();
            this.txtAmount.Text = dgvUser.Rows[r].Cells["tienTichLuy"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong Panel 

            this.txtMaKH.ResetText();
            this.txtNameKH.ResetText();
            this.txtAddress.ResetText();
            this.txtAmount.ResetText();
            this.txtSDT.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtName
            this.txtMaKH.Enabled = true;
            this.txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvUser_CellClick(null, null);
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
            this.txtMaKH.Enabled= false;
            this.txtNameKH.Focus();
            

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 

            this.txtMaKH.ResetText();
            this.txtNameKH.ResetText();
            this.txtAddress.ResetText();
            this.txtAmount.ResetText();
            this.txtSDT.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvUser_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            if (Them)
            {
                try
                {
                    //Lệnh Insert Into
                    bool f = dbst.ThemKhachHang(ref err,
                        int.Parse(this.txtMaKH.Text),
                        this.txtNameKH.Text.ToString(),
                        this.txtSDT.Text.ToString(),
                        this.txtAddress.Text.ToString(),
                        decimal.Parse(this.txtAmount.Text) // Chỉnh từ int.Parse sang decimal.Parse
                    );

                    if (f)
                    {
                        //Load lại dữ liệu trên DataGridView
                        LoadData();
                        //Thông báo
                        MessageBox.Show("Đã Thêm Xong");
                    }
                    else
                    {
                        MessageBox.Show("Chưa thêm xong!\n\r" + "Lỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không Thêm được, lỗi rồi! \nThông báo: {ex.Message}\nChi tiết: {ex.StackTrace}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    //Lệnh Insert Into
                    bool f = dbst.CapNhatKhachHang(ref err,
                        int.Parse(this.txtMaKH.Text),
                        this.txtNameKH.Text.ToString(),
                        this.txtSDT.Text.ToString(),
                        this.txtAddress.Text.ToString(),

                        decimal.Parse(this.txtAmount.Text) // Chỉnh từ int.Parse sang decimal.Parse
                    );





                    if (f)
                    {
                        //Load lại dữ liệu trên DataGridView
                        LoadData();
                        //Thông báo
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

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã Cập nhật mọi dữ liệu.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(dgvUser.CurrentRow.Cells["MaKH"].Value.ToString(), out id))
            {
                MessageBox.Show("Mã Khách Hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng có mã là {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string err = "";
                bool success = dbst.XoaKhachHang(ref err, id);

                if (success)
                {
                    dgvUser.Rows.Remove(dgvUser.CurrentRow); // Xóa luôn trên giao diện
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi xóa: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            Userquery frm = new Userquery();
            frm.ShowDialog();
        }
    }
}
