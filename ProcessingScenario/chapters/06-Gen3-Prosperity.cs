// ===================================================================
// CHAPTER: Gen3-Prosperity   (49 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage47    CureMoonSick1                L6114-6227  "Moon Sickness" lycanthropy narrative in the Prosperity branch
// passage83    ProsperityHunterIntro        L9367-9406  Generation III prose intro: Fraternity of Hunters branch
// passage352   Prosperity1                  L12992-13318  Round-1 HUB of the Prosperity Generation III branch
// passage120   Prosperity2                  L13335-13538  "Moving Forward - Middle Years" HUB rules screen
// passage121   Prosperity3                  L13543-13738  "Moving Forward - Late Years" HUB incl. Scientific Achievement Master's Study unlocks
// passage181   LycanGood                    L21320-21374  Grants the Lycanthropic Strength Masterwork Update once werewolves are proven real
// passage182   GoodConsequences             L21379-21461  Wolf-town resents the experiments; Creepy token on every Perform Experiment action
// passage197   GoodNote-Goals               L22532-22701  DEV NOTE: "good" Gen3 branch goals + Master's Study setup
// passage207   CharityAwardGood             L23463-23539  Private award to the charity leader: free Personal Library, Heart token returned
// passage208   MayoralAward                 L23544-23642  Private award for the librarian lineage: Personal Library, free Knowledge per Experiment
// passage212   EquitableValues              L23912-24004  Democratic equity: lowest-VP players recover a Servant, leader gains 2 Creepy
// passage213   LycanMessageGood             L24009-24058  Checks for the Lycanthropic Strength Masterwork; returns to Prosperity1
// passage214   WolvesEco-Friendly           L24063-24133  Reformed monsters turn eco-friendly; Creepy token on the Farmer's Market
// passage215   AngryMobStorybook            L24138-24281  Angry-Mob flavor vignettes triggered when the mob token advances
// passage216   GoodFrenzyEvent              L24286-24319  Proposal to hold a sanctioned monster "Frenzy"; branches to the vote variants
// passage217   YesFrenzy                    L24325-24364  The Frenzy happens; the town descends into permanent bloodlust
// passage218   NoFrenzy                     L24369-24443  Frenzy declined; Chemistry/Engineering Master's Study vanity upgrades unlocked
// passage230   Evilsforgive                 L25438-25638  Town meeting: monsters offer reconciliation; retrieves Master's Study tiles
// passage262   HuntersHUBcode               L28024-28189  CODE ONLY: shuffles the monster list and reward list for the Hunt mini-game
// passage265   HuntNorth                    L28378-28394  Hunt destination flavor: the foggy northern moors
// passage266   HuntWest                     L28400-28416  Hunt destination flavor: the blood-tinged western mountains
// passage267   HuntEast                     L28422-28438  Hunt destination flavor: the eastern Dark Forest
// passage268   HuntSouth                    L28444-28462  Hunt destination flavor: the town's cobblestone streets
// passage269   Pricolici                    L28468-28500  Hunt encounter: Pricolici
// passage270   Moon Presence                L28506-28541  Hunt encounter: Moonlight Presence
// passage271   Wight                        L28547-28583  Hunt encounter: Shambling Wight
// passage272   Troll                        L28589-28616  Hunt encounter: bridge Troll
// passage273   Golem                        L28622-28653  Hunt encounter: Stone Golem
// passage274   Manticore                    L28659-28686  Hunt encounter: Manticore
// passage275   Strigoi                      L28692-28724  Hunt encounter: Strigoi in the town alley
// passage276   Priest                       L28730-28765  Hunt encounter: disfigured Priest in the church
// passage277   HuntSuccess1                 L28771-28852  Hunt victory: beast destroyed; rewards; routes to Prosperity2 or HuntSuccessCheck
// passage278   HuntFail1                    L28857-28929  Hunt defeat: beast escapes with the servants
// passage316   Prosperity3b                 L32430-32608  "A Return to Evil - Late Years" final HUB: Suspicious Buildings, page 18, Monster Spawn, ending assignment
// passage317   HuntSuccessCheck             L32614-32720  Tallies hunt successes for a good or overrun fate; Master's Study Vanity Upgrades
// passage319   HuntersChoice1               L32789-32878  Hunt night 1: chosen player picks a direction; sets `direction`; routes to HuntNight1
// passage320   HuntersChoice2               L32883-32972  Hunt night 2: direction choice; routes to HuntNight2
// passage321   HuntNight1                   L32977-33076  Night-1 contribution vote by the two hunting players; success/failure branch
// passage322   HuntNight2                   L33082-33181  Night-2 contribution vote; success/failure branch
// passage323   Huntround1                   L33187-33251  Hunt prep: two players each place a Servant/Spouse on the Hunter's Haven
// passage324   Huntround2                   L33256-33320  Second hunt prep; place pieces on the Hunter's Haven again
// passage325   ProsperityWolvesIntro        L33325-33375  Generation III intro "The Order Revealed" (Wolves variant of the prosperity branch)
// passage334   2p-FrenzyALT                 L33779-33856  2-player ALT: money bid instead of a vote to decide the night of Frenzy
// passage335   GoodFrenzyEvent2             L33861-33944  Standard vote on encouraging the Frenzy
// passage344   2p-FrenzyALTb                L34361-34389  Resolves the 2-player Frenzy bid: winner pays, +2VP, picks Yes/NoFrenzy
// passage345   GoodFrenzyEvent2b            L34395-34428  Resolves the Frenzy vote tally; links to YesFrenzy/NoFrenzy
// passage353   MayorResolveHunters          L34701-34779  "Recompense for Past Leadership": mayoral legacy grants VP + a resource; leads to Huntround2
// passage354   ResolveCharityWolves         L34784-34862  "Passion and Empathy": charitable legacy recovers a Servant; Heart token returned
// passage359   WolvesBankMayorGood          L34965-35047  "The Stench of Man's Avarice": the bank/mayor legacy gives 1 resource but -2VP
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   Prosperity1          --end of round-->  WolvesEco-Friendly, CharityAwardGood
//   Prosperity2          --end of round-->  GoodFrenzyEvent, CureMoonSick1
//   Prosperity3          --end of round-->  Scoring, Scoring
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: CureMoonSick1   (passage47)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6114-6227
// Links:  Huntround1,Huntround2
// Aborts: -
// Purpose: "Moon Sickness" lycanthropy narrative in the Prosperity branch
// ###################################################################

    void passage47_Init()
    {
        this.Passages[@"CureMoonSick1"] = new StoryPassage(@"CureMoonSick1", new string[] { }, passage47_Main);
    }

    IStoryThread passage47_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Moon Sickness");
        }
        yield return lineBreak();
        if (Vars.round == 13)
        {
            yield return text("What a horrible night to have a curse!");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"They wrote of torn clothing, strange awakenings half-naked in the gardens at the edge of their Estate, of blood speckled about their boots and dried streaks from the corners of their lips. Lingering lucid memories of stalking prey in the woods haunted their dreams yet filled them with a terrible energy!");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"When they discovered the eviscerated body of one of their servants skewered upon the metal fence that lined the grounds, the bestial teeth and claw marks told a new story. They steeled their mind against the distraction, recommitting themselves with deadly focus to the task at hand.");
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage47_Fragment_1);
            using (styleScope("hook", "h0004701"))
                yield return link("Click to continue...", null, () => enchantHook("h0004701", HarloweEnchantCommand.Replace, passage47_Fragment_0));
        }
        //if (Vars.round == 14)
        else
        {
            yield return text("They could not dwell on the news of yet another victim within their household for" +
                " long as more pressing matters of scientific import weighed upon their every wak" +
                "ing hour. ");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"For theirs was a dismal, macabre occupation. They measured each moment in dark pen strokes, the incision of a sterilized blade, or the ebullition of glowing liquid in a graduated flask. The loss of a servant was unfortunate, not for the life it represented, but for the distinct lapse in efficiency procuring a new servant would cause.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage47_Fragment_3);
            using (styleScope("hook", "h0004703"))
                yield return link("Click to continue...", null, () => enchantHook("h0004703", HarloweEnchantCommand.Replace, passage47_Fragment_2));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage47_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "Huntround1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "CompulsionBack";
            yield return lineBreak();
            yield return text("All players with a ");
            using (styleScope("bold", true))
            {
                yield return text("Disease Experiment");
            }
            yield return text(" in their Stored Experiments ");
            using (styleScope("bold", true))
            {
                yield return text("draw a Compulsion and gain a Body.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "Huntround1", null);
        yield break;
    }

    IStoryThread passage47_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage47_Fragment_0);
        yield break;
    }

    IStoryThread passage47_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "MayorResolveHunters";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "CompulsionBack";
            yield return lineBreak();
            yield return text("All players with a ");
            using (styleScope("bold", true))
            {
                yield return text("Disease Experiment");
            }
            yield return text(" in their Stored Experiments ");
            using (styleScope("bold", true))
            {
                yield return text("draw a Compulsion and gain a Body.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "Huntround2", null);
        yield break;
    }

    IStoryThread passage47_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage47_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: ProsperityHunterIntro   (passage83)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 9367-9406
// Links:  HuntersHUBcode
// Aborts: -
// Purpose: Generation III prose intro: Fraternity of Hunters branch
// ###################################################################

    void passage83_Init()
    {
        this.Passages[@"ProsperityHunterIntro"] = new StoryPassage(@"ProsperityHunterIntro", new string[] { "INTRO", }, passage83_Main);
    }

    IStoryThread passage83_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION III:");
            yield return lineBreak();
            yield return text("The Fraternity of Hunters");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The disease had revealed a much deeper evil than the family could have ever expected: An evil ignorance that dwells within the minds of the people. It had not only left the previous generation in shambles, but imbued the townsfolk with a profound, insatiable fear, even as the town returned to relative stability. During the day, the people watched the forests, glimpsing dark shadows flitting between the trees. At night, they steeled themselves against the wailing howls of unseen terrors, dreading that their children would be stolen away from their beds.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"That was until the Fraternity of Hunters, emboldened by the success of their clandestine operations, emerged from the shadows on the night of a blood red moon. They wore long-tail coats of black, burgundy, and dark leather, a wooden cross hanging either from their necks or dangling from their sides. They clutched crossbows, whips, and daggers freshly glimmering with crimson fluid. Their blood-stained attire and steel-eyed gaze evoked the undaunted presence of ones who had peered into the void and returned forever changed.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Their stated goal: to slay every last beast in the land and return those who had unleashed this foul plague back to the depths of hell from whence they came. The Fraternity turned the fear of the populace to their advantage. They fed the superstitions of the people, blaming the sickness and disease on fiendish creatures from the dark.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"While they did not require monetary compensation in return, what they did ask was much more severe. Their sanguine efforts could not be completed in isolation, so on nights when the blood moon rose high in the evening sky, a handful of townsfolk were chosen to assist the Hunters' party and venture into the unknown. The next morning, the surviving Hunters would return, their garments speckled in the blood of the beasts and holding aloft the severed trophies of monsters slain in the wilderness. It was only a matter of time before they would call upon the family.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Perhaps driven by a sense of limited time or jealousy over the Hunters' ability to frighten the townsfolk even moreso than their own actions, the cousins continued their meticulous labors in earnest. However, they were deeply unaware of just how intertwined their fates would be to the Fraternity.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "HuntersHUBcode", null);
        yield return lineBreak();
        yield return lineBreak();
        Vars.prosp = 1;
        Vars.huntcount = 0;
        Vars.gen3pg = 0;
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Prosperity1   (passage352)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12992-13318
// Links:  AngryMobStorybook,WolvesEco-Friendly,CharityAwardGood
// Aborts: -
// Round end -> WolvesEco-Friendly, CharityAwardGood
// Purpose: Round-1 HUB of the Prosperity Generation III branch
// ###################################################################

    void passage352_Init()
    {
        this.Passages[@"Prosperity1"] = new StoryPassage(@"Prosperity1", new string[] { }, passage352_Main);
    }

    IStoryThread passage352_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Good Fight - Early Years");
        }
        yield return lineBreak();
        Vars.round = 13;
        yield return lineBreak();

        yield return lineBreak();
        if (Vars.society == "Order of St. Hubertus")
        {
            if (Vars.gen3pg == 0 || Vars.gen3pg == "")
            {
                using (styleScope("setupStyle", true))
                {
                    using (styleScope("bold", true))
                    {
                        //yield return text("SETUP");
                    }
                    Vars._SetupImage = "AngryMobSetup1";
                    yield return text("Turn to page ");
                    using (styleScope("bold", true))
                    {
                        yield return text("17");
                    }
                    yield return text(" of the Village Chronicle. Place the Suspicion Marke" +
                    "r on space ");
                    using (styleScope("bold", true))
                    {
                        if (Vars.Prosperity1 == 0 || Vars.Prosperity1 == "")
                        {
                            Vars.Prosperity1 = 1;
                            Vars.tracker = int.Parse(Vars.tracker) - 2;
                            if (Vars.players == 4)
                            {
                                Vars.tracker = int.Parse(Vars.tracker) - 1;
                            }
                            if (Vars.players == 5)
                            {
                                Vars.tracker = int.Parse(Vars.tracker) - 1;
                            }
                        }
                        yield return text(Vars.tracker);
                    }
                    yield return text(" and the ");
                    yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                    yield return text(" token one space to the left. ");
                    using (styleScope("italic", true))
                    {
                        yield return text("Pass the Starting Player token as normal.");
                    }
                    yield return text(" ");
                    if (Vars.players == 3)
                    {
                        yield return text("Then, since this is a 3 player game, pass the starting player marker clockwise 1 " +
                    "additional time.");
                    }
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("Place a ");
                    yield return text("<sprite=\"Storybook\" index=0>");
                    yield return text(" token directly on top of the ");
                    yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                    yield return text(" token.");
                    yield return lineBreak();
                    yield return lineBreak();
                    using (styleScope("bold", true))
                    {
                        //yield return text("SPECIAL SETUP");
                    }
                    Vars._SetupImage = "S1_Suspicious_Building";
                    //yield return text(" ");
                    //yield return lineBreak();
                    if (Vars.exposeA > 0)
                    {
                        yield return text("Place the ");
                        yield return text(Vars.ba);
                        yield return text(" tile over spot A on the Village Chronicle. ");
                        yield return lineBreak();
                    }
                    if (Vars.exposeB > 0)
                    {
                        yield return text("Place the ");
                        yield return text(Vars.bb);
                        yield return text(" tile over spot B on the Village Chronicle. ");
                        yield return lineBreak();
                    }
                    if (Vars.exposeC > 0)
                    {
                        yield return text("Place the ");
                        yield return text(Vars.bc);
                        yield return text(" tile over spot C on the Village Chronicle. ");
                        yield return lineBreak();
                    }
                    yield return lineBreak();
                    yield return text("Return all other Exposed Building tiles to the scenario box.");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Acceptance");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Caretaker pieces can now take actions in Town as well as in the Estates. ");
                using (styleScope("italic", true))
                {
                    yield return text("The same Town placement rules for Servants apply to Caretaker pieces.");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("School for Hybridized Individuals");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When a player visits the ");
                using (styleScope("bold", true))
                {
                    yield return text("School for Hybridized Individuals");
                }
                yield return text(", they ");
                using (styleScope("bold", true))
                {
                    yield return text("pay $1");
                }
                yield return text(" to gain a ");
                using (styleScope("bold", true))
                {
                    yield return text("Caretaker");
                }
                yield return text(" piece from Lost. ");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Experiments are Feared");
                }
            }
            using (styleScope("hubDetails", true))
            {
                yield return text("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" ");
                using (styleScope("bold", true))
                {
                    yield return text("Angry Mob");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Any time the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token moves, move the Storybook token along with it. If the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" overtakes a player, complete the current action and then ");
                yield return link("click here for a Storybook message.", "AngryMobStorybook", null);

                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "WolvesEco-Friendly", null);
                using (styleScope("hook", "h000011900"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h000011900", HarloweEnchantCommand.Replace, passage119_Fragment_0));
            }
            yield return lineBreak();
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            if (Vars.gen3pg == 0 || Vars.gen3pg == "")
            {
                using (styleScope("setupStyle", true))
                {
                    using (styleScope("bold", true))
                    {
                        //yield return text("SETUP");
                    }
                    Vars._SetupImage = "AngryMobSetup1";
                    yield return text("Turn to page ");
                    using (styleScope("bold", true))
                    {
                        yield return text("15");
                    }
                    yield return text(" of the Village Chronicle. Place the 2 ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Engineering Master\'s Study");
                    }
                    yield return text(" tiles into play near the other Vanity Estate Upgrades. The Suspicion Marker rema" +
                    "ins in the same space and the ");
                    yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                    yield return text(" token is reset 1 space to the left. ");
                    using (styleScope("italic", true))
                    {
                        yield return text("Pass the Starting Player token as normal.");
                    }
                    yield return text(" ");
                    if (Vars.players == 3)
                    {
                        yield return text("Then, since this is a 3-player game, pass the starting player marker clockwise 1 " +
                    "additional time.");
                    }
                    yield return lineBreak();
                    yield return lineBreak();
                    if (Vars.exposeA > 0)
                    {
                        yield return text("Place the ");
                        yield return text(Vars.ba);
                        yield return text(" tile over spot A on the Village Chronicle. ");
                        yield return lineBreak();
                    }
                    if (Vars.exposeB > 0)
                    {
                        yield return text("Place the ");
                        yield return text(Vars.bb);
                        yield return text(" tile over spot B on the Village Chronicle. ");
                        yield return lineBreak();
                    }
                    if (Vars.exposeC > 0)
                    {
                        yield return text("Place the ");
                        yield return text(Vars.bc);
                        yield return text(" tile over spot C on the Village Chronicle. ");
                        yield return lineBreak();
                    }
                    yield return lineBreak();
                    yield return text("Return all other Exposed Building tiles to the scenario box.");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Hunter\'s Haven");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("For each visit to the Hunter\'s Haven, pay 1 Occult Knowledge cube to lose 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(". ");
                using (styleScope("italic", true))
                {
                    yield return text("(You cannot use Journaled Knowledge to pay this cost.)");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Engineering Achievement");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When you gain a Vanity Estate Upgrade, the ");
                using (styleScope("bold", true))
                {
                    yield return text("Engineering Master\'s Study");
                }

                yield return text(" is part of the available pool to build as normal.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Endless Hunt");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("At the end of the round, two of the scientists will be chosen to participate in t" +
            "he ");
                using (styleScope("bold", true))
                {
                    yield return text("Night of the Hunt.");
                }
                yield return text(" This invitation cannot be refused.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "CharityAwardGood", null);
                using (styleScope("hook", "h000011901"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h000011901", HarloweEnchantCommand.Replace, passage119_Fragment_1));
                yield return lineBreak();
            }
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Prosperity2   (passage120)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 13335-13538
// Links:  AngryMobStorybook,GoodFrenzyEvent,CureMoonSick1
// Aborts: -
// Round end -> GoodFrenzyEvent, CureMoonSick1
// Purpose: "Moving Forward - Middle Years" HUB rules screen
// ###################################################################

    void passage120_Init()
    {
        this.Passages[@"Prosperity2"] = new StoryPassage(@"Prosperity2", new string[] { }, passage120_Main);
    }

    IStoryThread passage120_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Moving Forward - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 14;
        yield return lineBreak();
        if (Vars.society == "Order of St. Hubertus")
        {
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Acceptance");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Caretaker pieces can now take actions in Town as well as in the Estates. ");
                using (styleScope("italic", true))
                {
                    yield return text("The same Town placement rules for Servants apply to Caretaker pieces.");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("School for Hybridized Individuals");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When a player visits the ");
                using (styleScope("bold", true))
                {
                    yield return text("School for Hybridized Individuals");
                }
                yield return text(", they ");
                using (styleScope("bold", true))
                {
                    yield return text("pay $1");
                }
                yield return text(" to gain a ");
                using (styleScope("bold", true))
                {
                    yield return text("Caretaker");
                }
                yield return text(" piece from Lost. ");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Experiments are Feared");
                }
            }
            using (styleScope("hubDetails", true))
            {
                yield return text("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Farmer\'s Market");
                }
            }
            using (styleScope("hubDetails", true))
            {
                yield return text("Due to the associated social stigma, the Farmer\'s Market now acts as a Creepy loc" +
                "ation. When you visit the Farmer\'s Market also ");
                using (styleScope("bold", true))
                {
                    yield return text("gain 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
            }
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Angry Mob");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Any time the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token moves, move the ");
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" token along with it. If the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token overtakes a player, complete the current action and then ");
                yield return link("click here for a Storybook message.", "AngryMobStorybook", null);
                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "GoodFrenzyEvent", null);
                using (styleScope("hook", "h00001200"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h00001200", HarloweEnchantCommand.Replace, passage120_Fragment_0));
            }
            yield return lineBreak();
            yield return lineBreak();
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Hunter\'s Haven");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("For each visit to the Hunter\'s Haven, pay 1 Occult Knowledge cube to lose 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(". ");
                using (styleScope("italic", true))
                {
                    yield return text("(You cannot use Journaled Knowledge to pay this cost.)");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Engineering Achievement");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When you gain a Vanity Estate Upgrade, the ");
                using (styleScope("bold", true))
                {
                    yield return text("Engineering Master\'s Study");
                }
                yield return text(" is part of the available pool to build as normal.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Endless Hunt");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("At the end of the round, two of the scientists will be chosen to participate in t" +
                "he ");
                using (styleScope("bold", true))
                {
                    yield return text("Night of the Hunt.");
                }
                yield return text(" This invitation cannot be refused.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "CureMoonSick1", null);
                using (styleScope("hook", "h00001201"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h00001201", HarloweEnchantCommand.Replace, passage120_Fragment_1));

            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage120_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Prosperity2", "GoodFrenzyEvent");
        yield break;
    }

    IStoryThread passage120_Fragment_1()
    {
        PassageTracker.instance.CheckProgress("Prosperity2", "CureMoonSick1");
        yield break;
    }

// ###################################################################
// PASSAGE: Prosperity3   (passage121)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 13543-13738
// Links:  AngryMobStorybook,Scoring
// Aborts: -
// Round end -> Scoring, Scoring
// Purpose: "Moving Forward - Late Years" HUB incl. Scientific Achievement Master's Study unlocks
// ###################################################################

    void passage121_Init()
    {
        this.Passages[@"Prosperity3"] = new StoryPassage(@"Prosperity3", new string[] { }, passage121_Main);
    }

    IStoryThread passage121_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Moving Forward - Late Years");
        }
        yield return lineBreak();
        Vars.round = 15;
        yield return lineBreak();
        if (Vars.society == "Order of St. Hubertus")
        {
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Acceptance");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Caretaker pieces can now take actions in Town as well as in the Estates. ");
                using (styleScope("italic", true))
                {
                    yield return text("The same Town placement rules for Servants apply to Caretaker pieces.");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("School for Hybridized Individuals");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When a player visits the ");
                using (styleScope("bold", true))
                {
                    yield return text("School for Hybridized Individuals");
                }
                yield return text(", they ");
                using (styleScope("bold", true))
                {
                    yield return text("pay $1");
                }
                yield return text(" to gain a ");
                using (styleScope("bold", true))
                {
                    yield return text("Caretaker");
                }
                yield return text(" piece from Lost. ");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Experiments are Feared");
                }
            }
            using (styleScope("hubDetails", true))
            {
                yield return text("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Farmer\'s Market");
                }
            }
            using (styleScope("hubDetails", true))
            {
                yield return text("Due to the associated social stigma, the Farmer\'s Market now acts as a Creepy loc" +
                "ation. When you visit the Farmer\'s Market also ");
                using (styleScope("bold", true))
                {
                    yield return text("gain 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
            }
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Angry Mob");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Any time the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token moves, move the ");
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" token along with it. If the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token overtakes a player, complete the current action and then ");
                yield return link("click here for a Storybook message.", "AngryMobStorybook", null);
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Scientific Achievement");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When you gain a Vanity Estate Upgrade, all remaining <b>Master\'s Study</b> tiles are part of the" +
            " available pool to build as normal <i>(not Occult)</i>.");
                yield return lineBreak();
                yield return lineBreak();
                Vars.ending = "END-WolvesGood1";
                //yield return link("Click at the end of the Generation to continue to Final Scoring...", "Scoring", null);
                using (styleScope("hook", "h00001210"))
                    yield return link("Click at the end of the Generation to continue to Final Scoring...", null, () => enchantHook("h00001210", HarloweEnchantCommand.Replace, passage121_Fragment_0));
            }
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Hunter\'s Haven");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("For each visit to the Hunter\'s Haven, pay 1 Occult Knowledge cube to lose 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(". ");
                using (styleScope("italic", true))
                {
                    yield return text("(You cannot use Journaled Knowledge to pay this cost.)");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("Scientific Achievement");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When you gain a Vanity Estate Upgrade, all remaining <b>Master\'s Study</b> tiles are part of the" +
            " available pool to build as normal <i>(not Occult)</i>.");
                yield return lineBreak();
                yield return lineBreak();
                Vars.ending = "END-HunterGood1";
                //yield return link("Click at the end of the Generation to continue to Final Scoring...", "Scoring", null);
                using (styleScope("hook", "h00001211"))
                    yield return link("Click at the end of the Generation to continue to Final Scoring...", null, () => enchantHook("h00001211", HarloweEnchantCommand.Replace, passage121_Fragment_1));

            }
        }
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage121_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Prosperity3", "Scoring");
        yield break;
    }

    IStoryThread passage121_Fragment_1()
    {
        PassageTracker.instance.CheckProgress("Prosperity3", "Scoring");
        yield break;
    }

