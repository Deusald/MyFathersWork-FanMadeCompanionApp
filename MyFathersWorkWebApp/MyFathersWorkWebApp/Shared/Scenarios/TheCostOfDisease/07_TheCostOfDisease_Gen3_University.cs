namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _THE_BOARD_2_0_PLAYER = "TheBoard2_0_Player";

    public static void University(GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.HubId  = CostOfDiseaseHubId.University;
        globalData.TheCostOfDiseaseVars.Ending = "END-UniGood";
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

        const string       universitySection = "TheUniversity";
        GameplayHubSection theUniversity     = globalData.ActiveHub.AddSection(universitySection, true);
        theUniversity.AddDefaultContent(universitySection);

        const string       scientificSection     = "ScientificAchievement";
        GameplayHubSection scientificAchievement = globalData.ActiveHub.AddSection(scientificSection);
        scientificAchievement.AddDefaultContent(scientificSection);

        const string       vaccineSection     = "VaccinationProgram";
        GameplayHubSection vaccinationProgram = globalData.ActiveHub.AddSection(vaccineSection);
        vaccinationProgram.ReplaceShouldShow(() => globalData.Years == Years.Late);
        vaccinationProgram.AddDefaultContent(vaccineSection);

        GameplayHubSection nextRound = globalData.ActiveHub.AddSection(string.Empty);
        nextRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        nextRound.AddClickHereContinueNextRound(University_0);

        globalData.ActiveHub.AddEndOfGenerationSection(University_0);
    }

    private static void University_0(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => globalData.TheCostOfDiseaseVars.LifeCount > 0 ? d => StartDetEffectRandom(d, "UniEvent1") : UniEvent1,
            Years.Middle => globalData.TheCostOfDiseaseVars.LifeCount > 0 ? d => StartDetEffectRandom(d, "VaccinationProgram1") : VaccinationProgram1,
            Years.Late   => ResolveVaccination,
            _            => _ => { }
        });
    }

    #region Intro

    private static void UniversityIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TownName)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Pana == PanaceaVal.Unleash));
        globalData.ActiveWindow.AddClickHereToContinue(TheBoard2);
    }

    private static void TheBoard2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.HospCount > 0)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Pana is PanaceaVal.Cure or PanaceaVal.Mod));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.TheCostOfDiseaseVars.HospCount > 0 ? TheBoard2_0 : BuildAward);
    }

    private static void TheBoard2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ValidationToken, PopUpButton.Confirm, BuildAward, string.Empty);

        string desc = string.Empty;
        foreach (string name in globalData.GetActivePlayers())
        {
            if (!globalData.TheCostOfDiseaseVars.Hosp.GetValueOrDefault(name, false)) continue;
            desc += globalData.GetScenarioLocalizedTag(_THE_BOARD_2_0_PLAYER).FormatWithReplacement(0, name);
        }

        globalData.ActivePopup.ReplaceDescription(desc);
    }

    private static void BuildAward(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Mayor);
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank));
        globalData.ActiveWindow.AddClickHereToContinue(BuildAward_0);
    }

    private static void BuildAward_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_MayorCoin, PopUpButton.Confirm, LoveCharity,
            content => content
                .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mayor)
                .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank));
    }

    private static void LoveCharity(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddHandStorybookToNoJump(globalData.TheCostOfDiseaseVars.Charity);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
        globalData.ActiveWindow.AddClickHereToContinue(LoveCharity_0);
    }

    private static void LoveCharity_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Heart, PopUpButton.Confirm, PreUniversitySetup,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Charity));
    }

    private static void PreUniversitySetup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Tracker -= 2;
        if (globalData.PlayersNum >= 4) globalData.TheCostOfDiseaseVars.Tracker -= 1;

        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.Setup, PopUpIcon.AngryMobSetup1, PopUpButton.Accept, University,
            content => content
                .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Building == BankOrLibrary.Bank)
                .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Tracker.ToString())
                .FormatWithCondition(2, () => globalData.PlayersNum == 3));
    }

    #endregion Intro

    #region Round 1 Event - Department of Psychology

    private static void UniEvent1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(UniEvent2);
    }

    private static void UniEvent2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            d => SelectSanitySpace(0, d),
            d => SelectSanitySpace(1, d),
            d => SelectSanitySpace(2, d),
            d => SelectSanitySpace(3, d),
            d => SelectSanitySpace(4, d)
        ], true);
    }

    private static void SelectSanitySpace(int space, GlobalData globalData)
    {
        globalData.TheCostOfDiseaseVars.Mental = space;
        ChooseSanity(globalData);
    }

    private static void ChooseSanity(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mental.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(ChooseSanity_0);
    }

    private static void ChooseSanity_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.Insanity_Icon, PopUpButton.Confirm, UniversityEventEnd,
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Mental.ToString()));
    }

    private static void UniversityEventEnd(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    #endregion Round 1 Event - Department of Psychology

    #region Round 2 Event - Vaccination Program

    private static void VaccinationProgram1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(player =>
        {
            globalData.TheCostOfDiseaseVars.SanePlayer = player;
            VaccinationProgram1_0(globalData);
        });
    }

    private static void VaccinationProgram1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.GainExperiment_Icon, PopUpButton.Confirm, _ => { },
            content => content.FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.SanePlayer));
    }

    #endregion Round 2 Event - Vaccination Program

    #region Round 3 End - Resolve Vaccination

    private static void ResolveVaccination(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            SubVaccine,
            MedVaccine,
            UltimateVaccine
        ], true);
    }

    private static void SubVaccine(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Ultimate = false;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(SubVaccine_0);
    }

    private static void SubVaccine_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, Scoring);
    }

    private static void MedVaccine(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Ultimate = false;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(MedVaccine_0);
    }

    private static void MedVaccine_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, Scoring);
    }

    private static void UltimateVaccine(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Ultimate = true;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(UltimateVaccine_0);
    }

    private static void UltimateVaccine_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.ScoreTrackMarker, PopUpButton.Confirm, Scoring);
    }

    #endregion Round 3 End - Resolve Vaccination
}