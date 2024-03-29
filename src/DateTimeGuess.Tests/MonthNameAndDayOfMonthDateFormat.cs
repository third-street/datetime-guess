﻿namespace DateTimeGuess.Tests
{
    using System;
    using System.Linq;
    using DateTimeGuess;
    using Xunit;

    /// <summary>
    /// Month followed by day of month type dates
    /// </summary>
    public class MonthNameAndDayOfMonthDateFormat
    {
        [Fact]
        public void Mon_D()
        {
            Assert.Equal("MMM d", Guesser.GuessFormat("Jan 1", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D", Guesser.GuessFormat("Jan 1", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e", Guesser.GuessFormat("Jan 1", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_hh_mm_am_pm()
        {
            Assert.Equal("MMM d, hh:mm a", Guesser.GuessFormat("Jan 1, 10:00 am", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, hh:mm a", Guesser.GuessFormat("Jan 1, 10:00 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %I:%M %P", Guesser.GuessFormat("Jan 1, 10:00 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_h_am_pm()
        {
            Assert.Equal("MMM d, h a", Guesser.GuessFormat("Jan 1, 1 am", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, h a", Guesser.GuessFormat("Jan 1, 1 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %-l %P", Guesser.GuessFormat("Jan 1, 1 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_ham_pm()
        {
            Assert.Equal("MMM d, ha", Guesser.GuessFormat("Jan 1, 1am", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, ha", Guesser.GuessFormat("Jan 1, 1am", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %-l%P", Guesser.GuessFormat("Jan 1, 1am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_HH_mm()
        {
            Assert.Equal("MMM d, HH:mm", Guesser.GuessFormat("Jan 1, 10:00", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, HH:mm", Guesser.GuessFormat("Jan 1, 10:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %H:%M", Guesser.GuessFormat("Jan 1, 10:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_HH_mm_12_hours()
        {
            Assert.Equal("MMM d, HH:mm", Guesser.GuessFormat("Jan 1, 13:00", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, HH:mm", Guesser.GuessFormat("Jan 1, 13:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %H:%M", Guesser.GuessFormat("Jan 1, 13:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_hh_mm_ss_AM_PM()
        {
            Assert.Equal("MMM d, hh:mm:ss a", Guesser.GuessFormat("Jan 1, 10:00:59 AM", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, hh:mm:ss A", Guesser.GuessFormat("Jan 1, 10:00:59 AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %I:%M:%S %p", Guesser.GuessFormat("Jan 1, 10:00:59 AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_D_HH_mm_ss()
        {
            Assert.Equal("MMM d, HH:mm:ss", Guesser.GuessFormat("Jan 1, 10:00:59", Format.Java).FirstOrDefault());
            Assert.Equal("MMM D, HH:mm:ss", Guesser.GuessFormat("Jan 1, 10:00:59", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %-e, %H:%M:%S", Guesser.GuessFormat("Jan 1, 10:00:59", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Mon_DD()
        {
            Assert.Equal("MMM dd", Guesser.GuessFormat("Jan 01", Format.Java).FirstOrDefault());
            Assert.Equal("MMM DD", Guesser.GuessFormat("Jan 01", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %d", Guesser.GuessFormat("Jan 01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void ParseValidDayOfMonth()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Jan 32", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Jan 32", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Jan 32", Format.Linux));
        }

        [Fact]
        public void DayOfMonthWithOrdinal()
        {
            Assert.Equal("MMM d'st'", Guesser.GuessFormat("Jan 1st", Format.Java).FirstOrDefault());
            Assert.Equal("MMM Do", Guesser.GuessFormat("Jan 1st", Format.Moment).FirstOrDefault());
            Assert.Equal("%b %o", Guesser.GuessFormat("Jan 1st", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameWithD()
        {
            Assert.Equal("MMMM d", Guesser.GuessFormat("January 1", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM D", Guesser.GuessFormat("January 1", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %-e", Guesser.GuessFormat("January 1", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameWithDD()
        {
            Assert.Equal("MMMM dd", Guesser.GuessFormat("January 31", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM DD", Guesser.GuessFormat("January 31", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %d", Guesser.GuessFormat("January 31", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameDayOfMonthWithOrdinal()
        {
            Assert.Equal("MMMM dd'st'", Guesser.GuessFormat("January 31st", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do", Guesser.GuessFormat("January 31st", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o", Guesser.GuessFormat("January 31st", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullMonthNameDayOfMonthWithOrdinal_hhAM_PM()
        {
            Assert.Equal("MMMM dd'st', hha", Guesser.GuessFormat("January 31st, 10AM", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do, hhA", Guesser.GuessFormat("January 31st, 10AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o, %I%p", Guesser.GuessFormat("January 31st, 10AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendedDelimeters()
        {
            Assert.Equal("MMMM dd'st', ", Guesser.GuessFormat("January 31st, ", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do, ", Guesser.GuessFormat("January 31st, ", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o, ", Guesser.GuessFormat("January 31st, ", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void PrependDayOfWeekShortest()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Su, January 31st", Format.Java));
            Assert.Equal("dd, MMMM Do", Guesser.GuessFormat("Su, January 31st", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("Su, January 31st", Format.Linux));
        }

        [Fact]
        public void PrependDayOfWeekShort()
        {
            Assert.Equal("E, MMMM dd'st'", Guesser.GuessFormat("Sun, January 31st", Format.Java).FirstOrDefault());
            Assert.Equal("ddd, MMMM Do", Guesser.GuessFormat("Sun, January 31st", Format.Moment).FirstOrDefault());
            Assert.Equal("%a, %B %o", Guesser.GuessFormat("Sun, January 31st", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void PrependDayOfWeekFull()
        {
            Assert.Equal("EEEE, MMMM dd'st'", Guesser.GuessFormat("Sunday, January 31st", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, MMMM Do", Guesser.GuessFormat("Sunday, January 31st", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %B %o", Guesser.GuessFormat("Sunday, January 31st", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYearShort()
        {
            Assert.Equal("MMMM dd'st', yy", Guesser.GuessFormat("January 31st, 20", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do, YY", Guesser.GuessFormat("January 31st, 20", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o, %y", Guesser.GuessFormat("January 31st, 20", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYearShort_hh_mm_am_pm()
        {
            Assert.Equal("MMMM dd'st', yy hh:mm a", Guesser.GuessFormat("January 31st, 20 10:00 am", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do, YY hh:mm a", Guesser.GuessFormat("January 31st, 20 10:00 am", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o, %y %I:%M %P", Guesser.GuessFormat("January 31st, 20 10:00 am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYearShort_HH_mm()
        {
            Assert.Equal("MMMM dd'st', yy HH:mm", Guesser.GuessFormat("January 31st, 20 10:00", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do, YY HH:mm", Guesser.GuessFormat("January 31st, 20 10:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o, %y %H:%M", Guesser.GuessFormat("January 31st, 20 10:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void AppendYear()
        {
            Assert.Equal("MMMM dd'st', yyyy", Guesser.GuessFormat("January 31st, 2020", Format.Java).FirstOrDefault());
            Assert.Equal("MMMM Do, YYYY", Guesser.GuessFormat("January 31st, 2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%B %o, %Y", Guesser.GuessFormat("January 31st, 2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate()
        {
            Assert.Equal("EEEE, MMMM dd'st' yyyy", Guesser.GuessFormat("Sunday, January 31st 2020", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, MMMM Do YYYY", Guesser.GuessFormat("Sunday, January 31st 2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %B %o %Y", Guesser.GuessFormat("Sunday, January 31st 2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate_hh_mmAM_PM()
        {
            Assert.Equal("EEEE, MMMM dd'st' yyyy, hh:mma", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00AM", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, MMMM Do YYYY, hh:mmA", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00AM", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %B %o %Y, %I:%M%p", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00AM", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDate_HH_mm()
        {
            Assert.Equal("EEEE, MMMM dd'st' yyyy, HH:mm", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, MMMM Do YYYY, HH:mm", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %B %o %Y, %H:%M", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void FullDateWithAbbreviatedTimezone()
        {
            Assert.Equal("EEEE, MMMM dd'st' yyyy, HH:mm z", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00 PDT", Format.Java).FirstOrDefault());
            Assert.Equal("dddd, MMMM Do YYYY, HH:mm z", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00 PDT", Format.Moment).FirstOrDefault());
            Assert.Equal("%A, %B %o %Y, %H:%M %Z", Guesser.GuessFormat("Sunday, January 31st 2020, 09:00 PDT", Format.Linux).FirstOrDefault());
        }
    }
}