// ###################################################################
// PASSAGE: LycanGood   (passage181)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21320-21374
// Links:  Prosperity1
// Aborts: -
// Purpose: Grants the Lycanthropic Strength Masterwork Update once werewolves are proven real
// ###################################################################

    void passage181_Init()
    {
        this.Passages[@"LycanGood"] = new StoryPassage(@"LycanGood", new string[] { }, passage181_Main);
    }

    IStoryThread passage181_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Strength Can Be Mine");
        }
        yield return lineBreak();
        yield return text("Their existence was proven. Now could the catalyst for this truly powerful transf" +
            "ormation be replicated? And how could it be further strengthened?");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage181_Fragment_1);
        using (styleScope("hook", "h000181"))
            yield return link("Click to continue...", null, () => enchantHook("h000181", HarloweEnchantCommand.Replace, passage181_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage181_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Prosperity1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MWUpdateLycanthropic";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Lycanthropic Strength");
            }
            yield return text(" ");
            yield return text("Update card from the scenario box and give it to the player working towards this " +
                "Masterwork.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Prosperity1", null);
        yield break;
    }

    IStoryThread passage181_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage181_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: GoodConsequences   (passage182)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21379-21461
// Links:  Evilsforgive
// Aborts: -
// Purpose: Wolf-town resents the experiments; Creepy token on every Perform Experiment action
// ###################################################################

    void passage182_Init()
    {
        this.Passages[@"GoodConsequences"] = new StoryPassage(@"GoodConsequences", new string[] { }, passage182_Main);
    }

    IStoryThread passage182_Main()
    {
        //if (Vars.society == "Order of St. Hubertus")
        //{
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The Consequences of Being Good");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The sizzle of concentrated electricity, the sounds of agonized screams, the occasional plume of putrid smoke and teeth-rattling explosion; while these sounds were commonplace to hear emanating from the hilltop residences, they were nevertheless an increasing source of tension between the family's important research and the townsfolk. And while their etiquette would never allow them to directly address the issue, the lycanthropic citizens bristled at each frightening experiment all the same.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The town was desperate to move forward and they could not stomach the cousins\' am" +
        "bitions, which only served to dredge up the weight of guilt over their tortured " +
        "pasts.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage182_Fragment_1);
        using (styleScope("hook", "h000182"))
            yield return link("Click to continue...", null, () => enchantHook("h000182", HarloweEnchantCommand.Replace, passage182_Fragment_0));
        //}
        yield break;
    }

    IStoryThread passage182_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Evilsforgive";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" ");
                yield return text("tokens");
            }
            yield return text(" ");
            yield return text("from the scenario box. Each player must place a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the Perform Experiment Action in their Estate.");
            //yield return lineBreak();
            //yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Every time a Perform Experiment Action is taken, that player will move forward 1 " +
                "space on the ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("Track ");
            using (styleScope("italic", true))
            {
                yield return text("(in addition to any other printed effects)");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Evilsforgive", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage182_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage182_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: GoodNote-Goals    (passage197)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22532-22701
// Links:  Wolves1
// Aborts: -
// Purpose: DEV NOTE: "good" Gen3 branch goals + Master's Study setup
// ###################################################################

    void passage197_Init()
    {
        this.Passages[@"GoodNote-Goals "] = new StoryPassage(@"GoodNote-Goals ", new string[] { }, passage197_Main);
    }

    IStoryThread passage197_Main()
    {
        yield return text("Good Goals -");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("NOTE: If we do ever add a 5th player, the HUNT on this leg is not coded for 5 pla" +
            "yers.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("BONUS - Place an End-game goal if one of the Buildings that was Concealed.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Equity - Players that are behind are given a little boost.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.society == "Order of St. Hubertus")
        {
        }
        yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Monsters - REAL");
        yield return lineBreak();
        yield return text("Want to spread a message of love and peace to the outside world. They are eco-fri" +
            "endly. They built their own University.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("They want us to stop our Experimentations. Maybe we add a Creepy token to our Exp" +
            "eriment action.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Maybe we can take an action to be a real swell individual and help out with a min" +
            "i narrative and lose our Creepy.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Biology Experiments Encouraged");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("put a storybook token on the Angy Mob token.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Perhaps we should start a FRENZY in town.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hunters - MONSTERS ARE REAL    XXXXXXXXXXXXXXXXx");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("What if we just sent all the Hunters to their valiant deaths. That\'d deal with th" +
            "e problem, probably. Right?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("1st round, have the option to doubt. VOTE");
        yield return lineBreak();
        yield return text("You are punished as a group for being wrong (Estate Upgrades).");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Sponsor Holy relics & weapons. Maybe send someone out into the hills to kill stuf" +
            "f - mini-game.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Give resources and knowledge to win battles. Or let the hero die.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Engineering Experiments encouraged.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Award a different Area of normal Scientific expertise to each player.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            //yield return text("SPECIAL SETUP");
        }
        yield return lineBreak();
        yield return text("Retrieve the ");
        using (styleScope("bold", true))
        {
            yield return text("Master\'s Study");
        }
        yield return text(" ");
        yield return text("Vanity Estate upgrade tiles.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Choose:");
        }
        yield return lineBreak();
        yield return text("Starting with the player in Last place and continuing in ascending order by point" +
            " total, each player chooses a Master\'s Study tile and adds it to their Estate. N" +
            "o additional cost is paid if a new");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("<<<<<<<<<<<<<<<<Note this.");
        yield return lineBreak();
        if (Vars.aide == "yes")
        {
            yield return link("Click to continue...", "Wolves1", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Monsters come to work for you.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Choose one of the following options:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Lose ");
        using (styleScope("bold", true))
        {
            yield return text("1VP");
        }
        yield return text(", but gain a servant type.");
        yield return lineBreak();
        yield return text("OR");
        yield return lineBreak();
        yield return text("Gain your choice of a ");
        using (styleScope("bold", true))
        {
            yield return text("Body");
        }
        yield return text(" ");
        yield return text("or an ");
        using (styleScope("bold", true))
        {
            yield return text("Animal");
        }
        yield return text(" ");
        yield return text("resource.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Unimplemented Ideas:");
        yield return lineBreak();
        yield return text("If cured. Choose another player. You will eat their Servant.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            //yield return text("SPECIAL SETUP");
        }
        yield return lineBreak();
        yield return text("Any player that had joined the opposite side gains Ingredients equal to the total" +
            " number of tokens given to players.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Stray line - Even the disfigurements of the lowly caretakers were met with indiff" +
            "erence by the local populace.");
        yield break;
    }

// ###################################################################
// PASSAGE: CharityAwardGood   (passage207)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23463-23539
// Links:  CureMoonSick1
// Aborts: -
// Purpose: Private award to the charity leader: free Personal Library, Heart token returned
// ###################################################################

    void passage207_Init()
    {
        this.Passages[@"CharityAwardGood"] = new StoryPassage(@"CharityAwardGood", new string[] { }, passage207_Main);
    }

    IStoryThread passage207_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to ");
            yield return text(Vars.charity);
            yield return text(". This passage is read out loud in view of all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Consideration of Righteousness");
        }
        yield return lineBreak();
        yield return text("The Fraternity was correct to be cautious in their dealings with the eccentric fa" +
            "mily whose ominous visitings within the city carried a sinister air about them. " +
            "However, their fears could not completely overshadow their righteous convictions" +
            ".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("III\'s familial legacy of ");
        using (styleScope("bold", true))
        {
            yield return text("charity");
        }
        yield return text(" ");
        yield return text(@"was instrumental in sharing the gift of knowledge. Modern weaponry had transformed the Hunter's ability to fight against the evil forces threatening to overtake the city. And it was this malignant sentiment that forced their hand to offer a token of their appreciation.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage207_Fragment_1);
        using (styleScope("hook", "h000207"))
            yield return link("Click to continue...", null, () => enchantHook("h000207", HarloweEnchantCommand.Replace, passage207_Fragment_0));
        yield break;
    }

    IStoryThread passage207_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "CureMoonSick1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_EstateUpgradeBACK";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Personal Library");
            }
            yield return text(" ");
            yield return text("Estate Upgrade from the scenario box. You may immediately build it in the next em" +
                "pty plot on your Estate board at no additional cost. Then, return the Heart <sprite=\"S1_HeartToken\" index=0> to" +
                "ken to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "CureMoonSick1", null);
        yield break;
    }

    IStoryThread passage207_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage207_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: MayoralAward   (passage208)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23544-23642
// Links:  Prosperity2
// Aborts: -
// Purpose: Private award for the librarian lineage: Personal Library, free Knowledge per Experiment
// ###################################################################

    void passage208_Init()
    {
        this.Passages[@"MayoralAward"] = new StoryPassage(@"MayoralAward", new string[] { }, passage208_Main);
    }

    IStoryThread passage208_Main()
    {
        if (Vars.building == "library")
        {
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Carefully hand the Storybook to ");
                yield return text(Vars.mayor);
                yield return text(" ");
                yield return text("III. This passage is read out loud in view of all players.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("The Benefit of Knowledge");
            }
            yield return lineBreak();
            yield return text(@"The path to enlightenment is a not without its humble beginnings, and the creatures that now embraced a gentler path could not have done so without an intense pursuit of knowledge. The deviant machinations of a cruel world may have doomed them to these egregious forms, but to find peace with one's self is a struggle all beings face.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The townsfolk appreciated ");
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("III\'s lineage as partly responsible for spearheading the gift of ");
            using (styleScope("bold", true))
            {
                yield return text("knowledge");
            }
            yield return text(" ");
            yield return text("above all else in the generations past. They desire to repay this Librarian linea" +
            "ge with a contribution of their own.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage208_Fragment_1);
            using (styleScope("hook", "h000208"))
                yield return link("Click to continue...", null, () => enchantHook("h000208", HarloweEnchantCommand.Replace, passage208_Fragment_0));
        }
        else
        {
            yield return abort(goToPassage: "WolvesBankMayorGood");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage208_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "ResolveCharityWolves";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_EstateUpgradeBACK";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Personal Library");
            }
            yield return text(" ");
            yield return text("Estate Upgrade from the scenario box. You may immediately build it in the next em" +
                "pty plot on your Estate board at no additional cost. Then, return the <b>Commemorat" +
                "ive Mayoral Coin</b> to the box.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Whenever you take the Perform Experiment action, the ");
            using (styleScope("bold", true))
            {
                yield return text("Personal Library");
            }
            yield return text(" ");
            yield return text("provides one free Knowledge of your choice from the supply. This Knowledge can be" +
                " used immediately towards the cost of Performing that Experiment.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Prosperity2", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage208_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage208_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: EquitableValues   (passage212)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23912-24004
// Links:  LycanMessageGood
// Aborts: -
// Purpose: Democratic equity: lowest-VP players recover a Servant, leader gains 2 Creepy
// ###################################################################

    void passage212_Init()
    {
        this.Passages[@"EquitableValues"] = new StoryPassage(@"EquitableValues", new string[] { }, passage212_Main);
    }

    IStoryThread passage212_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Deplorable Equity");
        }
        Vars.gen3pg = 0;
        yield return lineBreak();
        yield return text("For the first time in decades, the townsfolk expressed a sense of community, a si" +
            "ngular and modern identity. ");
        if (Vars.society == "Order of St. Hubertus")
        {
            yield return text("The Order of St. Hubertus remained an official moniker, but a new, more democrati" +
            "c society emerged. The secrets that had remained hidden for so long had finally " +
            "been exposed and the sense of freedom was finally something worth protecting.");
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            yield return text("While members of the Fraternity attended to their dark business, sharpening their" +
            " skills and weapons on their own, the town remained resolute in their ability to" +
            " rid the surrounding hills of evil.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Unlike previous generations that were keen to allow an aloof eccentric to isolate themselves amongst the rocky crags at the valley's edge, the townsfolk became determined in their attempts to ingratiate the obstinate cousins into the fold. While the reception was always cold and the iron gates and foreboding wooden doorways were mostly closed to them, they never stopped trying.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While they would never admit to it, the ones who were most desperate tended to ac" +
            "cept the offers more readily.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage212_Fragment_1);
        using (styleScope("hook", "h000212"))
            yield return link("Click to continue...", null, () => enchantHook("h000212", HarloweEnchantCommand.Replace, passage212_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage212_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "LycanMessageGood";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The ");
            if (Vars.players <= 3)
            {
                yield return text("player with the fewest VP gains 1");
            }
            if (Vars.players >= 4)
            {
                using (styleScope("bold", true))
                {
                    yield return text("2");
                }
                yield return text(" players with the fewest VP gain 1");
            }
            yield return text(" ");
            yield return text("of their Servants from Lost. ");
            using (styleScope("italic", true))
            {
                yield return text("Ties are broken by the player who went last in the previous round.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The player with the most points gains 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "LycanMessageGood", null);
        yield break;
    }

    IStoryThread passage212_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage212_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: LycanMessageGood   (passage213)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24009-24058
// Links:  Prosperity1
// Aborts: -
// Purpose: Checks for the Lycanthropic Strength Masterwork; returns to Prosperity1
// ###################################################################

    void passage213_Init()
    {
        this.Passages[@"LycanMessageGood"] = new StoryPassage(@"LycanMessageGood", new string[] { }, passage213_Main);
    }

    IStoryThread passage213_Main()
    {
        if (Vars.wolves == "good")
        {
            using (styleScope("bold", true))
            {
                yield return text("The Form of the Wolf");
            }
            yield return lineBreak();
            yield return text("Though the sight had now become commonplace, confirming the existence of persons " +
            "with the ability to change into an animal form had remarkable consequences. It i" +
            "s possible that it even disrupted the studies of one of our kin.");
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Does any player have the ");
            using (styleScope("bold", true))
            {
                yield return text("Lycanthropic Strength");
            }
            yield return text(" ");
            yield return text("Masterwork Experiment?");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00176"))
                yield return link("Yes.", null, () => enchantHook("h00176", HarloweEnchantCommand.Replace, passage213_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            yield return link("No.", "Prosperity1", null);
            yield return lineBreak();
        }
        else
        {
            yield return abort(goToPassage: "Prosperity1");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage213_Fragment_0()
    {
        Vars.lycan = "yes";
        yield return abort(goToPassage: "LycanGood");
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesEco-Friendly   (passage214)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24063-24133
// Links:  MayoralAward
// Aborts: -
// Purpose: Reformed monsters turn eco-friendly; Creepy token on the Farmer's Market
// ###################################################################

    void passage214_Init()
    {
        this.Passages[@"WolvesEco-Friendly"] = new StoryPassage(@"WolvesEco-Friendly", new string[] { }, passage214_Main);
    }

    IStoryThread passage214_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Message");
        }
        yield return lineBreak();
        yield return text(@"As the new decade began, the motley parade of beastly horrors had turned their claws from weapons of destruction into instruments of cultivation. They embraced modern amenities and fashions, walking the streets with upright strides as the town continued to thrive.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("For most, however, this new sense of peace was tarnished by the persistence of pa" +
            "st injustices. As newspaper pressings became even more accessible, pamphlets and" +
            " signage began to circulate amongst the populace.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("\"Our brethren; abused, slaughtered, and experimented upon. No more! We can bear t" +
            "his injustice no longer.\" One paper stated, \"Meat is murder.\"");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Most had adopted a Pythagorean diet, developing a keen culinary taste for vegetable curries and rich, barley porridge. While it was not strictly forbidden to consume the cooked flesh of domestic animals, when the cousins' town business included a stop by the Farmer's Market, the townsfolk looked away in horror, mothers shielding their furred children's eyes as the implication was too much for them to bear.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Yet still roiling beneath the thin veneer of prim etiquette, a baser nature threa" +
            "tened to reemerge anew.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage214_Fragment_1);
        using (styleScope("hook", "h000214"))
            yield return link("Click to continue...", null, () => enchantHook("h000214", HarloweEnchantCommand.Replace, passage214_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage214_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.building == "library" ? "MayoralAward" : "WolvesBankMayorGood";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Put a ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token on the ");
            using (styleScope("bold", true))
            {
                yield return text("Farmer\'s Market");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "MayoralAward", null);
        yield break;
    }

    IStoryThread passage214_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage214_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: AngryMobStorybook   (passage215)
// Tags: ck2
// Source: TheCostofDiseaseEng.cs lines 24138-24281
// Links:  -
// Aborts: -
// Purpose: Angry-Mob flavor vignettes triggered when the mob token advances
// ###################################################################

    void passage215_Init()
    {
        this.Passages[@"AngryMobStorybook"] = new StoryPassage(@"AngryMobStorybook", new string[] { "ck2", }, passage215_Main);
    }

    IStoryThread passage215_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Frightful Day");
        }
        yield return lineBreak();
        Vars.amtoken = macros1.either(1, 2);
        Vars.gen3pg = 1;
        yield return lineBreak();
        if (Vars.amtoken == 1)
        {
            yield return text("There were moments when the rage amongst the townsfolk would well up and explode " +
            "in uncontrollably violent outbursts. For the monsters of ");
            yield return text(Vars.townname);
            yield return text(", these were no longer represented by torches or pitchforks held high, but by a f" +
            "everish bloodlust.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("As such, it was a calm Sunday afternoon when a local werewolf doffed his cap and " +
            "interrupted tea time by holding up a blood-stained and torn piece of fabric.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("He placed the scrap onto the table. \"We would return the body to you for proper b" +
            "urial if it were still possible,\" he shrugged, his ears flattening. \"But, you kn" +
            "ow how it goes when bones are involved. Sorry.\"");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Another good servant gone. It was somewhat inevitable, yet still an unfortunate l" +
            "oss of life, time and money.");
        }
        //if (Vars.amtoken == 2)
        else
        {
            yield return text("To be awakened early morning after a late night\'s work was agitating, but to awak" +
            "e to a shrill, blood-curdling scream was something else entirely.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"A woman in a modest blue dress crouched near the entrance to the estate, her blood-covered maw held within two clawed hands as she wailed in distress. A few feet away, two wolves clad in sharp business suits huddled over the dead body of a servant, tearing into the flesh with their teeth and claws as fresh blood flowed down the gravel drive.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("A monster stood nearby, clearly resisting the urge to join into the fray. He fixe" +
            "d his tie and wiped away saliva from his chin before speaking in a solemn voice." +
            " \"Poor thing couldn\'t control herself. Took the first bite. Terrible tragedy. Aw" +
            "fully sorry.\"");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Perhaps it was unavoidable that the close proximity of humanity to the beasts wou" +
            "ld incite such an event.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to return...", passage215_Fragment_2);
        using (styleScope("hook", "h000215"))
            yield return link("Click to continue...", null, () => enchantHook("h000215", HarloweEnchantCommand.Replace, passage215_Fragment_1));
        yield break;
    }

    IStoryThread passage215_Fragment_0()
    {
        if (Vars.round == 13)
        {
            yield return abort(goToPassage: "Prosperity1");
        }
        else if (Vars.round == 14)
        {
            yield return abort(goToPassage: "Prosperity2");
        }
        //if (Vars.round == 15)
        else
        {
            yield return abort(goToPassage: "Prosperity3");
        }
        yield break;
    }

    IStoryThread passage215_Fragment_1()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 13 ? "Prosperity1" : Vars.round == 14 ? "Prosperity2" : "Prosperity3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Return a Servant to Lost. ");
            if (Vars.round == 15)
            {
                yield return text("Then lose ");
                using (styleScope("bold", true))
                {
                    yield return text(macros1.either(2, 3));
                    yield return text("VP");
                }
                yield return text(".");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Move your ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("token ");
            using (styleScope("bold", true))
            {
                yield return text("2 spaces");
            }
            yield return text(" ");
            yield return text("to the left. Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token ");
            using (styleScope("bold", true))
            {
                yield return text("3 spaces");
            }
            yield return text(" ");
            yield return text("to the right ");
            using (styleScope("italic", true))
            {
                yield return text("(or as far as possible)");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00177"))
        //    yield return link("Click to return...", null, () => enchantHook("h00177", HarloweEnchantCommand.Replace, passage215_Fragment_0));
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage215_Fragment_2()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage215_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: GoodFrenzyEvent   (passage216)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24286-24319
// Links:  2p-FrenzyALT,GoodFrenzyEvent2
// Aborts: -
// Purpose: Proposal to hold a sanctioned monster "Frenzy"; branches to the vote variants
// ###################################################################

    void passage216_Init()
    {
        this.Passages[@"GoodFrenzyEvent"] = new StoryPassage(@"GoodFrenzyEvent", new string[] { }, passage216_Main);
    }

    IStoryThread passage216_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Reasoned Proposal");
        }
        yield return lineBreak();
        yield return text(@"While the system of progressive monster reform was altruistic, it was not without its imperfections. Infractions ranging from minor maulings to severe interdental jugular removal were noted over the years, as were the manic episodes associated with these incidents.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It was clear that humans were marginally upset about the lack of livestock and uptick in missing persons potentially consumed by wolves. It was also clear that each monster would experience near daily urges to indulge in profane behavior that they were forced to suppress.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Perhaps, they suggested, if they could attempt to indulge their darker urges in a" +
            " safe space where this expression was fully encouraged, then it would pacify tho" +
            "se urges at other more domestic times.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players == 2)
        {
            yield return link("Click here to continue...", "2p-FrenzyALT", null);
        }
        else
        {
            yield return link("Click here to continue...", "GoodFrenzyEvent2", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: YesFrenzy   (passage217)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24325-24364
// Links:  -
// Aborts: -
// Purpose: The Frenzy happens; the town descends into permanent bloodlust
// ###################################################################

    void passage217_Init()
    {
        this.Passages[@"YesFrenzy"] = new StoryPassage(@"YesFrenzy", new string[] { }, passage217_Main);
    }

    IStoryThread passage217_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The FRENZY");
        }
        yield return lineBreak();
        yield return text("The townsfolk who chose not to participate locked their doors and boarded their w" +
            "indows, but the first howls of ghoulish delight sent those same individuals claw" +
            "ing at the walls to be released into the wild again. The Frenzy spared no person" +
            " in ");
        yield return text(Vars.townname);
        yield return text(@". The unhinged spectacle set the teeth gnashing and a passionate fire blazing both metaphorically and physically, plumes of hot embers erupting upwards from homes set ablaze with wild abandon. When a door burst open or a window shattered, barely a strangled cry could be heard before another victim's fresh blood spilled into the streets.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Indulging in latent urges proved not to quell the dormant urges of the citizenry, but to stoke it. In the coming weeks, the logical faculties of the changed townfolk were removed. And in its place, a well of anger and a bloodlust so acute it left the landscape to darken and the soil to sour!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The thin line between civility and savagery had been severed. The monsters were s" +
            "et loose to prowl the region and invoke their hideous reign upon the unsuspectin" +
            "g masses.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00178"))
            yield return link("Click to continue...", null, () => enchantHook("h00178", HarloweEnchantCommand.Replace, passage217_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage217_Fragment_0()
    {
        Vars.frenzy = "yes";
        yield return abort(goToPassage: "Prosperity3b");
        yield break;
    }

// ###################################################################
// PASSAGE: NoFrenzy   (passage218)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24369-24443
// Links:  -
// Aborts: -
// Purpose: Frenzy declined; Chemistry/Engineering Master's Study vanity upgrades unlocked
// ###################################################################

    void passage218_Init()
    {
        this.Passages[@"NoFrenzy"] = new StoryPassage(@"NoFrenzy", new string[] { }, passage218_Main);
    }

    IStoryThread passage218_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Reasoned Response");
        }
        yield return lineBreak();
        yield return text("The recommendation was accepted with gravitas. While many remained wistful, the g" +
            "roup\'s almost immediate adoption of the concept made it clearly a dangerous prop" +
            "osition.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("To further preoccupy their minds and to quell the bloodlust just beneath the surf" +
            "ace, they offered further building assistance to reinforce a wider variety of sc" +
            "ientific disciplines.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage218_Fragment_2);
        using (styleScope("hook", "h000218"))
            yield return link("Click to continue...", null, () => enchantHook("h000218", HarloweEnchantCommand.Replace, passage218_Fragment_1));
        yield break;
    }

    IStoryThread passage218_Fragment_0()
    {
        Vars.frenzy = "no";
        yield return abort(goToPassage: "Prosperity3");
        yield break;
    }

    IStoryThread passage218_Fragment_1()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Prosperity3";
        Vars.frenzy = "no";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MastersStudy";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Chemistry");
            }
            yield return text(" ");
            yield return text("and ");
            using (styleScope("bold", true))
            {
                yield return text("Engineering Master\'s Study");
            }
            yield return text(" ");
            yield return text("Vanity Estate Upgrades from the scenario box and place them nearby. Any time you " +
                "gain a Vanity Estate Upgrade, you may choose to gain 1 of these instead.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00179"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00179", HarloweEnchantCommand.Replace, passage218_Fragment_0));
        yield break;
    }

    IStoryThread passage218_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage218_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: Evilsforgive   (passage230)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25438-25638
// Links:  EquitableValues
// Aborts: -
// Purpose: Town meeting: monsters offer reconciliation; retrieves Master's Study tiles
// ###################################################################

    void passage230_Init()
    {
        this.Passages[@"Evilsforgive"] = new StoryPassage(@"Evilsforgive", new string[] { }, passage230_Main);
    }

    IStoryThread passage230_Main()
    {
        if (Vars.society == "Order of St. Hubertus")
        {
            using (styleScope("bold", true))
            {
                yield return text("Forgiveness");
            }
            yield return lineBreak();
            yield return text(@"The scientists' doubts were put at ease when a werewolf in a brown sack suit took to the podium to preside over a town meeting. A mixture of lycanthropic beings, horned beasts, and those still holding onto their humanity were in attendance outside the school. The force of the wolf's words caused tears to stream down their cheeks.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"""We want to shatter those unfortunate stereotypes. We hold no grudges. We want to work with you all, not against you. The child should not be punished for the sins of the father. You are all welcome."" The werewolf blew their cold nose into their handkerchief as a rumbling cheer rose from the crowd.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("As a token of this myth-shattering event, many handshakes were exchanged that day" +
            " and a promise was made to press forward into a more modern era; an era where sc" +
            "ience could improve their lives ten-fold!");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage230_Fragment_1);
            using (styleScope("hook", "h00023001"))
                yield return link("Click to continue...", null, () => enchantHook("h00023001", HarloweEnchantCommand.Replace, passage230_Fragment_0));
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            if (Vars.hcount == 0)
            {
                yield return abort(goToPassage: "EquitableValues");
            }
            else
            {
                using (styleScope("bold", true))
                {
                    yield return text("Still Wary");
                }
                yield return lineBreak();
                yield return text(@"In the evenings, the Fraternity gathered in the former Town Hall and celebrated their political takeover of the small town. Observers could hear their loud revelry echo through the streets late into the night. The townsfolk had no reason to doubt their loyalty as it appeared that their activities kept both sickness and superstitions at bay.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("For the family members that had aided them in their efforts, they wore wide false" +
                "-smiles and offered toasts to their continued partnership. But, for those who ha" +
                "d plotted against them, they remained wary.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage230_Fragment_3);
                using (styleScope("hook", "h00023003"))
                    yield return link("Click to continue...", null, () => enchantHook("h00023003", HarloweEnchantCommand.Replace, passage230_Fragment_2));
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "EquitableValues", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage230_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "EquitableValues";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MastersStudy";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Master\'s Study");
            }
            yield return text(" Vanity Estate Upgrade tiles.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Choose:");
            }
            yield return lineBreak();
            yield return text("Starting with the player in last place and continuing in ascending order by point" +
                " total, each player chooses a ");
            using (styleScope("bold", true))
            {
                yield return text("Master\'s Study");
            }
            yield return text(" tile and adds it to their Estate. No additional cost is paid for a new plot to pl" +
                "ace this tile. ");
            using (styleScope("italic", true))
            {
                yield return text("(Ties are broken by the player that went later in turn order in the previous roun" +
                "d.)");
            }
        }
        yield break;
    }

    IStoryThread passage230_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage230_Fragment_0);
        yield break;
    }

    IStoryThread passage230_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "EquitableValues";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            if (Vars.allyA == "wolves")
            {
                yield return text(Vars.nameA);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyB == "wolves")
            {
                yield return text(Vars.nameB);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyC == "wolves")
            {
                yield return text(Vars.nameC);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyD == "wolves")
            {
                yield return text(Vars.nameD);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyE == "wolves")
            {
                yield return text(Vars.nameE);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
            }
            if (!(Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" && Vars.allyD == "wolves" && Vars.allyE == "wolves"))
            {
                yield return text(Vars.nameA);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(".");
            }
            yield return lineBreak();
        }
        yield break;
    }

    IStoryThread passage230_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage230_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: HuntersHUBcode   (passage262)
// Tags: CHECK
// Source: TheCostofDiseaseEng.cs lines 28024-28189
// Links:  -
// Aborts: -
// Purpose: CODE ONLY: shuffles the monster list and reward list for the Hunt mini-game
// ###################################################################

    void passage262_Init()
    {
        this.Passages[@"HuntersHUBcode"] = new StoryPassage(@"HuntersHUBcode", new string[] { "CHECK", }, passage262_Main);
    }

    IStoryThread passage262_Main()
    {
        Vars.mon = macros1.a("Strigoi", "Moon Presence", "Manticore", "Golem", "Wight", "Pricolici", "Troll", "Priest");
        Vars.mon = macros1.shuffled((HarloweSpread)Vars.mon);
        Vars.monster1 = Vars.mon["1st"];
        Vars.monster2 = Vars.mon["2nd"];
        Vars.monster3 = Vars.mon["3rd"];
        Vars.monster4 = Vars.mon["4th"];
        Vars.monster5 = Vars.mon["5th"];
        Vars.monster3 = Vars.mon["6th"];
        Vars.monster4 = Vars.mon["7th"];
        Vars.monster5 = Vars.mon["8th"];
        Vars.rew = macros1.a("Occult Knowledge", "Chemistry Knowledge", "Biology Knowledge", "Engineering Knowledge", "Chemicals", "Animals", "Gears", "$");
        Vars.rew = macros1.shuffled((HarloweSpread)Vars.rew);
        Vars.reward1 = Vars.rew["1st"];
        Vars.reward2 = Vars.rew["2nd"];
        Vars.reward3 = Vars.rew["3rd"];
        Vars.reward4 = Vars.rew["4th"];
        Vars.reward5 = Vars.rew["5th"];
        Vars.reward6 = Vars.rew["6th"];
        Vars.reward7 = Vars.rew["7th"];
        Vars.reward8 = Vars.rew["8th"];
        if (Vars.players == 3)
        {
            Vars.hunttemp = macros1.a(1, 2, 3);
            Vars.hunttemp = macros1.shuffled((HarloweSpread)Vars.hunttemp);
            Vars.hunt1a = Vars.hunttemp["1st"];
            Vars.hunt1b = Vars.hunttemp["2nd"];
            Vars.hunt2a = Vars.hunttemp["3rd"];
            Vars.hunt2b = Vars.hunttemp["2nd"];
        }
        if (Vars.players == 4)
        {
            Vars.hunttemp = macros1.a(1, 2, 3, 4);
            Vars.hunttemp = macros1.shuffled((HarloweSpread)Vars.hunttemp);
            Vars.hunt1a = Vars.hunttemp["1st"];
            Vars.hunt1b = Vars.hunttemp["2nd"];
            Vars.hunt2a = Vars.hunttemp["3rd"];
            Vars.hunt2b = Vars.hunttemp["4th"];
        }
        if (Vars.players == 5)
        {
            Vars.hunttemp = macros1.a(1, 2, 3, 4, 5);
            Vars.hunttemp = macros1.shuffled((HarloweSpread)Vars.hunttemp);
            Vars.hunt1a = Vars.hunttemp["1st"];
            Vars.hunt1b = Vars.hunttemp["2nd"];
            Vars.hunt2a = Vars.hunttemp["3rd"];
            Vars.hunt2b = Vars.hunttemp["4th"];
            Vars.hunt3a = Vars.hunttemp["5th"];
        }
        if (Vars.hunt1a == 1)
        {
            Vars.h1a = Vars.nameA;
        }
        if (Vars.hunt1a == 2)
        {
            Vars.h1a = Vars.nameB;
        }
        if (Vars.hunt1a == 3)
        {
            Vars.h1a = Vars.nameC;
        }
        if (Vars.hunt1a == 4)
        {
            Vars.h1a = Vars.nameD;
        }
        if (Vars.hunt1a == 5)
        {
            Vars.h1a = Vars.nameE;
        }
        if (Vars.hunt1b == 1)
        {
            Vars.h1b = Vars.nameA;
        }
        if (Vars.hunt1b == 2)
        {
            Vars.h1b = Vars.nameB;
        }
        if (Vars.hunt1b == 3)
        {
            Vars.h1b = Vars.nameC;
        }
        if (Vars.hunt1b == 4)
        {
            Vars.h1b = Vars.nameD;
        }
        if (Vars.hunt1b == 5)
        {
            Vars.h1b = Vars.nameE;
        }
        if (Vars.hunt2a == 1)
        {
            Vars.h2a = Vars.nameA;
        }
        if (Vars.hunt2a == 2)
        {
            Vars.h2a = Vars.nameB;
        }
        if (Vars.hunt2a == 3)
        {
            Vars.h2a = Vars.nameC;
        }
        if (Vars.hunt2a == 4)
        {
            Vars.h2a = Vars.nameD;
        }
        if (Vars.hunt2a == 5)
        {
            Vars.h2a = Vars.nameE;
        }
        if (Vars.hunt2b == 1)
        {
            Vars.h2b = Vars.nameA;
        }
        if (Vars.hunt2b == 2)
        {
            Vars.h2b = Vars.nameB;
        }
        if (Vars.hunt2b == 3)
        {
            Vars.h2b = Vars.nameC;
        }
        if (Vars.hunt2b == 4)
        {
            Vars.h2b = Vars.nameD;
        }
        if (Vars.hunt2b == 5)
        {
            Vars.h2b = Vars.nameE;
        }
        if (Vars.hunt1c == 1)
        {
            Vars.h2c = Vars.nameA;
        }
        if (Vars.hunt1c == 2)
        {
            Vars.h2c = Vars.nameB;
        }
        if (Vars.hunt1c == 3)
        {
            Vars.h2c = Vars.nameC;
        }
        if (Vars.hunt1c == 4)
        {
            Vars.h2c = Vars.nameD;
        }
        if (Vars.hunt1c == 5)
        {
            Vars.h2c = Vars.nameE;
        }
        if (Vars.players == 2)
        {
            Vars.h1a = Vars.nameA;
            Vars.h2a = Vars.nameA;
            Vars.h1b = Vars.nameB;
            Vars.h2b = Vars.nameB;
        }
        yield return lineBreak();
        yield return abort(goToPassage: "Evilsforgive");
        yield break;
    }

// ###################################################################
// PASSAGE: HuntNorth   (passage265)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28378-28394
// Links:  -
// Aborts: -
// Purpose: Hunt destination flavor: the foggy northern moors
// ###################################################################

    void passage265_Init()
    {
        this.Passages[@"HuntNorth"] = new StoryPassage(@"HuntNorth", new string[] { }, passage265_Main);
    }

    IStoryThread passage265_Main()
    {
        yield return text("The Hunting party explored the foggy Moors to the North.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.HuntNorthnextPsg == "" || Vars.HuntNorthnextPsg == 0)
        {
            Vars.HuntNorthnextPsg = macros1.either("Wight", "Moon Presence");
        }
        yield return passage(Vars.HuntNorthnextPsg);
        yield break;
    }

// ###################################################################
// PASSAGE: HuntWest   (passage266)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28400-28416
// Links:  -
// Aborts: -
// Purpose: Hunt destination flavor: the blood-tinged western mountains
// ###################################################################

    void passage266_Init()
    {
        this.Passages[@"HuntWest"] = new StoryPassage(@"HuntWest", new string[] { }, passage266_Main);
    }

    IStoryThread passage266_Main()
    {
        yield return text("The Hunting party explored into the blood-tinged mountains to the West.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.HuntWestnextPsg == "" || Vars.HuntWestnextPsg == 0)
        {
            Vars.HuntWestnextPsg = macros1.either("Golem", "Manticore");
        }
        yield return passage(Vars.HuntWestnextPsg);
        yield break;
    }

// ###################################################################
// PASSAGE: HuntEast   (passage267)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28422-28438
// Links:  -
// Aborts: -
// Purpose: Hunt destination flavor: the eastern Dark Forest
// ###################################################################

    void passage267_Init()
    {
        this.Passages[@"HuntEast"] = new StoryPassage(@"HuntEast", new string[] { }, passage267_Main);
    }

    IStoryThread passage267_Main()
    {
        yield return text("The Hunting party explored the Dark Forest to the East.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.HuntEastnextPsg == "" || Vars.HuntEastnextPsg == 0)
        {
            Vars.HuntEastnextPsg = macros1.either("Pricolici", "Troll");
        }
        yield return passage(Vars.HuntEastnextPsg);
        yield break;
    }

// ###################################################################
// PASSAGE: HuntSouth   (passage268)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28444-28462
// Links:  -
// Aborts: -
// Purpose: Hunt destination flavor: the town's cobblestone streets
// ###################################################################

    void passage268_Init()
    {
        this.Passages[@"HuntSouth"] = new StoryPassage(@"HuntSouth", new string[] { }, passage268_Main);
    }

    IStoryThread passage268_Main()
    {
        yield return text("The Hunting party explored the cobblestone streets of ");
        yield return text(Vars.townname);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.HuntSouthnextPsg == "" || Vars.HuntSouthnextPsg == 0)
        {
            Vars.HuntSouthnextPsg = macros1.either("Strigoi", "Priest");
        }
        yield return passage(Vars.HuntSouthnextPsg);
        yield break;
    }

// ###################################################################
// PASSAGE: Pricolici   (passage269)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28468-28500
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: Pricolici
// ###################################################################

    void passage269_Init()
    {
        this.Passages[@"Pricolici"] = new StoryPassage(@"Pricolici", new string[] { }, passage269_Main);
    }

    IStoryThread passage269_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Monster Emerges from the Forest");
        }
        yield return lineBreak();
        yield return text("It was only when they were less than a meter away in that tangled messed of ancie" +
            "nt undergrowth that the dark form revealed itself to ");
        yield return text(Vars.huntname);
        yield return text(" ");
        yield return text("III. It rose from its crouched position on a fallen tree to tower over the hunter" +
            "\'s party, half-man, half-beast.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Its body was covered head to toe with matted fur, and the face exposed an elongated snout flanked by eyes that shone like feral gas lamps. A being from folklore made flesh - a Pricolici! And there it waited, and watched, hovering in a space between one breath and the next, poised to flee or charge at a moment’s notice.");
        yield return lineBreak();
        Vars.huntbeast = "Pricolici";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Pricolici");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: Moon Presence   (passage270)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28506-28541
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: Moonlight Presence
// ###################################################################

    void passage270_Init()
    {
        this.Passages[@"Moon Presence"] = new StoryPassage(@"Moon Presence", new string[] { }, passage270_Main);
    }

    IStoryThread passage270_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Pathway Was Blocked");
        }
        yield return lineBreak();
        yield return text(@"The impenetrable haze swirled at its center like a small vortex, alive and billowing, before revealing a massive beast bathed in smoky luminescence. More than twice the size of any hunter in the group, it stood on reptilian hindquarters, scales speckled with moss and fungus oozing with a putrid sheen.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("And where a face should have been, only a dark, empty abyss could be seen, surrou" +
            "nded by a nest of thick, oily tentacles — a dark headdress of serpents floating " +
            "in space, unnatural and unseeing, yet devilish to behold. And thus the ");
        using (styleScope("bold", true))
        {
            yield return text("Moonlight Presence");
        }
        yield return text(" ");
        yield return text("made itself known.");
        yield return lineBreak();
        Vars.huntbeast = "Moonlight Presence";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Moonlight Presence");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: Wight   (passage271)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28547-28583
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: Shambling Wight
// ###################################################################

    void passage271_Init()
    {
        this.Passages[@"Wight"] = new StoryPassage(@"Wight", new string[] { }, passage271_Main);
    }

    IStoryThread passage271_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Pathway Was Blocked");
        }
        yield return lineBreak();
        yield return text("The stifling mist dissolved before ");
        yield return text(Vars.huntname);
        yield return text(" ");
        yield return text("III as the oily black eyes of a hideous visage glinted in the pale moonlight. Und" +
            "er the boughs of a dying black locust tree, a ");
        using (styleScope("bold", true))
        {
            yield return text("shambling wight");
        }
        yield return text(" ");
        yield return text("appeared. The ground beneath his broken toes withered to ash with each of his bel" +
            "abored steps. Somehow, the hunting party would need to vanquish this foul terror" +
            " before the night was over.");
        yield return lineBreak();
        Vars.huntbeast = "Wight";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Shambling Wight");
        }
        yield return text(" ");
        yield return text("required a sacrifice:");
        yield break;
    }

// ###################################################################
// PASSAGE: Troll   (passage272)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28589-28616
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: bridge Troll
// ###################################################################

    void passage272_Init()
    {
        this.Passages[@"Troll"] = new StoryPassage(@"Troll", new string[] { }, passage272_Main);
    }

    IStoryThread passage272_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Monster Emerges from the Forest");
        }
        yield return lineBreak();
        yield return text(@"As they approached a small stone bridgeway spanning a dried up creek bed, a foul odor hung heavy in the air, chokingly thick. It was not long before the source became apparent as an ancient Troll clambered out from under the bridge, taking up position in front of it as though to block the way.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Its blue-gray hair reached its knees, rope-like and covered with mud and leaves. From the tangle of wild hair emerged two massive arms with two equally massive hammers clutched in each hand. Its pock-marked, asymmetrical face loomed with anger in their direction.");
        yield return lineBreak();
        Vars.huntbeast = "Troll";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Troll");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: Golem   (passage273)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28622-28653
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: Stone Golem
// ###################################################################

    void passage273_Init()
    {
        this.Passages[@"Golem"] = new StoryPassage(@"Golem", new string[] { }, passage273_Main);
    }

    IStoryThread passage273_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Beast Amongst the Stony Crags");
        }
        yield return lineBreak();
        yield return text("A concussive pounding echoed down through the canyon. Upon a darkened ridge not a" +
            " furlong away, stood a colossus of aggravated rock that could have been hewn fro" +
            "m the mountain itself: a Stone Golem!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Its massive fists smashed repeatedly into a crater of its own making, and so preo" +
            "ccupied was it in this endeavor, the danger in approaching was not in being seen" +
            " but in avoiding the boulders it sent plummeting down in all directions.");
        yield return lineBreak();
        Vars.huntbeast = "Golem";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Golem");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: Manticore   (passage274)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28659-28686
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: Manticore
// ###################################################################

    void passage274_Init()
    {
        this.Passages[@"Manticore"] = new StoryPassage(@"Manticore", new string[] { }, passage274_Main);
    }

    IStoryThread passage274_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Beast Amongst the Stony Crags");
        }
        yield return lineBreak();
        yield return text(@"The ever-thinning air became filled with dust and smoke, followed by a terrifying roar that sent tremors of fear through all who heard it. A massive beast with a lion’s frame and giant’s head loomed above the path ahead, stirring up a cloud of debris in its wake.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The Manticore landed heavily on the narrow path, folded back its leathery wings, and stood perched upon the stone expectantly. Smiling hungrily through a distorted human face that revealed countless needle-sharp teeth, it whipped its barbed tail in malevolent anticipation.");
        yield return lineBreak();
        Vars.huntbeast = "Manticore";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Manticore");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: Strigoi   (passage275)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28692-28724
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: Strigoi in the town alley
// ###################################################################

    void passage275_Init()
    {
        this.Passages[@"Strigoi"] = new StoryPassage(@"Strigoi", new string[] { }, passage275_Main);
    }

    IStoryThread passage275_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Town Encounter");
        }
        yield return lineBreak();
        yield return text(@"As they approached the darkened alley, they heard first the hideous sound of an animal hungrily feeding on a fresh kill. Peering down the alley, the sound immediately ceased as torchlight revealed a pale-skinned creature hovering over the eviscerated body of an unfortunate townsfolk.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It spun to face them, baring long, white fangs and hissing like a cornered housecat. Its red, hateful eyes narrowed as it prepared to strike; its gangly torso was covered neck to waist in a glistening liquid. There was no doubt that this abomination was a ");
        using (styleScope("bold", true))
        {
            yield return text("Strigoi");
        }
        yield return text(". It would appear the tales were true.");
        yield return lineBreak();
        Vars.huntbeast = "Strigoi";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Strigoi");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: Priest   (passage276)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28730-28765
