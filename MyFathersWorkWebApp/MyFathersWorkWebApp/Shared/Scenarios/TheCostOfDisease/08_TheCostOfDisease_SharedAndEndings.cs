namespace MyFathersWorkWebApp;

public static partial class TheCostOfDisease
{
    private const string _DET_NEXT_TMP = "DetNext";

    #region Immortality Deterioration

    private static void StartDetEffectRandom(GlobalData globalData, string nextTarget)
    {
        globalData.TmpValues[_DET_NEXT_TMP] = nextTarget;
        DetEffectRandom(globalData);
    }

    private static void DetEffectRandom(GlobalData globalData)
    {
        List<int> unvisited = new();
        for (int i = 0; i < 4; i++)
        {
            if (!globalData.TheCostOfDiseaseVars.DetVisited[i])
            {
                unvisited.Add(i);
            }
        }

        if (unvisited.Count == 0)
        {
            DetEffectContinue(globalData);
            return;
        }

        int chosen = globalData.TheCostOfDiseaseVars.RandomElement(unvisited, 50 + unvisited.Count);
        globalData.TheCostOfDiseaseVars.DetVisited[chosen] = true;

        switch (chosen)
        {
            case 0:
                DetEffect1(globalData);
                break;
            case 1:
                DetEffect2(globalData);
                break;
            case 2:
                DetEffect3(globalData);
                break;
            default:
                DetEffect4(globalData);
                break;
        }
    }

    private static void DetEffectContinue(GlobalData globalData)
    {
        string nextTarget = (string)(globalData.TmpValues.GetValueOrDefault(_DET_NEXT_TMP, string.Empty) ?? string.Empty);
        switch (nextTarget)
        {
            case "UniEvent1":
                UniEvent1(globalData);
                break;
            case "VaccinationProgram1":
                VaccinationProgram1(globalData);
                break;
            case "ImmortalityCheck":
                ImmortalityCheck(globalData);
                break;
            case "DeteriorationHub":
                DeteriorationHub(globalData);
                break;
            case "Hub":
                break;
        }
    }

