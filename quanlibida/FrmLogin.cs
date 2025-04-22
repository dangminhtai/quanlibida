using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlibida
{
    public partial class FrmLogin : Form
    {
        public bool IsAuthenticated { get; private set; } = false; // Biến kiểm tra đăng nhập
        public string Username { get; private set; } = "";

        public FrmLogin()
        {
            InitializeComponent();
           
        }

    

        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "nhantaiduy", "221315" },
            { "trongnhan", "22072005" },
            { "minhtai", "taidz" },
            { "admin", "12345" },
            {"duy1509","duydz" }
          
        };

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();   
            string password = txtPassword.Text.Trim();

            if (users.ContainsKey(username) && users[username] == password)
            {
                IsAuthenticated = true; // Đánh dấu đăng nhập thành công
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
            
        }
        private void hideshowpass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            // Thay đổi icon của PictureBox (nếu bạn có icon cho ẩn/hiện)
            if (txtPassword.UseSystemPasswordChar)
            {
               hideshowpass.Image = Properties.Resources.hidepass; // Thay bằng ảnh "ẩn"
            }
            else
            {
                hideshowpass.Image = Properties.Resources.showpass; // Thay bằng ảnh "hiện"
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím Enter được nhấn
            {
                btnLogin.PerformClick(); // Kích hoạt sự kiện Click của nút Login
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím Enter được nhấn
            {
                btnLogin.PerformClick(); // Kích hoạt sự kiện Click của nút Login
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
    }

}
