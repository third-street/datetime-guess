namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Day of Year format.
    /// </summary>
    internal class DayOfYearFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfYearFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public DayOfYearFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{1,3}"), "D");
                Map.Add(new Regex(@"\d{3}"), "DDD");
                Map.Add(new Regex(@"\d{1,3}st"), "D'st'");
                Map.Add(new Regex(@"\d{1,3}nd"), "D'nd'");
                Map.Add(new Regex(@"\d{1,3}rd"), "D'rd'");
                Map.Add(new Regex(@"\d{1,3}th"), "D'th'");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{1,3}"), "DDD");
                Map.Add(new Regex(@"\d{3}"), "DDDD");
                Map.Add(new Regex(@"\d{1,3}(?:st|nd|rd|th)"), "DDDo");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{1,3}"), "NA");
                Map.Add(new Regex(@"\d{3}"), "%j");
                Map.Add(new Regex(@"\d{1,3}(?:st|nd|rd|th)"), "NA");
            }
        }
    }
}