    private static void DetEffect1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DetEffect1_0);
    }

    private static void DetEffect1_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Immortality, PopUpButton.Confirm, DetEffectContinue);
    }

    private static void DetEffect2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DetEffect2_0);
    }

    private static void DetEffect2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Immortality, PopUpButton.Confirm, DetEffectContinue);
    }

    private static void DetEffect3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DetEffect3_0);
    }

    private static void DetEffect3_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Immortality, PopUpButton.Confirm, DetEffectContinue);
    }

    private static void DetEffect4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(DetEffect4_0);
    }

    private static void DetEffect4_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.S1_Immortality, PopUpButton.Confirm, DetEffectContinue);
    }

    private static void DeteriorationHub(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.DetVisited[0])
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.DetVisited[1])
            .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.DetVisited[2])
            .FormatWithCondition(3, () => globalData.TheCostOfDiseaseVars.DetVisited[3]));

        if (globalData.TheCostOfDiseaseVars.DetVisited[3] && !globalData.TheCostOfDiseaseVars.Killed)
        {
            globalData.ActiveWindow.AddNextContentWithLinks(1, [DetEffect4Killed], true);
        }

        globalData.ActiveWindow.AddClickHereToContinue(_ => { });
    }

    private static void DetEffect4Killed(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.TheCostOfDiseaseVars.Killed = true;
        globalData.ActivePopup = new GameplayPopup(globalData, PopUpTitle.SpecialSetup, PopUpIcon.GainBody_Icon, PopUpButton.Confirm, DeteriorationHub);
    }

    #endregion Immortality Deterioration

    #region Final Scoring and Tie-Breakers

    private static void Scoring(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Lycan)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Immort));
        globalData.ActiveWindow.AddClickHereToContinue(ScoreEntryP1);
    }

    private static void ScoreEntryP1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveInputPopup = new GameplayInputPopup(globalData, "0", PopUpButton.Confirm,
            val => int.TryParse(val, out int s) && s >= 0 && s <= 500,
            val =>
            {
                globalData.TheCostOfDiseaseVars.Scores[globalData.PlayerAName] = int.Parse(val);
                ScoreEntryP1Confirm(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, globalData.PlayerAName));
    }

    private static void ScoreEntryP1Confirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.PlayerAName));
        globalData.ActiveWindow.AddClickHereToContinue(ScoreEntryP2);
    }

    private static void ScoreEntryP2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveInputPopup = new GameplayInputPopup(globalData, "0", PopUpButton.Confirm,
            val => int.TryParse(val, out int s) && s >= 0 && s <= 500,
            val =>
            {
                globalData.TheCostOfDiseaseVars.Scores[globalData.PlayerBName] = int.Parse(val);
                ScoreEntryP2Confirm(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, globalData.PlayerBName));
    }

    private static void ScoreEntryP2Confirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.PlayerBName));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.PlayersNum >= 3 ? ScoreEntryP3 : WinnerHUB);
    }

    private static void ScoreEntryP3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveInputPopup = new GameplayInputPopup(globalData, "0", PopUpButton.Confirm,
            val => int.TryParse(val, out int s) && s >= 0 && s <= 500,
            val =>
            {
                globalData.TheCostOfDiseaseVars.Scores[globalData.PlayerCName] = int.Parse(val);
                ScoreEntryP3Confirm(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, globalData.PlayerCName));
    }

    private static void ScoreEntryP3Confirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.PlayerCName));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.PlayersNum >= 4 ? ScoreEntryP4 : WinnerHUB);
    }

    private static void ScoreEntryP4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveInputPopup = new GameplayInputPopup(globalData, "0", PopUpButton.Confirm,
            val => int.TryParse(val, out int s) && s >= 0 && s <= 500,
            val =>
            {
                globalData.TheCostOfDiseaseVars.Scores[globalData.PlayerDName] = int.Parse(val);
                ScoreEntryP4Confirm(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, globalData.PlayerDName));
    }

    private static void ScoreEntryP4Confirm(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.PlayerDName));
        globalData.ActiveWindow.AddClickHereToContinue(WinnerHUB);
    }

    private static void WinnerHUB(GlobalData globalData)
    {
        string[] activePlayers = globalData.GetActivePlayers();
        int maxScore = activePlayers.Max(p => globalData.TheCostOfDiseaseVars.Scores.GetValueOrDefault(p, 0));
        List<string> tied = activePlayers.Where(p => globalData.TheCostOfDiseaseVars.Scores.GetValueOrDefault(p, 0) == maxScore).ToList();

        globalData.TheCostOfDiseaseVars.TiedPlayers = tied;
        foreach (string p in activePlayers)
        {
            globalData.TheCostOfDiseaseVars.TieSelection[p] = false;
        }

        if (tied.Count == 1)
        {
            globalData.TheCostOfDiseaseVars.Winner = tied[0];
            WinnerDisplay(globalData);
        }
        else
        {
            TieBreakerMasterwork(globalData);
        }
    }

    private static void TieBreakerMasterwork(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, string.Join(", ", globalData.TheCostOfDiseaseVars.TiedPlayers)));
        globalData.ActiveWindow.AddYesNo(TieBreakerUpgrades, TieBreakerMasterworkSelect);
    }

    private static void TieBreakerMasterworkSelect(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(
            p =>
            {
                globalData.TheCostOfDiseaseVars.Winner = p;
                WinnerDisplay(globalData);
            },
            PlayerFormatterTag.None,
            globalData.TheCostOfDiseaseVars.TiedPlayers.Contains);

        // "They are still tied / nobody qualifies" -> fall through to the next tie-breaker.
        globalData.ActiveWindow.AddNextContentWithLinks(1, [TieBreakerUpgrades], true);
    }

    private static void TieBreakerUpgrades(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(
            p =>
            {
                globalData.TheCostOfDiseaseVars.Winner = p;
                WinnerDisplay(globalData);
            },
            PlayerFormatterTag.None,
            globalData.TheCostOfDiseaseVars.TiedPlayers.Contains);

        globalData.ActiveWindow.AddNextContentWithLinks(1, [
            _ =>
            {
                globalData.TheCostOfDiseaseVars.Winner = "the family";
                WinnerDisplay(globalData);
            }
        ], true);
    }

    private static void WinnerDisplay(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var ranked = globalData.GetActivePlayers()
            .Select(p => (Name: p, Score: globalData.TheCostOfDiseaseVars.Scores.GetValueOrDefault(p, 0)))
            .OrderByDescending(x => x.Score)
            .ToList();

        string standings = string.Join("<br />", ranked.Select((r, idx) => $"<b>{idx + 1}. {r.Name}</b>: {r.Score} VP"));

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, standings)
            .FormatWithReplacement(1, globalData.TheCostOfDiseaseVars.Winner));
        globalData.ActiveWindow.AddClickHereToContinue(DispatchEnding);
    }

    private static void DispatchEnding(GlobalData globalData)
    {
        switch (globalData.TheCostOfDiseaseVars.Ending)
        {
            case "END-WolvesEvil1":
                END_WolvesEvil1(globalData);
                break;
            case "END-WolvesEvil2":
                END_WolvesEvil2(globalData);
                break;
            case "END-HuntersEvil1":
                END_HuntersEvil1(globalData);
                break;
            case "END-HuntersEvil2":
                END_HuntersEvil2(globalData);
                break;
            case "END-WolvesGood1":
                END_WolvesGood1(globalData);
                break;
            case "END-HunterGood1":
                END_HunterGood1(globalData);
                break;
            case "END-NoUniGood":
                END_NoUniGood(globalData);
                break;
            case "END-UniGood":
            default:
                END_UniGood(globalData);
                break;
        }
    }

    #endregion Final Scoring and Tie-Breakers

    #region Endings

    private static void END_WolvesEvil1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Winner)
            .FormatWithReplacement(1, globalData.TownName));
    }

    private static void END_WolvesEvil2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
    }

    private static void END_HuntersEvil1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Winner)
            .FormatWithReplacement(1, globalData.TownName));
    }

    private static void END_HuntersEvil2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithIndex(0, globalData.LocalizedPlayerNumberIndex())
            .FormatWithReplacement(1, globalData.TownName));
    }

    private static void END_WolvesGood1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Winner)
            .FormatWithReplacement(1, globalData.TownName));
    }

    private static void END_HunterGood1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Winner)
            .FormatWithReplacement(1, globalData.TownName));
    }

    private static void END_NoUniGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithReplacement(0, globalData.TheCostOfDiseaseVars.Winner)
            .FormatWithReplacement(1, globalData.TownName));
    }

    private static void END_UniGood(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content
            .FormatWithCondition(0, () => globalData.TheCostOfDiseaseVars.Cured != ExtendedBool.None)
            .FormatWithCondition(1, () => globalData.TheCostOfDiseaseVars.Uni == ExtendedBool.True)
            .FormatWithCondition(2, () => globalData.TheCostOfDiseaseVars.Ultimate)
            .FormatWithReplacement(3, globalData.TownName));
    }

    #endregion Endings
}
