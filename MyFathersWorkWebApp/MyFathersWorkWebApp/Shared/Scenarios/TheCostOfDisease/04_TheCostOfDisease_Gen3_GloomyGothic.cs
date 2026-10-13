namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _EVIL_CONSEQUENCES_0_CONTENT      = "EvilConsequences_0_Content";
    private const string _LOSING_ORDER_AID_0_CONTENT       = "LosingOrderAid_0_Content";
    private const string _PRE_GLOOMY_GOTHIC_SETUP_CONTENT  = "PreGloomyGothicSetup_Content";
    private const string _PRE_GLOOMY_GOTHIC_SETUP_CONTENT1 = "PreGloomyGothicSetup_Content1";
    private const string _PRE_GLOOMY_GOTHIC_SETUP_CONTENT2 = "PreGloomyGothicSetup_Content2";
    private const string _PRE_GLOOMY_GOTHIC3_SETUP_CONTENT = "PreGloomyGothic3Setup_Content";

    public static void GloomyGothic(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HubId = CostOfDiseaseHubId.GloomyGothic;
        globalData.ActiveHub                  = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        // Fraternity of Hunters sections
        const string       safeAndProtectedSection = "SafeAndProtected";
        GameplayHubSection safeAndProtected        = globalData.ActiveHub.AddSection(safeAndProtectedSection);
        safeAndProtected.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters &&
            ((globalData.Years == Years.Middle && !globalData.TheCostOfDiseaseVars.Confront) ||
             (globalData.Years == Years.Late && globalData.TheCostOfDiseaseVars.Taxes)));
        safeAndProtected.AddDefaultContent(safeAndProtectedSection, content => content.FormatWithCondition(0, () => globalData.Years == Years.Middle));

        const string       huntersRestSection = "TheHuntersRest";
        GameplayHubSection huntersRest        = globalData.ActiveHub.AddSection(huntersRestSection, true);
        huntersRest.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters &&
            (globalData.Years == Years.Early ||
             (globalData.Years == Years.Middle && !globalData.TheCostOfDiseaseVars.Confront) ||
             (globalData.Years == Years.Late && globalData.TheCostOfDiseaseVars.Taxes)));
        huntersRest.AddDefaultContent(huntersRestSection);

        const string       taxationSection = "Taxation";
        GameplayHubSection taxation        = globalData.ActiveHub.AddSection(taxationSection);
        taxation.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters &&
            (globalData.Years == Years.Early ||
             (globalData.Years == Years.Middle && !globalData.TheCostOfDiseaseVars.Confront)));
        taxation.AddDefaultContent(taxationSection);

        const string       huntIsOnSection = "TheHuntIsOn";
        GameplayHubSection huntIsOn        = globalData.ActiveHub.AddSection(huntIsOnSection, true);
        huntIsOn.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters &&
            globalData.Years == Years.Middle &&
            globalData.TheCostOfDiseaseVars.Confront);
        huntIsOn.AddDefaultContent(huntIsOnSection, content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntVp.ToString()));

        const string       huntersHavenSection = "TheHuntersHaven";
        GameplayHubSection huntersHaven        = globalData.ActiveHub.AddSection(huntersHavenSection, true);
        huntersHaven.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters &&
            globalData.Years == Years.Late &&
            !globalData.TheCostOfDiseaseVars.Taxes);
        huntersHaven.AddDefaultContent(huntersHavenSection);

        const string       finalTaxationSection = "FinalTaxation";
        GameplayHubSection finalTaxation        = globalData.ActiveHub.AddSection(finalTaxationSection);
        finalTaxation.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters &&
            globalData.Years == Years.Late &&
            globalData.TheCostOfDiseaseVars.Taxes);
        finalTaxation.AddDefaultContent(finalTaxationSection);

        // Order of St. Hubertus sections
        const string       masterworkCompletionSection = "MasterworkCompletion";
        GameplayHubSection masterworkCompletion        = globalData.ActiveHub.AddSection(masterworkCompletionSection);
        masterworkCompletion.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus &&
            (globalData.Years is Years.Early or Years.Middle ||
             (globalData.Years == Years.Late && !globalData.TheCostOfDiseaseVars.VialCleansed)));
        masterworkCompletion.AddDefaultContent(masterworkCompletionSection);
        masterworkCompletion.AddSpecialClickHere(masterworkCompletionSection, MWTokenResolve);

        const string       monsterSpawnSection = "MonsterSpawn";
        GameplayHubSection monsterSpawn        = globalData.ActiveHub.AddSection(monsterSpawnSection, true);
        monsterSpawn.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus &&
            (globalData.Years is Years.Early or Years.Middle ||
             (globalData.Years == Years.Late && !globalData.TheCostOfDiseaseVars.VialCleansed)));
        monsterSpawn.AddDefaultContent(monsterSpawnSection);

        const string       hybridSchoolSection = "HybridSchool";
        GameplayHubSection hybridSchool        = globalData.ActiveHub.AddSection(hybridSchoolSection, true);
        hybridSchool.ReplaceShouldShow(() =>
            globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus &&
            globalData.Years == Years.Late &&
            globalData.TheCostOfDiseaseVars.VialCleansed);
        hybridSchool.AddDefaultContent(hybridSchoolSection);

        const string       giftOfSpawningSection = "GiftOfSpawning";
        GameplayHubSection giftOfSpawning        = globalData.ActiveHub.AddSection(giftOfSpawningSection);
        giftOfSpawning.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus);
        giftOfSpawning.AddDefaultContent(giftOfSpawningSection);

        GameplayHubSection nextRound = globalData.ActiveHub.AddSection(string.Empty);
        nextRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        nextRound.AddClickHereContinueNextRound(GloomyGothic_0);

        globalData.ActiveHub.AddEndOfGenerationSection(GloomyGothic_0);
    }

    private static void GloomyGothic_0(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters
                ? GloomyPenalty1
                : WolvesEvil1,
            Years.Middle => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters
                ? (globalData.TheCostOfDiseaseVars.Confront ? HunterConfrontation : TaxesEventNoConfrontation)
                : WolvesVote,
            Years.Late => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters
                ? (globalData.TheCostOfDiseaseVars.Taxes ? GloomyPenalty3 : Scoring)
                : AwardSpawningPods,
            _ => _ => { }
        });
    }

    #region Intro

    private static void GloomyHunterIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Society = Society.FraternityOfHunters;
        globalData.TheCostOfDiseaseVars.HuntVp  = globalData.TheCostOfDiseaseVars.RandomElement([4, 5], 60);
        globalData.TheCostOfDiseaseVars.Taxes   = true;
        globalData.TheCostOfDiseaseVars.Ending  = "END-HuntersEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(EvilConsequences);
    }

    private static void GloomyWolvesIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Society      = Society.OrderOfStHubertus;
        globalData.TheCostOfDiseaseVars.VialCleansed = false;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(EvilConsequences);
    }

    private static void EvilConsequences(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Faction winningFaction = globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters
            ? Faction.Hunters
            : Faction.Wolves;
        bool anyDisobedient = globalData.GetActivePlayers()
            .Any(p => globalData.TheCostOfDiseaseVars.Ally.GetValueOrDefault(p, Faction.None) != winningFaction);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters));
        globalData.ActiveWindow.AddClickHereToContinue(anyDisobedient ? EvilConsequences_0 : EvilMayor);
    }

    private static void EvilConsequences_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, EvilMayor, string.Empty);

        Faction winningFaction = globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters
            ? Faction.Hunters
            : Faction.Wolves;

        string desc = string.Empty;
        foreach (string name in globalData.GetActivePlayers())
        {
            if (globalData.TheCostOfDiseaseVars.Ally.GetValueOrDefault(name, Faction.None) == winningFaction) continue;
            desc += globalData.GetScenarioLocalizedTag(_EVIL_CONSEQUENCES_0_CONTENT).FormatWithReplacement(0, name);
        }

        if (string.IsNullOrEmpty(desc))
        {
            desc = globalData.GetScenarioLocalizedTag(_EVIL_CONSEQUENCES_0_CONTENT).FormatWithReplacement(0, globalData.PlayerAName);
        }

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static void EvilMayor(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Building != BankOrLibrary.Bank)
        {
            MayorLibraryEvil(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Society));
        globalData.ActiveWindow.AddClickHereToContinue(EvilMayor_0);
    }

    private static void EvilMayor_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MayorCoin, PopUpButton.Confirm, LosingOrderAid);
    }

    private static void MayorLibraryEvil(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Building != BankOrLibrary.Library)
        {
            LosingOrderAid(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithReplacement(1, globalData.TownName)
            .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters));
        globalData.ActiveWindow.AddClickHereToContinue(MayorLibraryEvil_0);
    }

    private static void MayorLibraryEvil_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MayorCoin, PopUpButton.Confirm, LosingOrderAid,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor));
    }

    private static void LosingOrderAid(GlobalData globalData)
    {
        bool isWolvesSociety = globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus;
        int  losingCount     = isWolvesSociety ? globalData.TheCostOfDiseaseVars.HCount : globalData.TheCostOfDiseaseVars.WCount;

        if (losingCount == 0)
        {
            if (isWolvesSociety) EvilWolvesEventStart(globalData);
            else TaxesEventStart(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithCondition(0, () => isWolvesSociety));
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => isWolvesSociety));
        globalData.ActiveWindow.AddClickHereToContinue(LosingOrderAid_0);
    }

    private static void LosingOrderAid_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        bool               isWolvesSociety = globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus;
        Action<GlobalData> nextStep        = isWolvesSociety ? EvilWolvesEventStart : TaxesEventStart;
        Faction            losingFaction   = isWolvesSociety ? Faction.Hunters : Faction.Wolves;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.GainServantFromLost, PopUpButton.Confirm, nextStep, string.Empty);

        string desc = string.Empty;
        foreach (string name in globalData.GetActivePlayers())
        {
            if (globalData.TheCostOfDiseaseVars.Ally.GetValueOrDefault(name, Faction.None) != losingFaction) continue;
            desc += globalData.GetScenarioLocalizedTag(_LOSING_ORDER_AID_0_CONTENT).FormatWithReplacement(0, name);
        }

        if (string.IsNullOrEmpty(desc))
        {
            desc = globalData.GetScenarioLocalizedTag(_LOSING_ORDER_AID_0_CONTENT).FormatWithReplacement(0, globalData.PlayerAName);
        }

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static void TaxesEventStart(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CharityNegCons);
    }

    private static void CharityNegCons(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(CharityNegCons_0);
    }

    private static void CharityNegCons_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_HeartToken, PopUpButton.Confirm, PreGloomyGothicSetup,
            content => content
                .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity)
                .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.RandomBool(61)));
    }

    private static void EvilWolvesEventStart(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(VialCharity);
    }

    private static void VialCharity(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.TheCostOfDiseaseVars.Charity, VialCharity_0);
    }

    private static void VialCharity_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(VialCharity_1);
    }

    private static void VialCharity_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_VialToken, PopUpButton.Confirm, LycanthropicMessage);
    }

    private static void LycanthropicMessage(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddYesNo(LycanEvil, WolvesSetupGen3);
    }

    private static void LycanEvil(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Lycan = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(LycanEvil_0);
    }

    private static void LycanEvil_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MWUpdateLycanthropic, PopUpButton.Confirm, WolvesSetupGen3);
    }

    private static void WolvesSetupGen3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.StorybookToken, PopUpButton.Confirm, PreGloomyGothicSetup);
    }

    private static void PreGloomyGothicSetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.StartPlayerToken, PopUpButton.Confirm, GloomyGothic, string.Empty);

        string desc = globalData.GetScenarioLocalizedTag(_PRE_GLOOMY_GOTHIC_SETUP_CONTENT)
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters)
            .FormatWithCondition(1, () => globalData.PlayersNum == 3);

        for (int i = 0; i < 3; i++)
        {
            if (globalData.TheCostOfDiseaseVars.BuildingsExposeValue[i] <= 1)
            {
                desc += globalData.GetScenarioLocalizedTag(_PRE_GLOOMY_GOTHIC_SETUP_CONTENT1)
                    .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[i])
                    .FormatWithIndex(1, i);
            }
        }

        desc += globalData.GetScenarioLocalizedTag(_PRE_GLOOMY_GOTHIC_SETUP_CONTENT2);
        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static void PreGloomyGothic3Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Suspicious_Building, PopUpButton.Confirm, _ => { }, string.Empty);

        string desc = globalData.GetScenarioLocalizedTag(_PRE_GLOOMY_GOTHIC3_SETUP_CONTENT)
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters);

        for (int i = 0; i < 3; i++)
        {
            if (globalData.TheCostOfDiseaseVars.BuildingsExposeValue[i] <= 1)
            {
                desc += globalData.GetScenarioLocalizedTag(_PRE_GLOOMY_GOTHIC_SETUP_CONTENT1)
                    .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[i])
                    .FormatWithIndex(1, i);
            }
        }

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    #endregion Intro

    #region Masterwork Token Resolve (Wolves Hub)

    private static void MWTokenResolve(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(MWTokenResolve_0);
    }

    private static void MWTokenResolve_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, _ => { });
    }

    #endregion Masterwork Token Resolve (Wolves Hub)

    #region Round 1 Events

    private static void GloomyPenalty1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GloomyPenalty1_0);
    }

    private static void GloomyPenalty1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_HunterToken, PopUpButton.Confirm, Preposterous);
    }

    private static void Preposterous(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(EvilHunter1Event);
    }

    private static void EvilHunter1Event(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(EvilHunter1Event2);
    }

    private static void EvilHunter1Event2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [EvilHunter1EventYes, EvilHunter1EventNo], true);
    }

    private static void EvilHunter1EventYes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Confront = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    private static void EvilHunter1EventNo(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Confront = false;
        TaxesEventNoConfrontation2(globalData);
    }

    private static void WolvesEvil1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TieredRewards1);
    }

    private static void TieredRewards1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TieredRewards1_0);
    }

    private static void TieredRewards1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_WolfToken, PopUpButton.Confirm, _ => { },
            content => content
                .FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2, 3], 62))
                .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2],    63))
                .FormatWithIndex(2, globalData.TheCostOfDiseaseVars.RandomElement([0, 1],       64)));
    }

    #endregion Round 1 Events

    #region Round 2 Events

    private static void HunterConfrontation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(CannotParticipate);
    }

    private static void CannotParticipate(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CannotParticipate_0);
    }

    private static void CannotParticipate_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm, HunterConf2);
    }

    private static void HunterConf2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.DonatedVpTotal = globalData.PlayersNum switch
        {
            2 => globalData.TheCostOfDiseaseVars.RandomElement([3, 4, 5, 6, 7], 65),
            3 => globalData.TheCostOfDiseaseVars.RandomElement([8, 9, 10, 11, 12], 65),
            _ => globalData.TheCostOfDiseaseVars.RandomElement([11, 12, 13, 14, 15], 65)
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.DonatedVpTotal.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(HunterConf3);
    }

    private static void HunterConf3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content =>
            content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.DonatedVpTotal.ToString()));
        globalData.ActiveWindow.AddNextContentWithLinks(1, [OhYesTheyDead, ConfrontationFail], true,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.DonatedVpTotal.ToString()));
    }

    private static void OhYesTheyDead(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Taxes  = false;
        globalData.TheCostOfDiseaseVars.Ending = "END-HuntersEvil1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(OhYesTheyDead_0);
    }

    private static void OhYesTheyDead_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, PreGloomyGothic3Setup,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntVp.ToString()));
    }

    private static void ConfrontationFail(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Taxes  = true;
        globalData.TheCostOfDiseaseVars.Ending = "END-HuntersEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntVp.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(ConfrontationFail_0);
    }

    private static void ConfrontationFail_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.AngryMob_Icon, PopUpButton.Confirm, _ => { },
            content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.RandomBool(66)));
    }

    private static void TaxesEventNoConfrontation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TaxesEventNoConfrontation_0);
    }

    private static void TaxesEventNoConfrontation_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_HunterToken, PopUpButton.Confirm, TaxesEventNoConfrontation2);
    }

    private static void TaxesEventNoConfrontation2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Confront = false;
        globalData.TheCostOfDiseaseVars.Taxes    = true;
        globalData.TheCostOfDiseaseVars.Ending   = "END-HuntersEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(TaxesEventNoConfrontation2_0);
    }

    private static void TaxesEventNoConfrontation2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void WolvesVote(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WolvesVote2);
    }

    private static void WolvesVote2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [WolvesVoteCheck, TheVialUse], true);
    }

    private static void WolvesVoteCheck(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [WolvesVoteChange, TheVialUse], true);
    }

    private static void WolvesVoteChange(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.VialCleansed = true;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesEvil1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(VialSoldforLess);
    }

    private static void VialSoldforLess(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.VialCleansed = true;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesEvil1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(VialSoldforLess_0);
    }

    private static void VialSoldforLess_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Money_Icon, PopUpButton.Confirm, PreGloomyGothic3Setup,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
    }

    private static void TheVialUse(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [VialChanged, VialSold], true);
    }

    private static void VialChanged(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.VialCleansed = true;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesEvil1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(VialChanged_0);
    }

    private static void VialChanged_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_VialToken, PopUpButton.Confirm, PreGloomyGothic3Setup,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
    }

    private static void VialSold(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.VialCleansed = false;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(VialSold_0);
    }

    private static void VialSold_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Money_Icon, PopUpButton.Confirm, WolvesEvil2,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
    }

    private static void WolvesEvil2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(TieredRewards2);
    }

    private static void TieredRewards2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Ending = "END-WolvesEvil2";

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { },
            content => content
                .FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2, 3], 67))
                .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2],    68))
                .FormatWithIndex(2, globalData.TheCostOfDiseaseVars.RandomElement([0, 1],       69)));
    }

    #endregion Round 2 Events

    #region Round 3 End Events

    private static void GloomyPenalty3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Ending = "END-HuntersEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GloomyPenalty3_0);
    }

    private static void GloomyPenalty3_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_HunterToken, PopUpButton.Confirm, Scoring);
    }

    private static void AwardSpawningPods(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Ending = globalData.TheCostOfDiseaseVars.VialCleansed
            ? "END-WolvesEvil1"
            : "END-WolvesEvil2";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.VialCleansed));
        globalData.ActiveWindow.AddClickHereToContinue(AwardSpawningPods_0);
    }

    private static void AwardSpawningPods_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.MFWlogo, PopUpButton.Confirm, Scoring);
    }

    #endregion Round 3 End Events
}