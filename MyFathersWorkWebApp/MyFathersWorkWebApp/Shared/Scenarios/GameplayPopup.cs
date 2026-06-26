using System.Runtime.CompilerServices;

namespace MyFathersWorkWebApp;

public class GameplayPopup
{
    public string Title { get; }

    public string ImageSrc { get; }

    public string ButtonText { get; }

    public Action<GlobalData> OnClose     { get; }
    public string             Description { get; private set; }

    public GameplayPopup(GlobalData globalData, PopUpTitle title, string imageSrc, PopUpButton button, Action<GlobalData> onClose, string localizationTag, Func<string, string>? contentProcessor = null)
    {
        Title = title switch
        {
            PopUpTitle.SpecialSetup    => globalData.GetLocalizedUITag(GlobalTags.Gameplay_SpecialSetup),
            PopUpTitle.EndOfRound      => globalData.GetLocalizedUITag(GlobalTags.Gameplay_EndOfRound_Title),
            PopUpTitle.EndOfGeneration => globalData.GetLocalizedUITag(GlobalTags.Gameplay_EndOfGeneration_Title),
            _                          => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Setup)
        };
        ImageSrc = imageSrc;
        ButtonText = button switch
        {
            PopUpButton.Confirm => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Confirm),
            _                   => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Accept)
        };
        OnClose = onClose;

        if (localizationTag != string.Empty)
        {
            string description                        = localizationTag.Contains(GlobalTags.GameplayStartTag) ? globalData.GetLocalizedUITag(localizationTag) : globalData.GetScenarioLocalizedTag(localizationTag);
            if (contentProcessor != null) description = contentProcessor(description);
            Description = description;
        }
        else Description = string.Empty;
    }

    public GameplayPopup(GlobalData globalData, PopUpTitle title, string imageSrc, PopUpButton button, Action<GlobalData> onClose, Func<string, string>? contentProcessor = null, [CallerMemberName] string callerName = "")
    {
        Title = title switch
        {
            PopUpTitle.SpecialSetup    => globalData.GetLocalizedUITag(GlobalTags.Gameplay_SpecialSetup),
            PopUpTitle.EndOfRound      => globalData.GetLocalizedUITag(GlobalTags.Gameplay_EndOfRound_Title),
            PopUpTitle.EndOfGeneration => globalData.GetLocalizedUITag(GlobalTags.Gameplay_EndOfGeneration_Title),
            _                          => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Setup)
        };
        ImageSrc = imageSrc;
        ButtonText = button switch
        {
            PopUpButton.Confirm => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Confirm),
            _                   => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Accept)
        };
        OnClose = onClose;

        string description                        = globalData.GetScenarioLocalizedTag(callerName + "_Content");
        if (contentProcessor != null) description = contentProcessor(description);
        Description = description;
    }

    public void ReplaceDescription(string newDescription)
    {
        Description = newDescription;
    }
}