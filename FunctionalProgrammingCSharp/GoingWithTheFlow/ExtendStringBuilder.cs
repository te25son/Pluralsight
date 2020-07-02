using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoingWithTheFlow
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormattedLine(this StringBuilder @this, string format, params object[] args) =>
            @this.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendWhen(this StringBuilder @this, Func<bool> predicate, Func<StringBuilder, StringBuilder> func) =>
            predicate()
                ? func(@this)
                : @this;

        public static StringBuilder AppendSequence<T>(this StringBuilder @this, IEnumerable<T> sequence, Func<StringBuilder, T, StringBuilder> func) =>
            sequence.Aggregate(@this, func);
    }

    public class ExtendStringBuilder
    {
        public static string BuildSelectBox(IDictionary<int, string> options, string id, bool includeUnknown) =>
            new StringBuilder()
                .AppendFormattedLine("<select id=\"{0}\"> name=\"{0}\">", id)
                .AppendWhen(
                    () => includeUnknown,
                    sb => sb.AppendLine("\t<option>Unknown<option>"))
                .AppendSequence(
                    options,
                    (sb, o) =>
                        sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", o.Key, o.Value))
                .AppendLine("</select>")
                .ToString();

        public static void Run()
        {
            var fellowship = new Dictionary<int, string>
            {
                { 1, "Frodo" },
                { 2, "Merry" },
                { 3, "Pippin" },
                { 4, "Sam" },
                { 5, "Gandalf" },
                { 6, "Aragorn" },
                { 7, "Legolas" },
                { 8, "Gimli" },
                { 9, "Boromir" },
            };

            Console.WriteLine(BuildSelectBox(fellowship, "theFellowshipOfTheRing", true));
        }
    }
}
