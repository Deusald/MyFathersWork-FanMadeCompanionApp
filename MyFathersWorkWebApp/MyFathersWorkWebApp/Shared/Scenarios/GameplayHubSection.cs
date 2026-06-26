using System.Runtime.CompilerServices;

namespace MyFathersWorkWebApp;

public class GameplayHubSection(GlobalData globalData, bool main, string titleTag)
{
    public bool                  Main       { get; }      = main;
    public string                Title      { get; }      = titleTag.Contains(GlobalTags.GameplayStartTag) ? globalData.GetLocalizedUITag(titleTag) : globalData.GetScenarioLocalizedTag(titleTag);
    public List<GameplayElement> Elements   { get; }      = new();
    public Func<bool>            ShouldShow { get; set; } = () => true;

    public void ReplaceShouldShow(Func<bool> shouldShow)
    {
        ShouldShow = shouldShow;
    }

    public void AddDefaultContent(string subName, Func<string, string>? contentFormatter = null, [CallerMemberName] string callerName = "")
    {
        string content = globalData.GetScenarioLocalizedTag(callerName + "_" + subName + "_Content");
        if (contentFormatter != null) content = contentFormatter(content);
        Elements.Add(new GameplayElement(content));
    }

    public void AddNextContent(int index, string subName, bool fromNewLine = false, Func<string, string>? contentFormatter = null, [CallerMemberName] string callerName = "")
    {
        string content                        = globalData.GetScenarioLocalizedTag(callerName + "_" + subName + $"_Content{index}");
        if (contentFormatter != null) content = contentFormatter(content);
        Elements.Add(new GameplayElement(content, null, fromNewLine));
    }

    public void AddClickHere(Action<GlobalData>? callback, bool fromNewLine = false)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickHere), callback, fromNewLine));
    }
    
    public void AddSpecialClickHere(string subName, Action<GlobalData>? callback, bool fromNewLine = false, Func<string, string>? contentFormatter = null, [CallerMemberName] string callerName = "")
    {
        string click                        = globalData.GetScenarioLocalizedTag(callerName + "_" + subName + "_ClickHere");
        if (contentFormatter != null) click = contentFormatter(click);
        
        Elements.Add(new GameplayElement(click, callback, fromNewLine));
    }
    
    public void AddClickHereForReward(Action<GlobalData>? callback, bool fromNewLine = false)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickHereForReward), callback, fromNewLine));
    }

    public void AddClickHereContinueNextRound(Action<GlobalData>? callback, bool fromNewLine = false)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickHereContinueNextRound), callback, fromNewLine));
    }

    public void AddClickAtTheEndOfGeneration(Action<GlobalData>? callback, bool fromNewLine = false)
    {
        Elements.Add(new GameplayElement(globalData.GetLocalizedUITag(GlobalTags.Gameplay_ClickAtTheEndOfGeneration), callback, fromNewLine));
    }
}