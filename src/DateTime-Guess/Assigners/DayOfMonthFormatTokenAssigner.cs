namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Day of Month format.
    /// </summary>
    internal class DayOfMonthFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfMonthFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public DayOfMonthFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{1,2}"), "d");
                Map.Add(new Regex(@"\d{2}"), "dd");
                Map.Add(new Regex(@"\d{1,2}st"), "d'st'");
                Map.Add(new Regex(@"\d{1,2}nd"), "d'nd'");
                Map.Add(new Regex(@"\d{1,2}rd"), "d'rd'");
                Map.Add(new Regex(@"\d{1,2}th"), "d'th'");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{1,2}"), "D");
                Map.Add(new Regex(@"\d{2}"), "DD");
                Map.Add(new Regex(@"\d{1,2}(?:st|nd|rd|th)"), "Do");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{1,2}"), "%-e");
                Map.Add(new Regex(@"\d{2}"), "%d");
                Map.Add(new Regex(@"\d{1,2}(?:st|nd|rd|th)"), "%o");
            }
        }
    }
}