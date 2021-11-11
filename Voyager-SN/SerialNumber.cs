using Seagull.BarTender.Print;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Voyager_SN
{
    public partial class SerialNumber : Form
    {
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();
        Inprocess inprocess = new Inprocess();
        User user = new User();


        public SerialNumber()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void SerialNumber_Load(object sender, EventArgs e)
        {
            wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_wo where wo = '" + wo.Wo + "'"));

            dg_SN.DataSource = wo.LlenarDG("select SerialNumber, wo.wo, RegSN as 'Print Date', replace(Printed,1,'Printed') AS 'Print' from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo where Scrap = 0 or Scrap is null and wo.id_wo = '" + wo.Id_wo + "'").Tables[0];
            //label1.Text = DateTime.Now.ToString("yy" + WeekNumber());
            lbl_print.Text = wo.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "' and Printed != 0 and Scrap is null or Scrap = 0");
            wo.Qty = int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "' "));
            //wo.Qty = int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = 8 "));
            //wo.QtyReq = int.Parse(this.wo.ReturnValue("select qtyReq from tb_WO where id_wo = '" + wo.Id_wo + "' "));
            wo.QtyReq = int.Parse(lbl_print.Text);
            wo.Crud("update tb_WO set qtyReq = '" + wo.QtyReq + "' where id_wo = '" + wo.Id_wo + "'");

            lbl_Records.Text = wo.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "'");
            lbl_WO.Text = wo.Wo.ToString();
            //lbl_LP.Text = wo.ReturnValue("select count(*) from tb_Inprocess where Printed = 0 or Printed is null and id_wo = '" + wo.Id_wo + "'");
            lbl_LP.Text = wo.Qty.ToString();
            lbl_Idemploy.Text = user.ReturnValue("select nemploy from tb_User where id_user = '" + user.Id_user + "'");
            pn.Pn = wo.ReturnValue("select pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where id_wo = '" + wo.Id_wo + "'");
            pn.Rev = wo.ReturnValue("select rev from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where id_wo = '" + wo.Id_wo + "'");
        }

        private string WeekNumber()
        {

            var d = DateTime.Now;
            CultureInfo cul = CultureInfo.CurrentCulture;


            int weekNum = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);
            weekNum--;

            return weekNum.ToString().PadLeft(2, '0');
        }


        private void btn_Generate_Click(object sender, EventArgs e)
        {
            if (wo.QtyReq + int.Parse(txt_Qty.Text) <= wo.Qty && int.Parse(txt_Qty.Text) > 0)
            {
                if (pn.Pn == "3500-0087-0000")
                    SP_GenerateSN(wo.Wo, int.Parse(txt_Qty.Text));
                else if (pn.Pn == "3500-0076-0000")
                    SP_GenerateSNMic(wo.Wo, int.Parse(txt_Qty.Text));
                else if (pn.Pn == "3500-0086-0000")
                    SP_GenerateSNJAM(wo.Wo, int.Parse(txt_Qty.Text));

                PrintLabels();
                SerialNumber_Load(sender, e);
                txt_Qty.Text = "";


            }
            else
            {
                MessageBox.Show("Cannot generates zero or more Serial number than the WO Quantity!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void SP_GenerateSN(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabels", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WO", wo);
                cmd.Parameters.AddWithValue("@top", top);
                cmd.Parameters.AddWithValue("@WeekNumber", DateTime.Now.ToString("yy" + WeekNumber()));
                cmd.Parameters.AddWithValue("@id_user", user.Id_user);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
                this.wo.QtyReq = int.Parse(this.wo.ReturnValue("select qtyReq from tb_WO where id_wo = '" + this.wo.Id_wo + "'"));
            }
        }

        private void SP_GenerateSNMic(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Mic+", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WO", wo);
                cmd.Parameters.AddWithValue("@top", top);
                cmd.Parameters.AddWithValue("@WeekNumber", DateTime.Now.ToString("yy" + WeekNumber()));
                cmd.Parameters.AddWithValue("@id_user", user.Id_user);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
                this.wo.QtyReq = int.Parse(this.wo.ReturnValue("select qtyReq from tb_WO where id_wo = '" + this.wo.Id_wo + "'"));
            }
        }


        private void SP_GenerateSNJAM(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Jam+", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WO", wo);
                cmd.Parameters.AddWithValue("@top", top);
                cmd.Parameters.AddWithValue("@WeekNumber", DateTime.Now.ToString("yy" + WeekNumber()));
                cmd.Parameters.AddWithValue("@id_user", user.Id_user);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
                this.wo.QtyReq = int.Parse(this.wo.ReturnValue("select qtyReq from tb_WO where id_wo = '" + this.wo.Id_wo + "'"));
            }
        }


        private void PrintLabels()
        {
            inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");

            DefaultPrinter();


            MessageBox.Show("Printing labels completed!");
        }
        private void btn_Reprint_Click(object sender, EventArgs e)
        {
            Authenticate_Reprint no = new Authenticate_Reprint();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(Authenticate_Reprint))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;
                sn.BringToFront();
            }
        }


        private void DefaultPrinter()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();

                //LabelFormatDocument format = engine.ActiveDocument;

                //if (pn.Pn == "3500-0087-0000")
                //     format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\HMiC.btw");
                //else if (pn.Pn == "3500-0076-0000")
                //     format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\MiCPlus.btw");
                //else if (pn.Pn == "3500-0086-0000")
                //     format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\JamPlus.btw");

                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\Apogee_PCBA.btw");


                format.PrintSetup.PrinterName = @"\\MEX-ERP-003\Zebra_IT";
                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";


                //format.PageSetup.LabelColumns = 2;
                //format
                //format.PrintSetup. = int.Parse(txt_Qty.Text);
                int Toprint = int.Parse(txt_Qty.Text);
                format.PrintSetup.NumberOfSerializedLabels = Toprint;
                //format.SubStrings["PN"].Value = pn.Pn;
                //format.SubStrings["REV"].Value = "-" + pn.Rev;
                inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                format.SubStrings["SN"].Value = inprocess.SerialNumber;

                for (int i = 0; i < Toprint; i++)
                {
                    inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                    inprocess.Id_inprocess = int.Parse(inprocess.ReturnValue("select top 1 id_inprocess from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC"));

                    inprocess.Crud("update tb_Inprocess set Printed = 1 where id_inprocess = '" + inprocess.Id_inprocess + "'");
                }

                format.Print();

                engine.Stop();

            }
        }


        private void lbl_Idemploy_Click(object sender, EventArgs e)
        {

        }
    }
}
