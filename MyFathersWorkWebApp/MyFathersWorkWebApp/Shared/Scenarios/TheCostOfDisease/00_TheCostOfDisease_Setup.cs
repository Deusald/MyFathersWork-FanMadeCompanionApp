namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    public static void Init(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0 ,globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(IntroImmortalitySetup);
    }

    private static void IntroImmortalitySetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ScenarioStart);
    }

    private static void ScenarioStart(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle( GlobalTags.Gameplay_Generation_I);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Dubious);

        List<Affiliation> affiliations;

        if (globalData.TownName == TheCostOfDiseaseVars.WOLVES_EVIL_TOWN_NAME)
        {
            affiliations = [Affiliation.Evil, Affiliation.Good];
        }
        else if (globalData.TownName == TheCostOfDiseaseVars.HUNTERS_EVIL_TOWN_NAME)
        {
            affiliations = [Affiliation.Good, Affiliation.Evil];
        }
        else
        {
            affiliations = [Affiliation.Good, Affiliation.Evil];
            if (globalData.TheCostOfDiseaseVars.RandomBool(0)) (affiliations[0], affiliations[1]) = (affiliations[1], affiliations[0]);
        }

        globalData.TheCostOfDiseaseVars.Wolves  = affiliations[0];
        globalData.TheCostOfDiseaseVars.Hunters = affiliations[1];
    }

    private static void Dubious(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Dubious_0);
    }

    private static void Dubious_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_DubiousBartering, PopUpButton.Accept, SpecialGen1);
    }

    private static void SpecialGen1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.StorybookToken, PopUpButton.Accept, FirstTimeSuspicion);
    }

    private static void FirstTimeSuspicion(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Tracker = globalData.PlayersNum switch
        {
            2 => globalData.TheCostOfDiseaseVars.RandomElement([6, 7],      1),
            3 => globalData.TheCostOfDiseaseVars.RandomElement([7, 8],      1),
            _ => globalData.TheCostOfDiseaseVars.RandomElement([9, 10, 11], 1) // 4
        };

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.AngryMobSetup1,
            PopUpButton.Accept, FirstPlayer, content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Tracker.ToString()));
    }

    private static void FirstPlayer(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string firstPlayerName = globalData.PlayersNum switch
        {
            2 => globalData.TheCostOfDiseaseVars.RandomElement([globalData.PlayerAName, globalData.PlayerBName],                         2),
            3 => globalData.TheCostOfDiseaseVars.RandomElement([globalData.PlayerAName, globalData.PlayerBName, globalData.PlayerCName], 2),
            _ => globalData.TheCostOfDiseaseVars.RandomElement([globalData.PlayerAName, globalData.PlayerBName, globalData.PlayerDName], 2), // 4
        };

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.StartPlayerToken, PopUpButton.Accept, Fever, content => content.FormatWithReplacement(0, firstPlayerName));
    }
}