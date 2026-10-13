namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    public static void Paradox(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.Paradox;
        vars.Round = globalData.Years switch
        {
            Years.Early  => 10,
            Years.Middle => 11,
            Years.Late   => 12,
            _            => 10
        };

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        bool isLateParadox6 = globalData.Years == Years.Late && vars.Release >= 1 && vars.TimeMistake == 6;
        bool isLateParadox8 = globalData.Years == Years.Late && vars.Release >= 1 && vars.TimeMistake == 8;

        // Setup section (Early Years)
        const string setupSection = "Setup";
        GameplayHubSection setup = globalData.ActiveHub.AddSection(setupSection);
        setup.ReplaceShouldShow(() => globalData.Years == Years.Early && vars.PgGen3 == 0);
        setup.AddDefaultContent(
            setupSection,
            text => text.FormatWithCondition(0, () => globalData.PlayersNum == 3));

        // Angry Mob Return (Late Years when TimeMistake == 6)
        const string angryMobReturnSection = "AngryMobReturn";
        GameplayHubSection angryMobReturn = globalData.ActiveHub.AddSection(angryMobReturnSection);
        angryMobReturn.ReplaceShouldShow(() => isLateParadox6);
        angryMobReturn.AddDefaultContent(angryMobReturnSection);

        // Science At any Cost
        const string scienceAtAnyCostSection = "ScienceAtAnyCost";
        GameplayHubSection scienceAtAnyCost = globalData.ActiveHub.AddSection(scienceAtAnyCostSection);
        scienceAtAnyCost.ReplaceShouldShow(() => !isLateParadox6);
        scienceAtAnyCost.AddDefaultContent(
            scienceAtAnyCostSection,
            text => text
                .FormatWithReplacement(0, vars.Figure)
                .FormatWithCondition(1, () => vars.WarWinner == "Unified Monarchists"));

        // Technician
        const string technicianSection = "Technician";
        GameplayHubSection technician = globalData.ActiveHub.AddSection(technicianSection);
        technician.ReplaceShouldShow(() => !isLateParadox8);
        technician.AddDefaultContent(technicianSection);

        // Utopian Experiments
        const string utopianSection = "Utopian";
        GameplayHubSection utopian = globalData.ActiveHub.AddSection(utopianSection);
        utopian.AddDefaultContent(utopianSection);

        // University
        const string universitySection = "University";
        GameplayHubSection university = globalData.ActiveHub.AddSection(universitySection);
        university.ReplaceShouldShow(() => !isLateParadox8);
        university.AddDefaultContent(universitySection);
        university.AddSpecialClickHere(universitySection, UniGen3);

        // In Memoriam (Middle & Late Years when not destroyed)
        const string inMemoriamSection = "InMemoriam";
        GameplayHubSection inMemoriam = globalData.ActiveHub.AddSection(inMemoriamSection);
        inMemoriam.ReplaceShouldShow(() => globalData.Years != Years.Early && !isLateParadox8);
        inMemoriam.AddDefaultContent(
            inMemoriamSection,
            text => text.FormatWithCondition(0, () => vars.Release >= 1));

        // In Memoriam Destroyed (Late Years when TimeMistake == 8)
        const string inMemoriamDestroyedSection = "InMemoriamDestroyed";
        GameplayHubSection inMemoriamDestroyed = globalData.ActiveHub.AddSection(inMemoriamDestroyedSection);
        inMemoriamDestroyed.ReplaceShouldShow(() => isLateParadox8);
        inMemoriamDestroyed.AddDefaultContent(
            inMemoriamDestroyedSection,
            text => text.FormatWithReplacement(0, globalData.TownName));

        // End of Round / End of Generation
        const string endSection = "End";
        GameplayHubSection endEarlyMiddle = globalData.ActiveHub.AddSection(endSection);
        endEarlyMiddle.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        endEarlyMiddle.AddClickHereContinueNextRound(Paradox_0, true);

        globalData.ActiveHub.AddEndOfGenerationSection(ParadoxGiantCheck);
    }

    private static void Paradox_0(GlobalData globalData)
    {
        if (globalData.Years == Years.Early)
        {
            globalData.ShowEndOfRoundPopUp(ParadoxFirst);
        }
        else if (globalData.Years == Years.Middle)
        {
            globalData.ShowEndOfRoundPopUp(gd =>
            {
                if (gd.ATimeOfWarVars.Release >= 1)
                {
                    ParadoxRandoEvent(gd);
                }
                else
                {
                    Paradox(gd);
                }
            });
        }
    }

    #region Paradoxical & Pre-Hub Intro Events

    internal static void Paradoxical(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Generation = Generation.Third;
        globalData.Years      = Years.Early;
        globalData.ATimeOfWarVars.PgGen3 = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Paradoxical_0);
    }

    private static void Paradoxical_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_TimeParadox,
            PopUpButton.Accept,
            ParadoxIntro);
    }

    internal static void ParadoxIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Accolade    = Random.Shared.Next(12, 14);
        vars.TimeMistake = Random.Shared.Next(1, 9);
        vars.Release     = 0;
        vars.Giants      = 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravelEvent);
    }

    internal static void TimeTravelEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravelEvent_0);
    }

    private static void TimeTravelEvent_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ModernExperiment,
            PopUpButton.Accept,
            TimeTravelEventb);
    }

    internal static void TimeTravelEventb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravelEventb_0);
    }

    private static void TimeTravelEventb_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_CircuitryToken,
            PopUpButton.Accept,
            TimeTravelEventb_Next);
    }

    private static void TimeTravelEventb_Next(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Rumor2Visited)
        {
            FigureontheTrackIn(globalData);
        }
        else
        {
            NobodyFigures(globalData);
        }
    }

    internal static void FigureontheTrackIn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Counter = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddOnceYouAreReady(FigureontheTrackIn_0);
    }

    private static void FigureontheTrackIn_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddClickHereToContinue(FigureontheTrackIn_1);
    }

    private static void FigureontheTrackIn_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            FigureontheTrackInb);
    }

    internal static void FigureontheTrackInb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddClickHereToContinue(FigureontheTrackInb_0);
    }

    private static void FigureontheTrackInb_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string icon = vars.Figure == "Sickle" ? PopUpIcon.S3_SickleToken : PopUpIcon.S3_ShieldToken;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            Late2ResA,
            text => text
                .FormatWithReplacement(0, vars.Figure)
                .FormatWithReplacement(1, vars.Accolade.ToString())
                .FormatWithCondition(2, () => vars.WarWinner == "Unified Monarchists"));
    }

    internal static void NobodyFigures(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(NobodyFigures_0);
    }

    private static void NobodyFigures_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Accept,
            Late2ResA,
            text => text
                .FormatWithReplacement(0, vars.Figure)
                .FormatWithReplacement(1, vars.Accolade.ToString())
                .FormatWithCondition(2, () => vars.WarWinner == "Unified Monarchists"));
    }

    internal static void Late2ResA(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Late != 2)
        {
            Paradox(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Late2ResA_0);
    }

    private static void Late2ResA_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.MFWlogo,
            PopUpButton.Accept,
            Paradox);
    }

    #endregion Paradoxical & Pre-Hub Intro Events

    #region ParadoxFirst & MonumentVote (Early -> Middle Years)

    internal static void ParadoxFirst(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ParadoxFirst_0);
    }

    private static void ParadoxFirst_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_GiantMW,
            PopUpButton.Accept,
            ParadoxFirst_Next);
    }

    private static void ParadoxFirst_Next(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Crazy > 0)
        {
            if (Random.Shared.Next(2) == 0)
            {
                FutureStick(globalData);
            }
            else
            {
                CostStick1(globalData);
            }
        }
        else
        {
            MonumentVote(globalData);
        }
    }

    internal static void CostStick1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CostStick1_0);
    }

    private static void CostStick1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WoodenFigureToken,
            PopUpButton.Accept,
            MonumentVote);
    }

    internal static void FutureStick(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(FutureStick_0);
    }

    private static void FutureStick_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WoodenFigureToken,
            PopUpButton.Accept,
            MonumentVote);
    }

    internal static void MonumentVote(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Release = 0;
        for (int i = 0; i < vars.PlayerHasTm.Length; i++)
        {
            vars.PlayerHasTm[i] = false;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(MonuA);
    }

    internal static void MonuA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string playerName = globalData.ATimeOfWarVars.GetDisplayPlayerName(globalData, 0);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, MonuA_0);
    }

    private static void MonuA_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[0] = false;
                    MonuB(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[0] = true;
                    gd.ATimeOfWarVars.Release++;
                    MonuB(gd);
                }
            ],
            true);
    }

    internal static void MonuB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string playerName = globalData.ATimeOfWarVars.GetDisplayPlayerName(globalData, 1);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, MonuB_0);
    }

    private static void MonuB_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Action<GlobalData> nextStep = globalData.PlayersNum > 2 ? MonuC : MonuRes;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[1] = false;
                    nextStep(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[1] = true;
                    gd.ATimeOfWarVars.Release++;
                    nextStep(gd);
                }
            ],
            true);
    }

    internal static void MonuC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string playerName = globalData.ATimeOfWarVars.GetDisplayPlayerName(globalData, 2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, MonuC_0);
    }

    private static void MonuC_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Action<GlobalData> nextStep = globalData.PlayersNum > 3 ? MonuD : MonuRes;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[2] = false;
                    nextStep(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[2] = true;
                    gd.ATimeOfWarVars.Release++;
                    nextStep(gd);
                }
            ],
            true);
    }

    internal static void MonuD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string playerName = globalData.ATimeOfWarVars.GetDisplayPlayerName(globalData, 3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, MonuD_0);
    }

    private static void MonuD_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Action<GlobalData> nextStep = globalData.PlayersNum > 4 ? MonuE : MonuRes;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[3] = false;
                    nextStep(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[3] = true;
                    gd.ATimeOfWarVars.Release++;
                    nextStep(gd);
                }
            ],
            true);
    }

    internal static void MonuE(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string playerName = globalData.ATimeOfWarVars.GetDisplayPlayerName(globalData, 4);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, MonuE_0);
    }

    private static void MonuE_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[4] = false;
                    MonuRes(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.PlayerHasTm[4] = true;
                    gd.ATimeOfWarVars.Release++;
                    MonuRes(gd);
                }
            ],
            true);
    }

    internal static void MonuRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            text => text.FormatWithCondition(0, () => vars.Release >= 1));
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithCondition(0, () => vars.Release >= 1));
        globalData.ActiveWindow.AddClickHereToContinue(MonuRes_0);
    }

    private static void MonuRes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        List<string> lines = new();
        if (vars.Release == 1)
        {
            for (int i = 0; i < globalData.PlayersNum; i++)
            {
                if (vars.PlayerHasTm[i])
                {
                    lines.Add($"{vars.GetDisplayPlayerName(globalData, i)} gains 3VP.");
                }
            }
        }
        else if (vars.Release > 1)
        {
            for (int i = 0; i < globalData.PlayersNum; i++)
            {
                if (vars.PlayerHasTm[i])
                {
                    lines.Add($"{vars.GetDisplayPlayerName(globalData, i)} gains a Compulsion.");
                }
            }
        }

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (!vars.PlayerHasTm[i])
            {
                lines.Add($"{vars.GetDisplayPlayerName(globalData, i)} draws 1 Utopian Experiment and gains 1 <icon=Creepy_Icon>.");
            }
        }

        string summary = string.Join("<br />", lines);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_EstateUpgradeBack,
            PopUpButton.Accept,
            Paradox,
            text => text.FormatWithReplacement(0, summary));
    }

    #endregion ParadoxFirst & MonumentVote (Early -> Middle Years)

    #region ParadoxRandoEvent & ParadoxTimeRandom (Middle -> Late Years)

    internal static void ParadoxRandoEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.TimeMistake = Random.Shared.Next(1, 9);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [ParadoxTimeRandom], true);
    }

    internal static void ParadoxTimeRandom(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int idx = Math.Clamp(globalData.ATimeOfWarVars.TimeMistake - 1, 0, 7);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(text => text.FormatWithIndex(0, idx));
        globalData.ActiveWindow.AddDefaultContent(text => text.FormatWithIndex(0, idx));
        globalData.ActiveWindow.AddClickHereToContinue(ParadoxTimeRandom_0);
    }

    private static void ParadoxTimeRandom_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int mistake = Math.Clamp(vars.TimeMistake, 1, 8);

        string icon = mistake switch
        {
            1 => PopUpIcon.ExperimentCFront,
            2 => PopUpIcon.CompulsionBack,
            3 => PopUpIcon.ScoreTrackMarker,
            4 => PopUpIcon.MFWlogo,
            5 => PopUpIcon.LoseCreepy,
            6 => PopUpIcon.AngryMob_Icon,
            7 => PopUpIcon.S3_CardBack,
            8 => PopUpIcon.VillageChronicleCover,
            _ => PopUpIcon.MFWlogo
        };

        List<string> targetedLines = new();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.PlayerHasTm[i])
            {
                targetedLines.Add($"{vars.GetDisplayPlayerName(globalData, i)} must flip their Giant Masterwork face-down.");
            }
        }
        string targetedSummary = string.Join("<br />", targetedLines);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            icon,
            PopUpButton.Accept,
            Paradox,
            text => text
                .FormatWithReplacement(0, vars.Figure)
                .FormatWithReplacement(1, targetedSummary)
                .FormatWithIndex(2, mistake - 1));
    }

    #endregion ParadoxRandoEvent & ParadoxTimeRandom (Middle -> Late Years)

    #region End of Generation: ParadoxGiantCheck & ParadoxEvent

    internal static void ParadoxGiantCheck(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        // One <link=N> marker per possible giant count (0..PlayersNum) in the localized string.
        List<Action<GlobalData>?> giantCallbacks = new();
        for (int count = 0; count <= globalData.PlayersNum; count++)
        {
            int capturedCount = count;
            giantCallbacks.Add(gd =>
            {
                gd.ATimeOfWarVars.Giants = capturedCount;
                ParadoxEvent(gd);
            });
        }

        globalData.ActiveWindow.AddNextContentWithLinks(1, giantCallbacks, true);
    }

    internal static void ParadoxEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.TimeMistake < 8 && vars.Release >= 1)
        {
            vars.Giants--;
        }

        int requiredGiants = globalData.PlayersNum switch
        {
            2 => 1,
            3 => 2,
            _ => 3
        };
        vars.Ending = vars.Giants >= requiredGiants ? "ATOW-End1" : "ATOW-End2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            text => text.FormatWithCondition(0, () => vars.TimeMistake < 8));
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithCondition(0, () => vars.TimeMistake < 8));

        if (vars.TimeMistake == 8)
        {
            globalData.ActiveWindow.AddClickHereToContinue(Scoring);
        }
        else
        {
            globalData.ActiveWindow.AddClickHereToContinue(ParadoxEvent_0);
        }
    }

    private static void ParadoxEvent_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_EstateUpgradeBack,
            PopUpButton.Accept,
            Scoring,
            text => text.FormatWithCondition(0, () => vars.Release >= 1));
    }

    #endregion End of Generation: ParadoxGiantCheck & ParadoxEvent
}
