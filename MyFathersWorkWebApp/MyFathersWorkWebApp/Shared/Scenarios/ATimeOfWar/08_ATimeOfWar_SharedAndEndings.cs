namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    public static void UniGen3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.PgGen3 = 1;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Caretaker,
            PopUpButton.Accept,
            _ => { },
            "ATOW_UniGen3_Content",
            text => text.FormatWithCondition(0, () => globalData.ATimeOfWarVars.Round is 10 or 11 or 12));
    }

    public static void AtowChurch(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.LoseCreepy,
            PopUpButton.Accept,
            _ => { },
            "ATOW_Church_Content");
    }

    public static void Scoring(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveHub            = null;
        globalData.ATimeOfWarVars.HubId = TimeOfWarHubId.None;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithCondition(0, () => globalData.ATimeOfWarVars.TmMasterwork == "yes"));
        globalData.ActiveWindow.AddClickHereToContinue(StartScoreEntry);
    }

    private static void StartScoreEntry(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.ScoreEntryIndex = 0;
        for (int i = 0; i < vars.PlayerScores.Length; i++)
        {
            vars.PlayerScores[i] = 0;
        }
        PlayerScoreName(globalData);
    }

    private static void PlayerScoreName(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        string playerName = vars.GetDisplayPlayerName(globalData, vars.ScoreEntryIndex);

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "0",
            PopUpButton.Confirm,
            value => int.TryParse(value, out int score) && score is >= -100 and <= 999,
            value =>
            {
                vars.PlayerScores[vars.ScoreEntryIndex] = int.Parse(value);
                vars.ScoreEntryIndex++;

                if (vars.ScoreEntryIndex < globalData.PlayersNum) PlayerScoreName(globalData);
                else EvaluateWinner(globalData);
            },
            false,
            text => text.FormatWithReplacement(0, playerName));
    }

    private static void EvaluateWinner(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int maxScore = int.MinValue;
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.PlayerScores[i] > maxScore) maxScore = vars.PlayerScores[i];
        }

        vars.TiedPlayers.Clear();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.PlayerScores[i] == maxScore) vars.TiedPlayers.Add(i);
        }

        if (vars.TiedPlayers.Count == 1)
        {
            vars.WinnerName = vars.GetDisplayPlayerName(globalData, vars.TiedPlayers[0]);
            WinnerHUB(globalData);
        }
        else
        {
            WinnerHUBproblem(globalData);
        }
    }

    private static void WinnerHUBproblem(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        // Only the tied players are offered as options; everyone else is filtered out.
        HashSet<string> tiedNames = vars.TiedPlayers
            .Select(pid => globalData.GetPlayerNameByIndex(pid))
            .ToHashSet();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(
            name =>
            {
                globalData.ATimeOfWarVars.WinnerName = name;
                WinnerHUB(globalData);
            },
            PlayerFormatterTag.None,
            tiedNames.Contains);
        globalData.ActiveWindow.AddNextContent(1, true, null, StartMoneyTieBreaker);
    }

    private static void StartMoneyTieBreaker(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.TieBreakerIndex = 0;
        for (int i = 0; i < vars.TieBreakerMoney.Length; i++)
        {
            vars.TieBreakerMoney[i] = 0;
        }
        PromptNextTieBreakerMoney(globalData);
    }

    private static void PromptNextTieBreakerMoney(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int    currentPid = vars.TiedPlayers[vars.TieBreakerIndex];
        string playerName = vars.GetDisplayPlayerName(globalData, currentPid);

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "0",
            PopUpButton.Confirm,
            value => int.TryParse(value, out int money) && money is >= 0 and <= 999,
            value =>
            {
                vars.TieBreakerMoney[currentPid] = int.Parse(value);
                vars.TieBreakerIndex++;

                if (vars.TieBreakerIndex < vars.TiedPlayers.Count) PromptNextTieBreakerMoney(globalData);
                else ResolveMoneyTieBreaker(globalData);
            },
            false,
            text => text.FormatWithReplacement(0, playerName));
    }

    private static void ResolveMoneyTieBreaker(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int maxMoney = int.MinValue;
        foreach (int pid in vars.TiedPlayers)
        {
            if (vars.TieBreakerMoney[pid] > maxMoney) maxMoney = vars.TieBreakerMoney[pid];
        }

        List<int> stillTied = vars.TiedPlayers
            .Where(pid => vars.TieBreakerMoney[pid] == maxMoney)
            .ToList();

        int chosen = stillTied[Random.Shared.Next(stillTied.Count)];
        vars.WinnerName = vars.GetDisplayPlayerName(globalData, chosen);
        WinnerHUB(globalData);
    }

    private static void WinnerHUB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(text => text.FormatWithReplacement(0, vars.WinnerName));
        globalData.ActiveWindow.AddClickHereToContinue(ShowEnding);
    }

    public static void ShowEnding(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName))
        {
            vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);
        }

        switch (vars.Ending)
        {
            case "ATOW-End1":
                EndAtow1(globalData);
                break;
            case "ATOW-End2":
                EndAtow2(globalData);
                break;
            case "ATOW-End3":
                EndAtow3(globalData);
                break;
            case "ATOW-End4":
                EndAtow4(globalData);
                break;
            case "ATOW-End5":
                EndAtow5(globalData);
                break;
            case "ATOW-End6":
                EndAtow6(globalData);
                break;
            case "ATOW-End7":
                EndAtow7(globalData);
                break;
            case "ATOW-End8":
                EndAtow8(globalData);
                break;
            default:
                EndAtow1(globalData);
                break;
        }
    }

    public static void EndAtow1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName)) vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);

        string[] giantThings =
        {
            "Giant Spider Chariot",
            "Giant Love Potion",
            "Giant Teleportation Device"
        };
        string giantThing = giantThings[Random.Shared.Next(giantThings.Length)];

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text
                .FormatWithReplacement(0, vars.WinnerName)
                .FormatWithReplacement(2, giantThing)
                .FormatWithCondition(1, () => vars.Release >= 1));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName)) vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text
                .FormatWithReplacement(0, globalData.TownName)
                .FormatWithReplacement(1, vars.WinnerName));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithReplacement(0, vars.WarWinner));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow5(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName)) vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);

        int barracksVariant = vars.Barracks == "yes"
            ? (vars.EndChange == "yes" ? 0 : 1)
            : (vars.EndChange == "yes" ? 2 : 3);
        int persuadeVariant = vars.EndChange == "yes"
            ? (vars.WarDestroy > 0 ? 0 : 1)
            : 2;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text
                .FormatWithReplacement(0, globalData.TownName)
                .FormatWithReplacement(1, vars.WinnerName)
                .FormatWithIndex(2, barracksVariant)
                .FormatWithCondition(3, () => vars.EndChange == "yes")
                .FormatWithIndex(4, persuadeVariant)
                .FormatWithCondition(5, () => vars.Benevolent == "good"));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow6(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName)) vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text.FormatWithReplacement(0, vars.WinnerName));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow7(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName)) vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);

        string[] inventions =
        {
            "Tiger Launcher",
            "Psychic Mindbomb",
            "Irresistible Aphrodisiac",
            "Helmet-Mounted Flamethrower",
            "Steam Grenade",
            "Remote Controlled Plague Rat Swarm",
            "Flaming Pitchfork",
            "Mechanized Human Armor Suit",
            "Dream Stealer"
        };
        string invention = inventions[Random.Shared.Next(inventions.Length)];
        string meatName = string.IsNullOrEmpty(vars.NewMeat) ? "Soylent Ration" : vars.NewMeat;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text
                .FormatWithReplacement(0, globalData.TownName)
                .FormatWithReplacement(1, vars.WinnerName)
                .FormatWithReplacement(2, meatName)
                .FormatWithReplacement(3, invention));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    public static void EndAtow8(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (string.IsNullOrEmpty(vars.WinnerName)) vars.WinnerName = vars.GetDisplayPlayerName(globalData, 0);

        int peaceVariant = vars.PeaceCount == 1
            ? (vars.Peac == 2 ? 0 : 1)
            : 2;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            text => text
                .FormatWithReplacement(0, vars.WinnerName)
                .FormatWithIndex(1, peaceVariant));
        globalData.ActiveWindow.AddClickHereToContinue(FinalCredits);
    }

    private static void FinalCredits(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContent(1, true, null, ReturnToMainMenu);
    }

    private static void ReturnToMainMenu(GlobalData globalData)
    {
        globalData.ResetUndo();
        globalData.ActiveHub        = null;
        globalData.ActiveWindow     = null;
        globalData.ActivePopup      = null;
        globalData.ActiveInputPopup = null;
        globalData.ATimeOfWarVars.Reset(globalData);
    }
}
