namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Twenty Four Hour format.
    /// </summary>
    internal class TwentyFourHourFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyFourHourFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public TwentyFourHourFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"^(\d|1\d|2[0-3])$"), "H");
                Map.Add(new Regex(@"^([0-1]\d|2[0-3])$"), "HH");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"^(\d|1\d|2[0-3])$"), "H");
                Map.Add(new Regex(@"^([0-1]\d|2[0-3])$"), "HH");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"^(\d|1\d|2[0-3])$"), "%-k");
                Map.Add(new Regex(@"^([0-1]\d|2[0-3])$"), "%H");
            }
        }
    }
}