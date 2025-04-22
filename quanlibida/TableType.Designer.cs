namespace quanlibida
{
    partial class TableType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableType));
            this.cboxtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnloc = new System.Windows.Forms.Button();
            this.dgvtype = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtype)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxtype
            // 
            this.cboxtype.BackColor = System.Drawing.Color.DodgerBlue;
            this.cboxtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxtype.ForeColor = System.Drawing.Color.White;
            this.cboxtype.FormattingEnabled = true;
            this.cboxtype.Items.AddRange(new object[] {
            "KKKing",
            "MrSung",
            "Dragon"});
            this.cboxtype.Location = new System.Drawing.Point(575, 90);
            this.cboxtype.Name = "cboxtype";
            this.cboxtype.Size = new System.Drawing.Size(131, 33);
            this.cboxtype.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lọc danh sách khách hàng đã đặt bàn theo loại";
            // 
            // btnloc
            // 
            this.btnloc.BackColor = System.Drawing.Color.Blue;
            this.btnloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloc.ForeColor = System.Drawing.Color.White;
            this.btnloc.Location = new System.Drawing.Point(755, 90);
            this.btnloc.Margin = new System.Windows.Forms.Padding(4);
            this.btnloc.Name = "btnloc";
            this.btnloc.Size = new System.Drawing.Size(87, 38);
            this.btnloc.TabIndex = 38;
            this.btnloc.Text = "Lọc";
            this.btnloc.UseVisualStyleBackColor = false;
            this.btnloc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // dgvtype
            // 
            this.dgvtype.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtype.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.dgvtype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtype.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvtype.Location = new System.Drawing.Point(12, 165);
            this.dgvtype.Name = "dgvtype";
            this.dgvtype.RowHeadersWidth = 51;
            this.dgvtype.RowTemplate.Height = 24;
            this.dgvtype.Size = new System.Drawing.Size(761, 199);
            this.dgvtype.TabIndex = 39;
            this.dgvtype.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvtype_CellContentClick);
            // 
            // TableType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(846, 405);
            this.Controls.Add(this.dgvtype);
            this.Controls.Add(this.btnloc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxtype);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TableType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lọc khách hàng theo bàn";
            this.Load += new System.EventHandler(this.TableType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtype)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnloc;
        private System.Windows.Forms.DataGridView dgvtype;
    }
}