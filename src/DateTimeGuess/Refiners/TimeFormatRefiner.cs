namespace DateTimeGuess.Refiners
{
    using System.Collections.Generic;

    /// <summary>
    /// Refine time formats.
    /// </summary>
    internal class TimeFormatRefiner : IRefiner
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeFormatRefiner"/> class.
        /// </summary>
        /// <param name="name">The name of the refiner.</param>
        public TimeFormatRefiner(string name)
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
            parsedResults.ForEach(r =>
            {
                bool meridiemExists = false;
                r.Tokens.ForEach(t =>
                {
                    if (t.Type == "meridiem")
                    {
                        meridiemExists = true;
                    }
                });

                if (meridiemExists)
                {
                    r.Tokens.ForEach(t =>
                    {
                        if (t.Type == "twentyFourHour")
                        {
                            t.Type = "twelveHour";
                        }
                    });
                }
            });

            return parsedResults;
        }
    }
}