// ===================================================================
// CHAPTER: Setup   (38 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage1     Start2                       L1550-1608  Scenario-select screen listing the three scenarios by player count; links to Storybook help
// passage10    TITLE SCREEN                 L2637-2701  Title screen: how many players are sharing the session
// passage13    Scoring                      L2971-3036  Final scoring checklist: Estate Upgrades, Vanity, Maladjustment, unfinished Masterwork penalties
// passage16    END-WolvesEvil1              L3121-3154  Ending epilogue: evil-wolves outcome
// passage17    END-HuntersEvil1             L3160-3185  Ending epilogue: evil-hunters outcome
// passage18    END-WolvesGood1              L3191-3232  Ending epilogue: good-wolves outcome
// passage19    END-HunterGood1              L3238-3269  Ending epilogue: good-hunters outcome
// passage20    END-NoUniGood                L3275-3321  Ending epilogue: dedication to Dr. Benwallis, no-university good outcome
// passage40    StoryBook                    L5791-5844  Help page: how the Storybook app, round-end links and story prompts work
// passage41    LOGO                         L5850-5863  Displays the My Father's Work logo, advances to the title screen
// passage75    PlayerNameIntro              L8991-9030  Prompts the siblings to enter their names
// passage76    NameEntryA                   L9036-9070  Player 1 name entry confirmation
// passage77    NameEntryB                   L9076-9118  Player 2 name entry confirmation
// passage78    NameEntryC                   L9124-9165  Player 3 name entry confirmation
// passage79    NameEntryD                   L9171-9213  Player 4 name entry confirmation
// passage80    NameEntryE                   L9219-9253  Player 5 name entry confirmation
// passage126   HUBExample                   L14103-14216  DEV/template passage linking to every hub in the scenario
// passage176   Variable List CoD            L20706-20920  DEV REFERENCE: documents every story variable by generation
// passage220   TCOD-TownName                L24510-24529  Prompts the group to enter the village name
// passage221   NameEntryTownConfirm         L24535-24561  Confirms the town name; continues to Start2
// passage222   Preparations-TCOD            L24567-24624  Standard setup instructions; retrieve The Cost of Disease scenario box
// passage223   Preface-TCOD                 L24630-24664  Dr. Ensign Benwallis' in-fiction foreword
// passage234   TipsnTricks                  L25848-25860  Storybook help screen with general play tips
// passage253   ENDNOTE                      L27309-27354  DEV NOTE: unimplemented end-game scoring checks and tie-breakers
// passage318   END-UniGood                  L32725-32783  Good ending: 1923 editor's note praising the university/vaccine version of the tale
// passage326   ScoreEntryP1                 L33381-33414  Prompts for player 1's final score
// passage327   WinnerHUB                    L33420-33509  CODE: sorts entered player scores and builds the ranking page
// passage1008  VarEndingsPassage            L33511-33522  CODE: endings dispatcher; sets `winner` from GLOBALS and aborts to the chosen ending
// passage328   ScoreEntryP2                 L33527-33566  Prompts for player 2's final score
// passage329   ScoreEntryP3                 L33572-33611  Prompts for player 3's final score
// passage330   ScoreEntryP4                 L33617-33656  Prompts for player 4's final score
// passage331   ScoreEntryP5                 L33662-33698  Prompts for player 5's final score
// passage332   END-HuntersEvil2             L33704-33740  Ending "Overshadowed and Exploited": the family's knowledge dies with them
// passage333   END-WolvesEvil2              L33746-33773  Ending "The Spread of Evil": the work unleashes an unstoppable plague
// passage337   WinnerHUBproblem             L34027-34077  DEV NOTE: unimplemented tie-breaker rules for determining the winner
// passage338   SidestepPageTemporary        L34083-34092  TEMP bypass page linking straight to score tabulation
// passage339   AltStartPreviews             L34098-34138  Preview-edition welcome screen; links to TITLE SCREEN
// passage340   NoLink                       L34144-34161  Stub for scenarios not in the Preview version; returns to Start2
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: Start2   (passage1)
// Tags: ck,updated
// Source: TheCostofDiseaseEng.cs lines 1550-1608
// Links:  Preparations-TCOD,StoryBook
// Aborts: -
// Purpose: Scenario-select screen listing the three scenarios by player count; links to Storybook help
// ###################################################################

    void passage1_Init()
    {
        this.Passages[@"Start2"] = new StoryPassage(@"Start2", new string[] { "ck", "updated", }, passage1_Main);
    }

    IStoryThread passage1_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("MY FATHER\'S WORK");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Choose a Scenario ");
            if (Vars.players == 2)
            {
                yield return text("for 2 players:");
            }
            if (Vars.players == 3)
            {
                yield return text("for 3 players:");
            }
            if (Vars.players == 4)
            {
                yield return text("for 4 players:");
            }
            if (Vars.players == 5)
            {
                yield return text("for 5 players:");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("A Time of War", "NoLink", null);
        yield return lineBreak();
        yield return link("Fear and Politics", "NoLink", null);
        yield return lineBreak();
        yield return link("The Cost of Disease", "Preparations-TCOD", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("For an explanation of how to use this ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text("Storybook,");
        }
        yield return text(" ");
        yield return link("click here.", "StoryBook", null);
        yield return lineBreak();
        Vars.tracker = 0;
        yield break;
    }

// ###################################################################
// PASSAGE: TITLE SCREEN   (passage10)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 2637-2701
// Links:  -
// Aborts: -
// Purpose: Title screen: how many players are sharing the session
// ###################################################################

    void passage10_Init()
    {
        this.Passages[@"TITLE SCREEN"] = new StoryPassage(@"TITLE SCREEN", new string[] { "ck", }, passage10_Main);
    }

    IStoryThread passage10_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("MY FATHER\'S WORK");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        using (styleScope("italic", true))
        {
            yield return text("A clever game by");
        }
        yield return text(" ");
        yield return text("T. C. Petty III.");
        yield return lineBreak();
        Vars.players = 0;
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("How many individuals will be sharing this experience today?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00003"))
            yield return link("2 Players.", null, () => enchantHook("h00003", HarloweEnchantCommand.Replace, passage10_Fragment_0));
        yield return lineBreak();
        using (styleScope("hook", "h00004"))
            yield return link("3 Players.", null, () => enchantHook("h00004", HarloweEnchantCommand.Replace, passage10_Fragment_1));
        yield return lineBreak();
        using (styleScope("hook", "h00005"))
            yield return link("4 Players.", null, () => enchantHook("h00005", HarloweEnchantCommand.Replace, passage10_Fragment_2));
        yield break;
    }

    IStoryThread passage10_Fragment_0()
    {
        Vars.players = 2;
        yield return abort(goToPassage: "PlayerNameIntro");
        yield break;
    }

    IStoryThread passage10_Fragment_1()
    {
        Vars.players = 3;
        yield return abort(goToPassage: "PlayerNameIntro");
        yield break;
    }

    IStoryThread passage10_Fragment_2()
    {
        Vars.players = 4;
        yield return abort(goToPassage: "PlayerNameIntro");
        yield break;
    }

