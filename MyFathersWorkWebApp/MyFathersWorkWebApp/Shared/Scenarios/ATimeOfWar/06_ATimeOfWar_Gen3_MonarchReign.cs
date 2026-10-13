namespace MyFathersWorkWebApp;

public static partial class ATimeOfWar
{
    private static readonly string[] MonarchGenericRewards =
    [
        "Gain $3.",
        "Search the Experiment deck of your choice and gain 1 card.",
        "Gain 2 Ingredients.",
        "Gain 2 Compulsion cards.",
        "Lose 2 <icon=Creepy_Icon>.",
        "Lose 2 <icon=Insanity_Icon>.",
        "Gain 1 Knowledge of your choice.",
        "Gain 2 Knowledge of your choice.",
        "Gain an Estate Upgrade for -$2 cost.",
        "Immediately take a Record Knowledge action (you must still pay all costs).",
        "Gain $1 and Gain 1 Ingredient.",
        "Gain $1 and Gain 1 Knowledge of your choice.",
        "Gain 3VP.",
        "Immediately take a Perform Experiment action (you must still play all costs)."
    ];

    public static void MonarchReign(GlobalData globalData)
    {
        // Round 16 -> MonarchReign1 (Early Years)
        // Round 17 -> MonarchReign2 (Middle Years)
        // Round 18 -> MonarchReign3 (Late Years)
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.HubId = TimeOfWarHubId.MonarchReign;
        vars.Round = globalData.Years switch
        {
            Years.Early  => 16,
            Years.Middle => 17,
            Years.Late   => 18,
            _            => 16
        };

        globalData.ActiveHub = new GameplayHub(globalData);
        globalData.ActiveHub.SetDefaultTitle();
        globalData.ActiveHub.SetSubtitle(globalData.Years);

        const string       statueSection = "CommemorativeStatue";
        GameplayHubSection statue        = globalData.ActiveHub.AddSection(statueSection, true);
        statue.ReplaceShouldShow(() => globalData.Years == Years.Late && vars.PageTurn == "yes");
        statue.AddDefaultContent(statueSection);
        statue.AddSpecialClickHere(statueSection, CommemorativeSignIn);

        const string       churchSection = "Church";
        GameplayHubSection church        = globalData.ActiveHub.AddSection(churchSection);
        church.ReplaceShouldShow(() => globalData.Years == Years.Late && vars.PageTurn == "yes");
        church.AddClickHere(AtowChurch);
        church.AddDefaultContent(churchSection);

        const string       allegianceSection = "Allegiance";
        GameplayHubSection allegiance        = globalData.ActiveHub.AddSection(allegianceSection);
        allegiance.ReplaceShouldShow(() => vars.ReignSep != "no");
        allegiance.AddDefaultContent(
            allegianceSection,
            content => content.FormatWithCondition(0, () => vars.ReignSep == "yes"));

        const string       decreeSection = "RoyalDecree";
        GameplayHubSection decree        = globalData.ActiveHub.AddSection(decreeSection, true);
        decree.AddDefaultContent(decreeSection);
        decree.AddSpecialClickHere(decreeSection, ReignIntro);

        const string       mostDecreesSection = "MostDecrees";
        GameplayHubSection mostDecrees        = globalData.ActiveHub.AddSection(mostDecreesSection);
        mostDecrees.AddDefaultContent(
            mostDecreesSection,
            content => content
                .FormatWithReplacement(0, vars.DecBon.ToString())
                .FormatWithCondition(1, () => vars.Benevolent == "good")
                .FormatWithCondition(2, () => globalData.Years == Years.Early));

        const string       shadowSection = "Shadow";
        GameplayHubSection shadow        = globalData.ActiveHub.AddSection(shadowSection);
        shadow.AddDefaultContent(shadowSection);

        const string       royalsNoticeSection = "RoyalsTakeNotice";
        GameplayHubSection royalsNotice        = globalData.ActiveHub.AddSection(royalsNoticeSection, true);
        royalsNotice.AddDefaultContent(royalsNoticeSection);
        royalsNotice.AddSpecialClickHere(royalsNoticeSection, RoyalsTakeNoticeClick);

        const string       royalEyeSection = "RoyalEye";
        GameplayHubSection royalEye        = globalData.ActiveHub.AddSection(royalEyeSection);
        royalEye.ReplaceShouldShow(() => vars.OneStCrown == 1);
        royalEye.AddDefaultContent(royalEyeSection);

        const string       weaponBonusSection = "WeaponBonus";
        GameplayHubSection weaponBonus        = globalData.ActiveHub.AddSection(weaponBonusSection);
        weaponBonus.ReplaceShouldShow(() => vars.WeaponRew is "money" or "vp");
        weaponBonus.AddDefaultContent(
            weaponBonusSection,
            content => content.FormatWithCondition(0, () => vars.WeaponRew == "money"));

        GameplayHubSection endEarlyMiddle = globalData.ActiveHub.AddSection(string.Empty);
        endEarlyMiddle.ReplaceShouldShow(() => globalData.Years is Years.Early or Years.Middle);
        endEarlyMiddle.AddClickHereContinueNextRound(MonarchReign_EndRound);

        globalData.ActiveHub.AddEndOfGenerationSection(MonarchReign_EndRound);
    }

