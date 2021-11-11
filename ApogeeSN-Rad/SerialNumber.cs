using Seagull.BarTender.Print;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Voyager_SN
{
    public partial class SerialNumber : Form
    {
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();
        Inprocess inprocess = new Inprocess();
        User user = new User();
        Config config = new Config();

        public SerialNumber()
        {
            InitializeComponent();
            picLoader.Visible = false;

        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void LoadSetting()
        {
            wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_wo where wo = '" + wo.Wo + "'"));

            dg_SN.DataSource = wo.LlenarDG("select SerialNumber, wo.wo, RegSN as 'Print Date', replace(Printed,1,'Printed') AS 'Print' from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo where Scrap = 0 or Scrap is null and wo.id_wo = '" + wo.Id_wo + "'").Tables[0];
            inprocess.QtyReq = wo.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "' and Printed != 0 and Scrap is null or Scrap = 0");
            wo.Qty = int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "'"));
            wo.QtyReq = int.Parse(inprocess.QtyReq);
            wo.Crud("update tb_WO set qtyReq = '" + wo.QtyReq + "' where id_wo = '" + wo.Id_wo + "'");



            lbl_Records.Text = wo.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "' and Scrap is null");
            lbl_WO.Text = wo.Wo.ToString();
            lbl_LP.Text = wo.Qty.ToString();
            lbl_Idemploy.Text = user.ReturnValue("select nemploy from tb_User where id_user = '" + user.Id_user + "'");
            pn.Pn = wo.ReturnValue("select pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where id_wo = '" + wo.Id_wo + "'").ToString().Trim();
            pn.Rev = wo.ReturnValue("select revisionlbl from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where id_wo = '" + wo.Id_wo + "'");

            pn.Id_pn = int.Parse(wo.ReturnValue("select id_pn from tb_WO where id_wo = '" + wo.Id_wo + "'"));

            inprocess.SnContruction = inprocess.ReturnValue("select CONCAT(type,nom) from tb_PN where id_pn = '" + pn.Id_pn + "'");




            if (pn.Pn == "3500-0087-0000" && pn.Pn == "3500-0087-0000")
            {
                inprocess.SnContruction = inprocess.ReturnValue("select CONCAT(type,nom) from tb_PN where id_pn = " + pn.Id_pn);
            }
            else if (pn.Pn == "3500-0076-0000")
            {
                inprocess.SnContruction = inprocess.ReturnValue("select CONCAT(type,nom) from tb_PN where id_pn = " + pn.Id_pn);
            }
            else if (pn.Pn == "3500-0086-0000")
            {
                inprocess.SnContruction = inprocess.ReturnValue("select CONCAT(type,nom) from tb_PN where id_pn = " + pn.Id_pn);
            }
            else if (pn.Pn == "3500-0117-0000")
            {
                inprocess.SnContruction = inprocess.ReturnValue("select CONCAT(type,nom) from tb_PN where id_pn = " + pn.Id_pn);
            }
            else if (pn.Pn == "3500-0093-0000")
            {
                inprocess.SnContruction = inprocess.ReturnValue("select CONCAT(type,nom) from tb_PN where id_pn = " + pn.Id_pn);

                MessageBox.Show("Asegurese que este la etiqueta PN: 10023152 de color PLATEADO!","¡ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            lbl_PN.Text = pn.Pn;
            lbl_Rev.Text = pn.Rev;
            lbl_SN.Text = inprocess.SnContruction + pn.Rev + DateTime.Now.ToString("yy" + WeekNumber()) + "XXXXX";

            config.Printer = config.ReturnValue("select printer from config");

        }

        private void SerialNumber_Load(object sender, EventArgs e)
        {
            LoadSetting();
            //PrintBartender();
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
            try
            {
                Thread threadInput = new Thread(DisplayData);
                threadInput.Start();

                SerialNumber_Load(sender, e);
                //txt_Qty.Text = "";
            }
            catch (Exception ex)
            {

                DisplayError(ex);
            }


        }

        private void SP_GenerateSN_Rad(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Rad", con.Con1);
                //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabels", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WO", wo);
                cmd.Parameters.AddWithValue("@top", top);
                cmd.Parameters.AddWithValue("@WeekNumber", DateTime.Now.ToString("yy" + WeekNumber()));
                cmd.Parameters.AddWithValue("@id_pn", pn.Id_pn);
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

        private void SP_GenerateSN(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabels_Rad", con.Con1);
                //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabels", con.Con1);
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Mic+_Rad", con.Con1);
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Jam+_Rad", con.Con1);
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

        private void SP_GenerateSNSymphony(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Symphony_Rad", con.Con1);
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

        private void SP_GenerateSNJAM2(string wo, int top)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabel-Jam2_Rad", con.Con1);
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
            //inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");


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
            inprocess.Crud("delete Temp");

            using (Engine engine = new Engine())
            {
                engine.Start();



                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Apogee_PCBA.btw");

                if (pn.Pn == "3500-0093-0000")
                {
                    format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Symphony.btw");
                }

                format.PrintSetup.PrinterName = @"\\192.168.1.7\" + config.Printer;
                //format.PrintSetup.PrinterName = @"\\192.168.1.7\LabelPrinter08";

                int Toprint = int.Parse(txt_Qty.Text);
                format.PrintSetup.NumberOfSerializedLabels = 1;


                for (int i = 0; i < Toprint; i++)
                {
                    inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                    inprocess.Id_inprocess = int.Parse(inprocess.ReturnValue("select top 1 id_inprocess from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC"));

                    inprocess.ListSN.Add(inprocess.SerialNumber);
                    inprocess.Crud("update tb_Inprocess set Printed = 1 where id_inprocess = '" + inprocess.Id_inprocess + "'");
                }

                foreach (var item in inprocess.ListSN)
                {
                    inprocess.Crud("insert into Temp values('" + item + "')");
                }

                //format.Print();

                engine.Stop();
                //inprocess.Crud("delete Temp");

            }
            inprocess.ListSN.Clear();
        }


        private void lbl_Idemploy_Click(object sender, EventArgs e)
        {

        }

        private void txt_Qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Generate_Click(this, new EventArgs());
            }
        }

        private void DisplayData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(4000);

            if (wo.QtyReq + int.Parse(txt_Qty.Text) <= wo.Qty && int.Parse(txt_Qty.Text) > 0)
            {
                if (pn.Pn == "3500-0087-0000")
                    SP_GenerateSN(wo.Wo, int.Parse(txt_Qty.Text));
                else if (pn.Pn == "3500-0076-0000")
                    SP_GenerateSNMic(wo.Wo, int.Parse(txt_Qty.Text));
                else if (pn.Pn == "3500-0086-0000")
                    SP_GenerateSNJAM(wo.Wo, int.Parse(txt_Qty.Text));
                else if (pn.Pn == "3500-0117-0000")
                    SP_GenerateSNJAM2(wo.Wo, int.Parse(txt_Qty.Text));
                else if (pn.Pn == "3500-0093-0000")
                    SP_GenerateSNSymphony(wo.Wo, int.Parse(txt_Qty.Text));

                //SP_GenerateSN_Rad(wo.Wo, int.Parse(txt_Qty.Text));

                PrintLabels();
                //SerialNumber_Load(sender, e);
                //txt_Qty.Clear();
                //LoadSetting();
                txt_Qty.Invoke((Action)delegate
                {
                    txt_Qty.Text = "";
                    LoadSetting();
                });


            }
            else
            {
                MessageBox.Show("Cannot generates zero or more Serial number than the WO Quantity!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            SetLoading(false);
        }

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show("The below error occurred while processing the request: \n\r \n\r" + ex.Message);
        }

        private void btn_TestPrint_Click(object sender, EventArgs e)
        {
            inprocess.Crud("delete Temp");
            using (Engine engine = new Engine())
            {
                engine.Start();


                LabelFormatDocument format = engine.Documents.Open(@"C:\Users\leonel.valle\Desktop\Apogee_PCBA.btw");
                //LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Apogee_PCBA.btw");


                format.PrintSetup.PrinterName = @"\\MEX-ERP-003\Zebra_IT";
                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";

                format.PrintSetup.NumberOfSerializedLabels = 1;


                for (int i = 0; i < 4; i++)
                    inprocess.Crud("insert into Temp values('" + lbl_SN.Text.Trim() + "')");


                format.Print();

                engine.Stop();

                inprocess.Crud("delete Temp");
            }

        }
    }
}
