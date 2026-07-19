// ===================================================================
// CHAPTER: Shared   (17 passages)
// Extracted from Scripts/StoryScript/TheCostofDiseaseEng.cs
// Reference copy - not compilable standalone (no class wrapper / VarDefs).
// Each passage = passageN_Init (registration) + passageN_Main + passageN_Fragment_*.
// ===================================================================

// --- Passage index -------------------------------------------------
// passage42    Library                      L5869-5894  Reference popup: Library action space (gain 1 non-Occult Knowledge)
// passage44    TheBank                      L5935-5949  Reference popup: Bank action space (gain $2)
// passage45    Hospital                     L5955-5981  Reference popup: Hospital action space (search a deck for an Experiment)
// passage90    DeteriorationHub             L10227-10256  Router returning the player from Deterioration effects to the right Gen3 hub
// passage91    DetEffect1                   L10262-10348  Immortality "Major Deleterious Effect": the immortal dies; cards discarded, Caretaker lost
// passage92    DetEffect2                   L10353-10429  Immortality "Minor Deleterious Effect": discard an Ingredient, draw a Compulsion
// passage93    DetEffect3                   L10434-10500  Immortality "Minor Deleterious Effect": mild aging; lose VP
// passage94    DetEffect4                   L10505-10534  Immortality "No Effect": the solution works flawlessly
// passage166   DetEffectRandom              L19213-19258  Immortality-consequence framing; links to EffectRandomizer
// passage243   Church                       L26742-26768  Town building tile reference: Church (pay to move back on the Creepy track)
// passage244   HardwareStore1               L26774-26800  Town building tile reference: Hardware Store (1 ingredient of choice, no bodies)
// passage245   BookStore3                   L26806-26832  Town building tile reference: Book Store (1 Knowledge of choice, not Occult)
// passage246   WireService2                 L26838-26852  Town building tile reference: Wire Service (gain $2)
// passage247   Warehouse4                   L26858-26879  Town building tile reference: Warehouse (pay $1 repeatedly to recover Servants)
// passage248   PetStore5                    L26885-26899  Town building tile reference: Pet Store (gain 2 Chemicals)
// passage279   EffectRandomizer             L28934-28972  CODE ONLY: shuffles the four DetEffect options, removes visited ones, aborts to a random one
// passage341   HereditaryDiseaseComplete    L34167-34232  Reward for curing the Hereditary Disease: flip the card to become immune for the Generation
// -------------------------------------------------------------------


// ###################################################################
// PASSAGE: Library   (passage42)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 5869-5894
// Links:  -
// Aborts: -
// Purpose: Reference popup: Library action space (gain 1 non-Occult Knowledge)
// ###################################################################

    void passage42_Init()
    {
        this.Passages[@"Library"] = new StoryPassage(@"Library", new string[] { }, passage42_Main);
    }

    IStoryThread passage42_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Library");
        }
        yield return lineBreak();
        yield return text("Gain 1 Knowledge of your choice. ");
        using (styleScope("italic", true))
        {
            yield return text("(Not Occult.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("If you place multiple pieces with this action, each Knowledge you gain may be of " +
            "the same or a different type.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: TheBank   (passage44)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 5935-5949
// Links:  -
// Aborts: -
// Purpose: Reference popup: Bank action space (gain $2)
// ###################################################################

    void passage44_Init()
    {
        this.Passages[@"TheBank"] = new StoryPassage(@"TheBank", new string[] { }, passage44_Main);
    }

    IStoryThread passage44_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Bank");
        }
        yield return lineBreak();
        yield return text("Gain $2.");
        yield break;
    }

