using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genie_PC_player
{
    class CurrentSongInfo
    {
        public string StreamingURL { get; set; }
        public string image { get; set; }
        public string islogin { get; set; }
        public string isAdult { get; set; }
        public string LisenceYN { get; set; }
        public string isLycis { get; set; }
        public string LOG_PARAM { get; set; }
        public string Like_total { get; set; }
        public string isliked { get; set; }
        public Dictionary<string, string> liveLycis{get; set;}
        public Song Song { get; set; }
    }
}
