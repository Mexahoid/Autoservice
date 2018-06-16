using System;
using System.Windows.Forms;

namespace Autoservice.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ctrlTSMIHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Основные сущности: автомобили, виды поломок, предоставляемые услуги и цены, клиенты.\n" +
                            "Смоделировать процесс обслуживания автомобилей города в нескольких автосервисах, выполняющих различные типы работ.", "13: Автосервис");
        }
    }
}
