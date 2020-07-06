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

    public static class ExtendStringBuilder
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
    }
}