    private static void RoyalsTakeNoticeClick(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.OneStCrown == 0)
        {
            FirstCrownCons(globalData);
        }
        else
        {
            CrownCons(globalData);
        }
    }

    private static void MonarchReign_EndRound(GlobalData globalData)
    {
        globalData.ShowEndOfRoundPopUp(globalData.Years switch
        {
            Years.Early  => Stickfun,
            Years.Middle => MonarchReign_AfterMiddle,
            Years.Late   => Weapons,
            _            => _ => { }
        });
    }

    private static void MonarchReign_AfterMiddle(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.AdvisorCount >= vars.CommTrigger)
        {
            CommemorativeStatueEvent(globalData);
        }
        else
        {
            MonarchReign(globalData);
        }
    }

    #region Intro & Setup

    internal static void MonarchReignIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.Generation = Generation.Third;
        globalData.Years      = Years.Early;

        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Tracker -= 1;
        vars.DecBon   = Random.Shared.Next(5, 9);
        if (vars.WarLoser == "Unified Monarchists")
        {
            vars.EndChange = "yes";
        }

        vars.CommTrigger = globalData.PlayersNum switch
        {
            2 => Random.Shared.Next(2, 5),
            3 => Random.Shared.Next(3, 6),
            _ => Random.Shared.Next(4, 7)
        };

        Array.Clear(vars.PlayerReignGood, 0, vars.PlayerReignGood.Length);
        Array.Clear(vars.PlayerReignEvil, 0, vars.PlayerReignEvil.Length);
        Array.Clear(vars.DecreeVisited, 0, vars.DecreeVisited.Length);
        vars.AdvisorCount = 0;
        vars.CrownCount   = 0;
        vars.OneStCrown   = 0;
        vars.ReignSep     = "0";
        vars.WeaponRew    = "0";
        vars.Gen3Pg       = 0;
        vars.RoyalAdvisor = 0;
        vars.PageTurn     = "no";
        vars.Benevolent   = "good";

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (string.IsNullOrEmpty(vars.PlayerDisplayNames[i]))
            {
                vars.PlayerDisplayNames[i] = globalData.GetPlayerNameByIndex(i);
            }
        }

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddGameplayTitle(GlobalTags.Gameplay_Generation_III);
        globalData.ActiveWindow.AddDefaultSubtitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RoyalBarnCheck);
    }

    private static void RoyalBarnCheck(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.WarLoser != "Unified Monarchists" || vars.Barn != "yes")
        {
            BribeDenied(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RoyalBarnCheck_0);
    }

    private static void RoyalBarnCheck_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_EstateUpgradeBack,
            PopUpButton.Confirm,
            BribeDenied);
    }

    private static void BribeDenied(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.Bribe != "yes")
        {
            RoyalDecreeExplain(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BribeDenied_0);
    }

    private static void BribeDenied_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.S3_WeaponToken,
            PopUpButton.Confirm,
            RoyalDecreeExplain);
    }

    private static void RoyalDecreeExplain(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int inv1 = Random.Shared.Next(4);
        int inv2 = Random.Shared.Next(5);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithIndex(0, inv1)
                .FormatWithIndex(1, inv2));
        globalData.ActiveWindow.AddClickHereToContinue(RoyalPriceisRight);
    }

    private static void RoyalPriceisRight(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(RoyalPriceisRight_0);
    }

    private static void RoyalPriceisRight_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_CrownToken,
            PopUpButton.Confirm,
            RoyalPriceisRight_1,
            content => content.FormatWithReplacement(0, vars.Tracker.ToString()));
    }

    private static void RoyalPriceisRight_1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Gen3Pg = 1;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.VillageChronicleCover,
            PopUpButton.Confirm,
            MonarchReign,
            content => content.FormatWithCondition(0, () => globalData.PlayersNum == 3));
    }

    #endregion

    #region Crown Token Consequences

    private static void FirstCrownCons(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Gen3Pg = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(FirstCrownCons_0);
    }

    private static void FirstCrownCons_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.OneStCrown  = 1;
        vars.CrownCount += 1;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            MonarchReign);
    }

    private static void CrownCons(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.Gen3Pg = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CrownCons_0);
    }

    private static void CrownCons_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.CrownCount += 1;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.Creepy_Icon,
            PopUpButton.Confirm,
            MonarchReign);
    }

    #endregion

    #region Royal Advisor & Royal Decrees

    private static void AddMonarchPlayersAsOptions(GlobalData globalData, Action<int, string> onSelect)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            int    capturedIndex = i;
            string displayName   = vars.GetDisplayPlayerName(globalData, capturedIndex);
            globalData.ActiveWindow!.Elements.Add(
                new GameplayElement(displayName, _ => onSelect(capturedIndex, displayName), true));
        }
    }

    private static void ReignIntro(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.Gen3Pg = 1;
        bool isFirstVisit = vars.RoyalAdvisor == 0;
        vars.RoyalAdvisor = 1;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(
            content => content.FormatWithCondition(0, () => isFirstVisit));

        AddMonarchPlayersAsOptions(globalData, (idx, displayName) =>
        {
            vars.PlaReign  = idx;
            vars.ReignTemp = displayName;
            ReignHUB(globalData);
        });
    }

    private static void ReignHUB(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        int firstIdx  = Random.Shared.Next(MonarchGenericRewards.Length);
        int secondIdx = Random.Shared.Next(MonarchGenericRewards.Length - 1);
        if (secondIdx >= firstIdx) secondIdx++;

        vars.Ch1Reward = MonarchGenericRewards[firstIdx];
        vars.Ch2Reward = MonarchGenericRewards[secondIdx];

        vars.CrownL = Random.Shared.Next(2) == 0
            ? string.Empty
            : "Move the Crown token \"1 space to the left\".";
        vars.CrownR = Random.Shared.Next(2) == 0
            ? string.Empty
            : "Move the Crown token \"1 space to the right\".";

        List<int> candidates = [1];
        int[]     optionalDecrees = [2, 3, 4, 6, 7, 8];
        foreach (int d in optionalDecrees)
        {
            if (!vars.DecreeVisited[d])
            {
                candidates.Add(d);
            }
        }

        int chosenDecree = candidates[Random.Shared.Next(candidates.Count)];
        vars.Reigning     = chosenDecree.ToString();
        vars.AdvisorCount += 1;

        if (chosenDecree != 1)
        {
            vars.DecreeVisited[chosenDecree] = true;
        }

        switch (chosenDecree)
        {
            case 1:
                Reign1(globalData);
                break;
            case 2:
                Reign2(globalData);
                break;
            case 3:
                Reign3(globalData);
                break;
            case 4:
                Reign4(globalData);
                break;
            case 6:
                Reign6(globalData);
                break;
            case 7:
                Reign7(globalData);
                break;
            case 8:
                Reign8(globalData);
                break;
            default:
                Reign1(globalData);
                break;
        }
    }

    private static void RecordDecreeChoice(ATimeOfWarVars vars, int choice)
    {
        vars.Rc = choice;
        int idx = Math.Clamp(vars.PlaReign, 0, 4);
        if (choice == 1)
        {
            vars.PlayerReignGood[idx] += 1;
        }
        else
        {
            vars.PlayerReignEvil[idx] += 1;
        }
    }

    private static void Reign1(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        int titleVariant = Random.Shared.Next(3);
        int introVariant = Random.Shared.Next(3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithIndex(0, titleVariant));
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, vars.ReignTemp)
                .FormatWithIndex(1, introVariant));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign1b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign1b(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.Ch1Reward)
                .FormatWithReplacement(2, vars.CrownR)
                .FormatWithReplacement(3, vars.Ch2Reward));
    }

    private static void Reign1b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int endVariant = Random.Shared.Next(3);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, endVariant));
        globalData.ActiveWindow.AddClickHereToContinue(Reign1b_0);
    }

    private static void Reign1b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars   = globalData.ATimeOfWarVars;
        string         crown  = vars.Rc == 1 ? vars.CrownL : vars.CrownR;
        string         reward = vars.Rc == 1 ? vars.Ch1Reward : vars.Ch2Reward;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, crown)
                .FormatWithReplacement(1, reward));
    }

    private static void Reign2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign2b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign2b(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithReplacement(2, vars.Ch2Reward));
    }

    private static void Reign2b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => vars.Rc == 1));
        globalData.ActiveWindow.AddClickHereToContinue(Reign2b_0);
    }

    private static void Reign2b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithReplacement(2, vars.Ch2Reward)
                .FormatWithCondition(3, () => vars.Rc == 1));
    }

    private static void Reign3(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign3b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign3b(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithReplacement(2, vars.Ch2Reward));
    }

    private static void Reign3b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => vars.Rc == 1));
        globalData.ActiveWindow.AddClickHereToContinue(Reign3b_0);
    }

    private static void Reign3b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithReplacement(2, vars.Ch2Reward)
                .FormatWithCondition(3, () => vars.Rc == 1));
    }

    private static void Reign4(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign4b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign4b(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR));
    }

    private static void Reign4b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => vars.Rc == 1));
        globalData.ActiveWindow.AddClickHereToContinue(Reign4b_0);
    }

    private static void Reign4b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.ReignSep = vars.Rc == 1 ? "no" : "yes";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithCondition(2, () => vars.Rc == 1));
    }

    private static void Reign6(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign6b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign6b(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR));
    }

    private static void Reign6b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => vars.Rc == 1));
        globalData.ActiveWindow.AddClickHereToContinue(Reign6b_0);
    }

    private static void Reign6b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithCondition(2, () => vars.Rc == 1));
    }

    private static void Reign7(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign7b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign7c(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.Ch1Reward)
                .FormatWithReplacement(2, vars.CrownR));
    }

    private static void Reign7b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(Reign7b_0);
    }

    private static void Reign7b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.Ch1Reward));
    }

    private static void Reign7c(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveInputPopup = new GameplayInputPopup(
            globalData,
            "Reign7c_Placeholder",
            PopUpButton.Confirm,
            s => !string.IsNullOrWhiteSpace(s),
            input =>
            {
                string trimmed = input.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    vars.Title = trimmed;
                    int    idx      = Math.Clamp(vars.PlaReign, 0, 4);
                    string baseName = vars.GetDisplayPlayerName(globalData, idx);
                    vars.PlayerDisplayNames[idx] = $"{trimmed} {baseName}";
                    vars.ReignTemp               = vars.PlayerDisplayNames[idx];
                }
                Reign7c2(globalData);
            },
            true);
    }

    private static void Reign7c2(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddClickHereToContinue(Reign7c2_0);
    }

    private static void Reign7c2_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content.FormatWithReplacement(0, vars.CrownR));
    }

    private static void Reign8(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.ReignTemp));
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign8b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign8b(gd);
                }
            ],
            true,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR));
    }

    private static void Reign8b(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => vars.Rc == 1));
        globalData.ActiveWindow.AddClickHereToContinue(Reign8b_0);
    }

    private static void Reign8b_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        vars.WeaponRew = vars.Rc == 1 ? "money" : "vp";

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.MFWlogo,
            PopUpButton.Confirm,
            MonarchReign,
            content => content
                .FormatWithReplacement(0, vars.CrownL)
                .FormatWithReplacement(1, vars.CrownR)
                .FormatWithCondition(2, () => vars.Rc == 1));
    }

    private static void Reign10(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDoNotOtherPlayersToSee(vars.ReignTemp, Reign10_0);
    }

    private static void Reign10_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultBaseTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 1);
                    Reign1b(gd);
                },
                gd =>
                {
                    RecordDecreeChoice(gd.ATimeOfWarVars, 2);
                    Reign1b(gd);
                }
            ],
            true);
    }

    #endregion

    #region End of Early Years: Stickfun & CoWEvent

    private static void Stickfun(GlobalData globalData)
    {
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;
        if (vars.Crazy == 0)
        {
            CoWEvent(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithCondition(0, () => vars.Crazy > 1));
        globalData.ActiveWindow.AddClickHereToContinue(Stickfun_0);
    }

    private static void Stickfun_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            vars.Crazy > 1 ? PopUpIcon.S3_WeaponToken : PopUpIcon.S3_WoodenFigureToken,
            PopUpButton.Confirm,
            CoWEvent,
            content => content.FormatWithCondition(0, () => vars.Crazy > 1));
    }

    private static void CoWEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, globalData.TownName));
        globalData.ActiveWindow.AddClickHereToContinue(globalData.PlayersNum == 2 ? TwoPCoWEvent : CoWEventb);
    }

    private static void TwoPCoWEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.DecBon.ToString()));
        globalData.ActiveWindow.AddClickHereAfterBid(TwoPCoWRes);
    }

    private static void TwoPCoWRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.Benevolent = "good";
                    MonarchReign(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.Benevolent = "evil";
                    MonarchReign(gd);
                }
            ],
            true);
    }

    private static void CoWEventb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithReplacement(0, vars.DecBon.ToString()));
        globalData.ActiveWindow.AddClickHereToContinue(COWRes);
    }

    private static void COWRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddNextContentWithLinks(
            1,
            [
                gd =>
                {
                    gd.ATimeOfWarVars.Benevolent = "good";
                    MonarchReign(gd);
                },
                gd =>
                {
                    gd.ATimeOfWarVars.Benevolent = "evil";
                    MonarchReign(gd);
                }
            ],
            true);
    }

    #endregion

    #region End of Middle Years & Late Years: Commemorative Statue

    private static void CommemorativeStatueEvent(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ATimeOfWarVars.PageTurn = "yes";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CommemorativeStatueEventb);
    }

    private static void CommemorativeStatueEventb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereAfterBid(CommemorativeStatueEventRes);
    }

    private static void CommemorativeStatueEventRes(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        AddMonarchPlayersAsOptions(globalData, (_, displayName) =>
        {
            globalData.ATimeOfWarVars.AtowStatue = displayName;
            CommemorativeStatueEventResb(globalData);
        });
    }

    private static void CommemorativeStatueEventResb(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            MonarchReign,
            content => content.FormatWithReplacement(0, vars.AtowStatue));
    }

    private static void CommemorativeSignIn(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();

        AddMonarchPlayersAsOptions(globalData, (_, displayName) =>
        {
            ATimeOfWarVars vars = globalData.ATimeOfWarVars;
            vars.SignInComm = displayName;
            if (vars.SignInComm == vars.AtowStatue)
            {
                CommemorativeMAIN(globalData);
            }
            else
            {
                CommemorativeOTHER(globalData);
            }
        });
    }

    private static void CommemorativeMAIN(GlobalData globalData)
    {
        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(CommemorativeMAIN_0);
    }

    private static void CommemorativeMAIN_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.S3_CrownToken,
            PopUpButton.Confirm,
            MonarchReign,
            content => content.FormatWithReplacement(0, vars.SignInComm));
    }

    private static void CommemorativeOTHER(GlobalData globalData)
    {
        globalData.SaveToUndo();
        int sneerVariant = Random.Shared.Next(2);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent(content => content.FormatWithIndex(0, sneerVariant));
        globalData.ActiveWindow.AddClickHereToContinue(CommemorativeOTHER_0);
    }

    private static void CommemorativeOTHER_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.SpecialSetup,
            PopUpIcon.SearchDeck_Icon,
            PopUpButton.Confirm,
            MonarchReign,
            content => content.FormatWithReplacement(0, vars.SignInComm));
    }

    #endregion

    #region End of Late Years: Weapons, ShadowBonus, BenevolenceBonus

    private static void Weapons(GlobalData globalData)
    {
        if (globalData.ATimeOfWarVars.WeaponRew != "vp")
        {
            ShadowBonus(globalData);
            return;
        }

        globalData.SaveToUndo();
        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(ShadowBonus);
    }

    private static void ShadowBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        int[] counts   = vars.Benevolent == "good" ? vars.PlayerReignGood : vars.PlayerReignEvil;
        int   maxCount = -1;
        int   maxIndex = -1;
        bool  isTied   = false;

        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            if (counts[i] > maxCount)
            {
                maxCount = counts[i];
                maxIndex = i;
                isTied   = false;
            }
            else if (counts[i] == maxCount)
            {
                isTied = true;
            }
        }

        vars.MostBen = isTied || maxIndex < 0
            ? "Multiple players are tied, so no player"
            : vars.GetDisplayPlayerName(globalData, maxIndex);

        int crownThreshold = globalData.PlayersNum switch
        {
            2 => 0,
            3 => 1,
            _ => 2
        };
        vars.Ending = vars.CrownCount > crownThreshold ? "ATOW-End6" : "ATOW-End5";

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle();
        globalData.ActiveWindow.AddDefaultContent();
        globalData.ActiveWindow.AddClickHereToContinue(BenevolenceBonus);
    }

    private static void BenevolenceBonus(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars   = globalData.ATimeOfWarVars;
        bool           isGood = vars.Benevolent == "good";
        int[]          counts = isGood ? vars.PlayerReignGood : vars.PlayerReignEvil;
        string         kind   = isGood ? "Benevolent" : "Iron Fist";

        List<string> summaryLines = new();
        for (int i = 0; i < globalData.PlayersNum; i++)
        {
            summaryLines.Add($"{vars.GetDisplayPlayerName(globalData, i)} : {counts[i]} {kind} decrees.");
        }
        string breakdown = string.Join("<br>", summaryLines);

        globalData.ActiveWindow = new GameplayWindow(globalData);
        globalData.ActiveWindow.AddDefaultTitle(title => title.FormatWithCondition(0, () => isGood));
        globalData.ActiveWindow.AddDefaultContent(
            content => content
                .FormatWithReplacement(0, breakdown)
                .FormatWithCondition(1, () => isGood));
        globalData.ActiveWindow.AddClickHereToContinue(BenevolenceBonus_0);
    }

    private static void BenevolenceBonus_0(GlobalData globalData)
    {
        globalData.SaveToUndo();
        ATimeOfWarVars vars = globalData.ATimeOfWarVars;

        globalData.ActivePopup = new GameplayPopup(
            globalData,
            PopUpTitle.Setup,
            PopUpIcon.ScoreTrackMarker,
            PopUpButton.Confirm,
            Scoring,
            content => content
                .FormatWithReplacement(0, vars.MostBen)
                .FormatWithReplacement(1, vars.DecBon.ToString()));
    }

    #endregion
}
