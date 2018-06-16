namespace Autoservice.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ctrlTS = new System.Windows.Forms.ToolStrip();
            this.ctrlTSMI_Menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.ctrlTSMIHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlTS
            // 
            this.ctrlTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlTSMI_Menu});
            this.ctrlTS.Location = new System.Drawing.Point(0, 0);
            this.ctrlTS.Name = "ctrlTS";
            this.ctrlTS.Size = new System.Drawing.Size(800, 25);
            this.ctrlTS.TabIndex = 0;
            this.ctrlTS.Text = "toolStrip1";
            // 
            // ctrlTSMI_Menu
            // 
            this.ctrlTSMI_Menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ctrlTSMI_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlTSMIHelp});
            this.ctrlTSMI_Menu.Image = ((System.Drawing.Image)(resources.GetObject("ctrlTSMI_Menu.Image")));
            this.ctrlTSMI_Menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ctrlTSMI_Menu.Name = "ctrlTSMI_Menu";
            this.ctrlTSMI_Menu.Size = new System.Drawing.Size(54, 22);
            this.ctrlTSMI_Menu.Text = "Меню";
            // 
            // ctrlTSMIHelp
            // 
            this.ctrlTSMIHelp.Name = "ctrlTSMIHelp";
            this.ctrlTSMIHelp.Size = new System.Drawing.Size(123, 22);
            this.ctrlTSMIHelp.Text = "Помощь";
            this.ctrlTSMIHelp.Click += new System.EventHandler(this.ctrlTSMIHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlTS);
            this.Name = "MainForm";
            this.Text = "Автосервис";
            this.ctrlTS.ResumeLayout(false);
            this.ctrlTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ctrlTS;
        private System.Windows.Forms.ToolStripDropDownButton ctrlTSMI_Menu;
        private System.Windows.Forms.ToolStripMenuItem ctrlTSMIHelp;
    }
}

