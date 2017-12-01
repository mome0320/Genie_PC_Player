namespace Genie_PC_player
{
    partial class Login
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
            this.ID = new System.Windows.Forms.TextBox();
            this.PW = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(67, 42);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(100, 21);
            this.ID.TabIndex = 0;
            this.ID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PW
            // 
            this.PW.Location = new System.Drawing.Point(67, 69);
            this.PW.Name = "PW";
            this.PW.Size = new System.Drawing.Size(100, 21);
            this.PW.TabIndex = 1;
            this.PW.UseSystemPasswordChar = true;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(173, 42);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(56, 48);
            this.submit.TabIndex = 2;
            this.submit.Text = "로그인";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(0, 96);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(284, 42);
            this.Result.TabIndex = 3;
            this.Result.Text = "로그인 하세요!";
            this.Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(67, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "지니 로그인";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 147);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.PW);
            this.Controls.Add(this.ID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox PW;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label label2;
    }
}