using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer;
namespace quanlibida
{
    public partial class FrmStaff : Form
    {

        BAL dbst;
        // Đối tượng đưa dữ liệu vào DataTable dtStaff 
        public static DataTable dtStaff { get; set; }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public FrmStaff()
        {
            InitializeComponent();
            dbst = new BAL();
        }
        //
        void LoadData()
        {
            try
            {
               
              
                // Vận chuyển dữ liệu vào DataTable dtStaff 
                dtStaff = new DataTable();
                dtStaff.Clear();
                dtStaff = dbst.LayNhanVien().Tables[0];
                // Đưa dữ liệu lên DataGridView  
                dgvSTAFF.DataSource = dtStaff;

                // Xóa trống các đối tượng trong Panel 
              
                this.txtName.ResetText();
                this.txtGmail.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                dgvSTAFF_CellClick(null, null);
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
        private void dgvSTAFF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvSTAFF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvSTAFF.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaNV.Text = dgvSTAFF.Rows[r].Cells["MaNV"].Value.ToString();
            this.txtName.Text =
            dgvSTAFF.Rows[r].Cells["Name"].Value.ToString();
            this.txtGmail.Text = dgvSTAFF.Rows[r].Cells["Email"].Value.ToString();
            this.txtSalary.Text = dgvSTAFF.Rows[r].Cells["Salary"].Value.ToString();
            this.txtEnter.Text = Convert.ToDateTime(dgvSTAFF.Rows[r].Cells["Enter"].Value).ToString("yyyy-MM-dd");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaNV.ResetText();
            this.txtName.ResetText();
            this.txtGmail.ResetText();
            this.txtSalary.ResetText();
            this.txtEnter.ResetText();
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
            this.txtMaNV.Enabled = true;
            this.txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvSTAFF_CellClick(null, null);
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
            this.txtMaNV.Enabled = false;
            this.txtName.Focus();
           

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
           
            this.txtName.ResetText();
            this.txtGmail.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvSTAFF_CellClick(null, null);
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã Cập nhật mọi dữ liệu.");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            if (Them)
            {
                try
                {
                    //Lệnh Insert Into
                    bool f = dbst.ThemNhanVien(ref err,
                    int.Parse(this.txtMaNV.Text),
                    this.txtName.Text.ToString(),
                    decimal.Parse(this.txtSalary.Text),
                    DateTime.Parse(this.txtEnter.Text),
                    this.txtGmail.Text.ToString()
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
                catch (Exception ex) {
                    MessageBox.Show($"Không Thêm được, lỗi rồi! \nThông báo: {ex.Message}\nChi tiết: {ex.StackTrace}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    //Lệnh Insert Into
                    bool f = dbst.CapNhatNhanVien(
                    ref err,
                    int.Parse(this.txtMaNV.Text),  
                    this.txtName.Text.ToString(),
                    decimal.Parse(this.txtSalary.Text),
                    DateTime.Parse(this.txtEnter.Text),
                    this.txtGmail.Text.ToString()
                    );




                    if (f) {
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

      

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSTAFF.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(dgvSTAFF.CurrentRow.Cells["MaNV"].Value.ToString(), out id))
            {
                MessageBox.Show("Mã Nhân Viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên có mã là {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string err = "";
                bool success = dbst.XoaNhanVien(ref err, id);

                if (success)
                {
                    dgvSTAFF.Rows.Remove(dgvSTAFF.CurrentRow); // Xóa luôn trên giao diện
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi xóa: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGmail_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
