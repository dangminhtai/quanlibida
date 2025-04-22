using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
namespace quanlibida
{
    public partial class FrmAbout : Form
    {
        private class Ball
        {
            public double X, Y;
            public double SpeedX, SpeedY;
            public Color Color;
            public int Number;
            public const int Radius = 15;
            private class DoubleBufferedPanel : Panel
            {
                public DoubleBufferedPanel()
                {
                    this.DoubleBuffered = true;
                }
            }
            public Ball(double x, double y, Color color, int number)
            {
                X = x;
                Y = y;
                Color = color;
                Number = number;
                SpeedX = 0;
                SpeedY = 0;
            }

            public void Move(int width, int height)
            {
                X += SpeedX;
                Y += SpeedY;

                // Va chạm với mép bàn
                if (X <= 0 || X >= width - Radius * 2) SpeedX = -SpeedX;
                if (Y <= 0 || Y >= height - Radius * 2) SpeedY = -SpeedY;

                // Giảm tốc độ (mô phỏng ma sát)
                SpeedX *= 0.98;
                SpeedY *= 0.98;
                if (Math.Abs(SpeedX) < 0.1) SpeedX = 0;
                if (Math.Abs(SpeedY) < 0.1) SpeedY = 0;
            }
        }
        private List<Ball> balls = new List<Ball>();
        private Timer moveTimer, stopTimer;
        private Random rand = new Random();
        private class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
            }
        }
        public FrmAbout()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Lưu ảnh gốc để khôi phục lại sau khi rời chuột
        private Image originalImageFacebook;
        private Image originalImageZalo;
        private Image originalImageGithub;
        
       
    
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



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        //Hàm cho bida hoạt động
        private void MoveBalls(object sender, EventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.Move(panelTable.Width, panelTable.Height);
            }

            // Kiểm tra va chạm giữa các viên bi
            for (int i = 0; i < balls.Count; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    if (IsColliding(balls[i], balls[j]))
                    {
                        HandleCollision(balls[i], balls[j]);
                    }
                }
            }

            panelTable.Invalidate(); // Vẽ lại bàn bi-a
        }

        private void StopBalls(object sender, EventArgs e)
        {
            moveTimer.Stop();
            stopTimer.Stop();
            foreach (var ball in balls)
            {
                ball.SpeedX = 0;
                ball.SpeedY = 0;
            }
        }

        private bool IsColliding(Ball b1, Ball b2)
        {
            double dx = b1.X - b2.X;
            double dy = b1.Y - b2.Y;
            return dx * dx + dy * dy <= Ball.Radius * Ball.Radius * 4;
        }

        private void HandleCollision(Ball b1, Ball b2)
        {
            double dx = b2.X - b1.X;
            double dy = b2.Y - b1.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            if (distance == 0) return;

            // Vector đơn vị hướng ra ngoài
            double nx = dx / distance;
            double ny = dy / distance;

            // Thành phần vận tốc dọc theo vector va chạm
            double p = 2 * (b1.SpeedX * nx + b1.SpeedY * ny - b2.SpeedX * nx - b2.SpeedY * ny) / 2;

            // Cập nhật vận tốc mới
            b1.SpeedX -= p * nx;
            b1.SpeedY -= p * ny;
            b2.SpeedX += p * nx;
            b2.SpeedY += p * ny;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panelTable_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var ball in balls)
            {
                Brush brush = new SolidBrush(ball.Color);
                g.FillEllipse(brush, (float)ball.X, (float)ball.Y, Ball.Radius * 2, Ball.Radius * 2);

                if (ball.Number > 0)
                {
                    g.DrawString(ball.Number.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (float)ball.X + 8, (float)ball.Y + 8);
                }
            }
        }
        //--------------------------------
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            panelTable.GetType().GetProperty("DoubleBuffered",
              System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
              ?.SetValue(panelTable, true, null);

            // Tạo viên bi trắng (không kiểm tra va chạm)
            balls.Add(new Ball(panelTable.Width / 2, panelTable.Height - 50, Color.White, 0));

            Color[] rainbowColors = new Color[]
            {
        Color.Red,        // Đỏ
        Color.Orange,     // Cam
        Color.Yellow,     // Vàng
        Color.Green,      // Xanh lá
        Color.Blue,       // Xanh dương
        Color.Indigo,     // Chàm
        Color.Violet,     // Tím
        Color.Cyan,       // Xanh lơ
        Color.Magenta     // Hồng
            };

            // Tạo 9 viên bi màu mà không để chúng chồng lên nhau
            for (int i = 0; i < 9; i++)
            {
                int x, y;
                bool isOverlapping;

                do
                {
                    isOverlapping = false;
                    x = rand.Next(50, panelTable.Width - 50);
                    y = rand.Next(50, panelTable.Height / 2);

                    // Kiểm tra va chạm nhưng chỉ với 9 viên bi màu, bỏ qua viên bi trắng
                    foreach (var ball in balls.Skip(1)) // Bỏ viên đầu tiên (viên bi trắng)
                    {
                        double dx = ball.X - x;
                        double dy = ball.Y - y;
                        double distance = Math.Sqrt(dx * dx + dy * dy);

                        if (distance < Ball.Radius * 2) // Nếu khoảng cách nhỏ hơn đường kính, tạo lại
                        {
                            isOverlapping = true;
                            break;
                        }
                    }

                } while (isOverlapping); // Lặp lại nếu vị trí trùng

                balls.Add(new Ball(x, y, rainbowColors[i], i + 1));
            }

            // Timer di chuyển bi
            moveTimer = new Timer { Interval = 20 };
            moveTimer.Tick += MoveBalls;

            // Timer dừng bi sau 7 giây
            stopTimer = new Timer { Interval = 5000 };
            stopTimer.Tick += StopBalls;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureZalo_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://zalo.me/0333078554",
                UseShellExecute = true
            });
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/tamidanopro",
                UseShellExecute = true
            });
        }

        private void pictureFacebook_MouseHover(object sender, EventArgs e)
        {
            if (originalImageFacebook == null && pictureFacebook.Image != null)
            {
                originalImageFacebook = (Image)pictureFacebook.Image.Clone();
            }
            pictureFacebook.Image = SetImageOpacity(pictureFacebook.Image, 0.8f);
        }

        private void pictureFacebook_MouseLeave(object sender, EventArgs e)
        {
            if (originalImageFacebook != null)
            {
                pictureFacebook.Image = originalImageFacebook;
            }
        }

        private void pictureZalo_MouseHover(object sender, EventArgs e)
        {
            if (originalImageZalo == null && pictureZalo.Image != null)
            {
                originalImageZalo = (Image)pictureZalo.Image.Clone();
            }
            pictureZalo.Image = SetImageOpacity(pictureZalo.Image, 0.8f);
        }

        private void pictureZalo_MouseLeave(object sender, EventArgs e)
        {
            if (originalImageZalo != null)
            {
                pictureZalo.Image = originalImageZalo;
            }
        }

        private void pictureGithub_MouseHover(object sender, EventArgs e)
        {
            if (originalImageGithub == null && pictureGithub.Image != null)
            {
                originalImageGithub = (Image)pictureGithub.Image.Clone();
            }
            pictureGithub.Image = SetImageOpacity(pictureGithub.Image, 0.8f);
        }

        private void pictureGithub_MouseLeave(object sender, EventArgs e)
        {
            if (originalImageGithub != null)
            {
                pictureGithub.Image = originalImageGithub;
            }
        }

        private void panelTable_Click(object sender, EventArgs e)
        {
            do
            {
                balls[0].SpeedX = rand.Next(-12, 13);
                balls[0].SpeedY = rand.Next(-12, 13);
            } while (balls[0].SpeedX == 0 && balls[0].SpeedY == 0);

            moveTimer.Start();
            stopTimer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balls.Clear(); // Xóa tất cả viên bi cũ

            // Tạo viên bi trắng (vị trí ngẫu nhiên)
            int whiteX, whiteY;
            bool isOverlapping;

            do
            {
                isOverlapping = false;
                whiteX = rand.Next(50, panelTable.Width - 50);
                whiteY = rand.Next(panelTable.Height / 2, panelTable.Height - 50); // Đặt viên bi trắng ở nửa dưới bàn

                // Không cần kiểm tra vì đây là viên bi đầu tiên
            } while (isOverlapping);

            balls.Add(new Ball(whiteX, whiteY, Color.White, 0));

            Color[] rainbowColors = new Color[]
            {
        Color.Red, Color.Orange, Color.Yellow,
        Color.Green, Color.Blue, Color.Indigo,
        Color.Violet, Color.Cyan, Color.Magenta
            };

            // Tạo lại 9 viên bi màu
            for (int i = 0; i < 9; i++)
            {
                int x, y;

                do
                {
                    isOverlapping = false;
                    x = rand.Next(50, panelTable.Width - 50);
                    y = rand.Next(50, panelTable.Height / 2); // Đặt bi màu ở nửa trên bàn

                    foreach (var ball in balls)
                    {
                        double dx = ball.X - x;
                        double dy = ball.Y - y;
                        double distance = Math.Sqrt(dx * dx + dy * dy);

                        if (distance < Ball.Radius * 2) // Kiểm tra khoảng cách
                        {
                            isOverlapping = true;
                            break;
                        }
                    }
                } while (isOverlapping);

                balls.Add(new Ball(x, y, rainbowColors[i], i + 1));
            }

            panelTable.Invalidate(); // Vẽ lại bàn bi-a
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/tamidanopro",
                UseShellExecute = true
            });
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/minh.duy.182246",
                UseShellExecute = true
            });
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/tran.nhan.407057",
                UseShellExecute = true
            });
        }

        private void pictureGithub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/dangminhtai",
                UseShellExecute = true
            });
        }

       
    }
}
