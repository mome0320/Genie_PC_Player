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

namespace Genie_PC_player
{
    class Process
    {
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
            Stream stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            authdata.img = Image.FromStream(stream);
            AuthData.LoginInfo = authdata;
            return true;
        }
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
        /* public void onLogic()
        {
            //이용권 체크
            int iProdType;
            string strStreamLogData;
            string strStreamLogData2;
            if (Songinfo.STREAM_LICENSE_YN == "Y" || Songinfo.FULLSTREAMYN == "Y" || (Songinfo.MRSTM_YN == "Y" && int.Parse(Songinfo.MRSTM_NUM) > 0)) isAction = true;
            else isAction = false;

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
            }
            else if ((Songinfo.FULLSTERAMSVCYN == "Y") && (int.Parse(Songinfo.FULLSTREAMCNT) > 0) && (Songinfo.FULLSTREAMYN == "Y"))
            {
                iProdType = 2; //풀트랙
            }
            else if ((Songinfo.MRSTM_YN == "Y") && (int.Parse(Songinfo.MRSTM_NUM) > 0))
            {
                iProdType = 3; //PPS
                strStreamLogData2 = Songinfo.ITEM_PPS_CNT;
            }
            if (Songinfo.islogin == "Y")
            {
                if (!isAction)
                {
                    if (Songinfo.NONLICENSE == "N")
                    {
                        if ((Songinfo.HOLD_BACK == "Y") && (Songinfo.SID == ""))
                        {
                            //메세지
                            //권리사의 요청으로 1분 미리듣기만 제공됩니다 (hold-back)
                        }
                        else
                        {
                            if (Songinfo.LICENSE_YN == "N" && Songinfo.LICENSE_MSG != "")
                            {
                                //(1분) LICENSE_MSG 출력 하고 상품 구매하기 창 나오네?
                            }
                            else
                            {
                                //상품권 구매 안내 ^^
                            }
                        }
                    }
                    else
                    {
                        //권리사의 요청으로 1분 미리듣기만 제공됩니다.
                    }
                }
            }
            else { /*1분 미리듣기 중입니다.<br />로그인 후 음악감상 상품이 있으시면 전곡 감상이 가능합니다.}

        }*/
    }

}
