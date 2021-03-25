namespace DateTime_Guess.Assigners
{
    using DateTime_Guess.Parsers;

    /// <summary>
    /// Get the Escape Text Character format.
    /// </summary>
    internal class EscapeTextFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EscapeTextFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public EscapeTextFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
        }

        /// <inheritdoc/>
        public override Token Assign(Token token)
        {
            if (TestTokenType(token))
            {
                token.Format = (Format == Format.Moment) ? $"[{token.Value}]" : token.Value;
            }

            return token;
        }
    }
}