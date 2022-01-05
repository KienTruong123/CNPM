namespace RiceAgentManageSystem
{
    partial class Import
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
            this.gridBill = new System.Windows.Forms.DataGridView();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBID = new System.Windows.Forms.TextBox();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.x = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.pr = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnViewProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBill
            // 
            this.gridBill.AllowUserToAddRows = false;
            this.gridBill.AllowUserToDeleteRows = false;
            this.gridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBill.Location = new System.Drawing.Point(32, 141);
            this.gridBill.Name = "gridBill";
            this.gridBill.ReadOnly = true;
            this.gridBill.RowHeadersWidth = 62;
            this.gridBill.RowTemplate.Height = 28;
            this.gridBill.Size = new System.Drawing.Size(1131, 433);
            this.gridBill.TabIndex = 0;
            this.gridBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBill_CellClick);
            this.gridBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBill_CellContentClick);
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Location = new System.Drawing.Point(32, 618);
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersWidth = 62;
            this.gridDetail.RowTemplate.Height = 28;
            this.gridDetail.Size = new System.Drawing.Size(1131, 399);
            this.gridDetail.TabIndex = 1;
            this.gridDetail.AllowUserToAddRowsChanged += new System.EventHandler(this.gridDetail_AllowUserToAddRowsChanged);
            this.gridDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetail_CellClick);
            this.gridDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetail_CellContentClick);
            this.gridDetail.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridDetail_UserAddedRow);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1318, 1064);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(261, 51);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBill.Location = new System.Drawing.Point(32, 55);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(336, 56);
            this.btnCreateBill.TabIndex = 3;
            this.btnCreateBill.Text = "Create a new Import Bill";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1220, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "BillID";
            // 
            // tbBID
            // 
            this.tbBID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBID.Location = new System.Drawing.Point(1226, 201);
            this.tbBID.Name = "tbBID";
            this.tbBID.ReadOnly = true;
            this.tbBID.Size = new System.Drawing.Size(353, 39);
            this.tbBID.TabIndex = 5;
            // 
            // tbOrderID
            // 
            this.tbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderID.Location = new System.Drawing.Point(1226, 350);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(353, 39);
            this.tbOrderID.TabIndex = 7;
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x.Location = new System.Drawing.Point(1220, 290);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(139, 32);
            this.x.TabIndex = 6;
            this.x.Text = "ProductID";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.Location = new System.Drawing.Point(1226, 618);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(353, 39);
            this.tbQuantity.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1220, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(1226, 480);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(353, 39);
            this.tbPrice.TabIndex = 11;
            // 
            // pr
            // 
            this.pr.AutoSize = true;
            this.pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pr.Location = new System.Drawing.Point(1220, 420);
            this.pr.Name = "pr";
            this.pr.Size = new System.Drawing.Size(79, 32);
            this.pr.TabIndex = 10;
            this.pr.Text = "Price";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(289, 56);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(23, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(289, 56);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(23, 206);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(289, 56);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnAdd);
            this.gb1.Controls.Add(this.btnDelete);
            this.gb1.Controls.Add(this.btnUpdate);
            this.gb1.Location = new System.Drawing.Point(1226, 722);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(353, 295);
            this.gb1.TabIndex = 15;
            this.gb1.TabStop = false;
            this.gb1.Text = "Actions";
            // 
            // btnViewProduct
            // 
            this.btnViewProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProduct.Location = new System.Drawing.Point(900, 55);
            this.btnViewProduct.Name = "btnViewProduct";
            this.btnViewProduct.Size = new System.Drawing.Size(263, 56);
            this.btnViewProduct.TabIndex = 16;
            this.btnViewProduct.Text = "View Product";
            this.btnViewProduct.UseVisualStyleBackColor = true;
            this.btnViewProduct.Click += new System.EventHandler(this.btnViewProduct_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 1151);
            this.Controls.Add(this.btnViewProduct);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.pr);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOrderID);
            this.Controls.Add(this.x);
            this.Controls.Add(this.tbBID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.gridBill);
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBill;
        private System.Windows.Forms.DataGridView gridDetail;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBID;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label pr;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnViewProduct;
    }
}