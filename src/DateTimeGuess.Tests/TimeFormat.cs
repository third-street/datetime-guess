namespace DateTimeGuess.Tests
{
    using System;
    using System.Linq;
    using DateTimeGuess;
    using Xunit;

    /// <summary>
    /// Time formats.
    /// </summary>
    public class TimeFormat
    {
        [Fact]
        public void HoursAndMinsColonSep24HourFormat()
        {
            Assert.Equal("HH:mm", Guesser.GuessFormat("21:22", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm", Guesser.GuessFormat("21:22", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M", Guesser.GuessFormat("21:22", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursSingleDigitAndMinsCololSep24HourFormat()
        {
            Assert.Equal("H:mm", Guesser.GuessFormat("1:22", Format.Java).FirstOrDefault());
            Assert.Equal("H:mm", Guesser.GuessFormat("1:22", Format.Moment).FirstOrDefault());
            Assert.Equal("%-k:%M", Guesser.GuessFormat("1:22", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursAndMinsWithAbbreviatedTimezone24HourFormat()
        {
            Assert.Equal("HH:mm z", Guesser.GuessFormat("21:22 EST", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm z", Guesser.GuessFormat("21:22 EST", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M %Z", Guesser.GuessFormat("21:22 EST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursAndMinsDotSep24HourFormat()
        {
            Assert.Equal("HH.mm", Guesser.GuessFormat("21.22", Format.Java).FirstOrDefault());
            Assert.Equal("HH.mm", Guesser.GuessFormat("21.22", Format.Moment).FirstOrDefault());
            Assert.Equal("%H.%M", Guesser.GuessFormat("21.22", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsAndSecsColonSep24HourFormat()
        {
            Assert.Equal("HH:mm:ss", Guesser.GuessFormat("21:22:23", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss", Guesser.GuessFormat("21:22:23", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S", Guesser.GuessFormat("21:22:23", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsAndSecsColonSep24Hour_Timezone()
        {
            Assert.Equal("HH:mm:ssXXX", Guesser.GuessFormat("21:22:23+04:00", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ssZ", Guesser.GuessFormat("21:22:23+04:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S%:z", Guesser.GuessFormat("21:22:23+04:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsAndSecsColonSep24Hour_Delimiter_Timezone()
        {
            Assert.Equal("HH:mm:ss XXX", Guesser.GuessFormat("21:22:23 +04:00", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss Z", Guesser.GuessFormat("21:22:23 +04:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S %:z", Guesser.GuessFormat("21:22:23 +04:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsAndSecsDotSep24HourFormat()
        {
            Assert.Equal("HH.mm.ss", Guesser.GuessFormat("21.22.23", Format.Java).FirstOrDefault());
            Assert.Equal("HH.mm.ss", Guesser.GuessFormat("21.22.23", Format.Moment).FirstOrDefault());
            Assert.Equal("%H.%M.%S", Guesser.GuessFormat("21.22.23", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsSecsAndMillis24HourFormat()
        {
            Assert.Equal("HH:mm:ss.SSS", Guesser.GuessFormat("21:22:23.123", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss.SSS", Guesser.GuessFormat("21:22:23.123", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S.%L", Guesser.GuessFormat("21:22:23.123", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CompleteTime24HourFormat()
        {
            Assert.Equal("HH:mm:ss.SSS Z", Guesser.GuessFormat("21:22:23.123 +0000", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss.SSS ZZ", Guesser.GuessFormat("21:22:23.123 +0000", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S.%L %z", Guesser.GuessFormat("21:22:23.123 +0000", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CompleteTime24HourFormat_TimezoneX()
        {
            Assert.Equal("HH:mm:ss.SSS X", Guesser.GuessFormat("21:22:23.123 +00", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss.SSS Z", Guesser.GuessFormat("21:22:23.123 +00", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S.%L %:z", Guesser.GuessFormat("21:22:23.123 +00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CompleteTime24HourFormat_TimezoneXXX()
        {
            Assert.Equal("HH:mm:ss.SSS XXX", Guesser.GuessFormat("21:22:23.123 +00:00", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss.SSS Z", Guesser.GuessFormat("21:22:23.123 +00:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S.%L %:z", Guesser.GuessFormat("21:22:23.123 +00:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CompleteTime24HourFormat_TimezoneXXX_NoDelimiter()
        {
            Assert.Equal("HH:mm:ss.SSSXXX", Guesser.GuessFormat("21:22:23.123+00:00", Format.Java).FirstOrDefault());
            Assert.Equal("HH:mm:ss.SSSZ", Guesser.GuessFormat("21:22:23.123+00:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%H:%M:%S.%L%:z", Guesser.GuessFormat("21:22:23.123+00:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursAndMinsColonSep12HourFormatAM_PM()
        {
            Assert.Equal("hh:mm a", Guesser.GuessFormat("10:00 PM", Format.Java).FirstOrDefault());
            Assert.Equal("hh:mm A", Guesser.GuessFormat("10:00 PM", Format.Moment).FirstOrDefault());
            Assert.Equal("%I:%M %p", Guesser.GuessFormat("10:00 PM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursAndMinsColonSep12HourFormatam_pm()
        {
            Assert.Equal("hh:mm a", Guesser.GuessFormat("10:00 am", Format.Java).FirstOrDefault());
            Assert.Equal("hh:mm a", Guesser.GuessFormat("10:00 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%I:%M %P", Guesser.GuessFormat("10:00 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursAndMinsColonSep12HourFormatAM_PM_Timezone()
        {
            Assert.Equal("hh:mm a z", Guesser.GuessFormat("10:00 AM GMT", Format.Java).FirstOrDefault());
            Assert.Equal("hh:mm A z", Guesser.GuessFormat("10:00 AM GMT", Format.Moment).FirstOrDefault());
            Assert.Equal("%I:%M %p %Z", Guesser.GuessFormat("10:00 AM GMT", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsSecsColonSep12HourFormatam_pm()
        {
            Assert.Equal("hh:mm:ss a", Guesser.GuessFormat("10:00:59 am", Format.Java).FirstOrDefault());
            Assert.Equal("hh:mm:ss a", Guesser.GuessFormat("10:00:59 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%I:%M:%S %P", Guesser.GuessFormat("10:00:59 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursMinsSecsDotSep12HourFormatam_pm()
        {
            Assert.Equal("hh.mm.ss a", Guesser.GuessFormat("10.00.59 am", Format.Java).FirstOrDefault());
            Assert.Equal("hh.mm.ss a", Guesser.GuessFormat("10.00.59 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%I.%M.%S %P", Guesser.GuessFormat("10.00.59 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursDoubleDigit12HourFormatAM_PM()
        {
            Assert.Equal("hh a", Guesser.GuessFormat("10 PM", Format.Java).FirstOrDefault());
            Assert.Equal("hh A", Guesser.GuessFormat("10 PM", Format.Moment).FirstOrDefault());
            Assert.Equal("%I %p", Guesser.GuessFormat("10 PM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursDoubleDigitAndMeridiemWithoutDelimiter12HourFormatAM_PM()
        {
            Assert.Equal("hha", Guesser.GuessFormat("10PM", Format.Java).FirstOrDefault());
            Assert.Equal("hhA", Guesser.GuessFormat("10PM", Format.Moment).FirstOrDefault());
            Assert.Equal("%I%p", Guesser.GuessFormat("10PM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursSingleDigit12HourFormatAM_PM()
        {
            Assert.Equal("h a", Guesser.GuessFormat("5 PM", Format.Java).FirstOrDefault());
            Assert.Equal("h A", Guesser.GuessFormat("5 PM", Format.Moment).FirstOrDefault());
            Assert.Equal("%-l %p", Guesser.GuessFormat("5 PM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HoursSingleDigitAndMeridiemWithoutDelimiter12HourFormatAM_PM()
        {
            Assert.Equal("ha", Guesser.GuessFormat("5PM", Format.Java).FirstOrDefault());
            Assert.Equal("hA", Guesser.GuessFormat("5PM", Format.Moment).FirstOrDefault());
            Assert.Equal("%-l%p", Guesser.GuessFormat("5PM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void InvalidDate12HourFormatam_pm()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("13:00 am", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("13:00 am", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("13:00 am", Format.Linux));
        }
    }
}