// ###################################################################
// PASSAGE: Hospital   (passage45)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 5955-5981
// Links:  -
// Aborts: -
// Purpose: Reference popup: Hospital action space (search a deck for an Experiment)
// ###################################################################

    void passage45_Init()
    {
        this.Passages[@"Hospital"] = new StoryPassage(@"Hospital", new string[] { }, passage45_Main);
    }

    IStoryThread passage45_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Hospital");
        }
        yield return lineBreak();
        yield return text("Look through the deck of your choice to find an Experiment of your choice and dra" +
            "w it into your hand. ");
        using (styleScope("italic", true))
        {
            yield return text("(Once complete, shuffle the deck.)");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text("You have until the beginning of your next turn to complete this action ");
        using (styleScope("italic", true))
        {
            yield return text("(allow other players to begin their turn while you choose).");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: DeteriorationHub   (passage90)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10227-10256
// Links:  -
// Aborts: -
// Purpose: Router returning the player from Deterioration effects to the right Gen3 hub
// ###################################################################

    void passage90_Init()
    {
        this.Passages[@"DeteriorationHub"] = new StoryPassage(@"DeteriorationHub", new string[] { }, passage90_Main);
    }

    IStoryThread passage90_Main()
    {
        if (Vars.round == 16)
        {
            yield return abort(goToPassage: "NoUni2");
        }
        //yield return lineBreak();
        else if (Vars.round == 17)
        {
            yield return abort(goToPassage: "NoUni3");
        }
        else if (Vars.round == 19)
        {
            yield return abort(goToPassage: "University2");
        }
        //yield return lineBreak();
        //if (Vars.round == 20)
        else
        {
            yield return abort(goToPassage: "University3");
        }
        //yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: DetEffect1   (passage91)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10262-10348
// Links:  -
// Aborts: -
// Purpose: Immortality "Major Deleterious Effect": the immortal dies; cards discarded, Caretaker lost
// ###################################################################

    void passage91_Init()
    {
        this.Passages[@"DetEffect1"] = new StoryPassage(@"DetEffect1", new string[] { }, passage91_Main);
    }

    IStoryThread passage91_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Major Deleterious Effect");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"It could not continue. Sick and unable to heal again, stumbling blindly until the bones were brittle enough to snap, their bodies had finally failed them. And when the mind had joined the fragile physical form in its inability to perform the most basic of functions, the struggle ceased.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Death in all its inevitability had finally claimed them.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("Unfortunately, their body was in such an advanced state of degradation it could n" +
            "ot even be used for further experimentation. This made the grief more substantia" +
            "l.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage91_Fragment_2);
        using (styleScope("hook", "h00091"))
            yield return link("Click to continue...", null, () => enchantHook("h00091", HarloweEnchantCommand.Replace, passage91_Fragment_1));
        yield break;
    }

    IStoryThread passage91_Fragment_0()
    {
        Vars.det1 = "visited";
        Vars.killed = "yes";
        yield return abort(goToPassage: "DeteriorationHub");
        yield break;
    }

    IStoryThread passage91_Fragment_1()
    {
        //yield return lineBreak();
        Vars.det1 = "visited";
        Vars.killed = "yes";
        ViewItemObtain.SetupPassagename = "DeteriorationHub";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Immortality";
            yield return lineBreak();
            yield return text("Any player with an ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality card");
            }
            yield return text(" ");
            yield return text("discards a ");
            using (styleScope("bold", true))
            {
                yield return text("Caretaker");
            }
            yield return text(" ");
            yield return text("to Lost.");
            yield return lineBreak();
            yield return lineBreak();
            yield return text("Discard all ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality cards");
            }
            yield return text(" ");
            yield return text("to the scenario box.");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00031"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00031", HarloweEnchantCommand.Replace, passage91_Fragment_0));
        yield break;
    }

    IStoryThread passage91_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage91_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: DetEffect2   (passage92)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10353-10429
// Links:  -
// Aborts: -
// Purpose: Immortality "Minor Deleterious Effect": discard an Ingredient, draw a Compulsion
// ###################################################################

    void passage92_Init()
    {
        this.Passages[@"DetEffect2"] = new StoryPassage(@"DetEffect2", new string[] { }, passage92_Main);
    }

    IStoryThread passage92_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Minor Deleterious Effect");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"They feared that their hasty solution had borne upon them irreversible effects. The interior withered, the skin grayed and sagged translucently against the sinewy veins beneath. The ultimate cure had become a curse and life was like a festering wound that cut deeper with each passing day. Still, they continued on in their work, hoping the effects were temporary but fearing the worst. It took more and more resources to quell their pain each day.");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage92_Fragment_2);
        using (styleScope("hook", "h00092"))
            yield return link("Click to continue...", null, () => enchantHook("h00092", HarloweEnchantCommand.Replace, passage92_Fragment_1));
        yield break;
    }

    IStoryThread passage92_Fragment_0()
    {
        yield return abort(goToPassage: "DeteriorationHub");
        yield break;
    }

    IStoryThread passage92_Fragment_1()
    {
        //yield return lineBreak();
        Vars.det2 = "visited";
        ViewItemObtain.SetupPassagename = "DeteriorationHub";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Immortality";
            yield return lineBreak();
            yield return text("Any player with an ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality card");
            }
            yield return text(" ");
            yield return text("discards an ");
            using (styleScope("bold", true))
            {
                yield return text("Ingredient");
            }
            yield return text(" ");
            using (styleScope("italic", true))
            {
                yield return text("if possible");
            }
            yield return text(" ");
            yield return text("and ");
            using (styleScope("bold", true))
            {
                yield return text("draws a Compulsion");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00032"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00032", HarloweEnchantCommand.Replace, passage92_Fragment_0));
        yield break;
    }

    IStoryThread passage92_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage92_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: DetEffect3   (passage93)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10434-10500
