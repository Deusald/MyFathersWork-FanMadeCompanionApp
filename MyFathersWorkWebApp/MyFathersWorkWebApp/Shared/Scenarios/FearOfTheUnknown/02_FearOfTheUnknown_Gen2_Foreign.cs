namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    internal static void ForeignIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.Generation = Generation.Second;
        globalData.Years = Years.Early;
        globalData.ActiveHub = null;

        vars.Path4 = "PEForeign";
        vars.BrickValue = Random.Shared.Next(1, 3);
        vars.WSuspect = vars.Kill == "butcher" ? "Butcher's Apprentice" : "Blacksmith's Apprentice";

        string pA = globalData.PlayersName[0];
        string pB = globalData.PlayersName[1];
        string pC = globalData.PlayersNum >= 3 ? globalData.PlayersName[2] : string.Empty;
        string pD = globalData.PlayersNum >= 4 ? globalData.PlayersName[3] : string.Empty;
        string pE = globalData.PlayersNum >= 5 ? globalData.PlayersName[4] : string.Empty;

        if (globalData.PlayersNum == 2)
        {
            string[] candidates = { pA, pB, pA, pB, vars.WSuspect };
            vars.Witch = candidates[Random.Shared.Next(candidates.Length)];
            vars.PointAi = Random.Shared.Next(2) == 0 ? pA : pB;
            vars.HexAi = vars.WSuspect == "Butcher's Apprentice"
                ? (Random.Shared.Next(2) == 0 ? "Farmer's Apprentice" : "Laborer's Union")
                : (Random.Shared.Next(2) == 0 ? "Blacksmith's Apprentice" : "Laborer's Union");
        }
        else if (globalData.PlayersNum == 3)
        {
            string[] candidates = { pA, pB, pC, pA, pB, pC, vars.WSuspect };
            vars.Witch = candidates[Random.Shared.Next(candidates.Length)];
            string[] pointCandidates = { pA, pB, pC };
            vars.PointAi = pointCandidates[Random.Shared.Next(pointCandidates.Length)];
            vars.HexAi = vars.WSuspect == "Butcher's Apprentice"
                ? (Random.Shared.Next(2) == 0 ? "Farmer's Apprentice" : "Laborer's Union")
                : (Random.Shared.Next(2) == 0 ? "Blacksmith's Apprentice" : "Laborer's Union");
        }
        else if (globalData.PlayersNum == 4)
        {
            string[] candidates = { pA, pB, pC, pD };
            vars.Witch = candidates[Random.Shared.Next(candidates.Length)];
        }
        else
        {
            string[] candidates = { pA, pB, pC, pD, pE };
            vars.Witch = candidates[Random.Shared.Next(candidates.Length)];
        }

        string[] aiLocations1 = { "Church", "Traveling Caravan", "Laborer's Union" };
        vars.WitAi = aiLocations1[Random.Shared.Next(aiLocations1.Length)];

        string[] aiLocations2 = { "Park", "Builder's Office", "Cemetery" };
        vars.WitAi2 = aiLocations2[Random.Shared.Next(aiLocations2.Length)];

        vars.Visit = 0;
        vars.CarCount = 0;
        vars.Id = 0;
        vars.IdA = string.Empty;
        vars.IdB = string.Empty;
        vars.IdC = string.Empty;
        vars.IdD = string.Empty;
        vars.IdE = string.Empty;
        vars.Forpg = 0;
        vars.RevResolve = 0;

        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(CommemorativeIntro);
    }

    private static void CommemorativeIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string dateStr = GetDate1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(CommemorativeIntro_0);
    }

    private static void CommemorativeIntro_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_BrickTokens,
            PopUpButton.Accept,
            PEWitch2);
    }

    // ==========================================
    // REVENGE PLOT 35 & WITCH INTRO
    // ==========================================

    internal static void RevengePlot35(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { RevengePlot35_0 }, true);
    }

    private static void RevengePlot35_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { RevengePlotFortune, RevengePlotMisfortune }, true);
    }

    private static void RevengePlotFortune(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.RevPlot = "fortune";
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(RevengePlot_Setup);
    }

    private static void RevengePlotMisfortune(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.RevPlot = "misfortune";
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(RevengePlot_Setup);
    }

    private static void RevengePlot_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.StorybookToken,
            PopUpButton.Accept,
            WitchIntro);
    }

    private static void WitchIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader)
               .FormatWithReplacement(1, vars.RandomName)
               .FormatWithCondition(2, () => globalData.PlayersNum <= 3));
        globalData.ActiveWindow.AddClickHereToContinue(WitchIntro2);
    }

    private static void WitchIntro2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.WSuspect)
               .FormatWithCondition(1, () => globalData.PlayersNum <= 3));
        globalData.ActiveWindow.AddClickHereToContinue(WitchIntro2_0);
    }

    private static void WitchIntro2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pageNum = vars.Kill == "butcher" ? "12" : "13";
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            Witchwolf1a,
            str => str.FormatWithReplacement(0, pageNum));
    }

    // ==========================================
    // WITCHWOLF ROUND 1 (EARLY YEARS HEX SELECTION)
    // ==========================================

    private static void Witchwolf1a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[0];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf1a_0 }, true);
    }

    private static void Witchwolf1a_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[0];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf1Options(globalData, 0, Witchwolf1b);
    }

    private static void Witchwolf1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[1];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf1b_0 }, true);
    }

    private static void Witchwolf1b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[1];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf1Options(globalData, 1, globalData.PlayersNum >= 3 ? Witchwolf1c : Witchwolf1Hex);
    }

    private static void Witchwolf1c(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[2];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf1c_0 }, true);
    }

    private static void Witchwolf1c_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[2];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf1Options(globalData, 2, globalData.PlayersNum >= 4 ? Witchwolf1d : Witchwolf1Hex);
    }

    private static void Witchwolf1d(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[3];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf1d_0 }, true);
    }

    private static void Witchwolf1d_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[3];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf1Options(globalData, 3, globalData.PlayersNum >= 5 ? Witchwolf1e : Witchwolf1Hex);
    }

    private static void Witchwolf1e(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[4];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf1e_0 }, true);
    }

    private static void Witchwolf1e_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[4];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf1Options(globalData, 4, Witchwolf1Hex);
    }

    private static void AddWitchwolf1Options(GlobalData globalData, int playerIdx, Action<GlobalData> nextPassage)
    {
        string[] locations = { "Church", "Traveling Caravan", "Laborer's Union" };
        foreach (string loc in locations)
        {
            string selectedLoc = loc;
            globalData.ActiveWindow!.Elements.Add(new GameplayElement(selectedLoc, gd =>
            {
                gd.FearOfTheUnknownVars.SetWit(playerIdx, selectedLoc);
                nextPassage(gd);
            }, true));
        }
    }

    private static void Witchwolf1Hex(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Witch1 = vars.WitAi;
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.Witch == globalData.PlayersName[i])
            {
                vars.Witch1 = vars.GetWit(i);
                break;
            }
        }

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_WitchHexToken,
            PopUpButton.Accept,
            Foreign_Setup,
            str => str.FormatWithReplacement(0, vars.Witch1));
    }

    private static void Foreign_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.Forpg == 1)
        {
            Foreign(globalData);
            return;
        }
        vars.Forpg = 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMobSetup1,
            PopUpButton.Accept,
            Foreign,
            str => str.FormatWithReplacement(0, vars.Tracker.ToString())
                      .FormatWithCondition(1, () => globalData.PlayersNum == 3));
    }

    // ==========================================
    // FOREIGN HUB (EARLY, MIDDLE, LATE YEARS)
    // ==========================================

    public static void Foreign(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.HubId = FearOfUnknownHubId.Foreign;
        vars.Round = globalData.Years == Years.Early ? 4 : globalData.Years == Years.Middle ? 5 : 6;

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        // Witching Hour
        GameplayHubSection witchingHour = globalData.ActiveHub.AddSection("WitchingHour", true);
        witchingHour.ReplaceShouldShow(() =>
            globalData.Years is Years.Early or Years.Middle ||
            (globalData.Years == Years.Late && vars.Cursed == "1"));
        witchingHour.AddDefaultContent("WitchingHour", str =>
        {
            string activeHex = globalData.Years == Years.Early ? vars.Witch1 : vars.Witch2;
            return str.FormatWithReplacement(0, activeHex)
                      .FormatWithCondition(1, () => globalData.Years == Years.Late);
        });

        // Rumor Mill (Early & Middle Years)
        GameplayHubSection rumorMill = globalData.ActiveHub.AddSection("RumorMill", true);
        rumorMill.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        rumorMill.AddDefaultContent("RumorMill", str =>
            str.FormatWithCondition(0, () => globalData.Years == Years.Early && vars.Witch1 == "Church"));
        if (globalData.Years == Years.Early && vars.Witch1 != "Church")
        {
            rumorMill.AddSpecialClickHere("RumorMill", CheckW1);
        }
        else if (globalData.Years == Years.Middle)
        {
            rumorMill.AddSpecialClickHere("RumorMill", CheckW2);
        }

        // Strength of the Town (All Years)
        GameplayHubSection townStrength = globalData.ActiveHub.AddSection("TownStrength", true);
        townStrength.AddDefaultContent("TownStrength");
        townStrength.AddClickHere(TownHallExplanation);

        // Key to the City (All Years)
        GameplayHubSection keyToCity = globalData.ActiveHub.AddSection("KeyToTheCity", true);
        keyToCity.AddDefaultContent("KeyToTheCity");

        // Bank & Library (Early Years)
        GameplayHubSection bankLib = globalData.ActiveHub.AddSection("BankLib", true);
        bankLib.ReplaceShouldShow(() => globalData.Years == Years.Early);
        bankLib.AddDefaultContent("BankLib");
        bankLib.AddClickHere(BankLibExplain);

        // Second Round Event - Accusations (Early & Middle Years)
        GameplayHubSection accusations = globalData.ActiveHub.AddSection("Accusations", true);
        accusations.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        accusations.AddDefaultContent("Accusations");

        // Pressing Forward - 35VP (All Years if not yet resolved)
        GameplayHubSection pressingForward = globalData.ActiveHub.AddSection("PressingForward", true);
        pressingForward.ReplaceShouldShow(() => vars.RevResolve == 0);
        pressingForward.AddDefaultContent("PressingForward");
        pressingForward.AddClickHere(
            vars.RevPlot == "fortune" ? Fortune35 : Misfortune35,
            true);

        // Next Round / End of Generation
        if (globalData.Years is Years.Early or Years.Middle)
        {
            GameplayHubSection nextRoundSec = globalData.ActiveHub.AddSection("", true);
            nextRoundSec.AddClickHereContinueNextRound(Foreign_EndRound, true);
        }
        else
        {
            globalData.ActiveHub.AddEndOfGenerationSection(Foreign_EndRound);
        }
    }

    private static void Foreign_EndRound(GlobalData globalData)
    {
        if (globalData.Years == Years.Early)
        {
            globalData.ShowEndOfRoundPopUp(WallEvent);
        }
        else if (globalData.Years == Years.Middle)
        {
            globalData.ShowEndOfRoundPopUp(Witchwolfresolution);
        }
        else
        {
            S4IsoBrick(globalData);
        }
    }

    // ==========================================
    // RUMOR MILL, TOWN HALL, BANK/LIB, 35VP PASSAGES
    // ==========================================

    private static void CheckW1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            var vars = globalData.FearOfTheUnknownVars;
            vars.TempCheck = playerName;
            vars.Forpg = 1;
            CheckWitches1(globalData);
        });
    }

    private static void CheckWitches1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.TempCheck));
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { CheckWitches1_0 }, true);
    }

    private static void CheckWitches1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        List<string> lines = new();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            lines.Add($"<b>{globalData.PlayersName[i]}:</b> {vars.GetWit(i)}");
        }
        if (globalData.PlayersNum <= 3)
        {
            lines.Add($"<b>{vars.WSuspect}:</b> {vars.WitAi}");
        }
        string report = string.Join("<br>", lines);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, report));
        globalData.ActiveWindow.AddClickHereToContinue(Foreign);
    }

    private static void CheckW2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            var vars = globalData.FearOfTheUnknownVars;
            vars.TempCheck = playerName;
            vars.Forpg = 1;
            CheckWitches2(globalData);
        });
    }

    private static void CheckWitches2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.TempCheck));
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { CheckWitches2_0 }, true);
    }

    private static void CheckWitches2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        List<string> lines = new();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            lines.Add($"<b>{globalData.PlayersName[i]}:</b> {vars.GetWit(i)}");
        }
        if (globalData.PlayersNum <= 3)
        {
            lines.Add($"<b>{vars.WSuspect}:</b> {vars.WitAi2}");
        }
        string report = string.Join("<br>", lines);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, report));
        globalData.ActiveWindow.AddClickHereToContinue(Foreign);
    }

    private static void TownHallExplanation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.Forpg = 1;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Foreign);
    }

    private static void BankLibExplain(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.Forpg = 1;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Foreign);
    }

    private static void Fortune35(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Forpg = 1;
        vars.RevResolve = 1;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(Fortune35_0);
    }

    private static void Fortune35_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.SuspicionMarker,
            PopUpButton.Accept,
            Foreign);
    }

    private static void Misfortune35(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Forpg = 1;
        vars.RevResolve = 1;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(Misfortune35_0);
    }

    private static void Misfortune35_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.SuspicionMarker,
            PopUpButton.Accept,
            Foreign);
    }

    // ==========================================
    // WALL EVENT & WITCHWOLF ROUND 2
    // ==========================================

    private static void WallEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string dateStr = GetDate1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr)
               .FormatWithReplacement(2, globalData.CityName));
        globalData.ActiveWindow.AddClickHereToContinue(WallEvent1);
    }

    private static void WallEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WallEvent1b);
    }

    private static void WallEvent1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?>
        {
            gd =>
            {
                gd.FearOfTheUnknownVars.Walls = "yes";
                WallEvent2(gd);
            },
            gd =>
            {
                gd.FearOfTheUnknownVars.Walls = "no";
                WallEvent2(gd);
            }
        }, true);
    }

    private static void WallEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        bool wallsYes = vars.Walls == "yes";
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str =>
            str.FormatWithCondition(0, () => wallsYes));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr)
               .FormatWithReplacement(2, globalData.CityName)
               .FormatWithCondition(3, () => wallsYes));
        globalData.ActiveWindow.AddClickHereToContinue(WallEvent2_0);
    }

    private static void WallEvent2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        bool wallsYes = vars.Walls == "yes";
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_BrickTokens,
            PopUpButton.Accept,
            Witchwolf2a,
            str => str.FormatWithCondition(0, () => wallsYes));
    }

    private static void Witchwolf2a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[0];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf2a_0 }, true);
    }

    private static void Witchwolf2a_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[0];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf2Options(globalData, 0, Witchwolf2b);
    }

    private static void Witchwolf2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[1];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf2b_0 }, true);
    }

    private static void Witchwolf2b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[1];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf2Options(globalData, 1, globalData.PlayersNum >= 3 ? Witchwolf2c : Witchwolf2Hex);
    }

    private static void Witchwolf2c(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[2];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf2c_0 }, true);
    }

    private static void Witchwolf2c_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[2];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf2Options(globalData, 2, globalData.PlayersNum >= 4 ? Witchwolf2d : Witchwolf2Hex);
    }

    private static void Witchwolf2d(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[3];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf2d_0 }, true);
    }

    private static void Witchwolf2d_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[3];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf2Options(globalData, 3, globalData.PlayersNum >= 5 ? Witchwolf2e : Witchwolf2Hex);
    }

    private static void Witchwolf2e(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string pName = globalData.PlayersName[4];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(pName);
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Witchwolf2e_0 }, true);
    }

    private static void Witchwolf2e_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string pName = globalData.PlayersName[4];
        bool isWitch = vars.Witch == pName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, pName)
               .FormatWithCondition(1, () => isWitch));
        AddWitchwolf2Options(globalData, 4, Witchwolf2Hex);
    }

    private static void AddWitchwolf2Options(GlobalData globalData, int playerIdx, Action<GlobalData> nextPassage)
    {
        string[] locations = { "Park", "Builder's Office", "Cemetery" };
        foreach (string loc in locations)
        {
            string selectedLoc = loc;
            globalData.ActiveWindow!.Elements.Add(new GameplayElement(selectedLoc, gd =>
            {
                gd.FearOfTheUnknownVars.SetWit(playerIdx, selectedLoc);
                nextPassage(gd);
            }, true));
        }
    }

    private static void Witchwolf2Hex(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Witch2 = vars.WitAi2;
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.Witch == globalData.PlayersName[i])
            {
                vars.Witch2 = vars.GetWit(i);
                break;
            }
        }

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_WitchHexToken,
            PopUpButton.Accept,
            Foreign,
            str => str.FormatWithReplacement(0, vars.Witch2));
    }

    // ==========================================
    // WITCHWOLF RESOLUTION (END OF MIDDLE YEARS)
    // ==========================================

    private static void Witchwolfresolution(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader)
               .FormatWithReplacement(1, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(Witchres);
    }

    private static void Witchres(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.WSuspect)
               .FormatWithReplacement(1, vars.PointAi)
               .FormatWithReplacement(2, vars.HexAi)
               .FormatWithCondition(3, () => globalData.PlayersNum <= 3));
        globalData.ActiveWindow.AddClickHereToContinue(Witchres1);
    }

    private static void Witchres1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            string candidate = globalData.PlayersName[i];
            globalData.ActiveWindow.Elements.Add(new GameplayElement(candidate, gd =>
            {
                ResolveWitchAccusation(gd, candidate);
            }, true));
        }

        if (globalData.PlayersNum <= 3)
        {
            string suspect = vars.WSuspect;
            globalData.ActiveWindow.Elements.Add(new GameplayElement(suspect, gd =>
            {
                ResolveWitchAccusation(gd, suspect);
            }, true));
        }
    }

    private static void ResolveWitchAccusation(GlobalData globalData, string accused)
    {
        var vars = globalData.FearOfTheUnknownVars;
        if (accused == vars.Witch)
        {
            Witchres2(globalData);
        }
        else
        {
            vars.FalseWitch = accused;
            Witchres3(globalData);
        }
    }

    private static void Witchres2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Cursed = "1";
        bool witchIsSuspect = vars.Witch == vars.WSuspect;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader)
               .FormatWithReplacement(1, vars.Witch)
               .FormatWithReplacement(2, vars.RandomName)
               .FormatWithCondition(3, () => witchIsSuspect));
        globalData.ActiveWindow.AddClickHereToContinue(Witchres2_0);
    }

    private static void Witchres2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        bool witchIsSuspect = vars.Witch == vars.WSuspect;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_WitchHexToken,
            PopUpButton.Accept,
            Caravancheck,
            str => str.FormatWithReplacement(0, vars.Witch)
                      .FormatWithCondition(1, () => !witchIsSuspect));
    }

    private static void Witchres3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Cursed = "2";
        bool falseWitchIsSuspect = vars.FalseWitch == vars.WSuspect;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader)
               .FormatWithReplacement(1, vars.FalseWitch));
        globalData.ActiveWindow.AddClickHereToContinue(Witchres3_0);
    }

    private static void Witchres3_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        bool falseWitchIsSuspect = vars.FalseWitch == vars.WSuspect;
        bool witchIsSuspect = vars.Witch == vars.WSuspect;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Self,
            PopUpButton.Accept,
            Caravancheck,
            str => str.FormatWithReplacement(0, vars.FalseWitch)
                      .FormatWithReplacement(1, vars.Witch)
                      .FormatWithCondition(2, () => !falseWitchIsSuspect)
                      .FormatWithCondition(3, () => !witchIsSuspect));
    }

    // ==========================================
    // END OF GEN 2: S4IsoBrick -> S4Foreign1 / S4Foreign3
    // ==========================================

    internal static void S4IsoBrick(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string dateStr = GetDate1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr)
               .FormatWithReplacement(2, globalData.CityName));
        globalData.ActiveWindow.AddClickHereToContinue(S4IsoBrick_0);
    }

    private static void S4IsoBrick_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        int vpGain = globalData.PlayersNum switch
        {
            2 => 2,
            3 => 3,
            4 => 4,
            _ => 5
        };

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_BrickTokens,
            PopUpButton.Accept,
            RouteFromS4IsoBrick,
            str => str.FormatWithReplacement(0, vpGain.ToString()));
    }

    private static void RouteFromS4IsoBrick(GlobalData globalData)
    {
        var vars = globalData.FearOfTheUnknownVars;
        if (string.IsNullOrEmpty(vars.S4IsoBrickNextPsg) || vars.S4IsoBrickNextPsg == "0")
        {
            vars.S4IsoBrickNextPsg = Random.Shared.Next(2) == 0 ? "S4Foreign1" : "S4Foreign3";
        }

        string next = vars.S4IsoBrickNextPsg;
        vars.S4IsoBrickNextPsg = string.Empty;

        if (next == "S4Foreign1")
        {
            S4Foreign1_EndGenPopup(globalData);
        }
        else if (next == "S4Foreign3")
        {
            S4Foreign3_EndGenPopup(globalData);
        }
        else if (next.StartsWith("Isolation") || next == "IsoEnd")
        {
            Isolation(globalData);
        }
        else if (next.StartsWith("Tension"))
        {
            Tension(globalData);
        }
        else
        {
            Foreign(globalData);
        }
    }

    private static void S4Foreign1_EndGenPopup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            S4Foreign1,
            "Foreign_EndGen_Popup_Content",
            str => str.FormatWithCondition(0, () => vars.RevResolve == 0));
    }

    private static void S4Foreign1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Gen2Fate = "wall";
        bool wallsYes = vars.Walls == "yes";
        vars.Wal = globalData.PlayersNum switch
        {
            2 => wallsYes ? 2 : 3,
            3 => wallsYes ? 3 : 4,
            4 => wallsYes ? 4 : 5,
            _ => wallsYes ? 5 : 6
        };

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddNextContentWithLinks(
            0,
            new List<Action<GlobalData>?> { IsolationIntro, TensionIntro },
            true,
            str => str.FormatWithReplacement(0, vars.Wal.ToString()));
    }

    private static void S4Foreign3_EndGenPopup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            S4Foreign3,
            "Foreign_EndGen_Popup_Content",
            str => str.FormatWithCondition(0, () => vars.RevResolve == 0));
    }

    private static void S4Foreign3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Gen2Fate = "witch";
        bool cursedOne = vars.Cursed == "1";
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr)
               .FormatWithReplacement(2, globalData.CityName)
               .FormatWithCondition(3, () => cursedOne));
        globalData.ActiveWindow.AddClickHereToContinue(
            cursedOne ? TensionIntro : IsolationIntro);
    }
}
