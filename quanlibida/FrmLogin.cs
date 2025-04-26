using System;
using System.Windows.Forms;
using System.Drawing;
using BLL;

namespace quanlibida
{
    public partial class FrmLogin : Form
    {
        public bool IsAuthenticated { get; private set; } = false;
        public string Username { get; private set; } = "";

        public FrmLogin()
        {
            InitializeComponent();

            // Gắn thêm sự kiện TextChanged bằng tay nếu bạn không kéo thả trên Designer
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            TaiKhoanBLL bll = new TaiKhoanBLL();

            if (!bll.TonTaiTenDangNhap(user))
            {
                MessageBox.Show("Tên đăng nhập không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!bll.DangNhap(user, pass))
            {
                MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IsAuthenticated = true;
                Username = user;
                this.Close();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void hideshowpass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            hideshowpass.Image = txtPassword.UseSystemPasswordChar
                ? Properties.Resources.hidepass
                : Properties.Resources.showpass;
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0)
                txtUsername.Font = new Font(txtUsername.Font, FontStyle.Regular);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0)
                txtPassword.Font = new Font(txtPassword.Font, FontStyle.Regular);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Bạn tự viết xử lý riêng ở đây nếu cần
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {


        }
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
