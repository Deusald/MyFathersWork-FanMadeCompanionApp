namespace MyFathersWorkWebApp;

public static partial class FearOfTheUnknown
{
    public static void Init(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.FearOfTheUnknownVars.Reset(globalData);
        globalData.Generation = Generation.First;
        globalData.Years = Years.Early;
        globalData.ActiveHub = null;
        ScenarioBox_FOTU(globalData);
    }

    private static void ScenarioBox_FOTU(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { Prologue_FOTU }, true);
    }

    private static void Prologue_FOTU(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.CityName));
        globalData.ActiveWindow.AddClickHereToContinue(FearoftheUnknownStart);
    }

    private static void FearoftheUnknownStart(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.RandomName = GetRandomPlayerName(globalData);
        vars.RandomPlayer = vars.RandomName;
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_I);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName)
               .FormatWithReplacement(1, dateStr)
               .FormatWithReplacement(2, globalData.CityName));
        globalData.ActiveWindow.AddClickHereToContinue(ManiaSpecial);
    }

    private static void ManiaSpecial(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.RandomName = GetRandomPlayerName(globalData);
        vars.RandomPlayer = vars.RandomName;
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(ManiaSpecial_0);
    }

    private static void ManiaSpecial_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.StorybookToken,
            PopUpButton.Accept,
            Mania_Setup);
    }

    private static void Mania_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.Whpg == 0)
        {
            vars.Whpg = 1;
            vars.Tracker = globalData.PlayersNum switch
            {
                2 => 6,
                3 => Random.Shared.Next(6, 8),
                4 => Random.Shared.Next(7, 10),
                _ => Random.Shared.Next(8, 11)
            };
            vars.RandomName = GetRandomPlayerName(globalData);
            vars.RandomPlayer = vars.RandomName;
        }

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.AngryMobSetup1,
            PopUpButton.Accept,
            Mania,
            str => str.FormatWithReplacement(0, vars.Tracker.ToString())
                      .FormatWithReplacement(1, vars.RandomName));
    }

    public static void Mania(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.HubId = FearOfUnknownHubId.Mania;
        vars.Round = globalData.Years == Years.Early ? 1 : globalData.Years == Years.Middle ? 2 : 3;

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        // Late Years: PARANOIA - Town Hall
        GameplayHubSection paranoia = globalData.ActiveHub.AddSection("Paranoia", true);
        paranoia.ReplaceShouldShow(() => globalData.Years == Years.Late);
        paranoia.AddDefaultContent("Paranoia");

        // All Years: Family Plot
        GameplayHubSection familyPlot = globalData.ActiveHub.AddSection("FamilyPlot", true);
        familyPlot.AddDefaultContent("FamilyPlot");
        familyPlot.AddClickHere(PlotPlayerCheckin);

        // Achievement: 10VP
        GameplayHubSection fp10vp = globalData.ActiveHub.AddSection("Fp10vp", true);
        fp10vp.ReplaceShouldShow(() => vars.Fp10Vp == 0);
        fp10vp.AddDefaultContent("Fp10vp");
        fp10vp.AddClickHere(Fp10vp);

        // Achievement: Research Level 2
        GameplayHubSection fpResearch2 = globalData.ActiveHub.AddSection("FpResearch2", true);
        fpResearch2.ReplaceShouldShow(() => vars.FpResearch2 == 0);
        fpResearch2.AddDefaultContent("FpResearch2");
        fpResearch2.AddClickHere(FpResearch2);

        // Achievement: Insanity of 3
        GameplayHubSection fpSanity3 = globalData.ActiveHub.AddSection("FpSanity3", true);
        fpSanity3.ReplaceShouldShow(() => vars.FpSanity3 == 0);
        fpSanity3.AddDefaultContent("FpSanity3");
        fpSanity3.AddClickHere(FpSanity3);

        // Achievement: Creepy of 3
        GameplayHubSection fpCreepy3 = globalData.ActiveHub.AddSection("FpCreepy3", true);
        fpCreepy3.ReplaceShouldShow(() => vars.FpCreepy3 == 0);
        fpCreepy3.AddDefaultContent("FpCreepy3");
        fpCreepy3.AddClickHere(FpCreepy3);

        // Early & Middle Years: Second Round Event & Next Round Link
        GameplayHubSection secondRound = globalData.ActiveHub.AddSection("SecondRoundEvent", true);
        secondRound.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        secondRound.AddDefaultContent("SecondRoundEvent");
        secondRound.AddClickHereContinueNextRound(Mania_EndRound, true);

        // Late Years: End of Generation
        if (globalData.Years == Years.Late)
        {
            globalData.ActiveHub.AddEndOfGenerationSection(Mania_EndRound);
        }
    }

    private static void Mania_EndRound(GlobalData globalData)
    {
        if (globalData.Years == Years.Early)
        {
            globalData.ShowEndOfRoundPopUp(Mania);
        }
        else if (globalData.Years == Years.Middle)
        {
            globalData.ShowEndOfRoundPopUp(S4Kill1);
        }
        else
        {
            FPFateHub(globalData);
        }
    }

    // ==========================================
    // FAMILY PLOT & FATE HUB PASSAGES
    // ==========================================

    private static void PlotPlayerCheckin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddAllPlayersNamesAsOptions(playerName =>
        {
            vars.TempPlot = playerName;
            vars.Whpg = 1;
            GainFamilyPlot(globalData);
        });
    }

    private static void GainFamilyPlot(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string letterHeader = GetLetter1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, letterHeader));
        globalData.ActiveWindow.AddClickHereToContinue(GainFamilyPlot_0);
    }

    private static void GainFamilyPlot_0(GlobalData globalData)
    {
        var vars = globalData.FearOfTheUnknownVars;
        vars.Mobbed = "yes";
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.TempPlot == globalData.PlayersName[i])
            {
                vars.SetPlot(i, "yes");
            }
        }
        Mania(globalData);
    }

    private static void Fp10vp(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.OneCount >= globalData.PlayersNum)
        {
            vars.Fp10Vp = 1;
            FP1OverBonus(globalData);
            return;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            int idx = i;
            string pName = globalData.PlayersName[idx];
            globalData.ActiveWindow.Elements.Add(new GameplayElement(pName, gd =>
            {
                var v = gd.FearOfTheUnknownVars;
                if (v.GetConfirm(idx) == 0)
                {
                    v.Fp10Vp = 1;
                    v.SetConfirm(idx, 1);
                    v.SetPl(idx, 1);
                    v.TempName = pName;
                    FP10VPsignin(gd);
                }
                else
                {
                    v.TempName = pName;
                    FPNo(gd);
                }
            }, true));
        }
    }

    private static void FP10VPsignin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(FP10VPsignin_0);
    }

    private static void FP10VPsignin_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.OneCount += 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            Mania,
            "FP10VPsignin_0_Content");
    }

    private static void FpResearch2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.OneCount >= globalData.PlayersNum)
        {
            vars.FpResearch2 = 1;
            FP1OverBonus(globalData);
            return;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            int idx = i;
            string pName = globalData.PlayersName[idx];
            globalData.ActiveWindow.Elements.Add(new GameplayElement(pName, gd =>
            {
                var v = gd.FearOfTheUnknownVars;
                if (v.GetConfirm(idx) == 0)
                {
                    v.FpResearch2 = 1;
                    v.SetConfirm(idx, 1);
                    v.SetPl(idx, 2);
                    v.TempName = pName;
                    FPResearch2signin(gd);
                }
                else
                {
                    v.TempName = pName;
                    FPNo(gd);
                }
            }, true));
        }
    }

    private static void FPResearch2signin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(FPResearch2signin_0);
    }

    private static void FPResearch2signin_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.OneCount += 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.StorybookToken,
            PopUpButton.Accept,
            Mania,
            "FP10VPsignin_0_Content");
    }

    private static void FpSanity3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.OneCount >= globalData.PlayersNum)
        {
            vars.FpSanity3 = 1;
            FP1OverBonus(globalData);
            return;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            int idx = i;
            string pName = globalData.PlayersName[idx];
            globalData.ActiveWindow.Elements.Add(new GameplayElement(pName, gd =>
            {
                var v = gd.FearOfTheUnknownVars;
                if (v.GetConfirm(idx) == 0)
                {
                    v.FpSanity3 = 1;
                    v.SetConfirm(idx, 1);
                    v.SetPl(idx, 3);
                    v.TempName = pName;
                    FPSanity3signin(gd);
                }
                else
                {
                    v.TempName = pName;
                    FPNo(gd);
                }
            }, true));
        }
    }

    private static void FPSanity3signin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(FPSanity3signin_0);
    }

    private static void FPSanity3signin_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.OneCount += 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            Mania,
            "FP10VPsignin_0_Content");
    }

    private static void FpCreepy3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.OneCount >= globalData.PlayersNum)
        {
            vars.FpCreepy3 = 1;
            FP1OverBonus(globalData);
            return;
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            int idx = i;
            string pName = globalData.PlayersName[idx];
            globalData.ActiveWindow.Elements.Add(new GameplayElement(pName, gd =>
            {
                var v = gd.FearOfTheUnknownVars;
                if (v.GetConfirm(idx) == 0)
                {
                    v.FpCreepy3 = 1;
                    v.SetConfirm(idx, 1);
                    v.SetPl(idx, 4);
                    v.TempName = pName;
                    FPCreepy3signin(gd);
                }
                else
                {
                    v.TempName = pName;
                    FPNo(gd);
                }
            }, true));
        }
    }

    private static void FPCreepy3signin(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(FPCreepy3signin_0);
    }

    private static void FPCreepy3signin_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.OneCount += 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Accept,
            Mania,
            "FP10VPsignin_0_Content");
    }

    private static void FPNo(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.TempName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(FPNo_0);
    }

    private static void FPNo_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Accept,
            Mania);
    }

    private static void FP1OverBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(FP1OverBonus_0);
    }

    private static void FP1OverBonus_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.OneCount += 1;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.StorybookToken,
            PopUpButton.Accept,
            Mania);
    }

    // ==========================================
    // SECOND ROUND EVENT: S4Kill1 -> Blacksmith / Butcher
    // ==========================================

    private static void S4Kill1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Whpg = 0;
        vars.RandomName = GetRandomPlayerName(globalData);
        vars.RandomPlayer = vars.RandomName;
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, vars.RandomName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(
            globalData.PlayersNum == 2 ? TwoPS4Kill2 : S4Kill2);
    }

    private static void S4Kill2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(S4Kill3);
    }

    private static void S4Kill3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { S4Blacksmith, S4Butcher }, true);
    }

    private static void TwoPS4Kill2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereAfterBid(TwoPS4Kill2b);
    }

    private static void TwoPS4Kill2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(0, new List<Action<GlobalData>?> { S4Blacksmith, S4Butcher }, true);
    }

    private static void S4Blacksmith(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Kill = "blacksmith";
        vars.Warden = "The Butcher";
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(
            globalData.PlayersNum >= 3 ? S4Blacksmith_0 : Mania3_Setup);
    }

    private static void S4Blacksmith_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.VotingTokenNay,
            PopUpButton.Accept,
            Mania3_Setup);
    }

    private static void S4Butcher(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Kill = "butcher";
        vars.Warden = "The Bloodsmith";
        string dateStr = GetDate1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, globalData.NewspaperName)
               .FormatWithReplacement(1, dateStr));
        globalData.ActiveWindow.AddClickHereToContinue(
            globalData.PlayersNum >= 3 ? S4Butcher_0 : Mania3_Setup);
    }

    private static void S4Butcher_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.VotingTokenYay,
            PopUpButton.Accept,
            Mania3_Setup);
    }

    private static void Mania3_Setup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        vars.Whpg = 1;
        string pageNum = vars.Kill == "blacksmith" ? "3" : "2";
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Accept,
            Mania,
            str => str.FormatWithReplacement(0, pageNum));
    }

    // ==========================================
    // END OF GENERATION 1: FPFateHub -> Mobbed2 -> S4Witch1 / S4Witch2
    // ==========================================

    private static void FPFateHub(GlobalData globalData)
    {
        var vars = globalData.FearOfTheUnknownVars;
        List<int> available = new() { 1, 2, 3, 4, 5, 6 };
        if (vars.Fp10Vp == 1) available.Remove(1);
        if (vars.FpResearch2 == 1) available.Remove(2);
        if (vars.FpSanity3 == 1) available.Remove(3);
        if (vars.FpCreepy3 == 1) available.Remove(4);

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.GetPl(i) == 0 && available.Count > 0)
            {
                int pickIdx = Random.Shared.Next(available.Count);
                vars.SetPl(i, available[pickIdx]);
                available.RemoveAt(pickIdx);
            }
        }

        FPFateAssignHub(globalData);
    }

    private static void FPFateAssignHub(GlobalData globalData)
    {
        var vars = globalData.FearOfTheUnknownVars;
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            string pName = globalData.PlayersName[i];
            int fate = vars.GetPl(i);
            if (fate >= 1 && fate <= 6)
            {
                vars.SetFate(fate, pName);
            }
        }

        if (string.IsNullOrEmpty(vars.FPFateAssignHubNextPsg) || vars.FPFateAssignHubNextPsg == "0")
        {
            vars.FPFateAssignHubNextPsg = Random.Shared.Next(2) == 0 ? "S4Witch1" : "S4Witch2";
        }
        vars.Mobbed2NextPsg = vars.FPFateAssignHubNextPsg;

        if (vars.Mobbed == "yes")
        {
            Mobbed2(globalData);
        }
        else
        {
            RouteToWitchEnding(globalData);
        }
    }

    private static void Mobbed2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        string journalHeader = GetJournal1a(globalData);
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, journalHeader));
        globalData.ActiveWindow.AddClickHereToContinue(Mobbed2_0);
    }

    private static void Mobbed2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        List<string> plotHolders = new();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (vars.GetPlot(i) == "yes")
            {
                plotHolders.Add(globalData.PlayersName[i]);
            }
        }
        string holdersText = string.Join(", ", plotHolders);

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S2_EstateUpgradeBACK,
            PopUpButton.Accept,
            RouteToWitchEnding,
            str => str.FormatWithReplacement(0, holdersText));
    }

    private static void RouteToWitchEnding(GlobalData globalData)
    {
        var vars = globalData.FearOfTheUnknownVars;
        if (vars.Mobbed2NextPsg == "S4Witch2")
        {
            S4Witch2_EndGenPopup(globalData);
        }
        else
        {
            S4Witch1_EndGenPopup(globalData);
        }
    }

    private static void S4Witch1_EndGenPopup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            S4Witch1,
            "Mania_EndGen_Popup_Content",
            str => str.FormatWithCondition(0, () => vars.OneCount < 4));
    }

    private static void S4Witch1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        bool isButcher = vars.Kill == "butcher";
        string headerStr = isButcher ? GetLetter1a(globalData) : GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str =>
            str.FormatWithCondition(0, () => isButcher));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, headerStr)
               .FormatWithCondition(1, () => isButcher));
        globalData.ActiveWindow.AddClickHereToContinue(
            isButcher ? ForeignIntro : CreatureIntro);
    }

    private static void S4Witch2_EndGenPopup(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.EndOfGeneration,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            S4Witch2,
            "Mania_EndGen_Popup_Content",
            str => str.FormatWithCondition(0, () => vars.OneCount < 4));
    }

    private static void S4Witch2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        var vars = globalData.FearOfTheUnknownVars;
        bool noMobbed = vars.Mobbed == "no";
        string headerStr = noMobbed ? GetLetter1a(globalData) : GetJournal1a(globalData);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(str =>
            str.FormatWithCondition(0, () => noMobbed));
        globalData.ActiveWindow.AddDefaultContent(str =>
            str.FormatWithReplacement(0, headerStr)
               .FormatWithCondition(1, () => noMobbed));
        globalData.ActiveWindow.AddClickHereToContinue(
            noMobbed ? ForeignIntro : CreatureIntro);
    }
}
