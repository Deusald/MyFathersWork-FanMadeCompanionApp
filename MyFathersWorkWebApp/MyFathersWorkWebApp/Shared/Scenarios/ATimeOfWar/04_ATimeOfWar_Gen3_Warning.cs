namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    public static void Warning(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.Warning;
        vars.Round = globalData.Years switch
        {
            Years.Early  => 13,
            Years.Middle => 14,
            Years.Late   => 15,
            _            => 13
        };

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle(globalData.Years == Years.Early ? "Warning1" : "Warning2");
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        // --- Early Years (Warning1) ---
        const string setupEarlySection = "SetupEarly";
        GameplayHubSection setupEarly = globalData.ActiveHub.AddSection(setupEarlySection);
        setupEarly.ReplaceShouldShow(() => globalData.Years == Years.Early && vars.PgGen3 == 0);
        setupEarly.AddDefaultContent(
            setupEarlySection,
            text => text.FormatWithCondition(0, () => globalData.PlayersNum == 3));

        const string technicianSection = "Technician";
        GameplayHubSection technician = globalData.ActiveHub.AddSection(technicianSection);
        technician.ReplaceShouldShow(() => globalData.Years == Years.Early);
        technician.AddDefaultContent(technicianSection);

        const string utopianEarlySection = "Utopian";
        GameplayHubSection utopianEarly = globalData.ActiveHub.AddSection(utopianEarlySection);
        utopianEarly.ReplaceShouldShow(() => globalData.Years == Years.Early);
        utopianEarly.AddDefaultContent(utopianEarlySection);

        const string universitySection = "University";
        GameplayHubSection university = globalData.ActiveHub.AddSection(universitySection);
        university.ReplaceShouldShow(() => globalData.Years == Years.Early);
        university.AddDefaultContent(universitySection);
        university.AddSpecialClickHere(universitySection, UniGen3);

        // --- Middle & Late Years: Unstabilized Timeline (Warning2 / Warning3) ---
        const string setupContSection = "SetupCont";
        GameplayHubSection setupCont = globalData.ActiveHub.AddSection(setupContSection);
        setupCont.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes");
        setupCont.AddDefaultContent(
            setupContSection,
            text => text.FormatWithReplacement(0, string.IsNullOrEmpty(vars.Cont) ? "17" : vars.Cont));

        // Cont == 17 (Peaceful Green / Park)
        const string cont17DescSection = "Cont17Desc";
        GameplayHubSection cont17Desc = globalData.ActiveHub.AddSection(cont17DescSection);
        cont17Desc.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "17");
        cont17Desc.AddDefaultContent(cont17DescSection);

        const string cont17ActSection = "Cont17Act";
        GameplayHubSection cont17Act = globalData.ActiveHub.AddSection(cont17ActSection);
        cont17Act.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "17");
        cont17Act.AddDefaultContent(cont17ActSection);
        cont17Act.AddSpecialClickHere(cont17ActSection, TriggerTimeWarpFromHub, true);

        // Cont == 18 (Breaking the 4th Wall / Bank)
        const string cont18DescSection = "Cont18Desc";
        GameplayHubSection cont18Desc = globalData.ActiveHub.AddSection(cont18DescSection);
        cont18Desc.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "18");
        cont18Desc.AddDefaultContent(
            cont18DescSection,
            text => text.FormatWithIndex(0, Random.Shared.Next(2)));

        const string cont18ActSection = "Cont18Act";
        GameplayHubSection cont18Act = globalData.ActiveHub.AddSection(cont18ActSection);
        cont18Act.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "18");
        cont18Act.AddDefaultContent(cont18ActSection);
        cont18Act.AddSpecialClickHere(cont18ActSection, TriggerTimeWarpFromHub, true);

        // Cont == 19 (Too Perfect / Science is Stressful / Church)
        const string cont19DescSection = "Cont19Desc";
        GameplayHubSection cont19Desc = globalData.ActiveHub.AddSection(cont19DescSection);
        cont19Desc.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "19");
        cont19Desc.AddDefaultContent(cont19DescSection);

        const string cont19RuleSection = "Cont19Rule";
        GameplayHubSection cont19Rule = globalData.ActiveHub.AddSection(cont19RuleSection);
        cont19Rule.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "19");
        cont19Rule.AddDefaultContent(cont19RuleSection);

        const string cont19ActSection = "Cont19Act";
        GameplayHubSection cont19Act = globalData.ActiveHub.AddSection(cont19ActSection);
        cont19Act.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "19");
        cont19Act.AddDefaultContent(cont19ActSection);
        cont19Act.AddSpecialClickHere(cont19ActSection, TriggerTimeWarpFromHub, true);

        // Cont == 20 (Big Brother / Town Hall)
        const string cont20DescSection = "Cont20Desc";
        GameplayHubSection cont20Desc = globalData.ActiveHub.AddSection(cont20DescSection);
        cont20Desc.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "20");
        cont20Desc.AddDefaultContent(cont20DescSection);

        const string cont20ActSection = "Cont20Act";
        GameplayHubSection cont20Act = globalData.ActiveHub.AddSection(cont20ActSection);
        cont20Act.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "20");
        cont20Act.AddDefaultContent(cont20ActSection);
        cont20Act.AddSpecialClickHere(cont20ActSection, TriggerTimeWarpFromHub, true);

        // Cont == 21 (Amphibious / Blacksmith)
        const string cont21DescSection = "Cont21Desc";
        GameplayHubSection cont21Desc = globalData.ActiveHub.AddSection(cont21DescSection);
        cont21Desc.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "21");
        cont21Desc.AddDefaultContent(cont21DescSection);

        const string cont21ActSection = "Cont21Act";
        GameplayHubSection cont21Act = globalData.ActiveHub.AddSection(cont21ActSection);
        cont21Act.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "21");
        cont21Act.AddDefaultContent(cont21ActSection);
        cont21Act.AddSpecialClickHere(cont21ActSection, TriggerTimeWarpFromHub, true);

        // Cont == 22 (Age of the Dinosaurs / Bunker)
        const string cont22DescSection = "Cont22Desc";
        GameplayHubSection cont22Desc = globalData.ActiveHub.AddSection(cont22DescSection);
        cont22Desc.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "22");
        cont22Desc.AddDefaultContent(cont22DescSection);

        const string cont22ActSection = "Cont22Act";
        GameplayHubSection cont22Act = globalData.ActiveHub.AddSection(cont22ActSection);
        cont22Act.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes" && vars.Cont == "22");
        cont22Act.AddDefaultContent(cont22ActSection);
        cont22Act.AddSpecialClickHere(cont22ActSection, TriggerTimeWarpFromHub, true);

        const string utopianShiftSection = "UtopianShift";
        GameplayHubSection utopianShift = globalData.ActiveHub.AddSection(utopianShiftSection);
        utopianShift.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis != "yes");
        utopianShift.AddDefaultContent(utopianShiftSection);

        // --- Middle & Late Years: Stasis Timeline (Warning2time / Warning3time) ---
        const string setupStasisSection = "SetupStasis";
        GameplayHubSection setupStasis = globalData.ActiveHub.AddSection(setupStasisSection);
        setupStasis.ReplaceShouldShow(() =>
            globalData.Years != Years.Early &&
            vars.Stasis == "yes" &&
            (vars.Master == "0" || string.IsNullOrEmpty(vars.Master)));
        setupStasis.AddDefaultContent(setupStasisSection);

        const string masterworkStasisSection = "MasterworkStasis";
        GameplayHubSection masterworkStasis = globalData.ActiveHub.AddSection(masterworkStasisSection);
        masterworkStasis.ReplaceShouldShow(() =>
            globalData.Years != Years.Early &&
            vars.Stasis == "yes" &&
            (vars.Master == "0" || string.IsNullOrEmpty(vars.Master)));
        masterworkStasis.AddDefaultContent(masterworkStasisSection);
        masterworkStasis.AddSpecialClickHere(masterworkStasisSection, Stasis);

        const string perseveranceSection = "Perseverance";
        GameplayHubSection perseverance = globalData.ActiveHub.AddSection(perseveranceSection);
        perseverance.ReplaceShouldShow(() => globalData.Years != Years.Early && vars.Stasis == "yes");
        perseverance.AddDefaultContent(perseveranceSection);

        // --- End of Round / End of Generation ---
        const string endSection = "End";
        GameplayHubSection endEarlyMiddle = globalData.ActiveHub.AddSection(endSection);
        endEarlyMiddle.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        endEarlyMiddle.AddClickHereContinueNextRound(Warning_0, true);

        globalData.ActiveHub.AddEndOfGenerationSection(Scoring);
    }

    private static void Warning_0(GlobalData globalData)
    {
        if (globalData.Years == Years.Early)
        {
            globalData.ShowEndOfRoundPopUp(WarningEvent);
        }
        else if (globalData.Years == Years.Middle)
        {
            if (globalData.ATimeOfWarVars.Stasis == "yes")
            {
                globalData.ShowEndOfRoundPopUp(gd =>
                {
                    if (gd.ATimeOfWarVars.Rumor2Visited)
                    {
                        OldManToken(gd);
                    }
                    else
                    {
                        Warning(gd);
                    }
                });
            }
            else
            {
                globalData.ATimeOfWarVars.Search++;
                globalData.ShowEndOfRoundPopUp(TimeWarp2);
            }
        }
    }

    private static void TriggerTimeWarpFromHub(GlobalData globalData)
    {
        globalData.ATimeOfWarVars.Search++;
        TimeWarp(globalData);
    }

    #region WarningIntro & Pre-Hub Events

    internal static void WarningIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Generation = Generation.Third;
        globalData.Years      = Years.Early;

        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int baseTotal = Random.Shared.Next(6, 11);
        vars.Total = globalData.PlayersNum switch
        {
            4 => baseTotal - 1,
            3 => baseTotal - 2,
            2 => baseTotal - 3,
            _ => baseTotal
        };
        vars.Search = 0;
        vars.Stasis = "no";
        vars.Ending = "ATOW-End4";
        vars.Master = "0";
        vars.PgGen3 = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WarningIntro_Next);
    }

    private static void WarningIntro_Next(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Crazy >= 1)
        {
            if (Random.Shared.Next(2) == 0)
            {
                CostStick(globalData);
            }
            else
            {
                CostStick2(globalData);
            }
        }
        else
        {
            Late2ResB(globalData);
        }
    }

    internal static void CostStick(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CostStick_0);
    }

    private static void CostStick_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WoodenFigureToken,
            PopUpButton.Accept,
            Late2ResB);
    }

    internal static void CostStick2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CostStick2_0);
    }

    private static void CostStick2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WoodenFigureToken,
            PopUpButton.Accept,
            Late2ResB);
    }

    private static void Late2ResB(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Late != 2)
        {
            WarningWarEnding(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Late2ResB_0);
    }

    private static void Late2ResB_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.MFWlogo,
            PopUpButton.Accept,
            WarningWarEnding);
    }

    private static void WarningWarEnding(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithCondition(1, () => vars.WarWinner == "Separatists"));
        globalData.ActiveWindow.AddClickHereToContinue(WhoopsUtopian);
    }

    private static void WhoopsUtopian(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WhoopsUtopian_0);
    }

    private static void WhoopsUtopian_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ModernExperiment,
            PopUpButton.Accept,
            WhoopsUtopianb);
    }

    private static void WhoopsUtopianb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WhoopsUtopianb_0);
    }

    private static void WhoopsUtopianb_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_CircuitryToken,
            PopUpButton.Accept,
            Warning);
    }

    #endregion WarningIntro & Pre-Hub Events

    #region Time Travel & Timeline Shift Events

    private static void PickNextContPage(ATimeOfWarVars vars)
    {
        string[] allPages = { "17", "18", "19", "20", "21", "22" };
        List<string> candidates = allPages.Where(p => p != vars.Cont).ToList();
        for (int i = candidates.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (candidates[i], candidates[j]) = (candidates[j], candidates[i]);
        }
        vars.TwCode = candidates;
        vars.Cont   = candidates[0];
    }

    internal static void WarningEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(TimeWarp1st);
    }

    internal static void TimeWarp1st(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string[] allPages = { "17", "18", "19", "20", "21", "22" };
        globalData.ATimeOfWarVars.Cont = allPages[Random.Shared.Next(allPages.Length)];

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WarningMaybe);
    }

    internal static void WarningMaybe(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WarningMaybe_0);
    }

    private static void WarningMaybe_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ModernExperiment,
            PopUpButton.Accept,
            Warning);
    }

    internal static void TimeWarp(GlobalData globalData)
    {
        globalData.SaveToUndo();
        PickNextContPage(globalData.ATimeOfWarVars);

        int flavorIndex = Random.Shared.Next(4);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(text => text.FormatWithIndex(0, flavorIndex));
        globalData.ActiveWindow.AddClickHereToContinue(TimeWarp_0);
    }

    private static void TimeWarp_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int bonusVp = Random.Shared.Next(1, 3);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            TimeWarp_Next,
            text => text.FormatWithReplacement(0, bonusVp.ToString()));
    }

    private static void TimeWarp_Next(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Search >= vars.Total)
        {
            WarningEvent2(globalData);
        }
        else
        {
            Warning(globalData);
        }
    }

    internal static void WarningEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Stasis = "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Warning);
    }

    internal static void Stasis(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Master = "yes";
        vars.Ending = "ATOW-End3";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(Stasis_0);
    }

    private static void Stasis_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Bodies_Icon,
            PopUpButton.Accept,
            Warning);
    }

    internal static void TimeWarp2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        PickNextContPage(globalData.ATimeOfWarVars);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeWarp2_0);
    }

    private static void TimeWarp2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.GainServantFromLost,
            PopUpButton.Accept,
            TimeWarp2_Next);
    }

    private static void TimeWarp2_Next(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Rumor2Visited)
        {
            OldManToken(globalData);
        }
        else
        {
            Warning(globalData);
        }
    }

    #endregion Time Travel & Timeline Shift Events

    #region OldManToken

    internal static void OldManToken(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddOnceYouAreReady(OldManToken_0);
    }

    private static void OldManToken_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        Action<GlobalData> sepAction = vars.WarLoser == "Separatists" ? OldManYes : OldManNo;
        Action<GlobalData> monAction = vars.WarLoser == "Unified Monarchists" ? OldManYes : OldManNo;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [sepAction, monAction], true);
    }

    internal static void OldManYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(OldManYes_0);
    }

    private static void OldManYes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string icon = vars.Figure == "Sickle" ? PopUpIcon.S3_SickleToken : PopUpIcon.S3_ShieldToken;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            Warning,
            text => text.FormatWithReplacement(0, vars.Figure));
    }

    internal static void OldManNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(OldManNo_0);
    }

    private static void OldManNo_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ExperimentABack,
            PopUpButton.Accept,
            Warning);
    }

    #endregion OldManToken
}
