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
            this.ctrlBtnClients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGV_offers)).BeginInit();
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
            this.ctrlSFDGV_offers.Size = new System.Drawing.Size(345, 150);
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
            // ctrlBtnClients
            // 
            this.ctrlBtnClients.Location = new System.Drawing.Point(12, 193);
            this.ctrlBtnClients.Name = "ctrlBtnClients";
            this.ctrlBtnClients.Size = new System.Drawing.Size(167, 23);
            this.ctrlBtnClients.TabIndex = 2;
            this.ctrlBtnClients.Text = "Показать всех клиентов";
            this.ctrlBtnClients.UseVisualStyleBackColor = true;
            this.ctrlBtnClients.Click += new System.EventHandler(this.ctrlBtnClients_Click);
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 228);
            this.Controls.Add(this.ctrlBtnClients);
            this.Controls.Add(this.ctrlSFLblOffers);
            this.Controls.Add(this.ctrlSFDGV_offers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceForm";
            this.Text = "Сервис";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSFDGV_offers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ctrlSFDGV_offers;
        private System.Windows.Forms.Label ctrlSFLblOffers;
        private System.Windows.Forms.Button ctrlBtnClients;
    }
}