// Links:  -
// Aborts: -
// Purpose: Hunt encounter: disfigured Priest in the church
// ###################################################################

    void passage276_Init()
    {
        this.Passages[@"Priest"] = new StoryPassage(@"Priest", new string[] { }, passage276_Main);
    }

    IStoryThread passage276_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Town Encounter");
        }
        yield return lineBreak();
        yield return text("The doors to the church swung inward with great force as though pulled at the end" +
            " by an unseen hand. A figure in dark robes stood at the pulpit, his unnatural vo" +
            "ice echoing a solemn incantation.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Positioned like sentinels, marble statues flanked the apse, their eyes leaking bl" +
            "ood that pooled red and bright on the floor below. When ");
        yield return text(Vars.huntname);
        yield return text(" ");
        yield return text("III looked again to the figure at the altar, the Priest had turned towards them, " +
            "arms held high. His hood pulled back to reveal a disfigured face, hairless, lipl" +
            "ess and smiling grotesquely, glossy with a sheen of fresh blood.");
        yield return lineBreak();
        Vars.huntbeast = "Priest";
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text("Priest");
        }
        yield return text(" ");
        yield return text("required a sacrifice: ");
        yield break;
    }

// ###################################################################
// PASSAGE: HuntSuccess1   (passage277)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28771-28852
// Links:  Prosperity2,HuntSuccessCheck
// Aborts: -
// Purpose: Hunt victory: beast destroyed; rewards; routes to Prosperity2 or HuntSuccessCheck
// ###################################################################

    void passage277_Init()
    {
        this.Passages[@"HuntSuccess1"] = new StoryPassage(@"HuntSuccess1", new string[] { }, passage277_Main);
    }

    IStoryThread passage277_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("Majestic", "Stunning", "Grand", "Monumental", "Extraordinary"));
            yield return text(" ");
            yield return text("Success!");
        }
        yield return lineBreak();
        Vars.huntcount = Vars.huntcount + 1;
        yield return lineBreak();
        yield return text("The foul ");
        yield return text(Vars.huntbeast);
        yield return text(" ");
        yield return text("emits a ");
        yield return text(macros1.either("loud shriek", "low, rumbling growl", "strained gasp for air"));
        yield return text(" ");
        yield return text("before collapsing to the ground, defeated. In seconds, its corporeal form dissipa" +
            "tes to ash and is carried away on the wind. For as long as tales are still told " +
            "of this cursed night, the ");
        yield return text(Vars.huntbeast);
        yield return text(" ");
        yield return text("was never to be seen again.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click here to continue.", passage277_Fragment_1);
        using (styleScope("hook", "h000277"))
            yield return link("Click to continue...", null, () => enchantHook("h000277", HarloweEnchantCommand.Replace, passage277_Fragment_0));
        yield break;
    }

    IStoryThread passage277_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 13 ? "Prosperity2" : "HuntSuccessCheck";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("Each player participating in the Hunt: ");
            using (styleScope("bold", true))
            {
                yield return text("Lose 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(", return this servant to your Quarters,");
            yield return text(" ");
            yield return text("and ");
            using (styleScope("bold", true))
            {
                yield return text("Gain ");
                yield return text(macros1.either("2VP", "3VP", "a Knowledge of your choice"));
                yield return text(".");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //if (Vars.round == 13)
        //{
        //    yield return link("Click here to continue.", "Prosperity2", null);
        //}
        //if (Vars.round == 14)
        //{
        //    yield return link("Click here to continue.", "HuntSuccessCheck", null);
        //}
        yield break;
    }

    IStoryThread passage277_Fragment_1()
    {
        yield return enchant("Click here to continue.", HarloweEnchantCommand.Replace, passage277_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: HuntFail1   (passage278)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28857-28929
// Links:  Prosperity2,HuntSuccessCheck
// Aborts: -
// Purpose: Hunt defeat: beast escapes with the servants
// ###################################################################

    void passage278_Init()
    {
        this.Passages[@"HuntFail1"] = new StoryPassage(@"HuntFail1", new string[] { }, passage278_Main);
    }

    IStoryThread passage278_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text(macros1.either("Miserable", "Woeful", "Dismal", "Pathetic", "Grim"));
            yield return text(" ");
            yield return text("Failure!");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It had all occurred so quickly, and yet the devastation left in its wake was as v" +
            "iolent as it was terrible. The foul ");
        yield return text(Vars.huntbeast);
        yield return text(" ");
        yield return text(macros1.either("seemed to cackle to itself", "issued a triumphant wail", "smiled with an unsettling grin"));
        yield return text(", surveying the scene. Before them, strewn about in sanguine piles, were the wide" +
            "-eyed corpses of those hunters whose weapons failed to conquer the monstrous bei" +
            "ng. In the blink of an eye, the ");
        yield return text(Vars.huntbeast);
        yield return text(" ");
        yield return text("turned and quickly escaped into the shadows, but not before stealing away the fam" +
            "ily\'s trusted servants. Their tortured screams were heard throughout the valley." +
            "");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click here to continue.", passage278_Fragment_1);
        using (styleScope("hook", "h000278"))
            yield return link("Click to continue...", null, () => enchantHook("h000278", HarloweEnchantCommand.Replace, passage278_Fragment_0));
        yield break;
    }

    IStoryThread passage278_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 13 ? "Prosperity2" : "HuntSuccessCheck";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Servant";
            yield return lineBreak();
            yield return text("All players participating in the Hunt ");
            using (styleScope("bold", true))
            {
                yield return text("return their Servant on Hunter\'s Haven to Lost");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 13)
        //{
        //    yield return link("Click here to continue.", "Prosperity2", null);
        //}
        //if (Vars.round == 14)
        //{
        //    yield return link("Click here to continue.", "HuntSuccessCheck", null);
        //}
        yield break;
    }

    IStoryThread passage278_Fragment_1()
    {
        yield return enchant("Click here to continue.", HarloweEnchantCommand.Replace, passage278_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Prosperity3b   (passage316)
// Tags: checkinfinal
// Source: TheCostofDiseaseEng.cs lines 32430-32608
// Links:  Scoring
// Aborts: -
// Purpose: "A Return to Evil - Late Years" final HUB: Suspicious Buildings, page 18, Monster Spawn, ending assignment
// ###################################################################

    void passage316_Init()
    {
        this.Passages[@"Prosperity3b"] = new StoryPassage(@"Prosperity3b", new string[] { "checkinfinal", }, passage316_Main);
    }

    IStoryThread passage316_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Return to Evil - Late Years");
        }
        yield return lineBreak();
        Vars.round = 15;
        yield return lineBreak();
        if (Vars.overrun == "yes")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "S1_Suspicious_Building";
                yield return lineBreak();
                yield return text("Place all Suspicious Building tiles nearby, then turn to page ");
                using (styleScope("bold", true))
                {
                    yield return text("18");
                }
                yield return text(" of the Village Chronicle.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Return the ");
                using (styleScope("bold", true))
                {
                    yield return text("Engineering Master\'s Study");
                }
                yield return text(" Estate Upgrade to the scenario box.");
                yield return lineBreak();
                yield return lineBreak();
                if (Vars.exposeA > 0)
                {
                    yield return text("Place the ");
                    yield return text(Vars.ba);
                    yield return text(" tile over spot A on the Village Chronicle. ");
                    yield return lineBreak();
                }
                if (Vars.exposeB > 0)
                {
                    yield return text("Place the ");
                    yield return text(Vars.bb);
                    yield return text(" tile over spot B on the Village Chronicle. ");
                    yield return lineBreak();
                }
                if (Vars.exposeC > 0)
                {
                    yield return text("Place the ");
                    yield return text(Vars.bc);
                    yield return text(" tile over spot C on the Village Chronicle.");
                }
            }
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("MONSTER SPAWN");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("The Town Hall of the village has been transformed into the unofficial headquarter" +
            "s of the Order. When a player visits the Monster Spawn, they may ");
                using (styleScope("bold", true))
                {
                    yield return text("Perform an Experiment");
                }
                yield return text(".");

                yield return lineBreak();
                yield return lineBreak();
                Vars.ending = "END-WolvesEvil2";
                yield return link("Click at the end of the Generation to continue to Final Scoring...", "Scoring", null);
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.frenzy == "yes")
        else
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "S1_Suspicious_Building";
                yield return lineBreak();
                yield return text("Place all Suspicious Building tiles nearby, return the ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" token on the Farmer\'s Market to the scenario box, then turn to page ");
                using (styleScope("bold", true))
                {
                    yield return text("18");
                }
                yield return text(" of the Village Chronicle.");
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("bold", true))
                {
                    //yield return text("SPECIAL SETUP");
                }
                Vars._SetupImage = "Creepy_Icon";
                yield return text("Return all ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" tokens from player Estates to the scenario box. Remove the Storybook token from t" +
                "he ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(" Track.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return text("Return the ");
                //using (styleScope("bold", true))
                //{
                //    yield return text("Biology Master\'s Study");
                //}
                //yield return text(" Estate Upgrade to the scenario box.");
                //yield return lineBreak();
                //yield return lineBreak();
                if (Vars.exposeA > 0)
                {
                    yield return text("Place the ");
                    yield return text(Vars.ba);
                    yield return text(" tile over spot A on the Village Chronicle. ");
                    yield return lineBreak();
                }
                if (Vars.exposeB > 0)
                {
                    yield return text("Place the ");
                    yield return text(Vars.bb);
                    yield return text(" tile over spot B on the Village Chronicle. ");
                    yield return lineBreak();
                }
                if (Vars.exposeC > 0)
                {
                    yield return text("Place the ");
                    yield return text(Vars.bc);
                    yield return text(" tile over spot C on the Village Chronicle.");
                }
            }
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("MONSTER SPAWN");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("The Town Hall of the village has been transformed into the unofficial headquarter" +
                "s of the Order. When a player visits the Monster Spawn, they may ");
                using (styleScope("bold", true))
                {
                    yield return text("Perform an Experiment");
                }
                yield return text(".");

                yield return lineBreak();
                yield return lineBreak();
                Vars.ending = "END-WolvesEvil2";
                yield return link("Click at the end of the Generation to continue to Final Scoring...", "Scoring", null);
                yield return lineBreak();
            }
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HuntSuccessCheck   (passage317)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32614-32720
// Links:  Prosperity3b,Prosperity3
// Aborts: -
// Purpose: Tallies hunt successes for a good or overrun fate; Master's Study Vanity Upgrades
// ###################################################################

    void passage317_Init()
    {
        this.Passages[@"HuntSuccessCheck"] = new StoryPassage(@"HuntSuccessCheck", new string[] { }, passage317_Main);
    }

    IStoryThread passage317_Main()
    {
        if (Vars.huntcount == 2)
        {
            Vars.huntresult = "success";
        }
        if (Vars.huntcount == 1)
        {
            Vars.huntresult = macros1.either("success", "failure");
        }
        if (Vars.huntcount == 0)
        {
            Vars.huntresult = "failure";
        }
        if (Vars.huntresult == "success")
        {
            using (styleScope("bold", true))
            {
                yield return text("A ");
                yield return text(macros1.either("Righteous", "Wondrous"));
                yield return text(" Fate");
            }
            yield return lineBreak();
            yield return text(@"One by one, the steel weapons were dropped into the wooden chest; the clang of glaives, daggers, and morningstars reverberating through the lodge. They wiped the blood from tri-cornered hats and hung their polished rifles on hooks upon the walls. Affecting a cool manner, they calmed their shaken nerves with pálinka, a brandy that burned like hot coals on the throat and anesthetized their thoughts.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("They would remain vigilant until the pestilence was wiped from the land, but with" +
            " ");
            yield return text(Vars.huntcount);
            yield return text(" successful hunt, the worst of it was over. The hunt has been a success.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage317_Fragment_1);
            using (styleScope("hook", "h000317"))
                yield return link("Click to continue...", null, () => enchantHook("h000317", HarloweEnchantCommand.Replace, passage317_Fragment_0));
        }
        //if (Vars.huntresult == "failure")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Overrun By ");
                yield return text(macros1.either("Demons", "Monsters"));
            }
            yield return lineBreak();
            yield return text("The scud banked across the moon, enveloping the entire valley in a dismal, silver" +
            "y cocoon.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The townsfolk had placed the fate of ");
            yield return text(Vars.townname);
            yield return text(" into the hands of a group of leather-clad cretins willing to engage in hand-to-ha" +
            "nd combat with supernatural forces beyond their understanding. Ultimately, the s" +
            "cientists scoffed at their futile struggle.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"Embittered by what had been taken from them for this fool's errand, the cousins observed the chaos, protected from the wailing screams of a town overwhelmed by creatures. Perched upon their veranda, they sipped fresh coffee as the hellish minions descended upon the town to exert their terrible influence. The hunt had failed.");
            yield return lineBreak();
            yield return lineBreak();
            Vars.overrun = "yes";
            yield return link("Click to continue...", "Prosperity3b", null);
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage317_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "Prosperity3";
        Vars.overrun = "no";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MastersStudy";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Chemistry");
            }
            yield return text(" and ");
            using (styleScope("bold", true))
            {
                yield return text("Biology Master\'s Study");
            }
            yield return text(" Vanity Estate Upgrades from the scenario box and place them nearby. Any time you " +
                "gain a Vanity Estate Upgrade, you may choose to gain 1 of these instead.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Prosperity3", null);
        yield break;
    }

    IStoryThread passage317_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage317_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: HuntersChoice1   (passage319)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32789-32878
