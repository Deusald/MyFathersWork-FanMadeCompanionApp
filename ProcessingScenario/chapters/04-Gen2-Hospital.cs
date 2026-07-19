// ===================================================================
// CHAPTER: Gen2-Hospital   (50 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage3     Hospital1                    L1817-2083 [HUB]  Round-1 HUB "THRIVING IN ADVERSITY": Board of Trustees visit mandate, Cure/Panacea/35VP/Immortality triggers
// passage12    Hospitalintro                L2901-2965  Generation II prose intro for the prosperous "Thriving in Adversity" branch
// passage22    SymposiumFail                L3367-3414  Symposium failure; family barred from future lectures, returns to Hospital hub
// passage23    SymposiumSuccess             L3420-3464  Symposium success; academia won over, returns to Hospital hub
// passage24    S5HospA1Yes                  L3470-3507  End-of-Gen2 "Immortality Advances" transition into the University generation
// passage35    Hospital3                    L4590-5195 [HUB]  Round-3 HUB "THRIVING IN ADVERSITY - Late Years"
// passage34    Hospital2                    L4809-4994 [HUB]  Round-2 HUB "THRIVING IN ADVERSITY - Middle Years"
// passage56    Unicure                      L6878-6954  Yellow Fever Inoculation discovery; publish-vs-patent choice
// passage57    Panacea                      L6960-7050  "A Cure for All": which player completed the Panacea Experiment
// passage58    Panacea1                     L7055-7143  "A Weapon Published": VP + Creepy when the failed Panacea is published
// passage59    PanaceaTooOld                L7148-7211  "Too Old": the Panacea is wasted; player moves forward 1 space
// passage60    PanaceaUnleash               L7216-7302  1882 journal: the Panacea dissolves a servant, unleashing the deterioration agent
// passage61    SymposiumEvent3              L7307-7386  Symposium tally: total Experiments vs thresholds; branches fail/middle/success
// passage62    Unicure2                     L7392-7467  "Patented!" inoculation outcome: money, Suspicion marker left
// passage63    Unicure1                     L7472-7541  "Published!" inoculation outcome: VP, Suspicion marker 2 right
// passage85    HospitalDefine               L9479-9524  Hospital action-space rules popup incl. first-visit-with-Self caveat
// passage88    6Note                        L10029-10147  DEV NOTE: Symposium tiers, inoculation, Immortality token, university decision
// passage89    Immortality                  L10153-10221  "Overcoming Death": triggered at the third Journal Track level toward immortality
// passage95    InfinityClick2               L10539-10621  Infinity Journal reward: draw 2 Immortality cards, secretly keep one
// passage96    InfinityClick1               L10626-10721  "Research Completed": who finished the third Research Track level
// passage99    S5HospA1                     L10945-11014  LOGIC: compares `life` count vs player count; branches S5HospA1Yes/No
// passage100   S5HospA1No                   L11020-11071  "Death Becomes Us" ending: too few immortal, university abandoned
// passage122   Trigger35Points              L13743-13874  Private message to the first player reaching 35VP; rumor/sabotage penalty
// passage123   Trigger3Experiments          L13879-13969  Prompt: who completed 3 B/C Experiments, for a special reward
// passage124   ChooseScience                L13974-14060  Choose the Symposium science discipline that may determine the University; sets `sci3`
// passage125   SymposiumEvent1              L14065-14097  Budapest Symposium arrival flavor; leads to SymposiumEvent2
// passage130   HospitalVisitCheck           L14489-14709  Hospital tour flavor + prompt for which player is visiting
// passage131   HospitalVisitCheck2          L14714-14859  Private Nurse Varga report on the visiting doctor's unsettling behavior
// passage358   HospitalVisitReject          L14864-14926  "Kind Rejection" of a repeat hospital visit; gain 1 resource; return to the Hospital hub
// passage132   HospitalNegative             L14931-15062  "Lack of Hospitality": skipping Board duties costs 6VP + an Estate Upgrade
// passage160   EradicateDisease             L18567-18652  "The Cure": Yellow Fever Inoculation enters the common pool; routes to ChooseScience
// passage164   RippedMasterwork             L19075-19149  "Escaping The Curse": Masterwork schematics destroyed; Masterwork Experiments to the box
// passage165   S5HospA2                     L19154-19207  End-of-Hospital fate: University built vs not; branches UniversityIntro/RippedMasterwork
// passage167   PanaceaIntro                 L19264-19339  "Eradication Forever": Panacea Experiment enters the shared pool
// passage168   35VP                         L19344-19440  Last-place player chooses the penalty applied to whoever first reaches 35VP
// passage224   ImmortalitySetup             L24670-24756  "To Infinity" setup: Storybook token on level 3 of a chosen Journal track (ORPHANED)
// passage231   SymposiumMiddle              L25643-25723  Symposium critics' verdict; hinges on publishing the inoculation; decides the University
// passage235   NoHospitalCons               L25866-26024  Reward for solo labor when the Hospital was neglected: advance a Journal track
// passage236   S5HospA3                     L26029-26118  Generation-ending branch: RippedMasterwork (no university) or UniversityIntro
// passage241   YellowFeverCureSignin        L26630-26717  Asks which player completed the Yellow Fever Inoculation Experiment
// passage242   University                   L26722-26736  Town building tile reference: University (pay $1 to gain a Caretaker from Lost)
// passage249   3ExperimentsRes              L26905-27027  Reward for 3 Experiments: patrons grant a Master's Study vanity upgrade
// passage250   PanaceaMessage               L27032-27146  Secret screen: the Panacea's lethal side effects; publish or unleash
// passage251   ImmortalityMWUpdate          L27151-27219  Checks whether any player holds the Immortality Masterwork
// passage252   ImmortalityMWUpdate2         L27224-27304  Grants the Immortality Masterwork Update card
// passage255   SymposiumEvent2              L27427-27485  Symposium lectures scene: each cousin presents their gruesome work
// passage300   Gen1Creepy-RefuseBonus       L30890-31093  Hospital-branch strange visit: free Reading Room or Shrine for the parent's refusal
// passage301   Gen1Creepy-AgreedReturn      L31098-31267  Hospital-branch debt collection: discard an Experiment/Upgrade or pay $2
// passage303   Gen1Insanity-Yes2            L31361-31445  Same "Absent Parent" penalty, reached from the Hospital-branch 35VP check
// passage304   Gen1Insanity-NoExtraAction   L31450-31570  Gen1 refusal reward: return your Self to Quarters and take another action
// -------------------------------------------------------------------

// --- Round-end transitions (host: PassageTracker.CheckProgress) -----
//   Hospital1            --end of round-->  Immortality
//   Hospital3            --end of round-->  HospitalNegative
//   Hospital2            --end of round-->  SymposiumEvent1
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: Hospital1   (passage3)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 1817-2083
// Links:  HospitalVisitCheck,HospitalDefine,YellowFeverCureSignin,Panacea,Trigger3Experiments,Trigger35Points,Immortality
// Aborts: -
// Round end -> Immortality
// Purpose: Round-1 HUB "THRIVING IN ADVERSITY": Board of Trustees visit mandate, Cure/Panacea/35VP/Immortality triggers
// ###################################################################

    void passage3_Init()
    {
        this.Passages[@"Hospital1"] = new StoryPassage(@"Hospital1", new string[] { "HUB", }, passage3_Main);
    }

    IStoryThread passage3_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("THRIVING IN ADVERSITY - Early Years");
        }
        yield return lineBreak();
        Vars.round = 7;
        yield return lineBreak();
        if (Vars.twopage == 0 || Vars.twopage == "")
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
                yield return lineBreak();
                if (Vars.building == "bank")
                {
                    yield return text("Turn to page 4 of the Village Chronicle.");
                }
                //if (Vars.building == "library")
                else
                {
                    yield return text("Turn to page 5 of the Village Chronicle.");
                }
                yield return lineBreak();
                yield return text("Place the Suspicion marker on space ");
                using (styleScope("bold", true))
                {
                    if (Vars.players > 3 && (Vars.Hospital1 == 0 || Vars.Hospital1 == ""))
                    {
                        Vars.Hospital1 = 1;
                        Vars.tracker = int.Parse(Vars.tracker) - 1;
                    }
                    yield return text(Vars.tracker);
                }
                yield return text(" ");
                yield return text("and the ");
                yield return text("<sprite=\"AngryMob_Icon\" index=0>");
                yield return text(" ");
                yield return text("token ");
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
                yield return lineBreak();
                yield return lineBreak();
                yield return text("Then, place a ");
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" ");
                yield return text("token on ");
                using (styleScope("bold", true))
                {
                    yield return text("space 35");
                }
                yield return text(" ");
                yield return text("of the VP track. ");
                if (Vars.players == 3)
                {
                    yield return text("Then, since this is a 3 player game, pass the starting player marker clockwise 1 " +
                    "additional time.");
                }
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            using (styleScope("bold", true))
            {
                yield return text(" Board of Trustees");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text(@"Due to the efforts of your family, the Hospital has graciously awarded you with a seat on the Hospital's board of trustees. All players MUST personally visit the Hospital at least one time during this Generation by placing their Self on the Hospital space in town.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The ");
            using (styleScope("bold", true))
            {
                yield return text("first time");
            }
            yield return text(" ");
            yield return text("you visit the Hospital with your Self, ");
            yield return link("click here to confirm.", "HospitalVisitCheck", null);

            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("(If, for any reason, you have not visited the Hospital by the end of this Generat" +
                "ion, lose 6VP and an Estate Upgrade of your choice, if possible.)");
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("Hospital");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("For an explanation of the Hospital action space, ");
            yield return link("click here.", "HospitalDefine", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.cured == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Cure");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Whenever a player completes the ");
                using (styleScope("bold", true))
                {
                    yield return text("Yellow Fever Inoculation ");
                }
                yield return link("click here for a special message.", "YellowFeverCureSignin", null);
            }
        }
        if (Vars.cured == 1)
        {
            using (styleScope("hubTitle", true))
            {

                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Panacea");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Whenever a player completes the ");
                using (styleScope("bold", true))
                {
                    yield return text("Panacea");
                }
                yield return link("click here for a special message...", "Panacea", null);
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.sciadv == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Scientific Advances");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player completes a total of 3 B or C-Level ");
                yield return text(Vars.sci3);
                yield return text(" Experiments this Generation, ");
                yield return link("click here for a special reward.", "Trigger3Experiments", null);
            }
            yield return lineBreak();
            yield return lineBreak();
        }

        if (Vars.trigger35 == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Victory Ahead");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches or passes the Storybook token on space 35 of the Victory Poin" +
            "t Track, ");
                yield return link("click here for a special message", "Trigger35Points", null);
            }
            //yield return lineBreak();
            //yield return lineBreak();
        }
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("University Symposium");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of the second round, a Symposium in the field of ");
            yield return text(Vars.sci3);
            yield return text(" ");
            yield return text("will be held to determine the fate of a ");
            using (styleScope("bold", true))
            {
                yield return text("University");
            }
            yield return text(" ");
            yield return text("in town in the spot where the Traveling Caravan resides. Success will be determin" +
                "ed by our combined dedication to completing ");
            yield return text(Vars.sci3);
            yield return text(" ");
            yield return text("Experiments.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round to move to the next round...", "Immortality", null);
            using (styleScope("hook", "h0003"))
                yield return link("Click here at the end of the round to move to the next round...", null, () => enchantHook("h0003", HarloweEnchantCommand.Replace, passage3_Fragment_0));
        }
        yield return lineBreak();

        yield break;
    }

    IStoryThread passage3_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Hospital1", "Immortality");
        yield break;
    }

// ###################################################################
// PASSAGE: Hospitalintro   (passage12)
// Tags: INTRO
// Source: TheCostofDiseaseEng.cs lines 2901-2965
// Links:  EradicateDisease
// Aborts: -
// Purpose: Generation II prose intro for the prosperous "Thriving in Adversity" branch
// ###################################################################

    void passage12_Init()
    {
        this.Passages[@"Hospitalintro"] = new StoryPassage(@"Hospitalintro", new string[] { "INTRO", }, passage12_Main);
    }

    IStoryThread passage12_Main()
    {
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("GENERATION II:");
            yield return lineBreak();
            yield return text("Thriving in Adversity");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It is said that springtime under the watchful eye of the snow-tipped Carpathian mountains is a wondrous sight to behold. A single excursion in these rolling hills amongst the paths that split green grass is said to reinvigorate the lonely traveler. It is common to catch the aroma of sweet bread in the air, the sounds of babbling streams with moss-covered roots sipping the cool waters, and the richness of golden honey sunsets illuminating the countryside. If but for one season, a certain blitheness, a blissful simplicity of purpose alights the torch of poetry in the dark minds of men.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Therefore, perhaps it is most appropriate that the return of the scientists coincided with this season, as thanks to their predecessors' aid the town had become rejuvenated. The ashen grayness that once dominated the small town had been brightened, like the azalea flowers and crocus that now bloomed in window boxes along the streets.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The new hospital had become a site of great hope and strength for the people and the town was able to weather the disease even while the newspapers described the bleakness of the surrounding cities. Due to the work of their progenitors, honorary positions on the board of trustees at the hospital were awarded to their sons and daughters; positions which they sadly could not refuse. However, this controlled proximity to the ravages of disease also offered a boon for scientific inquiries and exploration.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"This serendipitous push forward in disease prevention attracted the attention of not only the diocese, but also the scientific community hoping to replicate their success. There were even rumors of a government-sponsored university; a prospect that caused great tension within the church and the townsfolk used to their isolated and bucolic existences.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The possibilities for advancement - and exploitation - seemed limitless. But, would their ingenious and unorthodox ambitions prove too unconventional for the cautious minds of academia? Or would the pressures of rejection from their peers break their indomitable spirit?");
        yield return lineBreak();
        if (Vars.building == "bank")
        {
            Vars.hos = 4;
        }
        //if (Vars.building == "library")
        else
        {
            Vars.hos = 5;
        }
        Vars.twopage = 0;
        Vars.life = 0;
        Vars.fevervp = macros1.either(4, 5, 6, 7);
        Vars.fevermoney = macros1.either(8, 9, 10, 11);
        Vars.gen3pg = 0;
        Vars.setinf = 0;
        Vars.pana = 0;
        Vars.hospA = 0;
        Vars.hospB = 0;
        Vars.hospC = 0;
        Vars.hospD = 0;
        Vars.hospE = 0;
        Vars.cured = 0;
        Vars.sciadv = 0;
        Vars.trigger35 = 0;
        Vars.lifeA = 0;
        Vars.lifeB = 0;
        Vars.lifeC = 0;
        Vars.lifeD = 0;
        Vars.lifeE = 0;
        Vars.life = 0;
        Vars.hospcount = 0;
        yield return lineBreak();
        yield return link("Click to continue...", "EradicateDisease", null);
        yield break;
    }

