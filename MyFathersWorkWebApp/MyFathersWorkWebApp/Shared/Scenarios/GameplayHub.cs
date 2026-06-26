using System.Runtime.CompilerServices;

namespace MyFathersWorkWebApp;

public class GameplayHub(GlobalData globalData)
{
    public string                   Title    { get; private set; } = string.Empty;
    public string                   Subtitle { get; private set; } = string.Empty;
    public List<GameplayHubSection> Sections { get; }              = new();

    public void SetDefaultTitle([CallerMemberName] string callerName = "")
    {
        Title = globalData.GetScenarioLocalizedTag(callerName + "_Title");
    }

    public void SetSubtitle(Years years)
    {
        Subtitle = globalData.GetLocalizedUITag(years switch
        {
            Years.Early  => GlobalTags.Gameplay_EarlyYears,
            Years.Middle => GlobalTags.Gameplay_MiddleYears,
            Years.Late   => GlobalTags.Gameplay_LateYears,
            _            => string.Empty
        });
    }

    public GameplayHubSection AddSection(string subName, bool main = false, [CallerMemberName] string callerName = "")
    {
        GameplayHubSection newSection = new GameplayHubSection(globalData, main,  subName == string.Empty ? string.Empty : callerName + "_" + subName + "_Title");
        Sections.Add(newSection);
        return newSection;
    }

    public void AddEndOfGenerationSection(Action<GlobalData> endOfGenerationAction)
    {
        GameplayHubSection endLate = new GameplayHubSection(globalData, false, GlobalTags.Gameplay_EndOfGeneration_Title);
        endLate.ReplaceShouldShow(() => globalData.Years is Years.Late);
        endLate.AddClickAtTheEndOfGeneration(endOfGenerationAction);
        Sections.Add(endLate);
    }
}