namespace DateTimeGuess.Tests
{
    using System.Linq;
    using DateTimeGuess;
    using Xunit;

    /// <summary>
    /// RFC 2822 date time formats.
    /// </summary>
    public class RFC2822DateTimeFormat
    {
        [Fact]
        public void CompleteDateAndTime()
        {
            Assert.Equal("E, dd MMM yyyy HH:mm:ss Z", Guesser.GuessFormat("Mon, 06 Mar 2017 21:22:23 +0000", Format.Java).FirstOrDefault());
            Assert.Equal("ddd, DD MMM YYYY HH:mm:ss ZZ", Guesser.GuessFormat("Mon, 06 Mar 2017 21:22:23 +0000", Format.Moment).FirstOrDefault());
            Assert.Equal("%a, %d %b %Y %H:%M:%S %z", Guesser.GuessFormat("Mon, 06 Mar 2017 21:22:23 +0000", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void OmitCommaAfterDayOfWeek()
        {
            Assert.Equal("E dd MMM yyyy HH:mm:ss 'z'", Guesser.GuessFormat("Mon 06 Mar 2017 21:22:23 z", Format.Java).FirstOrDefault());
            Assert.Equal("ddd DD MMM YYYY HH:mm:ss [z]", Guesser.GuessFormat("Mon 06 Mar 2017 21:22:23 z", Format.Moment).FirstOrDefault());
            Assert.Equal("%a %d %b %Y %H:%M:%S z", Guesser.GuessFormat("Mon 06 Mar 2017 21:22:23 z", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void OmitDayOfWeek()
        {
            Assert.Equal("dd MMM yyyy HH:mm:ss 'Z'", Guesser.GuessFormat("06 Mar 2017 21:22:23 Z", Format.Java).FirstOrDefault());
            Assert.Equal("DD MMM YYYY HH:mm:ss [Z]", Guesser.GuessFormat("06 Mar 2017 21:22:23 Z", Format.Moment).FirstOrDefault());
            Assert.Equal("%d %b %Y %H:%M:%S Z", Guesser.GuessFormat("06 Mar 2017 21:22:23 Z", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void SingleDigitDayOfMonth()
        {
            Assert.Equal("d MMM yyyy HH:mm:ss z", Guesser.GuessFormat("6 Mar 2017 21:22:23 GMT", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM YYYY HH:mm:ss z", Guesser.GuessFormat("6 Mar 2017 21:22:23 GMT", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b %Y %H:%M:%S %Z", Guesser.GuessFormat("6 Mar 2017 21:22:23 GMT", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void TwoDigitYear()
        {
            Assert.Equal("d MMM yy HH:mm:ss z", Guesser.GuessFormat("6 Mar 17 21:22:23 UTC", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM YY HH:mm:ss z", Guesser.GuessFormat("6 Mar 17 21:22:23 UT", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b %y %H:%M:%S %Z", Guesser.GuessFormat("6 Mar 17 21:22:23 UT", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void OmitSecondsFromTime()
        {
            Assert.Equal("d MMM yy HH:mm z", Guesser.GuessFormat("6 Mar 17 21:22 UTC", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM YY HH:mm z", Guesser.GuessFormat("6 Mar 17 21:22 UT", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b %y %H:%M %Z", Guesser.GuessFormat("6 Mar 17 21:22 UT", Format.Linux).FirstOrDefault());
        }
    }
}