namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    internal static void PeaceIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.Generation = Generation.Third;
        globalData.Years = Years.Early;
        vars.WeaponLimit = Random.Shared.Next(4, 6);
        if (vars.WarLoser == "Separatists")
        {
            vars.EndChange = "yes";
        }
        vars.Pea1 = 0;
        vars.Pea2 = 0;
        vars.Pea3 = 0;
        vars.Peac = 1;
        vars.PeaceCount = 0;

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultSubtitle();
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(SeparatistBarnCheck);
    }

    private static void SeparatistBarnCheck(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.WarLoser == "Separatists" && vars.Barn == "yes")
        {
            GameplayWindow window = new GameplayWindow(globalData);
            window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
            window.AddDefaultSubtitle();
            window.AddDefaultTitle();
            window.AddDefaultContent();
            window.AddNextButton(SeparatistBarnCheck_0);
        }
        else
        {
            PeaceWar(globalData);
        }
    }

    private static void SeparatistBarnCheck_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_EstateUpgradeBack,
            PopUpButton.Confirm,
            () => PeaceWar(globalData)
        );
    }

    private static void PeaceWar(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultSubtitle();
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(PeaceWar_0);
    }

    private static void PeaceWar_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_WorldConquest,
            PopUpButton.Confirm,
            () => PeacePrep(globalData)
        );
    }

    private static void PeacePrep(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultSubtitle();
        window.AddDefaultTitle();
        window.AddDefaultContent(text => text
            .FormatWithCondition(0, () => vars.Bribe == "yes"));
        window.AddNextButton(PeacePrep_0);
    }

    private static void PeacePrep_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_WeaponToken,
            PopUpButton.Confirm,
            () => PeacetoRebuild(globalData),
            text => text.FormatWithCondition(0, () => vars.Bribe == "yes")
        );
    }

    private static void PeacetoRebuild(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        int rebuildIdx = vars.WarDestroy switch
        {
            0 => 0,
            1 => 1,
            _ => 2
        };

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultSubtitle();
        window.AddDefaultTitle();
        window.AddDefaultContent(text => text
            .FormatWithIndex(0, rebuildIdx));
        window.AddNextButton(PeaceDiscard);
    }

    private static void PeaceDiscard(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultSubtitle();
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(PeaceDiscard_0);
    }

    private static void PeaceDiscard_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_WeaponToken,
            PopUpButton.Confirm,
            () => PeaceDiscard_1(globalData),
            text => text.FormatWithReplacement(0, vars.WeaponLimit.ToString())
        );
    }

    private static void PeaceDiscard_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Confirm,
            () => HowtoWar(globalData)
        );
    }

    internal static void HowtoWar(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(Peace);
    }

    public static void Peace(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.Peace;

        vars.Round = globalData.Years switch
        {
            Years.Early => 19,
            Years.Middle => 20,
            _ => 21
        };

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        GameplayHubSection allegianceSec = globalData.ActiveHub.AddSection("Allegiance", false);
        allegianceSec.AddDefaultContent("Allegiance");

        if (globalData.Years == Years.Early || globalData.Years == Years.Middle)
        {
            GameplayHubSection warSec = globalData.ActiveHub.AddSection("WarOnTheWorld", true);
            warSec.AddSpecialClickHere("WarOnTheWorld", () => HowtoWar(globalData));
            warSec.AddDefaultContent("WarOnTheWorld");
        }

        if (vars.Bribe == "yes")
        {
            GameplayHubSection weaponSec = globalData.ActiveHub.AddSection("EverythingIsAWeapon", false);
            weaponSec.AddDefaultContent("EverythingIsAWeapon");
        }

        if (globalData.Years == Years.Late && vars.Peac == 2)
        {
            GameplayHubSection prSec = globalData.ActiveHub.AddSection("PublicRelations", false);
            prSec.AddDefaultContent("PublicRelations");
        }

        if (globalData.Years == Years.Late)
        {
            GameplayHubSection finalSec = globalData.ActiveHub.AddSection("FinalConflict", true);
            finalSec.AddSpecialClickHere("FinalConflict", HowtoWar);
            finalSec.AddDefaultContent("FinalConflict", text => text
                .FormatWithCondition(0, () => vars.Peac == 1));
        }

        const string       endSection     = "End";
        GameplayHubSection endEarlyMiddle = globalData.ActiveHub.AddSection(endSection);
        endEarlyMiddle.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        endEarlyMiddle.AddDefaultContent(endSection);
        endEarlyMiddle.AddClickHereContinueNextRound(Peace_EndRound, true);

        globalData.ActiveHub.AddEndOfGenerationSection(Peace_EndRound);
    }

    private static void Peace_EndRound(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => ATOW_FamineEvent,
            Years.Middle => PeaceEvent,
            Years.Late   => FinalBattleTime,
            _            => _ => { }
        });
    }

    private static void ATOW_FamineEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        if (globalData.PlayersNum == 2)
        {
            window.AddNextButton(TwoPFamineBid);
        }
        else
        {
            window.AddNextButton(ATOW_FamineEventV);
        }
    }

    private static void TwoPFamineBid(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.RandomPlayer = Random.Shared.Next(0, globalData.PlayersNum);

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent(text => text
            .FormatWithReplacement(0, vars.GetPlayerName(globalData, vars.RandomPlayer)));
        window.AddNextButton(TwoPFamineBidRes);
    }

    private static void TwoPFamineBidRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.None,
            PopUpButton.Accept,
            () => TwoPFamineBidRes_Window(globalData),
            text => text.FormatWithReplacement(0, vars.GetPlayerName(globalData, vars.RandomPlayer))
        );
    }

    private static void TwoPFamineBidRes_Window(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultBaseTitle();
        window.AddNextContentWithLinks(1, [
            ATOW_FamineEventYes,
            ATOW_FamineEventNo
        ], true);
    }

    private static void ATOW_FamineEventV(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.RandomPlayer = Random.Shared.Next(0, globalData.PlayersNum);

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent(text => text
            .FormatWithReplacement(0, vars.GetPlayerName(globalData, vars.RandomPlayer)));
        window.AddNextButton(ATOW_FamineEventRes);
    }

    private static void ATOW_FamineEventRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddNextContentWithLinks(1, [
            ATOW_FamineEventYes,
            ATOW_FamineEventNo
        ], true);
    }

    private static void ATOW_FamineEventYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.PeaceCount += 1;

        new GameplayInputPopup(
            globalData,
            "ATOW_FamineEventYes_Placeholder",
            PopUpButton.Confirm,
            input => !string.IsNullOrWhiteSpace(input),
            input =>
            {
                vars.NewMeat = input.Trim();
                ATOW_FamineEventYes_Window(globalData);
            },
            true
        );
    }

    private static void ATOW_FamineEventYes_Window(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultBaseTitle();
        window.AddDefaultContent(text => text
            .FormatWithReplacement(0, vars.NewMeat));
        window.AddNextButton(ATOW_FamineEventYes_0);
    }

    private static void ATOW_FamineEventYes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Insanity_Icon,
            PopUpButton.Confirm,
            () => PeaceStick(globalData)
        );
    }

    private static void ATOW_FamineEventNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(ATOW_FamineEventNo_0);
    }

    private static void ATOW_FamineEventNo_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.AngryMob_Icon,
            PopUpButton.Confirm,
            () => PeaceStick(globalData)
        );
    }

    private static void PeaceStick(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        if (vars.Crazy >= 1)
        {
            GameplayWindow window = new GameplayWindow(globalData);
            window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
            window.AddDefaultTitle();
            window.AddDefaultContent();
            window.AddNextButton(PeaceStick_0);
        }
        else
        {
            BattleTime(globalData);
        }
    }

    private static void PeaceStick_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WeaponToken,
            PopUpButton.Confirm,
            () => BattleTime(globalData)
        );
    }

    private static void PeaceEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(PeaceEventb);
    }

    private static void PeaceEventb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(PeaceEventc);
    }

    private static void PeaceEventc(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddNextContentWithLinks(1, [
            PeaceEventGas,
            PeaceEventNo
        ], true);
    }

    private static void PeaceEventGas(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Peac = 2;
        vars.PeaceCount += 1;

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(PeaceEventGas_0);
    }

    private static void PeaceEventGas_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            () => BattleTime(globalData)
        );
    }

    private static void PeaceEventNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Peac = 1;

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(PeaceEventNo_0);
    }

    private static void PeaceEventNo_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_ScenarioIcon,
            PopUpButton.Confirm,
            () => BattleTime(globalData)
        );
    }

    private static void BattleTime(GlobalData globalData)
    {
        globalData.SaveToUndo();
        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(BattleCompleteReturn);
    }

    private static void BattleCompleteReturn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        if (globalData.Years == Years.Early)
        {
            globalData.Years = Years.Middle;
        }
        else if (globalData.Years == Years.Middle)
        {
            globalData.Years = Years.Late;
        }

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(Peace_NextRoundSetup);
    }

    private static void Peace_NextRoundSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_WeaponToken,
            PopUpButton.Confirm,
            () => Peace(globalData),
            text => text
                .FormatWithReplacement(0, vars.WeaponLimit.ToString())
                .FormatWithCondition(1, () => globalData.Years == Years.Middle)
                .FormatWithCondition(2, () => vars.WarDestroy >= 2)
        );
    }

    private static void FinalBattleTime(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent(text => text
            .FormatWithCondition(0, () => vars.Peac == 1));
        window.AddNextButton(FinalBattleTime_0);
    }

    private static void FinalBattleTime_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_WorldConquest,
            PopUpButton.Confirm,
            () => FinalBattleComplete(globalData),
            text => text.FormatWithCondition(0, () => vars.Peac == 1)
        );
    }

    private static void FinalBattleComplete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Ending = vars.PeaceCount == 2 ? "ATOW-End7" : "ATOW-End8";

        GameplayWindow window = new GameplayWindow(globalData);
        window.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        window.AddDefaultTitle();
        window.AddDefaultContent();
        window.AddNextButton(Scoring);
    }
}
