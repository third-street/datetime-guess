<h1 align="center">Welcome to dotnet-datetime-guess 👋<br> <img src="./logo.png" /></h1>

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/at0dd/dotnet-datetime-guess/.NET)
![Release Version](https://img.shields.io/github/v/release/at0dd/dotnet-datetime-guess)
![Nuget Version](https://img.shields.io/nuget/v/datetime-guess)
![Nuget Downloads](https://img.shields.io/nuget/dt/datetime-guess)

> :tada: A utility package for guessing date's format :alarm_clock: :raised_hands:

## 👨‍💻 Usage

### Package

Install from Powershell
```ps1
Nuget-Install 'DateTime-Guess'
```

Install from .NET CLI
```ps1
dotnet add package 'DateTime-Guess'
```

### Formats
Format is a public enumerator.
```c#
// output default format (Java)
List<string> = Guesser.GuessFormat("Fri, January 30th 2020, 10:00 AM")
List<string> = Guesser.GuessFormat("Fri, January 30th 2020, 10:00 AM", Format.Java)

// output Moment.js format
List<string> = Guesser.GuessFormat("31st Dec, 2020", Format.Moment)

// output strftime format
List<string> = Guesser.GuessFormat("31st Dec, 2020", Format.Linux)
```

### Code Example
```c#
using DateTime_Guess;

public class GetDateFormatExample
{
    public static List<string> GetDateFormat(string date)
    {
        try {
            return Guesser.GuessFormat(date, Format.Java);
        }
        catch (Exception e)
        {
            // "Couldn't parse date."
            // "Couldn't find a modifier for x."
        }
    }
}
```

## 🙌 Supported Date Formats
- *2020-07-24T17:09:03+00:00*([IS0 8601](https://en.wikipedia.org/wiki/ISO_8601))

- *Mon, 06 Mar 2017 21:22:23 +0000*([RFC 2822](https://tools.ietf.org/html/rfc2822#section-3.3))

- *31/12/2020, 1.1.2020, 31-12-20*(slash, dot or dash delimited dates, both US and UK styles)

- *31-Dec-2020, 1-Jan-20*(dash delimited with month name)

- *Fri, January 30th 2020, 10:00 AM*(dow, dd Mon yyyy[, hh:mm:ss am|pm|AM|PM] with both short and long names)

## 🤷‍♀️ What happens in case of ambiguous input?
If the input is ambiguous like 01/01/2020 (could mean DD/MM/YYYY or MM/DD/YYYY), **it would return all possible matched formats**.

## :mag: How does it work?
<img src="./design.png"/>

Entire module is split up into three main components, _parsers_, _refiners_ and _assigners_.

* _Parsers_ break the input into individual tokens, giving meaning to each token(whether it's year, month, day...).

* _Refiners_ refine the parsed results based on certain chosen heuristics in case the input matched multiple parsers.

* _Assigners_ assign the appropriate format tokens(don't confuse these with generated tokens from input) enlisted [here](https://momentjs.com/docs/#/displaying/) to each corresponding token based on the meaning given to the token by the parser(example, *YYYY* for a four digit year token).
