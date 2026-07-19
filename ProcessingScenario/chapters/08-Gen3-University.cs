// ===================================================================
// CHAPTER: Gen3-University   (20 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage14    UniversityIntro              L3041-3075  Generation III prose intro: the university was funded
// passage25    ForScience                   L3513-3584  "Award the Prize" Nobel event: least-Creepy player loses 7VP
// passage26    SanityCheck                  L3589-3657  End-of-generation Insanity-track scoring: 5VP on the target space
// passage38    University2                  L5567-5674 [HUB]  Round-2 HUB "SEARCH FOR THE CURE - Middle Years"
// passage39    University3                  L5679-5786 [HUB]  Round-3 HUB "SEARCH FOR THE CURE - Late Years"
// passage97    UniImmortal                  L10726-10834  Gen3 University Immortality setup: immortal parents return Caretakers; others lose 2 Creepy
// passage127   SanityChoice                 L14222-14334  A player privately picks an Insanity Track space; ending there = 5VP
// passage198   PostUniversity-Notes         L22707-22751  DEV NOTE: post-University branch (Mayor/Charity rewards, Ultimate Disease, Immortality)
// passage199   UniMayor                     L22757-22848  Mayoral parade; grants a Charity Memorial estate tile; returns the Coin
// passage200   UniCharity                   L22853-22983  Charity memorial ceremony; free Journal advance, lose 2VP, return the Heart token
// passage201   UniEquity                    L22988-23047  University equity boost: trailing players gain 1VP per player ahead
// passage202   UniEquity1                   L23052-23108  Repeat equity assessment in a later round
// passage203   UniEvent1-UltimateDisease    L23113-23165  Cousins resolve to create the ultimate disease
// passage204   UniEvent2-UltimateDisease    L23171-23270  Vote: contribute a Chemistry/Occult Experiment toward the disease
// passage205   UniEvent2-Success            L23275-23361  Disease released but accidentally inoculates the region
// passage206   UniEvent2-Failure            L23366-23458  Collaboration collapses; lowest-research player advances; "yay" voters lose Creepy
// passage233   PanaceaUnleashCons2          L25789-25843  Same "Whispers Abate" servant recovery on the University path; leads to University1
// passage257   University1                  L27567-27695 [HUB]  "Search for the Cure - Early Years" HUB: setup, Nobel penalty, Perfect Mental Balance
// passage315   InsanitySign                 L32332-32425  University consults the family; select the player with the least VP
// passage348   UniEvent2-UltimateDisease2   L34514-34549  Tallies the ultimate-disease vote; branches Success/Failure
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   University2          --end of round-->  UniEvent2-UltimateDisease
//   University3          --end of round-->  SanityCheck
//   University1          --end of round-->  UniEquity1
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: UniversityIntro   (passage14)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 3041-3075
// Links:  UniMayor
// Aborts: -
// Purpose: Generation III prose intro: the university was funded
// ###################################################################

    void passage14_Init()
    {
        this.Passages[@"UniversityIntro"] = new StoryPassage(@"UniversityIntro", new string[] { "INTRO", }, passage14_Main);
    }

    IStoryThread passage14_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION III:");
            yield return lineBreak();
            yield return text("The University Advances");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.theme = macros1.either("\"Chemistry\"", "\"Engineering\"", "\"Biology\"");
        yield return lineBreak();
        yield return text(@"They observed the city from the windows of their manor; watched as men in their brown sack suits and women with sashes tied firmly about their waists wandered the bustling sidewalks and modern pathways that winded throughout the university. What was once a bucolic and unknown region had developed into a thriving metropolis.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"And yet, it was that very same prosperity of the city that taunted them. Was it not their family's genius, their forebear's business acumen and ambition that exiled disease from the country? Was it not their shrewd antecedents that secured the government's funding of a university — the same who entered into this generation with the secret to eternal life?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Still the townsfolk eyed them as they would a foreigner, with silent judgement in their hearts. While the administration of the university offered assistance and reached out with kind words of encouragement, it was clear to the family that their presence was not truly appreciated. With each passing day, their resentment grew deeper. It seethed under the surface of their ambitious, technical labors.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Science should not be contained by the arbitrary limits of ethics. They believed that this was their chance to legitimize the family's research and to prove that bold, swift, and unmitigatable genius would propel the world forward. The ends would justify the means. From darkness, an electric spark would form to capture the entire scientific world within its grasp!");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "UniMayor", null);
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: ForScience   (passage25)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3513-3584
// Links:  Scoring
// Aborts: -
// Purpose: "Award the Prize" Nobel event: least-Creepy player loses 7VP
// ###################################################################

    void passage25_Init()
    {
        this.Passages[@"ForScience"] = new StoryPassage(@"ForScience", new string[] { }, passage25_Main);
    }

    IStoryThread passage25_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Award the Prize");
        }
        yield return lineBreak();
        yield return text("It was inescapable. The most prestigious award in science and all the conventiona" +
            "l praise, scrutiny, and adoration it engendered was thrust upon one of the famil" +
            "y.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"For a normal scientist, it should be the pinnacle of achievements; an honor that would ensure their name etched forever in the halls of academia. And that was just it. To be revered fondly by the same association that simultaneously despises the very source of the family's infamous ingenuity. Not to mention the additional obligations from the cursed establishment would pull them from their work up until their final hours.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("No, for them, this honor was the proverbial final nail in the coffin.");
        yield return lineBreak();
        yield return lineBreak();

        //yield return link("Click to continue...", "Scoring", null);
        using (styleScope("hook", "h00000025"))
            yield return link("Click to continue...", null, () => enchantHook("h00000025", HarloweEnchantCommand.Replace, passage25_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage25_Fragment_0()
    {
        yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Scoring";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The ");
            Vars._SetupImage = "Creepy_Icon";
            using (styleScope("bold", true))
            {
                yield return text("least ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("player ");
            using (styleScope("bold", true))
            {
                yield return text("loses 7VP.");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("(If there is a tie, ALL tied players ");
                using (styleScope("bold", true))
                {
                    yield return text("lose 4VP");
                }
                yield return text(" ");
                yield return text("instead.)");
                yield return lineBreak();
            }
            yield return lineBreak();
        }
        yield break;
    }

// ###################################################################
// PASSAGE: SanityCheck   (passage26)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3589-3657
// Links:  ForScience
// Aborts: -
// Purpose: End-of-generation Insanity-track scoring: 5VP on the target space
// ###################################################################

    void passage26_Init()
    {
        this.Passages[@"SanityCheck"] = new StoryPassage(@"SanityCheck", new string[] { }, passage26_Main);
    }

    IStoryThread passage26_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Final Clarity");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The boundary between mental instability and genius had been tested. It was this acuity, this willingness to find the perfect balance between madness and determination that defined the lives of this infamous family circle.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Continue to Final Scoring", "ForScience", null);
        using (styleScope("hook", "h00000026"))
            yield return link("Continue to Final Scoring", null, () => enchantHook("h00000026", HarloweEnchantCommand.Replace, passage26_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage26_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "ForScience";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SCORING");
            }
            Vars._SetupImage = "Insanity_Icon";
            //yield return lineBreak();
            //yield return lineBreak();
            yield return text("All players with their token on space ");
            yield return text(Vars.mental);
            yield return text(" ");
            yield return text("of the ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track ");
            using (styleScope("bold", true))
            {
                yield return text("gain 5VP");
            }
            yield return text(" ");
            yield return text("each.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("If ");
            yield return text(Vars.saneplayer);
            yield return text(" ");
            yield return text("has their token on space ");
            yield return text(Vars.mental);
            yield return text(", they ");
            using (styleScope("bold", true))
            {
                yield return text("gain ");
                yield return text(macros1.either(8, 9));
                yield return text("VP");
            }
            yield return text(" ");
            yield return text("instead.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: University2   (passage38)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 5567-5674
// Links:  UniEvent2-UltimateDisease
// Aborts: -
// Round end -> UniEvent2-UltimateDisease
// Purpose: Round-2 HUB "SEARCH FOR THE CURE - Middle Years"
// ###################################################################

    void passage38_Init()
    {
        this.Passages[@"University2"] = new StoryPassage(@"University2", new string[] { "HUB", }, passage38_Main);
    }

    IStoryThread passage38_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SEARCH FOR THE CURE - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 20;
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("The Ultimate Disease");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of this round, players will be given the opportunity to contribute 1 ");
            using (styleScope("bold", true))
            {
                yield return text("Chemistry or Occult");
            }
            yield return text(" ");
            yield return text("Experiment to create and unleash a new disease upon the town.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Nobel Prize in Medicine");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("The scientific world has finally taken notice of ");
            yield return text(Vars.townname);
            yield return text(" ");
            yield return text("and its ");
            yield return text(Vars.playtxt);
            yield return text(" ");
            yield return text("ingenious scholars. The absurdity of it all! Not only does this hamper their abil" +
                "ity to experiment freely, it also gives their work mainstream merit.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the End of the Generation, the ");
            using (styleScope("bold", true))
            {
                yield return text("least ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("player will be awarded this prestigious award and ");
            using (styleScope("bold", true))
            {
                yield return text("lose 7VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Perfect Mental Balance");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of the Generation, if your piece is on space ");
            yield return text(Vars.mental);
            yield return text(" ");
            yield return text("of the ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track, you will ");
            using (styleScope("bold", true))
            {
                yield return text("gain 5VP");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round for a special event.", "UniEvent2-UltimateDisease", null);
            using (styleScope("hook", "h000038"))
                yield return link("Click here at the end of the round for a special event.", null, () => enchantHook("h000038", HarloweEnchantCommand.Replace, passage38_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage38_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("University2", "UniEvent2-UltimateDisease");
        yield break;
    }

// ###################################################################
// PASSAGE: University3   (passage39)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 5679-5786
// Links:  -
// Aborts: -
// Round end -> SanityCheck
// Purpose: Round-3 HUB "SEARCH FOR THE CURE - Late Years"
// ###################################################################

    void passage39_Init()
    {
        this.Passages[@"University3"] = new StoryPassage(@"University3", new string[] { "HUB", }, passage39_Main);
    }

    IStoryThread passage39_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SEARCH FOR THE CURE - Late Years");
        }
        yield return lineBreak();
        Vars.round = 21;
        yield return lineBreak();
        if (Vars.ultimate == "yes")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "VillageChronicleCover";
                yield return lineBreak();
                yield return text("Turn to page ");
                using (styleScope("bold", true))
                {
                    yield return text("11");
                }
                yield return text("in the Village Chronicle.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Nobel Prize in Medicine");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("The scientific world has finally taken notice of ");
            yield return text(Vars.townname);
            yield return text(" ");
            yield return text("and its ");
            yield return text(Vars.playtxt);
            yield return text(" ");
            yield return text("ingenious scholars. The absurdity of it all! Not only does this hamper their abil" +
                "ity to experiment freely, it also gives their work mainstream merit.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the End of the Generation, the ");
            using (styleScope("bold", true))
            {
                yield return text("least ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("player will be awarded this prestigious award and ");
            using (styleScope("bold", true))
            {
                yield return text("lose 7VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Perfect Mental Balance");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of the Generation, if your piece is on space ");
            yield return text(Vars.mental);
            yield return text(" ");
            yield return text("of the ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track, you will ");
            using (styleScope("bold", true))
            {
                yield return text("gain 5VP");
            }
            yield return text(".");
            yield return lineBreak();
            Vars.ending = "END-UniGood";
            yield return lineBreak();
            using (styleScope("hook", "h00019"))
                yield return link("Click here at the end of the Generation for Final Scoring and to Determine the Fa" +
                "te of the Town.", null, () => enchantHook("h00019", HarloweEnchantCommand.Replace, passage39_Fragment_0));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage39_Fragment_0()
    {
        //yield return abort(goToPassage: "SanityCheck");
        PassageTracker.instance.CheckProgress("University3", "SanityCheck");
        yield break;
    }

// ###################################################################
// PASSAGE: UniImmortal   (passage97)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10726-10834
// Links:  UniEquity
// Aborts: -
// Purpose: Gen3 University Immortality setup: immortal parents return Caretakers; others lose 2 Creepy
// ###################################################################

    void passage97_Init()
    {
        this.Passages[@"UniImmortal"] = new StoryPassage(@"UniImmortal", new string[] { }, passage97_Main);
    }

    IStoryThread passage97_Main()
    {
        if (Vars.life == 0)
        {
            yield return abort(goToPassage: "UniEquity");
        }
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Immortality");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"Claiming an inheritance whilst one's parent still lives on; this foreign concept was decidedly unnerving both for the returning youths and their unaware spouses. However, after the initial shock of encountering a surprisingly spry parent tending to the Estate, the additional help did prove useful.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("For those whose parents had chosen a more amenable fate, having no secrets to con" +
                "ceal caused less suspicion during interactions with the local populace.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage97_Fragment_1);
            using (styleScope("hook", "h00097"))
                yield return link("Click to continue...", null, () => enchantHook("h00097", HarloweEnchantCommand.Replace, passage97_Fragment_0));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage97_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "UniEquity";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "GainCaretakerFromLost";
            yield return lineBreak();
            if (Vars.lifeA == "yes")
            {
                yield return text(Vars.nameA);
                yield return text(" retrieves a Caretaker piece from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeB == "yes")
            {
                yield return text(Vars.nameB);
                yield return text(" retrieves a Caretaker piece from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeC == "yes")
            {
                yield return text(Vars.nameC);
                yield return text(" retrieves a Caretaker piece from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeD == "yes")
            {
                yield return text(Vars.nameD);
                yield return text(" retrieves a Caretaker piece from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeE == "yes")
            {
                yield return text(Vars.nameE);
                yield return text(" retrieves a Caretaker piece from lost.");
                yield return lineBreak();
            }
            if (Vars.lifeA != "yes" && Vars.lifeB != "yes" && Vars.lifeC != "yes" && Vars.lifeD != "yes" && Vars.lifeE != "yes")
            {
                yield return text(Vars.nameA);
                yield return text(" retrieves a Caretaker piece from lost.");
                yield return lineBreak();
            }
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
        //yield return link("Click here to continue...", "UniEquity", null);
        yield break;
    }

    IStoryThread passage97_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage97_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: SanityChoice   (passage127)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14222-14334
// Links:  -
// Aborts: -
// Purpose: A player privately picks an Insanity Track space; ending there = 5VP
// ###################################################################

    void passage127_Init()
    {
        this.Passages[@"SanityChoice"] = new StoryPassage(@"SanityChoice", new string[] { }, passage127_Main);
    }

    IStoryThread passage127_Main()
    {
        yield return lineBreak();
        Vars.gen3pg = 0;
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to ");
            yield return text(Vars.saneplayer);
            yield return text(". This choice is read and made within view of all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Journal Entry, ");
            yield return text(Vars.saneplayer);
            yield return text(" ");
            yield return text("- September, 1892");
        }
        yield return lineBreak();
        yield return text(@"The fools! The utter fools! In their haste to return to their amateurish attempts at science, my dear, witless cousins have been overlooked by our colleagues at the university. And so it fell to me to advise them on this most important psychological matter!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"My in-depth studies of phrenology and first-hand observation of brain function have allowed me to calculate with flawless accuracy the appropriate level of mental intensity needed to excel in science; the most proper balance of passion and ethical ambiguity.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While, yes, we may ALL benefit from this assessment and yes, they did only consul" +
            "t me out of a sense of pity, it is I alone that will now control the fate of us " +
            "all!");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE");
        }
        yield return lineBreak();
        yield return text(Vars.saneplayer);
        yield return text(" ");
        yield return text("must now choose a numbered spot below on the ");
        yield return text("<sprite=\"Insanity_Icon\" index=0>");
        yield return text(" ");
        yield return text("Track.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("At the end of the Generation, any player whose piece is on this space will ");
        using (styleScope("bold", true))
        {
            yield return text("gain 5VP");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00068"))
            yield return link("3", null, () => enchantHook("h00068", HarloweEnchantCommand.Replace, passage127_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00069"))
            yield return link("4", null, () => enchantHook("h00069", HarloweEnchantCommand.Replace, passage127_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00070"))
            yield return link("5", null, () => enchantHook("h00070", HarloweEnchantCommand.Replace, passage127_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00071"))
            yield return link("6", null, () => enchantHook("h00071", HarloweEnchantCommand.Replace, passage127_Fragment_3));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00072"))
            yield return link("7", null, () => enchantHook("h00072", HarloweEnchantCommand.Replace, passage127_Fragment_4));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage127_Fragment_0()
    {
        Vars.mental = 3;
        yield return abort(goToPassage: "PanaceaUnleashCons2");
        yield break;
    }

    IStoryThread passage127_Fragment_1()
    {
        Vars.mental = 4;
        yield return abort(goToPassage: "PanaceaUnleashCons2");
        yield break;
    }

    IStoryThread passage127_Fragment_2()
    {
        Vars.mental = 5;
        yield return abort(goToPassage: "PanaceaUnleashCons2");
        yield break;
    }

    IStoryThread passage127_Fragment_3()
    {
        Vars.mental = 6;
        yield return abort(goToPassage: "PanaceaUnleashCons2");
        yield break;
    }

    IStoryThread passage127_Fragment_4()
    {
        Vars.mental = 7;
        yield return abort(goToPassage: "PanaceaUnleashCons2");
        yield break;
    }

// ###################################################################
// PASSAGE: PostUniversity-Notes   (passage198)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22707-22751
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: post-University branch (Mayor/Charity rewards, Ultimate Disease, Immortality)
// ###################################################################

    void passage198_Init()
    {
        this.Passages[@"PostUniversity-Notes"] = new StoryPassage(@"PostUniversity-Notes", new string[] { }, passage198_Main);
    }

    IStoryThread passage198_Main()
    {
        yield return text("PostUni -");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Mayor is rewarded.");
        yield return lineBreak();
        yield return text("Charity is rewarded.");
        yield return lineBreak();
        yield return text("Players are given extra bonus points for being behind. 1st place is considered Cr" +
            "eepier, gain 1 Creepy.");
        yield return lineBreak();
        yield return text("Gameplay changes include a Nobel Prize for the least Creepy scientist.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("1st Gen - Event - Things are TOO GOOD. We need to create the Ultimate Disease.");
        yield return lineBreak();
        yield return text("If players agree to work towards a master disease, an Ultimate Disease is created" +
            ". Problem is while a few initial cases are reported, the antibodies this creates" +
            " essentially give herd immunity to the entire region.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Immortality thread - players w/ immortality can choose to kill their parent. Sani" +
            "ty reduction.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Single Card - Ultimate - Anyone can complete it.  Once complete:");
        yield return lineBreak();
        yield return text("2nd Gen - VOTE to unleash the disease or not. Create the Disease or do not.");
        yield return lineBreak();
        yield return text("Anyone who is behind in Research gains a boost on a track of their choice.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("-");
        yield break;
    }

// ###################################################################
// PASSAGE: UniMayor   (passage199)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22757-22848
// Links:  UniImmortal
// Aborts: -
// Purpose: Mayoral parade; grants a Charity Memorial estate tile; returns the Coin
// ###################################################################

    void passage199_Init()
    {
        this.Passages[@"UniMayor"] = new StoryPassage(@"UniMayor", new string[] { }, passage199_Main);
    }

    IStoryThread passage199_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Legacy of Leadership");
        }
        yield return lineBreak();
        if (Vars.uni == "yes")
        {
            yield return text("With the continued success of the University");
        }
        //if (Vars.uni == "no")
        else
        {
            yield return text("To christen the advantageous construction of the new university");
        }
        yield return text(" ");
        yield return text("and the return of the eccentric family seemingly responsible for that turn of eve" +
            "nts, the city of ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("arranged a large parade.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Photographs from the event show a disgruntled individual sitting atop a large flo" +
            "at made of crocuses and lilies, powered by a newly procured steam and wheel devi" +
            "ce. ");
        yield return text(Vars.mayor);
        yield return text(" ");
        yield return text("III does not mention this event within their journal, however it is noted extensi" +
            "vely and with great sardonic enthusiasm for the next several months in the journ" +
            "als of their cousins.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was under the leadership of ");
        yield return text(Vars.mayor);
        yield return text(" ");
        yield return text("that this push for modern sensibilities was first spearheaded and the town could " +
            "not forget the significance of this event.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage199_Fragment_1);
        using (styleScope("hook", "h000199"))
            yield return link("Click to continue...", null, () => enchantHook("h000199", HarloweEnchantCommand.Replace, passage199_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage199_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.life == 0 ? "UniEquity" : "UniImmortal";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MayorCoin";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Retrieve a ");
            using (styleScope("bold", true))
            {
                yield return text("Charity Memorial");
            }
            yield return text(" ");
            yield return text("Estate Tile from the scenario box. ");
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("III may build this in their next available plot. They do not have to pay the cost" +
                " to open a new plot.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Return the Commemorative Mayoral Coin to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "UniImmortal", null);
        yield break;
    }

    IStoryThread passage199_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage199_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: UniCharity   (passage200)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22853-22983
// Links:  DetEffectRandom
// Aborts: -
// Purpose: Charity memorial ceremony; free Journal advance, lose 2VP, return the Heart token
// ###################################################################

    void passage200_Init()
    {
        this.Passages[@"UniCharity"] = new StoryPassage(@"UniCharity", new string[] { }, passage200_Main);
    }

    IStoryThread passage200_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Charity\'s Legacy");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.mayor == Vars.charity)
        {
            yield return text("It seemed the festivities in ");
            yield return text(Vars.townname);
            yield return text(" could scarcely cease before another bright and joyous event occurred. Only a few " +
            "years after a memorial had been erected in the honor of ");
            yield return text(Vars.mayor);
            yield return text(" III, the Hospital could not contain its admiration as well. It was surprised and " +
            "overjoyed to discover that the same individual\'s family was not only responsible" +
            " for guiding the town politically, but cemented their important legacy of giving" +
            ".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(Vars.mayor);
            yield return text(@" III was visibly agitated by the intrusion into their affairs, but when offered assistance from top researchers in the region, their surly demeanor softened temporarily. Perhaps the minor inconvenience of friendship and celebration would be worth the boon to their inventions.");

        }
        else
        {
            yield return text("It seemed the festivities in ");
            yield return text(Vars.townname);
            yield return text(" ");
            yield return text("could scarcely cease before another bright and joyous event occurred. Only a few " +
                "years after a memorial had been erected in the honor of ");
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("III, the Hospital could not contain its admiration as well. ");
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("III was offered the same generosity.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("In honor of ");
            yield return text(Vars.charity);
            yield return text("\'s legacy of charity, another memorial was revealed at a prestigious ceremony, ce" +
                "lebrating the continued medical contributions of ");
            yield return text(Vars.townname);
            yield return text(". As a university town, the small village hosted an impressive pedigree of schola" +
                "rs who worked with the most advanced methodology in treatment and disease preven" +
                "tion.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage200_Fragment_1);
        using (styleScope("hook", "h000200"))
            yield return link("Click to continue...", null, () => enchantHook("h000200", HarloweEnchantCommand.Replace, passage200_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage200_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "DetEffectRandom";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_HeartToken";
            yield return lineBreak();
            yield return lineBreak();
            if (Vars.mayor == Vars.charity)
            {
                yield return text("Immediately move ");
                using (styleScope("bold", true))
                {
                    yield return text("1 space forward");
                }
                yield return text(" on the Journal track of your choice ");
                using (styleScope("italic", true))
                {
                    yield return text("for no cost");
                }
                yield return text(". Then, lose ");
                using (styleScope("bold", true))
                {
                    yield return text("2VP");
                }
                yield return text(".");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Return the ");
                using (styleScope("bold", true))
                {
                    yield return text("Heart ");
                    yield return text("<sprite=\"S1_HeartToken\" index=0>");
                    yield return text(" token");
                }
                yield return text(" to the scenario box.");
            }
            else
            {
                yield return text("Retrieve a ");
                using (styleScope("bold", true))
                {
                    yield return text("Charity Memorial");
                }
                yield return text(" ");
                yield return text("Estate Tile from the scenario box. ");
                yield return text(Vars.charity);
                yield return text(" ");
                yield return text("III may build this in their next available plot. They do not have to pay the cost" +
                    " to open a new plot. \n\nReturn the <b>Heart <sprite=\"S1_HeartToken\" index=0> token</b> to the scenario box.");
            }
        }
        yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "DetEffectRandom", null);
        yield break;
    }

    IStoryThread passage200_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage200_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: UniEquity   (passage201)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22988-23047
// Links:  InsanitySign
// Aborts: -
// Purpose: University equity boost: trailing players gain 1VP per player ahead
// ###################################################################

    void passage201_Init()
    {
        this.Passages[@"UniEquity"] = new StoryPassage(@"UniEquity", new string[] { }, passage201_Main);
    }

    IStoryThread passage201_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Guiding Hand of Science");
        }
        yield return lineBreak();
        yield return text(@"At the behest of the university’s administrators, it was decided to more prominently feature scholarly works produced by local inventors. However, the administration deemed it unwise to promote the works of those who had already solidified their presence in the public eye. The course of action they deemed most appropriate was to provide an “equitable” boost to amplify the standing of lesser-known scientists, to better display the breadth of knowledge and ambition within the humble city of ");
        yield return text(Vars.townname);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The family was disgusted by this “lopsided” display of unmerited assistance. Howe" +
            "ver, they accepted it nonetheless, leaving the most seasoned cousin to grumble a" +
            "t the injustice of it all.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage201_Fragment_1);
        using (styleScope("hook", "h000201"))
            yield return link("Click to continue...", null, () => enchantHook("h000201", HarloweEnchantCommand.Replace, passage201_Fragment_0));
        yield break;
    }

    IStoryThread passage201_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "InsanitySign";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "ScoreTrackMarker";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Starting with the player(s) in last place, each player gains 1VP for each other p" +
                "layer\'s piece that is ahead of them on the VP track. ");
            using (styleScope("italic", true))
            {
                yield return text("For example, if a player is in 3rd place, two other pieces are ahead and they wil" +
                "l gain 2VP.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "InsanitySign", null);
        yield break;
    }

    IStoryThread passage201_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage201_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: UniEquity1   (passage202)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23052-23108
// Links:  UniEvent1-UltimateDisease
// Aborts: -
// Purpose: Repeat equity assessment in a later round
// ###################################################################

    void passage202_Init()
    {
        this.Passages[@"UniEquity1"] = new StoryPassage(@"UniEquity1", new string[] { }, passage202_Main);
    }

    IStoryThread passage202_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Another Competitive Assessment");
        }
        yield return lineBreak();
        yield return text(@"The University insisted upon periodic inspections of the laboratories and experimental apparatus being used by interns apportioned from the student body. While each scientist affected a congenial appearance and made sure to conceal their more sinister workings during these assessments, they made no similar attempts to conceal their agitation afterwards.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("However, the pitiable honorariums provided to those family members with lesser re" +
            "putations continued.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage202_Fragment_1);
        using (styleScope("hook", "h000202"))
            yield return link("Click to continue...", null, () => enchantHook("h000202", HarloweEnchantCommand.Replace, passage202_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage202_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "UniEvent1-UltimateDisease";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "ScoreTrackMarker";
            yield return lineBreak();
            yield return text("Starting with the player(s) in last place, each player gains 1VP for each other p" +
                "layer\'s piece that is ahead of them on the VP track. ");
            using (styleScope("italic", true))
            {
                yield return text("For example, if a player is in 3rd place, two other pieces are ahead and they wil" +
                "l gain 2VP.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "UniEvent1-UltimateDisease", null);
        yield break;
    }

    IStoryThread passage202_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage202_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: UniEvent1-UltimateDisease   (passage203)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23113-23165
// Links:  UniCharity
// Aborts: -
// Purpose: Cousins resolve to create the ultimate disease
// ###################################################################

    void passage203_Init()
    {
        this.Passages[@"UniEvent1-UltimateDisease"] = new StoryPassage(@"UniEvent1-UltimateDisease", new string[] { }, passage203_Main);
    }

    IStoryThread passage203_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Ignored Amongst the Scientific Elite");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The ");
        yield return text(Vars.playtxt);
        yield return text(" ");
        yield return text(@"cousins watched with dour hearts as the once morose streets were festooned with bright spring colors. Educated middle-class families strolled along the sidewalks in modest clothing. Children laughed and rode bicycles in the park. They shuddered at the sight. It was all ");
        using (styleScope("bold", true))
        {
            yield return text("too good");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"With the initial festivities over, their estimation had soured in the eyes of the academics. Though they had not been spurned or mistreated, the once generous enthusiasm had waned from repeated ethical infractions, misuse of the medical operating theater, and radical outbursts during local symposiums. And to complicate matters further, it became increasingly obvious that due to the peaceful and progressive values of ");
        yield return text(Vars.townname);
        yield return text(", the educated were less troubled with matters of any immediate, existential, or " +
            "diabolical concern.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The solution to this lack of a problem was obvious. If the world refused to creat" +
            "e a new, horrific problem to solve, then they would defy nature and create it th" +
            "emselves. Surely, if they combined their efforts, they could create the ");
        using (styleScope("bold", true))
        {
            yield return text("ultimate disease");
        }
        yield return text("! A disease so infectious that they would forever undo this plague of positivity." +
            "");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("This would certainly ");
        using (styleScope("bold", true))
        {
            yield return text("rid them of this unfair and blatant balancing");
        }
        yield return text(" ");
        yield return text("of fortunes.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "UniCharity", null);
        yield break;
    }

// ###################################################################
// PASSAGE: UniEvent2-UltimateDisease   (passage204)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23171-23270
// Links:  UniEvent2-UltimateDisease2
// Aborts: -
// Purpose: Vote: contribute a Chemistry/Occult Experiment toward the disease
// ###################################################################

    void passage204_Init()
    {
        this.Passages[@"UniEvent2-UltimateDisease"] = new StoryPassage(@"UniEvent2-UltimateDisease", new string[] { }, passage204_Main);
    }

    IStoryThread passage204_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Ultimate Disease");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return text("As the oppressive sunshine illuminated the study of ");
        if (Vars.players == 2)
        {
            yield return text(macros1.either(Vars.nameA, Vars.nameB));
            yield return text(" ");
        }
        else if (Vars.players == 3)
        {
            yield return text(macros1.either(Vars.nameA, Vars.nameB, Vars.nameC));
            yield return text(" ");
        }
        else if (Vars.players == 4)
        {
            yield return text(macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD));
            yield return text(" ");
        }
        else if (Vars.players == 5)
        {
            yield return text(macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD, Vars.nameE));
            yield return text(" ");
        }
        else
        {
            yield return text(macros1.either(Vars.nameA, Vars.nameB));
            yield return text(" ");
        }
        yield return text(@"III, the cousins assembled to finalize their creation. With a large piece of parchment sprawled across the desk and delightful bean strudels with heavy cream for refreshment, the scientists began to formulate a blueprint using the knowledge they had gained from recent experimentations.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Some, however, were more forthcoming with information than others.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        yield return text(@"Players will now vote to collaborate with their knowledge to create a new disease. All players take their Voting token into their hand. Players will secretly choose a side to place face up in their palm. Then, they will close their fist and extend it to the center of the table.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Yay");
        }
        yield return text(" ");
        yield return text("vote is a vote to discard ");
        using (styleScope("bold", true))
        {
            yield return text("1 completed Chemistry or Occult Experiment");
        }
        yield return text(".");
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Nay");
        }
        yield return text(" ");
        yield return text("vote is a vote to NOT contribute an experiment.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("When all players have chosen, all players reveal their vote. Tally all votes and " +
            "the side with the most votes wins. ");
        using (styleScope("bold", true))
        {
            using (styleScope("italic", true))
            {
                yield return text("Ties are considered a win for the \"yay\" vote.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the vote.", "UniEvent2-UltimateDisease2", null);
        using (styleScope("hook", "h0000204"))
            yield return link("Click here to start the vote...", null, () => enchantHook("h0000204", HarloweEnchantCommand.None, passage204_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage204_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("UniEvent2-UltimateDisease2", BiddingSystem.Voting);
        yield break;
    }

// ###################################################################
// PASSAGE: UniEvent2-Success   (passage205)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23275-23361
// Links:  -
// Aborts: -
// Purpose: Disease released but accidentally inoculates the region
// ###################################################################

    void passage205_Init()
    {
        this.Passages[@"UniEvent2-Success"] = new StoryPassage(@"UniEvent2-Success", new string[] { }, passage205_Main);
    }

    IStoryThread passage205_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Wondrous Success");
        }
        yield return lineBreak();
        yield return text(@"Symptoms: Nausea, fever, vomiting, hypertension, drowsiness, loss of libido, skin lesions, blurred vision, heart palpitations, headache, weight-loss, chronic pain, demonic possession. The prospectus for the ultimate disease included nearly every side-effect known to science. The cousins spent the late-night hours laughing till their throats were hoarse as they concocted the elixir.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The following week, the disease was released at the Farmer\'s Market, a tincture o" +
            "f the foul liquid smashed against the steps. It proved communicable within secon" +
            "ds and the noxious gases spread from person-to-person with each dry cough.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"However, the effect was not altogether anticipated. This grim amalgamation of deadly diseases, while invoking minor symptoms in some initially exposed, caused antibodies to build up within the region, nullifying their effects and strengthening their systems against infection. By creating a disease that included all known symptoms, they had essentially inoculated the populace against all disease simultaneously.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It wasn't long before the university traced the source of the marvel to the cousins. Word soon traveled about their research, and the town applauded yet another triumph for science and the world! Clearly, this family of scientists needed no assistance in their heavenly endeavors.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage205_Fragment_2);
        using (styleScope("hook", "h000205"))
            yield return link("Click to continue...", null, () => enchantHook("h000205", HarloweEnchantCommand.Replace, passage205_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage205_Fragment_0()
    {
        yield return abort(goToPassage: "DetEffectRandom");
        yield break;
    }

    IStoryThread passage205_Fragment_1()
    {
        //yield return lineBreak();
        Vars.ultimate = "yes";
        ViewItemObtain.SetupPassagename = "DetEffectRandom";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Any player that voted to contribute discards a ");
            using (styleScope("bold", true))
            {
                yield return text("completed");
            }
            yield return text(" ");
            yield return text("Chemistry or Occult Experiment. Each player that contributed ");
            using (styleScope("bold", true))
            {
                yield return text("gains 2 resources");
            }
            yield return text(" ");
            yield return text("of their choice from the supply.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that did not contribute ");
            using (styleScope("bold", true))
            {
                yield return text("gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00167"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00167", HarloweEnchantCommand.Replace, passage205_Fragment_0));
        yield break;
    }

    IStoryThread passage205_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage205_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: UniEvent2-Failure   (passage206)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23366-23458
// Links:  DetEffectRandom
// Aborts: -
// Purpose: Collaboration collapses; lowest-research player advances; "yay" voters lose Creepy
// ###################################################################

    void passage206_Init()
    {
        this.Passages[@"UniEvent2-Failure"] = new StoryPassage(@"UniEvent2-Failure", new string[] { }, passage206_Main);
    }

    IStoryThread passage206_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Unfortunate Failure");
        }
        yield return lineBreak();
        yield return text(@"With the cousins guarding their knowledge and no consensus on how to move forward, the meeting soon devolved into bickering and one-upmanship. Each cousin pontificated at length their personal achievements and the unexpressed envy the others had towards their work. Many of the pastries were left half-eaten that night.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("As the science was unsuccessful, they each retired to their estates in the late e" +
            "vening to let the familial jibes fester in their minds.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The town remained unaffected by their exchange of harsh words. And as before, the" +
            "y continued to offer assistance to those who they felt were lacking the resource" +
            "s. What a pitiable learning opportunity.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage206_Fragment_1);
        using (styleScope("hook", "h000206"))
            yield return link("Click to continue...", null, () => enchantHook("h000206", HarloweEnchantCommand.Replace, passage206_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage206_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "DetEffectRandom";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Each player counts the total amount of levels they have gained on their Journal R" +
                "esearch Tracks. The ");
            if (Vars.players < 4)
            {
                yield return text("player with the lowest total ");
                using (styleScope("bold", true))
                {
                    yield return text("moves their research marker forward 1 level");
                }
            }
            if (Vars.players > 3)
            {
                using (styleScope("bold", true))
                {
                    yield return text("2");
                }
                yield return text(" players with the lowest total ");
                using (styleScope("bold", true))
                {
                    yield return text("move their research marker forward 1 level");
                }
            }
            yield return text(" ");
            yield return text("on the track of their choice at no cost. ");
            using (styleScope("italic", true))
            {
                yield return text("If there is a tie, ties are broken by the player with the least VP.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that voted \"yay\" to contribute does not discard an Experiment. But, th" +
                "ey ");
            using (styleScope("bold", true))
            {
                yield return text("lose 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "DetEffectRandom", null);
        yield break;
    }

    IStoryThread passage206_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage206_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: PanaceaUnleashCons2   (passage233)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25789-25843
// Links:  University1
// Aborts: -
// Purpose: Same "Whispers Abate" servant recovery on the University path; leads to University1
// ###################################################################

    void passage233_Init()
    {
        this.Passages[@"PanaceaUnleashCons2"] = new StoryPassage(@"PanaceaUnleashCons2", new string[] { }, passage233_Main);
    }

    IStoryThread passage233_Main()
    {
        if (Vars.pana == "unleash")
        {
            using (styleScope("bold", true))
            {
                yield return text("Whispers Abate");
            }
            yield return lineBreak();
            yield return text(@"With the passing of the generation, the hideous and well-founded rumors regarding the grisly demise and otherwise negative treatment of servants within the family's households faded into history. As considerably misguided as it would have been, the allure of steady employ once again attracted new applicants to their estates.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage233_Fragment_1);
            using (styleScope("hook", "h000233"))
                yield return link("Click to continue...", null, () => enchantHook("h000233", HarloweEnchantCommand.Replace, passage233_Fragment_0));
        }
        else
        {
            yield return abort(goToPassage: "University1");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "University1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage233_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "University1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Servant";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any players with a Servant in the game box may retrieve it from the box and place" +
                " it in Lost.");
        }
        yield break;
    }

    IStoryThread passage233_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage233_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: University1   (passage257)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 27567-27695
// Links:  UniEquity1
// Aborts: -
// Round end -> UniEquity1
// Purpose: "Search for the Cure - Early Years" HUB: setup, Nobel penalty, Perfect Mental Balance
// ###################################################################

    void passage257_Init()
    {
        this.Passages[@"University1"] = new StoryPassage(@"University1", new string[] { "HUB", }, passage257_Main);
    }

    IStoryThread passage257_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("SEARCH FOR THE CURE - Early Years");
        }
        yield return lineBreak();
        Vars.round = 19;
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "AngryMobSetup1";
            yield return lineBreak();
            yield return text("Turn to page ");
            using (styleScope("bold", true))
            {
                yield return text("10");
            }
            yield return text(" ");
            yield return text("of the Village Chronicle.");
            yield return lineBreak();
            yield return text("Place the Suspicion Marker on space ");
            using (styleScope("bold", true))
            {
                if (Vars.University1 == 0 || Vars.University1 == "")
                {
                    Vars.University1 = 1;
                    Vars.tracker = int.Parse(Vars.tracker) + 2;
                    if (Vars.players == 4)
                    {
                        Vars.tracker = int.Parse(Vars.tracker) + 1;
                    }
                    if (Vars.players == 5)
                    {
                        Vars.tracker = int.Parse(Vars.tracker) + 1;
                    }
                }
                yield return text(Vars.tracker);
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
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Nobel Prize in Medicine");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("The scientific world has finally taken notice of ");
            yield return text(Vars.townname);
            yield return text(" ");
            yield return text("and its ");
            yield return text(Vars.playtxt);
            yield return text(" ");
            yield return text("ingenious scholars. The absurdity of it all! Not only does this hamper their abil" +
                "ity to experiment freely, it also gives their work mainstream merit.");

            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the End of the Generation, the ");
            using (styleScope("bold", true))
            {
                yield return text("least ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("player will be awarded this prestigious award and ");
            using (styleScope("bold", true))
            {
                yield return text("lose 7VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Perfect Mental Balance");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of the Generation, if your piece is on space ");
            yield return text(Vars.mental);
            yield return text(" ");
            yield return text("of the ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track, you will ");
            using (styleScope("bold", true))
            {
                yield return text("gain 5VP");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click to continue...", "UniEquity1", null);
            using (styleScope("hook", "h0000258"))
                yield return link("Click here at the end of the round to move to the next round...", null, () => enchantHook("h0000258", HarloweEnchantCommand.Replace, passage258_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: InsanitySign   (passage315)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32332-32425
// Links:  -
// Aborts: -
// Purpose: University consults the family; select the player with the least VP
// ###################################################################

    void passage315_Init()
    {
        this.Passages[@"InsanitySign"] = new StoryPassage(@"InsanitySign", new string[] { }, passage315_Main);
    }

    IStoryThread passage315_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Another Opportunity");
        }
        yield return lineBreak();
        yield return text("Along with a newfound sense of acceptance and encouragement for the works of the " +
            "young cousins, the university also consulted with the family on emerging matters" +
            " of progressive importance.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Please choose the player with the least VP:");
        }
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("(ties are broken by the player that went later in turn order on the previous roun" +
            "d.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00198"))
            yield return link(Vars.nameA, null, () => enchantHook("h00198", HarloweEnchantCommand.Replace, passage315_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00199"))
            yield return link(Vars.nameB, null, () => enchantHook("h00199", HarloweEnchantCommand.Replace, passage315_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00200"))
                yield return link(Vars.nameC, null, () => enchantHook("h00200", HarloweEnchantCommand.Replace, passage315_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00201"))
                yield return link(Vars.nameD, null, () => enchantHook("h00201", HarloweEnchantCommand.Replace, passage315_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00202"))
                yield return link(Vars.nameE, null, () => enchantHook("h00202", HarloweEnchantCommand.Replace, passage315_Fragment_4));
            yield return lineBreak();
        }
        yield break;
    }

    IStoryThread passage315_Fragment_0()
    {
        Vars.saneplayer = Vars.nameA;
        yield return abort(goToPassage: "SanityChoice");
        yield break;
    }

    IStoryThread passage315_Fragment_1()
    {
        Vars.saneplayer = Vars.nameB;
        yield return abort(goToPassage: "SanityChoice");
        yield break;
    }

    IStoryThread passage315_Fragment_2()
    {
        Vars.saneplayer = Vars.nameC;
        yield return abort(goToPassage: "SanityChoice");
        yield break;
    }

    IStoryThread passage315_Fragment_3()
    {
        Vars.saneplayer = Vars.nameD;
        yield return abort(goToPassage: "SanityChoice");
        yield break;
    }

    IStoryThread passage315_Fragment_4()
    {
        Vars.saneplayer = Vars.nameE;
        yield return abort(goToPassage: "SanityChoice");
        yield break;
    }

// ###################################################################
// PASSAGE: UniEvent2-UltimateDisease2   (passage348)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34514-34549
// Links:  UniEvent2-Success,UniEvent2-Failure
// Aborts: -
// Purpose: Tallies the ultimate-disease vote; branches Success/Failure
// ###################################################################

    void passage348_Init()
    {
        this.Passages[@"UniEvent2-UltimateDisease2"] = new StoryPassage(@"UniEvent2-UltimateDisease2", new string[] { }, passage348_Main);
    }

    IStoryThread passage348_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("VOTE OUTCOME");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Tally all votes and the side with the most votes wins. ");
        using (styleScope("bold", true))
        {
            using (styleScope("italic", true))
            {
                yield return text("Ties are considered a win for the \"yay\" vote.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Click on the result of your vote:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Yay. Unleash the Disease!", "UniEvent2-Success", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Nay. The Disease is not created.", "UniEvent2-Failure", null);
        yield return lineBreak();
        yield break;
    }
