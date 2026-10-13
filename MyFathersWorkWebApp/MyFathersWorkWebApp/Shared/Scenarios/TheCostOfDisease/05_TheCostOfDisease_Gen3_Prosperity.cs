namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _EVILS_FORGIVE_1_PLAYER            = "Evilsforgive_1_Player";
    private const string _PRE_PROSPERITY_WOLVES_CONTENT     = "PreProsperitySetup_Wolves_Content";
    private const string _PRE_PROSPERITY_HUNTERS_CONTENT    = "PreProsperitySetup_Hunters_Content";
    private const string _PRE_PROSPERITY_SPOT_A             = "PreProsperitySetup_SpotA";
    private const string _PRE_PROSPERITY_SPOT_B             = "PreProsperitySetup_SpotB";
    private const string _PRE_PROSPERITY_SPOT_C             = "PreProsperitySetup_SpotC";
    private const string _PRE_PROSPERITY_RETURN_OTHER       = "PreProsperitySetup_ReturnOther";
    private const string _PROSPERITY_3B_WOLVES_CONTENT      = "Prosperity3b_Wolves_Content";
    private const string _PROSPERITY_3B_HUNTERS_CONTENT     = "Prosperity3b_Hunters_Content";

    public static void Prosperity(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HubId = CostOfDiseaseHubId.Prosperity;
        globalData.ActiveHub                  = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        const string       monsterSpawnSection = "MonsterSpawn";
        GameplayHubSection monsterSpawn        = globalData.ActiveHub.AddSection(monsterSpawnSection, true);
        monsterSpawn.ReplaceShouldShow(() => globalData.Years == Years.Late && globalData.TheCostOfDiseaseVars.ReturnToEvil);
        monsterSpawn.AddDefaultContent(monsterSpawnSection);

        const string       acceptanceSection = "Acceptance";
        GameplayHubSection acceptance        = globalData.ActiveHub.AddSection(acceptanceSection, true);
        acceptance.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        acceptance.AddDefaultContent(acceptanceSection);

        const string       schoolSection = "School";
        GameplayHubSection school        = globalData.ActiveHub.AddSection(schoolSection);
        school.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        school.AddDefaultContent(schoolSection);

        const string       experimentsSection   = "ExperimentsAreFeared";
        GameplayHubSection experimentsAreFeared = globalData.ActiveHub.AddSection(experimentsSection);
        experimentsAreFeared.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        experimentsAreFeared.AddDefaultContent(experimentsSection);

        const string       farmersMarketSection = "FarmersMarket";
        GameplayHubSection farmersMarket        = globalData.ActiveHub.AddSection(farmersMarketSection);
        farmersMarket.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus && globalData.TheCostOfDiseaseVars.FarmersMarketCreepy && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        farmersMarket.AddDefaultContent(farmersMarketSection);

        const string       angryMobSection = "AngryMob";
        GameplayHubSection angryMob        = globalData.ActiveHub.AddSection(angryMobSection);
        angryMob.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        angryMob.AddDefaultContent(angryMobSection);
        angryMob.AddClickHere(AngryMobStorybook);

        const string       huntersHavenSection = "HuntersHaven";
        GameplayHubSection huntersHaven        = globalData.ActiveHub.AddSection(huntersHavenSection, true);
        huntersHaven.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        huntersHaven.AddDefaultContent(huntersHavenSection);

        const string       engineeringSection     = "EngineeringAchievement";
        GameplayHubSection engineeringAchievement = globalData.ActiveHub.AddSection(engineeringSection);
        engineeringAchievement.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters && globalData.Years is Years.Early or Years.Middle && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        engineeringAchievement.AddDefaultContent(engineeringSection);

        const string       endlessHuntSection = "EndlessHunt";
        GameplayHubSection endlessHunt        = globalData.ActiveHub.AddSection(endlessHuntSection);
        endlessHunt.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters && globalData.Years is Years.Early or Years.Middle && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        endlessHunt.AddDefaultContent(endlessHuntSection);

        const string       scientificSection     = "ScientificAchievement";
        GameplayHubSection scientificAchievement = globalData.ActiveHub.AddSection(scientificSection);
        scientificAchievement.ReplaceShouldShow(() => globalData.Years == Years.Late && !globalData.TheCostOfDiseaseVars.ReturnToEvil);
        scientificAchievement.AddDefaultContent(scientificSection);

        GameplayHubSection nextRound = globalData.ActiveHub.AddSection(string.Empty);
        nextRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        nextRound.AddClickHereContinueNextRound(Prosperity_0);

        globalData.ActiveHub.AddEndOfGenerationSection(Prosperity_0);
    }

    private static void Prosperity_0(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus ? WolvesEco_Friendly : CharityAwardGood,
            Years.Middle => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus ? GoodFrenzyEvent : StartHunterRound2End,
            Years.Late   => Scoring,
            _            => _ => { }
        });
    }

    private static void StartHunterRound2End(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntRound = 2;
        CureMoonSick1(globalData);
    }

    #region Intro

    private static void ProsperityHunterIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Society             = Society.FraternityOfHunters;
        globalData.TheCostOfDiseaseVars.ReturnToEvil        = false;
        globalData.TheCostOfDiseaseVars.FarmersMarketCreepy = false;
        globalData.TheCostOfDiseaseVars.HuntCount           = 0;
        globalData.TheCostOfDiseaseVars.HuntRound           = 1;
        globalData.TheCostOfDiseaseVars.Ending              = "END-HunterGood1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(HuntersHUBcode);
    }

    private static void HuntersHUBcode(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntMonsters[0] = globalData.TheCostOfDiseaseVars.RandomElement(["Wight", "Moon Presence"], 70);
        globalData.TheCostOfDiseaseVars.HuntMonsters[1] = globalData.TheCostOfDiseaseVars.RandomElement(["Pricolici", "Troll"],     71);
        globalData.TheCostOfDiseaseVars.HuntMonsters[2] = globalData.TheCostOfDiseaseVars.RandomElement(["Golem", "Manticore"],     72);
        globalData.TheCostOfDiseaseVars.HuntMonsters[3] = globalData.TheCostOfDiseaseVars.RandomElement(["Strigoi", "Priest"],      73);

        string[] rewards = GetShuffledHuntRewards(globalData);
        globalData.TheCostOfDiseaseVars.HuntRewards[0] = rewards[0];
        globalData.TheCostOfDiseaseVars.HuntRewards[1] = rewards[4];

        List<string> pool     = globalData.GetActivePlayers().ToList();
        List<string> shuffled = new();
        int          rngIdx   = 74;
        while (pool.Count > 0)
        {
            string pick = globalData.TheCostOfDiseaseVars.RandomElement(pool, rngIdx++);
            shuffled.Add(pick);
            pool.Remove(pick);
        }

        if (globalData.PlayersNum == 2)
        {
            globalData.TheCostOfDiseaseVars.HuntRound1Players = [globalData.PlayerAName, globalData.PlayerBName];
            globalData.TheCostOfDiseaseVars.HuntRound2Players = [globalData.PlayerAName, globalData.PlayerBName];
        }
        else if (globalData.PlayersNum == 3)
        {
            globalData.TheCostOfDiseaseVars.HuntRound1Players = [shuffled[0], shuffled[1]];
            globalData.TheCostOfDiseaseVars.HuntRound2Players = [shuffled[2], shuffled[1]];
        }
        else
        {
            globalData.TheCostOfDiseaseVars.HuntRound1Players = [shuffled[0], shuffled[1]];
            globalData.TheCostOfDiseaseVars.HuntRound2Players = [shuffled[2], shuffled[3]];
        }

        Evilsforgive(globalData);
    }

    private static string[] GetShuffledHuntRewards(GlobalData globalData)
    {
        List<string> pool     = ["Occult Knowledge", "Chemistry Knowledge", "Biology Knowledge", "Engineering Knowledge", "Chemicals", "Animals", "Gears", "$"];
        List<string> shuffled = new();
        int          rngIdx   = 80;
        while (pool.Count > 0)
        {
            string pick = globalData.TheCostOfDiseaseVars.RandomElement(pool, rngIdx++);
            shuffled.Add(pick);
            pool.Remove(pick);
        }

        return shuffled.ToArray();
    }

    private static void ProsperityWolvesIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Society             = Society.OrderOfStHubertus;
        globalData.TheCostOfDiseaseVars.ReturnToEvil        = false;
        globalData.TheCostOfDiseaseVars.FarmersMarketCreepy = false;
        globalData.TheCostOfDiseaseVars.AngryMobIndex       = 0;
        globalData.TheCostOfDiseaseVars.Ending              = "END-WolvesGood1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GoodConsequences);
    }

    private static void GoodConsequences(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GoodConsequences_0);
    }

    private static void GoodConsequences_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, Evilsforgive);
    }

    private static void Evilsforgive(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters && globalData.TheCostOfDiseaseVars.HCount == 0)
        {
            EquitableValues(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus));
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus ? Evilsforgive_0 : Evilsforgive_1);
    }

    private static void Evilsforgive_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MastersStudy, PopUpButton.Confirm, EquitableValues);
    }

    private static void Evilsforgive_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, EquitableValues, string.Empty);

        string desc      = string.Empty;
        bool   anyWolves = false;
        foreach (string player in globalData.GetActivePlayers())
        {
            if (globalData.TheCostOfDiseaseVars.Ally.GetValueOrDefault(player, Faction.None) != Faction.Wolves) continue;
            anyWolves = true;
            desc += globalData.GetScenarioLocalizedTag(_EVILS_FORGIVE_1_PLAYER).FormatWithReplacement(0, player);
        }

        if (!anyWolves)
        {
            desc += globalData.GetScenarioLocalizedTag(_EVILS_FORGIVE_1_PLAYER).FormatWithReplacement(0, globalData.PlayerAName);
        }

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static void EquitableValues(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus));
        globalData.ActiveWindow.AddClickHereToContinue(EquitableValues_0);
    }

    private static void EquitableValues_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Action<GlobalData> nextStep = globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Library
            ? MayoralAward
            : globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus
                ? WolvesBankMayorGood
                : PreProsperitySetup;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, nextStep,
            content => content.FormatWithCondition(0, () => globalData.PlayersNum <= 3));
    }

    private static void MayoralAward(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Building != BankOrLibrary.Library)
        {
            if (globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus) WolvesBankMayorGood(globalData);
            else PreProsperitySetup(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor));
        globalData.ActiveWindow.AddClickHereToContinue(MayoralAward_0);
    }

    private static void MayoralAward_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Action<GlobalData> nextStep = globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus
            ? ResolveCharityWolves
            : PreProsperitySetup;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, nextStep);
    }

    private static void WolvesBankMayorGood(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Building != BankOrLibrary.Bank)
        {
            ResolveCharityWolves(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(WolvesBankMayorGood_0);
    }

    private static void WolvesBankMayorGood_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, ResolveCharityWolves,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor));
    }

    private static void ResolveCharityWolves(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Charity);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TownName)
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(ResolveCharityWolves_0);
    }

    private static void ResolveCharityWolves_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, LycanMessageGood,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
    }

    private static void LycanMessageGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddYesNo(LycanGood, PreProsperitySetup);
    }

    private static void LycanGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Lycan = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(LycanGood_0);
    }

    private static void LycanGood_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MWUpdateLycanthropic, PopUpButton.Confirm, PreProsperitySetup);
    }

    private static void PreProsperitySetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        if (globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus)
        {
            globalData.TheCostOfDiseaseVars.Tracker -= 2;
            if (globalData.PlayersNum >= 4) globalData.TheCostOfDiseaseVars.Tracker -= 1;
        }

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.AngryMobSetup1, PopUpButton.Accept, Prosperity, string.Empty);

        string desc = globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus
            ? globalData.GetScenarioLocalizedTag(_PRE_PROSPERITY_WOLVES_CONTENT)
                        .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Tracker.ToString())
                        .FormatWithCondition(1, () => globalData.PlayersNum == 3)
            : globalData.GetScenarioLocalizedTag(_PRE_PROSPERITY_HUNTERS_CONTENT)
                        .FormatWithCondition(0, () => globalData.PlayersNum == 3);

        desc += BuildExposedBuildingsText(globalData);
        desc += globalData.GetScenarioLocalizedTag(_PRE_PROSPERITY_RETURN_OTHER);

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static string BuildExposedBuildingsText(GlobalData globalData)
    {
        string text = string.Empty;
        if (globalData.TheCostOfDiseaseVars.BuildingsExposeValue[0] > 0)
        {
            text += globalData.GetScenarioLocalizedTag(_PRE_PROSPERITY_SPOT_A)
                              .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[0]);
        }

        if (globalData.TheCostOfDiseaseVars.BuildingsExposeValue[1] > 0)
        {
            text += globalData.GetScenarioLocalizedTag(_PRE_PROSPERITY_SPOT_B)
                              .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[1]);
        }

        if (globalData.TheCostOfDiseaseVars.BuildingsExposeValue[2] > 0)
        {
            text += globalData.GetScenarioLocalizedTag(_PRE_PROSPERITY_SPOT_C)
                              .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[2]);
        }

        return text;
    }

    #endregion Intro

    #region Angry Mob Storybook

    private static void AngryMobStorybook(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int storyIndex = globalData.TheCostOfDiseaseVars.AngryMobIndex % 2;
        globalData.TheCostOfDiseaseVars.AngryMobIndex += 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(1, globalData.TownName)
            .FormatWithCondition(0, () => storyIndex == 0));
        globalData.ActiveWindow.AddClickHereToContinue(AngryMobStorybook_0);
    }

    private static void AngryMobStorybook_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int vpLoss = globalData.TheCostOfDiseaseVars.RandomElement([2, 3], 60);

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { },
            content => content
                .FormatWithReplacement(1, vpLoss.ToString())
                .FormatWithCondition(0, () => globalData.Years == Years.Late));
    }

    #endregion Angry Mob Storybook

    #region Round 1 End Events

    private static void WolvesEco_Friendly(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.FarmersMarketCreepy = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(WolvesEco_Friendly_0);
    }

    private static void WolvesEco_Friendly_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, Prosperity);
    }

    private static void CharityAwardGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.HuntRound = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Charity);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(CharityAwardGood_0);
    }

    private static void CharityAwardGood_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, CureMoonSick1);
    }

    private static void CureMoonSick1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.HuntRound == 1));
        globalData.ActiveWindow.AddClickHereToContinue(CureMoonSick1_0);
    }

    private static void CureMoonSick1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.CompulsionBack, PopUpButton.Confirm,
            globalData.TheCostOfDiseaseVars.HuntRound == 1 ? Huntround1 : MayorResolveHunters);
    }

    private static void Huntround1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntRound1Players[0])
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.HuntRound1Players[1]));
        globalData.ActiveWindow.AddClickHereToContinue(Huntround1_0);
    }

    private static void Huntround1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Spouse_Servant, PopUpButton.Confirm, HuntersChoice1,
            content => content
                .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntRound1Players[0])
                .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.HuntRound1Players[1]));
    }

    private static void HuntersChoice1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.HuntName = globalData.TheCostOfDiseaseVars.RandomElement(
            [globalData.TheCostOfDiseaseVars.HuntRound1Players[0], globalData.TheCostOfDiseaseVars.HuntRound1Players[1]], 61);

        string[] rewards = GetShuffledHuntRewards(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntName));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[0] = rewards[0];
                HuntNorth(d);
            },
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[0] = rewards[1];
                HuntEast(d);
            },
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[0] = rewards[2];
                HuntWest(d);
            },
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[0] = rewards[3];
                HuntSouth(d);
            }
        ], true, content => content
            .FormatWithReplacement(0, rewards[0])
            .FormatWithReplacement(1, rewards[1])
            .FormatWithReplacement(2, rewards[2])
            .FormatWithReplacement(3, rewards[3]));
    }

    private static void HuntNorth(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntDirection = "HuntNorth";
        if (globalData.TheCostOfDiseaseVars.HuntMonsters[0] == "Wight") Wight(globalData);
        else MoonPresence(globalData);
    }

    private static void HuntEast(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntDirection = "HuntEast";
        if (globalData.TheCostOfDiseaseVars.HuntMonsters[1] == "Pricolici") Pricolici(globalData);
        else Troll(globalData);
    }

    private static void HuntWest(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntDirection = "HuntWest";
        if (globalData.TheCostOfDiseaseVars.HuntMonsters[2] == "Golem") Golem(globalData);
        else Manticore(globalData);
    }

    private static void HuntSouth(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntDirection = "HuntSouth";
        if (globalData.TheCostOfDiseaseVars.HuntMonsters[3] == "Strigoi") Strigoi(globalData);
        else Priest(globalData);
    }

    private static string GetCurrentHuntReward(GlobalData globalData)
    {
        int idx = globalData.TheCostOfDiseaseVars.HuntRound == 2 ? 1 : 0;
        return globalData.TheCostOfDiseaseVars.HuntRewards[idx];
    }

    private static string GetCurrentHuntBeastName(GlobalData globalData)
    {
        return globalData.TheCostOfDiseaseVars.HuntDirection switch
        {
            "HuntNorth" => globalData.TheCostOfDiseaseVars.HuntMonsters[0] == "Wight" ? "Wight" : "Moonlight Presence",
            "HuntEast"  => globalData.TheCostOfDiseaseVars.HuntMonsters[1] == "Pricolici" ? "Pricolici" : "Troll",
            "HuntWest"  => globalData.TheCostOfDiseaseVars.HuntMonsters[2] == "Golem" ? "Golem" : "Manticore",
            "HuntSouth" => globalData.TheCostOfDiseaseVars.HuntMonsters[3] == "Strigoi" ? "Strigoi" : "Priest",
            _           => "Pricolici"
        };
    }

    private static void Pricolici(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntName)
            .FormatWithReplacement(1, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void MoonPresence(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void Wight(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntName)
            .FormatWithReplacement(1, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void Troll(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void Golem(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void Manticore(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void Strigoi(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TownName)
            .FormatWithReplacement(1, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void Priest(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TownName)
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.HuntName)
            .FormatWithReplacement(2, GetCurrentHuntReward(globalData)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HuntRound == 1 ? HuntNight1 : HuntNight2);
    }

    private static void HuntNight1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntRewards[0]));
        globalData.ActiveWindow.AddYesNo(HuntSuccess1, HuntFail1);
    }

    private static void HuntSuccess1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.HuntCount += 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2, 3, 4], 64)));
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, GetCurrentHuntBeastName(globalData))
            .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2], 65)));
        globalData.ActiveWindow.AddClickHereToContinue(HuntSuccess1_0);
    }

    private static void HuntSuccess1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm,
            globalData.TheCostOfDiseaseVars.HuntRound == 1 ? CompleteHuntRound1 : HuntSuccessCheck,
            content => content.FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2], 66)));
    }

    private static void HuntFail1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2, 3, 4], 67)));
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, GetCurrentHuntBeastName(globalData))
            .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2], 68)));
        globalData.ActiveWindow.AddClickHereToContinue(HuntFail1_0);
    }

    private static void HuntFail1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Servant, PopUpButton.Confirm,
            globalData.TheCostOfDiseaseVars.HuntRound == 1 ? CompleteHuntRound1 : HuntSuccessCheck);
    }

    private static void CompleteHuntRound1(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HuntRound = 2;
        Prosperity(globalData);
    }

    #endregion Round 1 End Events

    #region Round 2 End Events

    private static void GoodFrenzyEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(globalData.PlayersNum == 2 ? Frenzy2pALT : GoodFrenzyEvent2);
    }

    private static void Frenzy2pALT(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereAfterBid(Frenzy2pALTb);
    }

    private static void Frenzy2pALTb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [YesFrenzy, NoFrenzy], true);
    }

    private static void GoodFrenzyEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(GoodFrenzyEvent2b);
    }

    private static void GoodFrenzyEvent2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [YesFrenzy, NoFrenzy], true);
    }

    private static void YesFrenzy(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.ReturnToEvil = true;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesEvil1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(Prosperity3b);
    }

    private static void NoFrenzy(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.ReturnToEvil = false;
        globalData.TheCostOfDiseaseVars.Ending       = "END-WolvesGood1";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(NoFrenzy_0);
    }

    private static void NoFrenzy_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MastersStudy, PopUpButton.Confirm, Prosperity);
    }

    private static void MayorResolveHunters(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(MayorResolveHunters_0);
    }

    private static void MayorResolveHunters_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int vpGain = globalData.TheCostOfDiseaseVars.RandomElement([1, 2], 62);

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MayorCoin, PopUpButton.Confirm, Huntround2,
            content => content
                .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
                .FormatWithReplacement(1, vpGain.ToString()));
    }

    private static void Huntround2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntRound2Players[0])
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.HuntRound2Players[1]));
        globalData.ActiveWindow.AddClickHereToContinue(Huntround2_0);
    }

    private static void Huntround2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Spouse_Servant, PopUpButton.Confirm, HuntersChoice2,
            content => content
                .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntRound2Players[0])
                .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.HuntRound2Players[1]));
    }

    private static void HuntersChoice2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.HuntName = globalData.TheCostOfDiseaseVars.RandomElement(
            [globalData.TheCostOfDiseaseVars.HuntRound2Players[0], globalData.TheCostOfDiseaseVars.HuntRound2Players[1]], 63);

        string[] rewards = GetShuffledHuntRewards(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntName));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[1] = rewards[4];
                HuntNorth(d);
            },
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[1] = rewards[5];
                HuntEast(d);
            },
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[1] = rewards[6];
                HuntWest(d);
            },
            d =>
            {
                d.TheCostOfDiseaseVars.HuntRewards[1] = rewards[7];
                HuntSouth(d);
            }
        ], true, content => content
            .FormatWithReplacement(0, rewards[4])
            .FormatWithReplacement(1, rewards[5])
            .FormatWithReplacement(2, rewards[6])
            .FormatWithReplacement(3, rewards[7]));
    }

    private static void HuntNight2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.HuntRewards[1]));
        globalData.ActiveWindow.AddYesNo(HuntSuccess1, HuntFail1);
    }

    private static void HuntSuccessCheck(GlobalData globalData)
    {
        globalData.SaveToUndo();
        bool isSuccess = globalData.TheCostOfDiseaseVars.HuntCount == 2;
        globalData.TheCostOfDiseaseVars.ReturnToEvil = !isSuccess;
        globalData.TheCostOfDiseaseVars.Ending       = isSuccess ? "END-HunterGood1" : "END-HuntersEvil1";

        int titleVariant = (isSuccess ? 0 : 2) + globalData.TheCostOfDiseaseVars.RandomElement([0, 1], 69);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithIndex(0, titleVariant));
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.HuntCount.ToString())
            .FormatWithReplacement(2, globalData.TownName)
            .FormatWithCondition(0, () => isSuccess));
        globalData.ActiveWindow.AddClickHereToContinue(isSuccess ? HuntSuccessCheck_0 : Prosperity3b);
    }

    private static void HuntSuccessCheck_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MastersStudy, PopUpButton.Confirm, Prosperity);
    }

    private static void Prosperity3b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_Suspicious_Building, PopUpButton.Accept, Prosperity, string.Empty);

        string desc = globalData.TheCostOfDiseaseVars.Society == Society.OrderOfStHubertus
            ? globalData.GetScenarioLocalizedTag(_PROSPERITY_3B_WOLVES_CONTENT)
            : globalData.GetScenarioLocalizedTag(_PROSPERITY_3B_HUNTERS_CONTENT);

        desc += BuildExposedBuildingsText(globalData);

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    #endregion Round 2 End Events
}