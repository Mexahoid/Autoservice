using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Classes.Service;

namespace Autoservice.Forms
{
    public partial class ServiceForm : Form
    {
        private MaintenanceService service;

        public ServiceForm(MaintenanceService service)
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


        }

        private void ctrlSFDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
