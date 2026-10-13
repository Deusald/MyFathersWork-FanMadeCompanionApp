namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    // =========================================================================
    // GENERATION III - ISOLATION: INTRO CHAIN
    // IsolationIntro -> IsoBricksRes -> WitchIsolationResolution -> Creepy1stPlayer -> PEWitch3Intro
    // =========================================================================

    internal static void IsolationIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.Generation = Generation.Third;
        globalData.Years = Years.Early;
        vars.Path4 = "PEIsolation";
        vars.Visit = 1;
        vars.IsoOff = 0;

        string randomPlayer = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, randomPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(IsoBricksRes);
    }

    internal static void IsoBricksRes(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Gen2Fate != "witch")
        {
            WitchIsolationResolution(globalData);
            return;
        }

        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(IsoBricksRes_Setup);
    }

    private static void IsoBricksRes_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.SuspicionMarker,
            PopUpButton.Confirm,
            WitchIsolationResolution,
            str => str.FormatWithReplacement(0, vars.Tracker.ToString()));
    }

    internal static void WitchIsolationResolution(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Cursed != "1" || vars.Witch == vars.WSuspect)
        {
            Creepy1stPlayer(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.Witch));
        globalData.ActiveWindow.AddClickHereToContinue(WitchIsolationResolution_Setup);
    }

    private static void WitchIsolationResolution_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Creepy1stPlayer,
            str => str.FormatWithReplacement(0, vars.Witch));
    }

    internal static void Creepy1stPlayer(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string randomPlayer = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, randomPlayer)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(Creepy1stPlayer_Setup);
    }

    private static void Creepy1stPlayer_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            PEWitch3Intro);
    }

    // =========================================================================
    // GENERATION III - ISOLATION HUB (Early, Middle, Late Years)
    // =========================================================================

    public static void Isolation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.HubId = FearOfUnknownHubId.Isolation;
        vars.Round = globalData.Years == Years.Early ? 10 : globalData.Years == Years.Middle ? 11 : 12;

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        if (globalData.Years == Years.Early)
        {
            GameplayHubSection setupSec = globalData.ActiveHub.AddSection("Setup");
            setupSec.ReplaceShouldShow(() => vars.IsoOff == 0);
            setupSec.AddDefaultContent(
                "Setup",
                str => str
                    .FormatWithReplacement(0, vars.Tracker.ToString())
                    .FormatWithCondition(1, () => globalData.PlayersNum == 3));

            GameplayHubSection pricesSec = globalData.ActiveHub.AddSection("RisingPrices");
            pricesSec.AddDefaultContent("RisingPrices");
        }

        if (globalData.Years == Years.Middle || globalData.Years == Years.Late)
        {
            if (globalData.Years == Years.Late)
            {
                GameplayHubSection lateSetupSec = globalData.ActiveHub.AddSection("LateSetup");
                lateSetupSec.ReplaceShouldShow(() => vars.IsoOff == 0 && vars.Dev > 0);
                lateSetupSec.AddDefaultContent(
                    "LateSetup",
                    str => str.FormatWithReplacement(0, vars.Dev.ToString()));
            }

            GameplayHubSection brazenSec = globalData.ActiveHub.AddSection("BrazenOffer");
            brazenSec.AddDefaultContent("BrazenOffer");
            brazenSec.AddClickHere(SmugConsequence, true);
        }

        if (globalData.Years == Years.Early || globalData.Years == Years.Middle || vars.Dev == 0)
        {
            GameplayHubSection verifySec = globalData.ActiveHub.AddSection("Verification");
            verifySec.AddDefaultContent("Verification");
            verifySec.AddClickHere(IsoIdentificationSignIn, true);
        }

        if (globalData.Years == Years.Middle)
        {
            int exIndex = vars.Ex == "bio" ? 0 : vars.Ex == "chem" ? 1 : 2;
            GameplayHubSection expSec = globalData.ActiveHub.AddSection("TheExperiment");
            expSec.AddDefaultContent(
                "TheExperiment",
                str => str
                    .FormatWithIndex(0, exIndex)
                    .FormatWithCondition(1, () => globalData.PlayersNum > 2));
        }

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
                gd => gd.ShowEndOfRoundPopUp(IsolationEarlyEndRound),
                true);
        }
        else if (globalData.Years == Years.Middle)
        {
            GameplayHubSection endRoundSec = globalData.ActiveHub.AddSection("EndOfRound");
            endRoundSec.AddDefaultContent("EndOfRound");
            endRoundSec.AddClickHereContinueNextRound(
                gd => gd.ShowEndOfRoundPopUp(SmugEvent2),
                true);
        }
        else
        {
            globalData.ActiveHub.AddEndOfGenerationSection(IsolationCaravanResolve);
        }
    }

    private static void IsolationEarlyEndRound(GlobalData globalData)
    {
        globalData.Years = Years.Middle;
        globalData.FearOfTheUnknownVars.Round = 10;
        Caravancheck(globalData);
    }

    // =========================================================================
    // HUB ACTION: VERIFICATION OF IDENTITY (IsoIdentificationSignIn -> IsoIdentification)
    // =========================================================================

    internal static void IsoIdentificationSignIn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(name =>
        {
            FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
            vars.TempId = name;
            vars.Id++;
            if (name == vars.GetPlayerName(globalData, 0)) vars.IdA = "yes";
            else if (name == vars.GetPlayerName(globalData, 1)) vars.IdB = "yes";
            else if (name == vars.GetPlayerName(globalData, 2)) vars.IdC = "yes";
            else if (name == vars.GetPlayerName(globalData, 3)) vars.IdD = "yes";
            else vars.IdE = "yes";

            IsoIdentification(globalData);
        });
    }

    internal static void IsoIdentification(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.IsoOff = 1;
        vars.TempCreep = Random.Shared.Next(2).ToString();
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(IsoIdentification_Setup);
    }

    private static void IsoIdentification_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Isolation,
            str => str.FormatWithCondition(0, () => vars.TempCreep == "0"));
    }

    // =========================================================================
    // HUB ACTION: SMUGGLING GOODS (SmugConsequence -> S4Con1 / S4Con2 / S4Con3)
    // =========================================================================

    internal static void SmugConsequence(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.IsoOff = 1;
        if (string.IsNullOrEmpty(vars.SmugConsequenceNextPsg))
        {
            int roll = Random.Shared.Next(3);
            vars.SmugConsequenceNextPsg = roll == 0 ? "S4Con1" : roll == 1 ? "S4Con2" : "S4Con3";
        }

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, dateStr));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(name =>
        {
            vars.TempId = name;
            for (int i = 0; i < globalData.PlayersNum; i++)
            {
                if (name == vars.GetPlayerName(globalData, i))
                {
                    vars.Smug[i]++;
                    break;
                }
            }

            string nextPsg = vars.SmugConsequenceNextPsg;
            vars.SmugConsequenceNextPsg = string.Empty;
            if (nextPsg == "S4Con1") S4Con1(globalData);
            else if (nextPsg == "S4Con2") S4Con2(globalData);
            else S4Con3(globalData);
        });
    }

    internal static void S4Con1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(S4Con1_Setup);
    }

    private static void S4Con1_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Isolation);
    }

    internal static void S4Con2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string dateStr = GetDate1a(globalData);
        int bribeAmount = Random.Shared.Next(1, 3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Pay = 1;
                    S4Con2A(gd);
                }
            },
            true,
            str => str.FormatWithReplacement(0, bribeAmount.ToString()));
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Pay = 0;
                    gd.FearOfTheUnknownVars.Trial = Random.Shared.Next(3);
                    S4Con2A(gd);
                }
            },
            true);
    }

    internal static void S4Con2A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        bool isSuccess = vars.Pay == 1 || vars.Trial == 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str =>
            str.FormatWithCondition(0, () => isSuccess));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithCondition(0, () => isSuccess));
        globalData.ActiveWindow.AddClickHereToContinue(S4Con2A_Setup);
    }

    private static void S4Con2A_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        bool isSuccess = vars.Pay == 1 || vars.Trial == 0;
        int outcomeIdx = isSuccess ? 0 : vars.Trial == 1 ? 1 : 2;
        int vpLoss = Random.Shared.Next(1, 3);
        string icon = outcomeIdx == 0
            ? PopUpIcon.MFWlogo
            : outcomeIdx == 1
                ? PopUpIcon.Creepy_Icon
                : PopUpIcon.ScoreTrackMarker;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            Isolation,
            str => str
                .FormatWithReplacement(0, vpLoss.ToString())
                .FormatWithIndex(1, outcomeIdx));
    }

    internal static void S4Con3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.TempBs = Random.Shared.Next(1, 3);
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(S4Con3_Setup);
    }

    private static void S4Con3_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Isolation,
            str => str.FormatWithCondition(0, () => vars.TempBs == 1));
    }

    // =========================================================================
    // END OF EARLY YEARS: S4Smug -> SmugEvent -> SmugEventA -> Isolation (Middle Years)
    // =========================================================================

    internal static void S4Smug(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Years = Years.Middle;
        globalData.FearOfTheUnknownVars.Round = 11;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(S4Smug_Setup);
    }

    private static void S4Smug_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            SmugEvent);
    }

    internal static void SmugEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Ex = "bio";
                    SmugEventA(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Ex = "chem";
                    SmugEventA(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            3,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Ex = "eng";
                    SmugEventA(gd);
                }
            },
            true);
    }

    internal static void SmugEventA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Collab = globalData.PlayersNum switch
        {
            2 => 3,
            3 => 2,
            4 => Random.Shared.Next(2, 4),
            _ => Random.Shared.Next(3, 5)
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(SmugEventA_Setup);
    }

    private static void SmugEventA_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int exIdx = vars.Ex == "bio" ? 0 : vars.Ex == "chem" ? 1 : 2;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_CollaborativeToken,
            PopUpButton.Confirm,
            Isolation,
            str => str
                .FormatWithReplacement(0, vars.Collab.ToString())
                .FormatWithIndex(1, exIdx));
    }

    // =========================================================================
    // END OF MIDDLE YEARS: SmugEvent2 -> SmugEvent2A / SmugEvent2B -> Caravancheck -> Isolation (Late Years)
    // =========================================================================

    internal static void SmugEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.Years = Years.Late;
        vars.Dev = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.Collab.ToString()));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddYesNo(
            gd =>
            {
                gd.FearOfTheUnknownVars.Control = 1;
                SmugEvent2A(gd);
            },
            gd =>
            {
                gd.FearOfTheUnknownVars.Control = 0;
                SmugEvent2B(gd);
            });
    }

    internal static void SmugEvent2A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Ending = "FOTU-End1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Newspaper)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(SmugEvent2A_Setup);
    }

    private static void SmugEvent2A_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int creepyLoss = Random.Shared.Next(2, 4);
        string pA = vars.GetPlayerName(globalData, 0);
        string pB = vars.GetPlayerName(globalData, 1);
        string pC = vars.GetPlayerName(globalData, 2);
        string pD = vars.GetPlayerName(globalData, 3);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_CollaborativeToken,
            PopUpButton.Confirm,
            SmugEvent2ACont,
            str => str
                .FormatWithReplacement(0, pA)
                .FormatWithReplacement(1, pB)
                .FormatWithReplacement(2, pC)
                .FormatWithReplacement(3, pD)
                .FormatWithReplacement(4, creepyLoss.ToString())
                .FormatWithCondition(5, () => globalData.PlayersNum == 2)
                .FormatWithCondition(6, () => vars.IdA == "yes")
                .FormatWithCondition(7, () => vars.IdB == "yes")
                .FormatWithCondition(8, () => vars.IdC == "yes")
                .FormatWithCondition(9, () => vars.IdD == "yes")
                .FormatWithCondition(10, () => vars.Id > 0));
    }

    internal static void SmugEvent2ACont(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Dev = 16;
        int exIdx = vars.Ex == "chem" ? 0 : vars.Ex == "eng" ? 1 : 2;
        bool goToBankDestruction = Random.Shared.Next(3) < 2;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithIndex(1, exIdx));
        globalData.ActiveWindow.AddClickHereToContinue(
            goToBankDestruction ? SmugEvent2Aa : SmugEventEnd);
    }

    internal static void SmugEvent2Aa(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Dev = 17;
        bool goToLibraryDestruction = Random.Shared.Next(2) == 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(
            goToLibraryDestruction ? SmugEvent2aa_Library : SmugEventEnd);
    }

    internal static void SmugEvent2aa_Library(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Dev = 18;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(SmugEvent2aa_Library_Setup);
    }

    private static void SmugEvent2aa_Library_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Accept,
            Caravancheck);
    }

    internal static void SmugEventEnd(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(SmugEventEnd_Setup);
    }

    private static void SmugEventEnd_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int moveLeft = vars.Dev == 16 ? 1 : 2;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Accept,
            Caravancheck,
            str => str.FormatWithReplacement(0, moveLeft.ToString()));
    }

    internal static void SmugEvent2B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Ending = "FOTU-End2";
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(SmugEvent2B_Setup);
    }

    private static void SmugEvent2B_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_CollaborativeToken,
            PopUpButton.Confirm,
            Caravancheck,
            str => str.FormatWithCondition(0, () => globalData.PlayersNum == 2));
    }

    // =========================================================================
    // END OF LATE YEARS: IsolationCaravanResolve -> IsoVerify -> PEWitchEnding
    // =========================================================================

    internal static void IsolationCaravanResolve(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CarCount != 0)
        {
            IsoVerify(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Newspaper)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(IsolationCaravanResolve_Setup);
    }

    private static void IsolationCaravanResolve_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_MarketToken,
            PopUpButton.Accept,
            IsoVerify);
    }

    internal static void IsoVerify(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Dev != 0)
        {
            PEWitchEnding(globalData);
            return;
        }

        globalData.SaveToUndo();
        string pA = vars.GetPlayerName(globalData, 0);
        string pB = vars.GetPlayerName(globalData, 1);
        string pC = vars.GetPlayerName(globalData, 2);
        string pD = vars.GetPlayerName(globalData, 3);
        bool allVerified = vars.Id >= globalData.PlayersNum;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, pA)
                .FormatWithReplacement(1, pB)
                .FormatWithReplacement(2, pC)
                .FormatWithReplacement(3, pD)
                .FormatWithCondition(4, () => vars.IdA != "yes")
                .FormatWithCondition(5, () => vars.IdB != "yes")
                .FormatWithCondition(6, () => globalData.PlayersNum > 2 && vars.IdC != "yes")
                .FormatWithCondition(7, () => globalData.PlayersNum > 3 && vars.IdD != "yes")
                .FormatWithCondition(8, () => allVerified));
        globalData.ActiveWindow.AddClickHereToContinue(PEWitchEnding);
    }
}
