using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MyFathersWorkWebApp;

public class GameplayWindow(GlobalData globalData)
{
    public string                Title    { get; private set; } = string.Empty;
    public string                Subtitle { get; private set; } = string.Empty;
    public List<GameplayElement> Elements { get; }              = new();

    public void AddDefaultTitle(Func<string, string>? contentProcessor = null, [CallerMemberName] string callerName = "")
    {
        string title                        = globalData.GetScenarioLocalizedTag(callerName + "_Title");
        if (contentProcessor != null) title = contentProcessor(title);
        Title = title;
    }

    public void AddDefaultBaseTitle(Func<string, string>? contentProcessor = null, [CallerMemberName] string callerName = "")
    {
        string title                        = globalData.GetScenarioLocalizedTag(callerName.Split('_')[0] + "_Title");
        if (contentProcessor != null) title = contentProcessor(title);
        Title = title;
    }

    public void AddGameplayTitle(string titleTag)
    {
        Title = globalData.GetLocalizedUITag(titleTag);
    }

    public void AddDefaultSubtitle([CallerMemberName] string callerName = "")
    {
        Subtitle = globalData.GetScenarioLocalizedTag(callerName + "_SubTitle");
    }

    public void AddDefaultContent(Func<string, string>? contentProcessor = null, [CallerMemberName] string callerName = "")
    {
        string content                        = globalData.GetScenarioLocalizedTag(callerName + "_Content");
        if (contentProcessor != null) content = contentProcessor(content);
        Elements.Add(new GameplayElement(content));
    }

    public void AddNextContent(int index, bool fromNewLine = false, Func<string, string>? contentFormatter = null, Action<GlobalData>? nextCallback = null, [CallerMemberName] string callerName = "")
    {
        string content                        = globalData.GetScenarioLocalizedTag(callerName + $"_Content{index}");
        if (contentFormatter != null) content = contentFormatter(content);
        Elements.Add(new GameplayElement(content, nextCallback, fromNewLine));
    }

    public void AddNextContentWithLinks(int index, List<Action<GlobalData>?> nextCallbacks, bool fromNewLine = false, Func<string, string>? contentFormatter = null, [CallerMemberName] string callerName = "")
    {
        string content                        = globalData.GetScenarioLocalizedTag(callerName + $"_Content{index}");
        if (contentFormatter != null) content = contentFormatter(content);

        // Regex pattern to find <link=X>Text</link>
        var linkPattern = new Regex(@"<link=(\d+)>(.*?)<\/link>", RegexOptions.Singleline);
        var matches     = linkPattern.Matches(content);

        List<string>            outputStrings = new List<string>();
        Dictionary<string, int> linkIndexMap  = new Dictionary<string, int>();

        int lastIndex = 0;

        foreach (Match match in matches)
        {
            int    linkIndex = int.Parse(match.Groups[1].Value);
            string linkText  = match.Groups[2].Value;

            if (match.Index > lastIndex)
            {
                string before = content.Substring(lastIndex, match.Index - lastIndex);
                outputStrings.Add(before);
            }

            outputStrings.Add(linkText);
            linkIndexMap[linkText] = linkIndex;

            lastIndex = match.Index + match.Length;
        }

        if (lastIndex < content.Length)
        {
            string remaining = content.Substring(lastIndex);
            outputStrings.Add(remaining);
        }

        for (int x = 0; x < outputStrings.Count; ++x)
        {
            Action<GlobalData>? callback = linkIndexMap.TryGetValue(outputStrings[x], out int callbackIndex) ? nextCallbacks[callbackIndex] : null;
            Elements.Add(new GameplayElement(outputStrings[x], callback, x == 0 && fromNewLine));
        }
    }

    public void AddClickHere(Action<GlobalData> nextCallback, bool fromNewLine = false)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickHere), nextCallback, fromNewLine));
    }

    public void AddClickHereToContinue(Action<GlobalData> nextCallback)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickHereToContinue), nextCallback, true));
    }

    public void AddClickHereAfterBid(Action<GlobalData> nextCallback)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickHereAfterBid), nextCallback, true));
    }

    public void AddChoose()
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_Choose), null, true));
    }

    public void AddYesNo(Action<GlobalData> yesCallback, Action<GlobalData> noCallback)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_Yes), yesCallback, true));
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_No),  noCallback,  true));
    }

    public void AddHandStorybookTo(string who, Action<GlobalData> nextCallback)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_HandStorybookTo).FormatWithReplacement(0, who)));
        AddClickHereToContinue(nextCallback);
    }
    
    public void AddHandStorybookToNoJump(string who)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_HandStorybookTo).FormatWithReplacement(0, who)));
    }
    
    public void AddOnceYouAreReady(Action<GlobalData> nextCallback)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_OnceYouAreReady), nextCallback, true));
    }

    public void AddDoNotOtherPlayersToSee(string who, Action<GlobalData> nextCallback)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_DoNotOtherPlayersSee).FormatWithReplacement(0, who)));
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_OnceYouAreReady), nextCallback, true));
    }

    public void AddAllPlayersNamesAsOptions(Action<string> nextCallback, PlayerFormatterTag playerFormatterTag = PlayerFormatterTag.None, Func<string, bool>? showPlayer = null)
    {
        showPlayer ??= _ => true;

        string format = playerFormatterTag switch
        {
            PlayerFormatterTag.DrJr => globalData.GetLocalizedUITag(GlobalTags.Gameplay_DrJr),
            PlayerFormatterTag.Dr   => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Dr),
            _                       => "{{0=...|Oliver|James|Olivia|...}}"
        };

        if (showPlayer(globalData.PlayerAName)) Elements.Add(new GameplayElement(format.FormatWithReplacement(0,                               globalData.PlayerAName), data => nextCallback(data.PlayerAName), true));
        if (showPlayer(globalData.PlayerBName)) Elements.Add(new GameplayElement(format.FormatWithReplacement(0,                               globalData.PlayerBName), data => nextCallback(data.PlayerBName), true));
        if (globalData.PlayersNum >= 3 && showPlayer(globalData.PlayerCName)) Elements.Add(new GameplayElement(format.FormatWithReplacement(0, globalData.PlayerCName), data => nextCallback(data.PlayerCName), true));
        if (globalData.PlayersNum >= 4 && showPlayer(globalData.PlayerDName)) Elements.Add(new GameplayElement(format.FormatWithReplacement(0, globalData.PlayerDName), data => nextCallback(data.PlayerDName), true));
    }
}