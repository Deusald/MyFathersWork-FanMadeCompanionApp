// ===================================================================
// CHAPTER: Gen1-Fever   (28 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage2     Fever1                       L1613-1812 [HUB]  Round-1 HUB "YELLOW FEVER - Early Years": setup, Build-a-Hospital church donation, Creepy/Sanity track triggers
// passage5     Scenario5Start               L2238-2284  Generation I prose intro: the heirs arrive in the fever-stricken village
// passage6     S5Special1                   L2290-2341  Mayoral election event; new mayor gains 3VP and chooses Bank or Library
// passage7     S5SpecialSetup1              L2347-2472  Mayor setup: awards 3VP + Mayoral Coin, presents Bank vs Library choice
// passage8     S5Fate1                      L2477-2534  End-of-Gen1 fate: Bank/Library choice decides hospital funding; branches to Gen2 intro
// passage9     S5Fate2                      L2540-2631  End-of-Gen1 fate: Heart-token charity totals decide hospital built/not; branches to Gen2 intro
// passage28    Feverheart                   L3745-3851  End-of-Gen1 Heart-token count; 5VP to the most charitable player(s)
// passage360   FeverHeart2                  L3856-3940  "Charity Awarded": resolves who keeps the Heart token based on charity tokens
// passage29    Fever2                       L3946-4080 [HUB]  Round-2 HUB "YELLOW FEVER - Middle Years"
// passage30    Fever3                       L4085-4301 [HUB]  Round-3 HUB "YELLOW FEVER - Late Years"; adds the new Bank or Library benefits
// passage43    Gen1Church                   L5900-5929  Reference popup: Gen1 Charitable Church action ($0/1/2 for Heart tokens + Creepy reduction)
// passage55    4Note                        L6777-6872  DEV NOTE: Gen1 Creepy-4 / Sanity-3 trigger branches, mayor/charity consequences
// passage65    S5Special1b                  L7801-7899  Resolves the mayoral bid and tiebreak; asks who became Mayor
// passage66    FeverServe1                  L7904-7964  "Fortuitous Assistance": each player pays $1 to gain a Servant
// passage67    FeverServe2                  L7969-8026  "Daughters Entrusted": each player gains a Servant free
// passage68    Dubious                      L8031-8112  "Dubious Bartering" opening setup; deals each player a card
// passage81    S5Special1a                  L9259-9311  "A Bid for Mayor": simultaneous secret money bid for the mayoralty
// passage82    ReminderroundEnd             L9317-9361  End-of-round reminder + serves the first Gen1 servant event
// passage177   Gen1-CreepyTrack             L20926-21019  "Enemy of the People": who reached space 4 on the Creepy track
// passage178   Gen1-SanityTrack             L21024-21117  "To Quell the Mind": who reached space 3 on the Insanity track
// passage179   Gen1-CreepyTrackRes          L21122-21233  Private secret-society offer to fund the Creepy scientist's estate for $2 vs a future debt
// passage180   Gen1-SanityTrackRes          L21238-21315  Private letter offering the Insane scientist a Rovinj retreat, or refuse
// passage254   SpecialGen1                  L27360-27421  Gen1 setup: Storybook tokens on Insanity space 3 and Creepy space 4
// passage256   1sttime-Suspicion            L27491-27561  First-time rules explanation of the Suspicion Marker and Angry Mob limit
// passage296   Gen1CreepyYes                L30450-30586  Gen1 Creepy track ACCEPT: gain $2 or a free Perform an Experiment action
// passage297   Gen1CreepyNo                 L30591-30684  Gen1 Creepy track REFUSE: lose 1 resource; return to Fever1/2/3
// passage298   Gen1SanityYes                L30689-30786  Gen1 Sanity track ACCEPT: pay $1 for Knowledge (more via discarding a Compulsion)
// passage299   Gen1SanityNo                 L30791-30885  Gen1 Sanity track REFUSE: gain $1 and a resource
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   Fever1               --end of round-->  FeverServe1
//   Fever2               --end of round-->  S5Special1
//   Fever3               --end of round-->  Feverheart
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: Fever1   (passage2)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 1613-1812
// Links:  Gen1-CreepyTrack,Gen1-SanityTrack,ReminderroundEnd
// Aborts: -
// Round end -> FeverServe1
// Purpose: Round-1 HUB "YELLOW FEVER - Early Years": setup, Build-a-Hospital church donation, Creepy/Sanity track triggers
// ###################################################################

    void passage2_Init()
    {
        this.Passages[@"Fever1"] = new StoryPassage(@"Fever1", new string[] { "HUB", }, passage2_Main);
    }

    IStoryThread passage2_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("YELLOW FEVER - Early Years");
        }
        yield return lineBreak();
        Vars.round = 1;
        yield return lineBreak();
        if (Vars.tcodgen1 == 0 || Vars.tcodgen1 == "")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "StartPlayerToken";
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Turn to ");
                using (styleScope("bold", true))
                {
                    yield return text("The Cost of Disease");
                }
                yield return text(" ");
                yield return text("section of the Village Chronicle. Then, turn to ");
                using (styleScope("bold", true))
                {
                    yield return text("page 1");
                }
                yield return text(" ");
                using (styleScope("italic", true))
                {
                    yield return text("(this is noted by the matching The Cost of Disease symbol:");
                }
                yield return text(" ");
                yield return text("<sprite=\"S1_ScenarioIcon\" index=0>");
                yield return text("). ");
                yield return lineBreak();
                yield return text("Retrieve the ");
                yield return text("<sprite=\"S1_HeartToken\" index=0>");
                yield return text(" ");
                yield return text("tokens from the Scenario box and keep them in a supply near the board.");
                yield return lineBreak();
                yield return text("Give the ");
                using (styleScope("bold", true))
                {
                    yield return text("Start Player");
                }
                yield return text(" ");
                yield return text("marker to ");
                using (styleScope("bold", true))
                {
                    if (Vars.players == 2)
                    {
                        yield return text(macros1.either(Vars.nameA, Vars.nameB));
                    }
                    if (Vars.players == 3)
                    {
                        yield return text(macros1.either(Vars.nameA, Vars.nameB, Vars.nameC));
                    }
                    if (Vars.players == 4)
                    {
                        yield return text(macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD));
                    }
                    if (Vars.players == 5)
                    {
                        yield return text(macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD, Vars.nameE));
                    }
                    yield return text(".");
                }
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("BUILD A HOSPITAL");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text(@"The church can no longer handle the influx of the diseased and needs to expand their facilities. Each time a player visits the church, they may donate funds and assistance towards building a new Hospital by paying money to the supply. Depending on the amount spent ($0, $1, or $2), the player will receive 1, 2, or 3 ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("and lose 1, 2, or 3 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(". ");
            using (styleScope("italic", true))
            {
                yield return text("You do not pay extra ($) for placing a piece if another player has already placed at the church.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the end of the Generation, the player with the most ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("tokens will gain ");
            using (styleScope("bold", true))
            {
                yield return text("5VP.");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("If there is a tie, all tied players gain 5VP each.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.creepy4 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Attracting Attention");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches the ");
                using (styleScope("bold", true))
                {
                    yield return text("4th");
                }
                yield return text(" space on the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" Track, ");
                yield return link("click here", "Gen1-CreepyTrack", null);
            }
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.sane3 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Mark of Genius");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches the ");
                using (styleScope("bold", true))
                {
                    yield return text("3rd");
                }
                yield return text(" space on the ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(" Track, ");
                yield return link("click here.", "Gen1-SanityTrack", null);
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Second round Event - Election Season");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("Political pandering may require more than simply a silver tongue and a bright smi" +
            "le. Be sure to have some extra capital on hand as the need may arise.");

            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here to continue to the next round...", "ReminderroundEnd", null);
            using (styleScope("hook", "h0002"))
                yield return link("Click here to continue to the next round...", null, () => enchantHook("h0002", HarloweEnchantCommand.Replace, passage2_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage2_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Fever1", "FeverServe1");
        yield break;
    }

// ###################################################################
// PASSAGE: Scenario5Start   (passage5)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 2238-2284
// Links:  Dubious
// Aborts: -
// Purpose: Generation I prose intro: the heirs arrive in the fever-stricken village
// ###################################################################

    void passage5_Init()
    {
        this.Passages[@"Scenario5Start"] = new StoryPassage(@"Scenario5Start", new string[] { "INTRO", }, passage5_Main);
    }

    IStoryThread passage5_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION I:");
            yield return lineBreak();
            yield return text("Yellow Fever");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The siblings' arrival to claim their considerable inheritance was met with the indifference of a murky countryside, gray and overcast. The sky was heavy with moisture, but could not crack into a tempest, as if heralding the unfortunate circumstances to which they would soon find themselves.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Upon reaching the village, a foul stench tinged the air as teams of horses pulled the charcoal wagons like a silent funeral procession through the muddy streets. Emaciated peasants shielded their faces from the ashen gloom, seemingly unbothered by the display, and went about their somber activities uninterrupted. Several canvas-bound carts lined the edges of the main road, the dismal, gray skin of a human foot sometimes dangling freely from a rip in the fabric.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The Yellow Fever had struck the village, and for several weeks any visit to its somber limits forced the young heirs to keep a cloth handkerchief about their mouth and nostrils to protect from the miasma. While they were remiss to admit it, this seemed the perfect macabre backdrop in which to advance their father's dreadful business.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"While the prevailing mood in the village was one of morose caution, the young entrepreneurs saw potential in these darkened streets. A particularly ambitious individual could lift this gray village into a thriving city. Perhaps even an aristocrat with coin to spare could make a persuasive argument as to its direction.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"As the kindred surveyed the dreary countryside from behind the iron gates of their estate, they watched the billowing mists move slowly across the valley. The townsfolk stirred as a disquieting laugh echoed down from the hillside. They were excited to begin their father's work in earnest!");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "Dubious", null);
        yield return lineBreak();
        Vars.wolves = macros1.either("evil", "good");
        if (Vars.wolves == "good")
        {
            Vars.hunters = "evil";
        }
        //if (Vars.wolves == "evil")
        else
        {
            Vars.hunters = "good";
        }
        Vars.tcodgen1 = 0;
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5Special1   (passage6)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 2290-2341
// Links:  S5Special1a
// Aborts: -
// Purpose: Mayoral election event; new mayor gains 3VP and chooses Bank or Library
// ###################################################################

    void passage6_Init()
    {
        this.Passages[@"S5Special1"] = new StoryPassage(@"S5Special1", new string[] { }, passage6_Main);
    }

    IStoryThread passage6_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Town Is in Need of Direction");
        }
        yield return text("Before resolving this event, all players should complete all start of round actio" +
            "ns.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"After the untimely death of the current mayor (and the previous three), the town was once again embroiled in politics. While several mediocre businessmen had thrown their hats into the arena, the family sensed a restlessness in the small village as they searched for direction forward. Having been raised with an affinity for friendly competition, it was decided that governance would be a droll leisure activity for the family. They decided to use their influence to sway the election in their favor.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("This was especially pressing as the new mayor would immediately ");
        using (styleScope("bold", true))
        {
            yield return text("gain 3VP");
        }
        yield return text(" ");
        yield return text("and then make the decision as to whether to build a ");
        using (styleScope("bold", true))
        {
            yield return text("Bank");
        }
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("(to obtain additional income)");
        }
        yield return text(", or to build a ");
        using (styleScope("bold", true))
        {
            yield return text("Library");
        }
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("(to obtain additional knowledge)");
        }
        yield return text(".");
        yield return lineBreak();
        Vars.tcodgen1 = 0;
        yield return lineBreak();
        yield return link("Click to continue...", "S5Special1a", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5SpecialSetup1   (passage7)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 2347-2472
// Links:  -
// Aborts: -
// Purpose: Mayor setup: awards 3VP + Mayoral Coin, presents Bank vs Library choice
// ###################################################################

    void passage7_Init()
    {
        this.Passages[@"S5SpecialSetup1"] = new StoryPassage(@"S5SpecialSetup1", new string[] { }, passage7_Main);
    }

    IStoryThread passage7_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Direction of the Town");
        }
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "S1_MayorCoin";
            yield return lineBreak();
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("receives ");
            using (styleScope("bold", true))
            {
                yield return text("3VP");
            }
            yield return text(" ");
            yield return text("immediately. Then, they receive the ");
            using (styleScope("bold", true))
            {
                yield return text("Commemorative Mayoral Coin");
            }
            yield return text(" ");
            yield return text("from the box. And finally, they will choose if they would like to build a Bank or" +
                " a Library.");
        }
        yield return lineBreak();
        yield return text("<line-height=400%>");
        yield return text("</line-height>");
        yield return lineBreak();
        yield return text("<align=\"center\">");
        yield return text("<line-height=400%>");
        yield return text("<size=200>");
        yield return text("<sprite=\"Bank1\" index=0>");
        yield return text("</size>");
        yield return text("</line-height>");
        yield return text("</align>");
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("BANK");
        }
        yield return lineBreak();
        yield return text("For each visit to the Bank, ");
        using (styleScope("bold", true))
        {
            yield return text("gain $2.");
        }
        yield return text(" ");
        yield return text("The Mayor player will also ");
        using (styleScope("bold", true))
        {
            yield return text("immediately gain 1VP");
        }
        yield return text(" ");
        yield return text("for building the Bank.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<line-height=400%>");
        yield return lineBreak();
        yield return text("</line-height>");
        yield return text("<align=\"center\">");
        yield return text("<line-height=400%>");
        yield return text("<size=200>");
        yield return text("<sprite=\"Library1\" index=0>");
        yield return text("</size>");
        yield return text("</line-height>");
        yield return text("</align>");
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("LIBRARY");
        }
        yield return lineBreak();
        yield return text("For each visit to the Library, ");
        using (styleScope("bold", true))
        {
            yield return text("gain one Knowledge of your choice");
        }
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("(not Occult).");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Which building would the new Mayor like to Build?");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00001"))
            yield return link("Bank.", null, () => enchantHook("h00001", HarloweEnchantCommand.Replace, passage7_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00002"))
            yield return link("Library.", null, () => enchantHook("h00002", HarloweEnchantCommand.Replace, passage7_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage7_Fragment_0()
    {
        Vars.building = "bank";
        yield return abort(goToPassage: "FeverServe2");
        yield break;
    }

    IStoryThread passage7_Fragment_1()
    {
        Vars.building = "library";
        yield return abort(goToPassage: "FeverServe2");
        yield break;
    }

// ###################################################################
// PASSAGE: S5Fate1   (passage8)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 2477-2534
// Links:  Hospitalintro,DevastationIntro
// Aborts: -
// Purpose: End-of-Gen1 fate: Bank/Library choice decides hospital funding; branches to Gen2 intro
// ###################################################################

    void passage8_Init()
    {
        this.Passages[@"S5Fate1"] = new StoryPassage(@"S5Fate1", new string[] { "END", }, passage8_Main);
    }

    IStoryThread passage8_Main()
    {

        using (styleScope("bold", true))
        {
            yield return text("Financial Woes");
        }
        yield return lineBreak();
        string s = "Remove all player pieces from the board and Perform the End of a Generation. Return all <b>Dubious Bartering</b> cards to the box. Return any remaining <sprite=\"StorybookToken\" index=0> tokens to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 3);
        //yield return text("Remove all player pieces from the board and Perform the End of a Generation. Retu" +
        //    "rn all ");
        //yield return text(" ");
        //yield return text("cards to the box. Return any remaining ");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The village of ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text(@"was, for lack of a more appropriate term, agricultural in its funds and like many similar small villages, were woefully unprepared for the ravages of disease. Despite the generosity (or lack thereof) of the family, the church's already severely limited resources have been stretched to their limit in their distinctly unscientific attempts to stem the spread of infection. With no more donations to call upon, the diocese turned to the local financial institutions for aide.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.building == "bank")
        {
            yield return text("With additional financial capital from the ");
            using (styleScope("bold", true))
            {
                yield return text("Bank");
            }
            yield return text(", the church obtained the funds needed to build a Hospital. ");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "Hospitalintro", null);
        }
        //if (Vars.building == "library")
        else
        {
            yield return text("The addition of a ");
            using (styleScope("bold", true))
            {
                yield return text("Library");
            }
            yield return text(@" to the already strained finances of the village proved insurmountable, and the church failed to build a Hospital. Perhaps the lifestyle of an aristocrat blinded the mayor to this reality, but it was certain that the village would progress down a darker path.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "DevastationIntro", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5Fate2   (passage9)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 2540-2631
// Links:  Hospitalintro,DevastationIntro
// Aborts: -
// Purpose: End-of-Gen1 fate: Heart-token charity totals decide hospital built/not; branches to Gen2 intro
// ###################################################################

    void passage9_Init()
    {
        this.Passages[@"S5Fate2"] = new StoryPassage(@"S5Fate2", new string[] { "END", }, passage9_Main);
    }

    IStoryThread passage9_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("FATE of the Infected");
        }
        yield return lineBreak();
        //yield return text("Remove all player pieces from the board and Perform the End of a Generation. Retu" +
        //    "rn all ");
        //yield return text(" ");
        //yield return text("cards to the box. Return any remaining ");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens to the supply.");
        string s = "Remove all player pieces from the board and Perform the End of a Generation. Return all <b>Dubious Bartering</b> cards to the box. Return any remaining <sprite=\"StorybookToken\" index=0> tokens to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 3);
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players == 2)
        {
            Vars.heart = 3;
        }
        else if (Vars.players == 3)
        {
            Vars.heart = 6;
        }
        else if (Vars.players == 4)
        {
            Vars.heart = 8;
        }
        else if (Vars.players == 5)
        {
            Vars.heart = 10;
        }
        else
        {
            Vars.heart = 3;
        }
        Vars.hearttotal = macros1.random(1, 6) + Vars.heart;
        yield return lineBreak();
        yield return text("The congregation and citizenry, stricken with the weight of those lost in the bat" +
            "tle with Yellow Fever, could only provide a meager sum, which placed the financi" +
            "al future of the village into the hands of the most charitable scientists.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.charitytotal > Vars.hearttotal)
        {
            using (styleScope("bold", true))
            {
                yield return text("SUCCESS!");
            }
            yield return lineBreak();
            yield return text("With charitable contributions totaling over ");
            using (styleScope("bold", true))
            {
                yield return text(Vars.hearttotal);
            }
            yield return text(" <sprite=\"S1_HeartToken\" index=0>");
            yield return text(", the Hospital was built. The additional medical infrastructure provided the town" +
            " a respite from another severe outbreak and ushered in a new era.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Succeeded in Building the Hospital", "Hospitalintro", null);
        }
        //if (Vars.charitytotal <= Vars.hearttotal)
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("FAILURE!");
            }
            yield return lineBreak();
            yield return text("With charitable contributions failing to exceed ");
            using (styleScope("bold", true))
            {
                yield return text(Vars.hearttotal);
            }
            yield return text(" <sprite=\"S1_HeartToken\" index=0>");
            yield return text(", the Hospital was not built. This ill-timed news was delivered just as several n" +
            "ew cases of influenza spread across the region. Without the Hospital, the result" +
            "s were drastic.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Failed to Build the Hospital", "DevastationIntro", null);
        }
        yield break;
    }

// ###################################################################
// PASSAGE: Feverheart   (passage28)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3745-3851
// Links:  FeverHeart2
// Aborts: -
// Purpose: End-of-Gen1 Heart-token count; 5VP to the most charitable player(s)
// ###################################################################

    void passage28_Init()
    {
        this.Passages[@"Feverheart"] = new StoryPassage(@"Feverheart", new string[] { }, passage28_Main);
    }

    IStoryThread passage28_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Legacy of Charity");
        }
        //Vars.charitytotal = ("rompt: Count up all the Heart tokens collected by ALL players. Please enter the t" +
        //    "otal number here.");
        if (ViewPopupPanel.instance.PassageValueNumber() >= 0)
        {
            Vars.charitytotal = ViewPopupPanel.instance.PassageValueNumber();
            ViewPopupPanel.instance.valueNumber = -1;
            ViewPopupPanel.instance.Clear();
        }
        else
        {
            ViewPopupPanel.instance.OnGenerationBtn("Feverheart", "Count up all the heart tokens collected by ALL players. Please enter the total number here.", "number", 1f);
        }
        yield return lineBreak();
        Vars.charitytotal = macros1.num(Vars.charitytotal);
        yield return lineBreak();
        yield return text("Now count up the ");
        yield return text("<sprite=\"S1_HeartToken\" index=0>");
        yield return text(" ");
        yield return text("tokens collected by each indivdual player. The player(s) with the most ");
        yield return text("<sprite=\"S1_HeartToken\" index=0>");
        yield return text(" ");
        yield return text("tokens gains ");
        using (styleScope("bold", true))
        {
            yield return text("5VP");
        }
        yield return text(". ");
        using (styleScope("italic", true))
        {
            yield return text("(All tied players gain this bonus.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "FeverHeart2", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage28_Fragment_0()
    {
        Vars.charity = Vars.nameA;
        if (Vars.feverheartnextPsg == "" || Vars.feverheartnextPsg == 0)
        {
            Vars.feverheartnextPsg = macros1.either("S5Fate1", "S5Fate2");
        }
        yield return abort(goToPassage: Vars.feverheartnextPsg);
        yield break;
    }

    IStoryThread passage28_Fragment_1()
    {
        Vars.charity = Vars.nameB;
        //yield return abort(goToPassage: macros1.either("S5Fate1", "S5Fate2"));
        if (Vars.feverheartnextPsg == "" || Vars.feverheartnextPsg == 0)
        {
            Vars.feverheartnextPsg = macros1.either("S5Fate1", "S5Fate2");
        }
        yield return abort(goToPassage: Vars.feverheartnextPsg);
        yield break;
    }

    IStoryThread passage28_Fragment_2()
    {
        Vars.charity = Vars.nameC;
        //yield return abort(goToPassage: macros1.either("S5Fate1", "S5Fate2"));
        if (Vars.feverheartnextPsg == "" || Vars.feverheartnextPsg == 0)
        {
            Vars.feverheartnextPsg = macros1.either("S5Fate1", "S5Fate2");
        }
        yield return abort(goToPassage: Vars.feverheartnextPsg);
        yield break;
    }

    IStoryThread passage28_Fragment_3()
    {
        Vars.charity = Vars.nameD;
        if (Vars.feverheartnextPsg == "" || Vars.feverheartnextPsg == 0)
        {
            Vars.feverheartnextPsg = macros1.either("S5Fate1", "S5Fate2");
        }
        yield return abort(goToPassage: Vars.feverheartnextPsg);
        //yield return abort(goToPassage: macros1.either("S5Fate1", "S5Fate2"));
        yield break;
    }

    IStoryThread passage28_Fragment_4()
    {
        Vars.charity = Vars.nameE;
        if (Vars.feverheartnextPsg == "" || Vars.feverheartnextPsg == 0)
        {
            Vars.feverheartnextPsg = macros1.either("S5Fate1", "S5Fate2");
        }
        yield return abort(goToPassage: Vars.feverheartnextPsg);
        //yield return abort(goToPassage: macros1.either("S5Fate1", "S5Fate2"));
        yield break;
    }

// ###################################################################
// PASSAGE: FeverHeart2   (passage360)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3856-3940
// Links:  -
// Aborts: -
// Purpose: "Charity Awarded": resolves who keeps the Heart token based on charity tokens
// ###################################################################

    void passage360_Init()
    {
        this.Passages[@"FeverHeart2"] = new StoryPassage(@"FeverHeart2", new string[] { }, passage360_Main);
    }

    IStoryThread passage360_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Charity Awarded");
        }
        yield return lineBreak();
        using (styleScope("setupStyle", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_HeartToken";
            yield return text("The player with the most ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" tokens will keep ");
            using (styleScope("bold", true))
            {
                yield return text("1 ");
                yield return text("<sprite=\"S1_HeartToken\" index=0>");
            }
            yield return text(" in their Quarters and return all other tokens to the box. All other players retur" +
                "n ");
            using (styleScope("bold", true))
            {
                yield return text("all");
            }
            yield return text(" of their ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" tokens to the box. ");
            using (styleScope("italic", true))
            {
                yield return text("If there is a tie, the player ");
                using (styleScope("bold", true))
                {
                    yield return text("later in turn order");
                }
                yield return text(" this round receives the ");
                yield return text("<sprite=\"S1_HeartToken\" index=0>");
                yield return text(" token.");
            }
        }
        yield return lineBreak();
        yield return text("The player with the ");
        yield return text("<sprite=\"S1_HeartToken\" index=0>");
        yield return text(" ");
        yield return text("Token is:");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00007"))
            yield return link(Vars.nameA, null, () => enchantHook("h00007", HarloweEnchantCommand.Replace, passage28_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00008"))
            yield return link(Vars.nameB, null, () => enchantHook("h00008", HarloweEnchantCommand.Replace, passage28_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00009"))
                yield return link(Vars.nameC, null, () => enchantHook("h00009", HarloweEnchantCommand.Replace, passage28_Fragment_2));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00010"))
                yield return link(Vars.nameD, null, () => enchantHook("h00010", HarloweEnchantCommand.Replace, passage28_Fragment_3));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00011"))
                yield return link(Vars.nameE, null, () => enchantHook("h00011", HarloweEnchantCommand.Replace, passage28_Fragment_4));
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Fever2   (passage29)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 3946-4080
// Links:  Gen1-CreepyTrack,Gen1-SanityTrack,S5Special1
// Aborts: -
// Round end -> S5Special1
// Purpose: Round-2 HUB "YELLOW FEVER - Middle Years"
// ###################################################################

    void passage29_Init()
    {
        this.Passages[@"Fever2"] = new StoryPassage(@"Fever2", new string[] { "HUB", }, passage29_Main);
    }

    IStoryThread passage29_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("YELLOW FEVER - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 2;
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("BUILD A HOSPITAL");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text(@"The church can no longer handle the influx of the diseased and needs to expand their facilities. Each time a player visits the church, they may donate funds and assistance towards building a new Hospital by paying money to the supply. Depending on the amount spent ($0, $1, or $2), the player will receive 1, 2, or 3 ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("and lose 1, 2, or 3 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(". ");
            using (styleScope("italic", true))
            {
                yield return text("You do not pay extra ($) for placing a piece if another player has already placed" +
                " at the church.");
            }

            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the end of the Generation, the player with the most ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("tokens will gain ");
            using (styleScope("bold", true))
            {
                yield return text("5VP.");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("If there is a tie, all tied players gain 5VP.");
            }
        }
        yield return lineBreak();
        Vars._icon = "storybooktoken";
        yield return lineBreak();
        if (Vars.creepy4 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Attracting Attention");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches the ");
                using (styleScope("bold", true))
                {
                    yield return text("4th");
                }
                yield return text(" space on the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" Track, ");
                yield return link("click here", "Gen1-CreepyTrack", null);
            }
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.sane3 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Mark of Genius");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches the ");
                using (styleScope("bold", true))
                {
                    yield return text("3rd");
                }
                yield return text(" space on the ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(" Track, ");
                yield return link("click here.", "Gen1-SanityTrack", null);
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Second round Event - Election Season");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("Political pandering may require more than simply a silver tongue and a bright smi" +
            "le. Be sure to have some extra capital on hand as the need may arise.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round for a special event.", "S5Special1", null);
            using (styleScope("hook", "h000029"))
                yield return link("Click here at the end of the round for a special event.", null, () => enchantHook("h000029", HarloweEnchantCommand.Replace, passage29_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage29_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Fever2", "S5Special1");
        yield break;
    }

// ###################################################################
// PASSAGE: Fever3   (passage30)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 4085-4301
// Links:  Gen1-CreepyTrack,Gen1-SanityTrack,Feverheart
// Aborts: -
// Round end -> Feverheart
// Purpose: Round-3 HUB "YELLOW FEVER - Late Years"; adds the new Bank or Library benefits
// ###################################################################

    void passage30_Init()
    {
        this.Passages[@"Fever3"] = new StoryPassage(@"Fever3", new string[] { "HUB", }, passage30_Main);
    }

    IStoryThread passage30_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("YELLOW FEVER - Late Years");
        }
        yield return lineBreak();
        Vars.round = 3;
        yield return lineBreak();
        if (Vars.tcodgen1 == 0 || Vars.tcodgen1 == "")
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
                if (Vars.building == "bank")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("2");
                    }
                }
                //if (Vars.building == "library")
                else
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("3");
                    }
                }
                yield return text(" ");
                yield return text("of the Village Chronicle.");
                yield return lineBreak();
                yield return lineBreak();
                if (Vars.building == "bank")
                {
                    yield return text(Vars.mayor);
                    yield return text(" gains 1VP.");
                }
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.building == "bank")
        {
            using (styleScope("hubTitle", true))
            {

                //yield return text("_item: bank");
                using (styleScope("bold", true))
                {
                    yield return text("BANK");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("A new Bank has been built in town. For each visit to the Bank, ");
                using (styleScope("bold", true))
                {
                    yield return text("gain $2.");
                }
            }
        }
        //if (Vars.building == "library")
        else
        {
            //yield return text("_item: library");
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("LIBRARY");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("A new Library has been built in town. For each visit to the Library, ");
                using (styleScope("bold", true))
                {
                    yield return text("gain one Knowledge of your choice ");
                }
                using (styleScope("italic", true))
                {
                    yield return text("(not Occult).");
                }
                yield return text(" You will also gain 1 <sprite=\"Creepy_Icon\" index=0>.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("BUILD A HOSPITAL");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text(@"The church can no longer handle the influx of the diseased and needs to expand their facilities. Each time a player visits the church, they may donate funds and assistance towards building a new Hospital by paying money to the supply. Depending on the amount spent ($0, $1, or $2), the player will receive 1, 2, or 3 ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("and lose 1, 2, or 3 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(". ");
            using (styleScope("italic", true))
            {
                yield return text("You do not pay extra ($) for placing a piece if another player has already placed" +
                " at the church.");
            }

            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the end of the Generation, the player with the most ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("tokens will gain ");
            using (styleScope("bold", true))
            {
                yield return text("5VP.");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("If there is a tie, all tied players gain 5VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.creepy4 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Attracting Attention");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches the ");
                using (styleScope("bold", true))
                {
                    yield return text("4th");
                }
                yield return text(" space on the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" Track, ");
                yield return link("click here", "Gen1-CreepyTrack", null);
            }
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.sane3 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Mark of Genius");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches the ");
                using (styleScope("bold", true))
                {
                    yield return text("3rd");
                }
                yield return text(" space on the ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(" Track, ");
                yield return link("click here.", "Gen1-SanityTrack", null);
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click here at the end of the Generation to continue...", "Feverheart", null);
        using (styleScope("hubTitle", true))
        {
            //using (styleScope("bold", true))
            //{
            //    yield return text(" ");
            //}
        }
        using (styleScope("hubDetails", true))
        {
            using (styleScope("hook", "h000030"))
                yield return link("Click here at the end of the Generation to continue...", null, () => enchantHook("h000030", HarloweEnchantCommand.Replace, passage30_Fragment_0));
        }

        yield return lineBreak();
        yield break;
    }

    IStoryThread passage30_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Fever3", "Feverheart");
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Church   (passage43)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 5900-5929
// Links:  -
// Aborts: -
// Purpose: Reference popup: Gen1 Charitable Church action ($0/1/2 for Heart tokens + Creepy reduction)
// ###################################################################

    void passage43_Init()
    {
        this.Passages[@"Gen1Church"] = new StoryPassage(@"Gen1Church", new string[] { }, passage43_Main);
    }

    IStoryThread passage43_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Charitable Church");
        }
        yield return lineBreak();
        yield return text("Pay $0/1/2 to gain 1/2/3 ");
        yield return text("<sprite=\"S1_HeartToken\" index=0>");
        yield return text(" ");
        yield return text("Heart tokens and move an equal number of spaces backwards on the ");
        yield return text("<sprite=\"Creepy_Icon\" index=0>");
        yield return text(" ");
        yield return text("Track.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("For example: If you pay $1, you will gain 2 ");
            yield return text("<sprite=\"S1_HeartToken\" index=0>");
            yield return text(" ");
            yield return text("Heart tokens and move 2 spaces backwards.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: 4Note   (passage55)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6777-6872
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: Gen1 Creepy-4 / Sanity-3 trigger branches, mayor/charity consequences
// ###################################################################

    void passage55_Init()
    {
        this.Passages[@"4Note"] = new StoryPassage(@"4Note", new string[] { }, passage55_Main);
    }

    IStoryThread passage55_Main()
    {
        yield return text("Big Things Needed:");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Place and Hook up triggers for example.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("CREEPY 4");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hunters = Evil");
        yield return lineBreak();
        yield return text("$2 > Gain $2. > Start of Gen 2 Angry Mob moves 1.");
        yield return lineBreak();
        yield return text("No > 50% Lose 1 Creepy. > Gain SHRINE");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Wolves = Evil");
        yield return lineBreak();
        yield return text("Perform Experiment > Perform Experiment. > Start of Gen 2 Angry Mob moves 1.");
        yield return lineBreak();
        yield return text("No > 50% Lose 1 Creepy. > Gain READING ROOM");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("SANITY 3");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Yes > Pay $1. Gain Knowledge. Discard a Compulsion to Gain 1 more Knowledge. > Ge" +
            "n2 Start, Gain a Maladjustment / Lose 3VP.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("No > Gain 1 Creepy and $1. / Gain Nothing > Gen2 Extra Refusal Action = OR Gen2 E" +
            "xtra Hospital Action");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("(could make another option if they don\'t refuse, but good for now)");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Needs 1 or 2 Storybook tokens with consequence passages. Look in notes.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Mayor Token Bonus/Negative for 3rd Generation (could be different for Library or " +
            "Bank choice)");
        yield return lineBreak();
        yield return text("Charity Token Bonus/Negative for 3rd Generation");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Immortality Bonus/Negative for 3rd Generation. (could be different for choosing E" +
            "ngineering, Chemistry, Biology, Occult)");
        yield return lineBreak();
        yield return text("Disease Bonus/Negative for 2nd Gen and 3rd Generation. (could be different for Hu" +
            "nters or Wolves)");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Go through and ADD pass the start player marker 1 additional time: At the start o" +
            "f every Generation.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players == 3)
        {
            yield return text("Pass the Start Player marker to the next player in clockwise order 1 additional t" +
            "ime.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Probably should have a card or token for +2 points (Chem, Eng, Bio, Occ)");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.mayor);
        yield return lineBreak();
        yield return text(Vars.charity);
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5Special1b   (passage65)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7801-7899
// Links:  -
// Aborts: -
// Purpose: Resolves the mayoral bid and tiebreak; asks who became Mayor
// ###################################################################

    void passage65_Init()
    {
        this.Passages[@"S5Special1b"] = new StoryPassage(@"S5Special1b", new string[] { }, passage65_Main);
    }

    IStoryThread passage65_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Humble Beginnings");
        }
        yield return lineBreak();
        yield return text("The family had made their first mark on the history of the town, for good or ill." +
            " It would be several years before they would understand the ominous ramification" +
            "s of this decision, but it was clear that life in ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("would never again be the same.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The player that bid the most wins the election. ");
            using (styleScope("italic", true))
            {
                yield return text("(If there is a tie, the player who went last in turn order the previous round win" +
            "s the bid.)");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Which player became the elected Mayor?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00026"))
            yield return link(Vars.nameA, null, () => enchantHook("h00026", HarloweEnchantCommand.Replace, passage65_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00027"))
            yield return link(Vars.nameB, null, () => enchantHook("h00027", HarloweEnchantCommand.Replace, passage65_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00028"))
                yield return link(Vars.nameC, null, () => enchantHook("h00028", HarloweEnchantCommand.Replace, passage65_Fragment_2));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00029"))
                yield return link(Vars.nameD, null, () => enchantHook("h00029", HarloweEnchantCommand.Replace, passage65_Fragment_3));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00030"))
                yield return link(Vars.nameE, null, () => enchantHook("h00030", HarloweEnchantCommand.Replace, passage65_Fragment_4));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage65_Fragment_0()
    {
        Vars.mayor = Vars.nameA;
        yield return abort(goToPassage: "S5SpecialSetup1");
        yield break;
    }

    IStoryThread passage65_Fragment_1()
    {
        Vars.mayor = Vars.nameB;
        yield return abort(goToPassage: "S5SpecialSetup1");
        yield break;
    }

    IStoryThread passage65_Fragment_2()
    {
        Vars.mayor = Vars.nameC;
        yield return abort(goToPassage: "S5SpecialSetup1");
        yield break;
    }

    IStoryThread passage65_Fragment_3()
    {
        Vars.mayor = Vars.nameD;
        yield return abort(goToPassage: "S5SpecialSetup1");
        yield break;
    }

    IStoryThread passage65_Fragment_4()
    {
        Vars.mayor = Vars.nameE;
        yield return abort(goToPassage: "S5SpecialSetup1");
        yield break;
    }

// ###################################################################
// PASSAGE: FeverServe1   (passage66)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7904-7964
// Links:  Fever2
// Aborts: -
// Purpose: "Fortuitous Assistance": each player pays $1 to gain a Servant
// ###################################################################

    void passage66_Init()
    {
        this.Passages[@"FeverServe1"] = new StoryPassage(@"FeverServe1", new string[] { }, passage66_Main);
    }

    IStoryThread passage66_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Fortuitous Assistance");
        }
        yield return lineBreak();
        yield return text(@"The small village certainly offered a degree of seclusion and a minute amount of rustic charm on the days when gangrenous bodies of the afflicted were not carted through the streets. But in accordance with this anonymity, it did not easily provide the luxuries generally afforded to the whims of ");
        yield return text(Vars.playtxt);
        yield return text(" ");
        yield return text("young aristocrats and their spouses.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The family was overjoyed then to receive a letter from some of their most trusted colleagues; however, this joy abated when they detailed an opportunity to offer wardship and tutelage to unfortunate youths failing in their studies. While the interruption was exasperating, an additional hand would allow them more time to focus on important work and to avoid the aromas of the local peasantry.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage66_Fragment_1);
        using (styleScope("hook", "h000066"))
            yield return link("Click to continue...", null, () => enchantHook("h000066", HarloweEnchantCommand.Replace, passage66_Fragment_0));
        yield break;
    }

    IStoryThread passage66_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Fever2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "GainServantFromLost";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Each player ");
            using (styleScope("bold", true))
            {
                yield return text("pays $1 and gains a SERVANT from LOST");
            }
            yield return text(" ");
            yield return text("and places it in their Quarters.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Fever2", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage66_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage66_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: FeverServe2   (passage67)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7969-8026
// Links:  Fever3
// Aborts: -
// Purpose: "Daughters Entrusted": each player gains a Servant free
// ###################################################################

    void passage67_Init()
    {
        this.Passages[@"FeverServe2"] = new StoryPassage(@"FeverServe2", new string[] { }, passage67_Main);
    }

    IStoryThread passage67_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Daughters Entrusted");
        }
        yield return lineBreak();
        yield return text(@"During the heat of summer, a handsomely dressed woman arrived at each estate with a letter in hand. Interestingly, a former business associate of their mother's requested a daughter be put under each of the houses' charge; along with a considerable stipend to offset the cost. While an appreciable burden, it was irrefusable given the social mores of the time. Being twenty-three and therefore past the age of reasonable marriage, she accepted the new labors with a somewhat heavy heart and was quickly ingratiated into the fold.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage67_Fragment_1);
        using (styleScope("hook", "h000067"))
            yield return link("Click to continue...", null, () => enchantHook("h000067", HarloweEnchantCommand.Replace, passage67_Fragment_0));
        yield break;
    }

    IStoryThread passage67_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Fever3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "GainServantFromLost";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Each player ");
            using (styleScope("bold", true))
            {
                yield return text("gains a SERVANT from LOST");
            }
            yield return text(" ");
            yield return text("and places it in their Quarters. ");
            using (styleScope("italic", true))
            {
                yield return text("If you cannot gain a Servant, gain $1 instead.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Fever3", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage67_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage67_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Dubious   (passage68)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8031-8112
// Links:  SpecialGen1
// Aborts: -
// Purpose: "Dubious Bartering" opening setup; deals each player a card
// ###################################################################

    void passage68_Init()
    {
        this.Passages[@"Dubious"] = new StoryPassage(@"Dubious", new string[] { }, passage68_Main);
    }

    IStoryThread passage68_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Dubious Bartering");
        }
        yield return lineBreak();
        yield return text(@"Within days of their settling in to their spouse's liking, the local diocese sent a messenger to speak with each of the heirs about their father's charitability towards the diseased — or lack thereof. The bishop entreated them to donate precious time and money to help aid the sick at the church.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Having an extensive background in biological studies at the university, the youth" +
            "s proudly offered their scientific services in subduing the epidemic. The bishop" +
            " was unenthusiastic about the response and pressed them to change their mind — t" +
            "o no avail.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage68_Fragment_1);
        using (styleScope("hook", "h000068"))
            yield return link("Click to continue...", null, () => enchantHook("h000068", HarloweEnchantCommand.Replace, passage68_Fragment_0));
        yield break;
    }

    IStoryThread passage68_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "SpecialGen1";
        if (Vars.townname == "Rage")
        {
            Vars.wolves = "evil";
        }
        else if (Vars.townname == "Kraven")
        {
            Vars.wolves = "good";
        }
        else
        {
            Vars.wolves = macros1.either("evil", "good");
        }

        if (Vars.wolves == "good")
        {
            Vars.hunters = "evil";
        }
        else if (Vars.wolves == "evil")
        {
            Vars.hunters = "good";
        }
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "S1_DubiousBartering";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Retrieve the Dubious Bartering cards from the scenario box. Shuffle them and ");
            using (styleScope("bold", true))
            {
                yield return text("give each player a Dubious Bartering card");
            }
            yield return text(" ");
            yield return text("and return any remaining to the box. This card is placed face-up near their Estat" +
                "e and is activated each time the listed action is taken.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "SpecialGen1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage68_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage68_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: S5Special1a   (passage81)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 9259-9311
// Links:  S5Special1b
// Aborts: -
// Purpose: "A Bid for Mayor": simultaneous secret money bid for the mayoralty
// ###################################################################

    void passage81_Init()
    {
        this.Passages[@"S5Special1a"] = new StoryPassage(@"S5Special1a", new string[] { }, passage81_Main);
    }

    IStoryThread passage81_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Bid for Mayor");
        }
        ViewSpecialEvent.instance.ShowEventPopup();
        //ViewBiddingSystem.instance.OnShowBidding();
        yield return lineBreak();
        //yield return text("_event: speshevent");
        using (styleScope("bold", true))
        {
            yield return text("SPECIAL EVENT");
        }
        yield return lineBreak();
        yield return text("All players take all their money into their hands. They then secretly choose any " +
            "amount to place into their right hand to bid on becoming Mayor.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Once all players are ready, reveal the amount of money bid simultaneously. The pl" +
            "ayer that bid the most wins the election. ");
        using (styleScope("italic", true))
        {
            yield return text("(If there is a tie, the player who went last in turn order the previous round win" +
            "s the bid.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Only the player that wins the election must pay their bid to supply. All others r" +
            "eturn their money to their Estates.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Once you are ready, ");
            //yield return link("click to start the bid...", "S5Special1b", null);
            using (styleScope("hook", "h000081"))
                yield return link("click to start the bid...", null, () => enchantHook("h000081", HarloweEnchantCommand.None, passage81_Fragment_0));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage81_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("S5Special1b", BiddingSystem.Bidding);
        yield break;
    }

// ###################################################################
// PASSAGE: ReminderroundEnd   (passage82)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 9317-9361
// Links:  FeverServe1
// Aborts: -
// Purpose: End-of-round reminder + serves the first Gen1 servant event
// ###################################################################

    void passage82_Init()
    {
        this.Passages[@"ReminderroundEnd"] = new StoryPassage(@"ReminderroundEnd", new string[] { }, passage82_Main);
    }

    IStoryThread passage82_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("End of round");
        }
        yield return lineBreak();
        yield return text("Perform all End of round actions and prepare for the next round of play.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("NOTE");
        }
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("This message will appear at the end of every round in the final version, but NOT " +
            "in this prototype. When rounds 1 & 2 of a Generation are over, you will always p" +
            "erform all End of round actions ");
            using (styleScope("bold", true))
            {
                yield return text("BEFORE");
            }
            yield return text(" ");
            yield return text("resolving any new ");
            using (styleScope("bold", true))
            {
                yield return text("Storybook Events");
            }
            yield return text(". ");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "FeverServe1", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1-CreepyTrack   (passage177)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 20926-21019
// Links:  -
// Aborts: -
// Purpose: "Enemy of the People": who reached space 4 on the Creepy track
// ###################################################################

    void passage177_Init()
    {
        this.Passages[@"Gen1-CreepyTrack"] = new StoryPassage(@"Gen1-CreepyTrack", new string[] { }, passage177_Main);
    }

    IStoryThread passage177_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Enemy of the People");
        }
        yield return lineBreak();
        Vars.tcodgen1 = 1;
        yield return text(@"The increasingly eccentric actions of the siblings aroused dark memories from the previous generation, and tense rumors once again circulated throughout the village. However, as these same fears were shared more openly, the news attracted opportunities for those with similar, nefarious intent.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Please click on the name of the scientist that reached ");
        using (styleScope("bold", true))
        {
            yield return text("space 4");
        }
        yield return text(" ");
        yield return text("on the ");
        yield return text("<sprite=\"Creepy_Icon\" index=0>");
        yield return text(" ");
        yield return text("track:");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00151"))
            yield return link(Vars.nameA.ToString(), null, () => enchantHook("h00151", HarloweEnchantCommand.Replace, passage177_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00152"))
            yield return link(Vars.nameB.ToString(), null, () => enchantHook("h00152", HarloweEnchantCommand.Replace, passage177_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00153"))
                yield return link(Vars.nameC.ToString(), null, () => enchantHook("h00153", HarloweEnchantCommand.Replace, passage177_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00154"))
                yield return link(Vars.nameD.ToString(), null, () => enchantHook("h00154", HarloweEnchantCommand.Replace, passage177_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00155"))
                yield return link(Vars.nameE.ToString(), null, () => enchantHook("h00155", HarloweEnchantCommand.Replace, passage177_Fragment_4));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage177_Fragment_0()
    {
        Vars.gen1creep = Vars.nameA;
        yield return abort(goToPassage: "Gen1-CreepyTrackRes");
        yield break;
    }

    IStoryThread passage177_Fragment_1()
    {
        Vars.gen1creep = Vars.nameB;
        yield return abort(goToPassage: "Gen1-CreepyTrackRes");
        yield break;
    }

    IStoryThread passage177_Fragment_2()
    {
        Vars.gen1creep = Vars.nameC;
        yield return abort(goToPassage: "Gen1-CreepyTrackRes");
        yield break;
    }

    IStoryThread passage177_Fragment_3()
    {
        Vars.gen1creep = Vars.nameD;
        yield return abort(goToPassage: "Gen1-CreepyTrackRes");
        yield break;
    }

    IStoryThread passage177_Fragment_4()
    {
        Vars.gen1creep = Vars.nameE;
        yield return abort(goToPassage: "Gen1-CreepyTrackRes");
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1-SanityTrack   (passage178)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21024-21117
// Links:  -
// Aborts: -
// Purpose: "To Quell the Mind": who reached space 3 on the Insanity track
// ###################################################################

    void passage178_Init()
    {
        this.Passages[@"Gen1-SanityTrack"] = new StoryPassage(@"Gen1-SanityTrack", new string[] { }, passage178_Main);
    }

    IStoryThread passage178_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("To Quell the Mind");
        }
        yield return lineBreak();
        Vars.tcodgen1 = 1;
        yield return text(@"Just as a sharpened blade loses some of its steel, so it is the same with a pointed intellect so repeatedly ground. This precise focus upon scientific labors caused the siblings' brains to wander and ache for relief even as a powerful ambition compelled them well beyond their physical tolerances.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Please click on the name of the scientist that reached ");
        using (styleScope("bold", true))
        {
            yield return text("space 3");
        }
        yield return text(" ");
        yield return text("on the ");
        yield return text("<sprite=\"Insanity_Icon\" index=0>");
        yield return text(" ");
        yield return text("track:");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00156"))
            yield return link(Vars.nameA.ToString(), null, () => enchantHook("h00156", HarloweEnchantCommand.Replace, passage178_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00157"))
            yield return link(Vars.nameB.ToString(), null, () => enchantHook("h00157", HarloweEnchantCommand.Replace, passage178_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00158"))
                yield return link(Vars.nameC.ToString(), null, () => enchantHook("h00158", HarloweEnchantCommand.Replace, passage178_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00159"))
                yield return link(Vars.nameD.ToString(), null, () => enchantHook("h00159", HarloweEnchantCommand.Replace, passage178_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00160"))
                yield return link(Vars.nameE.ToString(), null, () => enchantHook("h00160", HarloweEnchantCommand.Replace, passage178_Fragment_4));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage178_Fragment_0()
    {
        Vars.gen1sane = Vars.nameA;
        yield return abort(goToPassage: "Gen1-SanityTrackRes");
        yield break;
    }

    IStoryThread passage178_Fragment_1()
    {
        Vars.gen1sane = Vars.nameB;
        yield return abort(goToPassage: "Gen1-SanityTrackRes");
        yield break;
    }

    IStoryThread passage178_Fragment_2()
    {
        Vars.gen1sane = Vars.nameC;
        yield return abort(goToPassage: "Gen1-SanityTrackRes");
        yield break;
    }

    IStoryThread passage178_Fragment_3()
    {
        Vars.gen1sane = Vars.nameD;
        yield return abort(goToPassage: "Gen1-SanityTrackRes");
        yield break;
    }

    IStoryThread passage178_Fragment_4()
    {
        Vars.gen1sane = Vars.nameE;
        yield return abort(goToPassage: "Gen1-SanityTrackRes");
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1-CreepyTrackRes   (passage179)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21122-21233
// Links:  Gen1CreepyYes,Gen1CreepyNo
// Aborts: -
// Purpose: Private secret-society offer to fund the Creepy scientist's estate for $2 vs a future debt
// ###################################################################

    void passage179_Init()
    {
        this.Passages[@"Gen1-CreepyTrackRes"] = new StoryPassage(@"Gen1-CreepyTrackRes", new string[] { }, passage179_Main);
    }

    IStoryThread passage179_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Seedy Arrangement");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this storybook device to ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage179_Fragment_1);
        using (styleScope("hook", "h000179"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000179", HarloweEnchantCommand.Replace, passage179_Fragment_0));
        yield break;
    }

    IStoryThread passage179_Fragment_0()
    {
        //using (styleScope("bold", true))
        //{
        //    yield return text("A Seedy Arrangement");
        //}
        yield return lineBreak();
        if (Vars.hunters == "evil")
        {
            yield return text("It was unorthodox for ");
            yield return text(Vars.gen1creep);
            yield return text(", or anyone of that reclusive lineage, to entertain unknown visitors, but somethi" +
            "ng must have piqued their curiosity. A conversation from an evening dinner is no" +
            "ted in a journal entry:");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"""Your estate is simply exquisite,"" the representative was noted as saying with an unsettling grin. ""I am impressed to find a rarefied jewel nestled in such a remote place. But, as you will no doubt agree, it can always use improvement and I would like to offer you support in this."" In fact, it was noted that the individual's mannerisms were especially secretive and plotting.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The representative from the Fraternity of Hunters offered their support with subs" +
            "tantial funds. With the \"hope\" that this kindness would be repaid in the future." +
            "");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("CHOOSE:");
            }
            yield return lineBreak();
            yield return link("Accept the offer.", "Gen1CreepyYes", null);
            yield return text("(To gain $2.)");
            yield return lineBreak();
            yield return text("OR");
            yield return lineBreak();
            yield return link("Refuse the offer.", "Gen1CreepyNo", null);
            yield return text("(To avoid a debt in the future.)");
            yield return lineBreak();
        }
        //if (Vars.wolves == "evil")
        else
        {
            yield return text("It was unorthodox for ");
            yield return text(Vars.gen1creep);
            yield return text(", or anyone of that reclusive lineage, to entertain unknown visitors, but somethi" +
            "ng must have piqued their curiosity. A conversation from an evening dinner is no" +
            "ted in a journal entry:");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"""Your reputation is known across the region for vehemently challenging the established norms,"" the representative from the Order of St. Hubertus was noted as saying with a wide grin. They leaned in conspiratorially, an expensive perfume loud enough in fragrance to draw water from the eyes. ""From what I hear, you are unwilling to allow the rules of academia to hold your work back from its true excellence. Please, let me admire your experimentation.""");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("This was highly controversial! And to be so brazen about it! It was left to the s" +
            "cientist to decide if being granted the opportunity to ");
            using (styleScope("bold", true))
            {
                yield return text("perform an extra experiment");
            }
            yield return text(" was worth the possible consequences of revealing one\'s work.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("CHOOSE:");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Accept.", "Gen1CreepyYes", null);
            yield return text("(To take a Perform Experiment Action.)");
            yield return lineBreak();
            yield return text("OR");
            yield return lineBreak();
            yield return link("Refuse.", "Gen1CreepyNo", null);
            yield return text("(If you cannot or choose not to take the action.)");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage179_Fragment_1()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage179_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1-SanityTrackRes   (passage180)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21238-21315
// Links:  Gen1SanityYes,Gen1SanityNo
// Aborts: -
// Purpose: Private letter offering the Insane scientist a Rovinj retreat, or refuse
// ###################################################################

    void passage180_Init()
    {
        this.Passages[@"Gen1-SanityTrackRes"] = new StoryPassage(@"Gen1-SanityTrackRes", new string[] { }, passage180_Main);
    }

    IStoryThread passage180_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Letter From an Old Friend");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this storybook device to ");
            yield return text(Vars.gen1sane);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage180_Fragment_1);
        using (styleScope("hook", "h000180"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000180", HarloweEnchantCommand.Replace, passage180_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage180_Fragment_0()
    {
        yield return lineBreak();
        yield return text("\"You shouldn\'t drive yourself so hard,\" the letter stated. \"It is unsustainable. " +
            "For each night you toil away until dawn\'s light, it takes years from your mind.\"" +
            "");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While the nature of their work ensured that it was performed in solitude, ");
        yield return text(Vars.gen1sane);
        yield return text(@", and their spouse especially, still enjoyed writing letters to the few friends who would receive them. This particular letter from an old colleague at university recommended a specific retreat in Rovinj, where the warm Mediterranean air would rejuvenate the body and quiet the mind. For a small price, they could own a vacation home.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While this time away could have a negative affect on their child, it would also a" +
            "llow them to ");
        using (styleScope("bold", true))
        {
            yield return text("gain knowledge");
        }
        yield return text(" ");
        yield return text("and ");
        using (styleScope("bold", true))
        {
            yield return text("calm their sanity");
        }
        yield return text(". Refusal, however, would carry no risk and maybe give them more time to complete" +
            " their labors.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Accept the offer and pay $1. (Calm your sanity and gain 1 Knowledge.)", "Gen1SanityYes", null);
        yield return lineBreak();
        yield return text("OR");
        yield return lineBreak();
        yield return link("Refuse. (Avoid the penalties of laziness.)", "Gen1SanityNo", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage180_Fragment_1()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage180_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: SpecialGen1   (passage254)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27360-27421
// Links:  1sttime-Suspicion
// Aborts: -
// Purpose: Gen1 setup: Storybook tokens on Insanity space 3 and Creepy space 4
// ###################################################################

    void passage254_Init()
    {
        this.Passages[@"SpecialGen1"] = new StoryPassage(@"SpecialGen1", new string[] { }, passage254_Main);
    }

    IStoryThread passage254_Main()
    {
        ViewItemObtain.SetupPassagename = "1sttime-Suspicion";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "StorybookToken";
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Retrieve the ");
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" ");
                yield return text("tokens.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Place one token on ");
            using (styleScope("bold", true))
            {
                yield return text("space 3");
            }
            yield return text(" ");
            yield return text("of the ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Place one token on ");
            using (styleScope("bold", true))
            {
                yield return text("space 4");
            }
            yield return text(" ");
            yield return text("of the ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("When a player\'s piece reaches one of these tokens, they will click on the appropr" +
                "iate link and receive a special message for reaching this achievement.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click here to continue...", "1sttime-Suspicion", null);
        yield break;
    }

// ###################################################################
// PASSAGE: 1sttime-Suspicion   (passage256)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27491-27561
// Links:  Fever1
// Aborts: -
// Purpose: First-time rules explanation of the Suspicion Marker and Angry Mob limit
// ###################################################################

    void passage256_Init()
    {
        this.Passages[@"1sttime-Suspicion"] = new StoryPassage(@"1sttime-Suspicion", new string[] { }, passage256_Main);
    }

    IStoryThread passage256_Main()
    {
        ViewItemObtain.SetupPassagename = "Fever1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "AngryMobSetup1";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Place the Suspicion marker on space ");
            using (styleScope("bold", true))
            {
                if (Vars.players == 2)
                {
                    Vars.tracker = macros1.either(6, 7);
                }
                if (Vars.players == 3)
                {
                    Vars.tracker = macros1.either(7, 8);
                }
                if (Vars.players == 4)
                {
                    Vars.tracker = macros1.either(9, 10, 11);
                }
                if (Vars.players == 5)
                {
                    Vars.tracker = macros1.either(10, 11, 12);
                }
                yield return text(Vars.tracker);
            }
            yield return text(" ");
            yield return text("and the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token one space to the left.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Suspicion Marker");
            }
            yield return lineBreak();
            yield return text("The Suspicion Marker represents the furthest right that the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("can move during a Generation. This marker stays in the same location throughout t" +
                "he current Generation and the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token can never be moved ");
            using (styleScope("bold", true))
            {
                yield return text("onto or past");
            }
            yield return text(" ");
            yield return text("this marker by any actions or abilities during gameplay.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Fever1", null);
        //yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1CreepyYes   (passage296)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 30450-30586
// Links:  Fever1,Fever2,Fever3
// Aborts: -
// Purpose: Gen1 Creepy track ACCEPT: gain $2 or a free Perform an Experiment action
// ###################################################################

    void passage296_Init()
    {
        this.Passages[@"Gen1CreepyYes"] = new StoryPassage(@"Gen1CreepyYes", new string[] { }, passage296_Main);
    }

    IStoryThread passage296_Main()
    {
        if (Vars.hunters == "evil")
        {
            using (styleScope("bold", true))
            {
                yield return text("Agreed");
            }
            yield return lineBreak();
            yield return text(@"The individual produced a banker's cheque from their overcoat and an ink pen from their breast pocket, signing the note with an extravagant signature. Stamped upon the egg-shell cardstock in golden foil was the insignia of a bow and arrow. The man twirled his handlebar mustache with a deep laugh before exiting by carriage.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Perhaps it had been a chance meeting, yet for some reason, the scientist suspecte" +
            "d a deeper meaning had yet to be revealed.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to return...", passage296_Fragment_1);
            using (styleScope("hook", "h000296"))
                yield return link("Click to continue...", null, () => enchantHook("h000296", HarloweEnchantCommand.Replace, passage296_Fragment_0));
        }
        //if (Vars.wolves == "evil")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Agreed");
            }
            yield return lineBreak();
            yield return text("The representative was appreciative of ");
            yield return text(Vars.gen1creep);
            yield return text("\'s humble demonstration. As the experiment was performed, they proceeded to take " +
            "extensive notes which were then sealed up in a leather satchel as they departed " +
            "soon after. The satchel was conspicuously emblazoned with the insignia of a wolf" +
            "\'s head.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Perhaps it had been a chance meeting, yet for some reason, the scientist suspecte" +
            "d a deeper meaning had yet to be revealed.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to return...", passage296_Fragment_3);
            using (styleScope("hook", "h00029603"))
                yield return link("Click to continue...", null, () => enchantHook("h00029603", HarloweEnchantCommand.Replace, passage296_Fragment_2));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage296_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = Vars.round == 1 ? "Fever1" : Vars.round == 2 ? "Fever2" : "Fever3";
        Vars.seedy = "yes";
        Vars.creepy4 = 1;
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Money_Icon";
            yield return lineBreak();
            yield return text("Gain $2. Then, return the ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" token to the supply.");
        }
        //if (Vars.round == 1)
        //{
        //    yield return link("Click to return...", "Fever1", null);
        //}
        //if (Vars.round == 2)
        //{
        //    Vars.creepy4 = 1;
        //    yield return link("Click to return...", "Fever2", null);
        //}
        //if (Vars.round == 3)
        //{
        //    Vars.creepy4 = 1;
        //    yield return link("Click to return...", "Fever3", null);
        //}
        yield break;
    }

    IStoryThread passage296_Fragment_1()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage296_Fragment_0);
        yield break;
    }

    IStoryThread passage296_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = Vars.round == 1 ? "Fever1" : Vars.round == 2 ? "Fever2" : "Fever3";
        Vars.seedy = "yes";
        Vars.creepy4 = 1;
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "MFWlogo";
            yield return lineBreak();
            yield return text("You may immediately take a ");
            using (styleScope("bold", true))
            {
                yield return text("Perform an Experiment");
            }
            yield return text(" action. Then, return the ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" token to the supply.");
        }
        //if (Vars.round == 1)
        //{
        //    yield return link("Click to return...", "Fever1", null);
        //}
        //if (Vars.round == 2)
        //{
        //    Vars.creepy4 = 1;
        //    yield return link("Click to return...", "Fever2", null);
        //}
        //if (Vars.round == 3)
        //{
        //    Vars.creepy4 = 1;
        //    yield return link("Click to return...", "Fever3", null);
        //}
        yield break;
    }

    IStoryThread passage296_Fragment_3()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage296_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1CreepyNo   (passage297)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 30591-30684
// Links:  Fever1,Fever2,Fever3
// Aborts: -
// Purpose: Gen1 Creepy track REFUSE: lose 1 resource; return to Fever1/2/3
// ###################################################################

    void passage297_Init()
    {
        this.Passages[@"Gen1CreepyNo"] = new StoryPassage(@"Gen1CreepyNo", new string[] { }, passage297_Main);
    }

    IStoryThread passage297_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Ridiculous!");
        }
        yield return lineBreak();
        Vars.seedy = "no";
        yield return lineBreak();
        yield return text("As one might expect, the next few pages of notes in the journal are filled with u" +
            "nflattering jests and laughter at this absolutely half-witted rube and the seedy" +
            " proposition they had offered. And so ");
        yield return text(Vars.gen1creep);
        yield return text(" ");
        yield return text("waved them away with flippant disregard for wasting their time.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("An individual has no allegiance but to one\'s self. They would not be saddled with" +
            " some unknown, absurd consequence!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("However, unbeknownst to the semi-virtuous scientist, there was another party that" +
            " observed this gesture with great interest. Perhaps in time this mystery would b" +
            "e revealed.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.Gen1CreepyNonextPsg == "" || Vars.Gen1CreepyNonextPsg == 0) { Vars.Gen1CreepyNonextPsg = macros1.either(1, 2); }
        Vars.randrew = Vars.Gen1CreepyNonextPsg;
        if (Vars.randrew == 1)
        {
            //yield return enchantIntoLink("Click to return...", passage297_Fragment_1);
            using (styleScope("hook", "h000297"))
                yield return link("Click to continue...", null, () => enchantHook("h000297", HarloweEnchantCommand.Replace, passage297_Fragment_0));
        }
        else
        {
            if (Vars.round == 1)
            {
                Vars.creepy4 = 1;
                yield return link("Click to return...", "Fever1", null);
            }
            else if (Vars.round == 2)
            {
                Vars.creepy4 = 1;
                yield return link("Click to return...", "Fever2", null);
            }
            //if (Vars.round == 3)
            else
            {
                Vars.creepy4 = 1;
                yield return link("Click to return...", "Fever3", null);
            }
        }
        yield break;
    }

    IStoryThread passage297_Fragment_0()
    {
        Vars.creepy4 = 1;
        ViewItemObtain.SetupPassagename = Vars.round == 1 ? "Fever1" : Vars.round == 2 ? "Fever2" : "Fever3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Lose ");
            using (styleScope("bold", true))
            {
                yield return text("1 ");
            }
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(". Then, return the ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" token to the supply.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage297_Fragment_1()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage297_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1SanityYes   (passage298)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 30689-30786
// Links:  Fever1,Fever2,Fever3
// Aborts: -
// Purpose: Gen1 Sanity track ACCEPT: pay $1 for Knowledge (more via discarding a Compulsion)
// ###################################################################

    void passage298_Init()
    {
        this.Passages[@"Gen1SanityYes"] = new StoryPassage(@"Gen1SanityYes", new string[] { }, passage298_Main);
    }

    IStoryThread passage298_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Vacation Offer Accepted");
        }
        yield return lineBreak();
        Vars.vacation = "yes";
        yield return lineBreak();
        yield return text("Perhaps the weight of the work lay heavy upon their shoulders or the stress of pa" +
            "renthood prompted a needed escape. In either case, ");
        yield return text(Vars.gen1sane);
        yield return text(" ");
        yield return text("would utilize this second home often. As they contemplated the calm ocean waters " +
            "from their seaside villa, their child was left in the care of servants and spent" +
            " their winters within the solitary stone walls of the cold estate.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage298_Fragment_1);
        using (styleScope("hook", "h000298"))
            yield return link("Click to continue...", null, () => enchantHook("h000298", HarloweEnchantCommand.Replace, passage298_Fragment_0));
        yield break;
    }

    IStoryThread passage298_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 1 ? "Fever1" : Vars.round == 2 ? "Fever2" : "Fever3";
        Vars.sane3 = 1;
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AnyKnowledge_Icon";
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Pay $1.");
            }
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Gain 1 Knowledge of your choice.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Then, you may discard a ");
            using (styleScope("bold", true))
            {
                yield return text("Compulsion");
            }
            yield return text(" ");
            yield return text("from your hand. If you do, ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1 Knowledge");
            }
            yield return text(" ");
            yield return text("of your choice.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Then, return the ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            yield return text("token to the supply.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 1)
        //{
        //    Vars.sane3 = 1;
        //    yield return link("Click to return...", "Fever1", null);
        //}
        //if (Vars.round == 2)
        //{
        //    Vars.sane3 = 1;
        //    yield return link("Click to return...", "Fever2", null);
        //}
        //if (Vars.round == 3)
        //{
        //    Vars.sane3 = 1;
        //    yield return link("Click to return...", "Fever3", null);
        //}
        yield break;
    }

    IStoryThread passage298_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage298_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1SanityNo   (passage299)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 30791-30885
// Links:  Fever1,Fever2,Fever3
// Aborts: -
// Purpose: Gen1 Sanity track REFUSE: gain $1 and a resource
// ###################################################################

    void passage299_Init()
    {
        this.Passages[@"Gen1SanityNo"] = new StoryPassage(@"Gen1SanityNo", new string[] { }, passage299_Main);
    }

    IStoryThread passage299_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Time is Precious");
        }
        yield return lineBreak();
        Vars.vacation = "no";
        yield return lineBreak();
        yield return text("There was no time to rest. And even if there was, the frequent bouts of insomnia " +
            "");
        yield return text(Vars.gen1sane);
        yield return text(" ");
        yield return text(@"experienced certainly eliminated the option. It was all in the work. They were convinced that this obsession that carved lines into their graying skin was more important than self-preservation. How could they vacation while perched on the precipice of a triumphant victory?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.Gen1SanityNonextPsg == "" || Vars.Gen1SanityNonextPsg == 0)
        {
            Vars.Gen1SanityNonextPsg = macros1.either(1, 2);
        }
        Vars.randrew = Vars.Gen1SanityNonextPsg;
        if (Vars.randrew == 1)
        {
            //yield return enchantIntoLink("Click to return...", passage299_Fragment_1);
            using (styleScope("hook", "h000299"))
                yield return link("Click to continue...", null, () => enchantHook("h000299", HarloweEnchantCommand.Replace, passage299_Fragment_0));

        }
        else
        {
            if (Vars.round == 1)
            {
                Vars.sane3 = 1;
                yield return link("Click to return...", "Fever1", null);
            }
            else if (Vars.round == 2)
            {
                Vars.sane3 = 1;
                yield return link("Click to return...", "Fever2", null);
            }
            //if (Vars.round == 3)
            else
            {
                Vars.sane3 = 1;
                yield return link("Click to return...", "Fever3", null);
            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage299_Fragment_0()
    {
        Vars.sane3 = 1;
        ViewItemObtain.SetupPassagename = Vars.round == 1 ? "Fever1" : Vars.round == 2 ? "Fever2" : "Fever3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Gain ");
            using (styleScope("bold", true))
            {
                yield return text("$1");
            }
            yield return text(". Gain ");
            using (styleScope("bold", true))
            {
                yield return text("1 ");
            }
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return text(" Then, return the ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" token to the supply.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage299_Fragment_1()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage299_Fragment_0);
        yield break;
    }
