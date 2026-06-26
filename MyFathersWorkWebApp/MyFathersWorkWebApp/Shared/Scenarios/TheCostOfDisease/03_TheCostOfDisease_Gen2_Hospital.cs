namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _HOSPITAL_NEGATIVE_0_CONTENT = "HospitalNegative_0_Content";
    private const string _NO_HOSPITAL_CONS_0_CONTENT  = "NoHospitalCons_0_Content";

    public static void Hospital(GlobalData globalData)
    {
        // Round 7 -> Hospital1
        // Round 8 -> Hospital2
        // Round 9 -> Hospital3
        globalData.TheCostOfDiseaseVars.HubId = CostOfDiseaseHubId.Hospital;
        globalData.ActiveHub                  = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(Years.Early);

        const string       boardSection    = "Board";
        GameplayHubSection boardOfTrustees = globalData.ActiveHub.AddSection(boardSection, true);
        boardOfTrustees.AddDefaultContent(boardSection);
        boardOfTrustees.AddNextContent(1, boardSection);
        boardOfTrustees.AddClickHere(HospitalVisitCheck);
        boardOfTrustees.AddNextContent(2, boardSection);

        const string       hospitalSection = "Hospital";
        GameplayHubSection hospital        = globalData.ActiveHub.AddSection(hospitalSection);
        hospital.AddDefaultContent(hospitalSection);
        hospital.AddClickHere(HospitalDefine);

        const string       cureSection = "Cure";
        GameplayHubSection cure        = globalData.ActiveHub.AddSection(cureSection);
        cure.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Cured == ExtendedBool.None);
        cure.AddDefaultContent(cureSection);
        cure.AddClickHere(YellowFeverCureSignin);

        const string       panaceaSection = "Panacea";
        GameplayHubSection panacea        = globalData.ActiveHub.AddSection(panaceaSection);
        panacea.ReplaceShouldShow(() => globalData.TheCostOfDiseaseVars.Cured == ExtendedBool.True);
        panacea.AddDefaultContent(panaceaSection);
        panacea.AddClickHere(Panacea);

        const string       immortalitySecretSection = "ImmortalitySecret";
        GameplayHubSection immortalitySecret        = globalData.ActiveHub.AddSection(immortalitySecretSection);
        immortalitySecret.ReplaceShouldShow(() => globalData.Years is Years.Middle or Years.Late && globalData.TheCostOfDiseaseVars.LifeCount != globalData.PlayersNum);
        immortalitySecret.AddDefaultContent(immortalitySecretSection);
        immortalitySecret.AddClickHere(InfinityClick1);

        const string       scientificAdvancesSection = "ScientificAdvances";
        GameplayHubSection scientificAdvances        = globalData.ActiveHub.AddSection(scientificAdvancesSection);
        scientificAdvances.ReplaceShouldShow(() => !globalData.TheCostOfDiseaseVars.SciAdv);
        scientificAdvances.AddDefaultContent(scientificAdvancesSection, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
        scientificAdvances.AddClickHereForReward(Trigger3Experiments);

        const string       victoryAheadSection = "VictoryAhead";
        GameplayHubSection victoryAhead        = globalData.ActiveHub.AddSection(victoryAheadSection);
        victoryAhead.ReplaceShouldShow(() => !globalData.TheCostOfDiseaseVars.Trigger35);
        victoryAhead.AddDefaultContent(victoryAheadSection);
        victoryAhead.AddClickHere(Trigger35Points);

        const string       symposiumSection = "Symposium";
        GameplayHubSection symposium        = globalData.ActiveHub.AddSection(symposiumSection);
        symposium.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        symposium.AddDefaultContent(symposiumSection, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
        symposium.AddNextContent(1, symposiumSection);
        symposium.AddNextContent(2, symposiumSection, false, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
        symposium.AddClickHereContinueNextRound(Hospital_0, true);

        globalData.ActiveHub.AddEndOfGenerationSection(Hospital_0);
    }

    private static void Hospital_0(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => Immortality,
            Years.Middle => SymposiumEvent1,
            Years.Late   => HospitalNegative,
            _            => _ => { }
        });
    }

    #region Intro

    private static void HospitalIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_II);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(EradicateDisease);

        globalData.TheCostOfDiseaseVars.FeverVp    = globalData.TheCostOfDiseaseVars.RandomElement([4, 5, 6, 7],   7);
        globalData.TheCostOfDiseaseVars.FeverMoney = globalData.TheCostOfDiseaseVars.RandomElement([8, 9, 10, 11], 8);
    }

    private static void EradicateDisease(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(EradicateDisease_0);
    }

    private static void EradicateDisease_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_YellowFeverInnoculation, PopUpButton.Accept, ChooseScience);
    }

    private static void ChooseScience(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Charity);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity).FormatWithReplacement(1, globalData.TownName));
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            _ => ChooseScience_0(Science.Chemistry,   globalData),
            _ => ChooseScience_0(Science.Engineering, globalData),
            _ => ChooseScience_0(Science.Biology,     globalData)
        ], true);
    }

    private static void ChooseScience_0(Science science, GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Sci3 = science;
        ThirtyFiveVp(globalData);
    }

    private static void ThirtyFiveVp(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddOnceYouAreReady(ThirtyFiveVp_0);
    }

    private static void ThirtyFiveVp_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();

        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [ThirtyFiveVp_1, ThirtyFiveVp_2], true);
    }

    private static void ThirtyFiveVp_1(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.ThirtyFiveVpCreep = true;
        Gen1InsanityYes2(globalData);
    }

    private static void ThirtyFiveVp_2(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.ThirtyFiveVpCreep = false;
        Gen1InsanityYes2(globalData);
    }

    private static void Gen1InsanityYes2(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Vacation != ExtendedBool.True)
        {
            PreHospital(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();

        globalData.ActiveWindow.AddHandStorybookTo(globalData.TheCostOfDiseaseVars.Gen1Sane, Gen1InsanityYes2_0);
    }

    private static void Gen1InsanityYes2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();

        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Sane));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.RandomBool(9) ? Gen1InsanityYes2_1 : Gen1InsanityYes2_2);
    }

    private static void Gen1InsanityYes2_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.MaladjustmentBack, PopUpButton.Accept, PreHospital);
    }

    private static void Gen1InsanityYes2_2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Accept, PreHospital);
    }

    private static void PreHospital(GlobalData globalData)
    {
        globalData.SaveToUndo();
        if (globalData.PlayersNum > 3) globalData.TheCostOfDiseaseVars.Tracker -= 1;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True ? PopUpIcon.AngryMobSetup2 : PopUpIcon.AngryMobSetup1,
            PopUpButton.Accept, Hospital, content => content
                                                    .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank)
                                                    .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Tracker.ToString())
                                                    .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True)
                                                    .FormatWithCondition(3, () => globalData.PlayersNum == 3));
    }

    #endregion Intro

    #region Hospital Visit Check

    private const string _PLAYER_HOSPITAL_VISIT_TMP = "PlayerHospitalVisit";

    private static void HospitalVisitCheck(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.TownName)
                                                            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Pub == ExtendedBool.True));
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TmpValues[_PLAYER_HOSPITAL_VISIT_TMP] = playerName;
            if (globalData.TheCostOfDiseaseVars.Hosp[playerName]) HospitalVisitReject(globalData);
            else HospitalVisitCheck2(globalData);
        }, PlayerFormatterTag.DrJr);
    }

    private static void HospitalVisitReject(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP)));
        globalData.ActiveWindow.AddClickHereToContinue(HospitalVisitReject_0);
    }

    private static void HospitalVisitReject_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void HospitalVisitCheck2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP), HospitalVisitCheck2_0);
    }

    private static void HospitalVisitCheck2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        // Those should be the same random value for a specific player
        int randomStory      = globalData.TheCostOfDiseaseVars.RandomElement([1, 2], globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP), 10);
        int innerRandomStory = globalData.TheCostOfDiseaseVars.RandomElement([1, 2], globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP), 14);

        globalData.TheCostOfDiseaseVars.HospCount                                                += 1;
        globalData.TheCostOfDiseaseVars.Hosp[globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP)] =  true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithReplacement(0, globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP)));
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddNextContent(randomStory, false, content => content
                                                                             .FormatWithReplacement(0, globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP))
                                                                             .FormatWithCondition(1, () => innerRandomStory == 1));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1InsanityNoExtraAction);
    }

    private static void Gen1InsanityNoExtraAction(GlobalData globalData)
    {
        if (globalData.GetTmpValue<string>(_PLAYER_HOSPITAL_VISIT_TMP) != globalData.TheCostOfDiseaseVars.Gen1Sane || globalData.TheCostOfDiseaseVars.Vacation != ExtendedBool.False) return;

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Sane));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1InsanityNoExtraAction_0);
    }

    private static void Gen1InsanityNoExtraAction_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.Self, PopUpButton.Accept, _ => { });
    }

    #endregion Hospital Visit Check

    #region Hospital Define

    private static void HospitalDefine(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    #endregion Hospital Define

    #region Yellow Fever Cure Signin

    private static void YellowFeverCureSignin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TheCostOfDiseaseVars.FeverCure = playerName;
            MethodUnicure(globalData);
        }, PlayerFormatterTag.DrJr);
    }

    private static void MethodUnicure(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookTo(globalData.TheCostOfDiseaseVars.FeverCure, MethodUnicure_0);
    }

    private static void MethodUnicure_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Cured = ExtendedBool.True;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();

        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Uni == ExtendedBool.False)
                                                            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.FeverCure));
        globalData.ActiveWindow.AddNextContent(1, false, content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.FeverVp.ToString()));
        globalData.ActiveWindow.AddClickHere(Unicure1);
        globalData.ActiveWindow.AddNextContent(2, false, content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.FeverMoney.ToString()));
        globalData.ActiveWindow.AddClickHere(Unicure2);
    }

    private static void Unicure1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.FeverCure));
        globalData.ActiveWindow.AddClickHereToContinue(Unicure1_0);
    }

    private static void Unicure1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Pub = ExtendedBool.True;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.AngryMob_Icon, PopUpButton.Accept, PanaceaIntro,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.FeverVp.ToString()));
    }

    private static void Unicure2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.FeverCure));
        globalData.ActiveWindow.AddClickHereToContinue(Unicure2_0);
    }

    private static void Unicure2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Pub = ExtendedBool.False;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.AngryMob_Icon, PopUpButton.Accept, PanaceaIntro,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.FeverMoney.ToString()));
    }

    #endregion Yellow Fever Cure Signin

    #region Panacea

    private static void PanaceaIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(PanaceaIntro_0);
    }

    private static void PanaceaIntro_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Pancea, PopUpButton.Accept, _ => { });
    }

    private static void Panacea(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1, true);
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TheCostOfDiseaseVars.PanaCure = playerName;
            PanaceaMessage(globalData);
        }, PlayerFormatterTag.DrJr);
    }

    private static void PanaceaMessage(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.TheCostOfDiseaseVars.PanaCure, PanaceaMessage_0);
    }

    private static void PanaceaMessage_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Cured = ExtendedBool.Complete;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContent(1, true);
        globalData.ActiveWindow.AddNextContent(2, true, null, PanaceaMessage_1);
        globalData.ActiveWindow.AddNextContent(3, true, null, globalData.Years switch
        {
            Years.Early  => PanaceaMessage_2,
            Years.Middle => PanaceaMessage_2,
            _            => PanaceaMessage_3
        });
    }

    private static void PanaceaMessage_1(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Pana = PanaceaVal.Publish;
        Panacea1(globalData);
    }

    private static void PanaceaMessage_2(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Pana = PanaceaVal.Unleash;
    }

    private static void PanaceaMessage_3(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Pana = PanaceaVal.Unleash;
        PanaceaTooOld(globalData);
    }

    private static void Panacea1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Panacea1_0);
    }

    private static void Panacea1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int points = globalData.TheCostOfDiseaseVars.RandomElement([2, 3, 4], 18);

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_Pancea, PopUpButton.Confirm, _ => { },
            content => content.FormatWithReplacement(0, points.ToString()));
    }

    private static void PanaceaTooOld(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.PanaCure));
        globalData.ActiveWindow.AddClickHereToContinue(PanaceaTooOld_0);
    }

    private static void PanaceaTooOld_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.S1_Pancea, PopUpButton.Confirm, _ => { });
    }

    private static void PanaceaUnleash(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.PanaCure == globalData.PlayerAName ? globalData.PlayerBName : globalData.PlayerAName));
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(PanaceaUnleash_0);
    }

    private static void PanaceaUnleash_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Pancea, PopUpButton.Accept, PreHospital3);
    }

    #endregion Panacea

    #region Trigger 3 Experiments

    private static void Trigger3Experiments(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithIndex(0,   (int)globalData.TheCostOfDiseaseVars.Sci3));
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TheCostOfDiseaseVars.Gen2Exp = playerName;
            globalData.TheCostOfDiseaseVars.SciAdv  = true;
            ThreeExperimentsRes(globalData);
        }, PlayerFormatterTag.DrJr);
    }

    private static void ThreeExperimentsRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen2Exp)
                                                            .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Sci3)
                                                            .FormatWithIndex(2, (int)globalData.TheCostOfDiseaseVars.Sci3));
        globalData.ActiveWindow.AddClickHereToContinue(ThreeExperimentsRes_0);
    }

    private static void ThreeExperimentsRes_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MastersStudy,
            PopUpButton.Accept, _ => { }, content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
    }

    #endregion Trigger 3 Experiments

    #region Trigger 35 Points

    private static void Trigger35Points(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Trigger35 = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.ThirtyFiveVpCreep ? Trigger35Points_A : Trigger35Points_B);
    }

    private static void Trigger35Points_A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Trigger35Points_A_0);
    }

    private static void Trigger35Points_A_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Confirm, _ => { });
    }

    private static void Trigger35Points_B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Trigger35Points_B_0);
    }

    private static void Trigger35Points_B_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Confirm, _ => { });
    }

    #endregion Trigger 35 Points

    #region Immortality

    private const string _INFINITY_COST_PLAYER_TMP = "InfinityCostPlayer";

    private static void Immortality(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Immortality_0);
    }

    private static void Immortality_0(GlobalData globalData)
    {
        Action<GlobalData> nextAction = _ => { };

        if (globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.False) nextAction     = Gen1CreepyRefuseBonus;
        else if (globalData.TheCostOfDiseaseVars.Seedy == ExtendedBool.True) nextAction = Gen1CreepyAgreedReturn;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.StorybookToken, PopUpButton.Confirm, nextAction);
    }

    private static void Gen1CreepyRefuseBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.TheCostOfDiseaseVars.Gen1Creep, Gen1CreepyRefuseBonus_0);
    }

    private static void Gen1CreepyRefuseBonus_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Creep));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Good ? Gen1CreepyRefuseBonus_1 : Gen1CreepyRefuseBonus_2);
    }

    private static void Gen1CreepyRefuseBonus_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Insanity_Icon, PopUpButton.Accept, _ => { });
    }

    private static void Gen1CreepyRefuseBonus_2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Creepy_Icon, PopUpButton.Accept, _ => { });
    }

    private static void Gen1CreepyAgreedReturn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(globalData.TheCostOfDiseaseVars.Gen1Creep, globalData.TheCostOfDiseaseVars.Wolves == Affiliation.Evil ? Gen1CreepyAgreedReturn_0 : Gen1CreepyAgreedReturn_1);
    }

    private static void Gen1CreepyAgreedReturn_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Creep));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1CreepyAgreedReturn_2);
    }

    private static void Gen1CreepyAgreedReturn_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Gen1Creep));
        globalData.ActiveWindow.AddClickHereToContinue(Gen1CreepyAgreedReturn_3);
    }

    private static void Gen1CreepyAgreedReturn_2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Accept, _ => { });
    }

    private static void Gen1CreepyAgreedReturn_3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Accept, _ => { });
    }

    private static void InfinityClick1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            globalData.TheCostOfDiseaseVars.Life[playerName] =  true;
            globalData.TheCostOfDiseaseVars.LifeCount        += 1;
            globalData.TmpValues[_INFINITY_COST_PLAYER_TMP]  =  playerName;
            InfinityClick2(globalData);
        }, PlayerFormatterTag.Dr, playerName => !globalData.TheCostOfDiseaseVars.Life[playerName]);
    }

    private static void InfinityClick2(GlobalData globalData)
    {
        string playerName = globalData.GetTmpValue<string>(_INFINITY_COST_PLAYER_TMP);
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content
                                                          .FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2, 3], playerName, 19))
                                                          .FormatWithReplacement(1, playerName));
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1], playerName, 13))
                                                            .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1], playerName, 27))
                                                            .FormatWithIndex(2, globalData.TheCostOfDiseaseVars.RandomElement([0, 1], playerName, 31)));
        globalData.ActiveWindow.AddClickHereToContinue(InfinityClick2_0);
    }

    private static void InfinityClick2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        bool showStart = false;
        bool prev      = globalData.TheCostOfDiseaseVars.SetInf;

        if (!globalData.TheCostOfDiseaseVars.SetInf)
        {
            showStart                              = true;
            globalData.TheCostOfDiseaseVars.SetInf = true;
        }

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Immortality, PopUpButton.Confirm,
            prev ? _ => { } : ImmortalityMwUpdate, content => content.FormatWithCondition(0, () => showStart));
    }

    private static void ImmortalityMwUpdate(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddYesNo(ImmortalityMwUpdate2, _ => { });
    }

    private static void ImmortalityMwUpdate2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Immort = true;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ImmortalityMwUpdate2_0);
    }

    private static void ImmortalityMwUpdate2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MWUpdateImmortality, PopUpButton.Confirm, _ => { });
    }

    #endregion Immortality

    #region Symposium Event

    private static void SymposiumEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3)
                                                            .FormatWithIndex(1, globalData.LocalizedPlayerNumberIndex()));
        globalData.ActiveWindow.AddClickHereToContinue(SymposiumEvent2);
    }

    private static void SymposiumEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Symp = globalData.PlayersNum switch
        {
            2 => globalData.TheCostOfDiseaseVars.RandomElement([3, 4],    35),
            3 => globalData.TheCostOfDiseaseVars.RandomElement([4, 5, 6], 35),
            _ => globalData.TheCostOfDiseaseVars.RandomElement([6, 7, 8], 35) // 4 players
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(content => content.FormatWithIndex(0,   (int)globalData.TheCostOfDiseaseVars.Sci3));
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3));
        globalData.ActiveWindow.AddClickHereToContinue(SymposiumEvent3);
    }

    private static void SymposiumEvent3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int superSymp = globalData.TheCostOfDiseaseVars.Symp + globalData.PlayersNum switch
        {
            4 => 3,
            _ => 2
        };

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1, false, content => content
                                                                   .FormatWithIndex(0, (int)globalData.TheCostOfDiseaseVars.Sci3)
                                                                   .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Symp.ToString()));
        globalData.ActiveWindow.AddClickHere(SymposiumFail);
        globalData.ActiveWindow.AddNextContent(2, false, content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Symp.ToString()));
        globalData.ActiveWindow.AddClickHere(SymposiumMiddle);
        globalData.ActiveWindow.AddNextContent(3, false, content => content.FormatWithReplacement(0, superSymp.ToString()));
        globalData.ActiveWindow.AddClickHere(SymposiumSuccess);
    }

    private static void SymposiumFail(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1], 36))
                                                            .FormatWithIndex(1, (int)globalData.TheCostOfDiseaseVars.Sci3));

        globalData.TheCostOfDiseaseVars.Uni = ExtendedBool.False;
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.Unleash ? PanaceaUnleash : PreHospital3);
    }

    private static void SymposiumMiddle(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
           .FormatWithIndex(0, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2], 37)));

        if (globalData.TheCostOfDiseaseVars.Pub == ExtendedBool.True)
        {
            globalData.ActiveWindow.AddNextContent(1);
            globalData.ActiveWindow.AddClickHereToContinue(SymposiumSuccess);
        }
        else
        {
            globalData.ActiveWindow.AddNextContent(2);
            globalData.ActiveWindow.AddClickHereToContinue(SymposiumFail);
        }
    }

    private static void SymposiumSuccess(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Uni = ExtendedBool.True;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.PlayerBName)
                                                            .FormatWithIndex(1, globalData.TheCostOfDiseaseVars.RandomElement([0, 1, 2, 3], 38)));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.Unleash ? PanaceaUnleash : PreHospital3);
    }

    private static void PreHospital3(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Uni != ExtendedBool.True) return;

        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.VillageChronicleCover, PopUpButton.Confirm, _ => { },
            content => content
               .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank));
    }

    #endregion Symposium Event

    #region Hospital End of Generation

    private static void HospitalNegative(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.HospCount == globalData.PlayersNum)
        {
            NoHospitalCons(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(HospitalNegative_0);
    }

    private static void HospitalNegative_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.DiscardEstateUpgrade_Icon, PopUpButton.Confirm, NoHospitalCons, string.Empty);

        string content = "";

        foreach (string name in globalData.GetActivePlayers())
        {
            if (globalData.TheCostOfDiseaseVars.Hosp[name]) continue;
            content += globalData.GetScenarioLocalizedTag(_HOSPITAL_NEGATIVE_0_CONTENT).FormatWithReplacement(0, name);
        }

        globalData.ActivePopup.ReplaceDescription(content);
    }

    private static void NoHospitalCons(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1);
        globalData.ActiveWindow.AddClickHereToContinue(NoHospitalCons_0);
    }

    private static void NoHospitalCons_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        Action<GlobalData> nextStep = globalData.TheCostOfDiseaseVars.RandomElement([S5HospA1, S5HospA2, S5HospA3], 39);

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.AdvanceJournalTrack, PopUpButton.Confirm, nextStep, string.Empty);

        string content = "";

        foreach (string name in globalData.GetActivePlayers())
        {
            if (!globalData.TheCostOfDiseaseVars.Hosp[name]) continue;
            content += globalData.GetScenarioLocalizedTag(_NO_HOSPITAL_CONS_0_CONTENT).FormatWithReplacement(0, name);
        }

        globalData.ActivePopup.ReplaceDescription(content);
    }

    private static void S5HospA1(GlobalData globalData)
    {
        int requiredLife = globalData.PlayersNum switch
        {
            2 => globalData.TheCostOfDiseaseVars.RandomElement([1, 2], 40),
            3 => globalData.TheCostOfDiseaseVars.RandomElement([2, 2], 40),
            _ => globalData.TheCostOfDiseaseVars.RandomElement([2, 3], 40) // 4 players
        };

        if (globalData.TheCostOfDiseaseVars.LifeCount >= requiredLife) HospA1Yes(globalData);
        else HospA1No(globalData);
    }

    private static void HospA1Yes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.LifeCount.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(UniversityIntro);
    }

    private static void HospA1No(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
                                                            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.LifeCount.ToString())
                                                            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Uni == ExtendedBool.True));
        globalData.ActiveWindow.AddClickHereToContinue(RippedMasterwork);
    }

    private static void S5HospA2(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Uni == ExtendedBool.True) S5HospA2_A(globalData);
        else S5HospA2_B(globalData);
    }

    private static void S5HospA2_A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(UniversityIntro);
    }

    private static void S5HospA2_B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RippedMasterwork);
    }

    private static void S5HospA3(GlobalData globalData)
    {
        if (globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.None) S5HospA3_A(globalData);
        else if (globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.Unleash) S5HospA3_B(globalData);
        else S5HospA3_C(globalData);
    }

    private static void S5HospA3_A(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RippedMasterwork);
    }

    private static void S5HospA3_B(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RippedMasterwork);
    }

    private static void S5HospA3_C(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(UniversityIntro);
    }

    private static void RippedMasterwork(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RippedMasterwork_0);
    }

    private static void RippedMasterwork_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.MFWlogo, PopUpButton.Confirm, NoUniversityIntro, content =>
            content.FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Immort));

        if (globalData.TheCostOfDiseaseVars.Immort) globalData.TheCostOfDiseaseVars.Immort = false;
    }

    #endregion Hospital End of Generation
}