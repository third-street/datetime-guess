namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Meridiem format.
    /// </summary>
    internal class MeridiemFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeridiemFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public MeridiemFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"am|pm"), "a");
                Map.Add(new Regex(@"AM|PM"), "a");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"am|pm"), "a");
                Map.Add(new Regex(@"AM|PM"), "A");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"am|pm"), "%P");
                Map.Add(new Regex(@"AM|PM"), "%p");
            }
        }
    }
}