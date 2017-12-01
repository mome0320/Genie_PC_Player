using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Genie_PC_player
{
    class Song
    {
        public static List<Song> songs = new List<Song>();  
       // public string MP3 { get; set; }
        public string Artist_ID { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Song_ID { get; set; }
        public string ALBUM { get; set; }
        public string ALBUM_ID { get; set; }
        public string isAdult { get; set; }
        public string Duration { get; set; }
        public string Streaming { get; set; }
        public void JObjectToSong(JObject obj,Boolean islist)
        {
            //MP3 = obj["MP3_YN"].ToString();
            Artist_ID = obj["ARTIST_ID"].ToString();
            Artist = HttpUtility.UrlDecode(obj["ARTIST"].ToString());
            Name = HttpUtility.UrlDecode(obj["SONG"].ToString());
            Song_ID = obj["SONG_ID"].ToString();
            ALBUM_ID = obj["ALBUM_ID"].ToString();
            ALBUM = HttpUtility.UrlDecode(obj["ALBUM"].ToString());
            isAdult = obj["ADLT_YN"].ToString();
            Duration = obj["DURATION"].ToString();
            Streaming = obj["STM_YN"].ToString();
            if (islist) songs.Add(this);
        }
        public void JObjectToSongSync(JObject obj, bool islist)
        {
            //MP3 = obj["MP3_YN"].ToString();
            Artist_ID = obj["ARTIST_ID"].ToString();
            Artist = HttpUtility.UrlDecode(obj["ARTIST_NAME"].ToString());
            Name = HttpUtility.UrlDecode(obj["SONG_NAME"].ToString());
            Song_ID = obj["SONG_ID"].ToString();
            ALBUM_ID = obj["ALBUM_ID"].ToString();
            ALBUM = HttpUtility.UrlDecode(obj["ALBUM_NAME"].ToString());
            isAdult = obj["SONG_ADLT_YN"].ToString();
            Duration = obj["DURATION"].ToString();
            Streaming = obj["STM_YN"].ToString();
            if (islist) songs.Add(this);
        }
    }
}
