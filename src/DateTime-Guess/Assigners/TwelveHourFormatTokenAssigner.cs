namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Twelve Hour format.
    /// </summary>
    internal class TwelveHourFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwelveHourFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public TwelveHourFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"^([1-9]|1[0-2])$"), "h");
                Map.Add(new Regex(@"^(0\d|1[0-2])$"), "hh");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"^([1-9]|1[0-2])$"), "h");
                Map.Add(new Regex(@"^(0\d|1[0-2])$"), "hh");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"^([1-9]|1[0-2])$"), "%-l");
                Map.Add(new Regex(@"^(0\d|1[0-2])$"), "%I");
            }
        }
    }
}