namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    // =========================================================================
    // GENERATION III - ACCEPTANCE (LIBERAL): INTRO CHAIN
    // LiberalIntro -> LiberalHomeTile -> LibCountBlessing -> LiberalReplace -> PEWitch3Intro
    // =========================================================================

    internal static void LiberalIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.Generation = Generation.Third;
        globalData.Years      = Years.Early;
        vars.Path4       = "PELiberal";
        vars.Exped       = 0;
        vars.AsylumCount = 0;
        vars.Gen3Pg      = 0;
        vars.Visit       = 3;

        string randomPlayer = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, randomPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalHomeTile);
    }

    internal static void LiberalHomeTile(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (string.IsNullOrEmpty(vars.BHome) || vars.BHome == "0")
        {
            LibCountBlessing(globalData);
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
        globalData.ActiveWindow.AddClickHereToContinue(LiberalHomeTile_Setup);
    }

    private static void LiberalHomeTile_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_HouseOnTheHillTile,
            PopUpButton.Accept,
            LibCountBlessing,
            str => str.FormatWithReplacement(0, vars.BHome));
    }

    internal static void LibCountBlessing(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CureCount != "yes")
        {
            LiberalReplace(globalData);
            return;
        }

        globalData.SaveToUndo();
        string cured = string.IsNullOrEmpty(vars.CurePlayer)
            ? vars.GetPlayerName(globalData, 0)
            : vars.CurePlayer;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, cured));
        globalData.ActiveWindow.AddClickHereToContinue(LibCountBlessing_Setup);
    }

    private static void LibCountBlessing_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string cured = string.IsNullOrEmpty(vars.CurePlayer)
            ? vars.GetPlayerName(globalData, 0)
            : vars.CurePlayer;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_BlessingOfTheStrigoi,
            PopUpButton.Accept,
            LiberalReplace,
            str => str.FormatWithReplacement(0, cured));
    }

    internal static void LiberalReplace(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string randomName = GetRandomPlayerName(globalData);
        string dateStr    = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, randomName)
                .FormatWithReplacement(1, dateStr)
                .FormatWithCondition(2, () => vars.Jail == 2));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalReplace_Setup);
    }

    private static void LiberalReplace_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_RehabilitationToken,
            PopUpButton.Confirm,
            PEWitch3Intro,
            str => str.FormatWithReplacement(0, vars.Tracker.ToString()));
    }

    // =========================================================================
    // GENERATION III - ACCEPTANCE HUB (Early = Liberal, Middle = Liberal2, Late = Liberal3)
    // =========================================================================

    public static void Liberal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.HubId = FearOfUnknownHubId.Liberal;
        vars.Round = globalData.Years == Years.Early ? 19 : globalData.Years == Years.Middle ? 20 : 21;

        string programName = string.IsNullOrEmpty(vars.MenName) ? "Rehabilitation" : vars.MenName;
        string programType = string.IsNullOrEmpty(vars.MenType) ? "Occult" : vars.MenType;
        string asylumUp    = string.IsNullOrEmpty(vars.AsylumUp) ? "Asylum" : vars.AsylumUp;

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        if (globalData.Years == Years.Early)
        {
            GameplayHubSection setupSec = globalData.ActiveHub.AddSection("Setup");
            setupSec.ReplaceShouldShow(() => vars.Gen3Pg == 0 && vars.Creature > 0);
            setupSec.AddDefaultContent(
                "Setup",
                str => str
                    .FormatWithCondition(0, () => vars.Creature == 2)
                    .FormatWithCondition(1, () => vars.Creature == 1)
                    .FormatWithCondition(2, () => vars.Creature == 1 && globalData.PlayersNum == 3));
        }

        GameplayHubSection servantSec = globalData.ActiveHub.AddSection("ServantRule");
        servantSec.AddDefaultContent("ServantRule");

        GameplayHubSection rehabSec = globalData.ActiveHub.AddSection("Rehabilitation");
        rehabSec.AddDefaultContent("Rehabilitation");

        GameplayHubSection focusSec = globalData.ActiveHub.AddSection("FocusOnRehabilitation");
        focusSec.AddDefaultContent("FocusOnRehabilitation");
        focusSec.AddClickHere(AsylumTreatment, true);

        if (vars.Creature == 1 && (globalData.Years == Years.Early || vars.Exped == 0))
        {
            GameplayHubSection huntSec = globalData.ActiveHub.AddSection("HuntIsOn");
            huntSec.AddDefaultContent("HuntIsOn");
            huntSec.AddClickHere(HuntExplanation, true);
        }

        if (globalData.Years != Years.Early)
        {
            GameplayHubSection programSec = globalData.ActiveHub.AddSection("Program");
            programSec.AddDefaultContent(
                "Program",
                str => str
                    .FormatWithReplacement(0, programName)
                    .FormatWithReplacement(1, programType)
                    .FormatWithCondition(2, () => globalData.PlayersNum >= 4));

            GameplayHubSection crossroadsSec = globalData.ActiveHub.AddSection("Crossroads");
            crossroadsSec.AddDefaultContent("Crossroads");
            crossroadsSec.AddClickHere(Gen3Token2SignIn, true);
        }

        if (globalData.Years == Years.Middle)
        {
            GameplayHubSection politicsSec = globalData.ActiveHub.AddSection("Politics");
            politicsSec.AddDefaultContent(
                "Politics",
                str => str.FormatWithReplacement(0, asylumUp));
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
                gd => gd.ShowEndOfRoundPopUp(LiberalEarlyEndRound),
                true);
        }
        else if (globalData.Years == Years.Middle)
        {
            GameplayHubSection endRoundSec = globalData.ActiveHub.AddSection("EndOfRound");
            endRoundSec.AddDefaultContent("EndOfRound");
            endRoundSec.AddClickHereContinueNextRound(
                gd => gd.ShowEndOfRoundPopUp(LiberalMiddleEndRound),
                true);
        }
        else
        {
            globalData.ActiveHub.AddEndOfGenerationSection(LiberalEndOfGeneration);
        }
    }

    // =========================================================================
    // END OF ROUND / END OF GENERATION ROUTERS
    // =========================================================================

    private static void LiberalEarlyEndRound(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Creature == 1 && vars.Exped == 0)
        {
            vars.ExpoNextPsg = "LiberalEvent3";
            Expedition1(globalData);
            return;
        }

        LiberalEvent3(globalData);
    }

    private static void LiberalMiddleEndRound(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Creature == 1 && vars.Exped == 0)
        {
            vars.ExpoNextPsg = GetLiberalMiddleEventName(vars);
            Expedition1(globalData);
            return;
        }

        RunLiberalMiddleEvent(globalData);
    }

    private static void LiberalEndOfGeneration(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Creature == 1 && vars.Exped == 0)
        {
            vars.ExpoNextPsg = "LiberalBonus";
            Expedition1(globalData);
            return;
        }

        LiberalBonus(globalData);
    }

    private static string GetLiberalMiddleEventName(FearOfTheUnknownVars vars)
    {
        if (string.IsNullOrEmpty(vars.Liberal2NextPsg))
        {
            vars.Liberal2NextPsg = Random.Shared.Next(2) == 0 ? "LiberalEvent" : "LiberalTaxes";
        }

        return vars.Liberal2NextPsg;
    }

    private static void RunLiberalMiddleEvent(GlobalData globalData)
    {
        string next = GetLiberalMiddleEventName(globalData.FearOfTheUnknownVars);
        if (next == "LiberalTaxes")
        {
            LiberalTaxes(globalData);
            return;
        }

        LiberalEvent(globalData);
    }

    // =========================================================================
    // THE HUNT: Expedition1 -> Expedition2 -> Expedition3 -> ExpYes / ExpNo
    // Also called by the Gen III Privatized chapter (rounds 16-18).
    // =========================================================================

    internal static void Expedition1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string journalHeader = GetJournal1a(globalData);
        int    expeditionIdx = vars.Round == 20 ? 1 : vars.Round == 21 || vars.Round == 18 ? 2 : 0;
        int    flavourIdx    = Random.Shared.Next(3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithIndex(1, expeditionIdx)
                .FormatWithIndex(2, flavourIdx));
        globalData.ActiveWindow.AddClickHereToContinue(Expedition2);
    }

    internal static void Expedition2(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Expedition3);
    }

    internal static void Expedition3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        int threshold = vars.Round switch
        {
            16 => 7 - Random.Shared.Next(1, 5),
            19 => 7 - Random.Shared.Next(1, 5),
            17 => 7 - Random.Shared.Next(1, 6),
            20 => 7 - Random.Shared.Next(1, 6),
            _  => 7 - Random.Shared.Next(1, 7)
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, threshold.ToString()));
        globalData.ActiveWindow.AddYesNo(ExpYes, ExpNo);
    }

    internal static void ExpYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.Exped = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ExpYes_Setup);
    }

    private static void ExpYes_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_HuntTokenFRONT,
            PopUpButton.Accept,
            ExpYesContinue);
    }

    private static void ExpYesContinue(GlobalData globalData)
    {
        int round = globalData.FearOfTheUnknownVars.Round;
        if (round == 19 || round == 20)
        {
            EssentialSalts(globalData);
            return;
        }

        ExpeditionContinue(globalData);
    }

    internal static void ExpNo(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ExpNo_Setup);
    }

    private static void ExpNo_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        bool anotherHunt = vars.Round != 18 && vars.Round != 21;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_HuntTokenFRONT,
            PopUpButton.Confirm,
            ExpeditionContinue,
            str => str.FormatWithCondition(0, () => anotherHunt));
    }

    /// <summary>
    /// Routes out of the Hunt / Essential Salts chain. <see cref="FearOfTheUnknownVars.ExpoNextPsg"/>
    /// is set by the calling hub before <see cref="Expedition1"/>; if it is empty we fall back
    /// to round-based routing so the Privatized chapter can call Expedition1 without extra setup.
    /// </summary>
    private static void ExpeditionContinue(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string next = vars.ExpoNextPsg;
        vars.ExpoNextPsg = string.Empty;

        switch (next)
        {
            case "LiberalEvent3": LiberalEvent3(globalData); return;
            case "LiberalEvent":  LiberalEvent(globalData);  return;
            case "LiberalTaxes":  LiberalTaxes(globalData);  return;
            case "LiberalBonus":  LiberalBonus(globalData);  return;
            case "Privatized":    Privatized(globalData);    return;
            case "Liberal":       Liberal(globalData);       return;
        }

        if (vars.Round <= 18)
        {
            Privatized(globalData);
            return;
        }

        if (vars.Round == 19)
        {
            LiberalEvent3(globalData);
            return;
        }

        if (vars.Round == 20)
        {
            RunLiberalMiddleEvent(globalData);
            return;
        }

        LiberalBonus(globalData);
    }

    // =========================================================================
    // ESSENTIAL SALTS: EssentialSalts -> EssentialSalts1 -> EssentialCons /
    // EssentialSaltsRes / EssentialSaltsNo -> ExpeditionContinue
    // =========================================================================

    internal static void EssentialSalts(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(EssentialSalts1);
    }

    internal static void EssentialSalts1(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { EssentialSaltsResolve },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { EssentialSaltsNo },
            true);
    }

    private static void EssentialSaltsResolve(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (string.IsNullOrEmpty(vars.EssentialSalts1NextPsg))
        {
            vars.EssentialSalts1NextPsg = Random.Shared.Next(2) == 0 ? "EssentialSaltsRes" : "EssentialCons";
        }

        if (vars.EssentialSalts1NextPsg == "EssentialSaltsRes")
        {
            EssentialSaltsRes(globalData);
            return;
        }

        EssentialCons(globalData);
    }

    internal static void EssentialCons(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.SaltSp = Random.Shared.Next(1, 3);

        string randomName = GetRandomPlayerName(globalData);
        bool   flawless   = vars.SaltSp == 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, randomName)
                .FormatWithCondition(1, () => flawless));
        globalData.ActiveWindow.AddClickHereToContinue(EssentialCons_Setup);
    }

    private static void EssentialCons_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Spouse,
            PopUpButton.Accept,
            ExpeditionContinue,
            str => str.FormatWithCondition(0, () => vars.SaltSp == 2));
    }

    internal static void EssentialSaltsRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string randomName = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, randomName));
        globalData.ActiveWindow.AddClickHereToContinue(EssentialSaltsRes_Setup);
    }

    private static void EssentialSaltsRes_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.GainCaretakerFromLost,
            PopUpButton.Accept,
            ExpeditionContinue);
    }

    internal static void EssentialSaltsNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string randomName = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, randomName));
        globalData.ActiveWindow.AddClickHereToContinue(EssentialSaltsNo_Setup);
    }

    private static void EssentialSaltsNo_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            ExpeditionContinue);
    }

    // =========================================================================
    // END OF EARLY YEARS: LiberalEvent3 -> LiberalEvent3b (bid) -> LiberalEvent3Res
    // -> LiberalEvent3Resa (name the program) -> LiberalEvent3Resb -> Liberal (Middle)
    // =========================================================================

    internal static void LiberalEvent3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalEvent3b);
    }

    internal static void LiberalEvent3b(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereAfterBid(LiberalEvent3Res);
    }

    internal static void LiberalEvent3Res(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.MenType = "Engineering";
                    LiberalEvent3Resa(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.MenType = "Chemistry";
                    LiberalEvent3Resa(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            3,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.MenType = "Biology";
                    LiberalEvent3Resa(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            4,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.MenType = "Occult";
                    LiberalEvent3Resa(gd);
                }
            },
            true);
    }

    internal static void LiberalEvent3Resa(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "Rehabilitation",
            PopUpButton.Confirm,
            value => !string.IsNullOrWhiteSpace(value) && value.Trim().Length <= 24 && !value.Contains(';'),
            value =>
            {
                vars.MenName = value.Trim();
                LiberalEvent3Resb(globalData);
            });
    }

    internal static void LiberalEvent3Resb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string programName = string.IsNullOrEmpty(vars.MenName) ? "Rehabilitation" : vars.MenName;
        int    typeIdx     = vars.MenType switch
        {
            "Engineering" => 0,
            "Chemistry"   => 1,
            "Biology"     => 2,
            _             => 3
        };
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, programName));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Newspaper)
                .FormatWithReplacement(1, dateStr)
                .FormatWithReplacement(2, globalData.TownName)
                .FormatWithIndex(3, typeIdx));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalEvent3Resb_Setup);
    }

    private static void LiberalEvent3Resb_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string programType = string.IsNullOrEmpty(vars.MenType) ? "Occult" : vars.MenType;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            Liberal,
            str => str
                .FormatWithReplacement(0, programType)
                .FormatWithCondition(1, () => globalData.PlayersNum >= 4));
    }

    // =========================================================================
    // END OF MIDDLE YEARS (A): LiberalEvent -> Vote / Bid -> LiberalEvent2 -> Bribe
    // -> LiberalEventA / LiberalEventB / LiberalEventGood -> PaymentOrDeathA
    // =========================================================================

    internal static void LiberalEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(
            globalData.PlayersNum == 2 ? TwoPLiberalEvent : LiberalEvent1);
    }

    internal static void LiberalEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string asylumUp = string.IsNullOrEmpty(vars.AsylumUp) ? "Asylum" : vars.AsylumUp;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, asylumUp));
        globalData.ActiveWindow.AddOnceYouAreReady(LiberalEvent1a);
    }

    internal static void LiberalEvent1a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.Bribed = globalData.PlayersNum switch
        {
            2 => "1",
            3 => "2",
            _ => Random.Shared.Next(2, 4).ToString()
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Lib = "taxes";
                    LiberalEvent2(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Lib = "nationalist";
                    LiberalEvent2(gd);
                }
            },
            true);
    }

    internal static void TwoPLiberalEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string asylumUp = string.IsNullOrEmpty(vars.AsylumUp) ? "Asylum" : vars.AsylumUp;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, asylumUp));
        globalData.ActiveWindow.AddClickHereAfterBid(TwoPLiberalEvent1);
    }

    internal static void TwoPLiberalEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.Bribed = "1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Lib = "taxes";
                    LiberalEvent2(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Lib = "nationalist";
                    LiberalEvent2(gd);
                }
            },
            true);
    }

    internal static void LiberalEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string bribed = string.IsNullOrEmpty(vars.Bribed) ? "1" : vars.Bribed;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithReplacement(1, bribed));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalEvent2a);
    }

    internal static void LiberalEvent2a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string bribed = string.IsNullOrEmpty(vars.Bribed) ? "1" : vars.Bribed;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, bribed));
        globalData.ActiveWindow.AddClickHereAfterBid(LiberalEvent2ab);
    }

    internal static void LiberalEvent2ab(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string bribed = string.IsNullOrEmpty(vars.Bribed) ? "1" : vars.Bribed;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, bribed));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { LiberalBribeSucceeded },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { LiberalBribeFailed },
            true);
    }

    private static void LiberalBribeSucceeded(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Bribe = "yes";

        if (vars.Creature == 2)
        {
            LiberalEventGood(globalData);
            return;
        }

        if (vars.Lib == "taxes")
        {
            LiberalEventA(globalData);
            return;
        }

        LiberalEventB(globalData);
    }

    private static void LiberalBribeFailed(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Bribe = "no";

        if (vars.Creature == 2)
        {
            LiberalEventGood(globalData);
            return;
        }

        if (string.IsNullOrEmpty(vars.LiberalEvent2abNextPsg))
        {
            vars.LiberalEvent2abNextPsg = Random.Shared.Next(2) == 0 ? "LiberalEventA" : "LiberalEventB";
        }

        if (vars.LiberalEvent2abNextPsg == "LiberalEventA")
        {
            LiberalEventA(globalData);
            return;
        }

        LiberalEventB(globalData);
    }

    internal static void LiberalEventGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Bribe = "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalEventGood_Setup);
    }

    private static void LiberalEventGood_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            LiberalEventGoodContinue);
    }

    private static void LiberalEventGoodContinue(GlobalData globalData)
    {
        if (globalData.FearOfTheUnknownVars.Lib == "taxes")
        {
            LiberalEventA(globalData);
            return;
        }

        LiberalEventB(globalData);
    }

    internal static void LiberalEventA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithCondition(1, () => vars.Bribe == "no"));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalEventA_Setup);
    }

    private static void LiberalEventA_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            PaymentOrDeathA);
    }

    internal static void LiberalEventB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithCondition(1, () => vars.Bribe == "no"));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalEventB_Setup);
    }

    private static void LiberalEventB_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string asylumUp = string.IsNullOrEmpty(vars.AsylumUp) ? "Asylum" : vars.AsylumUp;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            PaymentOrDeathA,
            str => str.FormatWithReplacement(0, asylumUp));
    }

    // =========================================================================
    // END OF MIDDLE YEARS (B): LiberalTaxes -> LiberalTaxes1 -> LiberalTaxes2 /
    // TaxesEventGood -> Liberal (Late)
    // =========================================================================

    internal static void LiberalTaxes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalTaxes1);
    }

    internal static void LiberalTaxes1(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddOnceYouAreReady(LiberalTaxesResolve);
    }

    private static void LiberalTaxesResolve(GlobalData globalData)
    {
        if (globalData.FearOfTheUnknownVars.Creature == 2)
        {
            TaxesEventGood(globalData);
            return;
        }

        LiberalTaxes2(globalData);
    }

    internal static void LiberalTaxes2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(LiberalTaxes2_Setup);
    }

    private static void LiberalTaxes2_Setup(GlobalData globalData)
    {
        string paidVp    = Random.Shared.Next(1, 4).ToString();
        string refusedVp = Random.Shared.Next(1, 3).ToString();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            Liberal,
            str => str
                .FormatWithReplacement(0, paidVp)
                .FormatWithReplacement(1, refusedVp));
    }

    internal static void TaxesEventGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.RandomName)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(TaxesEventGood_Setup);
    }

    private static void TaxesEventGood_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Liberal);
    }

    // =========================================================================
    // PAYMENT OR DEATH: PaymentOrDeathA..D -> Payment2Hub
    // Only players who still owe a contract debt (ContArr) are prompted.
    // =========================================================================

    internal static void PaymentOrDeathA(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.ACont == 0)
        {
            PaymentOrDeathB(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentHandoff(globalData, 0, PaymentRevealA);
    }

    internal static void PaymentOrDeathB(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.BCont == 0)
        {
            if (globalData.PlayersNum > 2) PaymentOrDeathC(globalData);
            else Payment2Hub(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentHandoff(globalData, 1, PaymentRevealB);
    }

    internal static void PaymentOrDeathC(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (globalData.PlayersNum <= 2 || vars.CCont == 0)
        {
            if (globalData.PlayersNum > 3) PaymentOrDeathD(globalData);
            else Payment2Hub(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentHandoff(globalData, 2, PaymentRevealC);
    }

    internal static void PaymentOrDeathD(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (globalData.PlayersNum <= 3 || vars.DCont == 0)
        {
            Payment2Hub(globalData);
            return;
        }

        globalData.SaveToUndo();
        ShowPaymentHandoff(globalData, 3, PaymentRevealD);
    }

    private static void ShowPaymentHandoff(GlobalData globalData, int playerIdx, Action<GlobalData> reveal)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string playerName = vars.GetPlayerName(globalData, playerIdx);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "PaymentOrDeath");
        globalData.ActiveWindow.AddDefaultContent(null, "PaymentOrDeath");
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, reveal);
    }

    private static void ShowPaymentReveal(
        GlobalData          globalData,
        int                 playerIdx,
        Action<GlobalData>  payCallback,
        Action<GlobalData>  refuseCallback)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string playerName = vars.GetPlayerName(globalData, playerIdx);
        string owed       = vars.ContArr[playerIdx].ToString();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "PaymentReveal");
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, playerName)
                .FormatWithReplacement(1, owed),
            "PaymentReveal");
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { payCallback },
            true,
            null,
            "PaymentReveal");
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { refuseCallback },
            true,
            null,
            "PaymentReveal");
    }

    private static void PaymentRevealA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentReveal(globalData, 0, Payment2ThanksA, Payment2NoA);
    }

    private static void PaymentRevealB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentReveal(globalData, 1, Payment2ThanksB, Payment2NoB);
    }

    private static void PaymentRevealC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentReveal(globalData, 2, Payment2ThanksC, Payment2NoC);
    }

    private static void PaymentRevealD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPaymentReveal(globalData, 3, Payment2ThanksD, Payment2NoD);
    }

    private static void ShowPayment2Thanks(GlobalData globalData, int playerIdx, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string playerName = vars.GetPlayerName(globalData, playerIdx);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "Payment2Thanks");
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, playerName),
            "Payment2Thanks");
        globalData.ActiveWindow.AddClickHereToContinue(next);
    }

    private static void ShowPayment2Refusal(GlobalData globalData, int playerIdx, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string playerName = vars.GetPlayerName(globalData, playerIdx);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, "Payment2No");
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, playerName),
            "Payment2No");
        globalData.ActiveWindow.AddClickHereToContinue(next);
    }

    private static void ShowPaymentThanksSetup(GlobalData globalData, int playerIdx, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        string owed = vars.ContArr[playerIdx].ToString();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Accept,
            next,
            "Payment2Thanks_Setup_Content",
            str => str.FormatWithReplacement(0, owed));
    }

    private static void ShowPaymentRefusalSetup(GlobalData globalData, Action<GlobalData> next)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Self,
            PopUpButton.Accept,
            next,
            "Payment2No_Setup_Content");
    }

    internal static void Payment2ThanksA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Thanks(globalData, 0, Payment2ThanksA_Setup);
    }

    private static void Payment2ThanksA_Setup(GlobalData globalData)
    {
        ShowPaymentThanksSetup(globalData, 0, PaymentOrDeathB);
    }

    internal static void Payment2NoA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Refusal(globalData, 0, Payment2NoA_Setup);
    }

    private static void Payment2NoA_Setup(GlobalData globalData)
    {
        ShowPaymentRefusalSetup(globalData, PaymentOrDeathB);
    }

    internal static void Payment2ThanksB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Thanks(globalData, 1, Payment2ThanksB_Setup);
    }

    private static void Payment2ThanksB_Setup(GlobalData globalData)
    {
        ShowPaymentThanksSetup(globalData, 1, PaymentOrDeathC);
    }

    internal static void Payment2NoB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Refusal(globalData, 1, Payment2NoB_Setup);
    }

    private static void Payment2NoB_Setup(GlobalData globalData)
    {
        ShowPaymentRefusalSetup(globalData, PaymentOrDeathC);
    }

    internal static void Payment2ThanksC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Thanks(globalData, 2, Payment2ThanksC_Setup);
    }

    private static void Payment2ThanksC_Setup(GlobalData globalData)
    {
        ShowPaymentThanksSetup(globalData, 2, PaymentOrDeathD);
    }

    internal static void Payment2NoC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Refusal(globalData, 2, Payment2NoC_Setup);
    }

    private static void Payment2NoC_Setup(GlobalData globalData)
    {
        ShowPaymentRefusalSetup(globalData, PaymentOrDeathD);
    }

    internal static void Payment2ThanksD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Thanks(globalData, 3, Payment2ThanksD_Setup);
    }

    private static void Payment2ThanksD_Setup(GlobalData globalData)
    {
        ShowPaymentThanksSetup(globalData, 3, Payment2Hub);
    }

    internal static void Payment2NoD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowPayment2Refusal(globalData, 3, Payment2NoD_Setup);
    }

    private static void Payment2NoD_Setup(GlobalData globalData)
    {
        ShowPaymentRefusalSetup(globalData, Payment2Hub);
    }

    internal static void Payment2Hub(GlobalData globalData)
    {
        if (globalData.FearOfTheUnknownVars.Path4 == "PEPrivatized")
        {
            Privatized(globalData);
            return;
        }

        Liberal(globalData);
    }

    // =========================================================================
    // END OF LATE YEARS: LiberalBonus -> PEWitchEnding
    // =========================================================================

    internal static void LiberalBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        int threshold = globalData.PlayersNum >= 4 ? 3 : 2;
        vars.Ending = vars.AsylumCount >= threshold ? "FOTU-End7" : "FOTU-End8";

        string programName = string.IsNullOrEmpty(vars.MenName) ? "Rehabilitation" : vars.MenName;
        string programType = string.IsNullOrEmpty(vars.MenType) ? "Occult" : vars.MenType;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, programName));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, programType)
                .FormatWithCondition(1, () => globalData.PlayersNum >= 4));
        globalData.ActiveWindow.AddClickHereToContinue(PEWitchEnding);
    }

    // =========================================================================
    // HUB ACTION: A FOCUS ON REHABILITATION
    // AsylumTreatment -> AsylumTreatmentB -> AsylumTreatmentBPay / AsylumInterviewBegin
    // =========================================================================

    internal static void AsylumTreatment(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Gen3Pg = 1;

        string[] suffixes = ["A", "B", "C", "D"];
        string   logId    = Random.Shared.Next(151, 3001) + " " + suffixes[Random.Shared.Next(suffixes.Length)];

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, logId));
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(chosenName =>
        {
            globalData.FearOfTheUnknownVars.Asymlump = chosenName;
            AsylumTreatmentB(globalData);
        });
    }

    internal static void AsylumTreatmentB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.AsylumCount++;

        string patient   = vars.Asymlump;
        string caseId    = Random.Shared.Next(151, 3001).ToString();
        int    noteIdx   = Random.Shared.Next(4);
        int    detailIdx = Random.Shared.Next(4);
        int    gripeIdx  = Random.Shared.Next(3);
        int    closeIdx  = Random.Shared.Next(4);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, patient));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, patient)
                .FormatWithReplacement(1, caseId)
                .FormatWithIndex(2, noteIdx)
                .FormatWithIndex(3, detailIdx)
                .FormatWithIndex(4, gripeIdx)
                .FormatWithIndex(5, closeIdx)
                .FormatWithCondition(6, () => vars.CureCount == "yes"));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>?> { AsylumTreatmentBPay },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>?> { AsylumInterviewBegin },
            true);
    }

    internal static void AsylumTreatmentBPay(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.Asymlump));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumTreatmentBPay_Setup);
    }

    private static void AsylumTreatmentBPay_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_RehabilitationToken,
            PopUpButton.Accept,
            ReturnToCurrentHub);
    }

    internal static void AsylumInterviewBegin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Test = 0;
        vars.Next = "1";
        vars.AsylumQuestion = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithCondition(0, () => vars.CureCount == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumHub);
    }

    /// <summary>
    /// Shuffles the psychological assessment question pool and stores the first four
    /// picks into Quest1..Quest4. No UI of its own: routes straight into AsylumTest1.
    /// </summary>
    internal static void AsylumHub(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        bool   isCount = vars.CureCount == "yes";
        int    poolMax = isCount ? 8 : 9;
        string prefix  = isCount ? "CountQuestion" : "AsylumQuestion";

        List<int> pool = new();
        for (int i = 1; i <= poolMax; i++) pool.Add(i);
        for (int i = pool.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (pool[i], pool[j]) = (pool[j], pool[i]);
        }

        vars.Qu1 = pool[0];
        vars.Qu2 = pool[1];
        vars.Qu3 = pool[2];
        vars.Qu4 = pool[3];

        vars.Quest1 = prefix + vars.Qu1;
        vars.Quest2 = prefix + vars.Qu2;
        vars.Quest3 = prefix + vars.Qu3;
        vars.Quest4 = prefix + vars.Qu4;

        vars.AsylumQuestion = 1;
        AsylumTest1(globalData);
    }

    /// <summary>Pure router: shows question 1-4, then the results passage.</summary>
    internal static void AsylumTest1(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        switch (vars.AsylumQuestion)
        {
            case 1: RunAsylumQuestion(globalData, vars.Quest1); return;
            case 2: RunAsylumQuestion(globalData, vars.Quest2); return;
            case 3: RunAsylumQuestion(globalData, vars.Quest3); return;
            case 4: RunAsylumQuestion(globalData, vars.Quest4); return;
        }

        if (vars.CureCount == "yes")
        {
            CountTestResults(globalData);
            return;
        }

        AsylumTestResults(globalData);
    }

    private static void RunAsylumQuestion(GlobalData globalData, string questionName)
    {
        switch (questionName)
        {
            case "AsylumQuestion1": AsylumQuestion1(globalData); return;
            case "AsylumQuestion2": AsylumQuestion2(globalData); return;
            case "AsylumQuestion3": AsylumQuestion3(globalData); return;
            case "AsylumQuestion4": AsylumQuestion4(globalData); return;
            case "AsylumQuestion5": AsylumQuestion5(globalData); return;
            case "AsylumQuestion6": AsylumQuestion6(globalData); return;
            case "AsylumQuestion7": AsylumQuestion7(globalData); return;
            case "AsylumQuestion8": AsylumQuestion8(globalData); return;
            case "AsylumQuestion9": AsylumQuestion9(globalData); return;
            case "CountQuestion1":  CountQuestion1(globalData);  return;
            case "CountQuestion2":  CountQuestion2(globalData);  return;
            case "CountQuestion3":  CountQuestion3(globalData);  return;
            case "CountQuestion4":  CountQuestion4(globalData);  return;
            case "CountQuestion5":  CountQuestion5(globalData);  return;
            case "CountQuestion6":  CountQuestion6(globalData);  return;
            case "CountQuestion7":  CountQuestion7(globalData);  return;
            case "CountQuestion8":  CountQuestion8(globalData);  return;
            default:                AsylumQuestion1(globalData); return;
        }
    }

    /// <summary>
    /// Renders one assessment question. <paramref name="answerScores"/> holds the delta
    /// applied to the "instability" score for each answer, in order.
    /// </summary>
    private static void ShowAsylumQuestion(GlobalData globalData, string tagBase, int[] answerScores)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int questionIdx = vars.AsylumQuestion - 1;
        if (questionIdx < 0) questionIdx = 0;
        if (questionIdx > 3) questionIdx = 3;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            str => str.FormatWithIndex(0, questionIdx),
            "AsylumQuestionHeader");
        globalData.ActiveWindow.AddDefaultContent(null, tagBase);
        globalData.ActiveWindow.AddChoose();

        for (int i = 0; i < answerScores.Length; i++)
        {
            int delta = answerScores[i];
            globalData.ActiveWindow.AddNextContentWithLinks(
                i + 1,
                new List<Action<GlobalData>?> { gd => AnswerAsylumQuestion(gd, delta) },
                true,
                null,
                tagBase);
        }
    }

    private static void AnswerAsylumQuestion(GlobalData globalData, int delta)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Test += delta;
        vars.AsylumQuestion++;
        AsylumTest1(globalData);
    }

    internal static void AsylumQuestion1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion1", [1, 0, 1]);
    }

    internal static void AsylumQuestion2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion2", [0, 1, 1, 0]);
    }

    internal static void AsylumQuestion3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion3", [1, 1, 0]);
    }

    internal static void AsylumQuestion4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion4", [1, 0, 1, 0]);
    }

    internal static void AsylumQuestion5(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion5", [1, 0, 1]);
    }

    internal static void AsylumQuestion6(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion6", [1, 1, 0, 1]);
    }

    internal static void AsylumQuestion7(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion7", [0, 0, 1]);
    }

    internal static void AsylumQuestion8(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion8", [1, 0, 0, 1]);
    }

    internal static void AsylumQuestion9(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "AsylumQuestion9", [1, 0, 1, 1]);
    }

    internal static void CountQuestion1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion1", [1, 0, 0, 0]);
    }

    internal static void CountQuestion2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion2", [-1, 0, 1]);
    }

    internal static void CountQuestion3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion3", [1, -1, 0, 1]);
    }

    internal static void CountQuestion4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion4", [1, -1, 0]);
    }

    internal static void CountQuestion5(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion5", [-1, 1, 1, 0]);
    }

    internal static void CountQuestion6(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion6", [1, 0, 0, 1]);
    }

    internal static void CountQuestion7(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion7", [1, 1, -1]);
    }

    internal static void CountQuestion8(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowAsylumQuestion(globalData, "CountQuestion8", [1, -1]);
    }

    // =========================================================================
    // ASSESSMENT RESULTS
    // =========================================================================

    internal static void AsylumTestResults(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        int metabolismIdx = Random.Shared.Next(5);
        int physicalIdx   = Random.Shared.Next(4);
        bool committed    = vars.Test > 3;

        if (!committed)
        {
            if (string.IsNullOrEmpty(vars.AsylumTestResultsNextPsg))
            {
                vars.AsylumTestResultsNextPsg = Random.Shared.Next(1, 6).ToString();
            }

            vars.Outcome = int.TryParse(vars.AsylumTestResultsNextPsg, out int parsed) ? parsed : 1;
        }
        else
        {
            vars.Outcome = 0;
        }

        int outcomeIdx = vars.Outcome;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, vars.Asymlump));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Asymlump)
                .FormatWithIndex(1, metabolismIdx)
                .FormatWithIndex(2, physicalIdx)
                .FormatWithIndex(3, outcomeIdx));
        globalData.ActiveWindow.AddClickHereToContinue(AsylumTestResults_Setup);
    }

    private static void AsylumTestResults_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string icon = vars.Outcome switch
        {
            1 => PopUpIcon.Money_Icon,
            2 => PopUpIcon.MaladjustmentBack,
            3 => PopUpIcon.Caretaker,
            4 => PopUpIcon.MaladjustmentBack,
            5 => PopUpIcon.Insanity_Icon,
            _ => PopUpIcon.Self
        };

        int outcomeIdx = vars.Outcome;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            ReturnToCurrentHub,
            str => str.FormatWithIndex(0, outcomeIdx));
    }

    internal static void CountTestResults(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        bool isThrall = !string.IsNullOrEmpty(vars.CurePlayer) && vars.Asymlump == vars.CurePlayer;
        vars.Outcome  = isThrall ? 0 : vars.Test >= 3 ? 1 : 2;

        int outcomeIdx = vars.Outcome;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, vars.Asymlump));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Asymlump)
                .FormatWithIndex(1, outcomeIdx));
        globalData.ActiveWindow.AddClickHereToContinue(CountTestResults_Setup);
    }

    private static void CountTestResults_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string icon = vars.Outcome == 0
            ? PopUpIcon.S2_BlessingOfTheStrigoi
            : PopUpIcon.ScoreTrackMarker;

        int outcomeIdx = vars.Outcome;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            ReturnToCurrentHub,
            str => str.FormatWithIndex(0, outcomeIdx));
    }
}
