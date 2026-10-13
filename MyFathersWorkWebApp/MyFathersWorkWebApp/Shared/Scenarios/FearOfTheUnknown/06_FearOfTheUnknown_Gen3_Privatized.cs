namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    // =========================================================================
    // GENERATION III - PRIVATIZED: INTRO CHAIN
    // PrivatizedIntro -> PrivatetoJail -> PrivateInvestors -> PrivateCountCure
    //                 -> PrivateHomeTile -> PrivateCountYesNo -> PEWitch3Intro
    // =========================================================================

    internal static void PrivatizedIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.Generation = Generation.Third;
        globalData.Years      = Years.Early;

        vars.Path4      = "PEPrivatized";
        vars.Exped      = 0;
        vars.Hunt       = 0;
        vars.CreepCount = 0;
        vars.Pripg      = 0;
        vars.Gen3Pg     = 0;
        vars.Privatized = 0;
        vars.ElimCount  = 0;
        vars.Warden     = vars.Kill == "butcher" ? "The Butcher" : "The Bloodsmith";

        // 0 = "Lose 5VP", 1 = "Discard a Vanity Estate Upgrade".
        vars.JunkPenalty = Random.Shared.Next(2);

        string randomPlayer = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, randomPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(PrivatetoJail);
    }

    internal static void PrivatetoJail(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, letterHeader)
                .FormatWithReplacement(1, globalData.TownName)
                .FormatWithCondition(2, () => vars.Jail == 2));
        globalData.ActiveWindow.AddClickHereToContinue(PrivatetoJail_Setup);
    }

    private static void PrivatetoJail_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            PrivateInvestors);
    }

    internal static void PrivateInvestors(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(PrivateInvestors_Setup);
    }

    private static void PrivateInvestors_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_ColoredMoneyToken,
            PopUpButton.Accept,
            PrivateCountCure);
    }

    internal static void PrivateCountCure(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CureCount != "yes")
        {
            PrivateHomeTile(globalData);
            return;
        }

        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.CurePlayer));
        globalData.ActiveWindow.AddClickHereToContinue(PrivateCountCure_Setup);
    }

    private static void PrivateCountCure_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_BlessingOfTheStrigoi,
            PopUpButton.Accept,
            PrivateHomeTile,
            str => str.FormatWithReplacement(0, vars.CurePlayer));
    }

    internal static void PrivateHomeTile(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (string.IsNullOrEmpty(vars.BHome))
        {
            PrivateCountYesNo(globalData);
            return;
        }

        globalData.SaveToUndo();
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.BHome)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(PrivateHomeTile_Setup);
    }

    private static void PrivateHomeTile_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_HouseOnTheHillTile,
            PopUpButton.Accept,
            PrivateCountYesNo,
            str => str.FormatWithReplacement(0, vars.BHome));
    }

    internal static void PrivateCountYesNo(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Jail != 2)
        {
            PEWitch3Intro(globalData);
            return;
        }

        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(PrivateCountYesNo_Setup);
    }

    private static void PrivateCountYesNo_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.GainServantFromLost,
            PopUpButton.Accept,
            PEWitch3Intro);
    }

    // =========================================================================
    // GENERATION III - PRIVATIZED HUB (Early, Middle, Late Years)
    // =========================================================================

    public static void Privatized(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.HubId = FearOfUnknownHubId.Privatized;
        vars.Round = globalData.Years == Years.Early ? 16 : globalData.Years == Years.Middle ? 17 : 18;

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        if (globalData.Years == Years.Early)
        {
            // Passage "Privatized": the Suspicion Marker slides back once, only ever once.
            if (vars.Privatized == 0)
            {
                vars.Privatized = 1;
                vars.Tracker   -= 1;
                if (globalData.PlayersNum > 3) vars.Tracker -= 1;
            }

            GameplayHubSection setupSec = globalData.ActiveHub.AddSection("Setup");
            setupSec.ReplaceShouldShow(() => vars.Gen3Pg == 0);
            setupSec.AddDefaultContent(
                "Setup",
                str => str
                    .FormatWithReplacement(0, vars.Tracker.ToString())
                    .FormatWithCondition(1, () => vars.Creature == 1)
                    .FormatWithCondition(2, () => globalData.PlayersNum == 3));

            GameplayHubSection investmentSec = globalData.ActiveHub.AddSection("Investment");
            investmentSec.AddDefaultContent("Investment");

            GameplayHubSection jailSec = globalData.ActiveHub.AddSection("Jail");
            jailSec.AddDefaultContent("Jail");

            if (vars.Creature == 1)
            {
                GameplayHubSection huntSec = globalData.ActiveHub.AddSection("Hunt");
                huntSec.AddDefaultContent("Hunt");
                huntSec.AddClickHere(HuntExplanation, true);
            }
        }
        else
        {
            if (globalData.Years == Years.Middle)
            {
                GameplayHubSection middleSetupSec = globalData.ActiveHub.AddSection("MiddleSetup");
                middleSetupSec.ReplaceShouldShow(() => vars.Pripg == 0);
                middleSetupSec.AddDefaultContent("MiddleSetup");
            }

            GameplayHubSection wrongSec = globalData.ActiveHub.AddSection("EverythingWrong");
            wrongSec.AddDefaultContent("EverythingWrong");

            GameplayHubSection impressSec = globalData.ActiveHub.AddSection("Impressing");
            impressSec.AddDefaultContent(
                "Impressing",
                str => str.FormatWithReplacement(0, vars.Warden));
            impressSec.AddClickHereForReward(PrivateRewardSignIn, true);

            if (vars.Jail == 1)
            {
                GameplayHubSection asylumSec = globalData.ActiveHub.AddSection("JunkPalaceAsylum");
                asylumSec.AddDefaultContent(
                    "JunkPalaceAsylum",
                    str => str.FormatWithReplacement(0, vars.AsylumUp));
            }
            else
            {
                GameplayHubSection junkSec = globalData.ActiveHub.AddSection("JunkPalace");
                junkSec.AddDefaultContent(
                    "JunkPalace",
                    str => str.FormatWithReplacement(0, vars.Warden));
                junkSec.AddClickHere(JunkPalaceSignIn, true);
            }

            GameplayHubSection domeSec = globalData.ActiveHub.AddSection("BattleDome");
            domeSec.AddDefaultContent("BattleDome");
            domeSec.AddClickHere(BattleDomeExplanation, true);

            if (vars.Exped == 0 && vars.Creature == 1)
            {
                GameplayHubSection huntOverSec = globalData.ActiveHub.AddSection("HuntOver");
                huntOverSec.AddDefaultContent("HuntOver");
            }

            GameplayHubSection crossroadsSec = globalData.ActiveHub.AddSection("Crossroads");
            crossroadsSec.AddDefaultContent("Crossroads");
            crossroadsSec.AddClickHere(Gen3Token2SignIn, true);
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
                gd => gd.ShowEndOfRoundPopUp(PrivatizedEarlyEndRound),
                true);
        }
        else if (globalData.Years == Years.Middle)
        {
            GameplayHubSection endRoundSec = globalData.ActiveHub.AddSection("EndOfRound");
            endRoundSec.AddDefaultContent("EndOfRound");
            endRoundSec.AddClickHereContinueNextRound(
                gd => gd.ShowEndOfRoundPopUp(PrivatizedMiddleEndRound),
                true);
        }
        else
        {
            globalData.ActiveHub.AddEndOfGenerationSection(PrivateCreepPenalty);
        }
    }

    private static void PrivatizedEarlyEndRound(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Creature == 1 && vars.Exped == 0)
        {
            Expedition1(globalData);
            return;
        }

        JailEventA(globalData);
    }

    private static void PrivatizedMiddleEndRound(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Creature == 1 && vars.Exped == 0)
        {
            Expedition1(globalData);
            return;
        }

        JailEvent2(globalData);
    }

    private static void PrivatizedToMiddleYears(GlobalData globalData)
    {
        globalData.Years = Years.Middle;
        Privatized(globalData);
    }

    private static void PrivatizedToLateYears(GlobalData globalData)
    {
        globalData.Years = Years.Late;
        Privatized(globalData);
    }

    // =========================================================================
    // HUB ACTION: IMPRESSING THE WARDEN (PrivateRewardSignIn -> PrivateReward)
    // =========================================================================

    internal static void PrivateRewardSignIn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.Warden));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(name =>
        {
            vars.TempName = name;
            for (int i = 0; i < globalData.PlayersNum; i++)
            {
                if (name == vars.GetPlayerName(globalData, i))
                {
                    vars.Creep[i] = "yes";
                    break;
                }
            }

            PrivateReward(globalData);
        });
    }

    internal static void PrivateReward(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.CreepCount++;
        vars.Pripg = 1;

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempName)
                .FormatWithReplacement(1, dateStr)
                .FormatWithReplacement(2, vars.Warden)
                .FormatWithCondition(3, () => vars.Warden == "The Butcher"));
        globalData.ActiveWindow.AddClickHereToContinue(PrivateReward_Setup);
    }

    private static void PrivateReward_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.EstateUpgradeBack3,
            PopUpButton.Accept,
            Privatized);
    }

    // =========================================================================
    // HUB ACTION: THE JUNK PALACE
    // JunkPalaceSignIn -> JunkPalace -> JunkPalaceReveal -> JunkPalaceMeet1 -> JunkPalaceMeetb
    // =========================================================================

    internal static void JunkPalaceSignIn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int flavorIdx = Random.Shared.Next(3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, globalData.TownName)
                .FormatWithReplacement(1, vars.Warden)
                .FormatWithIndex(2, flavorIdx));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(name =>
        {
            vars.TempName = name;
            JunkPalace(globalData);
        });
    }

    internal static void JunkPalace(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.TempName, JunkPalaceReveal);
    }

    internal static void JunkPalaceReveal(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        // While the Creature still roams the Warden keeps the penalty a secret.
        if (vars.Exped == 0 && vars.Creature == 1)
        {
            JunkPalaceMeet1(globalData);
            return;
        }

        globalData.SaveToUndo();
        int flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Warden)
                .FormatWithIndex(1, flavorIdx)
                .FormatWithIndex(2, vars.JunkPenalty));
        globalData.ActiveWindow.AddClickHereToContinue(JunkPalaceMeet1);
    }

    internal static void JunkPalaceMeet1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempName)
                .FormatWithReplacement(1, dateStr)
                .FormatWithReplacement(2, vars.Warden)
                .FormatWithCondition(3, () => vars.Warden == "The Butcher"));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.TempCreep = "0";
                    JunkPalaceMeetb(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.TempCreep = "1";
                    JunkPalaceMeetb(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            3,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.TempCreep = "2";
                    JunkPalaceMeetb(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            4,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.TempCreep = "3";
                    JunkPalaceMeetb(gd);
                }
            },
            true);
    }

    internal static void JunkPalaceMeetb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Pripg = 1;

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempName)
                .FormatWithReplacement(1, dateStr)
                .FormatWithReplacement(2, vars.Warden)
                .FormatWithCondition(3, () => vars.Exped == 0 && vars.Creature == 1));
        globalData.ActiveWindow.AddClickHereToContinue(JunkPalaceMeetb_Setup);
    }

    private static void JunkPalaceMeetb_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int choiceIdx = int.TryParse(vars.TempCreep, out int parsed) ? parsed : 0;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Privatized,
            str => str.FormatWithIndex(0, choiceIdx));
    }

    // =========================================================================
    // HUB ACTION: BattleDomeExplanation
    // =========================================================================

    internal static void BattleDomeExplanation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Pripg = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, (globalData.PlayersNum + 1).ToString())
                .FormatWithReplacement(1, vars.Warden));
        globalData.ActiveWindow.AddClickHereToContinue(Privatized);
    }

    // =========================================================================
    // END OF EARLY YEARS: JailEventA -> JailEvent1 -> JailEvent1A -> JailEvent1b
    //                     -> JailEvent1c -> EndtotheCount -> Privatized (Middle)
    // =========================================================================

    internal static void JailEventA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, letterHeader)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(JailEventA_Setup);
    }

    private static void JailEventA_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_ColoredMoneyToken,
            PopUpButton.Accept,
            JailEvent1);
    }

    internal static void JailEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithReplacement(1, vars.Warden)
                .FormatWithCondition(2, () => vars.Kill == "blacksmith")
                .FormatWithCondition(3, () => vars.Creature == 1 && vars.Exped == 0));
        globalData.ActiveWindow.AddClickHereToContinue(JailEvent1A);
    }

    internal static void JailEvent1A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithReplacement(1, vars.Warden));
        globalData.ActiveWindow.AddClickHereToContinue(JailEvent1A_Setup);
    }

    private static void JailEvent1A_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_BattleStartTile,
            PopUpButton.Confirm,
            JailEvent1b);
    }

    internal static void JailEvent1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithReplacement(1, vars.Warden));
        globalData.ActiveWindow.AddClickHereToContinue(JailEvent1c);
    }

    internal static void JailEvent1c(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Jail != 1 && vars.AsylumCount < 1)
        {
            EndtotheCount(globalData);
            return;
        }

        globalData.SaveToUndo();
        bool mercifulHeritage = vars.Jail == 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str =>
            str.FormatWithCondition(0, () => mercifulHeritage));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithReplacement(1, vars.Warden)
                .FormatWithReplacement(2, vars.AsylumUp)
                .FormatWithCondition(3, () => mercifulHeritage));

        Action<GlobalData> next = mercifulHeritage ? EndtotheCount : JailEvent1c_Setup;
        globalData.ActiveWindow.AddClickHereToContinue(next);
    }

    private static void JailEvent1c_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            EndtotheCount,
            str => str.FormatWithReplacement(0, vars.AsylumUp));
    }

    internal static void EndtotheCount(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(EndtotheCount_Setup);
    }

    private static void EndtotheCount_Setup(GlobalData globalData)
    {
        int giftIdx = Random.Shared.Next(2);
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_ScenarioIcon,
            PopUpButton.Accept,
            PrivatizedToMiddleYears,
            str => str.FormatWithIndex(0, giftIdx));
    }

    // =========================================================================
    // END OF MIDDLE YEARS: JailEvent2 -> Privatized (Late)
    // =========================================================================

    internal static void JailEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, letterHeader)
                .FormatWithReplacement(1, vars.Warden)
                .FormatWithReplacement(2, globalData.TownName)
                .FormatWithCondition(3, () => vars.CreepCount == 0)
                .FormatWithCondition(4, () => vars.Exped == 1));
        globalData.ActiveWindow.AddClickHereToContinue(JailEvent2_Setup);
    }

    private static void JailEvent2_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_BattleStartTile,
            PopUpButton.Accept,
            PrivatizedToLateYears,
            str => str.FormatWithReplacement(0, vars.Warden));
    }

    // =========================================================================
    // END OF LATE YEARS (END OF GENERATION III)
    // PrivateCreepPenalty -> ENTERTHEBATTLEDOME -> BattlePreparation
    // =========================================================================

    internal static void PrivateCreepPenalty(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CreepCount >= globalData.PlayersNum)
        {
            ENTERTHEBATTLEDOME(globalData);
            return;
        }

        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Warden)
                .FormatWithReplacement(1, vars.GetPlayerName(globalData, 0))
                .FormatWithReplacement(2, vars.GetPlayerName(globalData, 1))
                .FormatWithReplacement(3, vars.GetPlayerName(globalData, 2))
                .FormatWithReplacement(4, vars.GetPlayerName(globalData, 3))
                .FormatWithCondition(5, () => vars.CreepA != "yes")
                .FormatWithCondition(6, () => vars.CreepB != "yes")
                .FormatWithCondition(7, () => vars.CreepC != "yes" && globalData.PlayersNum >= 3)
                .FormatWithCondition(8, () => vars.CreepD != "yes" && globalData.PlayersNum >= 4)
                .FormatWithIndex(9, vars.JunkPenalty));
        globalData.ActiveWindow.AddClickHereToContinue(ENTERTHEBATTLEDOME);
    }

    internal static void ENTERTHEBATTLEDOME(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, vars.Warden));
        globalData.ActiveWindow.AddClickHereToContinue(BattlePreparation);
    }

    internal static void BattlePreparation(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Player1StatEntry);
    }

    // =========================================================================
    // WARRIOR CREATION HELPERS (shared localization, no SaveToUndo)
    // =========================================================================

    /// <summary>
    /// Warrior names are stored with a "_N" player suffix so that the endings in
    /// 08_FearOfTheUnknown_SharedAndEndings can strip it back out again.
    /// Index 4 is reserved for The Warden.
    /// </summary>
    private static string GetWarriorDisplayName(FearOfTheUnknownVars vars, int index)
    {
        if (index == 4)
        {
            return string.IsNullOrEmpty(vars.Warden) ? "The Warden" : vars.Warden;
        }

        string raw = vars.Warrior[index];
        if (string.IsNullOrEmpty(raw)) return "Warrior " + (index + 1);
        return raw.Replace("_" + (index + 1), string.Empty);
    }

    private static List<int> GetAliveCombatants(GlobalData globalData)
    {
        FearOfTheUnknownVars vars  = globalData.FearOfTheUnknownVars;
        List<int>            alive = new();

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.Hit[i] > 0) alive.Add(i);
        }

        if (vars.Hit[4] > 0) alive.Add(4);
        return alive;
    }

    private static void ShowWarriorHandOver(GlobalData globalData, int index, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, index);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            str => str.FormatWithReplacement(0, playerName),
            "BattleStatEntry");
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, playerName),
            "BattleStatEntry");
        globalData.ActiveWindow.AddHandStorybookTo(playerName, next);
    }

    /// <summary>statKind: 0 = Agility, 1 = Strength, 2 = Hit Points.</summary>
    private static void AskWarriorStat(GlobalData globalData, int index, int statKind, string tagBase, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, index);

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "0",
            PopUpButton.Confirm,
            value => int.TryParse(value, out int parsed) && parsed is >= 0 and <= 99,
            value =>
            {
                int parsed = int.Parse(value);
                if (statKind == 0) vars.Agi[index]      = parsed;
                else if (statKind == 1) vars.Str[index] = parsed;
                else vars.Hit[index]                    = parsed;

                next(globalData);
            },
            false,
            str => str.FormatWithReplacement(0, playerName),
            tagBase);
    }

    private static void ShowWarriorStatConfirmed(GlobalData globalData, string tagBase, int value, Action<GlobalData> next)
    {
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, tagBase);
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, value.ToString()),
            tagBase);
        globalData.ActiveWindow.AddClickHereToContinue(next);
    }

    private static void AskWarriorName(GlobalData globalData, int index, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        string               playerName = vars.GetPlayerName(globalData, index);

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "Warrior",
            PopUpButton.Confirm,
            value => !string.IsNullOrWhiteSpace(value) && value.Trim().Length <= 40,
            value =>
            {
                vars.Warrior[index] = value.Trim() + "_" + (index + 1);
                next(globalData);
            },
            false,
            str => str.FormatWithReplacement(0, playerName),
            "BattleAskName");
    }

    private static void ShowWarriorComplete(GlobalData globalData, int index, Action<GlobalData> confirmNext, Action<GlobalData> retry)
    {
        FearOfTheUnknownVars vars        = globalData.FearOfTheUnknownVars;
        string               warriorName = GetWarriorDisplayName(vars, index);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            str => str.FormatWithReplacement(0, warriorName),
            "BattleWarriorComplete");
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.Agi[index].ToString())
                .FormatWithReplacement(1, vars.Str[index].ToString())
                .FormatWithReplacement(2, vars.Hit[index].ToString()),
            "BattleWarriorComplete");
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { confirmNext, retry },
            true,
            null,
            "BattleWarriorComplete");
    }

    // =========================================================================
    // PLAYER A WARRIOR CREATION
    // =========================================================================

    internal static void Player1StatEntry(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorHandOver(globalData, 0, Player1AskAgility);
    }

    internal static void Player1AskAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 0, 0, "BattleAskAgility", Player1ShowAgility);
    }

    internal static void Player1ShowAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleAgilityConfirmed", globalData.FearOfTheUnknownVars.Agi[0], Player1AskStrength);
    }

    internal static void Player1AskStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 0, 1, "BattleAskStrength", Player1ShowStrength);
    }

    internal static void Player1ShowStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleStrengthConfirmed", globalData.FearOfTheUnknownVars.Str[0], Player1AskLife);
    }

    internal static void Player1AskLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 0, 2, "BattleAskLife", Player1ShowLife);
    }

    internal static void Player1ShowLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleLifeConfirmed", globalData.FearOfTheUnknownVars.Hit[0], Player1AskName);
    }

    internal static void Player1AskName(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorName(globalData, 0, Player1Complete);
    }

    internal static void Player1Complete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorComplete(globalData, 0, Player2StatEntry, Player1StatEntry);
    }

    // =========================================================================
    // PLAYER B WARRIOR CREATION
    // =========================================================================

    internal static void Player2StatEntry(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorHandOver(globalData, 1, Player2AskAgility);
    }

    internal static void Player2AskAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 1, 0, "BattleAskAgility", Player2ShowAgility);
    }

    internal static void Player2ShowAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleAgilityConfirmed", globalData.FearOfTheUnknownVars.Agi[1], Player2AskStrength);
    }

    internal static void Player2AskStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 1, 1, "BattleAskStrength", Player2ShowStrength);
    }

    internal static void Player2ShowStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleStrengthConfirmed", globalData.FearOfTheUnknownVars.Str[1], Player2AskLife);
    }

    internal static void Player2AskLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 1, 2, "BattleAskLife", Player2ShowLife);
    }

    internal static void Player2ShowLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleLifeConfirmed", globalData.FearOfTheUnknownVars.Hit[1], Player2AskName);
    }

    internal static void Player2AskName(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorName(globalData, 1, Player2Complete);
    }

    internal static void Player2Complete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorComplete(globalData, 1, AfterPlayer2Warrior, Player2StatEntry);
    }

    private static void AfterPlayer2Warrior(GlobalData globalData)
    {
        if (globalData.PlayersNum > 2) Player3StatEntry(globalData);
        else WardenStatEntry(globalData);
    }

    // =========================================================================
    // PLAYER C WARRIOR CREATION
    // =========================================================================

    internal static void Player3StatEntry(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorHandOver(globalData, 2, Player3AskAgility);
    }

    internal static void Player3AskAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 2, 0, "BattleAskAgility", Player3ShowAgility);
    }

    internal static void Player3ShowAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleAgilityConfirmed", globalData.FearOfTheUnknownVars.Agi[2], Player3AskStrength);
    }

    internal static void Player3AskStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 2, 1, "BattleAskStrength", Player3ShowStrength);
    }

    internal static void Player3ShowStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleStrengthConfirmed", globalData.FearOfTheUnknownVars.Str[2], Player3AskLife);
    }

    internal static void Player3AskLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 2, 2, "BattleAskLife", Player3ShowLife);
    }

    internal static void Player3ShowLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleLifeConfirmed", globalData.FearOfTheUnknownVars.Hit[2], Player3AskName);
    }

    internal static void Player3AskName(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorName(globalData, 2, Player3Complete);
    }

    internal static void Player3Complete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorComplete(globalData, 2, AfterPlayer3Warrior, Player3StatEntry);
    }

    private static void AfterPlayer3Warrior(GlobalData globalData)
    {
        if (globalData.PlayersNum > 3) Player4StatEntry(globalData);
        else WardenStatEntry(globalData);
    }

    // =========================================================================
    // PLAYER D WARRIOR CREATION
    // =========================================================================

    internal static void Player4StatEntry(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorHandOver(globalData, 3, Player4AskAgility);
    }

    internal static void Player4AskAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 3, 0, "BattleAskAgility", Player4ShowAgility);
    }

    internal static void Player4ShowAgility(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleAgilityConfirmed", globalData.FearOfTheUnknownVars.Agi[3], Player4AskStrength);
    }

    internal static void Player4AskStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 3, 1, "BattleAskStrength", Player4ShowStrength);
    }

    internal static void Player4ShowStrength(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleStrengthConfirmed", globalData.FearOfTheUnknownVars.Str[3], Player4AskLife);
    }

    internal static void Player4AskLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorStat(globalData, 3, 2, "BattleAskLife", Player4ShowLife);
    }

    internal static void Player4ShowLife(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorStatConfirmed(globalData, "BattleLifeConfirmed", globalData.FearOfTheUnknownVars.Hit[3], Player4AskName);
    }

    internal static void Player4AskName(GlobalData globalData)
    {
        globalData.SaveToUndo();
        AskWarriorName(globalData, 3, Player4Complete);
    }

    internal static void Player4Complete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowWarriorComplete(globalData, 3, WardenStatEntry, Player4StatEntry);
    }

    // =========================================================================
    // THE WARDEN'S CHAMPION (combatant index 4)
    // =========================================================================

    internal static void WardenStatEntry(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.Warrior[4] = vars.Warden;
        vars.Agi[4]     = Random.Shared.Next(8, 15);
        vars.Str[4]     = Random.Shared.Next(3, 8);

        // The more the household indulged the Warden, the weaker the champion.
        int wardenLife = 10 + globalData.PlayersNum * 5 - vars.CreepCount * 4;
        vars.Hit[4] = wardenLife < 6 ? 6 : wardenLife;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, vars.Warden));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Warden)
                .FormatWithReplacement(1, vars.Agi[4].ToString())
                .FormatWithReplacement(2, vars.Str[4].ToString())
                .FormatWithReplacement(3, vars.Hit[4].ToString())
                .FormatWithCondition(4, () => vars.CreepCount >= globalData.PlayersNum));
        globalData.ActiveWindow.AddClickHereToContinue(BattleIntro);
    }

    // =========================================================================
    // THE BATTLE: BattleIntro -> BattleChecks -> BattleStart -> BattleEnd
    // =========================================================================

    internal static void BattleIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.ElimCount   = 0;
        vars.BattleCount = globalData.PlayersNum; // (players + Warden) - 1 survivors to eliminate.

        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, vars.GetPlayerName(globalData, 0))
                .FormatWithReplacement(2, GetWarriorDisplayName(vars, 0))
                .FormatWithReplacement(3, vars.GetPlayerName(globalData, 1))
                .FormatWithReplacement(4, GetWarriorDisplayName(vars, 1))
                .FormatWithReplacement(5, vars.GetPlayerName(globalData, 2))
                .FormatWithReplacement(6, GetWarriorDisplayName(vars, 2))
                .FormatWithReplacement(7, vars.GetPlayerName(globalData, 3))
                .FormatWithReplacement(8, GetWarriorDisplayName(vars, 3))
                .FormatWithReplacement(9, vars.Warden)
                .FormatWithCondition(10, () => globalData.PlayersNum >= 3)
                .FormatWithCondition(11, () => globalData.PlayersNum >= 4));
        globalData.ActiveWindow.AddClickHereToContinue(BattleChecks);
    }

    internal static void BattleChecks(GlobalData globalData)
    {
        FearOfTheUnknownVars vars  = globalData.FearOfTheUnknownVars;
        List<int>            alive = GetAliveCombatants(globalData);

        if (alive.Count <= 1)
        {
            BattleEnd(globalData);
            return;
        }

        for (int i = alive.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (alive[i], alive[j]) = (alive[j], alive[i]);
        }

        vars.Active = alive[0].ToString();
        vars.Target = alive[1].ToString();
        BattleStart(globalData);
    }

    internal static void BattleStart(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        int attacker = int.TryParse(vars.Active, out int parsedActive) ? parsedActive : 0;
        int defender = int.TryParse(vars.Target, out int parsedTarget) ? parsedTarget : 1;
        if (attacker == defender) defender = attacker == 0 ? 1 : 0;

        string attackerName = GetWarriorDisplayName(vars, attacker);
        string defenderName = GetWarriorDisplayName(vars, defender);

        vars.TempStr = vars.Str[attacker];
        vars.TempAgi = vars.Agi[defender];

        int  attackIdx = Random.Shared.Next(13);
        bool connects  = Random.Shared.Next(1, 41) > vars.TempAgi;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, attackerName)
                .FormatWithReplacement(1, defenderName)
                .FormatWithIndex(2, attackIdx));

        bool eliminated = false;

        if (connects)
        {
            vars.Hit[defender] -= vars.TempStr;
            vars.TempHit       =  vars.Hit[defender];

            int reactionIdx = Random.Shared.Next(10);
            globalData.ActiveWindow.AddNextContent(1, true, str =>
                str
                    .FormatWithReplacement(0, defenderName)
                    .FormatWithReplacement(1, vars.TempStr.ToString())
                    .FormatWithIndex(2, reactionIdx));

            eliminated = vars.Hit[defender] <= 0;
        }
        else
        {
            vars.TempHit = 100;

            int dodgeIdx = Random.Shared.Next(6);
            globalData.ActiveWindow.AddNextContent(2, true, str =>
                str
                    .FormatWithReplacement(0, defenderName)
                    .FormatWithIndex(1, dodgeIdx));
        }

        if (eliminated)
        {
            vars.ElimCount++;

            int fallIdx   = Random.Shared.Next(6);
            int defeatIdx = Random.Shared.Next(3);
            globalData.ActiveWindow.AddNextContent(3, true, str =>
                str
                    .FormatWithReplacement(0, defenderName)
                    .FormatWithIndex(1, fallIdx)
                    .FormatWithIndex(2, defeatIdx));
        }

        globalData.ActiveWindow.AddClickHereToContinue(BattleStartContinue);
    }

    private static void BattleStartContinue(GlobalData globalData)
    {
        if (GetAliveCombatants(globalData).Count <= 1) BattleEnd(globalData);
        else BattleChecks(globalData);
    }

    internal static void BattleEnd(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        List<int> alive  = GetAliveCombatants(globalData);
        int       winner = alive.Count > 0 ? alive[0] : 4;

        bool wardenWins = winner == 4;
        vars.Ending = wardenWins ? "FOTU-End6" : "FOTU-End5";

        string winnerWarrior = GetWarriorDisplayName(vars, winner);
        string winnerOwner   = wardenWins ? vars.Warden : vars.GetPlayerName(globalData, winner);
        vars.TempName = winnerOwner;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, winnerOwner)
                .FormatWithReplacement(1, winnerWarrior)
                .FormatWithReplacement(2, vars.Warden)
                .FormatWithCondition(3, () => wardenWins));
        globalData.ActiveWindow.AddClickHereToContinue(BattleEnd_Setup);
    }

    private static void BattleEnd_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars       = globalData.FearOfTheUnknownVars;
        bool                 wardenWins = vars.Ending == "FOTU-End6";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            PEWitchEnding,
            str => str
                .FormatWithReplacement(0, vars.TempName)
                .FormatWithCondition(1, () => wardenWins));
    }
}