// Links:  -
// Aborts: -
// Purpose: Immortality "Minor Deleterious Effect": mild aging; lose VP
// ###################################################################

    void passage93_Init()
    {
        this.Passages[@"DetEffect3"] = new StoryPassage(@"DetEffect3", new string[] { }, passage93_Main);
    }

    IStoryThread passage93_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Minor Deleterious Effect");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"All and all, the continued effects of their approach to Immortality had fared exceptionally well. While the skin displayed liver spots and an amount of vigor had been lost as the blood cooled with age, the effects were only a distraction. At most, a gangrenous finger had to be excised once every few years, but what was one extraneous extremity compared to the ability to assist in the most important scientific discoveries the world had ever known?");
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to continue...", passage93_Fragment_2);
        using (styleScope("hook", "h00093"))
            yield return link("Click to continue...", null, () => enchantHook("h00093", HarloweEnchantCommand.Replace, passage93_Fragment_1));
        yield break;
    }

    IStoryThread passage93_Fragment_0()
    {
        yield return abort(goToPassage: "DeteriorationHub");
        yield break;
    }

    IStoryThread passage93_Fragment_1()
    {
        //yield return lineBreak();
        Vars.det3 = "visited";
        ViewItemObtain.SetupPassagename = "DeteriorationHub";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SPECIAL SETUP");
            }
            Vars._SetupImage = "S1_Immortality";
            yield return lineBreak();
            yield return text("Any player with an ");
            using (styleScope("bold", true))
            {
                yield return text("Immortality card");
            }
            yield return text(" ");
            yield return text("loses ");
            using (styleScope("bold", true))
            {
                yield return text(macros1.either(1, 2));
                yield return text("VP");
            }
            yield return text(".");
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //using (styleScope("hook", "h00033"))
        //    yield return link("Click to continue...", null, () => enchantHook("h00033", HarloweEnchantCommand.Replace, passage93_Fragment_0));
        yield break;
    }

    IStoryThread passage93_Fragment_2()
    {
        yield return enchant("Click to continue...", HarloweEnchantCommand.Replace, passage93_Fragment_1);
        yield break;
    }

// ###################################################################
// PASSAGE: DetEffect4   (passage94)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 10505-10534
// Links:  -
// Aborts: -
// Purpose: Immortality "No Effect": the solution works flawlessly
// ###################################################################

    void passage94_Init()
    {
        this.Passages[@"DetEffect4"] = new StoryPassage(@"DetEffect4", new string[] { }, passage94_Main);
    }

    IStoryThread passage94_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("No Effect");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return text(@"The unthinkable had been achieved. Whether by sheer providence or remarkable display of intellect, the solution to immortality appeared to have worked! In fact, the effects were so remarkable that many witness accounts of the day observed that the aging process appeared to have reversed. While still aged by all accounts, their individual treatise on Immortality appeared to have succeeded.");
        yield return lineBreak();
        yield return lineBreak();
        yield return text("At least, for now.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("hook", "h00034"))
            yield return link("Click to continue...", null, () => enchantHook("h00034", HarloweEnchantCommand.Replace, passage94_Fragment_0));
        yield break;
    }

    IStoryThread passage94_Fragment_0()
    {
        Vars.det4 = "visited";
        yield return abort(goToPassage: "DeteriorationHub");
        yield break;
    }

