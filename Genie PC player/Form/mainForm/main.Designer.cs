namespace Genie_PC_player
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.Profile = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button5 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.지니플레이어Beta01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.madeByMoartMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.버전Beta20171123ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.업데이트확인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Play = new System.Windows.Forms.ToolStripMenuItem();
            this.창모드로전환ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.lyrics = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(5, 246);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(330, 292);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "재생 할 노래가 없습니다.";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(58, 217);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(61, 20);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "로그인";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.TextChanged += new System.EventHandler(this.LoginButton_TextChanged);
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(84, 61);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(263, 34);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "▶";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(73, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "곡 가져오기";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(250, 98);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 26);
            this.button4.TabIndex = 9;
            this.button4.Text = "II";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // result
            // 
            this.result.BackColor = System.Drawing.Color.Transparent;
            this.result.Location = new System.Drawing.Point(58, 197);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(273, 19);
            this.result.TabIndex = 12;
            this.result.Text = "로그인 하세요.";
            this.result.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.result.Click += new System.EventHandler(this.result_Click);
            // 
            // Profile
            // 
            this.Profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Profile.Location = new System.Drawing.Point(11, 197);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(41, 40);
            this.Profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Profile.TabIndex = 14;
            this.Profile.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 454);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 21);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(93, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "00:00";
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(307, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "00:00";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(88, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "재생할 노래를 선택하세요!";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "128k",
            "192k",
            "320k",
            "FLAC"});
            this.comboBox1.Location = new System.Drawing.Point(14, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 20);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(11, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "음질:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 541);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "총 0곡";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.AutoSize = false;
            this.trackBar2.Location = new System.Drawing.Point(176, 543);
            this.trackBar2.Maximum = 20;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(85, 28);
            this.trackBar2.TabIndex = 26;
            this.trackBar2.Value = 10;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            this.trackBar2.VisibleChanged += new System.EventHandler(this.trackBar2_VisibleChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(125, 217);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 21);
            this.button5.TabIndex = 27;
            this.button5.Text = "동기화 재생목록\r\n불러오기";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.BalloonTipText = "지니 PC 플레이어";
            this.notifyIcon1.BalloonTipTitle = "지니 PC 플레이어";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "지니 PC 플레이어";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.지니플레이어Beta01ToolStripMenuItem,
            this.로그인ToolStripMenuItem,
            this.Play,
            this.창모드로전환ToolStripMenuItem,
            this.닫기ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 114);
            // 
            // 지니플레이어Beta01ToolStripMenuItem
            // 
            this.지니플레이어Beta01ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.madeByMoartMedia,
            this.버전Beta20171123ToolStripMenuItem,
            this.업데이트확인ToolStripMenuItem});
            this.지니플레이어Beta01ToolStripMenuItem.Name = "지니플레이어Beta01ToolStripMenuItem";
            this.지니플레이어Beta01ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.지니플레이어Beta01ToolStripMenuItem.Text = "비공식 지니 플레이어";
            // 
            // madeByMoartMedia
            // 
            this.madeByMoartMedia.Enabled = false;
            this.madeByMoartMedia.Name = "madeByMoartMedia";
            this.madeByMoartMedia.Size = new System.Drawing.Size(190, 22);
            this.madeByMoartMedia.Text = "Made By MoartMedia";
            // 
            // 버전Beta20171123ToolStripMenuItem
            // 
            this.버전Beta20171123ToolStripMenuItem.Enabled = false;
            this.버전Beta20171123ToolStripMenuItem.Name = "버전Beta20171123ToolStripMenuItem";
            this.버전Beta20171123ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.버전Beta20171123ToolStripMenuItem.Text = "버전: Beta.20171125";
            // 
            // 업데이트확인ToolStripMenuItem
            // 
            this.업데이트확인ToolStripMenuItem.Name = "업데이트확인ToolStripMenuItem";
            this.업데이트확인ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.업데이트확인ToolStripMenuItem.Text = "업데이트 확인";
            this.업데이트확인ToolStripMenuItem.Click += new System.EventHandler(this.업데이트확인ToolStripMenuItem_Click);
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            this.로그인ToolStripMenuItem.Click += new System.EventHandler(this.로그인ToolStripMenuItem_Click);
            // 
            // Play
            // 
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(190, 22);
            this.Play.Text = "재생/일시정지";
            this.Play.Click += new System.EventHandler(this.Play_Click);
            this.Play.Paint += new System.Windows.Forms.PaintEventHandler(this.Play_Paint);
            // 
            // 창모드로전환ToolStripMenuItem
            // 
            this.창모드로전환ToolStripMenuItem.Name = "창모드로전환ToolStripMenuItem";
            this.창모드로전환ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.창모드로전환ToolStripMenuItem.Text = "창모드로 전환";
            this.창모드로전환ToolStripMenuItem.Click += new System.EventHandler(this.창모드로전환ToolStripMenuItem_Click);
            // 
            // 닫기ToolStripMenuItem
            // 
            this.닫기ToolStripMenuItem.Name = "닫기ToolStripMenuItem";
            this.닫기ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.닫기ToolStripMenuItem.Text = "닫기";
            this.닫기ToolStripMenuItem.Click += new System.EventHandler(this.닫기ToolStripMenuItem_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(267, 544);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 23);
            this.button6.TabIndex = 28;
            this.button6.Text = "트레이로";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(167, 454);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(20, 26);
            this.button7.TabIndex = 29;
            this.button7.Text = "■";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 21);
            this.button2.TabIndex = 30;
            this.button2.Text = "실시간 지니\r\n차트 재생";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(295, 454);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 23);
            this.button9.TabIndex = 32;
            this.button9.Text = "검색";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(193, 455);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 33;
            this.textBox2.Text = "(업데이트 예정)";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button8.Location = new System.Drawing.Point(152, 540);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(24, 29);
            this.button8.TabIndex = 34;
            this.button8.Text = "🔉";
            this.button8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(276, 101);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(66, 23);
            this.button10.TabIndex = 35;
            this.button10.Text = "반복 없음";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // lyrics
            // 
            this.lyrics.Enabled = true;
            this.lyrics.Interval = 1;
            this.lyrics.Tick += new System.EventHandler(this.lyrics_Tick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.MintCream;
            this.label5.Location = new System.Drawing.Point(5, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(337, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(3, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(339, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 46);
            this.panel1.TabIndex = 39;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(97, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 16);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "접기/펼치기";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(345, 571);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "지니 PC 플레이어 Beta 0.1";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.PictureBox Profile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 지니플레이어Beta01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem madeByMoartMedia;
        private System.Windows.Forms.ToolStripMenuItem 창모드로전환ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 닫기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Play;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ToolStripMenuItem 버전Beta20171123ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 업데이트확인ToolStripMenuItem;
        private System.Windows.Forms.Timer lyrics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer2;
    }
}

