namespace DateTimeGuess.Refiners
{
    using System.Collections.Generic;

    /// <summary>
    /// Refine datetime formats.
    /// </summary>
    internal class StandardFormatParsersRefiner : IRefiner
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardFormatParsersRefiner"/> class.
        /// </summary>
        /// <param name="name">The name of the refiner.</param>
        public StandardFormatParsersRefiner(string name)
        {
            _name = name;
        }

        /// <inheritdoc/>
        public string Name
        {
            get { return _name; }
        }

        /// <inheritdoc/>
        public List<ParsedResult> Refine(List<ParsedResult> parsedResults)
        {
            List<ParsedResult> res = parsedResults.FindAll(r =>
                r.Parser == "ISO8601ExtendedDateTimeFormatParser" ||
                r.Parser == "ISO8601BasicDateTimeFormatParser" ||
                r.Parser == "RFC2822DateTimeFormatParser");

            if (res.Count == 0)
            {
                return parsedResults;
            }

            return res;
        }
    }
}
