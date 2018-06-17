namespace Autoservice.Forms
{
    partial class ServiceCreateForm
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
            this.ctrlTBName = new System.Windows.Forms.TextBox();
            this.ctrlLblMiscName = new System.Windows.Forms.Label();
            this.ctrlLblMiscWorkers = new System.Windows.Forms.Label();
            this.ctrlLblMiscOffers = new System.Windows.Forms.Label();
            this.ctrlNUDWorkers = new System.Windows.Forms.NumericUpDown();
            this.ctrlNUDOffers = new System.Windows.Forms.NumericUpDown();
            this.ctrlBtnOK = new System.Windows.Forms.Button();
            this.ctrlBtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNUDWorkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNUDOffers)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlTBName
            // 
            this.ctrlTBName.Location = new System.Drawing.Point(87, 6);
            this.ctrlTBName.Name = "ctrlTBName";
            this.ctrlTBName.Size = new System.Drawing.Size(148, 20);
            this.ctrlTBName.TabIndex = 0;
            // 
            // ctrlLblMiscName
            // 
            this.ctrlLblMiscName.AutoSize = true;
            this.ctrlLblMiscName.Location = new System.Drawing.Point(12, 9);
            this.ctrlLblMiscName.Name = "ctrlLblMiscName";
            this.ctrlLblMiscName.Size = new System.Drawing.Size(60, 13);
            this.ctrlLblMiscName.TabIndex = 1;
            this.ctrlLblMiscName.Text = "Название:";
            // 
            // ctrlLblMiscWorkers
            // 
            this.ctrlLblMiscWorkers.AutoSize = true;
            this.ctrlLblMiscWorkers.Location = new System.Drawing.Point(12, 43);
            this.ctrlLblMiscWorkers.Name = "ctrlLblMiscWorkers";
            this.ctrlLblMiscWorkers.Size = new System.Drawing.Size(64, 13);
            this.ctrlLblMiscWorkers.TabIndex = 1;
            this.ctrlLblMiscWorkers.Text = "Работники:";
            // 
            // ctrlLblMiscOffers
            // 
            this.ctrlLblMiscOffers.AutoSize = true;
            this.ctrlLblMiscOffers.Location = new System.Drawing.Point(12, 77);
            this.ctrlLblMiscOffers.Name = "ctrlLblMiscOffers";
            this.ctrlLblMiscOffers.Size = new System.Drawing.Size(46, 13);
            this.ctrlLblMiscOffers.TabIndex = 1;
            this.ctrlLblMiscOffers.Text = "Услуги:";
            // 
            // ctrlNUDWorkers
            // 
            this.ctrlNUDWorkers.Location = new System.Drawing.Point(87, 41);
            this.ctrlNUDWorkers.Name = "ctrlNUDWorkers";
            this.ctrlNUDWorkers.Size = new System.Drawing.Size(148, 20);
            this.ctrlNUDWorkers.TabIndex = 2;
            this.ctrlNUDWorkers.ValueChanged += new System.EventHandler(this.ctrlNUDWorkers_ValueChanged);
            // 
            // ctrlNUDOffers
            // 
            this.ctrlNUDOffers.Location = new System.Drawing.Point(87, 75);
            this.ctrlNUDOffers.Name = "ctrlNUDOffers";
            this.ctrlNUDOffers.Size = new System.Drawing.Size(148, 20);
            this.ctrlNUDOffers.TabIndex = 2;
            this.ctrlNUDOffers.ValueChanged += new System.EventHandler(this.ctrlNUDOffers_ValueChanged);
            // 
            // ctrlBtnOK
            // 
            this.ctrlBtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlBtnOK.Location = new System.Drawing.Point(160, 137);
            this.ctrlBtnOK.Name = "ctrlBtnOK";
            this.ctrlBtnOK.Size = new System.Drawing.Size(75, 23);
            this.ctrlBtnOK.TabIndex = 3;
            this.ctrlBtnOK.Text = "ОК";
            this.ctrlBtnOK.UseVisualStyleBackColor = true;
            this.ctrlBtnOK.Click += new System.EventHandler(this.ctrlBtnOK_Click);
            // 
            // ctrlBtnClose
            // 
            this.ctrlBtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ctrlBtnClose.Location = new System.Drawing.Point(15, 137);
            this.ctrlBtnClose.Name = "ctrlBtnClose";
            this.ctrlBtnClose.Size = new System.Drawing.Size(75, 23);
            this.ctrlBtnClose.TabIndex = 3;
            this.ctrlBtnClose.Text = "Отмена";
            this.ctrlBtnClose.UseVisualStyleBackColor = true;
            this.ctrlBtnClose.Click += new System.EventHandler(this.ctrlBtnClose_Click);
            // 
            // ServiceCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 172);
            this.Controls.Add(this.ctrlBtnClose);
            this.Controls.Add(this.ctrlBtnOK);
            this.Controls.Add(this.ctrlNUDOffers);
            this.Controls.Add(this.ctrlNUDWorkers);
            this.Controls.Add(this.ctrlLblMiscOffers);
            this.Controls.Add(this.ctrlLblMiscWorkers);
            this.Controls.Add(this.ctrlLblMiscName);
            this.Controls.Add(this.ctrlTBName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceCreateForm";
            this.Text = "Создание сервиса";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNUDWorkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNUDOffers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ctrlTBName;
        private System.Windows.Forms.Label ctrlLblMiscName;
        private System.Windows.Forms.Label ctrlLblMiscWorkers;
        private System.Windows.Forms.Label ctrlLblMiscOffers;
        private System.Windows.Forms.NumericUpDown ctrlNUDWorkers;
        private System.Windows.Forms.NumericUpDown ctrlNUDOffers;
        private System.Windows.Forms.Button ctrlBtnOK;
        private System.Windows.Forms.Button ctrlBtnClose;
    }
}