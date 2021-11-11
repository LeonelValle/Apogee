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
    public partial class FindWO : Form
    {
        WorkOrder wo = new WorkOrder();
        Conexion con = new Conexion();
        User user = new User();

        public FindWO()
        {
            InitializeComponent();
        }
        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (wo.Existe("select count(*) from tb_WO where wo = '" + txt_WO.Text + "'"))
            {
                //wo.wo = txt_WO.Text;

                wo.Id_wo = (wo.ReturnID("select id_wo from tb_WO where wo = '" + txt_WO.Text + "'"));
                //user.Nemploy = int.Parse(txt_Employ.Text);

                IdentifyEmploy sn = new IdentifyEmploy();

                Form NuevaOrden;
                if ((NuevaOrden = IsFormAlreadyOpen(typeof(IdentifyEmploy))) == null)
                {
                    sn.ShowDialog(this);
                }
                else
                {
                    NuevaOrden.WindowState = FormWindowState.Normal;
                    NuevaOrden.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Not found!", "ERROR");
            }
        }

        private void txt_WO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(this, new EventArgs());
            }
        }
    }
}
