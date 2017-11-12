using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genie_PC_player
{
    class AuthData
    {
        public static AuthData LoginInfo;
        public string Uno { get; set; }
        public string Sex { get; set; }
        public string Name{get; set; }
        public string Age { get; set; }
        public string isAdult { get; set; }
        public string token { get; set; }
        public string conf { get; set; }
        public string corp { get; set; }
        public string Prod { get; set; }
        public Image img { get; set; }
    }
}
