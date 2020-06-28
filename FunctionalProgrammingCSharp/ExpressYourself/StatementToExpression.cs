using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ExpressYourself
{
    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, TResult> map)
            where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return map(disposable);
            }
        }
    }

    public class StatementToExpression
    {
        public static void Run()
        {
            var time = 
                Disposable
                    .Using(
                        () => new System.Net.WebClient(),
                        client => XDocument.Parse(client.DownloadString("http://time.gov/actualtime.cgi")))
                    .Root
                    .Attribute("time")
                    .Value;
            
            var ms = Convert.ToInt64(time) / 1000;
            var currentTime = new DateTime(1970, 1, 1).AddMilliseconds(ms).ToLocalTime();

            Console.WriteLine(currentTime);
        }
    }
}
