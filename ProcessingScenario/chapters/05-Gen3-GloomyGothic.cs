// ===================================================================
// CHAPTER: Gen3-GloomyGothic   (46 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage64    LosingOrderAid               L7546-7796  Losing faction sends aid to the family; branches to wolves or taxes event
// passage128   LycanthropicMessage          L14339-14379  Does anyone hold the Lycanthropic Strength Masterwork? routes WolvesSetupGen3/LycanEvil
// passage129   LycanEvil                    L14384-14439  Grants the Lycanthropic Strength Update card
// passage357   WolvesSetupGen3              L14443-14484  Gen3 setup: Storybook token on each Masterwork for the Order's message; leads to GloomyGothic1
// passage169   GloomyHunterIntro            L19445-19480  Generation III intro: Fraternity of Hunters takeover
// passage170   EvilConsequences             L19486-19722  "The Consequences of Disobedience": reign of terror; each heir gains Creepy
// passage171   GloomyGothic1                L19727-19965 [HUB]  "A Taste of Evil - Early Years" HUB: Hunter's Rest, Taxation, Masterwork/Monster Spawn
// passage172   GloomyGothic2                L19970-20176 [HUB]  "A Taste of Evil - Middle Years" HUB: The Grand Contest donation event
// passage173   GloomyGothic3                L20180-20529 [HUB]  "A Taste of Evil - Late Years" HUB: Chronicle re-setup, Hunter's Haven, final Taxation
// passage174   EvilMayor                    L20534-20619  "Avarice Aplenty": ex-mayor's heir gets a free Curious Supply Room; returns the Coin
// passage175   CharityNegCons               L20624-20701  "Condescending Patronage": charitable heir pays $1 and gains Creepy each round
// passage186   EvilHunter1Event             L21702-21782  "Preposterous" vote: challenge the Hunters' monster-slaying claims or accept
// passage187   WolvesEvil1                  L21787-21847  Bloody wolf messenger demands an Experiment donation, or lose a Servant
// passage189   TaxesEventNoConfrontation    L21962-22053  Rising Hunter taxes: pay $2/2 resources or discard a Hunter token
// passage190   TaxesEventStart              L22058-22089  "The Hunt Begins": Hunters seize public favor and impose a tax
// passage191   EvilHunter1EventYes          L22095-22132  Family challenges the Hunters; a Grand Contest is arranged; leads to GloomyGothic2
// passage192   HunterConfrontation          L22138-22178  The Grand Contest night: cousins release Experiments against the Hunters
// passage193   OhYesTheyDead                L22184-22268  Contest success: Hunters exposed and hanged; VP for the top Experiment
// passage194   ConfrontationFail            L22273-22376  Contest failure: Hunters triumphant; VP bonus plus a group penalty
// passage195   HunterConf2                  L22381-22456  "Experiments Unleashed": secret simultaneous donation totalled vs a threshold
// passage196   TaxesEventNoConfrontation2   L22461-22527  "A Pittance": lose 2 Creepy or gain an ingredient after consenting to taxation
// passage219   WolvesEvil2                  L24448-24504  Second Order tithe: donate an Experiment for a tiered bonus or lose a Servant
// passage228   HelpingEvil                  L25040-25299  Inheritance reward for aiding evil: 4VP + token + Master's Study upgrades
// passage229   MWTokenResolve               L25360-25433  Masterwork completion under monster oversight: -4VP per stored Experiment
// passage258   EvilWolves1Note              L27697-27852  DEV NOTE: Evil Wolves / Evil Hunters branch design and rewards
// passage259   EvilWolvesEventStart         L27858-27892  The Order's underground spawning-pit lab offered in exchange for tribute
// passage263   TieredRewards1               L28195-28287  Resolves the first Order tribute; tiered rewards by donated Experiment level
// passage264   CannotParticipate            L28292-28373  Players with a stored Hereditary Disease Experiment are barred from the Grand Contest
// passage287   GloomyWolvesIntro            L29359-29398  Generation III intro "The Order Revealed" (Wolves variant of the gloomy branch)
// passage288   Preposterous                 L29404-29447  "Are You Quite Sure?": refusing the Hunter's Tax; leads to EvilHunter1Event
// passage289   TheVialUse                   L29452-29504  Choice: cleanse the land with the holy-water vial or sell it for $3
// passage290   VialCharity                  L29510-29600  Private screen granting the Vial token as a legacy of Gen1 charity
// passage291   VialSold                     L29605-29672  Sold the vial: +$3 and 1VP, blight spreads; sets up WolvesEvil2
// passage292   VialChanged                  L29677-29737  Cleansed: the valley restored, monsters genteel, +1VP
// passage293   TieredRewards2               L29742-29808  Tiered bonuses/penalties by donated Experiment level (A/B/C)
// passage306   GloomyPenalty1               L31661-31743  "The Hunter's Tax" town meeting: pay $2/2 resources or lose 3VP
// passage307   GloomyPenalty3               L31748-31828  Final-round repeat of the Hunter's Tax
// passage308   WolvesVote                   L31833-31911  Vote on unleashing the Order's concoction to tame the beasts
// passage309   WolvesVoteCheck              L31916-31982  Disease-card holders are compelled to flip their vote to Nay; retally
// passage310   WolvesVoteChange             L31988-32021  Changed vote result: the stream is cleansed and the Order flees
// passage311   VialSoldforLess              L32027-32090  After cleansing, the vial sells for $2; Vial token returned
// passage312   AwardSpawningPods            L32095-32175  Awards Spawning Pods Vanity Upgrade to the player with the most Occult experiments
// passage349   WolvesVote2                  L34555-34587  Tallies the Wolves concoction vote; branches WolvesVoteCheck or TheVialUse
// passage350   HunterConf3                  L34593-34642  Totals donated Experiment VP vs a threshold to resolve the hunter confrontation
// passage351   EvilHunter1Event2            L34648-34695  Vote-outcome screen for the evil hunter event
// passage355   MayorLibraryEvil             L34867-34960  "Detestable Education": the library legacy earns the town's grudge; +2 resources
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   GloomyGothic1        --end of round-->  GloomyPenalty1, WolvesEvil1
//   GloomyGothic2        --end of round-->  TaxesEventNoConfrontation, WolvesVote, HunterConfrontation
//   GloomyGothic3        --end of round-->  Scoring, GloomyPenalty3, AwardSpawningPods, AwardSpawningPods
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: LosingOrderAid   (passage64)
// Tags: code
// Source: TheCostofDiseaseEng.cs lines 7546-7796
// Links:  EvilWolvesEventStart,TaxesEventStart
// Aborts: -
// Purpose: Losing faction sends aid to the family; branches to wolves or taxes event
// ###################################################################

    void passage64_Init()
    {
        this.Passages[@"LosingOrderAid"] = new StoryPassage(@"LosingOrderAid", new string[] { "code", }, passage64_Main);
    }

    IStoryThread passage64_Main()
    {
        if (Vars.society == "Order of St. Hubertus")
        {
            if (Vars.hcount == 0)
            {
                yield return abort(goToPassage: "EvilWolvesEventStart");
            }
            else
            {
                using (styleScope("bold", true))
                {
                    yield return text("Despite the Hunters' Loss");
                }
                yield return lineBreak();
                yield return text(@"It was during a period of adjustment to their new surroundings that customary preparations were made to redecorate the west wing of the manor in a more modern style to which they were accustomed. Expecting a delivery of druggets from a Persian carpeter, instead they were greeted by a strapping young man in a burgundy leather coat. He tipped his wide-brimmed hat solemnly.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text(@"""Your family has made a contribution to our Fraternity and we are here to repay that debt through service,"" the young man stated, pulling back his shirt sleeve to reveal a tattoo of a bow and arrow. He then exited to the servant's quarters without further instruction.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage64_Fragment_1);
                if ((Vars.allyA != "hunters") && (Vars.allyB != "hunters") && (Vars.allyC != "hunters") && (Vars.allyD != "hunters"))
                {
                    yield return link("Click to continue...", "EvilWolvesEventStart", null);
                }
                else
                {
                    using (styleScope("hook", "h0006401"))
                        yield return link("Click to continue...", null, () => enchantHook("h0006401", HarloweEnchantCommand.Replace, passage64_Fragment_0));
                }
            }
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            if (Vars.wcount == 0)
            {
                yield return abort(goToPassage: "TaxesEventStart");
            }
            else
            {
                using (styleScope("bold", true))
                {
                    yield return text("Despite the wolves' Loss");
                }
                yield return lineBreak();
                yield return text(@"It was during a period of adjustment to their new surroundings that customary preparations were made to redecorate the west wing of the manor in a more modern style to which they were accustomed. Expecting a delivery of druggets from a Turkish carpeter, instead they were greeted by a strapping young man in a gray cloak. He tipped his fur cap solemnly.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text(@"""Your family has made a contribution to our Order and we are here to repay that debt through service,"" the young man stated, pulling back his shirt sleeve to reveal a tattoo of a wolf's head. He then exited to the servant's quarters without further instruction.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage64_Fragment_3);
                if ((Vars.allyA != "wolves") && (Vars.allyB != "wolves") && (Vars.allyC != "wolves") && (Vars.allyD != "wolves"))
                {
                    yield return link("Click to continue.", "TaxesEventStart", null);
                }
                else
                {
                    using (styleScope("hook", "h0006403"))
                        yield return link("Click to continue...", null, () => enchantHook("h0006403", HarloweEnchantCommand.Replace, passage64_Fragment_2));
                }
            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage64_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "EvilWolvesEventStart";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "GainServantFromLost";
            yield return lineBreak();
            if (Vars.allyA == "hunters")
            {
                yield return text(Vars.nameA);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyB == "hunters")
            {
                yield return text(Vars.nameB);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyC == "hunters")
            {
                yield return text(Vars.nameC);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyD == "hunters")
            {
                yield return text(Vars.nameD);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.allyE == "hunters")
            {
                yield return text(Vars.nameE);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if ((Vars.allyA != "hunters") && (Vars.allyB != "hunters") && (Vars.allyC != "hunters") && (Vars.allyD != "hunters"))
            {
                yield return text(Vars.nameA);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
        }
        //yield return lineBreak();
        //yield return link("Click to continue...", "EvilWolvesEventStart", null);
        yield break;
    }

    IStoryThread passage64_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage64_Fragment_0);
        yield break;
    }

    IStoryThread passage64_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "TaxesEventStart";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "GainServantFromLost";
            yield return lineBreak();
            if (Vars.allyA == "wolves")
            {
                yield return text(Vars.nameA);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
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
                    yield return text("immediately gains 1 Servant from Lost and $1");
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
                    yield return text("immediately gains 1 Servant from Lost and $1");
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
                    yield return text("immediately gains 1 Servant from Lost and $1");
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
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
            if ((Vars.allyA != "wolves") && (Vars.allyB != "wolves") && (Vars.allyC != "wolves") && (Vars.allyD != "wolves"))
            {
                yield return text(Vars.nameA);
                yield return text(" III ");
                using (styleScope("bold", true))
                {
                    yield return text("immediately gains 1 Servant from Lost and $1");
                }
                yield return text(".");
                yield return lineBreak();
            }
        }
        //yield return lineBreak();
        //yield return link("Click to continue.", "TaxesEventStart", null);
        yield break;
    }

    IStoryThread passage64_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage64_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: LycanthropicMessage   (passage128)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14339-14379
// Links:  WolvesSetupGen3
// Aborts: -
// Purpose: Does anyone hold the Lycanthropic Strength Masterwork? routes WolvesSetupGen3/LycanEvil
// ###################################################################

    void passage128_Init()
    {
        this.Passages[@"LycanthropicMessage"] = new StoryPassage(@"LycanthropicMessage", new string[] { }, passage128_Main);
    }

    IStoryThread passage128_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Form of the Wolf");
        }
        yield return lineBreak();
        yield return text("Confirming the existence of individuals with the ability to change into an animal" +
            " form had remarkable consequences. It is possible that it has even disrupted the" +
            " studies of one of our kin.");
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
        using (styleScope("hook", "h00073"))
            yield return link("Yes.", null, () => enchantHook("h00073", HarloweEnchantCommand.Replace, passage128_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return link("No.", "WolvesSetupGen3", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage128_Fragment_0()
    {
        Vars.lycan = "yes";
        yield return abort(goToPassage: "LycanEvil");
        yield break;
    }

// ###################################################################
// PASSAGE: LycanEvil   (passage129)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14384-14439
// Links:  GloomyGothic1
// Aborts: -
// Purpose: Grants the Lycanthropic Strength Update card
// ###################################################################

    void passage129_Init()
    {
        this.Passages[@"LycanEvil"] = new StoryPassage(@"LycanEvil", new string[] { }, passage129_Main);
    }

    IStoryThread passage129_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Strength Can Be Mine");
        }
        yield return lineBreak();
        yield return text("Their existence was proven. Now, could the catalyst of this truly powerful transf" +
            "ormation be replicated? And how could it be further strengthened?");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage129_Fragment_1);
        using (styleScope("hook", "h000129"))
            yield return link("Click to continue...", null, () => enchantHook("h000129", HarloweEnchantCommand.Replace, passage129_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage129_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "WolvesSetupGen3";
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
        //yield return link("Click to continue...", "GloomyGothic1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage129_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage129_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesSetupGen3   (passage357)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 14443-14484
// Links:  GloomyGothic1
// Aborts: -
// Purpose: Gen3 setup: Storybook token on each Masterwork for the Order's message; leads to GloomyGothic1
// ###################################################################

    void passage357_Init()
    {
        this.Passages[@"WolvesSetupGen3"] = new StoryPassage(@"WolvesSetupGen3", new string[] { "revised", }, passage357_Main);
    }

    IStoryThread passage357_Main()
    {
        ViewItemObtain.SetupPassagename = "GloomyGothic1";
        Vars.gen3pg = 0;
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }

            Vars._SetupImage = "StorybookToken";
            //yield return text("_SetupImage");
            //yield return text("<br>");
            //yield return lineBreak();

            yield return text("Each player retrieves a ");
            using (styleScope("bold", true))
            {
                yield return text("Storybook token");
            }
            yield return text(" ");
            yield return text("and places it on their Masterwork.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("When a player completes their Masterwork, they will consult the Storybook for a s" +
                "pecial message from the Order.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic1", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyHunterIntro   (passage169)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 19445-19480
// Links:  EvilConsequences
// Aborts: -
// Purpose: Generation III intro: Fraternity of Hunters takeover
// ###################################################################

    void passage169_Init()
    {
        this.Passages[@"GloomyHunterIntro"] = new StoryPassage(@"GloomyHunterIntro", new string[] { "INTRO", }, passage169_Main);
    }

    IStoryThread passage169_Main()
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
        yield return text(@"As expected, the family quickly grew to find their presence exhausting, both ideologically and financially. Clearly, the cousins opined, these Hunters' fear-mongering stemmed from a lack of true, scientific knowledge. As defenders against an unknown terror, they stood in direct competition to continued experimentation unfettered by ethical considerations. Yet, the Fraternity's need for additional capital to fuel their frequent ""hunts"" prevented the family from taking more direct action.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Perhaps driven by a sense of limited time or jealousy over the Hunter's ability to frighten the townsfolk even moreso than their own actions, the cousins continued their meticulous labors in earnest. However, they were deeply unaware of just how intertwined their fates would be to the Fraternity.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "EvilConsequences", null);
        yield return lineBreak();
        Vars.huntvp = macros1.either(4, 5);
        yield break;
    }

// ###################################################################
// PASSAGE: EvilConsequences   (passage170)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 19486-19722
// Links:  EvilMayor
// Aborts: -
// Purpose: "The Consequences of Disobedience": reign of terror; each heir gains Creepy
// ###################################################################

    void passage170_Init()
    {
        this.Passages[@"EvilConsequences"] = new StoryPassage(@"EvilConsequences", new string[] { }, passage170_Main);
    }

    IStoryThread passage170_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Consequences of Disobedience");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
            yield return text(@"In the evenings, the Fraternity gathered in the former Town Hall and celebrated their political takeover of the small town. Observers could hear their loud revelry echo through the streets late into the night. The townsfolk had no reason to doubt their loyalty as it appeared that their activities kept both sickness and superstitions at bay.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("For the family members that had aided them in their efforts, they wore wide false" +
            "-smiles and offered toasts to their continued partnership. But, for those that h" +
            "ad plotted against them, they remained wary.");
        }
        //if (Vars.society == "Order of St. Hubertus")
        else
        {
            yield return text(@"In the center of town, in the full light of day and without fear of reprisal, a silver-haired beast rose to its hindlegs, almost human in stature. On the steps of the former Town Hall, she held the still-beating heart of a man who had refused to join their numbers. ");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"The Order had revealed its true self with an unsettling ease, swiftly taking over the town and demanding alliance in the most vicious of terms. Streaks of dried blood and viscera adorned the windows of local businesses and homes. The family was only spared their wrath through allegiance or a cursed acknowledgement of their continued exploitation.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("Once all players have received their penalty, ");
        //yield return lineBreak();
        //yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
            //yield return enchantIntoLink("click here to continue...", passage170_Fragment_1);
            if (Vars.players > 4 ? Vars.allyA == "hunters" && Vars.allyB == "hunters" && Vars.allyC == "hunters" && Vars.allyD == "hunters" && Vars.allyE == "hunters" :
                    Vars.players > 3 ? Vars.allyA == "hunters" && Vars.allyB == "hunters" && Vars.allyC == "hunters" && Vars.allyD == "hunters" :
                    Vars.players > 2 ? Vars.allyA == "hunters" && Vars.allyB == "hunters" && Vars.allyC == "hunters" :
                    Vars.allyA == "hunters" && Vars.allyB == "hunters")
            {
                yield return link("click here to continue...", "EvilMayor", null);
            }
            else
            {
                using (styleScope("hook", "h00017001"))
                    yield return link("Click to continue...", null, () => enchantHook("h00017001", HarloweEnchantCommand.Replace, passage170_Fragment_0));
            }
        }
        //if (Vars.society == "Order of St. Hubertus")
        else
        {
            //yield return enchantIntoLink("click here to continue...", passage170_Fragment_3);
            if (Vars.players > 4 ? Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" && Vars.allyD == "wolves" && Vars.allyE == "wolves" :
                    Vars.players > 3 ? Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" && Vars.allyD == "wolves" :
                    Vars.players > 2 ? Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" :
                    Vars.allyA == "wolves" && Vars.allyB == "wolves")
            {
                yield return link("click here to continue...", "EvilMayor", null);
            }
            else
            {
                using (styleScope("hook", "h00017003"))
                    yield return link("Click to continue...", null, () => enchantHook("h00017003", HarloweEnchantCommand.Replace, passage170_Fragment_2));
            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage170_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "EvilMayor";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            if (Vars.allyA != "hunters")
            {
                yield return text(Vars.nameA);
                yield return text(" III gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
            if (Vars.allyB != "hunters")
            {
                yield return text(Vars.nameB);
                yield return text(" III gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
            if (Vars.players >= 3)
            {
                if (Vars.allyC != "hunters")
                {
                    yield return text(Vars.nameC);
                    yield return text(" III gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                    yield return text(".");
                }
                yield return lineBreak();
            }
            if (Vars.players >= 4)
            {
                if (Vars.allyD != "hunters")
                {
                    yield return text(Vars.nameD);
                    yield return text(" III gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                    yield return text(".");
                }
                yield return lineBreak();
            }
            if (Vars.players >= 5)
            {
                if (Vars.allyE != "hunters")
                {
                    yield return text(Vars.nameE);
                    yield return text(" III gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                    yield return text(".");
                }
                yield return lineBreak();
            }
            if (Vars.players > 4 ? Vars.allyA == "hunters" && Vars.allyB == "hunters" && Vars.allyC == "hunters" && Vars.allyD == "hunters" && Vars.allyE == "hunters" :
                    Vars.players > 3 ? Vars.allyA == "hunters" && Vars.allyB == "hunters" && Vars.allyC == "hunters" && Vars.allyD == "hunters" :
                    Vars.players > 2 ? Vars.allyA == "hunters" && Vars.allyB == "hunters" && Vars.allyC == "hunters" :
                    Vars.allyA == "hunters" && Vars.allyB == "hunters")
            {
                yield return text(Vars.nameA);
                yield return text(" III gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
        }
        yield return lineBreak();
        //yield return link("click here to continue...", "EvilMayor", null);
        yield break;
    }

    IStoryThread passage170_Fragment_1()
    {
        yield return enchant("click here to continue...", HarloweEnchantCommand.Replace, passage170_Fragment_0);
        yield break;
    }

    IStoryThread passage170_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "EvilMayor";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            if (Vars.allyA != "wolves")
            {
                yield return text(Vars.nameA);
                yield return text(" III gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
            if (Vars.allyB != "wolves")
            {
                yield return text(Vars.nameB);
                yield return text(" III gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
            if (Vars.players >= 3)
            {
                if (Vars.allyC != "wolves")
                {
                    yield return text(Vars.nameC);
                    yield return text(" III gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                    yield return text(".");
                }
                yield return lineBreak();
            }
            if (Vars.players >= 4)
            {
                if (Vars.allyD != "wolves")
                {
                    yield return text(Vars.nameD);
                    yield return text(" III gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                    yield return text(".");
                }
                yield return lineBreak();
            }
            if (Vars.players >= 5)
            {
                if (Vars.allyE != "wolves")
                {
                    yield return text(Vars.nameE);
                    yield return text(" III gains 1 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                    yield return text(".");
                }
                yield return lineBreak();
            }
            if (Vars.players > 4 ? Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" && Vars.allyD == "wolves" && Vars.allyE == "wolves" :
                    Vars.players > 3 ? Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" && Vars.allyD == "wolves" :
                    Vars.players > 2 ? Vars.allyA == "wolves" && Vars.allyB == "wolves" && Vars.allyC == "wolves" :
                    Vars.allyA == "wolves" && Vars.allyB == "wolves")
            {
                yield return text(Vars.nameA);
                yield return text(" III gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
        }
        //yield return link("click here to continue...", "EvilMayor", null);
        yield break;

    }

    IStoryThread passage170_Fragment_3()
    {
        yield return enchant("click here to continue...", HarloweEnchantCommand.Replace, passage170_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyGothic1   (passage171)
// Tags: checkinfinal,HUB
// Source: TheCostofDiseaseEng.cs lines 19727-19965
// Links:  GloomyPenalty1,MWTokenResolve,WolvesEvil1
// Aborts: -
// Round end -> GloomyPenalty1, WolvesEvil1
// Purpose: "A Taste of Evil - Early Years" HUB: Hunter's Rest, Taxation, Masterwork/Monster Spawn
// ###################################################################

    void passage171_Init()
    {
        this.Passages[@"GloomyGothic1"] = new StoryPassage(@"GloomyGothic1", new string[] { "checkinfinal", "HUB", }, passage171_Main);
    }

    IStoryThread passage171_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Taste of Evil - Early Years");
        }
        yield return lineBreak();
        Vars.round = 10;
        yield return lineBreak();
        if (Vars.gen3pg == 0 || Vars.gen3pg == "")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "StartPlayerToken";
                yield return lineBreak();
                if (Vars.society == "Fraternity of Hunters")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Turn to Page 16 of the Village Chronicle. ");
                    }
                    yield return text("Return the Angry Mob token to 1 space to the left of the Suspicion Marker. ");
                    using (styleScope("italic", true))
                    {
                        yield return text("Pass the Starting Player token as normal. ");
                    }
                    if (Vars.players == 3)
                    {
                        yield return text("Then, since this is a 3 player game, pass the starting player marker clockwise 1 " +
                    "additional time.");
                    }
                }
                //if (Vars.society == "Order of St. Hubertus")
                else
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Turn to Page 18 of the Village Chronicle. ");
                    }
                    yield return text("Retrieve the ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Spawning Pods");
                    }
                    yield return text(" Vanity Estate Upgrade and place it near the game board. Return the Angry Mob token to 1 space to the left of the Suspicion Marker. ");
                    using (styleScope("italic", true))
                    {
                        yield return text("Pass the Starting Player token as normal. ");
                    }
                    if (Vars.players == 3)
                    {
                        yield return text("Then, since this is a 3 player game, pass the starting player marker clockwise 1 " +
                    "additional time.");
                    }
                }
                yield return lineBreak();
                yield return lineBreak();
                if (Vars.exposeA <= 1)
                {
                    yield return text("Place the ");
                    yield return text(Vars.ba);
                    yield return text(" tile over spot A on the Village Chronicle. ");
                    yield return lineBreak();
                }
                if (Vars.exposeB <= 1)
                {
                    yield return text("Place the ");
                    yield return text(Vars.bb);
                    yield return text(" tile over spot B on the Village Chronicle. ");
                    yield return lineBreak();
                }
                if (Vars.exposeC <= 1)
                {
                    yield return text("Place the ");
                    yield return text(Vars.bc);
                    yield return text(" tile over spot C on the Village Chronicle.");
                    yield return lineBreak();
                }
                yield return lineBreak();
                yield return text("Return all other Building tiles to the scenario box.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
            using (styleScope("hubTitle", true))
            {

                using (styleScope("bold", true))
                {
                    yield return text("The Hunter\'s Rest");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("You may only place a Servant/Spouse piece on this building. This action causes yo" +
            "u to pay $1 to the supply. Then, ");
                using (styleScope("bold", true))
                {
                    yield return text("at the end of the round");
                }
                yield return text(", any piece on this building will become Lost.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {

                using (styleScope("bold", true))
                {
                    yield return text("Taxation");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("At the end of each round, the Fraternity will check to make sure each player has " +
                "placed a piece on ");
                using (styleScope("bold", true))
                {
                    yield return text("The Hunter\'s Rest");
                }
                yield return text(". If a player has not done so, they will be forced to pay a penalty.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "GloomyPenalty1", null);
                using (styleScope("hook", "h00001710"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h00001710", HarloweEnchantCommand.Replace, passage171_Fragment_0));

            }
        }
        //if (Vars.society == "Order of St. Hubertus")
        else
        {
            //using (styleScope("bold", true))
            //{
            //    //yield return text("SPECIAL SETUP");
            //}
            //Vars._SetupImage = "StorybookToken";
            //yield return lineBreak();
            //yield return text("Each player retrieves a ");
            //using (styleScope("bold", true))
            //{
            //    yield return text("Storybook token");
            //}
            //yield return text("and places it on their Masterwork.");
            //yield return lineBreak();
            //yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Masterwork Completion");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When a player completes their Masterwork, ");
                yield return link("click here for a special message from the Order.", "MWTokenResolve", null);
            }
            yield return lineBreak();
            yield return lineBreak();
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
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("A Gift of Spawning");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("At the end of the Generation, the player with the most completed ");
                using (styleScope("bold", true))
                {
                    yield return text("Occult");
                }
                yield return text(" Experiments will receive the ");
                using (styleScope("bold", true))
                {
                    yield return text("Spawning Pods");
                }
                yield return text(" Vanity Estate Upgrade.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "WolvesEvil1", null);
                using (styleScope("hook", "h00001711"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h00001711", HarloweEnchantCommand.Replace, passage171_Fragment_1));

            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage171_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic1", "GloomyPenalty1");
        yield break;
    }

    IStoryThread passage171_Fragment_1()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic1", "WolvesEvil1");
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyGothic2   (passage172)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 19970-20176
// Links:  HunterConfrontation,TaxesEventNoConfrontation,MWTokenResolve,WolvesVote
// Aborts: -
// Round end -> TaxesEventNoConfrontation, WolvesVote, HunterConfrontation
// Purpose: "A Taste of Evil - Middle Years" HUB: The Grand Contest donation event
// ###################################################################

    void passage172_Init()
    {
        this.Passages[@"GloomyGothic2"] = new StoryPassage(@"GloomyGothic2", new string[] { "HUB", }, passage172_Main);
    }

    IStoryThread passage172_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Taste of Evil - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 11;
        yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
            if (Vars.confront == "yes")
            {
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("The Hunt is On");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("At the end of this round, players will have the option to donate (discard) a comp" +
            "leted Experiment card ");
                    using (styleScope("italic", true))
                    {
                        yield return text("(not a Masterwork)");
                    }
                    yield return text(" to The Grand Contest event. If the combined VP total of these Experiments can van" +
                "quish the hunters, they will submit to public humiliation. Players cannot pay ta" +
                "xes by visiting The Hunter\'s Rest.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("Also, the player who contributes the Experiment with the highest VP total will ga" +
                "in ");
                    using (styleScope("bold", true))
                    {
                        yield return text(Vars.huntvp);
                        yield return text("VP. ");
                    }
                    using (styleScope("italic", true))
                    {
                        yield return text("If players are tied, all tied players receive this bonus.");
                    }
                    yield return lineBreak();
                    yield return lineBreak();
                    //yield return link("Click at the end of the round to continue...", "HunterConfrontation", null);
                    using (styleScope("hook", "h000017202"))
                        yield return link("Click at the end of the round to continue...", null, () => enchantHook("h000017202", HarloweEnchantCommand.Replace, passage172_Fragment_2));

                }
            }
            else
            {
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Safe and Protected");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("We have decided to believe the Fraternity of Hunters and allow them to continue t" +
            "heir important work, though it may place significant financial constraints upon " +
            "us.");
                }
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("The Hunter\'s Rest");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("You may only place a Servant/Spouse piece on this building. This action causes yo" +
            "u to pay $1 to the supply. Then, at the end of the round, any piece on this buil" +
            "ding will become Lost.");
                }
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Taxation");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("At the end of each round, the Fraternity will check to make sure each player has " +
            "placed a piece on ");
                    using (styleScope("bold", true))
                    {
                        yield return text("The Hunter\'s Rest");
                    }
                    yield return text(". If a player has not done so, they will be forced to pay a penalty.");
                    yield return lineBreak();
                    yield return lineBreak();
                    //yield return link("Click at the end of the round to continue...", "TaxesEventNoConfrontation", null);
                    using (styleScope("hook", "h000017200"))
                        yield return link("Click at the end of the round to continue...", null, () => enchantHook("h000017200", HarloweEnchantCommand.Replace, passage172_Fragment_0));

                }
            }
        }
        //if (Vars.society == "Order of St. Hubertus")
        else
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Masterwork Completion");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("When a player completes their Masterwork, ");
                yield return link("click here for a special message from the Order.", "MWTokenResolve", null);
            }
            yield return lineBreak();
            yield return lineBreak();
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
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                using (styleScope("bold", true))
                {
                    yield return text("A Gift of Spawning");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("At the end of the Generation, the player with the most completed ");
                using (styleScope("bold", true))
                {
                    yield return text("Occult");
                }
                yield return text(" Experiments will receive the ");
                using (styleScope("bold", true))
                {
                    yield return text("Spawning Pods");
                }
                yield return text(" Vanity Estate Upgrade.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return link("Click at the end of the round to continue...", "WolvesVote", null);
                using (styleScope("hook", "h000017201"))
                    yield return link("Click at the end of the round to continue...", null, () => enchantHook("h000017201", HarloweEnchantCommand.Replace, passage172_Fragment_1));

            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage172_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic2", "TaxesEventNoConfrontation");
        yield break;
    }

    IStoryThread passage172_Fragment_1()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic2", "WolvesVote");
        yield break;
    }

    IStoryThread passage172_Fragment_2()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic2", "HunterConfrontation");
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyGothic3   (passage173)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 20180-20529
// Links:  Scoring,GloomyPenalty3,AwardSpawningPods,MWTokenResolve
// Aborts: -
// Round end -> Scoring, GloomyPenalty3, AwardSpawningPods, AwardSpawningPods
// Purpose: "A Taste of Evil - Late Years" HUB: Chronicle re-setup, Hunter's Haven, final Taxation
// ###################################################################

    void passage173_Init()
    {
        this.Passages[@"GloomyGothic3"] = new StoryPassage(@"GloomyGothic3", new string[] { "HUB", }, passage173_Main);
    }

    IStoryThread passage173_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Taste of Evil - Late Years");
        }
        yield return lineBreak();
        Vars.round = 12;
        yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
            if (Vars.taxes == "no")
            {
                using (styleScope("setupStyle", true))
                {
                    using (styleScope("bold", true))
                    {
                        //yield return text("SPECIAL SETUP");
                    }
                    Vars._SetupImage = "S1_Suspicious_Building";
                    yield return lineBreak();
                    yield return text("Temporarily remove all Building tiles and turn to ");
                    using (styleScope("bold", true))
                    {
                        yield return text("page 15");
                    }
                    yield return text(" of the Village Chronicle. Then, return the Building tiles to their proper locatio" +
                "ns.");
                    yield return lineBreak();
                    yield return lineBreak();
                    if (Vars.exposeA <= 1)
                    {
                        using (styleScope("italic", true))
                        {
                            yield return text("Place the ");
                            yield return text(Vars.ba);
                            yield return text(" tile over spot A on the Village Chronicle.");
                        }
                        yield return lineBreak();
                    }
                    if (Vars.exposeB <= 1)
                    {
                        using (styleScope("italic", true))
                        {
                            yield return text("Place the ");
                            yield return text(Vars.bb);
                            yield return text(" tile over spot B on the Village Chronicle.");
                        }
                        yield return lineBreak();
                    }
                    if (Vars.exposeC <= 1)
                    {
                        using (styleScope("italic", true))
                        {
                            yield return text("Place the ");
                            yield return text(Vars.bc);
                            yield return text(" tile over spot C on the Village Chronicle.");
                        }
                        yield return lineBreak();
                    }
                }
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("The Hunter\'s Haven");
                    }
                }
                using (styleScope("hubDetails", true))
                {
                    yield return text("Visiting the remodeled Hunter\'s Lodge allows you to ");
                    using (styleScope("bold", true))
                    {
                        yield return text("pay 1 Occult knowledge cube to Lose 2 ");
                        yield return text(" <sprite=\"Insanity_Icon\" index=0>");
                    }
                    yield return text(".");
                    yield return lineBreak();
                    yield return lineBreak();
                    Vars.ending = "END-HuntersEvil1";
                    //yield return link("Click at the end of the Generation to continue...", "Scoring", null);
                    using (styleScope("hook", "h000017300"))
                        yield return link("Click at the end of the Generation to continue...", null, () => enchantHook("h000017300", HarloweEnchantCommand.Replace, passage173_Fragment_0));
                    yield return lineBreak();
                }
            }
            else
            {
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Safe and Protected");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("We have decided to believe the Fraternity of Hunters and allow them to continue t" +
            "heir important work. ");
                }
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("The Hunter\'s Rest");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("You may only place a Servant/Spouse piece on this building. This action causes yo" +
                "u to pay $1 to the supply. Then, at the end of the round, any piece on this buil" +
                "ding will become Lost.");
                }
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Final Taxation");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("At the end of this round, the Fraternity will check to make sure each player has " +
            "placed a piece on ");
                    using (styleScope("bold", true))
                    {
                        yield return text("The Hunter\'s Rest");
                    }
                    yield return text(". If a player has not done so, they will be forced to pay a penalty.");
                    yield return lineBreak();
                    yield return lineBreak();
                    Vars.ending = "END-HuntersEvil2";
                    //yield return link("Click at the end of the Generation to continue...", "GloomyPenalty3", null);
                    using (styleScope("hook", "h000017301"))
                        yield return link("Click at the end of the Generation to continue...", null, () => enchantHook("h000017301", HarloweEnchantCommand.Replace, passage173_Fragment_1));
                    yield return lineBreak();
                }
            }
        }
        //if (Vars.society == "Order of St. Hubertus")
        else
        {
            if (Vars.vialuse == "yes")
            {
                using (styleScope("setupStyle", true))
                {
                    using (styleScope("bold", true))
                    {
                        //yield return text("SPECIAL SETUP");
                    }
                    Vars._SetupImage = "S1_Suspicious_Building";
                    yield return lineBreak();
                    yield return text("Temporarily remove all Building tiles and turn to ");
                    using (styleScope("bold", true))
                    {
                        yield return text("page 17");
                    }
                    yield return text(" of the Village Chronicle. Then, return the Building tiles to their proper locatio" +
                "ns.");
                    yield return lineBreak();
                    yield return lineBreak();
                    if (Vars.exposeA <= 1)
                    {
                        using (styleScope("italic", true))
                        {
                            yield return text("Place the ");
                            yield return text(Vars.ba);
                            yield return text(" tile over spot A on the Village Chronicle.");
                        }
                        yield return lineBreak();
                    }
                    if (Vars.exposeB <= 1)
                    {
                        using (styleScope("italic", true))
                        {
                            yield return text("Place the ");
                            yield return text(Vars.bb);
                            yield return text(" tile over spot B on the Village Chronicle.");
                        }
                        yield return lineBreak();
                    }
                    if (Vars.exposeC <= 1)
                    {
                        using (styleScope("italic", true))
                        {
                            yield return text("Place the ");
                            yield return text(Vars.bc);
                            yield return text(" tile over spot C on the Village Chronicle.");
                        }
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
                    yield return text("When visiting this building, ");
                    using (styleScope("bold", true))
                    {
                        yield return text("pay $1 to gain a Caretaker from Lost.");
                    }
                }
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("A Gift of Spawning");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("At the end of the Generation, the player with the most completed ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Occult");
                    }
                    yield return text(" Experiments will receive the ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Spawning Pods");
                    }
                    yield return text(" Vanity Estate Upgrade.");
                    yield return lineBreak();
                    yield return lineBreak();
                    Vars.ending = "END-WolvesEvil1";
                    //yield return link("Click at the end of the Generation to continue...", "AwardSpawningPods", null);
                    using (styleScope("hook", "h000017302"))
                        yield return link("Click at the end of the Generation to continue...", null, () => enchantHook("h000017302", HarloweEnchantCommand.Replace, passage173_Fragment_2));
                    yield return lineBreak();
                }
            }
            else
            {
                using (styleScope("hubTitle", true))
                {
                    yield return text("<sprite=\"Storybook\" index=0>");
                    using (styleScope("bold", true))
                    {
                        yield return text(" Masterwork Completion");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("When a player completes their Masterwork, ");
                    yield return link("click here for a special message from the Order.", "MWTokenResolve", null);
                }
                yield return lineBreak();
                yield return lineBreak();
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
                }
                yield return lineBreak();
                yield return lineBreak();
                using (styleScope("hubTitle", true))
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("A Gift of Spawning");
                    }
                }
                yield return lineBreak();
                using (styleScope("hubDetails", true))
                {
                    yield return text("At the end of the Generation, the player with the most completed ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Occult");
                    }
                    yield return text(" Experiments will receive the ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Spawning Pods");
                    }
                    yield return text(" Vanity Estate Upgrade.");
                    yield return lineBreak();
                    yield return lineBreak();
                    Vars.ending = "END-WolvesEvil2";
                    //yield return link("Click at the end of the Generation to continue...", "AwardSpawningPods", null);
                    using (styleScope("hook", "h000017303"))
                        yield return link("Click at the end of the Generation to continue...", null, () => enchantHook("h000017303", HarloweEnchantCommand.Replace, passage173_Fragment_3));
                    yield return lineBreak();
                }
            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage173_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic3", "Scoring");
        yield break;
    }

    IStoryThread passage173_Fragment_1()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic3", "GloomyPenalty3");
        yield break;
    }

    IStoryThread passage173_Fragment_2()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic3", "AwardSpawningPods");
        yield break;
    }

    IStoryThread passage173_Fragment_3()
    {
        PassageTracker.instance.CheckProgress("GloomyGothic3", "AwardSpawningPods");
        yield break;
    }

