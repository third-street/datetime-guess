namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Year format.
    /// </summary>
    internal class YearFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YearFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public YearFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{2}"), "yy");
                Map.Add(new Regex(@"\d{4}"), "yyyy");
                Map.Add(new Regex(@"[+-]\d{6}"), "NA");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{2}"), "YY");
                Map.Add(new Regex(@"\d{4}"), "YYYY");
                Map.Add(new Regex(@"[+-]\d{6}"), "YYYYYY");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{2}"), "%y");
                Map.Add(new Regex(@"\d{4}"), "%Y");
                Map.Add(new Regex(@"[+-]\d{6}"), "NA");
            }
        }
    }
}