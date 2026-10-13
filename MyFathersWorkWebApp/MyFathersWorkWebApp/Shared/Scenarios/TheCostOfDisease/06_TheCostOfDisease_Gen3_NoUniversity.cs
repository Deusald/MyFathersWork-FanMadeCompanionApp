namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _THE_BOARD_1_0_PLAYER   = "TheBoard1_0_Player";
    private const string _MW_PLAYER_INDEX_TMP    = "NoUniMwPlayerIndex";
    private const string _MW_COMPLETE_PLAYER_TMP = "NoUniMwCompletePlayer";

    public static void NoUniversity(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HubId  = CostOfDiseaseHubId.NoUniversity;
        globalData.TheCostOfDiseaseVars.Ending = "END-NoUniGood";
        globalData.ActiveHub                   = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        const string       deteriorationSection = "Deterioration";
        GameplayHubSection deterioration        = globalData.ActiveHub.AddSection(deteriorationSection);
        deterioration.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.LifeCount > 0 && globalData.TheCostOfDiseaseVars.DetVisited.Any(v => v));
        deterioration.AddDefaultContent(deteriorationSection);
        deterioration.AddClickHere(DeteriorationHub);

        const string       immortalitySecretSection = "ImmortalitySecret";
        GameplayHubSection immortalitySecret        = globalData.ActiveHub.AddSection(immortalitySecretSection);
        immortalitySecret.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.LifeCount != globalData.PlayersNum);
        immortalitySecret.AddDefaultContent(immortalitySecretSection);
        immortalitySecret.AddClickHere(InfinityClick1);

        const string       localPubSection = "TheLocalPub";
        GameplayHubSection localPub        = globalData.ActiveHub.AddSection(localPubSection, true);
        localPub.AddDefaultContent(localPubSection);
        localPub.AddClickHere(EnterBar);

        const string       completeMasterworkSection = "CompleteMasterwork";
        GameplayHubSection completeMasterwork        = globalData.ActiveHub.AddSection(completeMasterworkSection, true);
        completeMasterwork.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.CustomMwCompleteCount < globalData.PlayersNum);
        completeMasterwork.AddDefaultContent(completeMasterworkSection);
        completeMasterwork.AddClickHere(CompleteMasterwork);

        const string       knowledgeSection = "Knowledge";
        GameplayHubSection knowledge        = globalData.ActiveHub.AddSection(knowledgeSection);
        knowledge.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        knowledge.AddDefaultContent(knowledgeSection);

        GameplayHubSection nextRound = globalData.ActiveHub.AddSection(string.Empty);
        nextRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        nextRound.AddClickHereContinueNextRound(NoUniversity_0);

        globalData.ActiveHub.AddEndOfGenerationSection(NoUniversity_0);
    }

    private static void NoUniversity_0(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => globalData.TheCostOfDiseaseVars.LifeCount > 0 ? d => StartDetEffectRandom(d, "Hub") : _ => { },
            Years.Middle => globalData.TheCostOfDiseaseVars.LifeCount > 0 ? d => StartDetEffectRandom(d, "ImmortalityCheck") : ImmortalityCheck,
            Years.Late   => Scoring,
            _            => _ => { }
        });
    }

    #region Intro

    private static void NoUniversityIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TownName)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.Unleash));
        globalData.ActiveWindow.AddClickHereToContinue(TheBoard1);
    }

    private static void TheBoard1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.HospCount > 0)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Pana is PanaceaVal.Cure or PanaceaVal.Mod));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HospCount > 0 ? TheBoard1_0 : NoUniBuildAward);
    }

    private static void TheBoard1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ValidationToken, PopUpButton.Confirm, NoUniBuildAward, string.Empty);

        string desc = string.Empty;
        foreach (string name in globalData.GetActivePlayers())
        {
            if (!globalData.TheCostOfDiseaseVars.Hosp.GetValueOrDefault(name, false)) continue;
            desc += globalData.GetScenarioLocalizedTag(_THE_BOARD_1_0_PLAYER).FormatWithReplacement(0, name);
        }

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static void NoUniBuildAward(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank));
        globalData.ActiveWindow.AddClickHereToContinue(NoUniBuildAward_0);
    }

    private static void NoUniBuildAward_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MayorCoin, PopUpButton.Confirm, LoveCharityNoUni,
            content => content
                .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
                .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank));
    }

    private static void LoveCharityNoUni(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Charity);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(LoveCharityNoUni_0);
    }

    private static void LoveCharityNoUni_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Heart, PopUpButton.Confirm, CreateAMasterwork,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
    }

    private static void CreateAMasterwork(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TmpValues[_MW_PLAYER_INDEX_TMP] = 0;
        globalData.ActiveWindow                    = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(CreateMwHandToPlayer);
    }

    private static void CreateMwHandToPlayer(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string player = globalData.GetActivePlayers()[globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP)];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(player, CreateMwDiscipline);
    }

    private static void CreateMwDiscipline(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string player = globalData.GetActivePlayers()[globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP)];
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithReplacement(0, player));
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            d => SelectMwDiscipline("Chemistry", d),
            d => SelectMwDiscipline("Biology", d),
            d => SelectMwDiscipline("Engineering", d),
            d => SelectMwDiscipline("Occult", d)
        ], true);
    }

    private static void SelectMwDiscipline(string discipline, GlobalData globalData)
    {
        string player = globalData.GetActivePlayers()[globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP)];
        globalData.TheCostOfDiseaseVars.CustomMwDiscipline[player] = discipline;
        CreateMwType(globalData);
    }

    private static void CreateMwType(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string player     = globalData.GetActivePlayers()[globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP)];
        string discipline = globalData.TheCostOfDiseaseVars.CustomMwDiscipline.GetValueOrDefault(player, "Chemistry");
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, discipline.ToLowerInvariant()));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            d => SelectMwType("Panacea", d),
            d => SelectMwType("Device", d),
            d => SelectMwType("Creature", d),
            d => SelectMwType("Concoction", d)
        ], true);
    }

    private static void SelectMwType(string type, GlobalData globalData)
    {
        string player     = globalData.GetActivePlayers()[globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP)];
        string discipline = globalData.TheCostOfDiseaseVars.CustomMwDiscipline.GetValueOrDefault(player, "Chemistry");
        globalData.TheCostOfDiseaseVars.CustomMwType[player] = type;
        globalData.TheCostOfDiseaseVars.CustomMwCode[player] = ComputeCustomMwCode(discipline, type);
        CreateMwNameInput(globalData);
    }

    private static int ComputeCustomMwCode(string discipline, string type)
    {
        int discIndex = discipline switch
        {
            "Chemistry"   => 0,
            "Biology"     => 1,
            "Engineering" => 2,
            "Occult"      => 3,
            _             => 0
        };

        int typeIndex = type switch
        {
            "Panacea"    => 0,
            "Device"     => 1,
            "Creature"   => 2,
            "Concoction" => 3,
            _            => 0
        };

        return discIndex * 4 + typeIndex + 1;
    }

    private static void CreateMwNameInput(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string player = globalData.GetActivePlayers()[globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP)];
        globalData.ActiveInputPopup = new GameplayInputPopup(globalData, string.Empty, PopUpButton.Confirm,
            val => !string.IsNullOrWhiteSpace(val),
            val =>
            {
                globalData.TheCostOfDiseaseVars.CustomMwName[player] = val.Trim();
                CreateMwConfirm(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, player));
    }

    private static void CreateMwConfirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int    idx    = globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP);
        string player = globalData.GetActivePlayers()[idx];
        string mwName = globalData.TheCostOfDiseaseVars.CustomMwName.GetValueOrDefault(player, "Masterwork");
        int    code   = Math.Clamp(globalData.TheCostOfDiseaseVars.CustomMwCode.GetValueOrDefault(player, 1), 1, 16);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithReplacement(0, mwName));
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(1, mwName)
            .FormatWithIndex(0, code - 1));
        globalData.ActiveWindow.AddClickHereToContinue(CreateMwAdvance);
    }

    private static void CreateMwAdvance(GlobalData globalData)
    {
        int nextIdx = globalData.GetTmpValue<int>(_MW_PLAYER_INDEX_TMP) + 1;
        if (nextIdx < globalData.PlayersNum)
        {
            globalData.TmpValues[_MW_PLAYER_INDEX_TMP] = nextIdx;
            CreateMwHandToPlayer(globalData);
        }
        else
        {
            PreNoUniversitySetup(globalData);
        }
    }

    private static void PreNoUniversitySetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int suspicionSpace = 3 + globalData.PlayersNum;
        globalData.TheCostOfDiseaseVars.Tracker = suspicionSpace;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.AngryMobSetup1, PopUpButton.Accept, NoUniversity,
            content => content
                .FormatWithReplacement(0, suspicionSpace.ToString())
                .FormatWithCondition(1, () => globalData.PlayersNum == 3)
                .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.LifeCount > 0)
                .FormatWithCondition(3, () => globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.Unleash));
    }

    #endregion Intro

    #region The Local Pub - Bar-Ventures

    private static void EnterBar(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(player =>
        {
            globalData.TheCostOfDiseaseVars.CurrentBarPlayer = player;
            DispatchBarVenture(globalData);
        });
    }

    private static void DispatchBarVenture(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.BarVenturesRemaining.Count == 0)
        {
            globalData.TheCostOfDiseaseVars.BarVenturesRemaining = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        }

        int count  = globalData.TheCostOfDiseaseVars.BarVenturesRemaining.Count;
        int chosen = globalData.TheCostOfDiseaseVars.RandomElement(globalData.TheCostOfDiseaseVars.BarVenturesRemaining, 60 + count);
        globalData.TheCostOfDiseaseVars.BarVenturesRemaining.Remove(chosen);

        switch (chosen)
        {
            case 1:
                Bar1(globalData);
                break;
            case 2:
                Bar2(globalData);
                break;
            case 3:
                Bar3(globalData);
                break;
            case 4:
                Bar4(globalData);
                break;
            case 5:
                Bar5(globalData);
                break;
            case 6:
                Bar6(globalData);
                break;
            case 7:
                Bar7(globalData);
                break;
            case 8:
                Bar8(globalData);
                break;
            case 9:
                Bar9(globalData);
                break;
            default:
                Bar10(globalData);
                break;
        }
    }

    private static void Bar1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar1_0);
    }

    private static void Bar1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar2_0);
    }

    private static void Bar2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar3_0);
    }

    private static void Bar3_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar4_0);
    }

    private static void Bar4_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar5(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar5_0);
    }

    private static void Bar5_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar6(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar6_0);
    }

    private static void Bar6_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar7(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar7_0);
    }

    private static void Bar7_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar8(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar8_0);
    }

    private static void Bar8_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar9(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar9_0);
    }

    private static void Bar9_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Bar10(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.CurrentBarPlayer));
        globalData.ActiveWindow.AddClickHereToContinue(Bar10_0);
    }

    private static void Bar10_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    #endregion The Local Pub - Bar-Ventures

    #region Complete a Masterwork

    private static void CompleteMasterwork(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();

        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(
            p =>
            {
                globalData.TmpValues[_MW_COMPLETE_PLAYER_TMP] = p;
                if (!globalData.TheCostOfDiseaseVars.CustomMwCompleted.GetValueOrDefault(p, false))
                {
                    globalData.TheCostOfDiseaseVars.CustomMwCompleted[p]  = true;
                    globalData.TheCostOfDiseaseVars.CustomMwCompleteCount += 1;
                }

                CompleteMasterworkStory(globalData);
            },
            PlayerFormatterTag.None,
            player => !globalData.TheCostOfDiseaseVars.CustomMwCompleted.GetValueOrDefault(player, false));

        globalData.ActiveWindow.AddNextContentWithLinks(1, [_ => { }], true);
    }

    private static void CompleteMasterworkStory(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string player = globalData.GetTmpValue<string>(_MW_COMPLETE_PLAYER_TMP);
        string mwName = globalData.TheCostOfDiseaseVars.CustomMwName.GetValueOrDefault(player, "Masterwork");
        int    code   = Math.Clamp(globalData.TheCostOfDiseaseVars.CustomMwCode.GetValueOrDefault(player, 1), 1, 16);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content
            .FormatWithReplacement(0, player)
            .FormatWithReplacement(1, mwName));
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(1, mwName)
            .FormatWithReplacement(2, player)
            .FormatWithIndex(0, code - 1));
        globalData.ActiveWindow.AddClickHereToContinue(CompleteMasterworkReward);
    }

    private static void CompleteMasterworkReward(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string player = globalData.GetTmpValue<string>(_MW_COMPLETE_PLAYER_TMP);
        string mwName = globalData.TheCostOfDiseaseVars.CustomMwName.GetValueOrDefault(player, "Masterwork");
        int    code   = Math.Clamp(globalData.TheCostOfDiseaseVars.CustomMwCode.GetValueOrDefault(player, 1), 1, 16);

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, _ => { },
            content => content
                .FormatWithReplacement(1, player)
                .FormatWithReplacement(2, mwName)
                .FormatWithIndex(0, code - 1));
    }

    #endregion Complete a Masterwork

    #region End of Middle Years - Immortality Check & Late Years Transition

    internal static void ImmortalityCheck(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.LifeCount > 0 || globalData.TheCostOfDiseaseVars.Immort)
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithReplacement(2, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(ImmortalityCheck_0);
    }

    private static void ImmortalityCheck_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, NoUniversity,
            content => content
                .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.LifeCount > 0 || globalData.TheCostOfDiseaseVars.Immort)
                .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Mayor)
                .FormatWithReplacement(2, globalData.TheCostOfDiseaseVars.Charity));
    }

    #endregion End of Middle Years - Immortality Check & Late Years Transition
}