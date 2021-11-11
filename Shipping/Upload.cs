using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Shipping
{
    public partial class Upload : Form
    {
        //Test test = new Test();
        Conexion con = new Conexion();
        Inprocess inp = new Inprocess();

        public Upload()
        {
            InitializeComponent();
        }

        private void Upload_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("pn", "pn");
            dataGridView1.Columns.Add("pnDesc", "pnDesc");
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                try
                {
                    if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim()))
                    {
                        if (con.Existe("select count(*) from tb_Inprocess where SerialNumber = '" + dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() + "'"))
                        {

                            //test.sn = dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim().Length - 4);

                            inp.Id_inprocess = int.Parse(con.ReturnID("select id_inprocess from tb_Inprocess where SerialNumber = '" + dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() + "'"));
                            con.Crud("update tb_shipping set isShip = null where id_inprocess = '" + inp.Id_inprocess + "'");

                        }
                        else
                            MessageBox.Show("Error");

                    }else
                            MessageBox.Show("Vacio");

                }
                catch (System.Data.SqlClient.SqlException) { }


            }
            MessageBox.Show("Upload Completed!");



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


        private void Paste()
        {
            string s = Clipboard.GetText();

            string[] lines = s.Replace("\n", "").Split('\r');
            if (lines.Length == 1)
            {
                dataGridView1.Rows.Add(lines.Length);

            }
            else
            {
                dataGridView1.Rows.Add(lines.Length - 1);

            }
            string[] fields;
            int row = 0;
            int col = 0;

            foreach (string item in lines)
            {
                fields = item.Split('\t');
                foreach (string f in fields)
                {
                    Console.WriteLine(f);
                    dataGridView1[col, row].Value = f;
                    col++;
                }
                row++;
                col = 0;
            }
        }

        private void btn_Claer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
}
