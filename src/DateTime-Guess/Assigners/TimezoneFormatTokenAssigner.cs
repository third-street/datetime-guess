namespace DateTime_Guess.Assigners
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Get the Timezone format.
    /// </summary>
    internal class TimezoneFormatTokenAssigner : Assigner
    {
        /// <summary>
        /// The regex string for abbreviated timezones.
        /// </summary>
        private readonly Regex _abbreviatedTimezoneRegex = new("UT|CAT|CET|CVT|EAT|EET|GMT|MUT|RET|SAST|SCT|WAST|WAT|WEST|WET|WST|WT|ADT|AFT|ALMT|AMST|AMT|ANAST|ANAT|AQTT|AST|AZST|AZT|BNT|BST|BTT|CHOST|CHOT|CST|EEST|EET|GET|GST|HKT|HOVST|HOVT|ICT|IDT|IRDT|IRKST|IRKT|IST|JST|KGT|KRAST|KRAT|KST|MAGST|MAGT|MMT|MSK|MVT|NOVST|NOVT|NPT|OMSST|OMST|ORAT|PETST|PETT|PHT|PKT|PYT|QYZT|SAKT|SGT|SRET|TJT|TLT|TMT|TRT|ULAST|ULAT|UZT|VLAST|VLAT|WIB|WIT|YAKST|YAKT|YEKST|YEKT|ART|CAST|CEST|CLST|CLT|DAVT|DDUT|GMT|MAWT|NZDT|NZST|ROTT|SYOT|VOST|ADT|AST|AT|AZOST|AZOT|ACDT|ACST|ACT|ACWST|AEDT|AEST|AET|AWDT|AWST|CXT|LHDT|LHST|NFDT|NFT|AST|AT|CDT|CIDST|CIST|CST|EDT|EST|ET|CST|CT|EST|ET|BST|CEST|CET|EEST|EET|FET|GET|GMT|IST|KUYT|MSD|MSK|SAMT|TRT|WEST|WET|CCT|EAT|IOT|TFT|ADT|AKDT|AKST|AST|AT|CDT|CST|CT|EDT|EGST|EGT|ET|GMT|HDT|HST|MDT|MST|MT|NDT|NST|PDT|PMDT|PMST|PST|PT|WGST|WGT|AoE|BST|CHADT|CHAST|CHUT|CKT|ChST|EASST|EAST|FJST|FJT|GALT|GAMT|GILT|HST|KOST|LINT|MART|MHT|NCT|NRT|NUT|NZDT|NZST|PGT|PHOT|PONT|PST|PWT|SBT|SST|TAHT|TKT|TOST|TOT|TVT|VUT|WAKT|WFT|WST|YAPT|ACT|AMST|AMT|ART|BOT|BRST|BRT|CLST|CLT|COT|ECT|FKST|FKT|FNT|GFT|GST|GYT|PET|PYST|PYT|SRT|UYST|UYT|VET|WARST");

        /// <summary>
        /// Initializes a new instance of the <see cref="TimezoneFormatTokenAssigner"/> class.
        /// </summary>
        /// <param name="name">The name of the assigner.</param>
        /// <param name="type">The type of the assigner.</param>
        /// <param name="format">The format of the assigner.</param>
        public TimezoneFormatTokenAssigner(string name, string type, Format format)
            : base(name, type, format)
        {
            if (format == Format.Java)
            {
                Map.Add(new Regex(@"[+-]\d{2}(?::\d{2})?"), "X");
                Map.Add(new Regex(@"[+-]\d{4}"), "Z");
                Map.Add(new Regex(@"Z"), "'Z'");
                Map.Add(new Regex(@"z"), "'z'");
                Map.Add(_abbreviatedTimezoneRegex, "z");
            }
            else if (format == Format.Moment)
            {
                Map.Add(new Regex(@"[+-]\d{2}(?::\d{2})?"), "Z");
                Map.Add(new Regex(@"[+-]\d{4}"), "ZZ");
                Map.Add(new Regex(@"Z"), "[Z]");
                Map.Add(new Regex(@"z"), "[z]");
                Map.Add(_abbreviatedTimezoneRegex, "z");
            }
            else if (format == Format.Linux)
            {
                Map.Add(new Regex(@"[+-]\d{2}(?::\d{2})?"), "%:z");
                Map.Add(new Regex(@"[+-]\d{4}"), "%z");
                Map.Add(new Regex(@"Z"), "Z");
                Map.Add(new Regex(@"z"), "z");
                Map.Add(_abbreviatedTimezoneRegex, "%Z");
            }
        }
    }
}