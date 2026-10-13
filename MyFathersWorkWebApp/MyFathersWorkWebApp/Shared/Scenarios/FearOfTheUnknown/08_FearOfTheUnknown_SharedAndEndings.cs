namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    // =========================================================================
    // SHARED HELPERS (no UI)
    // =========================================================================

    internal static string GetRandomPlayerName(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int    idx  = Random.Shared.Next(globalData.PlayersNum);
        string name = vars.GetPlayerName(globalData, idx);
        vars.RandomPlayer = name;
        vars.RandomName   = name;
        return name;
    }

    internal static string GetDate1a(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        int day = Random.Shared.Next(1, 30);

        string[] months =
        [
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];
        string month = months[Random.Shared.Next(months.Length)];

        int yearSuffix = vars.Round switch
        {
            1  => Random.Shared.Next(831, 842),
            2  => Random.Shared.Next(842, 852),
            3  => Random.Shared.Next(852, 863),
            4  => Random.Shared.Next(863, 872),
            5  => Random.Shared.Next(872, 881),
            6  => Random.Shared.Next(881, 892),
            7  => Random.Shared.Next(863, 872),
            8  => Random.Shared.Next(872, 881),
            9  => Random.Shared.Next(881, 892),
            10 => Random.Shared.Next(892, 902),
            11 => Random.Shared.Next(902, 912),
            12 => Random.Shared.Next(912, 923),
            13 => Random.Shared.Next(892, 902),
            14 => Random.Shared.Next(902, 912),
            15 => Random.Shared.Next(912, 923),
            16 => Random.Shared.Next(892, 902),
            17 => Random.Shared.Next(902, 912),
            18 => Random.Shared.Next(912, 923),
            19 => Random.Shared.Next(892, 902),
            20 => Random.Shared.Next(902, 912),
            _  => Random.Shared.Next(912, 923)
        };

        return $"{day} {month}, 1{yearSuffix}.";
    }

    internal static string GetLetter1a(GlobalData globalData)
    {
        string[] prefixes = ["Letter from ", "Noted Letters - ", "Letter Excerpt from ", "Correspondence - "];
        string   prefix   = prefixes[Random.Shared.Next(prefixes.Length)];
        string   name     = GetRandomPlayerName(globalData);
        string   date     = GetDate1a(globalData);
        string   place    = Random.Shared.Next(2) == 0 ? string.Empty : " Romania.";
        return $"<b>{prefix}{name} - <i>{date}{place}</i></b>";
    }

    internal static string GetJournal1a(GlobalData globalData)
    {
        string[] prefixes = ["Journal Entry - ", "Journal of ", "Collected Notes - ", "Diary Entry - "];
        string   prefix   = prefixes[Random.Shared.Next(prefixes.Length)];
        string   name     = GetRandomPlayerName(globalData);
        string   date     = GetDate1a(globalData);
        return $"<b>{prefix}{name} - <i>{date}</i></b>";
    }

    /// <summary>
    /// Returns the player to whatever Hub they are currently occupying.
    /// Mirrors the original Storybook's "Click to return..." round-based routing.
    /// </summary>
    internal static void ReturnToCurrentHub(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        switch (vars.HubId)
        {
            case FearOfUnknownHubId.Mania:      Mania(globalData);      return;
            case FearOfUnknownHubId.Foreign:    Foreign(globalData);    return;
            case FearOfUnknownHubId.Creature:   Creature(globalData);   return;
            case FearOfUnknownHubId.Isolation:  Isolation(globalData);  return;
            case FearOfUnknownHubId.Tension:    Tension(globalData);    return;
            case FearOfUnknownHubId.Privatized: Privatized(globalData); return;
            case FearOfUnknownHubId.Liberal:    Liberal(globalData);    return;
        }

        if (vars.Round      <= 3)  Mania(globalData);
        else if (vars.Round <= 6)  Foreign(globalData);
        else if (vars.Round <= 9)  Creature(globalData);
        else if (vars.Round <= 12) Isolation(globalData);
        else if (vars.Round <= 15) Tension(globalData);
        else if (vars.Round <= 18) Privatized(globalData);
        else Liberal(globalData);
    }

    // =========================================================================
    // PASSAGE: HuntExplanation
    // =========================================================================

    internal static void HuntExplanation(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.Gen3Pg = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ReturnToCurrentHub);
    }

    // =========================================================================
    // PASSAGE: FOTU-Church
    // =========================================================================

    internal static void FotuChurch(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ReturnToCurrentHub);
    }

    // =========================================================================
    // PASSAGE: ObsessionFAQ
    // =========================================================================

    internal static void ObsessionFAQ(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ReturnToCurrentHub);
    }

    // =========================================================================
    // PASSAGES: Caravancheck (router) -> Caravansery
    // =========================================================================

    internal static void Caravancheck(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.IsoOff = 0;

        // The original uses (either:) lists that repeat the Hub name, giving the
        // Caravan a 1-in-4 (Gen II) or 1-in-3 (Gen III) chance of appearing.
        if (vars.Visit == 0)
        {
            if (Random.Shared.Next(4) == 0) Caravansery(globalData);
            else Foreign(globalData);
            return;
        }

        if (Random.Shared.Next(3) == 0)
        {
            Caravansery(globalData);
            return;
        }

        CaravanReturnToHub(globalData);
    }

    private static void CaravanReturnToHub(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        if (vars.Visit == 0)
        {
            Foreign(globalData);
            return;
        }

        if (vars.Visit == 1)
        {
            if (vars.Round == 10) S4Smug(globalData);
            else Isolation(globalData);
            return;
        }

        if (vars.Visit == 2)
        {
            Tension(globalData);
            return;
        }

        ReturnToCurrentHub(globalData);
    }

    internal static void Caravansery(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.CarCount++;

        string journalHeader = GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str => str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(Caravansery_Setup);
    }

    private static void Caravansery_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_MarketToken,
            PopUpButton.Accept,
            CaravanReturnToHub);
    }

    // =========================================================================
    // PASSAGES: PEWitch2 -> PEWitch2PlayerA..D -> PEExplanation1
    // Assigns each player their Obsession card based on their Family Plot fate.
    // =========================================================================

    internal static void PEWitch2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        bool   isCreature   = vars.Path4 == "PECreature";
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithCondition(0, () => isCreature));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, letterHeader)
                .FormatWithCondition(1, () => isCreature));
        globalData.ActiveWindow.AddClickHereToContinue(PEWitch2_Setup);
    }

    private static void PEWitch2_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S2_Obsession,
            PopUpButton.Accept,
            PEWitch2PlayerA);
    }

    /// <summary>
    /// 0 = FOR FAME, 1 = FOR KNOWLEDGE, 2 = FOR SCIENCE,
    /// 3 = FOR REVENGE, 4 = FOR RESPECT, 5 = FOR ENTERTAINMENT.
    /// </summary>
    private static int GetPlayerFateIndex(FearOfTheUnknownVars vars, string playerName)
    {
        if (playerName == vars.Fate1) return 0;
        if (playerName == vars.Fate2) return 1;
        if (playerName == vars.Fate3) return 2;
        if (playerName == vars.Fate4) return 3;
        if (playerName == vars.Fate5) return 4;
        return 5;
    }

    private static void ShowObsessionForPlayer(GlobalData globalData, int playerIdx, string tagBase, Action<GlobalData> next)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string playerName = vars.GetPlayerName(globalData, playerIdx);
        int    fateIdx    = GetPlayerFateIndex(vars, playerName);
        string dateStr    = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(null, tagBase);
        globalData.ActiveWindow.AddDefaultContent(
            str =>
                str
                    .FormatWithReplacement(0, playerName)
                    .FormatWithReplacement(1, dateStr)
                    .FormatWithIndex(2, fateIdx),
            tagBase);
        globalData.ActiveWindow.AddClickHereToContinue(gd =>
        {
            gd.ActivePopup = new GameplayPopup(
                gd,
                PopUpTitle.Setup,
                PopUpIcon.S2_Obsession,
                PopUpButton.Accept,
                next,
                tagBase + "_Setup_Content",
                str => str.FormatWithReplacement(0, playerName).FormatWithIndex(1, fateIdx));
        });
    }

    internal static void PEWitch2PlayerA(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowObsessionForPlayer(globalData, 0, "PEWitch2PlayerA", PEWitch2PlayerB);
    }

    internal static void PEWitch2PlayerB(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowObsessionForPlayer(globalData, 1, "PEWitch2PlayerB",
            globalData.PlayersNum > 2 ? PEWitch2PlayerC : PEExplanation1);
    }

    internal static void PEWitch2PlayerC(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowObsessionForPlayer(globalData, 2, "PEWitch2PlayerC",
            globalData.PlayersNum > 3 ? PEWitch2PlayerD : PEExplanation1);
    }

    internal static void PEWitch2PlayerD(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ShowObsessionForPlayer(globalData, 3, "PEWitch2PlayerD", PEExplanation1);
    }

    internal static void PEExplanation1(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(gd =>
        {
            if (gd.FearOfTheUnknownVars.Path4 == "PECreature") Creature(gd);
            else RevengePlot35(gd);
        });
    }

    // =========================================================================
    // PASSAGES: PEWitch3Intro -> PEWitch3 -> PEWitch3b -> PEExplanation2
    // Start-of-Generation-III Obsession evolution.
    // =========================================================================

    internal static void PEWitch3Intro(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_Obsession,
            PopUpButton.Accept,
            PEWitch3);
    }

    internal static void PEWitch3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        int pathIdx = vars.Path4 switch
        {
            "PEIsolation"  => 0,
            "PETension"    => 1,
            "PEPrivatized" => 2,
            _              => 3
        };

        // Isolation & Privatized punish an UNFINISHED Obsession;
        // Tension & Liberal punish a COMPLETED one.
        bool   punishIncomplete = pathIdx is 0 or 2;
        string letterHeader     = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithIndex(0, pathIdx));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, letterHeader)
                .FormatWithIndex(1, pathIdx));
        globalData.ActiveWindow.AddClickHereToContinue(gd =>
        {
            gd.ActivePopup = new GameplayPopup(
                gd,
                PopUpTitle.Setup,
                PopUpIcon.MaladjustmentBack,
                PopUpButton.Accept,
                PEWitch3b,
                "PEWitch3_Setup_Content",
                str => str.FormatWithCondition(0, () => punishIncomplete));
        });
    }

    internal static void PEWitch3b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        bool hasFate1 = HasFate(vars.Fate1);
        bool hasFate2 = HasFate(vars.Fate2);
        bool hasFate3 = HasFate(vars.Fate3);
        bool hasFate4 = HasFate(vars.Fate4);
        bool hasFate5 = HasFate(vars.Fate5);
        bool hasFate6 = HasFate(vars.Fate6);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Fate1)
                .FormatWithReplacement(1, vars.Fate2)
                .FormatWithReplacement(2, vars.Fate3)
                .FormatWithReplacement(3, vars.Fate4)
                .FormatWithReplacement(4, vars.Fate5)
                .FormatWithReplacement(5, vars.Fate6)
                .FormatWithCondition(6,  () => hasFate1)
                .FormatWithCondition(7,  () => hasFate2)
                .FormatWithCondition(8,  () => hasFate3)
                .FormatWithCondition(9,  () => hasFate4)
                .FormatWithCondition(10, () => hasFate5)
                .FormatWithCondition(11, () => hasFate6));
        globalData.ActiveWindow.AddClickHereToContinue(PEExplanation2);
    }

    private static bool HasFate(string fate)
    {
        return !string.IsNullOrEmpty(fate) && fate != "0" && fate != "none";
    }

    internal static void PEExplanation2(GlobalData globalData)
    {
        globalData.SaveToUndo();

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(gd =>
        {
            switch (gd.FearOfTheUnknownVars.Path4)
            {
                case "PEIsolation":  Isolation(gd);  break;
                case "PETension":    Tension(gd);    break;
                case "PEPrivatized": Privatized(gd); break;
                default:             Liberal(gd);    break;
            }
        });
    }

    // =========================================================================
    // PASSAGE: PEWitchEnding (final Obsession resolution before Scoring)
    // =========================================================================

    internal static void PEWitchEnding(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string pA = vars.GetPlayerName(globalData, 0);
        string pB = vars.GetPlayerName(globalData, 1);
        string pC = vars.GetPlayerName(globalData, 2);
        string pD = vars.GetPlayerName(globalData, 3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.ObsVp.ToString())
                .FormatWithReplacement(1, pA)
                .FormatWithReplacement(2, pB)
                .FormatWithReplacement(3, pC)
                .FormatWithReplacement(4, pD)
                .FormatWithCondition(5, () => vars.TenseBad > 1)
                .FormatWithCondition(6, () => vars.Token2A == 1)
                .FormatWithCondition(7, () => vars.Token2B == 1)
                .FormatWithCondition(8, () => vars.Token2C == 1 && globalData.PlayersNum > 2)
                .FormatWithCondition(9, () => vars.Token2D == 1 && globalData.PlayersNum > 3));
        globalData.ActiveWindow.AddClickHereToContinue(Scoring);
    }

    // =========================================================================
    // PASSAGES: Gen3Token2SignIn -> Gen3Token2 -> Gen3Token2a / Gen3Token2b
    // The "At a Crossroads" Storybook token in Generation III.
    // =========================================================================

    internal static void Gen3Token2SignIn(GlobalData globalData)
    {
        globalData.SaveToUndo();

        string dateStr   = GetDate1a(globalData);
        int    flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, dateStr)
                .FormatWithIndex(1, flavorIdx));
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(chosenName =>
        {
            globalData.FearOfTheUnknownVars.TempId = chosenName;
            Gen3Token2(globalData);
        });
    }

    internal static void Gen3Token2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string dateStr   = GetDate1a(globalData);
        int    flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr)
                .FormatWithIndex(2, flavorIdx));
        globalData.ActiveWindow.AddChoose();
        globalData.ActiveWindow.AddNextContentWithLinks(1, [Gen3Token2a], true);
        globalData.ActiveWindow.AddNextContentWithLinks(2, [Gen3Token2b], true);
    }

    internal static void Gen3Token2a(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        vars.Token2 = 1;
        if (vars.TempId      == vars.GetPlayerName(globalData, 0)) vars.Token2A = 1;
        else if (vars.TempId == vars.GetPlayerName(globalData, 1)) vars.Token2B = 1;
        else if (vars.TempId == vars.GetPlayerName(globalData, 2)) vars.Token2C = 1;
        else if (vars.TempId == vars.GetPlayerName(globalData, 3)) vars.Token2D = 1;
        else vars.Token2A = 1;

        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(ReturnToCurrentHub);
    }

    internal static void Gen3Token2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string dateStr   = GetDate1a(globalData);
        int    flavorIdx = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.TempId)
                .FormatWithReplacement(1, dateStr)
                .FormatWithIndex(2, flavorIdx));
        globalData.ActiveWindow.AddClickHereToContinue(Gen3Token2b_Setup);
    }

    private static void Gen3Token2b_Setup(GlobalData globalData)
    {
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.CompulsionBack,
            PopUpButton.Accept,
            ReturnToCurrentHub);
    }

    // =========================================================================
    // FINAL SCORING & TIE-BREAKERS
    // =========================================================================

    internal static void Scoring(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveHub = null;
        vars.HubId           = FearOfUnknownHubId.None;

        bool hasCreatureCard = vars.CreatureCard == "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str => str.FormatWithCondition(0, () => hasCreatureCard));
        globalData.ActiveWindow.AddClickHereToContinue(StartScoreEntry);
    }

    private static void StartScoreEntry(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;
        vars.ScoreEntryIndex = 0;
        for (int i = 0; i < vars.PlayerScores.Length; i++) vars.PlayerScores[i] = 0;
        FotuScoreEntry(globalData);
    }

    private static void FotuScoreEntry(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string playerName = vars.GetPlayerName(globalData, vars.ScoreEntryIndex);

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "0",
            PopUpButton.Confirm,
            value =>
            {
                if (!int.TryParse(value, out int score)) return false;
                return score is >= -100 and <= 999;
            },
            value =>
            {
                vars.PlayerScores[vars.ScoreEntryIndex] = int.Parse(value);
                vars.ScoreEntryIndex++;

                if (vars.ScoreEntryIndex < globalData.PlayersNum) FotuScoreEntry(globalData);
                else EvaluateWinner(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, playerName));
    }

    private static void EvaluateWinner(GlobalData globalData)
    {
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

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
            vars.WinnerName = vars.GetPlayerName(globalData, vars.TiedPlayers[0]);
            vars.Winner     = vars.WinnerName;
            DispatchEnding(globalData);
            return;
        }

        vars.TieBreakerIndex = 0;
        for (int i = 0; i < vars.TieBreakerMoney.Length; i++) vars.TieBreakerMoney[i] = 0;
        FotuTieBreak(globalData);
    }

    private static void FotuTieBreak(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        int currentPid = vars.TiedPlayers[vars.TieBreakerIndex];
        string   playerName = vars.GetPlayerName(globalData, currentPid);

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "0",
            PopUpButton.Confirm,
            value =>
            {
                if (!int.TryParse(value, out int money)) return false;
                return money is >= 0 and <= 999;
            },
            value =>
            {
                vars.TieBreakerMoney[currentPid] = int.Parse(value);
                vars.TieBreakerIndex++;

                if (vars.TieBreakerIndex < vars.TiedPlayers.Count)
                {
                    FotuTieBreak(globalData);
                    return;
                }

                int      maxMoney = int.MinValue;
                int winnerId = vars.TiedPlayers[0];
                foreach (int pid in vars.TiedPlayers)
                {
                    if (vars.TieBreakerMoney[pid] > maxMoney)
                    {
                        maxMoney = vars.TieBreakerMoney[pid];
                        winnerId = pid;
                    }
                }

                vars.WinnerName = vars.GetPlayerName(globalData, winnerId);
                vars.Winner     = vars.WinnerName;
                DispatchEnding(globalData);
            },
            false,
            content => content.FormatWithReplacement(0, playerName));
    }

    private static void DispatchEnding(GlobalData globalData)
    {
        switch (globalData.FearOfTheUnknownVars.Ending)
        {
            case "FOTU-End2": FotuEnd2(globalData); break;
            case "FOTU-End3": FotuEnd3(globalData); break;
            case "FOTU-End4": FotuEnd4(globalData); break;
            case "FOTU-End5": FotuEnd5(globalData); break;
            case "FOTU-End6": FotuEnd6(globalData); break;
            case "FOTU-End7": FotuEnd7(globalData); break;
            case "FOTU-End8": FotuEnd8(globalData); break;
            default:          FotuEnd1(globalData); break;
        }
    }

    // =========================================================================
    // ENDINGS: FOTU-End1 .. FOTU-End8
    // =========================================================================

    internal static void FotuEnd1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str => str.FormatWithReplacement(0, vars.Winner));
    }

    internal static void FotuEnd2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Winner)
                .FormatWithReplacement(1, globalData.TownName));
    }

    internal static void FotuEnd3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddDefaultContent(str => str.FormatWithReplacement(0, vars.Winner));
    }

    internal static void FotuEnd4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str => str.FormatWithReplacement(0, vars.Winner));
    }

    internal static void FotuEnd5(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string warriorName = vars.WarriorA.Replace("_1", string.Empty);
        if (vars.Winner      == vars.GetPlayerName(globalData, 1)) warriorName = vars.WarriorB.Replace("_2", string.Empty);
        else if (vars.Winner == vars.GetPlayerName(globalData, 2)) warriorName = vars.WarriorC.Replace("_3", string.Empty);
        else if (vars.Winner == vars.GetPlayerName(globalData, 3)) warriorName = vars.WarriorD.Replace("_4", string.Empty);

        if (string.IsNullOrEmpty(warriorName)) warriorName = "their Champion";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Winner)
                .FormatWithReplacement(1, warriorName)
                .FormatWithReplacement(2, vars.Warden)
                .FormatWithCondition(3, () => vars.Creature == 2));
    }

    internal static void FotuEnd6(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str => str.FormatWithReplacement(0, vars.Warden));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, vars.Warden)
                .FormatWithReplacement(1, vars.Winner));
    }

    internal static void FotuEnd7(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str => str.FormatWithReplacement(0, vars.Winner));
    }

    internal static void FotuEnd8(GlobalData globalData)
    {
        globalData.SaveToUndo();
        FearOfTheUnknownVars vars = globalData.FearOfTheUnknownVars;

        string author      = vars.CureCount == "yes" ? "Vlad III Dracula" : vars.Winner;
        string programName = string.IsNullOrEmpty(vars.MenName) ? "Rehabilitation" : vars.MenName;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str
                .FormatWithReplacement(0, author)
                .FormatWithReplacement(1, globalData.TownName)
                .FormatWithReplacement(2, programName));
    }
}
