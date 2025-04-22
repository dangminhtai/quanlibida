using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace quanlibida
{
    public partial class MainFrm : Form
    {
        private Image originalImage1;
        private Image originalImage2;
        private Image originalImage3;
        private Image originalImage4;
        private Image originalImage5;
        private Image originalImage6;
        private Image originalImageAbout;
        private Image originalImageLogout;
        public MainFrm()
        {
            InitializeComponent();
            originalImage1 = pictureBox1.Image;
            originalImage2 = pictureBox2.Image;
            originalImage3 = pictureBox3.Image;
            originalImage4 = pictureBox4.Image;
            originalImage5 = pictureBox5.Image;
            originalImage6 = pictureBox6.Image;
            originalImageAbout = btnAbout.Image;
            originalImageLogout = btnLogout.Image;
        }

        private Image SetImageOpacity(Image img, float opacity)
        {
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix
                {
                    Matrix33 = opacity // Điều chỉnh độ trong suốt (alpha)
                };

                ImageAttributes imgAttr = new ImageAttributes();
                imgAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height),
                            0, 0, img.Width, img.Height,
                            GraphicsUnit.Pixel, imgAttr);
            }
            return tempBitmap;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form hiện tại
            Staffquery frm = new Staffquery();
            frm.ShowDialog();
            this.Show(); // Hiển thị lại form sau khi Staffquery đóng
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Userquery frm = new Userquery();
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Revenuequery frm = new Revenuequery();
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bookingquery frm = new Bookingquery();
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dichvuquery frm = new Dichvuquery();
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBill frm= new FrmBill();
            frm.ShowDialog();
            this.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAbout frm = new FrmAbout();
            frm.ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất tài khoản à, nghĩ kĩ chưa?",
                                                     "Xác nhận",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form hiện tại nhưng không đóng
                FrmLogin frm = new FrmLogin();

                if (frm.ShowDialog() == DialogResult.OK) // Nếu đăng nhập thành công
                {
                    this.Show(); // Hiển thị lại form chính
                }
                else
                {
                    this.Close(); // Nếu không đăng nhập, vẫn giữ form chính mở
                }
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = SetImageOpacity(originalImage1, 0.8f);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = originalImage1;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = SetImageOpacity(originalImage2, 0.8f);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = originalImage2;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = SetImageOpacity(originalImage3, 0.8f);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = originalImage3;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Image = SetImageOpacity(originalImage5, 0.8f);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = originalImage5;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Image = SetImageOpacity(originalImage6, 0.8f);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = originalImage6;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = SetImageOpacity(originalImage4, 0.8f);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = originalImage4;
        }

        private void btnAbout_MouseHover(object sender, EventArgs e)
        {
            btnAbout.Image = SetImageOpacity(originalImageAbout, 0.8f);
        }

        private void btnAbout_MouseLeave(object sender, EventArgs e)
        {
            btnAbout.Image = originalImageAbout;
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            btnLogout.Image = SetImageOpacity(originalImageLogout, 0.8f);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.Image = originalImageLogout;
        }
    }
}