// ###################################################################
// PASSAGE: SymposiumFail   (passage22)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3367-3414
// Links:  PanaceaUnleash,Hospital3
// Aborts: -
// Purpose: Symposium failure; family barred from future lectures, returns to Hospital hub
// ###################################################################

    void passage22_Init()
    {
        this.Passages[@"SymposiumFail"] = new StoryPassage(@"SymposiumFail", new string[] { }, passage22_Main);
    }

    IStoryThread passage22_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Symposium Failure");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("\"Preposterous. A vaudevillian side-show.\" The scathing negative reviews were most" +
            " predominant. ");
        yield return text(macros1.either("Then, we were treated to a ghastly vivisection of a wailing goat while an electri" +
            "cal device stimulated the nervous reflexes. Had I known, I would have brought an" +
            " umbrella.", "Steam shot from the abominable contraption\'s eye sockets as the speaker mumbled a" +
            " rhythmic incantation that, if it had any effect at all, was to cause a ringing " +
            "in my ears for hours afterward."));
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A professional scolding soon followed from notable experts in the ");
        yield return text(Vars.sci3);
        yield return text(" ");
        yield return text("field. Accused of peddling contentious pseudo-science, the cousins were informed " +
            "that they would not be receiving any invitations for lecture opportunities in th" +
            "e future.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The family returned home, each writing scathing remarks within their respective j" +
            "ournals. They concluded that while they were no longer welcome at the University" +
            ", \"they were also never planning to return anyway.\"");
        yield return lineBreak();
        yield return lineBreak();
        Vars.uni = "no";
        Vars.final5 = 5;
        if (Vars.pana == "unleash")
        {
            yield return link("Click to continue...", "PanaceaUnleash", null);
        }
        else
        {
            yield return link("Click to continue...", "Hospital3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: SymposiumSuccess   (passage23)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 3420-3464
// Links:  PanaceaUnleash,Hospital3
// Aborts: -
// Purpose: Symposium success; academia won over, returns to Hospital hub
// ###################################################################

    void passage23_Init()
    {
        this.Passages[@"SymposiumSuccess"] = new StoryPassage(@"SymposiumSuccess", new string[] { }, passage23_Main);
    }

    IStoryThread passage23_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Symposium Success");
        }
        yield return lineBreak();
        yield return text("\"Eccentric, but certainly well-documented,\" the succinct, blood-stained note stat" +
            "ed. \"I expected the worst when Dr. ");
        yield return text(Vars.nameB);
        yield return text(" ");
        yield return text("II began their presentation by ");
        yield return text(macros1.either("strumming a popular tune on the vocal chords of an otter.", "winding up the gear mechanism of an automaton with sharpened blades for hands.", "creating a salt circle with a sack-doll at the center and then asking for a blood" +
            " sample from someone in the audience.", "exploding a vial of acid using another, stronger vial of acid to \'get our attenti" +
            "on\'."));
        yield return text(" ");
        yield return text("But, by the hour mark, the speech really hit its stride.\"");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A mixture of befuddled excitement and intrigue swept through the halls of academi" +
            "a. Yet, the professors all agreed that despite a lack of traditional form, it wa" +
            "s the inexorably excitable demeanor of the cousins that so enamored them.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The Symposium had been a rousing success. Finally their work was becoming noted!");
        yield return lineBreak();
        Vars.uni = "yes";
        Vars.final5 = 6;
        yield return lineBreak();
        if (Vars.pana == "unleash")
        {
            yield return link("Click to continue...", "PanaceaUnleash", null);
        }
        else
        {
            yield return link("Click to continue...", "Hospital3", null);
        }
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: S5HospA1Yes   (passage24)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 3470-3507
// Links:  UniversityIntro
// Aborts: -
// Purpose: End-of-Gen2 "Immortality Advances" transition into the University generation
// ###################################################################

    void passage24_Init()
    {
        this.Passages[@"S5HospA1Yes"] = new StoryPassage(@"S5HospA1Yes", new string[] { "END", }, passage24_Main);
    }

    IStoryThread passage24_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Immortality Advances");
        }
        //yield return text("Remove all player pieces from the board and perform the End of a Generation. Any " +
        //    "");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens remaining on a player\'s Journal Track are returned to the supply.");
        string s = "Remove all player pieces from the board and perform the End of a Generation. Any <sprite=\"StorybookToken\" index=0> tokens remaining on a player's Journal Track are returned to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 6);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The ");
        using (styleScope("bold", true))
        {
            yield return text(Vars.life);
        }
        yield return text(" ");
        yield return text("scientists reveled in the suspicious glances of the townsfolk whenever they strol" +
            "led through town, their visages spotless and unaging. Surely, the indefinite ext" +
            "ension of their lives was a true marvel.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"They remained in the village, tending their estates into advanced ages unheard of in this Victorian era, seemingly untouched by time. The additional scientific advances made possible by this remarkable vitality guided the town towards a more modern direction.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue to a more enlightened time...", "UniversityIntro", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Hospital3   (passage35)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 4590-5195
// Links:  HospitalVisitCheck,YellowFeverCureSignin,Panacea,Trigger35Points,Trigger3Experiments,InfinityClick1,HospitalNegative
// Aborts: -
// Round end -> HospitalNegative
// Purpose: Round-3 HUB "THRIVING IN ADVERSITY - Late Years"
// ###################################################################

    IStoryThread passage35_Fragment_3()
    {
        PassageTracker.instance.CheckProgress("Devastation3", "BuildingsEnd");
        yield break;
    }

    void passage35_Init()
    {
        this.Passages[@"Hospital3"] = new StoryPassage(@"Hospital3", new string[] { "HUB", }, passage35_Main);
    }

    IStoryThread passage35_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("THRIVING IN ADVERSITY - Late Years");
        }
        yield return lineBreak();
        Vars.round = 9;
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.uni == "yes")
        {
            if (Vars.twopage == 0)
            {
                using (styleScope("setupStyle", true))
                {
                    using (styleScope("bold", true))
                    {
                        //yield return text("SETUP");
                    }
                    Vars._SetupImage = "VillageChronicleCover";
                    yield return lineBreak();
                    if (Vars.building == "bank")
                    {
                        yield return text("Turn to page ");
                        using (styleScope("bold", true))
                        {
                            yield return text("6");
                        }
                        yield return text(" of the Village Chronicle.");
                    }
                    //if (Vars.building == "library")
                    else
                    {
                        yield return text("Turn to page ");
                        using (styleScope("bold", true))
                        {
                            yield return text("7");
                        }
                        yield return text(" of the Village Chronicle.");
                    }
                }
                yield return lineBreak();
                yield return lineBreak();
            }
        }
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("Board of Trustees");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("All players MUST place their Self on the Hospital space in town once this generat" +
            "ion. ");
            using (styleScope("italic", true))
            {
                yield return text("(If, for any reason, you have not visited the Hospital by the end of this Generat" +
                "ion, lose 6VP and an Estate Upgrade of your choice, if possible.)");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The <b>first time</b> you visit the Hospital with your Self, ");
            yield return link("click here to confirm.", "HospitalVisitCheck", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.cured == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Cure");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Whenever a player completes the ");
                using (styleScope("bold", true))
                {
                    yield return text("Yellow Fever Inoculation ");
                }
                yield return link("click here for a special message.", "YellowFeverCureSignin", null);
            }
        }
        if (Vars.cured == 1)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Panacea");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Whenever a player completes the ");
                using (styleScope("bold", true))
                {
                    yield return text("Panacea ");
                }
                yield return link("click here for a special message...", "Panacea", null);
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.trigger35 == 0)
        {
            using (styleScope("hubTitle", true))
            {

                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Victory Ahead");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches or passes the Storybook token on space 35 of the Victory Poin" +
            "t Track, ");
                yield return link("click here for a special message", "Trigger35Points", null);
            }
            yield return lineBreak();
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.sciadv == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Scientific Advances");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player completes a total of 3 B or C-Level ");
                yield return text(Vars.sci3);
                yield return text(" Experiments this Generation, ");
                yield return link("Click here for a special reward.", "Trigger3Experiments", null);

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
                yield return text("The Secret");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If any player reaches the third level of research on the Journal Track with their" +
            " Storybook token, ");
            yield return link("click here for a reward...", "InfinityClick1", null);
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the Generation to  continue...", "HospitalNegative", null);
            using (styleScope("hook", "h0000035"))
                yield return link("Click here at the end of the Generation to continue...", null, () => enchantHook("h0000035", HarloweEnchantCommand.Replace, passage35_Fragment_0));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage35_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Hospital3", "HospitalNegative");
        yield break;
    }

