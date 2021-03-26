namespace DateTime_Guess_Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DateTime_Guess;
    using Xunit;

    /// <summary>
    /// Slash, dot or dash delimited date formats.
    /// </summary>
    public class SlashDelimitedDateFormat
    {
        [Fact]
        public void Slash_YYYY_MM_DD()
        {
            Assert.Equal("yyyy/MM/dd", Guesser.GuessFormat("2020/01/01", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/MM/DD", Guesser.GuessFormat("2020/01/01", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y/%m/%d", Guesser.GuessFormat("2020/01/01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YYYY_MM_DD_HH_mm_z()
        {
            Assert.Equal("yyyy/MM/dd HH:mm z", Guesser.GuessFormat("2020/01/01 17:00 IST", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/MM/DD HH:mm z", Guesser.GuessFormat("2020/01/01 17:00 IST", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y/%m/%d %H:%M %Z", Guesser.GuessFormat("2020/01/01 17:00 IST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YYYY_MM_DD_hh_mm_A_z()
        {
            Assert.Equal("yyyy/MM/dd hh:mm a z", Guesser.GuessFormat("2020/01/01 10:00 AM IST", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/MM/DD hh:mm A z", Guesser.GuessFormat("2020/01/01 10:00 AM IST", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y/%m/%d %I:%M %p %Z", Guesser.GuessFormat("2020/01/01 10:00 AM IST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YYYY_MM_DD_h_A_z()
        {
            Assert.Equal("yyyy/MM/dd h a z", Guesser.GuessFormat("2020/01/01 1 AM IST", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/MM/DD h A z", Guesser.GuessFormat("2020/01/01 1 AM IST", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y/%m/%d %-l %p %Z", Guesser.GuessFormat("2020/01/01 1 AM IST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YYYY_MM_DD_hA_z()
        {
            Assert.Equal("yyyy/MM/dd ha z", Guesser.GuessFormat("2020/01/01 1AM IST", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/MM/DD hA z", Guesser.GuessFormat("2020/01/01 1AM IST", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y/%m/%d %-l%p %Z", Guesser.GuessFormat("2020/01/01 1AM IST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dot_YYYY_MM_DD()
        {
            Assert.Equal("yyyy.MM.dd", Guesser.GuessFormat("2020.01.01", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY.MM.DD", Guesser.GuessFormat("2020.01.01", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y.%m.%d", Guesser.GuessFormat("2020.01.01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_YYYY_MM_DD()
        {
            Assert.Equal("yyyy-MM-dd", Guesser.GuessFormat("2020-01-01", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY-MM-DD", Guesser.GuessFormat("2020-01-01", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m-%d", Guesser.GuessFormat("2020-01-01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YYYY_MM()
        {
            Assert.Equal("yyyy/MM", Guesser.GuessFormat("2020/01", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/MM", Guesser.GuessFormat("2020/01", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y/%m", Guesser.GuessFormat("2020/01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dot_YYYY_MM()
        {
            Assert.Equal("yyyy.MM", Guesser.GuessFormat("2020.01", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY.MM", Guesser.GuessFormat("2020.01", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y.%m", Guesser.GuessFormat("2020.01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_YYYY_MM()
        {
            Assert.Equal("yyyy-MM", Guesser.GuessFormat("2020-01", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY-MM", Guesser.GuessFormat("2020-01", Format.Moment).FirstOrDefault());
            Assert.Equal("%Y-%m", Guesser.GuessFormat("2020-01", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YYYY_M_D()
        {
            Assert.Equal("yyyy/M/d", Guesser.GuessFormat("2020/1/1", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/M/D", Guesser.GuessFormat("2020/1/1", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/1/1", Format.Linux));
        }

        [Fact]
        public void Dot_YYYY_M_D()
        {
            Assert.Equal("yyyy.M.d", Guesser.GuessFormat("2020.1.1", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY.M.D", Guesser.GuessFormat("2020.1.1", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020.1.1", Format.Linux));
        }

        [Fact]
        public void Dash_YYYY_M_D()
        {
            Assert.Equal("yyyy-M-d", Guesser.GuessFormat("2020-1-1", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY-M-D", Guesser.GuessFormat("2020-1-1", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020-1-1", Format.Linux));
        }

        [Fact]
        public void Slash_YYYY_M()
        {
            Assert.Equal("yyyy/M", Guesser.GuessFormat("2020/1", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY/M", Guesser.GuessFormat("2020/1", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/1", Format.Linux));
        }

        [Fact]
        public void Dot_YYYY_M()
        {
            Assert.Equal("yyyy.M", Guesser.GuessFormat("2020.1", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY.M", Guesser.GuessFormat("2020.1", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020.1", Format.Linux));
        }

        [Fact]
        public void Dash_YYYY_M()
        {
            Assert.Equal("yyyy-M", Guesser.GuessFormat("2020-1", Format.Java).FirstOrDefault());
            Assert.Equal("YYYY-M", Guesser.GuessFormat("2020-1", Format.Moment).FirstOrDefault());
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020-1", Format.Linux));
        }

        [Fact]
        public void ErrorOnMonthOverflow()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/01", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/01", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/01", Format.Linux));
        }

        [Fact]
        public void ErrorOnMonthUnderflow()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/0/01", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/0/01", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/0/01", Format.Linux));
        }

        [Fact]
        public void ErrorOnDayOvererflow()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/32", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/32", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/32", Format.Linux));
        }

        [Fact]
        public void ErrorOnDayUnderflow()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/0", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/0", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13/0", Format.Linux));
        }

        [Fact]
        public void ErrorOnMonthUnderflowShortDate()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/00", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/00", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/00", Format.Linux));
        }

        [Fact]
        public void ErrorOnMonthOverflowShortDate()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("2020/13", Format.Linux));
        }

        // MM can be in [01, 12] | M can be in [1, 12]
        // DD can be in [01, 31] | D can be in [1, 31]
        // YYYY can be in [0000, 9999] | YY can be in [00, 99]
        [Fact]
        public void MM_DDInRange01_12SlashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "MM/dd/yyyy",
                "dd/MM/yyyy",
            };
            List<string> javaResult = Guesser.GuessFormat("01/02/2020", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "MM/DD/YYYY",
                "DD/MM/YYYY",
            };
            List<string> momentResult = Guesser.GuessFormat("01/02/2020", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%d/%m/%Y",
                "%m/%d/%Y",
            };
            List<string> linuxResult = Guesser.GuessFormat("01/02/2020", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DDInRange01_12DotDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "MM.dd.yyyy",
                "dd.MM.yyyy",
            };
            List<string> javaResult = Guesser.GuessFormat("01.02.2020", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "MM.DD.YYYY",
                "DD.MM.YYYY",
            };
            List<string> momentResult = Guesser.GuessFormat("01.02.2020", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%d.%m.%Y",
                "%m.%d.%Y",
            };
            List<string> linuxResult = Guesser.GuessFormat("01.02.2020", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DDInRange01_12DashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "MM-dd-yyyy",
                "dd-MM-yyyy",
            };
            List<string> javaResult = Guesser.GuessFormat("01-02-2020", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "MM-DD-YYYY",
                "DD-MM-YYYY",
            };
            List<string> momentResult = Guesser.GuessFormat("01-02-2020", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%d-%m-%Y",
                "%m-%d-%Y",
            };
            List<string> linuxResult = Guesser.GuessFormat("01-02-2020", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MMInRange01_12DDInRange12_31SlashDelimited()
        {
            Assert.Equal("MM/dd/yyyy", Guesser.GuessFormat("01/31/2020", Format.Java).FirstOrDefault());
            Assert.Equal("MM/DD/YYYY", Guesser.GuessFormat("01/31/2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%m/%d/%Y", Guesser.GuessFormat("01/31/2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void MMInRange01_12DDInRange13_31DotDelimited()
        {
            Assert.Equal("MM.dd.yyyy", Guesser.GuessFormat("01.31.2020", Format.Java).FirstOrDefault());
            Assert.Equal("MM.DD.YYYY", Guesser.GuessFormat("01.31.2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%m.%d.%Y", Guesser.GuessFormat("01.31.2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void MMInRange01_12DDInRange13_31DashDelimited()
        {
            Assert.Equal("MM-dd-yyyy", Guesser.GuessFormat("01-31-2020", Format.Java).FirstOrDefault());
            Assert.Equal("MM-DD-YYYY", Guesser.GuessFormat("01-31-2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%m-%d-%Y", Guesser.GuessFormat("01-31-2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_DD_MM_YYYY()
        {
            Assert.Equal("dd/MM/yyyy", Guesser.GuessFormat("13/01/2020", Format.Java).FirstOrDefault());
            Assert.Equal("DD/MM/YYYY", Guesser.GuessFormat("13/01/2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%d/%m/%Y", Guesser.GuessFormat("13/01/2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_DD_MM_YYYY_hh_mm_a_z()
        {
            Assert.Equal("dd/MM/yyyy hh:mm a z", Guesser.GuessFormat("13/01/2020 01:00 pm EST", Format.Java).FirstOrDefault());
            Assert.Equal("DD/MM/YYYY hh:mm a z", Guesser.GuessFormat("13/01/2020 01:00 pm EST", Format.Moment).FirstOrDefault());
            Assert.Equal("%d/%m/%Y %I:%M %P %Z", Guesser.GuessFormat("13/01/2020 01:00 pm EST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dot_DD_MM_YYYY()
        {
            Assert.Equal("dd.MM.yyyy", Guesser.GuessFormat("13.01.2020", Format.Java).FirstOrDefault());
            Assert.Equal("DD.MM.YYYY", Guesser.GuessFormat("13.01.2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%d.%m.%Y", Guesser.GuessFormat("13.01.2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_DD_MM_YYYY()
        {
            Assert.Equal("dd-MM-yyyy", Guesser.GuessFormat("13-01-2020", Format.Java).FirstOrDefault());
            Assert.Equal("DD-MM-YYYY", Guesser.GuessFormat("13-01-2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%d-%m-%Y", Guesser.GuessFormat("13-01-2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_DD_MMM_YYYY()
        {
            Assert.Equal("dd-MMM-yyyy", Guesser.GuessFormat("13-Jan-2020", Format.Java).FirstOrDefault());
            Assert.Equal("DD-MMM-YYYY", Guesser.GuessFormat("13-Jan-2020", Format.Moment).FirstOrDefault());
            Assert.Equal("%d-%b-%Y", Guesser.GuessFormat("13-Jan-2020", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_DD_MMM_YYYY_hh_mm_am_pm_Z()
        {
            Assert.Equal("dd-MMM-yyyy, hh:mm a z", Guesser.GuessFormat("13-Jan-2020, 10:00 am IST", Format.Java).FirstOrDefault());
            Assert.Equal("DD-MMM-YYYY, hh:mm a z", Guesser.GuessFormat("13-Jan-2020, 10:00 am IST", Format.Moment).FirstOrDefault());
            Assert.Equal("%d-%b-%Y, %I:%M %P %Z", Guesser.GuessFormat("13-Jan-2020, 10:00 am IST", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_DD_MMM_YY()
        {
            Assert.Equal("dd-MMM-yy", Guesser.GuessFormat("13-Jan-20", Format.Java).FirstOrDefault());
            Assert.Equal("DD-MMM-YY", Guesser.GuessFormat("13-Jan-20", Format.Moment).FirstOrDefault());
            Assert.Equal("%d-%b-%y", Guesser.GuessFormat("13-Jan-20", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_DD_MMM_YY_ham_pm()
        {
            Assert.Equal("dd-MMM-yy, ha", Guesser.GuessFormat("13-Jan-20, 1am", Format.Java).FirstOrDefault());
            Assert.Equal("DD-MMM-YY, ha", Guesser.GuessFormat("13-Jan-20, 1am", Format.Moment).FirstOrDefault());
            Assert.Equal("%d-%b-%y, %-l%P", Guesser.GuessFormat("13-Jan-20, 1am", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void MM_DDOutOfRange()
        {
            Assert.Throws<Exception>(() => Guesser.GuessFormat("99/99/2020", Format.Java));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("99/99/2020", Format.Moment));
            Assert.Throws<Exception>(() => Guesser.GuessFormat("99/99/2020", Format.Linux));
        }

        [Fact]
        public void MM_DD_YYInRange01_12SlashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy/MM/dd",
                "MM/dd/yy",
                "dd/MM/yy",
            };
            List<string> javaResult = Guesser.GuessFormat("01/02/03", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY/MM/DD",
                "MM/DD/YY",
                "DD/MM/YY",
            };
            List<string> momentResult = Guesser.GuessFormat("01/02/03", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y/%m/%d",
                "%d/%m/%y",
                "%m/%d/%y",
            };
            List<string> linuxResult = Guesser.GuessFormat("01/02/03", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DD_YYInRange01_12SlashDelimitedWithTime()
        {
            List<string> javaExpectedResult = new()
            {
                "yy/MM/dd hh:mm a",
                "MM/dd/yy hh:mm a",
                "dd/MM/yy hh:mm a",
            };
            List<string> javaResult = Guesser.GuessFormat("01/02/03 10:00 PM", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY/MM/DD hh:mm A",
                "MM/DD/YY hh:mm A",
                "DD/MM/YY hh:mm A",
            };
            List<string> momentResult = Guesser.GuessFormat("01/02/03 10:00 PM", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y/%m/%d %I:%M %p",
                "%d/%m/%y %I:%M %p",
                "%m/%d/%y %I:%M %p",
            };
            List<string> linuxResult = Guesser.GuessFormat("01/02/03 10:00 PM", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DD_YYInRange01_12DotDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy.MM.dd",
                "MM.dd.yy",
                "dd.MM.yy",
                "HH.mm.ss",
            };
            List<string> javaResult = Guesser.GuessFormat("01.02.03", Format.Java);
            Assert.Equal(4, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY.MM.DD",
                "MM.DD.YY",
                "DD.MM.YY",
                "HH.mm.ss",
            };
            List<string> momentResult = Guesser.GuessFormat("01.02.03", Format.Moment);
            Assert.Equal(4, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y.%m.%d",
                "%d.%m.%y",
                "%m.%d.%y",
                "%H.%M.%S",
            };
            List<string> linuxResult = Guesser.GuessFormat("01.02.03", Format.Linux);
            Assert.Equal(4, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DD_YYInRange01_12DotDelimitedWithColonDelimitedTime()
        {
            List<string> javaExpectedResult = new()
            {
                "yy.MM.dd HH:mm z",
                "MM.dd.yy HH:mm z",
                "dd.MM.yy HH:mm z",
            };
            List<string> javaResult = Guesser.GuessFormat("01.02.03 10:00 PDT", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY.MM.DD HH:mm z",
                "MM.DD.YY HH:mm z",
                "DD.MM.YY HH:mm z",
            };
            List<string> momentResult = Guesser.GuessFormat("01.02.03 10:00 PDT", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y.%m.%d %H:%M %Z",
                "%d.%m.%y %H:%M %Z",
                "%m.%d.%y %H:%M %Z",
            };
            List<string> linuxResult = Guesser.GuessFormat("01.02.03 10:00 PDT", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DD_YYInRange01_12DotDelimitedWithDotDelimitedTime()
        {
            List<string> javaExpectedResult = new()
            {
                "yy.MM.dd HH.mm z",
                "MM.dd.yy HH.mm z",
                "dd.MM.yy HH.mm z",
            };
            List<string> javaResult = Guesser.GuessFormat("01.02.03 10.00 PDT", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY.MM.DD HH.mm z",
                "MM.DD.YY HH.mm z",
                "DD.MM.YY HH.mm z",
            };
            List<string> momentResult = Guesser.GuessFormat("01.02.03 10.00 PDT", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y.%m.%d %H.%M %Z",
                "%d.%m.%y %H.%M %Z",
                "%m.%d.%y %H.%M %Z",
            };
            List<string> linuxResult = Guesser.GuessFormat("01.02.03 10.00 PDT", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DD_YYInRange01_12DashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy-MM-dd",
                "MM-dd-yy",
                "dd-MM-yy",
            };
            List<string> javaResult = Guesser.GuessFormat("01-02-03", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY-MM-DD",
                "MM-DD-YY",
                "DD-MM-YY",
            };
            List<string> momentResult = Guesser.GuessFormat("01-02-03", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y-%m-%d",
                "%d-%m-%y",
                "%m-%d-%y",
            };
            List<string> linuxResult = Guesser.GuessFormat("01-02-03", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void YYInRange13_31PlacedFirstSlashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy/MM/dd",
                "dd/MM/yy",
            };
            List<string> javaResult = Guesser.GuessFormat("13/02/01", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY/MM/DD",
                "DD/MM/YY",
            };
            List<string> momentResult = Guesser.GuessFormat("13/02/01", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y/%m/%d",
                "%d/%m/%y",
            };
            List<string> linuxResult = Guesser.GuessFormat("13/02/01", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void YYInRange13_31PlacedFirstDotDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy.MM.dd",
                "dd.MM.yy",
                "HH.mm.ss",
            };
            List<string> javaResult = Guesser.GuessFormat("13.02.01", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY.MM.DD",
                "DD.MM.YY",
                "HH.mm.ss",
            };
            List<string> momentResult = Guesser.GuessFormat("13.02.01", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y.%m.%d",
                "%d.%m.%y",
                "%H.%M.%S",
            };
            List<string> linuxResult = Guesser.GuessFormat("13.02.01", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void Slash_DD_MM_YY()
        {
            Assert.Equal("dd/MM/yy", Guesser.GuessFormat("31/01/70", Format.Java).FirstOrDefault());
            Assert.Equal("DD/MM/YY", Guesser.GuessFormat("31/01/70", Format.Moment).FirstOrDefault());
            Assert.Equal("%d/%m/%y", Guesser.GuessFormat("31/01/70", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dot_DD_MM_YY()
        {
            Assert.Equal("dd.MM.yy", Guesser.GuessFormat("31.01.70", Format.Java).FirstOrDefault());
            Assert.Equal("DD.MM.YY", Guesser.GuessFormat("31.01.70", Format.Moment).FirstOrDefault());
            Assert.Equal("%d.%m.%y", Guesser.GuessFormat("31.01.70", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_DD_MM_YY()
        {
            Assert.Equal("dd-MM-yy", Guesser.GuessFormat("31-01-70", Format.Java).FirstOrDefault());
            Assert.Equal("DD-MM-YY", Guesser.GuessFormat("31-01-70", Format.Moment).FirstOrDefault());
            Assert.Equal("%d-%m-%y", Guesser.GuessFormat("31-01-70", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_MM_DD_YY()
        {
            Assert.Equal("MM/dd/yy", Guesser.GuessFormat("12/31/70", Format.Java).FirstOrDefault());
            Assert.Equal("MM/DD/YY", Guesser.GuessFormat("12/31/70", Format.Moment).FirstOrDefault());
            Assert.Equal("%m/%d/%y", Guesser.GuessFormat("12/31/70", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_MM_DD_YY()
        {
            Assert.Equal("MM-dd-yy", Guesser.GuessFormat("12-31-70", Format.Java).FirstOrDefault());
            Assert.Equal("MM-DD-YY", Guesser.GuessFormat("12-31-70", Format.Moment).FirstOrDefault());
            Assert.Equal("%m-%d-%y", Guesser.GuessFormat("12-31-70", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_YY_MM_DD()
        {
            Assert.Equal("yy/MM/dd", Guesser.GuessFormat("70/12/31", Format.Java).FirstOrDefault());
            Assert.Equal("YY/MM/DD", Guesser.GuessFormat("70/12/31", Format.Moment).FirstOrDefault());
            Assert.Equal("%y/%m/%d", Guesser.GuessFormat("70/12/31", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dot_YY_MM_DD()
        {
            Assert.Equal("yy.MM.dd", Guesser.GuessFormat("70.12.31", Format.Java).FirstOrDefault());
            Assert.Equal("YY.MM.DD", Guesser.GuessFormat("70.12.31", Format.Moment).FirstOrDefault());
            Assert.Equal("%y.%m.%d", Guesser.GuessFormat("70.12.31", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dash_YY_MM_DD()
        {
            Assert.Equal("yy-MM-dd", Guesser.GuessFormat("70-12-31", Format.Java).FirstOrDefault());
            Assert.Equal("YY-MM-DD", Guesser.GuessFormat("70-12-31", Format.Moment).FirstOrDefault());
            Assert.Equal("%y-%m-%d", Guesser.GuessFormat("70-12-31", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void MM_DDInRange01_12ShortFormSlashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy/MM",
                "dd/MM",
                "MM/dd",
            };
            List<string> javaResult = Guesser.GuessFormat("01/01", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY/MM",
                "DD/MM",
                "MM/DD",
            };
            List<string> momentResult = Guesser.GuessFormat("01/01", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y/%m",
                "%d/%m",
                "%m/%d",
            };
            List<string> linuxResult = Guesser.GuessFormat("01/01", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DDInRange01_12ShortFormDotDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy.MM",
                "dd.MM",
                "MM.dd",
                "HH.mm",
            };
            List<string> javaResult = Guesser.GuessFormat("01.01", Format.Java);
            Assert.Equal(4, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY.MM",
                "DD.MM",
                "MM.DD",
                "HH.mm",
            };
            List<string> momentResult = Guesser.GuessFormat("01.01", Format.Moment);
            Assert.Equal(4, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y.%m",
                "%d.%m",
                "%m.%d",
                "%H.%M",
            };
            List<string> linuxResult = Guesser.GuessFormat("01.01", Format.Linux);
            Assert.Equal(4, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void MM_DDInRange01_12ShortFormDashDelimited()
        {
            List<string> javaExpectedResult = new()
            {
                "yy-MM",
                "dd-MM",
                "MM-dd",
            };
            List<string> javaResult = Guesser.GuessFormat("01-01", Format.Java);
            Assert.Equal(3, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "YY-MM",
                "DD-MM",
                "MM-DD",
            };
            List<string> momentResult = Guesser.GuessFormat("01-01", Format.Moment);
            Assert.Equal(3, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y-%m",
                "%d-%m",
                "%m-%d",
            };
            List<string> linuxResult = Guesser.GuessFormat("01-01", Format.Linux);
            Assert.Equal(3, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void Slash_MM_DD()
        {
            Assert.Equal("MM/dd", Guesser.GuessFormat("12/31", Format.Java).FirstOrDefault());
            Assert.Equal("MM/DD", Guesser.GuessFormat("12/31", Format.Moment).FirstOrDefault());
            Assert.Equal("%m/%d", Guesser.GuessFormat("12/31", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Dot_MM_DD()
        {
            List<string> javaExpectedResult = new()
            {
                "MM.dd",
                "HH.mm",
            };
            List<string> javaResult = Guesser.GuessFormat("12.31", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "MM.DD",
                "HH.mm",
            };
            List<string> momentResult = Guesser.GuessFormat("12.31", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%m.%d",
                "%H.%M",
            };
            List<string> linuxResult = Guesser.GuessFormat("12.31", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void Dash_MM_DD()
        {
            Assert.Equal("MM-dd", Guesser.GuessFormat("12-31", Format.Java).FirstOrDefault());
            Assert.Equal("MM-DD", Guesser.GuessFormat("12-31", Format.Moment).FirstOrDefault());
            Assert.Equal("%m-%d", Guesser.GuessFormat("12-31", Format.Linux).FirstOrDefault());
        }

        [Fact]
        public void Slash_DD_MM_YY_MM()
        {
            List<string> javaExpectedResult = new()
            {
                "dd/MM",
                "yy/MM",
            };
            List<string> javaResult = Guesser.GuessFormat("31/12", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "DD/MM",
                "YY/MM",
            };
            List<string> momentResult = Guesser.GuessFormat("31/12", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y/%m",
                "%d/%m",
            };
            List<string> linuxResult = Guesser.GuessFormat("31/12", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void Dot_DD_MM_YY_MM()
        {
            List<string> javaExpectedResult = new()
            {
                "dd.MM",
                "yy.MM",
            };
            List<string> javaResult = Guesser.GuessFormat("31.12", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "DD.MM",
                "YY.MM",
            };
            List<string> momentResult = Guesser.GuessFormat("31.12", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y.%m",
                "%d.%m",
            };
            List<string> linuxResult = Guesser.GuessFormat("31.12", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());
        }

        [Fact]
        public void Dash_DD_MM_YY_MM()
        {
            List<string> javaExpectedResult = new()
            {
                "dd-MM",
                "yy-MM",
            };
            List<string> javaResult = Guesser.GuessFormat("31-12", Format.Java);
            Assert.Equal(2, javaResult.Count);
            Assert.Equal(javaExpectedResult.OrderBy(s => s).ToList(), javaResult.OrderBy(s => s).ToList());

            List<string> momentExpectedResult = new()
            {
                "DD-MM",
                "YY-MM",
            };
            List<string> momentResult = Guesser.GuessFormat("31-12", Format.Moment);
            Assert.Equal(2, momentResult.Count);
            Assert.Equal(momentExpectedResult.OrderBy(s => s).ToList(), momentResult.OrderBy(s => s).ToList());

            List<string> linuxExpectedResult = new()
            {
                "%y-%m",
                "%d-%m",
            };
            List<string> linuxResult = Guesser.GuessFormat("31-12", Format.Linux);
            Assert.Equal(2, linuxResult.Count);
            Assert.Equal(linuxExpectedResult.OrderBy(s => s).ToList(), linuxResult.OrderBy(s => s).ToList());

        }
    }
}