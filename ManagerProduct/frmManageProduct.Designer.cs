namespace ManagerProduct
{
    partial class frmManageProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageStaff = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.btnManaBill = new System.Windows.Forms.Button();
            this.btnManageBillDetail = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(133, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOME APPLIANCE STORE SALES MANAGEMENT\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnManageStaff
            // 
            this.btnManageStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnManageStaff.Location = new System.Drawing.Point(39, 131);
            this.btnManageStaff.Name = "btnManageStaff";
            this.btnManageStaff.Size = new System.Drawing.Size(223, 41);
            this.btnManageStaff.TabIndex = 1;
            this.btnManageStaff.Text = "Manage Staff";
            this.btnManageStaff.UseVisualStyleBackColor = true;
            this.btnManageStaff.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnManageCustomer.Location = new System.Drawing.Point(39, 197);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(223, 41);
            this.btnManageCustomer.TabIndex = 2;
            this.btnManageCustomer.Text = "Manage Customer";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // btnManaBill
            // 
            this.btnManaBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnManaBill.Location = new System.Drawing.Point(39, 266);
            this.btnManaBill.Name = "btnManaBill";
            this.btnManaBill.Size = new System.Drawing.Size(223, 41);
            this.btnManaBill.TabIndex = 3;
            this.btnManaBill.Text = "Manage Bill";
            this.btnManaBill.UseVisualStyleBackColor = true;
            this.btnManaBill.Click += new System.EventHandler(this.btnManaBill_Click);
            // 
            // btnManageBillDetail
            // 
            this.btnManageBillDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnManageBillDetail.Location = new System.Drawing.Point(39, 351);
            this.btnManageBillDetail.Name = "btnManageBillDetail";
            this.btnManageBillDetail.Size = new System.Drawing.Size(223, 41);
            this.btnManageBillDetail.TabIndex = 4;
            this.btnManageBillDetail.Text = "Manage Bill Detail";
            this.btnManageBillDetail.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClose.Location = new System.Drawing.Point(472, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 41);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ManagerProduct.Properties.Resources.th;
            this.pictureBox1.Location = new System.Drawing.Point(317, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 176);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnManageBillDetail);
            this.Controls.Add(this.btnManaBill);
            this.Controls.Add(this.btnManageCustomer);
            this.Controls.Add(this.btnManageStaff);
            this.Controls.Add(this.label1);
            this.Name = "frmManageProduct";
            this.Text = "frmManageProduct";
            this.Load += new System.EventHandler(this.frmManageProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnManageCustomer;
        private System.Windows.Forms.Button btnManaBill;
        private System.Windows.Forms.Button btnManageBillDetail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
    }
}