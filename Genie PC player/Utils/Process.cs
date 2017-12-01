using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genie_PC_player
{
    class Process
    {
        public string RetCode = "";
        public string RetMsg = "";
        public string RetType = "";
        public string URL = "";
        public string Page = "";
        public string TotPage = "";
        public string TotCount = "";
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
        public async Task<bool> LoginAsync(string id, string pw)
        {
            Uri resourceuri;
            if (!Uri.TryCreate("https://app.genie.co.kr/member/j_Member_Login.json?", UriKind.Absolute, out resourceuri)) return false;
            try
            {
                HttpHelper.InitPostData();
                HttpHelper.setPostData("uxd", id);
                HttpHelper.setPostData("uxx", pw);
                string Output = await HttpHelper.PostAsync(resourceuri);
                if (string.IsNullOrEmpty(Output)) return false;
                if (!checkResult(Output)) return false;
                JObject obj = JObject.Parse(Output);
                JObject Result = JObject.Parse(obj["Result"].ToString());
                AuthData authdata = new AuthData();
                JObject DATA = JObject.Parse(obj["DATA0"].ToString());
                authdata.JObjectToData(DATA);
            }catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> LoadSongAsync(string songid)
        {
            Uri resourceuri;
            if (!Uri.TryCreate("http://www.genie.co.kr/player/jPlayerSongList.json?", UriKind.Absolute, out resourceuri)) return false;
            try
            {
                HttpHelper.InitPostData();
                HttpHelper.setPostData("xgnm", songid);
                string Output = await HttpHelper.PostAsync(resourceuri);
                if (string.IsNullOrEmpty(Output)) return false;
                JObject obj = JObject.Parse(Output);
                JArray songlist = JArray.Parse(obj["DataSet"]["DATA"].ToString());
                foreach (JObject songobj in songlist)
                {
                    Song song = new Song();
                    song.JObjectToSong(songobj, true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async void sendFullLog()
        {
            if (CurrentSongInfo.Songinfo.islogin == "N") return;
            if (AudioSystem.Playing.isseek) return;
            string log = CurrentSongInfo.Songinfo.Song.Song_ID;
            string log2 = CurrentSongInfo.Songinfo.MEM_CHK_UNO;
            await loggedFullAsync(log, log2);
            System.Diagnostics.Debug.WriteLine("풀로그 전송되었습니다.");
        }
        private async Task<bool> loggedFullAsync(string xgnm, string unm)
        {
            if (unm != "" && xgnm != "")
            {
                Uri resourceuri;
                if (!Uri.TryCreate("http://www.genie.co.kr/player/sendStreamFullLog", UriKind.Absolute, out resourceuri)) return false;
                HttpHelper.InitPostData();
                HttpHelper.setPostData("xgnm", xgnm);
                HttpHelper.setPostData("unm", unm);
                string Output = await HttpHelper.PostAsync(resourceuri);
                if (string.IsNullOrEmpty(Output)) return false;
                JObject obj = JObject.Parse(Output);
                if (obj["Result"]["RetCode"].ToString().Equals("0"))
                {
                    return true;
                }
            }
            return false;
            }
        public async void LogGenie()
        {
            if (AudioSystem.Playing.islogged) return;
            AudioSystem.Playing.islogged = true;
            string log= CurrentSongInfo.Songinfo.LOG_PARAM;
            int f = getProdType();
            if (f == 1)
            {
                await LoggedGermanAsync(log);
               //await Task.Run(() => LoggedGerman(log));
            }
            else if (f == 5)
            {
                await LoggedDPMRAsync(log);
                //await Task.Run(() => LoggedDPMR(log));
            }
        }
        public async void sns()
        {
            if (AudioSystem.Playing.issns) return;
            AudioSystem.Playing.issns = true;
            string unm = AuthData.LoginInfo.Uno;
            string songid = CurrentSongInfo.Songinfo.Song.Song_ID;
            string albumid = CurrentSongInfo.Songinfo.Song.ALBUM_ID;
            string artistid = CurrentSongInfo.Songinfo.Song.Artist_ID;
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("unm=" + unm);
            dataParams.Append("&xgnm=" + songid);
            dataParams.Append("&axnm=" + albumid);
            dataParams.Append("&xxnm=" + artistid);
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("http://www.genie.co.kr/player/jPlayerStmCntProc.json");
            re.Method = "POST";
            re.ContentType = "application/x-www-form-urlencoded";
            re.ContentLength = byteDataParams.Length;
            Stream Datastpar = re.GetRequestStream();
            Datastpar.Write(byteDataParams, 0, byteDataParams.Length);
            Datastpar.Close();
            Datastpar.Dispose();
            /*HttpWebResponse res = (HttpWebResponse)re.GetResponse();
            Stream ReadData = res.GetResponseStream();
            StreamReader reData = new StreamReader(ReadData, Encoding.UTF8);
            string strResult = reData.ReadToEnd();*/
        }
        private async Task<bool> LoggedGermanAsync(string log)
        {
                Uri resourceuri;
                if (!Uri.TryCreate("http://www.genie.co.kr/player/sendPlayStreamLog", UriKind.Absolute, out resourceuri)) return false;
                HttpHelper.InitPostData();
                HttpHelper.setPostData("LOG_PARAM", log);
                string Output = await HttpHelper.PostAsync(resourceuri);
                if (string.IsNullOrEmpty(Output)) return false;
                JObject obj = JObject.Parse(Output);
                if (obj["Result"]["RetCode"].ToString().Equals("0"))
                {
                    return true;
                }
            return false;
        }
        private async Task<bool> LoggedDPMRAsync(string log)
        {
            Uri resourceuri;
            if (!Uri.TryCreate("http://www.genie.co.kr/player/jPlayerDpMeterRateOffSet", UriKind.Absolute, out resourceuri)) return false;
            HttpHelper.InitPostData();
            HttpHelper.setPostData("LOG_PARAM", log);
            string Output = await HttpHelper.PostAsync(resourceuri);
            if (string.IsNullOrEmpty(Output)) return false;
            JObject obj = JObject.Parse(Output);
            if (obj["Result"]["RetCode"].ToString().Equals("0"))
            {
                await LoggedGermanAsync(log);
                return true;
            }
            return false;
        }
        public int getProdType()
        {
            CurrentSongInfo s = CurrentSongInfo.Songinfo;
            if (s.STREAM_LICENSE_YN == "Y")
            {
                if (s.DPMRSTM_YN == "Y")
                {
                    return 5;
                }
                else
                {
                    return 1;
                }
            }
            else if ((s.FULLSTERAMSVCYN == "Y") && (int.Parse(s.FULLSTREAMCNT) > 0) && (s.FULLSTREAMYN == "Y"))
            {
                return 2; //풀트랙 씨발 무료 꺼져
            }
            else if ((s.MRSTM_YN == "Y") && (int.Parse(s.MRSTM_NUM) > 0))
            {
                return 3; //PPS 씨발 병신 왜 이렇게 PC만 바라냐 ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ
                //strStreamLogData2 = Songinfo.ITEM_PPS_CNT;
            }
            return 0;
        }
    }

}
