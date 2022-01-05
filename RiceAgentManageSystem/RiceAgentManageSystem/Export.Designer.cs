namespace RiceAgentManageSystem
{
    partial class Export
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
            this.btnExportBill = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            this.gridBill = new System.Windows.Forms.DataGridView();
            this.btnClosed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBill)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportBill
            // 
            this.btnExportBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportBill.Location = new System.Drawing.Point(1265, 76);
            this.btnExportBill.Name = "btnExportBill";
            this.btnExportBill.Size = new System.Drawing.Size(336, 56);
            this.btnExportBill.TabIndex = 20;
            this.btnExportBill.Text = "Export Bill";
            this.btnExportBill.UseVisualStyleBackColor = true;
            this.btnExportBill.Click += new System.EventHandler(this.btnExportBill_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1340, 975);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(261, 51);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Location = new System.Drawing.Point(42, 553);
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersWidth = 62;
            this.gridDetail.RowTemplate.Height = 28;
            this.gridDetail.Size = new System.Drawing.Size(1165, 399);
            this.gridDetail.TabIndex = 18;
            this.gridDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetail_CellContentClick);
            // 
            // gridBill
            // 
            this.gridBill.AllowUserToAddRows = false;
            this.gridBill.AllowUserToDeleteRows = false;
            this.gridBill.AllowUserToOrderColumns = true;
            this.gridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBill.Location = new System.Drawing.Point(42, 76);
            this.gridBill.Name = "gridBill";
            this.gridBill.ReadOnly = true;
            this.gridBill.RowHeadersWidth = 62;
            this.gridBill.RowTemplate.Height = 28;
            this.gridBill.Size = new System.Drawing.Size(1165, 433);
            this.gridBill.TabIndex = 17;
            this.gridBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBill_CellClick);
            this.gridBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBill_CellContentClick);
            // 
            // btnClosed
            // 
            this.btnClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosed.Location = new System.Drawing.Point(1265, 163);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(336, 56);
            this.btnClosed.TabIndex = 21;
            this.btnClosed.Text = "Mark Bill is Completed";
            this.btnClosed.UseVisualStyleBackColor = true;
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 1050);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnExportBill);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.gridBill);
            this.Name = "Export";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportBill;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView gridDetail;
        private System.Windows.Forms.DataGridView gridBill;
        private System.Windows.Forms.Button btnClosed;
    }
}