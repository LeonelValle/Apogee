using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace BoxLabel
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

                SaveToCSV(dg_Reports);

                MessageBox.Show("DONE!");
            }
            catch (System.ArgumentOutOfRangeException)
            {

                throw;
            }
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
                FileName = dg_Reports.Rows[0].Cells[2].Value.ToString() + "-" + dg_Reports.Rows[0].Cells[4].Value.ToString(),
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
                    salida_datos = "select inp.SerialNumber as 'Serial Number', wot.wo as 'Work Order', wot.qty as 'Quantity', pn.description as 'Description', pn.pn as 'Part N#', pn.rev as 'Revision', ship.dateShip as 'Shipping Date' from tb_Inprocess inp join tb_shipping ship on inp.id_inprocess = ship.id_inprocess join tb_WO wo on wo.id_wo = inp.id_wo join tb_PN pn  on pn.id_pn = wo.id_pn join tb_User usr on  usr.id_user = inp.id_user join tb_WoTop wot on wot.id_wo = ship.id_wo where CONVERT(varchar(255),ship.dateShip,126) LIKE '%" + buscar + "%'";
                }


                dg_Reports.DataSource = wo.LlenarDG(salida_datos).Tables[0];
                //dg_buscar.DataSource = wo.BindGrid(salida_datos);
                //this.dg_Reports.Columns[0].Visible = false;
                //this.dg_buscar.Columns[1].Visible = false;
                //}
            }
            catch (System.InvalidOperationException) {
                MessageBox.Show("Not Found!");
            
            }
        }
    }
}

