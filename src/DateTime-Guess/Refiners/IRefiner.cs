namespace DateTime_Guess.Refiners
{
    using System.Collections.Generic;

    /// <summary>
    /// Refiners refine the parsed results based on certain chosen heuristics in case the input matched multiple parsers.
    /// </summary>
    internal interface IRefiner
    {
        /// <summary>
        /// Gets the name of the refiner.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Refine the results to try and get an exact match.
        /// </summary>
        /// <param name="parsedResults">The results to refine.</param>
        /// <returns>Returns the refined results.</returns>
        public List<ParsedResult> Refine(List<ParsedResult> parsedResults);
    }
}
