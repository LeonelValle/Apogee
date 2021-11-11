using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Shipping
{
    public partial class Form1 : Form
    {
        Inprocess inp = new Inprocess();
        int box = 1;
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();
        List<Inprocess> ListInprocess = new List<Inprocess>();
        //List<string> Lists = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }


        private void SendValues()
        {
            //List<String> list = new List<string>();

            //list.Add(txt_BoxScan.Text.Trim());

            string[] sep = new string[] { "\r\n" };
            string[] lines = txt_BoxScan.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            int iteration = 0;
            var query = lines.GroupBy(x => x)
          .Where(g => g.Count() > 1)
          .Select(y => y.Key)
          .Count();

            if (query <= 0)
            {
                foreach (var item in lines)
                {
                    if (inp.Existe("select count(*) from tb_Inprocess where Serialnumber ='" + item + "'"))
                    {
                        inp.Id_inprocess = int.Parse(inp.ReturnID("select id_inprocess from tb_Inprocess where Serialnumber = '" + item + "'"));
                        if (inp.Existe("select count(*) from tb_shipping where isShip is null and id_inprocess = " + inp.Id_inprocess))
                        {
                            dg_Scan.Rows.Add(box, item);
                            iteration++;
                            if (iteration >= lines.Length)
                                box++;

                        }
                        else
                        {
                            MessageBox.Show("Serial Numbers already sent!");
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Duplicate Serial Numbers!");
                //break;
            }



            txt_BoxScan.Text = "";
        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //List<String> list = new List<string>();

            //list.Add(txt_BoxScan.Text.Trim());

            string[] sep = new string[] { "\r\n" };
            string[] lines = txt_BoxScan.Text.Trim().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            bool ExistSN = false;
            int iteration = 0;
            var query = lines.GroupBy(x => x)
          .Where(g => g.Count() > 1)
          .Select(y => y.Key)
          .Count();

            foreach (var item in lines)
            {
                foreach (DataGridViewRow row in dg_Scan.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(item))
                        ExistSN = true;
                    //row.Cells["SN"].Style.ForeColor = Color.Red;

                }
            }
            if (ExistSN == false)
            {

                if (query <= 0)
                {
                    foreach (var item in lines)
                    {
                        //if (inp.Existe("select count(*) from tb_Inprocess where Serialnumber ='" + item.Trim() + "'"))
                        //{

                        //inp.Id_inprocess = int.Parse(inp.ReturnID("select id_inprocess from tb_Inprocess where Serialnumber = '" + item.Trim() + "'"));
                        //if (!inp.Existe("select count(*) from tb_shipping where isShip is null and id_inprocess = " + inp.Id_inprocess))
                        //{

                        dg_Scan.Rows.Add(box, item);

                        iteration++;
                        if (iteration >= lines.Length)
                            box++;
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Serial Numbers already sent!");

                        //}
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Serial Number not exist!");
                        //    //break;
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate Serial Numbers!");
                    //break;
                }
            }
            else
            {
                MessageBox.Show("Box already Scanning!");
                //break;
            }


            lbl_Contador.Text = dg_Scan.Rows.Count.ToString(); ;
            txt_BoxScan.Text = "";
            txt_BoxScan.Focus();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            List<string> listid = new List<string>();
            if (dg_Scan.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to sent: " + lbl_Contador.Text + " units", "Shipping Save Records", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    for (int i = 0; i < dg_Scan.Rows.Count; i++)
                    {
                        inp.Id_inprocess = int.Parse(inp.ReturnID("select id_inprocess from tb_Inprocess where Serialnumber = '" + dg_Scan.Rows[i].Cells["SN"].Value.ToString().Trim() + "'"));
                        inp.Crud("update tb_shipping set shippingDate = '" + DateTime.Now + "', isShip = 1 where id_inprocess = " + inp.Id_inprocess);

                        inp.PartNo = inp.ReturnValue("select pn.pn from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where id_inprocess = '" + inp.Id_inprocess + "'");
                        inp.Revision = inp.ReturnValue("select wo.rev from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo where id_inprocess = '" + inp.Id_inprocess + "'");
                        try
                        {
                            wo.Wo = inp.ReturnValue("select wo.wo from tb_shipping ship join tb_WoTop wo on ship.id_wo = wo.id_wo where id_inprocess = '" + inp.Id_inprocess + "'");
                            wo.Qty = int.Parse(inp.ReturnValue("select wo.qty from tb_shipping ship join tb_WoTop wo on ship.id_wo = wo.id_wo where id_inprocess = '" + inp.Id_inprocess + "'"));
                            pn.Rev = inp.ReturnValue("select pn.rev from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where id_inprocess = '" + inp.Id_inprocess + "'"); ; ;
                            pn.Descripcion = inp.ReturnValue("select pn.description from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where id_inprocess = '" + inp.Id_inprocess + "'"); ;

                            inp.ShippingDate = DateTime.Parse(inp.ReturnValue("select shippingDate from tb_shipping where id_inprocess = '" + inp.Id_inprocess + "'"));

                        }
                        catch (Exception)
                        {

                            //throw;

                            listid.Add(inp.Id_inprocess.ToString());

                        }
                        //ListInprocess.Add(new Inprocess(inp.Id_inprocess, dg_Scan.Rows[i].Cells["SN"].Value.ToString(), inp.ShippingDate, inp.Revision, inp.PartNo));
                        ListInprocess.Add(new Inprocess(inp.Id_inprocess, dg_Scan.Rows[i].Cells["SN"].Value.ToString(), wo.Wo, wo.Qty, pn.Descripcion, inp.PartNo, inp.Revision, inp.ShippingDate));
                        if (i >= dg_Scan.Rows.Count)
                            break;

                    }

                    //dg_Scan.Rows.Clear();
                    //dg_Scan.Refresh();
                    //dg_Scan.DataSource = ListInprocess.ToList().GetRange(1, ListInprocess.Count - 2);
                    //SaveToCSV(dg_Scan);
                    SaveToCsv(ListInprocess);
                }
                //else if (dialogResult == DialogResult.No)
                //{
                //    //do something else
                //}
            }
            else
                MessageBox.Show("No Data!", "ERROR!");
        }

        private void SaveToCSV(DataGridView DGV)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog
            {
                Filter = "Fichero CSV (*.csv)|*.csv",
                //FileName = dg_Scan.Rows[0].Cells[2].Value.ToString() + "-" + dg_Scan.Rows[0].Cells[0].Value.ToString(),
                Title = "Exportar a CSV"
            };
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                System.Text.StringBuilder csvMemoria = new System.Text.StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 0; i < DGV.Columns.Count; i++)
                {
                    if (i == DGV.Columns.Count - 1)
                    {
                        csvMemoria.Append(String.Format("\"{0}\"",
                            DGV.Columns[i].HeaderText));
                    }
                    else
                    {
                        csvMemoria.Append(String.Format("\"{0}\",",
                            DGV.Columns[i].HeaderText));
                    }
                }

                csvMemoria.AppendLine();


                for (int m = 0; m < DGV.Rows.Count; m++)
                {
                    for (int n = 0; n < DGV.Columns.Count; n++)
                    {
                        //si es la última columna no poner el ;
                        if (n == DGV.Columns.Count - 1)
                        {
                            csvMemoria.Append(String.Format("\"{0}\"", DGV.Rows[m].Cells[n].Value, @"\d+"));
                        }
                        else
                        {
                            csvMemoria.Append(String.Format("\"{0}\",", DGV.Rows[m].Cells[n].Value, @"\d+"));
                        }

                    }
                    csvMemoria.AppendLine();
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(dlGuardar.FileName, false, System.Text.Encoding.Default);
                sw.Write(csvMemoria.ToString());
                sw.Close();
            }
        }

        private void txt_BoxScan_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_Submit_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dg_Scan.DataSource = null;
            dg_Scan.Rows.Clear();
            dg_Scan.Refresh();
            box = 1;
        }

        private void btn_Rreports_Click(object sender, EventArgs e)
        {

            Reports reports = new Reports();
            reports.Show();

        }

        private void SaveToCsv<Inprocess>(List<Inprocess> reportData)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog
            {
                Filter = "Fichero CSV (*.csv)|*.csv",
                //FileName = dg_Scan.Rows[0].Cells[2].Value.ToString() + "-" + dg_Scan.Rows[0].Cells[0].Value.ToString(),
                Title = "Exportar a CSV"
            };
            //reportData.Skip(1).Take(3).Select(x => x);
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {

                var lines = new List<string>();
                IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(Inprocess)).OfType<PropertyDescriptor>();
                string header = string.Join(",", props.Skip(1).Take(7).ToList().Select(x => x.Name));
                //header.Replace("SerialNumber,Wo,Qty Desc,PartNo,Revision,ShippingDate", "Serial Number,Work Order,Quantity,Description,Part N#,Revision,Shipping Date");
                string h = ("Serial Number,Work Order,Quantity,Description,Part N#,Revision,Shipping Date");
                lines.Add(h);
                var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
                lines.AddRange(valueLines);
                File.WriteAllLines(dlGuardar.FileName, lines.ToArray());

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /////

    }
}
