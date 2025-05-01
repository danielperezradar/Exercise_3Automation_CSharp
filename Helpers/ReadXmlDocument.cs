using System.Xml;

namespace Exercise_3Automation_CSharp.Helpers
{
    public class ReadXmlDocument
    {
        protected string url, username, password;
        protected XmlDocument document;

        public XmlNodeList ReadXML(string path)
        {
            document = new XmlDocument();
            document.Load(path);
            return document.SelectNodes("test");  
        }

        public string GetUrl(XmlNodeList nodes)
        {
            foreach(XmlNode node in nodes) {
                url = node["url"].InnerText;
            }
            return url;
        }

        public string GetUsername(XmlNodeList nodes)
        {
            foreach(XmlNode node in nodes) {
                username = node["username"].InnerText;
            }
            return username;
        }

        public string GetPassword(XmlNodeList nodes)
        {
            foreach(XmlNode node in nodes) {
                password = node["password"].InnerText;
            }
            return password;
        }
    }
}