// ###################################################################
// PASSAGE: Scoring   (passage13)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 2971-3036
// Links:  -
// Aborts: -
// Purpose: Final scoring checklist: Estate Upgrades, Vanity, Maladjustment, unfinished Masterwork penalties
// ###################################################################

    void passage13_Init()
    {
        this.Passages[@"Scoring"] = new StoryPassage(@"Scoring", new string[] { }, passage13_Main);
    }

    IStoryThread passage13_Main()
    {
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Scoring");
        }
        yield return lineBreak();
        yield return text("Each Estate Upgrade is worth 1VP.");
        yield return lineBreak();
        yield return text("Add any additional points from Vanity Estate Upgrades.");
        yield return lineBreak();
        yield return text("Score -3VP for any Maladjustments gained at the End of this Generation.");
        yield return lineBreak();
        if (Vars.lycan == "yes")
        {
            yield return text("Check to make sure the player with ");
            using (styleScope("bold", true))
            {
                yield return text("Lycanthropic Strength");
            }
            yield return text(" completed their Masterwork. If they did not, they ");
            using (styleScope("bold", true))
            {
                yield return text("lose 5VP.");
            }
        }
        if (Vars.immort == "yes")
        {
            yield return text("Check to make sure the player with ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality");
            }
            yield return text(" completed their Masterwork. If they did not, they ");
            using (styleScope("bold", true))
            {
                yield return text("lose 5VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //Vars.winner = Vars.players > 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players > 2 ?
        //    macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);

        using (styleScope("hook", "h00006"))
            yield return link("Click to tabulate scores for posterity...", null, () => enchantHook("h00006", HarloweEnchantCommand.Replace, passage13_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage13_Fragment_0()
    {
        //yield return abort(goToPassage: Vars.ending);
        ViewController.instance.ChangeView(ViewController.instance.scoreEntry);
        //yield return abort(goToPassage: "ScoreEntryP1");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: END-WolvesEvil1   (passage16)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3121-3154
// Links:  -
// Aborts: -
// Purpose: Ending epilogue: evil-wolves outcome
// ###################################################################

    void passage16_Init()
    {
        this.Passages[@"END-WolvesEvil1"] = new StoryPassage(@"END-WolvesEvil1", new string[] { }, passage16_Main);
    }

    IStoryThread passage16_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Local Legends");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return text("Three generations of diligent scientific minds, toiling at an unspeakable work, s" +
            "urrounded by decaying stone walls, their ignoble experimentations tucked away am" +
            "ongst the deep forests and well-worn dirt roads that traverse the gray countrysi" +
            "de.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Could the family's indifference to the plight of the diseased truly be blamed for how the pandemic consumed the region? Is it possible that they assisted a supernatural force that could ingrain themselves so deeply in a small town's infrastructure that an entire populace would be turned into monsters themselves? Or that a counter-agent could be procured and unleashed to undo an evil curse?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Unearthing this mystery took considerable effort as the history of the region had all but been forgotten and the memory of several eccentric entrepreneurs isolated in aristocratic circles had faded away, obscured by time like the mists that still hang over this small valley. But whether truth or fiction, ");
        yield return text(Vars.townname);
        yield return text("\'s residents cling to these superstitions in whispered conversations. On nights w" +
            "hen strange sounds emerged from the fog, they turned their gaze towards the grim" +
            " chateaus in the distance and wondered what strange machinations were contained " +
            "within.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield break;
    }

// ###################################################################
// PASSAGE: END-HuntersEvil1   (passage17)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3160-3185
// Links:  -
// Aborts: -
// Purpose: Ending epilogue: evil-hunters outcome
// ###################################################################

    void passage17_Init()
    {
        this.Passages[@"END-HuntersEvil1"] = new StoryPassage(@"END-HuntersEvil1", new string[] { }, passage17_Main);
    }

    IStoryThread passage17_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Their Own Destiny");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return text(@"The impressive victory over the forces of superstition within the city marked a turning point in the acceptance of scientific experimentation and progress across the entire country. And while their work had done nothing to spare the community from future epidemics, their fears now abated, allowing them to expand deeper into the valley. Lucrative silver mining operations appeared and with it came even more opportunities for the family to invest.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Tall tales once told to frighten children were now believed to be real, macabre stories of true horrible scientific experiments. And after the hideous experiments let loose were wrangled once again, the respect and fear the people had for the family was demonstrable. For the family, this veneration meant a guarantee of autonomy and resources.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"But their fame was merely relegated to the Hungarian hillsides. They had weathered the storm, but now it was time to summon and control the tempest! With their legacy firmly cemented, they stood perched upon the precipice of true scientific discovery, confident and ready for their next moment of brilliance.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield break;
    }

// ###################################################################
// PASSAGE: END-WolvesGood1   (passage18)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3191-3232
// Links:  -
// Aborts: -
// Purpose: Ending epilogue: good-wolves outcome
// ###################################################################

    void passage18_Init()
    {
        this.Passages[@"END-WolvesGood1"] = new StoryPassage(@"END-WolvesGood1", new string[] { }, passage18_Main);
    }

    IStoryThread passage18_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("There Could Never Be Peace");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return text("There is not much possibility to confirm the notes I have herein on a society of " +
            "monsters. I have scoured the surviving journal entries, newspaper clippings, and" +
            " ephemera collected on a visit to the crumbling estates outside of ");
        yield return text(Vars.townname);
        yield return text(". Or what remains of ");
        yield return text(Vars.townname);
        yield return text(". Some locals in the areas surrounding the site swear by the stories, but the ens" +
            "uing decades have made the information scarce and proof even more so.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The final notes and news clippings available declare that a peace between monster" +
            " and man finally seemed like an imminent possibility after recent talks with the" +
            " government. However, it was only weeks later that ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text(@"became yet another casualty of the War to End All Wars. Despite the suspicious distance between the front lines and southeastern Hungary, an evening air raid resulted in a heavy firebomb and phosgene attack that devastated the city, leaving zero known survivors.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"As the cousins were vacationing along the Mediterranean at the time, this devastating loss was more one of property and potential opportunity. They were quick to salvage what remained of their experimentations and carry on again in their summer homes. The family had already established a name for themselves across the region, but what they had hoped would change the course of the world would have to wait as it was once again rebuilt.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"So like the monsters that once attempted to create their own utopian city hidden amongst the rolling hills and forests, the world was not yet ready for the family. But, like a phoenix rising reborn from the embers of destruction, it was assured that they would someday return to shock the world once again.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: END-HunterGood1   (passage19)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3238-3269
// Links:  -
// Aborts: -
// Purpose: Ending epilogue: good-hunters outcome
// ###################################################################

    void passage19_Init()
    {
        this.Passages[@"END-HunterGood1"] = new StoryPassage(@"END-HunterGood1", new string[] { }, passage19_Main);
    }

    IStoryThread passage19_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("To Be Rid of Evil");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return text(@"When disease wreaked havoc across the countryside, they remained safe in isolation, steadfast in their determination to complete a work that would transform our understanding of the world. And when an evil presence burrowed its ghastly business underneath the rebuilding town of ");
        yield return text(Vars.townname);
        yield return text(", the family ruthlessly exposed their efforts. Their contributions of time and re" +
            "sources to battle away the creatures when they threatened to overtake the countr" +
            "yside shone like a lighthouse in a storm.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The evil scourge, once a plague of disease and then again a plague of horrors from beyond, had been vanquished, leaving only the knowledge gleaned from their very existence to strengthen the family's pursuits. Though they were unhappy to share the same luminous spotlight with the Fraternity, the fame was grand enough to sate them. The city, the country, and nearly the entirety of Eastern Europe now knew their name.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was a time of peace, but not a time of rest. They had so much more science to " +
            "explore and so many new generations to do it. The world would soon quiver at the" +
            " very mention of that family!");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield break;
    }

// ###################################################################
// PASSAGE: END-NoUniGood   (passage20)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3275-3321
// Links:  -
// Aborts: -
// Purpose: Ending epilogue: dedication to Dr. Benwallis, no-university good outcome
// ###################################################################

    void passage20_Init()
    {
        this.Passages[@"END-NoUniGood"] = new StoryPassage(@"END-NoUniGood", new string[] { }, passage20_Main);
    }

    IStoryThread passage20_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Legacy Will Live On");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"This manuscript is dedicated to Dr. Ensign Benwallis who is survived by his two children, daughter, Celia Benwallis Cartwright and son, Ensign Benwallis Jr. It is with heavy heart that his story ends somewhere within these pages, though we endeavor to see his words live on. The research required for his later notes was known to have exacerbated his dipsomania. His untimely exit remains a stark reminder of the perils of inebriation.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The family that commissioned his work has dedicated three percent of the proceeds" +
            " from the publication of this document to the family of Dr. Benwallis. It is");
        if (Vars.uni == "yes")
        {
            yield return text(", as individuals associated with the original University groundbreaking,");
        }
        yield return text(" ");
        yield return text("the absolute least they could do.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.peeps == 0)
        {
            yield return text("With the introduction of electricity to the region, we have already seen a marked" +
            " increase in literacy percentages in the county. We are hopeful that this will a" +
            "ttract an audience for this scholarly work.");
        }
        if (Vars.peeps == 1)
        {
            yield return text(@"While we do not have hope for its continued publication within Hungary due to the region's continued lapse in general education capabilities and lack of connections to the electrical grid, we hope that individuals within other European markets will enjoy such a unique biography.");
        }
        yield return text(" ");
        yield return text("The eccentric and infamous scientific legacy of the family will undoubtedly leave" +
            " its mark for many years to come.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: StoryBook   (passage40)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 5791-5844
// Links:  Start2
// Aborts: -
// Purpose: Help page: how the Storybook app, round-end links and story prompts work
// ###################################################################

    void passage40_Init()
    {
        this.Passages[@"StoryBook"] = new StoryPassage(@"StoryBook", new string[] { "ck", }, passage40_Main);
    }

    IStoryThread passage40_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("How to Use the Storybook");
        }
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("My Father\'s Work");
        }
        yield return text(" ");
        yield return text(@"is a game of Victorian era mad scientist ambition told over three generations. The Storybook App controls the direction of the Town depending on the decisions made by the players. It will require that players interact with it by clicking on specific passages at certain times.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("End of a round");
        }
        yield return lineBreak();
        yield return text("There are three rounds in each Generation. At the end of each round, you ");
        using (styleScope("bold", true))
        {
            yield return text("must");
        }
        yield return text(" ");
        yield return text("click the bottom link to resolve any special events and move play to the next rou" +
            "nd. The screen will then display the current round and changes to gameplay (if a" +
            "ny).");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Story Actions");
        }
        yield return text(" ");
        yield return text("<sprite=\"Storybook\" index=0>");
        yield return lineBreak();
        yield return text("Sometimes, the game will require that a player click a certain link when an actio" +
            "n has been performed. This may be taking an action in the Town, your Estate, or " +
            "completing a specific goal. Be sure to click these links to receive a special st" +
            "ory passage.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to return...", "Start2", null);
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: LOGO   (passage41)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 5850-5863
// Links:  TITLE SCREEN
// Aborts: -
// Purpose: Displays the My Father's Work logo, advances to the title screen
// ###################################################################

    void passage41_Init()
    {
        this.Passages[@"LOGO"] = new StoryPassage(@"LOGO", new string[] { "ck", }, passage41_Main);
    }

    IStoryThread passage41_Main()
    {
        yield return text("<img src=\"MFWlogo\" style=\"width:100%;\">");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "TITLE SCREEN", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: PlayerNameIntro   (passage75)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 8991-9030
// Links:  NameEntryA
// Aborts: -
// Purpose: Prompts the siblings to enter their names
// ###################################################################

    void passage75_Init()
    {
        this.Passages[@"PlayerNameIntro"] = new StoryPassage(@"PlayerNameIntro", new string[] { "ck", }, passage75_Main);
    }

    IStoryThread passage75_Main()
    {
        if (Vars.players == 2)
        {
            Vars.playtxt = "two";
        }
        if (Vars.players == 3)
        {
            Vars.playtxt = "three";
        }
        if (Vars.players == 4)
        {
            Vars.playtxt = "four";
        }
        if (Vars.players == 5)
        {
            Vars.playtxt = "five";
        }
        yield return text("As siblings of an influential family of Eastern European descent, the ");
        using (styleScope("bold", true))
        {
            yield return text(Vars.playtxt);
        }
        yield return text(" ");
        yield return text("of us have received a not-insignificant portion of our family\'s estate.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Before we begin, let us make this historical fiction more engaging by providing o" +
            "ur names.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "NameEntryA", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NameEntryA   (passage76)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 9036-9070
// Links:  NameEntryB
// Aborts: -
// Purpose: Player 1 name entry confirmation
// ###################################################################

    void passage76_Init()
    {
        this.Passages[@"NameEntryA"] = new StoryPassage(@"NameEntryA", new string[] { "ck", }, passage76_Main);
    }

    IStoryThread passage76_Main()
    {
        Vars.nameA = GLOBALS.nameA;
        Vars.players = 1;
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("Welcome to ");
        using (styleScope("italic", true))
        {
            yield return text("My Father\'s Work");
        }
        yield return text(",");
        yield return lineBreak();
        yield return text(Vars.nameA);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Our warmest regards.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to Continue", "NameEntryB", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NameEntryB   (passage77)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 9076-9118
// Links:  NameEntryC,TCOD-TownName
// Aborts: -
// Purpose: Player 2 name entry confirmation
// ###################################################################

    void passage77_Init()
    {
        this.Passages[@"NameEntryB"] = new StoryPassage(@"NameEntryB", new string[] { "ck", }, passage77_Main);
    }

    IStoryThread passage77_Main()
    {
        Vars.nameB = GLOBALS.nameB;
        Vars.players = 2;
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("Welcome to ");
        using (styleScope("italic", true))
        {
            yield return text("My Father\'s Work");
        }
        yield return text(",");
        yield return lineBreak();
        yield return text(Vars.nameB);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Please enjoy your experience.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            yield return link("Click to Continue...", "NameEntryC", null);
        }
        else
        {
            yield return link("Click to Continue...", "TCOD-TownName", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NameEntryC   (passage78)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 9124-9165
// Links:  NameEntryD,TCOD-TownName
// Aborts: -
// Purpose: Player 3 name entry confirmation
// ###################################################################

    void passage78_Init()
    {
        this.Passages[@"NameEntryC"] = new StoryPassage(@"NameEntryC", new string[] { "ck", }, passage78_Main);
    }

    IStoryThread passage78_Main()
    {
        Vars.nameC = GLOBALS.nameC;
        Vars.players = 3;
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("Welcome to ");
        using (styleScope("italic", true))
        {
            yield return text("My Father\'s Work");
        }
        yield return text(",");
        yield return lineBreak();
        yield return text(Vars.nameC);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("May your name live in infamy.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 3)
        {
            yield return link("Click to Continue...", "NameEntryD", null);
        }
        else
        {
            yield return link("Click to Continue...", "TCOD-TownName", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NameEntryD   (passage79)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 9171-9213
// Links:  NameEntryE,TCOD-TownName
// Aborts: -
// Purpose: Player 4 name entry confirmation
// ###################################################################

    void passage79_Init()
    {
        this.Passages[@"NameEntryD"] = new StoryPassage(@"NameEntryD", new string[] { "ck", }, passage79_Main);
    }

    IStoryThread passage79_Main()
    {
        Vars.nameD = GLOBALS.nameD;
        Vars.players = 4;
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("Welcome to ");
        using (styleScope("italic", true))
        {
            yield return text("My Father\'s Work");
        }
        yield return text(",");
        yield return lineBreak();
        yield return text(Vars.nameD);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Be sure to leave your mark on the world.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 4)
        {
            yield return link("Click to Continue...", "NameEntryE", null);
        }
        else
        {
            yield return link("Click to Continue...", "TCOD-TownName", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NameEntryE   (passage80)
// Tags: Has-Question,ck
// Source: TheCostofDiseaseEng.cs lines 9219-9253
// Links:  TCOD-TownName
// Aborts: -
// Purpose: Player 5 name entry confirmation
// ###################################################################

    void passage80_Init()
    {
        this.Passages[@"NameEntryE"] = new StoryPassage(@"NameEntryE", new string[] { "Has-Question", "ck", }, passage80_Main);
    }

    IStoryThread passage80_Main()
    {
        Vars.nameE = GLOBALS.nameE;
        Vars.players = 5;
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("Welcome to ");
        using (styleScope("italic", true))
        {
            yield return text("My Father\'s Work");
        }
        yield return text(",");
        yield return lineBreak();
        yield return text(Vars.nameE);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Be sure to leave your mark on the world.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to Continue...", "TCOD-TownName", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HUBExample   (passage126)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14103-14216
// Links:  Fever1,Fever2,Fever3,Devastation1,Devastation2,Devastation3,Hospital1,Hospital2,Hospital3,GloomyGothic1,GloomyGothic2,GloomyGothic3,Prosperity1,Prosperity2,Prosperity3,NoUni1,NoUni2,NoUni3,University1,University2,University3
// Aborts: -
// Purpose: DEV/template passage linking to every hub in the scenario
// ###################################################################

    void passage126_Init()
    {
        this.Passages[@"HUBExample"] = new StoryPassage(@"HUBExample", new string[] { }, passage126_Main);
    }

    IStoryThread passage126_Main()
    {
        if (Vars.round == 1)
        {
            yield return link("Click to return...", "Fever1", null);
        }
        yield return lineBreak();
        if (Vars.round == 2)
        {
            yield return link("Click to return...", "Fever2", null);
        }
        yield return lineBreak();
        if (Vars.round == 3)
        {
            yield return link("Click to return...", "Fever3", null);
        }
        yield return lineBreak();
        if (Vars.round == 4)
        {
            yield return link("Click to return...", "Devastation1", null);
        }
        yield return lineBreak();
        if (Vars.round == 5)
        {
            yield return link("Click to return...", "Devastation2", null);
        }
        yield return lineBreak();
        if (Vars.round == 6)
        {
            yield return link("Click to return...", "Devastation3", null);
        }
        yield return lineBreak();
        if (Vars.round == 7)
        {
            yield return link("Click to return...", "Hospital1", null);
        }
        yield return lineBreak();
        if (Vars.round == 8)
        {
            yield return link("Click to return...", "Hospital2", null);
        }
        yield return lineBreak();
        if (Vars.round == 9)
        {
            yield return link("Click to return...", "Hospital3", null);
        }
        yield return lineBreak();
        if (Vars.round == 10)
        {
            yield return link("Click to return...", "GloomyGothic1", null);
        }
        yield return lineBreak();
        if (Vars.round == 11)
        {
            yield return link("Click to return...", "GloomyGothic2", null);
        }
        yield return lineBreak();
        if (Vars.round == 12)
        {
            yield return link("Click to return...", "GloomyGothic3", null);
        }
        yield return lineBreak();
        if (Vars.round == 13)
        {
            yield return link("Click to return...", "Prosperity1", null);
        }
        yield return lineBreak();
        if (Vars.round == 14)
        {
            yield return link("Click to return...", "Prosperity2", null);
        }
        yield return lineBreak();
        if (Vars.round == 15)
        {
            yield return link("Click to return...", "Prosperity3", null);
        }
        yield return lineBreak();
        if (Vars.round == 16)
        {
            yield return link("Click to return...", "NoUni1", null);
        }
        yield return lineBreak();
        if (Vars.round == 17)
        {
            yield return link("Click to return...", "NoUni2", null);
        }
        yield return lineBreak();
        if (Vars.round == 18)
        {
            yield return link("Click to return...", "NoUni3", null);
        }
        yield return lineBreak();
        if (Vars.round == 19)
        {
            yield return link("Click to return...", "University1", null);
        }
        yield return lineBreak();
        if (Vars.round == 20)
        {
            yield return link("Click to return...", "University2", null);
        }
        yield return lineBreak();
        if (Vars.round == 21)
        {
            yield return link("Click to return...", "University3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Variable List CoD   (passage176)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 20706-20920
// Links:  -
// Aborts: -
// Purpose: DEV REFERENCE: documents every story variable by generation
// ###################################################################

    void passage176_Init()
    {
        this.Passages[@"Variable List CoD"] = new StoryPassage(@"Variable List CoD", new string[] { }, passage176_Main);
    }

    IStoryThread passage176_Main()
    {
        yield return text(Vars.nameA);
        yield return text("/B/C/D/E = chosen name of player");
        yield return lineBreak();
        yield return text(Vars.players);
        yield return text(" ");
        yield return text("= number of players");
        yield return lineBreak();
        yield return text(Vars.playtxt);
        yield return text(" ");
        yield return text("= text version of number of players");
        yield return lineBreak();
        yield return text(Vars.randomplayer);
        yield return text(" ");
        yield return text("= array of current player names");
        yield return lineBreak();
        yield return text(Vars.randomname);
        yield return text(" ");
        yield return text("= used with above for random name.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("= name of the village in the game");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.nameA);
        yield return text(" ");
        yield return text("II (remember to make it the second for Gen 2)");
        yield return lineBreak();
        yield return text(Vars.nameA);
        yield return text(" ");
        yield return text("III (remember to make it the third for Gen 3)");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GEN I");
        }
        yield return lineBreak();
        yield return text(Vars.mayor);
        yield return text(" ");
        yield return text("= player elected mayor");
        yield return lineBreak();
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("= player most charitable");
        yield return lineBreak();
        yield return text(Vars.building);
        yield return text(" ");
        yield return text("= \"bank\" or \"library\" whichever was built");
        yield return lineBreak();
        yield return text(Vars.gen1creep);
        yield return text(" ");
        yield return text("= tracks player who was Creepy");
        yield return lineBreak();
        yield return text(Vars.creepy4);
        yield return text(" ");
        yield return text("= on/off switch for displaying clickable Creepy link");
        yield return lineBreak();
        yield return text(Vars.seedy);
        yield return text(" ");
        yield return text("= confirmation of yes or no to Creepy Event");
        yield return lineBreak();
        yield return text(Vars.gen1sane);
        yield return text(" ");
        yield return text("= tracks player who was Insane");
        yield return lineBreak();
        yield return text(Vars.sane3);
        yield return text(" ");
        yield return text("= on/off switch for displaying clickable Insane link");
        yield return lineBreak();
        yield return text(Vars.vacation);
        yield return text(" ");
        yield return text("= confirmation of yes or no to Sanity Event");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Devastation GEN II");
        }
        yield return lineBreak();
        yield return text(Vars.wolves);
        yield return text(" ");
        yield return text("= good or evil");
        yield return lineBreak();
        yield return text(Vars.hunters);
        yield return text(" ");
        yield return text("= good or evil");
        yield return lineBreak();
        yield return text(Vars.allyA);
        yield return text("/B/C/D/E = player has joined the wolves or hunters");
        yield return lineBreak();
        yield return text(Vars.refusaltoken);
        yield return text(" ");
        yield return text("= whether the storybook token has been placed");
        yield return lineBreak();
        yield return text(Vars.devpage);
        yield return text(" ");
        yield return text("= turns off SETUP when 1st HUB is left.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.pa);
        yield return text("/b/c/d/e = Letter card number assigned to a player");
        yield return lineBreak();
        yield return text(Vars.password);
        yield return text(" ");
        yield return text("= card password that opens up a wolf/hunter joining option");
        yield return lineBreak();
        yield return text(Vars.ba);
        yield return text("/b/c =");
        yield return lineBreak();
        yield return text(Vars.letA);
        yield return text("/B/C = Building A, B, & C");
        yield return lineBreak();
        yield return text(Vars.inv);
        yield return text(" ");
        yield return text("= Building to be investigated");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.exposeA);
        yield return text("/B/C = count for how many times a thing has been exposed or revealed");
        yield return lineBreak();
        yield return text(Vars.playA);
        yield return text("/B/C/D/E = count for how many investigations total");
        yield return lineBreak();
        yield return text(Vars.pAA);
        yield return text("/B/C = Player A \"yes\" or \"no\" helped with exposing or concealing Building A/B/C");
        yield return lineBreak();
        yield return text(Vars.goodcount);
        yield return text(" ");
        yield return text("= how many times a building was exposed");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Thriving GEN II");
        }
        yield return lineBreak();
        yield return text(Vars.sym);
        yield return text(" ");
        yield return text("= 1 Success or 2 Failure = Determines if the University is Built");
        yield return lineBreak();
        yield return text(Vars.fevervp);
        yield return text(" ");
        yield return text("= Yellow Fever VP to be awarded");
        yield return lineBreak();
        yield return text(Vars.fevermoney);
        yield return text(" ");
        yield return text("= Yellow Fever money to be awarded");
        yield return lineBreak();
        yield return text(Vars.fevercure);
        yield return text(" ");
        yield return text("= the player that cured Yellow Fever");
        yield return lineBreak();
        yield return text(Vars.panacure);
        yield return text(" ");
        yield return text("= the player that created a Panacea");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Gen III - Hunters & Wolves");
        }
        yield return lineBreak();
        yield return text(Vars.eviltax);
        yield return text(" ");
        yield return text("= Evil Hunters leg, did we confront them about their deception?");
        yield return lineBreak();
        yield return text(Vars.society);
        yield return text(" ");
        yield return text("= which faction won the secret battle.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hunting code");
        yield return lineBreak();
        yield return text(Vars.h1a);
        yield return text(" ");
        yield return text("& ");
        yield return text(Vars.h1b);
        yield return text(" ");
        yield return text("= 1st hunt names");
        yield return lineBreak();
        yield return text(Vars.h2a);
        yield return text(" ");
        yield return text("& ");
        yield return text(Vars.h2b);
        yield return text(" ");
        yield return text("= 2nd hunt names");
        yield return lineBreak();
        yield return text(Vars.huntname);
        yield return text(" ");
        yield return text("= randomly chosen hunt perspective name");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("ENDINGS");
        }
        yield return lineBreak();
        yield return text(Vars.winner);
        yield return text(" ");
        yield return text("= Winner of the game. If there is an absolute tie, this variable is represented a" +
            "s \"the family\".");
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: TCOD-TownName   (passage220)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 24510-24529
// Links:  NameEntryTownConfirm
// Aborts: -
// Purpose: Prompts the group to enter the village name
// ###################################################################

    void passage220_Init()
    {
        this.Passages[@"TCOD-TownName"] = new StoryPassage(@"TCOD-TownName", new string[] { "ck", }, passage220_Main);
    }

    IStoryThread passage220_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Village");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Now that our given names have been established, we must also search our recollection for the name of the village which our vast estates overlook. Considering the myriad of small towns in the Hungarian countryside, it would be unmeritably forward to not allow the group a chance to collectively name the place they will now inhabit.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to name the village...", "NameEntryTownConfirm", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NameEntryTownConfirm   (passage221)
// Tags: ck
// Source: TheCostofDiseaseEng.cs lines 24535-24561
// Links:  Start2
// Aborts: -
// Purpose: Confirms the town name; continues to Start2
// ###################################################################

    void passage221_Init()
    {
        this.Passages[@"NameEntryTownConfirm"] = new StoryPassage(@"NameEntryTownConfirm", new string[] { "ck", }, passage221_Main);
    }

    IStoryThread passage221_Main()
    {
        Vars.townname = GLOBALS.townName;
        //yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("Thank you and please do excuse our forgetfulness.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Of course, ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("is an appropriate and fitting moniker for a place to conduct important scientific" +
            " research. In fact, history will remember this name, mark my words.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to Continue...", "Start2", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Preparations-TCOD   (passage222)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24567-24624
// Links:  Preface-TCOD
// Aborts: -
// Purpose: Standard setup instructions; retrieve The Cost of Disease scenario box
// ###################################################################

    void passage222_Init()
    {
        this.Passages[@"Preparations-TCOD"] = new StoryPassage(@"Preparations-TCOD", new string[] { }, passage222_Main);
    }

    IStoryThread passage222_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Preparations");
        }
        yield return lineBreak();
        Vars.players = GLOBALS.playerCount;
        Vars.nameA = GLOBALS.nameA;
        Vars.nameB = GLOBALS.nameB;
        if (Vars.players > 2) Vars.nameC = GLOBALS.nameC;
        if (Vars.players > 3) Vars.nameD = GLOBALS.nameD;
        if (Vars.players > 4) Vars.nameE = GLOBALS.nameE;
        Vars.townname = GLOBALS.townName;
        Vars.playtxt = Vars.players == 2 ? "two" : Vars.players == 3 ? "three" : Vars.players == 4 ? "four" : Vars.players == 5 ? "five" : "two";

        yield return lineBreak();
        yield return text("Complete the standard setup for ");
        yield return text(Vars.playtxt);
        yield return text(" ");
        yield return text("players as shown in the rulebook. ");
        using (styleScope("italic", true))
        {
            yield return text("Note that the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("track and starting player will be set by the Storybook in the coming pages.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<align=\"center\">");
        yield return text("<line-height=400%>");
        yield return text("<size=200>");
        yield return text("<sprite=\"ScenarioBox3D_Disease\" index=0>");
        yield return text("</size>");
        yield return text("</align>");
        yield return text("</line-height>");
        yield return lineBreak();
        yield return text("Then, retrieve ");
        using (styleScope("bold", true))
        {
            yield return text("The Cost of Disease");
        }
        yield return text(" ");
        yield return text("Scenario box, which will contain all components needed for this story. As the Sto" +
            "rybook progresses, it will ask you to put items into play from this box. Be sure" +
            " to keep it nearby.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to continue...", "Preface-TCOD", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Preface-TCOD   (passage223)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24630-24664
// Links:  Scenario5Start
// Aborts: -
// Purpose: Dr. Ensign Benwallis' in-fiction foreword
// ###################################################################

    void passage223_Init()
    {
        this.Passages[@"Preface-TCOD"] = new StoryPassage(@"Preface-TCOD", new string[] { }, passage223_Main);
    }

    IStoryThread passage223_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("A Foreword");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Herein contains a historical account of a peculiar lineage. One that spans multip" +
            "le generations and by all accounts will continue to fascinate historians for man" +
            "y years to come.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"I have endeavored to provide as complete a scholarly history as one could provide given the conflicting accounts and whims of hearsay. While many of the details, haunting to the imagination as they may be, stretch the very limits of our human understanding, it is my hope that this text and the accompanying research materials procured will provide evidence as to their truth. The harrowing and potentially supernatural series of events has the capacity to shake the very foundations of the scientific world as we perceive it.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With deference to the fellowship that commissioned this explicit work, though I h" +
            "ave never met with these generous benefactors, I humbly submit this biographical" +
            " account in its entirety and swear by the veracity of the contents within.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("In good health,");
        yield return lineBreak();
        yield return text("Dr. Ensign Benwallis");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "Scenario5Start", null);
        yield break;
    }

// ###################################################################
// PASSAGE: TipsnTricks   (passage234)
// Tags: ck2
// Source: TheCostofDiseaseEng.cs lines 25848-25860
// Links:  -
// Aborts: -
// Purpose: Storybook help screen with general play tips
// ###################################################################

    void passage234_Init()
    {
        this.Passages[@"TipsnTricks"] = new StoryPassage(@"TipsnTricks", new string[] { "ck2", }, passage234_Main);
    }

    IStoryThread passage234_Main()
    {
        yield return text("It is almost never advantageous for all players to take the same route.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("All decisions carry with them consequences, both good and bad. ");
        yield break;
    }

// ###################################################################
// PASSAGE: ENDNOTE   (passage253)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27309-27354
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: unimplemented end-game scoring checks and tie-breakers
// ###################################################################

    void passage253_Init()
    {
        this.Passages[@"ENDNOTE"] = new StoryPassage(@"ENDNOTE", new string[] { }, passage253_Main);
    }

    IStoryThread passage253_Main()
    {
        yield return text("Add to SCORING");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.lycan == "yes")
        {
            yield return text("Check to make sure the player with ");
            using (styleScope("bold", true))
            {
                yield return text("Lycanthropic Strength");
            }
            yield return text("completed their Masterwork. If they did not, they ");
            using (styleScope("bold", true))
            {
                yield return text("lose 5VP.");
            }
        }
        if (Vars.immort == "yes")
        {
            yield return text("Check to make sure the player with ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality");
            }
            yield return text("completed their Masterwork. If they did not, they ");
            using (styleScope("bold", true))
            {
                yield return text("lose 5VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("NOT SURE HOW TO CODE TIE-BREAKERS:");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I can compare scores with a few lines, but it doesn\'t take into account tied scor" +
            "es.");
        yield break;
    }

// ###################################################################
// PASSAGE: END-UniGood   (passage318)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32725-32783
// Links:  -
// Aborts: -
// Purpose: Good ending: 1923 editor's note praising the university/vaccine version of the tale
// ###################################################################

    void passage318_Init()
    {
        this.Passages[@"END-UniGood"] = new StoryPassage(@"END-UniGood", new string[] { }, passage318_Main);
    }

    IStoryThread passage318_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Editor\'s note - August 1923");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hello Ensign,");
        yield return lineBreak();
        yield return text(@"I've looked over the manuscript you submitted and I have to admit that it is not what I would have expected. The foreword promises a harrowing and potentially supernatural series of events that test the limits of imagination. However, the story tells a cohesive and somewhat uplifting tale of a family of reformed scientists making the world a better place. I admit that in some cases the means to which this is accomplished is morosely detailed and quite unorthodox, but overall the story seems incomplete.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If I may paraphrase: A scientific family enters into the political theater and th" +
            "en assists the Church with charitable donations towards building a hospital. Thi" +
            "s decision results in prosperity in the region ");
        if (Vars.cured == 1)
        {
            yield return text("\"which is further improved by the generous creation of an unprecedented cure for" +
            " Yellow Fever.\" ");
        }
        if (Vars.uni == "yes")
        {
            yield return text("After which, they put on an excellent Symposium that attracts a University to the" +
            " area. ");
        }
        if (Vars.ultimate == "yes")
        {
            yield return text("They even create an unintentional vaccine that essentially eliminates all disease" +
            " from the region. ");
        }
        yield return text("Ultimately, their work is instrumental in catapulting Hungary and ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("into the international spotlight. It is very uplifting and has a good potential t" +
            "o sell well to the burgeoning educational market in London.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Recommendation - alter descriptions in early chapters to reflect a more uplifting" +
            " tale. Omit horror and supernatural elements. Offer happy ending.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I look forward to seeing your revisions.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("THE END?");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: ScoreEntryP1   (passage326)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33381-33414
// Links:  ScoreEntryP2
// Aborts: -
// Purpose: Prompts for player 1's final score
// ###################################################################

    void passage326_Init()
    {
        this.Passages[@"ScoreEntryP1"] = new StoryPassage(@"ScoreEntryP1", new string[] { }, passage326_Main);
    }

    IStoryThread passage326_Main()
    {
        //Vars.scoreA = ("rompt: Please enter the final score for $nameA.");
        //yield return lineBreak();
        //using (styleScope("heading", 1))
        //{
        //    yield return text("ERROR!");
        //}
        if (/*(Vars.scoreA == "" || Vars.scoreA == 0) &&*/ ispopup)
        {
            //yield return lineBreak();
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("ScoreEntryP1", "Please enter the final score for " + Vars.nameA + ".", "number", 0.5f);
        }
        if (ViewPopupPanel.instance.PassageValueNumber() >= 0)
        {
            Vars.scoreA = ViewPopupPanel.instance.PassageValueNumber();
            ispopup = true;
        }
        yield return text("Thank you for recording this important historical information, ");
        yield return text(Vars.nameA);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue.", "ScoreEntryP2", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: WinnerHUB   (passage327)
// Tags: CODINGHELP
// Source: TheCostofDiseaseEng.cs lines 33420-33509
// Links:  -
// Aborts: -
// Purpose: CODE: sorts entered player scores and builds the ranking page
// ###################################################################

    void passage327_Init()
    {
        this.Passages[@"WinnerHUB"] = new StoryPassage(@"WinnerHUB", new string[] { "CODINGHELP", }, passage327_Main);
    }

    IStoryThread passage327_Main()
    {
        //using (styleScope("bold", true))
        //{
        //    yield return text("THIS PASSAGE UNDER CONSTRUCTION.");
        //}
        //yield return lineBreak();
        //using (styleScope("italic", true))
        //{
        //    yield return text("(if it does not show the correct winning name, please excuse this error)");
        //}
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.scoreA > macros1.max(Vars.scoreB, Vars.scoreC, Vars.scoreD, Vars.scoreE))
        //{
        //    Vars.winner = Vars.nameA;
        //}
        //else if (Vars.scoreB > macros1.max(Vars.scoreC, Vars.scoreD, Vars.scoreE))
        //{
        //    Vars.winner = Vars.nameB;
        //}
        //else if (Vars.scoreC > macros1.max(Vars.scoreD, Vars.scoreE))
        //{
        //    Vars.winner = Vars.nameC;
        //}
        //else if (Vars.scoreE > macros1.max(Vars.scoreE))
        //{
        //    Vars.winner = Vars.nameD;
        //}
        //else
        //{
        //    Vars.winner = Vars.nameE;
        //}

        List<float> playerPoints = new List<float>();
        List<float> winnerPlayerPoints = new List<float>();
        List<NamePoints> PlayerNameAndPoint = new List<NamePoints>();
        playerPoints.Add(Vars.scoreA);
        PlayerNameAndPoint.Add(new NamePoints { playerName = Vars.nameA, Points = Vars.scoreA });
        playerPoints.Add(Vars.scoreB);
        PlayerNameAndPoint.Add(new NamePoints { playerName = Vars.nameB, Points = Vars.scoreB });
        if (Vars.scoreC > 0 && Vars.nameC != null)
        {
            playerPoints.Add(Vars.scoreC);
            PlayerNameAndPoint.Add(new NamePoints { playerName = Vars.nameC, Points = Vars.scoreC });
        }
        if (Vars.scoreD > 0 && Vars.nameD != null)
        {
            playerPoints.Add(Vars.scoreD);
            PlayerNameAndPoint.Add(new NamePoints { playerName = Vars.nameD, Points = Vars.scoreD });
        }
        ViewRankingPage.instance.playerRankList.Clear();
        playerPoints.Sort();
        for (int i = playerPoints.Count - 1; i >= 0; i--)
        {
            winnerPlayerPoints.Add(playerPoints[i]);
        }
        for (int j = 0; j < winnerPlayerPoints.Count; j++)
        {
            for (int k = 0; k < PlayerNameAndPoint.Count; k++)
            {
                if (winnerPlayerPoints[j] == PlayerNameAndPoint[k].Points)
                {
                    yield return text("Player Name :" + PlayerNameAndPoint[k].playerName + " point : " + PlayerNameAndPoint[k].Points);
                    ViewRankingPage.instance.playerRankList.Add(PlayerNameAndPoint[k].playerName.ToString());
                    yield return lineBreak();
                    PlayerNameAndPoint.RemoveAt(k);
                    goto next;
                }
            }
        next:;
        }

        //yield return lineBreak();
        //yield return lineBreak();
        //yield return text(Vars.winner);
        //yield return text(" ");
        //yield return text("is the winner!");
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00211"))
        //    yield return link("Click to see your Ending.", null, () => enchantHook("h00211", HarloweEnchantCommand.Replace, passage327_Fragment_0));
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: VarEndingsPassage   (passage1008)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33511-33522
// Links:  -
// Aborts: -
// Purpose: CODE: endings dispatcher; sets `winner` from GLOBALS and aborts to the chosen ending
// ###################################################################

    void passage1008_Init()
    {
        this.Passages[@"VarEndingsPassage"] = new StoryPassage(@"VarEndingsPassage", new string[] { }, passage1008_Main);
    }

    IStoryThread passage1008_Main()
    {
        Vars.winner = GLOBALS.winnerName;
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return abort(goToPassage: Vars.ending);
        yield break;
    }

// ###################################################################
// PASSAGE: ScoreEntryP2   (passage328)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33527-33566
// Links:  WinnerHUB,ScoreEntryP3
// Aborts: -
// Purpose: Prompts for player 2's final score
// ###################################################################

    void passage328_Init()
    {
        this.Passages[@"ScoreEntryP2"] = new StoryPassage(@"ScoreEntryP2", new string[] { }, passage328_Main);
    }

    IStoryThread passage328_Main()
    {
        if (/*(Vars.scoreA == "" || Vars.scoreA == 0) &&*/ ispopup)
        {
            //yield return lineBreak();
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("ScoreEntryP2", "Please enter the final score for " + Vars.nameB + ".", "number", 0.5f);
        }
        if (ViewPopupPanel.instance.PassageValueNumber() >= 0)
        {
            Vars.scoreB = ViewPopupPanel.instance.PassageValueNumber();
            ispopup = true;
        }
        //Vars.scoreB = ("rompt: Please enter the final score for $nameB.");
        //yield return lineBreak();
        //using (styleScope("heading", 1))
        //{
        //    yield return text("ERROR!");
        //}
        yield return text("Thank you for recording this important historical information, ");
        yield return text(Vars.nameB);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players < 3)
        {
            yield return link("Click to continue...", "WinnerHUB", null);
        }
        else
        {
            yield return link("Click to continue...", "ScoreEntryP3", null);
        }
        yield break;
    }

// ###################################################################
// PASSAGE: ScoreEntryP3   (passage329)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33572-33611
// Links:  WinnerHUB,ScoreEntryP4
// Aborts: -
// Purpose: Prompts for player 3's final score
// ###################################################################

    void passage329_Init()
    {
        this.Passages[@"ScoreEntryP3"] = new StoryPassage(@"ScoreEntryP3", new string[] { }, passage329_Main);
    }

    IStoryThread passage329_Main()
    {
        //Vars.scoreC = ("rompt: Please enter the final score for $nameC.");
        //yield return lineBreak();
        //using (styleScope("heading", 1))
        //{
        //    yield return text("ERROR!");
        //}
        if (/*(Vars.scoreA == "" || Vars.scoreA == 0) &&*/ ispopup)
        {
            //yield return lineBreak();
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("ScoreEntryP3", "Please enter the final score for " + Vars.nameC + ".", "number", 0.5f);
        }
        if (ViewPopupPanel.instance.PassageValueNumber() >= 0)
        {
            Vars.scoreC = ViewPopupPanel.instance.PassageValueNumber();
            ispopup = true;
        }
        yield return text("Thank you for recording this important historical information, ");
        yield return text(Vars.nameC);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players < 4)
        {
            yield return link("Click to continue...", "WinnerHUB", null);
        }
        else
        {
            yield return link("Click to continue...", "ScoreEntryP4", null);
        }
        yield break;
    }

// ###################################################################
// PASSAGE: ScoreEntryP4   (passage330)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33617-33656
// Links:  WinnerHUB,ScoreEntryP5
// Aborts: -
// Purpose: Prompts for player 4's final score
// ###################################################################

    void passage330_Init()
    {
        this.Passages[@"ScoreEntryP4"] = new StoryPassage(@"ScoreEntryP4", new string[] { }, passage330_Main);
    }

    IStoryThread passage330_Main()
    {
        //Vars.scoreD = ("rompt: Please enter the final score for $nameD.");
        //yield return lineBreak();
        //using (styleScope("heading", 1))
        //{
        //    yield return text("ERROR!");
        //}
        if (/*(Vars.scoreA == "" || Vars.scoreA == 0) &&*/ ispopup)
        {
            //yield return lineBreak();
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("ScoreEntryP4", "Please enter the final score for " + Vars.nameD + ".", "number", 0.5f);
        }
        if (ViewPopupPanel.instance.PassageValueNumber() >= 0)
        {
            Vars.scoreD = ViewPopupPanel.instance.PassageValueNumber();
            ispopup = true;
        }
        yield return text("Thank you for recording this important historical information, ");
        yield return text(Vars.nameD);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players < 5)
        {
            yield return link("Click to continue...", "WinnerHUB", null);
        }
        else
        {
            yield return link("Click to continue...", "ScoreEntryP5", null);
        }
        yield break;
    }

// ###################################################################
// PASSAGE: ScoreEntryP5   (passage331)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33662-33698
// Links:  WinnerHUB
// Aborts: -
// Purpose: Prompts for player 5's final score
// ###################################################################

    void passage331_Init()
    {
        this.Passages[@"ScoreEntryP5"] = new StoryPassage(@"ScoreEntryP5", new string[] { }, passage331_Main);
    }

    IStoryThread passage331_Main()
    {
        if (Vars.players < 5)
        {
            yield return abort(goToPassage: "WinnerHUB");
        }
        //Vars.scoreE = ("rompt: Please enter the final score for $nameE.");
        //yield return lineBreak();
        //using (styleScope("heading", 1))
        //{
        //    yield return text("ERROR!");
        //}
        if (/*(Vars.scoreA == "" || Vars.scoreA == 0) &&*/ ispopup)
        {
            //yield return lineBreak();
            ispopup = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("ScoreEntryP5", "Please enter the final score for " + Vars.nameE + ".", "number", 0.5f);
        }
        if (ViewPopupPanel.instance.PassageValueNumber() >= 0)
        {
            Vars.scoreE = ViewPopupPanel.instance.PassageValueNumber();
            ispopup = true;
        }
        yield return text("Thank you for recording this important historical information, ");
        yield return text(Vars.nameE);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue.", "WinnerHUB", null);
        yield break;
    }

// ###################################################################
// PASSAGE: END-HuntersEvil2   (passage332)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33704-33740
// Links:  -
// Aborts: -
// Purpose: Ending "Overshadowed and Exploited": the family's knowledge dies with them
// ###################################################################

    void passage332_Init()
    {
        this.Passages[@"END-HuntersEvil2"] = new StoryPassage(@"END-HuntersEvil2", new string[] { }, passage332_Main);
    }

    IStoryThread passage332_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Overshadowed and Exploited");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return text(@"While this history may contain a modicum of inconceivable occurrences that stretch the limits of the imagination, it remains a peculiar story relegated to an obscure place and time. It is a mostly forgotten artifact of an era of pseudo-science and speculation that amounted to very little historical significance.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("For it was not the experimentations of ");
        yield return text(Vars.playtxt);
        yield return text(" ");
        yield return text(@"ambitious and incredulous scientists that were remembered, it was the Hunters that amassed fame, wealth, and respect on the backs of the superstitious peasants. The disease that wreaked havoc on the countryside was ignored; recast as a demonic presence from folklore; one that could only be kept at bay through the continued vigilance of the Fraternity of Hunters, which of course came at a great financial cost.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Over the next several years, the Fraternity and its members abandoned the town for more lucrative positions within the government. Soon the not-so-secret society became the affluent aristocrats controlling the entirety of the Hungarian political establishment from the shadows. And the family, who once commanded a measure of reverence, were assigned to obscure prefectures of their own across the country.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If this story is to be believed, then their knowledge still remains trapped withi" +
            "n the decaying walls of stone estates overlooking the forgotten village of ");
        yield return text(Vars.townname);
        yield return text(". The work was finally over.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: END-WolvesEvil2   (passage333)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33746-33773
// Links:  -
// Aborts: -
// Purpose: Ending "The Spread of Evil": the work unleashes an unstoppable plague
// ###################################################################

    void passage333_Init()
    {
        this.Passages[@"END-WolvesEvil2"] = new StoryPassage(@"END-WolvesEvil2", new string[] { }, passage333_Main);
    }

    IStoryThread passage333_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Spread of Evil");
        }
        ViewGenerationEnding.instance.EnableDisableContinueBtn(true);
        yield return lineBreak();
        yield return text(@"I write these final words under candle-light, from a shelter I have fashioned in the crawl-space beneath the manor. For a desk, a dusty plank of cedar. I try to keep my utensils above the floor which can become musty and dank during my frequent overnight stays: a dull quill, ink, several lengths of charcoal, a ream of parchment. It is no longer safe to sleep in my bed when night falls. The creatures emerge from the shadows to feed on the few souls that still remain, or to irreversibly change them into shambling horrors most unimaginable.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"To think that my work to uncover the genealogy of a mildly successful scientific family would cause me to become consumed by a maelstrom of spreading evil! It is my hope that when I complete this writing (if I complete this writing), that these words will offer a history to condemn these fools and their complicity with demons. The world must know who is responsible. It must condemn the group who coddled darkness and made a mockery of science!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("O God, I hear the creatures again! Their malformed claw-tips scratching at the fl" +
            "oorboards! Damn them for what they have done! Damn this infernal work. For it ha" +
            "s unleashed a plague upon the land of which there can be no end in sight.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("THE END?");
        yield break;
    }

// ###################################################################
// PASSAGE: WinnerHUBproblem   (passage337)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34027-34077
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: unimplemented tie-breaker rules for determining the winner
// ###################################################################

    void passage337_Init()
    {
        this.Passages[@"WinnerHUBproblem"] = new StoryPassage(@"WinnerHUBproblem", new string[] { }, passage337_Main);
    }

    IStoryThread passage337_Main()
    {
        yield return text("What I\'m trying to do is compare all the entered scores and find the winner. BUT," +
            " this code below doesn\'t take into account TIES.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("FIRST TIE-BREAKER:");
        yield return lineBreak();
        yield return text("Did all tied players complete their Masterwork?");
        yield return lineBreak();
        yield return text("YES.");
        yield return lineBreak();
        yield return text("NO.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If no, choose the tied players that COMPLETED their Masterwork.");
        yield return lineBreak();
        yield return text("(display tied player names with a multiple-checkable boxes beside them)");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("SECOND TIE-BREAKER:");
        yield return lineBreak();
        yield return text("Which tied player built the most Estate Upgrades?");
        yield return lineBreak();
        yield return text("(display tied players\' names with a single checkable box beside them)");
        yield return lineBreak();
        yield return text("(also display checkable box that says \"Still tied\")");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If ");
        using (styleScope("bold", true))
        {
            yield return text("still tied");
        }
        yield return text(", set the ");
        yield return text(Vars.winner);
        yield return text(" ");
        yield return text("to \"the family.\"");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Otherwise, set ");
        yield return text(Vars.winner);
        yield return text(" ");
        yield return text("to the winner.");
        yield break;
    }

// ###################################################################
// PASSAGE: SidestepPageTemporary   (passage338)
// Tags: temp
// Source: TheCostofDiseaseEng.cs lines 34083-34092
// Links:  ScoreEntryP1
// Aborts: -
// Purpose: TEMP bypass page linking straight to score tabulation
// ###################################################################

    void passage338_Init()
    {
        this.Passages[@"SidestepPageTemporary"] = new StoryPassage(@"SidestepPageTemporary", new string[] { "temp", }, passage338_Main);
    }

    IStoryThread passage338_Main()
    {
        yield return link("Click to tabulate scores for posterity...", "ScoreEntryP1", null);
        yield break;
    }

// ###################################################################
// PASSAGE: AltStartPreviews   (passage339)
// Tags: removetemp
// Source: TheCostofDiseaseEng.cs lines 34098-34138
// Links:  TITLE SCREEN
// Aborts: -
// Purpose: Preview-edition welcome screen; links to TITLE SCREEN
// ###################################################################

    void passage339_Init()
    {
        this.Passages[@"AltStartPreviews"] = new StoryPassage(@"AltStartPreviews", new string[] { "removetemp", }, passage339_Main);
    }

    IStoryThread passage339_Main()
    {
        yield return lineBreak();
        yield return text("Welcome to");
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("MY FATHER\'S WORK");
        }
        yield return lineBreak();
        yield return text("Preview Edition");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("This is a preview prototype version of the full My Father\'s Work game and include" +
            "s the complete scenario: ");
        using (styleScope("bold", true))
        {
            yield return text("The Cost of Disease");
        }
        yield return text(". This version only includes the ");
        using (styleScope("bold", true))
        {
            yield return text("text");
        }
        yield return text(" ");
        yield return text("needed to play which should be read aloud to all players when appropriate.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The final version will be available as a free download for Apple and Android devices. It will feature gorgeous illustrations, atmospheric audio, helpful visual examples, introductory voice narration, and additional modes to track player scores and unlocked Endings. For the moment, we ask your patience as we labor to bring the full digital version into existence.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to continue...", "TITLE SCREEN", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NoLink   (passage340)
// Tags: tempremove
// Source: TheCostofDiseaseEng.cs lines 34144-34161
// Links:  Start2
// Aborts: -
// Purpose: Stub for scenarios not in the Preview version; returns to Start2
// ###################################################################

    void passage340_Init()
    {
        this.Passages[@"NoLink"] = new StoryPassage(@"NoLink", new string[] { "tempremove", }, passage340_Main);
    }

    IStoryThread passage340_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Our Sincerest Apology");
        }
        yield return lineBreak();
        yield return text("This scenario is not available in the Preview version.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to return...", "Start2", null);
        yield break;
    }
