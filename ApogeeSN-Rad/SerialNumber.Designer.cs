namespace Voyager_SN
{
    partial class SerialNumber
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialNumber));
            this.dg_SN = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Records = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.btn_Reprint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_WO = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_LP = new System.Windows.Forms.Label();
            this.lbl_Idemploy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_PN = new System.Windows.Forms.Label();
            this.lbl_Rev = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_SN = new System.Windows.Forms.Label();
            this.nhnh = new System.Windows.Forms.Label();
            this.btn_TestPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_SN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_SN
            // 
            this.dg_SN.AllowUserToAddRows = false;
            this.dg_SN.AllowUserToDeleteRows = false;
            this.dg_SN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_SN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_SN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_SN.Location = new System.Drawing.Point(16, 221);
            this.dg_SN.Name = "dg_SN";
            this.dg_SN.RowHeadersWidth = 51;
            this.dg_SN.Size = new System.Drawing.Size(1342, 379);
            this.dg_SN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total records:";
            // 
            // lbl_Records
            // 
            this.lbl_Records.AutoSize = true;
            this.lbl_Records.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Records.Location = new System.Drawing.Point(124, 195);
            this.lbl_Records.Name = "lbl_Records";
            this.lbl_Records.Size = new System.Drawing.Size(51, 16);
            this.lbl_Records.TabIndex = 4;
            this.lbl_Records.Text = "label3";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(12, 61);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(127, 20);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "Qty to Genarate:";
            // 
            // txt_Qty
            // 
            this.txt_Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Qty.Location = new System.Drawing.Point(16, 84);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(392, 26);
            this.txt_Qty.TabIndex = 6;
            this.txt_Qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Qty_KeyDown);
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(466, 69);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(75, 41);
            this.btn_Generate.TabIndex = 7;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // btn_Reprint
            // 
            this.btn_Reprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reprint.Location = new System.Drawing.Point(1283, 186);
            this.btn_Reprint.Name = "btn_Reprint";
            this.btn_Reprint.Size = new System.Drawing.Size(75, 29);
            this.btn_Reprint.TabIndex = 10;
            this.btn_Reprint.Text = "Re-Print";
            this.btn_Reprint.UseVisualStyleBackColor = true;
            this.btn_Reprint.Click += new System.EventHandler(this.btn_Reprint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(297, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Qty to print:";
            // 
            // lbl_WO
            // 
            this.lbl_WO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_WO.AutoSize = true;
            this.lbl_WO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WO.Location = new System.Drawing.Point(808, 39);
            this.lbl_WO.Name = "lbl_WO";
            this.lbl_WO.Size = new System.Drawing.Size(60, 20);
            this.lbl_WO.TabIndex = 14;
            this.lbl_WO.Text = "lbl_WO";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(708, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Work Order:";
            // 
            // lbl_LP
            // 
            this.lbl_LP.AutoSize = true;
            this.lbl_LP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LP.Location = new System.Drawing.Point(389, 195);
            this.lbl_LP.Name = "lbl_LP";
            this.lbl_LP.Size = new System.Drawing.Size(51, 16);
            this.lbl_LP.TabIndex = 16;
            this.lbl_LP.Text = "label3";
            // 
            // lbl_Idemploy
            // 
            this.lbl_Idemploy.AutoSize = true;
            this.lbl_Idemploy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Idemploy.Location = new System.Drawing.Point(124, 19);
            this.lbl_Idemploy.Name = "lbl_Idemploy";
            this.lbl_Idemploy.Size = new System.Drawing.Size(51, 16);
            this.lbl_Idemploy.TabIndex = 18;
            this.lbl_Idemploy.Text = "label3";
            this.lbl_Idemploy.Click += new System.EventHandler(this.lbl_Idemploy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "ID Employee:";
            // 
            // picLoader
            // 
            this.picLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLoader.Image = ((System.Drawing.Image)(resources.GetObject("picLoader.Image")));
            this.picLoader.Location = new System.Drawing.Point(660, 332);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(136, 111);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoader.TabIndex = 19;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(736, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Part N#:";
            // 
            // lbl_PN
            // 
            this.lbl_PN.AutoSize = true;
            this.lbl_PN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PN.Location = new System.Drawing.Point(808, 69);
            this.lbl_PN.Name = "lbl_PN";
            this.lbl_PN.Size = new System.Drawing.Size(54, 20);
            this.lbl_PN.TabIndex = 21;
            this.lbl_PN.Text = "lbl_PN";
            // 
            // lbl_Rev
            // 
            this.lbl_Rev.AutoSize = true;
            this.lbl_Rev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Rev.Location = new System.Drawing.Point(808, 108);
            this.lbl_Rev.Name = "lbl_Rev";
            this.lbl_Rev.Size = new System.Drawing.Size(61, 20);
            this.lbl_Rev.TabIndex = 23;
            this.lbl_Rev.Text = "lbl_Rev";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(729, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Revision:";
            // 
            // lbl_SN
            // 
            this.lbl_SN.AutoSize = true;
            this.lbl_SN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SN.Location = new System.Drawing.Point(808, 143);
            this.lbl_SN.Name = "lbl_SN";
            this.lbl_SN.Size = new System.Drawing.Size(161, 20);
            this.lbl_SN.TabIndex = 25;
            this.lbl_SN.Text = "H1M3002113XXXXX";
            // 
            // nhnh
            // 
            this.nhnh.AutoSize = true;
            this.nhnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhnh.Location = new System.Drawing.Point(689, 143);
            this.nhnh.Name = "nhnh";
            this.nhnh.Size = new System.Drawing.Size(113, 20);
            this.nhnh.TabIndex = 24;
            this.nhnh.Text = "Serial Number:";
            // 
            // btn_TestPrint
            // 
            this.btn_TestPrint.Location = new System.Drawing.Point(1283, 52);
            this.btn_TestPrint.Name = "btn_TestPrint";
            this.btn_TestPrint.Size = new System.Drawing.Size(75, 41);
            this.btn_TestPrint.TabIndex = 26;
            this.btn_TestPrint.Text = "Test Print";
            this.btn_TestPrint.UseVisualStyleBackColor = true;
            this.btn_TestPrint.Click += new System.EventHandler(this.btn_TestPrint_Click);
            // 
            // SerialNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 612);
            this.Controls.Add(this.btn_TestPrint);
            this.Controls.Add(this.lbl_SN);
            this.Controls.Add(this.nhnh);
            this.Controls.Add(this.lbl_Rev);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_PN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLoader);
            this.Controls.Add(this.lbl_Idemploy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_LP);
            this.Controls.Add(this.lbl_WO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Reprint);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl_Records);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dg_SN);
            this.Name = "SerialNumber";
            this.Text = "SerialNumber";
            this.Load += new System.EventHandler(this.SerialNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_SN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dg_SN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Records;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Button btn_Reprint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_WO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_LP;
        private System.Windows.Forms.Label lbl_Idemploy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_PN;
        private System.Windows.Forms.Label lbl_Rev;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_SN;
        private System.Windows.Forms.Label nhnh;
        private System.Windows.Forms.Button btn_TestPrint;
    }
}