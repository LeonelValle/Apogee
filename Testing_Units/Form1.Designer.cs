
namespace Testing_Units
{
    partial class Form1
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
            this.btn_Pass = new System.Windows.Forms.Button();
            this.btn_Fail = new System.Windows.Forms.Button();
            this.txt_serial = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Number:";
            // 
            // btn_Pass
            // 
            this.btn_Pass.BackColor = System.Drawing.Color.Green;
            this.btn_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pass.Location = new System.Drawing.Point(269, 253);
            this.btn_Pass.Name = "btn_Pass";
            this.btn_Pass.Size = new System.Drawing.Size(109, 49);
            this.btn_Pass.TabIndex = 1;
            this.btn_Pass.Text = "Pass";
            this.btn_Pass.UseVisualStyleBackColor = false;
            this.btn_Pass.Click += new System.EventHandler(this.btn_Pass_Click);
            // 
            // btn_Fail
            // 
            this.btn_Fail.BackColor = System.Drawing.Color.Red;
            this.btn_Fail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fail.Location = new System.Drawing.Point(426, 253);
            this.btn_Fail.Name = "btn_Fail";
            this.btn_Fail.Size = new System.Drawing.Size(109, 49);
            this.btn_Fail.TabIndex = 2;
            this.btn_Fail.Text = "Fail";
            this.btn_Fail.UseVisualStyleBackColor = false;
            this.btn_Fail.Click += new System.EventHandler(this.btn_Fail_Click);
            // 
            // txt_serial
            // 
            this.txt_serial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_serial.Location = new System.Drawing.Point(238, 123);
            this.txt_serial.Name = "txt_serial";
            this.txt_serial.Size = new System.Drawing.Size(352, 31);
            this.txt_serial.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 422);
            this.Controls.Add(this.txt_serial);
            this.Controls.Add(this.btn_Fail);
            this.Controls.Add(this.btn_Pass);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Pass;
        private System.Windows.Forms.Button btn_Fail;
        private System.Windows.Forms.TextBox txt_serial;
    }
}

