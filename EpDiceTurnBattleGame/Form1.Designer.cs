namespace EpDiceTurnBattleGame
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel = new EpDiceTurnBattleGame.DoubleBufferPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OneDfd = new System.Windows.Forms.RadioButton();
            this.OneAtk = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Mag = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TwoDfd = new System.Windows.Forms.RadioButton();
            this.TwoAtk = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.ListBox();
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.RunAnimation);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel.Controls.Add(this.panel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(884, 501);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(50, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 180);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "피격시 마법 무효화";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.OneDfd);
            this.groupBox1.Controls.Add(this.OneAtk);
            this.groupBox1.Location = new System.Drawing.Point(661, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "첫장";
            // 
            // OneDfd
            // 
            this.OneDfd.AutoSize = true;
            this.OneDfd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OneDfd.Location = new System.Drawing.Point(75, 17);
            this.OneDfd.Name = "OneDfd";
            this.OneDfd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OneDfd.Size = new System.Drawing.Size(47, 16);
            this.OneDfd.TabIndex = 3;
            this.OneDfd.TabStop = true;
            this.OneDfd.Text = "방어";
            this.OneDfd.UseVisualStyleBackColor = true;
            this.OneDfd.CheckedChanged += new System.EventHandler(this.OneDfd_CheckedChanged);
            // 
            // OneAtk
            // 
            this.OneAtk.AutoSize = true;
            this.OneAtk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OneAtk.Location = new System.Drawing.Point(15, 17);
            this.OneAtk.Name = "OneAtk";
            this.OneAtk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OneAtk.Size = new System.Drawing.Size(47, 16);
            this.OneAtk.TabIndex = 2;
            this.OneAtk.TabStop = true;
            this.OneAtk.Text = "공격";
            this.OneAtk.UseVisualStyleBackColor = true;
            this.OneAtk.CheckedChanged += new System.EventHandler(this.OneAtk_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.Mag);
            this.groupBox3.Location = new System.Drawing.Point(661, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(132, 39);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "전장";
            // 
            // Mag
            // 
            this.Mag.AutoSize = true;
            this.Mag.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Mag.Location = new System.Drawing.Point(75, 17);
            this.Mag.Name = "Mag";
            this.Mag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Mag.Size = new System.Drawing.Size(47, 16);
            this.Mag.TabIndex = 3;
            this.Mag.TabStop = true;
            this.Mag.Text = "마법";
            this.Mag.UseVisualStyleBackColor = true;
            this.Mag.CheckedChanged += new System.EventHandler(this.Mag_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "마법 == 방어 무시";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Silver;
            this.groupBox4.Controls.Add(this.TwoDfd);
            this.groupBox4.Controls.Add(this.TwoAtk);
            this.groupBox4.Location = new System.Drawing.Point(661, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 39);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "종장";
            // 
            // TwoDfd
            // 
            this.TwoDfd.AutoSize = true;
            this.TwoDfd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TwoDfd.Location = new System.Drawing.Point(75, 17);
            this.TwoDfd.Name = "TwoDfd";
            this.TwoDfd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TwoDfd.Size = new System.Drawing.Size(47, 16);
            this.TwoDfd.TabIndex = 3;
            this.TwoDfd.TabStop = true;
            this.TwoDfd.Text = "방어";
            this.TwoDfd.UseVisualStyleBackColor = true;
            this.TwoDfd.CheckedChanged += new System.EventHandler(this.TwoDfd_CheckedChanged);
            // 
            // TwoAtk
            // 
            this.TwoAtk.AutoSize = true;
            this.TwoAtk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TwoAtk.Location = new System.Drawing.Point(15, 17);
            this.TwoAtk.Name = "TwoAtk";
            this.TwoAtk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TwoAtk.Size = new System.Drawing.Size(47, 16);
            this.TwoAtk.TabIndex = 2;
            this.TwoAtk.TabStop = true;
            this.TwoAtk.Text = "공격";
            this.TwoAtk.UseVisualStyleBackColor = true;
            this.TwoAtk.CheckedChanged += new System.EventHandler(this.TwoAtk_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "방 && 방 == 차이 만큼 힐";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "공 < 방 == 방어";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "공 && 공 == 서로 피격";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "공 > 방 == 피격";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = " = 공격력 or 방어력 / 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "중앙 숫자 * 주사위 수";
            // 
            // textBox
            // 
            this.textBox.FormattingEnabled = true;
            this.textBox.ItemHeight = 12;
            this.textBox.Location = new System.Drawing.Point(155, 19);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(500, 148);
            this.textBox.TabIndex = 0;
            // 
            // enemyTimer
            // 
            this.enemyTimer.Enabled = true;
            this.enemyTimer.Interval = 10;
            this.enemyTimer.Tick += new System.EventHandler(this.GameEngine);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 501);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DoubleBufferPanel panel;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox textBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OneDfd;
        private System.Windows.Forms.RadioButton OneAtk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Mag;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton TwoDfd;
        private System.Windows.Forms.RadioButton TwoAtk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
    }
}

