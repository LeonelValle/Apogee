using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BoxLabel
{
    public partial class Form1 : Form
    {
        int CountSN = 0;
        Shipping ship = new Shipping();
        Inprocess inp = new Inprocess();
        WorkOrder wo = new WorkOrder();
        Box box = new Box();
        AccessCode ac = new AccessCode();
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectModel()
        {
            if (lbl_Model.Text == "Symphony Desktop")
            {

                //label3.Visible = true;
                //label3.Text = "CODE:";

                txt_CODE.Visible = true;
                lbl_CODE.Visible = true;

                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;

                txt_SN1.Visible = true;
                txt_SN2.Visible = false;

                txt_SN3.Visible = false;
                txt_SN4.Visible = false;
                txt_SN5.Visible = false;
                txt_SN6.Visible = false;
                txt_SN7.Visible = false;
                txt_SN8.Visible = false;
                txt_SN9.Visible = false;
                txt_SN10.Visible = false;
                txt_SN11.Visible = false;
                txt_SN12.Visible = false;

                txt_SN13.Visible = false;
                txt_SN14.Visible = false;
                txt_SN15.Visible = false;
                txt_SN16.Visible = false;
                txt_SN17.Visible = false;
                txt_SN18.Visible = false;
                txt_SN19.Visible = false;
                txt_SN20.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;


            }
            else if (lbl_Model.Text == "Hype Mic")
            {
                txt_CODE.Visible = false;
                lbl_CODE.Visible = false;

                label3.Visible = true;
                //label3.Text = "SN2:";
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;

                txt_SN1.Visible = true;
                txt_SN2.Visible = true;
                txt_SN3.Visible = true;
                txt_SN4.Visible = true;
                txt_SN5.Visible = true;
                txt_SN6.Visible = true;
                txt_SN7.Visible = true;
                txt_SN8.Visible = true;
                txt_SN9.Visible = true;
                txt_SN10.Visible = true;
                txt_SN11.Visible = true;
                txt_SN12.Visible = true;

                txt_SN13.Visible = false;
                txt_SN14.Visible = false;
                txt_SN15.Visible = false;
                txt_SN16.Visible = false;
                txt_SN17.Visible = false;
                txt_SN18.Visible = false;
                txt_SN19.Visible = false;
                txt_SN20.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;


            }
            else if (lbl_Model.Text == "Mic Plus")
            {

                txt_CODE.Visible = false;
                lbl_CODE.Visible = false;

                txt_SN1.Visible = true;
                txt_SN2.Visible = true;
                //label3.Text = "SN2:";
                txt_SN3.Visible = true;
                txt_SN4.Visible = true;
                txt_SN5.Visible = true;
                txt_SN6.Visible = true;
                txt_SN7.Visible = true;
                txt_SN8.Visible = true;
                txt_SN9.Visible = true;
                txt_SN10.Visible = true;
                txt_SN11.Visible = true;
                txt_SN12.Visible = true;
                txt_SN13.Visible = true;
                txt_SN14.Visible = true;
                txt_SN15.Visible = true;
                txt_SN16.Visible = true;
                txt_SN17.Visible = true;
                txt_SN18.Visible = true;
                txt_SN19.Visible = true;
                txt_SN20.Visible = true;

                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
            }
            else
            {
                txt_CODE.Visible = false;
                lbl_CODE.Visible = false;

                label3.Visible = true;
                //label3.Text = "SN2:";
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;


                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;

                txt_SN2.Visible = true;
                txt_SN3.Visible = true;
                txt_SN4.Visible = true;
                txt_SN5.Visible = true;
                txt_SN6.Visible = true;
                txt_SN7.Visible = true;
                txt_SN8.Visible = true;
                txt_SN9.Visible = true;
                txt_SN10.Visible = true;
                txt_SN11.Visible = true;
                txt_SN12.Visible = true;

                txt_SN13.Visible = true;
                txt_SN14.Visible = true;
                txt_SN15.Visible = true;
                txt_SN16.Visible = true;
                txt_SN17.Visible = true;
                txt_SN18.Visible = true;
                txt_SN19.Visible = true;
                txt_SN20.Visible = true;
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {

            CountTextBox();
            if (CheckExist() == false)
            {

                if (CheckDifferentModel() == false)
                {
                    if (Duplicates() == true)
                    {

                        //H1
                        if (lbl_Model.Text == "Hype Mic")
                        {
                            if (RecordSN() == false)
                            {
                                PrintHMiC();
                                Reprint();
                            }
                        }
                        //E4
                        else if (lbl_Model.Text == "Mic Plus")
                        {
                            if (RecordSN() == false)
                            {
                                PrintMiCPlus();
                                Reprint();
                            }
                        }
                        //B1
                        else if (lbl_Model.Text == "Jam Plus")
                        {
                            if (RecordSN() == false)
                            {
                                PrintJamPlus();
                                Reprint();
                            }
                        }
                        else if (lbl_Model.Text == "Symphony Desktop")
                        {
                            if (RecordSNSymphony() == false)
                            {
                                PrintSymphony();
                                Reprint();
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("no duplicate values");
                    }

                }
                else
                    MessageBox.Show("Scan Different Model");
            }
            else
                MessageBox.Show("Serial Number Not Exist!");
        }


        private void Reprint()
        {
            DialogResult dialogResult;/* = MessageBox.Show("Print Again", "Label Error!", MessageBoxButtons.YesNo);*/
            do
            {
                dialogResult = MessageBox.Show("Print Again?", "Reprint!", MessageBoxButtons.YesNo);


                if (dialogResult == DialogResult.No)
                {
                    //do something else
                    ClearTextBoxes();
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    //H1
                    if (lbl_Model.Text == "Hype Mic")
                    {
                        PrintHMiC();
                    }
                    //E4
                    else if (lbl_Model.Text == "Mic Plus")
                    {
                        PrintMiCPlus();
                    }
                    //B1
                    else if (lbl_Model.Text == "Jam Plus")
                    {
                        PrintJamPlus();
                    }
                    else if (lbl_Model.Text == "Symphony Desktop")
                    {
                        PrintSymphony();
                    }
                }

            } while (dialogResult == DialogResult.Yes);
        }
        public bool Duplicates()
        {

            List<TextBox> myTextBoxes = new List<TextBox>();

            //Add your textboxes to the list here...

            //Collect all your TextBox objects in a new list...  
            List<TextBox> textBoxes = new List<TextBox>
             {
                txt_SN1, txt_SN2, txt_SN3, txt_SN4, txt_SN5, txt_SN6, txt_SN7, txt_SN8, txt_SN9, txt_SN10, txt_SN11,txt_SN12,
                txt_SN13, txt_SN14, txt_SN15, txt_SN16, txt_SN17, txt_SN18, txt_SN19, txt_SN20
             };

            //Use LINQ to count duplicates in the list...
            int dupes = textBoxes.GroupBy(x => (x.Text.Trim()))
                                 .Where(x => x.Any())
                                 .Where(g => g.Count() > 1)
                                 .Count();

            //true if duplicates found, otherwise false
            return dupes <= 1;

        }
        private void CountTextBox()
        {
            CountSN = 0;
            //Add your textboxes to the list here...

            //Collect all your TextBox objects in a new list...  
            List<TextBox> textBoxes = new List<TextBox>
             {
                txt_SN1, txt_SN2, txt_SN3, txt_SN4, txt_SN5, txt_SN6, txt_SN7, txt_SN8, txt_SN9, txt_SN10, txt_SN11, txt_SN12,
                txt_SN13, txt_SN14, txt_SN15, txt_SN16, txt_SN17, txt_SN18, txt_SN19, txt_SN20
             };

            //Use LINQ to count duplicates in the list...
            //int dupes = textBoxes.Where(textBoxes.)
            //                     .Count();

            foreach (var item in textBoxes)
            {
                if (!string.IsNullOrEmpty(item.Text.Trim()))
                    CountSN++;
            }


            //true if duplicates found, otherwise false
            //return dupes < 1;
            //MessageBox.Show(CountSN.ToString());
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                        (control as TextBox).BackColor = Color.White;
                    }
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private bool RecordSN()
        {

            //Add your textboxes to the list here...

            //Collect all your TextBox objects in a new list...  
            List<TextBox> textBoxes = new List<TextBox>
             {
                txt_SN1, txt_SN2, txt_SN3, txt_SN4, txt_SN5, txt_SN6, txt_SN7, txt_SN8, txt_SN9, txt_SN10,
                txt_SN11,txt_SN12, txt_SN13, txt_SN14, txt_SN15, txt_SN16, txt_SN17, txt_SN18, txt_SN19, txt_SN20
             };


            bool exist = false;
            /////Check if exist serial 
            foreach (var item in textBoxes)
            {
                if (!string.IsNullOrEmpty(item.Text.Trim()))
                {
                    inp.Id_inprocess = int.Parse(ship.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + item.Text.Trim() + "'"));
                    if (ship.Existe("select count(*) from tb_shipping where id_inprocess = '" + inp.Id_inprocess + "'"))
                    {
                        exist = true;
                        MessageBox.Show("Serial Duplicado: " + item.Text.Trim());
                        break;
                    }
                }
            }

            //Save in db if not duplicate Serial
            if (exist == false)
            {
                box.Consecutive = int.Parse((box.ReturnValue("select consecutive from config")));
                box.Consecutive++;

                box.Nom = box.ReturnValue("select caracter1 from config");

                box.Boxes = box.Nom + "-" + DateTime.Now.ToString("yyMMdd") + box.Consecutive.ToString().PadLeft(5, '0');

                box.Id_box = int.Parse(box.ReturnID("insert into tb_box values('" + box.Boxes + "'); SELECT SCOPE_IDENTITY();"));
                box.Crud("update config set consecutive = '" + box.Consecutive + "'");

                foreach (var item in textBoxes)
                {
                    if (!string.IsNullOrEmpty(item.Text.Trim()))
                    {
                        inp.Id_inprocess = int.Parse(ship.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + item.Text.Trim() + "'"));
                        if (!ship.Existe("select count(*) from tb_shipping where id_inprocess = '" + inp.Id_inprocess + "'"))
                        {
                            ship.Id_inp = int.Parse(ship.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + item.Text.Trim() + "'"));
                            ship.Crud("insert into tb_shipping (id_inprocess, dateShip, id_wo, id_box) values ('" + ship.Id_inp + "','" + DateTime.Now + "','" + wo.Id_wo + "','" + box.Id_box + "')");
                        }
                    }
                }
            }

            return exist;

        }

        private bool RecordSNSymphony()
        {

            //Add your textboxes to the list here...

            //Collect all your TextBox objects in a new list...  
            List<TextBox> textBoxes = new List<TextBox>
             {
                txt_SN1
             };


            bool exist = false;
            ///Check if exist serial 
            foreach (var item in textBoxes)
            {
                if (!string.IsNullOrEmpty(item.Text.Trim()))
                {
                    inp.Id_inprocess = int.Parse(ship.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + item.Text.Trim() + "'"));
                    if (ship.Existe("select count(*) from tb_shipping where id_inprocess = '" + inp.Id_inprocess + "'"))
                    {
                        exist = true;
                        MessageBox.Show("Serial Duplicado: " + item.Text.Trim());
                        break;
                    }
                }
            }

            //Save in db if not duplicate Serial AND IS PASS TEST
            if (exist == false)
            {
                box.Consecutive = int.Parse((box.ReturnValue("select consecutive from config")));
                box.Consecutive++;

                box.Nom = box.ReturnValue("select caracter1 from config");

                box.Boxes = box.Nom + "-" + DateTime.Now.ToString("yyMMdd") + box.Consecutive.ToString().PadLeft(5, '0');

                box.Id_box = int.Parse(box.ReturnID("insert into tb_box values('" + box.Boxes + "'); SELECT SCOPE_IDENTITY();"));
                box.Crud("update config set consecutive = '" + box.Consecutive + "'");
                if (ship.ReturnValue("select TOP 1 test from test where serialnumber = '" + txt_SN1.Text.Trim() + "' ORDER BY id_test DESC") == "PASS")
                {
                    if (!ship.Existe("select count(*) from tb_shipping where AC = '" + txt_CODE.Text.Trim() + "'"))
                    {
                        if (ship.Existe("select * from accesscode where ac = '" + txt_CODE.Text.Trim() + "'"))
                        {

                            ship.Crud("insert into tb_shipping (id_inprocess, dateShip, id_wo, id_box, AC) values ('" + inp.Id_inprocess + "','" + DateTime.Now + "','" + wo.Id_wo + "','" + box.Id_box + "','" + txt_CODE.Text.Trim() + "')");
                            ac.Crud("update accesscode set used = '1', date_used = '" + DateTime.Now + "' where ac = '" + txt_CODE.Text.Trim() + "'");
                        }
                        else
                        {
                            MessageBox.Show("Access Code not exist!");
                            exist = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Access Code Already used!");
                        exist = true;
                    }

                }
                else
                {
                    MessageBox.Show("SERIAL NUMBER FAIL TEST!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    exist = true;
                }
            }

            return exist;

        }


        private bool CheckDifferentModel()
        {
            bool diff = false;
            //Add your textboxes to the list here...

            //Collect all your TextBox objects in a new list...  
            List<TextBox> textBoxes = new List<TextBox>
             {
                txt_SN1, txt_SN2, txt_SN3, txt_SN4, txt_SN5, txt_SN6, txt_SN7, txt_SN8, txt_SN9, txt_SN10,
                txt_SN11,txt_SN12, txt_SN13, txt_SN14, txt_SN15, txt_SN16, txt_SN17, txt_SN18, txt_SN19, txt_SN20
             };


            //Use LINQ to count duplicates in the list...            
            foreach (var item in textBoxes)
            {
                if (!string.IsNullOrEmpty(item.Text.Trim()))
                    if (textBoxes[0].Text.Trim().Substring(0, 2) != item.Text.Trim().Substring(0, 2))
                    {
                        item.BackColor = Color.Red;
                        diff = true;
                        //MessageBox.Show("");
                        //break;
                    }
            }

            return diff;
        }

        private bool CheckExist()
        {
            bool Exist = false;
            //Add your textboxes to the list here...

            //Collect all your TextBox objects in a new list...  
            List<TextBox> textBoxes = new List<TextBox>
             {
                txt_SN1, txt_SN2, txt_SN3, txt_SN4, txt_SN5, txt_SN6, txt_SN7, txt_SN8, txt_SN9, txt_SN10,
                txt_SN11,txt_SN12, txt_SN13, txt_SN14, txt_SN15, txt_SN16, txt_SN17, txt_SN18, txt_SN19, txt_SN20
             };


            //Use LINQ to count duplicates in the list...            
            foreach (var item in textBoxes)
            {
                if (!string.IsNullOrEmpty(item.Text.Trim()))
                    if (!inp.Existe("select count(*) from tb_Inprocess where SerialNumber = '" + item.Text.Trim() + "'"))
                    {
                        item.BackColor = Color.Yellow;
                        Exist = true;
                        //MessageBox.Show("");
                        //break;
                    }
            }

            return Exist;
        }

        private void PrintHMiC()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                //LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\Linea\Box Labels\Masterpack-HMiC.btw");
                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Linea\Box Labels\Masterpack-HMiC.btw");


                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";
                format.PrintSetup.PrinterName = @"LocalDP_Apogee2";


                // int Toprint = int.Parse(txt_Qty.Text);
                format.PrintSetup.NumberOfSerializedLabels = 1;
                format.SubStrings["SN1"].Value = txt_SN1.Text;
                format.SubStrings["SN2"].Value = txt_SN2.Text;
                format.SubStrings["SN3"].Value = txt_SN3.Text;
                format.SubStrings["SN4"].Value = txt_SN4.Text;
                format.SubStrings["SN5"].Value = txt_SN5.Text;
                format.SubStrings["SN6"].Value = txt_SN6.Text;
                format.SubStrings["SN7"].Value = txt_SN7.Text;
                format.SubStrings["SN8"].Value = txt_SN8.Text;
                format.SubStrings["SN9"].Value = txt_SN9.Text;
                format.SubStrings["SN10"].Value = txt_SN10.Text;
                format.SubStrings["SN11"].Value = txt_SN11.Text;
                format.SubStrings["SN12"].Value = txt_SN12.Text;
                format.SubStrings["QTY"].Value = CountSN.ToString();

                format.Print();

                engine.Stop();

            }
        }
        private void PrintJamPlus()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                //LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\Linea\Box Labels\Masterpack-JAMPLUS.btw");
                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Linea\Box Labels\Masterpack-JAMPLUS.btw");


                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";
                format.PrintSetup.PrinterName = @"LocalDP_Apogee2";


                format.SubStrings["SN1"].Value = txt_SN1.Text;
                format.SubStrings["SN2"].Value = txt_SN2.Text;
                format.SubStrings["SN3"].Value = txt_SN3.Text;
                format.SubStrings["SN4"].Value = txt_SN4.Text;
                format.SubStrings["SN5"].Value = txt_SN5.Text;
                format.SubStrings["SN6"].Value = txt_SN6.Text;
                format.SubStrings["SN7"].Value = txt_SN7.Text;
                format.SubStrings["SN8"].Value = txt_SN8.Text;
                format.SubStrings["SN9"].Value = txt_SN9.Text;
                format.SubStrings["SN10"].Value = txt_SN10.Text;
                format.SubStrings["SN11"].Value = txt_SN11.Text;
                format.SubStrings["SN12"].Value = txt_SN12.Text;
                format.SubStrings["SN13"].Value = txt_SN13.Text;
                format.SubStrings["SN14"].Value = txt_SN14.Text;
                format.SubStrings["SN15"].Value = txt_SN15.Text;
                format.SubStrings["SN16"].Value = txt_SN16.Text;
                format.SubStrings["SN17"].Value = txt_SN17.Text;
                format.SubStrings["SN18"].Value = txt_SN18.Text;
                format.SubStrings["SN19"].Value = txt_SN19.Text;
                format.SubStrings["SN20"].Value = txt_SN20.Text;
                format.SubStrings["QTY"].Value = CountSN.ToString();

                format.Print();
                engine.Stop();

            }
        }
        private void PrintMiCPlus()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                //LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\Linea\Box Labels\Masterpack-MiCPlus.btw");
                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Linea\Box Labels\Masterpack-MiCPlus.btw");


                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";
                format.PrintSetup.PrinterName = @"LocalDP_Apogee2";


                format.SubStrings["SN1"].Value = txt_SN1.Text;
                format.SubStrings["SN2"].Value = txt_SN2.Text;
                format.SubStrings["SN3"].Value = txt_SN3.Text;
                format.SubStrings["SN4"].Value = txt_SN4.Text;
                format.SubStrings["SN5"].Value = txt_SN5.Text;
                format.SubStrings["SN6"].Value = txt_SN6.Text;
                format.SubStrings["SN7"].Value = txt_SN7.Text;
                format.SubStrings["SN8"].Value = txt_SN8.Text;
                format.SubStrings["SN9"].Value = txt_SN9.Text;
                format.SubStrings["SN10"].Value = txt_SN10.Text;
                format.SubStrings["SN11"].Value = txt_SN11.Text;
                format.SubStrings["SN12"].Value = txt_SN12.Text;
                format.SubStrings["SN13"].Value = txt_SN13.Text;
                format.SubStrings["SN14"].Value = txt_SN14.Text;
                format.SubStrings["SN15"].Value = txt_SN15.Text;
                format.SubStrings["SN16"].Value = txt_SN16.Text;
                format.SubStrings["SN17"].Value = txt_SN17.Text;
                format.SubStrings["SN18"].Value = txt_SN18.Text;
                format.SubStrings["SN19"].Value = txt_SN19.Text;
                format.SubStrings["SN20"].Value = txt_SN20.Text;

                format.SubStrings["QTY"].Value = CountSN.ToString();

                format.Print();
                engine.Stop();

            }
        }

        private void PrintSymphony()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                //LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\labels$\Apogee\Linea\Box Labels\Masterpack-HMiC.btw");
                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\Apogee\Linea\Box Labels\Master Carton.btw");


                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";

                format.PrintSetup.PrinterName = @"Apogee_DP03";


                // int Toprint = int.Parse(txt_Qty.Text);
                format.PrintSetup.NumberOfSerializedLabels = 1;
                format.SubStrings["sn"].Value = txt_SN1.Text;

                format.Print();

                engine.Stop();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Print Again", "Label Error!", MessageBoxButtons.YesNo);


            lbl_WO.Text = wo.ReturnValue("select wo from tb_WoTop where id_wo = '" + wo.Id_wo + "'");
            lbl_Qty.Text = wo.ReturnValue("select qty from tb_WoTop where id_wo = '" + wo.Id_wo + "'");
        }
        private void txt_SN1_TextChanged(object sender, EventArgs e)
        {
            //SelectModel();
            if (txt_SN1.Text.Length > 1)
            {
                if (txt_SN1.Text.Substring(0, 2) == "H1")
                {
                    lbl_Model.Text = "Hype Mic";
                }
                else if (txt_SN1.Text.Substring(0, 2) == "E4")
                {
                    lbl_Model.Text = "Mic Plus";
                }
                else if (txt_SN1.Text.Substring(0, 2) == "B1")
                {
                    lbl_Model.Text = "Jam Plus";
                }
                else if (txt_SN1.Text.Substring(0, 2) == "SD")
                {
                    lbl_Model.Text = "Symphony Desktop";
                }
            }
            else if (txt_SN1.Text.Length <= 1)
                lbl_Model.Text = "Model";
        }

        private void lnk_reports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
        }

        private void lbl_Model_TextChanged(object sender, EventArgs e)
        {
            SelectModel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
