using System.IO;
using System.Net;
using System.Xml;

namespace Nova
{
    class GeoIP
    {
        public string WANIP { get; private set; }
        public string Country { get; private set; }
        public string CountryCode { get; private set; }
        public string Region { get; private set; }
        public string City { get; private set; }

        public GeoIP()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/xml/");
                request.Timeout = 1000;           // 连接超时 + 接收超时 = 1秒
                request.ReadWriteTimeout = 1000;  // 读写超时 = 1秒
                request.Proxy = null;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseString = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseString);

                WANIP = doc.SelectSingleNode("query//query").InnerXml.ToString();
                Country = (!string.IsNullOrEmpty(doc.SelectSingleNode("query//country").InnerXml.ToString())) ? doc.SelectSingleNode("query//country").InnerXml.ToString() : "Unknown";
                CountryCode = (!string.IsNullOrEmpty(doc.SelectSingleNode("query//countryCode").InnerXml.ToString())) ? doc.SelectSingleNode("query//countryCode").InnerXml.ToString() : "-";
                Region = (!string.IsNullOrEmpty(doc.SelectSingleNode("query//regionName").InnerXml.ToString())) ? doc.SelectSingleNode("query//regionName").InnerXml.ToString() : "Unknown";
                City = (!string.IsNullOrEmpty(doc.SelectSingleNode("query//city").InnerXml.ToString())) ? doc.SelectSingleNode("query//city").InnerXml.ToString() : "Unknown";
            }
            catch
            {
                WANIP = "-";
                Country = "Unknown";
                CountryCode = "-";
                Region = "Unknown";
                City = "Unknown";
            }
        }
    }
}
