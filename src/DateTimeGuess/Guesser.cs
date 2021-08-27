namespace DateTimeGuess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using DateTimeGuess.Assigners;
    using DateTimeGuess.Parsers;
    using DateTimeGuess.Refiners;

    /// <summary>
    /// Guess the format of a datetime string.
    /// </summary>
    public static class Guesser
    {
        /// <summary>
        /// The regex string for abbreviated timezones.
        /// </summary>
        public static readonly Regex _abbreviatedTimezoneRegex = new("UT|CAT|CET|CVT|EAT|EET|GMT|MUT|RET|SAST|SCT|WAST|WAT|WEST|WET|WST|WT|ADT|AFT|ALMT|AMST|AMT|ANAST|ANAT|AQTT|AST|AZST|AZT|BNT|BST|BTT|CHOST|CHOT|CST|EEST|EET|GET|GST|HKT|HOVST|HOVT|ICT|IDT|IRDT|IRKST|IRKT|IST|JST|KGT|KRAST|KRAT|KST|MAGST|MAGT|MMT|MSK|MVT|NOVST|NOVT|NPT|OMSST|OMST|ORAT|PETST|PETT|PHT|PKT|PYT|QYZT|SAKT|SGT|SRET|TJT|TLT|TMT|TRT|ULAST|ULAT|UZT|VLAST|VLAT|WIB|WIT|YAKST|YAKT|YEKST|YEKT|ART|CAST|CEST|CLST|CLT|DAVT|DDUT|GMT|MAWT|NZDT|NZST|ROTT|SYOT|VOST|ADT|AST|AT|AZOST|AZOT|ACDT|ACST|ACT|ACWST|AEDT|AEST|AET|AWDT|AWST|CXT|LHDT|LHST|NFDT|NFT|AST|AT|CDT|CIDST|CIST|CST|EDT|EST|ET|CST|CT|EST|ET|BST|CEST|CET|EEST|EET|FET|GET|GMT|IST|KUYT|MSD|MSK|SAMT|TRT|WEST|WET|CCT|EAT|IOT|TFT|ADT|AKDT|AKST|AST|AT|CDT|CST|CT|EDT|EGST|EGT|ET|GMT|HDT|HST|MDT|MST|MT|NDT|NST|PDT|PMDT|PMST|PST|PT|WGST|WGT|AoE|BST|CHADT|CHAST|CHUT|CKT|ChST|EASST|EAST|FJST|FJT|GALT|GAMT|GILT|HST|KOST|LINT|MART|MHT|NCT|NRT|NUT|NZDT|NZST|PGT|PHOT|PONT|PST|PWT|SBT|SST|TAHT|TKT|TOST|TOT|TVT|VUT|WAKT|WFT|WST|YAPT|ACT|AMST|AMT|ART|BOT|BRST|BRT|CLST|CLT|COT|ECT|FKST|FKT|FNT|GFT|GST|GYT|PET|PYST|PYT|SRT|UYST|UYT|VET|WARST");

        /// <summary>
        /// The Java regex string for abbreviated timezones.
        /// </summary>
        public static readonly Regex _javaTimezoneRegex = new("ACT|ADT|AET|AFT|AGT|AMT|ART|AST|AZT|BET|BIT|BNT|BOT|BRT|BST|BTT|CAT|CCT|CDT|CET|CKT|CLT|CNT|COT|CST|CTT|CVT|CXT|DFT|EAT|ECT|EDT|EET|EGT|EST|FET|FJT|FKT|FNT|GET|GFT|GIT|GMT|GST|GYT|HDT|HKT|HMT|HST|ICT|IDT|IET|IOT|IST|JST|KGT|KST|MDT|MET|MHT|MIT|MMT|MSK|MST|MUT|MVT|MYT|NCT|NDT|NET|NFT|NPT|NST|NUT|PDT|PET|PGT|PHT|PKT|PLT|PNT|PRC|PRT|PST|PWT|PYT|RET|ROK|SBT|SCT|SDT|SGT|SRT|SST|TFT|THA|TJT|TKT|TLT|TMT|TOT|TRT|TVT|UCT|UTC|UYT|UZT|VET|VST|VUT|WAT|WET|WGT|WIB|WIT");

        private static readonly List<Assigner> _javaAssigners = new()
        {
            new YearFormatTokenAssigner("YearFormatTokenAssigner", "year", Format.Java),
            new MonthFormatTokenAssigner("MonthFormatTokenAssigner", "month", Format.Java),
            new DayOfMonthFormatTokenAssigner("DelimiterFormatTokenAssigner", "dayOfMonth", Format.Java),
            new DelimiterFormatTokenAssigner("DelimiterFormatTokenAssigner", "delimiter", Format.Java),
            new MinuteFormatTokenAssigner("MinuteFormatTokenAssigner", "minute", Format.Java),
            new SecondFormatTokenAssigner("SecondFormatTokenAssigner", "second", Format.Java),
            new MillisecondFormatTokenAssigner("MillisecondFormatTokenAssigner", "millisecond", Format.Java),
            new TimezoneFormatTokenAssigner("TimezoneFormatTokenAssigner", "timezone", Format.Java),
            new DayOfYearFormatTokenAssigner("DayOfYearFormatTokenAssigner", "dayOfYear", Format.Java),
            new EscapeTextFormatTokenAssigner("EscapeTextFormatTokenAssigner", "escapeText", Format.Java),
            new ISODayOfWeekFormatTokenAssigner("ISODayOfWeekFormatTokenAssigner", "isoDayOfWeek", Format.Java),
            new ISOWeekOfYearFormatTokenAssigner("ISOWeekOfYearFormatTokenAssigner", "isoWeekOfYear", Format.Java),
            new TwentyFourHourFormatTokenAssigner("TwentyFourHourFormatTokenAssigner", "twentyFourHour", Format.Java),
            new TwelveHourFormatTokenAssigner("TwelveHourFormatTokenAssigner", "twelveHour", Format.Java),
            new DayOfWeekFormatTokenAssigner("DayOfWeekFormatTokenAssigner", "dayOfWeek", Format.Java),
            new MeridiemFormatTokenAssigner("MeridiemFormatTokenAssigner", "meridiem", Format.Java),
        };

        private static readonly List<Assigner> _momentAssigners = new()
        {
            new YearFormatTokenAssigner("YearFormatTokenAssigner", "year", Format.Moment),
            new MonthFormatTokenAssigner("MonthFormatTokenAssigner", "month", Format.Moment),
            new DayOfMonthFormatTokenAssigner("DelimiterFormatTokenAssigner", "dayOfMonth", Format.Moment),
            new DelimiterFormatTokenAssigner("DelimiterFormatTokenAssigner", "delimiter", Format.Moment),
            new MinuteFormatTokenAssigner("MinuteFormatTokenAssigner", "minute", Format.Moment),
            new SecondFormatTokenAssigner("SecondFormatTokenAssigner", "second", Format.Moment),
            new MillisecondFormatTokenAssigner("MillisecondFormatTokenAssigner", "millisecond", Format.Moment),
            new TimezoneFormatTokenAssigner("TimezoneFormatTokenAssigner", "timezone", Format.Moment),
            new DayOfYearFormatTokenAssigner("DayOfYearFormatTokenAssigner", "dayOfYear", Format.Moment),
            new EscapeTextFormatTokenAssigner("EscapeTextFormatTokenAssigner", "escapeText", Format.Moment),
            new ISODayOfWeekFormatTokenAssigner("ISODayOfWeekFormatTokenAssigner", "isoDayOfWeek", Format.Moment),
            new ISOWeekOfYearFormatTokenAssigner("ISOWeekOfYearFormatTokenAssigner", "isoWeekOfYear", Format.Moment),
            new TwentyFourHourFormatTokenAssigner("TwentyFourHourFormatTokenAssigner", "twentyFourHour", Format.Moment),
            new TwelveHourFormatTokenAssigner("TwelveHourFormatTokenAssigner", "twelveHour", Format.Moment),
            new DayOfWeekFormatTokenAssigner("DayOfWeekFormatTokenAssigner", "dayOfWeek", Format.Moment),
            new MeridiemFormatTokenAssigner("MeridiemFormatTokenAssigner", "meridiem", Format.Moment),
        };

        private static readonly List<Assigner> _linuxAssigners = new()
        {
            new DayOfMonthFormatTokenAssigner("DelimiterFormatTokenAssigner", "dayOfMonth", Format.Linux),
            new DayOfWeekFormatTokenAssigner("DayOfWeekFormatTokenAssigner", "dayOfWeek", Format.Linux),
            new DayOfYearFormatTokenAssigner("DayOfYearFormatTokenAssigner", "dayOfYear", Format.Linux),
            new DelimiterFormatTokenAssigner("DelimiterFormatTokenAssigner", "delimiter", Format.Linux),
            new EscapeTextFormatTokenAssigner("EscapeTextFormatTokenAssigner", "escapeText", Format.Linux),
            new ISODayOfWeekFormatTokenAssigner("ISODayOfWeekFormatTokenAssigner", "isoDayOfWeek", Format.Linux),
            new ISOWeekOfYearFormatTokenAssigner("ISOWeekOfYearFormatTokenAssigner", "isoWeekOfYear", Format.Linux),
            new MeridiemFormatTokenAssigner("MeridiemFormatTokenAssigner", "meridiem", Format.Linux),
            new MillisecondFormatTokenAssigner("MillisecondFormatTokenAssigner", "millisecond", Format.Linux),
            new MinuteFormatTokenAssigner("MinuteFormatTokenAssigner", "minute", Format.Linux),
            new MonthFormatTokenAssigner("MonthFormatTokenAssigner", "month", Format.Linux),
            new SecondFormatTokenAssigner("SecondFormatTokenAssigner", "second", Format.Linux),
            new TimezoneFormatTokenAssigner("TimezoneFormatTokenAssigner", "timezone", Format.Linux),
            new TwelveHourFormatTokenAssigner("TwelveHourFormatTokenAssigner", "twelveHour", Format.Linux),
            new TwentyFourHourFormatTokenAssigner("TwentyFourHourFormatTokenAssigner", "twentyFourHour", Format.Linux),
            new YearFormatTokenAssigner("YearFormatTokenAssigner", "year", Format.Linux),
        };

        private static readonly List<Parser> _parsers = new()
        {
            // ISO 8601 https://en.wikipedia.org/wiki/ISO_8601
            new Parser(
                "ISO8601ExtendedDateTimeFormatParser",
                new Regex(@"^(?<year>[+-]\d{6}|\d{4})(?<delim1>\-)(?:(?<month>\d{2})(?:(?<delim2>\-)(?<dayOfMonth>\d{2}))?|(?<escapeText>W)(?<isoWeekOfYear>\d{2})(?:(?<delim3>\-)(?<isoDayOfWeek>\d))?|(?<dayOfYear>\d{3}))(?:(?<delim4>T| )(?:(?<twentyFourHour>\d{2})(?:(?<delim5>:)(?<minute>\d{2})(?:(?<delim6>:)(?<second>\d{2})(?:(?<delim7>[.,])(?<millisecond>\d{1,9}))?)?)?)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z)?)?$")),

            // ISO 8601 https://en.wikipedia.org/wiki/ISO_8601
            new Parser(
                "ISO8601BasicDateTimeFormatParser",
                new Regex(@"^(?<year>[+-]\d{6}|\d{4})(?:(?<month>\d{2})(?:(?<dayOfMonth>\d{2}))?|(?<escapeText>W)(?<isoWeekOfYear>\d{2})(?:(?<isoDayOfWeek>\d))?|(?<dayOfYear>\d{3}))?(?:(?<delim1>T| )(?:(?<twentyFourHour>\d{2})(?:(?<minute>\d{2})(?:(?<second>\d{2})(?:(?<delim2>[.,])(?<millisecond>\d{1,9}))?)?)?)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z)?)?$")),

            // RFC 2822 https://tools.ietf.org/html/rfc2822#section-3.3
            new Parser(
                "RFC2822DateTimeFormatParser",
                new Regex(@"^(?:(?<dayOfWeek>Mon|Tue|Wed|Thu|Fri|Sat|Sun)(?<delim1>,)?(?<delim2>\s))?(?<dayOfMonth>\d{1,2})(?<delim3>\s)(?<month>Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(?<delim4>\s)(?<year>\d{2,4})(?<delim5>\s)(?<twentyFourHour>\d{2})(?<delim6>:)(?<minute>\d{2})(?:(?<delim7>:)(?<second>\d{2}))?(?<delim8>\s)(?<timezone>(?:(?:UT|GMT|[ECMP][SD]T)|[Zz]|[+-]\d{4}))$")),

            /*
             * YYYY/MM/DD [hh:mm a|A [abbr-tz]]
             * YYYY/M/D
             * YYYY/MM
             * YYYY/M
             */
            new Parser(
                "SlashDelimitedDateFormatParser",
                new Regex(@"^(?<year>\d{4}|\d{2})(?<delim1>[/.-])(?<month>0?[1-9]|1[0-2])(?:(?<delim2>[/.-])(?<dayOfMonth>0?[1-9]|[1-2]\d|3[0-1]))?(?:(?:(?<delim3>,)?(?<delim4>[\sT])(?:(?<twentyFourHour>2[0-3]|0?\d|1\d)|(?<twelveHour>0?[1-9]|1[0-2]))(?:(?<delim5>[:.])(?<minute>[0-5]\d))?(?:(?<delim6>[:.])(?<second>[0-5]\d))?(?:(?<delim7>.)(?<millisecond>\d{3}))?(?<delim8>\s)?(?<meridiem>am|pm|AM|PM)?(?:(?<delim9>\s)?(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?)?)?$")),

            /*
             * UK style
             *
             * - DD/MM/YYYY
             * - D/M/YYYY
             * - DD/MM/YY
             * - DD/MM
             */
            new Parser(
                "UKStyleSlashDelimitedDateFormatParser",
                new Regex(@"^(?<dayOfMonth>0?[1-9]|[1-2]\d|3[0-1])(?<delim1>[/.-])(?<month>0?[1-9]|1[0-2])(?:(?<delim2>[/.-])(?<year>\d{4}|\d{2}))?(?:(?:(?<delim3>,)?(?<delim4>\s)(?:(?<twentyFourHour>2[0-3]|0?\d|1\d)|(?<twelveHour>0?[1-9]|1[0-2]))(?:(?<delim5>[:.])(?<minute>[0-5]\d))?(?:(?<delim6>[:.])(?<second>[0-5]\d))?(?:(?<delim7>.)(?<millisecond>\d{3}))?(?<delim8>\s)?(?<meridiem>am|pm|AM|PM)?(?:(?<delim9>\s)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?)?)?$")),

            /*
             * US style
             *
             * - MM/DD/YYYY
             * - M/D/YYYY
             *
             * - MM/DD/YY
             * - M/D/YY
             *
             * - MM/DD
             * - M/D
             */
            new Parser(
                "USStyleSlashDelimitedDateFormatParser",
                new Regex(@"^(?<month>0?[1-9]|1[0-2])(?<delim1>[/.-])(?<dayOfMonth>0?[1-9]|[1-2]\d|3[0-1])(?:(?<delim2>[/.-])(?<year>\d{4}|\d{2}))?(?:(?:(?<delim3>,)?(?<delim4>\s)(?:(?<twentyFourHour>2[0-3]|0?\d|1\d)|(?<twelveHour>0?[1-9]|1[0-2]))(?:(?<delim5>[:.])(?<minute>[0-5]\d))?(?:(?<delim6>[:.])(?<second>[0-5]\d))?(?:(?<delim7>.)(?<millisecond>\d{3}))?(?<delim8>\s)?(?<meridiem>am|pm|AM|PM)?(?:(?<delim9>\s)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?)?)?$")),

            /**
             * Date only
             *
             * - Jan 1
             * - January 1
             * - Jan 1st
             * - January 1st
             * - Jan 01
             * - January 01
             *
             * Date with time
             *
             * - Jan 1, 10:00 AM
             * - Sunday, January 1st, 23:00
             * - Sunday, January 1st, 23:00 PDT
             */
            new Parser(
                "MonthNameAndDayOfMonthDateFormatParser",
                new Regex(@"^(?<dayOfWeek>(?:Sun?|Mon?|Tu(?:es)?|We(?:dnes)?|Th(?:urs)?|Fri?|Sa(?:tur)?)(?:day)?)?(?<delim1>,)?(?<delim2>\s)?(?<month>Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?|Apr(?:il)?|May|June?|July?|Aug(?:ust)?|Sep(?:tember)?|Oct(?:ober)?|Nov(?:ember)?|Dec(?:ember)?)(?<delim3>\s)(?<dayOfMonth>(?:3[0-1]|[1-2]\d|0?[1-9])(?:st|nd|rd|th)?)(?<delim4>,)?(?<delim5>\s)?(?<year>\d{4}|\d{2})?(?:(?:(?<delim6>,)?(?<delim7>\s)(?:(?<twentyFourHour>2[0-3]|0?\d|1\d)|(?<twelveHour>0?[1-9]|1[0-2]))(?:(?<delim8>[:.])(?<minute>[0-5]\d))?(?:(?<delim9>[:.])(?<second>[0-5]\d))?(?:(?<delim10>.)(?<millisecond>\d{3}))?(?<delim11>\s)?(?<meridiem>am|pm|AM|PM)?(?:(?<delim12>\s)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?)?)?$")),

            /**
             * Date only
             *
             * - 1 Jan
             * - 1 January
             * - 1st Jan
             * - 1st January
             * - 01 Jan
             * - 01 January
             *
             * Date with time
             *
             * - 1 Jan, 10:00 AM
             * - Sunday, 1st January, 23:00
             */
            new Parser(
                "DayOfMonthAndMonthNameDateFormatParser",
                new Regex(@"^(?<dayOfWeek>(?:Sun?|Mon?|Tu(?:es)?|We(?:dnes)?|Th(?:urs)?|Fri?|Sa(?:tur)?)(?:day)?)?(?<delim1>,)?(?<delim2>\s)?(?<dayOfMonth>(?:3[0-1]|[1-2]\d|0?[1-9])(?:st|nd|rd|th)?)(?<delim3>\s)(?<month>Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?|Apr(?:il)?|May|June?|July?|Aug(?:ust)?|Sep(?:tember)?|Oct(?:ober)?|Nov(?:ember)?|Dec(?:ember)?)(?<delim4>,)?(?<delim5>\s)?(?<year>\d{4}|\d{2})?(?:(?<delim6>,)?(?<delim7>\s)(?:(?<twentyFourHour>2[0-3]|0?\d|1\d)|(?<twelveHour>0?[1-9]|1[0-2]))(?:(?<delim8>[:.])(?<minute>[0-5]\d))?(?:(?<delim9>[:.])(?<second>[0-5]\d))?(?:(?<delim10>.)(?<millisecond>\d{3}))?(?<delim11>\s)?(?<meridiem>am|pm|AM|PM)?(?:(?<delim12>\s)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?)?$")),

            /**
             * HH:mm:ss[.ddd]
             * HH:mm
             * HH.mm.ss[ ]Z
             */
            new Parser(
                "TwentyFourHourTimeFormatParser",
                new Regex(@"^(?<twentyFourHour>2[0-3]|0?\d|1\d)(?<delim1>[:.])(?<minute>[0-5]\d)(?:(?<delim2>[:.])(?<second>[0-5]\d))?(?:(?<delim3>.)(?<millisecond>\d{3}))?(?:(?<delim4>\s)?(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?$")),

            /**
             * hh:mm[AP]M
             * hh:mm[AP]M [abbr-tz]
             * hh[AP]M
             */
            new Parser(
                "TwelveHourTimeFormatParser",
                new Regex(@"^(?<twelveHour>0?[1-9]|1[0-2])(?:(?<delim1>[:.])(?<minute>[0-5]\d))?(?:(?<delim2>[:.])(?<second>[0-5]\d))?(?:(?<delim3>.)(?<millisecond>\d{3}))?(?<delim4>\s)?(?<meridiem>am|pm|AM|PM)(?:(?<delim5>\s)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?$")),

            new Parser(
                "DashDelimitedWithMonthNameDateTimeFormatParser",
                new Regex(@"^(?<dayOfMonth>0?[1-9]|[1-2]\d|3[0-1])(?<delim1>-)(?<month>Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?|Apr(?:il)?|May|June?|July?|Aug(?:ust)?|Sep(?:tember)?|Oct(?:ober)?|Nov(?:ember)?|Dec(?:ember)?)(?<delim2>-)?(?<year>\d{4}|\d{2})?(?:(?:(?<delim3>,)?(?<delim4>\s)(?:(?<twentyFourHour>2[0-3]|0?\d|1\d)|(?<twelveHour>0?[1-9]|1[0-2]))(?:(?<delim5>[:.])(?<minute>[0-5]\d))?(?:(?<delim6>[:.])(?<second>[0-5]\d))?(?:(?<delim7>.)(?<millisecond>\d{3}))?(?<delim8>\s)?(?<meridiem>am|pm|AM|PM)?(?:(?<delim9>\s)(?<timezone>[+-]\d{2}(?::?\d{2})?|Z|" + $"{_abbreviatedTimezoneRegex}|{_javaTimezoneRegex}))?)?)?$")),
        };

        private static readonly List<IRefiner> _refinders = new()
        {
            new TimeFormatRefiner("TimeFormatRefiner"),
            new StandardFormatParsersRefiner("StandardFormatParsersRefiner"),
        };

        /// <summary>
        /// Guess the format of a date string.
        /// </summary>
        /// <param name="date">The date to guess the format of.</param>
        /// <param name="format">The format the guess should return in.</param>
        /// <returns>Returns a list of formats that match the date.</returns>
        public static List<string> GuessFormat(string date, Format format = Format.Java)
        {
            List<ParsedResult> parsedResults = Parse(date);
            List<ParsedResult> refinedParsedResults = Refine(parsedResults);
            if (refinedParsedResults.Count == 0)
            {
                throw new Exception("Couldn't parse date.");
            }

            refinedParsedResults.ForEach(r =>
            {
                r.Tokens = Assign(r.Tokens, format);
            });

            List<string> matchedFormats = new();
            refinedParsedResults.ForEach(r =>
            {
                string formatString = GetFormatString(r.Tokens);
                if (!matchedFormats.Contains(formatString))
                {
                    matchedFormats.Add(formatString);
                }
            });

            return matchedFormats;
        }

        internal static List<ParsedResult> Parse(string date)
        {
            List<ParsedResult> parsedResults = new();
            _parsers.ForEach(parser =>
            {
                ParsedResult parsedResult = parser.Parse(date);
                if (parsedResult != null)
                {
                    parsedResults.Add(parsedResult);
                }
            });

            return parsedResults;
        }

        internal static List<ParsedResult> Refine(List<ParsedResult> parsedResults)
        {
            List<ParsedResult> refinedParsedResults = new List<ParsedResult>();
            parsedResults.ForEach(result =>
            {
                refinedParsedResults.Add(result);
            });

            _refinders.ForEach(refiner =>
            {
                refinedParsedResults.AddRange(refiner.Refine(refinedParsedResults));
            });

            return refinedParsedResults;
        }

        internal static List<Token> Assign(List<Token> tokens, Format format)
        {
            List<Assigner> assigners = new();

            assigners = format switch
            {
                Format.Moment => _momentAssigners,
                Format.Linux => _linuxAssigners,
                _ => _javaAssigners,
            };

            assigners.ForEach(assigner =>
            {
                tokens.ForEach(token =>
                {
                    token = assigner.Assign(token);
                });
            });

            return tokens;
        }

        internal static string GetFormatString(List<Token> tokens)
        {
            string formatString = string.Empty;
            tokens.ForEach(token =>
            {
                if (token.Format == "NA")
                {
                    throw new Exception($"Couldn't find a modifier for {token.Value}.");
                }

                formatString += !string.IsNullOrWhiteSpace(token.Format) ? token.Format : token.Value;
            });

            return formatString;
        }
    }
}