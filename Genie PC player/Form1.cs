using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Timers;
using System.Windows.Threading;
using System.Threading;

namespace Genie_PC_player
{
    public partial class Form1 : Form
    {
        private Process process;
        public Form1()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Profile.Width, Profile.Height);
            Profile.Region = new Region(path);
            process = new Process();
        }
        //이벤트
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || PW.Text == "")
            {
                result.Text = "ID/PW 확인 (비어있음)";
                return;
            }
            Login();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AudioSystem.Playing.Stop();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AudioSystem.Playing.Play();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (AudioSystem.Playing != null)
            {
                TimeSpan CurrentTime = AudioSystem.Playing.getCurrentTime();
                TimeSpan TotalTime = AudioSystem.Playing.getTotalTime();
                trackBar1.Maximum = (int)TotalTime.TotalSeconds;
                trackBar1.Value = (int)CurrentTime.TotalSeconds;
                label3.Text = TotalTime.ToString("mm\\:ss");
                label2.Text = CurrentTime.ToString("mm\\:ss");
                if (AudioSystem.Playing.waveout != null)
                {
                    if (TotalTime.TotalMilliseconds <= CurrentTime.TotalMilliseconds)
                    {
                        trackBar1.Value = 0;
                        AudioSystem.Playing.wavestream.CurrentTime = TimeSpan.Zero;
                        AudioSystem.Playing.waveout.Play();
                    }
                }

            }

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (AudioSystem.Playing != null)
            {
                AudioSystem.Playing.wavestream.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RemoveDouble();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadSonginfo();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = Song.songs[listBox1.SelectedIndex];
            if (s.Streaming == "Y")
            {
                label1.Text = s.Name;
                label4.Text = s.Artist;
                SongLoad(s);
            }
        }

        //기능
        private static CurrentSongInfo Songinfo = new CurrentSongInfo();
        private async void Login()
        {
            if (AuthData.LoginInfo == null)
            {
                LoginButton.Enabled = false;
                ID.Enabled = false;
                PW.Enabled = false;
                result.Text = "로그인 중입니다...";
                var login = Task<Boolean>.Run(() => process.Login(ID.Text, PW.Text));
                Boolean issuccess = await login;
                if (issuccess)
                {
                    string a = AuthData.LoginInfo.Name;
                    result.Text = a + "님 환영합니다!";
                    LoginButton.Enabled = true;
                    Profile.Image = AuthData.LoginInfo.img;
                    LoginButton.Text = "로그아웃";
                    return;
                }
                else
                {
                    result.Text = "실패: " + process.RetMsg + "(" + process.RetCode + ")";
                    LoginButton.Enabled = true;
                    ID.Enabled = true;
                    PW.Enabled = true;
                }
            }
            else
            {
                AuthData.LoginInfo = null;
                LoginButton.Enabled = true;
                LoginButton.Text = "로그인";
                ID.Enabled = true;
                ID.Text = "";
                PW.Enabled = true;
                PW.Text = "";
                Profile.Image = null;
                result.Text = "로그인 하세요.";

            }
        }
        private async void LoadSonginfo()
        {
            var GetSongList = Task<bool>.Run(() => process.LoadSong(textBox1.Text));
            bool song = await GetSongList;
            if (!song) return;
            Song s = Song.songs.First();
            label1.Text = s.Name + " (" + s.Artist + ")";
            Refresh_ListBox();
        }
        private Boolean LoadInfo(Song song, string bit)
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("xgnm=" + song.Song_ID);
            dataParams.Append("&cdm=" + "http");
            if (AuthData.LoginInfo != null)
            {
                dataParams.Append("&uxnm=" + AuthData.LoginInfo.Uno);
                dataParams.Append("&uxtk=" + AuthData.LoginInfo.token);
            }
            dataParams.Append("&bit=" + bit);
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("http://www.genie.co.kr/player/playStmInfo.json?");
            re.Method = "POST";
            re.ContentType = "application/x-www-form-urlencoded";
            re.ContentLength = byteDataParams.Length;
            Stream Datastpar = re.GetRequestStream();
            Datastpar.Write(byteDataParams, 0, byteDataParams.Length);
            Datastpar.Close();
            HttpWebResponse res = (HttpWebResponse)re.GetResponse();
            Stream ReadData = res.GetResponseStream();
            StreamReader reData = new StreamReader(ReadData, Encoding.UTF8);
            string strResult = reData.ReadToEnd();
            if (!process.checkResult(strResult)) return false;
            JObject obj = JObject.Parse(strResult);
            JObject DATA = JObject.Parse(obj["DATA0"].ToString());
            CurrentSongInfo info = new CurrentSongInfo();
            info.JObjectToData(DATA, song);
            Songinfo = info;
            return true;
        }
        public void Refresh_ListBox()
        {
            List<string> temp = new List<string>();
            foreach (Song s in Song.songs)
            {
                temp.Add(s.Name + " / " + s.Artist);
            }
            label8.Text = "총 " + temp.Count() + "곡";
            listBox1.DataSource = temp;
        }
        public async void RemoveDouble()
        {
            List<string> temp = new List<string>();
            for (int ii = 0; ii < Song.songs.Count; ii++)
            {
                if (!temp.Contains(Song.songs[ii].Song_ID)) {
                    temp.Add(Song.songs[ii].Song_ID);
                }
            }
            string temp2 = "";
            foreach (string f in temp)
            {
                temp2 = temp2 + f + ";";
            }
            Song.songs.Clear();
            var list = Task.Run(() => process.LoadSong(temp2));
            await list;
            Refresh_ListBox();
        }
        private async void SongLoad(Song song)
        {
            //동일 시 리턴
            if (AudioSystem.Playing.song_ID == song.Song_ID) return;

            //음악 스트리밍 정보를 불러옵니다.
            string bit = comboBox1.Text.Substring(0, comboBox1.Text.Length-1);
            var Prepare = Task<Boolean>.Run(() => LoadInfo(song, bit));
            Boolean s = await Prepare;
            if (!s) return;
            listBox1.Enabled = false;

            //AudioSystem 초기화.
            if (AudioSystem.Playing.waveout != null)
            {
                AudioSystem.Playing.Dispose();
            }

            //엘범 사진 로드
            WebClient client = new WebClient();
            string decode = HttpUtility.UrlDecode(Songinfo.image);
            string http = "http:" + decode;
            byte[] buffer = client.DownloadData(new Uri(http));
            Stream stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            pictureBox1.Image = Image.FromStream(stream);

            //망할 실시간 가사 부분 주석 처리
            /* var Lycis = Task.Run(() => LoadLycis(song));
             await Lycis;*/

            //오디오 재생
            AudioSystem musicSystem = new AudioSystem(song.Song_ID);
            musicSystem.Dispose(); //초기화
            float volume= (float)trackBar2.Value / 100.0f;
            var PrepareMusic = Task.Run(() => musicSystem.init(HttpUtility.UrlDecode(Songinfo.StreamingURL), volume, Songinfo.isflac));
            await PrepareMusic;
            AudioSystem.Playing = musicSystem;

            listBox1.Enabled = true;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float i = (float)trackBar2.Value / 100.0f;
            AudioSystem.Playing.volumeProvider.Volume = i;
        }
    }
}