// ###################################################################
// PASSAGE: EvilMayor   (passage174)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 20534-20619
// Links:  LosingOrderAid
// Aborts: -
// Purpose: "Avarice Aplenty": ex-mayor's heir gets a free Curious Supply Room; returns the Coin
// ###################################################################

    void passage174_Init()
    {
        this.Passages[@"EvilMayor"] = new StoryPassage(@"EvilMayor", new string[] { }, passage174_Main);
    }

    IStoryThread passage174_Main()
    {
        if (Vars.building == "bank")
        {
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Carefully hand the Storybook to ");
                yield return text(Vars.mayor);
                yield return text(" ");
                yield return text("III.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Avarice Aplently");
            }
            yield return lineBreak();
            yield return text("The Bank had proven a valuable investment in the town\'s future, and since its con" +
            "struction was facilitated by the ");
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("name, the ");
            yield return text(Vars.society);
            yield return text(" ");
            yield return text("could not help but offer thanks. As a token of their appreciation, they felt it b" +
            "est to help construct an expansion to their Estate.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage174_Fragment_1);
            using (styleScope("hook", "h000174"))
                yield return link("Click to continue...", null, () => enchantHook("h000174", HarloweEnchantCommand.Replace, passage174_Fragment_0));
        }
        else
        {
            yield return abort(goToPassage: "MayorLibraryEvil");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage174_Fragment_0()
    {
        yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.hcount == 0 && Vars.society == "Order of St. Hubertus" ? "EvilWolvesEventStart" : "LosingOrderAid";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MayorCoin";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Curious Supply Room");
            }
            yield return text(" ");
            yield return text("Estate Upgrade from the scenario box. ");
            using (styleScope("italic", true))
            {
                yield return text("You may immediately build it in the next empty plot on your Estate board at no ad" +
                "ditional cost.");
            }
            yield return text(" ");
            yield return text("Then, return the <b>Commemorative Mayoral Coin</b> to the box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "LosingOrderAid", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage174_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage174_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: CharityNegCons   (passage175)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 20624-20701
// Links:  GloomyGothic1
// Aborts: -
// Purpose: "Condescending Patronage": charitable heir pays $1 and gains Creepy each round
// ###################################################################

    void passage175_Init()
    {
        this.Passages[@"CharityNegCons"] = new StoryPassage(@"CharityNegCons", new string[] { }, passage175_Main);
    }

    IStoryThread passage175_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Condescending Patronage");
        }
        yield return lineBreak();
        Vars.gen3pg = 0;
        Vars.conpat = macros1.either(1, 2);
        yield return lineBreak();
        yield return text(@"It should be expected that the townsfolk who had placed their trust in a group of hunters protecting them from real supernatural threats would joke about generations past and the absurd push to build a hospital. It was clear to them that disease was caused by the presence of demons.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("III\'s family legacy of ");
        using (styleScope("bold", true))
        {
            yield return text("charity");
        }
        yield return text(" ");
        yield return text("served to create for them an unwanted hassle in everything from business to socia" +
            "l gatherings in town.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage175_Fragment_1);
        using (styleScope("hook", "h000175"))
            yield return link("Click to continue...", null, () => enchantHook("h000175", HarloweEnchantCommand.Replace, passage175_Fragment_0));
        yield break;
    }

    IStoryThread passage175_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_HeartToken";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("At the start of the round, ");
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("III must ");
            if (Vars.conpat == 1)
            {
                yield return text("pay $1 to the supply.");
            }
            if (Vars.conpat == 2)
            {
                yield return text("gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Return the <b>Heart <sprite=\"S1_HeartToken\" index=0> token</b> to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic1", null);
        yield break;
    }

    IStoryThread passage175_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage175_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: EvilHunter1Event   (passage186)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21702-21782
// Links:  EvilHunter1Event2
// Aborts: -
// Purpose: "Preposterous" vote: challenge the Hunters' monster-slaying claims or accept
// ###################################################################

    void passage186_Init()
    {
        this.Passages[@"EvilHunter1Event"] = new StoryPassage(@"EvilHunter1Event", new string[] { }, passage186_Main);
    }

    IStoryThread passage186_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Preposterous");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return text("And how could they be sure of these claims to rid the land of monsters? Could the" +
            " superstitions of ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("have influenced their decisions so completely?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"But, perhaps a sense of safety or convenience had overwhelmed the cousins' frugal disposition. Whatever their motivations, several journal entries noted that without the combined efforts of the group, refusal to pay mandated taxes would only cause undue negative attention.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        yield return text("All players take their Voting token into their hand. Players will secretly choose" +
            " a side to place face up in their palm. Then, they will close their fist and ext" +
            "end it to the center of the table.");
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
            yield return text("Challenge the Hunters");
        }
        yield return text(" ");
        yield return text("about their monster hunting claims.");
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
            yield return text("Accept their story");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("When all players have chosen, all players reveal their votes. Tally all the votes" +
            " and the side with the most votes wins. ");
        using (styleScope("italic", true))
        {
            yield return text("Ties are broken by the last player in turn order.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the vote.", "EvilHunter1Event2", null);
        using (styleScope("hook", "h0000186"))
            yield return link("Click here to start the vote...", null, () => enchantHook("h0000186", HarloweEnchantCommand.None, passage186_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage186_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("EvilHunter1Event2", BiddingSystem.Voting);
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesEvil1   (passage187)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21787-21847
// Links:  TieredRewards1
// Aborts: -
// Purpose: Bloody wolf messenger demands an Experiment donation, or lose a Servant
// ###################################################################

    void passage187_Init()
    {
        this.Passages[@"WolvesEvil1"] = new StoryPassage(@"WolvesEvil1", new string[] { }, passage187_Main);
    }

    IStoryThread passage187_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Call for Assistance");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Each cousin's recollection of events seems to corroborate the same story during the Summer of 1892. A messenger, obviously meant to intimidate, arrived by carriage unannounced precisely at noon, dressed in a dapper gray suit stained in thick streaks by rivulets of blood that cascaded from his shoulders. He wore a mask of gore, his animalistic features stained a sanguine red that still dripped from the tips of his teeth, his belly distending the buttons as if he had recently enjoyed a horrifying meal.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"""I come to collect,"" he entreated with a bow and disgusting lick of his lips. ""It is by our pleasure that you and your family remain alive. And we have need of the knowledge of experimentation that you most assuredly can provide. If this cannot be arranged,"" he paused, pointing in the direction of a servant, ""I have slaked my thirst on the blood of lesser individuals than these today, that I guarantee.""");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Making a deal with demons? It was impossible for the young scientists to expect a" +
            "n entirely trustworthy offer as presented, yet to allow a human to be knowingly " +
            "sacrificed to the jaws of these grotesque animals would also be unconscionable.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        yield return text("In turn order, each player decides whether to contribute an Experiment. Donated E" +
            "xperiments are turned face-down and placed under your Masterwork card.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If a player donates, they will receive an immediate bonus based on the level of t" +
            "he Experiment they donate (");
        using (styleScope("italic", true))
        {
            yield return text("higher levels granting higher rewards");
        }
        yield return text(").");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If a player chooses not to donate, they will ");
        using (styleScope("bold", true))
        {
            yield return text("lose a Servant");
        }
        yield return text(" ");
        yield return text("and ");
        using (styleScope("bold", true))
        {
            yield return text("gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to receive bonuses and penalties...", "TieredRewards1", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: TaxesEventNoConfrontation   (passage189)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21962-22053
// Links:  -
// Aborts: -
// Purpose: Rising Hunter taxes: pay $2/2 resources or discard a Hunter token
// ###################################################################

    void passage189_Init()
    {
        this.Passages[@"TaxesEventNoConfrontation"] = new StoryPassage(@"TaxesEventNoConfrontation", new string[] { }, passage189_Main);
    }

    IStoryThread passage189_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Rising Cost of Living");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"While the townsfolk grumbled at the mention of a continuing increase in taxation, they clutched their crosses to their chests and remained thankful for the Hunters' continued vigilance. Because of their previous acquiescence, the family could no longer voice their displeasure and was forced to remunerate the Fraternity for their service if they had not done so already.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage189_Fragment_2);
        using (styleScope("hook", "h000189"))
            yield return link("Click to continue...", null, () => enchantHook("h000189", HarloweEnchantCommand.Replace, passage189_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage189_Fragment_0()
    {
        yield return abort(goToPassage: macros1.either("TaxesEventNoConfrontation2", "GloomyGothic3"));
        yield break;
    }

    IStoryThread passage189_Fragment_1()
    {
        //yield return lineBreak();
        if (Vars.TaxesEventNoConfrontationnextPsg == "" || Vars.TaxesEventNoConfrontationnextPsg == 0)
        {
            Vars.TaxesEventNoConfrontationnextPsg = macros1.either("TaxesEventNoConfrontation2", "GloomyGothic3");
        }
        ViewItemObtain.SetupPassagename = Vars.TaxesEventNoConfrontationnextPsg;
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_HunterToken";
            yield return lineBreak();
            yield return text("Any player that does not have a Servant/Spouse piece on ");
            using (styleScope("bold", true))
            {
                yield return text("The Hunter\'s Rest");
            }
            yield return text(" ");
            yield return text("must ");
            using (styleScope("bold", true))
            {
                yield return text("pay $2");
            }
            yield return text(" ");
            yield return text("OR ");
            using (styleScope("bold", true))
            {
                yield return text("2 resources");
            }
            yield return text(" ");
            yield return text("to the supply. If this is not possible, they instead ");
            using (styleScope("bold", true))
            {
                yield return text("lose 3VP");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Alternatively, any player with a Hunter token ");
            using (styleScope("bold", true))
            {
                yield return text("MUST");
            }
            yield return text(" ");
            yield return text("now discard it to the scenario box to invoke their privilege and forgo this payme" +
                "nt.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00166"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00166", HarloweEnchantCommand.Replace, passage189_Fragment_0));
        yield break;
    }

    IStoryThread passage189_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage189_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: TaxesEventStart   (passage190)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22058-22089
// Links:  CharityNegCons
// Aborts: -
// Purpose: "The Hunt Begins": Hunters seize public favor and impose a tax
// ###################################################################

    void passage190_Init()
    {
        this.Passages[@"TaxesEventStart"] = new StoryPassage(@"TaxesEventStart", new string[] { }, passage190_Main);
    }

    IStoryThread passage190_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Hunt Begins");
        }
        yield return lineBreak();
        yield return text(@"The hunter stood upon the steps of the Hunter's Lodge, dressed in a leather trenchcoat and holding a crossbow in his left hand. His garments were speckled in fresh streaks of blood while other members of the Fraternity stood nearby in black raincoats, brandishing handaxes, pistols, and muskets, holding aloft severed trophies from monsters slain in the wilderness. They had returned from the hunt.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The hunter spoke to the crowd of townspeople that had assembled, his eyes barely visible under the wide brim of his hat. ""No longer will this great city be forced to endure this hardship. We, the Fraternity of Hunters, will take the fight to the beasts of the forest. It is the monsters within these very hills that brought with them a pestilence and spread their sinful disease across the land. And with your assistance, we will exterminate these vermin and drive them back to hell once again!""");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The speech evoked jubilant cheers from the populace and the Fraternity\'s dominanc" +
            "e over the town was secured. Even a modest ");
        using (styleScope("bold", true))
        {
            yield return text("tax");
        }
        yield return text(" ");
        yield return text("from the new local government to help pay for the hunter\'s excursions into the wi" +
            "lds was met without skepticism.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "CharityNegCons", null);
        yield break;
    }

// ###################################################################
// PASSAGE: EvilHunter1EventYes   (passage191)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22095-22132
// Links:  GloomyGothic2
// Aborts: -
// Purpose: Family challenges the Hunters; a Grand Contest is arranged; leads to GloomyGothic2
// ###################################################################

    void passage191_Init()
    {
        this.Passages[@"EvilHunter1EventYes"] = new StoryPassage(@"EvilHunter1EventYes", new string[] { }, passage191_Main);
    }

    IStoryThread passage191_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Prepare a Contest");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The family underwent months of travel both by day and the pale light of the moon with barely the whisper of an ill wind or the echo of a beastly wail. It was clear to their scientific minds that these demonic occurrences were nothing more than mere flights of fancy. Without hesitance, they relayed these accusations against the ");
        using (styleScope("bold", true))
        {
            yield return text("Fraternity of Hunters");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"After an exchange of exasperated guffaws, it was decided that the Fraternity would provide guaranteed proof of their supernatural exploits by confronting the cursed beasts of the evening in full view of the townspeople. A great festival was planned around the contest, and under the light of a blood moon they would venture into the cursed hills and return with more trophies than ever before. But, if they were successful, the scientists would owe them a debt, ");
        using (styleScope("bold", true))
        {
            yield return text("with interest");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The cousins agreed to the terms while also devising a most insidious plot. They c" +
            "hortled with undisguised laughter. If the Hunters wanted a true bounty, they wou" +
            "ld give it to them!");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "GloomyGothic2", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HunterConfrontation   (passage192)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22138-22178
