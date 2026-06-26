using System.Runtime.CompilerServices;

namespace MyFathersWorkWebApp;

public class GameplayInputPopup(GlobalData globalData, string placeholder, PopUpButton popUpButton, Func<string, bool> validate, Action<string> onClose, bool placeholderAsTag = false, [CallerMemberName] string callerName = "")
{
    public string Message     { get; } = globalData.GetScenarioLocalizedTag(callerName + "_Content");
    public string Placeholder { get; } = placeholderAsTag ? globalData.GetScenarioLocalizedTag(placeholder) : placeholder;

    public string ButtonText { get; } = popUpButton switch
    {
        PopUpButton.Confirm => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Confirm),
        _                   => globalData.GetLocalizedUITag(GlobalTags.Gameplay_Accept)
    };

    public Func<string, bool> Validate { get; } = validate;
    public Action<string>     OnClose  { get; } = onClose;
}