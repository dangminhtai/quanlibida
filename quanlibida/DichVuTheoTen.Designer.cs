namespace quanlibida
{
    partial class DichVuTheoTen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DichVuTheoTen));
            this.dgvname = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvname)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvname
            // 
            this.dgvname.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvname.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.dgvname.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvname.Location = new System.Drawing.Point(-1, 12);
            this.dgvname.Name = "dgvname";
            this.dgvname.RowHeadersWidth = 51;
            this.dgvname.RowTemplate.Height = 24;
            this.dgvname.Size = new System.Drawing.Size(505, 261);
            this.dgvname.TabIndex = 8;
            this.dgvname.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvname_CellContentClick);
            // 
            // DichVuTheoTen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(507, 275);
            this.Controls.Add(this.dgvname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DichVuTheoTen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dịch vụ theo tên";
            this.Load += new System.EventHandler(this.DichVuTheoTen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvname)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvname;
    }
}