// Links:  CannotParticipate
// Aborts: -
// Purpose: The Grand Contest night: cousins release Experiments against the Hunters
// ###################################################################

    void passage192_Init()
    {
        this.Passages[@"HunterConfrontation"] = new StoryPassage(@"HunterConfrontation", new string[] { }, passage192_Main);
    }

    IStoryThread passage192_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Grand Contest - April, 1902");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("After years of apologies and unfortunate delays by the ");
        using (styleScope("bold", true))
        {
            yield return text("Fraternity of Hunters");
        }
        yield return text(", the night of the Grand Contest had arrived. The confrontation had been touted e" +
            "xtensively within the region and visitors gathered near the ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("Lodge to witness the spectacle of the hunt. The Hunters were treated to a tickert" +
            "ape parade and glorious feast. But, as the light of the afternoon slowly faded, " +
            "the sky began to glow with fiery intensity, and the revelry ceased.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The Hunters donned their signature clothes, took up their well-polished arms, and" +
            " proceeded down the main thoroughfare while the crimson light of the blood moon " +
            "heralded their exit into the forests beyond.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("That same fire reflected in the eyes of the scientists as they stifled their grim" +
            " laughter. The night before, the cousins had prepared their chosen Experiments t" +
            "o release into the wild. It was time now for the Hunters to become the prey!");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to Resolve the Event...", "CannotParticipate", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: OhYesTheyDead   (passage193)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22184-22268
