using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genie_PC_player
{
    public partial class Login : Form {
        Button button2;

        public Login(Button btn)
        {
            InitializeComponent();
            button2 = btn;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || PW.Text == "")
            {
                Result.Text = "ID/PW 확인 (비어있음)";
                return;
            }
            Loginproc();
        }
        private async void Loginproc()
        {
            submit.Enabled = false;
            ID.Enabled = false;
            PW.Enabled = false;
            Result.Text = "로그인 중...";
            Process Login=new Process();
            var prologin = Task<Boolean>.Run(() => Login.Login(ID.Text, PW.Text));
            Boolean issuccess = await prologin;
            if (issuccess)
            {
                submit.Enabled = true;
                ID.Enabled = true;
                PW.Enabled = true;
                button2.Text = "로그아웃";
                this.Close(); return;
            }
            else
            {
                Result.Text = Login.RetMsg + "(" + Login.RetCode + ")";
                submit.Enabled = true;
                ID.Enabled = true;
                PW.Enabled = true;
            }
        }
    }
}
