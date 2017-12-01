using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genie_PC_player
{
   public static class HttpHelper
    {
        private static List<KeyValuePair<string,string>> postData = new List<KeyValuePair<string, string>>();
        public static void setPostData(string key,string value)
        {
            HttpHelper.postData.Add(new KeyValuePair<string, string>(key, value));
        }
        public static List<KeyValuePair<string,string>> getPostData()
        {
            return HttpHelper.postData;
        }
        public static void InitPostData()
        {
            HttpHelper.postData.Clear();
        }
        public static async Task<string> PostAsync(Uri uri)
        {
            HttpContent content = (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)HttpHelper.getPostData());
            HttpHelper.postData.Clear();
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("인터넷 연결이 원활하지 않습니다." + Environment.NewLine + "네트워크 상태를 확인해주세요!", "인터넷 없음");
                return (string)null;
            }
            string output = (string)null;
            try
            {
                HttpResponseMessage res = await new HttpClient()
                {
                    Timeout = TimeSpan.FromSeconds(10.0)
                }.PostAsync(uri, content);
                if(res.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(string.Format("HTTP 에러났습니다! 에러코드:%d",res.StatusCode), "에러");
                    return output;
                }
               byte[] resultbyte= await res.Content.ReadAsByteArrayAsync();
                Encoding enc = Encoding.GetEncoding("utf-8");
                output = enc.GetString(resultbyte, 0, resultbyte.Length);
                output = output.Replace("<br>", Environment.NewLine);
                res.Dispose();
                content.Dispose();
            }catch(TimeoutException ex)
            {
                MessageBox.Show(string.Format("네트워크 연결 시간 초과되었습니다."+Environment.NewLine+"인터넷 상태를 확인하세요!"), "연결 초과");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"에외 발생 개발자한테 문의하세요.");
            }
            return output;
        }
    }
}
