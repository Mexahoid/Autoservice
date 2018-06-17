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

namespace Autoservice.Forms
{
    public partial class ClientsForm : Form
    {
        private static object locker = new object();
        public ClientsForm()
        {
            InitializeComponent();
            Manager.GetInstance().AddHandler(UpdateDgv);
            CheckForIllegalCrossThreadCalls = false;
        }

        public void UpdateDgv(List<string> clients)
        {
            lock (locker)
            {
                if (ctrlDGVClients == null)
                    return;
                ctrlDGVClients.RowCount = 0;
                ctrlDGVClients.ColumnCount = 1;
                ctrlDGVClients.RowCount = clients.Count;
                ctrlDGVClients.Columns[0].Width = ctrlDGVClients.Width;
                for (int i = 0; i < clients.Count; i++)
                {
                    if (ctrlDGVClients.RowCount == clients.Count)
                        ctrlDGVClients.Rows[i].Cells[0].Value = clients[i];
                }
            }
        }

        private void ClientsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Manager.GetInstance().RemoveHandler(UpdateDgv);
            Dispose();
        }

        private void ctrlDGVClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = ctrlDGVClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            
            Manager.GetInstance().ShowClient(name);
            //Close();
        }
    }
}
