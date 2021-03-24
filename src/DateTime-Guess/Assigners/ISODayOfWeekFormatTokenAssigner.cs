namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the ISO Day of the Week format.
    /// </summary>
    internal class ISODayOfWeekFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ISODayOfWeekFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public ISODayOfWeekFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"/[1-7]/"), "F");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"/[1-7]/"), "E");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"/[1-7]/"), "%u");
            }
        }
    }
}