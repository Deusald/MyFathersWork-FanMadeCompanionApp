namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    #region Intro & Setup

    internal static void IntroMartial_Monarchists(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Generation           = Generation.Second;
        globalData.Years                = Years.Early;
        globalData.ATimeOfWarVars.Iou   = 0;
        globalData.ATimeOfWarVars.Round = 7;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GUNSAward);
    }

    internal static void IntroMartial_Separatists(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Generation              = Generation.Second;
        globalData.Years                   = Years.Early;
        globalData.ATimeOfWarVars.Iou      = 0;
        globalData.ATimeOfWarVars.SepEvent = Random.Shared.Next(2) + 1;
        globalData.ATimeOfWarVars.Round    = 7;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GUNSAward);
    }

    private static void GUNSAward(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GUNSAward_0);
    }

    private static void GUNSAward_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Gen3Pg       = 0;
        vars.Martial      = 0;
        vars.Bldg1        = "0";
        vars.WarDestroy   = 0;
        vars.RoyalAdvisor = 0;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_WeaponToken,
            PopUpButton.Confirm,
            AdvancedWeaponryIntro,
            content => content
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser));
    }

    private static void AdvancedWeaponryIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.SepInc1      = Random.Shared.Next(2);
        vars.SepInc2      = Random.Shared.Next(2);
        vars.SepInc3      = Random.Shared.Next(2);
        vars.MonInc3      = Random.Shared.Next(2);
        vars.WarDetermine = Random.Shared.Next(2) + 1;
        vars.Defense      = globalData.PlayersNum + Random.Shared.Next(3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(AdvancedWeaponryIntro_0);
    }

    private static void AdvancedWeaponryIntro_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_AdvancedWeaponry,
            PopUpButton.Confirm,
            Martial1_Setup);
    }

    private static void Martial1_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Martial == 0)
        {
            vars.Martial = 1;
            if (vars.WarWinner == "Unified Monarchists")
            {
                vars.Tracker += 1;
            }
            else
            {
                vars.Tracker -= Random.Shared.Next(2);
            }
        }

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Accept,
            Martial,
            content => content
                .FormatWithReplacement(0, vars.Tracker.ToString())
                .FormatWithCondition(1, () => globalData.PlayersNum == 3));
    }

    #endregion

    #region Hub: Martial (Early, Middle, Late Years)

    public static void Martial(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.Martial;
        vars.Round = globalData.Years switch
        {
            Years.Early  => 7,
            Years.Middle => 8,
            _            => 9
        };
        if (globalData.Years is Years.Middle or Years.Late)
        {
            vars.Sabotagee1 = "none";
        }

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        const string       turnTheTideSection = "TurnTheTide";
        GameplayHubSection turnTheTide        = globalData.ActiveHub.AddSection(turnTheTideSection, true);
        turnTheTide.AddDefaultContent(
            turnTheTideSection,
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithCondition(1, () => vars.WarLoser == "Separatists"));

        const string       weaponsBonusSection = "WeaponsBonus";
        GameplayHubSection weaponsBonus        = globalData.ActiveHub.AddSection(weaponsBonusSection);
        weaponsBonus.ReplaceShouldShow(() => vars.MartWeapons == 0);
        weaponsBonus.AddDefaultContent(weaponsBonusSection);
        weaponsBonus.AddSpecialClickHere(weaponsBonusSection, PackingHeat1);

        const string       militaryDemandsSection = "MilitaryDemands";
        GameplayHubSection militaryDemands        = globalData.ActiveHub.AddSection(militaryDemandsSection);
        militaryDemands.ReplaceShouldShow(() => vars.WarWinner == "Unified Monarchists" && vars.Bldg1 != "Barracks");
        militaryDemands.AddDefaultContent(
            militaryDemandsSection,
            content => content.FormatWithCondition(0, () => globalData.Years == Years.Late && vars.MonInc3 == 1));

        const string       militaryIncentiveSection = "MilitaryIncentive";
        GameplayHubSection militaryIncentive        = globalData.ActiveHub.AddSection(militaryIncentiveSection);
        militaryIncentive.ReplaceShouldShow(() => vars.WarWinner == "Separatists" && vars.Bldg1 != "Barracks");
        int sepIncentiveIndex = globalData.Years switch
        {
            Years.Early  => vars.SepInc1,
            Years.Middle => 2 + vars.SepInc2,
            _            => 4 + vars.SepInc3
        };
        militaryIncentive.AddDefaultContent(
            militaryIncentiveSection,
            content => content.FormatWithIndex(0, sepIncentiveIndex));

        const string       everythingWeaponSection = "EverythingIsAWeapon";
        GameplayHubSection everythingWeapon        = globalData.ActiveHub.AddSection(everythingWeaponSection);
        everythingWeapon.ReplaceShouldShow(() => globalData.Years == Years.Late && vars.Bribe == "yes");
        everythingWeapon.AddDefaultContent(everythingWeaponSection);

        const string       outpostSection = "Outpost";
        GameplayHubSection outpost        = globalData.ActiveHub.AddSection(outpostSection);
        outpost.ReplaceShouldShow(() => globalData.Years != Years.Late || vars.WarDestroy < 2);
        outpost.AddDefaultContent(outpostSection);
        outpost.AddSpecialClickHere(outpostSection, OutpostExplain);

        GameplayHubSection nextRound = globalData.ActiveHub.AddSection(string.Empty);
        nextRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        nextRound.AddClickHereContinueNextRound(Martial_NextRound);

        globalData.ActiveHub.AddEndOfGenerationSection(BarracksSimple3);
    }

    private static void Martial_NextRound(GlobalData globalData)
    {
        if (globalData.Years == Years.Early)
        {
            Martial1Delay(globalData);
        }
        else
        {
            Martial2Delay(globalData);
        }
    }

    #endregion

    #region Hub Actions: PackingHeat1 & OutpostExplain

    private static void PackingHeat1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1, true);
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.ATimeOfWarVars.HeatPlayer = playerName;
            PackingHeat1a(globalData);
        });
    }

    private static void PackingHeat1a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser));
        globalData.ActiveWindow.AddClickHereToContinue(PackingHeat1a_0);
    }

    private static void PackingHeat1a_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.MartWeapons = 1;
        vars.Martial     = vars.Round switch
        {
            7 => 1,
            8 => 2,
            _ => 3
        };
        int rewardVariant = Random.Shared.Next(2);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Martial,
            content => content
                .FormatWithReplacement(0, vars.HeatPlayer)
                .FormatWithReplacement(1, vars.WarLoser)
                .FormatWithIndex(2, rewardVariant));
    }

    private static void OutpostExplain(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Martial);
    }

    #endregion

    #region Round End Delays & Sabotage Flow

    private static void Martial1Delay(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ScenarioIcon,
            PopUpButton.Confirm,
            ATOWSabotageIntro1);
    }

    private static void Martial2Delay(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        Action<GlobalData> nextPassage = vars.WarWinner == "Unified Monarchists"
            ? (vars.Rumor2Visited ? AMessenger2 : AfternoonTea)
            : (vars.WarDestroy == 1 ? ATOWSabotageIntro2Sep : ATOWSabotageIntro2);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ScenarioIcon,
            PopUpButton.Confirm,
            nextPassage,
            "Martial1Delay_Content");
    }

    private static void ATOWSabotageIntro1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Sabotagee1 = "none";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddOnceYouAreReady(ATOWSabotageIntro1_0);
    }

    private static void ATOWSabotageIntro1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.WarLoser));

        List<Action<GlobalData>?> callbacks = globalData.PlayersNum > 2
            ? [ATOWSabotage1, SabotageSignIn1, ATOWSabotageNO]
            : [ATOWSabotage1, ATOWSabotageNO];

        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            callbacks,
            true,
            content => content.FormatWithCondition(0, () => globalData.PlayersNum > 2));
    }

    private static void ATOWSabotageIntro2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Sabotagee1 = "none";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddOnceYouAreReady(ATOWSabotageIntro2_0);
    }

    private static void ATOWSabotageIntro2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.WarLoser));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [ATOWSabotage1, SabotageSignIn1, ATOWSabotageNO],
            true);
    }

    private static void ATOWSabotageIntro2Sep(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Sabotagee1 = "none";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddOnceYouAreReady(ATOWSabotageIntro2Sep_0);
    }

    private static void ATOWSabotageIntro2Sep_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.WarLoser));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [ATOWSabotageIntro2Sep_Outpost, SabotageSignIn1, ATOWSabotageNO],
            true);
    }

    private static void ATOWSabotageIntro2Sep_Outpost(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Bldg2   = "Outpost";
        vars.SabPage = vars.Bldg1 == "Barracks" ? 8 : 7;
        ATOWSabotageMonConfirm(globalData);
    }

    private static void ATOWSabotage1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [ATOWSabotage1_Barracks, ATOWSabotage1_Laborers],
            true);
    }

    private static void ATOWSabotage1_Barracks(GlobalData globalData)
    {
        globalData.ATimeOfWarVars.Bldg1   = "Barracks";
        globalData.ATimeOfWarVars.SabPage = 5;
        ATOWSabotageConfirm(globalData);
    }

    private static void ATOWSabotage1_Laborers(GlobalData globalData)
    {
        globalData.ATimeOfWarVars.Bldg1   = "Laborer's Union";
        globalData.ATimeOfWarVars.SabPage = 6;
        ATOWSabotageConfirm(globalData);
    }

    private static void ATOWSabotageConfirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.WarDestroy = 1;
        if (vars.Round != 7)
        {
            vars.WarPage2 = 1;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithReplacement(1, vars.Bldg1)
                .FormatWithReplacement(2, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(vars.Round == 7 ? AMessenger : ResistEvent);
    }

    private static void ATOWSabotageMonConfirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.WarDestroy = 2;
        vars.WarPage2   = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithReplacement(1, vars.Bldg2)
                .FormatWithReplacement(2, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(ResistEvent);
    }

    private static void SabotageSignIn1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.ATimeOfWarVars.PlayerSabotage1 = playerName;
            SabotagePlayerChoice1(globalData);
        });
    }

    private static void SabotagePlayerChoice1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(
            targetName =>
            {
                globalData.ATimeOfWarVars.Sabotagee1 = targetName;
                SabotagePlayerConfirmed(globalData);
            },
            PlayerFormatterTag.None,
            player => player != vars.PlayerSabotage1);
        globalData.ActiveWindow.AddNextContentWithLinks(1, [ATOWSabotageNO], true);
    }

    private static void SabotagePlayerConfirmed(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Sabotagee1));
        globalData.ActiveWindow.AddClickHereToContinue(vars.Round == 7 ? AMessenger : ResistEvent);
    }

    private static void ATOWSabotageNO(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ATOWSabotageNO_0);
    }

    private static void ATOWSabotageNO_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.CompulsionBack,
            PopUpButton.Confirm,
            vars.Round == 7 ? AMessenger : ResistEvent);
    }

    #endregion

    #region Messenger Events (Early & Middle Years)

    private static void AMessenger(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (!vars.Rumor1Visited)
        {
            if (vars.WarWinner == "Unified Monarchists")
            {
                BarracksSimple1(globalData);
            }
            else
            {
                Sabotage1Now(globalData);
            }
            return;
        }

        globalData.SaveToUndo();
        bool monIsYes = (vars.WarWinner == "Separatists" && vars.TakeReact == "1") ||
                        (vars.WarWinner != "Separatists" && vars.TakeReact != "1");

        Action<GlobalData> monCallback = monIsYes ? Amessyes : Amessno;
        Action<GlobalData> sepCallback = monIsYes ? Amessno : Amessyes;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Crest));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [monCallback, sepCallback],
            true);
    }

    private static void Amessyes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Crest));
        globalData.ActiveWindow.AddOnceYouAreReady(Amessyes_0);
    }

    private static void Amessyes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(Amessyes2);
    }

    private static void Amessyes2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Barn = "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Amessyes2_0);
    }

    private static void Amessyes2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_EstateUpgradeBack,
            PopUpButton.Confirm,
            vars.WarWinner == "Unified Monarchists" ? BarracksSimple1 : Sabotage1Now,
            content => content.FormatWithReplacement(0, vars.Crest));
    }

    private static void Amessno(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Amessno_0);
    }

    private static void Amessno_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            vars.WarWinner == "Unified Monarchists" ? BarracksSimple1 : Sabotage1Now,
            content => content.FormatWithReplacement(0, vars.Crest));
    }

    private static void AMessenger2(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.WarWinner != "Unified Monarchists")
        {
            if (vars.WarDestroy == 1)
            {
                ATOWSabotageIntro2Sep(globalData);
            }
            else
            {
                ATOWSabotageIntro2(globalData);
            }
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Figure));
        globalData.ActiveWindow.AddOnceYouAreReady(AMessenger2_0);
    }

    private static void AMessenger2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        bool monIsYes = vars.TakeReact == "1";

        Action<GlobalData> monCallback = monIsYes ? AMessYes2b : AMessno2;
        Action<GlobalData> sepCallback = monIsYes ? AMessno2 : AMessYes2b;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [monCallback, sepCallback],
            true);
    }

    private static void AMessYes2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Iou = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarDetermine.ToString())
                .FormatWithReplacement(1, vars.WarLoser));
        globalData.ActiveWindow.AddClickHereToContinue(AMessYes2b_0);
    }

    private static void AMessYes2b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            AfternoonTea,
            content => content.FormatWithReplacement(0, vars.Figure));
    }

    private static void AMessno2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(AMessno2_0);
    }

    private static void AMessno2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ExperimentABack,
            PopUpButton.Confirm,
            AfternoonTea,
            content => content.FormatWithReplacement(0, vars.Figure));
    }

    #endregion

    #region Afternoon Tea (Middle Years - Monarchists)

    private static void AfternoonTea(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.TeaOpt = (vars.Bldg1 == "0" || string.IsNullOrEmpty(vars.Bldg1)) ? "Barracks" : "Outpost";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.TeaOpt));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.PlayersNum == 2 ? TwoPAfternoonBid : AfternoonTeab);
    }

    private static void AfternoonTeab(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.TeaOpt));
        globalData.ActiveWindow.AddClickHereToContinue(AfternoonTeaRes);
    }

    private static void TwoPAfternoonBid(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.TeaOpt));
        globalData.ActiveWindow.AddClickHereAfterBid(TwoPAfternoonBidRes);
    }

    private static void AfternoonTeaRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.TeaOpt));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [AfternoonTeaResolutionYAY, AfternoonTeaResolutionNAY],
            true,
            content => content.FormatWithReplacement(0, vars.TeaOpt));
    }

    private static void TwoPAfternoonBidRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [AfternoonTeaResolutionYAY, AfternoonTeaResolutionNAY],
            true,
            content => content.FormatWithReplacement(0, vars.TeaOpt));
    }

    private static void AfternoonTeaResolutionYAY(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.TeaOpt == "Outpost")
        {
            vars.WarDestroy = 2;
            vars.SabPage    = 8;
        }
        else
        {
            vars.WarDestroy = 1;
            vars.SabPage    = 5;
            vars.Bldg1      = "Barracks";
        }
        vars.WarPage2 = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.TeaOpt)
                .FormatWithCondition(1, () => vars.TeaOpt == "Barracks"));
        globalData.ActiveWindow.AddClickHereToContinue(AfternoonTeaResolutionYAY_0);
    }

    private static void AfternoonTeaResolutionYAY_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Confirm,
            MartialPre3,
            content => content
                .FormatWithCondition(0, () => globalData.PlayersNum < 4)
                .FormatWithCondition(1, () => globalData.PlayersNum > 2));
    }

    private static void AfternoonTeaResolutionNAY(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithCondition(0, () => globalData.PlayersNum > 2));
        globalData.ActiveWindow.AddClickHereToContinue(AfternoonTeaResolutionNAY_0);
    }

    private static void AfternoonTeaResolutionNAY_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_AdvancedWeaponry,
            PopUpButton.Confirm,
            BarracksSimple2,
            content => content.FormatWithCondition(0, () => globalData.PlayersNum > 2));
    }

    #endregion

    #region Quartering Troops & Separatist Bribe Events

    private static void ResistEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(ResistEvent_0);
    }

    private static void ResistEvent_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Money_Icon,
            PopUpButton.Confirm,
            vars.Quarter == "yes" ? ResistEvent1 : ResistEvent2);
    }

    private static void ResistEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ResistEvent1_0);
    }

    private static void ResistEvent1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int vp = Random.Shared.Next(1, 4);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_EstateUpgradeBack,
            PopUpButton.Confirm,
            vars.WarWinner == "Separatists" ? MartialSepEvent : BarracksSimple2,
            content => content.FormatWithReplacement(0, vp.ToString()));
    }

    private static void ResistEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ResistEvent2_0);
    }

    private static void ResistEvent2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int vp = Random.Shared.Next(1, 5);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            vars.WarWinner == "Separatists" ? MartialSepEvent : BarracksSimple2,
            content => content.FormatWithReplacement(0, vp.ToString()));
    }

    private static void MartialSepEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(MartialSepEventa);
    }

    private static void MartialSepEventa(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Military = globalData.PlayersNum switch
        {
            2 => Random.Shared.Next(0, 3) + 1,
            3 => Random.Shared.Next(0, 5) + 2,
            4 => Random.Shared.Next(1, 5) + 2,
            _ => Random.Shared.Next(1, 6) + 2
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Military.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(MartialSepEventb);
    }

    private static void MartialSepEventb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.Military.ToString()));
        globalData.ActiveWindow.AddYesNo(MartialSepEventYes, MartialSepEventNo);
    }

    private static void MartialSepEventYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Bribe = "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(MartialSepEventYes_0);
    }

    private static void MartialSepEventYes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            Sabotage1Now,
            content => content.FormatWithCondition(0, () => vars.SepEvent == 2));
    }

    private static void MartialSepEventNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Bribe = "no";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(MartialSepEventNo_0);
    }

    private static void MartialSepEventNo_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.CompulsionBack,
            PopUpButton.Confirm,
            Sabotage1Now);
    }

    #endregion

    #region Barracks Enforcement (Early, Middle, Late Years)

    private static bool ShouldShowBarracksPenalty(ATimeOfWarVars vars)
    {
        return vars.WarWinner == "Unified Monarchists" &&
               (vars.Bldg1 == "Laborer's Union" || vars.Bldg1 == "0" || string.IsNullOrEmpty(vars.Bldg1));
    }

    private static void BarracksSimple1(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (!ShouldShowBarracksPenalty(vars))
        {
            Sabotage1Now(globalData);
            return;
        }

        globalData.SaveToUndo();
        vars.BarrackPen = Random.Shared.Next(1, 6);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BarracksSimple1_0);
    }

    private static void BarracksSimple1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int penIndex = GetBarrackPenaltyFormatIndex(globalData.ATimeOfWarVars.BarrackPen);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.BuildingS3Barracks,
            PopUpButton.Confirm,
            Sabotage1Now,
            "BarracksSimple_0_Content",
            content => content.FormatWithIndex(0, penIndex));
    }

    private static void BarracksSimple2(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (!ShouldShowBarracksPenalty(vars))
        {
            Sabotage1Now(globalData);
            return;
        }

        globalData.SaveToUndo();
        vars.BarrackPen = Random.Shared.Next(1, 6);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BarracksSimple2_0);
    }

    private static void BarracksSimple2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int penIndex = GetBarrackPenaltyFormatIndex(globalData.ATimeOfWarVars.BarrackPen);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.BuildingS3Barracks,
            PopUpButton.Confirm,
            Sabotage1Now,
            "BarracksSimple_0_Content",
            content => content.FormatWithIndex(0, penIndex));
    }

    private static void BarracksSimple3(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (!ShouldShowBarracksPenalty(vars))
        {
            ResistSides(globalData);
            return;
        }

        globalData.SaveToUndo();
        vars.BarrackPen = Random.Shared.Next(1, 6);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BarracksSimple3_0);
    }

    private static void BarracksSimple3_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int penIndex = GetBarrackPenaltyFormatIndex(globalData.ATimeOfWarVars.BarrackPen);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.BuildingS3Barracks,
            PopUpButton.Confirm,
            ResistSides,
            "BarracksSimple_0_Content",
            content => content.FormatWithIndex(0, penIndex));
    }

    private static int GetBarrackPenaltyFormatIndex(int barrackPen)
    {
        return barrackPen switch
        {
            1 => Random.Shared.Next(2),
            2 => 2,
            3 => 3 + Random.Shared.Next(2),
            4 => 5,
            _ => 6
        };
    }

    #endregion

    #region Sabotage Resolution & Duels

    private static void Sabotage1Now(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Sabotagee1 == "none" || string.IsNullOrEmpty(vars.Sabotagee1))
        {
            if (vars.Round == 7)
            {
                Martia1Pre2(globalData);
            }
            else
            {
                MartialPre3(globalData);
            }
            return;
        }

        globalData.SaveToUndo();
        int flavorIndex = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithIndex(0, flavorIndex));
        globalData.ActiveWindow.AddClickHereToContinue(Sabotage1Now_0);
    }

    private static void Sabotage1Now_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int penaltyVariant = Random.Shared.Next(2);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            Player1BeenSabotaged,
            content => content
                .FormatWithReplacement(0, vars.Sabotagee1)
                .FormatWithIndex(1, penaltyVariant));
    }

    private static void Player1BeenSabotaged(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.Sabotagee1, Player1BeenSabotaged_0);
    }

    private static void Player1BeenSabotaged_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.PlayerSabotage1));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [DuelRules1, DuelDenounce1],
            true);
    }

    private static void DuelRules1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [DuelRules1_Science, DuelRules1_Pistols, DuelDenounce1],
            true);
    }

    private static void DuelRules1_Science(GlobalData globalData)
    {
        globalData.ATimeOfWarVars.DuelType = "science";
        AcceptDuel1(globalData);
    }

    private static void DuelRules1_Pistols(GlobalData globalData)
    {
        globalData.ATimeOfWarVars.DuelType = "pistols";
        AcceptDuel1(globalData);
    }

    private static void DuelDenounce1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, vars.PlayerSabotage1));
        globalData.ActiveWindow.AddClickHereToContinue(DuelDenounce1_0);
    }

    private static void DuelDenounce1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            vars.Round == 7 ? Martia1Pre2 : MartialPre3,
            content => content.FormatWithReplacement(0, vars.PlayerSabotage1));
    }

    private static void AcceptDuel1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.PlayerSabotage1, AcceptDuel1_0);
    }

    private static void AcceptDuel1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.DuelType)
                .FormatWithCondition(1, () => vars.DuelType == "science"));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [AcceptDuel1b, DuelDecline1],
            true);
    }

    private static void DuelDecline1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DuelDecline1_0);
    }

    private static void DuelDecline1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            vars.Round == 7 ? Martia1Pre2 : MartialPre3,
            content => content.FormatWithReplacement(0, vars.PlayerSabotage1));
    }

    private static void AcceptDuel1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int variant = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithIndex(0, variant));
        globalData.ActiveWindow.AddClickHereToContinue(DuelResolution1);
    }

    private static void DuelResolution1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.DuelType == "science")
        {
            vars.DuelSci = Random.Shared.Next(4);
        }
        else
        {
            vars.DuelShot = Random.Shared.Next(1, 6);
            if (vars.DuelShot < 3)
            {
                vars.DuelWinner = vars.Sabotagee1;
                vars.DuelLoser  = vars.PlayerSabotage1;
            }
            else
            {
                vars.DuelWinner = vars.PlayerSabotage1;
                vars.DuelLoser  = vars.Sabotagee1;
            }
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithCondition(0, () => vars.DuelType == "science"));
        globalData.ActiveWindow.AddClickHereToContinue(DuelResolution1a);
    }

    private static void DuelResolution1a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string sciName = GetDuelScienceName(vars.DuelSci);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        if (vars.DuelType == "science")
        {
            globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithReplacement(0, sciName));
            globalData.ActiveWindow.AddDefaultContent(
                content => content
                    .FormatWithReplacement(0, sciName)
                    .FormatWithCondition(1, () => true));
            globalData.ActiveWindow.AddClickHereToContinue(DuelResolution1a_SciSetup);
        }
        else
        {
            globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithReplacement(0, "The Moment of Truth"));
            globalData.ActiveWindow.AddDefaultContent(
                content => content
                    .FormatWithReplacement(0, sciName)
                    .FormatWithCondition(1, () => false));
            globalData.ActiveWindow.AddClickHereToContinue(DuelResolution1b);
        }
    }

    private static void DuelResolution1a_SciSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string sciName = GetDuelScienceName(vars.DuelSci);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AdvanceJournalTrack,
            PopUpButton.Confirm,
            DuelResolution1sci,
            content => content
                .FormatWithReplacement(0, vars.Sabotagee1)
                .FormatWithReplacement(1, vars.PlayerSabotage1)
                .FormatWithReplacement(2, sciName));
    }

    private static void DuelResolution1sci(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string sciName = GetDuelScienceName(vars.DuelSci);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, sciName));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [DuelResolution1sci_SabotageeWins, DuelResolution1sci_SaboteurWins, DuelResolution1sci_Tied],
            true,
            content => content
                .FormatWithReplacement(0, vars.Sabotagee1)
                .FormatWithReplacement(1, vars.PlayerSabotage1));
    }

    private static void DuelResolution1sci_SabotageeWins(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.DuelWinner = vars.Sabotagee1;
        vars.DuelLoser  = vars.PlayerSabotage1;
        DuelResolution1b(globalData);
    }

    private static void DuelResolution1sci_SaboteurWins(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.DuelWinner = vars.PlayerSabotage1;
        vars.DuelLoser  = vars.Sabotagee1;
        DuelResolution1b(globalData);
    }

    private static void DuelResolution1sci_Tied(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.DuelWinner = "tied";
        vars.DuelLoser  = "tied";
        ScienceDuelTiedRes(globalData);
    }

    private static void ScienceDuelTiedRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string sciName = GetDuelScienceName(vars.DuelSci);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithReplacement(0, sciName));
        globalData.ActiveWindow.AddClickHereToContinue(ScienceDuelTiedRes_0);
    }

    private static void ScienceDuelTiedRes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            vars.Round == 7 ? Martia1Pre2 : MartialPre3,
            content => content
                .FormatWithReplacement(0, vars.Sabotagee1)
                .FormatWithReplacement(1, vars.PlayerSabotage1));
    }

    private static void DuelResolution1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.DuelResult = Random.Shared.Next(1, 6);
        int flavorIndex = vars.DuelType == "science" ? vars.DuelSci : 4;
        bool isDeath = vars.DuelResult == 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithCondition(0, () => isDeath));
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.DuelLoser)
                .FormatWithCondition(1, () => isDeath)
                .FormatWithIndex(2, flavorIndex));
        globalData.ActiveWindow.AddClickHereToContinue(isDeath ? DuelResolution1b_DeathSetup : DuelResolution1b_WoundSetup);
    }

    private static void DuelResolution1b_DeathSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Bodies_Icon,
            PopUpButton.Confirm,
            vars.Round == 7 ? Martia1Pre2 : MartialPre3,
            content => content
                .FormatWithReplacement(0, vars.DuelLoser)
                .FormatWithCondition(1, () => vars.Round == 7));
    }

    private static void DuelResolution1b_WoundSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            vars.Round == 7 ? Martia1Pre2 : MartialPre3,
            content => content.FormatWithReplacement(0, vars.DuelLoser));
    }

    private static string GetDuelScienceName(int duelSci)
    {
        return duelSci switch
        {
            0 => "Engineering",
            1 => "Chemistry",
            2 => "Biology",
            _ => "Occult"
        };
    }

    #endregion

    #region Round Transitions (Martia1Pre2 & MartialPre3)

    private static void Martia1Pre2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Sabotagee1 = "none";
        globalData.ShowEndOfRoundPopUp(Martial2_Entry);
    }

    private static void Martial2_Entry(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Martial <= 1 && vars.WarDestroy == 1)
        {
            Martial2_BuildingDestroyedSetup(globalData);
            return;
        }
        Martial(globalData);
    }

    private static void Martial2_BuildingDestroyedSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Martial = 2;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            Martial,
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithReplacement(1, vars.SabPage.ToString()));
    }

    private static void MartialPre3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Sabotagee1 = "none";
        globalData.ShowEndOfRoundPopUp(Martial3_Entry);
    }

    private static void Martial3_Entry(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Martial <= 2 && vars.WarPage2 == 1)
        {
            Martial3_BuildingDestroyedSetup(globalData);
            return;
        }
        Martial(globalData);
    }

    private static void Martial3_BuildingDestroyedSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Martial = 3;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            Martial,
            "Martial2_BuildingDestroyedSetup_Content",
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithReplacement(1, vars.SabPage.ToString()));
    }

    #endregion

    #region End of Generation 2 (ResistSides, ResistEnd, ResistEnd2, ResistEnd3)

    private static void ResistSides(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int reqIndex = Random.Shared.Next(2);

        Action<GlobalData> nextPassage;
        if (vars.Iou == 1)
        {
            nextPassage = ResistEnd;
        }
        else
        {
            int choice = Random.Shared.Next(3);
            nextPassage = choice switch
            {
                0 => ResistEnd,
                1 => ResistEnd2,
                _ => ResistEnd3
            };
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithIndex(0, reqIndex));
        globalData.ActiveWindow.AddClickHereToContinue(nextPassage);
    }

    private static void ResistEnd(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        bool resistanceWon = vars.WarDestroy >= vars.WarDetermine;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithCondition(0, () => resistanceWon));
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarDestroy.ToString())
                .FormatWithReplacement(1, vars.WarLoser)
                .FormatWithReplacement(2, vars.WarWinner)
                .FormatWithCondition(3, () => resistanceWon));

        Action<GlobalData> nextCallback = resistanceWon
            ? (vars.WarWinner == "Unified Monarchists" ? Martial_TransitionToPeace : Martial_TransitionToMonarchReign)
            : (vars.WarWinner == "Unified Monarchists" ? Martial_TransitionToMonarchReign : Martial_TransitionToPeace);

        globalData.ActiveWindow.AddClickHereToContinue(nextCallback);
    }

    private static void ResistEnd2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        Action<GlobalData> winnerOptionCallback = vars.WarWinner == "Unified Monarchists"
            ? Martial_TransitionToMonarchReign
            : Martial_TransitionToPeace;
        Action<GlobalData> loserOptionCallback = vars.WarWinner == "Unified Monarchists"
            ? Martial_TransitionToPeace
            : Martial_TransitionToMonarchReign;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [winnerOptionCallback, loserOptionCallback],
            true,
            content => content
                .FormatWithReplacement(0, vars.WarWinner)
                .FormatWithReplacement(1, vars.WarLoser));
    }

    private static void ResistEnd3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        Action<GlobalData> loserSuccessCallback = vars.WarWinner == "Unified Monarchists"
            ? Martial_TransitionToPeace
            : Martial_TransitionToMonarchReign;
        Action<GlobalData> winnerDefendedCallback = vars.WarWinner == "Unified Monarchists"
            ? Martial_TransitionToMonarchReign
            : Martial_TransitionToPeace;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithReplacement(1, vars.Defense.ToString())
                .FormatWithReplacement(2, vars.WarWinner));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [loserSuccessCallback, winnerDefendedCallback],
            true,
            content => content
                .FormatWithReplacement(0, vars.WarLoser)
                .FormatWithReplacement(1, vars.WarWinner));
    }

    private static void Martial_TransitionToMonarchReign(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.WarWinner != "Unified Monarchists")
        {
            vars.EndChange = "yes";
        }
        vars.WarWinner = "Unified Monarchists";
        vars.WarLoser  = "Separatists";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.S3_ScenarioIcon,
            PopUpButton.Confirm,
            gd =>
            {
                gd.Years      = Years.Early;
                gd.Generation = Generation.Third;
                gd.ActiveHub  = null;
                MonarchReignIntro(gd);
            },
            "Martial_EndOfGen_Content");
    }

    private static void Martial_TransitionToPeace(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.WarWinner != "Separatists")
        {
            vars.EndChange = "yes";
        }
        vars.WarWinner = "Separatists";
        vars.WarLoser  = "Unified Monarchists";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.S3_ScenarioIcon,
            PopUpButton.Confirm,
            gd =>
            {
                gd.Years      = Years.Early;
                gd.Generation = Generation.Third;
                gd.ActiveHub  = null;
                PeaceIntro(gd);
            },
            "Martial_EndOfGen_Content");
    }

    #endregion
}
