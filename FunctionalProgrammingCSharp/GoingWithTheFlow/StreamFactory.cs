using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingWithTheFlow
{
    public static class StreamFactory
    {
        public static Stream GetStream()
        {
            var doctors =
                String.Join(
                    Environment.NewLine,
                    new[] {
                        "Frodo", "Merry", "Pippin", "Samwise",
                        "Gandalf", "Aragorn", "Legolas", "Gimli", "Boromir"
                    });

            var buffer = Encoding.UTF8.GetBytes(doctors);

            var stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0L;

            return stream;
        }
    }
}
