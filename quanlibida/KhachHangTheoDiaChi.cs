﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessAccessLayer;
using BLLCustomer;
namespace quanlibida
{
    public partial class KhachHangTheoDiaChi : Form
    {
        private string keyword;
        private CustomerBLL bllKhachHang = new CustomerBLL();
        public KhachHangTheoDiaChi(string keyword)
        {
            InitializeComponent();
            this.keyword = keyword;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var ds = bllKhachHang.KhachHangTheoDiaChi(keyword);
                dgvAddress.DataSource = ds; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KhachHangTheoDiaChi_Load(object sender, EventArgs e)
        {

        }
    }
}
