using System;
using System.Windows.Forms;

namespace Testing_Units
{
    public partial class Form1 : Form
    {
        Test test = new Test();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Pass_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_serial.Text.Trim()))
            {
                if (test.Existe("select count(*) from tb_Inprocess where SerialNumber = '" + txt_serial.Text.Trim() + "'"))
                {
                    test.Crud("insert into test values ('" + txt_serial.Text.Trim() + "','PASS','" + DateTime.Now + "')");
                    MessageBox.Show("SERIAL PASS!");
                    txt_serial.Text = "";
                    txt_serial.Focus();
                }
                else
                    MessageBox.Show("SERIAL NUMBER NOT EXIST!");
            }
            else
                MessageBox.Show("EMPTY DATA!");
        }

        private void btn_Fail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_serial.Text.Trim()))
            {
                if (test.Existe("select count(*) from tb_Inprocess where SerialNumber = '" + txt_serial.Text.Trim() + "'"))
                {
                    test.Crud("insert into test values ('" + txt_serial.Text.Trim() + "','FAIL','" + DateTime.Now + "')");
                    MessageBox.Show("SERIAL FAIL!");
                    txt_serial.Text = "";
                    txt_serial.Focus();
                }
                else
                    MessageBox.Show("SERIAL NUMBER NOT EXIST!");
            }
            else
                MessageBox.Show("EMPTY DATA!");
        }
    }
}
