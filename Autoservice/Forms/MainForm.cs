using System;
using System.Windows.Forms;
using Autoservice.Classes;
using Autoservice.Classes.Drawing;

namespace Autoservice.Forms
{
    public partial class MainForm : Form
    {
        private readonly Manager manager;
        private readonly MainFormDrawingManager drawManager;

        public MainForm()
        {
            InitializeComponent();
            drawManager = MainFormDrawingManager.GetInstance();
            manager = Manager.GetInstance();
            drawManager.SetCanvas(ctrlPanel);
            drawManager.EventReDraw += OnPaint;
        }

        private void ctrlTSMIHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Основные сущности: автомобили, виды поломок, предоставляемые услуги и цены, клиенты.\n" +
                            "Смоделировать процесс обслуживания автомобилей города в нескольких автосервисах, выполняющих различные типы работ.", "13: Автосервис");
        }

        /// <inheritdoc />
        /// <summary>
        /// Переопределяет метода перерисовки для инвалидации.
        /// </summary>
        /// <param name="e">Объект отрисовки.</param>
        protected override void OnPaint(PaintEventArgs e) => MainFormDrawingManager.GetInstance().Draw();

        private void ctrlTSMIAddCLient_Click(object sender, EventArgs e)
        {
            manager.MakeClient();
        }

        private void ctrlPanel_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    manager.InvokeMaintenanceForm(drawManager.FindMaintenanceByPointer(e.X, e.Y));
                    break;
                case MouseButtons.Right when drawManager.TryAddService(e.X, e.Y):
                    drawManager.AddDrawable(manager.AddService(), e.X, e.Y);
                    drawManager.Draw();
                    break;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            manager.Stop();
        }
    }
}
