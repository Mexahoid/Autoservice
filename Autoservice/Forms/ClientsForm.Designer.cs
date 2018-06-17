namespace Autoservice.Forms
{
    partial class ClientsForm
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
            this.ctrlDGVClients = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVClients)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDGVClients
            // 
            this.ctrlDGVClients.AllowUserToAddRows = false;
            this.ctrlDGVClients.AllowUserToDeleteRows = false;
            this.ctrlDGVClients.AllowUserToResizeColumns = false;
            this.ctrlDGVClients.AllowUserToResizeRows = false;
            this.ctrlDGVClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlDGVClients.ColumnHeadersVisible = false;
            this.ctrlDGVClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDGVClients.Location = new System.Drawing.Point(0, 0);
            this.ctrlDGVClients.Name = "ctrlDGVClients";
            this.ctrlDGVClients.RowHeadersVisible = false;
            this.ctrlDGVClients.Size = new System.Drawing.Size(387, 231);
            this.ctrlDGVClients.TabIndex = 0;
            this.ctrlDGVClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctrlDGVClients_CellClick);
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 231);
            this.Controls.Add(this.ctrlDGVClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientsForm";
            this.Text = "Клиенты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlDGVClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ctrlDGVClients;
    }
}