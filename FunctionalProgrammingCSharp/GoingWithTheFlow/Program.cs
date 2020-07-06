using System;
using System.Linq;
using System.Text;

namespace GoingWithTheFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer;

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
