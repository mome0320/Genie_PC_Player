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
using Genie_PC_player.Utils;

namespace Genie_PC_player
{
    public partial class main : Form
    {
        private Process process;
        private bool isplayed = false;
        int songplayingindex;
        private Image noimage;
        private Image noAlbum;
        public enum playmode { Normal, All, One };
        public playmode selectmode;
        public main()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Profile.Width, Profile.Height);
            Profile.Region = new Region(path);
            process = new Process();
            selectmode = playmode.Normal;
            WebClient client = new WebClient();
            byte[] buffer = client.DownloadData(new Uri("http://image.genie.co.kr/imageg/app/profile/ng_noimg_profile1.png"));
            using (Stream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                noimage = Image.FromStream(stream);
            }
            Profile.Image = noimage;
            client = new WebClient();
            buffer = client.DownloadData(new Uri("http://image.genie.co.kr/imageg/web/common/blank_200.gif"));
            using (Stream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                noAlbum = Image.FromStream(stream);
            }
            pictureBox1.Image = noAlbum;
            comboBox1.SelectedIndex = 2;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginButton.Text == "로그아웃")
            {
                if (AudioSystem.Playing.song_ID != "")
                {
                    AudioSystem.Playing.Stop();
                    AudioSystem.Playing.waveout.Dispose();
                    AudioSystem.Playing.waveout = null;
                    AudioSystem.Playing.Dispose();
                    AudioSystem.Playing = new AudioSystem();
                    CurrentSongInfo.Songinfo = null;
                    pictureBox1.Image = noAlbum;
                    label1.Text = "재생 할 노래가 없습니다.";
                    label4.Text = "재생할 노래를 선택하세요!";
                }
                AuthData.LoginInfo = null;
                LoginButton.Enabled = true;
                LoginButton.Text = "로그인";
                Profile.Image = noimage;
                button5.Visible = false;
                result.Text = "로그인 하세요.";
            }
            else
            {
                Login l = new Login(LoginButton);
                l.ShowDialog();
            }
        }
        /*//이벤트
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || PW.Text == "")
            {
                result.Text = "ID/PW 확인 (비어있음)";
                return;
            }
            Login();
        }*/
        private void button4_Click(object sender, EventArgs e)
        {
            if (AudioSystem.Playing.waveout == null) return;
            AudioSystem.Playing.Pause();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (AudioSystem.Playing.waveout == null) return;
            AudioSystem.Playing.Play();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (AudioSystem.Playing.waveout == null && AudioSystem.Playing.wavestream == null) return;
            AudioSystem.Playing.Stop();
            trackBar1.Value = 0;
            AudioSystem.Playing.wavestream.CurrentTime = TimeSpan.Zero;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (AudioSystem.Playing != null)
            {
                TimeSpan CurrentTime = AudioSystem.Playing.getCurrentTime();
                TimeSpan TotalTime = AudioSystem.Playing.getTotalTime();
                if (!AudioSystem.Playing.isFull)
                    trackBar1.Maximum = 60;
                else
                    trackBar1.Maximum = (int)TotalTime.TotalSeconds;
                trackBar1.Value = (int)CurrentTime.TotalSeconds;
                if (!AudioSystem.Playing.isFull)
                {
                    label3.Text = "01:00";
                } else
                    label3.Text = TotalTime.ToString("mm\\:ss");
                label2.Text = CurrentTime.ToString("mm\\:ss");
                if (AudioSystem.Playing.waveout != null && TotalTime != TimeSpan.Zero)
                {
                    if (CurrentTime.TotalMinutes >= 1)
                    {
                        if (!AudioSystem.Playing.isFull)
                        {
                            nextsong();
                        }
                        else if (!AudioSystem.Playing.islogged)
                        {
                            System.Diagnostics.Debug.WriteLine("전산 처리 인식되었습니다.");
                            process.LogGenie();//전산
                        }
                    }
                    /* else if(CurrentTime.TotalSeconds >=3&&CurrentSongInfo.Songinfo.islogin == "Y"&&!AudioSystem.Playing.issns)
                     {
                         process.sns();
                     }*/
                    if (TotalTime.TotalMilliseconds <= CurrentTime.TotalMilliseconds)
                    {
                        if (CurrentSongInfo.Songinfo.islogin == "Y" && !AudioSystem.Playing.isseek) { System.Diagnostics.Debug.WriteLine("풀로그 전송중입니다.."); process.sendFullLog(); }
                        nextsong();
                    }
                }


            }

        }
        private void nextsong()
        {
            AudioSystem.Playing.waveout.Stop();
            AudioSystem.Playing.waveout.Dispose();
            AudioSystem.Playing.waveout = null;
            songplayingindex = songplayingindex + 1;
            Song s = null;
            if (selectmode.Equals(playmode.All))
            {
                if (Song.songs.Count > songplayingindex)
                {
                    s = Song.songs[songplayingindex];
                    isplayed = true;
                    listBox1.SelectedIndex = songplayingindex;
                }
                else
                {
                    s = Song.songs[0];
                    songplayingindex = 0;
                    isplayed = true;
                    listBox1.SelectedIndex = 0;
                }
            }
            else if (selectmode.Equals(playmode.One))
            {
                s = CurrentSongInfo.Songinfo.Song;
            } else if (selectmode.Equals(playmode.Normal))
            {
                if (Song.songs.Count > songplayingindex)
                {
                    s = Song.songs[songplayingindex];
                    isplayed = true;
                    listBox1.SelectedIndex = songplayingindex;
                }
                else
                {
                    AudioSystem.Playing.Dispose();
                    AudioSystem.Playing = new AudioSystem();
                    CurrentSongInfo.Songinfo = null;
                    pictureBox1.Image = noAlbum;
                    label1.Text = "재생 할 노래가 없습니다.";
                    label4.Text = "재생할 노래를 선택하세요!";
                }
            }
            if (s == null) return;
            if (s.Song_ID == AudioSystem.Playing.song_ID)
            { SongLoad(s); return; }
            if (s.Streaming == "Y")
            {
                label1.Text = s.Name.Replace("&", "&&");
                label4.Text = s.Artist.Replace("&", "&&");
                SongLoad(s);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (AudioSystem.Playing.wavestream != null)
            {
                AudioSystem.Playing.isseek = true;
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
            if (isplayed) { isplayed = false; return; }
            songplayingindex = listBox1.SelectedIndex;
            var s = Song.songs[listBox1.SelectedIndex];
            if (s.Streaming == "Y")
            {
                label1.Text = s.Name.Replace("&", "&&");
                label4.Text = s.Artist.Replace("&", "&&");
                SongLoad(s);
            }
        }

        //기능
        private async void LoadSonginfo()
        {
            // var GetSongList = Task<bool>.Run(() => process.LoadSong(textBox1.Text));
            bool song = await process.LoadSongAsync(textBox1.Text);
            if (!song) return;
            Song s = Song.songs.First();
            label1.Text = s.Name + " (" + s.Artist + ")";
            Refresh_ListBox();
        }
        private async Task<bool> LoadInfoAsync(Song song, string bit)
        {
            Uri resourceuri;
            if (!Uri.TryCreate("http://www.genie.co.kr/player/playStmInfo.json?", UriKind.Absolute, out resourceuri)) return false;
            HttpHelper.InitPostData();
            HttpHelper.setPostData("xgnm", song.Song_ID);
            HttpHelper.setPostData("cdm", "http");
            if (AuthData.LoginInfo != null)
            {
                HttpHelper.setPostData("uxnm", AuthData.LoginInfo.Uno);
                HttpHelper.setPostData("uxtk", AuthData.LoginInfo.token);
            }
            HttpHelper.setPostData("bit", bit);
            string Output = await HttpHelper.PostAsync(resourceuri);
            if (string.IsNullOrEmpty(Output)) return false;
            if (!process.checkResult(Output)) return false;
            JObject obj = JObject.Parse(Output);
            JObject DATA = JObject.Parse(obj["DATA0"].ToString());
            CurrentSongInfo info = new CurrentSongInfo();
            info.JObjectToData(DATA, song);
            CurrentSongInfo.Songinfo = info;
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
            //var list = Task.Run(() => process.LoadSong(temp2));
            await process.LoadSongAsync(temp2);
            Refresh_ListBox();
        }
        private void Labelbold(Label a)
        {
            a.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            a.ForeColor = System.Drawing.Color.MintCream;
        }
        private void Labelnormal(Label a)
        {
            a.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            a.ForeColor = System.Drawing.Color.DimGray;
        }
        private async void SongLoad(Song song)
        {
            lyrics.Enabled = false;
            label5.Text = ""; label6.Text = "";
            Labelbold(label5);
            Labelnormal(label6);
            /*//동일 시 리턴
            if (AudioSystem.Playing.song_ID == song.Song_ID) return;*/
            //음악 스트리밍 정보를 불러옵니다.
            listBox1.Enabled = false;
            string bit = "";
            if (comboBox1.Text.Equals("FLAC")) bit = "1000"; else
                bit = comboBox1.Text.Substring(0, comboBox1.Text.Length - 1);
            label5.Text = "음악 정보 불러오는 중..";
            System.Diagnostics.Debug.WriteLine("음악 스트리밍 정보 불러오는 중입니다..");
            //var Prepare = Task<Boolean>.Run(() => LoadInfo(song, bit));
            Boolean s = await LoadInfoAsync(song, bit);
            if (!s) { System.Diagnostics.Debug.WriteLine("음악 스트리밍: 실패"); return; }
            System.Diagnostics.Debug.WriteLine("음악 스트리밍: 성공");
            timer1.Enabled = false;
            label5.Text = "가사 불러오는 중입니다..";
            var Lyris = Task.Run(() => Lm.GetLyricsAsync(song.Song_ID));
            await Lyris;
            System.Diagnostics.Debug.WriteLine("AudioSystem 초기화중입니다...");
            label5.Text = "오디오 초기화 중..";
            //AudioSystem 초기화.
            if (AudioSystem.Playing != null)
            {
                AudioSystem.Playing.Dispose();
            }
            System.Diagnostics.Debug.WriteLine("AudioSystem 초기화 완료.");

            //엘범 사진 로드
            label5.Text = "엘범 사진 준비중..";
            System.Diagnostics.Debug.WriteLine("엘범 사진 로드중입니다..");
            WebClient client = new WebClient();
            string decode = HttpUtility.UrlDecode(CurrentSongInfo.Songinfo.image);
            string http = "http:" + decode;
            byte[] buffer = client.DownloadData(new Uri(http));
            using (Stream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                pictureBox1.Image = Image.FromStream(stream);
            }
            System.Diagnostics.Debug.WriteLine("엘범 사진 로드완료..");
            //망할 실시간 가사 부분 주석 처리
            /* var Lycis = Task.Run(() => LoadLycis(song));
             await Lycis;*/
            if (notifyIcon1.Visible)
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = "현재 곡 : " + song.Name + " / " + song.Artist;
                notifyIcon1.ShowBalloonTip(2);
                if (AuthData.LoginInfo == null) { Thread.Sleep(3000); notifyIcon1.BalloonTipText = "비로그인 회원은 1분 미리 듣기만 가능합니다."; notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning; notifyIcon1.ShowBalloonTip(5); }
            }
            bool isFull = true;
            if (!(process.getProdType() == 1 || process.getProdType() == 5))
                isFull = false;
            //오디오 재생
            label5.Text = "재생 준비중..";
            System.Diagnostics.Debug.WriteLine("재생 시스템 기동중!");
            AudioSystem.Playing = new AudioSystem(song.Song_ID, isFull);
            //musicSystem.Dispose(); //초기화
            float volume = (float)trackBar2.Value / (float)trackBar2.Maximum;
            System.Diagnostics.Debug.WriteLine("음악 로딩중입니다..");
            label5.Text = "음악 준비중..";
            var PrepareMusic = Task.Run(() => AudioSystem.Playing.init(HttpUtility.UrlDecode(CurrentSongInfo.Songinfo.StreamingURL), volume, CurrentSongInfo.Songinfo.isflac));
            await PrepareMusic;
            System.Diagnostics.Debug.WriteLine("모든 작업 완료!");
            label5.Text = "";
            lyrics.Enabled = true;
            listBox1.Enabled = true;
            timer1.Enabled = true;
            if (!isFull)
                MessageBox.Show("이 프로그램은 무제한 상품만 가능합니다.\r추가 상품 이용자는 다음 버전 나올 때 까지 기다려주세요!\r그로 인해 1분 재생이 됩니다.", "이용권 제한 안내", MessageBoxButtons.OK);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetSync();
        }
        private async void GetSync()
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("unm=" + AuthData.LoginInfo.Uno);
            dataParams.Append("&uxtk=" + AuthData.LoginInfo.token);
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("https://app.genie.co.kr/player/j_PlayListSyncList.json?");
            re.Method = "POST";
            re.ContentType = "application/x-www-form-urlencoded";
            re.ContentLength = byteDataParams.Length;
            Stream Datastpar = re.GetRequestStream();
            Datastpar.Write(byteDataParams, 0, byteDataParams.Length);
            Datastpar.Close();
            Datastpar.Dispose();
            HttpWebResponse res = (HttpWebResponse)re.GetResponse();
            Stream ReadData = res.GetResponseStream();
            StreamReader reData = new StreamReader(ReadData, Encoding.UTF8);
            string strResult = reData.ReadToEnd();
            if (!process.checkResult(strResult)) return;
            Song.songs.Clear();
            JObject obj = JObject.Parse(strResult);
            JArray songlist = JArray.Parse(obj["DATA1"]["DATA"].ToString());
            foreach (JObject songobj in songlist)
            {
                Song song = new Song();
                song.JObjectToSongSync(songobj, false);
                Song.songs.Add(song);
            }
            Refresh_ListBox();
            return;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            this.ShowInTaskbar = false;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            notifyIcon1.BalloonTipTitle = "지니 PC 플레이어";
            notifyIcon1.BalloonTipText = "성공적으로 트레이에 이동되었습니다.";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void 창모드로전환ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (AudioSystem.Playing.waveout != null)
            {
                if (AudioSystem.Playing.waveout.PlaybackState != PlaybackState.Playing)
                {
                    AudioSystem.Playing.Play();
                    //Play.Text = "일시정지";
                }
                else
                {
                    AudioSystem.Playing.Pause();
                    //Play.Text = "재생";
                }
            }
        }

        private void LoginButton_TextChanged(object sender, EventArgs e)
        {
            if (LoginButton.Text == "로그아웃")
            {
                string a = AuthData.LoginInfo.Name;
                result.Text = a + "님 환영합니다!";
                LoginButton.Enabled = true;
                button5.Visible = true;
                Profile.Image = AuthData.LoginInfo.img;
                로그인ToolStripMenuItem.Text = "로그아웃";
            }
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoginButton.Text == "로그아웃")
            {
                if (AudioSystem.Playing.song_ID != "")
                {
                    AudioSystem.Playing.Stop();
                    AudioSystem.Playing.waveout.Dispose();
                    AudioSystem.Playing.waveout = null;
                    AudioSystem.Playing.Dispose();
                    AudioSystem.Playing = new AudioSystem();
                    CurrentSongInfo.Songinfo = null;
                    pictureBox1.Image = noAlbum;
                    label1.Text = "재생 할 노래가 없습니다.";
                    label4.Text = "재생할 노래를 선택하세요!";
                }
                AuthData.LoginInfo = null;
                LoginButton.Enabled = true;
                LoginButton.Text = "로그인";
                로그인ToolStripMenuItem.Text = "로그인";
                Profile.Image = noimage;
                button5.Visible = false;
                result.Text = "로그인 하세요.";
            }
            else
            {
                Login l = new Login(LoginButton);
                l.ShowDialog();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0) { trackBar2.Value = 10; } else { trackBar2.Value = 0; }
        }

        private void trackBar2_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0) button8.Text = "🔈"; else if (trackBar2.Value == trackBar2.Maximum) button8.Text = "🔊"; else button8.Text = "🔉";
            if (AudioSystem.Playing.volumeProvider == null) return;
            float i = (float)trackBar2.Value / (float)trackBar2.Maximum;
            AudioSystem.Playing.volumeProvider.Volume = i;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            switch (selectmode)
            {
                case playmode.All:
                    selectmode = playmode.One;
                    button10.Text = "1곡 반복";
                    break;
                case playmode.One:
                    selectmode = playmode.Normal;
                    button10.Text = "반복 없음";
                    break;
                case playmode.Normal:
                    selectmode = playmode.All;
                    button10.Text = "전체 반복";
                    break;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Gettop();
        }
        private async void Gettop()
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("pg=1");
            dataParams.Append("&pgsize=100");
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("https://app.genie.co.kr/chart/j_RankSongList.json?");
            re.Method = "POST";
            re.ContentType = "application/x-www-form-urlencoded";
            re.ContentLength = byteDataParams.Length;
            Stream Datastpar = re.GetRequestStream();
            Datastpar.Write(byteDataParams, 0, byteDataParams.Length);
            Datastpar.Close();
            Datastpar.Dispose();
            HttpWebResponse res = (HttpWebResponse)re.GetResponse();
            Stream ReadData = res.GetResponseStream();
            StreamReader reData = new StreamReader(ReadData, Encoding.UTF8);
            string strResult = reData.ReadToEnd();
            if (!process.checkResult(strResult)) return;
            Song.songs.Clear();
            JObject obj = JObject.Parse(strResult);
            JArray songlist = JArray.Parse(obj["DataSet"]["DATA"].ToString());
            foreach (JObject songobj in songlist)
            {
                Song song = new Song();
                song.JObjectToSongSync(songobj, false);
                Song.songs.Add(song);
            }
            Refresh_ListBox();
            return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("FLAC"))
            {
                MessageBox.Show("FLAC 음질은 오디오 라이브러리 특성상 RAM 사용률이 좀 높습니다. 계속 하시겠습니까?", "FLAC 음원 이용시 주의 안내", MessageBoxButtons.OK);
            }
        }

        private void 업데이트확인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loading ver = new Loading();
            ver.ShowDialog();
        }

        private void Play_Paint(object sender, PaintEventArgs e)
        {
            if (AudioSystem.Playing.waveout != null)
            {
                if (AudioSystem.Playing.waveout.PlaybackState != PlaybackState.Playing)
                {
                    Play.Text = "재생";
                }
                else
                {
                    Play.Text = "일시정지";
                }
            }
            else
            {
                Play.Text = "재생/일시정지";
            }
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {

        }
        private CLyricsManager Lm = new CLyricsManager();
        private void lyrics_Tick(object sender, EventArgs e)
        {
            if (AudioSystem.Playing.wavestream == null) return;
            if (this.Lm.InfoID.Equals("-1")) { label5.Text = "가사 정보가 없습니다."; label6.Text = ""; lyrics.Enabled = false; return; }
            if (this.Lm.Lyric_List == null && this.Lm.Lyric_List.Count < 0) return;
            int Time = (int)AudioSystem.Playing.wavestream.CurrentTime.TotalMilliseconds;
            if (label5.Text == "") { Labelnormal(label5); label5.Text = this.Lm.Lyric_List[0]; Labelnormal(label6); label6.Text = this.Lm.Lyric_List[1]; }
            for (int index1 = this.Lm.Lyric_Time_List.Count - 1; index1 >= 0; --index1)
            {
                if (this.Lm.Lyric_Time_List[index1] < Time)
                {
                    string str = this.Lm.Lyric_List[index1];
                    if (this.Lm.Lyric_List.Count <= index1+1) { Labelnormal(label5); label5.Refresh(); Labelbold(label6); label6.Refresh(); return; }
                    Labelnormal(label6); Labelbold(label5);
                    if (label5.Text.Equals(str)) return;
                    label5.Text = str;
                    label5.Refresh();
                        label6.Text = this.Lm.Lyric_List[index1 + 1];
                    label6.Refresh();
                    /*
                    for (int index2 = index1; index1>index1 -5 && index2 >=0; --index2)
                    {
                        if ((int) this.Lm.Lyric_Time_List[index2]== (int)this.Lm.Lyric_Time_List[index1])
                        {
                            Label label5 = this.label5;
                            string str = this.Lm.Lyric_List[index2];
                            label5.Text = str;
                    if (this.Lm.Lyric_List.Count > index2 + 1)
                    label6.Text = this.Lm.Lyric_List[index2 + 1];
                    else
                        label6.Text = "";
                }
            }*/
                    break;
            }
    }
}

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           if (!checkBox1.Checked && this.Size.Height >= 610) return;
           else if (checkBox1.Checked && this.Size.Height <= 230) return;
            if (checkBox1.Checked) this.Height -= 12;else
            if (!checkBox1.Checked) this.Height+= 12;
        }
    }
}
