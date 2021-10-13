namespace GameCaro
{
    partial class DetailSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailSetting));
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnMute = new System.Windows.Forms.Button();
            this.elipseControl1 = new GameCaro.ElipseControl();
            this.chkChanHaiDau = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdKho = new System.Windows.Forms.RadioButton();
            this.rdThuong = new System.Windows.Forms.RadioButton();
            this.rdDe = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.elipseControl2 = new GameCaro.ElipseControl();
            this.button2 = new System.Windows.Forms.Button();
            this.elipseControl3 = new GameCaro.ElipseControl();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Âm thanh";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 280);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(191, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseLeave += new System.EventHandler(this.trackBar1_MouseLeave);
            // 
            // btnMute
            // 
            this.btnMute.BackgroundImage = global::GameCaro.Properties.Resources.mnSound;
            this.btnMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMute.Location = new System.Drawing.Point(218, 280);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(50, 34);
            this.btnMute.TabIndex = 2;
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // elipseControl1
            // 
            this.elipseControl1.CornerRadius = 30;
            this.elipseControl1.TargetControl = this.btnMute;
            // 
            // chkChanHaiDau
            // 
            this.chkChanHaiDau.AutoSize = true;
            this.chkChanHaiDau.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.chkChanHaiDau.Location = new System.Drawing.Point(39, 133);
            this.chkChanHaiDau.Name = "chkChanHaiDau";
            this.chkChanHaiDau.Size = new System.Drawing.Size(105, 20);
            this.chkChanHaiDau.TabIndex = 3;
            this.chkChanHaiDau.Text = "Chặn hai đầu";
            this.chkChanHaiDau.UseVisualStyleBackColor = true;
            this.chkChanHaiDau.CheckedChanged += new System.EventHandler(this.chkChanHaiDau_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Độ khó";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdKho);
            this.panel1.Controls.Add(this.rdThuong);
            this.panel1.Controls.Add(this.rdDe);
            this.panel1.Location = new System.Drawing.Point(28, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 39);
            this.panel1.TabIndex = 4;
            // 
            // rdKho
            // 
            this.rdKho.AutoSize = true;
            this.rdKho.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.rdKho.Location = new System.Drawing.Point(190, 12);
            this.rdKho.Name = "rdKho";
            this.rdKho.Size = new System.Drawing.Size(50, 20);
            this.rdKho.TabIndex = 0;
            this.rdKho.TabStop = true;
            this.rdKho.Text = "Khó";
            this.rdKho.UseVisualStyleBackColor = true;
            this.rdKho.CheckedChanged += new System.EventHandler(this.rdKho_CheckedChanged);
            // 
            // rdThuong
            // 
            this.rdThuong.AutoSize = true;
            this.rdThuong.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.rdThuong.Location = new System.Drawing.Point(89, 12);
            this.rdThuong.Name = "rdThuong";
            this.rdThuong.Size = new System.Drawing.Size(71, 20);
            this.rdThuong.TabIndex = 0;
            this.rdThuong.TabStop = true;
            this.rdThuong.Text = "Thường";
            this.rdThuong.UseVisualStyleBackColor = true;
            this.rdThuong.CheckedChanged += new System.EventHandler(this.rdThuong_CheckedChanged);
            // 
            // rdDe
            // 
            this.rdDe.AutoSize = true;
            this.rdDe.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.rdDe.Location = new System.Drawing.Point(13, 12);
            this.rdDe.Name = "rdDe";
            this.rdDe.Size = new System.Drawing.Size(45, 20);
            this.rdDe.TabIndex = 0;
            this.rdDe.TabStop = true;
            this.rdDe.Text = "Dễ";
            this.rdDe.UseVisualStyleBackColor = true;
            this.rdDe.CheckedChanged += new System.EventHandler(this.rdDe_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kiểu Chơi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 15.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(12, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kích thước bàn cờ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(36, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Dòng";
            // 
            // txtSD
            // 
            this.txtSD.Location = new System.Drawing.Point(78, 214);
            this.txtSD.Name = "txtSD";
            this.txtSD.Size = new System.Drawing.Size(62, 20);
            this.txtSD.TabIndex = 6;
            this.txtSD.TextChanged += new System.EventHandler(this.txtSD_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(166, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cột";
            // 
            // txtSC
            // 
            this.txtSC.Location = new System.Drawing.Point(200, 214);
            this.txtSC.Name = "txtSC";
            this.txtSC.Size = new System.Drawing.Size(62, 20);
            this.txtSC.TabIndex = 6;
            this.txtSC.TextChanged += new System.EventHandler(this.txtSC_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.ForeColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(217, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "kiểm tra";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // elipseControl2
            // 
            this.elipseControl2.CornerRadius = 30;
            this.elipseControl2.TargetControl = this.button1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button2.ForeColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(217, 323);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Trờ Về";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // elipseControl3
            // 
            this.elipseControl3.CornerRadius = 30;
            this.elipseControl3.TargetControl = this.button2;
            // 
            // DetailSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(312, 362);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkChanHaiDau);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetailSetting_FormClosing);
            this.Load += new System.EventHandler(this.DetailSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnMute;
        private ElipseControl elipseControl1;
        private System.Windows.Forms.CheckBox chkChanHaiDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdKho;
        private System.Windows.Forms.RadioButton rdThuong;
        private System.Windows.Forms.RadioButton rdDe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSC;
        private System.Windows.Forms.Button button1;
        private ElipseControl elipseControl2;
        private System.Windows.Forms.Button button2;
        private ElipseControl elipseControl3;
    }
}