﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Classes;

namespace Autoservice.Forms
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            Manager.GetInstance().AddHandler(UpdateDgv);
        }

        private void UpdateDgv(List<string> clients)
        {
            ctrlDGVClients.RowCount = 0;
            ctrlDGVClients.ColumnCount = 1;
            ctrlDGVClients.RowCount = clients.Count;
            ctrlDGVClients.Columns[0].Width = ctrlDGVClients.Width;

            for (int i = 0; i < clients.Count; i++)
            {
                ctrlDGVClients.Rows[i].Cells[0].Value = clients[i];
            }
        }

        private void ClientsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Manager.GetInstance().RemoveHandler(UpdateDgv);
        }

        private void ctrlDGVClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = ctrlDGVClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Manager.GetInstance().ShowClient(name);
        }
    }
}
