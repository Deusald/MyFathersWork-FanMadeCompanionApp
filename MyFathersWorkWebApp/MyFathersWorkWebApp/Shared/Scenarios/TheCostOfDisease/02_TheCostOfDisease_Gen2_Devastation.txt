namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _LETTER_CODE_0_CONTENT = "LetterCode_0_Content";

    public static void Devastation(GlobalData globalData)
    {
        // Round 4 -> Devastation1
        // Round 5 -> Devastation2
        // Round 6 -> Devastation3
        globalData.TheCostOfDiseaseVars.HubId = CostOfDiseaseHubId.Devastation;
        globalData.ActiveHub                  = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(Years.Early);

        const string       envelopesSection = "Envelopes";
        GameplayHubSection envelopes        = globalData.ActiveHub.AddSection(envelopesSection, true);
        envelopes.ReplaceShouldShow(() => globalData.Years == Years.Early);
        envelopes.AddDefaultContent(envelopesSection);
        envelopes.AddClickHere(Envelopes);

        const string       suspicionSection = "Suspicion";
        GameplayHubSection suspicion        = globalData.ActiveHub.AddSection(suspicionSection, true);
        suspicion.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late);
        suspicion.AddDefaultContent(suspicionSection);
        suspicion.AddSpecialClickHere(suspicionSection, _ => BuildingSignin(0, globalData), false, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[0]));
        suspicion.AddSpecialClickHere(suspicionSection, _ => BuildingSignin(1, globalData), true,  content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[1]));
        suspicion.AddSpecialClickHere(suspicionSection, _ => BuildingSignin(2, globalData), true,  content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[2]));
        suspicion.AddNextContent(1, suspicionSection);

        const string       hereditaryDiseaseSection = "HereditaryDisease";
        GameplayHubSection hereditaryDisease        = globalData.ActiveHub.AddSection(hereditaryDiseaseSection);
        hereditaryDisease.AddDefaultContent(hereditaryDiseaseSection);
        hereditaryDisease.AddClickHere(HereditaryDiseaseComplete);

        const string       stableHandSection = "StableHand";
        GameplayHubSection stableHand        = globalData.ActiveHub.AddSection(stableHandSection);
        stableHand.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late);
        stableHand.AddDefaultContent(stableHandSection);
        stableHand.AddSpecialClickHere(stableHandSection, RefusalEvent);
        stableHand.AddNextContent(1, stableHandSection, true);

        GameplayHubSection nextRound = globalData.ActiveHub.AddSection(string.Empty);
        nextRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        nextRound.AddClickHereContinueNextRound(Devastation_0);

        GameplayHubSection nextGeneration = globalData.ActiveHub.AddSection(string.Empty);
        nextGeneration.ReplaceShouldShow(() => globalData.Years == Years.Late);
        nextGeneration.AddClickAtTheEndOfGeneration(Devastation_0);
    }

    private static void Devastation_0(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => Changes,
            Years.Middle => DevEventCure,
            Years.Late   => BuildingsEnd,
            _            => _ => { }
        });
    }

    #region Intro

    private static void DevastationIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DiseaseConsequence);
    }

    private static void DiseaseConsequence(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DiseaseConsequence_0);
    }

    private static void DiseaseConsequence_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm, LetterCode);
    }

    private static void LetterCode(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(LetterCode_0);
    }

    private static void LetterCode_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_LetterBACK, PopUpButton.Confirm, Gen1InsanityYes, string.Empty);

        List<int> letterIds = [0, 1, 2, 3, 4, 5];
        List<int> randomIds = [globalData.TheCostOfDiseaseVars.RandomArray[41], globalData.TheCostOfDiseaseVars.RandomArray[42], globalData.TheCostOfDiseaseVars.RandomArray[43], globalData.TheCostOfDiseaseVars.RandomArray[44]];

        string content = globalData.GetScenarioLocalizedTag(_LETTER_CODE_0_CONTENT);

        int index = 0;

        foreach (string player in globalData.GetActivePlayers())
        {
            int letterId = letterIds[randomIds[index] % letterIds.Count];
            globalData.TheCostOfDiseaseVars.Letter[letterId] = player;

            content += globalData.GetScenarioLocalizedTag(_LETTER_CODE_0_CONTENT + "1").FormatWithReplacement(0, player).FormatWithReplacement(1, (letterId + 1).ToString());

            letterIds.Remove(letterId);
            ++index;
        }

        content += globalData.GetScenarioLocalizedTag(_LETTER_CODE_0_CONTENT + "2");
        globalData.ActivePopup.ReplaceDescription(content);
    }

    private static void Gen1InsanityYes(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Vacation != ExtendedBool.True)
        {
            PreDevastation(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookTo(globalData.TheCostOfDiseaseVars.Gen1Sane, Gen1InsanityYes_0);
    }

    private static void Gen1InsanityYes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Sane));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.RandomBool(45) ? Gen1InsanityYes_1 : Gen1InsanityYes_2);
    }

    private static void Gen1InsanityYes_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.MaladjustmentBack, PopUpButton.Confirm, PreDevastation);
    }

    private static void Gen1InsanityYes_2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, PreDevastation);
    }

    private static void PreDevastation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Tracker += 2;
        if (globalData.PlayersNum == 4) globalData.TheCostOfDiseaseVars.Tracker += 3;

        List<BuildingS1A> buildings = [BuildingS1A.HardwareStore, BuildingS1A.WireService, BuildingS1A.BookStore, BuildingS1A.Warehouse, BuildingS1A.PetStore];
        BuildingS1A       removed   = globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank ? BuildingS1A.WireService : BuildingS1A.BookStore;
        buildings.Remove(removed);
        BuildingS1A firstBuilding = globalData.TheCostOfDiseaseVars.RandomElement(buildings, 50);
        buildings.Remove(firstBuilding);
        BuildingS1A secondBuilding = globalData.TheCostOfDiseaseVars.RandomElement(buildings, 51);

        globalData.TheCostOfDiseaseVars.Gen2Buildings[0] = firstBuilding;
        globalData.TheCostOfDiseaseVars.Gen2Buildings[1] = secondBuilding;
        globalData.TheCostOfDiseaseVars.Gen2Buildings[2] = removed;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True ? PopUpIcon.AngryMobSetup2 : PopUpIcon.AngryMobSetup1, PopUpButton.Confirm,
            Devastation, content => content
                                   .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank)
                                   .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Tracker.ToString())
                                   .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True));
    }

    #endregion Intro

    #region Envelopes

    private static void Envelopes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddOnceYouAreReady(Envelopes_0);
    }

    private static void Envelopes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(EnvPasscode);
    }

    private const string _LETTER_PASS_TMP        = "LetterPass";
    private const string _LETTER_PLAYER_NAME_TMP = "LetterPlayerName";

    private static readonly List<string>             _Passwords     = ["alpha", "moon", "howl", "right", "cross", "bolt"];
    private static readonly List<Action<GlobalData>> _LetterMethods = [HubertusWolves, HubertusWolves, HubertusWolves, HubertusHunters, HubertusHunters, HubertusHunters];

    private static void EnvPasscode(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveInputPopup = new GameplayInputPopup(globalData, "EnvPasscode_Placeholder", PopUpButton.Confirm, pass => pass.Length > 1, pass =>
        {
            pass = pass.ToLower();

            int index = -1;

            for (int x = 0; x < _Passwords.Count; ++x)
            {
                if (_Passwords[x] != pass) continue;
                index = x;
                break;
            }

            globalData.TmpValues[_LETTER_PASS_TMP] = pass;

            if (index == -1)
            {
                FailedMeeting(globalData);
            }
            else
            {
                string playerName = globalData.TheCostOfDiseaseVars.Letter[index];

                if (playerName == string.Empty)
                {
                    FailedMeeting(globalData);
                    return;
                }

                globalData.TmpValues[_LETTER_PLAYER_NAME_TMP] = playerName;
                globalData.TheCostOfDiseaseVars.Letter[index] = string.Empty;

                globalData.ActiveWindow = new GameplayWindow(globalData);
                globalData.ActiveWindow.AddDoNotOtherPlayersToSee(playerName, _LetterMethods[index]);
            }
        }, true);
    }

    private static void HubertusWolves(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content =>
            content.FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2], 46))
                   .FormatWithReplacement(1, (globalData.TheCostOfDiseaseVars.RandomArray[47] % 30).ToString()));
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP))
                                                            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil));
        globalData.ActiveWindow.AddNextContentWithLinks(1, [HubertusWolves_Join, RefusalWolvesOrHunters]);
    }

    private static void HubertusWolves_Join(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Ally[globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP)] = Faction.Wolves;
        HubertusConfirmation(globalData);
    }

    private static void HubertusConfirmation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.WCount += 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP))
                                                            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Good));
        globalData.ActiveWindow.AddClickHereToContinue(_ => Gen1InsanityNoAction(globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP), globalData));
    }

    private static void HubertusHunters(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content =>
            content.FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2], 48))
                   .FormatWithReplacement(1, (globalData.TheCostOfDiseaseVars.RandomArray[49] % 30).ToString()));
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP))
                                                            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Hunters == Affiliation.Evil));
        globalData.ActiveWindow.AddNextContentWithLinks(1, [HubertusHunters_Join, RefusalWolvesOrHunters]);
    }

    private static void HubertusHunters_Join(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Ally[globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP)] = Faction.Hunters;
        HuntersConfirmation(globalData);
    }

    private static void HuntersConfirmation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.HCount += 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP))
                                                            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Hunters == Affiliation.Good));
        globalData.ActiveWindow.AddClickHereToContinue(_ => Gen1InsanityNoAction(globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP), globalData));
    }

    private static void RefusalWolvesOrHunters(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(_ => Gen1InsanityNoAction(globalData.GetTmpValue<string>(_LETTER_PLAYER_NAME_TMP), globalData));
    }

    private static void FailedMeeting(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.GetTmpValue<string>(_LETTER_PASS_TMP)));
        globalData.ActiveWindow.AddClickHereToContinue(FailedMeeting_0);
    }

    private static void FailedMeeting_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.Creepy_Icon, PopUpButton.Accept, _ => { });
    }

    #endregion Envelopes

    #region Hereditary Disease

    private static void HereditaryDiseaseComplete(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(HereditaryDiseaseComplete_0);
    }

    private static void HereditaryDiseaseComplete_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm, _ => { });
    }

    #endregion Hereditary Disease

    #region Changes

    private static void Changes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Changes_0);
    }

    private static void Changes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_LetterBACK, PopUpButton.Confirm, Diseases1);
    }

    private static void Diseases1(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.RandomElement([Diseases1A, Diseases1B], 52).Invoke(globalData);
    }

    private static void Diseases1A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Diseases1A_0);
    }

    private static void Diseases1A_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm,
            globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.False ? Gen1CreepyRefusalBuild : PreDevastation2);
    }

    private static void Diseases1B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Diseases1B_0);
    }

    private static void Diseases1B_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm,
            globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.False ? Gen1CreepyRefusalBuild : PreDevastation2);
    }

    private static void PreDevastation2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_Suspicious_Building, PopUpButton.Confirm, _ => { },
            content => content
                      .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[0])
                      .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[1])
                      .FormatWithIndex(2, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[2]));
    }

    #endregion Changes

    #region Gen 1 Insanity No Action

    private const string _GEN1_SANE_NO_ACTION_TMP = "Gen1InsanityNoAction";

    private static void Gen1InsanityNoAction(string playerName, GlobalData globalData)
    {
        globalData.TmpValues[_GEN1_SANE_NO_ACTION_TMP] = playerName;
        Gen1InsanityNoAction_0(globalData);
    }

    private static void Gen1InsanityNoAction_0(GlobalData globalData)
    {
        if (globalData.GetTmpValue<string>(_GEN1_SANE_NO_ACTION_TMP) != globalData.TheCostOfDiseaseVars.Gen1Sane) return;
        if (globalData.TheCostOfDiseaseVars.Vacation != ExtendedBool.False) return;

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.GetTmpValue<string>(_GEN1_SANE_NO_ACTION_TMP)));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1InsanityNoAction_1);
    }

    private static void Gen1InsanityNoAction_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Vacation = ExtendedBool.Complete;
        globalData.ActivePopup                   = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.WhenYouPlaceThisPiece, PopUpButton.Confirm, _ => { });
    }

    #endregion Gen 1 Insanity No Action

    #region Gen1 Creepy Refusal Build

    private static void Gen1CreepyRefusalBuild(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.TheCostOfDiseaseVars.Gen1Creep, globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Good ? Gen1CreepyRefusalBuildA : Gen1CreepyRefusalBuildB);
    }

    private static void Gen1CreepyRefusalBuildA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Creep));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1CreepyRefusalBuildA_0);
    }

    private static void Gen1CreepyRefusalBuildA_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, PreDevastation2);
    }

    private static void Gen1CreepyRefusalBuildB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Creep));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1CreepyRefusalBuildB_0);
    }

    private static void Gen1CreepyRefusalBuildB_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, PreDevastation2);
    }

    #endregion Gen1 Creepy Refusal Build

    #region Refusal Event

    private const string _REFUSAL_PLAYER_TMP = "RefusalPlayer";

    private static void RefusalEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TmpValues[_REFUSAL_PLAYER_TMP] = playerName;

            if (globalData.TheCostOfDiseaseVars.Ally[playerName] == Faction.None) RefusalReveal(globalData);
            else JoinedAlready(globalData);
        });
    }

    private static void RefusalReveal(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.GetTmpValue<string>(_REFUSAL_PLAYER_TMP), RefusalReveal_0);
    }

    private static void RefusalReveal_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Wolves)
                                                            .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Hunters)
                                                            .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Good)
                                                            .FormatWithCondition(3, () => globalData.TheCostOfDiseaseVars.Hunters == Affiliation.Good)
                                                            .FormatWithReplacement(4, globalData.GetTmpValue<string>(_REFUSAL_PLAYER_TMP)));
        globalData.ActiveWindow.AddNextContentWithLinks(1, [WolfJoin, HunterJoin, _ => { }]);
    }

    private static void WolfJoin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [WolfJoin_0, _ => { }]);
    }

    private static void WolfJoin_0(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.WCount                                                    += 1;
        globalData.TheCostOfDiseaseVars.Ally[globalData.GetTmpValue<string>(_REFUSAL_PLAYER_TMP)] =  Faction.Wolves;
    }

    private static void HunterJoin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [HunterJoin_0, _ => { }]);
    }

    private static void HunterJoin_0(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HCount                                                    += 1;
        globalData.TheCostOfDiseaseVars.Ally[globalData.GetTmpValue<string>(_REFUSAL_PLAYER_TMP)] =  Faction.Hunters;
    }

    private static void JoinedAlready(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.GetTmpValue<string>(_REFUSAL_PLAYER_TMP)));
        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    #endregion Refusal Event

    #region Building Signin

    private const string _INVESTIGATE_BUILDING_INDEX  = "InvestedBuildingIndex";
    private const string _INVESTIGATE_BUILDING_PLAYER = "InvestedBuildingPlayer";

    private static void BuildingSignin(int index, GlobalData globalData)
    {
        globalData.TmpValues[_INVESTIGATE_BUILDING_INDEX] = index;
        BuildingSignin0(globalData);
    }

    private static void BuildingSignin0(GlobalData globalData)
    {
        globalData.SaveToUndo();

        BuildingS1A building = globalData.TheCostOfDiseaseVars.Gen2Buildings[globalData.GetTmpValue<int>(_INVESTIGATE_BUILDING_INDEX)];

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, (int)building));
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TmpValues[_INVESTIGATE_BUILDING_PLAYER] = playerName;
            BuildingSignin1(globalData);
        });
    }

    private static void BuildingSignin1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.GetTmpValue<string>(_INVESTIGATE_BUILDING_PLAYER), BuildPlay);
    }

    private static void BuildPlay(GlobalData globalData)
    {
        globalData.SaveToUndo();

        string      playerName    = globalData.GetTmpValue<string>(_INVESTIGATE_BUILDING_PLAYER);
        int         buildingIndex = globalData.GetTmpValue<int>(_INVESTIGATE_BUILDING_INDEX);
        BuildingS1A building      = globalData.TheCostOfDiseaseVars.Gen2Buildings[buildingIndex];
        globalData.TheCostOfDiseaseVars.BuildingPlay[playerName] += 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithReplacement(0, playerName));
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithIndex(0, (int)building)
                                                            .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1], playerName, 53))
                                                            .FormatWithIndex(2, buildingIndex));
        globalData.ActiveWindow.AddNextContentWithLinks(1, [BuildPlay_0, BuildPlay_1]);
    }

    private static void BuildPlay_0(GlobalData globalData)
    {
        string playerName    = globalData.GetTmpValue<string>(_INVESTIGATE_BUILDING_PLAYER);
        int    buildingIndex = globalData.GetTmpValue<int>(_INVESTIGATE_BUILDING_INDEX);

        globalData.TheCostOfDiseaseVars.HelpedExposeBuilding[playerName][buildingIndex] =  true;
        globalData.TheCostOfDiseaseVars.BuildingsExposeValue[buildingIndex]             += 1;
        ExposeConfirmation(globalData);
    }

    private static void ExposeConfirmation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    private static void BuildPlay_1(GlobalData globalData)
    {
        int buildingIndex = globalData.GetTmpValue<int>(_INVESTIGATE_BUILDING_INDEX);
        globalData.TheCostOfDiseaseVars.BuildingsExposeValue[buildingIndex] -= 1;
        ConcealConfirmation(globalData);
    }

    private static void ConcealConfirmation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    #endregion Building Signin

    #region Dev Event Cure

    private static void DevEventCure(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil));
        globalData.ActiveWindow.AddClickHereToContinue(DevEventCure_0);
    }

    private static void DevEventCure_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ExperimentBBack, PopUpButton.Confirm, globalData.TheCostOfDiseaseVars.RandomElement([Diseases2A, Diseases2B], 57));
    }

    private static void Diseases2A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Diseases2A_0);
    }

    private static void Diseases2A_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Confirm, globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True ? Gen1CreepyConcealExpose : _ => { });
    }

    private static void Diseases2B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Diseases2B_0);
    }

    private static void Diseases2B_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm, globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True ? Gen1CreepyConcealExpose : _ => { });
    }

    #endregion Dev Event Cure

    #region Gen 1 Creepy Conceal Expose

    private static void Gen1CreepyConcealExpose(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.TheCostOfDiseaseVars.Gen1Creep, Gen1CreepyConcealExpose_0);
    }

    private static void Gen1CreepyConcealExpose_0(GlobalData globalData)
    {
        // Wolves are evil, we are with them = 0
        // Wolves are evil, we are against them = 1
        // Hunters are evil, we are with them = 2
        // Hunters are evil, we are against them = 3
        int index = globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil
                        ? globalData.TheCostOfDiseaseVars.Ally[globalData.TheCostOfDiseaseVars.Gen1Creep] == Faction.Wolves ? 0 : 1
                        : globalData.TheCostOfDiseaseVars.Ally[globalData.TheCostOfDiseaseVars.Gen1Creep] == Faction.Hunters
                            ? 2
                            : 3;

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil)
                                                            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Gen1Creep)
                                                            .FormatWithIndex(2, index));
        globalData.ActiveWindow.AddClickHereToContinue(index is 1 or 3 ? Gen1CreepyConcealExpose_1 : _ => { });
    }

    private static void Gen1CreepyConcealExpose_1(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil) Gen1CreepyConcealExpose_1A(globalData);
        else Gen1CreepyConcealExpose_1B(globalData);
    }

    private static void Gen1CreepyConcealExpose_1A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Gen1CreepyConcealExpose_1B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Confirm, _ => { });
    }

    #endregion Gen 1 Creepy Conceal Expose

    #region Buildings End

    private static void BuildingsEnd(GlobalData globalData)
    {
        globalData.SaveToUndo();

        foreach (int exposedValue in globalData.TheCostOfDiseaseVars.BuildingsExposeValue) globalData.TheCostOfDiseaseVars.GoodCount += exposedValue > 0 ? 1 : 0;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        for (int x = 0; x < globalData.TheCostOfDiseaseVars.BuildingsExposeValue.Length; ++x)
        {
            int index = x;

            if (globalData.TheCostOfDiseaseVars.BuildingsExposeValue[x] > 0)
            {
                globalData.ActiveWindow.AddNextContent(1, true,  content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[index]));
                globalData.ActiveWindow.AddNextContent(2, false, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[index]));

                foreach (string playerName in globalData.GetActivePlayers())
                {
                    if (!globalData.TheCostOfDiseaseVars.HelpedExposeBuilding[playerName][index]) continue;
                    globalData.ActiveWindow.AddNextContent(3, false, content => content.FormatWithReplacement(0, playerName));
                }
            }
            else
            {
                globalData.ActiveWindow.AddNextContent(4, true,  content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[index]));
                globalData.ActiveWindow.AddNextContent(2, false, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Gen2Buildings[index]));
            }
        }

        globalData.ActiveWindow.AddClickHereToContinue(MostInvestigated);
    }

    private static void MostInvestigated(GlobalData globalData)
    {
        List<int> investigations = new();
        foreach (string playerName in globalData.GetActivePlayers()) investigations.Add(globalData.TheCostOfDiseaseVars.BuildingPlay[playerName]);
        investigations.Sort();
        investigations.Reverse();

        string mostInvestigations                                      = string.Empty;
        if (investigations[0] != investigations[1]) mostInvestigations = globalData.TheCostOfDiseaseVars.BuildingPlay.First(p => p.Value == investigations[0]).Key;

        if (globalData.TheCostOfDiseaseVars.Hunters == Affiliation.Evil)
        {
            globalData.TheCostOfDiseaseVars.Society = globalData.TheCostOfDiseaseVars.GoodCount < 2 ? Society.FraternityOfHunters : Society.OrderOfStHubertus;
        }
        else
        {
            globalData.TheCostOfDiseaseVars.Society = globalData.TheCostOfDiseaseVars.GoodCount > 1 ? Society.FraternityOfHunters : Society.OrderOfStHubertus;
        }

        if (string.IsNullOrEmpty(mostInvestigations))
        {
            DiseaseEnd(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, mostInvestigations)
                                                            .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Society));
        globalData.ActiveWindow.AddNextContent(1, false, content => content.FormatWithReplacement(0, mostInvestigations));
        globalData.ActiveWindow.AddClickHereToContinue(DiseaseEnd);
    }

    private static void DiseaseEnd(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DiseaseEnd_0);
    }

    private static void DiseaseEnd_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm, globalData.TheCostOfDiseaseVars.RandomElement([DiseaseEffectA, DiseaseEffectB], 58));
    }

    private static void DiseaseEffectA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DiseaseEffectA_0);
    }

    private static void DiseaseEffectA_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.MaladjustmentBack, PopUpButton.Confirm, DevastationFate1);
    }

    private static void DiseaseEffectB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DiseaseEffectB_0);
    }

    private static void DiseaseEffectB_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_DiseaseExperiment, PopUpButton.Confirm, DevastationFate1);
    }

    private static void DevastationFate1(GlobalData globalData)
    {
        globalData.SaveToUndo();

        int                index;
        Action<GlobalData> nextAction;

        if (globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters)
        {
            if (globalData.TheCostOfDiseaseVars.Hunters == Affiliation.Evil)
            {
                index      = 0;
                nextAction = HelpingEvil;
            }
            else
            {
                index      = 1;
                nextAction = ProsperityHunterIntro;
            }
        }
        else if (globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil)
        {
            index      = 2;
            nextAction = HelpingEvil;
        }
        else
        {
            index      = 3;
            nextAction = ProsperityWolvesIntro;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1, false, content => content
                                                                   .FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex())
                                                                   .FormatWithIndex(1, index));
        globalData.ActiveWindow.AddClickHereToContinue(nextAction);
    }

    private static void HelpingEvil(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Society));
        globalData.ActiveWindow.AddClickHereToContinue(HelpingEvil_0);
    }

    private static void HelpingEvil_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup,
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters ? PopUpIcon.S1_HunterToken : PopUpIcon.S1_WolfToken,
            PopUpButton.Confirm, HelpingEvil2, string.Empty);

        string  content         = globalData.GetScenarioLocalizedTag("HelpingEvil_0_Content").FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Society);
        Faction rewardedFaction = globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters ? Faction.Hunters : Faction.Wolves;

        foreach (string playerName in globalData.GetActivePlayers())
        {
            if (globalData.TheCostOfDiseaseVars.Ally[playerName] != rewardedFaction) continue;
            content += globalData.GetScenarioLocalizedTag("HelpingEvil_0_Content1")
                                 .FormatWithReplacement(0, playerName)
                                 .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Society);
        }

        globalData.ActivePopup.ReplaceDescription(content);
    }

    private static void HelpingEvil2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_EstateUpgradeBACK, PopUpButton.Confirm,
            globalData.TheCostOfDiseaseVars.Society == Society.FraternityOfHunters ? GloomyHunterIntro : GloomyWolvesIntro,
            content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Society));
    }

    #endregion Buildings End
}