using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer;
namespace quanlibida
{
    public partial class Staffquery : Form
    {
        BAL dbst2;

        public Staffquery() // Constructor mới
        {
            InitializeComponent();
            dbst2 = new BAL();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

      
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static DataTable dtStaff { get; set; }


        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi stored procedure để lấy nhân viên làm việc lâu nhất
                DataTable dt = dbst2.TimNhanVienLauNhat();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string maNV = row["MaNV"].ToString();
                    string tenNV = row["Name"].ToString();
                    string enter = Convert.ToDateTime(row["Enter"]).ToString("dd/MM/yyyy");

                    MessageBox.Show($" Nhân viên làm việc lâu nhất\n\n"
                                  + $"🆔 Mã nhân viên: {maNV}\n"
                                  + $"👤 Tên nhân viên: {tenNV}\n"
                                  + $"📅 Ngày vào làm: {enter}",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy nhân viên lâu năm nhất!",
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

        private void btntimkiem2_Click(object sender, EventArgs e)
        {
            // Lấy giá trị năm từ textbox
            if (int.TryParse(txtNam.Text, out int nam))
            {
                // Mở form mới và truyền năm vào
                NhanVienTheoNam frm = new NhanVienTheoNam(nam);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập năm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntimkiem3_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi stored procedure để lấy nhân viên làm việc lâu nhất
                DataTable dt = dbst2.TimNhanVienMoiLam();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string maNV = row["MaNV"].ToString();
                    string tenNV = row["Name"].ToString();
                    string enter = Convert.ToDateTime(row["Enter"]).ToString("dd/MM/yyyy");

                    MessageBox.Show($" Nhân viên mới vào làm \n\n"
                                  + $"🆔 Mã nhân viên: {maNV}\n"
                                  + $"👤 Tên nhân viên: {tenNV}\n"
                                  + $"📅 Ngày vào làm: {enter}",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy nhân viên theo yêu cầu!",
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
            //luongMin=1000000
            if (int.TryParse(txtluongcao.Text, out int luongMin))
            {
                // Mở form mới và truyền năm vào
                LuongNhanVienLonHon frm = new LuongNhanVienLonHon(luongMin);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lương hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntimkiem5_Click(object sender, EventArgs e)
        {
            // Lấy giá trị năm từ textbox
            if (int.TryParse(txtluongthap.Text, out int luongMax))
            {
                // Mở form mới và truyền năm vào
                LuongNhanVienNhoHon frm = new LuongNhanVienNhoHon(luongMax);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lương hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntimkiem6_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ textbox
            string name = txtname.Text.Trim();

            if (!string.IsNullOrEmpty(name)) // Kiểm tra nếu không rỗng
            {
                // Mở form mới và truyền tên vào
                LayNhanVienTheoTen frm = new LayNhanVienTheoTen(name);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Staffquery_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     
        private void txtluongcao_TextChanged(object sender, EventArgs e)
        {

        }

 

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmStaff frm = new FrmStaff(); 
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
