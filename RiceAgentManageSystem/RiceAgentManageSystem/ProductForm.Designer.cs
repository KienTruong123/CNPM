namespace RiceAgentManageSystem
{
    partial class ProductForm
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
            this.gridP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridP)).BeginInit();
            this.SuspendLayout();
            // 
            // gridP
            // 
            this.gridP.AllowUserToAddRows = false;
            this.gridP.AllowUserToDeleteRows = false;
            this.gridP.AllowUserToOrderColumns = true;
            this.gridP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridP.Location = new System.Drawing.Point(32, 22);
            this.gridP.Name = "gridP";
            this.gridP.ReadOnly = true;
            this.gridP.RowHeadersWidth = 62;
            this.gridP.RowTemplate.Height = 28;
            this.gridP.Size = new System.Drawing.Size(967, 843);
            this.gridP.TabIndex = 0;
            this.gridP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 905);
            this.Controls.Add(this.gridP);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridP;
    }
}