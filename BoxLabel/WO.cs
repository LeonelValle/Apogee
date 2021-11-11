using System;
using System.Windows.Forms;

namespace BoxLabel
{
    public partial class WO : Form
    {
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();
        public WO()
        {
            InitializeComponent();
        }

        private void Log()
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Wo.Text.Trim()) || !string.IsNullOrEmpty(txt_Qty.Text.Trim()))
            {
                if (!wo.Existe("select count(*) from tb_WoTop where wo = '" + txt_Wo.Text.Trim() + "'"))
                {

                    wo.Id_wo = int.Parse(wo.ReturnID("insert into tb_WoTop values('" + txt_Wo.Text.Trim() + "','" + txt_Qty.Text.Trim() + "'); SELECT SCOPE_IDENTITY();"));
                    txt_Qty.Text = "";
                    txt_Wo.Text = "";


                    Log();
                }
                else
                {
                    wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_WoTop where wo = '" + txt_Wo.Text.Trim() + "'"));
                    txt_Qty.Text = "";
                    txt_Wo.Text = "";

                    Log();
                    //MessageBox.Show("WO already exist!");
                }
            }
        }

        private bool ExistWO()
        {
            bool exist = false;

            wo.Wo = wo.ReturnFromROI("SELECT * FROM OPENQUERY([M2K], 'select Qty_To_Mfg from WO_v_1 where Wo_Nbr = ''" + txt_Wo.Text + "''')");
            wo.Qty = int.Parse(wo.ReturnFromROI("SELECT * FROM OPENQUERY([M2K], 'select Bom_Rev_Level from WO_v_1 where Wo_Nbr = ''" + wo.Wo + "''')"));
            pn.Pn = wo.ReturnFromROI("SELECT left(Part_Nbr,len(Part_Nbr)-3) FROM OPENQUERY([M2K], 'select Part_Nbr from WO_v_1 where Wo_Nbr = ''" + wo.Wo + "''')");

            return exist;
        }

        private void WO_Load(object sender, EventArgs e)
        {
          

        }

        private void lnk_reports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
        }
    }
}
