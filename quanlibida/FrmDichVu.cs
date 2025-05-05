using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer;
using BLLDichVu;
using DAL;
using System.Collections.Generic;
namespace quanlibida
{
    public partial class FrmDichVu : Form
    {

        DichVuBLL dbst=new DichVuBLL();
        // Đối tượng đưa dữ liệu vào DataTable dtDichVu 
        public static DataTable dtDichVu { get; set; }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public FrmDichVu()
        {
            InitializeComponent();
        
        }
        private void LoadData()
        {
            try
            {
                List<DichVu> listDichVu = dbst.LayDichVu();
                dgvDichVu.DataSource = listDichVu;

                ResetInputFields();

                btnLuu.Enabled = false;
                btnHuyBo.Enabled = false;
                panel.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTroVe.Enabled = true;

                if (listDichVu.Count > 0)
                    dgvDichVu_CellClick(null, null);
            }
            catch (SqlException ex)
            {
                ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                ShowGeneralError(ex);
            }
        }

        private void ResetInputFields()
        {
            txtName.ResetText();
            txtType.ResetText();
            txtPrice.ResetText();
        }

        private void ShowSqlError(SqlException ex)
        {
            MessageBox.Show($"Lỗi SQL!\nMã lỗi: {ex.Number}\nThông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowGeneralError(Exception ex)
        {
            MessageBox.Show($"Lỗi!\nThông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvDichVu.CurrentRow != null)
            {
                txtName.Text = dgvDichVu.CurrentRow.Cells["TenDV"].Value?.ToString();
                txtType.Text = dgvDichVu.CurrentRow.Cells["LoaiDV"].Value?.ToString();
                txtPrice.Text = dgvDichVu.CurrentRow.Cells["GiaTien"].Value?.ToString();
            }
        }


        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                string tenDV = this.txtName.Text.Trim();
                string loaiDV = this.txtType.Text.Trim();
                decimal giaTien = decimal.Parse(this.txtPrice.Text);

                bool f = false;

                if (Them) // Thêm mới dịch vụ
                {
                    f = dbst.ThemDichVu(tenDV, loaiDV, giaTien);
                    if (f)
                    {
                        LoadData(); // Load lại dữ liệu trên DataGridView
                        MessageBox.Show("Đã thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Cập nhật dịch vụ
                {
                    f = dbst.CapNhatDichVu(tenDV, loaiDV, giaTien);
                    if (f)
                    {
                        LoadData(); // Load lại dữ liệu trên DataGridView
                        MessageBox.Show("Đã cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Lỗi định dạng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra: {ex.Message}\nChi tiết: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bool success = dbst.XoaDichVu(tenDV, loaiDV);

                if (success)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // ✅ Gọi lại hàm load dữ liệu
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
