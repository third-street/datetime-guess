namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Month format.
    /// </summary>
    internal class MonthFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public MonthFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{1,2}"), "M");
                Map.Add(new Regex(@"\d{1,2}st"), "M'st'");
                Map.Add(new Regex(@"\d{1,2}nd"), "M'nd'");
                Map.Add(new Regex(@"\d{1,2}rd"), "M'rd'");
                Map.Add(new Regex(@"\d{1,2}th"), "M'th'");
                Map.Add(new Regex(@"\d{2}"), "MM");
                Map.Add(new Regex(@"\d{1,2}st"), "MM'st'");
                Map.Add(new Regex(@"\d{1,2}nd"), "MM'nd'");
                Map.Add(new Regex(@"\d{1,2}rd"), "MM'rd'");
                Map.Add(new Regex(@"\d{1,2}th"), "MM'th'");
                Map.Add(new Regex(@"^(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)$"), "MMM");
                Map.Add(new Regex(@"^(January|February|March|April|May|June|July|August|September|October|November|December)$"), "MMMM");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{1,2}"), "M");
                Map.Add(new Regex(@"\d{2}"), "MM");
                Map.Add(new Regex(@"\d{1,2}(?:st|nd|rd|th)"), "Mo");
                Map.Add(new Regex(@"^(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)$"), "MMM");
                Map.Add(new Regex(@"^(January|February|March|April|May|June|July|August|September|October|November|December)$"), "MMMM");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{1,2}"), "NA");
                Map.Add(new Regex(@"\d{2}"), "%m");
                Map.Add(new Regex(@"\d{1,2}(?:st|nd|rd|th)"), "NA");
                Map.Add(new Regex(@"^(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)$"), "%b");
                Map.Add(new Regex(@"^(January|February|March|April|May|June|July|August|September|October|November|December)$"), "%B");
            }
        }
    }
}