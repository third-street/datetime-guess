namespace DateTime_Guess.Assigners
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using DateTime_Guess.Parsers;

    /// <summary>
    /// Assigners assign the appropriate format tokens (don't confuse these with generated tokens from input) to each corresponding token based on the meaning given to the token by the parser.
    /// Example: YYYY for a four digit year token.
    /// </summary>
    internal class Assigner
    {
        /// <summary>
        /// The format of the assigner.
        /// </summary>
        public readonly Format Format;

        /// <summary>
        /// A dictionary mapping a regex string for a section of the datetime to the format for that datetime.
        /// </summary>
        public readonly Dictionary<Regex, string> Map;

        /// <summary>
        /// The name of the assigner.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The type of the assigner.
        /// </summary>
        public readonly string Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assigner"/> class.
        /// </summary>
        /// <param name="name">The <see cref="Name"/> of the <see cref="Assigner"/>.</param>
        /// <param name="type">The <see cref="Type"/> of the <see cref="Assigner"/>.</param>
        /// <param name="format">The <see cref="Format"/> of the <see cref="Assigner"/>.</param>
        public Assigner(string name, string type, Format format)
        {
            Name = name;
            Type = type;
            Format = format;
            Map = new Dictionary<Regex, string>();
        }

        /// <summary>
        /// Assign a <see cref="Token"/> a format string.
        /// </summary>
        /// <param name="token">The <see cref="Token"/> to assign.</param>
        public virtual void Assign(Token token)
        {
            foreach (KeyValuePair<Regex, string> kvp in Map)
            {
                if (TestTokenType(token) && kvp.Key.Match(token.Value).Success)
                {
                    token.Format = kvp.Value;
                }
            }
        }

        /// <summary>
        /// Validate that the <see cref="Token.Type"/> is the same for two <see cref="Token"/>'s.
        /// </summary>
        /// <param name="token">The <see cref="Token"/> to validate.</param>
        /// <returns>Returns true if the <see cref="Token.Type"/>s match.</returns>
        public bool TestTokenType(Token token)
        {
            return token.Type == Type;
        }
    }
}
