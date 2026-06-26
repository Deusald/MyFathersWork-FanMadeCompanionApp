using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace MyFathersWorkWebApp;

public static class Extensions
{
    public static MarkupString AsMarkup(this string s) => (MarkupString)s;

    public static void ProcessLocalizationFile(this string localization, Dictionary<string, Dictionary<string, string>> target)
    {
        string[] lines     = localization.Split(new[] { '\r', '\n' });
        string[] languages = [];

        for (int x = 0; x < lines.Length; ++x)
        {
            string[] data = lines[x].Split(';');

            if (x == 0)
            {
                List<string> languagesTmp = new();
                for (int y = 1; y < data.Length; ++y)
                {
                    target[data[y]] = new();
                    languagesTmp.Add(data[y]);
                }

                languages = languagesTmp.ToArray();
                continue;
            }

            if (data[0].StartsWith("//")) continue;
            if (data[0] == string.Empty) continue;
            string tag = data[0];

            for (int y = 1; y < data.Length; ++y)
            {
                if (target[languages[y - 1]].ContainsKey(tag)) throw new Exception("Duplicate tag: " + tag);
                target[languages[y - 1]][tag] = data[y];
            }
        }
    }

    public static string InsertImages(this string text)
    {
        string pattern     = "<icon=([A-Za-z0-9_]+)>";
        string replacement = "<img style=\"display: inline-block; height: 1.5em; width: auto; transform: translate(0, -0.1em);\" src=\"./images/gameplay/$1.png\" alt=\"$1\">";
        text = Regex.Replace(text, pattern, replacement);

        string pattern2     = "<sprite=([A-Za-z0-9_]+)>";
        string replacement2 = "<img class=\"full-image\" style=\"height: 8em; display: block; margin: 1rem auto;\" src=\"./images/gameplay/$1.png\" alt=\"$1\">";
        return Regex.Replace(text, pattern2, replacement2);
    }

    public static string FormatWithIndex(this string text, int id, int index)
    {
        string pattern = @"\{\{(";
        pattern += id.ToString();
        pattern += @"=[^}]+)\}\}";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            string[] options = match.Groups[1].Value.Split('|');
            text = text.Replace(match.Value, options[index + 1]);
        }

        return text;
    }

    public static string FormatWithReplacement(this string text, int id, string replacement)
    {
        string pattern = @"\{\{(";
        pattern += id.ToString();
        pattern += @"=[^}]+)\}\}";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            text = text.Replace(match.Value, replacement);
        }

        return text;
    }

    public static string FormatWithCondition(this string text, int id, Func<bool> condition)
    {
        string pattern = @"\{\{(";
        pattern += id.ToString();
        pattern += @"=[^}]+)\}\}";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            string innerMatch = match.Groups[1].Value;
            innerMatch = innerMatch.Replace($"{id}=?|", "");

            string onTrue  = innerMatch;
            string onFalse = string.Empty;

            if (innerMatch.Contains('|'))
            {
                string[] split = innerMatch.Split('|');
                onTrue  = split[0];
                onFalse = split[1];
            }

            text = text.Replace(match.Value, condition() ? onTrue : onFalse);
        }

        return text;
    }
}