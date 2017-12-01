using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Genie_PC_player.Utils
{
    internal class CLyricsManager
    {
        public List<string> Lyric_List = new List<string>();
        public List<uint> Lyric_Time_List = new List<uint>();
        public string InfoID;

        public async void GetLyricsAsync(string songid)
        {
            Uri resourceuri;
            if (!Uri.TryCreate("http://dn.genie.co.kr/app/purchase/get_msl.asp?", UriKind.Absolute, out resourceuri)) return;
            Lyric_List.Clear();
            Lyric_Time_List.Clear();
            HttpHelper.InitPostData();
            HttpHelper.setPostData("path", "a");
            HttpHelper.setPostData("songid", songid);
            string OutPut= await HttpHelper.PostAsync(resourceuri);
            if (OutPut.Equals("NOT FOUND LYRICS")) { InfoID = "-1"; return; }
            InfoID = songid;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(OutPut);
            foreach (var str2 in dict)
            {
                this.Lyric_Time_List.Add((uint)(0 + (int)Convert.ToUInt32(str2.Key)));
                this.Lyric_List.Add(str2.Value);
            }
        }
    }
}
