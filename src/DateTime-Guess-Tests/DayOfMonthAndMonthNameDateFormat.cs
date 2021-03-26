namespace DateTime_Guess_Tests
{
    using System;
    using System.Linq;
    using DateTime_Guess;
    using Xunit;

    /// <summary>
    /// Day of month followed by month name type dates.
    /// </summary>
    public class DayOfMonthAndMonthNameDateFormat
    {
        [Fact]
        public void D_Mon()
        {
            Assert.Equal("d MMM", Guesser.GuessFormat("1 Jan", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM", Guesser.GuessFormat("1 Jan", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b", Guesser.GuessFormat("1 Jan", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void D_Mon_hh_mm_am_pm()
        {
            Assert.Equal("d MMM, hh:mm a", Guesser.GuessFormat("1 Jan, 10:00 am", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM, hh:mm a", Guesser.GuessFormat("1 Jan, 10:00 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b, %I:%M %P", Guesser.GuessFormat("1 Jan, 10:00 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void D_Mon_h_am_pm()
        {
            Assert.Equal("d MMM, h a", Guesser.GuessFormat("1 Jan, 1 am", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM, h a", Guesser.GuessFormat("1 Jan, 1 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b, %-l %P", Guesser.GuessFormat("1 Jan, 1 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void D_Mon_ham_pm()
        {
            Assert.Equal("d MMM, ha", Guesser.GuessFormat("1 Jan, 1am", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM, ha", Guesser.GuessFormat("1 Jan, 1am", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b, %-l%P", Guesser.GuessFormat("1 Jan, 1am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_HH_mm_Over_12_hours()
        {
            Assert.Equal("d MMM, HH:mm", Guesser.GuessFormat("1 Jan, 13:00", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM, HH:mm", Guesser.GuessFormat("1 Jan, 13:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b, %H:%M", Guesser.GuessFormat("1 Jan, 13:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void D_Mon_hh_mm_ss_AM_PM()
        {
            Assert.Equal("d MMM, hh:mm:ss a", Guesser.GuessFormat("1 Jan, 10:00:59 AM", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM, hh:mm:ss A", Guesser.GuessFormat("1 Jan, 10:00:59 AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b, %I:%M:%S %p", Guesser.GuessFormat("1 Jan, 10:00:59 AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_HH_mm_ss()
        {
            Assert.Equal("d MMM, HH:mm:ss", Guesser.GuessFormat("1 Jan, 10:00:59", Format.Java).FirstOrDefault());
            Assert.Equal("D MMM, HH:mm:ss", Guesser.GuessFormat("1 Jan, 10:00:59", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %b, %H:%M:%S", Guesser.GuessFormat("1 Jan, 10:00:59", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void DD_Mon()
        {
            Assert.Equal("dd MMM", Guesser.GuessFormat("01 Jan", Format.Java).FirstOrDefault());
            Assert.Equal("DD MMM", Guesser.GuessFormat("01 Jan", Format.Moment).FirstOrDefault());
            Assert.Equal("%d %b", Guesser.GuessFormat("01 Jan", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ParseValidDayOfMonth()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("32 Jan", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("32 Jan", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("32 Jan", Format.Linux));
        }

        [Fact]
        public void DayOfMonthWithOrdinal()
        {
            Assert.Equal("d'st' MMM", Guesser.GuessFormat("1st Jan", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMM", Guesser.GuessFormat("1st Jan", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %b", Guesser.GuessFormat("1st Jan", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameWithD()
        {
            Assert.Equal("d MMMM", Guesser.GuessFormat("1 January", Format.Java).FirstOrDefault());
            Assert.Equal("D MMMM", Guesser.GuessFormat("1 January", Format.Moment).FirstOrDefault());
            Assert.Equal("%-e %B", Guesser.GuessFormat("1 January", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameWithDD()
        {
            Assert.Equal("dd MMMM", Guesser.GuessFormat("31 January", Format.Java).FirstOrDefault());
            Assert.Equal("DD MMMM", Guesser.GuessFormat("31 January", Format.Moment).FirstOrDefault());
            Assert.Equal("%d %B", Guesser.GuessFormat("31 January", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameDayOfMonthWithOrdinal()
        {
            Assert.Equal("dd'st' MMMM", Guesser.GuessFormat("31st January", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM", Guesser.GuessFormat("31st January", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B", Guesser.GuessFormat("31st January", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameDayOfMonthWithOrdinal_hhAM_PM()
        {
            Assert.Equal("dd'st' MMMM, hha", Guesser.GuessFormat("31st January, 10AM", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, hhA", Guesser.GuessFormat("31st January, 10AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, %I%p", Guesser.GuessFormat("31st January, 10AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameDayOfMonthWithordinal_hAM_PM()
        {
            Assert.Equal("dd'st' MMMM, ha", Guesser.GuessFormat("31st January, 1AM", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, hA", Guesser.GuessFormat("31st January, 1AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, %-l%p", Guesser.GuessFormat("31st January, 1AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendedDelimeters()
        {
            Assert.Equal("dd'st' MMMM, ", Guesser.GuessFormat("31st January, ", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, ", Guesser.GuessFormat("31st January, ", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, ", Guesser.GuessFormat("31st January, ", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void PrependDayOfWeekShortest()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Su, 31st January", Format.Java));
            Assert.Equal("dd, Do MMMM", Guesser.GuessFormat("Su, 31st January", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Su, 31st January", Format.Linux));
        }

        [Fact]
        public void PrependDayOfWeekShort()
        {
            Assert.Equal("E, dd'st' MMMM", Guesser.GuessFormat("Sun, 31st January", Format.Java).FirstOrDefault());
            Assert.Equal("ddd, Do MMMM", Guesser.GuessFormat("Sun, 31st January", Format.Moment).FirstOrDefault());
            Assert.Equal("%a, %o %B", Guesser.GuessFormat("Sun, 31st January", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void PrependDayOfWeekFull()
        {
            Assert.Equal("EEEE, dd'st' MMMM", Guesser.GuessFormat("Sunday, 31st January", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, Do MMMM", Guesser.GuessFormat("Sunday, 31st January", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %o %B", Guesser.GuessFormat("Sunday, 31st January", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYearShort()
        {
            Assert.Equal("dd'st' MMMM, yy", Guesser.GuessFormat("31st January, 20", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, YY", Guesser.GuessFormat("31st January, 20", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, %y", Guesser.GuessFormat("31st January, 20", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYearShort_hh_mm_am_pm()
        {
            Assert.Equal("dd'st' MMMM, yy hh:mm a", Guesser.GuessFormat("31st January, 20 10:00 am", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, YY hh:mm a", Guesser.GuessFormat("31st January, 20 10:00 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, %y %I:%M %P", Guesser.GuessFormat("31st January, 20 10:00 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYearShort_HH_mm()
        {
            Assert.Equal("dd'st' MMMM, yy HH:mm", Guesser.GuessFormat("31st January, 20 10:00", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, YY HH:mm", Guesser.GuessFormat("31st January, 20 10:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, %y %H:%M", Guesser.GuessFormat("31st January, 20 10:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYear()
        {
            Assert.Equal("dd'st' MMMM, yyyy", Guesser.GuessFormat("31st January, 2020", Format.Java).FirstOrDefault());
            Assert.Equal("Do MMMM, YYYY", Guesser.GuessFormat("31st January, 2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%o %B, %Y", Guesser.GuessFormat("31st January, 2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate()
        {
            Assert.Equal("EEEE, dd'st' MMMM yyyy", Guesser.GuessFormat("Sunday, 31st January 2020", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, Do MMMM YYYY", Guesser.GuessFormat("Sunday, 31st January 2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %o %B %Y", Guesser.GuessFormat("Sunday, 31st January 2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate_hhAM_PM()
        {
            Assert.Equal("EEEE, dd'st' MMMM yyyy, hh:mma", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00AM", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, Do MMMM YYYY, hh:mmA", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %o %B %Y, %I:%M%p", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate_hhAM_P_2()
        {
            Assert.Equal("EEEE, dd'st' MMMM yyyy, ha", Guesser.GuessFormat("Sunday, 31st January 2020, 9AM", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, Do MMMM YYYY, hA", Guesser.GuessFormat("Sunday, 31st January 2020, 9AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %o %B %Y, %-l%p", Guesser.GuessFormat("Sunday, 31st January 2020, 9AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate_HH_mm()
        {
            Assert.Equal("EEEE, dd'st' MMMM yyyy, HH:mm", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, Do MMMM YYYY, HH:mm", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %o %B %Y, %H:%M", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDateWithAbbreviatedTimezone()
        {
            Assert.Equal("EEEE, dd'st' MMMM yyyy, HH:mm z", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00 IST", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, Do MMMM YYYY, HH:mm z", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00 IST", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %o %B %Y, %H:%M %Z", Guesser.GuessFormat("Sunday, 31st January 2020, 09:00 IST", Format.Linux).FirstOrDefault());
        }
    }
}