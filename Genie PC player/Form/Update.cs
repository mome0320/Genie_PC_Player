using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genie_PC_player
{
    public partial class Loading : Form
    {

        delegate void TestDelegate(string msg);
        delegate void TestDelegate2();
        public static bool isUpdated;
        public Loading()
        {
            InitializeComponent();
            System.Threading.Thread thread = new System.Threading.Thread(Setup);
            thread.Start();
        }
        private void formClose()
        {
            this.Close();
        }
        private void Setup()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()){MessageBox.Show("인터넷 연결이 원활하지 않습니다." + Environment.NewLine + "네트워크 상태를 확인해주세요!"); isUpdated = false; this.Invoke(new TestDelegate2(formClose)); return; }
            System.Threading.Thread.Sleep(1500);
                string Version = "Beta.20171125";
                var client = new HttpClient();
                var response = client.GetAsync("http://moartmedia.github.io/Genie/player/check.html").Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                 MessageBox.Show("인터넷 연결이 원활하지 않습니다."+ Environment.NewLine + "네트워크 상태를 확인해주세요!");
            }
            var html = response.Content.ReadAsStringAsync().Result;
                string[] lines = html.Split(new[] { "\r\n", "\r", "\n", Environment.NewLine }, StringSplitOptions.None);
                string ver = "null";
                string date = "null";
                string notice = "";
                string URL = "";
                foreach (string s in lines)
                {
                    if (s.StartsWith("Version: "))
                    {
                        ver = (s.Replace("Version: ", ""));
                    }
                    else if (s.StartsWith("LastUpdate: "))
                    {
                        date = (s.Replace("LastUpdate: ", ""));
                    }
                    else if (s.StartsWith("UpdateText: "))
                    {
                        notice = (s.Replace("UpdateText: ", ""));
                    }
                    else if (s.StartsWith("UpdateURL: "))
                    {
                        URL = (s.Replace("UpdateURL: ", ""));
                    }
                }
                if (!ver.Equals(Version))
                {
                    isUpdated = false;
                    MessageBox.Show("새로운 업데이트가 존재합니다. (" + ver + ")" + Environment.NewLine + "확인 버튼을 눌르면 설치 창으로 이동됩니다." + Environment.NewLine + date + Environment.NewLine + notice, "업데이트 안내");
                    System.Diagnostics.Process.Start(URL);
                    System.Threading.Thread.Sleep(500);
            }
            else
            {
                isUpdated = true;
            }
                this.Invoke(new TestDelegate2(formClose));
            }
    }
}