// ###################################################################
// PASSAGE: DetEffectRandom   (passage166)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 19213-19258
// Links:  EffectRandomizer
// Aborts: -
// Purpose: Immortality-consequence framing; links to EffectRandomizer
// ###################################################################

    void passage166_Init()
    {
        this.Passages[@"DetEffectRandom"] = new StoryPassage(@"DetEffectRandom", new string[] { }, passage166_Main);
    }

    IStoryThread passage166_Main()
    {
        if (Vars.killed == "yes")
        {
            yield return abort(goToPassage: "DeteriorationHub");
        }
        else
        {
            using (styleScope("bold", true))
            {
                yield return text("The Effects of Immortality ");
                if (Vars.round == 16)
                {
                    yield return text("- Early Years");
                }
                if (Vars.round == 17)
                //else
                {
                    yield return text("- Middle Years");
                }
            }
            yield return lineBreak();
            yield return lineBreak();
            //using (styleScope("hubTitle", true))
            //{
            //    //yield return text(" ");
            //}
            //using (styleScope("hubDetails", true))
            //{
            yield return text(@"It cannot be overstated: the dangers of defying God and the natural order of all things. Immortality, the likes of which the scientists craved, could never be sustained forever without some great sacrifice. Their continued existence was like a rolling of the dice, a gamble as precarious ");
            yield return text(macros1.either("as a spider held by a thread above an all-consuming flame.", "as a candle flame amongst a roaring tempest.", "as a pendulous dagger perched above their head."));
            yield return lineBreak();
            yield return lineBreak();
            yield return link("Click to see the effects...", "EffectRandomizer", null);
            //}
        }
        yield return lineBreak();
        yield return lineBreak();

        yield break;
    }

// ###################################################################
// PASSAGE: Church   (passage243)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26742-26768
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: Church (pay to move back on the Creepy track)
// ###################################################################

    void passage243_Init()
    {
        this.Passages[@"Church"] = new StoryPassage(@"Church", new string[] { }, passage243_Main);
    }

    IStoryThread passage243_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Charitable Church");
        }
        yield return lineBreak();
        yield return text("Pay $ X/X/X to move 1/2/3 spaces backwards on the ");
        yield return text("<sprite=\"Creepy_Icon\" index=0>");
        yield return text(" ");
        yield return text("Track.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("For example, if the cost is 1/2/3 and you pay $2, you will lose 2 Creepy.");
        }
        yield return lineBreak();
        yield return lineBreak();
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HardwareStore1   (passage244)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26774-26800
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: Hardware Store (1 ingredient of choice, no bodies)
// ###################################################################

    void passage244_Init()
    {
        this.Passages[@"HardwareStore1"] = new StoryPassage(@"HardwareStore1", new string[] { }, passage244_Main);
    }

    IStoryThread passage244_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Hardware Store");
        }
        yield return lineBreak();
        yield return text("Gain 1 Ingredient of your choice ");
        using (styleScope("italic", true))
        {
            yield return text("(except bodies)");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("If you place multiple pieces with this action, each Ingredient you gain may be of" +
            " the same or a different type.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: BookStore3   (passage245)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26806-26832
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: Book Store (1 Knowledge of choice, not Occult)
// ###################################################################

    void passage245_Init()
    {
        this.Passages[@"BookStore3"] = new StoryPassage(@"BookStore3", new string[] { }, passage245_Main);
    }

    IStoryThread passage245_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Book Store");
        }
        yield return lineBreak();
        yield return text("Gain 1 Knowledge of your choice ");
        using (styleScope("italic", true))
        {
            yield return text("(not Occult)");
        }
        yield return text(".");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("If you place multiple pieces with this action, each Knowledge you gain may be of " +
            "the same or a different type.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: WireService2   (passage246)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26838-26852
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: Wire Service (gain $2)
// ###################################################################

    void passage246_Init()
    {
        this.Passages[@"WireService2"] = new StoryPassage(@"WireService2", new string[] { }, passage246_Main);
    }

    IStoryThread passage246_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Wire Service");
        }
        yield return lineBreak();
        yield return text("Gain $2.");
        yield break;
    }

// ###################################################################
// PASSAGE: Warehouse4   (passage247)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26858-26879
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: Warehouse (pay $1 repeatedly to recover Servants)
// ###################################################################

    void passage247_Init()
    {
        this.Passages[@"Warehouse4"] = new StoryPassage(@"Warehouse4", new string[] { }, passage247_Main);
    }

    IStoryThread passage247_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Warehouse");
        }
        yield return lineBreak();
        yield return text("For a single action, pay $1 any number of times to gain an equal number of Servan" +
            "ts from Lost.");
        yield return lineBreak();
        yield return lineBreak();
        using (styleScope("italic", true))
        {
            yield return text("Your Self can only perform this action once per visit.");
        }
        yield break;
    }

// ###################################################################
// PASSAGE: PetStore5   (passage248)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 26885-26899
// Links:  -
// Aborts: -
// Purpose: Town building tile reference: Pet Store (gain 2 Chemicals)
// ###################################################################

    void passage248_Init()
    {
        this.Passages[@"PetStore5"] = new StoryPassage(@"PetStore5", new string[] { }, passage248_Main);
    }

    IStoryThread passage248_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Friendly Pet Store");
        }
        yield return lineBreak();
        yield return text("Gain 2 Chemicals.");
        yield break;
    }

