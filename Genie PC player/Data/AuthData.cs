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
    class AuthData
    {
        public static AuthData LoginInfo;
        public string Uno { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string isAdult { get; set; }
        public string token { get; set; }
        public string conf { get; set; }
        public string corp { get; set; }
        public string Prod { get; set; }
        public Image img { get; set; }
        public void JObjectToData(JObject DATA)
        {
            Sex = DATA["MemSex"].ToString();
            Uno = DATA["MemUno"].ToString();
            Age = DATA["MemAge"].ToString();
            isAdult = DATA["MemAdult"].ToString();
            token = DATA["MemToken"].ToString();
            conf = DATA["MemConf"].ToString();
            Prod = DATA["MemProd"].ToString();
            corp = DATA["MemCorp"].ToString();
            Name = DATA["MemNick"].ToString();
            string imagelink = WebUtility.UrlDecode(DATA["MemImg"].ToString());
            WebClient client = new WebClient();
            byte[] buffer = client.DownloadData(new Uri(imagelink));
            using (Stream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                img = Image.FromStream(stream);
            }
            LoginInfo = this;
        }
    }
}
