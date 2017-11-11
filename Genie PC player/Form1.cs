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
        private Thread lyrics;
        public Form1()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Profile.Width, Profile.Height);
            Profile.Region = new Region(path);
        }

        private static AuthData LoginInfo;
        private static CurrentSongInfo Songinfo = new CurrentSongInfo();

        private Boolean Login(string id, string pw)
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("uxd=" + id);
            dataParams.Append("&uxx=" + pw);
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("https://app.genie.co.kr/member/j_Member_Login.json?");
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
            if (!checkResult(strResult)) return false;
            JObject obj = JObject.Parse(strResult);
            JObject Result = JObject.Parse(obj["Result"].ToString());
            AuthData authdata = new AuthData();
            JObject DATA = JObject.Parse(obj["DATA0"].ToString());
            authdata.Sex = DATA["MemSex"].ToString();
            authdata.Uno = DATA["MemUno"].ToString();
            authdata.Age = DATA["MemAge"].ToString();
            authdata.isAdult = DATA["MemAdult"].ToString();
            authdata.token = DATA["MemToken"].ToString();
            authdata.conf = DATA["MemConf"].ToString();
            authdata.Prod = DATA["MemProd"].ToString();
            authdata.corp = DATA["MemCorp"].ToString();
            authdata.Name = DATA["MemNick"].ToString();
            string imagelink = this.GetInfoString(DATA, "MemImg");
            WebClient client = new WebClient();
            byte[] buffer = client.DownloadData(new Uri(imagelink));
            Stream stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            authdata.img = Image.FromStream(stream);
            Profile.Image = authdata.img;
            LoginInfo = authdata;
            return true;
        }
        private string RetCode = "";
        private string RetMsg = "";
        private string RetType = "";
        private string URL = "";
        private string Page = "";
        private string TotPage = "";
        private string TotCount = "";
        public bool checkResult(string response)
        {
            try
            {
                if (response == null)
                    return false;
                JObject jobject = JObject.Parse(response);
                if (jobject["Result"] == null)
                    return false;
                this.RetCode = this.GetInfoString(jobject["Result"], "RetCode");
                this.RetMsg = this.GetInfoString(jobject["Result"], "RetMsg");
                this.RetType = this.GetInfoString(jobject["Result"], "RetType");
                this.URL = this.GetInfoString(jobject["Result"], "URL");
                if (this.RetCode != "0")
                    return false;
                if (jobject["PageInfo"] != null)
                {
                    this.Page = this.GetInfoString(jobject["PageInfo"], "Page");
                    this.TotPage = this.GetInfoString(jobject["PageInfo"], "TotPage");
                    this.TotCount = this.GetInfoString(jobject["PageInfo"], "TotCount");
                }
            }
            catch (JsonReaderException ex)
            {
                return false;
            }
            return true;
        }
        private string GetInfoString(JToken SongInfo, string strKey)
        {
            if (SongInfo == null)
                return "";
            string str = "";
            if (SongInfo[(object)strKey] != null)
                str = WebUtility.UrlDecode(SongInfo[(object)strKey].ToString());
            return str;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || PW.Text == "")
            {
                result.Text = "ID/PW 확인 (비어있음)";
                return;
            }
            Login();
        }
        private async void Login()
        {
            if (LoginInfo == null)
            {
                LoginButton.Enabled = false;
                ID.Enabled = false;
                PW.Enabled = false;
                result.Text = "로그인 중입니다...";
                var login = Task<Boolean>.Run(() => Login(ID.Text, PW.Text));
                Boolean issuccess = await login;
                if (issuccess)
                {
                    string a = LoginInfo.Name;
                    result.Text = a + "님 환영합니다!";
                    LoginButton.Enabled = true;
                    LoginButton.Text = "로그아웃";
                    return;
                }
                else
                {
                    result.Text = "실패: " + RetMsg + "(" + RetCode + ")";
                    LoginButton.Enabled = true;
                    ID.Enabled = true;
                    PW.Enabled = true;
                }
            }
            else
            {
                LoginInfo = null;
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
            var GetSongList = Task<List<Song>>.Run(() => LoadSong(textBox1.Text));
            Boolean song = await GetSongList;
            if (!song) return;
            Song s = Song.songs.First();
            label1.Text = s.Name + " (" + s.Artist + ")";
            Refresh_ListBox();
        }

        private Boolean LoadSong(string songid)
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("xgnm=" + songid);
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("http://www.genie.co.kr/player/jPlayerSongList.json?");
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
            //if (!checkResult(strResult)) return false;
            JObject obj = JObject.Parse(strResult);
            Song authdata = new Song();
            JArray songlist = JArray.Parse(obj["DataSet"]["DATA"].ToString());
            foreach (JObject songobj in songlist)
            {
                Song song = new Song();
                song.JObjectToSong(songobj, false);
                Song.songs.Add(song);
            }
            return true;
        }
        //망할 실시간 가사 부분 불러오기
        /* private Boolean LoadLycis(Song song)
         {
             StringBuilder dataParams = new StringBuilder();
             dataParams.Append("path=a");
             dataParams.Append("&songid=" + song.Song_ID);
             byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
             WebRequest re = WebRequest.Create("http://dn.genie.co.kr/app/purchase/get_msl.asp?");
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
             JObject obj = JObject.Parse(strResult);
             Songinfo.liveLycis = JsonConvert.DeserializeObject<Dictionary<string, string>>(obj.ToString());
             return true;
         }*/
        private Boolean LoadInfo(Song song, string bit)
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("xgnm=" + song.Song_ID);
            dataParams.Append("&cdm=" + "http");
            if (LoginInfo != null)
            {
                dataParams.Append("&uxnm=" + LoginInfo.Uno);
                dataParams.Append("&uxtk=" + LoginInfo.token);
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
            if (!checkResult(strResult)) return false;
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
            label8.Text = "총 " + temp.Count()+"곡";
            listBox1.DataSource = temp;
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
        bool isAction = true;
        private async void SongLoad(Song song)
        {
            if (AudioSystem.Playing.song_ID == song.Song_ID) return;
            string bit = comboBox1.Text.Substring(0, 3);
            var Prepare = Task<Boolean>.Run(() => LoadInfo(song, bit));
            Boolean s = await Prepare;
            if (!s) return;
            listBox1.Enabled = false;
            if (AudioSystem.Playing.waveout != null)
            {
                AudioSystem.Playing.Dispose();
            }
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
            //이용권 체크 드러갑니다.
            int iProdType;
            string strStreamLogData;
            string strStreamLogData2;
            if (Songinfo.STREAM_LICENSE_YN == "Y" || Songinfo.FULLSTREAMYN=="Y"||(Songinfo.MRSTM_YN == "Y" && int.Parse(Songinfo.MRSTM_NUM) > 0))
            {
                isAction = true;
            }
            else
            {
                isAction = false;
            }
            iProdType = 0;
            strStreamLogData = Songinfo.LOG_PARAM;

            if (Songinfo.STREAM_LICENSE_YN == "Y")
            {
                if (Songinfo.DPMRSTM_YN == "Y")
                {
                    iProdType = 5; //알뜰음악감상
                }
                else
                {
                    iProdType = 1; //일반
                }
            } else if ((Songinfo.FULLSTERAMSVCYN == "Y") && (int.Parse(Songinfo.FULLSTREAMCNT) > 0) && (Songinfo.FULLSTREAMYN == "Y"))
            {
                iProdType = 2; //풀트랙
            }
            else if((Songinfo.MRSTM_YN=="Y")&& (int.Parse(Songinfo.MRSTM_NUM) > 0))
            {
                iProdType = 3; //PPS
                strStreamLogData2 = Songinfo.ITEM_PPS_CNT;
            }
            //오디오 제생
            AudioSystem musicSystem = new AudioSystem(song.Song_ID);
            musicSystem.Dispose();
            string decode3 = HttpUtility.UrlDecode(Songinfo.StreamingURL);
            var PrepareMusic = Task.Run(() => musicSystem.init(decode3));
            await PrepareMusic;
            AudioSystem.Playing = musicSystem;
            listBox1.Enabled = true;
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

            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (AudioSystem.Playing != null)
            {
                AudioSystem.Playing.wavestream.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void PW_TextChanged(object sender, EventArgs e)
        {

        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
