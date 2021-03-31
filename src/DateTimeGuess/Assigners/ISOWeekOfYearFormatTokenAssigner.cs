namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the ISO Week of th Year format.
    /// </summary>
    internal class ISOWeekOfYearFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ISOWeekOfYearFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public ISOWeekOfYearFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{1,2}"), "w");
                Map.Add(new Regex(@"\d{1,2}st"), "w'st'");
                Map.Add(new Regex(@"\d{1,2}nd"), "w'nd'");
                Map.Add(new Regex(@"\d{1,2}rd"), "w'rd'");
                Map.Add(new Regex(@"\d{1,2}th"), "w'th'");
                Map.Add(new Regex(@"\d{2}"), "ww");
                Map.Add(new Regex(@"\d{2}st"), "ww'st'");
                Map.Add(new Regex(@"\d{2}nd"), "ww'nd'");
                Map.Add(new Regex(@"\d{2}rd"), "ww'rd'");
                Map.Add(new Regex(@"\d{2}th"), "ww'th'");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{1,2}"), "W");
                Map.Add(new Regex(@"\d{2}"), "WW");
                Map.Add(new Regex(@"\d{1,2}(?:st|nd|rd|th)"), "Wo");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{1,2}"), "NA");
                Map.Add(new Regex(@"\d{2}"), "%U");
                Map.Add(new Regex(@"\d{1,2}(?:st|nd|rd|th)"), "NA");
            }
        }
    }
}