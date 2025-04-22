using System;
using System.Data;
using System.Windows.Forms;

namespace BusinessAccessLayer
{
    public partial class TimePlay : Form
    {
        public TimePlay()
        {
            InitializeComponent();
        }
        public void UpdateDataGrid(DataTable dt)
        {
            dgvTime.DataSource = dt;
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
