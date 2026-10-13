namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    // =========================================================================
    // GENERATION III - TENSION: INTRO CHAIN
    // TensionIntro -> TensionSetting -> WallCheck -> TenseBricksRes -> WitchTensionResolution -> Creepy1stPlayerB -> PEWitch3Intro
    // =========================================================================

    internal static void TensionIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.Generation = Generation.Third;
        globalData.Years = Years.Early;
        vars.Path4 = "PETension";
        vars.Visit = 2;
        vars.TenseGood = 0;
        vars.TenseBad = 1;
        vars.Ten = 0;
        vars.Eor = 0;

        string randomPlayer = GetRandomPlayerName(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, randomPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(TensionSetting);
    }

    internal static void TensionSetting(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(TensionSetting_Setup);
    }

    private static void TensionSetting_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_RomaniToken,
            PopUpButton.Accept,
            WallCheck);
    }

    internal static void WallCheck(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Gen2Fate != "witch")
        {
            TenseBricksRes(globalData);
            return;
        }

        globalData.SaveToUndo();
        vars.Wal = globalData.PlayersNum switch
        {
            2 => Random.Shared.Next(2, 6),
            3 => Random.Shared.Next(4, 9),
            _ => Random.Shared.Next(6, 10)
        };
        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Walls = "yes";
                    TenseBricksRes(gd);
                }
            },
            true,
            str => str.FormatWithReplacement(0, vars.Wal.ToString()));
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.Walls = "no";
                    TenseBricksRes(gd);
                }
            },
            true,
            str => str.FormatWithReplacement(0, vars.Wal.ToString()));
    }

    internal static void TenseBricksRes(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Walls != "no")
        {
            WitchTensionResolution(globalData);
            return;
        }

        globalData.SaveToUndo();
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(WitchTensionResolution);
    }

    internal static void WitchTensionResolution(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Cursed != "1" || vars.Witch == vars.WSuspect)
        {
            Creepy1stPlayerB(globalData);
            return;
        }

        globalData.SaveToUndo();
        bool witchHasPlot =
            (vars.Witch == vars.GetPlayerName(globalData, 0) && vars.PlotA == "yes") ||
            (vars.Witch == vars.GetPlayerName(globalData, 1) && vars.PlotB == "yes") ||
            (vars.Witch == vars.GetPlayerName(globalData, 2) && vars.PlotC == "yes") ||
            (vars.Witch == vars.GetPlayerName(globalData, 3) && vars.PlotD == "yes") ||
            (vars.Witch == vars.GetPlayerName(globalData, 4) && vars.PlotE == "yes");

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Witch)
                .FormatWithCondition(1, () => witchHasPlot));
        globalData.ActiveWindow.AddClickHereToContinue(WitchTensionResolution_Setup);
    }

    private static void WitchTensionResolution_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.GainServantFromLost,
            PopUpButton.Accept,
            Creepy1stPlayerB,
            str => str.FormatWithReplacement(0, vars.Witch));
    }

    internal static void Creepy1stPlayerB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Creepy1stPlayerB_Setup);
    }

    private static void Creepy1stPlayerB_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            PEWitch3Intro);
    }

    // =========================================================================
    // GENERATION III - TENSION HUB (Early, Middle, Late Years)
    // =========================================================================

    public static void Tension(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.HubId = FearOfUnknownHubId.Tension;
        vars.Round = globalData.Years == Years.Early ? 13 : globalData.Years == Years.Middle ? 14 : 15;

        globalData.ActiveHub = new GameplayHub(globalData);
        if (globalData.Years == Years.Early)
        {
            globalData.ActiveHub.SetDefaultTitle();
        }
        else
        {
            // SetDefaultTitle only accepts a tag base, so the good/bad variation is
            // carried by two separate tags rather than a conditional format.
            globalData.ActiveHub.SetDefaultTitle(vars.Tension == "bad" ? "TensionBad" : "TensionGood");
        }
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        if (globalData.Years == Years.Early)
        {
            if (vars.Ten == 0)
            {
                GameplayHubSection setupSec = globalData.ActiveHub.AddSection("Setup");
                setupSec.AddDefaultContent(
                    "Setup",
                    str => str
                        .FormatWithCondition(0, () => vars.Walls == "yes")
                        .FormatWithCondition(1, () => globalData.PlayersNum == 3));

                GameplayHubSection ruleSec = globalData.ActiveHub.AddSection("SpecialRule");
                ruleSec.AddDefaultContent("SpecialRule");

                GameplayHubSection eventSec = globalData.ActiveHub.AddSection("SpecialEvent");
                eventSec.AddDefaultContent("SpecialEvent");
                eventSec.AddClickHere(
                    gd =>
                    {
                        gd.FearOfTheUnknownVars.Eor = 0;
                        TenseConfirm(gd);
                    },
                    true);
            }
            else
            {
                vars.Eor = 1;
            }
        }
        else if (globalData.Years == Years.Middle)
        {
            if (vars.Tension == "bad")
            {
                GameplayHubSection badSetupSec = globalData.ActiveHub.AddSection("MiddleBadSetup");
                badSetupSec.AddDefaultContent("MiddleBadSetup");

                GameplayHubSection badRuleSec = globalData.ActiveHub.AddSection("BadSpecialRule");
                badRuleSec.AddDefaultContent("BadSpecialRule");
            }
            else
            {
                GameplayHubSection goodSetupSec = globalData.ActiveHub.AddSection("MiddleGoodSetup");
                goodSetupSec.AddDefaultContent("MiddleGoodSetup");

                GameplayHubSection crossroadsSec = globalData.ActiveHub.AddSection("Crossroads");
                crossroadsSec.AddDefaultContent(
                    "Crossroads",
                    str => str.FormatWithReplacement(0, vars.Crossroads.ToString()));
                crossroadsSec.AddClickHere(Gen3Token2SignIn, true);
            }
        }
        else
        {
            if (vars.Tension == "bad")
            {
                GameplayHubSection badRuleSec = globalData.ActiveHub.AddSection("BadSpecialRule");
                badRuleSec.AddDefaultContent("BadSpecialRule");

                if (vars.TenseBad == 0)
                {
                    GameplayHubSection obsPenaltySec = globalData.ActiveHub.AddSection("ObsessionPenalty");
                    obsPenaltySec.AddDefaultContent(
                        "ObsessionPenalty",
                        str => str.FormatWithReplacement(0, vars.ObsVp.ToString()));
                }
            }
            else
            {
                GameplayHubSection crossroadsSec = globalData.ActiveHub.AddSection("Crossroads");
                crossroadsSec.AddDefaultContent(
                    "Crossroads",
                    str => str.FormatWithReplacement(0, vars.Crossroads.ToString()));
                crossroadsSec.AddClickHere(Gen3Token2SignIn, true);
            }
        }

        if (vars.Walls == "no")
        {
            GameplayHubSection plotSec = globalData.ActiveHub.AddSection("PlotExpansion");
            plotSec.AddDefaultContent("PlotExpansion");
        }

        GameplayHubSection occultSec = globalData.ActiveHub.AddSection("OccultExperimentation");
        occultSec.AddDefaultContent(
            "OccultExperimentation",
            str => str.FormatWithCondition(0, () => globalData.PlayersNum >= 4));

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
                gd => gd.ShowEndOfRoundPopUp(TensionEarlyEndRound),
                true);
        }
        else if (globalData.Years == Years.Middle)
        {
            GameplayHubSection endRoundSec = globalData.ActiveHub.AddSection("EndOfRound");
            endRoundSec.AddDefaultContent("EndOfRound");
            endRoundSec.AddClickHereContinueNextRound(
                gd => gd.ShowEndOfRoundPopUp(TensionMiddleEndRound),
                true);
        }
        else
        {
            globalData.ActiveHub.AddEndOfGenerationSection(TensionBonus);
        }
    }

    private static void TensionEarlyEndRound(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Ten == 0)
        {
            vars.Eor = 1;
            TenseConfirm(globalData);
        }
        else
        {
            ConsequencesTense(globalData);
        }
    }

    private static void TensionMiddleEndRound(GlobalData globalData)
    {
        globalData.Years = Years.Late;
        if (globalData.FearOfTheUnknownVars.Tension == "good")
        {
            Caravancheck(globalData);
        }
        else
        {
            TenseEventBad2(globalData);
        }
    }

    // =========================================================================
    // EARLY YEARS RESOLUTION: TenseConfirm -> ConsequencesTense -> ThistenseBad / ThisTenseGood
    // =========================================================================

    internal static void TenseConfirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Ten = 1;
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(
            vars.Eor == 0 ? TenseConfirmNo_Setup : TenseConfirmYes_Setup);
    }

    private static void TenseConfirmNo_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_RomaniToken,
            PopUpButton.Accept,
            Tension);
    }

    private static void TenseConfirmYes_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Accept,
            ConsequencesTense);
    }

    internal static void ConsequencesTense(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.Years = Years.Middle;

        int badCount = 0;
        int goodCount = 0;
        if (vars.Kill == "butcher") badCount++;
        else goodCount++;

        if (vars.Cursed == "2") badCount++;
        else goodCount++;

        if (vars.Walls == "yes") badCount++;
        else goodCount++;

        vars.TenseBad = badCount;
        vars.TenseGood = goodCount;
        bool isBadPath = badCount > goodCount;
        vars.Tension = isBadPath ? "bad" : "good";

        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, journalHeader)
                .FormatWithReplacement(1, globalData.TownName)
                .FormatWithCondition(2, () => vars.Kill == "butcher")
                .FormatWithCondition(3, () => vars.Cursed == "2")
                .FormatWithCondition(4, () => vars.Walls == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(
            isBadPath ? ThistenseBad : ThisTenseGood);
    }

    internal static void ThistenseBad(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Ending = "FOTU-End4";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(ThistenseBad_Setup);
    }

    private static void ThistenseBad_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_RomaniToken,
            PopUpButton.Accept,
            Caravancheck);
    }

    internal static void ThisTenseGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Ending = "FOTU-End3";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName));
        globalData.ActiveWindow.AddClickHereToContinue(ThisTenseGood_Setup);
    }

    private static void ThisTenseGood_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Accept,
            TenseGoodEvent1);
    }

    internal static void TenseGoodEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.Crossroads = Random.Shared.Next(7, 10);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TenseGoodEvent1_Setup);
    }

    private static void TenseGoodEvent1_Setup(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.StorybookToken,
            PopUpButton.Accept,
            Caravancheck,
            str => str.FormatWithReplacement(0, vars.Crossroads.ToString()));
    }

    // =========================================================================
    // END OF MIDDLE YEARS (BAD PATH): TenseEventBad2 -> TenseEventBad2b / TwoPTenseEvent1 -> Caravancheck
    // =========================================================================

    internal static void TenseEventBad2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.ObsVp = Random.Shared.Next(4, 7);
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(
            globalData.PlayersNum == 2 ? TwoPTenseEvent1 : TenseEventBad2b);
    }

    internal static void TenseEventBad2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.ObsVp.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(TenseEventBad2Res);
    }

    internal static void TenseEventBad2Res(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.TenseBad = 0;
                    TenseEventBad2Yes(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>>
            {
                TenseEventBad2No
            },
            true);
    }

    internal static void TwoPTenseEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.ObsVp.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(TwoPTenseEvent2);
    }

    internal static void TwoPTenseEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            new List<Action<GlobalData>>
            {
                gd =>
                {
                    gd.FearOfTheUnknownVars.TenseBad = 0;
                    TenseEventBad2Yes(gd);
                }
            },
            true);
        globalData.ActiveWindow.AddNextContentWithLinks(
            2,
            new List<Action<GlobalData>>
            {
                TenseEventBad2No
            },
            true);
    }

    internal static void TenseEventBad2Yes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TenseEventBad2Yes_Setup);
    }

    private static void TenseEventBad2Yes_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Accept,
            Caravancheck,
            str => str
                .FormatWithCondition(0, () => globalData.PlayersNum == 2)
                .FormatWithCondition(1, () => globalData.PlayersNum > 2));
    }

    internal static void TenseEventBad2No(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TenseEventBad2No_Setup);
    }

    private static void TenseEventBad2No_Setup(GlobalData globalData)
    {
        int moveRight = globalData.PlayersNum + 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_RomaniToken,
            PopUpButton.Accept,
            Caravancheck,
            str => str
                .FormatWithReplacement(0, moveRight.ToString())
                .FormatWithCondition(1, () => globalData.PlayersNum > 2));
    }

    // =========================================================================
    // END OF LATE YEARS: TensionBonus -> TensionCaravanResolve -> PEWitchEnding
    // =========================================================================

    internal static void TensionBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.Tension == "bad" && vars.TenseBad == 0)
        {
            vars.TenseBad = 2;
        }
        else
        {
            vars.TenseBad = 0;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithCondition(0, () => globalData.PlayersNum >= 4));
        globalData.ActiveWindow.AddClickHereToContinue(TensionCaravanResolve);
    }

    internal static void TensionCaravanResolve(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        if (vars.CarCount != 0)
        {
            PEWitchEnding(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Newspaper)
                .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(TensionCaravanResolve_Setup);
    }

    private static void TensionCaravanResolve_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_MarketToken,
            PopUpButton.Accept,
            PEWitchEnding);
    }
}
