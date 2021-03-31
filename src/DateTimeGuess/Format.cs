namespace DateTimeGuess
{
    /// <summary>
    /// The format that the guess should return in. Java is the default.
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Java
        /// https://docs.oracle.com/javase/8/docs/api/java/time/format/DateTimeFormatter.html
        /// </summary>
        Java,

        /// <summary>
        /// Linux strftime
        /// https://man7.org/linux/man-pages/man3/strftime.3.html
        /// </summary>
        Linux,

        /// <summary>
        /// Moment.js
        /// https://momentjs.com/docs/#/displaying/
        /// </summary>
        Moment,
    }
}
