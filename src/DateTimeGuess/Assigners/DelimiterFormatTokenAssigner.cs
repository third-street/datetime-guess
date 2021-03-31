namespace DateTimeGuess.Assigners
{
    using DateTimeGuess.Parsers;

    /// <summary>
    /// Get the Delimeter format.
    /// </summary>
    internal class DelimiterFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DelimiterFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public DelimiterFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
        }

        /// <inheritdoc/>
        public override Token Assign(Token token)
        {
            if (Format == Format.Java && token.Value == "T")
            {
                token.Format = $"'{token.Value}'";
            }

            return token;
        }
    }
}
