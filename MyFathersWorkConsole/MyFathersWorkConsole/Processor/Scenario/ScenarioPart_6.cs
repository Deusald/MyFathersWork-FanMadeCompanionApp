namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodHuntNorth()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("The Hunting party explored the foggy Moors to the North.");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.HuntNorthnextPsg == "" || StaticGameState.HuntNorthnextPsg == 0)
        {
            StaticGameState.HuntNorthnextPsg = StaticGameState.GetRandom(new[]
            {
                MethodWight,
                MethodMoonPresence
            });
        }

        optionsManager.AddOption("Continue...", StaticGameState.HuntNorthnextPsg);
        optionsManager.PresentOptions();
    }


    private static void MethodHuntWest()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("The Hunting party explored into the blood-tinged mountains to the West.");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.HuntWestnextPsg == "" || StaticGameState.HuntWestnextPsg == 0)
        {
            StaticGameState.HuntWestnextPsg = StaticGameState.GetRandom(new[]
            {
                MethodGolem,
                MethodManticore
            });
        }

        optionsManager.AddOption("Continue...", StaticGameState.HuntWestnextPsg);
        optionsManager.PresentOptions();
    }


    private static void MethodHuntEast()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("The Hunting party explored the Dark Forest to the East.");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.HuntEastnextPsg == "" || StaticGameState.HuntEastnextPsg == 0)
        {
            StaticGameState.HuntEastnextPsg = StaticGameState.GetRandom(new[]
            {
                MethodPricolici,
                MethodTroll
            });
        }

        optionsManager.AddOption("Continue...", StaticGameState.HuntEastnextPsg);
        optionsManager.PresentOptions();
    }


    private static void MethodHuntSouth()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("The Hunting party explored the cobblestone streets of ");
        Console.Write(StaticGameState.townname);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.HuntSouthnextPsg == "" || StaticGameState.HuntSouthnextPsg == 0)
        {
            StaticGameState.HuntSouthnextPsg = StaticGameState.GetRandom(new[]
            {
                MethodStrigoi,
                MethodPriest
            });
        }

        optionsManager.AddOption("Continue...", StaticGameState.HuntSouthnextPsg);
        optionsManager.PresentOptions();
    }


    private static void MethodPricolici()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Monster Emerges from the Forest");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("It was only when they were less than a meter away in that tangled messed of ancient undergrowth that the dark form revealed itself to ");
        Console.Write(StaticGameState.huntname);
        Console.Write(" ");
        Console.Write("III. It rose from its crouched position on a fallen tree to tower over the hunter's party, half-man, half-beast.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Its body was covered head to toe with matted fur, and the face exposed an elongated snout flanked by eyes that shone like feral gas lamps. A being from folklore made flesh - a Pricolici! And there it waited, and watched, hovering in a space between one breath and the next, poised to flee or charge at a moment’s notice.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Pricolici";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Pricolici");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodMoonPresence()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Pathway Was Blocked");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The impenetrable haze swirled at its center like a small vortex, alive and billowing, before revealing a massive beast bathed in smoky luminescence. More than twice the size of any hunter in the group, it stood on reptilian hindquarters, scales speckled with moss and fungus oozing with a putrid sheen.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "And where a face should have been, only a dark, empty abyss could be seen, surrounded by a nest of thick, oily tentacles — a dark headdress of serpents floating in space, unnatural and unseeing, yet devilish to behold. And thus the ");
        Console.Write("<bold>");
        Console.Write("Moonlight Presence");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("made itself known.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Moonlight Presence";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Moonlight Presence");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodWight()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Pathway Was Blocked");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("The stifling mist dissolved before ");
        Console.Write(StaticGameState.huntname);
        Console.Write(" ");
        Console.Write("III as the oily black eyes of a hideous visage glinted in the pale moonlight. Under the boughs of a dying black locust tree, a ");
        Console.Write("<bold>");
        Console.Write("shambling wight");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("appeared. The ground beneath his broken toes withered to ash with each of his belabored steps. Somehow, the hunting party would need to vanquish this foul terror before the night was over.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Wight";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Shambling Wight");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice:");
        optionsManager.PresentOptions();
    }


    private static void MethodTroll()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Monster Emerges from the Forest");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "As they approached a small stone bridgeway spanning a dried up creek bed, a foul odor hung heavy in the air, chokingly thick. It was not long before the source became apparent as an ancient Troll clambered out from under the bridge, taking up position in front of it as though to block the way.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Its blue-gray hair reached its knees, rope-like and covered with mud and leaves. From the tangle of wild hair emerged two massive arms with two equally massive hammers clutched in each hand. Its pock-marked, asymmetrical face loomed with anger in their direction.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Troll";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Troll");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodGolem()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Beast Amongst the Stony Crags");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("A concussive pounding echoed down through the canyon. Upon a darkened ridge not a furlong away, stood a colossus of aggravated rock that could have been hewn from the mountain itself: a Stone Golem!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Its massive fists smashed repeatedly into a crater of its own making, and so preoccupied was it in this endeavor, the danger in approaching was not in being seen but in avoiding the boulders it sent plummeting down in all directions.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Golem";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Golem");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodManticore()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Beast Amongst the Stony Crags");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The ever-thinning air became filled with dust and smoke, followed by a terrifying roar that sent tremors of fear through all who heard it. A massive beast with a lion’s frame and giant’s head loomed above the path ahead, stirring up a cloud of debris in its wake.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The Manticore landed heavily on the narrow path, folded back its leathery wings, and stood perched upon the stone expectantly. Smiling hungrily through a distorted human face that revealed countless needle-sharp teeth, it whipped its barbed tail in malevolent anticipation.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Manticore";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Manticore");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodStrigoi()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Town Encounter");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "As they approached the darkened alley, they heard first the hideous sound of an animal hungrily feeding on a fresh kill. Peering down the alley, the sound immediately ceased as torchlight revealed a pale-skinned creature hovering over the eviscerated body of an unfortunate townsfolk.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "It spun to face them, baring long, white fangs and hissing like a cornered housecat. Its red, hateful eyes narrowed as it prepared to strike; its gangly torso was covered neck to waist in a glistening liquid. There was no doubt that this abomination was a ");
        Console.Write("<bold>");
        Console.Write("Strigoi");
        Console.Write("</bold>");
        Console.Write(". It would appear the tales were true.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Strigoi";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Strigoi");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodPriest()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Town Encounter");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("The doors to the church swung inward with great force as though pulled at the end by an unseen hand. A figure in dark robes stood at the pulpit, his unnatural voice echoing a solemn incantation.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Positioned like sentinels, marble statues flanked the apse, their eyes leaking blood that pooled red and bright on the floor below. When ");
        Console.Write(StaticGameState.huntname);
        Console.Write(" ");
        Console.Write(
            "III looked again to the figure at the altar, the Priest had turned towards them, arms held high. His hood pulled back to reveal a disfigured face, hairless, lipless and smiling grotesquely, glossy with a sheen of fresh blood.");
        Console.WriteLine();
        StaticGameState.huntbeast = "Priest";
        Console.WriteLine();
        Console.Write("The ");
        Console.Write("<bold>");
        Console.Write("Priest");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("required a sacrifice: ");
        optionsManager.PresentOptions();
    }


    private static void MethodHuntSuccess1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "Majestic",
            "Stunning",
            "Grand",
            "Monumental",
            "Extraordinary"
        }));
        Console.Write(" ");
        Console.Write("Success!");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.huntcount = StaticGameState.huntcount + 1;
        Console.WriteLine();
        Console.Write("The foul ");
        Console.Write(StaticGameState.huntbeast);
        Console.Write(" ");
        Console.Write("emits a ");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "loud shriek",
            "low, rumbling growl",
            "strained gasp for air"
        }));
        Console.Write(" ");
        Console.Write("before collapsing to the ground, defeated. In seconds, its corporeal form dissipates to ash and is carried away on the wind. For as long as tales are still told of this cursed night, the ");
        Console.Write(StaticGameState.huntbeast);
        Console.Write(" ");
        Console.Write("was never to be seen again.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage277_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage277_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.round == 13) ? MethodProsperity2 : MethodHuntSuccessCheck));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Each player participating in the Hunt: ");
        Console.Write("<bold>");
        Console.Write("Lose 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(", return this servant to your Quarters,");
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("Gain ");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "2VP",
            "3VP",
            "a Knowledge of your choice"
        }));
        Console.Write(".");
        Console.Write("</bold>");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodHuntFail1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "Miserable",
            "Woeful",
            "Dismal",
            "Pathetic",
            "Grim"
        }));
        Console.Write(" ");
        Console.Write("Failure!");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It had all occurred so quickly, and yet the devastation left in its wake was as violent as it was terrible. The foul ");
        Console.Write(StaticGameState.huntbeast);
        Console.Write(" ");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "seemed to cackle to itself",
            "issued a triumphant wail",
            "smiled with an unsettling grin"
        }));
        Console.Write(", surveying the scene. Before them, strewn about in sanguine piles, were the wide-eyed corpses of those hunters whose weapons failed to conquer the monstrous being. In the blink of an eye, the ");
        Console.Write(StaticGameState.huntbeast);
        Console.Write(" ");
        Console.Write("turned and quickly escaped into the shadows, but not before stealing away the family's trusted servants. Their tortured screams were heard throughout the valley.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage278_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage278_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.round == 13) ? MethodProsperity2 : MethodHuntSuccessCheck));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Servant";
        Console.WriteLine();
        Console.Write("All players participating in the Hunt ");
        Console.Write("<bold>");
        Console.Write("return their Servant on Hunter's Haven to Lost");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodEffectRandomizer()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.effect =
        [
            MethodDetEffect1,
            MethodDetEffect2,
            MethodDetEffect3,
            MethodDetEffect4
        ];
        Console.WriteLine();
        if (StaticGameState.det1 == "visited")
        {
            StaticGameState.effect.Remove(MethodDetEffect1);
        }

        Console.WriteLine();
        if (StaticGameState.det2 == "visited")
        {
            StaticGameState.effect.Remove(MethodDetEffect2);
        }

        Console.WriteLine();
        if (StaticGameState.det3 == "visited")
        {
            StaticGameState.effect.Remove(MethodDetEffect3);
        }

        Console.WriteLine();
        if (StaticGameState.det4 == "visited")
        {
            StaticGameState.effect.Remove(MethodDetEffect4);
        }

        Console.WriteLine();
        Console.WriteLine();
        StaticGameState.effect.Shuffle();
        Console.WriteLine();
        StaticGameState.tempeffect = StaticGameState.effect[0];
        Console.WriteLine();
        Console.WriteLine();
        StaticGameState.tempeffect.Invoke();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodOptiontoKillYes()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Inevitable");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "While I struggle to insinuate such an onerous deed, the cousins were correct in assuming the worst. Whether intentional or merely a byproduct of the stresses of advanced aging on the mind, there would soon be horrible and unknowable consequences for unnaturally extending one's existence.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Did they take this opportunity to experiment upon their own flesh and blood? Or was this only coincidental, and was the continued promise of additional help around the Estate worth the potential negatives to come?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("In turn order, any player with an ");
        Console.Write("<bold>");
        Console.Write("Immortality card");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("can choose to discard it to the scenario box.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If a player ");
        Console.Write("<bold>");
        Console.Write("discards an Immortality card");
        Console.Write("</bold>");
        Console.Write(", they immediately:");
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Gain 1 Body,");
        Console.Write("</bold>");
        Console.Write(" Lose 1 ");
        Console.Write("<sprite=\"Insanity_Icon\" index=0>,");
        Console.Write(" ");
        Console.Write("and Gain 1VP");
        Console.Write(". Then");
        Console.Write(" ");
        Console.Write("they must return a ");
        Console.Write("Caretaker");
        Console.Write(" ");
        Console.Write("piece to Lost.\n\nIf a player chooses to keep their Immortality card,");
        Console.Write(" ");
        Console.Write("they receive no special bonus and also keep their ");
        Console.Write("<b>Caretaker</b>");
        Console.Write(" ");
        Console.Write("piece.\n\nOnce all players have chosen");
        Console.Write(" \n");
        optionsManager.AddOption("OptiontoKillQuestion", MethodOptiontoKillQuestion);
        optionsManager.PresentOptions();
    }


    private static void MethodOptiontoKillStart()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Peculiar Biological Study");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "During this time, the cousins' journal entries became increasingly paranoid about the work of their remarkably hardy parental figures. Not only did they describe a feeling of anxiety from their constant negativity and criticism, but there was a growing fear that they were actively sabotaging the experiments.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Coincidentally, several journal entries, dated over the course of the first months in the year of 1891, form a collective study on human anatomy. Contained within these pages are detailed sketches of exposed muscle fibers with cross-sections of the various strains upon veins and arteries. The age of the subject is especially advanced, providing exceptional clarity on how this has affected the structure and blood flow of these areas.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It is only in the final pages that the unnamed subject (or subjects?) is referred to as \"deceased.\" The note reads:");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("\"Subject deceased. Over these months, I believe I have become even closer to my parent than ever before. If only we could have had more time together; so much still to learn. It is so silent in the laboratory now.\"");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("OptiontoKillYes", MethodOptiontoKillYes);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodS5SpecialVote()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Retrieve the Voting tokens from the box. Each player takes a Voting token into their fist and chooses a side. When all players have chosen, all players simultaneously reveal their vote.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("is a vote to facilitate electricity, which will ");
        Console.Write("<bold>");
        Console.Write("allow us to complete experiments at a discounted cost");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("despite the fact that it may enrage the populace into ");
        Console.Write("<bold>");
        Console.Write("destruction of property");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("is vote to reject electricity and support the obstinate masses.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<italic>");
        Console.Write("(Ties are broken, by the last player in turn order.)");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here to start the vote...", passage282_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage282_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodS5SpecialVote2);
        optionsManager.PresentOptions();
    }

    private static void MethodOptiontoKillQuestion()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Immortality Check");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Are there any players with Immortality cards remaining in their possession?");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("DetEffectRandom", MethodDetEffectRandom);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("No.", passage283_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage283_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.imm = "none";
        MethodNoUni2();
        optionsManager.PresentOptions();
    }

    private static void MethodNoUniMayornCreepy()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Somber End");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "\"Fat lot of good your family's 'contribution to society' has done for us!\" The patrons would sneer upon their approach. \"I used to have Yellow Fever. Now I've got Yellow Fever AND an insufferable doctor trying to tell me what to do!\"");
        StaticGameState.gen3pg = 0;
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The townsfolk showed little respect for the family's past political and charitable stances and they expressed their derision at every opportunity. This resulted in significant perturbation.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage284_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage284_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodS5Specialbar1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "CompulsionBack";
        Console.WriteLine();
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("III ");
        Console.Write("<bold>");
        Console.Write("draws 1 Compulsion");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and returns the ");
        Console.Write("<bold>");
        Console.Write("Commemorative Mayoral Coin");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("token to the scenario box.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III ");
        Console.Write("<bold>");
        Console.Write("draws 1 Compulsion");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and returns the ");
        Console.Write("<bold>");
        Console.Write("Heart <sprite=\"S1_HeartToken\" index=0> token");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("token to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodMWCheckComplete()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Reveal this screen to all players to confirm your Masterwork has been completed.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.tempcomp == StaticGameState.nameA)
        {
            MethodMWCreationHubA();
        }
        else if (StaticGameState.tempcomp == StaticGameState.nameB)
        {
            MethodMWCreationHubB();
        }
        else if (StaticGameState.tempcomp == StaticGameState.nameC)
        {
            MethodMWCreationHubC();
        }
        else if (StaticGameState.tempcomp == StaticGameState.nameD)
        {
            MethodMWCreationHubD();
        }
        else if (StaticGameState.tempcomp == StaticGameState.nameE)
        {
            MethodMWCreationHubE();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If you have paid all necessary costs and completed your Masterwork, ");
        optionsManager.AddOption("MWComplete", MethodMWComplete);
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.round == 16)
        {
            optionsManager.AddOption("NoUni1", MethodNoUni1);
        }
        else if (StaticGameState.round == 17)
        {
            optionsManager.AddOption("NoUni2", MethodNoUni2);
        }
        else
        {
            optionsManager.AddOption("NoUni3", MethodNoUni3);
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodGloomyWolvesIntro()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("GENERATION III:");
        Console.WriteLine();
        Console.Write("The Order Revealed");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("I will attempt to relay the events as they were explained to me, though I fully understand the solemn repercussions of the unfathomable knowledge contained within this text.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Amongst the forests of the Romanian countryside, nestled in shadowed valleys of the Carpathian mountains, there are places so far removed from the rest of the world as to appear almost invisible in their machinations. In shadows tucked away amongst the deepest tangled forests, from the darkest crevices burrowed deep into the earth, these are the places where our most pervasive legends and folklore emerge. And in their isolation, it grows.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The next generation's return was marked by a most startling and terrifying discovery. For it appeared that while the disease had left the town, another more insidious plague had befallen the land. The Order of St. Hubertus, emboldened by the success of their clandestine labors, took the opportunity afforded them and manifested in their true and cursed forms. And like the emblematic wolfhead adorning their insignia, they arose with silvered pelts, baring distended fangs and open animalistic maws that dripped with saliva. The least horrifying held this form at least, as the other beasts hosted swelling deformities and twisted extremities too repulsive to describe. The ancient evils they had unearthed from beneath the town gave them the ability to transform without the full moon's glow, and in the light of day, these monstrous beings set upon the townsfolk to enforce their rule either by coercion or by visceral and bloody execution.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The beasts were real.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "But as the Order expanded its numbers and influence, the beasts did not recognize their new forms as folly. They called themselves \"Strigoi\" (embracing the vampiric moniker given them by local folklore) and commanded quick control over the local government. To them, they were the powerful new evolution of society. They perceived humanity as the real monster!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "However, they were not unkeen to the important work of the family. In fact, they took a great interest in their experimentations, even to the point of offering their assistance. And as the new generation was thrust into this distorted new reality, they were forced to consider a most dreadful prospect: to aid these creatures in their scheme and spread their message of dreadful bloodlust or incur their loathsome wrath.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("EvilConsequences", MethodEvilConsequences);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodPreposterous()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Are You Quite Sure?");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Despite their proclivities towards what other weaker willed individuals might call \"a mad, unending exploration of a vile and unethical pseudoscience by the frightfully inexperienced,\" the youthful generation had one unyielding virtue: they were very rich. And the rich definitely do not pay taxes.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("While a sort of hysteria may have gripped their frail psyche, the very idea that ");
        Console.Write(StaticGameState.playtxt);
        Console.Write(" ");
        Console.Write("noted aristocrats would pay a penalty for the privilege of living amongst these rabble without a significant guarantee of return on investment was more absurd than the rumors of a portal opened to the netherworld.");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players == 2)
        {
            Console.Write("<hook>");
            optionsManager.AddOption("Click here to continue...", passage288_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            optionsManager.AddOption("EvilHunter1Event", MethodEvilHunter1Event);
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage288_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.confront = "yes";
        MethodEvilHunter1EventYes();
        optionsManager.PresentOptions();
    }


    private static void MethodTheVialUse()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Clear Choice");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Clearly, there were no others strong enough to thwart the evil that had taken over the valley and spread across the forests of Hungary. ");
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III returned to their home with determination in their chest and retrieved the crystal ");
        Console.Write("<bold>");
        Console.Write("vial");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("now displayed above their hearth.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With this vial of the most blessed of holy waters, they knew they could take matters into their own hands and righteously reclaim the land once lost.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Alternatively and suspiciously well-timed, a traveling caravan had offered a significant sum for it recently. But, of course, ridding the land of all evil was the most pressing of matters.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("VialChanged", MethodVialChanged);
        Console.Write(" ");
        Console.Write("the land of this evil.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("VialSold", MethodVialSold);
        Console.Write(" ");
        Console.Write("the vial for selfish reasons (for $3).");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodVialCharity()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand this storybook device to ");
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("and do not allow any other players to see the screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Once you are ready", passage290_Fragment_2);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage290_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodLycanthropicMessage);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_VialToken";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Vial");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("token from the scenario box and place it near your Estate.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Return the <b>Heart <sprite=\"S1_HeartToken\" index=0> token</b> to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void passage290_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Legacy of Charity");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("While inspecting a wooden shelf in the pantry, the unexpected clatter of crystal on stone shook the young ");
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III. Luckily, it appeared the vial of liquid remained undamaged, although the paper tag attached to the cork stopper at its top was of considerable age.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The note stated, \"A gift of Holy Water from a thankful church of God,\" and was aptly addressed to ");
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("the 1st. Interestingly, it had remained stored away since the charitable events of the long past.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage290_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void MethodVialSold()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Unconscionable Choice");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("To look back on this moment with pure hindsight and recognize that a being had the potential to halt this insidious infestation and chose instead to turn the situation into a financial windfall is harrowing. ");
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III's infamous decision would result in a blight upon the land that was nigh unstoppable.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage291_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage291_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.vialuse = "no";
        optionsManager.AddOption("Continue...", MethodWolvesEvil2);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Money_Icon";
        Console.WriteLine();
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III gains ");
        Console.Write("<bold>");
        Console.Write("$3");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("1VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodVialChanged()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Selflessness for Change");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.vialuse = "yes";
        Console.WriteLine();
        Console.Write("The liquid was introduced at the source of the stream that winded through the hoary gloom enveloping the town of ");
        Console.Write(StaticGameState.townname);
        Console.Write(". Like a glittering oil, it spread downstream, turning the murky waters clear once again with a supernatural effervescence.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "After less than a day's passing, the azalea blossoms that once dotted the landscape were in full bloom and the radiant sunlight bathed the valley in a honey glow. The creatures that remained found themselves reformed, though still horrific to behold, and went about clothed in dapper suits and summer dresses with hats that could easily be tipped as a friendly greeting.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Those of the Order that refused to submit to the cleansing beauty fled into the hills never to be seen again. The cousins were free once again to be the most unconventional presences within the town, and returned to their labors with no further interruptions.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage292_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage292_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic3);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_VialToken";
        Console.WriteLine();
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III gains 1VP.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodTieredRewards2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic3);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that donated an ");
        Console.Write("<bold>");
        Console.Write("A Experiment");
        Console.Write("</bold>");
        Console.Write(":");
        Console.WriteLine();
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "Gain 1VP.",
            "Gain an ingredient of your choice.",
            "Receives no bonus.",
            "Loses 1VP. The Order is unpleased with this meager offering."
        }));
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that donated a ");
        Console.Write("<bold>");
        Console.Write("B Experiment");
        Console.Write("</bold>");
        Console.Write(":");
        Console.WriteLine();
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "Gain a Knowledge of your choice.",
            "Gain $2.",
            "Gain 2VP."
        }));
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that donated a ");
        Console.Write("<bold>");
        Console.Write("C Experiment");
        Console.Write("</bold>");
        Console.Write(":");
        Console.WriteLine();
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "Gain 4VP.",
            "Gain $4."
        }));
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that chose not to donate ");
        Console.Write("<bold>");
        Console.Write("returns a Servant to Lost");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("gains 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodGloomyPenalty1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Hunter's Tax");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "Set amid an unseasonably warm afternoon, the Fraternity Lodge held a town meeting, gathering the majority of the townsfolk within its carved stone walls, which were most lavishly adorned with rich velvet trappings and the stuffed heads of beasts they claimed to have bested in the wilds.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The leader spoke again, outfitted in his signature trenchcoat and broad-rimmed hat. \"The unprecedented progress this town has made is due to our immaculate safeguarding from disease and the insidious demons that haunt us from the hills. However, unprecedented progress does come at a price...\"");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage306_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage306_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodPreposterous);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_HunterToken";
        Console.WriteLine();
        Console.Write("Any player that does not have a Servant/Spouse piece on ");
        Console.Write("<bold>");
        Console.Write("The Hunter's Rest");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("must ");
        Console.Write("<bold>");
        Console.Write("pay $2");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("OR ");
        Console.Write("<bold>");
        Console.Write("2 resources");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the supply. If this is not possible, they instead ");
        Console.Write("<bold>");
        Console.Write("lose 3VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Alternatively, any player with a ");
        Console.Write("<bold>");
        Console.Write("Hunter token");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("may discard it to the scenario box to invoke their privilege and forgo this payment.");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodGloomyPenalty3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Hunter's Tax");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Even in their final years of life, the Hunters were unwilling to forgo the last remaining payment.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue to Final Scoring...", passage307_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage307_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodScoring);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_HunterToken";
        Console.WriteLine();
        Console.Write("Any player that does not have a Servant/Spouse piece on ");
        Console.Write("<bold>");
        Console.Write("The Hunter's Rest");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("must ");
        Console.Write("<bold>");
        Console.Write("pay $2");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("OR ");
        Console.Write("<bold>");
        Console.Write("2 resources");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the supply. If this is not possible, they instead ");
        Console.Write("<bold>");
        Console.Write("lose 3VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Alternatively, any player with a ");
        Console.Write("<bold>");
        Console.Write("Hunter token");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("may discard it to the scenario box to invoke their privilege and forgo this payment.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodWolvesVote()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("An Opportunity");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "With a shrill squeal, the violin player ended the performance abruptly. The dinner guests turned their heads to see the source of the commotion: a shambling creature with unseemly patches of wispy gray fur covering their deformities had climbed over the east Veranda and now crouched near the dinner table. It seemed to intuit the place of their gathering and only appeared when all of the family were present.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "\"Do not fear me. I am not your enemy. By mere chance, I happened upon a concoction of daisy fleabane and tassel hyacinth that was able to completely suppress my insatiable hunger for destruction.\" The jowls of the malformed dog-man shuddered with each gnarled utterance, yet his emerald eyes gleamed with a light of hope.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("\"With your help, we can cure the entirety of the valley and help to undo the horrors that we have wrought!\"");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Though they took exception to using an invention not of their own creation, the cousins knew a decision could allow them to avoid the humiliation of donating another one of their precious experiments to these mongrels.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Players will now vote on whether to unleash this concoction to tame the demonic beasts of the land.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to Unleash the Concoction.");
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to refuse.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("All players take their Voting tokens into their hand. Players will secretly choose a side to place face up in their palm. Then, they will close their fist and extend it to the center of the table.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("When all players have chosen, all players reveal their votes. Tally all the votes and the side with the most votes wins. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the last player in turn order.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to start the vote...", passage308_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage308_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodWolvesVote2);
        optionsManager.PresentOptions();
    }

    private static void MethodWolvesVoteCheck()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Remember the Cure");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It was strange. While the vote may have commenced and they seemed to have come to a positive arrangement, some were suddenly overwhelmed with an urge to assist the ");
        Console.Write("<bold>");
        Console.Write("Order");
        Console.Write("</bold>");
        Console.Write(". They tried to voice their approval to the vote, straining with effort, but the word \"nay\" instead escaped their lips.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "How could they have known the consequences of their parents' decision to accept the cure for their hereditary illness? Moments later, their cursed minds has twisted the truth so irreversibly that they could not fathom why they had ever agreed to such a foul plan in the first place!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("SPECIAL ACTION");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("All players with a ");
        Console.Write("<bold>");
        Console.Write("Disease card");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("in their Stored Experiments must ");
        Console.Write("<bold>");
        Console.Write("flip their Vote token to Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("in their palm if it is not already.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Tally all votes once again.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on the result of your vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("WolvesVoteChange", MethodWolvesVoteChange);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("TheVialUse", MethodTheVialUse);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
}