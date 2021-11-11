using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SupplyPro_Project
{
    public partial class Scanning : Form
    {
        WorkOrder wo = new WorkOrder();
        Scan scan = new Scan();
        User user = new User();
        Box box = new Box();
        PN pn = new PN();
        Test test = new Test();

        public Scanning()
        {
            InitializeComponent();
        }

        private void Scanning_Load(object sender, EventArgs e)
        {

            dg_Scan.DataSource = scan.LlenarDG("select sc.sn, sc.dateReg , pn.pn, box.box from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn join tb_Box box on box.id_box = sc.id_box where wo.id_wo = '" + wo.Id_wo + "'").Tables[0];


            scan.id_box = int.Parse(scan.ReturnValue("select top 1 id_box from tb_Box order by id_box desc"));
            scan.box = int.Parse(scan.ReturnValue("select box from tb_Box where id_box = " + scan.id_box));



            BoxControl();

            lbl_RB.Text = box.CountBox.ToString();

            lbl_Employ.Text = user.ReturnValue("select idemp from tb_User where id_user = '" + user.Id_user + "'");
            lbl_WO.Text = user.ReturnValue("select wo from tb_WO where id_wo = '" + wo.Id_wo + "'");
            lbl_Records.Text = scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'");




            if (int.Parse(scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'")) >= int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "'")))
            {
                txt_Scan.Enabled = false;
                MessageBox.Show("WO COMPLETED!");
            }
            txt_Scan.Focus();

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            BoxControl();
            if (!string.IsNullOrEmpty(txt_Scan.Text.Trim()))
            {
                GetSN();
                if (!scan.Existe("select count(*) from tb_Scan where id_inprocess = '" + scan.id_inprocess + "'"))
                {


                    scan.Crud("insert into tb_Scan(id_inprocess, dateReg, id_wo, id_user, id_box) values('" + txt_Scan.Text.Trim() + "','" + DateTime.Now + "','" + wo.Id_wo + "','" + user.Id_user + "','" + scan.id_box + "')");
                    BoxControl();
                    txt_Scan.Text = "";


                }
                else
                    MessageBox.Show("Unit duplicate!");

            }
            else
                MessageBox.Show("Empty Field!");
            Scanning_Load(sender, e);

        }
        private void btn_Submit_Enter(object sender, EventArgs e)
        {


            SendKeys.Send("{ENTER}");
        }

        private void dg_Scan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dg_Scan.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).Last();
            // scroll to last row if necessary
            dg_Scan.FirstDisplayedScrollingRowIndex = dg_Scan.Rows.IndexOf(row);
            // select row
            row.Selected = true;
        }

        private void BoxControl()
        {
            pn.unit = int.Parse(pn.ReturnValue("select unit from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where wo.id_wo = " + wo.Id_wo));
            box.CountBox = int.Parse(box.ReturnValue("select count(*) from tb_Scan where box = '" + scan.id_box + "'"));

            if (box.CountBox == pn.unit)
            {

                scan.box++;
                scan.Crud("insert into tb_Box values('" + scan.box + "')");
                scan.id_box = int.Parse(scan.ReturnValue("select top 1 id_box from tb_Box order by id_box desc"));

            }
            else
            {
                BOX.Text = scan.box.ToString();
                txt_Scan.Focus();
            }
        }

        private void GetSN()
        {
            scan.id_inprocess = scan.ReturnID("select id_inprocess from tb_inprocess where SerialNumber = '" + txt_Scan.Text.Trim() + "'");
        }

        private bool CheckTest()
        {
            bool tested = false;

            test.result = test.ReturnValue("select result from test where sn = '" + txt_Scan.Text.Trim() + "'");

            if (test.result == "Pass")
            {
                tested = true;
            }
            else if (test.result == "Fail")
            {
                tested = false;
            }


            return tested;
        }

    }
}
