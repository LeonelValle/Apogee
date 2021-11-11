using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Shipping
{
    public partial class Reports : Form
    {
        WorkOrder wo = new WorkOrder();
        Inprocess inprocess = new Inprocess();
        PN pn = new PN();

        public Reports()
        {
            InitializeComponent();
        }
        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            try
            {

                if (cb_Filter.Text == "Voyager")
                    VoyagerFile();
                //EditExcel();
                else
                    SaveToCSV(dg_Reports);

                MessageBox.Show("DONE!");
            }
            catch (System.ArgumentOutOfRangeException)
            {

                throw;
            }
        }

        private void VoyagerFile()
        {
            
            if (!Directory.Exists(@"C:/VoyagerFile/Apogee SN.xlsx"))
            {
                Directory.CreateDirectory(@"C:/VoyagerFile/");


                using (System.IO.FileStream fs = new System.IO.FileStream("C:\\VoyagerFile\\Apogee SN.xlsx", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    byte[] data = Properties.Resources.Apogee_SN;

                    fs.Write(data, 0, data.Length);
                }

                EditExcel();
            }
            else
            {
                EditExcel();
            }
        }

        private void EditExcel()
        {
            Application excel = new Application();

            //string path = @"C:\Users\leonel.valle\Desktop\WO 71976.xlsx";


            //Workbook workbook = excel.Workbooks.Open(@"\\192.168.1.4\labels$\Rocket\Voyager excel file\Voyager SN.xlsx", ReadOnly: false, Editable: true);
            Workbook workbook = excel.Workbooks.Open(@"C:\\VoyagerFile\Apogee SN.xlsx", ReadOnly: false, Editable: true);


            Worksheet worksheet = workbook.Worksheets.Item[1] as Worksheet;

            worksheet.Range["A8:D882"].Clear();

            if (worksheet == null)
                return;
            for (int i = 0; i < dg_Reports.Rows.Count; i++)
            {

                for (int j = 0; j < dg_Reports.Columns.Count; j++)
                {
                    if (dg_Reports.Rows[i].Cells[j].Value != null)
                    {

                        //worksheet.Cells[i + 2, j + 1] = dg_Reports.Rows[i].Cells[j].Value.ToString();
                        Range row1 = worksheet.Cells[i + 8, j + 1];
                        row1.Value = dg_Reports.Rows[i].Cells[j].Value.ToString();

                    }
                    else
                    {
                        //worksheet.Cells[i + 1, j + 1] = "";
                    }
                }
            }


            excel.Application.ActiveWorkbook.Save();
            excel.Application.Quit();
            excel.Quit();
        }



        private void ExportToExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;

                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < dg_Reports.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dg_Reports.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dg_Reports.Rows.Count; i++)
                    {
                        for (int j = 0; j < dg_Reports.Columns.Count; j++)
                        {
                            if (dg_Reports.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dg_Reports.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    //saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    //aveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void SaveToCSV(DataGridView DGV)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog
            {
                Filter = "Fichero CSV (*.csv)|*.csv",
                //FileName = dg_Reports.Rows[0].Cells[2].Value.ToString() + "-" + dg_Reports.Rows[0].Cells[4].Value.ToString(),
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                string salida_datos = "";
                _ = this.txt_Search.Text.Split(' ');

                //foreach (string palabra in palabra_busqueda)
                //{

                if (cb_Filter.Text == "Serial Number")
                {
                    if (wo.Existe("select COUNT(*) from tb_Inprocess where SerialNumber = '" + txt_Search.Text + "'"))
                    {
                        inprocess.Id_inprocess = int.Parse(wo.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + txt_Search.Text + "'"));
                        salida_datos = "select inp.SerialNumber as 'Serial Number', wot.wo as 'Work Order', wot.qty as 'Quantity', pn.description as 'Description', pn.pn as 'Part N#', pn.rev as 'Revision', ship.dateShip as 'Shipping Date' from tb_Inprocess inp join tb_shipping ship on inp.id_inprocess = ship.id_inprocess join tb_WO wo on wo.id_wo = inp.id_wo join tb_PN pn  on pn.id_pn = wo.id_pn join tb_User usr on  usr.id_user = inp.id_user join tb_WoTop wot on wot.id_wo = ship.id_wo where inp.id_inprocess = '" + inprocess.Id_inprocess + "' order by inp.id_inprocess asc";
                    }

                }
                else if (cb_Filter.Text == "Work Order")
                {
                    if (wo.Existe("select COUNT(*) from tb_WoTop where wo = '" + txt_Search.Text + "'"))
                    {
                        wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_WoTop where wo = '" + txt_Search.Text + "'"));
                        salida_datos = "select inp.SerialNumber as 'Serial Number', wot.wo as 'Work Order', wot.qty as 'Quantity', pn.description as 'Description', pn.pn as 'Part N#', pn.rev as 'Revision', ship.dateShip as 'Shipping Date' from tb_Inprocess inp join tb_shipping ship on inp.id_inprocess = ship.id_inprocess join tb_WO wo on wo.id_wo = inp.id_wo join tb_PN pn  on pn.id_pn = wo.id_pn join tb_User usr on  usr.id_user = inp.id_user join tb_WoTop wot on wot.id_wo = ship.id_wo where wot.id_wo = '" + wo.Id_wo + "' order by inp.id_inprocess asc";
                    }

                }
                else if (cb_Filter.Text == "Part Number")
                {
                    if (wo.Existe("select COUNT(*) from tb_PN where pn = '" + txt_Search.Text + "'"))
                    {
                        int id_pn1 = int.Parse(wo.ReturnID("select top 1 id_pn from tb_PN where pn = '" + txt_Search.Text + "' order by id_pn desc"));
                        int id_pn2 = int.Parse(wo.ReturnID("select top 1 id_pn from tb_PN where pn = '" + txt_Search.Text + "' order by id_pn asc"));
                        salida_datos = "select inp.SerialNumber as 'Serial Number', wot.wo as 'Work Order', wot.qty as 'Quantity', pn.description as 'Description', pn.pn as 'Part N#', pn.rev as 'Revision', ship.dateShip as 'Shipping Date' from tb_Inprocess inp join tb_shipping ship on inp.id_inprocess = ship.id_inprocess join tb_WO wo on wo.id_wo = inp.id_wo join tb_PN pn  on pn.id_pn = wo.id_pn join tb_User usr on  usr.id_user = inp.id_user join tb_WoTop wot on wot.id_wo = ship.id_wo where pn.id_pn = '" + id_pn1 + "' or pn.id_pn = '" + id_pn2 + "' order by inp.id_inprocess asc";
                    }

                }
                else if (cb_Filter.Text == "Date Shipping")
                {
                    DateTime fecha = Convert.ToDateTime(txt_Search.Text);
                    string buscar = fecha.ToString("yyyy-MM-dd");
                    salida_datos = "select inp.SerialNumber as 'Serial Number', wot.wo as 'Work Order', wot.qty as 'Quantity', pn.description as 'Description', pn.pn as 'Part N#', pn.rev as 'Revision', ship.dateShip as 'Shipping Date' from tb_Inprocess inp join tb_shipping ship on inp.id_inprocess = ship.id_inprocess join tb_WO wo on wo.id_wo = inp.id_wo join tb_PN pn  on pn.id_pn = wo.id_pn join tb_User usr on  usr.id_user = inp.id_user join tb_WoTop wot on wot.id_wo = ship.id_wo where CONVERT(varchar(255),ship.shippingDate,126) LIKE '%" + buscar + "%'";
                }
                else if (cb_Filter.Text == "Voyager")
                {
                    if (wo.Existe("select COUNT(*) from tb_WO where wo = '" + txt_Search.Text + "'"))
                    {
                        wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_WO where wo = '" + txt_Search.Text + "'"));
                        salida_datos = "select wo.wo as 'wono', inp.SerialNumber as 'serialno', pn.pn as 'part_no', wo.rev as 'revision' from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo join tb_PN pn on wo.id_pn = pn.id_pn left join tb_shipping ship on inp.id_inprocess = ship.id_inprocess left join tb_WoTop wot on ship.id_wo = wot.id_wo where wo.id_wo = '" + wo.Id_wo + "'";
                    }

                }


                dg_Reports.DataSource = wo.LlenarDG(salida_datos).Tables[0];
                //dg_buscar.DataSource = wo.BindGrid(salida_datos);
                //this.dg_Reports.Columns[0].Visible = false;
                //this.dg_buscar.Columns[1].Visible = false;
                //}
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Not Found!");

            }
        }
    }
}

