namespace DateTime_Guess.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Parsers break the input into individual tokens, giving meaning to each token (whether it's year, month, day...).
    /// </summary>
    internal class Parser : IParser
    {
        private readonly string _name;
        private readonly Regex _pattern;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="name">The <see cref="IParser.Name"/> of the <see cref="IParser"/>.</param>
        /// <param name="pattern">The <see cref="IParser.Pattern"/> of the <see cref="IParser"/>.</param>
        public Parser(string name, Regex pattern)
        {
            _name = name;
            _pattern = pattern;
        }

        /// <inheritdoc/>
        public string Name
        {
            get { return _name; }
        }

        /// <inheritdoc/>
        public Regex Pattern
        {
            get { return _pattern; }
        }

        /// <inheritdoc/>
        public ParsedResult Parse(string datetime)
        {
            Match match = _pattern.Match(datetime);
            if (!match.Success || match.Groups.Count == 0)
            {
                return null;
            }

            List<Token> tokens = new();
            foreach (Group group in match.Groups)
            {
                if (!string.IsNullOrEmpty(group.Value) && group.Name != "0")
                {
                    tokens.Add(new Token(group.Value, new Regex(@"delim\d+").Match(group.Name).Success ? "delimeter" : group.Name));
                }
            }

            return new ParsedResult
            {
                Index = match.Index,
                Parser = Name,
                Tokens = tokens,
            };
        }
    }
}