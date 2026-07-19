// ===================================================================
// CHAPTER: Gen2-Devastation   (49 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage4     Devastation1                 L2088-2233 [HUB]  Round-1 HUB "Devastation - Early Years": Sealed Envelope meetings, Hereditary Disease rule
// passage31    Changes                      L4306-4450  "A Return to Civility" event: discard Letter cards as suspicious buildings appear
// passage32    Devastation3                 L4455-4588 [HUB]  Round-3 HUB "Devastation - Late Years": Suspicion reveal/conceal, Stables
// passage33    Devastation2                 L4599-4798 [HUB]  Round-2 HUB "Devastation - Middle Years": places the three Suspicious Building tiles
// passage46    HubertusWolves1              L5987-6109  Private letter: Order of St. Hubertus / wolves faction offer after envelope passcode
// passage71    Lettercode                   L8318-8694  "Surprising Correspondence": deals numbered sealed Letter cards with passcode + meeting place
// passage73    Envelopes                    L8735-8781  Private "Secret Meeting" preamble leading to envelope passcode entry
// passage74    BuildingsEnd                 L8786-8985  End-of-generation Suspicious Building resolution; 3VP per Exposed threat
// passage84    DiseaseConsequence           L9412-9474  "Inescapable Plague": deals Hereditary Disease cards in the no-hospital branch
// passage86    DevastationIntro             L9530-9597  Generation II prose intro: the second epidemic ruins the town
// passage87    5Note                        L9603-10023  DEV NOTE + Devastation setup (Stables, Letters, factions, Suspicious Buildings, page 17)
// passage101   DevEventCure                 L11077-11170  "An Alternative Cure": discard a completed B Experiment to store the Disease Experiment
// passage102   EnvPasscode                  L11175-11200  Prompt to type the secret envelope password; hands off to Passcodechk
// passage103   HubertusWolves2              L11206-11325  Private Hubertus letter variant 2; secret expose/conceal choice
// passage104   Diseases1                    L11330-11435  "A Year of Sickness": players without the Disease Experiment discard Knowledge or lose 2VP
// passage105   HubertusWolves3              L11440-11560  Private Hubertus letter variant 3; expose/conceal choice
// passage106   HubertusHunters1             L11565-11683  Private Fraternity of Hunters letter variant 1; expose/conceal choice
// passage107   DevastationFate1             L11688-11793  "Strong Alliance" end-of-Devastation fate; branches to the Gen3 intros
// passage108   HubertusHunters2             L11799-11917  Private Hunters letter variant 2; expose/conceal choice
// passage109   HubertusHunters3             L11922-12040  Private Hunters letter variant 3; expose/conceal choice
// passage110   Passcodechk                  L12045-12119  Password validator: alpha/moon/howl/right/cross/bolt -> the six letter passages, else FailedMeeting
// passage111   BuildingSignin               L12125-12210  "Investigation": which player is investigating; routes to the matching Buildplay
// passage112   BuildplayA                   L12215-12330  Player A private investigation journal; secret expose/conceal decision
// passage113   ExposeConfirmation           L12335-12364  Private confirmation screen: chose to expose
// passage114   ConcealConfirmation          L12370-12399  Private confirmation screen: chose to conceal
// passage115   BuildplayB                   L12405-12520  Player B private investigation journal
// passage116   BuildplayC                   L12525-12640  Player C private investigation journal
// passage117   BuildplayD                   L12645-12760  Player D private investigation journal
// passage118   BuildplayE                   L12765-12880  Player E private investigation journal
// passage119   MostInvestigated             L12885-13330  Tallies investigation counts; 4VP to the sole leader; continues to DiseaseEnd
// passage183   RefusalReveal                L21466-21631  Secret stable-hand briefing: which faction is Wolves vs Hunters; lets the player join
// passage184   RefusalWolves                L21636-21664  Declining the Order of St. Hubertus letter; contact stays at the Stables
// passage185   RefusalHunters               L21669-21697  Declining the Fraternity of Hunters letter; contact stays at the Stables
// passage188   DiseaseEffect                L21853-21957  End-of-generation Hereditary Disease resolution; hands off to DevastationFate1
// passage209   HunterJoin                   L23647-23720  The Hunters' messenger arrives to accept membership
// passage210   RefusalEvent                 L23725-23861  Stables hub: identify yourself to the stable hand to learn about the factions
// passage211   JoinedAlready                L23866-23907  Rebuff for a player who already joined a faction
// passage225   Diseases2                    L24761-24877  Penalty for lacking a completed Hereditary Disease Experiment
// passage226   DiseaseEnd                   L24882-24956  End-of-generation Disease wrap-up; grants Stasis Chamber estate upgrades
// passage227   WolfJoin                     L24961-25035  The Order of St. Hubertus' messenger arrives to accept membership
// passage356   HelpingEvil2                 L25303-25355  End-of-Gen2 setup: Heart-token players build a Master's Study; routes into the Gloomy Gen3 intro
// passage294   Gen1Creepy-ConcealExpose     L29814-30241  Private society visit collecting on the Gen1 "seedy" pledge; conceal/expose + debt
// passage295   Gen1Creepy-RefusalBuild      L30246-30445  Gen1 refusal consequence: free Reading Room or Shrine Estate Upgrade
// passage302   Gen1Insanity-Yes             L31272-31356  "Absent Parent" penalty from the Gen1 summer home: Maladjustment card and -3VP
// passage305   Gen1Insanity-NoAction        L31575-31656  Gen1 refusal reward: retake your piece, take another turn, gain 1VP
// passage313   FailedMeeting                L32180-32238  Failed secret meeting: the character raves publicly and gains 1 resource
// passage314   Gen1Creepy-EvilCollect       L32243-32326  Shared fragment: society operative offers a choice of debt repayment
// passage342   HubertusConfirmation         L34237-34293  Private Order of St. Hubertus letter confirming conceal-or-expose pledge
// passage343   HuntersConfirmation          L34299-34355  Private Fraternity of Hunters missive confirming conceal-or-expose pledge
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   Devastation1         --end of round-->  Changes
//   Devastation3         --end of round-->  BuildingsEnd
//   Devastation2         --end of round-->  DevEventCure
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: Devastation1   (passage4)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 2088-2233
// Links:  Envelopes,HereditaryDiseaseComplete,Changes
// Aborts: -
// Round end -> Changes
// Purpose: Round-1 HUB "Devastation - Early Years": Sealed Envelope meetings, Hereditary Disease rule
// ###################################################################

    void passage4_Init()
    {
        this.Passages[@"Devastation1"] = new StoryPassage(@"Devastation1", new string[] { "HUB", }, passage4_Main);
    }

    IStoryThread passage4_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Devastation - Early Years");
        }
        yield return lineBreak();
        ispasscode = true;
        Vars.round = 4;
        yield return lineBreak();
        if (Vars.devpage == 0 || Vars.devpage == "")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                if (Vars.seedy == "yes")
                {
                    Vars._SetupImage = "AngryMobSetup2";
                    yield return lineBreak();
                }
                else
                {
                    Vars._SetupImage = "AngryMobSetup1";
                    yield return lineBreak();
                }
                yield return text("Turn to page ");
                if (Vars.building == "bank")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("12");
                    }
                }
                //if (Vars.building == "library")
                else
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("13");
                    }
                }
                yield return text(" of the Village Chronicle. Place the Suspicion marker on space ");
                using (styleScope("bold", true))
                {
                    if (Vars.Devastation1 == 0 || Vars.Devastation1 == "")
                    {
                        Vars.Devastation1 = 1;
                        Vars.tracker = int.Parse(Vars.tracker) + 2;
                        if (Vars.players == 4)
                        {
                            Vars.tracker = int.Parse(Vars.tracker) + 3;
                        }
                        if (Vars.players == 5)
                        {
                            Vars.tracker = int.Parse(Vars.tracker) + 3;
                        }
                    }
                    yield return text(Vars.tracker);
                }
                yield return text(" and the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" token ");
                if (Vars.seedy == "yes")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("two");
                    }
                    yield return text(" spaces to the left (due to some seedy dealings).");
                }
                else
                {
                    yield return text("one space to the left.");
                }
                yield return text(" Pass the Start Player token to the player with the ");
                yield return text("<sprite=\"S1_HeartToken\" index=0>");
                yield return text(".");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            using (styleScope("bold", true))
            {
                yield return text(" Clandestine Meetings");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("When a player reveals their Sealed Envelope card, complete the location\'s action " +
            "and then ");
            yield return link("click here for a special secret message.", "Envelopes", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            using (styleScope("bold", true))
            {
                yield return text(" Relief from Disease");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("A \"Hereditary Disease\" Experiment card can be completed by taking the Perform Exp" +
            "eriment action as normal. Completing this Experiment will allow you to ");
            using (styleScope("bold", true))
            {
                yield return text("ignore all ill effects");
            }
            yield return text(" ");
            yield return text("from Disease between rounds.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("When a player completes their Hereditary Disease Experiment, ");
            yield return link("click here for a special message.", "HereditaryDiseaseComplete", null);
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round to move to the next round...", "Changes", null);
            using (styleScope("hook", "h000000004"))
                yield return link("Click here at the end of the round to move to the next round...", null, () => enchantHook("h000000004", HarloweEnchantCommand.Replace, passage04_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage04_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Devastation1", "Changes");
        yield break;
    }

// ###################################################################
// PASSAGE: Changes   (passage31)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 4306-4450
// Links:  Diseases1
// Aborts: -
// Purpose: "A Return to Civility" event: discard Letter cards as suspicious buildings appear
// ###################################################################

    void passage31_Init()
    {
        this.Passages[@"Changes"] = new StoryPassage(@"Changes", new string[] { }, passage31_Main);
    }

    IStoryThread passage31_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Return to Civility");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Though the decayed trails that led to the village caused a carriage to jostle and creak most violently, a brisk, morning ride allowed the aging aristocrats a chance to escape the stale air of their stone manors and ruminate on the melancholic, dour beauty of the region.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It was upon these morning rides that they were able to observe a sudden and peculiar transformation occurring within the town. Crews of hired laborers arrived to clear several of the empty lots in the village and construct new foundations. Within weeks, these vacant lots were filled by nondescript buildings of various purposes.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Armed with an inimitable curiosity and thirst for knowledge, the cousins could no" +
            "t resist further investigation.");
        yield return lineBreak();
        Vars.devpage = 0;
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage31_Fragment_1);
        using (styleScope("hook", "h000031"))
            yield return link("Click to continue...", null, () => enchantHook("h000031", HarloweEnchantCommand.Replace, passage31_Fragment_0));
        yield break;
    }

    IStoryThread passage31_Fragment_0()
    {
        yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Diseases1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_LetterBACK";
            yield return lineBreak();
            yield return text("All players discard their Letter cards to the box.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "Diseases1", null);
        yield return lineBreak();
        Vars.build = macros1.a(1, 2, 3, 4, 5);
        if (Vars.building == "bank")
        {
            Vars.build = Vars.build - macros1.a(2);
        }
        //if (Vars.building == "library")
        else
        {
            Vars.build = Vars.build - macros1.a(3);
        }
        Vars.build = macros1.shuffled((HarloweSpread)Vars.build);
        Vars.buildA = Vars.build["1st"];
        Vars.buildB = Vars.build["2nd"];
        if (Vars.building == "bank")
        {
            Vars.buildC = 2;
        }
        else if (Vars.building == "library")
        {
            Vars.buildC = 3;
        }
        else
        {
            Vars.buildC = Vars.build["3rd"];
        }
        if (Vars.buildA == 1)
        {
            Vars.ba = "Hardware Store";
        }
        else if (Vars.buildA == 2)
        {
            Vars.ba = "Wire Service";
        }
        else if (Vars.buildA == 3)
        {
            Vars.ba = "Book Store";
        }
        else if (Vars.buildA == 4)
        {
            Vars.ba = "Warehouse";
        }
        //if (Vars.buildA == 5)
        else
        {
            Vars.ba = "Pet Store";
        }
        if (Vars.buildB == 1)
        {
            Vars.bb = "Hardware Store";
        }
        else if (Vars.buildB == 2)
        {
            Vars.bb = "Wire Service";
        }
        else if (Vars.buildB == 3)
        {
            Vars.bb = "Book Store";
        }
        else if (Vars.buildB == 4)
        {
            Vars.bb = "Warehouse";
        }
        //if (Vars.buildB == 5)
        else
        {
            Vars.bb = "Pet Store";
        }
        if (Vars.buildC == 1)
        {
            Vars.bc = "Hardware Store";
        }
        else if (Vars.buildC == 2)
        {
            Vars.bc = "Wire Service";
        }
        else if (Vars.buildC == 3)
        {
            Vars.bc = "Book Store";
        }
        else if (Vars.buildC == 4)
        {
            Vars.bc = "Warehouse";
        }
        //if (Vars.buildC == 5)
        else
        {
            Vars.bc = "Pet Store";
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage31_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage31_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Devastation3   (passage32)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 4455-4588
// Links:  HereditaryDiseaseComplete,RefusalEvent,BuildingsEnd
// Aborts: -
// Round end -> BuildingsEnd
// Purpose: Round-3 HUB "Devastation - Late Years": Suspicion reveal/conceal, Stables
// ###################################################################

    void passage32_Init()
    {
        this.Passages[@"Devastation3"] = new StoryPassage(@"Devastation3", new string[] { "HUB", }, passage32_Main);
    }

    IStoryThread passage32_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Devastation - Late Years");
        }
        yield return lineBreak();
        Vars.round = 6;
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text(" Suspicion");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text(@"When a player visits one of the three Suspicious locations, they may investigate the location by secretly picking it up and looking at its reverse side. Then, click on the appropriate location below to choose whether to reveal or conceal the secrets underneath.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00012"))
                yield return link("Investigate " + Vars.ba, null, () => enchantHook("h00012", HarloweEnchantCommand.Replace, passage32_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00013"))
                yield return link("Investigate " + Vars.bb, null, () => enchantHook("h00013", HarloweEnchantCommand.Replace, passage32_Fragment_1));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00014"))
                yield return link("Investigate " + Vars.bc, null, () => enchantHook("h00014", HarloweEnchantCommand.Replace, passage32_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("You may visit the same Building multiple times.");
            }
            yield return text(" ");
            yield return text("At the end of the Generation, if a Building has been revealed more times than con" +
                "cealed, the work will be ");
            using (styleScope("bold", true))
            {
                yield return text("Exposed");
            }
            yield return text(" ");
            yield return text("for the world to see.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text(" Relief from Disease");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("A \"Hereditary Disease\" Experiment card can be completed by taking the Perform Exp" +
            "eriment action as normal. Completing this Experiment will allow you to ");
            using (styleScope("bold", true))
            {
                yield return text("ignore all ill effects");
            }
            yield return text(" ");
            yield return text("from Disease between rounds.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("When a player completes their Hereditary Disease Experiment, ");
            yield return link("click here for a special message.", "HereditaryDiseaseComplete", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text(" Stable Hand");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("When a player visits the Stables, they may ");
            yield return link("click here to speak with the Stable Hand.", "RefusalEvent", null);
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("If you have joined a faction, this action will have no effect.");
            }
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the Generation to Determine the Fate of the Town.", "BuildingsEnd", null);
            using (styleScope("hook", "h000035"))
                yield return link("Click here at the end of the Generation to Determine the Fate of the Town.", null, () => enchantHook("h000035", HarloweEnchantCommand.None, passage35_Fragment_3));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage32_Fragment_0()
    {
        Vars.inv = Vars.ba;
        yield return abort(goToPassage: "BuildingSignin");
        yield break;
    }

    IStoryThread passage32_Fragment_1()
    {
        Vars.inv = Vars.bb;
        yield return abort(goToPassage: "BuildingSignin");
        yield break;
    }

    IStoryThread passage32_Fragment_2()
    {
        Vars.inv = Vars.bc;
        yield return abort(goToPassage: "BuildingSignin");
        yield break;
    }

// ###################################################################
// PASSAGE: Devastation2   (passage33)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 4599-4798
// Links:  HereditaryDiseaseComplete,RefusalEvent,DevEventCure
// Aborts: -
// Round end -> DevEventCure
// Purpose: Round-2 HUB "Devastation - Middle Years": places the three Suspicious Building tiles
// ###################################################################

    void passage33_Init()
    {
        this.Passages[@"Devastation2"] = new StoryPassage(@"Devastation2", new string[] { "HUB", }, passage33_Main);
    }

    IStoryThread passage33_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Devastation - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 5;
        yield return lineBreak();
        if (Vars.devpage == 0 || Vars.devpage == "")
        {
            using (styleScope("setupStyle", true))
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SETUP");
                }
                Vars._SetupImage = "S1_Suspicious_Building";
                yield return lineBreak();
                yield return text("Turn to page ");
                using (styleScope("bold", true))
                {
                    yield return text("14");
                }
                yield return text(" ");
                yield return text("of the Village Chronicle. Retrieve the ");
                using (styleScope("bold", true))
                {
                    yield return text("Suspicious Building");
                }
                yield return text(" ");
                yield return text("tiles, leaving them building side up.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Place a storybook token on the ");
                using (styleScope("bold", true))
                {
                    yield return text("Stables");
                }
                yield return text(".");

                yield return lineBreak();
                yield return lineBreak();
                yield return text("Place the Building marked ");
                using (styleScope("bold", true))
                {
                    yield return text(Vars.ba);
                }
                yield return text(" ");
                yield return text("on the A Building location.");
                yield return lineBreak();
                yield return text("Place the Building marked ");
                using (styleScope("bold", true))
                {
                    yield return text(Vars.bb);
                }
                yield return text(" ");
                yield return text("on the B Building location.");
                yield return lineBreak();
                yield return text("Place the Building marked ");
                using (styleScope("bold", true))
                {
                    yield return text(Vars.bc);
                }
                yield return text(" ");
                yield return text("on the C Building location.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Return the remaining tiles to the scenario box.");
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
                yield return text(" Suspicion");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text(@"When a player visits one of the three Suspicious locations, they may investigate the location by secretly picking it up and looking at its reverse side. Then, click on the appropriate location below to choose whether to reveal or conceal the secrets underneath.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00015"))
                yield return link("Investigate " + Vars.ba.ToString(), null, () => enchantHook("h00015", HarloweEnchantCommand.Replace, passage33_Fragment_0));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00016"))
                yield return link("Investigate " + Vars.bb.ToString(), null, () => enchantHook("h00016", HarloweEnchantCommand.Replace, passage33_Fragment_1));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hook", "h00017"))
                yield return link("Investigate " + Vars.bc.ToString(), null, () => enchantHook("h00017", HarloweEnchantCommand.Replace, passage33_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("You may visit the same Building multiple times.");
            }
            yield return text(" ");
            yield return text("At the end of the Generation, if a Building has been revealed more times than con" +
                "cealed, the work will be ");
            using (styleScope("bold", true))
            {
                yield return text("Exposed");
            }
            yield return text(" ");
            yield return text("for the world to see.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text(" Relief from Disease");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("A \"Hereditary Disease\" Experiment card can be completed by taking the Perform Exp" +
                "eriment action as normal. Completing this Experiment will allow you to ");
            using (styleScope("bold", true))
            {
                yield return text("ignore all ill effects");
            }
            yield return text(" ");
            yield return text("from Disease between rounds.");

            yield return lineBreak();
            yield return lineBreak();
            yield return text("When a player completes their Hereditary Disease Experiment, ");
            yield return link("click here for a special message.", "HereditaryDiseaseComplete", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text(" Stable Hand");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("When a player visits the Stables, they may ");
            yield return link("click here to speak with the Stable Hand.", "RefusalEvent", null);
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("If you have joined a faction, this action will have no effect.");
            }
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round for a Special Event...", "DevEventCure", null);
            using (styleScope("hook", "h00000033"))
                yield return link("Click here at the end of the round for a Special Event...", null, () => enchantHook("h00000033", HarloweEnchantCommand.None, passage36_Fragment_3));

        }
        yield return lineBreak();
        //Vars.vial = macros1.either("wolves", "hunters");
        yield break;
    }

    IStoryThread passage33_Fragment_0()
    {
        Vars.inv = Vars.ba;
        yield return abort(goToPassage: "BuildingSignin");
        yield break;
    }

    IStoryThread passage33_Fragment_1()
    {
        Vars.inv = Vars.bb;
        yield return abort(goToPassage: "BuildingSignin");
        yield break;
    }

    IStoryThread passage33_Fragment_2()
    {
        Vars.inv = Vars.bc;
        yield return abort(goToPassage: "BuildingSignin");
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusWolves1   (passage46)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 5987-6109
// Links:  RefusalWolves
// Aborts: -
// Purpose: Private letter: Order of St. Hubertus / wolves faction offer after envelope passcode
// ###################################################################

    void passage46_Init()
    {
        this.Passages[@"HubertusWolves1"] = new StoryPassage(@"HubertusWolves1", new string[] { }, passage46_Main);
    }

    IStoryThread passage46_Main()
    {
        if (Vars.meet == 0 || Vars.meet == "")
        {
            yield return abort(goToPassage: "FailedMeeting");
        }

        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage46_Fragment_2);
        using (styleScope("hook", "h000046"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000046", HarloweEnchantCommand.Replace, passage46_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage46_Fragment_0()
    {
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "wolves";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "wolves";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "wolves";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "wolves";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "wolves";
        }
        yield return abort(goToPassage: "HubertusConfirmation");
        yield break;
    }

    IStoryThread passage46_Fragment_1()
    {
        using (styleScope("bold", true))
        {
            yield return text("Upon a Secret Meeting - Letter - ");
            yield return text(macros1.either("April", "August", "October"));
            yield return text(" ");
            yield return text(macros1.random(1, 29));
            yield return text(", 1865");
        }
        yield return lineBreak();
        yield return text("I, ");
        yield return text(Vars.meet);
        yield return text(", am writing this letter to you after my meeting with an associate of the Interna" +
            "tional Order of St. Hubertus. Our conversation was brief, but the resulting know" +
            "ledge has piqued my curiosities.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It has been revealed to me that your intentions are ");
        if (Vars.wolves == "evil")
        {
            yield return text("nefarious. The malevolent Order is consumed with greed, seeking to unearth the an" +
            "cient secrets in this area and use this power to alter humanity and spread a pla" +
            "gue of monstrous entities across the world. You only asked for your work to rema" +
            "in ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(".");
        }
        //else if (Vars.wolves == "good")
        else
        {
            yield return text(@"demonstrably positive. The Order is only concerned with establishing a safe haven for those afflicted by disease. Your representative even revealed a physical peculiarity that had elongated her cuspids into sharp points. She left swiftly before nightfall, ignoring my pleas for her to remain, but she urged me to ");
            using (styleScope("bold", true))
            {
                yield return text("investigate");
            }
            yield return text(" the secret workings soon to become apparent.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Being intimately familiar with matters of the occult, this admission is unsurpris" +
            "ing. My apprehensions are only related to how your actions will impact my abilit" +
            "y to advance my scientific studies most generously.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("It is with sincerity that I:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        using (styleScope("hook", "h00020"))
            yield return link("join and pledge my service to your cause.", null, () => enchantHook("h00020", HarloweEnchantCommand.Replace, passage46_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        yield return link("refuse this ridiculous offer.", "RefusalWolves", null);
        yield break;
    }

    IStoryThread passage46_Fragment_2()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage46_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: Lettercode   (passage71)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8318-8694
// Links:  Gen1Insanity-Yes
// Aborts: -
// Purpose: "Surprising Correspondence": deals numbered sealed Letter cards with passcode + meeting place
// ###################################################################

    void passage71_Init()
    {
        this.Passages[@"Lettercode"] = new StoryPassage(@"Lettercode", new string[] { }, passage71_Main);
    }

    IStoryThread passage71_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Surprising Correspondence");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"As the welcome from the townspeople was considerably icy, the cousins were amused to receive a plain letter of correspondence sealed with wax. No return address was provided and no watermarks offered evidence as to their origin. Perhaps this mystery, they surmised, would afford them more than simple seclusion in this dreary countryside.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Little did they realize how instrumental this stealthful exchange would prove ove" +
            "r the next several decades.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("click here to continue...", passage71_Fragment_1);
        using (styleScope("hook", "h000071"))
            yield return link("Click here to continue...", null, () => enchantHook("h000071", HarloweEnchantCommand.Replace, passage71_Fragment_0));
        yield return lineBreak();
        if (Vars.letterSetRandomize == 0 || Vars.letterSetRandomize == "")
        {
            Vars.letter = macros1.a(1, 2, 3, 4, 5, 6);
            Vars.letter = macros1.shuffled((HarloweSpread)Vars.letter);
            Vars.pa = Vars.letter["1st"];
            Vars.pb = Vars.letter["2nd"];
            Vars.pc = Vars.letter["3rd"];
            Vars.pd = Vars.letter["4th"];
            Vars.pe = Vars.letter["5th"];
        }
        if (Vars.pa == 1)
        {
            Vars.let1 = Vars.nameA;
        }
        if (Vars.pa == 2)
        {
            Vars.let2 = Vars.nameA;
        }
        if (Vars.pa == 3)
        {
            Vars.let3 = Vars.nameA;
        }
        if (Vars.pa == 4)
        {
            Vars.let4 = Vars.nameA;
        }
        if (Vars.pa == 5)
        {
            Vars.let5 = Vars.nameA;
        }
        if (Vars.pa == 6)
        {
            Vars.let6 = Vars.nameA;
        }
        if (Vars.pb == 1)
        {
            Vars.let1 = Vars.nameB;
        }
        if (Vars.pb == 2)
        {
            Vars.let2 = Vars.nameB;
        }
        if (Vars.pb == 3)
        {
            Vars.let3 = Vars.nameB;
        }
        if (Vars.pb == 4)
        {
            Vars.let4 = Vars.nameB;
        }
        if (Vars.pb == 5)
        {
            Vars.let5 = Vars.nameB;
        }
        if (Vars.pb == 6)
        {
            Vars.let6 = Vars.nameB;
        }
        if (Vars.pc == 1)
        {
            Vars.let1 = Vars.players == 3 ? Vars.nameC : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pc == 2)
        {
            Vars.let2 = Vars.players == 3 ? Vars.nameC : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pc == 3)
        {
            Vars.let3 = Vars.players == 3 ? Vars.nameC : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pc == 4)
        {
            Vars.let4 = Vars.players == 3 ? Vars.nameC : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pc == 5)
        {
            Vars.let5 = Vars.players == 3 ? Vars.nameC : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pc == 6)
        {
            Vars.let6 = Vars.players == 3 ? Vars.nameC : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pd == 1)
        {
            Vars.let1 = Vars.players == 4 ? Vars.nameD : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pd == 2)
        {
            Vars.let2 = Vars.players == 4 ? Vars.nameD : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pd == 3)
        {
            Vars.let3 = Vars.players == 4 ? Vars.nameD : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pd == 4)
        {
            Vars.let4 = Vars.players == 4 ? Vars.nameD : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pd == 5)
        {
            Vars.let5 = Vars.players == 4 ? Vars.nameD : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pd == 6)
        {
            Vars.let6 = Vars.players == 4 ? Vars.nameD : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pe == 1)
        {
            Vars.let1 = Vars.players == 5 ? Vars.nameE : Vars.players == 4 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pe == 2)
        {
            Vars.let2 = Vars.players == 5 ? Vars.nameE : Vars.players == 4 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pe == 3)
        {
            Vars.let3 = Vars.players == 5 ? Vars.nameE : Vars.players == 4 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pe == 4)
        {
            Vars.let4 = Vars.players == 5 ? Vars.nameE : Vars.players == 4 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pe == 5)
        {
            Vars.let5 = Vars.players == 5 ? Vars.nameE : Vars.players == 4 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        if (Vars.pe == 6)
        {
            Vars.let6 = Vars.players == 5 ? Vars.nameE : Vars.players == 4 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC, Vars.nameD) : Vars.players == 3 ? macros1.either(Vars.nameA, Vars.nameB, Vars.nameC) : macros1.either(Vars.nameA, Vars.nameB);
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage71_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Gen1Insanity-Yes";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_LetterBACK";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Letter");
            }
            yield return text(" ");
            yield return text("cards from the Scenario box. Keep them seal side up and consult the number on the" +
                " back of each letter:");
            yield return lineBreak();
            if (Vars.letterSetRandomize == 0 || Vars.letterSetRandomize == "")
            {
                Vars.letter = macros1.a(1, 2, 3, 4, 5, 6);
                Vars.letter = macros1.shuffled((HarloweSpread)Vars.letter);
                Vars.pa = Vars.letter["1st"];
                Vars.pb = Vars.letter["2nd"];
                Vars.pc = Vars.letter["3rd"];
                Vars.pd = Vars.letter["4th"];
                Vars.pe = Vars.letter["5th"];
            }
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text(Vars.nameA);
                yield return text(" ");
                yield return text("collects letter number ");
                yield return text(Vars.pa);
            }
            yield return text(".");
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text(Vars.nameB);
                yield return text(" ");
                yield return text("collects letter number ");
                yield return text(Vars.pb);
            }
            yield return text(".");
            yield return lineBreak();
            if (Vars.players > 2)
            {
                using (styleScope("bold", true))
                {
                    yield return text(Vars.nameC);
                    yield return text(" collects letter number ");
                    yield return text(Vars.pc);
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.players > 3)
            {
                using (styleScope("bold", true))
                {
                    yield return text(Vars.nameD);
                    yield return text(" collects letter number ");
                    yield return text(Vars.pd);
                }
                yield return text(".");
                yield return lineBreak();
            }
            if (Vars.players > 4)
            {
                using (styleScope("bold", true))
                {
                    yield return text(Vars.nameE);
                    yield return text(" collects letter number ");
                    yield return text(Vars.pe);
                }
                yield return text(".");
                yield return lineBreak();
            }
            yield return lineBreak();
            yield return text("Once all players have received their correspondence, they may read the reverse si" +
                "de secretly.");
        }
        if (Vars.pa == 1)
        {
            Vars.let1 = Vars.nameA;
        }
        if (Vars.pa == 2)
        {
            Vars.let2 = Vars.nameA;
        }
        if (Vars.pa == 3)
        {
            Vars.let3 = Vars.nameA;
        }
        if (Vars.pa == 4)
        {
            Vars.let4 = Vars.nameA;
        }
        if (Vars.pa == 5)
        {
            Vars.let5 = Vars.nameA;
        }
        if (Vars.pa == 6)
        {
            Vars.let6 = Vars.nameA;
        }
        if (Vars.pb == 1)
        {
            Vars.let1 = Vars.nameB;
        }
        if (Vars.pb == 2)
        {
            Vars.let2 = Vars.nameB;
        }
        if (Vars.pb == 3)
        {
            Vars.let3 = Vars.nameB;
        }
        if (Vars.pb == 4)
        {
            Vars.let4 = Vars.nameB;
        }
        if (Vars.pb == 5)
        {
            Vars.let5 = Vars.nameB;
        }
        if (Vars.pb == 6)
        {
            Vars.let6 = Vars.nameB;
        }
        if (Vars.pc == 1)
        {
            Vars.let1 = Vars.nameC;
        }
        if (Vars.pc == 2)
        {
            Vars.let2 = Vars.nameC;
        }
        if (Vars.pc == 3)
        {
            Vars.let3 = Vars.nameC;
        }
        if (Vars.pc == 4)
        {
            Vars.let4 = Vars.nameC;
        }
        if (Vars.pc == 5)
        {
            Vars.let5 = Vars.nameC;
        }
        if (Vars.pc == 6)
        {
            Vars.let6 = Vars.nameC;
        }
        if (Vars.pd == 1)
        {
            Vars.let1 = Vars.nameD;
        }
        if (Vars.pd == 2)
        {
            Vars.let2 = Vars.nameD;
        }
        if (Vars.pd == 3)
        {
            Vars.let3 = Vars.nameD;
        }
        if (Vars.pd == 4)
        {
            Vars.let4 = Vars.nameD;
        }
        if (Vars.pd == 5)
        {
            Vars.let5 = Vars.nameD;
        }
        if (Vars.pd == 6)
        {
            Vars.let6 = Vars.nameD;
        }
        if (Vars.pe == 1)
        {
            Vars.let1 = Vars.nameE;
        }
        if (Vars.pe == 2)
        {
            Vars.let2 = Vars.nameE;
        }
        if (Vars.pe == 3)
        {
            Vars.let3 = Vars.nameE;
        }
        if (Vars.pe == 4)
        {
            Vars.let4 = Vars.nameE;
        }
        if (Vars.pe == 5)
        {
            Vars.let5 = Vars.nameE;
        }
        if (Vars.pe == 6)
        {
            Vars.let6 = Vars.nameE;
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return text("Then, ");
        //yield return link("click here to continue...", "Gen1Insanity-Yes", null);
        yield break;
    }

    IStoryThread passage71_Fragment_1()
    {
        yield return enchant("click here to continue...", HarloweEnchantCommand.Replace, passage71_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Envelopes   (passage73)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8735-8781
// Links:  EnvPasscode
// Aborts: -
// Purpose: Private "Secret Meeting" preamble leading to envelope passcode entry
// ###################################################################

    void passage73_Init()
    {
        this.Passages[@"Envelopes"] = new StoryPassage(@"Envelopes", new string[] { }, passage73_Main);
    }

    IStoryThread passage73_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the Storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage73_Fragment_1);
        using (styleScope("hook", "h000073"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000073", HarloweEnchantCommand.Replace, passage73_Fragment_0));
        yield return lineBreak();
        Vars.devpage = 1;
        yield break;
    }

    IStoryThread passage73_Fragment_0()
    {
        using (styleScope("bold", true))
        {
            yield return text("Secret Meeting");
        }
        yield return lineBreak();
        yield return text("When I arrived at the location, I went about my business as normal. As I was leav" +
            "ing, I felt a gentle tap on my shoulder. A woman dressed in traditional garb tip" +
            "ped her wool cap and bid me follow her to a wooden bench nearby.");
        yield return lineBreak();
        yield return lineBreak();
        ispasscode = true;
        ispopup = true;
        yield return link("Click here to continue...", "EnvPasscode", null);
        yield break;
    }

    IStoryThread passage73_Fragment_1()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage73_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: BuildingsEnd   (passage74)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 8786-8985
// Links:  MostInvestigated
// Aborts: -
// Purpose: End-of-generation Suspicious Building resolution; 3VP per Exposed threat
// ###################################################################

    void passage74_Init()
    {
        this.Passages[@"BuildingsEnd"] = new StoryPassage(@"BuildingsEnd", new string[] { }, passage74_Main);
    }

    IStoryThread passage74_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Good or Evil Intent");
        }
        yield return lineBreak();
        yield return text(@"As they entered their twilight years, the results of the family's investigative efforts became known. The town, no longer in complete poverty, began to attract new interest from those with both genuine and nefarious motivations. The true intent of the family members was revealed.");
        yield return lineBreak();
        Vars.gen3pg = 0;
        yield return lineBreak();
        if (Vars.exposeA > 0)
        {
            Vars.goodcount = int.Parse(Vars.goodcount) + 1;
            yield return text("The evil activities of the ");
            yield return text(Vars.ba);
            yield return text(" were ");
            using (styleScope("bold", true))
            {
                yield return text("thwarted");
            }
            yield return text(" by our efforts. Place the ");
            yield return text(Vars.ba);
            yield return text(" tile to the side of the play area within reach.");
            yield return lineBreak();
            if (Vars.pAA == "yes")
            {
                yield return text(Vars.nameA);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pBA == "yes")
            {
                yield return text(Vars.nameB);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pCA == "yes")
            {
                yield return text(Vars.nameC);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pDA == "yes")
            {
                yield return text(Vars.nameD);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pEA == "yes")
            {
                yield return text(Vars.nameE);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
        }
        else
        {
            yield return text("The evil activities of the ");
            yield return text(Vars.ba);
            yield return text(" were ");
            using (styleScope("bold", true))
            {
                yield return text("successful");
            }
            yield return text(" because of our collective efforts to obscure and conceal. Place the ");
            yield return text(Vars.ba);
            yield return text(" tile to the side of the play area within reach.");
            yield return lineBreak();
        }
        yield return lineBreak();
        if (Vars.exposeB > 0)
        {
            Vars.goodcount = int.Parse(Vars.goodcount) + 1;
            yield return text("The evil activities of the ");
            yield return text(Vars.bb);
            yield return text(" were ");
            using (styleScope("bold", true))
            {
                yield return text("thwarted");
            }
            yield return text(" by our efforts. Place the ");
            yield return text(Vars.bb);
            yield return text(" tile to the side of the play area within reach.");
            yield return lineBreak();
            if (Vars.pAB == "yes")
            {
                yield return text(Vars.nameA);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pBB == "yes")
            {
                yield return text(Vars.nameB);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pCB == "yes")
            {
                yield return text(Vars.nameC);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pDB == "yes")
            {
                yield return text(Vars.nameD);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pEB == "yes")
            {
                yield return text(Vars.nameE);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
        }
        else
        {
            yield return text("The evil activities of the ");
            yield return text(Vars.bb);
            yield return text(" were ");
            using (styleScope("bold", true))
            {
                yield return text("successful");
            }
            yield return text(" because of our collective efforts to obscure and conceal. Place the ");
            yield return text(Vars.bb);
            yield return text(" tile to the side of the play area within reach.");
            yield return lineBreak();
        }
        yield return lineBreak();
        if (Vars.exposeC > 0)
        {
            Vars.goodcount = int.Parse(Vars.goodcount) + 1;
            yield return text("The evil activities of the ");
            yield return text(Vars.bc);
            yield return text(" were ");
            using (styleScope("bold", true))
            {
                yield return text("thwarted");
            }
            yield return text(" by our efforts. Place the ");
            yield return text(Vars.bc);
            yield return text(" tile to the side of the play area within reach.");
            yield return lineBreak();
            if (Vars.pAC == "yes")
            {
                yield return text(Vars.nameA);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pBC == "yes")
            {
                yield return text(Vars.nameB);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pCC == "yes")
            {
                yield return text(Vars.nameC);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pDC == "yes")
            {
                yield return text(Vars.nameD);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
            if (Vars.pEC == "yes")
            {
                yield return text(Vars.nameE);
                yield return text(" gains 3VP for Exposing the threat.");
                yield return lineBreak();
            }
        }
        else
        {
            yield return text("The evil activities of the ");
            yield return text(Vars.bc);
            yield return text(" were ");
            using (styleScope("bold", true))
            {
                yield return text("successful");
            }
            yield return text(" because of our collective efforts to obscure and conceal. Place the ");
            yield return text(Vars.bc);
            yield return text(" tile to the side of the play area within reach.");
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return link("Click here to continue...", "MostInvestigated", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: DiseaseConsequence   (passage84)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 9412-9474
// Links:  Lettercode
// Aborts: -
// Purpose: "Inescapable Plague": deals Hereditary Disease cards in the no-hospital branch
// ###################################################################

    void passage84_Init()
    {
        this.Passages[@"DiseaseConsequence"] = new StoryPassage(@"DiseaseConsequence", new string[] { }, passage84_Main);
    }

    IStoryThread passage84_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Inescapable Plague");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"While their parents may have escaped the harshness of the Yellow Fever epidemic thanks to their aristocratic distance from the populace, the young scientists were unable to avoid the effects of such dismal environs. As the years passed, they found themselves stricken with a chronic illness that would remain with them for their entire lives. The enfeeblement haunted their work, insomuch that many weeks at a time were spent in isolation and bed rest.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("In their individual ways, the group set to work on something to alleviate or cure" +
            " these symptoms, knowing that if they were unsuccessful, ");
        using (styleScope("bold", true))
        {
            yield return text("the disease would carry over to their progeny.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage84_Fragment_1);
        using (styleScope("hook", "h000084"))
            yield return link("Click to continue...", null, () => enchantHook("h000084", HarloweEnchantCommand.Replace, passage84_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage84_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Lettercode";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return text("Retrieve the Hereditary Disease cards from the Scenario box. Shuffle them and ");
            using (styleScope("bold", true))
            {
                yield return text("deal one Disease card face-up");
            }
            yield return text(" ");
            yield return text("to each player near their Masterwork. Return the remaining Hereditary Disease cards to the box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Lettercode", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage84_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage84_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: DevastationIntro   (passage86)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 9530-9597
// Links:  DiseaseConsequence
// Aborts: -
// Purpose: Generation II prose intro: the second epidemic ruins the town
// ###################################################################

    void passage86_Init()
    {
        this.Passages[@"DevastationIntro"] = new StoryPassage(@"DevastationIntro", new string[] { "INTRO", }, passage86_Main);
    }

    IStoryThread passage86_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION II:");
            yield return lineBreak();
            yield return text("The Epidemic Strikes");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Following a bitter winter in 1862, a second epidemic descended upon the village in all its visceral and bloody force. This time, however, the town was unable to recover. Buildings were left to rot as the sick fled into the countryside. Some escaped to shelter in camps near Bucharest, while the less fortunate collapsed on the icy pathways along the journey, their frozen flesh left to thaw along muddy roadsides with the change of seasons. Lost and hopeless without aid, the town dwindled until only the barest of amenities remained.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The desolation to which the family returned was unlike anything they had experienced in their short lifetime and the joys of youthful marriage were swiftly eclipsed by the reality of disease. Those who had stubbornly refused to join the others in mass exodus burned incense in their homes to prevent miasmatic transference of the fever; a practice quickly adopted within the family's estates. For years, the ominous tintinnabulation echoed across the stricken valley each night to ward off the disease even as the cemetery was inundated with new bodies.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"For most, this environment of sullen quiet and isolation would cause one to question their sanity, but for the scientists, this time was marked by a signature productivity. Perhaps the thought of redemption drove them forward or the constant reminder of their own mortality with each passing moment. Either way, they each toiled away in their studies, confident that through tragedy their family's legacy would finally be secured forever in the annals of science!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"And the country began to take notice of their activities; though not in the academic manner which they anticipated. Shadowy figures kept their watchful eye on the region with mysterious intentions. Unaware of the sinister machinations afoot, the scientists blindly immersed themselves in their work. They would soon find themselves confronted by a choice that would rock the very foundations of scientific (and rational) thought as they understood it.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Continue...", "DiseaseConsequence", null);
        yield return lineBreak();
        Vars.letter = macros1.a(1, 2, 3, 4, 5);
        Vars.letter = macros1.shuffled((HarloweSpread)Vars.letter);
        Vars.letterA = Vars.letter["1st"];
        Vars.letterB = Vars.letter["2nd"];
        Vars.letterC = Vars.letter["3rd"];
        Vars.letA = 0;
        Vars.letB = 0;
        Vars.letC = 0;
        Vars.goodcount = 0;
        Vars.refusaltoken = "no";
        Vars.sick = 0;
        Vars.devpage = 0;
        Vars.let1 = 0;
        Vars.let2 = 0;
        Vars.let3 = 0;
        Vars.let4 = 0;
        Vars.let5 = 0;
        Vars.let6 = 0;
        Vars.wcount = 0;
        Vars.hcount = 0;
        Vars.gen3pg = 0;
        Vars.allyA = 0;
        Vars.allyB = 0;
        Vars.allyC = 0;
        Vars.allyD = 0;
        Vars.allyE = 0;
        Vars.most = 0;
        Vars.playA = 0;
        Vars.playB = 0;
        Vars.playC = 0;
        Vars.playD = 0;
        Vars.playE = 0;
        Vars.exposeA = 0;
        Vars.exposeB = 0;
        Vars.exposeC = 0;
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: 5Note   (passage87)
// Tags: resolve
// Source: TheCostofDiseaseEng.cs lines 9603-10023
// Links:  AngryMobStorybook,WolvesEco-Friendly,CharityAwardGood
// Aborts: -
// Purpose: DEV NOTE + Devastation setup (Stables, Letters, factions, Suspicious Buildings, page 17)
// ###################################################################

    void passage87_Init()
    {
        this.Passages[@"5Note"] = new StoryPassage(@"5Note", new string[] { "resolve", }, passage87_Main);
    }

    IStoryThread passage87_Main()
    {
        yield return text("NOTES:");
        yield return lineBreak();
        yield return text("PROBLEM w/ Stables Code - Need Stables to open 2nd round when a refusal occurs AN" +
            "D also if a player does not have a meeting.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("SPECIFIC ON LETTER - WHAT DO THEY PROVIDE");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hereditary Disease cards list a Storybook token. Either cut Storybook token or de" +
            "termine where this is referenced.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Go back and be more SPECIFIC on the gains for each group. Can even make them vari" +
            "able each game BUT:");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Help GOOD = 3VP for helping Expose a Building.");
        yield return lineBreak();
        yield return text("Help EVIL = Vanity Upgrade + 4VP only if you WIN.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("BuildplayA could have individual descriptions for each location. May add later co" +
            "de below.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.ba == "Hardware Store")
        {
        }
        else if (Vars.ba == "Wire Service")
        {
        }
        else if (Vars.ba == "Book Store")
        {
        }
        else if (Vars.ba == "Warehouse")
        {
        }
        else if (Vars.ba == "Pet Store")
        {
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Make sure Page 11 is correct. I think it\'s fine. Library/Bank check it!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.pa);
        yield return text(", ");
        yield return text(Vars.allyA);
        yield return lineBreak();
        yield return text(Vars.pb);
        yield return text(", ");
        yield return text(Vars.allyB);
        yield return lineBreak();
        yield return text(Vars.pc);
        yield return text(", ");
        yield return text(Vars.allyC);
        yield return lineBreak();
        yield return text(Vars.pd);
        yield return text(", ");
        yield return text(Vars.allyD);
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.playA);
        yield return lineBreak();
        yield return text(Vars.playB);
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Hereditary Diseases assigned to players due to the town not building a Hospital.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The Fight over the TRUE followers of St. Hubertus. -Wolves or Hunters-");
        yield return lineBreak();
        yield return text("At start of Generation, one faction is randomly assigned EVIL and one is assigned" +
            " GOOD. O");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Letters =");
        yield return lineBreak();
        yield return text("Player receives an assigned letter numbered 1-6.");
        yield return lineBreak();
        yield return text("Each letter has a password and a meeting place on the reverse side.");
        yield return lineBreak();
        yield return text("Player can visit the meeting place or NOT.");
        yield return lineBreak();
        yield return text("At meeting place, they enter password and get an offer from the appropriate facti" +
            "on, with a potential reward for their help.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("NOT: if the player chooses NOT to meet up or types in the wrong password as a goo" +
            "f. They are accosted by a random faction during the second round Event with a sp" +
            "ecial sad note added.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("EVIL offers a free Estate Upgrade and 4VP as long as they WIN. You gotta win thou" +
            "gh.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Buildings =");
        yield return lineBreak();
        yield return text("The game assigns three Buildings to be built randomly.");
        yield return lineBreak();
        yield return text("One of those buildings is either the Bank or Library GUARANTEED.");
        yield return lineBreak();
        yield return text("The game keeps track of whether players, once a place has been investigated, deci" +
            "de to conceal or reveal the building\'s intentions.");
        yield return lineBreak();
        yield return text("At End of Generation - each building is checked to see if the votes to reveal are" +
            " more than conceal. If a building\'s intent is concealed, the player");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Event GOOD/BAD -");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("GOOD -");
        yield return lineBreak();
        yield return text("BAD - Cure for a price.");
        yield return lineBreak();
        yield return text("already cured? Gain any knowledge.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Mind control");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("End =");
        yield return lineBreak();
        yield return text("The player that investigates the most times receives a bonus/negative.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Other Possible Ideas Not Implemented:");
        yield return lineBreak();
        yield return text("Place a Storybook token on space 35 of the Point track.");
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        yield return text("If a player completes 3 Occult Experiments this Generation.");
        yield return lineBreak();
        using (styleScope("heading", 1))
        {
            yield return text("ERROR!");
        }
        Vars.round = 13;
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            //yield return text("SETUP");
        }
        Vars._SetupImage = "AngryMobSetup1";
        yield return lineBreak();
        if (Vars.society == "Order of St. Hubertus")
        {
            yield return text("Turn to page ");
            using (styleScope("bold", true))
            {
                yield return text("17");
            }
            yield return text("of the Village Chronicle. Place the 2 ");
            using (styleScope("bold", true))
            {
                yield return text("Biology Master\'s Study");
            }
            yield return text("tiles into play near the other Vanity Estate Upgrades. Place the Suspicion Marker" +
            " on space ");
            using (styleScope("bold", true))
            {
                Vars.tracker = int.Parse(Vars.tracker) - 2;
                if (Vars.players == 4)
                {
                    Vars.tracker = int.Parse(Vars.tracker) - 1;
                }
                if (Vars.players == 5)
                {
                    Vars.tracker = int.Parse(Vars.tracker) - 1;
                }
                yield return text(Vars.tracker);
            }
            yield return text("and the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text("token one space to the left. ");
            using (styleScope("italic", true))
            {
                yield return text("Pass the Starting Player token as normal.");
            }
            if (Vars.players == 3)
            {
                yield return text("Then, since this is a 3 player game, pass the starting player marker clockwise 1 " +
            "additional time.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Place a ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text("token directly on top of the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text("token.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Suspicious_Building";
            yield return lineBreak();
            if (Vars.exposeA > 0)
            {
                yield return text("Place the ");
                yield return text(Vars.ba);
                yield return text("tile over spot A on the Village Chronicle. ");
                yield return lineBreak();
            }
            if (Vars.exposeB > 0)
            {
                yield return text("Place the ");
                yield return text(Vars.bb);
                yield return text("tile over spot B on the Village Chronicle. ");
                yield return lineBreak();
            }
            if (Vars.exposeC > 0)
            {
                yield return text("Place the ");
                yield return text(Vars.bc);
                yield return text("tile over spot C on the Village Chronicle.");
            }
            yield return text("Return all other Exposed Building tiles to the scenario box.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Acceptance");
            }
            yield return lineBreak();
            yield return text("Caretaker pieces can now take actions in Town as well as in the Estates. ");
            using (styleScope("italic", true))
            {
                yield return text("The same Town placement rules for Servants apply to Caretaker pieces.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("School for Hybridized Individuals");
            }
            yield return lineBreak();
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
            yield return text("to gain a ");
            using (styleScope("bold", true))
            {
                yield return text("Caretaker");
            }
            yield return text("piece from Lost. ");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Experiments are Feared");
            }
            yield return text("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
            yield return text("<sprite=\"Storybook\" index=0>");
            using (styleScope("bold", true))
            {
                yield return text("Angry Mob");
            }
            yield return lineBreak();
            yield return text("Any time the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text("token moves, move the Storybook token along with it. If the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text("overtakes a player, complete the current action and then ");
            yield return link("click here for a Storybook message.", "AngryMobStorybook", null);
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Biology Achievement");
            }
            yield return lineBreak();
            yield return text("When you gain a Vanity Estate Upgrade, the Biology Master\'s Study is part of the " +
            "available pool to build as normal.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click at the end of the round to continue...", "WolvesEco-Friendly", null);
        }
        //if (Vars.society == "Fraternity of Hunters")
        else
        {
            yield return text("Turn to page ");
            using (styleScope("bold", true))
            {
                yield return text("15");
            }
            yield return text("of the Village Chronicle. Place the 2 ");
            using (styleScope("bold", true))
            {
                yield return text("Engineering Master\'s Study");
            }
            yield return text("tiles into play near the other Vanity Estate Upgrades. The Suspicion Marker remai" +
            "ns in the same space and the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text("token is reset 1 space to the left. ");
            using (styleScope("italic", true))
            {
                yield return text("Pass the Starting Player token as normal.");
            }
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
                yield return text("tile over spot A on the Village Chronicle. ");
                yield return lineBreak();
            }
            if (Vars.exposeB > 0)
            {
                yield return text("Place the ");
                yield return text(Vars.bb);
                yield return text("tile over spot B on the Village Chronicle. ");
                yield return lineBreak();
            }
            if (Vars.exposeC > 0)
            {
                yield return text("Place the ");
                yield return text(Vars.bc);
                yield return text("tile over spot C on the Village Chronicle.");
            }
            yield return text("Return all other Exposed Building tiles to the scenario box.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Hunter\'s Haven");
            }
            yield return lineBreak();
            yield return text("For each visit to the Hunter\'s Haven, pay 1 Occult Knowledge cube to lose 2 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(". ");
            using (styleScope("italic", true))
            {
                yield return text("(You cannot use Journaled Knowledge to pay this cost.)");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Engineering Achievement");
            }
            yield return lineBreak();
            yield return text("When you gain a Vanity Estate Upgrade, the ");
            using (styleScope("bold", true))
            {
                yield return text("Engineering Master\'s Study");
            }
            yield return text("is part of the available pool to build as normal.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Endless Hunt");
            }
            yield return lineBreak();
            yield return text("At the end of the round, two of the scientists will be chosen to participate in t" +
            "he ");
            using (styleScope("bold", true))
            {
                yield return text("Night of the Hunt.");
            }
            yield return text("This invitation cannot be refused.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click at the end of the round to continue...", "CharityAwardGood", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: DevEventCure   (passage101)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11077-11170
// Links:  Diseases2
// Aborts: -
// Purpose: "An Alternative Cure": discard a completed B Experiment to store the Disease Experiment
// ###################################################################

    void passage101_Init()
    {
        this.Passages[@"DevEventCure"] = new StoryPassage(@"DevEventCure", new string[] { }, passage101_Main);
    }

    IStoryThread passage101_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("An Alternative Cure");
        }
        yield return lineBreak();
        yield return text("An envoy from the ");
        if (Vars.wolves == "evil")
        {
            using (styleScope("bold", true))
            {
                yield return text("Order of St. Hubertus");
            }
        }
        if (Vars.hunters == "evil")
        {
            using (styleScope("bold", true))
            {
                yield return text("Fraternity of Hunters");
            }
        }
        yield return text(" ");
        yield return text("arrived bearing an interesting narrative and a shimmering tincture of liquid. She vis" +
            "ited each of the manors in turn unable to conceal her wicked grin and laughter a" +
            "s she did so.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("\"The brotherhood has heard of your suffering and we wish to offer an exchange. Fo" +
            "r a meager bit of knowledge, we present a cure. Drink of this liquid and your dr" +
            "eaded affliction will cease,\" she said as a bolt of lightning arced across the s" +
            "ky above.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("click here to continue...", passage101_Fragment_1);
        using (styleScope("hook", "h000101"))
            yield return link("Click to continue...", null, () => enchantHook("h000101", HarloweEnchantCommand.Replace, passage101_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage101_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Diseases2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "ExperimentBBack";
            yield return lineBreak();
            yield return text("Each player, in turn order, may choose to discard a completed B-Level Experiment " +
                "");
            using (styleScope("italic", true))
            {
                yield return text("(to the bottom of the deck)");
            }
            yield return text(" ");
            yield return text("to place their ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" ");
            yield return text("into their ");
            using (styleScope("bold", true))
            {
                yield return text("Stored Experiments");
            }
            yield return text(". <i>They will no longer be affected by Disease events.</i>");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Any player that has already completed their <b>Hereditary Disease Experiment</b> cannot choose this action.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Continue once all players have made their decision.");
        }
        //yield return link("click here to continue...", "Diseases2", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage101_Fragment_1()
    {
        yield return enchant("click here to continue...", HarloweEnchantCommand.Replace, passage101_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: EnvPasscode   (passage102)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11175-11200
// Links:  -
// Aborts: -
// Purpose: Prompt to type the secret envelope password; hands off to Passcodechk
// ###################################################################

    void passage102_Init()
    {
        this.Passages[@"EnvPasscode"] = new StoryPassage(@"EnvPasscode", new string[] { }, passage102_Main);
    }

    IStoryThread passage102_Main()
    {
        if (ispopup && ispasscode)
        {
            ispopup = false;
            ispasscode = false;
            ViewPopupPanel.instance.Clear();
            ViewPopupPanel.instance.OnGenerationBtn("EnvPasscode", "Enter the secret password on your envelope.", "string", 0.25f);
        }
        else //if (ViewPopupPanel.instance.PassageValueString() != Vars.password )
        {
            Vars.password = ViewPopupPanel.instance.PassageValueString();
            Debug.Log("password check : " + Vars.password);
            ViewPopupPanel.instance.Clear();
            ispopup = true;
            yield return abort(goToPassage: "Passcodechk");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusWolves2   (passage103)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11206-11325
// Links:  RefusalWolves
// Aborts: -
// Purpose: Private Hubertus letter variant 2; secret expose/conceal choice
// ###################################################################

    void passage103_Init()
    {
        this.Passages[@"HubertusWolves2"] = new StoryPassage(@"HubertusWolves2", new string[] { }, passage103_Main);
    }

    IStoryThread passage103_Main()
    {
        if (Vars.meet == 0 || Vars.meet == "")
        {
            yield return abort(goToPassage: "FailedMeeting");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage103_Fragment_2);
        using (styleScope("hook", "h000103"))
            yield return link("Click to continue...", null, () => enchantHook("h000103", HarloweEnchantCommand.Replace, passage103_Fragment_1));
        yield break;
    }

    IStoryThread passage103_Fragment_0()
    {
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "wolves";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "wolves";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "wolves";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "wolves";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "wolves";
        }
        yield return abort(goToPassage: "HubertusConfirmation");
        yield break;
    }

    IStoryThread passage103_Fragment_1()
    {
        using (styleScope("bold", true))
        {
            yield return text("Upon a Secret Meeting - Letter - ");
            yield return text(macros1.either("April", "August", "October"));
            yield return text(" ");
            yield return text(macros1.random(1, 29));
            yield return text(", 1865");
        }
        yield return lineBreak();
        yield return text("I, ");
        yield return text(Vars.meet);
        yield return text(", am writing this letter to you after my meeting with an associate of the Interna" +
            "tional Order of St. Hubertus. Our conversation was brief, but the resulting know" +
            "ledge has piqued my curiosities.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It has been revealed to me that your intentions are ");
        if (Vars.wolves == "evil")
        {
            yield return text("nefarious. The malevolent Order is consumed with greed, seeking to unearth the an" +
            "cient secrets in this area and use this power to alter humanity and spread a pla" +
            "gue of monstrous entities across the world. You only asked for your work to rema" +
            "in ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(".");
        }
        else if (Vars.wolves == "good")
        {
            yield return text(@"demonstrably positive. The Order is only concerned with establishing a safe haven for those afflicted by disease. Your representative even revealed a physical peculiarity that had elongated her cuspids into sharp points. She left swiftly before nightfall, ignoring my pleas for her to remain, but she urged me to ");
            using (styleScope("bold", true))
            {
                yield return text("investigate");
            }
            yield return text(" the secret workings soon to become apparent.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Being intimately familiar with matters of the occult, this admission is unsurpris" +
            "ing. My apprehensions are only related to how your actions will impact my abilit" +
            "y to advance my scientific studies most generously.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("It is with sincerity that I:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        using (styleScope("hook", "h00040"))
            yield return link("join and pledge my service to your cause.", null, () => enchantHook("h00040", HarloweEnchantCommand.Replace, passage103_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        yield return link("refuse this ridiculous offer.", "RefusalWolves", null);
        yield break;
    }

    IStoryThread passage103_Fragment_2()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage103_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: Diseases1   (passage104)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11330-11435
// Links:  Gen1Creepy-RefusalBuild
// Aborts: -
// Purpose: "A Year of Sickness": players without the Disease Experiment discard Knowledge or lose 2VP
// ###################################################################

    void passage104_Init()
    {
        this.Passages[@"Diseases1"] = new StoryPassage(@"Diseases1", new string[] { }, passage104_Main);
    }

    IStoryThread passage104_Main()
    {
        Vars.disease1 = macros1.either(1, 2);
        if (Vars.disease1 == 1)
        {
            using (styleScope("bold", true))
            {
                yield return text("A Year of Sickness");
            }
            yield return lineBreak();
            yield return text("Even the most agile mind cannot willingly escape the frailness of the human form." +
            " As such, the foul plague upon the household syphoned a considerable energy from" +
            " their work and left them bed-ridden for months on end. ");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage104_Fragment_1);
            using (styleScope("hook", "h00010401"))
                yield return link("Click to continue...", null, () => enchantHook("h00010401", HarloweEnchantCommand.Replace, passage104_Fragment_0));
        }
        if (Vars.disease1 == 2)
        {
            using (styleScope("bold", true))
            {
                yield return text("Rest and Time");
            }
            yield return lineBreak();
            yield return text("It seemed that the cousins were fortunate in their early years. Even the most agi" +
            "le mind cannot willingly escape the frailness of the human form. However, with a" +
            " strict regimen of rest, diet, and bloodletting, these deficiencies could mostly" +
            " be nullified.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage104_Fragment_3);
            using (styleScope("hook", "h00010403"))
                yield return link("Click to continue...", null, () => enchantHook("h00010403", HarloweEnchantCommand.Replace, passage104_Fragment_2));
        }
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage104_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = Vars.seedy == "no" ? "Gen1Creepy-RefusalBuild" : "Devastation2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return text("All players that have not completed the ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" must ");
            using (styleScope("bold", true))
            {
                yield return text("discard a Knowledge cube to the supply");
            }
            yield return text(" or ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2VP");
            }
            yield return text(".");
        }
        //yield return link("Click to continue...", "Gen1Creepy-RefusalBuild", null);
        yield break;
    }

    IStoryThread passage104_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage104_Fragment_0);
        yield break;
    }

    IStoryThread passage104_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = Vars.seedy == "no" ? "Gen1Creepy-RefusalBuild" : "Devastation2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return text("The Hereditary disease has no effect.");
        }
        //yield return link("Click to continue...", "Gen1Creepy-RefusalBuild", null);
        yield break;
    }

    IStoryThread passage104_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage104_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusWolves3   (passage105)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11440-11560
// Links:  RefusalWolves
// Aborts: -
// Purpose: Private Hubertus letter variant 3; expose/conceal choice
// ###################################################################

    void passage105_Init()
    {
        this.Passages[@"HubertusWolves3"] = new StoryPassage(@"HubertusWolves3", new string[] { }, passage105_Main);
    }

    IStoryThread passage105_Main()
    {
        if (Vars.meet == 0 || Vars.meet == "")
        {
            yield return abort(goToPassage: "FailedMeeting");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage105_Fragment_2);
        using (styleScope("hook", "h000105"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000105", HarloweEnchantCommand.Replace, passage105_Fragment_1));
        yield break;
    }

    IStoryThread passage105_Fragment_0()
    {
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "wolves";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "wolves";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "wolves";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "wolves";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "wolves";
        }
        yield return abort(goToPassage: "HubertusConfirmation");
        yield break;
    }

    IStoryThread passage105_Fragment_1()
    {
        using (styleScope("bold", true))
        {
            yield return text("Upon a Secret Meeting - Letter - ");
            yield return text(macros1.either("April", "August", "October"));
            yield return text(" ");
            yield return text(macros1.random(1, 29));
            yield return text(", 1865");
        }
        yield return lineBreak();
        yield return text("I, ");
        yield return text(Vars.meet);
        yield return text(", am writing this letter to you after my meeting with an associate of the Interna" +
            "tional Order of St. Hubertus. Our conversation was brief, but the resulting know" +
            "ledge has piqued my curiosities.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It has been revealed to me that your intentions are ");
        if (Vars.wolves == "evil")
        {
            yield return text("nefarious. The malevolent Order is consumed with greed, seeking to unearth the an" +
            "cient secrets in this area and use this power to alter humanity and spread a pla" +
            "gue of monstrous entities across the world. You only asked for your work to rema" +
            "in ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(".");
        }
        //else if (Vars.wolves == "good")
        else
        {
            yield return text(@"demonstrably positive. The Order is only concerned with establishing a safe haven for those afflicted by disease. Your representative even revealed a physical peculiarity that had elongated her cuspids into sharp points. She left swiftly before nightfall, ignoring my pleas for her to remain, but she urged me to ");
            using (styleScope("bold", true))
            {
                yield return text("investigate");
            }
            yield return text(" the secret workings soon to become apparent.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Being intimately familiar with matters of the occult, this admission is unsurpris" +
            "ing. My apprehensions are only related to how your actions will impact my abilit" +
            "y to advance my scientific studies most generously.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("It is with sincerity that I:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        using (styleScope("hook", "h00041"))
            yield return link("join and pledge my service to your cause.", null, () => enchantHook("h00041", HarloweEnchantCommand.Replace, passage105_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        yield return link("refuse this ridiculous offer.", "RefusalWolves", null);
        yield break;
    }

    IStoryThread passage105_Fragment_2()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage105_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusHunters1   (passage106)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11565-11683
// Links:  RefusalHunters
// Aborts: -
// Purpose: Private Fraternity of Hunters letter variant 1; expose/conceal choice
// ###################################################################

    void passage106_Init()
    {
        this.Passages[@"HubertusHunters1"] = new StoryPassage(@"HubertusHunters1", new string[] { }, passage106_Main);
    }

    IStoryThread passage106_Main()
    {
        if (Vars.meet == 0 || Vars.meet == "")
        {
            yield return abort(goToPassage: "FailedMeeting");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage106_Fragment_2);
        using (styleScope("hook", "h000106"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000106", HarloweEnchantCommand.Replace, passage106_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage106_Fragment_0()
    {
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "hunters";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "hunters";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "hunters";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "hunters";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "hunters";
        }
        yield return abort(goToPassage: "HuntersConfirmation");
        yield break;
    }

    IStoryThread passage106_Fragment_1()
    {
        using (styleScope("bold", true))
        {
            yield return text("Upon a Secret Meeting - Letter - ");
            yield return text(macros1.either("April", "August", "October"));
            yield return text(" ");
            yield return text(macros1.random(1, 29));
            yield return text(", 1865");
        }
        yield return lineBreak();
        yield return text("I, ");
        yield return text(Vars.meet);
        yield return text(", am writing this letter to you after my meeting with an associate of the Interna" +
            "tional Fraternity of Hunters. Our secret conversation over brunch was quite reve" +
            "aling, and the resulting knowledge has piqued my interests.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It has been revealed to me that your intentions are ");
        if (Vars.hunters == "evil")
        {
            yield return text(@"amusingly exploitative. The Fraternity hopes to use the recent epidemic as a cover for their activities to unearth ancient supernatural secrets in the region and use them for monetary and political gain. Although I remain skeptical, if these labors are successful, I will be deeply interested in the results. You only asked for your work to remain ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(".");
        }
        //else if (Vars.hunters == "good")
        else
        {
            yield return text(@"good. It was astute for you to note how oddly silent the town has remained over the last few years. Keeping a watchful eye over the proceedings, the Fraternity appears only concerned with rooting out who or what is behind this veil of secrecy. You've urged me to ");
            using (styleScope("bold", true))
            {
                yield return text("investigate");
            }
            yield return text(" the secret workings soon to become apparent.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Being an entrepreneur myself, in a fashion, these goals are not so misaligned wit" +
            "h my own. My apprehensions are only related to how your actions will impact my a" +
            "bility to advance my scientific studies most generously.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("It is with sincerity that I:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        using (styleScope("hook", "h00042"))
            yield return link("join and pledge my service to your cause.", null, () => enchantHook("h00042", HarloweEnchantCommand.Replace, passage106_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        yield return link("refuse this ridiculous offer.", "RefusalHunters", null);
        yield break;
    }

    IStoryThread passage106_Fragment_2()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage106_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: DevastationFate1   (passage107)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 11688-11793
// Links:  HelpingEvil,ProsperityHunterIntro,ProsperityWolvesIntro
// Aborts: -
// Purpose: "Strong Alliance" end-of-Devastation fate; branches to the Gen3 intros
// ###################################################################

    void passage107_Init()
    {
        this.Passages[@"DevastationFate1"] = new StoryPassage(@"DevastationFate1", new string[] { "END", }, passage107_Main);
    }

    IStoryThread passage107_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Strong Alliance");
        }
        yield return lineBreak();
        //yield return lineBreak();
        //yield return text("Remove all player pieces from the board and Perform the End of a Generation. Retu" +
        //    "rn any remaining ");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens to the supply.");
        string s = "Remove all player pieces from the board and Perform the End of a Generation. Return any remaining <sprite=\"StorybookToken\" index=0> tokens to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 6);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The ties that bound the family to these secret warring factions changed the cours" +
            "e of history.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.society == "Fraternity of Hunters")
        {
            if (Vars.hunters == "evil")
            {
                yield return text("While secrets could not forever be kept, the silent assistance of ");
                yield return text(Vars.playtxt);
                yield return text(" influential members of the upper crust ensured that the ");
                using (styleScope("bold", true))
                {
                    yield return text("Hunters");
                }
                yield return text(" could progress in their endeavors long enough to make their presence integral to " +
            "the town. For a price, they swore to protect all citizens from the disease and d" +
            "arkness that had enveloped the countryside.");
                yield return lineBreak();
                yield return lineBreak();
                yield return link("Click to continue...", "HelpingEvil", null);
            }
            //if (Vars.hunters == "good")
            else
            {
                yield return text("By exposing the nefarious work of the ");
                using (styleScope("bold", true))
                {
                    yield return text("Order of St. Hubertus,");
                }
                yield return text(" the additional attention forced them to leave the region. Motivated by the promis" +
            "e of swift justice, the ");
                using (styleScope("bold", true))
                {
                    yield return text("Fraternity of Hunters");
                }
                yield return text(" created a stronghold in the town. They swore at all costs to protect the town fro" +
            "m the evils that roamed the land.");
                yield return lineBreak();
                yield return lineBreak();
                yield return link("Click to continue...", "ProsperityHunterIntro", null);
            }
        }
        //if (Vars.society == "Order of St. Hubertus")
        else
        {
            if (Vars.wolves == "evil")
            {
                yield return text("While secrets could not forever be kept, the silent assistance of ");
                yield return text(Vars.playtxt);
                yield return text(" influential members of the upper crust ensured that the ");
                using (styleScope("bold", true))
                {
                    yield return text("Order");
                }
                yield return text(" could progress in their endeavors long enough to make their presence integral to " +
            "the town. They immediately began to advance their schemes.");
                yield return lineBreak();
                yield return lineBreak();
                yield return link("Click to continue...", "HelpingEvil", null);
            }
            //if (Vars.wolves == "good")
            else
            {
                yield return text("By exposing the insidious deeds of the ");
                using (styleScope("bold", true))
                {
                    yield return text("Fraternity of Hunters,");
                }
                yield return text(" the additional attention forced them to quit the region. Motivated by the promise" +
            " of swift justice, the ");
                using (styleScope("bold", true))
                {
                    yield return text("Order of St. Hubertus");
                }
                yield return text(" created a stronghold in the town. They swore to provide a haven for all outcasts." +
            "");
                yield return lineBreak();
                yield return lineBreak();
                yield return link("Click to continue...", "ProsperityWolvesIntro", null);
            }
        }
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusHunters2   (passage108)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11799-11917
// Links:  RefusalHunters
// Aborts: -
// Purpose: Private Hunters letter variant 2; expose/conceal choice
// ###################################################################

    void passage108_Init()
    {
        this.Passages[@"HubertusHunters2"] = new StoryPassage(@"HubertusHunters2", new string[] { }, passage108_Main);
    }

    IStoryThread passage108_Main()
    {
        if (Vars.meet == 0 || Vars.meet == "")
        {
            yield return abort(goToPassage: "FailedMeeting");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage108_Fragment_2);
        using (styleScope("hook", "h000108"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000108", HarloweEnchantCommand.Replace, passage108_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage108_Fragment_0()
    {
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "hunters";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "hunters";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "hunters";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "hunters";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "hunters";
        }
        yield return abort(goToPassage: "HuntersConfirmation");
        yield break;
    }

    IStoryThread passage108_Fragment_1()
    {
        using (styleScope("bold", true))
        {
            yield return text("Upon a Secret Meeting - Letter - ");
            yield return text(macros1.either("April", "August", "October"));
            yield return text(" ");
            yield return text(macros1.random(1, 29));
            yield return text(", 1865");
        }
        yield return lineBreak();
        yield return text("I, ");
        yield return text(Vars.meet);
        yield return text(", am writing this letter to you after my meeting with an associate of the Interna" +
            "tional Fraternity of Hunters. Our secret conversation over brunch was quite reve" +
            "aling, and the resulting knowledge has piqued my interests.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It has been revealed to me that your intentions are ");
        if (Vars.hunters == "evil")
        {
            yield return text(@"amusingly exploitative. The Fraternity hopes to use the recent epidemic as a cover for their activities to unearth ancient, supernatural secrets in the region and use them for monetary and political gain. Although I remain skeptical, if these labors are successful, I will be deeply interested in the results. You only asked for your work to remain ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(".");
        }
        //else if (Vars.hunters == "good")
        else
        {
            yield return text(@"good. It was astute for you to note how oddly silent the town has remained over the last few years. Keeping a watchful eye over the proceedings, the Fraternity appears only concerned with rooting out who or what is behind this veil of secrecy. You've urged me to ");
            using (styleScope("bold", true))
            {
                yield return text("investigate");
            }
            yield return text(" the secret workings soon to become apparent.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Being an entrepreneur myself, in a fashion, these goals are not so misaligned wit" +
            "h my own. My apprehensions are only related to how your actions will impact my a" +
            "bility to advance my scientific studies most generously.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("It is with sincerity that I:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        using (styleScope("hook", "h00043"))
            yield return link("join and pledge my service to your cause.", null, () => enchantHook("h00043", HarloweEnchantCommand.Replace, passage108_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        yield return link("refuse this ridiculous offer.", "RefusalHunters", null);
        yield break;
    }

    IStoryThread passage108_Fragment_2()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage108_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusHunters3   (passage109)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 11922-12040
// Links:  RefusalHunters
// Aborts: -
// Purpose: Private Hunters letter variant 3; expose/conceal choice
// ###################################################################

    void passage109_Init()
    {
        this.Passages[@"HubertusHunters3"] = new StoryPassage(@"HubertusHunters3", new string[] { }, passage109_Main);
    }

    IStoryThread passage109_Main()
    {
        if (Vars.meet == 0 || Vars.meet == "")
        {
            yield return abort(goToPassage: "FailedMeeting");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage109_Fragment_2);
        using (styleScope("hook", "h000109"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000109", HarloweEnchantCommand.Replace, passage109_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage109_Fragment_0()
    {
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "hunters";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "hunters";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "hunters";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "hunters";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "hunters";
        }
        yield return abort(goToPassage: "HuntersConfirmation");
        yield break;
    }

    IStoryThread passage109_Fragment_1()
    {
        using (styleScope("bold", true))
        {
            yield return text("Upon a Secret Meeting - Letter - ");
            yield return text(macros1.either("April", "August", "October"));
            yield return text(" ");
            yield return text(macros1.random(1, 29));
            yield return text(", 1865");
        }
        yield return lineBreak();
        yield return text("I, ");
        yield return text(Vars.meet);
        yield return text(", am writing this letter to you after my meeting with an associate of the Interna" +
            "tional Fraternity of Hunters. Our secret conversation over brunch was quite reve" +
            "aling, and the resulting knowledge has piqued my interests.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It has been revealed to me that your intentions are ");
        if (Vars.hunters == "evil")
        {
            yield return text(@"amusingly exploitative. The Fraternity hopes to use the recent epidemic as a cover for their activities to unearth ancient, supernatural secrets in the region and use them for monetary and political gain. Although I remain skeptical, if these labors are successful, I will be deeply interested in the results. You only asked for your work to remain ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(".");
        }
        //else if (Vars.hunters == "good")
        else
        {
            yield return text(@"good. It was astute for you to note how oddly silent the town has remained over the last few years. Keeping a watchful eye over the proceedings, the Fraternity appears only concerned with rooting out who or what is behind this veil of secrecy. You've urged me to ");
            using (styleScope("bold", true))
            {
                yield return text("investigate");
            }
            yield return text(" the secret workings soon to become apparent.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Being an entrepreneur myself, in a fashion, these goals are not so misaligned wit" +
            "h my own. My apprehensions are only related to how your actions will impact my a" +
            "bility to advance my scientific studies most generously.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("It is with sincerity that I:");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        using (styleScope("hook", "h00044"))
            yield return link("join and pledge my service to your cause.", null, () => enchantHook("h00044", HarloweEnchantCommand.Replace, passage109_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("...have decided to ");
        yield return link("refuse this ridiculous offer.", "RefusalHunters", null);
        yield break;
    }

    IStoryThread passage109_Fragment_2()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage109_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: Passcodechk   (passage110)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12045-12119
// Links:  -
// Aborts: -
// Purpose: Password validator: alpha/moon/howl/right/cross/bolt -> the six letter passages, else FailedMeeting
// ###################################################################

    void passage110_Init()
    {
        this.Passages[@"Passcodechk"] = new StoryPassage(@"Passcodechk", new string[] { }, passage110_Main);
    }

    IStoryThread passage110_Main()
    {
        Debug.Log("Password ::: " + Vars.password);
        if (Vars.password == "alpha")
        {
            Vars.meet = Vars.let1;
            yield return abort(goToPassage: "HubertusWolves1");
        }
        else if (Vars.password == "moon")
        {
            Vars.meet = Vars.let2;
            yield return abort(goToPassage: "HubertusWolves2");
        }
        else if (Vars.password == "howl")
        {
            Vars.meet = Vars.let3;
            yield return abort(goToPassage: "HubertusWolves3");
        }
        else if (Vars.password == "right")
        {
            Vars.meet = Vars.let4;
            yield return abort(goToPassage: "HubertusHunters1");
        }
        else if (Vars.password == "cross")
        {
            Vars.meet = Vars.let5;
            yield return abort(goToPassage: "HubertusHunters2");
        }
        else if (Vars.password == "bolt")
        {
            Vars.meet = Vars.let6;
            yield return abort(goToPassage: "HubertusHunters3");
        }
        else if (Vars.password == "Alpha")
        {
            Vars.meet = Vars.let1;
            yield return abort(goToPassage: "HubertusWolves1");
        }
        else if (Vars.password == "Moon")
        {
            Vars.meet = Vars.let2;
            yield return abort(goToPassage: "HubertusWolves2");
        }
        else if (Vars.password == "Howl")
        {
            Vars.meet = Vars.let3;
            yield return abort(goToPassage: "HubertusWolves3");
        }
        else if (Vars.password == "Right")
        {
            Vars.meet = Vars.let4;
            yield return abort(goToPassage: "HubertusHunters1");
        }
        else if (Vars.password == "Cross")
        {
            Vars.meet = Vars.let5;
            yield return abort(goToPassage: "HubertusHunters2");
        }
        else if (Vars.password == "Bolt")
        {
            Vars.meet = Vars.let6;
            yield return abort(goToPassage: "HubertusHunters3");
        }
        else
        {
            yield return abort(goToPassage: "FailedMeeting");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: BuildingSignin   (passage111)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12125-12210
// Links:  -
// Aborts: -
// Purpose: "Investigation": which player is investigating; routes to the matching Buildplay
// ###################################################################

    void passage111_Init()
    {
        this.Passages[@"BuildingSignin"] = new StoryPassage(@"BuildingSignin", new string[] { }, passage111_Main);
    }

    IStoryThread passage111_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Investigation");
        }
        yield return lineBreak();
        yield return text("After visiting the establishment, the peculiar attitude of the workers and the pr" +
            "istine furnishings further piqued their curiosity. Several days later, they deci" +
            "ded to forgo their scientific obligations for one evening and investigate the ");
        yield return text(Vars.inv);
        yield return text(".");
        yield return lineBreak();
        Vars.devpage = 1;
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Please choose which player is making this investigation:");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00045"))
            yield return link(Vars.nameA, null, () => enchantHook("h00045", HarloweEnchantCommand.Replace, passage111_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00046"))
            yield return link(Vars.nameB, null, () => enchantHook("h00046", HarloweEnchantCommand.Replace, passage111_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00047"))
                yield return link(Vars.nameC, null, () => enchantHook("h00047", HarloweEnchantCommand.Replace, passage111_Fragment_2));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00048"))
                yield return link(Vars.nameD, null, () => enchantHook("h00048", HarloweEnchantCommand.Replace, passage111_Fragment_3));
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00049"))
                yield return link(Vars.nameE, null, () => enchantHook("h00049", HarloweEnchantCommand.Replace, passage111_Fragment_4));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage111_Fragment_0()
    {
        yield return abort(goToPassage: "BuildplayA");
        yield break;
    }

    IStoryThread passage111_Fragment_1()
    {
        yield return abort(goToPassage: "BuildplayB");
        yield break;
    }

    IStoryThread passage111_Fragment_2()
    {
        yield return abort(goToPassage: "BuildplayC");
        yield break;
    }

    IStoryThread passage111_Fragment_3()
    {
        yield return abort(goToPassage: "BuildplayD");
        yield break;
    }

    IStoryThread passage111_Fragment_4()
    {
        yield return abort(goToPassage: "BuildplayE");
        yield break;
    }

// ###################################################################
// PASSAGE: BuildplayA   (passage112)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12215-12330
// Links:  -
// Aborts: -
// Purpose: Player A private investigation journal; secret expose/conceal decision
// ###################################################################

    void passage112_Init()
    {
        this.Passages[@"BuildplayA"] = new StoryPassage(@"BuildplayA", new string[] { }, passage112_Main);
    }

    IStoryThread passage112_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Do not allow the other players to see the Storybook while making the decision bel" +
            "ow.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continuing Investigation - Compiled Journal Entries of ");
            yield return text(Vars.nameA);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.inv == Vars.ba)
        {
            yield return text("I arrived at the ");
            yield return text(Vars.ba);
            yield return text(" under cover of darkness. I was ill-suited for such stealthy missions, but I kept " +
            "my cloak and collar about my neck to conceal my identity in case I was discovere" +
            "d.");
        }
        else if (Vars.inv == Vars.bb)
        {
            yield return text("A thick fog shrouded my approach on the cool night that I chose to investigate th" +
            "e ");
            yield return text(Vars.bb);
            yield return text(". I asked the carriage driver to await my return on the outskirts of town, while " +
            "I stole away into the empty streets. Nary a soul was about on this evening, and " +
            "I was soon inside without arousing suspicion.");
        }
        //if (Vars.inv == Vars.bc)
        else
        {
            yield return text("To my chagrin, a ");
            yield return text(macros1.either("gentleman", "gentlewoman"));
            yield return text(@" stood near the front door of the building. At this late hour, I could only assume that they were standing guard. Not to be thwarted so easily, I tilted my hat to obscure my face and stalked into the alley behind. The lock on the rear door was a trifle for my tools, and I entered without a sound.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I could either provide evidence to help ");
        using (styleScope("bold", true))
        {
            yield return text("expose");
        }
        yield return text(" ");
        yield return text("the secret inner workings of the building or I could ");
        using (styleScope("bold", true))
        {
            yield return text("conceal");
        }
        yield return text(" ");
        yield return text("the truth and allow the work to continue. ");
        using (styleScope("bold", true))
        {
            yield return text("The decision was clear to me:");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.playA = int.Parse(Vars.playA) + 1;
        using (styleScope("hook", "h00050"))
            yield return link("I exposed the truth.", null, () => enchantHook("h00050", HarloweEnchantCommand.Replace, passage112_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00051"))
            yield return link("I concealed the true purpose.", null, () => enchantHook("h00051", HarloweEnchantCommand.Replace, passage112_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage112_Fragment_0()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.pAA = "yes";
            Vars.exposeA = int.Parse(Vars.exposeA) + 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.pAB = "yes";
            Vars.exposeB = int.Parse(Vars.exposeB) + 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.pAC = "yes";
            Vars.exposeC = int.Parse(Vars.exposeC) + 1;
        }
        yield return abort(goToPassage: "ExposeConfirmation");
        yield break;
    }

    IStoryThread passage112_Fragment_1()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.exposeA = int.Parse(Vars.exposeA) - 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.exposeB = int.Parse(Vars.exposeB) - 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.exposeC = int.Parse(Vars.exposeC) - 1;
        }
        yield return abort(goToPassage: "ConcealConfirmation");
        yield break;
    }

// ###################################################################
// PASSAGE: ExposeConfirmation   (passage113)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12335-12364
// Links:  Devastation2,Devastation3
// Aborts: -
// Purpose: Private confirmation screen: chose to expose
// ###################################################################

    void passage113_Init()
    {
        this.Passages[@"ExposeConfirmation"] = new StoryPassage(@"ExposeConfirmation", new string[] { }, passage113_Main);
    }

    IStoryThread passage113_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Exposed");
        }
        yield return lineBreak();
        yield return text("I knew it was the correct decision. To allow this terrible work to continue unaba" +
            "ted would not align with my own crucial endeavors. But, would my cousins feel th" +
            "e same way?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 5)
        {
            yield return link("Click here to continue...", "Devastation2", null);
        }
        //yield return lineBreak();
        //if (Vars.round == 6)
        else
        {
            yield return link("Click here to continue...", "Devastation3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: ConcealConfirmation   (passage114)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12370-12399
// Links:  Devastation2,Devastation3
// Aborts: -
// Purpose: Private confirmation screen: chose to conceal
// ###################################################################

    void passage114_Init()
    {
        this.Passages[@"ConcealConfirmation"] = new StoryPassage(@"ConcealConfirmation", new string[] { }, passage114_Main);
    }

    IStoryThread passage114_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Concealed");
        }
        yield return lineBreak();
        yield return text("Knowledge may have been my main pursuit when investigating the suspicious buildin" +
            "g, but now with a complete understanding of the devious machinations inside, I d" +
            "ecided to err on the side of secrecy. But would this be enough?");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 5)
        {
            yield return link("Click here to continue...", "Devastation2", null);
        }
        //yield return lineBreak();
        //if (Vars.round == 6)
        else
        {
            yield return link("Click here to continue...", "Devastation3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: BuildplayB   (passage115)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12405-12520
// Links:  -
// Aborts: -
// Purpose: Player B private investigation journal
// ###################################################################

    void passage115_Init()
    {
        this.Passages[@"BuildplayB"] = new StoryPassage(@"BuildplayB", new string[] { }, passage115_Main);
    }

    IStoryThread passage115_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Do not allow the other player\'s to see the Storybook while making the decision be" +
            "low.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continuing Investigation - Compiled Journal Entries of ");
            yield return text(Vars.nameB);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.inv == Vars.ba)
        {
            yield return text("I arrived at the ");
            yield return text(Vars.ba);
            yield return text(" under cover of darkness. I was ill-suited for such stealthy missions, but I kept " +
            "my cloak and collar about my neck to conceal my identity in case I was discovere" +
            "d.");
        }
        else if (Vars.inv == Vars.bb)
        {
            yield return text("A thick fog shrouded my approach on the cool night that I chose to investigate th" +
            "e ");
            yield return text(Vars.bb);
            yield return text(". I asked the carriage driver to await my return on the outskirts of town, while " +
            "I stole away into the empty streets. Nary a soul was about on this evening, and " +
            "I was soon inside without arousing suspicion.");
        }
        //if (Vars.inv == Vars.bc)
        else
        {
            yield return text("To my chagrin, a ");
            yield return text(macros1.either("gentleman", "gentlewoman"));
            yield return text(@" stood near the front door of the building. At this late hour, I could only assume that they were standing guard. Not to be thwarted so easily, I tilted my hat to obscure my face and stalked into the alley behind. The lock on the rear door was a trifle for my tools, and I entered without a sound.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I could either provide evidence to help ");
        using (styleScope("bold", true))
        {
            yield return text("expose");
        }
        yield return text(" ");
        yield return text("the secret inner workings of the building or I could ");
        using (styleScope("bold", true))
        {
            yield return text("conceal");
        }
        yield return text(" ");
        yield return text("the truth and allow the work to continue. ");
        using (styleScope("bold", true))
        {
            yield return text("The decision was clear to me:");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.playB = int.Parse(Vars.playB) + 1;
        using (styleScope("hook", "h00052"))
            yield return link("I exposed the truth.", null, () => enchantHook("h00052", HarloweEnchantCommand.Replace, passage115_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00053"))
            yield return link("I concealed the true purpose.", null, () => enchantHook("h00053", HarloweEnchantCommand.Replace, passage115_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage115_Fragment_0()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.pBA = "yes";
            Vars.exposeA = int.Parse(Vars.exposeA) + 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.pBB = "yes";
            Vars.exposeB = int.Parse(Vars.exposeB) + 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.pBC = "yes";
            Vars.exposeC = int.Parse(Vars.exposeC) + 1;
        }
        yield return abort(goToPassage: "ExposeConfirmation");
        yield break;
    }

    IStoryThread passage115_Fragment_1()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.exposeA = int.Parse(Vars.exposeA) - 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.exposeB = int.Parse(Vars.exposeB) - 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.exposeC = int.Parse(Vars.exposeC) - 1;
        }
        yield return abort(goToPassage: "ConcealConfirmation");
        yield break;
    }

// ###################################################################
// PASSAGE: BuildplayC   (passage116)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12525-12640
// Links:  -
// Aborts: -
// Purpose: Player C private investigation journal
// ###################################################################

    void passage116_Init()
    {
        this.Passages[@"BuildplayC"] = new StoryPassage(@"BuildplayC", new string[] { }, passage116_Main);
    }

    IStoryThread passage116_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Do not allow the other player\'s to see the Storybook while making the decision be" +
            "low.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continuing Investigation - Compiled Journal Entries of ");
            yield return text(Vars.nameC);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.inv == Vars.ba)
        {
            yield return text("I arrived at the ");
            yield return text(Vars.ba);
            yield return text(" under cover of darkness. I was ill-suited for such stealthy missions, but I kept " +
            "my cloak and collar about my neck to conceal my identity in case I was discovere" +
            "d.");
        }
        else if (Vars.inv == Vars.bb)
        {
            yield return text("A thick fog shrouded my approach on the cool night that I chose to investigate th" +
            "e ");
            yield return text(Vars.bb);
            yield return text(". I asked the carriage driver to await my return on the outskirts of town, while " +
            "I stole away into the empty streets. Nary a soul was about on this evening, and " +
            "I was soon inside without arousing suspicion.");
        }
        //if (Vars.inv == Vars.bc)
        else
        {
            yield return text("To my chagrin, a ");
            yield return text(macros1.either("gentleman", "gentlewoman"));
            yield return text(@" stood near the front door of the building. At this late hour, I could only assume that they were standing guard. Not to be thwarted so easily, I tilted my hat to obscure my face and stalked into the alley behind. The lock on the rear door was a trifle for my tools, and I entered without a sound.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I could either provide evidence to help ");
        using (styleScope("bold", true))
        {
            yield return text("expose");
        }
        yield return text(" ");
        yield return text("the secret inner workings of the building or I could ");
        using (styleScope("bold", true))
        {
            yield return text("conceal");
        }
        yield return text(" ");
        yield return text("the truth and allow the work to continue. ");
        using (styleScope("bold", true))
        {
            yield return text("The decision was clear to me:");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.playC = int.Parse(Vars.playC) + 1;
        using (styleScope("hook", "h00054"))
            yield return link("I exposed the truth.", null, () => enchantHook("h00054", HarloweEnchantCommand.Replace, passage116_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00055"))
            yield return link("I concealed the true purpose.", null, () => enchantHook("h00055", HarloweEnchantCommand.Replace, passage116_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage116_Fragment_0()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.pCA = "yes";
            Vars.exposeA = int.Parse(Vars.exposeA) + 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.pCB = "yes";
            Vars.exposeB = int.Parse(Vars.exposeB) + 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.pCC = "yes";
            Vars.exposeC = int.Parse(Vars.exposeC) + 1;
        }
        yield return abort(goToPassage: "ExposeConfirmation");
        yield break;
    }

    IStoryThread passage116_Fragment_1()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.exposeA = int.Parse(Vars.exposeA) - 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.exposeB = int.Parse(Vars.exposeB) - 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.exposeC = int.Parse(Vars.exposeC) - 1;
        }
        yield return abort(goToPassage: "ConcealConfirmation");
        yield break;
    }

// ###################################################################
// PASSAGE: BuildplayD   (passage117)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12645-12760
// Links:  -
// Aborts: -
// Purpose: Player D private investigation journal
// ###################################################################

    void passage117_Init()
    {
        this.Passages[@"BuildplayD"] = new StoryPassage(@"BuildplayD", new string[] { }, passage117_Main);
    }

    IStoryThread passage117_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Do not allow the other players to see the Storybook while making the decision bel" +
            "ow.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continuing Investigation - Compiled Journal Entries of ");
            yield return text(Vars.nameD);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.inv == Vars.ba)
        {
            yield return text("I arrived at the ");
            yield return text(Vars.ba);
            yield return text(" under cover of darkness. I was ill-suited for such stealthy missions, but I kept " +
            "my cloak and collar about my neck to conceal my identity in case I was discovere" +
            "d.");
        }
        else if (Vars.inv == Vars.bb)
        {
            yield return text("A thick fog shrouded my approach on the cool night that I chose to investigate th" +
            "e ");
            yield return text(Vars.bb);
            yield return text(". I asked the carriage driver to await my return on the outskirts of town, while " +
            "I stole away into the empty streets. Nary a soul was about on this evening, and " +
            "I was soon inside without arousing suspicion.");
        }
        //if (Vars.inv == Vars.bc)
        else
        {
            yield return text("To my chagrin, a ");
            yield return text(macros1.either("gentleman", "gentlewoman"));
            yield return text(@" stood near the front door of the building. At this late hour, I could only assume that they were standing guard. Not to be thwarted so easily, I tilted my hat to obscure my face and stalked into the alley behind. The lock on the rear door was a trifle for my tools, and I entered without a sound.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I could either provide evidence to help ");
        using (styleScope("bold", true))
        {
            yield return text("expose");
        }
        yield return text(" ");
        yield return text("the secret inner workings of the building or I could ");
        using (styleScope("bold", true))
        {
            yield return text("conceal");
        }
        yield return text(" ");
        yield return text("the truth and allow the work to continue. ");
        using (styleScope("bold", true))
        {
            yield return text("The decision was clear to me:");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.playD = int.Parse(Vars.playD) + 1;
        using (styleScope("hook", "h00056"))
            yield return link("I exposed the truth.", null, () => enchantHook("h00056", HarloweEnchantCommand.Replace, passage117_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00057"))
            yield return link("I concealed the true purpose.", null, () => enchantHook("h00057", HarloweEnchantCommand.Replace, passage117_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage117_Fragment_0()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.pDA = "yes";
            Vars.exposeA = int.Parse(Vars.exposeA) + 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.pDB = "yes";
            Vars.exposeB = int.Parse(Vars.exposeB) + 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.pDC = "yes";
            Vars.exposeC = int.Parse(Vars.exposeC) + 1;
        }
        yield return abort(goToPassage: "ExposeConfirmation");
        yield break;
    }

    IStoryThread passage117_Fragment_1()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.exposeA = int.Parse(Vars.exposeA) - 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.exposeB = int.Parse(Vars.exposeB) - 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.exposeC = int.Parse(Vars.exposeC) - 1;
        }
        yield return abort(goToPassage: "ConcealConfirmation");
        yield break;
    }

// ###################################################################
// PASSAGE: BuildplayE   (passage118)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12765-12880
// Links:  -
// Aborts: -
// Purpose: Player E private investigation journal
// ###################################################################

    void passage118_Init()
    {
        this.Passages[@"BuildplayE"] = new StoryPassage(@"BuildplayE", new string[] { }, passage118_Main);
    }

    IStoryThread passage118_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Do not allow the other players to see the Storybook while making the decision bel" +
            "ow.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continuing Investigation - Compiled Journal Entries of ");
            yield return text(Vars.nameE);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.inv == Vars.ba)
        {
            yield return text("I arrived at the ");
            yield return text(Vars.ba);
            yield return text(" under cover of darkness. I was ill-suited for such stealthy missions, but I kept " +
            "my cloak and collar about my neck to conceal my identity in case I was discovere" +
            "d.");
        }
        else if (Vars.inv == Vars.bb)
        {
            yield return text("A thick fog shrouded my approach on the cool night that I chose to investigate th" +
            "e ");
            yield return text(Vars.bb);
            yield return text(". I asked the carriage driver to await my return on the outskirts of town, while " +
            "I stole away into the empty streets. Nary a soul was about on this evening, and " +
            "I was soon inside without arousing suspicion.");
        }
        //if (Vars.inv == Vars.bc)
        else
        {
            yield return text("To my chagrin, a ");
            yield return text(macros1.either("gentleman", "gentlewoman"));
            yield return text(@" stood near the front door of the building. At this late hour, I could only assume that they were standing guard. Not to be thwarted so easily, I tilted my hat to obscure my face and stalked into the alley behind. The lock on the rear door was a trifle for my tools, and I entered without a sound.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I could either provide evidence to help ");
        using (styleScope("bold", true))
        {
            yield return text("expose");
        }
        yield return text(" ");
        yield return text("the secret inner workings of the building or I could ");
        using (styleScope("bold", true))
        {
            yield return text("conceal");
        }
        yield return text(" ");
        yield return text("the truth and allow the work to continue. ");
        using (styleScope("bold", true))
        {
            yield return text("The decision was clear to me:");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.playE = int.Parse(Vars.playE) + 1;
        using (styleScope("hook", "h00058"))
            yield return link("I exposed the truth.", null, () => enchantHook("h00058", HarloweEnchantCommand.Replace, passage118_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00059"))
            yield return link("I concealed the true purpose.", null, () => enchantHook("h00059", HarloweEnchantCommand.Replace, passage118_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage118_Fragment_0()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.pEA = "yes";
            Vars.exposeA = int.Parse(Vars.exposeA) + 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.pEB = "yes";
            Vars.exposeB = int.Parse(Vars.exposeB) + 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.pEC = "yes";
            Vars.exposeC = int.Parse(Vars.exposeC) + 1;
        }
        yield return abort(goToPassage: "ExposeConfirmation");
        yield break;
    }

    IStoryThread passage118_Fragment_1()
    {
        if (Vars.inv == Vars.ba)
        {
            Vars.exposeA = int.Parse(Vars.exposeA) - 1;
        }
        if (Vars.inv == Vars.bb)
        {
            Vars.exposeB = int.Parse(Vars.exposeB) - 1;
        }
        if (Vars.inv == Vars.bc)
        {
            Vars.exposeC = int.Parse(Vars.exposeC) - 1;
        }
        yield return abort(goToPassage: "ConcealConfirmation");
        yield break;
    }

// ###################################################################
// PASSAGE: MostInvestigated   (passage119)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 12885-13330
// Links:  DiseaseEnd
// Aborts: -
// Purpose: Tallies investigation counts; 4VP to the sole leader; continues to DiseaseEnd
// ###################################################################

    void passage119_Init()
    {
        this.Passages[@"MostInvestigated"] = new StoryPassage(@"MostInvestigated", new string[] { }, passage119_Main);
    }

    IStoryThread passage119_Main()
    {
        List<int> play = new List<int>(new int[] { Vars.playA, Vars.playB, Vars.playC, Vars.playD, Vars.playE });
        int numberOfMax = play.Where(value => value == play.Max()).Count();
        Debug.Log("numberOfMax of max value " + numberOfMax);
        //if (Vars.players == 5 ? Vars.nameA == Vars.playB || Vars.nameA == Vars.playC || Vars.nameA == Vars.playD || Vars.nameA == Vars.playE ||
        //    Vars.nameB == Vars.playC || Vars.nameB == Vars.playD || Vars.nameB == Vars.playE || Vars.nameC == Vars.playD || Vars.nameC == Vars.playE || Vars.playD == Vars.playE :
        //    Vars.players == 4 ? Vars.playA == Vars.playB || Vars.playA == Vars.playC || Vars.playA == Vars.playD || Vars.playB == Vars.playC || Vars.playB == Vars.playD || Vars.playC == Vars.playD :
        //    Vars.players == 3 ? Vars.playA == Vars.playB || Vars.playA == Vars.playC || Vars.playB == Vars.playC : Vars.playA == Vars.playB)
        //{
        //    Vars.most = 0;
        //}
        if (numberOfMax > 1)
        {
            Vars.most = 0;
        }
        else
        {
            if (Vars.playA > Mathf.Max(Vars.playB, Vars.playC, Vars.playD, Vars.playE))
            {
                Vars.most = Vars.nameA;
            }
            else if (Vars.playB > Mathf.Max(Vars.playC, Vars.playD, Vars.playE))
            {
                Vars.most = Vars.nameB;
            }
            else if (Vars.playC > Mathf.Max(Vars.playD, Vars.playE))
            {
                Vars.most = Vars.nameC;
            }
            else if (Vars.playD > Mathf.Max(Vars.playE))
            {
                Vars.most = Vars.nameD;
            }
            else
            {
                Vars.most = Vars.nameE;
            }
        }
        //if (Vars.most == null || String.IsNullOrEmpty(Vars.most))
        //{
        //    Vars.most = Vars.nameA;
        //}
        if (Vars.hunters == "evil")
        {
            if (Vars.goodcount < 2)
            {
                Vars.society = "Fraternity of Hunters";
            }
            else
            {
                Vars.society = "Order of St. Hubertus";
            }
        }
        if (Vars.hunters == "good")
        {
            if (Vars.goodcount > 1)
            {
                Vars.society = "Fraternity of Hunters";
            }
            else
            {
                Vars.society = "Order of St. Hubertus";
            }
        }
        if (Vars.most == 0 || Vars.most == "" || String.IsNullOrEmpty(Vars.most))
        {
            yield return abort(goToPassage: "DiseaseEnd");
        }
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Most Investigations");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text(Vars.most);
            yield return text(" ");
            yield return text("performed the most investigative actions. This did not go unnoticed by the ");
            yield return text(Vars.society);
            yield return text(", and despite their allegiances, they felt this exploratory spirit worthy of rewa" +
            "rd.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text(Vars.most);
                yield return text(" ");
                yield return text("immediately gains 4VP.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to continue...", "DiseaseEnd", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage119_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Prosperity1", "WolvesEco-Friendly");
        yield break;
    }

    IStoryThread passage119_Fragment_1()
    {
        PassageTracker.instance.CheckProgress("Prosperity1", "CharityAwardGood");
        yield break;
    }

// ###################################################################
// PASSAGE: RefusalReveal   (passage183)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21466-21631
// Links:  -
// Aborts: -
// Purpose: Secret stable-hand briefing: which faction is Wolves vs Hunters; lets the player join
// ###################################################################

    void passage183_Init()
    {
        this.Passages[@"RefusalReveal"] = new StoryPassage(@"RefusalReveal", new string[] { }, passage183_Main);
    }

    IStoryThread passage183_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the Storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage183_Fragment_4);
        using (styleScope("hook", "h000183"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000183", HarloweEnchantCommand.Replace, passage183_Fragment_3));
        yield break;
    }

    IStoryThread passage183_Fragment_0()
    {
        yield return abort(goToPassage: "WolfJoin");
        yield break;
    }

    IStoryThread passage183_Fragment_1()
    {
        yield return abort(goToPassage: "HunterJoin");
        yield break;
    }

    IStoryThread passage183_Fragment_2()
    {
        if (Vars.round == 5)
        {
            yield return abort(goToPassage: "Devastation2");
        }
        //if (Vars.round == 6)
        else
        {
            yield return abort(goToPassage: "Devastation3");
        }
        yield break;
    }

    IStoryThread passage183_Fragment_3()
    {
        yield return text("\"You do well to proceed with caution,\" The stable hand stated. \"The situation, as" +
            " I understand it, is simple. The Order of St. Hubertus is ");
        yield return text(Vars.wolves);
        yield return text(". Fraternity of Hunters is ");
        yield return text(Vars.hunters);
        yield return text(". It doesn\'t get much simpler than that, to me at least.\"");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.wolves == "good")
        {
            yield return text("\"The Order wants the village to become a haven for outcasts. They\'re set to ");
            using (styleScope("bold", true))
            {
                yield return text("expose");
            }
            yield return text(" the evils in the region and if they do, you can be sure they\'ll build a Universit" +
            "y with ");
            using (styleScope("bold", true))
            {
                yield return text("skilled workers");
            }
            yield return text(".");
            //yield return lineBreak();
        }
        //if (Vars.wolves == "evil")
        else
        {
            yield return text("\"The Order - not sure what they really want per se. Something about unleashing a " +
            "horrible vengeance on mankind. It isn\'t very specific. They want to keep their w" +
            "ork ");
            using (styleScope("bold", true))
            {
                yield return text("concealed");
            }
            yield return text(" and are even now setting up a way to perform their ");
            using (styleScope("bold", true))
            {
                yield return text("Experiments");
            }
            yield return text(".");
            //yield return lineBreak();
        }
        if (Vars.hunters == "good")
        {
            yield return text("\" The Fraternity; the usual good guy routine. ");
            using (styleScope("bold", true))
            {
                yield return text("Expose");
            }
            yield return text(" injustice in the village today and hunt down the demons that roam the countryside" +
            ". If you want to ");
            using (styleScope("bold", true))
            {
                yield return text("regain your sanity");
            }
            yield return text(" in this messed up world, they\'ll be the ones to aid.");
            //yield return lineBreak();
        }
        //if (Vars.hunters == "evil")
        else
        {
            yield return text("\" ");
            using (styleScope("bold", true))
            {
                yield return text("Money");
            }
            yield return text(", power, influence. If the Fraternity can use these dark secrets to their advanta" +
            "ge, they will. They want to ");
            using (styleScope("bold", true))
            {
                yield return text("conceal");
            }
            yield return text(" their work in the village. They prey on the weak-willed and gullible.");
        }
        yield return text(" ");
        yield return text("He punctuated his final statement with a puff of acrid tobacco.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(Vars.meet);
        yield return text(" ");
        yield return text("was fascinated by the idea of not one, but two secret societies hiding in this ve" +
            "ry village. The stable hand, after an exchange of some coin, was even willing to" +
            " give instructions on how to contact the factions for membership. ");
        yield return text(Vars.meet);
        yield return text(" ");
        yield return text("was presented with a curious dilemma indeed.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("You may choose to:");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00161"))
            yield return link("Join the Order of St. Hubertus.", null, () => enchantHook("h00161", HarloweEnchantCommand.Replace, passage183_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00162"))
            yield return link("Join the Fraternity of Hunters.", null, () => enchantHook("h00162", HarloweEnchantCommand.Replace, passage183_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("OR");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00163"))
            yield return link("Leave and do Nothing.", null, () => enchantHook("h00163", HarloweEnchantCommand.Replace, passage183_Fragment_2));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage183_Fragment_4()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage183_Fragment_3);
        yield break;
    }

// ###################################################################
// PASSAGE: RefusalWolves   (passage184)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21636-21664
// Links:  -
// Aborts: -
// Purpose: Declining the Order of St. Hubertus letter; contact stays at the Stables
// ###################################################################

    void passage184_Init()
    {
        this.Passages[@"RefusalWolves"] = new StoryPassage(@"RefusalWolves", new string[] { }, passage184_Main);
    }

    IStoryThread passage184_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Exercising Caution");
        }
        yield return lineBreak();
        yield return text("There was no formal response to any letters expressing doubt. However, an individ" +
            "ual at the Stables who could observe the comings and goings of travelers would l" +
            "ater provide ways to contact them if the need arose.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00164"))
            yield return link("Click to continue...", null, () => enchantHook("h00164", HarloweEnchantCommand.Replace, passage184_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage184_Fragment_0()
    {
        Vars.refusaltoken = "yes";
        yield return abort(goToPassage: "Gen1Insanity-NoAction");
        yield break;
    }

// ###################################################################
// PASSAGE: RefusalHunters   (passage185)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21669-21697
// Links:  -
// Aborts: -
// Purpose: Declining the Fraternity of Hunters letter; contact stays at the Stables
// ###################################################################

    void passage185_Init()
    {
        this.Passages[@"RefusalHunters"] = new StoryPassage(@"RefusalHunters", new string[] { }, passage185_Main);
    }

    IStoryThread passage185_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Exercising Caution");
        }
        yield return lineBreak();
        yield return text("There was no formal response to any letters expressing doubt. However, an individ" +
            "ual at the Stables who could observe the comings and goings of travelers would l" +
            "ater provide ways to contact them if the need arose.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00165"))
            yield return link("Click to continue...", null, () => enchantHook("h00165", HarloweEnchantCommand.Replace, passage185_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage185_Fragment_0()
    {
        Vars.refusaltoken = "yes";
        yield return abort(goToPassage: "Gen1Insanity-NoAction");
        yield break;
    }

// ###################################################################
// PASSAGE: DiseaseEffect   (passage188)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 21853-21957
// Links:  DevastationFate1
// Aborts: -
// Purpose: End-of-generation Hereditary Disease resolution; hands off to DevastationFate1
// ###################################################################

    void passage188_Init()
    {
        this.Passages[@"DiseaseEffect"] = new StoryPassage(@"DiseaseEffect", new string[] { }, passage188_Main);
    }

    IStoryThread passage188_Main()
    {
        Vars.tempdisease = macros1.either(1, 2);
        using (styleScope("hook", null))
        {
            if (Vars.tempdisease == 1)
            {
                using (styleScope("bold", true))
                {
                    yield return text("A Continuing Malady");
                }
                yield return lineBreak();
                yield return text("It appeared that the effects of the disease had been inherited by the next Genera" +
            "tion. Without a cure, symptoms of this ailment began to surface at an early age " +
            "and would carry on through the remainder of their lives.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage188_Fragment_1);
                using (styleScope("hook", "h00018801"))
                    yield return link("Click to continue...", null, () => enchantHook("h00018801", HarloweEnchantCommand.Replace, passage188_Fragment_0));
            }
            //if (Vars.tempdisease == 2)
            else
            {
                using (styleScope("bold", true))
                {
                    yield return text("Not Passed Down");
                }
                yield return lineBreak();
                yield return text(@"Twenty years passed without incident. As they were known to state, the only true science was that which one could observe plainly to a most dizzying effect. Surely, there would have been signs of the disease resurfacing in the next generation by then if it were truly a hereditary disease.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Family curse? They dismissed it as simple superstition.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage188_Fragment_3);
                using (styleScope("hook", "h00018803"))
                    yield return link("Click to continue...", null, () => enchantHook("h00018803", HarloweEnchantCommand.Replace, passage188_Fragment_2));
            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage188_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "DevastationFate1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "MaladjustmentBack";
            yield return lineBreak();
            yield return text("Any player who did not complete or store their Hereditary Disease Experiment draw" +
                "s a ");
            using (styleScope("bold", true))
            {
                yield return text("Maladjustment");
            }
            yield return text(" card for the next Generation. Then, return that Experiment to the scenario box.");
        }
        //yield return link("Click to continue...", "DevastationFate1", null);
        yield break;
    }

    IStoryThread passage188_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage188_Fragment_0);
        yield break;
    }

    IStoryThread passage188_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "DevastationFate1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return text("All players who did not complete or store their ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" discard them to the scenario box.");
        }
        //yield return link("Click to continue...", "DevastationFate1", null);
        yield break;
    }

    IStoryThread passage188_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage188_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: HunterJoin   (passage209)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23647-23720
// Links:  -
// Aborts: -
// Purpose: The Hunters' messenger arrives to accept membership
// ###################################################################

    void passage209_Init()
    {
        this.Passages[@"HunterJoin"] = new StoryPassage(@"HunterJoin", new string[] { }, passage209_Main);
    }

    IStoryThread passage209_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Fraternity of Hunters");
        }
        yield return lineBreak();
        yield return text("A messenger arrives at sunset wearing a pendant around their neck with a golden b" +
            "ow and arrow insignia upon it. They wait expectantly for your correspondence.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00168"))
            yield return link("Pledge your service to the Fraternity of Hunters.", null, () => enchantHook("h00168", HarloweEnchantCommand.Replace, passage209_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00169"))
            yield return link("Decide to do nothing instead.", null, () => enchantHook("h00169", HarloweEnchantCommand.Replace, passage209_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage209_Fragment_0()
    {
        Vars.hcount = int.Parse(Vars.hcount) + 1;
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "hunters";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "hunters";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "hunters";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "hunters";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "hunters";
        }
        if (Vars.round == 5)
        {
            yield return abort(goToPassage: "Devastation2");
        }
        //if (Vars.round == 6)
        else
        {
            yield return abort(goToPassage: "Devastation3");
        }
        yield break;
    }

    IStoryThread passage209_Fragment_1()
    {
        if (Vars.round == 5)
        {
            yield return abort(goToPassage: "Devastation2");
        }
        //if (Vars.round == 6)
        else
        {
            yield return abort(goToPassage: "Devastation3");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: RefusalEvent   (passage210)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23725-23861
// Links:  -
// Aborts: -
// Purpose: Stables hub: identify yourself to the stable hand to learn about the factions
// ###################################################################

    void passage210_Init()
    {
        this.Passages[@"RefusalEvent"] = new StoryPassage(@"RefusalEvent", new string[] { }, passage210_Main);
    }

    IStoryThread passage210_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("An Illuminating Conversation");
        }
        yield return lineBreak();
        yield return text("As the black carriage approached, the young man paused in his duties and lit a small pipe. In these dark times, a stablehand knew more about the comings and goings of the townsfolk than most anyone in the region. A few conspiratorial words and he was generous with information.");
        Vars.devpage = 1;
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("I introduced myself as:");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00170"))
            yield return link(Vars.nameA, null, () => enchantHook("h00170", HarloweEnchantCommand.Replace, passage210_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00171"))
            yield return link(Vars.nameB, null, () => enchantHook("h00171", HarloweEnchantCommand.Replace, passage210_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00172"))
                yield return link(Vars.nameC, null, () => enchantHook("h00172", HarloweEnchantCommand.Replace, passage210_Fragment_2));
            yield return lineBreak();
        }
        yield return lineBreak();
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00173"))
                yield return link(Vars.nameD, null, () => enchantHook("h00173", HarloweEnchantCommand.Replace, passage210_Fragment_3));
            yield return lineBreak();
        }
        yield return lineBreak();
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00174"))
                yield return link(Vars.nameE, null, () => enchantHook("h00174", HarloweEnchantCommand.Replace, passage210_Fragment_4));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage210_Fragment_0()
    {
        yield return lineBreak();
        if (Vars.allyA == 0 || Vars.allyA == "" || String.IsNullOrEmpty(Vars.allyA))
        {
            Vars.meet = Vars.nameA;
            yield return abort(goToPassage: "RefusalReveal");
        }
        else
        {
            Vars.meet = Vars.nameA;
            yield return abort(goToPassage: "JoinedAlready");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage210_Fragment_1()
    {
        yield return lineBreak();
        if (Vars.allyB == 0 || Vars.allyB == "" || String.IsNullOrEmpty(Vars.allyB))
        {
            Vars.meet = Vars.nameB;
            yield return abort(goToPassage: "RefusalReveal");
        }
        else
        {
            Vars.meet = Vars.nameB;
            yield return abort(goToPassage: "JoinedAlready");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage210_Fragment_2()
    {
        yield return lineBreak();
        if (Vars.allyC == 0 || Vars.allyC == "" || String.IsNullOrEmpty(Vars.allyC))
        {
            Vars.meet = Vars.nameC;
            yield return abort(goToPassage: "RefusalReveal");
        }
        else
        {
            Vars.meet = Vars.nameC;
            yield return abort(goToPassage: "JoinedAlready");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage210_Fragment_3()
    {
        yield return lineBreak();
        if (Vars.allyD == 0 || Vars.allyD == "" || String.IsNullOrEmpty(Vars.allyD))
        {
            Vars.meet = Vars.nameD;
            yield return abort(goToPassage: "RefusalReveal");
        }
        else
        {
            Vars.meet = Vars.nameD;
            yield return abort(goToPassage: "JoinedAlready");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage210_Fragment_4()
    {
        yield return lineBreak();
        if (Vars.allyE == 0 || Vars.allyE == "" || String.IsNullOrEmpty(Vars.allyE))
        {
            Vars.meet = Vars.nameE;
            yield return abort(goToPassage: "RefusalReveal");
        }
        else
        {
            Vars.meet = Vars.nameE;
            yield return abort(goToPassage: "JoinedAlready");
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: JoinedAlready   (passage211)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 23866-23907
// Links:  -
// Aborts: -
// Purpose: Rebuff for a player who already joined a faction
// ###################################################################

    void passage211_Init()
    {
        this.Passages[@"JoinedAlready"] = new StoryPassage(@"JoinedAlready", new string[] { }, passage211_Main);
    }

    IStoryThread passage211_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Busy Day");
        }
        yield return lineBreak();
        if (String.IsNullOrEmpty(Vars.meet)) Vars.meet = Vars.nameA;
        yield return text("The man looked at ");
        yield return text(Vars.meet);
        yield return text(" ");
        yield return text("quizzically for a moment before shaking his head and returning to work. ");
        yield return text(Vars.meet);
        yield return text(" ");
        yield return text("had already joined a faction and continued on their way after the fog cleared fro" +
            "m their mind.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00175"))
            yield return link("Click here to continue...", null, () => enchantHook("h00175", HarloweEnchantCommand.None, passage211_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage211_Fragment_0()
    {
        if (Vars.round == 5)
        {
            yield return abort(goToPassage: "Devastation2");
        }
        //if (Vars.round == 6)
        else
        {
            yield return abort(goToPassage: "Devastation3");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: Diseases2   (passage225)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24761-24877
// Links:  Gen1Creepy-ConcealExpose
// Aborts: -
// Purpose: Penalty for lacking a completed Hereditary Disease Experiment
// ###################################################################

    void passage225_Init()
    {
        this.Passages[@"Diseases2"] = new StoryPassage(@"Diseases2", new string[] { }, passage225_Main);
    }

    IStoryThread passage225_Main()
    {
        if (Vars.Diseases2nextPsg == "" || Vars.Diseases2nextPsg == 0)
            Vars.Diseases2nextPsg = macros1.either(1, 2);
        Vars.disease2 = Vars.Diseases2nextPsg;
        Vars.devpage = 0;
        if (Vars.disease2 == 1)
        {
            using (styleScope("bold", true))
            {
                yield return text("A Cleansing");
            }
            yield return lineBreak();
            yield return text(@"When the symptoms grew too fierce, they locked themselves away inside one of the myriad rooms of their estate. This resulted in an unfortunate loss of productivity and an odiferous contamination. When chemicals would not suffice for cleansing, it was deemed necessary to burn the entire room and start again.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage225_Fragment_1);
            using (styleScope("hook", "h00022501"))
                yield return link("Click to continue...", null, () => enchantHook("h00022501", HarloweEnchantCommand.Replace, passage225_Fragment_0));
        }
        //if (Vars.disease2 == 2)
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Wasted Potential");
            }
            yield return lineBreak();
            yield return text("While the disease that plagued the scientists was manageable, the effects were st" +
            "ill tiresome. Time spent advancing what they considered \"true science\" was inste" +
            "ad squandered upon practical medical applications to assuage their own afflictio" +
            "ns.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage225_Fragment_3);
            using (styleScope("hook", "h00022503"))
                yield return link("Click to continue...", null, () => enchantHook("h00022503", HarloweEnchantCommand.Replace, passage225_Fragment_2));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage225_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = Vars.seedy == "yes" ? "Gen1Creepy-ConcealExpose" : "Devastation3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            yield return lineBreak();
            yield return text("All players that have not completed their ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" must ");
            using (styleScope("bold", true))
            {
                yield return text("discard an Estate Upgrade tile");
            }
            yield return text(" to the box or ");
            using (styleScope("bold", true))
            {
                yield return text("lose 3VP");
            }
            yield return text(".");
        }
        //yield return link("Click to continue...", "Gen1Creepy-ConcealExpose", null);
        yield break;
    }

    IStoryThread passage225_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage225_Fragment_0);
        yield break;
    }

    IStoryThread passage225_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = Vars.seedy == "yes" ? "Gen1Creepy-ConcealExpose" : "Devastation3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return text("All players that have not completed their ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" must ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2VP");
            }
            yield return text(".");
        }
        //yield return link("Click to continue...", "Gen1Creepy-ConcealExpose", null);
        yield break;
    }

    IStoryThread passage225_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage225_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: DiseaseEnd   (passage226)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24882-24956
// Links:  DiseaseEffect
// Aborts: -
// Purpose: End-of-generation Disease wrap-up; grants Stasis Chamber estate upgrades
// ###################################################################

    void passage226_Init()
    {
        this.Passages[@"DiseaseEnd"] = new StoryPassage(@"DiseaseEnd", new string[] { }, passage226_Main);
    }

    IStoryThread passage226_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Longevity and Clarity");
        }
        yield return lineBreak();
        yield return text(@"Notes from this time period detail potential blueprints for a special room; a sanguine coagulant encased in a glass bubble and fed with an electrical current. Although there are no further mentions of the device, peculiarities in historical accounts suggest that some in the next generation received advice and assistance from an unknown source.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click here to determine the fate of the town...", passage226_Fragment_1);
        using (styleScope("hook", "h000226"))
            yield return link("Click here to determine the fate of the town...", null, () => enchantHook("h000226", HarloweEnchantCommand.Replace, passage226_Fragment_0));
        yield break;
    }

    IStoryThread passage226_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "DiseaseEffect";
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
                yield return text("Stasis Chamber Estate Upgrade tiles");
            }
            yield return text(" ");
            yield return text("from the Scenario box. Any player with a completed, face-down, ");
            using (styleScope("bold", true))
            {
                yield return text("Hereditary Disease Experiment");
            }
            yield return text(" ");
            yield return text("has the option of building the Stasis Chamber in their Estate. Players with the H" +
                "ereditary Disease Experiment ");
            using (styleScope("bold", true))
            {
                yield return text("stored");
            }
            yield return text(" ");
            yield return text("cannot accept this bonus. ");
            using (styleScope("italic", true))
            {
                yield return text("You must still pay $ if you would like to build this tile in a new plot, or you c" +
                "an replace an existing Estate tile.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Then, discard any face-down Hereditary Disease cards to the scenario box, along w" +
                "ith any remaining Stasis Chamber Estate Upgrades.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click here to determine the fate of the town...", "DiseaseEffect", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage226_Fragment_1()
    {
        yield return enchant("Click here to determine the fate of the town...", HarloweEnchantCommand.Replace, passage226_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: WolfJoin   (passage227)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24961-25035
// Links:  -
// Aborts: -
// Purpose: The Order of St. Hubertus' messenger arrives to accept membership
// ###################################################################

    void passage227_Init()
    {
        this.Passages[@"WolfJoin"] = new StoryPassage(@"WolfJoin", new string[] { }, passage227_Main);
    }

    IStoryThread passage227_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Order of St. Hubertus");
        }
        yield return lineBreak();
        yield return text("A messenger in a gray cloak marked with the insignia of a wolf\'s head arrived at " +
            "the estate one evening. They smiled and the gleam of their white teeth shone in " +
            "the moonlight.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00180"))
            yield return link("Pledge your service to the Order of St. Hubertus.", null, () => enchantHook("h00180", HarloweEnchantCommand.Replace, passage227_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00181"))
            yield return link("Decide to do nothing instead.", null, () => enchantHook("h00181", HarloweEnchantCommand.Replace, passage227_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage227_Fragment_0()
    {
        Vars.wcount = int.Parse(Vars.wcount) + 1;
        if (Vars.meet == Vars.nameA)
        {
            Vars.allyA = "wolves";
        }
        if (Vars.meet == Vars.nameB)
        {
            Vars.allyB = "wolves";
        }
        if (Vars.meet == Vars.nameC)
        {
            Vars.allyC = "wolves";
        }
        if (Vars.meet == Vars.nameD)
        {
            Vars.allyD = "wolves";
        }
        if (Vars.meet == Vars.nameE)
        {
            Vars.allyE = "wolves";
        }
        if (Vars.round == 5)
        {
            yield return abort(goToPassage: "Devastation2");
        }
        //if (Vars.round == 6)
        else
        {
            yield return abort(goToPassage: "Devastation3");
        }
        yield break;
    }

    IStoryThread passage227_Fragment_1()
    {
        if (Vars.round == 5)
        {
            yield return abort(goToPassage: "Devastation2");
        }
        //if (Vars.round == 6)
        else
        {
            yield return abort(goToPassage: "Devastation3");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: HelpingEvil2   (passage356)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 25303-25355
// Links:  GloomyHunterIntro,GloomyWolvesIntro
// Aborts: -
// Purpose: End-of-Gen2 setup: Heart-token players build a Master's Study; routes into the Gloomy Gen3 intro
// ###################################################################

    void passage356_Init()
    {
        this.Passages[@"HelpingEvil2"] = new StoryPassage(@"HelpingEvil2", new string[] { "revised", }, passage356_Main);
    }

    IStoryThread passage356_Main()
    {
        ViewItemObtain.SetupPassagename = Vars.society == "Fraternity of Hunters" ? "GloomyHunterIntro" : "GloomyWolvesIntro";
        using (styleScope("bold", true))
        {
            //yield return text("SETUP");
        }
        Vars._SetupImage = "S1_EstateUpgradeBACK";
        //yield return text("_SetupImage");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("setupStyleEvnt", true))
        {
            yield return text("Then, starting with the player with the ");
            using (styleScope("bold", true))
            {
                yield return text("most Victory Points");
            }
            yield return text(" ");
            yield return text("and continuing in descending order of points, each player with a ");
            yield return text(Vars.society);
            yield return text(" ");
            yield return text("token chooses a ");
            using (styleScope("bold", true))
            {
                yield return text("Master\'s Study");
            }
            yield return text(" ");
            yield return text("to build on their Estate. No additional cost is paid for a new plot to place this" +
                " tile. ");
            using (styleScope("italic", true))
            {
                yield return text("(Ties are broken by the player that went later in turn order in the previous roun" +
                "d.) Return all unclaimed tiles to the box.");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
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

// ###################################################################
// PASSAGE: Gen1Creepy-ConcealExpose   (passage294)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 29814-30241
// Links:  Devastation3
// Aborts: -
// Purpose: Private society visit collecting on the Gen1 "seedy" pledge; conceal/expose + debt
// ###################################################################

    void passage294_Init()
    {
        this.Passages[@"Gen1Creepy-ConcealExpose"] = new StoryPassage(@"Gen1Creepy-ConcealExpose", new string[] { }, passage294_Main);
    }

    IStoryThread passage294_Main()
    {
        //if (Vars.seedy == "yes")
        //{
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this storybook device to ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage294_Fragment_1);
        using (styleScope("hook", "h000294"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000294", HarloweEnchantCommand.Replace, passage294_Fragment_0));
        //}
        //else
        //{
        //    yield return abort(goToPassage: "Devastation3");
        //}
        yield break;
    }

    IStoryThread passage294_Fragment_0()
    {
        using (styleScope("bold", true))
        {
            yield return text("Under Cover of Darkness");
        }
        yield return lineBreak();
        yield return text("On an unseasonably warm evening with a thick fog obscuring their arrival, an oper" +
            "ative from the ");
        if (Vars.wolves == "evil")
        {
            yield return text("Order of St. Hubertus");
        }
        if (Vars.hunters == "evil")
        {
            yield return text("Fraternity of Hunters");
        }
        yield return text(" ");
        yield return text("knocked upon the estate door. There, at the entranceway with no intent to venture" +
            " further, the man addressed ");
        yield return text(Vars.gen1creep);
        yield return text(" ");
        yield return text("II in an authoritative tone.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.wolves == "evil")
        {
            if (Vars.gen1creep == Vars.nameA)
            {
                if (Vars.allyA == "hunters" || Vars.allyA == 0 || Vars.allyA == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameB)
            {
                if (Vars.allyB == "hunters" || Vars.allyB == 0 || Vars.allyB == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you. The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameC)
            {
                if (Vars.allyC == "hunters" || Vars.allyC == 0 || Vars.allyC == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameD)
            {
                if (Vars.allyD == "hunters" || Vars.allyD == 0 || Vars.allyD == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameE)
            {
                if (Vars.allyE == "hunters" || Vars.allyE == 0 || Vars.allyE == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
        }
        if (Vars.hunters == "evil")
        {
            if (Vars.gen1creep == Vars.nameA)
            {
                if (Vars.allyA == "wolves" || Vars.allyA == 0 || Vars.allyA == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameB)
            {
                if (Vars.allyB == "wolves" || Vars.allyB == 0 || Vars.allyB == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameC)
            {
                if (Vars.allyC == "wolves" || Vars.allyC == 0 || Vars.allyC == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameD)
            {
                if (Vars.allyD == "wolves" || Vars.allyD == 0 || Vars.allyD == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
            if (Vars.gen1creep == Vars.nameE)
            {
                if (Vars.allyE == "wolves" || Vars.allyE == 0 || Vars.allyE == "")
                {
                    yield return passage("Gen1Creepy-EvilCollect");
                }
                else
                {
                    yield return text(@"""We have decided to forgive your family's debt to us due to your recent pledge of loyalty. I was sent to offer this word of salutation and reminder that we are pleased. Consider this canceled debt as our gift to you."" The man, with a ceremonial air, then lifted a piece of parchment before him and, with a quick slice, let the cleaved paper fall to the stone steps.");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("After ");
                    yield return text(Vars.gen1creep);
                    yield return text(" and the man exchanged their secret handshake, the meeting was over and the carria" +
            "ge was once again swallowed by the mists.");
                }
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.wolves == "evil")
        {
            if (Vars.gen1creep == Vars.nameA)
            {
                if (Vars.allyA == "hunters" || Vars.allyA == 0 || Vars.allyA == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else if (Vars.gen1creep == Vars.nameB)
            {
                if (Vars.allyB == "hunters" || Vars.allyB == 0 || Vars.allyB == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else if (Vars.gen1creep == Vars.nameC)
            {
                if (Vars.allyC == "hunters" || Vars.allyC == 0 || Vars.allyC == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else if (Vars.gen1creep == Vars.nameD)
            {
                if (Vars.allyD == "hunters" || Vars.allyD == 0 || Vars.allyD == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else //if (Vars.gen1creep == Vars.nameE)
            {
                if (Vars.allyE == "hunters" || Vars.allyE == 0 || Vars.allyE == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
        }
        else //if (Vars.hunters == "evil")
        {
            if (Vars.gen1creep == Vars.nameA)
            {
                if (Vars.allyA == "wolves" || Vars.allyA == 0 || Vars.allyA == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else if (Vars.gen1creep == Vars.nameB)
            {
                if (Vars.allyB == "wolves" || Vars.allyB == 0 || Vars.allyB == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else if (Vars.gen1creep == Vars.nameC)
            {
                if (Vars.allyC == "wolves" || Vars.allyC == 0 || Vars.allyC == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else if (Vars.gen1creep == Vars.nameD)
            {
                if (Vars.allyD == "wolves" || Vars.allyD == 0 || Vars.allyD == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
            else //if (Vars.gen1creep == Vars.nameE)
            {
                if (Vars.allyE == "wolves" || Vars.allyE == 0 || Vars.allyE == "")
                {
                    using (styleScope("hook", "h00029401"))
                        yield return link("Click to continue...", null, () => enchantHook("h00029401", HarloweEnchantCommand.Replace, passage294_Fragment_1));
                }
                else
                {
                    yield return link("Click to continue...", "Devastation3", null);
                }
            }
        }

        yield return lineBreak();
        yield break;
    }

    IStoryThread passage294_Fragment_1()
    {
        ViewItemObtain.SetupPassagename = "Devastation3";
        using (styleScope("setupStyleEvnt", true))
        {
            if (Vars.wolves == "evil")
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SPECIAL SETUP");
                }
                Vars._SetupImage = "DiscardEstateUpgrade_Icon";
                yield return lineBreak();
                yield return text("Discard a ");
                using (styleScope("bold", true))
                {
                    yield return text("completed Experiment (of B-Level or higher)");
                }
                yield return text(" OR ");
                using (styleScope("bold", true))
                {
                    yield return text("discard an Estate Upgrade Tile");
                }
                yield return text(" (not a Storage Shed).");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Also, ");
                using (styleScope("bold", true))
                {
                    yield return text("Lose 1VP.");
                }
            }
            else
            {
                using (styleScope("setupStyleEvnt", true))
                {
                    using (styleScope("bold", true))
                    {
                        //yield return text("SPECIAL SETUP");
                    }
                    Vars._SetupImage = "DiscardEstateUpgrade_Icon";
                    yield return lineBreak();
                    yield return text("Pay $2 to the supply OR ");
                    using (styleScope("bold", true))
                    {
                        yield return text("discard an Estate Upgrade Tile");
                    }
                    yield return text(" (not a Storage Shed).");
                    yield return lineBreak();
                    yield return lineBreak();
                    yield return text("Also, ");
                    using (styleScope("bold", true))
                    {
                        yield return text("Gain 1 ");
                        yield return text("<sprite=\"Insanity_Icon\" index=0>");
                    }
                    yield return text(".");
                }
            }
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Creepy-RefusalBuild   (passage295)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 30246-30445
// Links:  Devastation2
// Aborts: -
// Purpose: Gen1 refusal consequence: free Reading Room or Shrine Estate Upgrade
// ###################################################################

    void passage295_Init()
    {
        this.Passages[@"Gen1Creepy-RefusalBuild"] = new StoryPassage(@"Gen1Creepy-RefusalBuild", new string[] { }, passage295_Main);
    }

    IStoryThread passage295_Main()
    {
        //if (Vars.seedy == "no")
        //{
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this storybook device to ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("and do not allow any other players to see the screen.");
        }
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage295_Fragment_5);
        using (styleScope("hook", "h000295"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000295", HarloweEnchantCommand.Replace, passage295_Fragment_4));
        //}
        //else
        //{
        //    yield return abort(goToPassage: "Devastation2");
        //}
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage295_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "Devastation2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_EstateUpgradeBACK";
            yield return lineBreak();
            yield return text("You may choose to immediately retrieve and build the ");
            using (styleScope("bold", true))
            {
                yield return text("Reading Room");
            }
            yield return text(" Estate Upgrade at no cost. ");
            using (styleScope("italic", true))
            {
                yield return text("However, you must still pay any costs related to expanding into a new Estate plot" +
                ".");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The ");
            using (styleScope("bold", true))
            {
                yield return text("Reading Room");
            }
            yield return text(" acts the same as any other action space in your Estate: On your turn, you may pla" +
                "ce a Servant or Spouse on this tile to ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
            }
            yield return text(".");
        }
        //yield return link("Click to continue...", "Devastation2", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage295_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage295_Fragment_0);
        yield break;
    }

    IStoryThread passage295_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "Devastation2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_EstateUpgradeBACK";
            yield return lineBreak();
            yield return text("You may choose to immediately retrieve and build the ");
            using (styleScope("bold", true))
            {
                yield return text("Shrine");
            }
            yield return text(" Estate Upgrade at no cost. ");
            using (styleScope("italic", true))
            {
                yield return text("However, you must still pay any costs related to expanding into a new Estate plot" +
                ".");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The ");
            using (styleScope("bold", true))
            {
                yield return text("Shrine");
            }
            yield return text(" acts the same as any other action space in your Estate: On your turn, you may pla" +
                "ce a Servant or Spouse on this tile to ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(".");
        }
        yield return lineBreak();
        //yield return link("Click to continue...", "Devastation2", null);
        yield break;
    }

    IStoryThread passage295_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage295_Fragment_2);
        yield break;
    }

    IStoryThread passage295_Fragment_4()
    {
        if (Vars.wolves == "good")
        {
            using (styleScope("bold", true))
            {
                yield return text("Order of St. Hubertus");
            }
            yield return lineBreak();
            yield return text("Consumed by the immense scientific enterprise they have undertaken, the cousins r" +
            "arely allowed moments to indulge visitation. However, after they had ignored sev" +
            "eral missives from the Order, a group of individuals arrived at ");
            yield return text(Vars.gen1creep);
            yield return text("\'s estate with an un-sprung cart full of building materials.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It appeared that they were aware of their ");
            using (styleScope("bold", true))
            {
                yield return text("parent\'s refusal");
            }
            yield return text(" to accept a gift from the Fraternity of Hunters. So, regardless of ");
            yield return text(Vars.gen1creep);
            yield return text("\'s current allegiances, they had procured the necessary materials to construct a " +
            "gift and were set upon the task immediately. ");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage295_Fragment_1);
            using (styleScope("hook", "h00029501"))
                yield return link("Click to continue...", null, () => enchantHook("h00029501", HarloweEnchantCommand.Replace, passage295_Fragment_0));
        }
        //if (Vars.hunters == "good")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Fraternity of Hunters");
            }
            yield return lineBreak();
            yield return text("Consumed by the immense scientific enterprise they have undertaken, the cousins r" +
            "arely allowed moments to indulge visitation. However, after they had ignored sev" +
            "eral missives from the Fraternity, a group of individuals arrived at ");
            yield return text(Vars.gen1creep);
            yield return text("\'s estate with an un-sprung cart full of building materials.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It appeared that they were aware of their ");
            using (styleScope("bold", true))
            {
                yield return text("parent\'s refusal");
            }
            yield return text(" to assist the evil schemes of the Order of St. Hubertus. So, regardless of ");
            yield return text(Vars.gen1creep);
            yield return text("\'s current allegiances, they had procured the necessary materials to construct a " +
            "gift and were set upon the task immediately. ");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage295_Fragment_3);
            using (styleScope("hook", "h00029503"))
                yield return link("Click to continue...", null, () => enchantHook("h00029503", HarloweEnchantCommand.Replace, passage295_Fragment_2));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage295_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage295_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Insanity-Yes   (passage302)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31272-31356
// Links:  Devastation1
// Aborts: -
// Purpose: "Absent Parent" penalty from the Gen1 summer home: Maladjustment card and -3VP
// ###################################################################

    void passage302_Init()
    {
        this.Passages[@"Gen1Insanity-Yes"] = new StoryPassage(@"Gen1Insanity-Yes", new string[] { }, passage302_Main);
    }

    IStoryThread passage302_Main()
    {
        Vars.letterSetRandomize = 1;
        if (Vars.vacation == "yes")
        {
            using (styleScope("bold", true))
            {
                yield return text("Absent Parent");
            }
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Carefully hand this storybook device to ");
                yield return text(Vars.gen1sane);
                yield return text(".");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("An investment in a summer home meant time away from the estate, and these increas" +
            "ingly frequent visits to rekindle sanity meant ");
            yield return text(Vars.gen1sane);
            yield return text(" ");
            yield return text("II\'s childhood guidance came more from the servants around the home than from the" +
            "ir parental figures. This left an unfortunate void in their psychological develo" +
            "pment, one that affected their actions for the remainder of their life.");
            if (Vars.Gen1Insanity_YesnextPsg == "" || Vars.Gen1Insanity_YesnextPsg == 0)
            {
                Vars.Gen1Insanity_YesnextPsg = macros1.either(1, 2);
            }
            Vars.instemp = Vars.Gen1Insanity_YesnextPsg;
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click here to continue...", passage302_Fragment_1);
            using (styleScope("hook", "h000302"))
                yield return link("Click to continue...", null, () => enchantHook("h000302", HarloweEnchantCommand.Replace, passage302_Fragment_0));
        }
        else
        {
            yield return abort(goToPassage: "Devastation1");
        }
        yield break;
    }

    IStoryThread passage302_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Devastation1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            if (Vars.instemp == 1)
            {
                Vars._SetupImage = "MaladjustmentBack";
                yield return lineBreak();
                yield return text("Gain a Maladjustment card and place it into play immediately for this Generation." +
                "");
            }
            //if (Vars.instemp == 2)
            else
            {
                Vars._SetupImage = "ScoreTrackMarker";
                yield return lineBreak();
                yield return text("Lose 3VP.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click here to continue...", "Devastation1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage302_Fragment_1()
    {
        yield return enchant("Click here to continue...", HarloweEnchantCommand.Replace, passage302_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Insanity-NoAction   (passage305)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31575-31656
// Links:  Devastation1
// Aborts: -
// Purpose: Gen1 refusal reward: retake your piece, take another turn, gain 1VP
// ###################################################################

    void passage305_Init()
    {
        this.Passages[@"Gen1Insanity-NoAction"] = new StoryPassage(@"Gen1Insanity-NoAction", new string[] { }, passage305_Main);
    }

    IStoryThread passage305_Main()
    {
        if (Vars.meet == Vars.gen1sane)
        {
            //yield return lineBreak();
            if (Vars.vacation == "no")
            {
                using (styleScope("bold", true))
                {
                    yield return text("More Time Than Ever");
                }
                yield return lineBreak();
                yield return text(Vars.gen1sane);
                yield return text(" ");
                yield return text("II\'s parent had instilled in them a strict work ethic. Their refusal to purchase " +
            "a summer home at their colleague\'s insistence, while stressful, had allowed them" +
            " time to engender this familial connection.");
                yield return lineBreak();
                yield return lineBreak();
                yield return text("And so this matter of written refusal was handled with the utmost brevity, allowi" +
            "ng them to focus on the monumental task at hand.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage305_Fragment_1);
                using (styleScope("hook", "h000305"))
                    yield return link("Click to continue...", null, () => enchantHook("h000305", HarloweEnchantCommand.Replace, passage305_Fragment_0));
            }
            else
            {
                yield return abort(goToPassage: "Devastation1");
            }
            yield return lineBreak();
        }
        else
        {
            yield return abort(goToPassage: "Devastation1");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage305_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Devastation1";
        Vars.vacation = "complete";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "WhenYouPlaceThisPiece";
            yield return lineBreak();
            yield return text("Return the piece you placed on this location to your Quarters. You may immediatel" +
                "y take another turn.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Also, ");
            using (styleScope("bold", true))
            {
                yield return text("gain 1VP");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Devastation1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage305_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage305_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: FailedMeeting   (passage313)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32180-32238
// Links:  Devastation1
// Aborts: -
// Purpose: Failed secret meeting: the character raves publicly and gains 1 resource
// ###################################################################

    void passage313_Init()
    {
        this.Passages[@"FailedMeeting"] = new StoryPassage(@"FailedMeeting", new string[] { }, passage313_Main);
    }

    IStoryThread passage313_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Failed Meeting");
        }
        yield return lineBreak();
        yield return text(@"The family's eccentricities were well known in the local area, but generally these were for reasons that at least appeared to have a sinister logic behind them. However, during this time, one of the family members was seen around town (for a period of several weeks) wearing a thinly veiled disguise about them and saying the phrase, ");
        yield return text(Vars.password);
        yield return text(", in a conspiratorial tone to anyone who should pass by.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Their presence was more harshly scrutinized by the local residents after this bou" +
            "t of what could only be deemed mental instability.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage313_Fragment_1);
        using (styleScope("hook", "h000313"))
            yield return link("Click to continue...", null, () => enchantHook("h000313", HarloweEnchantCommand.Replace, passage313_Fragment_0));
        yield break;
    }

    IStoryThread passage313_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Devastation1";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("You gain 1 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
                yield return text(".");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Devastation1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage313_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage313_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Creepy-EvilCollect   (passage314)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 32243-32326
// Links:  -
// Aborts: -
// Purpose: Shared fragment: society operative offers a choice of debt repayment
// ###################################################################

    void passage314_Init()
    {
        this.Passages[@"Gen1Creepy-EvilCollect"] = new StoryPassage(@"Gen1Creepy-EvilCollect", new string[] { }, passage314_Main);
    }

    IStoryThread passage314_Main()
    {
        if (Vars.wolves == "evil")
        {
            yield return text(@"The man peered out from under his cloth hood, his eyes glowing with unnatural light. ""We are displeased with your decision to forgo aligning yourself with our numbers. Fortunately for yourself, we will assume this is merely ignorance on your part and kindly ask for immediate remuneration,"" the man stated while several other cloaked individuals emerged from their carriage, small blades visibly clutched between their fingers.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The gentlemen were kind enough to offer ");
            yield return text(Vars.gen1creep);
            yield return text(" II a choice of debt repayment.");
            yield return lineBreak();
            yield return lineBreak();
            //using (styleScope("setupStyle", true))
            //{
            //    using (styleScope("bold", true))
            //    {
            //        //yield return text("SPECIAL SETUP");
            //    }
            //    Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            //    yield return lineBreak();
            //    yield return text("Discard a ");
            //    using (styleScope("bold", true))
            //    {
            //        yield return text("completed Experiment (of B-Level or higher)");
            //    }
            //    yield return text(" OR ");
            //    using (styleScope("bold", true))
            //    {
            //        yield return text("discard an Estate Upgrade Tile");
            //    }
            //    yield return text(" (not a Storage Shed).");
            //    yield return lineBreak();
            //    yield return lineBreak();
            //    yield return text("Also, ");
            //    using (styleScope("bold", true))
            //    {
            //        yield return text("Lose 1 VP.");
            //    }
            //}
        }
        //if (Vars.hunters == "evil")
        else
        {
            yield return text(@"""We are displeased with your decision to forgo aligning yourself with our numbers. Fortunately for yourself, we will assume this is merely ignorance on your part and kindly ask for immediate remuneration,"" the man stated while several other burly individuals emerged from their carriage, tapping various gleaming bludgeoning instruments against their palms.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The gentlemen were kind enough to offer ");
            yield return text(Vars.gen1creep);
            yield return text(" II a choice of debt repayment.");
            yield return lineBreak();
            yield return lineBreak();
            //using (styleScope("setupStyle", true))
            //{
            //    using (styleScope("bold", true))
            //    {
            //        //yield return text("SPECIAL SETUP");
            //    }
            //    Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            //    yield return lineBreak();
            //    yield return text("Pay $2 to the supply OR ");
            //    using (styleScope("bold", true))
            //    {
            //        yield return text("discard an Estate Upgrade Tile");
            //    }
            //    yield return text(" (not a Storage Shed).");
            //    yield return lineBreak();
            //    yield return lineBreak();
            //    yield return text("Also, ");
            //    using (styleScope("bold", true))
            //    {
            //        yield return text("Gain 1 ");
            //        yield return text("<sprite=\"Insanity_Icon\" index=0>");
            //    }
            //    yield return text(".");
            //}
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HubertusConfirmation   (passage342)
// Tags: NEW
// Source: TheCostofDiseaseEng.cs lines 34237-34293
// Links:  Gen1Insanity-NoAction
// Aborts: -
// Purpose: Private Order of St. Hubertus letter confirming conceal-or-expose pledge
// ###################################################################

    void passage342_Init()
    {
        this.Passages[@"HubertusConfirmation"] = new StoryPassage(@"HubertusConfirmation", new string[] { "NEW", }, passage342_Main);
    }

    IStoryThread passage342_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continue to not allow other players to see the screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.wolves == "good")
        {
            using (styleScope("bold", true))
            {
                yield return text("A Message of Confirmation");
            }
            yield return lineBreak();
            yield return text("Several weeks hence, ");
            yield return text(Vars.meet);
            yield return text(" received a small package with a rough, handwritten letter containing small bits o" +
            "f gray hairs stuck to the adhesive. It instructed them to keep their pledge to ");
            using (styleScope("bold", true))
            {
                yield return text("expose");
            }
            yield return text(" the suspicious activities to themselves. In the coming years, it would become cle" +
            "ar what was required of them.");
        }
        else //if (Vars.wolves == "evil")
        {
            using (styleScope("bold", true))
            {
                yield return text("A Message of Confirmation");
            }
            yield return lineBreak();
            yield return text("Several weeks hence, ");
            yield return text(Vars.meet);
            yield return text(" received a small package with a rough, handwritten letter containing small bits o" +
            "f gray hairs stuck to the adhesive. It instructed them to keep their pledge to ");
            using (styleScope("bold", true))
            {
                yield return text("conceal");
            }
            yield return text(" the suspicious activities to themselves. In the coming years, it would become cle" +
            "ar what was required of them.");
        }
        yield return lineBreak();
        Vars.wcount = int.Parse(Vars.wcount) + 1;
        yield return lineBreak();
        yield return link("Click to return...", "Gen1Insanity-NoAction", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HuntersConfirmation   (passage343)
// Tags: NEW
// Source: TheCostofDiseaseEng.cs lines 34299-34355
// Links:  Gen1Insanity-NoAction
// Aborts: -
// Purpose: Private Fraternity of Hunters missive confirming conceal-or-expose pledge
// ###################################################################

    void passage343_Init()
    {
        this.Passages[@"HuntersConfirmation"] = new StoryPassage(@"HuntersConfirmation", new string[] { "NEW", }, passage343_Main);
    }

    IStoryThread passage343_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Continue to not allow other players to see the screen.");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.hunters == "good")
        {
            using (styleScope("bold", true))
            {
                yield return text("A Message of Confirmation");
            }
            yield return lineBreak();
            yield return text("Several weeks hence, ");
            yield return text(Vars.meet);
            yield return text(" received a small missive with a watermark in the shape of a crossbow. It instruct" +
            "ed them to keep their pledge to ");
            using (styleScope("bold", true))
            {
                yield return text("expose");
            }
            yield return text(" the suspicious activities to themselves. In the coming years, it would become cle" +
            "ar what was required of them.");
        }
        else //if (Vars.hunters == "evil")
        {
            using (styleScope("bold", true))
            {
                yield return text("A Message of Confirmation");
            }
            yield return lineBreak();
            yield return text("Several weeks hence, ");
            yield return text(Vars.meet);
            yield return text(" received a small missive with a watermark in the shape of a crossbow. It instruct" +
            "ed them to keep their pledge to ");
            using (styleScope("bold", true))
            {
                yield return text("conceal");
            }
            yield return text(" the suspicious activities to themselves. In the coming years, it would become cle" +
            "ar what was required of them.");
        }
        yield return lineBreak();
        Vars.hcount = int.Parse(Vars.hcount) + 1;
        yield return lineBreak();
        yield return link("Click to return...", "Gen1Insanity-NoAction", null);
        yield return lineBreak();
        yield break;
    }
