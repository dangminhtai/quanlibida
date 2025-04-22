using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessAccessLayer;
namespace quanlibida
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmLogin loginForm = new FrmLogin())
            {
                loginForm.ShowDialog(); // Chạy form đăng nhập trước

                if (loginForm.IsAuthenticated) // Nếu đăng nhập thành công
                {
                    Application.Run(new MainFrm()); // Mở form chính
              
                }
            }
        }
    }
}
