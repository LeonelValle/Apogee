using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Voyager_SN
{
    public partial class Form1 : Form
    {
        User user = new User();
        WorkOrder wo = new WorkOrder();

        public Form1()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dg_WO.DataSource = wo.LlenarDG("select wo, qty, pn.description from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn").Tables[0];
            if (user.Id_level == 3)
            {
                //btn_Reprint.Visible = false;
                //toolStripButton4.Visible = false;
                ////toolStripButton3.Visible = false;
                //btn_Reprint.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WO no = new WO();

            no.Show();
            this.Hide();

            //WO no = new WO();

            //Form NuevaOrden;
            //if ((NuevaOrden = IsFormAlreadyOpen(typeof(WO))) == null)
            //{
            //    no.ShowDialog(this);
            //}

            //else
            //{
            //    NuevaOrden.WindowState = FormWindowState.Normal;
            //    NuevaOrden.BringToFront();
            //}
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Reprint_Click(object sender, EventArgs e)
        {
            WO_Reprint no = new WO_Reprint();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(WO_Reprint))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;
                sn.BringToFront();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Scrap_WO no = new Scrap_WO();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(Scrap_WO))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;
                sn.BringToFront();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Reportes
            Mantenimiento no = new Mantenimiento();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(Mantenimiento))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            WO_ValidateSN no = new WO_ValidateSN();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(WO_ValidateSN))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;

            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            InitWO no = new InitWO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(InitWO))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }

        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
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
    }
}
