using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DAL;

namespace BusinessAccessLayer
{
    public partial class TimePlay : Form
    {
        public TimePlay()
        {
            InitializeComponent();
        }
        public void UpdateDataGrid(List<Booking> bookings)
        {
            dgvTime.DataSource = bookings;
        }

        private void TimePlay_Load(object sender, EventArgs e)
        {

        }

        private void btntimkiem4_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvTime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
