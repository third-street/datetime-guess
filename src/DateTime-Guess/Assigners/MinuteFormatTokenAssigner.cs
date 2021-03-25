namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Minute format.
    /// </summary>
    internal class MinuteFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public MinuteFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{1,2}"), "m");
                Map.Add(new Regex(@"\d{2}"), "mm");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{1,2}"), "m");
                Map.Add(new Regex(@"\d{2}"), "mm");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{1,2}"), "NA");
                Map.Add(new Regex(@"\d{2}"), "%M");
            }
        }
    }
}