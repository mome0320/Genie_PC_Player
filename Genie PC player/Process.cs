using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genie_PC_player
{
    class Process
    {
       // [Obfuscation(Feature = "renaming", Exclude = true)]
        public Boolean Login(string id, string pw)
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
            using (Stream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                authdata.img = Image.FromStream(stream);
            AuthData.LoginInfo = authdata;
            }
            return true;
        }
public string RetCode = "";
        public string RetMsg = "";
        public string RetType = "";
        public string URL = "";
        public string Page = "";
        public string TotPage = "";
        public string TotCount = "";
        //[Obfuscation(Feature = "renaming", Exclude = true)]
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
       // [Obfuscation(Feature = "renaming", Exclude = true)]
        public bool LoadSong(string songid)
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
            JArray songlist = JArray.Parse(obj["DataSet"]["DATA"].ToString());
            foreach (JObject songobj in songlist)
            {
                Song song = new Song();
                song.JObjectToSong(songobj, false);
                Song.songs.Add(song);
            }
            return true;
        }

        public async void sendFullLog()
        {
            if (CurrentSongInfo.Songinfo.islogin == "N") return;
            if (AudioSystem.Playing.isseek) return;
            string log = CurrentSongInfo.Songinfo.Song.Song_ID;
            string log2 = CurrentSongInfo.Songinfo.MEM_CHK_UNO;
            await Task.Run(() =>loggedFull(log,log2));
            System.Diagnostics.Debug.WriteLine("풀로그 전송되었습니다.");
        }
        private bool loggedFull(string xgnm ,string unm)
        {
            if(unm != ""&&xgnm != "")
            {
                StringBuilder dataParams = new StringBuilder();
                dataParams.Append("xgnm=" + xgnm);
                dataParams.Append("&unm=" + unm);
                byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
                WebRequest re = WebRequest.Create("http://www.genie.co.kr/player/sendStreamFullLog");
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
                JObject obj = JObject.Parse(strResult);
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
            
               await Task.Run(() => LoggedGerman(log));
            }
            else if (f == 5)
            {
                await Task.Run(() => LoggedDPMR(log));
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
        private bool LoggedGerman(string log)
        {
            if(log != "")
            {
                StringBuilder dataParams = new StringBuilder();
                dataParams.Append("LOG_PARAM=" + log);
                byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
                WebRequest re = WebRequest.Create("http://www.genie.co.kr/player/sendPlayStreamLog");
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
                JObject obj = JObject.Parse(strResult);
                if(obj["Result"]["RetCode"].ToString().Equals("0"))
                {
                    return true;
                }
            }
            return false;
        }
        private bool LoggedDPMR(string log)
        {
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("xpld=" + log);
            byte[] byteDataParams = Encoding.Default.GetBytes(dataParams.ToString());
            WebRequest re = WebRequest.Create("/player/jPlayerDpMeterRateOffSet");
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
            JObject obj = JObject.Parse(strResult);
            if (obj["Result"]["RetCode"].ToString().Equals("0"))
            {
                return true;
            }
            return false;
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
        bool isDpMrLayerAgree = false;
       /*public PlayMode getPlayMode()
        {
            CurrentSongInfo s = CurrentSongInfo.Songinfo;
            bool isAction;
            if (s.STREAM_LICENSE_YN == "Y" || s.FULLSTREAMYN == "Y" || (s.MRSTM_YN == "Y" && int.Parse(s.MRSTM_NUM) > 0)) isAction = true;
            else isAction = false;
            int prod = getProdType();
            if (s.islogin == "Y")
            {
                if (!isAction)
                {
                    if (s.NONLICENSE == "N")
                    {
                        if ((s.HOLD_BACK == "Y") && (s.SID == ""))
                        {
                            return PlayMode.onemin;
                        }
                        else
                        {
                            if (s.LICENSE_YN == "N" && s.LICENSE_MSG != "")
                            {
                                return PlayMode.onemin;
                            }
                            else
                            {
                                return PlayMode.onemin;
                            }
                        }
                    }
                }
            }
            else
            {
                return PlayMode.onemin;
            }
            if (prod == 5)
            {
                int iPayCnt = int.Parse(s.DPMRSTM_CNT);
                int iPayAmount = iPayCnt * 10;

                if (iPayCnt % 100 == 0 && iPayCnt >= 100)
                {
                    int iPopCnt = iPayCnt / 100;
                    if (iPopCnt >= 6)
                    {
                        //얼마나 이런 미친짓을 했길레
                        //사용량이 마나요?
                    }
                    else
                    {
                        //금액 알림이네? ㅋ
                    }
                    //iPayCnt + "회";
                    //iPayAmount+"원";
                }
            }
        }
      /*  public PlayMode StreamingReady()
        {
            CurrentSongInfo Songinfo = CurrentSongInfo.Songinfo;
            bool isAction;
            string strStreamLogData2;
            if (Songinfo.STREAM_LICENSE_YN == "Y" || Songinfo.FULLSTREAMYN == "Y" || (Songinfo.MRSTM_YN == "Y" && int.Parse(Songinfo.MRSTM_NUM) > 0)) isAction = true;
            else isAction = false;
            int prod = getProdType();
            if (prod == 3)
            {
                strStreamLogData2 = Songinfo.ITEM_PPS_CNT;
                //잔여곡: MRSTM_NUM;
                //사용 표시 해야한다 이기야
            }
            if (Songinfo.islogin == "Y")
            {
                if (!isAction)
                {
                    if(Songinfo.NONLICENSE == "N")
                    {
                        if((Songinfo.HOLD_BACK == "Y")&&(Songinfo.SID == ""))
                        {
                            return PlayMode.onemin;
                        }
                        else
                        {
                            if(Songinfo.LICENSE_YN == "N"&&Songinfo.LICENSE_MSG != "")
                            {
                                return PlayMode.onemin;
                            }
                            else
                            {
                                return PlayMode.onemin;
                            }
                        }
                    }
                }
            }
            else
            {
                return PlayMode.onemin;
            }
            if(prod ==5 && !isDpMrLayerAgree)
            {
                int iPayCnt = int.Parse(Songinfo.DPMRSTM_CNT);
                int iPayAmount = iPayCnt * 10;

                if(iPayCnt % 100 == 0 &&iPayCnt >= 100)
                {
                    int iPopCnt = iPayCnt / 100;
                    if(iPopCnt >= 6)
                    {
                        //얼마나 이런 미친짓을 했길레
                        //사용량이 마나요?
                    }
                    else
                    {
                        //금액 알림이네? ㅋ
                    }
                   //iPayCnt + "회";
                   //iPayAmount+"원";
                }
            }
        }*/
        public enum PlayMode
        {

            Normal = 0,

            onemin = 1,

            NONE = 2
        }
    }

}
