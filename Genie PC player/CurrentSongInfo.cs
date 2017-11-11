using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Genie_PC_player
{
    class CurrentSongInfo
    {
        public string StreamingURL { get; set; }
        public string STREAM_LICENSE_YN { get; set; }
        public string LICENSE_YN { get; set; }
        public string LICENSE_MSG { get; set; }
        public string NONLICENSE { get; set; }
        public string image { get; set; }
        public string islogin { get; set; }
        public string isAdult { get; set; }
        public string FULLSTREAMYN { get; set; }
        public string FULLSTREAMCNT { get; set; }
        public string FULLSTERAMSVCYN { get; set; }
        public string isLycis { get; set; }
        public string DPMRSTM_CNT { get; set; }
        public string MRSTM_YN { get; set; }
        public string MRSTM_NUM { get; set; }
        public string MRSTM_MAX_NUM{ get; set; }
        public string LOG_PARAM { get; set; }
        public string Like_total { get; set; }
        public string isliked { get; set; }
        public string SID { get; set; }
        public string BITRATE { get; set; }
        public string ITEM_PPS_CNT { get; set; }
        public string MEM_CHK_UNO { get; set; }
        public string HOLD_BACK { get; set; }
        public Dictionary<string, string> liveLycis{get; set;}
        public Song Song { get; set; }
        public string DPMRSTM_YN { get; set; }

        public void JObjectToData(JObject data, Song s)
        {
            StreamingURL = HttpUtility.UrlDecode(data["STREAMING_MP3_URL"].ToString());
            STREAM_LICENSE_YN = data["STREAMING_LICENSE_YN"].ToString();
            isAdult = data["ADULT_YN"].ToString();
            isLycis = data["LYRICS_YN"].ToString();
            DPMRSTM_CNT = data["DPMRSTM_CNT"].ToString();
            DPMRSTM_YN = data["DPMRSTM_YN"].ToString();
            FULLSTREAMYN = data["FULLSTREAMYN"].ToString();
            FULLSTREAMCNT = data["FULLSTREAMCNT"].ToString();
            FULLSTERAMSVCYN = data["FULLSTREAMSVCYN"].ToString();
            islogin = data["ISLOGIN"].ToString();
            SID = data["SID"].ToString();
            MRSTM_YN = data["MRSTM_YN"].ToString();
            MRSTM_MAX_NUM = data["MRSTM_MAX_NUM"].ToString();
            MRSTM_NUM = data["MRSTM_NUM"].ToString();
            image = HttpUtility.UrlDecode(data["ABM_IMG_PATH"].ToString());
            BITRATE = data["BITRATE"].ToString();
            ITEM_PPS_CNT = data["ITEM_PPS_CNT"].ToString();
            NONLICENSE = data["NONLICENCE"].ToString();
            MEM_CHK_UNO = data["MEM_CHK_UNO"].ToString();
            LOG_PARAM = data["LOG_PARAM"].ToString();
            LICENSE_YN = data["LICENSE_YN"].ToString();
            LICENSE_MSG = data["LICENSE_MSG"].ToString();
            HOLD_BACK = data["HOLD_BACK"].ToString();
            Song = s;
        }
    }
}
