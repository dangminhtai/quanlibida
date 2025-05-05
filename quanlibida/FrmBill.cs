using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer;
using QRCoder;
using BLLBill;

namespace quanlibida
{
    public partial class FrmBill : Form
    {
        BillBLL dbbill = new BillBLL();
        private string hoaDonText = "";
        private PrintDocument printDocument = new PrintDocument();
        private string tenKH, diaChi;
        private int maKH, tongPhutChoi;
        private decimal tienBan, tienDV, tongTien;

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FrmBill()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtID1.Text, out maKH))
                {
                    MessageBox.Show("❌ Vui lòng nhập mã khách hàng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var billInfo = dbbill.GetBillInfo(maKH);
                if (billInfo != null && billInfo.TongTienPhaiTra > 0)
                {
                    // Gán cho biến toàn cục để in
                    this.tenKH = billInfo.hoTen;
                    this.diaChi = billInfo.diaChi;
                    this.tongPhutChoi = billInfo.TongPhutChoi;
                    this.tienBan = billInfo.TienBan;
                    this.tienDV = billInfo.TongTienDV;
                    this.tongTien = billInfo.TongTienPhaiTra;

                    PrintPreviewDialog previewDialog = new PrintPreviewDialog
                    {
                        Document = printDocument,
                        Width = 600,
                        Height = 800
                    };
                    previewDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("❌ Không tìm thấy thông tin khách hàng hoặc khách hàng chưa phát sinh chi phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font font = new Font("Arial", 12);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            int startX = 50;
            int startY = 50;
            int offsetY = 30;

            g.DrawString("HÓA ĐƠN THANH TOÁN CHƠI BIDA TẠI QUÁN", titleFont, Brushes.Black, startX + 100, startY);
            startY += offsetY;
            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), font, Brushes.Black, startX, startY);
            startY += offsetY;

            g.DrawString("Mã KH: " + maKH, boldFont, Brushes.Black, startX, startY);
            startY += offsetY;
            g.DrawString("Tên KH: " + tenKH, boldFont, Brushes.Black, startX, startY);
            startY += offsetY;
            g.DrawString("Địa chỉ: " + diaChi, font, Brushes.Black, startX, startY);
            startY += offsetY;
            g.DrawString("Tổng phút chơi: " + tongPhutChoi + " phút", font, Brushes.Black, startX, startY);
            startY += offsetY;

            int tableStartY = startY + 20;
            int rowHeight = 30;
            string[] headers = { "Dịch vụ", "Số lượng", "Đơn giá", "Thành tiền" };
            string[,] rows =
            {
        { "Bàn chơi", "1", tienBan.ToString("N2") + " VND", tienBan.ToString("N2") + " VND" },
        { "Dịch vụ khác", "1", tienDV.ToString("N2") + " VND", tienDV.ToString("N2") + " VND" }
    };

            int[] colWidths = { 150, 100, 150, 150 };
            int tableWidth = colWidths.Sum();
            int columnX = startX;

            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawRectangle(Pens.Black, columnX, tableStartY, colWidths[i], rowHeight);
                g.DrawString(headers[i], font, Brushes.Black, columnX + 5, tableStartY + 5);
                columnX += colWidths[i];
            }

            tableStartY += rowHeight;
            for (int j = 0; j < rows.GetLength(0); j++)
            {
                columnX = startX;
                for (int i = 0; i < headers.Length; i++)
                {
                    g.DrawRectangle(Pens.Black, columnX, tableStartY, colWidths[i], rowHeight);
                    g.DrawString(rows[j, i], font, Brushes.Black, columnX + 5, tableStartY + 5);
                    columnX += colWidths[i];
                }
                tableStartY += rowHeight;
            }

            startY = tableStartY + 40;
            g.DrawString("Tổng tiền phải trả: " + tongTien.ToString("N2") + " VND", boldFont, Brushes.Black, startX, startY);

            string qrData = "00020101021138540010A00000072701240006970436011010408867370208QRIBFTTA53037045802VN6304EF52";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q))
                {
                    QRCode qrCode = new QRCode(qrCodeData);
                    using (Bitmap qrBitmap = qrCode.GetGraphic(10))
                    {
                        int qrX = startX + 150;
                        int qrY = startY + 20;
                        g.DrawImage(qrBitmap, qrX, qrY, 150, 150);
                    }
                }
            }
            startY += 170;
            g.DrawString("Quét mã QR để thanh toán", font, Brushes.Black, startX + 110, startY);
        }
    }
}
