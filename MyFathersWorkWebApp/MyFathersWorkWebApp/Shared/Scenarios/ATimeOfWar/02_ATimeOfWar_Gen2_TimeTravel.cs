namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    internal static void TimeTravelintro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Generation = Generation.Second;
        globalData.Years      = Years.Early;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravelintro_0);
    }

    private static void TimeTravelintro_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            TimeTravelintro1);
    }

    private static void TimeTravelintro1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Buy      = 0;
        vars.TmRepair = "no";
        vars.PgGen3   = 0;
        vars.Pg13     = 0;
        vars.Master   = "0";
        vars.TtSet    = 0;
        vars.Pg14     = 0;

        if (vars.TakeReact == "1")
        {
            if (vars.WarWinner == "Separatists")
            {
                vars.WarWinner = "Unified Monarchists";
                vars.WarLoser  = "Separatists";
            }
            else
            {
                vars.WarWinner = "Separatists";
                vars.WarLoser  = "Unified Monarchists";
            }
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravelIntro2);
    }

    private static void TimeTravelIntro2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(TimeMachineExperiment);
    }

    private static void TimeMachineExperiment(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddYesNo(TMReplace, TTIntro3);
    }

    private static void TMReplace(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.TmMasterwork = "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TMReplace_0);
    }

    private static void TMReplace_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_MWUpgradeTimeMaching,
            PopUpButton.Accept,
            TTIntro3);
    }

    private static void TTIntro3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTokens);
    }

    private static void TimeTokens(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTokens_0);
    }

    private static void TimeTokens_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ParadoxToken,
            PopUpButton.Accept,
            TimeTravelSetup);
    }

    private static void TimeTravelSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Pg13 = 1;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            TimeTravel,
            str => str.FormatWithCondition(0, () => globalData.PlayersNum == 3));
    }

    public static void TimeTravel(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.TimeTravel;
        vars.Round = globalData.Years switch
        {
            Years.Early  => 4,
            Years.Middle => 5,
            _            => 6
        };

        if (globalData.Years == Years.Early)
        {
            vars.Late = 0;
        }

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        // Late Years: Military Demands (Barracks == "no")
        GameplayHubSection milDemandsSec = globalData.ActiveHub.AddSection("MilitaryDemands", true);
        milDemandsSec.ReplaceShouldShow(() => globalData.Years == Years.Late && vars.Barracks == "no");
        milDemandsSec.AddDefaultContent("MilitaryDemands");

        // Middle & Late Years: Repair the Time Machine (TmRepair == "no")
        GameplayHubSection repairSec = globalData.ActiveHub.AddSection("RepairTimeMachine", true);
        repairSec.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late && vars.TmRepair == "no");
        repairSec.AddDefaultContent("RepairTimeMachine");
        repairSec.AddSpecialClickHere("RepairTimeMachine", ATimeMachineRepaired, true);

        // All Years: Paradox Explanation
        GameplayHubSection paradoxExpSec = globalData.ActiveHub.AddSection("ParadoxExplanation", true);
        paradoxExpSec.AddDefaultContent("ParadoxExplanation");
        paradoxExpSec.AddClickHere(ParadoxExReminder);

        // All Years: Paradoxical Mending Reward (TtSet == 0)
        GameplayHubSection paradoxMendingSec = globalData.ActiveHub.AddSection("ParadoxMending", true);
        paradoxMendingSec.ReplaceShouldShow(() => vars.TtSet == 0);
        paradoxMendingSec.AddDefaultContent("ParadoxMending");
        paradoxMendingSec.AddSpecialClickHere("ParadoxMending", TriggerParadox);

        // Early & Middle Years End of Round
        GameplayHubSection endSec = globalData.ActiveHub.AddSection("End", true);
        endSec.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        endSec.AddDefaultContent("End");
        endSec.AddClickHereContinueNextRound(TimeTravel_EndRound, true);

        // Late Years End of Generation
        globalData.ActiveHub.AddEndOfGenerationSection(TimeTravel_EndRound);
    }

    private static void TimeTravel_EndRound(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ShowEndOfRoundPopUp(
            globalData.Years switch
            {
                Years.Early  => FixIt,
                Years.Middle => TownHallOpposite,
                _            => TimeTravel3_EndGen
            });
    }

    private static void ParadoxExReminder(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (globalData.Years == Years.Early) vars.Pg13 = 1;
        if (globalData.Years == Years.Late) vars.Pg14 = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravel);
    }

    private static void TriggerParadox(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.TtSet = 1;
        if (globalData.Years == Years.Early) vars.Pg13 = 1;
        if (globalData.Years == Years.Late) vars.Pg14 = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TriggerParadox_0);
    }

    private static void TriggerParadox_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int vpAmount = Random.Shared.Next(2) + 3;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            TimeTravel,
            str => str.FormatWithReplacement(0, vpAmount.ToString()));
    }

    private static void ATimeMachineRepaired(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.TmRepair = "yes";
        if (globalData.Years == Years.Late) vars.Pg14 = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TimeTravel);
    }

    private static void FixIt(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(FixIt_0);
    }

    private static void FixIt_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_TimeMachineRepairs,
            PopUpButton.Accept,
            gd =>
            {
                if (gd.ATimeOfWarVars.Rumor1Visited) Militarytoken(gd);
                else TimeTravel(gd);
            });
    }

    private static void Militarytoken(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, crestIcon));
        globalData.ActiveWindow.AddClickHereToContinue(Militarytoken_0);
    }

    private static void Militarytoken_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, crestIcon));
        globalData.ActiveWindow.AddNextContent(1, true, null, MilitaryYes);
        globalData.ActiveWindow.AddNextContent(2, true, null, MilitaryNo);
    }

    private static void MilitaryYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, crestIcon));
        globalData.ActiveWindow.AddClickHereToContinue(MilitaryYes_0);
    }

    private static void MilitaryYes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ParadoxToken,
            PopUpButton.Accept,
            TimeTravel,
            str => str.FormatWithReplacement(0, crestIcon));
    }

    private static void MilitaryNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(MilitaryNo_0);
    }

    private static void MilitaryNo_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string crestIcon = vars.Crest == "Sickle" ? "<icon=S3_SickleToken>" : "<icon=S3_ShieldToken>";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ParadoxToken,
            PopUpButton.Accept,
            TimeTravel,
            str => str.FormatWithReplacement(0, crestIcon));
    }

    private static void TownHallOpposite(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser)
                .FormatWithCondition(2, () => vars.Barracks == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(SeedResolution);
    }

    private static void SeedResolution(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            str => str.FormatWithIndex(0, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithIndex(0, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
        globalData.ActiveWindow.AddClickHereToContinue(SeedResolution_0);
    }

    private static void SeedResolution_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.CompulsionBack,
            PopUpButton.Accept,
            BlameGameEvent,
            str => str.FormatWithIndex(0, Math.Clamp(vars.GunsBonus - 1, 0, 2)));
    }

    private static void BlameGameEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Buy     = 0;
        vars.Counter = 0;
        for (int i = 0; i < vars.BlameCounts.Length; i++)
        {
            vars.BlameCounts[i] = 0;
            vars.SilentVoted[i] = false;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(
            gd =>
            {
                if (gd.PlayersNum == 2) TwoPBlameGameEvent(gd);
                else Blame1(gd);
            });
    }

    private static void TwoPBlameGameEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Blame1);
    }

    private static void Blame1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Counter = 1;
        ShowBlameHandDevice(globalData);
    }

    private static void Blame2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Counter = 2;
        ShowBlameHandDevice(globalData);
    }

    private static void Blame3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Counter = 3;
        ShowBlameHandDevice(globalData);
    }

    private static void Blame4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Counter = 4;
        ShowBlameHandDevice(globalData);
    }

    private static void ShowBlameHandDevice(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string playerName = vars.GetDisplayPlayerName(globalData, vars.Counter - 1);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, playerName));
        globalData.ActiveWindow.AddClickHereToContinue(BlameInterrogation);
    }

    private static void BlameInterrogation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddNextContent(1, true, null, Blame1c);
        globalData.ActiveWindow.AddNextContent(2, true, null, Blame1b);
    }

    private static void Blame1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            null,
            gd =>
            {
                gd.ATimeOfWarVars.Buy++;
                Blame1c(gd);
            });
        globalData.ActiveWindow.AddNextContent(2, true, null, Blame1c);
    }

    private static void Blame1c(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int currentIdx = vars.Counter - 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        // Option: To stay silent.
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            null,
            gd =>
            {
                gd.ATimeOfWarVars.SilentVoted[currentIdx] = true;
                AdvanceBlameQueue(gd);
            });

        // Options: To blame each other player
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (i == currentIdx) continue;
            int targetIdx     = i;
            string targetName = vars.GetDisplayPlayerName(globalData, targetIdx);

            globalData.ActiveWindow.AddNextContent(
                2,
                true,
                str => str.FormatWithReplacement(0, targetName),
                gd =>
                {
                    gd.ATimeOfWarVars.BlameCounts[targetIdx]++;
                    AdvanceBlameQueue(gd);
                });
        }
    }

    private static void AdvanceBlameQueue(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Counter >= globalData.PlayersNum)
        {
            BlameResolve(globalData);
        }
        else if (vars.Counter == 1)
        {
            Blame2(globalData);
        }
        else if (vars.Counter == 2)
        {
            Blame3(globalData);
        }
        else
        {
            Blame4(globalData);
        }
    }

    private static void BlameResolve(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BlameResolve_Evaluate);
    }

    private static void BlameResolve_Evaluate(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        int totalBlame = 0;
        int maxVotes   = -1;
        int maxCount   = 0;
        int winnerIdx  = -1;

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            int c = vars.BlameCounts[i];
            totalBlame += c;
            if (c > maxVotes)
            {
                maxVotes  = c;
                maxCount  = 1;
                winnerIdx = i;
            }
            else if (c == maxVotes)
            {
                maxCount++;
            }
        }

        if (totalBlame == 0)
        {
            vars.Blame = "none";
            vars.Late  = 2;
        }
        else if (maxCount == 1 && maxVotes > 0)
        {
            vars.Blame = vars.GetDisplayPlayerName(globalData, winnerIdx);
            vars.Late  = 1;
        }
        else
        {
            vars.Blame = "tied";
            vars.Late  = 0;
        }

        if (vars.Buy >= 1)
        {
            BlameResolve_BuySetup(globalData);
        }
        else
        {
            RouteAfterBlameResolve(globalData);
        }
    }

    private static void BlameResolve_BuySetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        int bonusIdx = vars.WarWinner == "Separatists"
            ? (vars.Sep == "win" ? 1 : 0)
            : (vars.Mon == "win" ? 2 : 0);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_SeparatistToken,
            PopUpButton.Accept,
            RouteAfterBlameResolve,
            str => str
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithCondition(1, () => vars.Buy == 1)
                .FormatWithIndex(2, bonusIdx));
    }

    private static void RouteAfterBlameResolve(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Late == 2)
        {
            TimeTravel3Setup(globalData);
        }
        else if (vars.Late == 1)
        {
            BlameOut1(globalData);
        }
        else
        {
            BlameOut2(globalData);
        }
    }

    private static void BlameOut1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithReplacement(0, vars.Blame));
        globalData.ActiveWindow.AddClickHereToContinue(BlameOut1_0);
    }

    private static void BlameOut1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.DiscardEstateUpgrade_Icon,
            PopUpButton.Accept,
            TimeTravel3Setup,
            str => str.FormatWithReplacement(0, vars.Blame));
    }

    private static void BlameOut2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BlameOut2_0);
    }

    private static void BlameOut2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        List<string> lines = new();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            string pName = vars.GetDisplayPlayerName(globalData, i);
            if (vars.SilentVoted[i])
            {
                lines.Add($"{pName} must discard 1 Resource and 1 Servant into Lost.");
            }
            else
            {
                lines.Add($"{pName} must discard 2 Resources and 1 Servant into Lost.");
            }
        }

        string summary = string.Join("<br /><br />", lines);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Servant,
            PopUpButton.Accept,
            TimeTravel3Setup,
            str => str.FormatWithReplacement(0, summary));
    }

    private static void TimeTravel3Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.Barracks == "no" && vars.Pg14 == 0)
        {
            vars.Pg14 = 1;
            globalData.ActivePopup = new GameplayPopup(
                globalData,
                PopUpTitle.Setup,
                PopUpIcon.VillageChronicleCover,
                PopUpButton.Accept,
                TimeTravel);
        }
        else
        {
            TimeTravel(globalData);
        }
    }

    private static void TimeTravel3_EndGen(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Late == 2)
        {
            BlameOut3(globalData);
        }
        else
        {
            SecretParadoxBonus(globalData);
        }
    }

    private static void BlameOut3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(SecretParadoxBonus);
    }

    private static void SecretParadoxBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.ParaSecret = Random.Shared.Next(2) + 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithCondition(0, () => vars.ParaSecret == 1));
        globalData.ActiveWindow.AddClickHereToContinue(SecretParadoxBonus_0);
    }

    private static void SecretParadoxBonus_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ParadoxToken,
            PopUpButton.Accept,
            TTBarracksPenalty);
    }

    private static void TTBarracksPenalty(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.Barracks == "no")
        {
            globalData.ActiveWindow = new GameplayWindow(globalData);
            globalData.ActiveWindow.AddDefaultTitle();
            globalData.ActiveWindow.AddDefaultContent();
            globalData.ActiveWindow.AddClickHereToContinue(RouteToTimeEnd);
        }
        else
        {
            RouteToTimeEnd(globalData);
        }
    }

    private static void RouteToTimeEnd(GlobalData globalData)
    {
        if (Random.Shared.Next(2) == 0)
        {
            TimeEnd1(globalData);
        }
        else
        {
            TimeEnd2(globalData);
        }
    }

    private static void TimeEnd1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            TimeEnd1_Window);
    }

    private static void TimeEnd1_Window(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Dox = globalData.PlayersNum switch
        {
            2 => Random.Shared.Next(3) + 1,
            3 => Random.Shared.Next(3) + 2,
            _ => Random.Shared.Next(3) + 3
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(
            1,
            true,
            str => str.FormatWithReplacement(0, vars.Dox.ToString()),
            WarningIntro);
        globalData.ActiveWindow.AddNextContent(
            2,
            true,
            str => str.FormatWithReplacement(0, vars.Dox.ToString()),
            Paradoxical);
    }

    private static void TimeEnd2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            TimeEnd2_Window);
    }

    private static void TimeEnd2_Window(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(
            str => str.FormatWithCondition(0, () => vars.TmRepair == "yes"));
        globalData.ActiveWindow.AddDefaultContent(
            str => str.FormatWithCondition(0, () => vars.TmRepair == "yes"));

        if (vars.TmRepair == "yes")
        {
            globalData.ActiveWindow.AddClickHereToContinue(Paradoxical);
        }
        else
        {
            globalData.ActiveWindow.AddNextContent(
                1,
                true,
                null,
                gd =>
                {
                    gd.ATimeOfWarVars.TmNumber = "zero pieces";
                    TimeEnd2b(gd);
                });
            globalData.ActiveWindow.AddNextContent(
                2,
                true,
                null,
                gd =>
                {
                    gd.ATimeOfWarVars.TmNumber = "one piece";
                    TimeEnd2b(gd);
                });
            globalData.ActiveWindow.AddNextContent(
                3,
                true,
                null,
                gd =>
                {
                    gd.ATimeOfWarVars.TmNumber = "two pieces";
                    TimeEnd2b(gd);
                });
        }
    }

    private static void TimeEnd2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            str => str
                .FormatWithReplacement(0, vars.TmNumber)
                .FormatWithCondition(1, () => vars.TmNumber == "zero pieces"));
        globalData.ActiveWindow.AddClickHereToContinue(WarningIntro);
    }
}
