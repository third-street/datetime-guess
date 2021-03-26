namespace DateTime_Guess.Parsers
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Parsers break the input into individual tokens, giving meaning to each token (whether it's year, month, day...).
    /// </summary>
    internal interface IParser
    {
        /// <summary>
        /// Gets the name of the parser.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the pattern for the parser.
        /// </summary>
        public Regex Pattern { get; }

        /// <summary>
        /// Parse the input into individual tokens.
        /// </summary>
        /// <param name="datetime">The datetime to parse.</param>
        /// <returns>Returns the parsed <see cref="Token"/>s.</returns>
        public ParsedResult Parse(string datetime);
    }
}
