using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Classes.Drawing;

namespace Autoservice.Forms
{
    public partial class CarForm : Form
    {
        private readonly CarFormDrawingManager carFormDrawingManager;

        public CarForm()
        {
            InitializeComponent();
            carFormDrawingManager = CarFormDrawingManager.GetInstance();
            carFormDrawingManager.EventReDraw += OnPaint;
            carFormDrawingManager.SetCanvas(ctrlCFPanel);
            carFormDrawingManager.Draw();

            CheckForIllegalCrossThreadCalls = false;
        }
        

        protected override void OnPaint(PaintEventArgs e) => carFormDrawingManager.Draw();

        private void CarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            carFormDrawingManager.EventReDraw -= OnPaint;
        }
    }
}