// ###################################################################
// PASSAGE: EffectRandomizer   (passage279)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 28934-28972
// Links:  -
// Aborts: -
// Purpose: CODE ONLY: shuffles the four DetEffect options, removes visited ones, aborts to a random one
// ###################################################################

    void passage279_Init()
    {
        this.Passages[@"EffectRandomizer"] = new StoryPassage(@"EffectRandomizer", new string[] { }, passage279_Main);
    }

    IStoryThread passage279_Main()
    {
        Vars.effect = macros1.a("DetEffect1", "DetEffect2", "DetEffect3", "DetEffect4");
        yield return lineBreak();
        if (Vars.det1 == "visited")
        {
            Vars.effect = Vars.effect - macros1.a("DetEffect1");
        }
        yield return lineBreak();
        if (Vars.det2 == "visited")
        {
            Vars.effect = Vars.effect - macros1.a("DetEffect2");
        }
        yield return lineBreak();
        if (Vars.det3 == "visited")
        {
            Vars.effect = Vars.effect - macros1.a("DetEffect3");
        }
        yield return lineBreak();
        if (Vars.det4 == "visited")
        {
            Vars.effect = Vars.effect - macros1.a("DetEffect4");
        }
        yield return lineBreak();
        yield return lineBreak();
        Vars.effect = macros1.shuffled((HarloweSpread)Vars.effect);
        yield return lineBreak();
        Vars.tempeffect = Vars.effect["1st"];
        yield return lineBreak();
        yield return lineBreak();
        yield return abort(goToPassage: Vars.tempeffect);
        yield return lineBreak();
        yield break;
    }

// ###################################################################
// PASSAGE: HereditaryDiseaseComplete   (passage341)
// Tags: -
// Source: TheCostofDiseaseEng.cs lines 34167-34232
// Links:  Devastation1,Devastation2,Devastation3
// Aborts: -
// Purpose: Reward for curing the Hereditary Disease: flip the card to become immune for the Generation
// ###################################################################

    void passage341_Init()
    {
        this.Passages[@"HereditaryDiseaseComplete"] = new StoryPassage(@"HereditaryDiseaseComplete", new string[] { }, passage341_Main);
    }

    IStoryThread passage341_Main()
    {
        using (styleScope("bold", true))
        {
            yield return text("Successful Treatment");
        }
        yield return lineBreak();
        yield return text(@"While they could never fully cure the psychologic disorders that plagued them throughout their lives, they were able to pinpoint effective countermeasures to provide relief. The continued treatment of their afflictions allowed the scientists to overcome the especially ravaging effects of their diseases.");
        Vars.devpage = 1;
        yield return lineBreak();
        yield return lineBreak();
        //yield return enchantIntoLink("Click to return...", passage341_Fragment_1);
        using (styleScope("hook", "h000341"))
            yield return link("Click to continue...", null, () => enchantHook("h000341", HarloweEnchantCommand.Replace, passage341_Fragment_0));
        yield break;
    }

    IStoryThread passage341_Fragment_0()
    {
        //yield return lineBreak();
        ViewItemObtain.SetupPassagename = Vars.round == 4 ? "Devastation1" : Vars.round == 5 ? "Devastation2" : "Devastation3";
        using (styleScope("setupStyleEvnt", true))
        {
            using (styleScope("bold", true))
            {
                //yield return text("SETUP");
            }
            Vars._SetupImage = "S1_DiseaseExperiment";
            yield return lineBreak();
            yield return text("After gaining your VP reward for completing this Experiment, flip this card face-" +
                "down. While this card is face-down, you cannot be affected by Hereditary Disease Events.");
            yield return lineBreak();
            yield return lineBreak();
            using (styleScope("italic", true))
            {
                yield return text("At the end of the Generation, this card will be discarded.");
            }
        }
        //yield return lineBreak();
        //yield return lineBreak();
        //if (Vars.round == 4)
        //{
        //    yield return link("Click to return...", "Devastation1", null);
        //}
        //if (Vars.round == 5)
        //{
        //    yield return link("Click to return...", "Devastation2", null);
        //}
        //if (Vars.round == 6)
        //{
        //    yield return link("Click to return...", "Devastation3", null);
        //}
        //yield return lineBreak();
        yield break;
    }

    IStoryThread passage341_Fragment_1()
    {
        yield return enchant("Click to return...", HarloweEnchantCommand.Replace, passage341_Fragment_0);
        yield break;
    }
