using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyPro_Project
{
    public partial class MainMenu : Form
    {
        WorkOrder wo = new WorkOrder();

        public MainMenu()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dg_Inprocess.DataSource = wo.LlenarDG("select wo, qty, pn.pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn").Tables[0];

        }

        private void btn_WO_Click(object sender, EventArgs e)
        {
            WO no = new WO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(WO))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void btn_Scanning_Click(object sender, EventArgs e)
        {
            FindWO no = new FindWO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(FindWO))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            Reports no = new Reports();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(Reports))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WO no = new WO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(WO))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }
    }
}
