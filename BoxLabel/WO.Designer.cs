
namespace BoxLabel
{
    partial class WO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.txt_Wo = new System.Windows.Forms.TextBox();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lnk_reports = new System.Windows.Forms.LinkLabel();
            this.txt_rev = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Work Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "WorkOrder:";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(216, 268);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // txt_Wo
            // 
            this.txt_Wo.Location = new System.Drawing.Point(133, 105);
            this.txt_Wo.Name = "txt_Wo";
            this.txt_Wo.Size = new System.Drawing.Size(270, 20);
            this.txt_Wo.TabIndex = 0;
            // 
            // txt_Qty
            // 
            this.txt_Qty.Location = new System.Drawing.Point(133, 150);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(270, 20);
            this.txt_Qty.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity:";
            // 
            // lnk_reports
            // 
            this.lnk_reports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_reports.AutoSize = true;
            this.lnk_reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnk_reports.Location = new System.Drawing.Point(380, 312);
            this.lnk_reports.Name = "lnk_reports";
            this.lnk_reports.Size = new System.Drawing.Size(115, 16);
            this.lnk_reports.TabIndex = 55;
            this.lnk_reports.TabStop = true;
            this.lnk_reports.Text = "Go To Reports -->";
            this.lnk_reports.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_reports_LinkClicked);
            // 
            // txt_rev
            // 
            this.txt_rev.Location = new System.Drawing.Point(133, 188);
            this.txt_rev.Name = "txt_rev";
            this.txt_rev.Size = new System.Drawing.Size(270, 20);
            this.txt_rev.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Revision:";
            // 
            // txt_pn
            // 
            this.txt_pn.Location = new System.Drawing.Point(133, 227);
            this.txt_pn.Name = "txt_pn";
            this.txt_pn.Size = new System.Drawing.Size(270, 20);
            this.txt_pn.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Part N#:";
            // 
            // WO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 337);
            this.Controls.Add(this.txt_pn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_rev);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lnk_reports);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Wo);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WO";
            this.Text = "Work Order";
            this.Load += new System.EventHandler(this.WO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.TextBox txt_Wo;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnk_reports;
        private System.Windows.Forms.TextBox txt_rev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_pn;
        private System.Windows.Forms.Label label5;
    }
}