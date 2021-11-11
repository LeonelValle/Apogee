using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxLabel
{
    public partial class CRUD : Form
    {
        Conexion con = new Conexion();
        Shipping ship = new Shipping();
        public CRUD()
        {
            InitializeComponent();
        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {

            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows.Clear();

                if (dataGridView1.ColumnCount > 0)
                    dataGridView1.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView1.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView1.Rows.Add();
                    int myRowIndex = dataGridView1.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGridView1.Rows[myRowIndex])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                }
            }

        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                try
                {

                    ship.Id_inp = int.Parse(ship.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'"));

                    con.Crud("delete tb_shipping where id_inprocess = '" +ship.Id_inp + "'");


                }
                catch (System.Data.SqlClient.SqlException) { }
                //catch (System.NullReferenceException) { }
                //test.Crud("insert into test(cp_sin, cp_imei, cp_mac, nuc_sn, nuc_mac, mediabox_sn, result, test_time) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "')");


            }
            MessageBox.Show("Upload Completed!");


        }

        private void btn_Claer_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }
    }
}
