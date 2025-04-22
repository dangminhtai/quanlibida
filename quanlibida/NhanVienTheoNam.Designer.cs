namespace quanlibida
{
    partial class NhanVienTheoNam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVienTheoNam));
            this.dgvNam = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNam)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNam
            // 
            this.dgvNam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNam.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.dgvNam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNam.Location = new System.Drawing.Point(31, 81);
            this.dgvNam.Name = "dgvNam";
            this.dgvNam.RowHeadersWidth = 51;
            this.dgvNam.RowTemplate.Height = 24;
            this.dgvNam.Size = new System.Drawing.Size(761, 199);
            this.dgvNam.TabIndex = 0;
            this.dgvNam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNam_CellClick);
            this.dgvNam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNam_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách nhân viên theo năm thỏa mãn:";
            // 
            // NhanVienTheoNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(804, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NhanVienTheoNam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.NhanVienTheoNam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNam;
        private System.Windows.Forms.Label label1;
    }
}