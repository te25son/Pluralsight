using System;
using System.Linq;
using System.Text;

namespace GoingWithTheFlow
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

    public static class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource @this, Func<TSource, TResult> func) => func(@this);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var selectBox =
                Disposable
                    .Using(
                        StreamFactory.GetStream,
                        stream =>
                        {
                            var b = new byte[stream.Length];
                            stream.Read(b, 0, (int)stream.Length);
                            return b;
                        })
                    .Map(Encoding.UTF8.GetString)
                    .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2)
                    .Map(options => ExtendStringBuilder.BuildSelectBox(options, "theFellowshop", true));

            Console.WriteLine(selectBox);
        }
    }
}
