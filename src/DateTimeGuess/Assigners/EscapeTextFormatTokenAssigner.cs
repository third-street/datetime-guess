namespace DateTimeGuess.Assigners
{
    using DateTimeGuess.Parsers;

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
                if (Format == Format.Java)
                {
                    token.Format = $"'{token.Value}'";
                }
                else if (Format == Format.Moment)
                {
                    token.Format = $"[{token.Value}]";
                }
                else
                {
                    token.Format = token.Value;
                }
            }

            return token;
        }
    }
}