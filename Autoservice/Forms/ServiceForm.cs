using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Classes;
using Autoservice.Classes.Drawing;
using Autoservice.Classes.Service;

namespace Autoservice.Forms
{
    public partial class ServiceForm : Form
    {
        private MaintenanceServiceWrapper service;

        public ServiceForm(MaintenanceServiceWrapper service)
        {
            InitializeComponent();
            this.service = service;
            IList<string> maintenances = service.GetMaintenances();
            ctrlSFDGV_offers.ColumnCount = 1;
            ctrlSFDGV_offers.RowCount = maintenances.Count;
            ctrlSFDGV_offers.Columns[0].Width = ctrlSFDGV_offers.Width;

            for (int index = 0; index < maintenances.Count; index++)
            {
                ctrlSFDGV_offers.Rows[index].Cells[0].Value = maintenances[index];
            }

            CheckForIllegalCrossThreadCalls = false;
        }
        

        private void ctrlBtnClients_Click(object sender, EventArgs e)
        {
            Manager.GetInstance().ShowClients();
        }
    }
}
