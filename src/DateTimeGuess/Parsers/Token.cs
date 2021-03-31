namespace DateTimeGuess.Parsers
{
    /// <summary>
    /// A token containing a section of the datetime string and the format for that section.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="value">The value of the token.</param>
        /// <param name="type">The type of the token.</param>
        public Token(string value, string type)
        {
            Format = string.Empty;
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the format for the token.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the token.
        /// </summary>
        public string Value { get; set; }
    }
}