// ###################################################################
// PASSAGE: Hospital2   (passage34)
// Tags: HUB
// Source: TheCostofDiseaseEng.cs lines 4809-4994
// Links:  HospitalVisitCheck,YellowFeverCureSignin,Panacea,Trigger35Points,InfinityClick1,Trigger3Experiments,SymposiumEvent1
// Aborts: -
// Round end -> SymposiumEvent1
// Purpose: Round-2 HUB "THRIVING IN ADVERSITY - Middle Years"
// ###################################################################

    void passage34_Init()
    {
        this.Passages[@"Hospital2"] = new StoryPassage(@"Hospital2", new string[] { "HUB", }, passage34_Main);
    }

    IStoryThread passage34_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("THRIVING IN ADVERSITY - Middle Years");
        }
        yield return lineBreak();
        Vars.round = 8;
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            using (styleScope("bold", true))
            {
                yield return text(" Board of Trustees");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("All players MUST place their Self on the Hospital space in town once this generat" +
            "ion. ");
            using (styleScope("italic", true))
            {
                yield return text("(If, for any reason, you have not visited the Hospital by the end of this Generat" +
                "ion, lose 6VP and an Estate Upgrade of your choice, if possible.)");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The <b>first time</b> you visit the Hospital with your Self, ");
            yield return link("click here to confirm.", "HospitalVisitCheck", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.cured == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Cure");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Whenever a player completes the ");
                using (styleScope("bold", true))
                {
                    yield return text("Yellow Fever Inoculation ");
                }
                yield return link("click here for a special message.", "YellowFeverCureSignin", null);
            }
        }
        if (Vars.cured == 1)
        {
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" The Panacea");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("Whenever a player completes the ");
                using (styleScope("bold", true))
                {
                    yield return text("Panacea");
                }
                yield return link("click here for a special message...", "Panacea", null);
            }
        }
        if (Vars.trigger35 == 0)
        {
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Victory Ahead");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player reaches or passes the Storybook token on space 35 of the Victory Poin" +
            "t Track, ");
                yield return link("click here for a special message", "Trigger35Points", null);
            }
            yield return lineBreak();
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            using (styleScope("bold", true))
            {
                yield return text("The Secret to Immortality");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("If any player reaches the third level of research on the Journal Track with their" +
            " Storybook token, ");
            yield return link("click here for a reward.", "InfinityClick1", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.sciadv == 0)
        {
            using (styleScope("hubTitle", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                using (styleScope("bold", true))
                {
                    yield return text(" Scientific Advances");
                }
            }
            yield return lineBreak();
            using (styleScope("hubDetails", true))
            {
                yield return text("If a player completes a total of 3 B or C-Level ");
                yield return text(Vars.sci3);
                yield return text(" Experiments this Generation, ");
                yield return link("Click here for a special reward...", "Trigger3Experiments", null);
            }
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hubTitle", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("University Symposium");
            }
        }
        yield return lineBreak();
        using (styleScope("hubDetails", true))
        {
            yield return text("At the end of the second round, a Symposium in the field of ");
            yield return text(Vars.sci3);
            yield return text(" ");
            yield return text("will be held to determine the fate of a ");
            using (styleScope("bold", true))
            {
                yield return text("University");
            }
            yield return text(" ");
            yield return text("in town in the spot where the Traveling Caravan resides. Success will be determin" +
                "ed by our combined dedication to completing ");
            yield return text(Vars.sci3);
            yield return text(" ");
            yield return text("Experiments.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return link("Click here at the end of the round to attend the " + Vars.sci3 + " " + "Symposium.", "SymposiumEvent1", null);
            using (styleScope("hook", "h000034"))
                yield return link("Click here at the end of the round to attend the " + Vars.sci3 + " " + "Symposium.", null, () => enchantHook("h000034", HarloweEnchantCommand.Replace, passage34_Fragment_0));

        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage34_Fragment_0()
    {
        PassageTracker.instance.CheckProgress("Hospital2", "SymposiumEvent1");
        yield break;
    }

// ###################################################################
// PASSAGE: Unicure   (passage56)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6878-6954
// Links:  Unicure1,Unicure2
// Aborts: -
// Purpose: Yellow Fever Inoculation discovery; publish-vs-patent choice
// ###################################################################

    void passage56_Init()
    {
        this.Passages[@"Unicure"] = new StoryPassage(@"Unicure", new string[] { }, passage56_Main);
    }

    IStoryThread passage56_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to ");
            yield return text(Vars.fevercure);
            yield return text(". This choice is read and made within view all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Local Scientist Discovers Inoculation for Yellow Fever");
        }
        yield return lineBreak();
        yield return text(@"The local headlines were inevitable. While history may ascribe a later date to this monumental event due to the volatile nature of simply injecting oneself with the viscous black and yellow vomit of an infected individual, it was an unsettling leap forward in our understanding of antibodies and herd immunity.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The scientific establishment");
        if (Vars.uni == "no")
        {
            yield return text(", although pensive about my recent lecture, ");
        }
        //yield return text(" ");
        yield return text("was thrilled by the discovery of a cure for the pervasive disease. Dr. ");
        yield return text(Vars.fevercure);
        yield return text(" ");
        yield return text(@"Jr. was urged to release their curious methodology in a series of published journal entries to offer peer review and additional critique. However, they were reticent to immediately share findings before obtaining a patent. This knowledge could provide a lucrative financial outlet.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Make a Choice to Publish or Patent");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("To ");
        using (styleScope("bold", true))
        {
            yield return text("publish");
        }
        yield return text(" ");
        yield return text("the cure in a medical journal and ");
        using (styleScope("bold", true))
        {
            yield return text("gain ");
            yield return text(Vars.fevervp);
            //yield return text(" ");
            yield return text("VP");
        }
        yield return text(", ");
        yield return link("Click here", "Unicure1", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("To ");
        using (styleScope("bold", true))
        {
            yield return text("patent");
        }
        yield return text(" ");
        yield return text("the cure and sell the process to world governments and ");
        using (styleScope("bold", true))
        {
            yield return text("gain $");
            yield return text(Vars.fevermoney);
        }
        yield return text(", ");
        yield return link("Click here.", "Unicure2", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Panacea   (passage57)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 6960-7050
// Links:  -
// Aborts: -
// Purpose: "A Cure for All": which player completed the Panacea Experiment
// ###################################################################

    void passage57_Init()
    {
        this.Passages[@"Panacea"] = new StoryPassage(@"Panacea", new string[] { }, passage57_Main);
    }

    IStoryThread passage57_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Cure for All");
        }
        yield return lineBreak();
        yield return text("It seemed that finally, after years of tireless dedication, a solution to the ail" +
            "s of all men had been formulated. The family was divided on the efficacy of this" +
            " course of action, but one individual forged ahead recklessly, headless to their" +
            " warnings.");
        yield return lineBreak();
        Vars.twopage = 1;
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Which individual completed the Panacea Experiment?");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00021"))
            yield return link("Dr. " + Vars.nameA + " Jr.", null, () => enchantHook("h00021", HarloweEnchantCommand.Replace, passage57_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00022"))
            yield return link("Dr. " + Vars.nameB + " Jr.", null, () => enchantHook("h00022", HarloweEnchantCommand.Replace, passage57_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00023"))
                yield return link("Dr. " + Vars.nameC + " Jr.", null, () => enchantHook("h00023", HarloweEnchantCommand.Replace, passage57_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00024"))
                yield return link("Dr. " + Vars.nameD + " Jr.", null, () => enchantHook("h00024", HarloweEnchantCommand.Replace, passage57_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00025"))
                yield return link("Dr. " + Vars.nameE + " Jr.", null, () => enchantHook("h00025", HarloweEnchantCommand.Replace, passage57_Fragment_4));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage57_Fragment_0()
    {
        Vars.panacure = Vars.nameA;
        yield return abort(goToPassage: "PanaceaMessage");
        yield break;
    }

    IStoryThread passage57_Fragment_1()
    {
        Vars.panacure = Vars.nameB;
        yield return abort(goToPassage: "PanaceaMessage");
        yield break;
    }

    IStoryThread passage57_Fragment_2()
    {
        Vars.panacure = Vars.nameC;
        yield return abort(goToPassage: "PanaceaMessage");
        yield break;
    }

    IStoryThread passage57_Fragment_3()
    {
        Vars.panacure = Vars.nameD;
        yield return abort(goToPassage: "PanaceaMessage");
        yield break;
    }

    IStoryThread passage57_Fragment_4()
    {
        Vars.panacure = Vars.nameE;
        yield return abort(goToPassage: "PanaceaMessage");
        yield break;
    }

// ###################################################################
// PASSAGE: Panacea1   (passage58)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7055-7143
// Links:  Hospital1,Hospital2,Hospital3
// Aborts: -
// Purpose: "A Weapon Published": VP + Creepy when the failed Panacea is published
// ###################################################################

    void passage58_Init()
    {
        this.Passages[@"Panacea1"] = new StoryPassage(@"Panacea1", new string[] { }, passage58_Main);
    }

    IStoryThread passage58_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Weapon Published");
        }
        yield return lineBreak();
        yield return text("In a shocking display of altruism, the findings were published in a series of med" +
            "ical journals at the behest of the university\'s administration. The published wo" +
            "rk was controversial, but considered revolutionary, as the strength of the faile" +
            "d ");
        using (styleScope("bold", true))
        {
            yield return text("Panacea");
        }
        yield return text(" ");
        yield return text("had several alternative applications.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The local population, while grateful for the additional tourism, were less than c" +
            "onsoled. As much as it was innovative, it was also a secretly manufactured chemi" +
            "cal so devastating that all organic matter deteriorated within minutes of it\'s a" +
            "pplication.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage58_Fragment_1);
        using (styleScope("hook", "h000058"))
            yield return link("Click to continue...", null, () => enchantHook("h000058", HarloweEnchantCommand.Replace, passage58_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage58_Fragment_0()
    {
        yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 7 ? "Hospital1" : Vars.round == 8 ? "Hospital2" : "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "S1_Pancea";
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Gain ");
                yield return text(macros1.either(2, 3, 4));
                //yield return text(" ");
                yield return text("VP.");
            }
            yield return text(" ");
            yield return text("Also, Gain ");
            using (styleScope("bold", true))
            {
                yield return text("1");
            }
            yield return text(" ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 7)
        //{
        //    yield return link("Click to continue...", "Hospital1", null);
        //}
        //if (Vars.round == 8)
        //{
        //    yield return link("Click to continue...", "Hospital2", null);
        //}
        //if (Vars.round == 9)
        //{
        //    yield return link("Click to continue...", "Hospital3", null);
        //}
        yield break;
    }

    IStoryThread passage58_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage58_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: PanaceaTooOld   (passage59)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7148-7211
// Links:  Hospital3
// Aborts: -
// Purpose: "Too Old": the Panacea is wasted; player moves forward 1 space
// ###################################################################

    void passage59_Init()
    {
        this.Passages[@"PanaceaTooOld"] = new StoryPassage(@"PanaceaTooOld", new string[] { }, passage59_Main);
    }

    IStoryThread passage59_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Too Old");
        }
        yield return lineBreak();
        yield return text("With only a few years left in their existence, and hence the existence of their f" +
            "amilial rivals, ");
        yield return text(Vars.panacure);
        yield return text(" ");
        yield return text("realized that it was too late for their creation to have a critical effect on the" +
            "ir endeavors.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("This crucial realization was certainly prompted by the entire reserves of the con" +
            "coction being exhausted one evening when testing the local livestock. Ah, how th" +
            "e mind fades with old age!");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage59_Fragment_1);
        using (styleScope("hook", "h000059"))
            yield return link("Click to continue...", null, () => enchantHook("h000059", HarloweEnchantCommand.Replace, passage59_Fragment_0));
        yield break;
    }

    IStoryThread passage59_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "S1_Pancea";
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Move forward 1 space on the ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(" ");
                yield return text("Track.");
            }
            //yield return lineBreak();
            //yield return lineBreak();
            //yield return link("click to continue...", "Hospital3", null);
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage59_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage59_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: PanaceaUnleash   (passage60)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7216-7302
// Links:  Hospital3
// Aborts: -
// Purpose: 1882 journal: the Panacea dissolves a servant, unleashing the deterioration agent
// ###################################################################

    void passage60_Init()
    {
        this.Passages[@"PanaceaUnleash"] = new StoryPassage(@"PanaceaUnleash", new string[] { }, passage60_Main);
    }

    IStoryThread passage60_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("\"April Fools Day\" - Journal Entry - 1882");
            if (Vars.panacure == Vars.nameA)
            {
                Vars.tempjournal = Vars.nameB;
            }
            else
            {
                Vars.tempjournal = Vars.nameA;
            }
            yield return text(" ");
            yield return text(Vars.tempjournal);
            yield return text(" ");
            yield return text("Jr.");
        }
        yield return lineBreak();
        yield return text("It was a fine summer morning when I heard a piercing scream from the garden. Whil" +
            "e I had grown relatively accustomed to this cry of distress in my experimentatio" +
            "ns, it was decidedly peculiar to hear the sound over morning coffee and crepes.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"After sashing my robe about me, I exited the manor in time to witness the final moments of a servant tending to the trimming. With a quick lurch, they turned towards me, now beyond sound as their facial features collapsed inwardly. Sanguine chunks of flesh fell to the ground and sizzled like bacon grease on the grass. Within seconds, the human figure that once tended to our garden was a sloshy pile of pink and white froth on the lawn and whatever substance had caused it had seeped deep into the ground, creating a considerable hole in the landscaping.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I took a sip of coffee and examined a nearby glass vial labeled as \"vital elixir " +
            "for use in the prevention of disease.\" I recognized our dear cousin\'s penmanship" +
            " instantly; the prankster!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("However, unfortunately, another servant stood slack-jawed near the gate, having w" +
            "itnessed the entire spectacle. It would be difficult to replace this worker.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage60_Fragment_1);
        using (styleScope("hook", "h000060"))
            yield return link("Click to continue...", null, () => enchantHook("h000060", HarloweEnchantCommand.Replace, passage60_Fragment_0));
        yield break;
    }

    IStoryThread passage60_Fragment_0()
    {
        yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Pancea";
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("The player who completed the Panacea Experiment moves forward one space on the ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
                yield return text(" ");
                yield return text("Track.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("All other players must immediately return one Servant piece to the game box. This" +
                " piece cannot be hired again.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Hospital3", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage60_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage60_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: SymposiumEvent3   (passage61)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7307-7386
// Links:  SymposiumFail,SymposiumMiddle,SymposiumSuccess
// Aborts: -
// Purpose: Symposium tally: total Experiments vs thresholds; branches fail/middle/success
// ###################################################################

    void passage61_Init()
    {
        this.Passages[@"SymposiumEvent3"] = new StoryPassage(@"SymposiumEvent3", new string[] { }, passage61_Main);
    }

    IStoryThread passage61_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Fate of the Lecture Series");
        }
        yield return lineBreak();
        yield return text(@"If it amounted to anything, those in attendance were certainly astonished by the eccentricities witnessed that day. Some weaker-willed individuals were prone to nausea and fainting spells during the speeches, clearly in deference to the astounding breadth of visionary experimentation.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("But, were their efforts enough to sway the most notable scientific minds of the t" +
            "ime?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("SYMPOSIUM RESULT");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Add up the total number of ");
            yield return text(Vars.sci3);
            yield return text(" ");
            yield return text("Experiments completed by ALL players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the total is less than ");
        using (styleScope("bold", true))
        {
            yield return text(Vars.symp);
        }
        yield return text(", ");
        yield return link("click here.", "SymposiumFail", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("If the total is equal to or greater than ");
        using (styleScope("bold", true))
        {
            yield return text(Vars.symp);
        }
        yield return text(", ");
        yield return link("click here...", "SymposiumMiddle", null);
        yield return lineBreak();
        yield return lineBreak();
        yield return text("However, if the total is equal to or greater than ");
        using (styleScope("bold", true))
        {
            if (Vars.players == 2)
            {
                yield return text(Vars.symp + 2);
            }
            else if (Vars.players == 3)
            {
                yield return text(Vars.symp + 2);
            }
            else if (Vars.players == 4)
            {
                yield return text(Vars.symp + 3);
            }
            else if (Vars.players == 5)
            {
                yield return text(Vars.symp + 4);
            }
            else
            {
                yield return text(Vars.symp + 2);
            }
        }
        yield return text(", ");
        yield return link("click here instead.", "SymposiumSuccess", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Unicure2   (passage62)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7392-7467
// Links:  PanaceaIntro
// Aborts: -
// Purpose: "Patented!" inoculation outcome: money, Suspicion marker left
// ###################################################################

    void passage62_Init()
    {
        this.Passages[@"Unicure2"] = new StoryPassage(@"Unicure2", new string[] { }, passage62_Main);
    }

    IStoryThread passage62_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Patented!");
        }
        yield return lineBreak();
        yield return text(Vars.fevercure);
        yield return text(" ");
        yield return text("Jr. was known for their incisive wit and even more acute business dealings. Shirk" +
            "ing the potential admiration of medical elites, ");
        yield return text(Vars.fevercure);
        yield return text(" ");
        yield return text(@"hastily submitted a patent for this breakthrough in disease prevention. While it ensured a hefty sum for royalties, the locals eyed this new development as yet another attempt by aloof eccentrics to toy with the lives of the poor and their wariness increased.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage62_Fragment_1);
        using (styleScope("hook", "h000062"))
            yield return link("Click to continue...", null, () => enchantHook("h000062", HarloweEnchantCommand.Replace, passage62_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage62_Fragment_0()
    {
        //yield return lineBreak();
        Vars.pub = "no";
        Vars.cured = 1;
        ViewItemObtain.SetupPassagename = "PanaceaIntro";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AngryMob_Icon";
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Gain $");
                yield return text(Vars.fevermoney);
                yield return text(".");
            }
            yield return lineBreak();
            yield return text("Then, move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("marker ");
            using (styleScope("bold", true))
            {
                yield return text("1 space");
            }
            yield return text(" ");
            yield return text("to the ");
            using (styleScope("bold", true))
            {
                yield return text("left.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "PanaceaIntro", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage62_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage62_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Unicure1   (passage63)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 7472-7541
// Links:  PanaceaIntro
// Aborts: -
// Purpose: "Published!" inoculation outcome: VP, Suspicion marker 2 right
// ###################################################################

    void passage63_Init()
    {
        this.Passages[@"Unicure1"] = new StoryPassage(@"Unicure1", new string[] { }, passage63_Main);
    }

    IStoryThread passage63_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Published!");
        }
        yield return lineBreak();
        yield return text("While inevitably the findings were deemed underdeveloped by the prevailing medica" +
            "l institutions, the discussion they set forth resulted in the name ");
        yield return text(Vars.fevercure);
        yield return text(" ");
        yield return text("being bandied about for years to come. The release of this knowledge even had a m" +
            "inor sedative effect on the locals; those poor, gullible wretches.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage63_Fragment_1);
        using (styleScope("hook", "h000063"))
            yield return link("Click to continue...", null, () => enchantHook("h000063", HarloweEnchantCommand.Replace, passage63_Fragment_0));
        yield break;
    }

    IStoryThread passage63_Fragment_0()
    {
        //yield return lineBreak();
        Vars.pub = "yes";
        Vars.cured = 1;
        ViewItemObtain.SetupPassagename = "PanaceaIntro";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AngryMob_Icon";
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Gain ");
                yield return text(Vars.fevervp);
                yield return text("VP.");
            }
            yield return lineBreak();
            yield return text("Then, move the ");
            yield return text("<sprite=\"AngryMob_Icon\" index=0>");
            yield return text(" ");
            yield return text("marker ");
            using (styleScope("bold", true))
            {
                yield return text("2 spaces");
            }
            yield return text(" ");
            yield return text("to the right.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "PanaceaIntro", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage63_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage63_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: HospitalDefine   (passage85)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 9479-9524
// Links:  Hospital1
// Aborts: -
// Purpose: Hospital action-space rules popup incl. first-visit-with-Self caveat
// ###################################################################

    void passage85_Init()
    {
        this.Passages[@"HospitalDefine"] = new StoryPassage(@"HospitalDefine", new string[] { }, passage85_Main);
    }

    IStoryThread passage85_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Hospital");
        }
        yield return text("<line-height=400%>");
        yield return lineBreak();
        yield return text("</line-height>");
        yield return text("<align=\"center\">");
        yield return text("<line-height=400%>");
        yield return text("<size=200>");
        yield return text("<sprite=\"Hospital1\" index=0>");
        yield return text("</size>");
        yield return text("</align>");
        yield return text("</line-height>");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Look through the Experiment deck of your choice to find an Experiment of your cho" +
            "ice and draw it into your hand. ");
        using (styleScope("italic", true))
        {
            yield return text("(Once complete, shuffle the deck.)");
        }
        yield return lineBreak();
        Vars.twopage = 1;
        yield return lineBreak();
        yield return text("You have until the beginning of your next turn to complete this action ");
        using (styleScope("italic", true))
        {
            yield return text("(allow other players to begin their turn while you choose).");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("NOTE: You may take the Hospital action with any legal token, but you must only click on the Storybook prompt the <b>first time</b> you visit the Hospital with your Self.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click here to return...", "Hospital1", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: 6Note   (passage88)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10029-10147
// Links:  -
// Aborts: -
// Purpose: DEV NOTE: Symposium tiers, inoculation, Immortality token, university decision
// ###################################################################

    void passage88_Init()
    {
        this.Passages[@"6Note"] = new StoryPassage(@"6Note", new string[] { }, passage88_Main);
    }

    IStoryThread passage88_Main()
    {
        yield return text("Choose 35VP negative - last place player");
        yield return lineBreak();
        yield return text("Introduce Yellow Fever Innoculation - must be tested on someone");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Charity/Mayor? choose 3 Sciences for symposium.");
        yield return lineBreak();
        yield return text("End of Generation Science Bonus.");
        yield return lineBreak();
        yield return text("1st Immortality token. Infinity Token placed on 3rd level of track.");
        yield return lineBreak();
        yield return text("2nd Symposium - If more, Uni is built. If middle, Yellow Fever determines. If low" +
            ", no Uni. (3 narratives presented)");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Could potentially write a short excerpt from each Symposium speech. This could al" +
            "so be based on how effective the players were.");
        yield return lineBreak();
        if (Vars.sci3 == "Biology")
        {
        }
        yield return lineBreak();
        if (Vars.sci3 == "Chemistry")
        {
        }
        yield return lineBreak();
        if (Vars.sci3 == "Engineering")
        {
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.sci3 == "Biology")
        {
            yield return text(@"Within minutes, a pool of blood that could not begin to be contained by the hastily tarped flooring caused the lower row in the theater to move to the second level. Conflicting theories of homeopathic remedies, misasmatic transference of disease, and the efficacy of good and bad Earth were debunked with live displays and bacterial cultures. By the end, ");
        }
        if (Vars.sci3 == "Chemistry")
        {
        }
        if (Vars.sci3 == "Engineering")
        {
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("NOTE: Do not have a thing to attack other players with YELLOW FEVER.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Replace Stasis Chamber to this side. Doesn\'t make sense on the other side.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Also, now that this side deals with finding the secret to immortality. Eternal li" +
            "fe.");
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
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Scientific \"biological immortality\":");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("WHO WANTS TO LIVE FOREVER");
        yield return lineBreak();
        yield return text("Ways to become Immortal:");
        yield return lineBreak();
        yield return text("Biology -");
        yield return lineBreak();
        yield return text("Chemistry -");
        yield return lineBreak();
        yield return text("Engineering -");
        yield return lineBreak();
        yield return text("Occult -");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Put a Storybook token on the end of the Research Track of your choice. If/when th" +
            "is track is complete, click on the Storybook icon.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Gift of immortality is of course a free caretaker disc that can take double town " +
            "actions once per round.");
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Maybe move up the Panacea and Yellow Fever cures.");
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
        yield break;
    }

// ###################################################################
// PASSAGE: Immortality   (passage89)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10153-10221
// Links:  ImmortalitySetup,Gen1Creepy-RefuseBonus
// Aborts: -
// Purpose: "Overcoming Death": triggered at the third Journal Track level toward immortality
// ###################################################################

    void passage89_Init()
    {
        this.Passages[@"Immortality"] = new StoryPassage(@"Immortality", new string[] { }, passage89_Main);
    }

    IStoryThread passage89_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Overcoming Death");
        }
        yield return lineBreak();
        yield return text(@"If not now, then when? The cousins pored over this question. How long would they remain relegated to an eccentric footnote murmured amongst the townspeople? Why must they toil in their most important labors under the cover of darkness and stone like vermin? A deep restlessness had set into the minds of each, and even on the cusp of approval from the academic community, they could not quell these thoughts.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was trivial to discuss meager experimentations when the solidification of such" +
            " a poignant legacy repeated fruitlessly generation upon generation. If only time" +
            " was no longer an obstacle.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"They vowed to accumulate a wealth of knowledge in their fields of expertise that far surpassed the pitiable ruminations of ancient scholars. Perhaps if they pushed forward into the unknown they would harness new and untold powers. Their evening conversations spurred them to devise a way to cheat the most sacred and inevitable truth of existence.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("For if life can be taken and altered by humanity into its most cruel and twisted " +
            "form, surely that same spark could be endlessly preserved!");
        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "ImmortalitySetup", null);
        using (styleScope("hook", "h0000089"))
            yield return link("Click to continue...", null, () => enchantHook("h0000089", HarloweEnchantCommand.Replace, passage89_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage89_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = (Vars.seedy == "no") ? "Gen1Creepy-RefuseBonus" : (Vars.seedy == "yes") ? "Gen1Creepy-AgreedReturn" : "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "StorybookToken";
            yield return lineBreak();
            yield return text("Give each player a ");
            using (styleScope("bold", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" ");
                yield return text("token");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Each player chooses an incomplete track of their choice in their Journal and plac" +
                "es their ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            yield return text("token on the third level of that track.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Gen1Creepy-RefuseBonus", null);
        //yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: InfinityClick2   (passage95)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10539-10621
// Links:  ImmortalityMWUpdate
// Aborts: -
// Purpose: Infinity Journal reward: draw 2 Immortality cards, secretly keep one
// ###################################################################

    void passage95_Init()
    {
        this.Passages[@"InfinityClick2"] = new StoryPassage(@"InfinityClick2", new string[] { }, passage95_Main);
    }

    IStoryThread passage95_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The ");
            yield return text(macros1.either("Secret to", "Marvelous", "Discovering", "Forward to"));
            yield return text(" ");
            yield return text("Infinity Journal Entry ");
            yield return text(Vars.tempinf);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("There is no doubt in my ");
        yield return text(macros1.either("immaculate brain", "inestimable mind"));
        yield return text(". With this research completed, ");
        yield return text(macros1.either("I have surely unlocked a most flawless scheme to extend my existence indefinitely" +
            "!", "the world will tremble at the mere utterance of my name."));
        yield return text(" ");
        yield return text("The ravages of time will no longer have an effect on my work and I will be free t" +
            "o face the ");
        yield return text(macros1.either("infinite", "future"));
        yield return text(" ");
        yield return text("unimpeded by this mortal coil!");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage95_Fragment_1);
        using (styleScope("hook", "h000095"))
            yield return link("Click to continue...", null, () => enchantHook("h000095", HarloweEnchantCommand.Replace, passage95_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage95_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "ImmortalityMWUpdate";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Immortality";
            yield return lineBreak();
            if (Vars.setinf == 0)
            {
                yield return text("Retrieve the ");
                using (styleScope("bold", true))
                {
                    yield return text("Immortality cards");
                }
                yield return text(" from the scenario box. Shuffle them face down and place them nearby.");
            }
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Draw 2 Immortality cards. Look at both of them and choose one as your secret to E" +
                "ternal Life. Discard the other.");
            }
            yield return text(" ");
            yield return text("Then, discard the ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            yield return text("token to the supply.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "ImmortalityMWUpdate", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage95_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage95_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: InfinityClick1   (passage96)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10626-10721
// Links:  -
// Aborts: -
// Purpose: "Research Completed": who finished the third Research Track level
// ###################################################################

    void passage96_Init()
    {
        this.Passages[@"InfinityClick1"] = new StoryPassage(@"InfinityClick1", new string[] { }, passage96_Main);
    }

    IStoryThread passage96_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Research Completed");
        }
        yield return lineBreak();
        yield return text(@"It seemed unimaginable; not simply a cure for all disease, but a mysterious contrivance to extend life indefinitely. Perhaps, those that pursued this heretical course of action should not have postulated, ""could it be done?"" Instead, they might have asked themselves, ""but at what cost?""");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Which player has completed the third level of their Journal\'s Research Track?");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00035"))
            yield return link("Dr. " + Vars.nameA, null, () => enchantHook("h00035", HarloweEnchantCommand.Replace, passage96_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00036"))
            yield return link("Dr. " + Vars.nameB, null, () => enchantHook("h00036", HarloweEnchantCommand.Replace, passage96_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00037"))
                yield return link("Dr. " + Vars.nameC, null, () => enchantHook("h00037", HarloweEnchantCommand.Replace, passage96_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00038"))
                yield return link("Dr. " + Vars.nameD, null, () => enchantHook("h00038", HarloweEnchantCommand.Replace, passage96_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00039"))
                yield return link("Dr. " + Vars.nameE, null, () => enchantHook("h00039", HarloweEnchantCommand.Replace, passage96_Fragment_4));
            yield return lineBreak();
        }
        yield break;
    }

    IStoryThread passage96_Fragment_0()
    {
        Vars.tempinf = Vars.nameA;
        Vars.lifeA = "yes";
        Vars.life = Vars.life + 1;
        yield return abort(goToPassage: "InfinityClick2");
        yield break;
    }

    IStoryThread passage96_Fragment_1()
    {
        Vars.tempinf = Vars.nameB;
        Vars.lifeB = "yes";
        Vars.life = Vars.life + 1;
        yield return abort(goToPassage: "InfinityClick2");
        yield break;
    }

    IStoryThread passage96_Fragment_2()
    {
        Vars.tempinf = Vars.nameC;
        Vars.lifeC = "yes";
        Vars.life = Vars.life + 1;
        yield return abort(goToPassage: "InfinityClick2");
        yield break;
    }

    IStoryThread passage96_Fragment_3()
    {
        Vars.tempinf = Vars.nameD;
        Vars.lifeD = "yes";
        Vars.life = Vars.life + 1;
        yield return abort(goToPassage: "InfinityClick2");
        yield break;
    }

    IStoryThread passage96_Fragment_4()
    {
        Vars.tempinf = Vars.nameE;
        Vars.lifeE = "yes";
        Vars.life = Vars.life + 1;
        yield return abort(goToPassage: "InfinityClick2");
        yield break;
    }

// ###################################################################
// PASSAGE: S5HospA1   (passage99)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10945-11014
// Links:  -
// Aborts: -
// Purpose: LOGIC: compares `life` count vs player count; branches S5HospA1Yes/No
// ###################################################################

    void passage99_Init()
    {
        this.Passages[@"S5HospA1"] = new StoryPassage(@"S5HospA1", new string[] { }, passage99_Main);
    }

    IStoryThread passage99_Main()
    {
        if (Vars.S5HospA1nextPsg == "" || Vars.S5HospA1nextPsg == 0)
        {
            if (Vars.players == 2)
            {
                if (Vars.life >= int.Parse(macros1.either(1, 2)))
                {
                    //yield return abort(goToPassage: "S5HospA1Yes");
                    Vars.S5HospA1nextPsg = "S5HospA1Yes";
                }
                else
                {
                    //yield return abort(goToPassage: "S5HospA1No");
                    Vars.S5HospA1nextPsg = "S5HospA1No";
                }
            }
            else if (Vars.players == 3)
            {
                if (Vars.life >= 2)
                {
                    //yield return abort(goToPassage: "S5HospA1Yes");
                    Vars.S5HospA1nextPsg = "S5HospA1Yes";
                }
                else
                {
                    //yield return abort(goToPassage: "S5HospA1No");
                    Vars.S5HospA1nextPsg = "S5HospA1No";
                }
            }
            else if (Vars.players == 4)
            {
                if (Vars.life >= int.Parse(macros1.either(2, 3)))
                {
                    //yield return abort(goToPassage: "S5HospA1Yes");
                    Vars.S5HospA1nextPsg = "S5HospA1Yes";
                }
                else
                {
                    //yield return abort(goToPassage: "S5HospA1No");
                    Vars.S5HospA1nextPsg = "S5HospA1No";
                }
            }
            else if (Vars.players == 5)
            {
                if (Vars.life >= int.Parse(macros1.either(2, 3, 4)))
                {
                    //yield return abort(goToPassage: "S5HospA1Yes");
                    Vars.S5HospA1nextPsg = "S5HospA1Yes";
                }
                else
                {
                    //yield return abort(goToPassage: "S5HospA1No");
                    Vars.S5HospA1nextPsg = "S5HospA1No";
                }
            }
            else
            {
                //yield return abort(goToPassage: "S5HospA1No");
                Vars.S5HospA1nextPsg = "S5HospA1No";
            }
        }
        yield return abort(goToPassage: Vars.S5HospA1nextPsg);
        yield break;
    }

// ###################################################################
// PASSAGE: S5HospA1No   (passage100)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 11020-11071
// Links:  RippedMasterwork
// Aborts: -
// Purpose: "Death Becomes Us" ending: too few immortal, university abandoned
// ###################################################################

    void passage100_Init()
    {
        this.Passages[@"S5HospA1No"] = new StoryPassage(@"S5HospA1No", new string[] { "END", }, passage100_Main);
    }

    IStoryThread passage100_Main()
    {
        //yield return text("Remove all player pieces from the board and perform the End of a Generation. Any " +
        //    "");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens remaining on a player\'s Journal Track are returned to the supply.");
        //yield return lineBreak();
        //yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Death Becomes Us");
        }
        yield return lineBreak();
        string s = "Remove all player pieces from the board and perform the End of a Generation. Any <sprite=\"StorybookToken\" index=0> tokens remaining on a player's Journal Track are returned to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 6);
        yield return lineBreak();
        yield return text("As their bodies withered with time, the failures of their equally outdated scient" +
            "ific pursuits weighed heavily on their deteriorating minds. With only ");
        using (styleScope("bold", true))
        {
            yield return text(Vars.life);
        }
        yield return text(" ");
        yield return text("of them discovering the way towards ");
        using (styleScope("bold", true))
        {
            yield return text("immortality");
        }
        yield return text(", the cousins wallowed in their own ineptitude.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.uni == "yes")
        {
            yield return text("With no further push from its energetic benefactors, the university was shunned, " +
            "abandoned, and refitted.");
            yield return text(" ");
        }
        yield return text("With no sounds of screams and explosions echoing down from the hillsides, the tow" +
            "nsfolk lost their sense of purpose. A thick fog of ignorance fell across the pop" +
            "ulace as they returned to the old ways with a righteous fervor.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue to a more depressing time...", "RippedMasterwork", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Trigger35Points   (passage122)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 13743-13874
// Links:  Hospital1,Hospital2,Hospital3
// Aborts: -
// Purpose: Private message to the first player reaching 35VP; rumor/sabotage penalty
// ###################################################################

    void passage122_Init()
    {
        this.Passages[@"Trigger35Points"] = new StoryPassage(@"Trigger35Points", new string[] { }, passage122_Main);
    }

    IStoryThread passage122_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand this storybook device to the player that just reached 35VP. This i" +
            "s read within view of all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.thirtyFivevp == "creep")
        {
            using (styleScope("bold", true))
            {
                yield return text("\"Nasty Rumors\" - Journal Entry, 1878");
            }
            yield return lineBreak();
            yield return text("To reach the pinnacle of understanding, only to feel the cruel hand of treachery." +
            " The rest of the family was noticeably not distraught when a recent article in t" +
            "he regional newspaper spread an uncomfortable rumor about my personal hygiene.");
            yield return lineBreak();
            Vars.twopage = 1;
            yield return lineBreak();
            yield return text("I do not have time for this interruption! I do not smell like pickles! It is the " +
            "formaldehyde solution for my most recent experiment. It is not the smell of pick" +
            "les; it is the smell of SCIENCE!");
            yield return lineBreak();
            yield return lineBreak();
        }
        else //if (Vars.thirtyFivevp == "vp")
        {
            using (styleScope("bold", true))
            {
                yield return text("\"Unfortunate Accident\" - Journal Entry, 1876");
            }
            yield return lineBreak();
            yield return text("My work! My property! Sabotaged.");
            yield return lineBreak();
            Vars.twopage = 1;
            yield return lineBreak();
            yield return text(@"I awoke this evening to find my home on fire and the culprits nowhere to be found. But, I know who did it. I could still smell the chemical reaction as the fires raged. I would have never expected my cousins to stoop to such a base level. Direct and blatant sabotage? Absolutely unconscionable.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It will take weeks for my spouse to manage the removal of the damaged piece of ou" +
            "r Estate. They are all just jealous of my genius!");
            yield return lineBreak();
            yield return lineBreak();
        }
        //yield return text("Click to return...");
        //yield return enchantIntoLink("Click to return...", passage122_Fragment_1);
        using (styleScope("hook", "h000122"))
            yield return link("Click to return...", null, () => enchantHook("h000122", HarloweEnchantCommand.Replace, passage122_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage122_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = Vars.round == 7 ? "Hospital1" : Vars.round == 8 ? "Hospital2" : "Hospital3";
        Vars.trigger35 = 1;
        using (styleScope("setupStyleEvnt", true))
        {
            if (Vars.thirtyFivevp == "creep")
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SPECIAL SETUP");
                }
                Vars._SetupImage = "Creepy_Icon";
                yield return lineBreak();
                yield return text("Immediately ");
                using (styleScope("bold", true))
                {
                    yield return text("gain 2 ");
                    yield return text("<sprite=\"Creepy_Icon\" index=0>");
                }
                yield return text(" and ");
                using (styleScope("bold", true))
                {
                    yield return text("gain 1 ");
                    yield return text("<sprite=\"Insanity_Icon\" index=0>");
                }
                yield return text(".");
            }
            else //if (Vars.thirtyFivevp == "vp")
            {
                using (styleScope("bold", true))
                {
                    //yield return text("SPECIAL SETUP");
                }
                Vars._SetupImage = "DiscardEstateUpgrade_Icon";
                yield return lineBreak();
                yield return text("Immediately ");
                using (styleScope("bold", true))
                {
                    yield return text("lose 4VP");
                }
                yield return text(" and ");
                using (styleScope("bold", true))
                {
                    yield return text("discard an Estate Upgrade of your choice");
                }
                yield return text(".");
            }
        }
        //if (Vars.round == 7)
        //{
        //    Vars.trigger35 = 1;
        //    yield return link("Click to return...", "Hospital1", null);
        //}
        //if (Vars.round == 8)
        //{
        //    Vars.trigger35 = 1;
        //    yield return link("Click to return...", "Hospital2", null);
        //}
        //if (Vars.round == 9)
        //{
        //    yield return link("Click to return...", "Hospital3", null);
        //}
        yield break;
    }

    IStoryThread passage122_Fragment_1()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage122_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Trigger3Experiments   (passage123)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 13879-13969
// Links:  -
// Aborts: -
// Purpose: Prompt: who completed 3 B/C Experiments, for a special reward
// ###################################################################

    void passage123_Init()
    {
        this.Passages[@"Trigger3Experiments"] = new StoryPassage(@"Trigger3Experiments", new string[] { }, passage123_Main);
    }

    IStoryThread passage123_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Advancements in ");
            yield return text(Vars.sci3);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Please click on the name of the scientist that completed a total of ");
        using (styleScope("bold", true))
        {
            yield return text("3 B or C ");
            yield return text(Vars.sci3);
            yield return text(" ");
            yield return text("Experiments");
        }
        yield return text(":");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00060"))
            yield return link("Dr. " + Vars.nameA + " Jr.", null, () => enchantHook("h00060", HarloweEnchantCommand.Replace, passage123_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00061"))
            yield return link("Dr. " + Vars.nameB + " Jr.", null, () => enchantHook("h00061", HarloweEnchantCommand.Replace, passage123_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00062"))
                yield return link("Dr. " + Vars.nameC + " Jr.", null, () => enchantHook("h00062", HarloweEnchantCommand.Replace, passage123_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00063"))
                yield return link("Dr. " + Vars.nameD + " Jr.", null, () => enchantHook("h00063", HarloweEnchantCommand.Replace, passage123_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00064"))
                yield return link("Dr. " + Vars.nameE + " Jr.", null, () => enchantHook("h00064", HarloweEnchantCommand.Replace, passage123_Fragment_4));
            yield return lineBreak();
            yield return lineBreak();
        }
        yield break;
    }

    IStoryThread passage123_Fragment_0()
    {
        Vars.gen2exp = Vars.nameA;
        yield return abort(goToPassage: "3ExperimentsRes");
        yield break;
    }

    IStoryThread passage123_Fragment_1()
    {
        Vars.gen2exp = Vars.nameB;
        yield return abort(goToPassage: "3ExperimentsRes");
        yield break;
    }

    IStoryThread passage123_Fragment_2()
    {
        Vars.gen2exp = Vars.nameC;
        yield return abort(goToPassage: "3ExperimentsRes");
        yield break;
    }

    IStoryThread passage123_Fragment_3()
    {
        Vars.gen2exp = Vars.nameD;
        yield return abort(goToPassage: "3ExperimentsRes");
        yield break;
    }

    IStoryThread passage123_Fragment_4()
    {
        Vars.gen2exp = Vars.nameE;
        yield return abort(goToPassage: "3ExperimentsRes");
        yield break;
    }

// ###################################################################
// PASSAGE: ChooseScience   (passage124)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 13974-14060
// Links:  -
// Aborts: -
// Purpose: Choose the Symposium science discipline that may determine the University; sets `sci3`
// ###################################################################

    void passage124_Init()
    {
        this.Passages[@"ChooseScience"] = new StoryPassage(@"ChooseScience", new string[] { }, passage124_Main);
    }

    IStoryThread passage124_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to ");
            yield return text(Vars.charity);
            yield return text(". This choice is read and made within view of all players.");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("\"Universal Interest\" - Journal Entry - November, 1859 - ");
            yield return text(Vars.charity);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It has been three days since I received a letter from the Hungarian government and two days since my cousins deigned it necessary to make me the target of their ridicule. My parents cared deeply for this horrid community - a sentiment that those miscreants know nothing about!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("I am not some groveler who needs confirmation from the stuffed shirts and upturne" +
            "d noses of European academies. But, getting to choose the ");
        using (styleScope("bold", true))
        {
            yield return text("subject of the upcoming Symposium");
        }
        yield return text(" ");
        yield return text("that could very well determine if a ");
        using (styleScope("bold", true))
        {
            yield return text("University");
        }
        yield return text(" ");
        yield return text("is built in ");
        yield return text(Vars.townname);
        yield return text("?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"My parents instilled into me a scientific vigor that far surpasses even the members of my own, somewhat beloved, family. As I returned from studies abroad, it was my own aptitudes that spearheaded my cousins into action. Damn them and their jibes! I will show them. In fact, I have already made my choice and penned my response. It will be I who will be doing the laughing in the end.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Choose which of the Sciences our family will focus upon this Generation:");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00065"))
            yield return link("Chemistry", null, () => enchantHook("h00065", HarloweEnchantCommand.Replace, passage124_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00066"))
            yield return link("Engineering", null, () => enchantHook("h00066", HarloweEnchantCommand.Replace, passage124_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00067"))
            yield return link("Biology", null, () => enchantHook("h00067", HarloweEnchantCommand.Replace, passage124_Fragment_2));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage124_Fragment_0()
    {
        Vars.sci3 = "Chemistry";
        yield return abort(goToPassage: "35VP");
        yield break;
    }

    IStoryThread passage124_Fragment_1()
    {
        Vars.sci3 = "Engineering";
        yield return abort(goToPassage: "35VP");
        yield break;
    }

    IStoryThread passage124_Fragment_2()
    {
        Vars.sci3 = "Biology";
        yield return abort(goToPassage: "35VP");
        yield break;
    }

// ###################################################################
// PASSAGE: SymposiumEvent1   (passage125)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14065-14097
// Links:  SymposiumEvent2
// Aborts: -
// Purpose: Budapest Symposium arrival flavor; leads to SymposiumEvent2
// ###################################################################

    void passage125_Init()
    {
        this.Passages[@"SymposiumEvent1"] = new StoryPassage(@"SymposiumEvent1", new string[] { }, passage125_Main);
    }

    IStoryThread passage125_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Collection of Esteemed Colleagues");
        }
        yield return lineBreak();
        Vars.twopage = 0;
        yield return lineBreak();
        yield return text("The journey to the newly created city of Budapest for the ");
        yield return text(Vars.sci3);
        yield return text(" ");
        yield return text("Symposium was uncharacteristically dour. However, this dreadful murkiness could n" +
            "ot dampen the spirits of the ");
        yield return text(Vars.playtxt);
        yield return text("; nor could the sojourn in the marginal accommodations prepared for their arrival" +
            ". For the cousins, this recognition for their efforts to advance science at all " +
            "costs was considerably well-deserved and long-overdue.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The University was abuzz with activity as they attended various events and offere" +
            "d their prescribed greetings.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "SymposiumEvent2", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HospitalVisitCheck   (passage130)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14489-14709
// Links:  -
// Aborts: -
// Purpose: Hospital tour flavor + prompt for which player is visiting
// ###################################################################

    void passage130_Init()
    {
        this.Passages[@"HospitalVisitCheck"] = new StoryPassage(@"HospitalVisitCheck", new string[] { }, passage130_Main);
    }

    IStoryThread passage130_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Compulsory Visitation");
        }
        yield return lineBreak();
        yield return text("The ");
        yield return text(Vars.townname);
        yield return text(" ");
        yield return text("General Hospital was one of the first hospitals in the region. Established in 186" +
            "5, it was instrumental in changing the public perception of a hospital from a pl" +
            "ace you go to die to a place of healing with the most modern advances in medicin" +
            "e.");
        yield return lineBreak();
        Vars.twopage = 1;
        yield return lineBreak();
        yield return text("On the day of the visit, several nurses bandied about, treating patients from nea" +
            "rby villages with symptoms of the Yellow Fever");
        if (Vars.pub == "yes")
        {
            yield return text(" and using the innoculation techniques that the family had recently published");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Click on the name of the player ");
        using (styleScope("bold", true))
        {
            yield return text("visiting the Hospital");
        }
        yield return text(" ");
        yield return text("today:");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00074"))
            yield return link("Dr. " + Vars.nameA + " Jr.", null, () => enchantHook("h00074", HarloweEnchantCommand.Replace, passage130_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00075"))
            yield return link("Dr. " + Vars.nameB + " Jr.", null, () => enchantHook("h00075", HarloweEnchantCommand.Replace, passage130_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00076"))
                yield return link("Dr. " + Vars.nameC + " Jr.", null, () => enchantHook("h00076", HarloweEnchantCommand.Replace, passage130_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00077"))
                yield return link("Dr. " + Vars.nameD + " Jr.", null, () => enchantHook("h00077", HarloweEnchantCommand.Replace, passage130_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00078"))
                yield return link("Dr. " + Vars.nameE + " Jr.", null, () => enchantHook("h00078", HarloweEnchantCommand.Replace, passage130_Fragment_4));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage130_Fragment_0()
    {
        Vars.hospsign = Vars.nameA;
        if (Vars.hospsign == Vars.nameA && Vars.hospA == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameB && Vars.hospB == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameC && Vars.hospC == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameD && Vars.hospD == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameE && Vars.hospE == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else
        {
            yield return abort(goToPassage: "HospitalVisitCheck2");
        }
        yield break;
    }

    IStoryThread passage130_Fragment_1()
    {
        Vars.hospsign = Vars.nameB;
        if (Vars.hospsign == Vars.nameA && Vars.hospA == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameB && Vars.hospB == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameC && Vars.hospC == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameD && Vars.hospD == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameE && Vars.hospE == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else
        {
            yield return abort(goToPassage: "HospitalVisitCheck2");
        }
        yield break;
    }

    IStoryThread passage130_Fragment_2()
    {
        Vars.hospsign = Vars.nameC;
        if (Vars.hospsign == Vars.nameA && Vars.hospA == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameB && Vars.hospB == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameC && Vars.hospC == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameD && Vars.hospD == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameE && Vars.hospE == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else
        {
            yield return abort(goToPassage: "HospitalVisitCheck2");
        }
        yield break;
    }

    IStoryThread passage130_Fragment_3()
    {
        Vars.hospsign = Vars.nameD;
        if (Vars.hospsign == Vars.nameA && Vars.hospA == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameB && Vars.hospB == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameC && Vars.hospC == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameD && Vars.hospD == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameE && Vars.hospE == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else
        {
            yield return abort(goToPassage: "HospitalVisitCheck2");
        }
        yield break;
    }

    IStoryThread passage130_Fragment_4()
    {
        Vars.hospsign = Vars.nameE;
        if (Vars.hospsign == Vars.nameA && Vars.hospA == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameB && Vars.hospB == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameC && Vars.hospC == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameD && Vars.hospD == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else if (Vars.hospsign == Vars.nameE && Vars.hospE == "yes")
        {
            yield return abort(goToPassage: "HospitalVisitReject");
        }
        else
        {
            yield return abort(goToPassage: "HospitalVisitCheck2");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: HospitalVisitCheck2   (passage131)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14714-14859
// Links:  Gen1Insanity-NoExtraAction
// Aborts: -
// Purpose: Private Nurse Varga report on the visiting doctor's unsettling behavior
// ###################################################################

    void passage131_Init()
    {
        this.Passages[@"HospitalVisitCheck2"] = new StoryPassage(@"HospitalVisitCheck2", new string[] { }, passage131_Main);
    }

    IStoryThread passage131_Main()
    {
        //if (Vars.hospsign == Vars.nameA && Vars.hospA == "yes")
        //{
        //    yield return abort(goToPassage: "HospitalVisitReject");
        //}
        //else if (Vars.hospsign == Vars.nameB && Vars.hospB == "yes")
        //{
        //    yield return abort(goToPassage: "HospitalVisitReject");
        //}
        //else if (Vars.hospsign == Vars.nameC && Vars.hospC == "yes")
        //{
        //    yield return abort(goToPassage: "HospitalVisitReject");
        //}
        //else if (Vars.hospsign == Vars.nameD && Vars.hospD == "yes")
        //{
        //    yield return abort(goToPassage: "HospitalVisitReject");
        //}
        //else if (Vars.hospsign == Vars.nameE && Vars.hospE == "yes")
        //{
        //    yield return abort(goToPassage: "HospitalVisitReject");
        //}
        //else
        //{
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully pick up the Storybook and do not allow any other players to see the scr" +
            "een.");
        }
        yield return lineBreak();
        Vars.hospentry = macros1.either(1, 2);
        yield return lineBreak();
        if (Vars.hospentry == 1)
        {
            using (styleScope("bold", true))
            {
                yield return text("Visitation Report: Dr. ");
                yield return text(Vars.hospsign);
                yield return text(" - Notes submitted by Nurse Varga");
            }
            yield return lineBreak();
            yield return text("Dr. ");
            yield return text(Vars.hospsign);
            yield return text(" seemed in a hurry. Dismissed each area as sterile and uninspired. Until we arrive" +
            "d at the operating room. Immediately became enraptured, fixated, and I had " +
            "to thrice repeat myself before they responded.");
            yield return lineBreak();
            yield return lineBreak();
            if (macros1.either(1, 2) == 1)
            {
                yield return text("\"This is all wrong. What do they teach in these surgeon schools?\" Dr. ");
                yield return text(Vars.hospsign);
                yield return text(" asked, clearly not expecting an answer and brazenly entered the operating room to" +
                " accost the surgeons on duty. They retrieved a scalpel and insisting on completi" +
                "ng the operation themselves. I have never seen so much blood.");
            }
            else
            {
                yield return text("Their response was muffled and I was unable to stop them from entering the theater. Their face was etched in a hideous grin as they stood at the center with their hands raised into the air. At this point, they either refused to listen or entered a catatonic state which left them motionless for nearly an hour.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("At this point, ");
            yield return text(Vars.hospsign);
            yield return text(" had to be escorted by security from the premises. They are barred from any furthe" +
            "r tours of the facilities.");
        }
        //if (Vars.hospentry == 2)
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Visitation Report: Dr. ");
                yield return text(Vars.hospsign);
                yield return text(" - Notes submitted by Nurse Varga");
            }
            yield return lineBreak();
            yield return text("Relatively uneventful visit, though unsettling. Dr. ");
            yield return text(Vars.hospsign);
            yield return text(" requested a tour through the wards.");
            yield return lineBreak();
            yield return lineBreak();
            if (macros1.either(1, 2) == 1)
            {
                yield return text("Mostly disinterested and silent. However, our visit to the morgue was longer than" +
            " to my liking. Dr. ");
                yield return text(Vars.hospsign);
                yield return text(" kept insisting on inspecting the more extreme cases, excitedly asking questions w" +
                "hile I unsuccessfully attempted to stop them from physically handling the deceas" +
                "ed.");
            }
            else
            {
                yield return text("At one juncture, Dr. ");
                yield return text(Vars.hospsign);
                yield return text(" approached a patient in the hallway that had been confined to a bath chair. Unprompted, they began a through examination of the individual, palpating their hairline and skull with their fingers. To my dismay, they were enraptured by a rash along the patients cheek which was covered in small protusions and red boils. They insisted on collecting several samples of the fluid they produced.");
            }
            yield return lineBreak();
            yield return lineBreak();
            yield return text("After requesting access to more severe emergency cases, we walked the grounds. Th" +
            "ey kept stating that the facilities were \"unimpressive compared to their own.\" I" +
            " shudder to think on what that phrase means.");
        }

        yield return lineBreak();
        yield return lineBreak();
        //yield return link("Click to continue...", "Gen1Insanity-NoExtraAction", null);
        using (styleScope("hook", "h0000131"))
            yield return link("Click to continue...", null, () => enchantHook("h0000131", HarloweEnchantCommand.Replace, passage131_Fragment_0));
        //}
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage131_Fragment_0()
    {
        Vars.hospcount = Vars.hospcount + 1;
        if (Vars.hospsign == Vars.nameA)
        {
            Vars.hospA = "yes";
        }
        else if (Vars.hospsign == Vars.nameB)
        {
            Vars.hospB = "yes";
        }
        else if (Vars.hospsign == Vars.nameC)
        {
            Vars.hospC = "yes";
        }
        else if (Vars.hospsign == Vars.nameD)
        {
            Vars.hospD = "yes";
        }
        else if (Vars.hospsign == Vars.nameE)
        {
            Vars.hospE = "yes";
        }
        yield return abort(goToPassage: "Gen1Insanity-NoExtraAction");
        yield break;
    }

// ###################################################################
// PASSAGE: HospitalVisitReject   (passage358)
// Tags: revised
// Source: TheCostofDiseaseEng.cs lines 14864-14926
// Links:  Hospital1,Hospital2,Hospital3
// Aborts: -
// Purpose: "Kind Rejection" of a repeat hospital visit; gain 1 resource; return to the Hospital hub
// ###################################################################

    void passage358_Init()
    {
        this.Passages[@"HospitalVisitReject"] = new StoryPassage(@"HospitalVisitReject", new string[] { "revised", }, passage358_Main);
    }

    IStoryThread passage358_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Kind Rejection");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Legal proceedings were still ongoing due to their previous visit to the Hospital " +
            "grounds. Therefore, Dr. ");
        yield return text(Vars.hospsign);
        yield return text("\'s repeated presence was not well-received by the staff nor by the other cousins " +
            "who were forced to witness them debase themselves by raising their voice and try" +
            "ing to forcefully gain entry to the facility.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Was it madness that drove them to it or a deep obsession that even this humble bi" +
            "ographer cannot fathom? Whatever mental deficiency urged them onward, it certain" +
            "ly did not have the desired outcome.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00000358"))
            yield return link("Click to return...", null, () => enchantHook("h00000358", HarloweEnchantCommand.Replace, passage358_Fragment_0));
        //if (Vars.round == 7)
        //{
        //    yield return link("Click to return...", "Hospital1", null);
        //}
        //if (Vars.round == 8)
        //{
        //    yield return link("Click to return...", "Hospital2", null);
        //}
        //if (Vars.round == 9)
        //{
        //    yield return link("Click to return...", "Hospital3", null);
        //}
        yield break;
    }

    IStoryThread passage358_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = Vars.round == 7 ? "Hospital1" : Vars.round == 8 ? "Hospital2" : "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Gain 1 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(".");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HospitalNegative   (passage132)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 14931-15062
// Links:  NoHospitalCons
// Aborts: -
// Purpose: "Lack of Hospitality": skipping Board duties costs 6VP + an Estate Upgrade
// ###################################################################

    void passage132_Init()
    {
        this.Passages[@"HospitalNegative"] = new StoryPassage(@"HospitalNegative", new string[] { }, passage132_Main);
    }

    IStoryThread passage132_Main()
    {
        if (Vars.hospcount == Vars.players)
        {
            if (Vars.HospitalNegativenextPsg == "" || Vars.HospitalNegativenextPsg == 0)
            {
                Vars.HospitalNegativenextPsg = macros1.either("S5HospA1", "S5HospA2", "S5HospA3");
            }
            yield return abort(goToPassage: Vars.HospitalNegativenextPsg);
        }
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Lack of Hospitality");
            }
            yield return lineBreak();
            yield return text("Unfortunately, the lack of participation in the Hospital Board of Trustees needed" +
                " to be reckoned and any who chose to forgo their obligations felt their business" +
                " dealings in the local area become even further strained.");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage132_Fragment_1);
            if ((Vars.players > 4 ? Vars.hospA == "" || Vars.hospB == "" || Vars.hospC == "" || Vars.hospD == "" || Vars.hospE == "" || Vars.hospA == 0 || Vars.hospB == 0 || Vars.hospC == 0 || Vars.hospD == 0 || Vars.hospE == 0 :
                    Vars.players > 3 ? Vars.hospA == "" || Vars.hospB == "" || Vars.hospC == "" || Vars.hospD == "" || Vars.hospA == 0 || Vars.hospB == 0 || Vars.hospC == 0 || Vars.hospD == 0 :
                    Vars.players > 2 ? Vars.hospA == "" || Vars.hospB == "" || Vars.hospC == "" || Vars.hospA == 0 || Vars.hospB == 0 || Vars.hospC == 0 : Vars.hospA == "" || Vars.hospB == "" || Vars.hospA == 0 || Vars.hospB == 0))
            {
                using (styleScope("hook", "h000132"))
                    yield return link("Click here to continue...", null, () => enchantHook("h000132", HarloweEnchantCommand.Replace, passage132_Fragment_0));
            }
            else
            {
                yield return link("Click here to continue...", "NoHospitalCons", null);
                yield return lineBreak();
            }
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage132_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "NoHospitalCons";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            yield return lineBreak();
            Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            if (Vars.hospA == 0 || Vars.hospA == "")
            {
                yield return text("Dr. ");
                yield return text(Vars.nameA);
                yield return text(" Jr. must immediately lose 6VP and discard an Estate Upgrade of their choice.");
                yield return lineBreak();
                yield return lineBreak();
            }
            if (Vars.hospB == 0 || Vars.hospB == "")
            {
                yield return text("Dr. ");
                yield return text(Vars.nameB);
                yield return text(" Jr. must immediately lose 6VP and discard an Estate Upgrade of their choice.");
                yield return lineBreak();
                yield return lineBreak();
            }
            if (Vars.players > 2)
            {
                if (Vars.hospC == 0 || Vars.hospC == "")
                {
                    yield return text("Dr. ");
                    yield return text(Vars.nameC);
                    yield return text(" Jr. must immediately lose 6VP and discard an Estate Upgrade of their choice.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
            }
            if (Vars.players > 3)
            {
                if (Vars.hospD == 0 || Vars.hospD == "")
                {
                    yield return text("Dr. ");
                    yield return text(Vars.nameD);
                    yield return text(" Jr. must immediately lose 6VP and discard an Estate Upgrade of their choice.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
            }
            if (Vars.players > 4)
            {
                if (Vars.hospE == 0 || Vars.hospE == "")
                {
                    yield return text("Dr. ");
                    yield return text(Vars.nameE);
                    yield return text(" Jr. must immediately lose 6VP and discard an Estate Upgrade of their choice.");
                    yield return lineBreak();
                    yield return lineBreak();
                }
            }
            if (!(Vars.players > 4 ? Vars.hospA == "" || Vars.hospB == "" || Vars.hospC == "" || Vars.hospD == "" || Vars.hospE == "" || Vars.hospA == 0 || Vars.hospB == 0 || Vars.hospC == 0 || Vars.hospD == 0 || Vars.hospE == 0 :
                    Vars.players > 3 ? Vars.hospA == "" || Vars.hospB == "" || Vars.hospC == "" || Vars.hospD == "" || Vars.hospA == 0 || Vars.hospB == 0 || Vars.hospC == 0 || Vars.hospD == 0 :
                    Vars.players > 2 ? Vars.hospA == "" || Vars.hospB == "" || Vars.hospC == "" || Vars.hospA == 0 || Vars.hospB == 0 || Vars.hospC == 0 : Vars.hospA == "" || Vars.hospB == "" || Vars.hospA == 0 || Vars.hospB == 0))
            {
                yield return text("Dr. ");
                yield return text(Vars.nameA);
                yield return text(" Jr. must immediately lose 6VP and discard an Estate Upgrade of their choice.");
                yield return lineBreak();
                yield return lineBreak();
            }
        }
        yield return lineBreak();
        //yield return link("Click here to continue...", "NoHospitalCons", null);
        //yield return lineBreak();
        //if (Vars.hospcount == Vars.players)
        //{
        //    yield return abort(goToPassage: macros1.either("S5HospA1", "S5HospA2", "S5HospA3"));
        //}
        yield break;
    }

    IStoryThread passage132_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage132_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: EradicateDisease   (passage160)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 18567-18652
// Links:  ChooseScience
// Aborts: -
// Purpose: "The Cure": Yellow Fever Inoculation enters the common pool; routes to ChooseScience
// ###################################################################

    void passage160_Init()
    {
        this.Passages[@"EradicateDisease"] = new StoryPassage(@"EradicateDisease", new string[] { }, passage160_Main);
    }

    IStoryThread passage160_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Cure");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"They dined together on weekends, accepting hosting duties with a benign reciprocity. As such, many an evening's conversation descended into more hotly contested subjects of the time. No topic was more pervasive than disease. And most specifically, Yellow Fever; with the incessant sound of coughing and chiming of bells with every breeze.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While they agreed that for a ");
        if (Vars.players == 2)
        {
            yield return text("duo");
        }
        if (Vars.players == 3)
        {
            yield return text("trio");
        }
        if (Vars.players == 4)
        {
            yield return text("quartet");
        }
        if (Vars.players == 5)
        {
            yield return text("quintet");
        }
        yield return text(" ");
        yield return text(@"of respectable, infamous scholars, this problem should prove trivial, it was the actual curing effect that was hotly contested. The disease provided them a decent concealment for their surreptitious enterprise. Were they to become philanthropists, it may prove detrimental to secrecy.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("They decided to leave the matter up to personal pursuits. If someone felt industr" +
            "ious enough to complete it, then so be it.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage160_Fragment_1);
        using (styleScope("hook", "h000160"))
            yield return link("Click to continue...", null, () => enchantHook("h000160", HarloweEnchantCommand.Replace, passage160_Fragment_0));

        yield return lineBreak();
        yield break;
    }

    IStoryThread passage160_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "ChooseScience";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_YellowFeverInnoculation";
            yield return lineBreak();
            yield return text("Place the ");
            using (styleScope("bold", true))
            {
                yield return text("Yellow Fever Inoculation");
            }
            yield return text(" ");
            yield return text("Experiment near the game board. When taking a Perform Experiment action, any play" +
                "er may choose to complete this Experiment as if it were in their hand. ");
            using (styleScope("italic", true))
            {
                yield return text("There is no additional Generation Bonus for completing this Experiment.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "ChooseScience", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage160_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage160_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: RippedMasterwork   (passage164)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 19075-19149
// Links:  NoUniversityIntro
// Aborts: -
// Purpose: "Escaping The Curse": Masterwork schematics destroyed; Masterwork Experiments to the box
// ###################################################################

    void passage164_Init()
    {
        this.Passages[@"RippedMasterwork"] = new StoryPassage(@"RippedMasterwork", new string[] { }, passage164_Main);
    }

    IStoryThread passage164_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Escaping The Curse");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("In their late years, watching the town forsake science and wary colleagues abando" +
            "n them, the weight of the injustice was all too much to bear. With fists raised " +
            "to the sky, cursing the gods, they ended the generation in desperation!");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The records of this time do not mention any notes of collaboration, yet each individual experienced their own bout of isolation and self-destructive mania. In a rage, they stormed their laboratories and each shattered retort, each biological anomaly encased in formaldehyde, each rusted contraption that met its end against the concrete floor was a new moment of catharsis.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("They held in their hands the feeble-minded schematic passed down from generation " +
            "to generation, haunting them with its unattainable scientific pursuits, and unce" +
            "remoniously scattered the torn pages across the floor.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Finally, they we were free from this cursed legacy!");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage164_Fragment_1);
        using (styleScope("hook", "h000164"))
            yield return link("Click to continue...", null, () => enchantHook("h000164", HarloweEnchantCommand.Replace, passage164_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage164_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "NoUniversityIntro";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "MFWlogo";
            yield return lineBreak();
            yield return text("All players return their ");
            using (styleScope("bold", true))
            {
                yield return text("Masterwork Experiments");
            }
            yield return text(" ");
            yield return text("to the box.");
            yield return lineBreak();
            yield return lineBreak();
            if (Vars.tmmasterwork == "yes")
            {
                yield return text("The player with the Immortality Masterwork Upgrade discards it to the scenario box. They will no longer be penalized for not completing their Masterwork.");
                Vars.tmmasterwork = "no";
            }
            yield return lineBreak();
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "NoUniversityIntro", null);
        yield break;
    }

    IStoryThread passage164_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage164_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: S5HospA2   (passage165)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 19154-19207
// Links:  UniversityIntro,RippedMasterwork
// Aborts: -
// Purpose: End-of-Hospital fate: University built vs not; branches UniversityIntro/RippedMasterwork
// ###################################################################

    void passage165_Init()
    {
        this.Passages[@"S5HospA2"] = new StoryPassage(@"S5HospA2", new string[] { "END", }, passage165_Main);
    }

    IStoryThread passage165_Main()
    {
        //yield return text("Remove all player pieces from the board and perform the End of a Generation. Any " +
        //    "");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens remaining on a player\'s Journal Track are returned to the supply.");
        //yield return lineBreak();
        //yield return lineBreak();
        if (Vars.uni == "yes")
        {
            using (styleScope("bold", true))
            {
                yield return text("A Foundation for Science");
            }
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("With the University built,");
            }
            yield return text(@" the town slowly embraced the advances of modern science. But, while progress certainly had its benefits, it was unclear if these surprisingly mediocre ""mad"" scientists were prepared for the changes that lay just ahead in a world of fairness and social change.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click to move to a more modern age...", "UniversityIntro", null);
        }
        //if (Vars.uni == "no")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("The Foundation Crumbles");
            }
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("With the University unbuilt,");
            }
            yield return text(" the townsfolk were swayed by the local diocese to shun the sciences and cling to " +
            "their faith. A swathe of ignorance encompassed the small town, as they moved tow" +
            "ards a simpler time with simpler solutions.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click to move to a more depressing time...", "RippedMasterwork", null);
        }
        string s = "Remove all player pieces from the board and perform the End of a Generation. Any <sprite=\"StorybookToken\" index=0> tokens remaining on a player's Journal Track are returned to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 6);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: PanaceaIntro   (passage167)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 19264-19339
// Links:  Hospital1,Hospital2,Hospital3
// Aborts: -
// Purpose: "Eradication Forever": Panacea Experiment enters the shared pool
// ###################################################################

    void passage167_Init()
    {
        this.Passages[@"PanaceaIntro"] = new StoryPassage(@"PanaceaIntro", new string[] { }, passage167_Main);
    }

    IStoryThread passage167_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Eradication Forever");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"Were they still not satisfied? The family pondered this as they enjoyed their morning tea on the veranda, peering over the countryside from behind their gothic spires while their experimentations simmered in the laboratories deep in their manors. The people, the scientists, the church; which institution would be the next to take exception to their important discoveries?");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A Cure-All, or Grecian Panacea, became the newest topic of considerable divisiven" +
            "ess. It was the logical next step. Some in the family dismissed it as a waste of" +
            " energy, while others valued it as a sought-after proposition.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage167_Fragment_1);
        using (styleScope("hook", "h000167"))
            yield return link("Click to continue...", null, () => enchantHook("h000167", HarloweEnchantCommand.Replace, passage167_Fragment_0));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage167_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 7 ? "Hospital1" : Vars.round == 8 ? "Hospital2" : "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Pancea";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Panacea: Cure for all Ailments");
            }
            yield return text(" ");
            yield return text("Experiment from the Scenario box and put it into play in view of all players. Whe" +
                "n taking a Perform Experiment action, any player may choose to complete this Exp" +
                "eriment as if it were in their hand. ");
            using (styleScope("italic", true))
            {
                yield return text("There is no additional Generation Bonus for completing this Experiment.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 7)
        //{
        //    yield return link("Click to continue...", "Hospital1", null);
        //}
        //if (Vars.round == 8)
        //{
        //    yield return link("Click to continue...", "Hospital2", null);
        //}
        //if (Vars.round == 9)
        //{
        //    yield return link("Click to continue...", "Hospital3", null);
        //}
        yield break;
    }

    IStoryThread passage167_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage167_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: 35VP   (passage168)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 19344-19440
// Links:  -
// Aborts: -
// Purpose: Last-place player chooses the penalty applied to whoever first reaches 35VP
// ###################################################################

    void passage168_Init()
    {
        this.Passages[@"35VP"] = new StoryPassage(@"35VP", new string[] { }, passage168_Main);
    }

    IStoryThread passage168_Main()
    {
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Carefully hand the Storybook to the player with the least VP.");
        }
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("If there is a tie, hand the Storybook to the player later in turn order last roun" +
            "d.");
        }
        yield return lineBreak();
        yield return lineBreak();
        //yield return text("Once you are ready, click here to reveal your secret conversation.");
        yield return lineBreak();
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage168_Fragment_3);
        using (styleScope("hook", "h000168"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000168", HarloweEnchantCommand.Replace, passage168_Fragment_2));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage168_Fragment_0()
    {
        Vars.thirtyFivevp = "creep";
        yield return abort(goToPassage: "Gen1Insanity-Yes2");
        yield break;
    }

    IStoryThread passage168_Fragment_1()
    {
        Vars.thirtyFivevp = "vp";
        yield return abort(goToPassage: "Gen1Insanity-Yes2");
        yield break;
    }

    IStoryThread passage168_Fragment_2()
    {
        using (styleScope("bold", true))
        {
            yield return text("Planned Destruction");
        }
        yield return lineBreak();
        yield return text(@"From the letters and journal entries of the young entrepreneurs, we can see a deeply seated rivalry between them, spurred onward by feelings of inadequacy, solitude, and betrayal. Nothing was more insidious than the moments when they actively sabotaged the work of others for their own benefit.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("The first player that reaches the 35VP mark:");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00149"))
            yield return link("Has a Nasty Rumor spread about them.", null, () => enchantHook("h00149", HarloweEnchantCommand.Replace, passage168_Fragment_0));
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("(They gain 2 ");
            yield return text("<sprite=\"Creepy_Icon\" index=0>");
            yield return text(" ");
            yield return text("and 1 ");
            yield return text("<sprite=\"Insanity_Icon\" index=0>");
            yield return text(".)");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("OR");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00150"))
            yield return link("Has an unfortunate accident.", null, () => enchantHook("h00150", HarloweEnchantCommand.Replace, passage168_Fragment_1));
        yield return text(" ");
        using (styleScope("italic", true))
        {
            yield return text("(They immediately lose 4VP and an Estate Upgrade of their choice.)");
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage168_Fragment_3()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage168_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: ImmortalitySetup   (passage224)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 24670-24756
// Links:  Gen1Creepy-RefuseBonus
// Aborts: -
// Purpose: "To Infinity" setup: Storybook token on level 3 of a chosen Journal track (ORPHANED)
// ###################################################################

    void passage224_Init()
    {
        this.Passages[@"ImmortalitySetup"] = new StoryPassage(@"ImmortalitySetup", new string[] { }, passage224_Main);
    }

    IStoryThread passage224_Main()
    {

        ViewItemObtain.SetupPassagename = (Vars.seedy == "no") ? "Gen1Creepy-RefuseBonus" : (Vars.seedy == "yes") ? "Gen1Creepy-AgreedReturn" : "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                yield return text("To Infinity");
            }
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "StorybookToken";
            yield return lineBreak();
            yield return text("Give each player a ");
            using (styleScope("bold", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" ");
                yield return text("token");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Each player chooses an incomplete track of their choice in their Journal and plac" +
                "es their ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            yield return text("token on the third level of that track.");
        }

        yield return lineBreak();
        //yield return lineBreak();
        ////yield return enchantIntoLink("Click to continue...", passage224_Fragment_1);
        //using (styleScope("hook", "h000224"))
        //    yield return link("Click to continue...", null, () => enchantHook("h000224", HarloweEnchantCommand.Replace, passage224_Fragment_0));
        yield break;
    }

    IStoryThread passage224_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = (Vars.seedy == "no") ? "Gen1Creepy-RefuseBonus" : (Vars.seedy == "yes") ? "Gen1Creepy-AgreedReturn" : "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "StorybookToken";
            yield return lineBreak();
            yield return text("Give each player a ");
            using (styleScope("bold", true))
            {
                yield return text("<sprite=\"Storybook\" index=0>");
                yield return text(" ");
                yield return text("token");
            }
            yield return text(".");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Each player chooses an incomplete track of their choice in their Journal and plac" +
                "es their ");
            yield return text("<sprite=\"Storybook\" index=0>");
            yield return text(" ");
            yield return text("token on the third level of that track.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Gen1Creepy-RefuseBonus", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage224_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage224_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: SymposiumMiddle   (passage231)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25643-25723
// Links:  SymposiumSuccess,SymposiumFail
// Aborts: -
// Purpose: Symposium critics' verdict; hinges on publishing the inoculation; decides the University
// ###################################################################

    void passage231_Init()
    {
        this.Passages[@"SymposiumMiddle"] = new StoryPassage(@"SymposiumMiddle", new string[] { }, passage231_Main);
    }

    IStoryThread passage231_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Cure for Yellow Fever");
        }
        yield return lineBreak();
        if (Vars.SymposiumMiddlenextPsg == "" || Vars.SymposiumMiddlenextPsg == 0)
        {
            Vars.SymposiumMiddlenextPsg = macros1.either(1, 2, 3);
        }
        Vars.midquote = Vars.SymposiumMiddlenextPsg;
        yield return lineBreak();
        yield return text("\"Vague, tawdry.\" The notes from the lectures created a tableau of mixed reactions" +
            ". ");
        if (Vars.midquote == 1)
        {
            yield return text("\"All angst and ambition without respect for traditional ethics or the scientific " +
            "method. Unsupported hypotheses, and rapid-fire homeopathic conjecture.\"");
        }
        else if (Vars.midquote == 2)
        {
            yield return text("\"Of note, however, was one intriguing if not juvenile statement. I jotted the quo" +
            "te down for posterity and so that others at the state may enjoy it when I plaste" +
            "r the message all across the lavatories. The quote:");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("\'It\'s simple. Wash your hands after you touch your butt.\'\"");
        }
        //if (Vars.midquote == 3)
        else
        {
            yield return text("\"Delightfully crude, but potentially insightful. Overall though, the lectures wer" +
            "e amusing for what they lacked in substance.\"");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"At first they seemed intrigued, but the presentations, while exciting, proved to have only minimal scientific value in their eyes. It was decided by the majority to research any other notable discoveries in their portfolio before making their recommendations.");
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.pub == "yes")
        {
            yield return text("And it was the ");
            using (styleScope("bold", true))
            {
                yield return text("publication");
            }
            yield return text(" of a ");
            using (styleScope("bold", true))
            {
                yield return text("Yellow Fever");
            }
            yield return text(" inoculation from an otherwise unknown town in Hungary that made their decision to" +
            " build a University in the region much easier.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "SymposiumSuccess", null);
        }
        else
        {
            yield return text("And without the publication of a proposed ");
            using (styleScope("bold", true))
            {
                yield return text("Yellow Fever");
            }
            yield return text(" inoculation, their decision on the value of a university in a small town in Hunga" +
            "ry was easy to make.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "SymposiumFail", null);
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: NoHospitalCons   (passage235)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 25866-26024
// Links:  -
// Aborts: -
// Purpose: Reward for solo labor when the Hospital was neglected: advance a Journal track
// ###################################################################

    void passage235_Init()
    {
        this.Passages[@"NoHospitalCons"] = new StoryPassage(@"NoHospitalCons", new string[] { }, passage235_Main);
    }

    IStoryThread passage235_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("A Steady Focus");
        }
        yield return lineBreak();
        yield return text(@"For members of this ignoble family, it was not uncommon for personal labors to consume an individual's waking thoughts and cause them to forget even the most simplistic of instructions. But for those that toiled endlessly on their infernal schemes, their reward - aside from obesity and appalling hygiene - was one of a deeper understanding.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("click here to determine the Fate of the Town.", passage235_Fragment_2);
        using (styleScope("hook", "h000235"))
            yield return link("Click to continue...", null, () => enchantHook("h000235", HarloweEnchantCommand.Replace, passage235_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage235_Fragment_0()
    {
        yield return abort(goToPassage: macros1.either("S5HospA1", "S5HospA2", "S5HospA3"));
        yield break;
    }

    IStoryThread passage235_Fragment_1()
    {
        //yield return lineBreak();
        if (Vars.NoHospitalConsnextPsg == "" || Vars.NoHospitalConsnextPsg == 0)
        {
            Vars.NoHospitalConsnextPsg = macros1.either("S5HospA1", "S5HospA2", "S5HospA3");
        }
        ViewItemObtain.SetupPassagename = Vars.NoHospitalConsnextPsg;
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "AdvanceJournalTrack";
            yield return lineBreak();
            yield return lineBreak();
            if (Vars.hospA == 0 || Vars.hospA == "")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Dr. ");
                    yield return text(Vars.nameA);
                    yield return text(" III");
                }
                yield return lineBreak();
                yield return text("Move forward ");
                using (styleScope("bold", true))
                {
                    yield return text("1 level on the Journal Track of your choice");
                }
                yield return text(".");
                yield return lineBreak();
                yield return lineBreak();
            }
            if (Vars.hospB == 0 || Vars.hospB == "")
            {
                using (styleScope("bold", true))
                {
                    yield return text("Dr. ");
                    yield return text(Vars.nameB);
                    yield return text(" III");
                }
                yield return lineBreak();
                yield return text("Move forward ");
                using (styleScope("bold", true))
                {
                    yield return text("1 level on the Journal Track of your choice");
                }
                yield return text(".");
                yield return lineBreak();
                yield return lineBreak();
            }
            if (Vars.players > 2)
            {
                if (Vars.hospC == 0 || Vars.hospC == "")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Dr. ");
                        yield return text(Vars.nameC);
                        yield return text(" III");
                    }
                    yield return lineBreak();
                    yield return text("Move forward ");
                    using (styleScope("bold", true))
                    {
                        yield return text("1 level on the Journal Track of your choice");
                    }
                    yield return text(".");
                    yield return lineBreak();
                    yield return lineBreak();
                }
            }
            if (Vars.players > 3)
            {
                if (Vars.hospD == 0 || Vars.hospD == "")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Dr. ");
                        yield return text(Vars.nameD);
                        yield return text(" III");
                    }
                    yield return lineBreak();
                    yield return text("Move forward ");
                    using (styleScope("bold", true))
                    {
                        yield return text("1 level on the Journal Track of your choice");
                    }
                    yield return text(".");
                    yield return lineBreak();
                    yield return lineBreak();
                }
            }
            if (Vars.players > 4)
            {
                if (Vars.hospE == 0 || Vars.hospE == "")
                {
                    using (styleScope("bold", true))
                    {
                        yield return text("Dr. ");
                        yield return text(Vars.nameE);
                        yield return text(" III");
                    }
                    yield return lineBreak();
                    yield return text("Move forward ");
                    using (styleScope("bold", true))
                    {
                        yield return text("1 level on the Journal Track of your choice");
                    }
                    yield return text(".");
                    yield return lineBreak();
                    yield return lineBreak();
                }
            }
            yield return lineBreak();
            //yield return text("Once this assistance has been resolved, determine the Fate of the Town.");
        }
        //using (styleScope("hook", "h00182"))
        //    yield return link("click here to determine the Fate of the Town.", null, () => enchantHook("h00182", HarloweEnchantCommand.Replace, passage235_Fragment_0));
        yield break;
    }

    IStoryThread passage235_Fragment_2()
    {
        yield return enchant("click here to determine the Fate of the Town.", HarloweEnchantCommand.Replace, passage235_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: S5HospA3   (passage236)
// Tags: END
// Source: TheCostofDiseaseEng.cs lines 26029-26118
// Links:  RippedMasterwork,UniversityIntro
// Aborts: -
// Purpose: Generation-ending branch: RippedMasterwork (no university) or UniversityIntro
// ###################################################################

    void passage236_Init()
    {
        this.Passages[@"S5HospA3"] = new StoryPassage(@"S5HospA3", new string[] { "END", }, passage236_Main);
    }

    IStoryThread passage236_Main()
    {
        //yield return text("Remove all player pieces from the board and Perform the End of a Generation. Any " +
        //    "");
        //yield return text("<sprite=\"Storybook\" index=0>");
        //yield return text(" ");
        //yield return text("tokens remaining on a player\'s Journal Track are returned to the supply.");
        //yield return lineBreak();
        //yield return lineBreak();
        if (Vars.pana == 0 || Vars.pana == "")
        {
            using (styleScope("bold", true))
            {
                yield return text("Relentless Opposition");
            }
            yield return lineBreak();
            yield return text("The church\'s distrust of science has riled up the populace. Contributions to the " +
            "Hospital\'s original construction notwithstanding, without the hope provided by a" +
            " ");
            using (styleScope("bold", true))
            {
                yield return text("Panacea");
            }
            yield return text(" to remove ailments en masse, the townsfolk became determined to return to the old" +
            " ways.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("A most pitiful display that led to stagnation and the return of the pestilence th" +
            "at once was eliminated from the land.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "RippedMasterwork", null);
        }
        else if (Vars.pana == "unleash")
        {
            using (styleScope("bold", true))
            {
                yield return text("Relentless Opposition");
            }
            yield return lineBreak();
            yield return text("The church\'s distrust of science has riled up the populace. Contributions to the " +
            "Hospital\'s original construction notwithstanding, the nonsensical decision to ");
            using (styleScope("bold", true))
            {
                yield return text("unleash");
            }
            yield return text(" the proposed Panacea resulted in a loss of the original formula. Without the hope" +
            " provided by a ");
            using (styleScope("bold", true))
            {
                yield return text("Panacea");
            }
            yield return text(" to remove ailments en masse, the townsfolk became determined to return to the old" +
            " ways.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("A most pitiful display that led to stagnation and the return of the pestilence th" +
            "at once was eliminated from the land.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "RippedMasterwork", null);
        }
        //if (Vars.pana == "publish")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("The Allure of Discovery");
            }
            yield return lineBreak();
            yield return text(@"While the Panacea proposed may not have approached the problem in an ethical nor fiscally responsible way, the simple gesture garnered much attention from the academic community. Along with the famed discovery of a ""cure"" for Yellow Fever, this potential for scientific advancement was too strong to ignore.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The family soon found a rapt audience for their unconventional experimentations, " +
            "despite all logic running counter to this development, and the city entered into" +
            " a golden age of progress.");
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click here to continue...", "UniversityIntro", null);
        }
        string s = "Remove all player pieces from the board and perform the End of a Generation. Any <sprite=\"StorybookToken\" index=0> tokens remaining on a player's Journal Track are returned to the supply.";
        ViewEndOfGeneration.S_OnEndOfGeneration?.Invoke(s, 6);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: YellowFeverCureSignin   (passage241)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26630-26717
// Links:  -
// Aborts: -
// Purpose: Asks which player completed the Yellow Fever Inoculation Experiment
// ###################################################################

    void passage241_Init()
    {
        this.Passages[@"YellowFeverCureSignin"] = new StoryPassage(@"YellowFeverCureSignin", new string[] { }, passage241_Main);
    }

    IStoryThread passage241_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Yellow Fever Inoculation");
        }
        yield return lineBreak();
        yield return text(@"Through sheer perseverance and months of exposing both themselves, their spouse, all their servants, and several delivery persons to potential curing agents in different hues of yellow, a surprisingly effective solution was created that could be administered intravenously.");
        yield return lineBreak();
        Vars.twopage = 1;
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Which individual completed the Yellow Fever Inoculation Experiment?");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00183"))
            yield return link("Dr. " + Vars.nameA + " Jr.", null, () => enchantHook("h00183", HarloweEnchantCommand.Replace, passage241_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00184"))
            yield return link("Dr. " + Vars.nameB + " Jr.", null, () => enchantHook("h00184", HarloweEnchantCommand.Replace, passage241_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.players > 2)
        {
            using (styleScope("hook", "h00185"))
                yield return link("Dr. " + Vars.nameC + " Jr.", null, () => enchantHook("h00185", HarloweEnchantCommand.Replace, passage241_Fragment_2));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 3)
        {
            using (styleScope("hook", "h00186"))
                yield return link("Dr. " + Vars.nameD + " Jr.", null, () => enchantHook("h00186", HarloweEnchantCommand.Replace, passage241_Fragment_3));
            yield return lineBreak();
            yield return lineBreak();
        }
        if (Vars.players > 4)
        {
            using (styleScope("hook", "h00187"))
                yield return link("Dr. " + Vars.nameE + " Jr.", null, () => enchantHook("h00187", HarloweEnchantCommand.Replace, passage241_Fragment_4));
            yield return lineBreak();
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage241_Fragment_0()
    {
        Vars.fevercure = Vars.nameA;
        yield return abort(goToPassage: "Unicure");
        yield break;
    }

    IStoryThread passage241_Fragment_1()
    {
        Vars.fevercure = Vars.nameB;
        yield return abort(goToPassage: "Unicure");
        yield break;
    }

    IStoryThread passage241_Fragment_2()
    {
        Vars.fevercure = Vars.nameC;
        yield return abort(goToPassage: "Unicure");
        yield break;
    }

    IStoryThread passage241_Fragment_3()
    {
        Vars.fevercure = Vars.nameD;
        yield return abort(goToPassage: "Unicure");
        yield break;
    }

    IStoryThread passage241_Fragment_4()
    {
        Vars.fevercure = Vars.nameE;
        yield return abort(goToPassage: "Unicure");
        yield break;
    }

// ###################################################################
// PASSAGE: University   (passage242)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26722-26736
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: University (pay $1 to gain a Caretaker from Lost)
// ###################################################################

    void passage242_Init()
    {
        this.Passages[@"University"] = new StoryPassage(@"University", new string[] { }, passage242_Main);
    }

    IStoryThread passage242_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("University");
        }
        yield return lineBreak();
        yield return text("Pay $1 to gain a Caretaker from Lost and place it in your Quarters. ");
        yield break;
    }

// ###################################################################
// PASSAGE: 3ExperimentsRes   (passage249)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26905-27027
// Links:  -
// Aborts: -
// Purpose: Reward for 3 Experiments: patrons grant a Master's Study vanity upgrade
// ###################################################################

    void passage249_Init()
    {
        this.Passages[@"3ExperimentsRes"] = new StoryPassage(@"3ExperimentsRes", new string[] { }, passage249_Main);
    }

    IStoryThread passage249_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Advancements in ");
            yield return text(Vars.sci3);
        }
        yield return lineBreak();
        yield return text(@"As the years ambled onward and the peculiarities of their experimentations became more complex, it was not unheard of for the family to submit discoveries to scientific and medical journals. While most were summarily rejected, this constant stream of inquiries sometimes resulted in visits from interested parties.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("One such visitation occurred at the laboratory of ");
        yield return text(Vars.gen2exp);
        yield return text(". While frightening to behold at first, they were intrigued by the exceedingly co" +
            "mplex ");
        if (Vars.sci3 == "Biology")
        {
            yield return text("display of colorful Chemicals and unique specimens collected (and created) over t" +
            "ime.");
        }
        if (Vars.sci3 == "Chemistry")
        {
            yield return text("labyrinthine weaving of rubber tubing, chemicals, and simmering beakers of variou" +
            "s shapes and sizes along the walls.");
        }
        if (Vars.sci3 == "Engineering")
        {
            yield return text("vestibule filled with electrical coils, switches, dials, and several large metal " +
            "cabinets with blinking red lights (a dazzling rarity in that age).");
        }
        yield return text(" ");
        yield return text("Certainly immense strides forward had been made in ");
        yield return text(Vars.sci3);
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("It was only natural that they provided encouragement and financial resources to h" +
            "elp preserve this unique arrangement. Especially after being informed that it wa" +
            "s the only way they would leave the premises unaltered.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage249_Fragment_2);
        using (styleScope("hook", "h000249"))
            yield return link("Click to continue...", null, () => enchantHook("h000249", HarloweEnchantCommand.Replace, passage249_Fragment_1));
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage249_Fragment_0()
    {
        yield return lineBreak();
        if (Vars.round == 7)
        {
            Vars.sciadv = 1;
            yield return abort(goToPassage: "Hospital1");
        }
        //yield return lineBreak();
        else if (Vars.round == 8)
        {
            Vars.sciadv = 1;
            yield return abort(goToPassage: "Hospital2");
        }
        //yield return lineBreak();
        //if (Vars.round == 9)
        else
        {
            Vars.sciadv = 1;
            yield return abort(goToPassage: "Hospital3");
        }
        yield break;
    }

    IStoryThread passage249_Fragment_1()
    {
        //yield return lineBreak();
        Vars.sciadv = 1;
        ViewItemObtain.SetupPassagename = Vars.round == 7 ? "Hospital1" : Vars.round == 8 ? "Hospital2" : "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MastersStudy";
            yield return lineBreak();
            using (styleScope("bold", true))
            {
                yield return text("Retrieve the ");
                yield return text(Vars.sci3);
                yield return text(" ");
                yield return text("Master\'s Study Vanity Estate Upgrade from the scenario box and add it to your Est" +
                "ate.");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("You must still pay any required costs if you place it a new plot.");
            }
            //yield return text(" ");
            //yield return text("Then, return the ");
            //yield return text("<sprite=\"Storybook\" index=0>");
            //yield return text(" ");
            //yield return text("token to the supply.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00188"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00188", HarloweEnchantCommand.Replace, passage249_Fragment_0));
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage249_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage249_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: PanaceaMessage   (passage250)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27032-27146
// Links:  -
// Aborts: -
// Purpose: Secret screen: the Panacea's lethal side effects; publish or unleash
// ###################################################################

    void passage250_Init()
    {
        this.Passages[@"PanaceaMessage"] = new StoryPassage(@"PanaceaMessage", new string[] { }, passage250_Main);
    }

    IStoryThread passage250_Main()
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
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage250_Fragment_5);
        using (styleScope("hook", "h000250"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000250", HarloweEnchantCommand.Replace, passage250_Fragment_4));
        yield break;
    }

    IStoryThread passage250_Fragment_0()
    {
        Vars.cured = 2;
        Vars.pana = "publish";
        yield return abort(goToPassage: "Panacea1");
        yield break;
    }

    IStoryThread passage250_Fragment_1()
    {
        Vars.cured = 2;
        Vars.pana = "unleash";
        yield return abort(goToPassage: "Hospital1");
        yield break;
    }

    IStoryThread passage250_Fragment_2()
    {
        Vars.cured = 2;
        Vars.pana = "unleash";
        yield return abort(goToPassage: "Hospital2");
        yield break;
    }

    IStoryThread passage250_Fragment_3()
    {
        Vars.cured = 2;
        Vars.pana = "unleash";
        yield return abort(goToPassage: "PanaceaTooOld");
        yield break;
    }

    IStoryThread passage250_Fragment_4()
    {
        using (styleScope("bold", true))
        {
            yield return text("Unintended Results");
        }
        yield return lineBreak();
        yield return text(@"The dedication to the task was clear. My research unearthed several journals filled with line after line of a single mathematical formula, handwritten and repeated ad nauseam, followed by a chemical formula with slight alterations over time. The obsession literally spanned volumes and eventually paid large dividends.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("While technically the resulting solution did in fact \"cure\" all diseases, it also" +
            " resulted in the death of the test subject, the liquification of their bones, di" +
            "ssolution of skin, and eventually five meters of solid ground in the affected ar" +
            "ea.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("A concoction such as this, despite its volatile nature, could offer legitimate sc" +
            "ientific benefits upon publication. However, there were, of course, other option" +
            "s...");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("CHOOSE:");
        }
        yield return lineBreak();
        using (styleScope("bold", true))
        {
            yield return text("Do you wish to publish your findings or would you like unleash your creation on y" +
            "our rivals?");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00189"))
            yield return link("Publish my findings for fame.", null, () => enchantHook("h00189", HarloweEnchantCommand.Replace, passage250_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        if (Vars.round == 7)
        {
            using (styleScope("hook", "h00190"))
                yield return link("Unleash my creation!", null, () => enchantHook("h00190", HarloweEnchantCommand.Replace, passage250_Fragment_1));
        }
        else if (Vars.round == 8)
        {
            using (styleScope("hook", "h00191"))
                yield return link("Unleash my creation!", null, () => enchantHook("h00191", HarloweEnchantCommand.Replace, passage250_Fragment_2));
        }
        else //if (Vars.round == 9)
        {
            using (styleScope("hook", "h00192"))
                yield return link("Unleash my creation!", null, () => enchantHook("h00192", HarloweEnchantCommand.Replace, passage250_Fragment_3));
        }
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage250_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage250_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: ImmortalityMWUpdate   (passage251)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27151-27219
// Links:  -
// Aborts: -
// Purpose: Checks whether any player holds the Immortality Masterwork
// ###################################################################

    void passage251_Init()
    {
        this.Passages[@"ImmortalityMWUpdate"] = new StoryPassage(@"ImmortalityMWUpdate", new string[] { }, passage251_Main);
    }

    IStoryThread passage251_Main()
    {
        if (Vars.setinf > 0)
        {
            if (Vars.round == 8)
            {
                yield return abort(goToPassage: "Hospital2");
            }
            //if (Vars.round == 9)
            else
            {
                yield return abort(goToPassage: "Hospital3");
            }
        }
        using (styleScope("bold", true))
        {
            yield return text("The True Secret");
        }
        yield return lineBreak();
        yield return text("The family\'s pursuit of everlasting life brought new and inspirational concepts t" +
            "o the forefront. These ideas could verify the seemingly untenable Masterwork blu" +
            "eprints created by their Grandfather.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Does any player have the ");
        using (styleScope("bold", true))
        {
            yield return text("Immortality");
        }
        yield return text(" ");
        yield return text("Masterwork Experiment?");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00193"))
            yield return link("Yes.", null, () => enchantHook("h00193", HarloweEnchantCommand.Replace, passage251_Fragment_0));
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00194"))
            yield return link("No.", null, () => enchantHook("h00194", HarloweEnchantCommand.Replace, passage251_Fragment_1));
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage251_Fragment_0()
    {
        Vars.immort = "yes";
        yield return abort(goToPassage: "ImmortalityMWUpdate2");
        yield break;
    }

    IStoryThread passage251_Fragment_1()
    {
        Vars.setinf = 1;
        if (Vars.round == 8)
        {
            yield return abort(goToPassage: "Hospital2");
        }
        //if (Vars.round == 9)
        else
        {
            yield return abort(goToPassage: "Hospital3");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: ImmortalityMWUpdate2   (passage252)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27224-27304
// Links:  -
// Aborts: -
// Purpose: Grants the Immortality Masterwork Update card
// ###################################################################

    void passage252_Init()
    {
        this.Passages[@"ImmortalityMWUpdate2"] = new StoryPassage(@"ImmortalityMWUpdate2", new string[] { }, passage252_Main);
    }

    IStoryThread passage252_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("The Possibility Exists");
        }
        yield return lineBreak();
        yield return text("The thoughts consumed their waking hours, compelling them to action. Surely if a " +
            "form of ");
        using (styleScope("bold", true))
        {
            yield return text("Immortality");
        }
        yield return text(" ");
        yield return text("can be so readily created by the family, then a more perfected version was just o" +
            "n the horizon. It would need to be done. It had to be done, or the shame they fe" +
            "lt would weigh heavily on everything their exceptional lineage had created thus " +
            "far.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage252_Fragment_2);
        using (styleScope("hook", "h000252"))
            yield return link("Click to continue...", null, () => enchantHook("h000252", HarloweEnchantCommand.Replace, passage252_Fragment_1));
        yield break;
    }

    IStoryThread passage252_Fragment_0()
    {
        Vars.setinf = 1;
        if (Vars.round == 8)
        {
            yield return abort(goToPassage: "Hospital2");
        }
        //if (Vars.round == 9)
        else
        {
            yield return abort(goToPassage: "Hospital3");
        }
        yield break;
    }

    IStoryThread passage252_Fragment_1()
    {
        //yield return lineBreak();
        Vars.setinf = 1;
        ViewItemObtain.SetupPassagename = Vars.round == 8 ? "Hospital2" : "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_MWUpdateImmortality";
            yield return lineBreak();
            yield return text("Retrieve the ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality");
            }
            yield return text(" ");
            yield return text("Masterwork Update card from the Scenario box and give it to the player working to" +
                "wards this Masterwork.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00195"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00195", HarloweEnchantCommand.Replace, passage252_Fragment_0));
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage252_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage252_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: SymposiumEvent2   (passage255)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 27427-27485
// Links:  SymposiumEvent3
// Aborts: -
// Purpose: Symposium lectures scene: each cousin presents their gruesome work
// ###################################################################

    void passage255_Init()
    {
        this.Passages[@"SymposiumEvent2"] = new StoryPassage(@"SymposiumEvent2", new string[] { }, passage255_Main);
    }

    IStoryThread passage255_Main()
    {
        if (Vars.players == 2)
        {
            Vars.symp = macros1.random(3, 4);
        }
        else if (Vars.players == 3)
        {
            Vars.symp = macros1.random(4, 6);
        }
        else if (Vars.players == 4)
        {
            Vars.symp = macros1.random(6, 8);
        }
        else if (Vars.players == 5)
        {
            Vars.symp = macros1.random(8, 10);
        }
        using (styleScope("bold", true))
        {
            yield return text("For the Advancement of ");
            yield return text(Vars.sci3);
        }
        yield return lineBreak();
        yield return text("The symposium began with a series of lectures from various noted ");
        if (Vars.sci3 == "Biology")
        {
            yield return text("biologists");
        }
        else if (Vars.sci3 == "Chemistry")
        {
            yield return text("chemists");
        }
        //if (Vars.sci3 == "Engineering")
        else
        {
            yield return text("engineers");
        }
        yield return text(" ");
        yield return text("from Eastern Europe. When it was their time to present, each cousin in turn rolle" +
            "d in a large cart covered with a velvet blanket to conceal their work until the " +
            "appropriate moment during the lecture.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"As noted by several critics, each family member went well over their allotted time, providing eye-opening live demonstrations during the peak of their lectures that required many in the first rows of the operating theater to change into a clean outfit after the end of the exhibition.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("The spirited presentations stunned the community to abject silence.");
        yield return lineBreak();
        yield return lineBreak();
        yield return link("Click to continue...", "SymposiumEvent3", null);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Creepy-RefuseBonus   (passage300)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 30890-31093
// Links:  Gen1Creepy-AgreedReturn
// Aborts: -
// Purpose: Hospital-branch strange visit: free Reading Room or Shrine for the parent's refusal
// ###################################################################

    void passage300_Init()
    {
        this.Passages[@"Gen1Creepy-RefuseBonus"] = new StoryPassage(@"Gen1Creepy-RefuseBonus", new string[] { }, passage300_Main);
    }

    IStoryThread passage300_Main()
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
        //yield return enchantIntoLink("Once you are ready, click here to reveal your secret conversation.", passage300_Fragment_5);
        using (styleScope("hook", "h000300"))
            yield return link("Once you are ready, click here to reveal your secret conversation.", null, () => enchantHook("h000300", HarloweEnchantCommand.Replace, passage300_Fragment_4));
        yield return lineBreak();
        //}
        //else
        //{
        //    yield return abort(goToPassage: "Gen1Creepy-AgreedReturn");
        //}
        yield break;
    }

    IStoryThread passage300_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = (Vars.seedy == "yes") ? "Gen1Creepy-AgreedReturn" : "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Insanity_Icon";
            yield return lineBreak();
            yield return text("You may choose to immediately retrieve and build the ");
            using (styleScope("bold", true))
            {
                yield return text("Reading Room");
            }
            yield return text(" Estate Upgrade at no cost. ");
            using (styleScope("italic", true))
            {
                yield return text("However, you must still pay any costs related to expanding into a new estate plot" +
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
                "ce a Servant or Spouse onto this tile to ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2 ");
                yield return text("<sprite=\"Insanity_Icon\" index=0>");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Gen1Creepy-AgreedReturn", null);
        yield break;
    }

    IStoryThread passage300_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage300_Fragment_0);
        yield break;
    }

    IStoryThread passage300_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = (Vars.seedy == "yes") ? "Gen1Creepy-AgreedReturn" : "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Creepy_Icon";
            yield return lineBreak();
            yield return text("You may choose to immediately retrieve and build the ");
            using (styleScope("bold", true))
            {
                yield return text("Shrine");
            }
            yield return text(" Estate Upgrade at no cost. ");
            using (styleScope("italic", true))
            {
                yield return text("However, you must still pay any costs related to expanding into a new estate plot" +
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
                "ce a Servant or Spouse onto this tile to ");
            using (styleScope("bold", true))
            {
                yield return text("lose 2 ");
                yield return text("<sprite=\"Creepy_Icon\" index=0>");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //yield return link("Click to continue...", "Gen1Creepy-AgreedReturn", null);
        yield break;
    }

    IStoryThread passage300_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage300_Fragment_2);
        yield break;
    }

    IStoryThread passage300_Fragment_4()
    {
        if (Vars.wolves == "good")
        {
            using (styleScope("bold", true))
            {
                yield return text("A Strange Visit");
            }
            yield return lineBreak();
            yield return text("Consumed by the immense scientific enterprise they have undertaken, the cousins r" +
            "arely allowed moments to indulge visitation. However, after they had ignored sev" +
            "eral missives from a strange organization, a group of individuals arrived at ");
            yield return text(Vars.gen1creep);
            yield return text("\'s estate with an un-sprung cart full of building materials.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It appeared that they were aware of ");
            yield return text(Vars.gen1creep);
            yield return text("\'s ");
            using (styleScope("bold", true))
            {
                yield return text("parent\'s refusal");
            }
            yield return text(" to accept a suspicious gift, a refusal that avoided catastrophic consequences too" +
            " horrible to describe. Without further explanation though, they had procured the" +
            " necessary materials to construct a gift and were set upon the task immediately." +
            " ");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage300_Fragment_1);
            using (styleScope("hook", "h00030001"))
                yield return link("Click to continue...", null, () => enchantHook("h00030001", HarloweEnchantCommand.Replace, passage300_Fragment_0));
        }
        //if (Vars.hunters == "good")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("A Strange Visit");
            }
            yield return lineBreak();
            yield return text("Consumed by the immense scientific enterprise they have undertaken, the cousins r" +
            "arely allowed moments to indulge visitation. However, after they had ignored sev" +
            "eral missives from a strange organization, a group of individuals arrived at ");
            yield return text(Vars.gen1creep);
            yield return text("\'s estate with an un-sprung cart full of building materials.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It appeared that they were aware of ");
            yield return text(Vars.gen1creep);
            yield return text("\'s ");
            using (styleScope("bold", true))
            {
                yield return text("parent\'s refusal");
            }
            yield return text(" to accept a suspicious gift, a refusal that avoided catastrophic consequences too" +
            " horrible to describe. Without further explanation, they had procured the necess" +
            "ary materials to construct a gift and were set upon the task immediately. ");
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage300_Fragment_3);
            using (styleScope("hook", "h00030003"))
                yield return link("Click to continue...", null, () => enchantHook("h00030003", HarloweEnchantCommand.Replace, passage300_Fragment_2));
        }
        yield break;
    }

    IStoryThread passage300_Fragment_5()
    {
        yield return enchant("Once you are ready, click here to reveal your secret conversation.", HarloweEnchantCommand.Replace, passage300_Fragment_4);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Creepy-AgreedReturn   (passage301)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31098-31267
// Links:  Hospital2
// Aborts: -
// Purpose: Hospital-branch debt collection: discard an Experiment/Upgrade or pay $2
// ###################################################################

    void passage301_Init()
    {
        this.Passages[@"Gen1Creepy-AgreedReturn"] = new StoryPassage(@"Gen1Creepy-AgreedReturn", new string[] { }, passage301_Main);
    }

    IStoryThread passage301_Main()
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
        yield return lineBreak();
        if (Vars.wolves == "evil")
        {
            using (styleScope("bold", true))
            {
                yield return text("Order of St. Hubertus");
            }
            yield return lineBreak();
            yield return text("On an unseasonably warm evening with a thick fog obscuring their arrival, an oper" +
        "ative from the Order of St. Hubertus knocked upon the estate door. There, at the" +
        " entranceway with no intent to venture further, the man addressed ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("II in an authoritative tone.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"The man peered out from under his cloth hood, his eyes glowing with unnatural light. ""Though we no longer have claims to this region, our assistance is not given without cost. And your family's debt has come due,"" the man stated while several other cloaked individuals emerged from their carriage, small blades visibly clutched between their fingers.");
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return text("It seemed that decision of their parent had finally come to fruition. The gentlem" +
        "en were kind enough to offer ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("II a choice of debt repayment.");
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage301_Fragment_1);
            using (styleScope("hook", "h00030101"))
                yield return link("Click to continue...", null, () => enchantHook("h00030101", HarloweEnchantCommand.Replace, passage301_Fragment_0));
        }
        //yield return lineBreak();
        //if (Vars.hunters == "evil")
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("Fraternity of Hunters");
            }
            yield return lineBreak();
            yield return text("On an unseasonably warm evening with a thick fog obscuring their arrival, an oper" +
        "ative from the Fraternity of Hunters knocked upon the estate door. There, at the" +
        " entranceway with no intent to venture further, the man addressed ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("II in an authoritative tone.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text(@"""Though we no longer have claims to this region, our assistance is not given without cost. And your family's debt has come due. We kindly ask for immediate remuneration,"" the man stated while several other burly individuals emerged from their carriage, tapping various gleaming bludgeoning instruments against their palms.");
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return text("The gentlemen were kind enough to offer ");
            yield return text(Vars.gen1creep);
            yield return text(" ");
            yield return text("II a choice of debt repayment.");
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage301_Fragment_3);
            using (styleScope("hook", "h00030103"))
                yield return link("Click to continue...", null, () => enchantHook("h00030103", HarloweEnchantCommand.Replace, passage301_Fragment_2));
        }
        //}
        //else
        //{
        //    yield return abort(goToPassage: "Hospital2");
        //}
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage301_Fragment_0()
    {
        ViewItemObtain.SetupPassagename = "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Discard a ");
            using (styleScope("bold", true))
            {
                yield return text("completed Experiment (of B-Level or higher)");
            }
            yield return text(" ");
            yield return text("OR ");
            using (styleScope("bold", true))
            {
                yield return text("discard an Estate Upgrade Tile");
            }
            yield return text(" ");
            yield return text("(not a Storage Shed).");
        }
        //yield return lineBreak();
        //yield return link("Click to continue...", "Hospital2", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage301_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage301_Fragment_0);
        yield break;
    }

    IStoryThread passage301_Fragment_2()
    {
        ViewItemObtain.SetupPassagename = "Hospital2";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "DiscardEstateUpgrade_Icon";
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Pay ");
            using (styleScope("bold", true))
            {
                yield return text("$2 to the supply");
            }
            yield return text(" ");
            yield return text("OR ");
            using (styleScope("bold", true))
            {
                yield return text("discard an Estate Upgrade Tile");
            }
            yield return text(" ");
            yield return text("(not a Storage Shed).");
        }
        //yield return lineBreak();
        //yield return link("Click to continue...", "Hospital2", null);
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage301_Fragment_3()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage301_Fragment_2);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Insanity-Yes2   (passage303)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31361-31445
// Links:  Hospital1
// Aborts: -
// Purpose: Same "Absent Parent" penalty, reached from the Hospital-branch 35VP check
// ###################################################################

    void passage303_Init()
    {
        this.Passages[@"Gen1Insanity-Yes2"] = new StoryPassage(@"Gen1Insanity-Yes2", new string[] { }, passage303_Main);
    }

    IStoryThread passage303_Main()
    {
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
            yield return text("An investment in a summer home may have calmed their parent\'s nerves during times" +
            " of stress, but it also meant time away from the Estate. These increasingly freq" +
            "uent visits to rekindle sanity meant ");
            yield return text(Vars.gen1sane);
            yield return text(" ");
            yield return text("II\'s childhood guidance came more from the servants around the home than from the" +
            "ir parental figures. This left an unfortunate void in their psychological develo" +
            "pment, one that affected their actions for the remainder of their life.");
            if (Vars.Gen1Insanity_Yes2nextPsg == "" || Vars.Gen1Insanity_Yes2nextPsg == 0)
            {
                Vars.Gen1Insanity_Yes2nextPsg = macros1.either(1, 2);
            }
            Vars.instemp = Vars.Gen1Insanity_Yes2nextPsg;
            yield return lineBreak();
            yield return lineBreak();
            //yield return enchantIntoLink("Click to continue...", passage303_Fragment_1);
            using (styleScope("hook", "h000303"))
                yield return link("Click to continue...", null, () => enchantHook("h000303", HarloweEnchantCommand.Replace, passage303_Fragment_0));
        }
        else
        {
            yield return abort(goToPassage: "Hospital1");
        }
        yield break;
    }

    IStoryThread passage303_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = "Hospital1";
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
        //yield return link("Click to continue...", "Hospital1", null);
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage303_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage303_Fragment_0);
        yield break;
    }

// ###################################################################
// PASSAGE: Gen1Insanity-NoExtraAction   (passage304)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 31450-31570
// Links:  Hospital1,Hospital2,Hospital3
// Aborts: -
// Purpose: Gen1 refusal reward: return your Self to Quarters and take another action
// ###################################################################

    void passage304_Init()
    {
        this.Passages[@"Gen1Insanity-NoExtraAction"] = new StoryPassage(@"Gen1Insanity-NoExtraAction", new string[] { }, passage304_Main);
    }

    IStoryThread passage304_Main()
    {
        if (Vars.hospsign == Vars.gen1sane)
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
                yield return text("And so this matter of administrative duties was handled with the utmost brevity, " +
            "allowing them to focus on the monumental task at hand.");
                yield return lineBreak();
                yield return lineBreak();
                //yield return enchantIntoLink("Click to continue...", passage304_Fragment_1);
                using (styleScope("hook", "h000304"))
                    yield return link("Click to continue...", null, () => enchantHook("h000304", HarloweEnchantCommand.Replace, passage304_Fragment_0));
            }
            else
            {
                yield return lineBreak();
                if (Vars.round == 7)
                {
                    yield return abort(goToPassage: "Hospital1");
                }
                //yield return lineBreak();
                else if (Vars.round == 8)
                {
                    yield return abort(goToPassage: "Hospital2");
                }
                //yield return lineBreak();
                //if (Vars.round == 9)
                else
                {
                    yield return abort(goToPassage: "Hospital3");
                }
                yield return lineBreak();
            }
            yield return lineBreak();
        }
        else
        {
            //yield return lineBreak();
            if (Vars.round == 7)
            {
                yield return abort(goToPassage: "Hospital1");
            }
            //yield return lineBreak();
            else if (Vars.round == 8)
            {
                yield return abort(goToPassage: "Hospital2");
            }
            //yield return lineBreak();
            //if (Vars.round == 9)
            else
            {
                yield return abort(goToPassage: "Hospital3");
            }
            yield return lineBreak();
        }
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

    IStoryThread passage304_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 7 ? "Hospital1" : Vars.round == 8 ? "Hospital2" : "Hospital3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "Self";
            yield return lineBreak();
            yield return text("You may immediately return your ");
            using (styleScope("bold", true))
            {
                yield return text("Self");
            }
            yield return text(" ");
            yield return text("to your Quarters and take another action.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 7)
        //{
        //    yield return link("Click to return...", "Hospital1", null);
        //}
        //if (Vars.round == 8)
        //{
        //    yield return link("Click to return...", "Hospital2", null);
        //}
        //if (Vars.round == 9)
        //{
        //    yield return link("Click to return...", "Hospital3", null);
        //}
        yield break;
    }

    IStoryThread passage304_Fragment_1()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage304_Fragment_0);
        yield break;
    }
