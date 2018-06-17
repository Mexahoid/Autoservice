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
            service.Event += FillDatagrids;
            IList<string> maintenances = service.GetMaintenances();
            ctrlSFDGV_offers.ColumnCount = 1;
            ctrlSFDGV_offers.RowCount = maintenances.Count;
            ctrlSFDGV_offers.Columns[0].Width = ctrlSFDGV_offers.Width;

            for (int index = 0; index < maintenances.Count; index++)
            {
                ctrlSFDGV_offers.Rows[index].Cells[0].Value = maintenances[index];
            }

            FillDatagrids();

            CheckForIllegalCrossThreadCalls = false;
        }


        private void FillDatagrids()
        {
            IList<string> input = service.GetInQueueCars();
            IList<string> working = service.GetWorkingCars();
            IList<string> output = service.GetReadyCars();

            ctrlSFDGVIn.ColumnCount = 0;
            ctrlSFDGVOut.ColumnCount = 0;
            ctrlSFDGVWork.ColumnCount = 0;

            if (input.Count > 0)
            {
                ctrlSFDGVIn.ColumnCount = 1;
                ctrlSFDGVIn.RowCount = input.Count;
                ctrlSFDGVIn.Columns[0].Width = ctrlSFDGVIn.Width;

                for (int index = 0; index < input.Count; index++)
                {
                    ctrlSFDGVIn.Rows[index].Cells[0].Value = input[index];
                }
            }

            if (working.Count > 0)
            {
                ctrlSFDGVWork.ColumnCount = 1;
                ctrlSFDGVWork.RowCount = working.Count;
                ctrlSFDGVWork.Columns[0].Width = ctrlSFDGVWork.Width;

                for (int index = 0; index < working.Count; index++)
                {
                    ctrlSFDGVWork.Rows[index].Cells[0].Value = working[index];
                }
            }

            if (output.Count <= 0)
                return;
            ctrlSFDGVOut.ColumnCount = 1;
            ctrlSFDGVOut.RowCount = output.Count;
            ctrlSFDGVOut.Columns[0].Width = ctrlSFDGVOut.Width;

            for (int index = 0; index < output.Count; index++)
            {
                ctrlSFDGVOut.Rows[index].Cells[0].Value = output[index];
            }
        }

        private void ctrlSFDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Manager.GetInstance().ShowClient(name);
        }
    }
}