// Links:  -
// Aborts: -
// Purpose: Hunt night 1: chosen player picks a direction; sets `direction`; routes to HuntNight1
// ###################################################################

    void passage319_Init()
    {
        this.Passages[@"HuntersChoice1"] = new StoryPassage(@"HuntersChoice1", new string[] { }, passage319_Main);
    }

    IStoryThread passage319_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The First Night of the Hunt");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The horses reared as a blinding vein of lightning arced across the tempestuous sky, followed by a thunderous rapport that shook the ground beneath their hooves. The anxious party stood at a crossing in the roadway, trembling as they surveyed their surroundings.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"To the north, a thick fog swallowed the moors, the gray mist obscuring the horrors hidden beneath. To the east, the road entered a dark forest of foreboding trees with limbs entangled. To the West, the sky burned a deep red above the rocky mountains, seething with demonic ferocity.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was also possible to return south to the village again and see what lurked amo" +
            "ngst the cordoned streets and torchlight.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text(macros1.either(Vars.h1a, Vars.h1b));
            yield return text(" ");
            yield return text("III");
        }
        yield return text(" ");
        yield return text("has been selected to make the choice of directions for the Hunt. Once you have ch" +
            "osen a direction, the town will supply both players with the listed resources.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00203"))
            yield return link("North to the moors. Both players gain 2 " + Vars.reward1 + ".", null, () => enchantHook("h00203", HarloweEnchantCommand.Replace, passage319_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00204"))
            yield return link("East to the dark forest. Both players gain 2 " + Vars.reward2 + ".", null, () => enchantHook("h00204", HarloweEnchantCommand.Replace, passage319_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00205"))
            yield return link("West to the mountains. Both players gain 2 " + Vars.reward3 + ".", null, () => enchantHook("h00205", HarloweEnchantCommand.Replace, passage319_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00206"))
            yield return link("South, back to the town. Both players gain 2 " + Vars.reward4 + ".", null, () => enchantHook("h00206", HarloweEnchantCommand.Replace, passage319_Fragment_3));
        yield return lineBreak();
        Vars.huntname = macros1.either(Vars.h1a, Vars.h1b);
        yield break;
    }

    IStoryThread passage319_Fragment_0()
    {
        Vars.huntreward1 = Vars.reward1;
        Vars.direction = "HuntNorth";
        yield return abort(goToPassage: "HuntNight1");
        yield break;
    }

    IStoryThread passage319_Fragment_1()
    {
        Vars.huntreward1 = Vars.reward2;
        Vars.direction = "HuntEast";
        yield return abort(goToPassage: "HuntNight1");
        yield break;
    }

    IStoryThread passage319_Fragment_2()
    {
        Vars.huntreward1 = Vars.reward3;
        Vars.direction = "HuntWest";
        yield return abort(goToPassage: "HuntNight1");
        yield break;
    }

    IStoryThread passage319_Fragment_3()
    {
        Vars.huntreward1 = Vars.reward4;
        Vars.direction = "HuntSouth";
        yield return abort(goToPassage: "HuntNight1");
        yield break;
    }

// ###################################################################
// PASSAGE: HuntersChoice2   (passage320)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32883-32972
// Links:  -
// Aborts: -
// Purpose: Hunt night 2: direction choice; routes to HuntNight2
// ###################################################################

    void passage320_Init()
    {
        this.Passages[@"HuntersChoice2"] = new StoryPassage(@"HuntersChoice2", new string[] { }, passage320_Main);
    }

    IStoryThread passage320_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Second Night of the Hunt");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The horses reared as a blinding vein of lightning arced across the tempestuous sky, followed by a thunderous rapport that shook the ground beneath their hooves. The anxious party stood at a crossing in the roadway, trembling as they surveyed their surroundings.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"To the north, a thick fog swallowed the moors, the gray mist obscuring the horrors hidden beneath. To the east, the road entered a dark forest of foreboding trees with limbs entangled. To the West, the sky burned a deep red above the rocky mountains, seething with demonic ferocity.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was also possible to return south to the village again and see what lurked amo" +
            "ngst the cordoned streets and torchlight.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text(macros1.either(Vars.h2a, Vars.h2b));
            yield return text(" ");
            yield return text("III");
        }
        yield return text(" ");
        yield return text("has been selected to make the choice of directions for the Hunt. Once you have ch" +
            "osen a direction, the town will supply both players with the listed resources.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00207"))
            yield return link("North to the moors. Both players gain 2 " + Vars.reward5 + ".", null, () => enchantHook("h00207", HarloweEnchantCommand.Replace, passage320_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00208"))
            yield return link("East to the dark forest. Both players gain 2 " + Vars.reward6 + ".", null, () => enchantHook("h00208", HarloweEnchantCommand.Replace, passage320_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00209"))
            yield return link("West to the mountains. Both players gain 2 " + Vars.reward7 + ".", null, () => enchantHook("h00209", HarloweEnchantCommand.Replace, passage320_Fragment_2));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00210"))
            yield return link("South, back to the town. Both players gain 2 " + Vars.reward8 + ".", null, () => enchantHook("h00210", HarloweEnchantCommand.Replace, passage320_Fragment_3));
        yield return lineBreak();
        Vars.huntname = macros1.either(Vars.h2a, Vars.h2b);
        yield break;
    }

    IStoryThread passage320_Fragment_0()
    {
        Vars.huntreward2 = Vars.reward5;
        Vars.direction = "HuntNorth";
        yield return abort(goToPassage: "HuntNight2");
        yield break;
    }

    IStoryThread passage320_Fragment_1()
    {
        Vars.huntreward2 = Vars.reward6;
        Vars.direction = "HuntEast";
        yield return abort(goToPassage: "HuntNight2");
        yield break;
    }

    IStoryThread passage320_Fragment_2()
    {
        Vars.huntreward2 = Vars.reward7;
        Vars.direction = "HuntWest";
        yield return abort(goToPassage: "HuntNight2");
        yield break;
    }

    IStoryThread passage320_Fragment_3()
    {
        Vars.huntreward2 = Vars.reward8;
        Vars.direction = "HuntSouth";
        yield return abort(goToPassage: "HuntNight2");
        yield break;
    }

// ###################################################################
// PASSAGE: HuntNight1   (passage321)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32977-33076
// Links:  HuntSuccess1,HuntFail1
// Aborts: -
// Purpose: Night-1 contribution vote by the two hunting players; success/failure branch
// ###################################################################

    void passage321_Init()
    {
        this.Passages[@"HuntNight1"] = new StoryPassage(@"HuntNight1", new string[] { }, passage321_Main);
    }

    IStoryThread passage321_Main()
    {
        yield return passage(Vars.direction);
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text(Vars.huntreward1);
            yield return text(".");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        yield return text("Both players on the Hunt take their Voting tokens into their hand. They will secr" +
            "etly choose a side to place face up in their palm. Then they will close their fi" +
            "st and extend it to the center of the table.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Yay");
        }
        yield return text(" ");
        yield return text("vote is a vote to ");
        using (styleScope("bold", true))
        {
            yield return text("contribute");
        }
        yield return text(" ");
        yield return text("to the Hunt.");
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Nay");
        }
        yield return text(" ");
        yield return text("vote is a vote to ");
        using (styleScope("bold", true))
        {
            yield return text("keep your resources");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If BOTH players choose to contribute, all Servants will survive and each player w" +
            "ill ");
        using (styleScope("bold", true))
        {
            yield return text("pay 1 ");
            yield return text(Vars.huntreward1);
        }
        yield return text(" ");
        yield return text("to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If 1 player chooses to contribute, all Servants will survive and the contributing" +
            " player will ");
        using (styleScope("bold", true))
        {
            yield return text("pay 2 ");
            yield return text(Vars.huntreward1);
        }
        yield return text(" ");
        yield return text("to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If neither player chooses to contribute, their Servants will go to Lost and the ");
        using (styleScope("bold", true))
        {
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token will move 1 space to the left.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The Result of the Vote");
        }
        yield return lineBreak();
        yield return text("Did at least one player vote to contribute to the Hunt?");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Yes.", "HuntSuccess1", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("No.", "HuntFail1", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HuntNight2   (passage322)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33082-33181
// Links:  HuntSuccess1,HuntFail1
// Aborts: -
// Purpose: Night-2 contribution vote; success/failure branch
// ###################################################################

    void passage322_Init()
    {
        this.Passages[@"HuntNight2"] = new StoryPassage(@"HuntNight2", new string[] { }, passage322_Main);
    }

    IStoryThread passage322_Main()
    {
        yield return passage(Vars.direction);
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text(Vars.huntreward2);
            yield return text(".");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        yield return text("Both players on the Hunt take their Voting tokens into their hands. They will sec" +
            "retly choose a side to place face up in their palm. Then they will close their f" +
            "ist and extend it to the center of the table.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Yay");
        }
        yield return text(" ");
        yield return text("vote is a vote to ");
        using (styleScope("bold", true))
        {
            yield return text("contribute");
        }
        yield return text(" ");
        yield return text("to the Hunt.");
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Nay");
        }
        yield return text(" ");
        yield return text("vote is a vote to ");
        using (styleScope("bold", true))
        {
            yield return text("keep your resources");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If BOTH players choose to contribute, all Servants will survive and each player w" +
            "ill ");
        using (styleScope("bold", true))
        {
            yield return text("pay 1 ");
            yield return text(Vars.huntreward2);
        }
        yield return text(" ");
        yield return text("to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If 1 player chooses to contribute, all Servants will survive and the contributing" +
            " player will ");
        using (styleScope("bold", true))
        {
            yield return text("pay 2 ");
            yield return text(Vars.huntreward2);
        }
        yield return text(" ");
        yield return text("to the supply.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If neither player choose to contribute, their Servants will go to Lost and the ");
        using (styleScope("bold", true))
        {
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token will move 1 space to the left.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The Result of the Vote:");
        }
        yield return lineBreak();
        yield return text("Did at least one player vote to contribute to the Hunt?");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Yes.", "HuntSuccess1", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("No.", "HuntFail1", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Huntround1   (passage323)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33187-33251
// Links:  HuntersChoice1
// Aborts: -
// Purpose: Hunt prep: two players each place a Servant/Spouse on the Hunter's Haven
// ###################################################################

    void passage323_Init()
    {
        this.Passages[@"Huntround1"] = new StoryPassage(@"Huntround1", new string[] { }, passage323_Main);
    }

    IStoryThread passage323_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("In Preparation for the Hunt");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("As the full moon rose against a crimson sky, it was clear that the night of the H" +
            "unt had finally arrived. ");
        yield return text(Vars.h1a);
        yield return text(" ");
        yield return text("III and ");
        yield return text(Vars.h1b);
        yield return text(" ");
        yield return text("III were chosen. Naturally, the cousins declined to put themselves in potential h" +
            "arms way, so it was decided that they would send representatives in their stead " +
            "to assist the Hunters.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage323_Fragment_1);
        using (styleScope("hook", "h000323"))
            yield return link("Click to continue...", null, () => enchantHook("h000323", HarloweEnchantCommand.Replace, passage323_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage323_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "HuntersChoice1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Spouse_Servant";
            yield return lineBreak();
            yield return text(Vars.h1a);
            yield return text(" ");
            yield return text("III and ");
            yield return text(Vars.h1b);
            yield return text(" ");
            yield return text("III each choose a Servant/Spouse piece and place it on the Hunter\'s Haven.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("<i>If a player cannot perform this action, they lose 3VP and gain a Servant/Spouse piece from Lost to place onto the Hunter's Haven.</i>");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "HuntersChoice1", null);
        yield break;
    }

    IStoryThread passage323_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage323_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Huntround2   (passage324)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33256-33320
// Links:  HuntersChoice2
// Aborts: -
// Purpose: Second hunt prep; place pieces on the Hunter's Haven again
// ###################################################################

    void passage324_Init()
    {
        this.Passages[@"Huntround2"] = new StoryPassage(@"Huntround2", new string[] { }, passage324_Main);
    }

    IStoryThread passage324_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("In Preparation for the Hunt");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("As the full moon rose against a crimson sky, it was clear that the night of the H" +
            "unt had finally arrived. ");
        yield return text(Vars.h2a);
        yield return text(" ");
        yield return text("III and ");
        yield return text(Vars.h2b);
        yield return text(" ");
        yield return text("III were chosen. Naturally, the cousins declined to put themselves in potential h" +
            "arms way, so it was decided that they would send representatives in their stead " +
            "to assist the Hunters.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage324_Fragment_1);
        using (styleScope("hook", "h000324"))
            yield return link("Click to continue...", null, () => enchantHook("h000324", HarloweEnchantCommand.Replace, passage324_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage324_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "HuntersChoice2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Spouse_Servant";
            yield return lineBreak();
            yield return text(Vars.h2a);
            yield return text(" ");
            yield return text("III and ");
            yield return text(Vars.h2b);
            yield return text(" ");
            yield return text("III each choose a Servant/Spouse piece and place it onto the Hunter\'s Haven.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("<i>If a player cannot perform this action, they lose 3VP and gain a Servant/Spouse piece from Lost to place onto the Hunter's Haven.</i>");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "HuntersChoice2", null);
        yield break;
    }

    IStoryThread passage324_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage324_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: ProsperityWolvesIntro   (passage325)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 33325-33375
// Links:  GoodConsequences
// Aborts: -
// Purpose: Generation III intro "The Order Revealed" (Wolves variant of the prosperity branch)
// ###################################################################

    void passage325_Init()
    {
        this.Passages[@"ProsperityWolvesIntro"] = new StoryPassage(@"ProsperityWolvesIntro", new string[] { "INTRO", }, passage325_Main);
    }

    IStoryThread passage325_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION III:");
            yield return lineBreak();
            yield return text("The Order Revealed");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I will attempt to relay the events as they were explained to me, though I fully u" +
            "nderstand the solemn repercussions of the unfathomable knowledge contained withi" +
            "n this text.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Could a period of prosperity emerge like a blooming lily in the shadow of a headstone? Could it thrive in soil so enriched by disease and death? With the evil machinations exposed and banished from the town, the Order of St. Hubertus was quick to answer these questions with reforms that cleared the smog and grayness from the streets. They tilled the fields till the beet flowers sprung from the earth, encouraged trade with nearby towns, and embraced modern conveniences, even so far as to negotiate an extension of the national electrical power grid. The youths, upon returning from university to claim their inheritance, could scarcely recognize the village from their childhood.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"But, it soon became clear why they were so determined to be accepted and improve their reputation. For one evening, when the blood moon crossed the evening sky, they transformed, revealing the monstrous beings they had kept secret for so many years as the unafflicted in the town looked on in horror.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The beasts were real.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"But the beasts did not recognize their new forms as folly. Though their bodies shifted into monstrosities more animal than man - more wolven, with sharp features, claws, and steel-eyed gazes - they pleaded with the public for compassion. Should we not celebrate that which makes us different? Is it not these differences that allow us to grow stronger together?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"They believed that every creature was special in their own way and were convinced that reformation could tame the impulses of any creature be it man or beast. And with that hope in their hollow hearts, they endeavored to spread a message of love and acceptance to all humans.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("O poor, misguided wretches!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Had the human inhabitants not suddenly found themselves outnumbered by a den of nightmarish beings, they may have voiced their opposition with violent reprisal. But, with no option to the contrary, the monsters retained their hellish visages and life returned to a semblance of normalcy.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("That is, until the scientists once again began their work in earnest and attracte" +
            "d the Order\'s attention.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "GoodConsequences", null);
        Vars.gen3pg = 0;
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: 2p-FrenzyALT   (passage334)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33779-33856
// Links:  2p-FrenzyALTb
// Aborts: -
// Purpose: 2-player ALT: money bid instead of a vote to decide the night of Frenzy
// ###################################################################

    void passage334_Init()
    {
        this.Passages[@"2p-FrenzyALT"] = new StoryPassage(@"2p-FrenzyALT", new string[] { }, passage334_Main);
    }

    IStoryThread passage334_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Frenzy Decision");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return lineBreak();
        yield return text(@"The Order suggested a single evening, once every few years, where the town becomes a place to unleash all their frustrations at once. They deemed it the night of ""The Frenzy."" Citing recent advances in the field of psychology, they suggested that controlled indulgence might alleviate the mania they experience.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Given the scientific expertise of the cousins (and possibly with no other stable " +
            "options), they consulted them in private on this matter, hoping to come to a con" +
            "sensus.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("BID");
        }
        yield return lineBreak();
        yield return text("All players take all of their money into their hands. They then secretly choose a" +
            "ny amount to place into their right hand to bid on choosing the outcome.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Encouraging");
        }
        yield return text(" ");
        yield return text("the Frenzy will guarantee that experimentation will no longer be considered Creep" +
            "y, but also introduces other problems.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Not encouraging");
        }
        yield return text(" ");
        yield return text("the Frenzy will maintain the Biology award.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Once all players are ready, reveal the amount of money bid simultaneously. The pl" +
            "ayer that bid the most wins the vote and also ");
        using (styleScope("bold", true))
        {
            yield return text("gains 2VP");
        }
        yield return text(". ");
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
        //yield return link("Click to start the bid...", "2p-FrenzyALTb", null);
        using (styleScope("hook", "h0000334"))
            yield return link("Click to start the bid...", null, () => enchantHook("h0000334", HarloweEnchantCommand.None, passage334_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage334_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("2p-FrenzyALTb", BiddingSystem.Bidding);
        yield break;
    }

// ###################################################################
// PASSAGE: GoodFrenzyEvent2   (passage335)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 33861-33944
// Links:  GoodFrenzyEvent2b
// Aborts: -
// Purpose: Standard vote on encouraging the Frenzy
// ###################################################################

    void passage335_Init()
    {
        this.Passages[@"GoodFrenzyEvent2"] = new StoryPassage(@"GoodFrenzyEvent2", new string[] { }, passage335_Main);
    }

    IStoryThread passage335_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Frenzied Decision");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return lineBreak();
        yield return text(@"The Order suggested a single evening, once every few years, where the town becomes a place to unleash all their frustrations at once. They deemed it the night of ""The Frenzy."" Citing recent advances in the field of psychology, they suggested that controlled indulgence might alleviate the mania they experience.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Given the scientific expertise of the cousins (and possibly with no other stable " +
            "options), they consulted them in private on this matter, hoping to come to a con" +
            "sensus.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        yield return text("All players take their Voting tokens into their hands. The players will secretly " +
            "choose a side to place face up in their palm. Then they will close their fist an" +
            "d extend it to the center of the table.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Yay");
        }
        yield return text(" ");
        yield return text("vote is a vote to encourage the Frenzy. ");
        using (styleScope("italic", true))
        {
            yield return text("This will guarantee that experimentation will no longer be considered Creepy, but" +
            " creates other problems.");
        }
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Nay");
        }
        yield return text(" ");
        yield return text("vote is a vote to ");
        using (styleScope("bold", true))
        {
            yield return text("not");
        }
        yield return text(" ");
        yield return text("encourage the Frenzy. ");
        using (styleScope("italic", true))
        {
            yield return text("This will maintain the Biology award.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Once all players have chosen, they all reveal their votes. Tally the votes and th" +
            "e side with the most votes wins. ");
        using (styleScope("italic", true))
        {
            yield return text("Ties are broken by the last player in turn order.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the vote...", "GoodFrenzyEvent2b", null);
        using (styleScope("hook", "h0000335"))
            yield return link("Click here to start the vote...", null, () => enchantHook("h0000335", HarloweEnchantCommand.None, passage335_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage335_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("GoodFrenzyEvent2b", BiddingSystem.Voting);
        yield break;
    }

// ###################################################################
// PASSAGE: 2p-FrenzyALTb   (passage344)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34361-34389
// Links:  YesFrenzy,NoFrenzy
// Aborts: -
// Purpose: Resolves the 2-player Frenzy bid: winner pays, +2VP, picks Yes/NoFrenzy
// ###################################################################

    void passage344_Init()
    {
        this.Passages[@"2p-FrenzyALTb"] = new StoryPassage(@"2p-FrenzyALTb", new string[] { }, passage344_Main);
    }

    IStoryThread passage344_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Bid Outcome");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The player that won the bid must pay their bid to supply.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The winning player immediately gains 2VP and chooses the option below:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("We encouraged this Frenzy behavior.", "YesFrenzy", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("For God\'s sake, we did not encourage this behavior.", "NoFrenzy", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: GoodFrenzyEvent2b   (passage345)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34395-34428
// Links:  YesFrenzy,NoFrenzy
// Aborts: -
// Purpose: Resolves the Frenzy vote tally; links to YesFrenzy/NoFrenzy
// ###################################################################

    void passage345_Init()
    {
        this.Passages[@"GoodFrenzyEvent2b"] = new StoryPassage(@"GoodFrenzyEvent2b", new string[] { }, passage345_Main);
    }

    IStoryThread passage345_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("VOTE OUTCOME");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Once all players have chosen, they all reveal their votes. Tally the votes and th" +
            "e side with the most votes wins. ");
        using (styleScope("italic", true))
        {
            yield return text("Ties are broken by the last player in turn order.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Click on the result of your vote:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("We encouraged this frenzied behavior.", "YesFrenzy", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("For God\'s sake, we did not encourage this behavior.", "NoFrenzy", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: MayorResolveHunters   (passage353)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 34701-34779
// Links:  -
// Aborts: -
// Purpose: "Recompense for Past Leadership": mayoral legacy grants VP + a resource; leads to Huntround2
// ###################################################################

    void passage353_Init()
    {
        this.Passages[@"MayorResolveHunters"] = new StoryPassage(@"MayorResolveHunters", new string[] { "revised", }, passage353_Main);
    }

    IStoryThread passage353_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Recompense for Past Leadership");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to ");
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("III. This passage is read out loud in view of all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Though memories of the past may be harsh or serene, one cannot deny the significance of those distinctive few whose actions set the gears in motion. ");
        yield return text(Vars.mayor);
        yield return text("\'s namesake was still whispered amongst the townfolk of ");
        yield return text(Vars.townname);
        yield return text(". ");
        yield return text(Vars.mayor);
        yield return text("\'s contribution to the wellbeing of all may have been acute, but it was noticeable nonetheless.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.mayor);
        yield return text("\'s family legacy, whether through infamy or prestige, raged onward to press upon the boundaries of science and common decency.");

        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00000353"))
            yield return link("Click to continue...", null, () => enchantHook("h00000353", HarloweEnchantCommand.Replace, passage353_Fragment_0));

        //yield return text("Click to continue...");
        yield break;
    }

    IStoryThread passage353_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "Huntround2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            //yield return lineBreak();
            //yield return lineBreak();
            Vars._SetupImage = "S1_MayorCoin";
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("gains ");
            using (styleScope("bold", true))
            {
                yield return text(macros1.either(1, 2));
                yield return text("VP");
            }
            yield return text(". Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Return the ");
            using (styleScope("bold", true))
            {
                yield return text("Commemorative Mayoral Coin");
            }
            yield return text(" ");
            yield return text("to the scenario box.");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: ResolveCharityWolves   (passage354)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 34784-34862
// Links:  -
// Aborts: -
// Purpose: "Passion and Empathy": charitable legacy recovers a Servant; Heart token returned
// ###################################################################

    void passage354_Init()
    {
        this.Passages[@"ResolveCharityWolves"] = new StoryPassage(@"ResolveCharityWolves", new string[] { "revised", }, passage354_Main);
    }

    IStoryThread passage354_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Passion and Empathy");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to ");
            yield return text(Vars.charity);
            yield return text(". This passage is read out loud in view of all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("For the residents of ");
        yield return text(Vars.townname);
        yield return text(", though I shudder at the descriptions of their mongrel countenances, there was deep affection for those thrust into the epic struggle between wild passion and sympathy for the lesser among them. ");
        yield return text(Vars.charity);
        yield return text(" III's fiery ambitions inspired the beasts, while their familial legacy of humility and charity - begrudgingly or elsewise - garnered an even deeper admiration.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("There was not a day that went by with a friendly set of claws proudly patting their shoulder or saliva - laden greeting at the local pub. As naive as they were, some even relished the opportunity to donate their labors inside the ominous iron gates upon the hillside.");
        yield return lineBreak();
        yield return lineBreak();

        using (styleScope("hook", "h00000354"))
            yield return link("Click to continue...", null, () => enchantHook("h00000354", HarloweEnchantCommand.Replace, passage354_Fragment_0));

        yield return lineBreak();
        yield break;
    }

    IStoryThread passage354_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "Prosperity2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_EstateUpgradeBACK";
            //yield return text("_SetupImage");
            //yield return lineBreak();
            //yield return lineBreak();
            yield return text(Vars.charity);
            yield return text(" may ");
            using (styleScope("bold", true))
            {
                yield return text("gain a Servant from Lost");
            }
            yield return text(" (if possible) and ");
            using (styleScope("bold", true))
            {
                yield return text("returns their <sprite=\"Creepy_Icon\" index=0> token to the start of the <sprite=\"Creepy_Icon\" index=0> Track.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Return the ");
            using (styleScope("bold", true))
            {
                yield return text("Heart ");
                yield return text("<sprite=\"S1_HeartToken\" index=0>");
                yield return text(" ");
                yield return text("token");
            }
            yield return text(" ");
            yield return text("to the scenario box.");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesBankMayorGood   (passage359)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 34965-35047
// Links:  Prosperity2
// Aborts: -
// Purpose: "The Stench of Man's Avarice": the bank/mayor legacy gives 1 resource but -2VP
// ###################################################################

    void passage359_Init()
    {
        this.Passages[@"WolvesBankMayorGood"] = new StoryPassage(@"WolvesBankMayorGood", new string[] { "revised", }, passage359_Main);
    }

    IStoryThread passage359_Main()
    {
        if (Vars.building == "bank")
        {
            using (styleScope("bold", true))
            {
                yield return text("The Stench of Man's Avarice");
            }
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Carefully hand the Storybook to ");
                yield return text(Vars.mayor);
                yield return text(" ");
                yield return text("III. This passage is read out loud in view of all players.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"These beastly apparitions may have squashed their hirsute forms into makeshift suits and summer dresses - photographs of which degrade the very silver they were impressed upon - but when the subject of money was discussed, they sneered in disgust.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("For they abhored all forms of numismatic pursuits, only abiding them as a necessity in their brief business dealings with the outside world. ");
            yield return text(Vars.mayor);
            yield return text(" III\'s family lineage bore the golden mark of this shameful greed, and set their noses twitching every time they entered ");
            yield return text(Vars.townname);
            yield return text("\'s limits.");

            yield return lineBreak();
            yield return lineBreak();

            //yield return link("Click to continue...", "Prosperity2", null);
            using (styleScope("hook", "h00000359"))
                yield return link("Click to continue...", null, () => enchantHook("h00000359", HarloweEnchantCommand.Replace, passage359_Fragment_0));

            yield return lineBreak();
        }
        else
        {
            yield return abort(goToPassage: "ResolveCharityWolves");
        }
        yield break;
    }

    IStoryThread passage359_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "ResolveCharityWolves";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_EstateUpgradeBACK";
            //yield return text("_SetupImage");
            //yield return lineBreak();
            //yield return lineBreak();
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("gains 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("and loses ");
            using (styleScope("bold", true))
            {
                yield return text("2VP");
            }
            yield return text(". Then, return the ");
            using (styleScope("bold", true))
            {
                yield return text("Commemorative Mayoral Coin");
            }
            yield return text(" ");
            yield return text("to the scenario box.");
            yield return lineBreak();
            yield return lineBreak();
        }
        yield break;
    }
