using System;
using System.Linq;
using System.Text;

namespace GoingWithTheFlow
{
    class Program
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

        static void Main(string[] args)
        {
            var buffer =
                Disposable
                    .Using(
                        StreamFactory.GetStream,
                        stream =>
                        {
                            var b = new byte[stream.Length];
                            stream.Read(b, 0, (int)stream.Length);
                            return b;
                        });
                    

            using (var stream = StreamFactory.GetStream())
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }

            var options =
                Encoding
                    .UTF8
                    .GetString(buffer)
                    .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2);

            var selectBox = ExtendStringBuilder.BuildSelectBox(options, "theFellowshop", true);

            Console.WriteLine(selectBox);
        }
    }
}
