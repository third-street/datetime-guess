namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Millisecond format.
    /// </summary>
    internal class MillisecondFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MillisecondFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public MillisecondFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d"), "S");
                Map.Add(new Regex(@"\d{2}"), "SS");
                Map.Add(new Regex(@"\d{3}"), "SSS");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d"), "S");
                Map.Add(new Regex(@"\d{2}"), "SS");
                Map.Add(new Regex(@"\d{3}"), "SSS");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d"), "NA");
                Map.Add(new Regex(@"\d{2}"), "NA");
                Map.Add(new Regex(@"\d{3}"), "%L");
            }
        }
    }
}