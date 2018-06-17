namespace Autoservice.Forms
{
    partial class ServiceForm
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
            this.ctrlSFDGV_offers = new System.Windows.Forms.DataGridView();
            this.ctrlSFLblOffers = new System.Windows.Forms.Label();
            this.ctrlSFDGVIn = new System.Windows.Forms.DataGridView();
            this.ctrlSFLblIn = new System.Windows.Forms.Label();
            this.ctrlSFDGVWork = new System.Windows.Forms.DataGridView();
            this.ctrlSFLblWork = new System.Windows.Forms.Label();
            this.ctrlSFDGVOut = new System.Windows.Forms.DataGridView();
            this.ctrlSFLblOut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGV_offers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGVIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGVWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGVOut)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlSFDGV_offers
            // 
            this.ctrlSFDGV_offers.AllowUserToAddRows = false;
            this.ctrlSFDGV_offers.AllowUserToDeleteRows = false;
            this.ctrlSFDGV_offers.AllowUserToResizeRows = false;
            this.ctrlSFDGV_offers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlSFDGV_offers.ColumnHeadersVisible = false;
            this.ctrlSFDGV_offers.Location = new System.Drawing.Point(12, 25);
            this.ctrlSFDGV_offers.MultiSelect = false;
            this.ctrlSFDGV_offers.Name = "ctrlSFDGV_offers";
            this.ctrlSFDGV_offers.ReadOnly = true;
            this.ctrlSFDGV_offers.RowHeadersVisible = false;
            this.ctrlSFDGV_offers.Size = new System.Drawing.Size(583, 150);
            this.ctrlSFDGV_offers.TabIndex = 0;
            // 
            // ctrlSFLblOffers
            // 
            this.ctrlSFLblOffers.AutoSize = true;
            this.ctrlSFLblOffers.Location = new System.Drawing.Point(9, 9);
            this.ctrlSFLblOffers.Name = "ctrlSFLblOffers";
            this.ctrlSFLblOffers.Size = new System.Drawing.Size(46, 13);
            this.ctrlSFLblOffers.TabIndex = 1;
            this.ctrlSFLblOffers.Text = "Услуги:";
            // 
            // ctrlSFDGVIn
            // 
            this.ctrlSFDGVIn.AllowUserToAddRows = false;
            this.ctrlSFDGVIn.AllowUserToDeleteRows = false;
            this.ctrlSFDGVIn.AllowUserToResizeRows = false;
            this.ctrlSFDGVIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlSFDGVIn.ColumnHeadersVisible = false;
            this.ctrlSFDGVIn.Location = new System.Drawing.Point(12, 251);
            this.ctrlSFDGVIn.MultiSelect = false;
            this.ctrlSFDGVIn.Name = "ctrlSFDGVIn";
            this.ctrlSFDGVIn.ReadOnly = true;
            this.ctrlSFDGVIn.RowHeadersVisible = false;
            this.ctrlSFDGVIn.Size = new System.Drawing.Size(180, 150);
            this.ctrlSFDGVIn.TabIndex = 0;
            this.ctrlSFDGVIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctrlSFDGV_CellClick);
            // 
            // ctrlSFLblIn
            // 
            this.ctrlSFLblIn.AutoSize = true;
            this.ctrlSFLblIn.Location = new System.Drawing.Point(9, 235);
            this.ctrlSFLblIn.Name = "ctrlSFLblIn";
            this.ctrlSFLblIn.Size = new System.Drawing.Size(61, 13);
            this.ctrlSFLblIn.TabIndex = 1;
            this.ctrlSFLblIn.Text = "В очереди:";
            // 
            // ctrlSFDGVWork
            // 
            this.ctrlSFDGVWork.AllowUserToAddRows = false;
            this.ctrlSFDGVWork.AllowUserToDeleteRows = false;
            this.ctrlSFDGVWork.AllowUserToResizeRows = false;
            this.ctrlSFDGVWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlSFDGVWork.ColumnHeadersVisible = false;
            this.ctrlSFDGVWork.Location = new System.Drawing.Point(215, 251);
            this.ctrlSFDGVWork.MultiSelect = false;
            this.ctrlSFDGVWork.Name = "ctrlSFDGVWork";
            this.ctrlSFDGVWork.ReadOnly = true;
            this.ctrlSFDGVWork.RowHeadersVisible = false;
            this.ctrlSFDGVWork.Size = new System.Drawing.Size(180, 150);
            this.ctrlSFDGVWork.TabIndex = 0;
            this.ctrlSFDGVWork.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctrlSFDGV_CellClick);
            // 
            // ctrlSFLblWork
            // 
            this.ctrlSFLblWork.AutoSize = true;
            this.ctrlSFLblWork.Location = new System.Drawing.Point(212, 235);
            this.ctrlSFLblWork.Name = "ctrlSFLblWork";
            this.ctrlSFLblWork.Size = new System.Drawing.Size(98, 13);
            this.ctrlSFLblWork.TabIndex = 1;
            this.ctrlSFLblWork.Text = "Обрабатываются:";
            // 
            // ctrlSFDGVOut
            // 
            this.ctrlSFDGVOut.AllowUserToAddRows = false;
            this.ctrlSFDGVOut.AllowUserToDeleteRows = false;
            this.ctrlSFDGVOut.AllowUserToResizeRows = false;
            this.ctrlSFDGVOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlSFDGVOut.ColumnHeadersVisible = false;
            this.ctrlSFDGVOut.Location = new System.Drawing.Point(415, 251);
            this.ctrlSFDGVOut.MultiSelect = false;
            this.ctrlSFDGVOut.Name = "ctrlSFDGVOut";
            this.ctrlSFDGVOut.ReadOnly = true;
            this.ctrlSFDGVOut.RowHeadersVisible = false;
            this.ctrlSFDGVOut.Size = new System.Drawing.Size(180, 150);
            this.ctrlSFDGVOut.TabIndex = 0;
            this.ctrlSFDGVOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctrlSFDGV_CellClick);
            // 
            // ctrlSFLblOut
            // 
            this.ctrlSFLblOut.AutoSize = true;
            this.ctrlSFLblOut.Location = new System.Drawing.Point(412, 235);
            this.ctrlSFLblOut.Name = "ctrlSFLblOut";
            this.ctrlSFLblOut.Size = new System.Drawing.Size(61, 13);
            this.ctrlSFLblOut.TabIndex = 1;
            this.ctrlSFLblOut.Text = "Починены:";
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 413);
            this.Controls.Add(this.ctrlSFLblOut);
            this.Controls.Add(this.ctrlSFLblWork);
            this.Controls.Add(this.ctrlSFLblIn);
            this.Controls.Add(this.ctrlSFLblOffers);
            this.Controls.Add(this.ctrlSFDGVOut);
            this.Controls.Add(this.ctrlSFDGVWork);
            this.Controls.Add(this.ctrlSFDGVIn);
            this.Controls.Add(this.ctrlSFDGV_offers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceForm";
            this.Text = "Сервис";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGV_offers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGVIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGVWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGVOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ctrlSFDGV_offers;
        private System.Windows.Forms.Label ctrlSFLblOffers;
        private System.Windows.Forms.DataGridView ctrlSFDGVIn;
        private System.Windows.Forms.Label ctrlSFLblIn;
        private System.Windows.Forms.DataGridView ctrlSFDGVWork;
        private System.Windows.Forms.Label ctrlSFLblWork;
        private System.Windows.Forms.DataGridView ctrlSFDGVOut;
        private System.Windows.Forms.Label ctrlSFLblOut;
    }
}