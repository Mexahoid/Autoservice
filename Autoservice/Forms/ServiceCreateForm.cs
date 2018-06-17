using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoservice.Forms
{
    public partial class ServiceCreateForm : Form
    {
        public string ServiceName { get; set; }

        public int Workers { get; set; }

        public int Offers { get; set; }

        public ServiceCreateForm()
        {
            InitializeComponent();
            ServiceName = null;
        }

        private void ctrlBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlBtnOK_Click(object sender, EventArgs e)
        {
            ServiceName = ctrlTBName.Text;
            Close();
        }

        private void ctrlNUDWorkers_ValueChanged(object sender, EventArgs e)
        {
            Workers = (int) ctrlNUDWorkers.Value;
        }

        private void ctrlNUDOffers_ValueChanged(object sender, EventArgs e)
        {
            Offers = (int)ctrlNUDOffers.Value;
        }
    }
}
