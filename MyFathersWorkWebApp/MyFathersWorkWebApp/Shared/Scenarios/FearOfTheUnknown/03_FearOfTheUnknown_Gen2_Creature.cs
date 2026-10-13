namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    // =========================================================================
    // GENERATION II - THE CREATURE
    // Chapter 03. Ported from the Harlowe passages:
    //   CreatureIntro, CreatureDemands, TheCreatureCard, TheCreatureCard2,
    //   Creature / Creature2 / Creature3 (one Hub, three Years),
    //   Guilt, AsylumOpps, AsylumOpp2, AsylumSignIn, AsylumMeet, AsylumComplete,
    //   BusinessMeet, BusinessMeetb, BusMeetA..D, BusThanks, BusNo, BusBargain,
    //   CountCureQuestion, S4Asylum, S4Asylum2, S4Asylum3,
    //   S4Creature1, S4GoodCreature, S4CompareTotals, S4CountCure,
    //   CureCountYes, CureCountNo, Payment1A..D (+Thanks/No), Payment1Hub,
    //   S4Jail1, S4Jail2, S4BadCreature, RareCreatureBonus.
    // Player E has been dropped - the web app supports 2-4 players only.
    // =========================================================================

    // =========================================================================
    // SHARED HELPERS (no UI, never call SaveToUndo)
    // =========================================================================

    private static int GetFotuPlayerIndexByName(GlobalData globalData, string playerName)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        for (int i = 0; i < 4; i++)
        {
            if (vars.GetPlayerName(globalData, i) == playerName) return i;
        }

        return 0;
    }

    /// <summary>
    /// 0 = Asylum Labor Union, 1 = Key to the Asylum, 2 = Asylum Share.
    /// </summary>
    private static int GetAsylumUpgradeIndex(FearOfTheUnknownVars vars)
    {
        if (vars.AsylumUp == "Key to the Asylum") return 1;
        if (vars.AsylumUp == "Asylum Share") return 2;
        return 0;
    }

    // =========================================================================
    // INTRO CHAIN
    // CreatureIntro -> CreatureDemands -> TheCreatureCard
    //              -> TheCreatureYes / TheCreatureNo -> PEWitch2
    // =========================================================================

    internal static void CreatureIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.Generation = Generation.Second;
        globalData.Years      = Years.Early;

        vars.Path4 = "PECreature";
        vars.Round = 7;
        vars.Mog   = 0;
        vars.Liber = 0;
        vars.Conse = 0;
        vars.Crpg  = 0;

        vars.Asupg = Random.Shared.Next(1, 3);
        vars.AsylumUp = Random.Shared.Next(3) switch
        {
            0 => "Asylum Labor Union",
            1 => "Key to the Asylum",
            _ => "Asylum Share"
        };

        // 0 = Puppy, 1 = Bride, 2 = Puppy and Bride.
        vars.Did1 = Random.Shared.Next(3);

        vars.CureCount     = string.Empty;
        vars.CurePlayer    = string.Empty;
        vars.BHome         = string.Empty;
        vars.BusM          = string.Empty;
        vars.TempAs        = string.Empty;
        vars.Bnc           = 0;
        vars.BusVp         = 0;
        vars.BTemp         = 0;
        vars.AsylumCount   = 0;
        vars.BusinessCount = 0;

        vars.ACont = 0;
        vars.BCont = 0;
        vars.CCont = 0;
        vars.DCont = 0;

        vars.Av = 0;
        vars.Bv = 0;
        vars.Cv = 0;
        vars.Dv = 0;

        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(CreatureDemands);
    }

    internal static void CreatureDemands(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(TheCreatureCard);
    }

    internal static void TheCreatureCard(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddYesNo(TheCreatureYes, TheCreatureNo);
    }

    internal static void TheCreatureNo(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.CreatureCard = "no";
        PEWitch2(globalData);
    }

    internal static void TheCreatureYes(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TheCreatureYes_Setup);
    }

    private static void TheCreatureYes_Setup(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.CreatureCard = "yes";
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_MWUpdateCreature,
            PopUpButton.Accept,
            PEWitch2);
    }

    // =========================================================================
    // THE CREATURE HUB (Early = Creature, Middle = Creature2, Late = Creature3)
    // =========================================================================

    public static void Creature(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.HubId = FearOfUnknownHubId.Creature;
        vars.Round = globalData.Years == Years.Early ? 7 : globalData.Years == Years.Middle ? 8 : 9;

        if (globalData.Years != Years.Early)
        {
            vars.BusVp = 0;
            vars.BTemp = 0;
        }

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        if (globalData.Years == Years.Early)
        {
            if (vars.Crpg == 0)
            {
                if (vars.Creature == 0)
                {
                    vars.Creature =  1;
                    vars.Tracker  += 2;
                    if (globalData.PlayersNum == 4) vars.Tracker += 1;
                }

                GameplayHubSection earlySetupSec = globalData.ActiveHub.AddSection("EarlySetup");
                earlySetupSec.AddDefaultContent(
                    "EarlySetup",
                    str => str
                        .FormatWithReplacement(0, vars.Tracker.ToString())
                        .FormatWithCondition(1, () => vars.Kill == "butcher")
                        .FormatWithCondition(2, () => globalData.PlayersNum == 3));
            }

            GameplayHubSection asylumEarlySec = globalData.ActiveHub.AddSection("AsylumEarly");
            asylumEarlySec.AddDefaultContent("AsylumEarly");
        }
        else
        {
            if (globalData.Years == Years.Middle && vars.Crpg == 0)
            {
                GameplayHubSection middleSetupSec = globalData.ActiveHub.AddSection("MiddleSetup");
                middleSetupSec.AddDefaultContent(
                    "MiddleSetup",
                    str => str.FormatWithCondition(0, () => vars.Kill == "butcher"));
            }

            GameplayHubSection asylumSec = globalData.ActiveHub.AddSection("Asylum");
            asylumSec.AddDefaultContent("Asylum");
            asylumSec.AddClickHere(AsylumSignIn, true);

            GameplayHubSection businessSec = globalData.ActiveHub.AddSection("Business");
            businessSec.AddDefaultContent("Business");
            businessSec.AddClickHere(BusinessMeet, true);
        }

        GameplayHubSection requestsSec = globalData.ActiveHub.AddSection("Requests");
        requestsSec.AddDefaultContent("Requests");
        requestsSec.AddClickHere(Guilt, true);

        GameplayHubSection churchSec = globalData.ActiveHub.AddSection("Church");
        churchSec.AddDefaultContent("Church");
        churchSec.AddClickHere(FotuChurch, true);

        GameplayHubSection faqSec = globalData.ActiveHub.AddSection("ObsessionFAQ");
        faqSec.AddDefaultContent("ObsessionFAQ");
        faqSec.AddClickHere(ObsessionFAQ, true);

        if (globalData.Years == Years.Early)
        {
            GameplayHubSection endRoundSec = globalData.ActiveHub.AddSection("EndOfRound");
            endRoundSec.AddDefaultContent("EndOfRound");
            endRoundSec.AddClickHereContinueNextRound(
                gd => gd.ShowEndOfRoundPopUp(AsylumOpps),
                true);
        }
        else if (globalData.Years == Years.Middle)
        {
            GameplayHubSection endRoundSec = globalData.ActiveHub.AddSection("EndOfRound");
            endRoundSec.AddDefaultContent("EndOfRound");
            endRoundSec.AddClickHereContinueNextRound(
                gd => gd.ShowEndOfRoundPopUp(S4Asylum),
                true);
        }
        else
        {
            globalData.ActiveHub.AddEndOfGenerationSection(S4Creature1);
        }
    }

    // =========================================================================
    // HUB EVENT: Guilt (Creature's Requests Storybook token)
    // =========================================================================

    internal static void Guilt(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Crpg = 1;

        string journalHeader = GetJournal1a(globalData);
        int    flavorIdx     = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithIndex(1, flavorIdx));
        globalData.ActiveWindow.AddClickHereToContinue(Guilt_Setup);
    }

    private static void Guilt_Setup(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.CreatureHelp += 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_CardBack,
            PopUpButton.Accept,
            ReturnToCurrentHub);
    }

    // =========================================================================
    // END OF THE EARLY YEARS: AsylumOpps -> AsylumOpp2 -> Creature (Middle)
    // =========================================================================

    internal static void AsylumOpps(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, letterHeader)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumOpps_Setup);
    }

    private static void AsylumOpps_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Servant,
            PopUpButton.Accept,
            AsylumOpp2);
    }

    internal static void AsylumOpp2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Crpg = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumOpp2_Setup);
    }

    private static void AsylumOpp2_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_HouseOnTheHillTile,
            PopUpButton.Accept,
            Creature);
    }

    // =========================================================================
    // HUB EVENT: The Asylum
    // AsylumSignIn -> AsylumMeet (first visit) / AsylumComplete (repeat visit)
    // =========================================================================

    internal static void AsylumSignIn(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(chosenName =>
        {
            FearOfTheUnknownVars chosenVars = globalData.FearOfTheUnknownVars;
            chosenVars.TempAs = chosenName;

            int chosenIdx = GetFotuPlayerIndexByName(globalData, chosenName);
            chosenVars.VArr[chosenIdx] += 1;

            AsylumMeet(globalData);
        });
    }

    internal static void AsylumMeet(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int                  idx  = GetFotuPlayerIndexByName(globalData, vars.TempAs);

        if (vars.VArr[idx] > 1)
        {
            AsylumComplete(globalData);
            return;
        }

        globalData.SaveToUndo();
        vars.Crpg = 1;

        string dateStr   = GetDate1a(globalData);
        int    flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempAs)
                .FormatWithReplacement(1, dateStr)
                .FormatWithIndex(2, flavorIdx));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumMeet_Setup);
    }

    private static void AsylumMeet_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.GainCaretakerFromLost,
            PopUpButton.Accept,
            ReturnToCurrentHub);
    }

    internal static void AsylumComplete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempAs)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumComplete_Setup);
    }

    private static void AsylumComplete_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            ReturnToCurrentHub,
            str => str.FormatWithReplacement(0, vars.TempAs));
    }

    // =========================================================================
    // HUB EVENT: The Business Meeting (House on the Hill)
    // BusinessMeet -> BusinessMeetIntro -> BusMeetA..D -> BusMeetA1..D1
    //              -> BusThanks / BusBargain / BusNo
    // =========================================================================

    internal static void BusinessMeet(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithIndex(0, flavorIdx));
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(chosenName =>
        {
            globalData.FearOfTheUnknownVars.BusM = chosenName;
            BusinessMeetIntro(globalData);
        });
    }

    internal static void BusinessMeetIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string dateStr   = GetDate1a(globalData);
        int    flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.BusM)
                .FormatWithReplacement(1, dateStr)
                .FormatWithIndex(2, flavorIdx));
        globalData.ActiveWindow.AddClickHereToContinue(BusMeetRoute);
    }

    private static void BusMeetRoute(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        switch (GetFotuPlayerIndexByName(globalData, vars.BusM))
        {
            case 1:  BusMeetB(globalData); return;
            case 2:  BusMeetC(globalData); return;
            case 3:  BusMeetD(globalData); return;
            default: BusMeetA(globalData); return;
        }
    }

    private static void ShowBusMeetPrivacy(GlobalData globalData, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "BusMeetPrivacy");
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.BusM, next);
    }

    private static void ShowBusMeetOffer(GlobalData globalData, int playerIdx, Action<GlobalData> notConvinced)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string playerName = vars.GetPlayerName(globalData, playerIdx);
        int    flavorIdx  = Random.Shared.Next(2);
        bool   homeFree   = string.IsNullOrEmpty(vars.BHome);
        bool   canLabor   = vars.Bnc < 2;
        bool   secondTry  = vars.BusVp == 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "BusMeetOffer");
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, playerName)
                .FormatWithIndex(1, flavorIdx)
                .FormatWithCondition(2, () => secondTry)
                .FormatWithCondition(3, () => canLabor)
                .FormatWithCondition(4, () => homeFree),
            "BusMeetOffer");
        globalData.ActiveWindow.AddChoose();

        if (homeFree)
        {
            globalData.ActiveWindow.AddNextContentWithLinks(
                1,
                new List<Action<GlobalData>?>
                {
                    gd =>
                    {
                        FearOfTheUnknownVars gdVars = gd.FearOfTheUnknownVars;
                        gdVars.ContArr[playerIdx] += 3;
                        gdVars.BHome              =  playerName;
                        BusThanks(gd);
                    }
                },
                true,
                null,
                "BusMeetOffer");
        }

        if (canLabor)
        {
            globalData.ActiveWindow.AddNextContentWithLinks(
                2,
                new List<Action<GlobalData>?>
                {
                    gd =>
                    {
                        FearOfTheUnknownVars gdVars = gd.FearOfTheUnknownVars;
                        gdVars.ContArr[playerIdx] += 2;
                        gdVars.BTemp              =  1;
                        gdVars.Bnc                += 1;
                        BusThanks(gd);
                    }
                },
                true,
                null,
                "BusMeetOffer");
        }

        globalData.ActiveWindow.AddNextContentWithLinks(
            3,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.ContArr[playerIdx] += 1;
                    BusThanks(gd);
                }
            },
            true,
            null,
            "BusMeetOffer");

        if (secondTry)
        {
            globalData.ActiveWindow.AddNextContentWithLinks(
                5,
                new List<Action<GlobalData>?> { BusNo },
                true,
                null,
                "BusMeetOffer");
        }
        else
        {
            globalData.ActiveWindow.AddNextContentWithLinks(
                4,
                new List<Action<GlobalData>?> { notConvinced },
                true,
                null,
                "BusMeetOffer");
        }
    }

    private static void ResolveBusMeetBargain(GlobalData globalData, string storedChoice, Action<string> store)
    {
        string choice = storedChoice;
        if (string.IsNullOrEmpty(choice))
        {
            choice = Random.Shared.Next(2) == 0 ? "BusBargain" : "BusNo";
            store(choice);
        }

        if (choice == "BusBargain") BusBargain(globalData);
        else BusNo(globalData);
    }

    internal static void BusMeetA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetPrivacy(globalData, BusMeetA1);
    }

    internal static void BusMeetA1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetOffer(globalData, 0, BusMeetA2);
    }

    private static void BusMeetA2(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        ResolveBusMeetBargain(globalData, vars.BusMeetANextPsg, value => vars.BusMeetANextPsg = value);
    }

    internal static void BusMeetB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetPrivacy(globalData, BusMeetB1);
    }

    internal static void BusMeetB1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetOffer(globalData, 1, BusMeetB2);
    }

    private static void BusMeetB2(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        ResolveBusMeetBargain(globalData, vars.BusMeetBNextPsg, value => vars.BusMeetBNextPsg = value);
    }

    internal static void BusMeetC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetPrivacy(globalData, BusMeetC1);
    }

    internal static void BusMeetC1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetOffer(globalData, 2, BusMeetC2);
    }

    private static void BusMeetC2(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        ResolveBusMeetBargain(globalData, vars.BusMeetCNextPsg, value => vars.BusMeetCNextPsg = value);
    }

    internal static void BusMeetD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetPrivacy(globalData, BusMeetD1);
    }

    internal static void BusMeetD1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowBusMeetOffer(globalData, 3, BusMeetD2);
    }

    private static void BusMeetD2(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        ResolveBusMeetBargain(globalData, vars.BusMeetDNextPsg, value => vars.BusMeetDNextPsg = value);
    }

    internal static void BusBargain(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.BusVp = 1;
        vars.Crpg  = 1;

        int flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.BusM)
                .FormatWithIndex(1, flavorIdx));
        globalData.ActiveWindow.AddClickHereToContinue(BusMeetRoute);
    }

    internal static void BusNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Crpg = 1;

        int flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.BusM)
                .FormatWithIndex(1, flavorIdx));
        globalData.ActiveWindow.AddClickHereToContinue(ReturnToCurrentHub);
    }

    internal static void BusThanks(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Crpg = 1;

        bool cureAlreadyOffered = vars.CureCount == "no" || vars.CureCount == "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.BusM)
                .FormatWithCondition(1, () => cureAlreadyOffered));
        globalData.ActiveWindow.AddClickHereToContinue(BusThanksResolve);
    }

    private static void BusThanksResolve(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        if (vars.BTemp == 1)
        {
            BusThanks_UpgradeSetup(globalData);
            return;
        }

        if (vars.BusVp == 1)
        {
            BusThanks_VpSetup(globalData);
            return;
        }

        BusThanksNext(globalData);
    }

    private static void BusThanks_UpgradeSetup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars    = globalData.FearOfTheUnknownVars;
        int                  bonusVp = Random.Shared.Next(2, 4);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            BusThanksNext,
            str => str
                .FormatWithReplacement(0, bonusVp.ToString())
                .FormatWithCondition(1, () => vars.BusVp == 1));
    }

    private static void BusThanks_VpSetup(GlobalData globalData)
    {
        int bonusVp = Random.Shared.Next(2, 4);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            BusThanksNext,
            str => str.FormatWithReplacement(0, bonusVp.ToString()));
    }

    private static void BusThanksNext(GlobalData globalData)
    {
        if (string.IsNullOrEmpty(globalData.FearOfTheUnknownVars.CureCount))
        {
            CountCureQuestion(globalData);
            return;
        }

        ReturnToCurrentHub(globalData);
    }

    // =========================================================================
    // HUB EVENT: The Count's request for a cure (seeded by the first BusThanks)
    // =========================================================================

    internal static void CountCureQuestion(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.BusM, CountCureQuestion1);
    }

    internal static void CountCureQuestion1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.CureCount  = "no";
        vars.CurePlayer = vars.BusM;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.BusM));
        globalData.ActiveWindow.AddClickHereToContinue(CountCureQuestion1_Setup);
    }

    private static void CountCureQuestion1_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.StorybookToken,
            PopUpButton.Accept,
            ReturnToCurrentHub);
    }

    // =========================================================================
    // END OF THE MIDDLE YEARS: S4Asylum -> S4Asylum2 -> S4Asylum3 -> Creature (Late)
    // =========================================================================

    internal static void S4Asylum(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(S4Asylum_Setup);
    }

    private static void S4Asylum_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        int                  upgradeIdx = GetAsylumUpgradeIndex(vars);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            S4Asylum2,
            str => str.FormatWithIndex(0, upgradeIdx));
    }

    internal static void S4Asylum2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Jail = 1;

        int upgradeIdx = GetAsylumUpgradeIndex(vars);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithIndex(0, upgradeIdx)
                .FormatWithIndex(1, upgradeIdx));
        globalData.ActiveWindow.AddClickHereToContinue(S4Asylum2_Setup);
    }

    private static void S4Asylum2_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            S4Asylum3,
            str => str.FormatWithReplacement(0, vars.Asupg.ToString()));
    }

    internal static void S4Asylum3(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();

        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { gd => S4AsylumVote(gd, 0) },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { gd => S4AsylumVote(gd, 1) },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            3,
            new List<Action<GlobalData>?> { gd => S4AsylumVote(gd, 2) },
            true);

        if (globalData.PlayersNum > 2)
        {
            globalData.ActiveWindow.AddNextContentWithLinks(
                4,
                new List<Action<GlobalData>?> { gd => S4AsylumVote(gd, 3) },
                true);
        }

        if (globalData.PlayersNum > 3)
        {
            globalData.ActiveWindow.AddNextContentWithLinks(
                5,
                new List<Action<GlobalData>?> { gd => S4AsylumVote(gd, 4) },
                true);
        }
    }

    private static void S4AsylumVote(GlobalData globalData, int buyers)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.AsylumCount += vars.Asupg * buyers;
        Creature(globalData);
    }

    // =========================================================================
    // END OF THE GENERATION (Late Years)
    // S4Creature1 -> S4GoodCreature / S4CompareTotals -> S4CountCure
    //             -> Payment1A..D -> Payment1Hub -> S4Jail1 / S4Jail2
    //             -> S4BadCreature -> RareCreatureBonus -> Liberal / Privatized
    // =========================================================================

    internal static void S4Creature1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.BusinessCount = vars.ACont + vars.BCont + vars.CCont + vars.DCont;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithIndex(0, vars.Did1)
                .FormatWithIndex(1, vars.Did1));
        globalData.ActiveWindow.AddYesNo(S4CreatureYes, S4CreatureNo);
    }

    private static void S4CreatureYes(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.Creature = 2;
        S4GoodCreature(globalData);
    }

    private static void S4CreatureNo(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.Creature = 1;
        S4CompareTotals(globalData);
    }

    internal static void S4GoodCreature(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Revenge = 0;

        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(S4CompareTotals);
    }

    internal static void S4CompareTotals(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string asylumTotal = vars.AsylumCount.ToString();
        string countTotal  = vars.BusinessCount.ToString();

        // 0 = tie (Asylum wins the tie-break), 1 = the Count wins, 2 = the Asylum wins.
        int outcome;
        if (vars.AsylumCount == vars.BusinessCount)
        {
            vars.AsylumCount += 1;
            outcome          =  0;
        }
        else if (vars.BusinessCount > vars.AsylumCount)
        {
            vars.Jail = 2;
            outcome   = 1;
        }
        else
        {
            vars.Jail = 1;
            outcome   = 2;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, asylumTotal)
                .FormatWithReplacement(1, countTotal)
                .FormatWithIndex(2, outcome));
        globalData.ActiveWindow.AddClickHereToContinue(S4CountCure);
    }

    internal static void S4CountCure(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CureCount != "no")
        {
            Payment1A(globalData);
            return;
        }

        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.CurePlayer, S4CountCure1);
    }

    internal static void S4CountCure1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.CurePlayer)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { S4CountCureYes },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { S4CountCureNo },
            true);
    }

    private static void S4CountCureYes(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.CureCount = "yes";
        CureCountYes(globalData);
    }

    private static void S4CountCureNo(GlobalData globalData)
    {
        globalData.FearOfTheUnknownVars.CureCount = "no";
        CureCountNo(globalData);
    }

    internal static void CureCountYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.CurePlayer));
        globalData.ActiveWindow.AddClickHereToContinue(CureCountYes_Setup);
    }

    private static void CureCountYes_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ExperimentCBack,
            PopUpButton.Accept,
            Payment1A);
    }

    internal static void CureCountNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.CurePlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Payment1A);
    }

    // -------------------------------------------------------------------------
    // Collection Day - shared presentation helpers.
    // -------------------------------------------------------------------------

    private static void ShowPaymentPrivacy(GlobalData globalData, int playerIdx, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, playerIdx);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "Payment1Privacy");
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, next);
    }

    private static void ShowPaymentCollection(GlobalData globalData, int playerIdx, Action<GlobalData> yes, Action<GlobalData> no)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, playerIdx);
        string               owed       = vars.ContArr[playerIdx].ToString();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "Payment1Collection");
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, playerName)
                .FormatWithReplacement(1, owed),
            "Payment1Collection");
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { yes },
            true,
            null,
            "Payment1Collection");
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { no },
            true,
            null,
            "Payment1Collection");
    }

    private static void ShowPaymentThanks(GlobalData globalData, int playerIdx, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, playerIdx);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "Payment1Thanks");
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, playerName),
            "Payment1Thanks");
        globalData.ActiveWindow.AddClickHereToContinue(next);
    }

    private static void ShowPaymentRefusal(GlobalData globalData, int playerIdx, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, playerIdx);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "Payment1No");
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, playerName),
            "Payment1No");
        globalData.ActiveWindow.AddClickHereToContinue(next);
    }

    private static void Payment1AfterB(GlobalData globalData)
    {
        if (globalData.PlayersNum > 2) Payment1C(globalData);
        else Payment1Hub(globalData);
    }

    private static void Payment1AfterC(GlobalData globalData)
    {
        if (globalData.PlayersNum > 3) Payment1D(globalData);
        else Payment1Hub(globalData);
    }

    // -------------------------------------------------------------------------
    // Collection Day - Player A
    // -------------------------------------------------------------------------

    internal static void Payment1A(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.ACont == 0)
        {
            Payment1B(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentPrivacy(globalData, 0, Payment1A1);
    }

    internal static void Payment1A1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentCollection(globalData, 0, Payment1ThanksA, Payment1NoA);
    }

    internal static void Payment1ThanksA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentThanks(globalData, 0, Payment1ThanksA_Setup);
    }

    private static void Payment1ThanksA_Setup(GlobalData globalData)
    {
        string owed = globalData.FearOfTheUnknownVars.ACont.ToString();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            gd =>
            {
                gd.FearOfTheUnknownVars.ACont = 0;
                Payment1B(gd);
            },
            "Payment1Thanks_Setup_Content",
            str => str.FormatWithReplacement(0, owed));
    }

    internal static void Payment1NoA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentRefusal(globalData, 0, gd =>
        {
            gd.FearOfTheUnknownVars.ACont += 1;
            Payment1B(gd);
        });
    }

    // -------------------------------------------------------------------------
    // Collection Day - Player B
    // -------------------------------------------------------------------------

    internal static void Payment1B(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.BCont == 0)
        {
            Payment1AfterB(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentPrivacy(globalData, 1, Payment1B1);
    }

    internal static void Payment1B1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentCollection(globalData, 1, Payment1ThanksB, Payment1NoB);
    }

    internal static void Payment1ThanksB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentThanks(globalData, 1, Payment1ThanksB_Setup);
    }

    private static void Payment1ThanksB_Setup(GlobalData globalData)
    {
        string owed = globalData.FearOfTheUnknownVars.BCont.ToString();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            gd =>
            {
                gd.FearOfTheUnknownVars.BCont = 0;
                Payment1AfterB(gd);
            },
            "Payment1Thanks_Setup_Content",
            str => str.FormatWithReplacement(0, owed));
    }

    internal static void Payment1NoB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentRefusal(globalData, 1, gd =>
        {
            gd.FearOfTheUnknownVars.BCont += 1;
            Payment1AfterB(gd);
        });
    }

    // -------------------------------------------------------------------------
    // Collection Day - Player C
    // -------------------------------------------------------------------------

    internal static void Payment1C(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CCont == 0)
        {
            Payment1AfterC(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentPrivacy(globalData, 2, Payment1C1);
    }

    internal static void Payment1C1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentCollection(globalData, 2, Payment1ThanksC, Payment1NoC);
    }

    internal static void Payment1ThanksC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentThanks(globalData, 2, Payment1ThanksC_Setup);
    }

    private static void Payment1ThanksC_Setup(GlobalData globalData)
    {
        string owed = globalData.FearOfTheUnknownVars.CCont.ToString();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            gd =>
            {
                gd.FearOfTheUnknownVars.CCont = 0;
                Payment1AfterC(gd);
            },
            "Payment1Thanks_Setup_Content",
            str => str.FormatWithReplacement(0, owed));
    }

    internal static void Payment1NoC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentRefusal(globalData, 2, gd =>
        {
            gd.FearOfTheUnknownVars.CCont += 1;
            Payment1AfterC(gd);
        });
    }

    // -------------------------------------------------------------------------
    // Collection Day - Player D
    // -------------------------------------------------------------------------

    internal static void Payment1D(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.DCont == 0)
        {
            Payment1Hub(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentPrivacy(globalData, 3, Payment1D1);
    }

    internal static void Payment1D1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentCollection(globalData, 3, Payment1ThanksD, Payment1NoD);
    }

    internal static void Payment1ThanksD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentThanks(globalData, 3, Payment1ThanksD_Setup);
    }

    private static void Payment1ThanksD_Setup(GlobalData globalData)
    {
        string owed = globalData.FearOfTheUnknownVars.DCont.ToString();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            gd =>
            {
                gd.FearOfTheUnknownVars.DCont = 0;
                Payment1Hub(gd);
            },
            "Payment1Thanks_Setup_Content",
            str => str.FormatWithReplacement(0, owed));
    }

    internal static void Payment1NoD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentRefusal(globalData, 3, gd =>
        {
            gd.FearOfTheUnknownVars.DCont += 1;
            Payment1Hub(gd);
        });
    }

    // -------------------------------------------------------------------------
    // The Fate of the Town
    // -------------------------------------------------------------------------

    internal static void Payment1Hub(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        if (string.IsNullOrEmpty(vars.Payment1HubNextPsg))
        {
            vars.Payment1HubNextPsg = Random.Shared.Next(2) == 0 ? "S4Jail2" : "S4Jail1";
        }

        if (vars.Payment1HubNextPsg == "S4Jail2") S4Jail2(globalData);
        else S4Jail1(globalData);
    }

    internal static void S4Jail1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.Gen2Fate = "creature";
        vars.Gen2End  = vars.Creature == 2 ? "asylum" : "jail";

        int  upgradeIdx = GetAsylumUpgradeIndex(vars);
        bool noHouse    = string.IsNullOrEmpty(vars.BHome);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithIndex(0, upgradeIdx)
                .FormatWithCondition(1, () => noHouse)
                .FormatWithCondition(2, () => vars.Creature == 2));
        globalData.ActiveWindow.AddClickHereToContinue(S4BadCreature);
    }

    internal static void S4Jail2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.Gen2Fate = "money";
        vars.Gen2End  = vars.Jail == 2 ? "jail" : "asylum";

        int  upgradeIdx = GetAsylumUpgradeIndex(vars);
        bool noHouse    = string.IsNullOrEmpty(vars.BHome);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithIndex(0, upgradeIdx)
                .FormatWithCondition(1, () => noHouse)
                .FormatWithCondition(2, () => vars.Jail == 2));
        globalData.ActiveWindow.AddClickHereToContinue(S4BadCreature);
    }

    internal static void S4BadCreature(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Creature != 1)
        {
            Gen2CreatureEnding(globalData);
            return;
        }

        globalData.SaveToUndo();
        vars.Revenge = 1;

        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(S4BadCreature_Setup);
    }

    private static void S4BadCreature_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Bodies_Icon,
            PopUpButton.Accept,
            RareCreatureBonus);
    }

    internal static void RareCreatureBonus(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CreatureHelp != 1)
        {
            Gen2CreatureEnding(globalData);
            return;
        }

        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RareCreatureBonus_Setup);
    }

    private static void RareCreatureBonus_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AdvanceJournalTrack,
            PopUpButton.Accept,
            Gen2CreatureEnding);
    }

    private static void Gen2CreatureEnding(GlobalData globalData)
    {
        if (globalData.FearOfTheUnknownVars.Gen2End == "asylum") LiberalIntro(globalData);
        else PrivatizedIntro(globalData);
    }
}
