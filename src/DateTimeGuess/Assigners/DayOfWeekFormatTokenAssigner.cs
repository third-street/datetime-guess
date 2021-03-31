namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Day of Week format.
    /// </summary>
    internal class DayOfWeekFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfWeekFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public DayOfWeekFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"[0-6]"), "u");
                Map.Add(new Regex(@"[0-6]st"), "u'st'");
                Map.Add(new Regex(@"[0-6]nd"), "u'nd'");
                Map.Add(new Regex(@"[0-6]rd"), "u'rd'");
                Map.Add(new Regex(@"[0-6]th"), "u'th'");
                Map.Add(new Regex(@"(?:Su|Mo|Tu|We|Th|Fr|Sa)"), "NA");
                Map.Add(new Regex(@"(?:Sun|Mon|Tue|Wed|Thu|Fri|Sat)"), "E");
                Map.Add(new Regex(@"(?:Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday)"), "EEEE");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"[0-6]"), "d");
                Map.Add(new Regex(@"[0-6](?:st|nd|rd|th)"), "do");
                Map.Add(new Regex(@"(?:Su|Mo|Tu|We|Th|Fr|Sa)"), "dd");
                Map.Add(new Regex(@"(?:Sun|Mon|Tue|Wed|Thu|Fri|Sat)"), "ddd");
                Map.Add(new Regex(@"(?:Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday)"), "dddd");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"[0-6]"), "%w");
                Map.Add(new Regex(@"[0-6](?:st|nd|rd|th)"), "NA");
                Map.Add(new Regex(@"(?:Su|Mo|Tu|We|Th|Fr|Sa)"), "NA");
                Map.Add(new Regex(@"(?:Sun|Mon|Tue|Wed|Thu|Fri|Sat)"), "%a");
                Map.Add(new Regex(@"(?:Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday)"), "%A");
            }
        }
    }
}