// Links:  GloomyGothic3
// Aborts: -
// Purpose: Contest success: Hunters exposed and hanged; VP for the top Experiment
// ###################################################################

    void passage193_Init()
    {
        this.Passages[@"OhYesTheyDead"] = new StoryPassage(@"OhYesTheyDead", new string[] { }, passage193_Main);
    }

    IStoryThread passage193_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A \"Hero's\" Welcome");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The cousins enjoyed fresh pastries and coffee as they admired the town's activities with amusement from their folding lawn chairs. When the triumphant return they had expected never came, the gathered crowds became restless and burst into the Hunter's Lodge only to discover stores of freshly slaughtered goat's blood and taxidermy supplies. The Fraternity had played them for fools.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The town gallows had fallen into disrepair over the years, but upon the return of the remaining wild-eyed hunters that somehow survived the vicious experiments, lumber was quickly procured by the decidedly unimpressed townsfolk along with fresh hemp rope, thick and strong. The same crowd that gathered that afternoon for the festivities would be the crowd that watched every last writhing body swing lifeless for their crimes. If any Hunters did survive, they most certainly never returned.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The people would speak of the Grand Contest as one of the crowning events in the " +
            "history of ");
        yield return text(Vars.townname);
        yield return text(". Having rooted out the evil infesting their government, the town entered a perio" +
            "d of peace that was especially productive for a group of scientists.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage193_Fragment_1);
        using (styleScope("hook", "h000193"))
            yield return link("Click to continue...", null, () => enchantHook("h000193", HarloweEnchantCommand.Replace, passage193_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage193_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic3";
        Vars.taxes = "no";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "ScoreTrackMarker";
            yield return lineBreak();
            yield return text("The player(s) who contributed the Experiment worth the highest VP gains ");
            using (styleScope("bold", true))
            {
                yield return text(Vars.huntvp);
                yield return text("VP");
            }
            yield return text(". ");
            using (styleScope("italic", true))
            {
                yield return text("All tied players gain this VP.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token ");
            using (styleScope("bold", true))
            {
                yield return text("2 spaces");
            }
            yield return text(" ");
            yield return text("to the right.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("All contributed Experiments are then discarded to the bottom of the appropriate E" +
                "xperiment decks.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic3", null);
        yield break;
    }

    IStoryThread passage193_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage193_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: ConfrontationFail   (passage194)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22273-22376
// Links:  GloomyGothic3
// Aborts: -
// Purpose: Contest failure: Hunters triumphant; VP bonus plus a group penalty
// ###################################################################

    void passage194_Init()
    {
        this.Passages[@"ConfrontationFail"] = new StoryPassage(@"ConfrontationFail", new string[] { }, passage194_Main);
    }

    IStoryThread passage194_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Hero\'s Welcome");
        }
        yield return lineBreak();
        Vars.taxes = "yes";
        yield return lineBreak();
        yield return text(@"The Hunters return relatively unscathed by the proceedings to a resounding cheer from the excited crowd. Covered in blood and oil, with the trophies of their victory held high, they regaled the crowd with their highly embellished and harrowing tale. Each ferocious severed head receiving more applause than the last.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("For a family that until now had never been forced to admit shame, the blow was un" +
            "mistakable. Disheartened and angry with their current fate, they silently immers" +
            "ed themselves in their labors, resolved to avoid further visits to town at all c" +
            "osts.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Experimental Bonus");
        }
        yield return lineBreak();
        yield return text("The player(s) who contributed the Experiment worth the highest VP gains ");
        using (styleScope("bold", true))
        {
            yield return text(Vars.huntvp);
        }
        yield return text(". ");
        using (styleScope("italic", true))
        {
            yield return text("All tied players gain this VP.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("All contributed Experiments are discarded.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage194_Fragment_1);
        using (styleScope("hook", "h000194"))
            yield return link("Click to continue...", null, () => enchantHook("h000194", HarloweEnchantCommand.Replace, passage194_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage194_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AngryMob_Icon";
            yield return lineBreak();
            yield return text("Move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("token ");
            yield return text(macros1.either(2, 3));
            yield return text(" ");
            yield return text("spaces to the left.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("ALL players must choose and perform one penalty:");
            }
            yield return lineBreak();
            yield return text("Pay $3.");
            yield return lineBreak();
            yield return text("Return 3 resources to the supply.");
            yield return lineBreak();
            yield return text("Discard 2 Estate Upgrades.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("If this is not possible, they instead ");
                using (styleScope("bold", true))
                {
                    yield return text("lose 5VP");
                }
                yield return text(".");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic3", null);
        yield break;
    }

    IStoryThread passage194_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage194_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: HunterConf2   (passage195)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22381-22456
// Links:  HunterConf3
// Aborts: -
// Purpose: "Experiments Unleashed": secret simultaneous donation totalled vs a threshold
// ###################################################################

    void passage195_Init()
    {
        this.Passages[@"HunterConf2"] = new StoryPassage(@"HunterConf2", new string[] { }, passage195_Main);
    }

    IStoryThread passage195_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("EXPERIMENTS UNLEASHED");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return text("All remaining eligible players take all the Experiments they have completed ");
        using (styleScope("bold", true))
        {
            yield return text("this Generation");
        }
        yield return text(" ");
        yield return text("into their hands ");
        using (styleScope("italic", true))
        {
            yield return text("(excluding any Masterwork)");
        }
        yield return text(". Then, they secretly choose an Experiment card (or no card at all) and keep it h" +
            "idden under their palm.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Once all players have chosen, all players reveal the card (or no card) they have " +
            "chosen simultaneously. This card will be discarded after the event is resolved.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Then, players will ");
        using (styleScope("bold", true))
        {
            yield return text("count up the total value of the VP on all donated Experiment cards.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the value is equal to ");
        if (Vars.players == 2)
        {
            Vars.huntnum = macros1.random(3, 7);
        }
        if (Vars.players == 3)
        {
            Vars.huntnum = macros1.random(8, 12);
        }
        if (Vars.players == 4)
        {
            Vars.huntnum = macros1.random(11, 15);
        }
        if (Vars.players == 5)
        {
            Vars.huntnum = macros1.random(13, 19);
        }
        yield return text(Vars.huntnum);
        yield return text(" ");
        yield return text("or higher, the unleashed experiments will succeed.");
        yield return lineBreak();
        yield return text("If the value is less, the hunters will prevail.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the bid.", "HunterConf3", null);
        using (styleScope("hook", "h0000195"))
            yield return link("Click to start the bid.", null, () => enchantHook("h0000195", HarloweEnchantCommand.None, passage195_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage195_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("HunterConf3", BiddingSystem.Bidding);
        yield break;
    }

// ###################################################################
// PASSAGE: TaxesEventNoConfrontation2   (passage196)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 22461-22527
// Links:  GloomyGothic3
// Aborts: -
// Purpose: "A Pittance": lose 2 Creepy or gain an ingredient after consenting to taxation
// ###################################################################

    void passage196_Init()
    {
        this.Passages[@"TaxesEventNoConfrontation2"] = new StoryPassage(@"TaxesEventNoConfrontation2", new string[] { }, passage196_Main);
    }

    IStoryThread passage196_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Pittance");
        }
        yield return lineBreak();
        yield return text("While it amounted to little less than political pandering, the Hunters did, howev" +
            "er, offer kind words and assurances to the people of ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("in response to the family\'s gentle consent to further taxation. This did nothing " +
            "to soothe the financial stress it placed upon them, nor did it cool their sneeri" +
            "ng derision when the deeds of the Hunters were brought up in casual conversation" +
            "s about town.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage196_Fragment_1);
        using (styleScope("hook", "h000196"))
            yield return link("Click to continue...", null, () => enchantHook("h000196", HarloweEnchantCommand.Replace, passage196_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage196_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("All players, in turn order, may choose to either ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("or ");
            using (styleScope("bold", true))
            {
                yield return text("gain an ingredient");
            }
            yield return text(" ");
            yield return text("of their choice from the supply.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic3", null);
        yield break;
    }

    IStoryThread passage196_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage196_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesEvil2   (passage219)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24448-24504
// Links:  TieredRewards2
// Aborts: -
// Purpose: Second Order tithe: donate an Experiment for a tiered bonus or lose a Servant
// ###################################################################

    void passage219_Init()
    {
        this.Passages[@"WolvesEvil2"] = new StoryPassage(@"WolvesEvil2", new string[] { }, passage219_Main);
    }

    IStoryThread passage219_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Once More the Accursed Contribution");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The messenger did not appear until nightfall, whereupon the lateness of arrival interrupted the cousins' dessert and coffee. The moonlight reflected off his steel gaze as he entered the sitting room without invitation. His fangs had tasted blood that same night.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The family could delay their offering no longer and the beasts of the Order saliv" +
            "ated with anticipation over the knowledge they would soon acquire.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        yield return text("In turn order, each player decides whether to contribute an Experiment. Donated E" +
            "xperiments are turned face-down and placed under your Masterwork card.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If a player donates, they will receive an immediate bonus based on the level of E" +
            "xperiment they donate (");
        using (styleScope("italic", true))
        {
            yield return text("higher levels granting higher rewards");
        }
        yield return text(").");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If a player chooses not to donate, they will ");
        using (styleScope("bold", true))
        {
            yield return text("lose a Servant");
        }
        yield return text(" ");
        yield return text("and ");
        using (styleScope("bold", true))
        {
            yield return text("gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to receive bonuses and penalties...", "TieredRewards2", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HelpingEvil   (passage228)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25040-25299
// Links:  GloomyHunterIntro,GloomyWolvesIntro
// Aborts: -
// Purpose: Inheritance reward for aiding evil: 4VP + token + Master's Study upgrades
// ###################################################################

    void passage228_Init()
    {
        this.Passages[@"HelpingEvil"] = new StoryPassage(@"HelpingEvil", new string[] { }, passage228_Main);
    }

    IStoryThread passage228_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Reward for Service");
        }
        yield return lineBreak();
        yield return text("Upon receipt of their inheritance, the newest Generation of scientists were surpr" +
            "ised to find a generous addendum attached by the ");
        yield return text(Vars.society);
        yield return text(". Aside from the notoriety afforded by this gift, as promised, a permanent struct" +
            "ure was to be erected on their properties to aid in their experimental pursuits." +
            "");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage228_Fragment_1);
        using (styleScope("hook", "h000228"))
            yield return link("Click to continue...", null, () => enchantHook("h000228", HarloweEnchantCommand.Replace, passage228_Fragment_0));
        yield break;
    }

    IStoryThread passage228_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "HelpingEvil2";//Vars.society == "Fraternity of Hunters" ? "GloomyHunterIntro" : "GloomyWolvesIntro";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = Vars.society == "Fraternity of Hunters" ? "S1_HunterToken" : "S1_WolfToken";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text(Vars.society);
            }
            yield return text(" ");
            yield return text("tokens. Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Master\'s Study");
            }
            yield return text(" ");
            yield return text("Vanity Estate Upgrades.");
            yield return lineBreak();
            yield return lineBreak();
            if (Vars.society == "Fraternity of Hunters")
            {
                if (Vars.allyA == "hunters")
                {
                    yield return text(Vars.nameA);
                    yield return text(" III gains ");
                    using (styleScope("bold", true))
                    {
                        yield return text("4VP");
                    }
                    yield return text(" and gains a ");
                    yield return text(Vars.society);
                    yield return text(" token.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
                if (Vars.allyB == "hunters")
                {
                    yield return text(Vars.nameB);
                    yield return text(" III gains ");
                    using (styleScope("bold", true))
                    {
                        yield return text("4VP");
                    }
                    yield return text(" and gains a ");
                    yield return text(Vars.society);
                    yield return text(" token.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
                if (Vars.players > 2)
                {
                    if (Vars.allyC == "hunters")
                    {
                        yield return text(Vars.nameC);
                        yield return text(" III gains ");
                        using (styleScope("bold", true))
                        {
                            yield return text("4VP");
                        }
                        yield return text(" and gains a ");
                        yield return text(Vars.society);
                        yield return text(" token.");
                        yield return lineBreak();
                        yield return lineBreak();
                    }
                }
                if (Vars.players > 3)
                {
                    if (Vars.allyD == "hunters")
                    {
                        yield return text(Vars.nameD);
                        yield return text(" III gains ");
                        using (styleScope("bold", true))
                        {
                            yield return text("4VP");
                        }
                        yield return text(" and gains a ");
                        yield return text(Vars.society);
                        yield return text(" token.");
                        yield return lineBreak();
                        yield return lineBreak();
                    }
                }
                if (Vars.players > 4)
                {
                    if (Vars.allyE == "hunters")
                    {
                        yield return text(Vars.nameE);
                        yield return text(" III gains ");
                        using (styleScope("bold", true))
                        {
                            yield return text("4VP");
                        }
                        yield return text(" and gains a ");
                        yield return text(Vars.society);
                        yield return text(" token.");
                        yield return lineBreak();
                        yield return lineBreak();
                    }
                }
            }
            //if (Vars.society == "Order of St. Hubertus")
            else
            {
                if (Vars.allyA == "wolves")
                {
                    yield return text(Vars.nameA);
                    yield return text(" III gains ");
                    using (styleScope("bold", true))
                    {
                        yield return text("4VP");
                    }
                    yield return text(" and gains a ");
                    yield return text(Vars.society);
                    yield return text(" token.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
                if (Vars.allyB == "wolves")
                {
                    yield return text(Vars.nameB);
                    yield return text(" III gains ");
                    using (styleScope("bold", true))
                    {
                        yield return text("4VP");
                    }
                    yield return text(" and gains a ");
                    yield return text(Vars.society);
                    yield return text(" token.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
                if (Vars.players > 2)
                {
                    if (Vars.allyC == "wolves")
                    {
                        yield return text(Vars.nameC);
                        yield return text(" III gains ");
                        using (styleScope("bold", true))
                        {
                            yield return text("4VP");
                        }
                        yield return text(" and gains a ");
                        yield return text(Vars.society);
                        yield return text(" token.");
                        yield return lineBreak();
                        yield return lineBreak();
                    }
                }
                if (Vars.players > 3)
                {
                    if (Vars.allyD == "wolves")
                    {
                        yield return text(Vars.nameD);
                        yield return text(" III gains ");
                        using (styleScope("bold", true))
                        {
                            yield return text("4VP");
                        }
                        yield return text(" and gains a ");
                        yield return text(Vars.society);
                        yield return text(" token.");
                        yield return lineBreak();
                        yield return lineBreak();
                    }
                }
                if (Vars.players > 4)
                {
                    if (Vars.allyE == "wolves")
                    {
                        yield return text(Vars.nameE);
                        yield return text(" III gains ");
                        using (styleScope("bold", true))
                        {
                            yield return text("4VP");
                        }
                        yield return text(" and gains a ");
                        yield return text(Vars.society);
                        yield return text(" token.");
                        yield return lineBreak();
                        yield return lineBreak();
                    }
                }
            }
            yield return lineBreak();
            //yield return text("Then, starting with the player with the ");
            //using (styleScope("bold", true))
            //{
            //    yield return text("most Victory Points");
            //}
            //yield return text(" ");
            //yield return text("and continuing in descending order of points, each player with a ");
            //yield return text(Vars.society);
            //yield return text(" ");
            //yield return text("token chooses a ");
            //using (styleScope("bold", true))
            //{
            //    yield return text("Master\'s Study");
            //}
            //yield return text(" ");
            //yield return text("to build on their Estate. No additional cost is paid for a new plot to place this" +
            //    " tile. ");
            //using (styleScope("italic", true))
            //{
            //    yield return text("(Ties are broken by the player that went later in turn order in the previous roun" +
            //    "d.) Return all unclaimed tiles to the box.");
            //}
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.society == "Fraternity of Hunters")
        //{
        //    yield return link("Click to continue...", "GloomyHunterIntro", null);
        //}
        //if (Vars.society == "Order of St. Hubertus")
        //{
        //    yield return link("Click to continue...", "GloomyWolvesIntro", null);
        //}
        yield break;
    }

    IStoryThread passage228_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage228_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: MWTokenResolve   (passage229)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25360-25433
// Links:  GloomyGothic1,GloomyGothic2,GloomyGothic3
// Aborts: -
// Purpose: Masterwork completion under monster oversight: -4VP per stored Experiment
// ###################################################################

    void passage229_Init()
    {
        this.Passages[@"MWTokenResolve"] = new StoryPassage(@"MWTokenResolve", new string[] { }, passage229_Main);
    }

    IStoryThread passage229_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Work is Complete");
        }
        yield return lineBreak();
        Vars.gen3pg = 1;
        yield return lineBreak();
        yield return text(@"The gathering of clawed monstrosities celebrated with keening wails as the Masterwork was completed in all of its glory. Surely, the legacy of the family would be secured forever. Yet, the watchful, glowing eyes of the crowd did not share this same deference to sentimentality.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"A furious cacophony of growls sounded as the monsters surrounded the experiment. Some scribbled away at notes, copying the formulas and schematics as best as they could while others simply traced every minute detail with their fingers and observed with interest.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was clear that they would have been much more able to understand and reproduce" +
            " the results of the experiment if they had been given earlier access to the cous" +
            "in\'s work over the years.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click here to return...", passage229_Fragment_1);
        using (styleScope("hook", "h000229"))
            yield return link("Click to continue...", null, () => enchantHook("h000229", HarloweEnchantCommand.Replace, passage229_Fragment_0));
        yield break;
    }

    IStoryThread passage229_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 10 ? "GloomyGothic1" : Vars.round == 11 ? "GloomyGothic2" : "GloomyGothic3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "ScoreTrackMarker";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Resolve your Masterwork as normal. Then, for each Experiment under your Masterwor" +
                "k, ");
            using (styleScope("bold", true))
            {
                yield return text("lose 4VP");
            }
            yield return text(". Discard all cards under your Masterwork.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 10)
        //{
        //    yield return link("Click here to return...", "GloomyGothic1", null);
        //}
        //if (Vars.round == 11)
        //{
        //    yield return link("Click here to return...", "GloomyGothic2", null);
        //}
        //if (Vars.round == 12)
        //{
        //    yield return link("Click here to return...", "GloomyGothic3", null);
        //}
        yield break;
    }

    IStoryThread passage229_Fragment_1()
    {
        yield return enchant("Click here to return...", HarloweEnchantCommand.Replace, passage229_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: EvilWolves1Note   (passage258)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27697-27852
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: Evil Wolves / Evil Hunters branch design and rewards
// ###################################################################

    IStoryThread passage258_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("University1", "UniEquity1");
        yield break;
    }

    void passage258_Init()
    {
        this.Passages[@"EvilWolves1Note"] = new StoryPassage(@"EvilWolves1Note", new string[] { }, passage258_Main);
    }

    IStoryThread passage258_Main()
    {
        yield return text("CODE:");
        yield return lineBreak();
        yield return text("LosingOrderAid entry should NOT appear if no one has joined the Losing faction.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("EVIL WOLVES -");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("EVIL bonus - players given a token");
        yield return lineBreak();
        yield return text("GOOD penalty - can\'t use Monster Spawn in town. Gain Creepy.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Lycanthropic Strength check");
        yield return lineBreak();
        yield return text("If Bank was built - Mayor Award.");
        yield return lineBreak();
        yield return text("Masterwork Award - 1st to complete.");
        yield return lineBreak();
        yield return text("Charity penalty - ??");
        yield return lineBreak();
        yield return text("Ask for Experiments. Or Eat Servants. - those accepting the cure are unable to re" +
            "fuse. OR masterwork is shared.");
        yield return lineBreak();
        yield return text("Occult Experiments encouraged");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Personal Event Bonus - Steal an Experiment that was donated.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A VIAL to cleanse this evil from the land.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("SETUP");
        yield return lineBreak();
        yield return text("Retrieve the Spawning Pods Vanity Estate Tile.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Spread their message of dreadful bloodlust and recruit others.");
        yield return lineBreak();
        yield return text("They allow for Experiments in the City Limits. They know we can help and require " +
            "it or they will eat our SERVANTS. But, each round they offer something in return" +
            " for our sacrifice.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Something happens when a player completes a Masterwork. Place a Storybook token t" +
            "here.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("- Most Creepy Player");
        yield return lineBreak();
        yield return text("- Player that donates the most Experiment cards total to the Monster cause");
        yield return lineBreak();
        yield return text("will receive a Spawning Pods Vanity Estate Tile.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("EVENT? I like Revenge for the player that\'s losing. They choose a player to have " +
            "to fight.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Could rename Labor to Human Jail");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Other ideas -");
        yield return lineBreak();
        yield return text("Creepy Meter alteration. Could just be way less emphasis on Creepiness even thoug" +
            "h they still have a limit.");
        yield return lineBreak();
        yield return text("Occult Experiments Encouraged - Most receives points.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("EVIL HUNTERS -");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("GOOD consequence - can\'t use token. Also move on Creepy.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If Bank was built - Mayor Award");
        yield return lineBreak();
        yield return text("Charity penalty - ??");
        yield return lineBreak();
        yield return text("Chemistry Award");
        yield return lineBreak();
        yield return text("1st round Vote - call the Hunters out as fakes, challenge them to a contest.");
        yield return lineBreak();
        yield return text("- those accepting the cure are unable to plot against the Hunters cannot count th" +
            "eir Experiments towards the Event.");
        yield return lineBreak();
        yield return text("2nd round Event - donate experiments and add up VP - Either minor reward or donat" +
            "ion of Experiment to release into the wild.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Chemistry Award given to player");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Building Gets Checked at end of every round. If a player hasn\'t performed the act" +
            "ion, they take a penalty.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hunters - MONSTERS ARE NOT REAL IN THIS LINE");
        yield return lineBreak();
        yield return text("wealth, fame, and power. Something which they will fight to keep, but will not fi" +
            "ght actual monsters.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("1st round - family meeting! Do we confront the liars and antagonize them (gain Cr" +
            "eepy and potentially other negatives). Or do we allow them to continue their rus" +
            "e (pay taxes and stay the course).");
        yield return lineBreak();
        yield return text("VOTE - use Voting token.");
        yield return lineBreak();
        yield return text("- players that accepted the CURE have their votes overturned.");
        yield return lineBreak();
        yield return text("- most votes win.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Chemistry Experiments Encouraged");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("NOT IMPLEMENTED IDEAS:");
        yield return lineBreak();
        yield return text("Gain the completed Experiment of another player. That player loses 3VP.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("EVENT? I like Revenge for the player that\'s losing. They choose a player to have " +
            "to fight.");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: EvilWolvesEventStart   (passage259)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27858-27892
// Links:  VialCharity
// Aborts: -
// Purpose: The Order's underground spawning-pit lab offered in exchange for tribute
// ###################################################################

    void passage259_Init()
    {
        this.Passages[@"EvilWolvesEventStart"] = new StoryPassage(@"EvilWolvesEventStart", new string[] { }, passage259_Main);
    }

    IStoryThread passage259_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Monster Without");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The Order of St. Hubertus' Lodge held a dark secret in the miasmic recesses beneath the edifice above, and after navigating a steep spiraling stone staircase, the cousins found themselves in a large stone room: a makeshift laboratory deep enough beneath the earth that the walls were warm with heat. Glass baubles and pilfered tools were stacked haphazardly around several wooden workspaces with failed experiments and devices thrown into metal waste bins beneath.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The Lodge's caretaker extended a long clawed hand towards the center of the room, where a large circular stone well squatted. When they peered inside, they saw the infernal spawning grounds. Slime-covered beasts wallowed within a murky pit sloshing with the putrid stench of rotten meat. They wailed in unseen torment as the caretakers of the Order snapped coiled whips to frighten the malformed wretches into submission.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The caretaker spoke in a harsh, gravelly tone, \"You are free to use this place as" +
            " you wish. All that we ask is for a single experiment when we call upon you. Alt" +
            "ernatively, our children here are always so very hungry.\"");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was a dark boon indeed to be offered a place in town to ");
        using (styleScope("bold", true))
        {
            yield return text("perform experiments");
        }
        yield return text(", but what would this horrible convenience cost them?");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "VialCharity", null);
        yield break;
    }

// ###################################################################
// PASSAGE: TieredRewards1   (passage263)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28195-28287
// Links:  GloomyGothic2
// Aborts: -
// Purpose: Resolves the first Order tribute; tiered rewards by donated Experiment level
// ###################################################################

    void passage263_Init()
    {
        this.Passages[@"TieredRewards1"] = new StoryPassage(@"TieredRewards1", new string[] { }, passage263_Main);
    }

    IStoryThread passage263_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Reckoning");
        }
        yield return lineBreak();
        yield return text("The messenger from the Order thanked the scientists and vowed to return once agai" +
            "n after a time.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage263_Fragment_1);
        using (styleScope("hook", "h000263"))
            yield return link("Click to continue...", null, () => enchantHook("h000263", HarloweEnchantCommand.Replace, passage263_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage263_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_WolfToken";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that donated an ");
            using (styleScope("bold", true))
            {
                yield return text("A Experiment");
            }
            yield return text(":");
            yield return lineBreak();
            yield return text(macros1.either("Gain 1VP.", "Gain an ingredient of your choice.", "Receives no bonus.", "Loses 1VP. The Order is unpleased with this meager offering."));
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that donated a ");
            using (styleScope("bold", true))
            {
                yield return text("B Experiment");
            }
            yield return text(":");
            yield return lineBreak();
            yield return text(macros1.either("Gain a Knowledge of your choice.", "Gain $2.", "Gain 2VP."));
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that donated a ");
            using (styleScope("bold", true))
            {
                yield return text("C Experiment");
            }
            yield return text(":");
            yield return lineBreak();
            yield return text(macros1.either("Gain 4VP.", "Gain $4."));
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that chose not to donate ");
            using (styleScope("bold", true))
            {
                yield return text("returns a Servant to Lost");
            }
            yield return text(" ");
            yield return text("and ");
            using (styleScope("bold", true))
            {
                yield return text("gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(". ");
            yield return text("<i>If you cannot lose a Servant, lose 3VP instead.</i>");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic2", null);
        yield break;
    }

    IStoryThread passage263_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage263_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: CannotParticipate   (passage264)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28292-28373
// Links:  HunterConf2
// Aborts: -
// Purpose: Players with a stored Hereditary Disease Experiment are barred from the Grand Contest
// ###################################################################

    void passage264_Init()
    {
        this.Passages[@"CannotParticipate"] = new StoryPassage(@"CannotParticipate", new string[] { }, passage264_Main);
    }

    IStoryThread passage264_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("In the Blood");
        }
        yield return lineBreak();
        yield return text("However, at their final moment of triumph, an unfortunate occurrence in the famil" +
            "y\'s past could have potentially unraveled their attempt to overthrow the Hunters" +
            "\' dominion over this fair village.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"In the interim evenings before the event could begin, for some, the very thought of confronting the Hunters made them desperately ill. It was as if some occult power had a hold over their senses. This nausea quickly turned to resolve and some even questioned why they had ever doubted the veracity of the Hunters' claims.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("But, how could their parents have envisioned a strong curse would have been place" +
            "d upon them when they decided to accept the ");
        using (styleScope("bold", true))
        {
            yield return text("cure");
        }
        yield return text(" ");
        yield return text("so many years ago?");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage264_Fragment_1);
        using (styleScope("hook", "h000264"))
            yield return link("Click to continue...", null, () => enchantHook("h000264", HarloweEnchantCommand.Replace, passage264_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage264_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "HunterConf2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player with a ");
            using (styleScope("bold", true))
            {
                yield return text("STORED Hereditary Disease Experiment");
            }
            yield return text(" ");
            yield return text("card cannot donate an Experiment to this Event. They immediately ");
            using (styleScope("bold", true))
            {
                yield return text("Lose 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(" ");
            yield return text("and return the stored ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" ");
            yield return text("to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "HunterConf2", null);
        yield break;
    }

    IStoryThread passage264_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage264_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyWolvesIntro   (passage287)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 29359-29398
// Links:  EvilConsequences
// Aborts: -
// Purpose: Generation III intro "The Order Revealed" (Wolves variant of the gloomy branch)
// ###################################################################

    void passage287_Init()
    {
        this.Passages[@"GloomyWolvesIntro"] = new StoryPassage(@"GloomyWolvesIntro", new string[] { "INTRO", }, passage287_Main);
    }

    IStoryThread passage287_Main()
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
        yield return text(@"Amongst the forests of the Romanian countryside, nestled in shadowed valleys of the Carpathian mountains, there are places so far removed from the rest of the world as to appear almost invisible in their machinations. In shadows tucked away amongst the deepest tangled forests, from the darkest crevices burrowed deep into the earth, these are the places where our most pervasive legends and folklore emerge. And in their isolation, it grows.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The next generation's return was marked by a most startling and terrifying discovery. For it appeared that while the disease had left the town, another more insidious plague had befallen the land. The Order of St. Hubertus, emboldened by the success of their clandestine labors, took the opportunity afforded them and manifested in their true and cursed forms. And like the emblematic wolfhead adorning their insignia, they arose with silvered pelts, baring distended fangs and open animalistic maws that dripped with saliva. The least horrifying held this form at least, as the other beasts hosted swelling deformities and twisted extremities too repulsive to describe. The ancient evils they had unearthed from beneath the town gave them the ability to transform without the full moon's glow, and in the light of day, these monstrous beings set upon the townsfolk to enforce their rule either by coercion or by visceral and bloody execution.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The beasts were real.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"But as the Order expanded its numbers and influence, the beasts did not recognize their new forms as folly. They called themselves ""Strigoi"" (embracing the vampiric moniker given them by local folklore) and commanded quick control over the local government. To them, they were the powerful new evolution of society. They perceived humanity as the real monster!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"However, they were not unkeen to the important work of the family. In fact, they took a great interest in their experimentations, even to the point of offering their assistance. And as the new generation was thrust into this distorted new reality, they were forced to consider a most dreadful prospect: to aid these creatures in their scheme and spread their message of dreadful bloodlust or incur their loathsome wrath.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "EvilConsequences", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Preposterous   (passage288)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29404-29447
// Links:  EvilHunter1Event
// Aborts: -
// Purpose: "Are You Quite Sure?": refusing the Hunter's Tax; leads to EvilHunter1Event
// ###################################################################

    void passage288_Init()
    {
        this.Passages[@"Preposterous"] = new StoryPassage(@"Preposterous", new string[] { }, passage288_Main);
    }

    IStoryThread passage288_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Are You Quite Sure?");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Despite their proclivities towards what other weaker willed individuals might call ""a mad, unending exploration of a vile and unethical pseudoscience by the frightfully inexperienced,"" the youthful generation had one unyielding virtue: they were very rich. And the rich definitely do not pay taxes.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While a sort of hysteria may have gripped their frail psyche, the very idea that " +
            "");
        yield return text(Vars.playtxt);
        yield return text(" ");
        yield return text("noted aristocrats would pay a penalty for the privilege of living amongst these r" +
            "abble without a significant guarantee of return on investment was more absurd th" +
            "an the rumors of a portal opened to the netherworld.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players == 2)
        {
            using (styleScope("hook", "h00197"))
                yield return link("Click here to continue...", null, () => enchantHook("h00197", HarloweEnchantCommand.Replace, passage288_Fragment_0));
        }
        else
        {
            yield return link("Click here to continue...", "EvilHunter1Event", null);
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage288_Fragment_0()
    {
        Vars.confront = "yes";
        yield return abort(goToPassage: "EvilHunter1EventYes");
        yield break;
    }

// ###################################################################
// PASSAGE: TheVialUse   (passage289)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29452-29504
// Links:  VialChanged,VialSold
// Aborts: -
// Purpose: Choice: cleanse the land with the holy-water vial or sell it for $3
// ###################################################################

    void passage289_Init()
    {
        this.Passages[@"TheVialUse"] = new StoryPassage(@"TheVialUse", new string[] { }, passage289_Main);
    }

    IStoryThread passage289_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Clear Choice");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Clearly, there were no others strong enough to thwart the evil that had taken ove" +
            "r the valley and spread across the forests of Hungary. ");
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("III returned to their home with determination in their chest and retrieved the cr" +
            "ystal ");
        using (styleScope("bold", true))
        {
            yield return text("vial");
        }
        yield return text(" ");
        yield return text("now displayed above their hearth.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("With this vial of the most blessed of holy waters, they knew they could take matt" +
            "ers into their own hands and righteously reclaim the land once lost.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Alternatively and suspiciously well-timed, a traveling caravan had offered a sign" +
            "ificant sum for it recently. But, of course, ridding the land of all evil was th" +
            "e most pressing of matters.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to Cleanse", "VialChanged", null);
        yield return text(" ");
        yield return text("the land of this evil.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to Sell", "VialSold", null);
        yield return text(" ");
        yield return text("the vial for selfish reasons (for $3).");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: VialCharity   (passage290)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29510-29600
// Links:  LycanthropicMessage
// Aborts: -
// Purpose: Private screen granting the Vial token as a legacy of Gen1 charity
// ###################################################################

    void passage290_Init()
    {
        this.Passages[@"VialCharity"] = new StoryPassage(@"VialCharity", new string[] { }, passage290_Main);
    }

    IStoryThread passage290_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this storybook device to ");
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage290_Fragment_3);
        using (styleScope("hook", "h000290"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000290", HarloweEnchantCommand.Replace, passage290_Fragment_2));
        yield break;
    }

    IStoryThread passage290_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "LycanthropicMessage";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_VialToken";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Vial");
            }
            yield return text(" ");
            yield return text("token from the scenario box and place it near your Estate.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Return the <b>Heart <sprite=\"S1_HeartToken\" index=0> token</b> to the scenario box.");
        }
        //yield return link("Click to continue...", "LycanthropicMessage", null);
        yield break;
    }

    IStoryThread passage290_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage290_Fragment_0);
        yield break;
    }

    IStoryThread passage290_Fragment_2()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Legacy of Charity");
        }
        yield return lineBreak();
        yield return text("While inspecting a wooden shelf in the pantry, the unexpected clatter of crystal " +
            "on stone shook the young ");
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("III. Luckily, it appeared the vial of liquid remained undamaged, although the pap" +
            "er tag attached to the cork stopper at its top was of considerable age.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The note stated, \"A gift of Holy Water from a thankful church of God,\" and was ap" +
            "tly addressed to ");
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("the 1st. Interestingly, it had remained stored away since the charitable events o" +
            "f the long past.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage290_Fragment_1);
        using (styleScope("hook", "h00029001"))
            yield return link("Click to continue...", null, () => enchantHook("h00029001", HarloweEnchantCommand.Replace, passage290_Fragment_0));
        yield break;
    }

    IStoryThread passage290_Fragment_3()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage290_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: VialSold   (passage291)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29605-29672
// Links:  WolvesEvil2
// Aborts: -
// Purpose: Sold the vial: +$3 and 1VP, blight spreads; sets up WolvesEvil2
// ###################################################################

    void passage291_Init()
    {
        this.Passages[@"VialSold"] = new StoryPassage(@"VialSold", new string[] { }, passage291_Main);
    }

    IStoryThread passage291_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Unconscionable Choice");
        }
        yield return lineBreak();
        yield return text("To look back on this moment with pure hindsight and recognize that a being had th" +
            "e potential to halt this insidious infestation and chose instead to turn the sit" +
            "uation into a financial windfall is harrowing. ");
        yield return text(Vars.charity);
        yield return text(" ");
        yield return text("III\'s infamous decision would result in a blight upon the land that was nigh unst" +
            "oppable.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage291_Fragment_1);
        using (styleScope("hook", "h000291"))
            yield return link("Click to continue...", null, () => enchantHook("h000291", HarloweEnchantCommand.Replace, passage291_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage291_Fragment_0()
    {
        //yield return lineBreak();
        Vars.vialuse = "no";
        ViewItemObtain.SetupPassagename = "WolvesEvil2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Money_Icon";
            yield return lineBreak();
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("III gains ");
            using (styleScope("bold", true))
            {
                yield return text("$3");
            }
            yield return text(" ");
            yield return text("and ");
            using (styleScope("bold", true))
            {
                yield return text("1VP");
            }
            yield return text(".");
            yield return lineBreak();
        }

        //yield return lineBreak();
        //yield return link("Click to continue...", "WolvesEvil2", null);
        yield break;
    }

    IStoryThread passage291_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage291_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: VialChanged   (passage292)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29677-29737
// Links:  GloomyGothic3
// Aborts: -
// Purpose: Cleansed: the valley restored, monsters genteel, +1VP
// ###################################################################

    void passage292_Init()
    {
        this.Passages[@"VialChanged"] = new StoryPassage(@"VialChanged", new string[] { }, passage292_Main);
    }

    IStoryThread passage292_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Selflessness for Change");
        }
        yield return lineBreak();
        Vars.vialuse = "yes";
        yield return lineBreak();
        yield return text("The liquid was introduced at the source of the stream that winded through the hoa" +
            "ry gloom enveloping the town of ");
        yield return text(Vars.townname);
        yield return text(". Like a glittering oil, it spread downstream, turning the murky waters clear onc" +
            "e again with a supernatural effervescence.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"After less than a day's passing, the azalea blossoms that once dotted the landscape were in full bloom and the radiant sunlight bathed the valley in a honey glow. The creatures that remained found themselves reformed, though still horrific to behold, and went about clothed in dapper suits and summer dresses with hats that could easily be tipped as a friendly greeting.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Those of the Order that refused to submit to the cleansing beauty fled into the hills never to be seen again. The cousins were free once again to be the most unconventional presences within the town, and returned to their labors with no further interruptions.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage292_Fragment_1);
        using (styleScope("hook", "h000292"))
            yield return link("Click to continue...", null, () => enchantHook("h000292", HarloweEnchantCommand.Replace, passage292_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage292_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_VialToken";
            yield return lineBreak();
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("III gains 1VP.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic3", null);
        yield break;
    }

    IStoryThread passage292_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage292_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: TieredRewards2   (passage293)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29742-29808
// Links:  GloomyGothic3
// Aborts: -
// Purpose: Tiered bonuses/penalties by donated Experiment level (A/B/C)
// ###################################################################

    void passage293_Init()
    {
        this.Passages[@"TieredRewards2"] = new StoryPassage(@"TieredRewards2", new string[] { }, passage293_Main);
    }

    IStoryThread passage293_Main()
    {
        ViewItemObtain.SetupPassagename = "GloomyGothic3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that donated an ");
            using (styleScope("bold", true))
            {
                yield return text("A Experiment");
            }
            yield return text(":");
            yield return lineBreak();
            yield return text(macros1.either("Gain 1VP.", "Gain an ingredient of your choice.", "Receives no bonus.", "Loses 1VP. The Order is unpleased with this meager offering."));
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that donated a ");
            using (styleScope("bold", true))
            {
                yield return text("B Experiment");
            }
            yield return text(":");
            yield return lineBreak();
            yield return text(macros1.either("Gain a Knowledge of your choice.", "Gain $2.", "Gain 2VP."));
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that donated a ");
            using (styleScope("bold", true))
            {
                yield return text("C Experiment");
            }
            yield return text(":");
            yield return lineBreak();
            yield return text(macros1.either("Gain 4VP.", "Gain $4."));
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that chose not to donate ");
            using (styleScope("bold", true))
            {
                yield return text("returns a Servant to Lost");
            }
            yield return text(" ");
            yield return text("and ");
            using (styleScope("bold", true))
            {
                yield return text("gains 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic3", null);
        //yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyPenalty1   (passage306)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31661-31743
// Links:  Preposterous
// Aborts: -
// Purpose: "The Hunter's Tax" town meeting: pay $2/2 resources or lose 3VP
// ###################################################################

    void passage306_Init()
    {
        this.Passages[@"GloomyPenalty1"] = new StoryPassage(@"GloomyPenalty1", new string[] { }, passage306_Main);
    }

    IStoryThread passage306_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Hunter\'s Tax");
        }
        yield return lineBreak();
        yield return text(@"Set amid an unseasonably warm afternoon, the Fraternity Lodge held a town meeting, gathering the majority of the townsfolk within its carved stone walls, which were most lavishly adorned with rich velvet trappings and the stuffed heads of beasts they claimed to have bested in the wilds.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The leader spoke again, outfitted in his signature trenchcoat and broad-rimmed hat. ""The unprecedented progress this town has made is due to our immaculate safeguarding from disease and the insidious demons that haunt us from the hills. However, unprecedented progress does come at a price...""");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage306_Fragment_1);
        using (styleScope("hook", "h000306"))
            yield return link("Click to continue...", null, () => enchantHook("h000306", HarloweEnchantCommand.Replace, passage306_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage306_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Preposterous";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP - TAXATION");
            }
            Vars._SetupImage = "S1_HunterToken";
            yield return lineBreak();
            yield return text("Any player that does not have a Servant/Spouse piece on ");
            using (styleScope("bold", true))
            {
                yield return text("The Hunter\'s Rest");
            }
            yield return text(" ");
            yield return text("must ");
            using (styleScope("bold", true))
            {
                yield return text("pay $2");
            }
            yield return text(" ");
            yield return text("OR ");
            using (styleScope("bold", true))
            {
                yield return text("2 resources");
            }
            yield return text(" ");
            yield return text("to the supply. If this is not possible, they instead ");
            using (styleScope("bold", true))
            {
                yield return text("lose 3VP");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Alternatively, any player with a ");
            using (styleScope("bold", true))
            {
                yield return text("Hunter token");
            }
            yield return text(" ");
            yield return text("may discard it to the scenario box to invoke their privilege and forgo this payme" +
                "nt.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "Preposterous", null);
        yield break;
    }

    IStoryThread passage306_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage306_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: GloomyPenalty3   (passage307)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31748-31828
// Links:  Scoring
// Aborts: -
// Purpose: Final-round repeat of the Hunter's Tax
// ###################################################################

    void passage307_Init()
    {
        this.Passages[@"GloomyPenalty3"] = new StoryPassage(@"GloomyPenalty3", new string[] { }, passage307_Main);
    }

    IStoryThread passage307_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Hunter\'s Tax");
        }
        yield return lineBreak();
        yield return text("Even in their final years of life, the Hunters were unwilling to forgo the last r" +
            "emaining payment.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue to Final Scoring...", passage307_Fragment_1);
        using (styleScope("hook", "h000307"))
            yield return link("Click to continue to Final Scoring...", null, () => enchantHook("h000307", HarloweEnchantCommand.Replace, passage307_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage307_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Scoring";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_HunterToken";
            yield return lineBreak();
            yield return text("Any player that does not have a Servant/Spouse piece on ");
            using (styleScope("bold", true))
            {
                yield return text("The Hunter\'s Rest");
            }
            yield return text(" ");
            yield return text("must ");
            using (styleScope("bold", true))
            {
                yield return text("pay $2");
            }
            yield return text(" ");
            yield return text("OR ");
            using (styleScope("bold", true))
            {
                yield return text("2 resources");
            }
            yield return text(" ");
            yield return text("to the supply. If this is not possible, they instead ");
            using (styleScope("bold", true))
            {
                yield return text("lose 3VP");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Alternatively, any player with a ");
            using (styleScope("bold", true))
            {
                yield return text("Hunter token");
            }
            yield return text(" ");
            yield return text("may discard it to the scenario box to invoke their privilege and forgo this payme" +
                "nt.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue to Final Scoring...", "Scoring", null);
        yield break;
    }

    IStoryThread passage307_Fragment_1()
    {
        yield return enchant("Click to continue to Final Scoring...", HarloweEnchantCommand.Replace, passage307_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesVote   (passage308)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31833-31911
// Links:  WolvesVote2
// Aborts: -
// Purpose: Vote on unleashing the Order's concoction to tame the beasts
// ###################################################################

    void passage308_Init()
    {
        this.Passages[@"WolvesVote"] = new StoryPassage(@"WolvesVote", new string[] { }, passage308_Main);
    }

    IStoryThread passage308_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("An Opportunity");
        }
        yield return lineBreak();
        ViewSpecialEvent.instance.ShowEventPopup();
        yield return text(@"With a shrill squeal, the violin player ended the performance abruptly. The dinner guests turned their heads to see the source of the commotion: a shambling creature with unseemly patches of wispy gray fur covering their deformities had climbed over the east Veranda and now crouched near the dinner table. It seemed to intuit the place of their gathering and only appeared when all of the family were present.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"""Do not fear me. I am not your enemy. By mere chance, I happened upon a concoction of daisy fleabane and tassel hyacinth that was able to completely suppress my insatiable hunger for destruction."" The jowls of the malformed dog-man shuddered with each gnarled utterance, yet his emerald eyes gleamed with a light of hope.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("\"With your help, we can cure the entirety of the valley and help to undo the horr" +
            "ors that we have wrought!\"");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Though they took exception to using an invention not of their own creation, the c" +
            "ousins knew a decision could allow them to avoid the humiliation of donating ano" +
            "ther one of their precious experiments to these mongrels.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("VOTE");
        }
        yield return lineBreak();
        yield return text("Players will now vote on whether to unleash this concoction to tame the demonic b" +
            "easts of the land.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Yay");
        }
        yield return text(" ");
        yield return text("vote is a vote to Unleash the Concoction.");
        yield return lineBreak();
        yield return text("A ");
        using (styleScope("bold", true))
        {
            yield return text("Nay");
        }
        yield return text(" ");
        yield return text("vote is a vote to refuse.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("All players take their Voting tokens into their hand. Players will secretly choos" +
            "e a side to place face up in their palm. Then, they will close their fist and ex" +
            "tend it to the center of the table.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("When all players have chosen, all players reveal their votes. Tally all the votes" +
            " and the side with the most votes wins. ");
        using (styleScope("italic", true))
        {
            yield return text("Ties are broken by the last player in turn order.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to start the vote...", "WolvesVote2", null);
        using (styleScope("hook", "h0000308"))
            yield return link("Click to start the vote...", null, () => enchantHook("h0000308", HarloweEnchantCommand.None, passage308_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage308_Fragment_0()
    {
        ViewBiddingSystem.instance.OnShowBidding("WolvesVote2", BiddingSystem.Voting);
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesVoteCheck   (passage309)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31916-31982
// Links:  WolvesVoteChange,TheVialUse
// Aborts: -
// Purpose: Disease-card holders are compelled to flip their vote to Nay; retally
// ###################################################################

    void passage309_Init()
    {
        this.Passages[@"WolvesVoteCheck"] = new StoryPassage(@"WolvesVoteCheck", new string[] { }, passage309_Main);
    }

    IStoryThread passage309_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Remember the Cure");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was strange. While the vote may have commenced and they seemed to have come to" +
            " a positive arrangement, some were suddenly overwhelmed with an urge to assist t" +
            "he ");
        using (styleScope("bold", true))
        {
            yield return text("Order");
        }
        yield return text(". They tried to voice their approval to the vote, straining with effort, but the " +
            "word \"nay\" instead escaped their lips.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"How could they have known the consequences of their parents' decision to accept the cure for their hereditary illness? Moments later, their cursed minds has twisted the truth so irreversibly that they could not fathom why they had ever agreed to such a foul plan in the first place!");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("SPECIAL ACTION");
        }
        yield return lineBreak();
        yield return text("All players with a ");
        using (styleScope("bold", true))
        {
            yield return text("Disease card");
        }
        yield return text(" ");
        yield return text("in their Stored Experiments must ");
        using (styleScope("bold", true))
        {
            yield return text("flip their Vote token to Nay");
        }
        yield return text(" ");
        yield return text("in their palm if it is not already.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Tally all votes once again.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Click on the result of your vote:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here if you voted to Cleanse.", "WolvesVoteChange", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here if you voted Nay.", "TheVialUse", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesVoteChange   (passage310)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31988-32021
// Links:  VialSoldforLess
// Aborts: -
// Purpose: Changed vote result: the stream is cleansed and the Order flees
// ###################################################################

    void passage310_Init()
    {
        this.Passages[@"WolvesVoteChange"] = new StoryPassage(@"WolvesVoteChange", new string[] { }, passage310_Main);
    }

    IStoryThread passage310_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Vote for Change");
        }
        yield return lineBreak();
        Vars.vialuse = "yes";
        yield return lineBreak();
        yield return text(@"And it was decided by the group that by the next fortnight, they would devise a serum powerful enough to reverse the evil blight upon the land. Using a coagulated mixture of the beast's own blood, hemlock's root, and borax throughout a series of involuntary trials, the chemical was proven strong enough to eliminate the effects of the transformation or kill the subject.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The liquid was introduced at the source of the stream that winded through the hoa" +
            "ry gloom enveloping the town of ");
        yield return text(Vars.townname);
        yield return text(". Like a glittering oil, it spread downstream, turning the murky waters clear onc" +
            "e again with a supernatural effervescence.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"After less than a day's passing, the azalea blossoms that once dotted the landscape were in full bloom and the radiant sunlight bathed the valley in a honey glow. The creatures that remained found themselves reformed, though still horrific to behold, and went about clothed in dapper suits and summer dresses with hats that could easily be tipped as a friendly greeting.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Those of the Order that refused to submit to the cleansing beauty fled into the hills never to be seen again. The cousins were free once again to be the most unconventional presences within the town, and returned to their labors with no further interruptions.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "VialSoldforLess", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: VialSoldforLess   (passage311)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32027-32090
// Links:  GloomyGothic3
// Aborts: -
// Purpose: After cleansing, the vial sells for $2; Vial token returned
// ###################################################################

    void passage311_Init()
    {
        this.Passages[@"VialSoldforLess"] = new StoryPassage(@"VialSoldforLess", new string[] { }, passage311_Main);
    }

    IStoryThread passage311_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Valuable Keepsake");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Due to the surprising and uncharacteristically good nature of the ill-tempered fa" +
            "mily of scientists, the blight from the land was removed.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The seemingly important crystal vial of holy water, while not pivotal to the tale of the cousins, was interesting to note nonetheless. For this bohemian glass piece represented the finest hand-blown 17th century crystal, and as the Austro-Hungarian Empire waned, these commanded prices that rivaled the most precious jewelry of the time.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The cousin took this opportunity to sell the vial for a significant sum of money." +
            "");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage311_Fragment_1);
        using (styleScope("hook", "h000311"))
            yield return link("Click to continue...", null, () => enchantHook("h000311", HarloweEnchantCommand.Replace, passage311_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage311_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "GloomyGothic3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Money_Icon";
            yield return lineBreak();
            yield return text(Vars.charity);
            yield return text(" ");
            yield return text("III gains ");
            using (styleScope("bold", true))
            {
                yield return text("$2");
            }
            yield return text(". Return the <b>Vial token</b> to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "GloomyGothic3", null);
        yield break;
    }

    IStoryThread passage311_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage311_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: AwardSpawningPods   (passage312)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32095-32175
// Links:  Scoring
// Aborts: -
// Purpose: Awards Spawning Pods Vanity Upgrade to the player with the most Occult experiments
// ###################################################################

    void passage312_Init()
    {
        this.Passages[@"AwardSpawningPods"] = new StoryPassage(@"AwardSpawningPods", new string[] { }, passage312_Main);
    }

    IStoryThread passage312_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("An Award For Research");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.vialuse == "yes")
        {
            yield return text(@"The monsters felt guilty about not honoring their word even if it stretched their sense of ethical duty to do so. On a cool summer evening in the twilight years of life, the newly inspired creatures formed a bright cavalcade and paraded their way up the steep and winding hills to the Estate.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Within hours, the new structure was built, and though they proposed a feast in th" +
            "e scientist\'s honor, they quickly meandered back home when the gates were firmly" +
            " shut and the hounds were released to chase them from the property.");
        }
        else
        {
            yield return text(@"Though uninterested in the pageantry of a meager prize, they performed the gesture anyway. A small group of gray minions lumbered their way into the courtyard and built the unseemly structure with muck and stone. Once finished to their satisfaction, they stuck a slimy ribbon on the doorframe and skulked away into the surrounding fog without a word.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue to Final Scoring...", passage312_Fragment_1);
        using (styleScope("hook", "h000312"))
            yield return link("Click to continue to Final Scoring...", null, () => enchantHook("h000312", HarloweEnchantCommand.Replace, passage312_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage312_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Scoring";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "MFWlogo";
            yield return lineBreak();
            yield return text("Award the ");
            using (styleScope("bold", true))
            {
                yield return text("Spawning Pods");
            }
            yield return text(" ");
            yield return text("Vanity Estate Upgrade to the player with the most completed ");
            using (styleScope("bold", true))
            {
                yield return text("Occult");
            }
            yield return text(" ");
            yield return text("Experiments. If there is a tie, award the Upgrade to the tied player with the lea" +
                "st VP. ");
            using (styleScope("italic", true))
            {
                yield return text("If there is still a tie, return the Upgrade to the box and all tied players gain " +
                "7VP instead.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Ignore all plot costs when building this Upgrade.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue to Final Scoring...", "Scoring", null);
        yield break;
    }

    IStoryThread passage312_Fragment_1()
    {
        yield return enchant("Click to continue to Final Scoring...", HarloweEnchantCommand.Replace, passage312_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: WolvesVote2   (passage349)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34555-34587
// Links:  WolvesVoteCheck,TheVialUse
// Aborts: -
// Purpose: Tallies the Wolves concoction vote; branches WolvesVoteCheck or TheVialUse
// ###################################################################

    void passage349_Init()
    {
        this.Passages[@"WolvesVote2"] = new StoryPassage(@"WolvesVote2", new string[] { }, passage349_Main);
    }

    IStoryThread passage349_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("VOTE OUTCOME");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Tally all the votes and the side with the most votes wins. ");
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
        yield return link("Click here if you voted to Cleanse.", "WolvesVoteCheck", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here if you voted Nay.", "TheVialUse", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HunterConf3   (passage350)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34593-34642
// Links:  OhYesTheyDead,ConfrontationFail
// Aborts: -
// Purpose: Totals donated Experiment VP vs a threshold to resolve the hunter confrontation
// ###################################################################

    void passage350_Init()
    {
        this.Passages[@"HunterConf3"] = new StoryPassage(@"HunterConf3", new string[] { }, passage350_Main);
    }

    IStoryThread passage350_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Donation Outcome");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Count up the total value of the VP on all donated Experiment cards.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the value is equal to ");
        //if (Vars.players == 2)
        //{
        //    Vars.huntnum = macros1.random(3, 7);
        //}
        //if (Vars.players == 3)
        //{
        //    Vars.huntnum = macros1.random(8, 12);
        //}
        //if (Vars.players == 4)
        //{
        //    Vars.huntnum = macros1.random(11, 15);
        //}
        //if (Vars.players == 5)
        //{
        //    Vars.huntnum = macros1.random(13, 19);
        //}
        yield return text(Vars.huntnum);
        yield return text(" ");
        yield return text("or higher, ");
        yield return link("click here to continue.", "OhYesTheyDead", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the value is less, ");
        yield return link("click here to continue", "ConfrontationFail", null);
        yield return text(" ");
        yield return text("instead.");
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: EvilHunter1Event2   (passage351)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34648-34695
// Links:  -
// Aborts: -
// Purpose: Vote-outcome screen for the evil hunter event
// ###################################################################

    void passage351_Init()
    {
        this.Passages[@"EvilHunter1Event2"] = new StoryPassage(@"EvilHunter1Event2", new string[] { }, passage351_Main);
    }

    IStoryThread passage351_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Vote Outcome");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Tally all the votes and the side with the most votes wins. ");
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
        using (styleScope("hook", "h00212"))
            yield return link("Click here if you voted to Confront the Hunters. (YAY!)", null, () => enchantHook("h00212", HarloweEnchantCommand.Replace, passage351_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00213"))
            yield return link("Click here if you voted to Believe the Hunters. (NAY!)", null, () => enchantHook("h00213", HarloweEnchantCommand.Replace, passage351_Fragment_1));
        yield break;
    }

    IStoryThread passage351_Fragment_0()
    {
        Vars.confront = "yes";
        yield return abort(goToPassage: "EvilHunter1EventYes");
        yield break;
    }

    IStoryThread passage351_Fragment_1()
    {
        Vars.confront = "no";
        yield return abort(goToPassage: "GloomyGothic2");
        yield break;
    }

// ###################################################################
// PASSAGE: MayorLibraryEvil   (passage355)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 34867-34960
// Links:  LosingOrderAid
// Aborts: -
// Purpose: "Detestable Education": the library legacy earns the town's grudge; +2 resources
// ###################################################################

    void passage355_Init()
    {
        this.Passages[@"MayorLibraryEvil"] = new StoryPassage(@"MayorLibraryEvil", new string[] { "revised", }, passage355_Main);
    }

    IStoryThread passage355_Main()
    {
        if (Vars.building == "library")
        {
            using (styleScope("bold", true))
            {
                yield return text("Detestable Education");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Carefully hand the Storybook to ");
                yield return text(Vars.mayor);
                yield return text(" ");
                yield return text("III.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It was impossible for ");
            yield return text(Vars.mayor);
            yield return text(" III to convince them otherwise; for the new leaders of ");
            yield return text(Vars.townname);
            yield return text(", access to untamed knowledge had poisoned the pure minds of the citizens. They were well aware that it was ");
            yield return text(Vars.mayor);
            yield return text("\'s ancestry that had brought this blight of terrible cognition to this fair town.");
            yield return lineBreak();
            if (Vars.society == "Fraternity of Hunters")
            {
                yield return text("For with knowledge came a lack of faith; a propensity to question authority and cause unwanted friction. It made them look upon ");
                yield return text(Vars.mayor);
                yield return text(" III the same way they looked upon the beasts they hunted in the wild.");
            }
            else // if(Vars.society == "Order of St. Hubertus")
            {
                yield return text("For with knowledge came a way to overcome the fears inhabiting the hearts of all men - a fear that could be manipulated. And they bore a deep grudge against anyone that sook to quell that primal urge.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00000355"))
                yield return link("Click to continue...", null, () => enchantHook("h00000355", HarloweEnchantCommand.Replace, passage355_Fragment_0));

            //yield return link("Click to continue...", "LosingOrderAid", null);
            yield return lineBreak();
        }
        else
        {
            if (Vars.hcount == 0 && Vars.society == "Order of St. Hubertus")
            {
                yield return abort(goToPassage: "EvilWolvesEventStart");
            }
            else
            {
                yield return abort(goToPassage: "LosingOrderAid");
            }
        }
        yield break;
    }

    IStoryThread passage355_Fragment_0()
    {
        //ViewItemObtain.SetupPassagename = "LosingOrderAid";
        ViewItemObtain.SetupPassagename = Vars.hcount == 0 && Vars.society == "Order of St. Hubertus" ? "EvilWolvesEventStart" : "LosingOrderAid";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MayorCoin";
            //yield return text("_SetupImage");
            //yield return lineBreak();
            //yield return lineBreak();
            yield return text(Vars.mayor);
            yield return text(" ");
            yield return text("gains 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(". Then, return the ");
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
