using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace quanlibida
{
    public partial class FrmDichVu : Form
    {

        BAL dbst;
        // Đối tượng đưa dữ liệu vào DataTable dtDichVu 
        public static DataTable dtDichVu { get; set; }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public FrmDichVu()
        {
            InitializeComponent();
            dbst = new BAL();
        }
        void LoadData()
        {
            try
            {
             
                // Vận chuyển dữ liệu vào DataTable dtDichVu 
                dtDichVu = new DataTable();
                dtDichVu.Clear();
                dtDichVu = dbst.LayDichVu().Tables[0];
                // Đưa dữ liệu lên DataGridView  
                dgvDichVu.DataSource = dtDichVu;

                // Xóa trống các đối tượng trong Panel 

                this.txtName.ResetText();
                this.txtType.ResetText();
                this.txtPrice.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                dgvDichVu_CellClick(null, null);
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
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtName.ResetText();
            
            this.txtType.ResetText();
            this.txtPrice.ResetText();
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
            this.txtName.Enabled = true;
            this.txtName.Focus();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvDichVu.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtName.Text = dgvDichVu.Rows[r].Cells["TenDV"].Value.ToString();
            this.txtType.Text = dgvDichVu.Rows[r].Cells["LoaiDV"].Value.ToString();
            this.txtPrice.Text = dgvDichVu.Rows[r].Cells["GiaTien"].Value.ToString();
            
        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            if (Them) // Trường hợp thêm mới
            {
                try
                {
                    // Lệnh Insert Into
                    bool f = dbst.ThemDichVu(ref err,
                        this.txtName.Text.ToString(),
                        this.txtType.Text.ToString(),
                        decimal.Parse(this.txtPrice.Text)
                    );

                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm dịch vụ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thêm được, lỗi rồi!\nThông báo: {ex.Message}\nChi tiết: {ex.StackTrace}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Trường hợp cập nhật
            {
                try
                {
                    // Lệnh Update
                    bool f = dbst.CapNhatDichVu(
                        ref err,
                        this.txtName.Text.ToString(),
                        this.txtType.Text.ToString(),
                        decimal.Parse(this.txtPrice.Text)
                    );

                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã cập nhật dịch vụ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dịch vụ thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được, lỗi rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvDichVu_CellClick(null, null);
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
            
            this.txtName.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDV = dgvDichVu.CurrentRow.Cells["TenDV"].Value.ToString();
            string loaiDV = dgvDichVu.CurrentRow.Cells["LoaiDV"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa dịch vụ '{tenDV}' loại '{loaiDV}'?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string err = "";
               
                bool success = dbst.XoaDichVu(ref err, tenDV, loaiDV);

                if (success )
                {
                    dgvDichVu.Rows.Remove(dgvDichVu.CurrentRow); // Xóa luôn trên giao diện
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi xóa: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã Cập nhật mọi dữ liệu.");
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 

            this.txtName.ResetText();
            this.txtType.ResetText();
            this.txtPrice.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvDichVu_CellClick(null, null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Dichvuquery frm = new Dichvuquery();
            frm.ShowDialog();
        }
    }
}
