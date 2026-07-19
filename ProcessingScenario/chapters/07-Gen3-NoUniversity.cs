// ===================================================================
// CHAPTER: Gen3-NoUniversity   (64 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage11    NoUni1                       L2706-2896 [HUB]  Round-1 HUB "THE CRAWL - Early Years": Pub/Angry Mob, Masterwork rules, Creepy-per-Knowledge upkeep
// passage15    NoUniversityIntro            L3081-3115  Generation III prose intro: university denied, taverns replaced it
// passage21    S5Specialbar1                L3327-3361  "Hungarian Bright" event: sets up the town vote on the electrical grid
// passage27    Barventures                  L3662-3739  Bar-venture dispatcher: randomly serves one of bar1-bar7, returns to a NoUni hub
// passage36    NoUni2                       L4800-5343 [HUB]  Round-2 HUB "THE CRAWL - Middle Years"
// passage37    NoUni3                       L5348-5562 [HUB]  Round-3 HUB "THE CRAWL - Late Years": electricity vote fallout, Power of Electricity discount
// passage48    bar1                         L6232-6308  Bar-venture sworn statement: blacksmith's son
// passage49    bar2                         L6314-6397  Bar-venture sworn statement: stables/pig incident
// passage50    bar3                         L6403-6480  Bar-venture sworn statement: fortune teller's tarot deck
// passage51    bar4                         L6486-6561  Bar-venture sworn statement: General Store break-in
// passage52    bar5                         L6567-6640  Bar-venture sworn statement: hospital brawl
// passage53    bar6                         L6646-6706  Bar-venture sworn statement: Laborer's Union fire
// passage54    bar7                         L6712-6771  Bar-venture sworn statement: cemetery vandalism
// passage69    ElecY                        L8117-8208  Voted FOR electricity: the 1912 riot burns the town and hospital
// passage70    ElecN                        L8213-8313  Voted AGAINST electricity: celebration still devolves into a riot
// passage72    NoUni3b                      L8699-8729  "One Last Attempt": a final Perform Experiment before scoring
// passage98    ImmortalNoUni                L10839-10940  Same Immortality inheritance setup for the No-University branch
// passage133   NewMaster1A                  L15067-15157  Player A privately chooses their Masterwork's scientific discipline
// passage134   NewMaster2A                  L15162-15287  Player A privately chooses their Masterwork's type/form
// passage135   NewMaster3A                  L15292-15352  Confirms player A's Masterwork name; explains re-checking its cost
// passage136   NewMaster                    L15358-15384  "Masters of Their Own Destiny": heirs resolve to build their own Masterworks
// passage137   MWCreationHubA               L15390-15660  Player A's custom Masterwork recipe: cost by discipline/type, VP/Insanity/Creepy reward
// passage138   MWCompleteHubA               L15666-15742  Player A's Masterwork-completion journal excerpt, varying by creation type
// passage139   NewMaster1B                  L15748-15839  Player B privately chooses their Masterwork's discipline
// passage140   MWComplete                   L15844-15892  Shows the completing player's Masterwork narrative and reward; returns to NoUni hubs
// passage141   MWCheck                      L15898-15941  Router: displays the selected player's MWCreationHub, links back to NoUni1/2/3 by round
// passage142   MWTemp                       L15947-16028  Name-picker: click your name to view your Masterwork recipe
// passage143   MWCompleteName               L16033-16118  Name-picker: click your name to view the recipe and confirm completion
// passage144   AllMWRewards                 L16123-16796  Lookup table of every custom-Masterwork reward combination
// passage145   NewMaster2B                  L16802-16927  Player B privately chooses their Masterwork's type/form
// passage146   NewMaster3B                  L16932-16991  Confirms player B's Masterwork; returns to NewMHub
// passage147   MWCreationHubB               L16997-17267  Player B's custom Masterwork recipe
// passage148   MWCompleteHubB               L17273-17348  Player B's Masterwork-completion journal excerpt
// passage149   NewMHub                      L17354-17386  Router advancing through each player's NewMaster creation flow; ends at NoUni1
// passage150   NewMaster1C                  L17392-17484  Player C privately chooses their Masterwork's discipline
// passage151   NewMaster2C                  L17489-17614  Player C privately chooses their Masterwork's type/form
// passage152   NewMaster3C                  L17619-17678  Confirms player C's Masterwork; returns to NewMHub
// passage153   NewMaster1D                  L17684-17776  Player D privately chooses their Masterwork's discipline
// passage154   MWCreationHubC               L17781-18051  Player C's custom Masterwork recipe
// passage155   MWCompleteHubC               L18057-18132  Player C's Masterwork-completion journal excerpt
// passage156   NewMaster2D                  L18138-18263  Player D privately chooses their Masterwork's type/form
// passage157   NewMaster3D                  L18268-18327  Confirms player D's Masterwork; returns to NewMHub
// passage158   NewMaster1E                  L18333-18429  Player E privately chooses their Masterwork's discipline
// passage159   NewMaster2E                  L18434-18562  Player E privately chooses their Masterwork's type/form
// passage161   MWCreationHubD               L18657-18927  Player D's custom Masterwork recipe
// passage162   MWCompleteHubD               L18933-19008  Player D's Masterwork-completion journal excerpt
// passage163   CreepyStar                   L19014-19070  "A Grudge Towards Intellect": VP leader gains 2 Creepy; gateway to Immortality/Panacea setup
// passage232   PanaceaUnleashCons1          L25729-25784  "Whispers Abate": rumors fade; players recover a Servant from the box to Lost
// passage237   NewMaster3E                  L26124-26183  Player E's Create-A-Masterwork step; returns to the new-Masterwork hub
// passage238   MWCreationHubE               L26189-26459  Player E's Masterwork cost/reward reference sheet
// passage239   MWCompleteHubE               L26465-26540  Player E's Masterwork completion journal entry
// passage240   CureNegCons                  L26546-26625  Anti-inoculation backlash: Angry Mob advances; the cure's author gains Creepy + Insanity
// passage260   NoUni3Note                   L27898-27936  DEV NOTE: Barventures / Create-A-Masterwork branch
// passage261   roundEndKnowledge            L27942-28019  End-of-round penalty: Creepy for each Knowledge cube in your Quarters
// passage280   OptiontoKillYes              L28978-29041  "The Inevitable": discard an Immortality card for Body/VP at the cost of a Caretaker
// passage281   OptiontoKillStart            L29047-29078  Intro to the immortality/caretaker paranoia event
// passage282   S5SpecialVote                L29084-29146  Vote on bringing electricity to the town (discounted experiments vs angry mob)
// passage283   OptiontoKillQuestion         L29151-29184  Asks whether any Immortality cards remain; branches to the effect randomizer
// passage284   NoUniMayornCreepy            L29189-29275  "A Somber End": mayor/heart token holders draw a Compulsion and return their tokens
// passage285   MWNote                       L29280-29292  DEV NOTE: cannot strip "the"/"a" from Masterwork titles in code
// passage286   MWCheckComplete              L29298-29353  Masterwork completion confirmation; returns to NoUni1/2/3
// passage336   2p-S5SpecialVoteALT          L33949-34022  2-player ALT: money bid for the right to accept or reject electricity
// passage346   S5SpecialVote2               L34434-34469  Tallies the electricity vote; links to ElecY or ElecN
// passage347   2p-S5SpecialVoteALT2         L34475-34508  Resolves the 2-player electricity bid: winner +3VP, chooses ElecY/ElecN
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   NoUni1               --end of round-->  roundEndKnowledge
//   NoUni2               --end of round-->  roundEndKnowledge
//   NoUni3               --end of round-->  NoUni3b, Scoring
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: NoUni1   (passage11)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 2706-2896
// Links:  Barventures,MWTemp,MWCompleteName,roundEndKnowledge
// Aborts: -
// Round end -> roundEndKnowledge
// Purpose: Round-1 HUB "THE CRAWL - Early Years": Pub/Angry Mob, Masterwork rules, Creepy-per-Knowledge upkeep
// ###################################################################

    void passage11_Init()
    {
        this.Passages[@"NoUni1"] = new StoryPassage(@"NoUni1", new string[] { "HUB", }, passage11_Main);
    }

    IStoryThread passage11_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("THE CRAWL - Early Years");
        }
        yield return lineBreak();
        Vars.round = 16;
        yield return lineBreak();
        if (Vars.gen3pg == 0 || Vars.gen3pg == "")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "AngryMobSetup1";
                yield return lineBreak();
                yield return text("Turn to ");
                using (styleScope("bold", true))
                {
                    yield return text("page 8");
                }
                yield return text(" ");
                yield return text("of the Village Chronicle. Retrieve the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("tokens from the box.");
                yield return lineBreak();
                yield return text("Place the Suspicion Marker on space ");
                using (styleScope("bold", true))
                {
                    if (Vars.players == 2)
                    {
                        yield return text("5");
                    }
                    else if (Vars.players == 3)
                    {
                        yield return text("6");
                    }
                    else if (Vars.players == 4)
                    {
                        yield return text("7");
                    }
                    else if (Vars.players == 5)
                    {
                        yield return text("8");
                    }
                    else
                    {
                        yield return text("5");
                    }
                }
                yield return text(" ");
                yield return text("and the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" ");
                yield return text("token one space to the left. ");
                if (Vars.players == 3)
                {
                    yield return text("Then, since this is a 3-player game, pass the starting player marker clockwise 1 " +
                    "additional time.");
                }
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {

            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("PUB");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If your token is overtaken by the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(", in addition to visiting the Church you can also visit any Pub. When you visit a" +
                " Pub marked with a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("and 0 symbol, ");
            using (styleScope("bold", true))
            {
                yield return text("reset your ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("to zero");
            }
            yield return text(" ");
            yield return text("by buying a couple rounds at the Pub. Then, immediately ");
            yield return link("click here for a Bar-venture.", "Barventures", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("MASTERWORK");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("A Masterwork can be completed by taking the Perform Experiment action and paying " +
            "all of its costs.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Masterwork Recipe");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("To check your Masterwork Cost, ");
            yield return link("click here.", "MWTemp", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Completed Masterwork");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If you are completing a Masterwork, ");
            yield return link("click here to receive your rewards.", "MWCompleteName", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Knowledge");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of each round, each player will ");
            using (styleScope("bold", true))
            {
                yield return text("move one space forward on the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("Track for each Knowledge cube in their Estate");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round to move to the next round...", "roundEndKnowledge", null);
            using (styleScope("hook", "h000011"))
                yield return link("Click here at the end of the round to move to the next round...", null, () => enchantHook("h000011", HarloweEnchantCommand.Replace, passage11_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage11_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("NoUni1", "roundEndKnowledge");
        yield break;
    }

// ###################################################################
// PASSAGE: NoUniversityIntro   (passage15)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 3081-3115
// Links:  CreepyStar
// Aborts: -
// Purpose: Generation III prose intro: university denied, taverns replaced it
// ###################################################################

    void passage15_Init()
    {
        this.Passages[@"NoUniversityIntro"] = new StoryPassage(@"NoUniversityIntro", new string[] { "INTRO", }, passage15_Main);
    }

    IStoryThread passage15_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION III:");
            yield return lineBreak();
            yield return text("DROWN YOUR SORROWS");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"They arrived by coach on a cold day in autumn, summoned from studies abroad in order to claim an inheritance that, despite their reticence, carried with it an extraordinary wealth that they could not resist. The once bright village they remembered from their eccentric youth was mired in gray fog that clung to the ashen streets. Their carriage nearly unchained itself in the deep muddy ruts of the dilapidated roads nearby.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Not much is written about this time aside from journal entries from the young scientists that all echo an immediate revulsion towards the circumstances in which they found themselves and the sense of despair among the townsfolk. Photographs show us some evidence that the hospital was still in operation but its facilities had fallen into disrepair. The university that had once represented a bastion of new science was reduced to rubble, and in its place a disreputable tavern emerged.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"In fact, several public houses had been built upon the main thoroughfare. When the government denied the town a university, the backlash from the peasantry was swift. The citizens developed a sharp distrust of modern advances in science and medicine and were wary of those who displayed signs of intelligence. The grudge they harbored even prevented the extension of the electrical grid to a town in most desperate need of modern updates.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"There was an emptiness in the dusty hallways and barren passageways of the ruined Estates and this hollowness pressed upon the cousins' minds most forcefully. For years, they would be forced into secrecy, listless and isolated from their colleagues, their sense of ambition cut short at the most crucial interval. And while a visit to one of the spirited establishments would help quell the masses, the indulgence only made the gravity of the situation wear more heavily upon their features.");
        yield return lineBreak();
        yield return lineBreak();
        Vars.final5 = 3;
        Vars.bar = 0;
        yield return lineBreak();
        yield return link("Continue...", "CreepyStar", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5Specialbar1   (passage21)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3327-3361
// Links:  2p-S5SpecialVoteALT,S5SpecialVote
// Aborts: -
// Purpose: "Hungarian Bright" event: sets up the town vote on the electrical grid
// ###################################################################

    void passage21_Init()
    {
        this.Passages[@"S5Specialbar1"] = new StoryPassage(@"S5Specialbar1", new string[] { }, passage21_Main);
    }

    IStoryThread passage21_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Hungarian Bright");
        }
        yield return lineBreak();
        yield return text(@"While the cousins thrived in the lamplit tenebrosity of their basement laboratories and spent many evenings observing the melancholic, ashen mists that enveloped the nearby village, the lack of modern convenience - of light and electricity which had been granted across all of Europe - had become a detriment to their experimental capabilities.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"One particularly chill evening in winter, a meeting was called at the Town Hall, in which the topic of electricity and connection to the national grid was reintroduced. However, possibly fueled by many in attendance having already given patronage to the local pub, the icy mood of the meeting suddenly erupted into a fiery debate. The meeting soon descended into chaos and was adjourned as a minor brawl spilled out into the snow-covered streets. It appeared as if nothing would be done without intervention.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With their influence amongst aristocratic circles, it would only take a minute am" +
            "ount of effort for the cousins to levy outside approval for the installation of " +
            "an electrical grid. But were they aligned in their desire to agitate the masses?" +
            "");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players == 2)
        {
            yield return link("Click to continue...", "2p-S5SpecialVoteALT", null);
        }
        else
        {
            yield return link("Click to continue...", "S5SpecialVote", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Barventures   (passage27)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3662-3739
// Links:  NoUni1,NoUni2,NoUni3
// Aborts: -
// Purpose: Bar-venture dispatcher: randomly serves one of bar1-bar7, returns to a NoUni hub
// ###################################################################

    void passage27_Init()
    {
        this.Passages[@"Barventures"] = new StoryPassage(@"Barventures", new string[] { }, passage27_Main);
    }

    IStoryThread passage27_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Bar-venture");
        }
        Vars.barin = macros1.either(1, 2, 3);
        Vars.gen3pg = 1;
        yield return lineBreak();
        if (Vars.barin == 1)
        {
            using (styleScope("italic", true))
            {
                yield return text("Local records from this time show a shocking number of legal depositions submitte" +
            "d on the behalf of the family due to minor incidents at one of the town\'s drinki" +
            "ng establishments. A pertinent example is included below.");
            }
        }
        else if (Vars.barin == 2)
        {
            using (styleScope("italic", true))
            {
                yield return text("As your historical curator, I humbly submit this legal document in its entirety a" +
            "s an example of the colorful \"adventures\" remarked upon by locals during my rese" +
            "arch into the family\'s past.");
            }
        }
        //if (Vars.barin == 3)
        else
        {
            using (styleScope("italic", true))
            {
                yield return text("It is in the interest of thoroughness that I include this legal note. Maybe it is" +
            " of some ");
                yield return text(macros1.either("historical", "comical", "scientific"));
                yield return text(" value? The sheer number of embarrassing anecdotes does offer insight into the cha" +
            "racter of the scientists, though it certainly does not paint them in a favorable" +
            " light.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return passage(macros1.either("bar1", "bar2", "bar3", "bar4", "bar5", "bar6", "bar7"));
        }
        else if (Vars.round == 17)
        {
            yield return passage(macros1.either("bar1", "bar2", "bar3", "bar4", "bar5", "bar6", "bar7"));
        }
        //if (Vars.round == 18)
        else
        {
            yield return passage(macros1.either("bar1", "bar2", "bar3", "bar4", "bar6", "bar7"));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return link("Click to continue...", "NoUni1", null);
        }
        else if (Vars.round == 17)
        {
            yield return link("Click to continue...", "NoUni2", null);
        }
        //if (Vars.round == 18)
        else
        {
            yield return link("Click to continue...", "NoUni3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NoUni2   (passage36)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 4800-5343
// Links:  Barventures,MWTemp,MWCompleteName,roundEndKnowledge
// Aborts: -
// Round end -> roundEndKnowledge
// Purpose: Round-2 HUB "THE CRAWL - Middle Years"
// ###################################################################

    IStoryThread passage36_Fragment_3()
    {
        PassageTracker.instance.CheckProgress("Devastation2", "DevEventCure");
        yield break;
    }

    void passage36_Init()
    {
        this.Passages[@"NoUni2"] = new StoryPassage(@"NoUni2", new string[] { "HUB", }, passage36_Main);
    }

    IStoryThread passage36_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("THE CRAWL - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 17;
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("PUB");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If your token is overtaken by the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(", in addition to visiting the Church you can also visit any Pub. When you visit a" +
                " Pub marked with a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("and 0 symbol, ");
            using (styleScope("bold", true))
            {
                yield return text("reset your ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("to zero");
            }
            yield return text(" ");
            yield return text("by buying a couple rounds at the Pub. Then, immediately ");
            yield return link("click here for a Bar-venture.", "Barventures", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("MASTERWORK");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("A Masterwork can be completed by taking the Perform Experiment action and paying " +
            "all of its costs.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Masterwork Recipe");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("To check your Masterwork Cost, ");
            yield return link("click here.", "MWTemp", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Completed Masterwork");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If you are completing a Masterwork, ");
            yield return link("click here to receive your rewards.", "MWCompleteName", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Knowledge");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of each round, each player will ");
            using (styleScope("bold", true))
            {
                yield return text("move one space forward on the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("Track for each Knowledge cube in their Estate");
            }
            yield return text(".");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Second round Event");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            //yield return link("Click here at the end of the second round for a special event.", "roundEndKnowledge", null);
            using (styleScope("hook", "h000036"))
                yield return link("Click here at the end of the second round for a special event.", null, () => enchantHook("h000036", HarloweEnchantCommand.Replace, passage36_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage36_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("NoUni2", "roundEndKnowledge");
        yield break;
    }

// ###################################################################
// PASSAGE: NoUni3   (passage37)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 5348-5562
// Links:  Barventures,MWTemp,MWCompleteName
// Aborts: -
// Round end -> NoUni3b, Scoring
// Purpose: Round-3 HUB "THE CRAWL - Late Years": electricity vote fallout, Power of Electricity discount
// ###################################################################

    void passage37_Init()
    {
        this.Passages[@"NoUni3"] = new StoryPassage(@"NoUni3", new string[] { "HUB", }, passage37_Main);
    }

    IStoryThread passage37_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("THE CRAWL - Late Years");
        }
        yield return lineBreak();
        Vars.round = 18;
        yield return lineBreak();
        if (Vars.gen3pg == 0 || Vars.gen3pg == "")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "Creepy_Icon";
                yield return lineBreak();
                yield return text("Remove all ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("tokens from the board. Turn to page ");
                using (styleScope("bold", true))
                {
                    yield return text("9");
                }
                yield return text(" ");
                yield return text("of the Village Chronicle.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.peeps == 1)
        {
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Like Us");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("The townspeople express regret for their actions and offer assistance in the fami" +
            "ly\'s endeavors.");
                yield return lineBreak();
                yield return lineBreak();
                Vars.ending = "END-NoUniGood";
                yield return text("Any player with a token that is not currently overtaken by the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" receives ");
                using (styleScope("bold", true))
                {
                    yield return text("one final Perform Experiment action");
                }
                yield return text(" at the end of this round.");
            }
        }
        if (Vars.peeps == 0)
        {
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("A Step Forward");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("The townspeople begrudgingly accept the conveniences provided by access to electr" +
            "icity and while no apologies are offered, no further actions are taken as retrib" +
            "ution.");
            }
            yield return lineBreak();
            yield return lineBreak();
            Vars.ending = "END-NoUniGood";
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("The Power of Electricity");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("During a ");
                using (styleScope("bold", true))
                {
                    yield return text("Perform Experiment");
                }
                yield return text(" action, choose a type of Knowledge. ");
                using (styleScope("bold", true))
                {
                    yield return text("Ignore that Knowledge type when paying the costs of any B or C-Level Experiment. ");
                }
                using (styleScope("italic", true))
                {
                    yield return text("For example, if you choose Chemistry and an Experiment card has a 2 Chemistry cos" +
                "t, you pay 0 Chemistry to complete it.");
                }
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("PUB");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If your token is overtaken by the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(", in addition to visiting the Church you can also visit any Pub. When you visit a" +
                " Pub marked with a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("and 0 symbol, ");
            using (styleScope("bold", true))
            {
                yield return text("reset your ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("to zero");
            }
            yield return text(" ");
            yield return text("by buying a couple rounds at the Pub. Then, immediately ");
            yield return link("click here for a Bar-venture.", "Barventures", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("MASTERWORK");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("A Masterwork can be completed by taking the Perform Experiment action and paying " +
            "all of its costs.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Masterwork Recipe");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("To check your Masterwork Cost, ");
            yield return link("click here.", "MWTemp", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Completed Masterwork");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If you are completing a Masterwork, ");
            yield return link("click here to receive your rewards.", "MWCompleteName", null);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00018"))
                yield return link("Click here at the end of the Generation for Final Scoring and to Determine the Fa" +
                "te of the Town.", null, () => enchantHook("h00018", HarloweEnchantCommand.Replace, passage37_Fragment_0));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage37_Fragment_0()
    {
        if (Vars.peeps == 1)
        {
            //yield return abort(goToPassage: "NoUni3b");
            PassageTracker.instance.CheckProgress("NoUni3", "NoUni3b");
        }
        else
        {
            //yield return abort(goToPassage: "Scoring");
            PassageTracker.instance.CheckProgress("NoUni3", "Scoring");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: bar1   (passage48)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6232-6308
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: blacksmith's son
// ###################################################################

    void passage48_Init()
    {
        this.Passages[@"bar1"] = new StoryPassage(@"bar1", new string[] { }, passage48_Main);
    }

    IStoryThread passage48_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text(" -HDG- ");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        Vars.bar1 = macros1.either(1, 2);
        yield return lineBreak();
        if (Vars.bar1 == 1)
        {
            yield return text("After a brief excursion to the local pub, I happened to engage in a spirited conv" +
            "ersation with the ");
            using (styleScope("bold", true))
            {
                yield return text("Blacksmith’s");
            }
            yield return text(@" son. Being slightly out of my wits, his slightly improper offer to accompany him home to his chateau for further libations appealed. We engaged in a delightful conversation, so intriguing in fact, that I accepted his generous offer of temporary lodging for the evening. I will spare the details of our respectable and entirely benign conversation.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"We both decided to disrobe as any person would when making nightly preparations for sleep. Regrettably, though I cannot recollect how it occurred, the Blacksmith was unpleased to discover us similarly nude and entwined in this state the next morning, surrounded by several defiled tools from the forge. Our family’s reputation was certainly sullied at the Blacksmith and I resolved to avoid it in the future.");
        }
        //if (Vars.bar1 == 2)
        else
        {
            yield return text("After a brief excursion to the local pub, I happened to engage in a spirited conv" +
            "ersation with the ");
            using (styleScope("bold", true))
            {
                yield return text("Blacksmith’s");
            }
            yield return text(@" daughter. While I am unable to discern the reasoning behind my actions, I have since apologized for my repeated comments besmirching her virtuous nature; comments which apparently resulted in a minor altercation with a gentlemen or two at the fine establishment.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"It was around midnight that I decided to make a quiet exit, in order to properly avoid any further antagonism. My clothes, soiled and bloodied by the ensuing brawl, were found discarded along the muddy trek to the Blacksmith's forge. While I have no recollection of the ensuing events, multiple witnesses attest that I then proceeded to brand the blacksmith's dog and passed out naked in the slack tub. Our family’s reputation was certainly sullied at the Blacksmith and I resolved to avoid it in the future.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Blacksmith");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: bar2   (passage49)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6314-6397
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: stables/pig incident
// ###################################################################

    void passage49_Init()
    {
        this.Passages[@"bar2"] = new StoryPassage(@"bar2", new string[] { }, passage49_Main);
    }

    IStoryThread passage49_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text("-HDG-");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        Vars.bar2 = macros1.either(1, 2);
        yield return lineBreak();
        if (Vars.bar2 == 1)
        {
            yield return text(@"While many first-hand accounts from the townsfolk may not corroborate my story, I cannot conceal my disgust with the insinuation. The stable hand and I were simply enjoying a midnight ride in the nearby beet fields in the spirit of the season. Due to my enhanced state of inebriation, I may have chosen the incorrect steed for our excursion.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("I awoke in the stables beside my porcine companion, who had been outfitted with a" +
            " leather riding saddle. The gate to their pen had been left open and the entire " +
            "pig population of the town was scattered throughout the streets.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"I would also like to note that the charges of public nudity against me are warrantless, as upon discovery of my predicament that morning, I hastily endeavored to hide my shame and purchase new clothing from a local tailor as would be customary in such a situation. Our family’s reputation was certainly sullied at the ");
            using (styleScope("bold", true))
            {
                yield return text("Farmer’s Market");
            }
            yield return text(" and I resolved to avoid it in the future.");
        }
        //if (Vars.bar2 == 2)
        else
        {
            yield return text(@"I find the accusations toward my conduct and character most disturbing. To insinuate that I was openly consorting with individuals of ill-repute and offered compensation for illicit activities, why it is as absurd as the other charges against me from that evening.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"While I admit to having a few additional libations, it is most presumptuous to believe that just because I was found near the open door of my carriage in the buff, covered in tomato paste, with lipstick impressions across the entirety of my form, that I would be held responsible for the debasing of a bushel of cherry tomatoes and several other vegetable stocks.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Despite my personal objections, I have summarily reimbursed the stall owner for t" +
            "heir produce and discretion in the matter. Our family’s reputation was certainly" +
            " sullied at the ");
            using (styleScope("bold", true))
            {
                yield return text("Farmer’s Market");
            }
            yield return text(" and I resolved to avoid it in the future.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Farmer\'s Market");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: bar3   (passage50)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6403-6480
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: fortune teller's tarot deck
// ###################################################################

    void passage50_Init()
    {
        this.Passages[@"bar3"] = new StoryPassage(@"bar3", new string[] { }, passage50_Main);
    }

    IStoryThread passage50_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text("-HDG-");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        Vars.bar3 = macros1.either(1, 2);
        yield return lineBreak();
        if (Vars.bar3 == 1)
        {
            yield return text("It was very much in poor taste for a ");
            using (styleScope("bold", true))
            {
                yield return text("fortune teller");
            }
            yield return text(@" to summarily dismiss my romantic advances given my current social status and level of wealth. However, I admit that my inebriated reaction to steal and destroy her Tarot deck was highly juvenile. And the public defiling of said Tarot cards afterwards was certainly not in keeping with the standards of my aristocratic upbringing.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("I have since reimbursed the Fortune Teller for her ruined Tarot cards, and apolog" +
            "ized to the Sheriff for my display of public nudity. Our family’s reputation was" +
            " certainly sullied at the Fortune Teller and I resolved to avoid it in the futur" +
            "e.");
        }
        //if (Vars.bar3 == 2)
        else
        {
            yield return text(@"During a spirited conversation at the local pub, I was informed of a fine establishment with premium snuff and tobacco on the outskirts of town. While I cannot recall if I partook, I was made aware that this establishment promoted opium use, which is a vile indulgence indeed. Sadly, I admit poor judgement in not exiting the premises immediately upon this discovery and my subsequent refusal to leave after four hours had elapsed.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"An exchange of bitter words may have occurred, which resulted in myself yelling expletives and unfortunate ethnic slurs which I would dare not repeat. At some point my clothes had vanished, so I was at a distinct physical disadvantage when I was swiftly removed from the area, not without sustaining several bruises from the scuffle (which, to note, I have not pressed charges for). Our family’s reputation was certainly sullied at the ");
            using (styleScope("bold", true))
            {
                yield return text("Fortune Teller");
            }
            yield return text(" and I resolved to avoid it in the future.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Fortune Teller");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: bar4   (passage51)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6486-6561
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: General Store break-in
// ###################################################################

    void passage51_Init()
    {
        this.Passages[@"bar4"] = new StoryPassage(@"bar4", new string[] { }, passage51_Main);
    }

    IStoryThread passage51_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text("-HDG-");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        Vars.bar4 = macros1.either(1, 2);
        yield return lineBreak();
        if (Vars.bar4 == 1)
        {
            yield return text("The celebration had been exceedingly rowdy. I could not recall whose birthday or " +
            "anniversary was being celebrated, but I could remember my celebratory stilted wa" +
            "lk to the ");
            using (styleScope("bold", true))
            {
                yield return text("General Store");
            }
            yield return text(" near midnight. In my admittedly intoxicated state, I required sustenance.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"Unfortunately, my hunger pangs may have overtaken my sensibilities. A rock may have been plunged through the front window, and I may have been discovered the next morning by the constabulary, passed out naked on the wooden floor, surrounded by several empty cartons of canned sardines, the contents of which may have been returned to the same general area in a more semi-digested form. Our family’s reputation was certainly sullied at the General Store and I resolved to avoid it in the future.");
        }
        if (Vars.bar4 == 2)
        {
            yield return text(@"The proprietors of the General Store, Hagen and Mabel Varga, are respectable, upstanding citizens of whom I have a deep respect. Their fine emporium of quality products is a grand example of successful private business ownership that positively serves the community.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"My unfortunate public statements to the contrary in a loud and admittedly inebriated state were categorically untrue and misinformed. My subsequent scrawling of expletives upon their business' front window - with a crude writing medium that I will not elaborate upon - was brash and reckless.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("I regret that my nude form was discovered curled up at their doorstep by the cons" +
            "tabulary. Our family’s reputation was certainly sullied at the General Store and" +
            " I resolved to avoid it in the future.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("General Store");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: bar5   (passage52)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6567-6640
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: hospital brawl
// ###################################################################

    void passage52_Init()
    {
        this.Passages[@"bar5"] = new StoryPassage(@"bar5", new string[] { }, passage52_Main);
    }

    IStoryThread passage52_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text("-HDG-");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        Vars.bar5 = macros1.either(1, 2);
        yield return lineBreak();
        if (Vars.bar5 == 1)
        {
            yield return text(@"I vaguely remember the phrase that began the argument, but the stitches above my left eye from a shattered glass mug jogged my recollection of the ensuing brawl. A quick nightcap turned into an extended stay of tumbled barstools, belligerence, and wild accusations. My injuries must have been extensive as my memory ceased soon after.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"My displeased spouse informed me that I was currently the height of gossip within the town. First-hand accounts - of which I cannot confirm given my state of awareness - described how I spat blood in a nurse’s face, tore off my leggings (and undergarments), tried to punch the vicar thrice, and defiled myself in the lobby. Our family’s reputation was certainly sullied at the ");
            using (styleScope("bold", true))
            {
                yield return text("Hospital");
            }
            yield return text(" and I resolved to avoid it in the future.");
        }
        if (Vars.bar5 == 2)
        {
            yield return text(@"I should not have attempted to perform a surgical procedure in my state. Nor should I have locked myself in the surgical arena with a patient, barred the door, and undressed, dousing myself in a carbolic acid solution for the purposes of sterilization. However, my honor had been questioned at the pub and I deemed it only necessary to demonstrate my surgical prowess.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"The demonstration of my experimentation capabilities - which are normally formidable, I might add - turned into a series of unfortunate mishaps and misunderstandings. The unfortunate patient has since made a full recovery and has already received a generous stipend in recompense and the hospital a donation with which to cleanse the arena of the admittedly large quantity of blood on the walls, seating, instruments, and ceiling. Our family’s reputation was certainly sullied at the ");
            using (styleScope("bold", true))
            {
                yield return text("Hospital");
            }
            yield return text(" and I resolved to avoid it in the future.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Hospital");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: bar6   (passage53)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6646-6706
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: Laborer's Union fire
// ###################################################################

    void passage53_Init()
    {
        this.Passages[@"bar6"] = new StoryPassage(@"bar6", new string[] { }, passage53_Main);
    }

    IStoryThread passage53_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text("-HDG-");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Although witnesses claim that I had carried a makeshift torch several blocks to the destination, my ignition of nearby gasoline reserves was entirely accidental. My intent, of course, was a comical reenactment of the wiles of recent angry mobs; clearly satirical in nature. A vaudevillian parody. However, the French performance art overtones due to my regrettable nudity were not considered with high regard. The resulting blaze that consumed over half of the Laborer’s Union building that night was also not met with the warmest of receptions.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Honestly, the Laborer’s Union building had not been updated for years. It was ove" +
            "rdue for renovations. However, our family’s reputation was certainly sullied at " +
            "the ");
        using (styleScope("bold", true))
        {
            yield return text("Laborer’s Union");
        }
        yield return text(" ");
        yield return text("and I resolved to avoid it in the future.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Laborer\'s Union");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: bar7   (passage54)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6712-6771
// Links:  -
// Aborts: -
// Purpose: Bar-venture sworn statement: cemetery vandalism
// ###################################################################

    void passage54_Init()
    {
        this.Passages[@"bar7"] = new StoryPassage(@"bar7", new string[] { }, passage54_Main);
    }

    IStoryThread passage54_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SWORN STATEMENT - Case ");
            yield return text(macros1.random(001, 999));
            yield return text("-HDG-");
            yield return text(macros1.random(001, 999));
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"While the cemetery has certainly been a crucial source of ingredients for my experiments - acquired by pruning local flora and herbs - calling attention to this fact very loudly while inside the local pub was probably a mistake. Openly inviting all patrons to join me in the cemetery to kick over headstones and then running directly to said location to do so was a clear error of judgement. My alleged indecent exposure whilst doing so, also unfortunate.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("After being treated for a sprained ankle, I spent a night half-remembered in the " +
            "local police station. Our family’s reputation was certainly sullied at the ");
        using (styleScope("bold", true))
        {
            yield return text("Cemetery");
        }
        yield return text(" ");
        yield return text("and I resolved to avoid it in the future.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Cemetery");
            }
            yield return text(". When a player takes an action at this location, they ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for every ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on that location.");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: ElecY   (passage69)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8117-8208
// Links:  NoUni3,DetEffectRandom
// Aborts: -
// Purpose: Voted FOR electricity: the 1912 riot burns the town and hospital
// ###################################################################

    void passage69_Init()
    {
        this.Passages[@"ElecY"] = new StoryPassage(@"ElecY", new string[] { }, passage69_Main);
    }

    IStoryThread passage69_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Anger and Resentment");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("At the next town meeting, the townspeople were furious to discover a government o" +
            "fficial sent to survey a new extension to the electrical grid. The cousins\' acti" +
            "ons were noted in the minutes from that event where they disclosed their ");
        using (styleScope("bold", true))
        {
            yield return text("support for the installation of electricity");
        }
        yield return text(" ");
        yield return text("and the proposed installation of it at zero cost to the town.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"In a mad display of various ignorances, an angry mob began to form in the center of town, forcing the scientists to retreat by carriage. The crowd soon burst into riotous fury, cursing the government and destroying everything in sight. The riot of 1912 is noted within town archives as the most violent in recorded history. The mob's flaming torches set the Hospital ablaze, leaving multiple individuals severely injured or deceased as they continued into the nearby hills.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While the people\'s specific grievance had been long forgotten by the time the mob" +
            " reached the steps of their estates, it was no less malicious in its issuance of" +
            " flawed justice.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage69_Fragment_1);
        using (styleScope("hook", "h000069"))
            yield return link("Click to continue...", null, () => enchantHook("h000069", HarloweEnchantCommand.Replace, passage69_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage69_Fragment_0()
    {
        //yield return lineBreak();
        Vars.peeps = 0;
        ViewItemObtain.SetupPassagename = Vars.imm == "none" ? "NoUni3" : "DetEffectRandom";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Each player (regardless of their vote) must choose and discard an Estate Upgrade " +
                "");
                using (styleScope("italic", true))
                {
                    yield return text("(not a Storage Shed).");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that voted ");
            using (styleScope("bold", true))
            {
                yield return text("Nay");
            }
            yield return text(" ");
            yield return text("loses 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
        }
        yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.imm == "none")
        //{
        //    yield return link("Click to continue...", "NoUni3", null);
        //}
        //else
        //{
        //    yield return link("Click to continue...", "DetEffectRandom", null);
        //}
        yield break;
    }

    IStoryThread passage69_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage69_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: ElecN   (passage70)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8213-8313
// Links:  NoUni3,DetEffectRandom
// Aborts: -
// Purpose: Voted AGAINST electricity: celebration still devolves into a riot
// ###################################################################

    void passage70_Init()
    {
        this.Passages[@"ElecN"] = new StoryPassage(@"ElecN", new string[] { }, passage70_Main);
    }

    IStoryThread passage70_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Celebration and Anger");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The townspeople sifted through the cousins\' erudite proposal at the next town mee" +
            "ting and realized that they intended to ");
        using (styleScope("bold", true))
        {
            yield return text("support their ridiculous distrust of modern convenience");
        }
        yield return text(". That evening, a celebratory mob congregated in town with various primitive ligh" +
            "ting devices - given the lack of electricity - to cheer and chant their approval" +
            ".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Fueled by alcohol and inspired by ignorant revelry, the gathering quickly devolve" +
            "d into a riotous mass. Chanting loudly in crass language, they tore down the cen" +
            "tral streets of the village, leaving nothing untouched in their destructive path" +
            ".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"In the morning, as the misty streets revealed themselves, the devastation and regret became clear as crystal. Newspapers of the time displayed pictures of the aftermath: the Hospital ablaze, the Town Hall left in smoldering ruins. They hastily rebuilt as best they could, but it would never be the same.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage70_Fragment_1);
        using (styleScope("hook", "h000070"))
            yield return link("Click to continue...", null, () => enchantHook("h000070", HarloweEnchantCommand.Replace, passage70_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage70_Fragment_0()
    {
        //yield return lineBreak();
        Vars.peeps = 1;
        ViewItemObtain.SetupPassagename = Vars.imm == "none" ? "NoUni3" : "DetEffectRandom";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AngryMob_Icon";
            yield return lineBreak();
            yield return text("Return the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token to its starting location.");
            yield return lineBreak();
            yield return lineBreak();
            if (Vars.players == 2)
            {
                yield return text("The player that won the vote also receives ");
                using (styleScope("bold", true))
                {
                    yield return text("1 Ingredient or Knowledge");
                }
                yield return text(" of their choice.");
            }
            else
            {
                yield return text("Any player that voted ");
                using (styleScope("bold", true))
                {
                    yield return text("Yay");
                }
                yield return text(" receives ");
                using (styleScope("bold", true))
                {
                    yield return text("1 Ingredient or Knowledge");
                }
                yield return text(" of their choice.");
            }
        }
        yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.imm == "none")
        //{
        //    yield return link("Click to continue...", "NoUni3", null);
        //}
        //else
        //{
        //    yield return link("Click to continue...", "DetEffectRandom", null);
        //}
        yield break;
    }

    IStoryThread passage70_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage70_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: NoUni3b   (passage72)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8699-8729
// Links:  Scoring
// Aborts: -
// Purpose: "One Last Attempt": a final Perform Experiment before scoring
// ###################################################################

    void passage72_Init()
    {
        this.Passages[@"NoUni3b"] = new StoryPassage(@"NoUni3b", new string[] { }, passage72_Main);
    }

    IStoryThread passage72_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("One Last Attempt");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Weary with age and weakened by a brief resurgence of Yellow Fever left uncured, the scientists' last days are spent wheezing and frail. Would this final crucial moment be filled with a single triumph that would secure irrefutable proof of their scientific legacy?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Any player with a token that is not currently overtaken by the ");
        yield return text("<sprite=\"AngryMob_Icon\" index=0>");
        yield return text(" ");
        yield return text("receives ");
        using (styleScope("bold", true))
        {
            yield return text("one final Perform Experiment action");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue to Final Scoring...", "Scoring", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: ImmortalNoUni   (passage98)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10839-10940
// Links:  PanaceaUnleashCons1
// Aborts: -
// Purpose: Same Immortality inheritance setup for the No-University branch
// ###################################################################

    void passage98_Init()
    {
        this.Passages[@"ImmortalNoUni"] = new StoryPassage(@"ImmortalNoUni", new string[] { }, passage98_Main);
    }

    IStoryThread passage98_Main()
    {
        if (Vars.life == 0)
        {
            yield return abort(goToPassage: "PanaceaUnleashCons1");
        }
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Immortality");
            }
            yield return lineBreak();
            yield return text(@"Claiming an inheritance whilst one's parent still lives on; this foreign concept was decidedly unnerving both for the returning youths and their unaware spouses. However, after the initial shock of encountering a surprisingly spry parent tending to the Estate, the additional help did prove useful.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("For those whose parents had chosen a more amenable fate, having no secrets to con" +
                "ceal caused less suspicion during interactions with the local populace.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage98_Fragment_1);
            using (styleScope("hook", "h00098"))
                yield return link("Click to continue...", null, () => enchantHook("h00098", HarloweEnchantCommand.Replace, passage98_Fragment_0));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage98_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "PanaceaUnleashCons1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            if (Vars.lifeA == "yes")
            {
                yield return text(Vars.nameA);
                yield return text(" III retrieves a Caretaker from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeB == "yes")
            {
                yield return text(Vars.nameB);
                yield return text(" III retrieves a Caretaker from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeC == "yes")
            {
                yield return text(Vars.nameC);
                yield return text(" III retrieves a Caretaker from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeD == "yes")
            {
                yield return text(Vars.nameD);
                yield return text(" III retrieves a Caretaker from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeE == "yes")
            {
                yield return text(Vars.nameE);
                yield return text(" III retrieves a Caretaker from lost.");
                yield return lineBreak();
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player who did not receive a Caretaker for Immortality ");
            using (styleScope("bold", true))
            {
                yield return text("Loses 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("(2 spaces to the left)");
            }
            yield return text(" ");
            yield return text("at the start of this Generation.");
        }
        yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "PanaceaUnleashCons1", null);
        yield break;
    }

    IStoryThread passage98_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage98_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster1A   (passage133)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15067-15157
// Links:  -
// Aborts: -
// Purpose: Player A privately chooses their Masterwork's scientific discipline
// ###################################################################

    void passage133_Init()
    {
        this.Passages[@"NewMaster1A"] = new StoryPassage(@"NewMaster1A", new string[] { }, passage133_Main);
    }

    IStoryThread passage133_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this Storybook device to ");
            yield return text(Vars.nameA);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        Vars.trig = 1;//int.Parse(Vars.trig) + 1;
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage133_Fragment_5);
        using (styleScope("hook", "h000133"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000133", HarloweEnchantCommand.Replace, passage133_Fragment_4));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage133_Fragment_0()
    {
        Vars.disA = "biology";
        yield return abort(goToPassage: "NewMaster2A");
        yield break;
    }

    IStoryThread passage133_Fragment_1()
    {
        Vars.disA = "engineering";
        yield return abort(goToPassage: "NewMaster2A");
        yield break;
    }

    IStoryThread passage133_Fragment_2()
    {
        Vars.disA = "chemistry";
        yield return abort(goToPassage: "NewMaster2A");
        yield break;
    }

    IStoryThread passage133_Fragment_3()
    {
        Vars.disA = "occult";
        yield return abort(goToPassage: "NewMaster2A");
        yield break;
    }

    IStoryThread passage133_Fragment_4()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Masterwork of My Own - ");
            yield return text(Vars.nameA);
            yield return text(" III");
        }
        yield return lineBreak();
        yield return text(@"I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation is from which scientific discipline?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00079"))
            yield return link("Biology.", null, () => enchantHook("h00079", HarloweEnchantCommand.Replace, passage133_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00080"))
            yield return link("Engineering.", null, () => enchantHook("h00080", HarloweEnchantCommand.Replace, passage133_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00081"))
            yield return link("Chemistry.", null, () => enchantHook("h00081", HarloweEnchantCommand.Replace, passage133_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00082"))
            yield return link("Occult.", null, () => enchantHook("h00082", HarloweEnchantCommand.Replace, passage133_Fragment_3));
        yield break;
    }

    IStoryThread passage133_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage133_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster2A   (passage134)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15162-15287
// Links:  -
// Aborts: -
// Purpose: Player A privately chooses their Masterwork's type/form
// ###################################################################

    void passage134_Init()
    {
        this.Passages[@"NewMaster2A"] = new StoryPassage(@"NewMaster2A", new string[] { }, passage134_Main);
    }

    IStoryThread passage134_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("What Type of Glorious Creation");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my unique ");
        yield return text(Vars.disA);
        yield return text(" ");
        yield return text("skills, this creation was already more focused and impressive than ever before. B" +
            "ut, what ingenious type of creation would I explore?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation could be described as what type?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.disA == "biology")
        {
            Vars.costA = macros1.either("Engineering", "Chemistry");
            using (styleScope("hook", "h00083"))
                yield return link("Creature.", null, () => enchantHook("h00083", HarloweEnchantCommand.Replace, passage134_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00084"))
                yield return link("Superpower.", null, () => enchantHook("h00084", HarloweEnchantCommand.Replace, passage134_Fragment_1));
            yield return lineBreak();
        }
        else if (Vars.disA == "engineering")
        {
            Vars.costA = macros1.either("Biology", "Chemistry");
            using (styleScope("hook", "h00085"))
                yield return link("Robot.", null, () => enchantHook("h00085", HarloweEnchantCommand.Replace, passage134_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00086"))
                yield return link("Weapon.", null, () => enchantHook("h00086", HarloweEnchantCommand.Replace, passage134_Fragment_3));
            yield return lineBreak();
        }
        else if (Vars.disA == "chemistry")
        {
            Vars.costA = macros1.either("Engineering", "Biology");
            using (styleScope("hook", "h00087"))
                yield return link("Medicine.", null, () => enchantHook("h00087", HarloweEnchantCommand.Replace, passage134_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00088"))
                yield return link("Drug.", null, () => enchantHook("h00088", HarloweEnchantCommand.Replace, passage134_Fragment_5));
            yield return lineBreak();
        }
        else //if (Vars.disA == "occult")
        {
            Vars.costA = macros1.either("Engineering", "Chemistry", "Biology");
            using (styleScope("hook", "h00089"))
                yield return link("Demonic Creature.", null, () => enchantHook("h00089", HarloweEnchantCommand.Replace, passage134_Fragment_6));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00090"))
                yield return link("Ritual.", null, () => enchantHook("h00090", HarloweEnchantCommand.Replace, passage134_Fragment_7));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage134_Fragment_0()
    {
        Vars.typeA = "creature";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_1()
    {
        Vars.typeA = "power";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_2()
    {
        Vars.typeA = "robot";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_3()
    {
        Vars.typeA = "weapon";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_4()
    {
        Vars.typeA = "medicine";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_5()
    {
        Vars.typeA = "drug";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_6()
    {
        Vars.typeA = "demon";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

    IStoryThread passage134_Fragment_7()
    {
        Vars.typeA = "ritual";
        yield return abort(goToPassage: "NewMaster3A");
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster3A   (passage135)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15292-15352
// Links:  NewMaster1B
// Aborts: -
// Purpose: Confirms player A's Masterwork name; explains re-checking its cost
// ###################################################################

    void passage135_Init()
    {
        this.Passages[@"NewMaster3A"] = new StoryPassage(@"NewMaster3A", new string[] { }, passage135_Main);
    }

    IStoryThread passage135_Main()
    {
        if (Vars.costA == "Biology")
        {
            Vars.cost2A = "Animal";
        }
        if (Vars.costA == "Engineering")
        {
            Vars.cost2A = "Gear";
        }
        if (Vars.costA == "Chemistry")
        {
            Vars.cost2A = "Bottle";
        }
        //yield return lineBreak();
        //Vars.creationA = ("rompt: Give your creation a new, majestic name:");
        if (ispopup && iscreationA)
        {
            iscreationA = false;
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("NewMaster3A", "Give your creation a new, majestic name:", "string", 0.25f);
        }
        if (ViewPopupPanel.instance.PassageValueString() != null)
        {
            Vars.creationA = ViewPopupPanel.instance.PassageValueString();
            ViewPopupPanel.instance.Clear();
            ispopup = true;
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The ");
            yield return text(macros1.either("Infamous", "Transcendent", "Monumental", "Nefarious", "Unspeakable", "Legendary", "Noble", "Phenomenal", "Stunning", "Masterful", "Insidious"));
            yield return text(" ");
            yield return text(Vars.creationA);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return passage("MWCreationHubA");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my own destiny determined, I resolved to forge a new path into the future an" +
            "d create my Masterwork.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("You may check the cost of completing your new Masterwork at any time by clicking " +
            "on your name on the main Storybook screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "NewMaster1B", null);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster   (passage136)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15358-15384
// Links:  NewMaster1A
// Aborts: -
// Purpose: "Masters of Their Own Destiny": heirs resolve to build their own Masterworks
// ###################################################################

    void passage136_Init()
    {
        this.Passages[@"NewMaster"] = new StoryPassage(@"NewMaster", new string[] { }, passage136_Main);
    }

    IStoryThread passage136_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Masters of Their Own Destiny");
        }
        yield return lineBreak();
        Vars.gen3pg = 0;
        yield return lineBreak();
        yield return text("It seemed the pervasive gloom of ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text(@"had infected the halls of the great estates. For when the cousins explored the musty recesses of their inherited homes, they discovered great underground laboratories left in startling disarray. Volumetric flasks lay shattered amongst the rusted remains of mechanical devices misshapen and strewn across the floor. And most disconcerting, the tattered remains of a most exceptional experiment. Oh the folly of the depressed and aged mind!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"To those of lesser imagination, this may have been the death knell of their ambitions, but their youthful exuberance could not be shackled by the capricious whims of their progenitors! If their family could not continue the generations of hard work, they would create their own legacy!");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to create a new Masterwork!", "NewMaster1A", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCreationHubA   (passage137)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15390-15660
// Links:  -
// Aborts: -
// Purpose: Player A's custom Masterwork recipe: cost by discipline/type, VP/Insanity/Creepy reward
// ###################################################################

    void passage137_Init()
    {
        this.Passages[@"MWCreationHubA"] = new StoryPassage(@"MWCreationHubA", new string[] { }, passage137_Main);
    }

    IStoryThread passage137_Main()
    {
        if (Vars.typeA == "creature")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Animals, 5 Biology, 1 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeA == "power")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Animal, 1 ");
            yield return text(Vars.cost2A);
            yield return text(", 3 Biology, 3 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeA == "robot")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Gears, 5 Engineering, 1 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeA == "weapon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Gear, 1 ");
            yield return text(Vars.cost2A);
            yield return text(", 4 Engineering, 2 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeA == "medicine")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Chemicals, 4 Chemistry, 2 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeA == "drug")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Bottle, 1 ");
            yield return text(Vars.cost2A);
            yield return text(", 3 Chemistry, 3 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeA == "demon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Bodies, 4 Occult, 1 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else //if (Vars.typeA == "ritual")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationA);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Body, 1 ");
            yield return text(Vars.cost2A);
            yield return text(", 3 Occult, 3 ");
            yield return text(Vars.costA);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<i>Note: This Masterwork still requires 1 A Experiment, 2 B Experiments, and 3 C Experiments to be completed.</i>");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCompleteHubA   (passage138)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15666-15742
// Links:  -
// Aborts: -
// Purpose: Player A's Masterwork-completion journal excerpt, varying by creation type
// ###################################################################

    void passage138_Init()
    {
        this.Passages[@"MWCompleteHubA"] = new StoryPassage(@"MWCompleteHubA", new string[] { }, passage138_Main);
    }

    IStoryThread passage138_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("The Work is Done", "I Have Done the Impossible", "My Legacy is Ensured", "AH HA HA HAAAAA!!!", "My Glorious Creation", "The Glory is Mine Forever!"));
            yield return text(" ");
            yield return text("- ");
            yield return text(Vars.nameA);
            yield return text(" ");
            yield return text("- Journal Entry Excerpt");
        }
        yield return lineBreak();
        if (Vars.typeA == "creature")
        {
            yield return text("Upon the stroke of midnight, lightning struck metal, sending a terrible electrica" +
            "l current through the machinery. My creation awoke, and with wild eyes gazed upo" +
            "n me, its creator. I had done it! I had created life!");
        }
        else if (Vars.typeA == "power")
        {
            yield return text("To see my work in the flesh, to see ");
            yield return text(Vars.creationA);
            yield return text(" finally realized; the passion of the moment overwhelmed my senses. I had done it." +
            " I shook my fist at God and all who doubted me! You were wrong! I am invincible!" +
            "");
        }
        else if (Vars.typeA == "robot")
        {
            yield return text("A brief, blinding flash and the work was done. I threw my goggles to the floor to" +
            " gaze upon my creation with my own eyes - ");
            yield return text(Vars.creationA);
            yield return text(". The polished metal surface whirred with interior mechanisms churning - then, gl" +
            "orious motion! Oh wondrous automaton, with you by my side the scientific world w" +
            "ill be humbled!");
        }
        else if (Vars.typeA == "weapon")
        {
            yield return text(@"I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (Vars.typeA == "medicine")
        {
            yield return text("I tapped the glass bottle, watching the liquid inside swirl and glow with the pur" +
            "ity of the mixture. The ");
            yield return text(Vars.creationA);
            yield return text(" had been a stunning success and once mass production could be attained, my family" +
            "\'s legacy would be secure. I laughed. Then, laughed again. My cacophonous laught" +
            "er echoed off the stone walls of my estate for years to come.");
        }
        else if (Vars.typeA == "drug")
        {
            yield return text("I observed the effects as the syringe filled with ");
            yield return text(Vars.creationA);
            yield return text(@" emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (Vars.typeA == "demon")
        {
            yield return text("The world darkened around me as the ");
            yield return text(Vars.creationA);
            yield return text(@" emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, ""Master."" I had done it. I was now in control and the world would rue the day they doubted ");
            yield return text(Vars.nameA);
            yield return text(" III!");
        }
        else //if (Vars.typeA == "ritual")
        {
            yield return text("The preparations proved tedious, but the resulting wave of spiritual energy as th" +
            "e ritual was completed left me standing in awe of my creation. The ");
            yield return text(Vars.creationA);
            yield return text(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster1B   (passage139)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15748-15839
// Links:  -
// Aborts: -
// Purpose: Player B privately chooses their Masterwork's discipline
// ###################################################################

    void passage139_Init()
    {
        this.Passages[@"NewMaster1B"] = new StoryPassage(@"NewMaster1B", new string[] { }, passage139_Main);
    }

    IStoryThread passage139_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this Storybook device to ");
            yield return text(Vars.nameB);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        Vars.trig = 2;//int.Parse(Vars.trig) + 1;
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage139_Fragment_5);
        using (styleScope("hook", "h000139"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000139", HarloweEnchantCommand.Replace, passage139_Fragment_4));
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage139_Fragment_0()
    {
        Vars.disB = "biology";
        yield return abort(goToPassage: "NewMaster2B");
        yield break;
    }

    IStoryThread passage139_Fragment_1()
    {
        Vars.disB = "engineering";
        yield return abort(goToPassage: "NewMaster2B");
        yield break;
    }

    IStoryThread passage139_Fragment_2()
    {
        Vars.disB = "chemistry";
        yield return abort(goToPassage: "NewMaster2B");
        yield break;
    }

    IStoryThread passage139_Fragment_3()
    {
        Vars.disB = "occult";
        yield return abort(goToPassage: "NewMaster2B");
        yield break;
    }

    IStoryThread passage139_Fragment_4()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Masterwork of My Own - ");
            yield return text(Vars.nameB);
            yield return text(" III");
        }
        yield return lineBreak();
        yield return text(@"I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation is from which scientific discipline?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h000091"))
            yield return link("Biology.", null, () => enchantHook("h000091", HarloweEnchantCommand.Replace, passage139_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h000092"))
            yield return link("Engineering.", null, () => enchantHook("h000092", HarloweEnchantCommand.Replace, passage139_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h000093"))
            yield return link("Chemistry.", null, () => enchantHook("h000093", HarloweEnchantCommand.Replace, passage139_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h000094"))
            yield return link("Occult.", null, () => enchantHook("h000094", HarloweEnchantCommand.Replace, passage139_Fragment_3));
        yield break;
    }

    IStoryThread passage139_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage139_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: MWComplete   (passage140)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15844-15892
// Links:  NoUni1,NoUni2,NoUni3
// Aborts: -
// Purpose: Shows the completing player's Masterwork narrative and reward; returns to NoUni hubs
// ###################################################################

    void passage140_Init()
    {
        this.Passages[@"MWComplete"] = new StoryPassage(@"MWComplete", new string[] { }, passage140_Main);
    }

    IStoryThread passage140_Main()
    {
        if (Vars.tempcomp == Vars.nameA)
        {
            yield return passage("MWCompleteHubA");
        }
        if (Vars.tempcomp == Vars.nameB)
        {
            yield return passage("MWCompleteHubB");
        }
        if (Vars.tempcomp == Vars.nameC)
        {
            yield return passage("MWCompleteHubC");
        }
        if (Vars.tempcomp == Vars.nameD)
        {
            yield return passage("MWCompleteHubD");
        }
        if (Vars.tempcomp == Vars.nameE)
        {
            yield return passage("MWCompleteHubE");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Then, collect your ");
        yield return passage("AllMWRewards");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return link("Click to return...", "NoUni1", null);
        }
        else if (Vars.round == 17)
        {
            yield return link("Click to return...", "NoUni2", null);
        }
        //if (Vars.round == 18)
        else
        {
            yield return link("Click to return...", "NoUni3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCheck   (passage141)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15898-15941
// Links:  NoUni1,NoUni2,NoUni3
// Aborts: -
// Purpose: Router: displays the selected player's MWCreationHub, links back to NoUni1/2/3 by round
// ###################################################################

    void passage141_Init()
    {
        this.Passages[@"MWCheck"] = new StoryPassage(@"MWCheck", new string[] { }, passage141_Main);
    }

    IStoryThread passage141_Main()
    {
        if (Vars.tempcheck == Vars.nameA)
        {
            yield return passage("MWCreationHubA");
        }
        else if (Vars.tempcheck == Vars.nameB)
        {
            yield return passage("MWCreationHubB");
        }
        else if (Vars.tempcheck == Vars.nameC)
        {
            yield return passage("MWCreationHubC");
        }
        else if (Vars.tempcheck == Vars.nameD)
        {
            yield return passage("MWCreationHubD");
        }
        else if (Vars.tempcheck == Vars.nameE)
        {
            yield return passage("MWCreationHubE");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return link("Click to return...", "NoUni1", null);
        }
        else if (Vars.round == 17)
        {
            yield return link("Click to return...", "NoUni2", null);
        }
        //if (Vars.round == 18)
        else
        {
            yield return link("Click to return...", "NoUni3", null);
        }
        yield break;
    }

// ###################################################################
// PASSAGE: MWTemp   (passage142)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 15947-16028
// Links:  -
// Aborts: -
// Purpose: Name-picker: click your name to view your Masterwork recipe
// ###################################################################

    void passage142_Init()
    {
        this.Passages[@"MWTemp"] = new StoryPassage(@"MWTemp", new string[] { }, passage142_Main);
    }

    IStoryThread passage142_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Click on your name below to view the Masterwork Recipe:");
        }
        Vars.gen3pg = 1;
        yield return lineBreak();
        yield return lineBreak();

        using (styleScope("hook", "h00095"))
            yield return link(Vars.nameA + " III", null, () => enchantHook("h00095", HarloweEnchantCommand.Replace, passage142_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00096"))
            yield return link(Vars.nameB + " III", null, () => enchantHook("h00096", HarloweEnchantCommand.Replace, passage142_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h000097"))
                yield return link(Vars.nameC + " III", null, () => enchantHook("h000097", HarloweEnchantCommand.Replace, passage142_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h000098"))
                yield return link(Vars.nameD + " III", null, () => enchantHook("h000098", HarloweEnchantCommand.Replace, passage142_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00099"))
                yield return link(Vars.nameE + " III", null, () => enchantHook("h00099", HarloweEnchantCommand.Replace, passage142_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
        }
        yield break;
    }

    IStoryThread passage142_Fragment_0()
    {
        Vars.tempcheck = Vars.nameA;
        yield return abort(goToPassage: "MWCheck");
        yield break;
    }

    IStoryThread passage142_Fragment_1()
    {
        Vars.tempcheck = Vars.nameB;
        yield return abort(goToPassage: "MWCheck");
        yield break;
    }

    IStoryThread passage142_Fragment_2()
    {
        Vars.tempcheck = Vars.nameC;
        yield return abort(goToPassage: "MWCheck");
        yield break;
    }

    IStoryThread passage142_Fragment_3()
    {
        Vars.tempcheck = Vars.nameD;
        yield return abort(goToPassage: "MWCheck");
        yield break;
    }

    IStoryThread passage142_Fragment_4()
    {
        Vars.tempcheck = Vars.nameE;
        yield return abort(goToPassage: "MWCheck");
        yield break;
    }

// ###################################################################
// PASSAGE: MWCompleteName   (passage143)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 16033-16118
// Links:  -
// Aborts: -
// Purpose: Name-picker: click your name to view the recipe and confirm completion
// ###################################################################

    void passage143_Init()
    {
        this.Passages[@"MWCompleteName"] = new StoryPassage(@"MWCompleteName", new string[] { }, passage143_Main);
    }

    IStoryThread passage143_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Click on your name below to view the Masterwork Recipe and confirm that it is com" +
            "plete:");
        }
        Vars.gen3pg = 1;
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00100"))
            yield return link(Vars.nameA + " III", null, () => enchantHook("h00100", HarloweEnchantCommand.Replace, passage143_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00101"))
            yield return link(Vars.nameB + " III", null, () => enchantHook("h00101", HarloweEnchantCommand.Replace, passage143_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00102"))
                yield return link(Vars.nameC + " III", null, () => enchantHook("h00102", HarloweEnchantCommand.Replace, passage143_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00103"))
                yield return link(Vars.nameD + " III", null, () => enchantHook("h00103", HarloweEnchantCommand.Replace, passage143_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00104"))
                yield return link(Vars.nameE + " III", null, () => enchantHook("h00104", HarloweEnchantCommand.Replace, passage143_Fragment_4));
            yield return lineBreak();
        }
        yield break;
    }

    IStoryThread passage143_Fragment_0()
    {
        Vars.tempcomp = Vars.nameA;
        Vars.tempcheck = Vars.nameA;
        yield return abort(goToPassage: "MWCheckComplete");
        yield break;
    }

    IStoryThread passage143_Fragment_1()
    {
        Vars.tempcomp = Vars.nameB;
        Vars.tempcheck = Vars.nameB;
        yield return abort(goToPassage: "MWCheckComplete");
        yield break;
    }

    IStoryThread passage143_Fragment_2()
    {
        Vars.tempcomp = Vars.nameC;
        Vars.tempcheck = Vars.nameC;
        yield return abort(goToPassage: "MWCheckComplete");
        yield break;
    }

    IStoryThread passage143_Fragment_3()
    {
        Vars.tempcomp = Vars.nameD;
        Vars.tempcheck = Vars.nameD;
        yield return abort(goToPassage: "MWCheckComplete");
        yield break;
    }

    IStoryThread passage143_Fragment_4()
    {
        Vars.tempcomp = Vars.nameE;
        Vars.tempcheck = Vars.nameE;
        yield return abort(goToPassage: "MWCheckComplete");
        yield break;
    }

// ###################################################################
// PASSAGE: AllMWRewards   (passage144)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 16123-16796
// Links:  -
// Aborts: -
// Purpose: Lookup table of every custom-Masterwork reward combination
// ###################################################################

    void passage144_Init()
    {
        this.Passages[@"AllMWRewards"] = new StoryPassage(@"AllMWRewards", new string[] { }, passage144_Main);
    }

    IStoryThread passage144_Main()
    {
        if (Vars.tempcomp == Vars.nameA)
        {
            if (Vars.typeA == "creature")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeA == "power")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeA == "robot")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeA == "weapon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeA == "medicine")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeA == "drug")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeA == "demon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else //if (Vars.typeA == "ritual")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
        }
        if (Vars.tempcomp == Vars.nameB)
        {
            if (Vars.typeB == "creature")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeB == "power")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeB == "robot")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeB == "weapon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeB == "medicine")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeB == "drug")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeB == "demon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else //if (Vars.typeB == "ritual")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
        }
        if (Vars.tempcomp == Vars.nameC)
        {
            if (Vars.typeC == "creature")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeC == "power")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeC == "robot")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeC == "weapon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeC == "medicine")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeC == "drug")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeC == "demon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else //if (Vars.typeC == "ritual")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
        }
        if (Vars.tempcomp == Vars.nameD)
        {
            if (Vars.typeD == "creature")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeD == "power")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeD == "robot")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeD == "weapon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeD == "medicine")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeD == "drug")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeD == "demon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else //if (Vars.typeD == "ritual")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
        }
        if (Vars.tempcomp == Vars.nameE)
        {
            if (Vars.typeE == "creature")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeE == "power")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeE == "robot")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeE == "weapon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeE == "medicine")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeE == "drug")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 19VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else if (Vars.typeE == "demon")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 21VP.");
                yield return lineBreak();
                yield return text("Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
            else //if (Vars.typeE == "ritual")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Reward:");
                }
                yield return lineBreak();
                yield return text("Gain 20VP.");
                yield return lineBreak();
                yield return text("Gain 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(", Gain 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(", Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(".");
                yield return lineBreak();
            }
        }
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster2B   (passage145)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 16802-16927
// Links:  -
// Aborts: -
// Purpose: Player B privately chooses their Masterwork's type/form
// ###################################################################

    void passage145_Init()
    {
        this.Passages[@"NewMaster2B"] = new StoryPassage(@"NewMaster2B", new string[] { }, passage145_Main);
    }

    IStoryThread passage145_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("What Type of Glorious Creation");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my unique ");
        yield return text(Vars.disB);
        yield return text(" ");
        yield return text("skills, this creation was already more focused and impressive than ever before. B" +
            "ut, what ingenious type of creation would I explore?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation could be described as what type?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.disB == "biology")
        {
            Vars.costB = macros1.either("Engineering", "Chemistry");
            using (styleScope("hook", "h00105"))
                yield return link("Creature.", null, () => enchantHook("h00105", HarloweEnchantCommand.Replace, passage145_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00106"))
                yield return link("Superpower.", null, () => enchantHook("h00106", HarloweEnchantCommand.Replace, passage145_Fragment_1));
            yield return lineBreak();
        }
        else if (Vars.disB == "engineering")
        {
            Vars.costB = macros1.either("Biology", "Chemistry");
            using (styleScope("hook", "h00107"))
                yield return link("Robot.", null, () => enchantHook("h00107", HarloweEnchantCommand.Replace, passage145_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00108"))
                yield return link("Weapon.", null, () => enchantHook("h00108", HarloweEnchantCommand.Replace, passage145_Fragment_3));
            yield return lineBreak();
        }
        else if (Vars.disB == "chemistry")
        {
            Vars.costB = macros1.either("Engineering", "Biology");
            using (styleScope("hook", "h00109"))
                yield return link("Medicine.", null, () => enchantHook("h00109", HarloweEnchantCommand.Replace, passage145_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00110"))
                yield return link("Drug.", null, () => enchantHook("h00110", HarloweEnchantCommand.Replace, passage145_Fragment_5));
            yield return lineBreak();
        }
        else //if (Vars.disB == "occult")
        {
            Vars.costB = macros1.either("Engineering", "Chemistry", "Biology");
            using (styleScope("hook", "h00111"))
                yield return link("Demonic Creature.", null, () => enchantHook("h00111", HarloweEnchantCommand.Replace, passage145_Fragment_6));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00112"))
                yield return link("Ritual.", null, () => enchantHook("h00112", HarloweEnchantCommand.Replace, passage145_Fragment_7));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage145_Fragment_0()
    {
        Vars.typeB = "creature";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_1()
    {
        Vars.typeB = "power";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_2()
    {
        Vars.typeB = "robot";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_3()
    {
        Vars.typeB = "weapon";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_4()
    {
        Vars.typeB = "medicine";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_5()
    {
        Vars.typeB = "drug";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_6()
    {
        Vars.typeB = "demon";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

    IStoryThread passage145_Fragment_7()
    {
        Vars.typeB = "ritual";
        yield return abort(goToPassage: "NewMaster3B");
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster3B   (passage146)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 16932-16991
// Links:  NewMHub
// Aborts: -
// Purpose: Confirms player B's Masterwork; returns to NewMHub
// ###################################################################

    void passage146_Init()
    {
        this.Passages[@"NewMaster3B"] = new StoryPassage(@"NewMaster3B", new string[] { }, passage146_Main);
    }

    IStoryThread passage146_Main()
    {
        if (Vars.costB == "Biology")
        {
            Vars.cost2B = "Animal";
        }
        if (Vars.costB == "Engineering")
        {
            Vars.cost2B = "Gear";
        }
        if (Vars.costB == "Chemistry")
        {
            Vars.cost2B = "Bottle";
        }
        //yield return lineBreak();
        //Vars.creationB = ("rompt: Give your creation a new, majestic name:");
        if (/*(Vars.creationB == "" || Vars.creationB == 0) &&*/ ispopup)
        {
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("NewMaster3B", "Give your creation a new, majestic name:", "string", 0.5f);
        }
        else //if (ViewPopupPanel.instance.PassageValueString() != null)
        {
            Vars.creationB = ViewPopupPanel.instance.PassageValueString();
            ViewPopupPanel.instance.Clear();
            ispopup = true;
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The ");
            yield return text(macros1.either("Infamous", "Transcendent", "Monumental", "Nefarious", "Unspeakable", "Legendary", "Noble", "Phenomenal", "Stunning", "Masterful", "Insidious"));
            yield return text(" ");
            yield return text(Vars.creationB);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return passage("MWCreationHubB");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my own destiny determined, I resolved to forge a new path into the future an" +
            "d create my Masterwork.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("You may check the cost of completing your new Masterwork at any time by clicking " +
            "on your name on the main Storybook screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "NewMHub", null);
        yield break;
    }

// ###################################################################
// PASSAGE: MWCreationHubB   (passage147)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 16997-17267
// Links:  -
// Aborts: -
// Purpose: Player B's custom Masterwork recipe
// ###################################################################

    void passage147_Init()
    {
        this.Passages[@"MWCreationHubB"] = new StoryPassage(@"MWCreationHubB", new string[] { }, passage147_Main);
    }

    IStoryThread passage147_Main()
    {
        if (Vars.typeB == "creature")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Animals, 5 Biology, 1 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeB == "power")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Animal, 1 ");
            yield return text(Vars.cost2B);
            yield return text(", 3 Biology, 3 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeB == "robot")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Gears, 5 Engineering, 1 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeB == "weapon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Gear, 1 ");
            yield return text(Vars.cost2B);
            yield return text(", 4 Engineering, 2 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeB == "medicine")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Chemicals, 4 Chemistry, 2 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeB == "drug")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Bottle, 1 ");
            yield return text(Vars.cost2B);
            yield return text(", 3 Chemistry, 3 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeB == "demon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Bodies, 4 Occult, 1 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else //if (Vars.typeB == "ritual")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationB);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Body, 1 ");
            yield return text(Vars.cost2B);
            yield return text(", 3 Occult, 3 ");
            yield return text(Vars.costB);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<i>Note: This Masterwork still requires 1 A Experiment, 2 B Experiments, and 3 C Experiments to be completed.</i>");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCompleteHubB   (passage148)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17273-17348
// Links:  -
// Aborts: -
// Purpose: Player B's Masterwork-completion journal excerpt
// ###################################################################

    void passage148_Init()
    {
        this.Passages[@"MWCompleteHubB"] = new StoryPassage(@"MWCompleteHubB", new string[] { }, passage148_Main);
    }

    IStoryThread passage148_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("The Work is Done", "I Have Done the Impossible", "My Legacy is Ensured", "AH HA HA HAAAAA!!!", "My Glorious Creation", "The Glory is Mine Forever!"));
            yield return text(" ");
            yield return text("- ");
            yield return text(Vars.nameB);
            yield return text(" ");
            yield return text("- Journal Entry Excerpt");
        }
        yield return lineBreak();
        if (Vars.typeB == "creature")
        {
            yield return text("Upon the stroke of midnight, lightning struck metal, sending a terrible electrica" +
            "l current through the machinery. My creation awoke, and with wild eyes gazed upo" +
            "n me, its creator. I had done it! I had created life!");
        }
        else if (Vars.typeB == "power")
        {
            yield return text("To see my work in the flesh, to see ");
            yield return text(Vars.creationB);
            yield return text(" finally realized; the passion of the moment overwhelmed my senses. I had done it." +
            " I shook my fist at God and all who doubted me! You were wrong! I am invincible!" +
            "");
        }
        else if (Vars.typeB == "robot")
        {
            yield return text("A brief, blinding flash and the work was done. I threw my goggles to the floor to" +
            " gaze upon my creation with my own eyes - ");
            yield return text(Vars.creationB);
            yield return text(". The polished metal surface whirred with interior mechanisms churning - then, gl" +
            "orious motion! Oh wondrous automaton, with you by my side the scientific world w" +
            "ill be humbled!");
        }
        else if (Vars.typeB == "weapon")
        {
            yield return text(@"I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (Vars.typeB == "medicine")
        {
            yield return text("I tapped the glass bottle, watching the liquid inside swirl and glow with the pur" +
            "ity of the mixture. The ");
            yield return text(Vars.creationB);
            yield return text(" had been a stunning success and once mass production could be attained, my family" +
            "\'s legacy would be secure. I laughed. Then, laughed again. My cacophonous laught" +
            "er echoed off the stone walls of my estate for years to come.");
        }
        else if (Vars.typeB == "drug")
        {
            yield return text("I observed the effects as the syringe filled with ");
            yield return text(Vars.creationB);
            yield return text(@" emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (Vars.typeB == "demon")
        {
            yield return text("The world darkened around me as the ");
            yield return text(Vars.creationB);
            yield return text(@" emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, ""Master."" I had done it. I was now in control and the world would rue the day they doubted ");
            yield return text(Vars.nameB);
            yield return text(" III!");
        }
        else //if (Vars.typeB == "ritual")
        {
            yield return text("The preparations proved tedious, but the resulting wave of spiritual energy as th" +
            "e ritual was completed left me standing in awe of my creation. The ");
            yield return text(Vars.creationB);
            yield return text(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: NewMHub   (passage149)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17354-17386
// Links:  -
// Aborts: -
// Purpose: Router advancing through each player's NewMaster creation flow; ends at NoUni1
// ###################################################################

    void passage149_Init()
    {
        this.Passages[@"NewMHub"] = new StoryPassage(@"NewMHub", new string[] { }, passage149_Main);
    }

    IStoryThread passage149_Main()
    {
        if (Vars.trig == Vars.players)
        {
            yield return abort(goToPassage: "NoUni1");
        }
        else if (Vars.trig == 1)
        {
            yield return abort(goToPassage: "NewMaster1B");
        }
        else if (Vars.trig == 2)
        {
            yield return abort(goToPassage: "NewMaster1C");
        }
        else if (Vars.trig == 3)
        {
            yield return abort(goToPassage: "NewMaster1D");
        }
        else if (Vars.trig == 4)
        {
            yield return abort(goToPassage: "NewMaster1E");
        }
        else
        {
            yield return abort(goToPassage: "NoUni1");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster1C   (passage150)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17392-17484
// Links:  -
// Aborts: -
// Purpose: Player C privately chooses their Masterwork's discipline
// ###################################################################

    void passage150_Init()
    {
        this.Passages[@"NewMaster1C"] = new StoryPassage(@"NewMaster1C", new string[] { }, passage150_Main);
    }

    IStoryThread passage150_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this Storybook device to ");
            yield return text(Vars.nameC);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        Vars.trig = 3;//int.Parse(Vars.trig) + 1;
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage150_Fragment_5);
        using (styleScope("hook", "h000150"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000150", HarloweEnchantCommand.Replace, passage150_Fragment_4));

        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage150_Fragment_0()
    {
        Vars.disC = "biology";
        yield return abort(goToPassage: "NewMaster2C");
        yield break;
    }

    IStoryThread passage150_Fragment_1()
    {
        Vars.disC = "engineering";
        yield return abort(goToPassage: "NewMaster2C");
        yield break;
    }

    IStoryThread passage150_Fragment_2()
    {
        Vars.disC = "chemistry";
        yield return abort(goToPassage: "NewMaster2C");
        yield break;
    }

    IStoryThread passage150_Fragment_3()
    {
        Vars.disC = "occult";
        yield return abort(goToPassage: "NewMaster2C");
        yield break;
    }

    IStoryThread passage150_Fragment_4()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Masterwork of My Own - ");
            yield return text(Vars.nameC);
            yield return text(" III");
        }
        yield return lineBreak();
        yield return text(@"I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation is from which scientific discipline?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00113"))
            yield return link("Biology.", null, () => enchantHook("h00113", HarloweEnchantCommand.Replace, passage150_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00114"))
            yield return link("Engineering.", null, () => enchantHook("h00114", HarloweEnchantCommand.Replace, passage150_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00115"))
            yield return link("Chemistry.", null, () => enchantHook("h00115", HarloweEnchantCommand.Replace, passage150_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00116"))
            yield return link("Occult.", null, () => enchantHook("h00116", HarloweEnchantCommand.Replace, passage150_Fragment_3));
        yield break;
    }

    IStoryThread passage150_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage150_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster2C   (passage151)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17489-17614
// Links:  -
// Aborts: -
// Purpose: Player C privately chooses their Masterwork's type/form
// ###################################################################

    void passage151_Init()
    {
        this.Passages[@"NewMaster2C"] = new StoryPassage(@"NewMaster2C", new string[] { }, passage151_Main);
    }

    IStoryThread passage151_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("What Type of Glorious Creation");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my unique ");
        yield return text(Vars.disC);
        yield return text(" ");
        yield return text("skills, this creation was already more focused and impressive than ever before. B" +
            "ut, what ingenious type of creation would I explore?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation could be described as what type?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.disC == "biology")
        {
            Vars.costC = macros1.either("Engineering", "Chemistry");
            using (styleScope("hook", "h00117"))
                yield return link("Creature.", null, () => enchantHook("h00117", HarloweEnchantCommand.Replace, passage151_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00118"))
                yield return link("Superpower.", null, () => enchantHook("h00118", HarloweEnchantCommand.Replace, passage151_Fragment_1));
            yield return lineBreak();
        }
        else if (Vars.disC == "engineering")
        {
            Vars.costC = macros1.either("Biology", "Chemistry");
            using (styleScope("hook", "h00119"))
                yield return link("Robot.", null, () => enchantHook("h00119", HarloweEnchantCommand.Replace, passage151_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00120"))
                yield return link("Weapon.", null, () => enchantHook("h00120", HarloweEnchantCommand.Replace, passage151_Fragment_3));
            yield return lineBreak();
        }
        else if (Vars.disC == "chemistry")
        {
            Vars.costC = macros1.either("Engineering", "Biology");
            using (styleScope("hook", "h00121"))
                yield return link("Medicine.", null, () => enchantHook("h00121", HarloweEnchantCommand.Replace, passage151_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00122"))
                yield return link("Drug.", null, () => enchantHook("h00122", HarloweEnchantCommand.Replace, passage151_Fragment_5));
            yield return lineBreak();
        }
        else //if (Vars.disC == "occult")
        {
            Vars.costC = macros1.either("Engineering", "Chemistry", "Biology");
            using (styleScope("hook", "h00123"))
                yield return link("Demonic Creature.", null, () => enchantHook("h00123", HarloweEnchantCommand.Replace, passage151_Fragment_6));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00124"))
                yield return link("Ritual.", null, () => enchantHook("h00124", HarloweEnchantCommand.Replace, passage151_Fragment_7));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage151_Fragment_0()
    {
        Vars.typeC = "creature";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_1()
    {
        Vars.typeC = "power";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_2()
    {
        Vars.typeC = "robot";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_3()
    {
        Vars.typeC = "weapon";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_4()
    {
        Vars.typeC = "medicine";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_5()
    {
        Vars.typeC = "drug";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_6()
    {
        Vars.typeC = "demon";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

    IStoryThread passage151_Fragment_7()
    {
        Vars.typeC = "ritual";
        yield return abort(goToPassage: "NewMaster3C");
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster3C   (passage152)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17619-17678
// Links:  NewMHub
// Aborts: -
// Purpose: Confirms player C's Masterwork; returns to NewMHub
// ###################################################################

    void passage152_Init()
    {
        this.Passages[@"NewMaster3C"] = new StoryPassage(@"NewMaster3C", new string[] { }, passage152_Main);
    }

    IStoryThread passage152_Main()
    {
        if (Vars.costC == "Biology")
        {
            Vars.cost2C = "Animal";
        }
        if (Vars.costC == "Engineering")
        {
            Vars.cost2C = "Gear";
        }
        if (Vars.costC == "Chemistry")
        {
            Vars.cost2C = "Bottle";
        }
        //yield return lineBreak();
        //Vars.creationC = ("rompt: Give your creation a new, majestic name:");
        if (ispopup)
        {
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("NewMaster3C", "Give your creation a new, majestic name:", "string", 0.5f);
        }
        else //if (ViewPopupPanel.instance.PassageValueString() != null)
        {
            Vars.creationC = ViewPopupPanel.instance.PassageValueString();
            ViewPopupPanel.instance.Clear();
            ispopup = true;
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The ");
            yield return text(macros1.either("Infamous", "Transcendent", "Monumental", "Nefarious", "Unspeakable", "Legendary", "Noble", "Phenomenal", "Stunning", "Masterful", "Insidious"));
            yield return text(" ");
            yield return text(Vars.creationC);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return passage("MWCreationHubC");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my own destiny determined, I resolved to forge a new path into the future an" +
            "d create my Masterwork.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("You may check the cost of completing your new Masterwork at any time by clicking " +
            "on your name on the main Storybook screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "NewMHub", null);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster1D   (passage153)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17684-17776
// Links:  -
// Aborts: -
// Purpose: Player D privately chooses their Masterwork's discipline
// ###################################################################

    void passage153_Init()
    {
        this.Passages[@"NewMaster1D"] = new StoryPassage(@"NewMaster1D", new string[] { }, passage153_Main);
    }

    IStoryThread passage153_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this Storybook device to ");
            yield return text(Vars.nameD);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        Vars.trig = 4;//int.Parse(Vars.trig) + 1;
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage153_Fragment_5);
        using (styleScope("hook", "h000153"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000153", HarloweEnchantCommand.Replace, passage153_Fragment_4));

        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage153_Fragment_0()
    {
        Vars.disD = "biology";
        yield return abort(goToPassage: "NewMaster2D");
        yield break;
    }

    IStoryThread passage153_Fragment_1()
    {
        Vars.disD = "engineering";
        yield return abort(goToPassage: "NewMaster2D");
        yield break;
    }

    IStoryThread passage153_Fragment_2()
    {
        Vars.disD = "chemistry";
        yield return abort(goToPassage: "NewMaster2D");
        yield break;
    }

    IStoryThread passage153_Fragment_3()
    {
        Vars.disD = "occult";
        yield return abort(goToPassage: "NewMaster2D");
        yield break;
    }

    IStoryThread passage153_Fragment_4()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Masterwork of My Own - ");
            yield return text(Vars.nameD);
            yield return text(" III");
        }
        yield return lineBreak();
        yield return text(@"I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation is from which scientific discipline?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00125"))
            yield return link("Biology.", null, () => enchantHook("h00125", HarloweEnchantCommand.Replace, passage153_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00126"))
            yield return link("Engineering.", null, () => enchantHook("h00126", HarloweEnchantCommand.Replace, passage153_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00127"))
            yield return link("Chemistry.", null, () => enchantHook("h00127", HarloweEnchantCommand.Replace, passage153_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00128"))
            yield return link("Occult.", null, () => enchantHook("h00128", HarloweEnchantCommand.Replace, passage153_Fragment_3));
        yield break;
    }

    IStoryThread passage153_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage153_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: MWCreationHubC   (passage154)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 17781-18051
// Links:  -
// Aborts: -
// Purpose: Player C's custom Masterwork recipe
// ###################################################################

    void passage154_Init()
    {
        this.Passages[@"MWCreationHubC"] = new StoryPassage(@"MWCreationHubC", new string[] { }, passage154_Main);
    }

    IStoryThread passage154_Main()
    {
        if (Vars.typeC == "creature")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Animals, 5 Biology, 1 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeC == "power")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Animal, 1 ");
            yield return text(Vars.cost2C);
            yield return text(", 3 Biology, 3 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeC == "robot")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Gears, 5 Engineering, 1 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeC == "weapon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Gear, 1 ");
            yield return text(Vars.cost2C);
            yield return text(", 4 Engineering, 2 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeC == "medicine")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Chemicals, 4 Chemistry, 2 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeC == "drug")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Bottle, 1 ");
            yield return text(Vars.cost2C);
            yield return text(", 3 Chemistry, 3 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeC == "demon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Bodies, 4 Occult, 1 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else //if (Vars.typeC == "ritual")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationC);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Body, 1 ");
            yield return text(Vars.cost2C);
            yield return text(", 3 Occult, 3 ");
            yield return text(Vars.costC);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<i>Note: This Masterwork still requires 1 A Experiment, 2 B Experiments, and 3 C Experiments to be completed.</i>");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCompleteHubC   (passage155)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18057-18132
// Links:  -
// Aborts: -
// Purpose: Player C's Masterwork-completion journal excerpt
// ###################################################################

    void passage155_Init()
    {
        this.Passages[@"MWCompleteHubC"] = new StoryPassage(@"MWCompleteHubC", new string[] { }, passage155_Main);
    }

    IStoryThread passage155_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("The Work is Done", "I Have Done the Impossible", "My Legacy is Ensured", "AH HA HA HAAAAA!!!", "My Glorious Creation", "The Glory is Mine Forever!"));
            yield return text(" ");
            yield return text("- ");
            yield return text(Vars.nameC);
            yield return text(" ");
            yield return text("- Journal Entry Excerpt");
        }
        yield return lineBreak();
        if (Vars.typeC == "creature")
        {
            yield return text("Upon the stroke of midnight, lightning struck metal, sending a terrible electrica" +
            "l current through the machinery. My creation awoke, and with wild eyes gazed upo" +
            "n me, its creator. I had done it! I had created life!");
        }
        else if (Vars.typeC == "power")
        {
            yield return text("To see my work in the flesh, to see ");
            yield return text(Vars.creationC);
            yield return text(" finally realized; the passion of the moment overwhelmed my senses. I had done it." +
            " I shook my fist at God and all who doubted me! You were wrong! I am invincible!" +
            "");
        }
        else if (Vars.typeC == "robot")
        {
            yield return text("A brief, blinding flash and the work was done. I threw my goggles to the floor to" +
            " gaze upon my creation with my own eyes  - ");
            yield return text(Vars.creationC);
            yield return text(". The polished metal surface whirred with interior mechanisms churning - then, gl" +
            "orious motion! Oh wondrous automaton, with you by my side the scientific world w" +
            "ill be humbled!");
        }
        else if (Vars.typeC == "weapon")
        {
            yield return text(@"I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (Vars.typeC == "medicine")
        {
            yield return text("I tapped the glass bottle, watching the liquid inside swirl and glow with the pur" +
            "ity of the mixture. The ");
            yield return text(Vars.creationC);
            yield return text(" had been a stunning success and once mass production could be attained, my family" +
            "\'s legacy would be secure. I laughed. Then, laughed again. My cacophonous laught" +
            "er echoed off the stone walls of my estate for years to come.");
        }
        else if (Vars.typeC == "drug")
        {
            yield return text("I observed the effects as the syringe filled with ");
            yield return text(Vars.creationC);
            yield return text(@" emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (Vars.typeC == "demon")
        {
            yield return text("The world darkened around me as the ");
            yield return text(Vars.creationC);
            yield return text(@" emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, ""Master."" I had done it. I was now in control and the world would rue the day they doubted ");
            yield return text(Vars.nameC);
            yield return text(" III!");
        }
        else //if (Vars.typeC == "ritual")
        {
            yield return text("The preparations proved tedious, but the resulting wave of spiritual energy as th" +
            "e ritual was completed left me standing in awe of my creation. The ");
            yield return text(Vars.creationC);
            yield return text(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster2D   (passage156)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18138-18263
// Links:  -
// Aborts: -
// Purpose: Player D privately chooses their Masterwork's type/form
// ###################################################################

    void passage156_Init()
    {
        this.Passages[@"NewMaster2D"] = new StoryPassage(@"NewMaster2D", new string[] { }, passage156_Main);
    }

    IStoryThread passage156_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("What Type of Glorious Creation");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my unique ");
        yield return text(Vars.disD);
        yield return text(" ");
        yield return text("skills, this creation was already more focused and impressive than ever before. B" +
            "ut, what ingenious type of creation would I explore?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("My creation could be described as what type?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.disD == "biology")
        {
            Vars.costD = macros1.either("Engineering", "Chemistry");
            using (styleScope("hook", "h00129"))
                yield return link("Creature.", null, () => enchantHook("h00129", HarloweEnchantCommand.Replace, passage156_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00130"))
                yield return link("Superpower.", null, () => enchantHook("h00130", HarloweEnchantCommand.Replace, passage156_Fragment_1));
            yield return lineBreak();
        }
        else if (Vars.disD == "engineering")
        {
            Vars.costD = macros1.either("Biology", "Chemistry");
            using (styleScope("hook", "h00131"))
                yield return link("Robot.", null, () => enchantHook("h00131", HarloweEnchantCommand.Replace, passage156_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00132"))
                yield return link("Weapon.", null, () => enchantHook("h00132", HarloweEnchantCommand.Replace, passage156_Fragment_3));
            yield return lineBreak();
        }
        else if (Vars.disD == "chemistry")
        {
            Vars.costD = macros1.either("Engineering", "Biology");
            using (styleScope("hook", "h00133"))
                yield return link("Medicine.", null, () => enchantHook("h00133", HarloweEnchantCommand.Replace, passage156_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00134"))
                yield return link("Drug.", null, () => enchantHook("h00134", HarloweEnchantCommand.Replace, passage156_Fragment_5));
            yield return lineBreak();
        }
        else //if (Vars.disD == "occult")
        {
            Vars.costD = macros1.either("Engineering", "Chemistry", "Biology");
            using (styleScope("hook", "h00135"))
                yield return link("Demonic Creature.", null, () => enchantHook("h00135", HarloweEnchantCommand.Replace, passage156_Fragment_6));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00136"))
                yield return link("Ritual.", null, () => enchantHook("h00136", HarloweEnchantCommand.Replace, passage156_Fragment_7));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage156_Fragment_0()
    {
        Vars.typeD = "creature";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_1()
    {
        Vars.typeD = "power";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_2()
    {
        Vars.typeD = "robot";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_3()
    {
        Vars.typeD = "weapon";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_4()
    {
        Vars.typeD = "medicine";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_5()
    {
        Vars.typeD = "drug";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_6()
    {
        Vars.typeD = "demon";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

    IStoryThread passage156_Fragment_7()
    {
        Vars.typeD = "ritual";
        yield return abort(goToPassage: "NewMaster3D");
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster3D   (passage157)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18268-18327
// Links:  NewMHub
// Aborts: -
// Purpose: Confirms player D's Masterwork; returns to NewMHub
// ###################################################################

    void passage157_Init()
    {
        this.Passages[@"NewMaster3D"] = new StoryPassage(@"NewMaster3D", new string[] { }, passage157_Main);
    }

    IStoryThread passage157_Main()
    {
        if (Vars.costD == "Biology")
        {
            Vars.cost2D = "Animal";
        }
        if (Vars.costD == "Engineering")
        {
            Vars.cost2D = "Gear";
        }
        if (Vars.costD == "Chemistry")
        {
            Vars.cost2D = "Bottle";
        }
        //yield return lineBreak();
        //Vars.creationD = ("rompt: Give your creation a new, majestic name:");
        if (ispopup)
        {
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("NewMaster3D", "Give your creation a new, majestic name:", "string", 0.5f);
        }
        else //if (ViewPopupPanel.instance.PassageValueString() != null)
        {
            Vars.creationD = ViewPopupPanel.instance.PassageValueString();
            ViewPopupPanel.instance.Clear();
            ispopup = true;
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The ");
            yield return text(macros1.either("Infamous", "Transcendent", "Monumental", "Nefarious", "Unspeakable", "Legendary", "Noble", "Phenomenal", "Stunning", "Masterful", "Insidious"));
            yield return text(" ");
            yield return text(Vars.creationD);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return passage("MWCreationHubD");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my own destiny determined, I resolved to forge a new path into the future an" +
            "d create my Masterwork.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("You may check the cost of completing your new Masterwork at any time by clicking " +
            "on your name on the main Storybook screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "NewMHub", null);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster1E   (passage158)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18333-18429
// Links:  -
// Aborts: -
// Purpose: Player E privately chooses their Masterwork's discipline
// ###################################################################

    void passage158_Init()
    {
        this.Passages[@"NewMaster1E"] = new StoryPassage(@"NewMaster1E", new string[] { }, passage158_Main);
    }

    IStoryThread passage158_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this Storybook device to ");
            yield return text(Vars.nameE);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        Vars.trig = 5;//int.Parse(Vars.trig) + 1;
        //yield return text("Once you are ready, click here to reveal your secret conversation.");/
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage158_Fragment_5);
        using (styleScope("hook", "h000158"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000158", HarloweEnchantCommand.Replace, passage158_Fragment_4));

        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage158_Fragment_0()
    {
        Vars.disE = "biology";
        yield return abort(goToPassage: "NewMaster2E");
        yield break;
    }

    IStoryThread passage158_Fragment_1()
    {
        Vars.disE = "engineering";
        yield return abort(goToPassage: "NewMaster2E");
        yield break;
    }

    IStoryThread passage158_Fragment_2()
    {
        Vars.disE = "chemistry";
        yield return abort(goToPassage: "NewMaster2E");
        yield break;
    }

    IStoryThread passage158_Fragment_3()
    {
        Vars.disE = "occult";
        yield return abort(goToPassage: "NewMaster2E");
        yield break;
    }

    IStoryThread passage158_Fragment_4()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Masterwork of My Own - ");
            yield return text(Vars.nameE);
            yield return text(" III");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("My creation is from which scientific discipline?");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00137"))
            yield return link("Biology.", null, () => enchantHook("h00137", HarloweEnchantCommand.Replace, passage158_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00138"))
            yield return link("Engineering.", null, () => enchantHook("h00138", HarloweEnchantCommand.Replace, passage158_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00139"))
            yield return link("Chemistry.", null, () => enchantHook("h00139", HarloweEnchantCommand.Replace, passage158_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00140"))
            yield return link("Occult.", null, () => enchantHook("h00140", HarloweEnchantCommand.Replace, passage158_Fragment_3));
        yield break;
    }

    IStoryThread passage158_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage158_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster2E   (passage159)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18434-18562
// Links:  -
// Aborts: -
// Purpose: Player E privately chooses their Masterwork's type/form
// ###################################################################

    void passage159_Init()
    {
        this.Passages[@"NewMaster2E"] = new StoryPassage(@"NewMaster2E", new string[] { }, passage159_Main);
    }

    IStoryThread passage159_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("What Type of Glorious Creation");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my unique ");
        yield return text(Vars.disE);
        yield return text(" ");
        yield return text("skills, this creation was already more focused and impressive than ever before. B" +
            "ut, what ingenious type of creation would I explore?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("My creation could be described as what Type?");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.disE == "biology")
        {
            Vars.costE = macros1.either("Engineering", "Chemistry");
            using (styleScope("hook", "h00141"))
                yield return link("Creature.", null, () => enchantHook("h00141", HarloweEnchantCommand.Replace, passage159_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00142"))
                yield return link("Superpower.", null, () => enchantHook("h00142", HarloweEnchantCommand.Replace, passage159_Fragment_1));
            yield return lineBreak();
        }
        else if (Vars.disE == "engineering")
        {
            Vars.costE = macros1.either("Biology", "Chemistry");
            using (styleScope("hook", "h00143"))
                yield return link("Robot.", null, () => enchantHook("h00143", HarloweEnchantCommand.Replace, passage159_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00144"))
                yield return link("Weapon.", null, () => enchantHook("h00144", HarloweEnchantCommand.Replace, passage159_Fragment_3));
            yield return lineBreak();
        }
        else if (Vars.disE == "chemistry")
        {
            Vars.costE = macros1.either("Engineering", "Biology");
            using (styleScope("hook", "h00145"))
                yield return link("Medicine.", null, () => enchantHook("h00145", HarloweEnchantCommand.Replace, passage159_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00146"))
                yield return link("Drug.", null, () => enchantHook("h00146", HarloweEnchantCommand.Replace, passage159_Fragment_5));
            yield return lineBreak();
        }
        else //if (Vars.disE == "occult")
        {
            Vars.costE = macros1.either("Engineering", "Chemistry", "Biology");
            using (styleScope("hook", "h00147"))
                yield return link("Demonic Creature.", null, () => enchantHook("h00147", HarloweEnchantCommand.Replace, passage159_Fragment_6));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00148"))
                yield return link("Ritual.", null, () => enchantHook("h00148", HarloweEnchantCommand.Replace, passage159_Fragment_7));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage159_Fragment_0()
    {
        Vars.typeE = "creature";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_1()
    {
        Vars.typeE = "power";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_2()
    {
        Vars.typeE = "robot";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_3()
    {
        Vars.typeE = "weapon";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_4()
    {
        Vars.typeE = "medicine";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_5()
    {
        Vars.typeE = "drug";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_6()
    {
        Vars.typeE = "demon";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

    IStoryThread passage159_Fragment_7()
    {
        Vars.typeE = "ritual";
        yield return abort(goToPassage: "NewMaster3E");
        yield break;
    }

// ###################################################################
// PASSAGE: MWCreationHubD   (passage161)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18657-18927
// Links:  -
// Aborts: -
// Purpose: Player D's custom Masterwork recipe
// ###################################################################

    void passage161_Init()
    {
        this.Passages[@"MWCreationHubD"] = new StoryPassage(@"MWCreationHubD", new string[] { }, passage161_Main);
    }

    IStoryThread passage161_Main()
    {
        if (Vars.typeD == "creature")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Animals, 5 Biology, 1 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeD == "power")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Animal, 1 ");
            yield return text(Vars.cost2D);
            yield return text(", 3 Biology, 3 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeD == "robot")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Gears, 5 Engineering, 1 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeD == "weapon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Gear, 1 ");
            yield return text(Vars.cost2D);
            yield return text(", 4 Engineering, 2 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeD == "medicine")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Chemicals, 4 Chemistry, 2 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeD == "drug")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Bottle, 1 ");
            yield return text(Vars.cost2D);
            yield return text(", 3 Chemistry, 3 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeD == "demon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Bodies, 4 Occult, 1 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else //if (Vars.typeD == "ritual")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationD);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Body, 1 ");
            yield return text(Vars.cost2D);
            yield return text(", 3 Occult, 3 ");
            yield return text(Vars.costD);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<i>Note: This Masterwork still requires 1 A Experiment, 2 B Experiments, and 3 C Experiments to be completed.</i>");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCompleteHubD   (passage162)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18933-19008
// Links:  -
// Aborts: -
// Purpose: Player D's Masterwork-completion journal excerpt
// ###################################################################

    void passage162_Init()
    {
        this.Passages[@"MWCompleteHubD"] = new StoryPassage(@"MWCompleteHubD", new string[] { }, passage162_Main);
    }

    IStoryThread passage162_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("The Work is Done", "I Have Done the Impossible", "My Legacy is Ensured", "AH HA HA HAAAAA!!!", "My Glorious Creation", "The Glory is Mine Forever!"));
            yield return text(" ");
            yield return text("- ");
            yield return text(Vars.nameD);
            yield return text(" ");
            yield return text("- Journal Entry Excerpt");
        }
        yield return lineBreak();
        if (Vars.typeD == "creature")
        {
            yield return text("Upon the stroke of midnight, lightning struck metal, sending a terrible electrica" +
            "l current through the machinery. My creation awoke, and with wild eyes gazed upo" +
            "n me, its creator. I had done it! I had created life!");
        }
        else if (Vars.typeD == "power")
        {
            yield return text("To see my work in the flesh, to see ");
            yield return text(Vars.creationD);
            yield return text(" finally realized; the passion of the moment overwhelmed my senses. I had done it." +
            " I shook my fist at God and all who doubted me! You were wrong! I am invincible!" +
            "");
        }
        else if (Vars.typeD == "robot")
        {
            yield return text("A brief, blinding flash and the work was done. I threw my goggles to the floor to" +
            " gaze upon my creation with my own eyes - ");
            yield return text(Vars.creationD);
            yield return text(". The polished metal surface whirred with interior mechanisms churning - then, gl" +
            "orious motion! Oh wondrous automaton, with you by my side the scientific world w" +
            "ill be humbled!");
        }
        else if (Vars.typeD == "weapon")
        {
            yield return text(@"I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (Vars.typeD == "medicine")
        {
            yield return text("I tapped the glass bottle, watching the liquid inside swirl and glow with the pur" +
            "ity of the mixture. The ");
            yield return text(Vars.creationD);
            yield return text(" had been a stunning success and once mass production could be attained, my family" +
            "\'s legacy would be secure. I laughed. Then, laughed again. My cacophonous laught" +
            "er echoed off the stone walls of my estate for years to come.");
        }
        else if (Vars.typeD == "drug")
        {
            yield return text("I observed the effects as the syringe filled with ");
            yield return text(Vars.creationD);
            yield return text(@" emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (Vars.typeD == "demon")
        {
            yield return text("The world darkened around me as the ");
            yield return text(Vars.creationD);
            yield return text(@" emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, ""Master."" I had done it. I was now in control and the world would rue the day they doubted ");
            yield return text(Vars.nameD);
            yield return text(" III!");
        }
        else //if (Vars.typeD == "ritual")
        {
            yield return text("The preparations proved tedious, but the resulting wave of spiritual energy as th" +
            "e ritual was completed left me standing in awe of my creation. The ");
            yield return text(Vars.creationD);
            yield return text(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: CreepyStar   (passage163)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 19014-19070
// Links:  ImmortalNoUni
// Aborts: -
// Purpose: "A Grudge Towards Intellect": VP leader gains 2 Creepy; gateway to Immortality/Panacea setup
// ###################################################################

    void passage163_Init()
    {
        this.Passages[@"CreepyStar"] = new StoryPassage(@"CreepyStar", new string[] { }, passage163_Main);
    }

    IStoryThread passage163_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Grudge Towards Intellect");
        }
        yield return lineBreak();
        yield return text(@"As many found solace in drink and the blackening of the liver, this alcoholic inebriety soon devolved into open displays of unfounded accusations against those who displayed even a modest bit of intellect. They took a sense of malformed pride in the depths of their ignorance.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The reputation of a famed scientist, however mild in its influence over the scholars in Budapest, was firmly reviled by the faith-driven townsfolk. It was an easy target to blame their misfortunes upon. They would spit on the ground and whisper curses under their breath as the best known of the family walked by.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage163_Fragment_1);
        using (styleScope("hook", "h000163"))
            yield return link("Click to continue...", null, () => enchantHook("h000163", HarloweEnchantCommand.Replace, passage163_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage163_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.life == 0 ? Vars.pana == "unleash" ? "PanaceaUnleashCons1" : "NewMaster" : "ImmortalNoUni";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The player(s) with the most victory points immediately ");
            using (styleScope("bold", true))
            {
                yield return text("gains 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "ImmortalNoUni", null);
        yield break;
    }

    IStoryThread passage163_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage163_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: PanaceaUnleashCons1   (passage232)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25729-25784
// Links:  NewMaster
// Aborts: -
// Purpose: "Whispers Abate": rumors fade; players recover a Servant from the box to Lost
// ###################################################################

    void passage232_Init()
    {
        this.Passages[@"PanaceaUnleashCons1"] = new StoryPassage(@"PanaceaUnleashCons1", new string[] { }, passage232_Main);
    }

    IStoryThread passage232_Main()
    {
        if (Vars.pana == "unleash")
        {
            using (styleScope("bold", true))
            {
                yield return text("Whispers Abate");
            }
            yield return lineBreak();
            yield return text(@"With the passing of the generation, the hideous and well-founded rumors regarding the grisly demise and otherwise negative treatment of servants in the family's households faded into history. As considerably misguided as it was, the allure of steady employ once again attracted new applicants to the estates once more.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage232_Fragment_1);
            using (styleScope("hook", "h000232"))
                yield return link("Click to continue...", null, () => enchantHook("h000232", HarloweEnchantCommand.Replace, passage232_Fragment_0));
        }
        else
        {
            yield return abort(goToPassage: "NewMaster");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "NewMaster", null);
        //yield return lineBreak();
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage232_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "NewMaster";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Servant";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any players with a Servant in the game box retrieves it from the box and adds it " +
                "to Lost.");
        }
        yield break;
    }

    IStoryThread passage232_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage232_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: NewMaster3E   (passage237)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26124-26183
// Links:  NewMHub
// Aborts: -
// Purpose: Player E's Create-A-Masterwork step; returns to the new-Masterwork hub
// ###################################################################

    void passage237_Init()
    {
        this.Passages[@"NewMaster3E"] = new StoryPassage(@"NewMaster3E", new string[] { }, passage237_Main);
    }

    IStoryThread passage237_Main()
    {
        if (Vars.costE == "Biology")
        {
            Vars.cost2E = "Animal";
        }
        if (Vars.costE == "Engineering")
        {
            Vars.cost2E = "Gear";
        }
        if (Vars.costE == "Chemistry")
        {
            Vars.cost2E = "Bottle";
        }
        //yield return lineBreak();
        //Vars.creationE = ("rompt: Give your creation a new, majestic name:");
        if (ispopup)
        {
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("NewMaster3E", "Give your creation a new, majestic name:", "string", 0.5f);
        }
        else //if (ViewPopupPanel.instance.PassageValueString() != null)
        {
            Vars.creationE = ViewPopupPanel.instance.PassageValueString();
            ViewPopupPanel.instance.Clear();
            ispopup = true;
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The ");
            yield return text(macros1.either("Infamous", "Transcendent", "Monumental", "Nefarious", "Unspeakable", "Legendary", "Noble", "Phenomenal", "Stunning", "Masterful", "Insidious"));
            yield return text(" ");
            yield return text(Vars.creationE);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return passage("MWCreationHubE");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With my own destiny determined, I resolved to forge a new path into the future an" +
            "d create my Masterwork.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("You may check the cost of completing your new Masterwork at any time by clicking " +
            "on your name on the main Storybook screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "NewMHub", null);
        yield break;
    }

// ###################################################################
// PASSAGE: MWCreationHubE   (passage238)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26189-26459
// Links:  -
// Aborts: -
// Purpose: Player E's Masterwork cost/reward reference sheet
// ###################################################################

    void passage238_Init()
    {
        this.Passages[@"MWCreationHubE"] = new StoryPassage(@"MWCreationHubE", new string[] { }, passage238_Main);
    }

    IStoryThread passage238_Main()
    {
        if (Vars.typeE == "creature")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Animals, 5 Biology, 1 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeE == "power")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Animal, 1 ");
            yield return text(Vars.cost2E);
            yield return text(", 3 Biology, 3 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeE == "robot")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Gears, 5 Engineering, 1 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeE == "weapon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Gear, 1 ");
            yield return text(Vars.cost2E);
            yield return text(", 4 Engineering, 2 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeE == "medicine")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Chemicals, 4 Chemistry, 2 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeE == "drug")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Bottle, 1 ");
            yield return text(Vars.cost2E);
            yield return text(", 3 Chemistry, 3 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 19VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else if (Vars.typeE == "demon")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("2 Bodies, 4 Occult, 1 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 21VP.");
            yield return lineBreak();
            yield return text("Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        else //if (Vars.typeE == "ritual")
        {
            using (styleScope("bold", true))
            {
                yield return text(Vars.creationE);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Cost:");
            }
            yield return lineBreak();
            yield return text("1 Body, 1 ");
            yield return text(Vars.cost2E);
            yield return text(", 3 Occult, 3 ");
            yield return text(Vars.costE);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Reward:");
            }
            yield return lineBreak();
            yield return text("Gain 20VP.");
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(", Gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(", Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<i>Note: This Masterwork still requires 1 A Experiment, 2 B Experiments, and 3 C Experiments to be completed.</i>");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MWCompleteHubE   (passage239)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26465-26540
// Links:  -
// Aborts: -
// Purpose: Player E's Masterwork completion journal entry
// ###################################################################

    void passage239_Init()
    {
        this.Passages[@"MWCompleteHubE"] = new StoryPassage(@"MWCompleteHubE", new string[] { }, passage239_Main);
    }

    IStoryThread passage239_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("The Work is Done", "I Have Done the Impossible", "My Legacy is Ensured", "AH HA HA HAAAAA!!!", "My Glorious Creation", "The Glory is Mine Forever!"));
            yield return text(" ");
            yield return text("- ");
            yield return text(Vars.nameE);
            yield return text(" ");
            yield return text("- Journal Entry Excerpt");
        }
        yield return lineBreak();
        if (Vars.typeE == "creature")
        {
            yield return text("Upon the stroke of midnight, lightning struck metal, sending a terrible electrica" +
            "l current through the machinery. My creation awoke, and with wild eyes gazed upo" +
            "n me, its creator. I had done it! I had created life!");
        }
        else if (Vars.typeE == "power")
        {
            yield return text("To see my work in the flesh, to see ");
            yield return text(Vars.creationE);
            yield return text(" finally realized; the passion of the moment overwhelmed my senses. I had done it." +
            " I shook my fist at God and all who doubted me! You were wrong! I am invincible!" +
            "");
        }
        else if (Vars.typeE == "robot")
        {
            yield return text("A brief, blinding flash and the work was done. I threw my goggles to the floor to" +
            " gaze upon my creation with my own eyes - ");
            yield return text(Vars.creationE);
            yield return text(". The polished metal surface whirred with interior mechanisms churning - then, gl" +
            "orious motion! Oh wondrous automaton, with you by my side the scientific world w" +
            "ill be humbled!");
        }
        else if (Vars.typeE == "weapon")
        {
            yield return text(@"I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (Vars.typeE == "medicine")
        {
            yield return text("I tapped the glass bottle, watching the liquid inside swirl and glow with the pur" +
            "ity of the mixture. The ");
            yield return text(Vars.creationE);
            yield return text(" had been a stunning success and once mass production could be attained, my family" +
            "\'s legacy would be secure. I laughed. Then, laughed again. My cacophonous laught" +
            "er echoed off the stone walls of my estate for years to come.");
        }
        else if (Vars.typeE == "drug")
        {
            yield return text("I observed the effects as the syringe filled with ");
            yield return text(Vars.creationE);
            yield return text(@" emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (Vars.typeD == "demon")
        {
            yield return text("The world darkened around me as the ");
            yield return text(Vars.creationE);
            yield return text(@" emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, ""Master."" I had done it. I was now in control and the world would rue the day they doubted ");
            yield return text(Vars.nameE);
            yield return text(" III!");
        }
        else //if (Vars.typeD == "ritual")
        {
            yield return text("The preparations proved tedious, but the resulting wave of spiritual energy as th" +
            "e ritual was completed left me standing in awe of my creation. The ");
            yield return text(Vars.creationE);
            yield return text(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: CureNegCons   (passage240)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26546-26625
// Links:  OptiontoKillStart
// Aborts: -
// Purpose: Anti-inoculation backlash: Angry Mob advances; the cure's author gains Creepy + Insanity
// ###################################################################

    void passage240_Init()
    {
        this.Passages[@"CureNegCons"] = new StoryPassage(@"CureNegCons", new string[] { }, passage240_Main);
    }

    IStoryThread passage240_Main()
    {
        //if (Vars.cured == 1)
        //{
        using (styleScope("bold", true))
        {
            yield return text("Distrust in Medicine");
        }
        yield return lineBreak();
        yield return text(@"With the Hospital slowly falling into disrepair, the church took great measures to warn the populace of the dangers of inoculation, espousing the virtues of alternative homeopathic remedies and pious living. Inevitably, this led to clusters of Yellow Fever once again appearing within the region.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Having no target for their anger, in a befuddled daze, they turned against the sc" +
        "ientist responsible for introducing the cure, without whom this self-inflicted m" +
        "oral dilemma would never have existed.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage240_Fragment_1);
        using (styleScope("hook", "h000240"))
            yield return link("Click to continue...", null, () => enchantHook("h000240", HarloweEnchantCommand.Replace, passage240_Fragment_0));
        //}
        //else
        //{
        //    yield return abort(goToPassage: "OptiontoKillStart");
        //}
        yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "OptiontoKillStart", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage240_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "OptiontoKillStart";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AngryMob_Icon";
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Move the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token 1 space to the left. ");
            }
            if (Vars.fevercure == "" || Vars.fevercure == 0)
                Vars.fevercure = Vars.nameA;
            yield return text(Vars.fevercure);
            yield return text(" immediately ");
            using (styleScope("bold", true))
            {
                yield return text("gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" and ");
            using (styleScope("bold", true))
            {
                yield return text("gains 1 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
            }
            yield return text(".");
        }
        yield break;
    }

    IStoryThread passage240_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage240_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: NoUni3Note   (passage260)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27898-27936
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: Barventures / Create-A-Masterwork branch
// ###################################################################

    void passage260_Init()
    {
        this.Passages[@"NoUni3Note"] = new StoryPassage(@"NoUni3Note", new string[] { }, passage260_Main);
    }

    IStoryThread passage260_Main()
    {
        yield return text("Barventures -");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("MASTERWORK REMOVED");
        yield return lineBreak();
        yield return text("Immortality reward");
        yield return lineBreak();
        yield return text("(Panacea return)");
        yield return lineBreak();
        yield return text("CREATE-A-MASTERWORK");
        yield return lineBreak();
        yield return text("Storybook Event - Barventures");
        yield return lineBreak();
        yield return text("Event - VOTE - to introduce Electricity to the town. They may not like it. It may" +
            " not be worth the trouble, but the benefits could allow them to Experiment more " +
            "quickly.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Reset Creepy Meter by visiiting Pub, then consult the Storybook.");
        yield return lineBreak();
        yield return text("Knowledge is Creepy - gain Creepy for each Knowledge you have at the end of a rou" +
            "nd.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Create-A-Masterwork");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Kinda makes no sense that Immortality occurs along with MW destruction.");
        yield break;
    }

// ###################################################################
// PASSAGE: roundEndKnowledge   (passage261)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27942-28019
// Links:  CureNegCons,NoUniMayornCreepy
// Aborts: -
// Purpose: End-of-round penalty: Creepy for each Knowledge cube in your Quarters
// ###################################################################

    void passage261_Init()
    {
        this.Passages[@"roundEndKnowledge"] = new StoryPassage(@"roundEndKnowledge", new string[] { }, passage261_Main);
    }

    IStoryThread passage261_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Curse of Knowledge");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return text("The townsfolk chose to remain ignorant of the technological advances of the age. " +
            "Not only did they begrudge and mistrust the wealth of knowledge that the cousins" +
            " had accrued, they hated them for it.");
        }
        //if (Vars.round == 17)
        else
        {
            yield return text("The hostility had not abated. If anything, time had proven the townsfolk steadfas" +
            "t in their unsophisticated point of view. The perils of blind faith and excessiv" +
            "e drink manifested in the gloom that surrounded the ashen streets.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage261_Fragment_1);
        using (styleScope("hook", "h000261"))
            yield return link("Click to continue...", null, () => enchantHook("h000261", HarloweEnchantCommand.Replace, passage261_Fragment_0));
        yield break;
    }

    IStoryThread passage261_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = Vars.round == 16 ? "CureNegCons" : "NoUniMayornCreepy";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Each player gains ");
            using (styleScope("bold", true))
            {
                yield return text("1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("for ");
            using (styleScope("bold", true))
            {
                yield return text("each");
            }
            yield return text(" ");
            yield return text("Knowledge cube in their Quarters.");
        }
        yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 16)
        //{
        //    yield return link("Click to continue...", "CureNegCons", null);
        //}
        //if (Vars.round == 17)
        //{
        //    yield return link("Click to continue...", "NoUniMayornCreepy", null);
        //}
        yield break;
    }

    IStoryThread passage261_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage261_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: OptiontoKillYes   (passage280)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28978-29041
// Links:  OptiontoKillQuestion
// Aborts: -
// Purpose: "The Inevitable": discard an Immortality card for Body/VP at the cost of a Caretaker
// ###################################################################

    void passage280_Init()
    {
        this.Passages[@"OptiontoKillYes"] = new StoryPassage(@"OptiontoKillYes", new string[] { }, passage280_Main);
    }

    IStoryThread passage280_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Inevitable");
        }
        yield return lineBreak();
        yield return text(@"While I struggle to insinuate such an onerous deed, the cousins were correct in assuming the worst. Whether intentional or merely a byproduct of the stresses of advanced aging on the mind, there would soon be horrible and unknowable consequences for unnaturally extending one's existence.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Did they take this opportunity to experiment upon their own flesh and blood? Or w" +
            "as this only coincidental, and was the continued promise of additional help arou" +
            "nd the Estate worth the potential negatives to come?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        yield return text("In turn order, any player with an ");
        using (styleScope("bold", true))
        {
            yield return text("Immortality card");
        }
        yield return text(" ");
        yield return text("can choose to discard it to the scenario box.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If a player ");
        using (styleScope("bold", true))
        {
            yield return text("discards an Immortality card");
        }
        yield return text(", they immediately:");
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Gain 1 Body,");
        }
        yield return text(" Lose 1");
        yield return text("<sprite=\"Insanity_Icon\" index=0>,");
        yield return text(" ");
        yield return text("and Gain 1VP");
        yield return text(". Then");
        yield return text(" ");
        yield return text("they must return a ");
        yield return text("Caretaker");
        yield return text(" ");
        yield return text("piece to Lost.\n\nIf a player chooses to keep their Immortality card,");
        yield return text(" ");
        yield return text("they receive no special bonus and also keep their ");
        yield return text("<b>Caretaker</b>");
        yield return text(" ");
        yield return text("piece.\n\nOnce all players have chosen");
        yield return text(" \n");
        yield return link("click here to continue", "OptiontoKillQuestion", null);
        yield break;
    }

// ###################################################################
// PASSAGE: OptiontoKillStart   (passage281)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29047-29078
// Links:  OptiontoKillYes
// Aborts: -
// Purpose: Intro to the immortality/caretaker paranoia event
// ###################################################################

    void passage281_Init()
    {
        this.Passages[@"OptiontoKillStart"] = new StoryPassage(@"OptiontoKillStart", new string[] { }, passage281_Main);
    }

    IStoryThread passage281_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Peculiar Biological Study");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"During this time, the cousins' journal entries became increasingly paranoid about the work of their remarkably hardy parental figures. Not only did they describe a feeling of anxiety from their constant negativity and criticism, but there was a growing fear that they were actively sabotaging the experiments.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Coincidentally, several journal entries, dated over the course of the first months in the year of 1891, form a collective study on human anatomy. Contained within these pages are detailed sketches of exposed muscle fibers with cross-sections of the various strains upon veins and arteries. The age of the subject is especially advanced, providing exceptional clarity on how this has affected the structure and blood flow of these areas.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It is only in the final pages that the unnamed subject (or subjects?) is referred" +
            " to as \"deceased.\" The note reads:");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("\"Subject deceased. Over these months, I believe I have become even closer to my p" +
            "arent than ever before. If only we could have had more time together; so much st" +
            "ill to learn. It is so silent in the laboratory now.\"");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "OptiontoKillYes", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5SpecialVote   (passage282)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29084-29146
// Links:  S5SpecialVote2
// Aborts: -
// Purpose: Vote on bringing electricity to the town (discounted experiments vs angry mob)
// ###################################################################

    void passage282_Init()
    {
        this.Passages[@"S5SpecialVote"] = new StoryPassage(@"S5SpecialVote", new string[] { }, passage282_Main);
    }

    IStoryThread passage282_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return text("Retrieve the Voting tokens from the box. Each player takes a Voting token into th" +
            "eir fist and chooses a side. When all players have chosen, all players simultane" +
            "ously reveal their vote.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Yay");
        }
        yield return text(" ");
        yield return text("is a vote to facilitate electricity, which will ");
        using (styleScope("bold", true))
        {
            yield return text("allow us to complete experiments at a discounted cost");
        }
        yield return text(" ");
        yield return text("despite the fact that it may enrage the populace into ");
        using (styleScope("bold", true))
        {
            yield return text("destruction of property");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Nay");
        }
        yield return text(" ");
        yield return text("is vote to reject electricity and support the obstinate masses.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("(Ties are broken, by the last player in turn order.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the vote", "S5SpecialVote2", null);
        using (styleScope("hook", "h0000282"))
            yield return link("Click here to start the vote...", null, () => enchantHook("h0000282", HarloweEnchantCommand.None, passage282_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage282_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("S5SpecialVote2", BiddingSystem.Voting);
        yield break;
    }

// ###################################################################
// PASSAGE: OptiontoKillQuestion   (passage283)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29151-29184
// Links:  DetEffectRandom
// Aborts: -
// Purpose: Asks whether any Immortality cards remain; branches to the effect randomizer
// ###################################################################

    void passage283_Init()
    {
        this.Passages[@"OptiontoKillQuestion"] = new StoryPassage(@"OptiontoKillQuestion", new string[] { }, passage283_Main);
    }

    IStoryThread passage283_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Immortality Check");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Are there any players with Immortality cards remaining in their possession?");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Yes.", "DetEffectRandom", null);
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00196"))
            yield return link("No.", null, () => enchantHook("h00196", HarloweEnchantCommand.Replace, passage283_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage283_Fragment_0()
    {
        Vars.imm = "none";
        yield return abort(goToPassage: "NoUni2");
        yield break;
    }

// ###################################################################
// PASSAGE: NoUniMayornCreepy   (passage284)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29189-29275
// Links:  S5Specialbar1
// Aborts: -
// Purpose: "A Somber End": mayor/heart token holders draw a Compulsion and return their tokens
// ###################################################################

    void passage284_Init()
    {
        this.Passages[@"NoUniMayornCreepy"] = new StoryPassage(@"NoUniMayornCreepy", new string[] { }, passage284_Main);
    }

    IStoryThread passage284_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Somber End");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("\"Fat lot of good your family\'s \'contribution to society\' has done for us!\" The pa" +
            "trons would sneer upon their approach. \"I used to have Yellow Fever. Now I\'ve go" +
            "t Yellow Fever AND an insufferable doctor trying to tell me what to do!\"");
        Vars.gen3pg = 0;
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The townsfolk showed little respect for the family\'s past political and charitabl" +
            "e stances and they expressed their derision at every opportunity. This resulted" +
            " in significant perturbation.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage284_Fragment_1);
        using (styleScope("hook", "h000284"))
            yield return link("Click to continue...", null, () => enchantHook("h000284", HarloweEnchantCommand.Replace, passage284_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage284_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "S5Specialbar1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "CompulsionBack";
            yield return lineBreak();
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("III ");
            using (styleScope("bold", true))
            {
                yield return text("draws 1 Compulsion");
            }
            yield return text(" ");
            yield return text("and returns the ");
            using (styleScope("bold", true))
            {
                yield return text("Commemorative Mayoral Coin");
            }
            yield return text(" ");
            yield return text("token to the scenario box.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("III ");
            using (styleScope("bold", true))
            {
                yield return text("draws 1 Compulsion");
            }
            yield return text(" ");
            yield return text("and returns the ");
            using (styleScope("bold", true))
            {
                yield return text("Heart <sprite=\"S1_HeartToken\" index=0> token");
            }
            yield return text(" ");
            yield return text("token to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "S5Specialbar1", null);
        yield break;
    }

    IStoryThread passage284_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage284_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: MWNote   (passage285)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29280-29292
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: cannot strip "the"/"a" from Masterwork titles in code
// ###################################################################

    void passage285_Init()
    {
        this.Passages[@"MWNote"] = new StoryPassage(@"MWNote", new string[] { }, passage285_Main);
    }

    IStoryThread passage285_Main()
    {
        yield return text("One thing I was unable to do with coding is figure out how to remove the articles" +
            " \"the\" and \"a\" from the start of someone\'s title. Many people start with THE and" +
            " I\'d like to remove that and add it again when describing it on the confirmation" +
            " page.");
        yield break;
    }

// ###################################################################
// PASSAGE: MWCheckComplete   (passage286)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29298-29353
// Links:  MWComplete,NoUni1,NoUni2,NoUni3
// Aborts: -
// Purpose: Masterwork completion confirmation; returns to NoUni1/2/3
// ###################################################################

    void passage286_Init()
    {
        this.Passages[@"MWCheckComplete"] = new StoryPassage(@"MWCheckComplete", new string[] { }, passage286_Main);
    }

    IStoryThread passage286_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Reveal this screen to all players to confirm your Masterwork has been completed.");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.tempcomp == Vars.nameA)
        {
            yield return passage("MWCreationHubA");
        }
        else if (Vars.tempcomp == Vars.nameB)
        {
            yield return passage("MWCreationHubB");
        }
        else if (Vars.tempcomp == Vars.nameC)
        {
            yield return passage("MWCreationHubC");
        }
        else if (Vars.tempcomp == Vars.nameD)
        {
            yield return passage("MWCreationHubD");
        }
        else if (Vars.tempcomp == Vars.nameE)
        {
            yield return passage("MWCreationHubE");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If you have paid all necessary costs and completed your Masterwork, ");
        yield return link("click here to continue...", "MWComplete", null);
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return link("If not, click to return...", "NoUni1", null);
        }
        else if (Vars.round == 17)
        {
            yield return link("If not, click to return...", "NoUni2", null);
        }
        //if (Vars.round == 18)
        else
        {
            yield return link("If not, click to return...", "NoUni3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: 2p-S5SpecialVoteALT   (passage336)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33949-34022
// Links:  2p-S5SpecialVoteALT2
// Aborts: -
// Purpose: 2-player ALT: money bid for the right to accept or reject electricity
// ###################################################################

    void passage336_Init()
    {
        this.Passages[@"2p-S5SpecialVoteALT"] = new StoryPassage(@"2p-S5SpecialVoteALT", new string[] { }, passage336_Main);
    }

    IStoryThread passage336_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("BID");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return text("All players take all of their money into their hands. They then secretly choose a" +
            "ny amount to place in their right hand to bid on choosing the outcome.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The winning player will ");
        using (styleScope("bold", true))
        {
            yield return text("gain 3VP");
        }
        yield return text(" ");
        yield return text("and have the option to choose if the town gains or rejects electricity. Once all " +
            "players are ready, reveal the amount of money bid simultaneously. ");
        using (styleScope("italic", true))
        {
            yield return text("(If there is a tie, the player who went last in turn order the previous round win" +
            "s the bid.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Accepting electricity which will ");
        using (styleScope("bold", true))
        {
            yield return text("allow us to complete experiments at a discounted cost");
        }
        yield return text(" ");
        yield return text("despite the fact that it may enrage the populace into ");
        using (styleScope("bold", true))
        {
            yield return text("destruction of property");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Rejecting electricity will support the obstinate masses and ");
        using (styleScope("bold", true))
        {
            yield return text("quell the Angry Mob");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Once all players are ready, reveal the amount of money bid simultaneously. The pl" +
            "ayer that bid the most wins the ability to choose.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Only the player that wins the bid must pay their bid to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the bid...", "2p-S5SpecialVoteALT2", null);
        using (styleScope("hook", "h0000336"))
            yield return link("Click to start the bid...", null, () => enchantHook("h0000336", HarloweEnchantCommand.None, passage336_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage336_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("2p-S5SpecialVoteALT2", BiddingSystem.Bidding);
        yield break;
    }

// ###################################################################
// PASSAGE: S5SpecialVote2   (passage346)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34434-34469
// Links:  ElecY,ElecN
// Aborts: -
// Purpose: Tallies the electricity vote; links to ElecY or ElecN
// ###################################################################

    void passage346_Init()
    {
        this.Passages[@"S5SpecialVote2"] = new StoryPassage(@"S5SpecialVote2", new string[] { }, passage346_Main);
    }

    IStoryThread passage346_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Vote Outcome");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Tally the votes from all players.");
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("(Ties are broken, by the last player in turn order.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Choose the option below based on the result of your vote:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the majority of votes are YAY, ");
        yield return link("click here for electricity.", "ElecY", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the majority of votes are NAY, ");
        yield return link("click here.", "ElecN", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: 2p-S5SpecialVoteALT2   (passage347)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34475-34508
// Links:  ElecY,ElecN
// Aborts: -
// Purpose: Resolves the 2-player electricity bid: winner +3VP, chooses ElecY/ElecN
// ###################################################################

    void passage347_Init()
    {
        this.Passages[@"2p-S5SpecialVoteALT2"] = new StoryPassage(@"2p-S5SpecialVoteALT2", new string[] { }, passage347_Main);
    }

    IStoryThread passage347_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("BID Outcome");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The player that wins the bid must pay their bid to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The winning player immediately gains 3VP and chooses the option below:");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("");
        yield return link("Obtain Electricity and click here", "ElecY", null);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("");
        yield return link("Refuse Electricity and click here", "ElecN", null);
        yield return text(".");
        yield return lineBreak();
        yield break;
    }
