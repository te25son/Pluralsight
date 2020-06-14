using System;
using System.Net;

namespace CsOop
{
    public class WebLoader : IDataLoader
    {
        private readonly string Url;

        public WebLoader(string url)
        {
            Url = url;
        }

        public string LoadData()
        {
            var client = new WebClient();
            return client.DownloadString(new Uri(Url));
        }
    }
}
