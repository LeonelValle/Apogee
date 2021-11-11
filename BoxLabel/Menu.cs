using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BoxLabel
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void btn_WO_Click(object sender, EventArgs e)
        {
            WO wo = new WO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(WO))) == null)
            {
                wo.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }

        }

        private void btn_Scanning_Click(object sender, EventArgs e)
        {
            FindWO f = new FindWO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(FindWO))) == null)
            {
                f.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(WO))) == null)
            {
                reports.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }
    }
}
