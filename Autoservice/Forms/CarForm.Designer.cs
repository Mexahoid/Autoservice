namespace Autoservice.Forms
{
    partial class CarForm
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
            this.ctrlCFPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ctrlCFPanel
            // 
            this.ctrlCFPanel.BackColor = System.Drawing.Color.White;
            this.ctrlCFPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCFPanel.Location = new System.Drawing.Point(0, 0);
            this.ctrlCFPanel.Name = "ctrlCFPanel";
            this.ctrlCFPanel.Size = new System.Drawing.Size(540, 390);
            this.ctrlCFPanel.TabIndex = 0;
            // 
            // CarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 390);
            this.Controls.Add(this.ctrlCFPanel);
            this.Name = "CarForm";
            this.Text = "Автомобиль";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CarForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ctrlCFPanel;
    }
}