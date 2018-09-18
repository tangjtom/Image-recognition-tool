using System;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace APICALL
{
    public class Web_Request
    {
        public Web_Request()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        public static string GET_WebRequestHTML(string encodingName, string htmlUrl, string token)
        {
            string josn = string.Empty;

            try
            {
                Encoding encoding = Encoding.GetEncoding(encodingName);

                WebRequest webRequest = WebRequest.Create(htmlUrl);
                HttpWebRequest httpRequest = webRequest as System.Net.HttpWebRequest;
                httpRequest.Headers.Add("Authorization", token);
                httpRequest.ContentType = "application/json";

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();

                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);

                josn = streamReader.ReadToEnd();

                httpWebResponse.Close();
                responseStream.Close();
                streamReader.Close();
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }

            return josn;
        }

        /// <summary>
        /// 将网址类容转换成文本字符串 post请求
        /// </summary>
        /// <param name="data">要post的数据</param>
        /// <param name="url">目标url</param>
        /// <returns>服务器响应</returns>
        public static string POST_WebRequestHTML(string encodingName,
                               string htmlUrl,
                               string postData, string token)
        {
            string json = string.Empty;

            try
            {
                Encoding encoding = Encoding.GetEncoding(encodingName);

                byte[] bytesToPost = encoding.GetBytes(postData);

                WebRequest webRequest = WebRequest.Create(htmlUrl);
                HttpWebRequest httpRequest = webRequest as System.Net.HttpWebRequest;

                httpRequest.Method = "POST";
                httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                // httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.ContentType = "application/json";
                httpRequest.ContentLength = bytesToPost.Length;
                httpRequest.Timeout = 30000;
                httpRequest.ReadWriteTimeout = 30000;

                httpRequest.Headers.Add("token", token);

                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                requestStream.Close();

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);

                json = streamReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }

            return json;
        }
        public static string POST_WebRequestHTML(string encodingName,
                               string htmlUrl,
                               string postData)
        {
            string json = string.Empty;
            try
            {
                Encoding encoding = Encoding.GetEncoding(encodingName);

                byte[] bytesToPost = encoding.GetBytes(postData);

                WebRequest webRequest = WebRequest.Create(htmlUrl);
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                HttpWebRequest httpRequest = webRequest as System.Net.HttpWebRequest;

                httpRequest.Method = "POST";
                httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                //httpRequest.ContentType = "application/json";
                httpRequest.ContentLength = bytesToPost.Length;
                httpRequest.Timeout = 30000;
                httpRequest.ReadWriteTimeout = 30000;
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                requestStream.Close();

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);

                json = streamReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }

            return json;
        }
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {  // 总是接受  
            return true;
        }

    }
}
