namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    public static void Init(GlobalData globalData)
    {
        globalData.ATimeOfWarVars.Reset(globalData);
        globalData.Generation = Generation.First;
        globalData.Years      = Years.Early;
        ATOW_Preparations(globalData);
    }

    private static void ATOW_Preparations(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(ForewordScen2);
    }

    private static void ForewordScen2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ATimeofWarIntro);
    }

    private static void ATimeofWarIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();

        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Rumblings = 0;
        vars.War       = Random.Shared.Next(2) + 1;
        vars.WarWinner = Random.Shared.Next(2) == 0 ? "Separatists" : "Unified Monarchists";

        if (vars.WarWinner == "Separatists")
        {
            vars.Crest    = "Sickle";
            vars.WarLoser = "Unified Monarchists";
            vars.Figure   = "Shield";
            vars.Quarter  = Random.Shared.Next(2) == 0 ? "yes" : "no";
        }
        else
        {
            vars.Crest    = "Shield";
            vars.WarLoser = "Separatists";
            vars.Figure   = "Sickle";
            vars.Quarter  = "no";
        }

        vars.Crazy       = 0;
        vars.BarracksAct = Random.Shared.Next(2) == 0 ? "mean" : "nice";
        vars.Sep         = "0";
        vars.Mon         = "0";
        vars.GunsBonus   = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_I);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(IntroConflict);
    }

    private static void IntroConflict(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(IntroConflict_0);
    }

    private static void IntroConflict_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        string flagIcon = vars.WarWinner == "Separatists"
            ? PopUpIcon.S3_FlagSeparatists
            : PopUpIcon.S3_FlagUnitfiedMonarchists;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            flagIcon,
            PopUpButton.Accept,
            TakeSidesSetup,
            str => str.FormatWithReplacement(0, vars.WarWinner));
    }

    private static void TakeSidesSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.Rumblings == 0)
        {
            vars.Tracker = globalData.PlayersNum switch
            {
                2 => Random.Shared.Next(3) + 4,
                3 => Random.Shared.Next(3) + 6,
                _ => Random.Shared.Next(3) + 7
            };

            string startPlayer = vars.GetDisplayPlayerName(globalData, Random.Shared.Next(globalData.PlayersNum));

            globalData.ActivePopup = new GameplayPopup(
                globalData,
                PopUpTitle.Setup,
                PopUpIcon.S3_ScenarioIcon,
                PopUpButton.Accept,
                TakeSides,
                str => str
                    .FormatWithReplacement(0, vars.Tracker.ToString())
                    .FormatWithReplacement(1, startPlayer));
        }
        else
        {
            TakeSides(globalData);
        }
    }

    public static void TakeSides(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.TakeSides;
        vars.Round = globalData.Years switch
        {
            Years.Early  => 1,
            Years.Middle => 2,
            _            => 3
        };

        if (globalData.Years == Years.Middle)
        {
            vars.NoMore = 0;
        }

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        // Town Hall - Political Rumblings (Early & Middle Years)
        GameplayHubSection townHallSec = globalData.ActiveHub.AddSection("TownHall", true);
        townHallSec.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        townHallSec.AddDefaultContent("TownHall");
        townHallSec.AddSpecialClickHere("TownHall", RumorD, true);

        // Pledge of Support (Early & Middle Years)
        GameplayHubSection pledgeSec = globalData.ActiveHub.AddSection("Pledge", true);
        pledgeSec.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        pledgeSec.AddDefaultContent(
            "Pledge",
            str => str.FormatWithCondition(0, () => globalData.Years == Years.Early));

        // Late Years: Military Demands (Barracks == "yes" && BarracksAct == "mean")
        GameplayHubSection milDemandsSec = globalData.ActiveHub.AddSection("MilitaryDemands", true);
        milDemandsSec.ReplaceShouldShow(() => globalData.Years == Years.Late && vars.Barracks == "yes" && vars.BarracksAct == "mean");
        milDemandsSec.AddDefaultContent("MilitaryDemands");

        // Late Years: Military Service (Barracks == "yes" && BarracksAct != "mean")
        GameplayHubSection milServiceSec = globalData.ActiveHub.AddSection("MilitaryService", true);
        milServiceSec.ReplaceShouldShow(() => globalData.Years == Years.Late && vars.Barracks == "yes" && vars.BarracksAct != "mean");
        milServiceSec.AddDefaultContent("MilitaryService");

        // Middle & Late Years: Knowledge Bonus (GunsBonus == 1)
        GameplayHubSection knowBonusSec = globalData.ActiveHub.AddSection("KnowledgeBonus", true);
        knowBonusSec.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late && vars.GunsBonus == 1);
        knowBonusSec.AddDefaultContent("KnowledgeBonus");

        // Middle & Late Years: Ingredient Bonus (GunsBonus == 2)
        GameplayHubSection ingBonusSec = globalData.ActiveHub.AddSection("IngredientBonus", true);
        ingBonusSec.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late && vars.GunsBonus == 2);
        ingBonusSec.AddDefaultContent("IngredientBonus");

        // Middle & Late Years: Wealth Bonus (GunsBonus == 3)
        GameplayHubSection wealthBonusSec = globalData.ActiveHub.AddSection("WealthBonus", true);
        wealthBonusSec.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late && vars.GunsBonus == 3);
        wealthBonusSec.AddDefaultContent("WealthBonus");

        // Early & Middle Years End of Round
        GameplayHubSection endSec = globalData.ActiveHub.AddSection("End", true);
        endSec.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        endSec.AddDefaultContent("End");
        endSec.AddClickHereContinueNextRound(TakeSides_EndRound, true);

        // Late Years End of Generation
        globalData.ActiveHub.AddEndOfGenerationSection(TakeSides_EndRound);
    }

    private static void TakeSides_EndRound(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ShowEndOfRoundPopUp(
            globalData.Years switch
            {
                Years.Early  => TownHallSpecial,
                Years.Middle => TakeEvent,
                _            => TakeSides3_EndGen
            });
    }

    private static List<int> GetAvailableRumors(ATimeOfWarVars vars)
    {
        List<int> available = new() { 1, 2, 3, 4, 5, 6 };
        if (vars.Rumor1Visited) available.Remove(1);
        if (vars.Rumor2Visited) available.Remove(2);
        if (vars.Rumor6Visited) available.Remove(6);

        // Shuffle
        for (int i = available.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (available[i], available[j]) = (available[j], available[i]);
        }

        return available;
    }

    private static Action<GlobalData> GetRumorCallback(int rumorId)
    {
        return rumorId switch
        {
            1 => RumorD1,
            2 => RumorD2,
            3 => RumorD5,
            4 => RumorD4,
            5 => RumorD3,
            _ => RumorD6Guns
        };
    }

    private static void RumorD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Rumblings++;

        List<int> available = GetAvailableRumors(vars);
        vars.Opt1 = available[0];
        vars.Opt2 = available[1];

        int introVariant = Random.Shared.Next(4);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithIndex(0, introVariant));
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            str => str.FormatWithIndex(0, vars.Opt1 - 1),
            GetRumorCallback(vars.Opt1));
        globalData.ActiveWindow.AddNextContent(
            2,
            true,
            str => str.FormatWithIndex(0, vars.Opt2 - 1),
            GetRumorCallback(vars.Opt2));
    }

    private static void TownHallSpecial(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.NoMore         = 1;
        vars.TownHallVisits = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TownHallS1);
    }

    private static void TownHallS1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.TownHallVisits++;

        if (vars.TownHallVisits > globalData.PlayersNum)
        {
            GunsAnnouncement(globalData);
            return;
        }

        List<int> available = GetAvailableRumors(vars);
        vars.Opt1 = available[0];
        vars.Opt2 = available[1];

        string currentPlayer = vars.GetDisplayPlayerName(globalData, vars.TownHallVisits - 1);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, currentPlayer));
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            str => str.FormatWithIndex(0, vars.Opt1 - 1),
            GetRumorCallback(vars.Opt1));
        globalData.ActiveWindow.AddNextContent(
            2,
            true,
            str => str.FormatWithIndex(0, vars.Opt2 - 1),
            GetRumorCallback(vars.Opt2));
    }

    private static void RumorD1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Rumor1Visited = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorD1_Reveal);
    }

    private static void RumorD1_Reveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, crestIcon)
                .FormatWithReplacement(1, vars.WarWinner)
                .FormatWithCondition(2, () => vars.War == 1));
        globalData.ActiveWindow.AddClickHereToContinue(RumorD1_Setup);
    }

    private static void RumorD1_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string popIcon   = vars.Crest == "Sickle" ? PopUpIcon.S3_SickleToken : PopUpIcon.S3_ShieldToken;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            popIcon,
            PopUpButton.Accept,
            RumorRandomReward,
            str => str.FormatWithReplacement(0, crestIcon));
    }

    private static void RumorD2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Rumor2Visited = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorD2_Reveal);
    }

    private static void RumorD2_Reveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string figIcon = vars.Figure == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, figIcon));
        globalData.ActiveWindow.AddClickHereToContinue(RumorD2_Setup);
    }

    private static void RumorD2_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string popIcon = vars.Figure == "Sickle" ? PopUpIcon.S3_SickleToken : PopUpIcon.S3_ShieldToken;
        string figIcon = vars.Figure == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            popIcon,
            PopUpButton.Accept,
            RumorRandomReward,
            str => str.FormatWithReplacement(0, figIcon));
    }

    private static void RumorD3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Mon = vars.WarWinner == "Separatists" ? "lose" : "win";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorD3_Reveal);
    }

    private static void RumorD3_Reveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithCondition(0, () => vars.War == 2 && vars.Quarter == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(RumorRandomReward);
    }

    private static void RumorD4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Sep = vars.WarWinner == "Separatists" ? "win" : "lose";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorD4_Reveal);
    }

    private static void RumorD4_Reveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorRandomReward);
    }

    private static void RumorD5(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Crazy++;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorD5_Reveal);
    }

    private static void RumorD5_Reveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithCondition(0, () => vars.War == 1));
        globalData.ActiveWindow.AddClickHereToContinue(RumorD5_Setup);
    }

    private static void RumorD5_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WoodenFigureToken,
            PopUpButton.Accept,
            RumorCreep);
    }

    private static void RumorD6Guns(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorD6Guns_Reveal);
    }

    private static void RumorD6Guns_Reveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        List<int> choices = new() { 1, 2, 3 };
        for (int i = choices.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (choices[i], choices[j]) = (choices[j], choices[i]);
        }

        vars.Gun1 = choices[0];
        vars.Gun2 = choices[1];

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            str => str.FormatWithIndex(0, vars.Gun1 - 1),
            gd =>
            {
                gd.ATimeOfWarVars.GunsBonus = gd.ATimeOfWarVars.Gun1;
                RumorD6Confirm(gd);
            });
        globalData.ActiveWindow.AddNextContent(
            2,
            true,
            str => str.FormatWithIndex(0, vars.Gun2 - 1),
            gd =>
            {
                gd.ATimeOfWarVars.GunsBonus = gd.ATimeOfWarVars.Gun2;
                RumorD6Confirm(gd);
            });
    }

    private static void RumorD6Confirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Rumor6Visited = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithIndex(0, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
        globalData.ActiveWindow.AddClickHereToContinue(RumorRandomReward);
    }

    private static void RumorRandomReward(GlobalData globalData)
    {
        int roll = Random.Shared.Next(3);
        if (roll == 0) RumorIngredient(globalData);
        else if (roll == 1) RumorKnowledge(globalData);
        else RumorPitch(globalData);
    }

    private static void RumorCreep(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorCreep_Setup);
    }

    private static void RumorCreep_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            FinishRumor);
    }

    private static void RumorIngredient(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorIngredient_Setup);
    }

    private static void RumorIngredient_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Accept,
            FinishRumor);
    }

    private static void RumorKnowledge(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorKnowledge_Setup);
    }

    private static void RumorKnowledge_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ChooseFromSupply_Icon,
            PopUpButton.Accept,
            FinishRumor);
    }

    private static void RumorPitch(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RumorPitch_Setup);
    }

    private static void RumorPitch_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AdvanceAngryMob,
            PopUpButton.Accept,
            FinishRumor);
    }

    private static void FinishRumor(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.NoMore == 1)
        {
            if (vars.TownHallVisits < globalData.PlayersNum)
            {
                TownHallS1(globalData);
            }
            else
            {
                GunsAnnouncement(globalData);
            }
        }
        else
        {
            TakeSides(globalData);
        }
    }

    private static void GunsAnnouncement(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.GunsBonus >= 1)
        {
            globalData.ActiveWindow = new GameplayWindow(globalData);
            globalData.ActiveWindow.AddDefaultTitle(
                str => str.FormatWithReplacement(0, globalData.TownName));
            globalData.ActiveWindow.AddDefaultContent(
                str => str
                    .FormatWithReplacement(0, globalData.TownName)
                    .FormatWithIndex(1, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
            globalData.ActiveWindow.AddClickHereToContinue(TakeSides);
        }
        else
        {
            vars.Rumor6Visited = true;
            TakeSides(globalData);
        }
    }

    private static void TakeEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser));
        globalData.ActiveWindow.AddClickHereAfterBid(TakeEventb);
    }

    private static void TakeEventb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            null,
            gd =>
            {
                gd.ATimeOfWarVars.Barracks = "yes";
                ResolutionofEvent(gd);
            });
        globalData.ActiveWindow.AddNextContent(
            2,
            true,
            null,
            gd =>
            {
                gd.ATimeOfWarVars.Barracks = "no";
                ResolutionofEvent(gd);
            });
    }

    private static void ResolutionofEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.TakeReact = Random.Shared.Next(2) == 0 ? "1" : "2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithCondition(1, () => vars.Barracks == "yes")
                .FormatWithIndex(2, globalData.PlayersNum == 2 ? 0 : 1));
        globalData.ActiveWindow.AddClickHereToContinue(ResolutionofEvent_Setup);
    }

    private static void ResolutionofEvent_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        int sepBonusIndex = vars.Sep switch
        {
            "0"    => 0,
            "win"  => 1,
            _      => 2
        };

        int monBonusIndex = vars.Mon switch
        {
            "0"    => 0,
            "win"  => 1,
            _      => 2
        };

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_SeparatistToken,
            PopUpButton.Accept,
            TakeEventFlag,
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser)
                .FormatWithCondition(2, () => vars.Barracks == "yes")
                .FormatWithIndex(3, sepBonusIndex)
                .FormatWithIndex(4, monBonusIndex));
    }

    private static void TakeEventFlag(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.TakeReact == "1")
        {
            globalData.ActiveWindow = new GameplayWindow(globalData);
            globalData.ActiveWindow.AddDefaultTitle();
            globalData.ActiveWindow.AddDefaultContent(
                str => str
                    .FormatWithReplacement(0, vars.WarWinner)
                    .FormatWithReplacement(1, vars.WarLoser)
                    .FormatWithCondition(2, () => vars.Barracks == "yes"));
            globalData.ActiveWindow.AddClickHereToContinue(TakeEventFlag_Setup);
        }
        else
        {
            TakeSides3Setup(globalData);
        }
    }

    private static void TakeEventFlag_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        string flagIcon = vars.WarLoser == "Separatists"
            ? PopUpIcon.S3_FlagSeparatists
            : PopUpIcon.S3_FlagUnitfiedMonarchists;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            flagIcon,
            PopUpButton.Accept,
            TakeSides3Setup,
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser));
    }

    private static void TakeSides3Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        string icon = vars.Barracks == "yes"
            ? PopUpIcon.Caretaker
            : PopUpIcon.VillageChronicleCover;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            TakeSides,
            str => str.FormatWithCondition(0, () => vars.Barracks == "yes"));
    }

    private static void TakeSides3_EndGen(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Barracks == "yes")
        {
            TSBarracksPenalty(globalData);
        }
        else
        {
            RouteAfterBarracksPenalty(globalData);
        }
    }

    private static void TSBarracksPenalty(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RouteAfterBarracksPenalty);
    }

    private static void RouteAfterBarracksPenalty(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (globalData.TownName == "Paradox")
        {
            vars.War = 1;
        }
        else if (globalData.TownName == "Destruction")
        {
            vars.War = 2;
        }

        if (vars.GunsBonus != 0)
        {
            SeedGUNS(globalData);
        }
        else if (vars.War == 1)
        {
            Warwarn(globalData);
        }
        else
        {
            TowardsWar(globalData);
        }
    }

    private static void SeedGUNS(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            str => str.FormatWithIndex(0, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithIndex(0, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
        globalData.ActiveWindow.AddClickHereToContinue(SeedGUNS_Setup);
    }

    private static void SeedGUNS_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int vpAmount = Random.Shared.Next(2) + 2;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            gd =>
            {
                if (gd.ATimeOfWarVars.War == 1) Warwarn(gd);
                else TowardsWar(gd);
            },
            str => str
                .FormatWithReplacement(0, vpAmount.ToString())
                .FormatWithIndex(1, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
    }

    private static void Warwarn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TowardsDev);
    }

    private static void TowardsDev(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithCondition(1, () => vars.Barracks == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(TowardsDev_EndGen);
    }

    private static void TowardsDev_EndGen(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            TimeTravelintro);
    }

    private static void TowardsWar(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithCondition(1, () => vars.Barracks == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(TowardsWar_EndGen);
    }

    private static void TowardsWar_EndGen(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            gd =>
            {
                if (gd.ATimeOfWarVars.WarWinner == "Separatists")
                {
                    IntroMartial_Separatists(gd);
                }
                else
                {
                    IntroMartial_Monarchists(gd);
                }
            });
    }
}
