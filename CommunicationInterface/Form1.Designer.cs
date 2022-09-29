
namespace CommunicationInterface
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
            this.components = new System.ComponentModel.Container();
            this.writeBtn = new System.Windows.Forms.Button();
            this.writting_grb = new System.Windows.Forms.GroupBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.wtextBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reading_gbx = new System.Windows.Forms.GroupBox();
            this.rnumberBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtextBx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exit_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.error_lbl = new System.Windows.Forms.Label();
            this.writting_grb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.reading_gbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // writeBtn
            // 
            this.writeBtn.Location = new System.Drawing.Point(221, 28);
            this.writeBtn.Name = "writeBtn";
            this.writeBtn.Size = new System.Drawing.Size(93, 23);
            this.writeBtn.TabIndex = 0;
            this.writeBtn.Text = "Write";
            this.writeBtn.UseVisualStyleBackColor = true;
            this.writeBtn.Click += new System.EventHandler(this.writeBtn_Click);
            // 
            // writting_grb
            // 
            this.writting_grb.Controls.Add(this.numericUpDown);
            this.writting_grb.Controls.Add(this.wtextBx);
            this.writting_grb.Controls.Add(this.label2);
            this.writting_grb.Controls.Add(this.label1);
            this.writting_grb.Controls.Add(this.writeBtn);
            this.writting_grb.Location = new System.Drawing.Point(23, 25);
            this.writting_grb.Name = "writting_grb";
            this.writting_grb.Size = new System.Drawing.Size(320, 100);
            this.writting_grb.TabIndex = 1;
            this.writting_grb.TabStop = false;
            this.writting_grb.Text = "Write To FS19Writting.xml\"";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(49, 56);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown.TabIndex = 5;
            // 
            // wtextBx
            // 
            this.wtextBx.Location = new System.Drawing.Point(51, 30);
            this.wtextBx.MaxLength = 50;
            this.wtextBx.Name = "wtextBx";
            this.wtextBx.Size = new System.Drawing.Size(118, 20);
            this.wtextBx.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "text:";
            // 
            // reading_gbx
            // 
            this.reading_gbx.Controls.Add(this.rnumberBx);
            this.reading_gbx.Controls.Add(this.label3);
            this.reading_gbx.Controls.Add(this.rtextBx);
            this.reading_gbx.Controls.Add(this.label4);
            this.reading_gbx.Location = new System.Drawing.Point(23, 142);
            this.reading_gbx.Name = "reading_gbx";
            this.reading_gbx.Size = new System.Drawing.Size(320, 100);
            this.reading_gbx.TabIndex = 2;
            this.reading_gbx.TabStop = false;
            this.reading_gbx.Text = "Read From FS19Reading.xml";
            // 
            // rnumberBx
            // 
            this.rnumberBx.BackColor = System.Drawing.SystemColors.Info;
            this.rnumberBx.Location = new System.Drawing.Point(51, 55);
            this.rnumberBx.MaxLength = 50;
            this.rnumberBx.Name = "rnumberBx";
            this.rnumberBx.ReadOnly = true;
            this.rnumberBx.Size = new System.Drawing.Size(118, 20);
            this.rnumberBx.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "number:";
            // 
            // rtextBx
            // 
            this.rtextBx.BackColor = System.Drawing.SystemColors.Info;
            this.rtextBx.Location = new System.Drawing.Point(51, 30);
            this.rtextBx.MaxLength = 50;
            this.rtextBx.Name = "rtextBx";
            this.rtextBx.ReadOnly = true;
            this.rtextBx.Size = new System.Drawing.Size(118, 20);
            this.rtextBx.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "text:";
            // 
            // exit_btn
            // 
            this.exit_btn.Location = new System.Drawing.Point(268, 248);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(75, 23);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ERROR:";
            // 
            // error_lbl
            // 
            this.error_lbl.AutoSize = true;
            this.error_lbl.ForeColor = System.Drawing.Color.Red;
            this.error_lbl.Location = new System.Drawing.Point(45, 283);
            this.error_lbl.Name = "error_lbl";
            this.error_lbl.Size = new System.Drawing.Size(61, 13);
            this.error_lbl.TabIndex = 5;
            this.error_lbl.Text = "------------------";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 302);
            this.Controls.Add(this.error_lbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.reading_gbx);
            this.Controls.Add(this.writting_grb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FS19 test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.writting_grb.ResumeLayout(false);
            this.writting_grb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.reading_gbx.ResumeLayout(false);
            this.reading_gbx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button writeBtn;
        private System.Windows.Forms.GroupBox writting_grb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wtextBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox reading_gbx;
        private System.Windows.Forms.TextBox rnumberBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rtextBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label error_lbl;
    }
}

