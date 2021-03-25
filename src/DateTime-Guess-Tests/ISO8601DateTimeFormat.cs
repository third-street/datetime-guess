namespace DateTime_Guess_Tests
{
    using System.Linq;
    using DateTime_Guess;
    using Xunit;

    /// <summary>
    /// ISO 8601 extended date time formats.
    /// ISO 8601 basic date time formats.
    /// </summary>
    public class ISO8601DateTimeFormat
    {
        [Fact]
        public void CalendarDatePart()
        {
            Assert.Equal("YYYY-MM-DD", Guesser.GuessFormat("2020-10-10", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d", Guesser.GuessFormat("2020-10-10", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void MonthDatePart()
        {
            Assert.Equal("YYYY-MM", Guesser.GuessFormat("2020-10", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m", Guesser.GuessFormat("2020-10", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void WeekDatePart()
        {
            Assert.Equal("YYYY-[W]WW-E", Guesser.GuessFormat("2013-W06-5", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-W%U-%u", Guesser.GuessFormat("2013-W06-5", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void OrdinalDatePart()
        {
            Assert.Equal("YYYY-DDDD", Guesser.GuessFormat("2013-039", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%j", Guesser.GuessFormat("2013-039", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HourTimePartSeparatedByAT()
        {
            Assert.Equal("YYYY-MM-DDTHH", Guesser.GuessFormat("2013-02-08T09", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%dT%H", Guesser.GuessFormat("2013-02-08T09", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HourTimePartSeparatedByASpace()
        {
            Assert.Equal("YYYY-MM-DD HH", Guesser.GuessFormat("2013-02-08 09", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %H", Guesser.GuessFormat("2013-02-08 09", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HourAndMinuteTimePart()
        {
            Assert.Equal("YYYY-MM-DDTHH:mm", Guesser.GuessFormat("2013-02-08T09:30", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%dT%H:%M", Guesser.GuessFormat("2013-02-08T09:30", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HourMinuteAndSecondTimePart()
        {
            Assert.Equal("YYYY-MM-DDTHH:mm:ss", Guesser.GuessFormat("2013-02-08T09:30:26", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%dT%H:%M:%S", Guesser.GuessFormat("2013-02-08T09:30:26", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HourMinuteSecondAndMillisecondTimePart()
        {
            Assert.Equal("YYYY-MM-DDTHH:mm:ss.SSS", Guesser.GuessFormat("2013-02-08T09:30:26.123", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%dT%H:%M:%S.%L", Guesser.GuessFormat("2013-02-08T09:30:26.123", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void HourMinuteSecondAndMillisecondTimePartMillisecondsSeparatedByAComma()
        {
            Assert.Equal("YYYY-MM-DDTHH:mm:ss,SSS", Guesser.GuessFormat("2013-02-08T09:30:26,123", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%dT%H:%M:%S,%L", Guesser.GuessFormat("2013-02-08T09:30:26,123", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CalendarDatePartAndHourTimePart()
        {
            Assert.Equal("YYYY-MM-DD HH", Guesser.GuessFormat("2013-02-08 09", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %H", Guesser.GuessFormat("2013-02-08 09", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void WeekDatePartAndHourTimePart()
        {
            Assert.Equal("YYYY-[W]WW-E HH", Guesser.GuessFormat("2013-W06-5 09", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-W%U-%u %H", Guesser.GuessFormat("2013-W06-5 09", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void OrdinalDatePartAndHourTimePart()
        {
            Assert.Equal("YYYY-DDDD HH", Guesser.GuessFormat("2013-039 09", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%j %H", Guesser.GuessFormat("2013-039 09", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CalendarDateAndTimeWithHoursAndTimezon_Plus_HH_mm()
        {
            Assert.Equal("YYYY-MM-DD HHZ", Guesser.GuessFormat("2013-02-08 09+07:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %H%:z", Guesser.GuessFormat("2013-02-08 09+07:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CalendarDateAndTimeWithHoursAndTimezone_Minus_HH_mm()
        {
            Assert.Equal("YYYY-MM-DD HHZZ", Guesser.GuessFormat("2013-02-08 09-0100", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %H%z", Guesser.GuessFormat("2013-02-08 09-0100", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CalendarDateAndTimeWithHoursAndTimezoneZ()
        {
            Assert.Equal("YYYY-MM-DD HH[Z]", Guesser.GuessFormat("2013-02-08 09Z", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %HZ", Guesser.GuessFormat("2013-02-08 09Z", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CalendarDateAndFullTimeWithTimezone_Plus_HH_mm()
        {
            Assert.Equal("YYYY-MM-DD HH:mm:ss.SSSZ", Guesser.GuessFormat("2013-02-08 09:30:26.123+07:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %H:%M:%S.%L%:z", Guesser.GuessFormat("2013-02-08 09:30:26.123+07:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void CalendarDateAndFullTimeWithTimezone_Plus_HH()
        {
            Assert.Equal("YYYY-MM-DD HH:mm:ss.SSSZ", Guesser.GuessFormat("2013-02-08 09:30:26.123+07", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d %H:%M:%S.%L%:z", Guesser.GuessFormat("2013-02-08 09:30:26.123+07", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void BasicShortFullDate()
        {
            Assert.Equal("YYYYMMDD", Guesser.GuessFormat("20130208", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%d", Guesser.GuessFormat("20130208", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void BasicShortYearMonth()
        {
            Assert.Equal("YYYYMM", Guesser.GuessFormat("201303", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m", Guesser.GuessFormat("201303", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void BasicShortYearOnly()
        {
            Assert.Equal("YYYY", Guesser.GuessFormat("2013", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y", Guesser.GuessFormat("2013", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void BasicShortWeekWeekday()
        {
            Assert.Equal("YYYY[W]WWE", Guesser.GuessFormat("2013W065", Format.Moment).FirstOrDefault());
            Assert.Equal("%YW%U%u", Guesser.GuessFormat("2013W065", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void BasicShortWeekOnly()
        {
            Assert.Equal("YYYY[W]WW", Guesser.GuessFormat("2013W06", Format.Moment).FirstOrDefault());
            Assert.Equal("%YW%U", Guesser.GuessFormat("2013W06", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void BasicShortOrdinalDate_Year_Plus_Day_of_Year()
        {
            Assert.Equal("YYYYDDDD", Guesser.GuessFormat("2013050", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%j", Guesser.GuessFormat("2013050", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeUpToMSSeparatedByComma()
        {
            Assert.Equal("YYYYMMDDTHHmmss,SSS", Guesser.GuessFormat("20130208T080910,123", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%M%S,%L", Guesser.GuessFormat("20130208T080910,123", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeUpToMS()
        {
            Assert.Equal("YYYYMMDDTHHmmss.SSS", Guesser.GuessFormat("20130208T080910.123", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%M%S.%L", Guesser.GuessFormat("20130208T080910.123", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeUpToSeconds()
        {
            Assert.Equal("YYYYMMDDTHHmmss", Guesser.GuessFormat("20130208T080910", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%M%S", Guesser.GuessFormat("20130208T080910", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeUpToMinutes()
        {
            Assert.Equal("YYYYMMDDTHHmm", Guesser.GuessFormat("20130208T0809", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%M", Guesser.GuessFormat("20130208T0809", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeHoursOnly()
        {
            Assert.Equal("YYYYMMDDTHH", Guesser.GuessFormat("20130208T08", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H", Guesser.GuessFormat("20130208T08", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeWithHoursAndTimezone_PlusHH_mm()
        {
            Assert.Equal("YYYYMMDDTHHZ", Guesser.GuessFormat("20130208T09+07:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%:z", Guesser.GuessFormat("20130208T09+07:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeWithHoursAndTimezone_MinusHH_mm()
        {
            Assert.Equal("YYYYMMDDTHHZZ", Guesser.GuessFormat("20130208T09-0100", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%z", Guesser.GuessFormat("20130208T09-0100", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndTimeWithHoursAndTimezoneZ()
        {
            Assert.Equal("YYYYMMDDTHH[Z]", Guesser.GuessFormat("20130208T09Z", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%HZ", Guesser.GuessFormat("20130208T09Z", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndFullTimeWithTimezone_PlusHH_mm()
        {
            Assert.Equal("YYYYMMDDTHHmmss.SSSZ", Guesser.GuessFormat("20130208T093026.123+07:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%M%S.%L%:z", Guesser.GuessFormat("20130208T093026.123+07:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ShortDateAndFullTimeWithTimezone_PlusHH()
        {
            Assert.Equal("YYYYMMDDTHHmmss.SSSZ", Guesser.GuessFormat("20130208T093026.123+07", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y%m%dT%H%M%S.%L%:z", Guesser.GuessFormat("20130208T093026.123+07", Format.Linux).FirstOrDefault());
        }
    }
}