namespace DateTimeGuess
{
    using System.Collections.Generic;
    using DateTimeGuess.Parsers;

    /// <summary>
    /// A result from parsing a datetime string.
    /// </summary>
    public class ParsedResult
    {
        /// <summary>
        /// Gets or sets the index of the result.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Parser"/> that was used.
        /// </summary>
        public string Parser { get; set; }

        /// <summary>
        /// Gets or sets a list of <see cref="Token"/>s generated.
        /// </summary>
        public List<Token> Tokens { get; set; }
    }
}
