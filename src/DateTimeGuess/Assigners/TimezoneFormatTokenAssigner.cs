namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Timezone format.
    /// </summary>
    internal class TimezoneFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimezoneFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public TimezoneFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"^[+-]\d{2}:\d{2}$"), "XXX");
                Map.Add(new Regex(@"^[+-]\d{2}$"), "X");
                Map.Add(new Regex(@"[+-]\d{4}"), "Z");
                Map.Add(new Regex(@"Z"), "'Z'");
                Map.Add(new Regex(@"z"), "'z'");
                Map.Add(Guesser._javaTimezoneRegex, "z");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"[+-]\d{2}(?::\d{2})?"), "Z");
                Map.Add(new Regex(@"[+-]\d{4}"), "ZZ");
                Map.Add(new Regex(@"Z"), "[Z]");
                Map.Add(new Regex(@"z"), "[z]");
                Map.Add(Guesser._abbreviatedTimezoneRegex, "z");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"[+-]\d{2}(?::\d{2})?"), "%:z");
                Map.Add(new Regex(@"[+-]\d{4}"), "%z");
                Map.Add(new Regex(@"Z"), "Z");
                Map.Add(new Regex(@"z"), "z");
                Map.Add(Guesser._abbreviatedTimezoneRegex, "%Z");
            }
        }
    }
}