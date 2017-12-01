namespace Genie_PC_player
{
    partial class SongManager
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
            this.List = new System.Windows.Forms.TabControl();
            this.Chart = new System.Windows.Forms.TabPage();
            this.Add = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.AlbumPic = new System.Windows.Forms.PictureBox();
            this.Artist = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Livetop = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Search = new System.Windows.Forms.TabPage();
            this.kubun = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.List.SuspendLayout();
            this.Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Controls.Add(this.Chart);
            this.List.Controls.Add(this.Search);
            this.List.Location = new System.Drawing.Point(4, 12);
            this.List.Name = "List";
            this.List.SelectedIndex = 0;
            this.List.Size = new System.Drawing.Size(593, 377);
            this.List.TabIndex = 0;
            // 
            // Chart
            // 
            this.Chart.BackColor = System.Drawing.SystemColors.GrayText;
            this.Chart.Controls.Add(this.Add);
            this.Chart.Controls.Add(this.Play);
            this.Chart.Controls.Add(this.AlbumPic);
            this.Chart.Controls.Add(this.Artist);
            this.Chart.Controls.Add(this.Title);
            this.Chart.Controls.Add(this.button1);
            this.Chart.Controls.Add(this.tabControl1);
            this.Chart.Location = new System.Drawing.Point(4, 22);
            this.Chart.Name = "Chart";
            this.Chart.Padding = new System.Windows.Forms.Padding(3);
            this.Chart.Size = new System.Drawing.Size(585, 351);
            this.Chart.TabIndex = 0;
            this.Chart.Text = "지니차트";
            this.Chart.Click += new System.EventHandler(this.Chart_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(346, 284);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(84, 23);
            this.Add.TabIndex = 5;
            this.Add.Text = "추가";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(444, 284);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(86, 23);
            this.Play.TabIndex = 4;
            this.Play.Text = "듣기";
            this.Play.UseVisualStyleBackColor = true;
            // 
            // AlbumPic
            // 
            this.AlbumPic.Location = new System.Drawing.Point(346, 94);
            this.AlbumPic.Name = "AlbumPic";
            this.AlbumPic.Size = new System.Drawing.Size(184, 184);
            this.AlbumPic.TabIndex = 1;
            this.AlbumPic.TabStop = false;
            // 
            // Artist
            // 
            this.Artist.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Artist.ForeColor = System.Drawing.Color.White;
            this.Artist.Location = new System.Drawing.Point(302, 71);
            this.Artist.Name = "Artist";
            this.Artist.Size = new System.Drawing.Size(283, 20);
            this.Artist.TabIndex = 3;
            this.Artist.Text = "피카부 (Peek-A-Boo)";
            this.Artist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(301, 43);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(281, 28);
            this.Title.TabIndex = 2;
            this.Title.Text = "비도 오고 그래서 (Feat. 신용재)";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "전체 듣기";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(295, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Livetop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 260);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "실시간";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Livetop
            // 
            this.Livetop.FormattingEnabled = true;
            this.Livetop.Location = new System.Drawing.Point(2, 1);
            this.Livetop.Name = "Livetop";
            this.Livetop.Size = new System.Drawing.Size(284, 260);
            this.Livetop.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(287, 260);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "주간";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(287, 260);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "월간";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.DimGray;
            this.Search.Controls.Add(this.kubun);
            this.Search.Controls.Add(this.textBox1);
            this.Search.Controls.Add(this.button4);
            this.Search.Controls.Add(this.listBox1);
            this.Search.Controls.Add(this.button2);
            this.Search.Controls.Add(this.button3);
            this.Search.Controls.Add(this.pictureBox1);
            this.Search.Controls.Add(this.label1);
            this.Search.Controls.Add(this.label2);
            this.Search.Location = new System.Drawing.Point(4, 22);
            this.Search.Name = "Search";
            this.Search.Padding = new System.Windows.Forms.Padding(3);
            this.Search.Size = new System.Drawing.Size(585, 351);
            this.Search.TabIndex = 1;
            this.Search.Text = "검색";
            // 
            // kubun
            // 
            this.kubun.AllowDrop = true;
            this.kubun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kubun.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kubun.FormattingEnabled = true;
            this.kubun.Items.AddRange(new object[] {
            "가수별",
            "곡별",
            "엘범별"});
            this.kubun.Location = new System.Drawing.Point(20, 57);
            this.kubun.Name = "kubun";
            this.kubun.Size = new System.Drawing.Size(68, 23);
            this.kubun.TabIndex = 16;
            this.kubun.SelectedIndexChanged += new System.EventHandler(this.kubun_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(94, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 21);
            this.textBox1.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(245, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "검색";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "안녕!",
            "안녕하시유!"});
            this.listBox1.Location = new System.Drawing.Point(20, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(272, 244);
            this.listBox1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "추가";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(441, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "듣기";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(343, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 184);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(299, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "피카부 (Peek-A-Boo)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(298, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "비도 오고 그래서 (Feat. 신용재)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SongManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 390);
            this.Controls.Add(this.List);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SongManager";
            this.Text = "SongManager";
            this.List.ResumeLayout(false);
            this.Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl List;
        private System.Windows.Forms.TabPage Chart;
        private System.Windows.Forms.PictureBox AlbumPic;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox Livetop;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage Search;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label Artist;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox kubun;
    }
}