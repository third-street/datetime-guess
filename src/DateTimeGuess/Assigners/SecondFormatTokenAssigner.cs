﻿namespace DateTimeGuess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Second format.
    /// </summary>
    internal class SecondFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public SecondFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"\d{1,2}"), "s");
                Map.Add(new Regex(@"\d{2}"), "ss");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"\d{1,2}"), "s");
                Map.Add(new Regex(@"\d{2}"), "ss");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"\d{1,2}"), "NA");
                Map.Add(new Regex(@"\d{2}"), "%S");
            }
        }
    }
}