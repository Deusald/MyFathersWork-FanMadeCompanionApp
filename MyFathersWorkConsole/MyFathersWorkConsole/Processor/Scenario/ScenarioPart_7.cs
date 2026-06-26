namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodWolvesVoteChange()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Vote for Change");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.vialuse = "yes";
        Console.WriteLine();
        Console.Write(
            "And it was decided by the group that by the next fortnight, they would devise a serum powerful enough to reverse the evil blight upon the land. Using a coagulated mixture of the beast's own blood, hemlock's root, and borax throughout a series of involuntary trials, the chemical was proven strong enough to eliminate the effects of the transformation or kill the subject.");
        Console.WriteLine();
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
        optionsManager.AddOption("VialSoldforLess", MethodVialSoldforLess);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodVialSoldforLess()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Valuable Keepsake");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Due to the surprising and uncharacteristically good nature of the ill-tempered family of scientists, the blight from the land was removed.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The seemingly important crystal vial of holy water, while not pivotal to the tale of the cousins, was interesting to note nonetheless. For this bohemian glass piece represented the finest hand-blown 17th century crystal, and as the Austro-Hungarian Empire waned, these commanded prices that rivaled the most precious jewelry of the time.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The cousin took this opportunity to sell the vial for a significant sum of money.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage311_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage311_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic3);
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
        Console.Write("$2");
        Console.Write("</bold>");
        Console.Write(". Return the <b>Vial token</b> to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodAwardSpawningPods()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("An Award For Research");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.vialuse == "yes")
        {
            Console.Write(
                "The monsters felt guilty about not honoring their word even if it stretched their sense of ethical duty to do so. On a cool summer evening in the twilight years of life, the newly inspired creatures formed a bright cavalcade and paraded their way up the steep and winding hills to the Estate.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "Within hours, the new structure was built, and though they proposed a feast in the scientist's honor, they quickly meandered back home when the gates were firmly shut and the hounds were released to chase them from the property.");
        }
        else
        {
            Console.Write(
                "Though uninterested in the pageantry of a meager prize, they performed the gesture anyway. A small group of gray minions lumbered their way into the courtyard and built the unseemly structure with muck and stone. Once finished to their satisfaction, they stuck a slimy ribbon on the doorframe and skulked away into the surrounding fog without a word.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue to Final Scoring...", passage312_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage312_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodScoring);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "MFWlogo";
        Console.WriteLine();
        Console.Write("Award the ");
        Console.Write("<bold>");
        Console.Write("Spawning Pods");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Vanity Estate Upgrade to the player with the most completed ");
        Console.Write("<bold>");
        Console.Write("Occult");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Experiments. If there is a tie, award the Upgrade to the tied player with the least VP. ");
        Console.Write("<italic>");
        Console.Write("If there is still a tie, return the Upgrade to the box and all tied players gain 7VP instead.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Ignore all plot costs when building this Upgrade.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodInsanitySign()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Another Opportunity");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Along with a newfound sense of acceptance and encouragement for the works of the young cousins, the university also consulted with the family on emerging matters of progressive importance.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Please choose the player with the least VP:");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("<italic>");
        Console.Write("(ties are broken by the player that went later in turn order on the previous round.)");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption((string)StaticGameState.nameA, passage315_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption((string)StaticGameState.nameB, passage315_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players > 2)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameC, passage315_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        if (StaticGameState.players > 3)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameD, passage315_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        if (StaticGameState.players > 4)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameE, passage315_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        optionsManager.PresentOptions();
    }

    private static void passage315_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.saneplayer = StaticGameState.nameA;
        MethodSanityChoice();
        optionsManager.PresentOptions();
    }

    private static void passage315_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.saneplayer = StaticGameState.nameB;
        MethodSanityChoice();
        optionsManager.PresentOptions();
    }

    private static void passage315_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.saneplayer = StaticGameState.nameC;
        MethodSanityChoice();
        optionsManager.PresentOptions();
    }

    private static void passage315_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.saneplayer = StaticGameState.nameD;
        MethodSanityChoice();
        optionsManager.PresentOptions();
    }

    private static void passage315_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.saneplayer = StaticGameState.nameE;
        MethodSanityChoice();
        optionsManager.PresentOptions();
    }


    private static void MethodProsperity3b()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Return to Evil - Late Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 15;
        Console.WriteLine();
        if (StaticGameState.overrun == "yes")
        {
            Console.Write("<setupStyle>");
            Console.Write("<bold>");
            Console.Write("SETUP");
            Console.Write("</bold>");
            StaticGameState._SetupImage = "S1_Suspicious_Building";
            Console.WriteLine();
            Console.Write("Place all Suspicious Building tiles nearby, then turn to page ");
            Console.Write("<bold>");
            Console.Write("18");
            Console.Write("</bold>");
            Console.Write(" of the Village Chronicle.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Return the ");
            Console.Write("<bold>");
            Console.Write("Engineering Master's Study");
            Console.Write("</bold>");
            Console.Write(" Estate Upgrade to the scenario box.");
            Console.WriteLine();
            Console.WriteLine();
            if (StaticGameState.exposeA > 0)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.ba);
                Console.Write(" tile over spot A on the Village Chronicle. ");
                Console.WriteLine();
            }

            if (StaticGameState.exposeB > 0)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.bb);
                Console.Write(" tile over spot B on the Village Chronicle. ");
                Console.WriteLine();
            }

            if (StaticGameState.exposeC > 0)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.bc);
                Console.Write(" tile over spot C on the Village Chronicle.");
            }

            Console.Write("</setupStyle>");
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("MONSTER SPAWN");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("The Town Hall of the village has been transformed into the unofficial headquarters of the Order. When a player visits the Monster Spawn, they may ");
            Console.Write("<bold>");
            Console.Write("Perform an Experiment");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.ending = MethodENDWolvesEvil2;
            optionsManager.AddOption("Scoring", MethodScoring);
            Console.Write("</hubDetails>");
        }
        else
        {
            Console.Write("<setupStyle>");
            Console.Write("<bold>");
            Console.Write("SETUP");
            Console.Write("</bold>");
            StaticGameState._SetupImage = "S1_Suspicious_Building";
            Console.WriteLine();
            Console.Write("Place all Suspicious Building tiles nearby, return the ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(" token on the Farmer's Market to the scenario box, then turn to page ");
            Console.Write("<bold>");
            Console.Write("18");
            Console.Write("</bold>");
            Console.Write(" of the Village Chronicle.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("SPECIAL SETUP");
            Console.Write("</bold>");
            StaticGameState._SetupImage = "Creepy_Icon";
            Console.Write("Return all ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(" tokens from player Estates to the scenario box. Remove the Storybook token from the ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(" Track.");
            Console.WriteLine();
            Console.WriteLine();
            if (StaticGameState.exposeA > 0)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.ba);
                Console.Write(" tile over spot A on the Village Chronicle. ");
                Console.WriteLine();
            }

            if (StaticGameState.exposeB > 0)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.bb);
                Console.Write(" tile over spot B on the Village Chronicle. ");
                Console.WriteLine();
            }

            if (StaticGameState.exposeC > 0)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.bc);
                Console.Write(" tile over spot C on the Village Chronicle.");
            }

            Console.Write("</setupStyle>");
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("MONSTER SPAWN");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("The Town Hall of the village has been transformed into the unofficial headquarters of the Order. When a player visits the Monster Spawn, they may ");
            Console.Write("<bold>");
            Console.Write("Perform an Experiment");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.ending = MethodENDWolvesEvil2;
            optionsManager.AddOption("Scoring", MethodScoring);
            Console.WriteLine();
            Console.Write("</hubDetails>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodHuntSuccessCheck()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.huntcount == 2)
        {
            StaticGameState.huntresult = "success";
        }

        if (StaticGameState.huntcount == 1)
        {
            StaticGameState.huntresult = StaticGameState.GetRandom(new[]
            {
                "success",
                "failure"
            });
        }

        if (StaticGameState.huntcount == 0)
        {
            StaticGameState.huntresult = "failure";
        }

        if (StaticGameState.huntresult == "success")
        {
            Console.Write("<bold>");
            Console.Write("A ");
            Console.Write(StaticGameState.GetRandom(new[]
            {
                "Righteous",
                "Wondrous"
            }));
            Console.Write(" Fate");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "One by one, the steel weapons were dropped into the wooden chest; the clang of glaives, daggers, and morningstars reverberating through the lodge. They wiped the blood from tri-cornered hats and hung their polished rifles on hooks upon the walls. Affecting a cool manner, they calmed their shaken nerves with pálinka, a brandy that burned like hot coals on the throat and anesthetized their thoughts.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("They would remain vigilant until the pestilence was wiped from the land, but with ");
            Console.Write(StaticGameState.huntcount);
            Console.Write(" successful hunt, the worst of it was over. The hunt has been a success.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage317_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            Console.Write("<bold>");
            Console.Write("Overrun By ");
            Console.Write(StaticGameState.GetRandom(new[]
            {
                "Demons",
                "Monsters"
            }));
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("The scud banked across the moon, enveloping the entire valley in a dismal, silvery cocoon.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The townsfolk had placed the fate of ");
            Console.Write(StaticGameState.townname);
            Console.Write(" into the hands of a group of leather-clad cretins willing to engage in hand-to-hand combat with supernatural forces beyond their understanding. Ultimately, the scientists scoffed at their futile struggle.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "Embittered by what had been taken from them for this fool's errand, the cousins observed the chaos, protected from the wailing screams of a town overwhelmed by creatures. Perched upon their veranda, they sipped fresh coffee as the hellish minions descended upon the town to exert their terrible influence. The hunt had failed.");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.overrun = "yes";
            optionsManager.AddOption("Prosperity3b", MethodProsperity3b);
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage317_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodProsperity3);
        StaticGameState.overrun = "no";
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MastersStudy";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Chemistry");
        Console.Write("</bold>");
        Console.Write(" and ");
        Console.Write("<bold>");
        Console.Write("Biology Master's Study");
        Console.Write("</bold>");
        Console.Write(" Vanity Estate Upgrades from the scenario box and place them nearby. Any time you gain a Vanity Estate Upgrade, you may choose to gain 1 of these instead.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodENDUniGood()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Editor's note - August 1923");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Hello Ensign,");
        Console.WriteLine();
        Console.Write(
            "I've looked over the manuscript you submitted and I have to admit that it is not what I would have expected. The foreword promises a harrowing and potentially supernatural series of events that test the limits of imagination. However, the story tells a cohesive and somewhat uplifting tale of a family of reformed scientists making the world a better place. I admit that in some cases the means to which this is accomplished is morosely detailed and quite unorthodox, but overall the story seems incomplete.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If I may paraphrase: A scientific family enters into the political theater and then assists the Church with charitable donations towards building a hospital. This decision results in prosperity in the region ");
        if (StaticGameState.cured == 1)
        {
            Console.Write("\"which is further improved by the generous creation of an unprecedented cure for Yellow Fever.\" ");
        }

        if (StaticGameState.uni == "yes")
        {
            Console.Write("After which, they put on an excellent Symposium that attracts a University to the area. ");
        }

        if (StaticGameState.ultimate == "yes")
        {
            Console.Write("They even create an unintentional vaccine that essentially eliminates all disease from the region. ");
        }

        Console.Write("Ultimately, their work is instrumental in catapulting Hungary and ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write("into the international spotlight. It is very uplifting and has a good potential to sell well to the burgeoning educational market in London.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Recommendation - alter descriptions in early chapters to reflect a more uplifting tale. Omit horror and supernatural elements. Offer happy ending.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("I look forward to seeing your revisions.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("THE END?");
        Console.Write("</bold>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodHuntersChoice1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The First Night of the Hunt");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The horses reared as a blinding vein of lightning arced across the tempestuous sky, followed by a thunderous rapport that shook the ground beneath their hooves. The anxious party stood at a crossing in the roadway, trembling as they surveyed their surroundings.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "To the north, a thick fog swallowed the moors, the gray mist obscuring the horrors hidden beneath. To the east, the road entered a dark forest of foreboding trees with limbs entangled. To the West, the sky burned a deep red above the rocky mountains, seething with demonic ferocity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It was also possible to return south to the village again and see what lurked amongst the cordoned streets and torchlight.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            StaticGameState.h1a,
            StaticGameState.h1b
        }));
        Console.Write(" ");
        Console.Write("III");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("has been selected to make the choice of directions for the Hunt. Once you have chosen a direction, the town will supply both players with the listed resources.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("North to the moors. Both players gain 2 " + (string)StaticGameState.reward1 + ".", passage319_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("East to the dark forest. Both players gain 2 " + (string)StaticGameState.reward2 + ".", passage319_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("West to the mountains. Both players gain 2 " + (string)StaticGameState.reward3 + ".", passage319_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("South", passage319_Fragment_3);
        Console.Write("</hook>");
        Console.WriteLine();
        StaticGameState.huntname = StaticGameState.GetRandom(new[]
        {
            StaticGameState.h1a,
            StaticGameState.h1b
        });
        optionsManager.PresentOptions();
    }

    private static void passage319_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward1 = StaticGameState.reward1;
        StaticGameState.direction = MethodHuntNorth;
        MethodHuntNight1();
        optionsManager.PresentOptions();
    }

    private static void passage319_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward1 = StaticGameState.reward2;
        StaticGameState.direction = MethodHuntEast;
        MethodHuntNight1();
        optionsManager.PresentOptions();
    }

    private static void passage319_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward1 = StaticGameState.reward3;
        StaticGameState.direction = MethodHuntWest;
        MethodHuntNight1();
        optionsManager.PresentOptions();
    }

    private static void passage319_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward1 = StaticGameState.reward4;
        StaticGameState.direction = MethodHuntSouth;
        MethodHuntNight1();
        optionsManager.PresentOptions();
    }


    private static void MethodHuntersChoice2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Second Night of the Hunt");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The horses reared as a blinding vein of lightning arced across the tempestuous sky, followed by a thunderous rapport that shook the ground beneath their hooves. The anxious party stood at a crossing in the roadway, trembling as they surveyed their surroundings.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "To the north, a thick fog swallowed the moors, the gray mist obscuring the horrors hidden beneath. To the east, the road entered a dark forest of foreboding trees with limbs entangled. To the West, the sky burned a deep red above the rocky mountains, seething with demonic ferocity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It was also possible to return south to the village again and see what lurked amongst the cordoned streets and torchlight.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            StaticGameState.h2a,
            StaticGameState.h2b
        }));
        Console.Write(" ");
        Console.Write("III");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("has been selected to make the choice of directions for the Hunt. Once you have chosen a direction, the town will supply both players with the listed resources.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("North to the moors. Both players gain 2 " + (string)StaticGameState.reward5 + ".", passage320_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("East to the dark forest. Both players gain 2 " + (string)StaticGameState.reward6 + ".", passage320_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("West to the mountains. Both players gain 2 " + (string)StaticGameState.reward7 + ".", passage320_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("South", passage320_Fragment_3);
        Console.Write("</hook>");
        Console.WriteLine();
        StaticGameState.huntname = StaticGameState.GetRandom(new[]
        {
            StaticGameState.h2a,
            StaticGameState.h2b
        });
        optionsManager.PresentOptions();
    }

    private static void passage320_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward2 = StaticGameState.reward5;
        StaticGameState.direction = MethodHuntNorth;
        MethodHuntNight2();
        optionsManager.PresentOptions();
    }

    private static void passage320_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward2 = StaticGameState.reward6;
        StaticGameState.direction = MethodHuntEast;
        MethodHuntNight2();
        optionsManager.PresentOptions();
    }

    private static void passage320_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward2 = StaticGameState.reward7;
        StaticGameState.direction = MethodHuntWest;
        MethodHuntNight2();
        optionsManager.PresentOptions();
    }

    private static void passage320_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.huntreward2 = StaticGameState.reward8;
        StaticGameState.direction = MethodHuntSouth;
        MethodHuntNight2();
        optionsManager.PresentOptions();
    }


    private static void MethodHuntNight1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.direction.Invoke();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write(StaticGameState.huntreward1);
        Console.Write(".");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Both players on the Hunt take their Voting tokens into their hand. They will secretly choose a side to place face up in their palm. Then they will close their fist and extend it to the center of the table.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("contribute");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the Hunt.");
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("keep your resources");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If BOTH players choose to contribute, all Servants will survive and each player will ");
        Console.Write("<bold>");
        Console.Write("pay 1 ");
        Console.Write(StaticGameState.huntreward1);
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If 1 player chooses to contribute, all Servants will survive and the contributing player will ");
        Console.Write("<bold>");
        Console.Write("pay 2 ");
        Console.Write(StaticGameState.huntreward1);
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If neither player chooses to contribute, their Servants will go to Lost and the ");
        Console.Write("<bold>");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token will move 1 space to the left.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("The Result of the Vote");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Did at least one player vote to contribute to the Hunt?");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("HuntSuccess1", MethodHuntSuccess1);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("HuntFail1", MethodHuntFail1);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodHuntNight2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.direction();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write(StaticGameState.huntreward2);
        Console.Write(".");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Both players on the Hunt take their Voting tokens into their hands. They will secretly choose a side to place face up in their palm. Then they will close their fist and extend it to the center of the table.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("contribute");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the Hunt.");
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("keep your resources");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If BOTH players choose to contribute, all Servants will survive and each player will ");
        Console.Write("<bold>");
        Console.Write("pay 1 ");
        Console.Write(StaticGameState.huntreward2);
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If 1 player chooses to contribute, all Servants will survive and the contributing player will ");
        Console.Write("<bold>");
        Console.Write("pay 2 ");
        Console.Write(StaticGameState.huntreward2);
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If neither player choose to contribute, their Servants will go to Lost and the ");
        Console.Write("<bold>");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token will move 1 space to the left.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("The Result of the Vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Did at least one player vote to contribute to the Hunt?");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("HuntSuccess1", MethodHuntSuccess1);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("HuntFail1", MethodHuntFail1);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodHuntround1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("In Preparation for the Hunt");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("As the full moon rose against a crimson sky, it was clear that the night of the Hunt had finally arrived. ");
        Console.Write(StaticGameState.h1a);
        Console.Write(" ");
        Console.Write("III and ");
        Console.Write(StaticGameState.h1b);
        Console.Write(" ");
        Console.Write("III were chosen. Naturally, the cousins declined to put themselves in potential harms way, so it was decided that they would send representatives in their stead to assist the Hunters.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage323_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage323_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodHuntersChoice1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Spouse_Servant";
        Console.WriteLine();
        Console.Write(StaticGameState.h1a);
        Console.Write(" ");
        Console.Write("III and ");
        Console.Write(StaticGameState.h1b);
        Console.Write(" ");
        Console.Write("III each choose a Servant/Spouse piece and place it on the Hunter's Haven.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<i>If a player cannot perform this action, they lose 3VP and gain a Servant/Spouse piece from Lost to place onto the Hunter's Haven.</i>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodHuntround2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("In Preparation for the Hunt");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("As the full moon rose against a crimson sky, it was clear that the night of the Hunt had finally arrived. ");
        Console.Write(StaticGameState.h2a);
        Console.Write(" ");
        Console.Write("III and ");
        Console.Write(StaticGameState.h2b);
        Console.Write(" ");
        Console.Write("III were chosen. Naturally, the cousins declined to put themselves in potential harms way, so it was decided that they would send representatives in their stead to assist the Hunters.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage324_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage324_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodHuntersChoice2);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Spouse_Servant";
        Console.WriteLine();
        Console.Write(StaticGameState.h2a);
        Console.Write(" ");
        Console.Write("III and ");
        Console.Write(StaticGameState.h2b);
        Console.Write(" ");
        Console.Write("III each choose a Servant/Spouse piece and place it onto the Hunter's Haven.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<i>If a player cannot perform this action, they lose 3VP and gain a Servant/Spouse piece from Lost to place onto the Hunter's Haven.</i>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodProsperityWolvesIntro()
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
            "Could a period of prosperity emerge like a blooming lily in the shadow of a headstone? Could it thrive in soil so enriched by disease and death? With the evil machinations exposed and banished from the town, the Order of St. Hubertus was quick to answer these questions with reforms that cleared the smog and grayness from the streets. They tilled the fields till the beet flowers sprung from the earth, encouraged trade with nearby towns, and embraced modern conveniences, even so far as to negotiate an extension of the national electrical power grid. The youths, upon returning from university to claim their inheritance, could scarcely recognize the village from their childhood.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "But, it soon became clear why they were so determined to be accepted and improve their reputation. For one evening, when the blood moon crossed the evening sky, they transformed, revealing the monstrous beings they had kept secret for so many years as the unafflicted in the town looked on in horror.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The beasts were real.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "But the beasts did not recognize their new forms as folly. Though their bodies shifted into monstrosities more animal than man - more wolven, with sharp features, claws, and steel-eyed gazes - they pleaded with the public for compassion. Should we not celebrate that which makes us different? Is it not these differences that allow us to grow stronger together?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "They believed that every creature was special in their own way and were convinced that reformation could tame the impulses of any creature be it man or beast. And with that hope in their hollow hearts, they endeavored to spread a message of love and acceptance to all humans.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("O poor, misguided wretches!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Had the human inhabitants not suddenly found themselves outnumbered by a den of nightmarish beings, they may have voiced their opposition with violent reprisal. But, with no option to the contrary, the monsters retained their hellish visages and life returned to a semblance of normalcy.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("That is, until the scientists once again began their work in earnest and attracted the Order's attention.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("GoodConsequences", MethodGoodConsequences);
        StaticGameState.gen3pg = 0;
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodScoreEntryP1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine("Please enter the final score for " + StaticGameState.nameA + ".");
        StaticGameState.scoreA = int.Parse(Console.ReadLine()!);
        Console.Write("Thank you for recording this important historical information, ");
        Console.Write(StaticGameState.nameA);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("ScoreEntryP2", MethodScoreEntryP2);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private class NamePoints
    {
        public string playerName;
        public int Points;
    }

    private static void MethodWinnerHUB()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        List<float> list = new List<float>();
        List<float> winnerPlayerPoints = new List<float>();
        List<NamePoints> PlayerNameAndPoint = new List<NamePoints>();
        list.Add((float)StaticGameState.scoreA);
        PlayerNameAndPoint.Add(new NamePoints
        {
            playerName = StaticGameState.nameA,
            Points = StaticGameState.scoreA
        });
        list.Add((float)StaticGameState.scoreB);
        PlayerNameAndPoint.Add(new NamePoints
        {
            playerName = StaticGameState.nameB,
            Points = StaticGameState.scoreB
        });
        if (StaticGameState.scoreC > 0 && StaticGameState.nameC != null)
        {
            list.Add((float)StaticGameState.scoreC);
            PlayerNameAndPoint.Add(new NamePoints
            {
                playerName = StaticGameState.nameC,
                Points = StaticGameState.scoreC
            });
        }

        if (StaticGameState.scoreD > 0 && StaticGameState.nameD != null)
        {
            list.Add((float)StaticGameState.scoreD);
            PlayerNameAndPoint.Add(new NamePoints
            {
                playerName = StaticGameState.nameD,
                Points = StaticGameState.scoreD
            });
        }

        list.Sort();
        for (int k = list.Count - 1; k >= 0; k--)
        {
            winnerPlayerPoints.Add(list[k]);
        }

        int num;
        for (int i = 0; i < winnerPlayerPoints.Count; i = num + 1)
        {
            for (int j = 0; j < PlayerNameAndPoint.Count; j = num + 1)
            {
                if (winnerPlayerPoints[i] == (float)PlayerNameAndPoint[j].Points)
                {
                    Console.Write(string.Concat(new object[]
                    {
                        "Player Name :",
                        PlayerNameAndPoint[j].playerName,
                        " point : ",
                        PlayerNameAndPoint[j].Points
                    }));
                    //ViewRankingPage.instance.playerRankList.Add(PlayerNameAndPoint[j].playerName.ToString());
                    Console.WriteLine();
                    PlayerNameAndPoint.RemoveAt(j);
                    break;
                }

                num = j;
            }

            num = i;
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodScoreEntryP2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine("Please enter the final score for " + StaticGameState.nameB + ".");
        StaticGameState.scoreB = int.Parse(Console.ReadLine()!);
        Console.Write("Thank you for recording this important historical information, ");
        Console.Write(StaticGameState.nameB);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players < 3)
        {
            optionsManager.AddOption("WinnerHUB", MethodWinnerHUB);
        }
        else
        {
            optionsManager.AddOption("ScoreEntryP3", MethodScoreEntryP3);
        }

        optionsManager.PresentOptions();
    }


    private static void MethodScoreEntryP3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine("Please enter the final score for " + StaticGameState.nameC + ".");
        StaticGameState.scoreC = int.Parse(Console.ReadLine()!);
        Console.Write("Thank you for recording this important historical information, ");
        Console.Write(StaticGameState.nameC);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players < 4)
        {
            optionsManager.AddOption("WinnerHUB", MethodWinnerHUB);
        }
        else
        {
            optionsManager.AddOption("ScoreEntryP4", MethodScoreEntryP4);
        }

        optionsManager.PresentOptions();
    }


    private static void MethodScoreEntryP4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine("Please enter the final score for " + StaticGameState.nameD + ".");
        StaticGameState.scoreD = int.Parse(Console.ReadLine()!);
        Console.Write("Thank you for recording this important historical information, ");
        Console.Write(StaticGameState.nameD);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players < 5)
        {
            optionsManager.AddOption("WinnerHUB", MethodWinnerHUB);
        }
        else
        {
            optionsManager.AddOption("ScoreEntryP5", MethodScoreEntryP5);
        }

        optionsManager.PresentOptions();
    }


    private static void MethodScoreEntryP5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.players < 5)
        {
            MethodWinnerHUB();
        }

        Console.WriteLine("Please enter the final score for " + StaticGameState.nameE + ".");
        StaticGameState.scoreE = int.Parse(Console.ReadLine()!);
        Console.Write("Thank you for recording this important historical information, ");
        Console.Write(StaticGameState.nameE);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("WinnerHUB", MethodWinnerHUB);
        optionsManager.PresentOptions();
    }


    private static void MethodENDHuntersEvil2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Overshadowed and Exploited");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "While this history may contain a modicum of inconceivable occurrences that stretch the limits of the imagination, it remains a peculiar story relegated to an obscure place and time. It is a mostly forgotten artifact of an era of pseudo-science and speculation that amounted to very little historical significance.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("For it was not the experimentations of ");
        Console.Write(StaticGameState.playtxt);
        Console.Write(" ");
        Console.Write(
            "ambitious and incredulous scientists that were remembered, it was the Hunters that amassed fame, wealth, and respect on the backs of the superstitious peasants. The disease that wreaked havoc on the countryside was ignored; recast as a demonic presence from folklore; one that could only be kept at bay through the continued vigilance of the Fraternity of Hunters, which of course came at a great financial cost.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Over the next several years, the Fraternity and its members abandoned the town for more lucrative positions within the government. Soon the not-so-secret society became the affluent aristocrats controlling the entirety of the Hungarian political establishment from the shadows. And the family, who once commanded a measure of reverence, were assigned to obscure prefectures of their own across the country.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If this story is to be believed, then their knowledge still remains trapped within the decaying walls of stone estates overlooking the forgotten village of ");
        Console.Write(StaticGameState.townname);
        Console.Write(". The work was finally over.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("THE END?");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodENDWolvesEvil2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Spread of Evil");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "I write these final words under candle-light, from a shelter I have fashioned in the crawl-space beneath the manor. For a desk, a dusty plank of cedar. I try to keep my utensils above the floor which can become musty and dank during my frequent overnight stays: a dull quill, ink, several lengths of charcoal, a ream of parchment. It is no longer safe to sleep in my bed when night falls. The creatures emerge from the shadows to feed on the few souls that still remain, or to irreversibly change them into shambling horrors most unimaginable.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "To think that my work to uncover the genealogy of a mildly successful scientific family would cause me to become consumed by a maelstrom of spreading evil! It is my hope that when I complete this writing (if I complete this writing), that these words will offer a history to condemn these fools and their complicity with demons. The world must know who is responsible. It must condemn the group who coddled darkness and made a mockery of science!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "O God, I hear the creatures again! Their malformed claw-tips scratching at the floorboards! Damn them for what they have done! Damn this infernal work. For it has unleashed a plague upon the land of which there can be no end in sight.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("THE END?");
        optionsManager.PresentOptions();
    }


    private static void Method2pFrenzyALT()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Frenzy Decision");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The Order suggested a single evening, once every few years, where the town becomes a place to unleash all their frustrations at once. They deemed it the night of \"The Frenzy.\" Citing recent advances in the field of psychology, they suggested that controlled indulgence might alleviate the mania they experience.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Given the scientific expertise of the cousins (and possibly with no other stable options), they consulted them in private on this matter, hoping to come to a consensus.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("BID");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("All players take all of their money into their hands. They then secretly choose any amount to place into their right hand to bid on choosing the outcome.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Encouraging");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("the Frenzy will guarantee that experimentation will no longer be considered Creepy, but also introduces other problems.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Not encouraging");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("the Frenzy will maintain the Biology award.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Once all players are ready, reveal the amount of money bid simultaneously. The player that bid the most wins the vote and also ");
        Console.Write("<bold>");
        Console.Write("gains 2VP");
        Console.Write("</bold>");
        Console.Write(". ");
        Console.Write("<italic>");
        Console.Write("(If there is a tie, the player who went last in turn order the previous round wins the bid.)");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Only the player that wins the election must pay their bid to supply. All others return their money to their Estates.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to start the bid...", passage334_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage334_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", Method2pFrenzyALTb);
        optionsManager.PresentOptions();
    }


    private static void MethodGoodFrenzyEvent2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Frenzied Decision");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The Order suggested a single evening, once every few years, where the town becomes a place to unleash all their frustrations at once. They deemed it the night of \"The Frenzy.\" Citing recent advances in the field of psychology, they suggested that controlled indulgence might alleviate the mania they experience.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Given the scientific expertise of the cousins (and possibly with no other stable options), they consulted them in private on this matter, hoping to come to a consensus.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("All players take their Voting tokens into their hands. The players will secretly choose a side to place face up in their palm. Then they will close their fist and extend it to the center of the table.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to encourage the Frenzy. ");
        Console.Write("<italic>");
        Console.Write("This will guarantee that experimentation will no longer be considered Creepy, but creates other problems.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("not");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("encourage the Frenzy. ");
        Console.Write("<italic>");
        Console.Write("This will maintain the Biology award.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Once all players have chosen, they all reveal their votes. Tally the votes and the side with the most votes wins. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the last player in turn order.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here to start the vote...", passage335_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage335_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGoodFrenzyEvent2b);
        optionsManager.PresentOptions();
    }


    private static void Method2pS5SpecialVoteALT()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("BID");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("All players take all of their money into their hands. They then secretly choose any amount to place in their right hand to bid on choosing the outcome.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The winning player will ");
        Console.Write("<bold>");
        Console.Write("gain 3VP");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and have the option to choose if the town gains or rejects electricity. Once all players are ready, reveal the amount of money bid simultaneously. ");
        Console.Write("<italic>");
        Console.Write("(If there is a tie, the player who went last in turn order the previous round wins the bid.)");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Accepting electricity which will ");
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
        Console.Write("Rejecting electricity will support the obstinate masses and ");
        Console.Write("<bold>");
        Console.Write("quell the Angry Mob");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Once all players are ready, reveal the amount of money bid simultaneously. The player that bid the most wins the ability to choose.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Only the player that wins the bid must pay their bid to the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to start the bid...", passage336_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage336_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", Method2pS5SpecialVoteALT2);
        optionsManager.PresentOptions();
    }

    private static void Method2pFrenzyALTb()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Bid Outcome");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The player that won the bid must pay their bid to supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("The winning player immediately gains 2VP and chooses the option below:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("YesFrenzy", MethodYesFrenzy);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("NoFrenzy", MethodNoFrenzy);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodGoodFrenzyEvent2b()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("VOTE OUTCOME");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Once all players have chosen, they all reveal their votes. Tally the votes and the side with the most votes wins. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the last player in turn order.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on the result of your vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("YesFrenzy", MethodYesFrenzy);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("NoFrenzy", MethodNoFrenzy);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodS5SpecialVote2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Vote Outcome");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Tally the votes from all players.");
        Console.WriteLine();
        Console.Write("<italic>");
        Console.Write("(Ties are broken, by the last player in turn order.)");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Choose the option below based on the result of your vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If the majority of votes are YAY, ");
        optionsManager.AddOption("ElecY", MethodElecY);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If the majority of votes are NAY, ");
        optionsManager.AddOption("ElecN", MethodElecN);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Method2pS5SpecialVoteALT2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("BID Outcome");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The player that wins the bid must pay their bid to the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("The winning player immediately gains 3VP and chooses the option below:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("ElecY", MethodElecY);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("ElecN", MethodElecN);
        Console.Write(".");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodUniEvent2UltimateDisease2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("VOTE OUTCOME");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Tally all votes and the side with the most votes wins. ");
        Console.Write("<bold>");
        Console.Write("<italic>");
        Console.Write("Ties are considered a win for the \"yay\" vote.");
        Console.Write("</italic>");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on the result of your vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("UniEvent2-Success", MethodUniEvent2Success);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("UniEvent2-Failure", MethodUniEvent2Failure);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodWolvesVote2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("VOTE OUTCOME");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Tally all the votes and the side with the most votes wins. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the last player in turn order.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on the result of your vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("WolvesVoteCheck", MethodWolvesVoteCheck);
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("TheVialUse", MethodTheVialUse);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodHunterConf3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Donation Outcome");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Count up the total value of the VP on all donated Experiment cards.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If the value is equal to ");
        Console.Write(StaticGameState.huntnum);
        Console.Write(" ");
        Console.Write("or higher, ");
        optionsManager.AddOption("OhYesTheyDead", MethodOhYesTheyDead);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If the value is less, ");
        optionsManager.AddOption("ConfrontationFail", MethodConfrontationFail);
        Console.Write(" ");
        Console.Write("instead.");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodEvilHunter1Event2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Vote Outcome");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Tally all the votes and the side with the most votes wins. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the last player in turn order.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on the result of your vote:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here if you voted to Confront the Hunters. (YAY!", passage351_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here if you voted to Believe the Hunters. (NAY!", passage351_Fragment_1);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage351_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.confront = "yes";
        MethodEvilHunter1EventYes();
        optionsManager.PresentOptions();
    }

    private static void passage351_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.confront = "no";
        MethodGloomyGothic2();
        optionsManager.PresentOptions();
    }


    private static void MethodMayorResolveHunters()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Recompense for Past Leadership");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand the Storybook to ");
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("III. This passage is read out loud in view of all players.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Though memories of the past may be harsh or serene, one cannot deny the significance of those distinctive few whose actions set the gears in motion. ");
        Console.Write(StaticGameState.mayor);
        Console.Write("'s namesake was still whispered amongst the townfolk of ");
        Console.Write(StaticGameState.townname);
        Console.Write(". ");
        Console.Write(StaticGameState.mayor);
        Console.Write("'s contribution to the wellbeing of all may have been acute, but it was noticeable nonetheless.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(StaticGameState.mayor);
        Console.Write("'s family legacy, whether through infamy or prestige, raged onward to press upon the boundaries of science and common decency.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage353_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage353_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodHuntround2);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MayorCoin";
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("gains ");
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            1,
            2
        }));
        Console.Write("VP");
        Console.Write("</bold>");
        Console.Write(". Gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Return the ");
        Console.Write("<bold>");
        Console.Write("Commemorative Mayoral Coin");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the scenario box.");
        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodResolveCharityWolves()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Passion and Empathy");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand the Storybook to ");
        Console.Write(StaticGameState.charity);
        Console.Write(". This passage is read out loud in view of all players.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("For the residents of ");
        Console.Write(StaticGameState.townname);
        Console.Write(", though I shudder at the descriptions of their mongrel countenances, there was deep affection for those thrust into the epic struggle between wild passion and sympathy for the lesser among them. ");
        Console.Write(StaticGameState.charity);
        Console.Write(" III's fiery ambitions inspired the beasts, while their familial legacy of humility and charity - begrudgingly or elsewise - garnered an even deeper admiration.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "There was not a day that went by with a friendly set of claws proudly patting their shoulder or saliva - laden greeting at the local pub. As naive as they were, some even relished the opportunity to donate their labors inside the ominous iron gates upon the hillside.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage354_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage354_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodProsperity2);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_EstateUpgradeBACK";
        Console.Write(StaticGameState.charity);
        Console.Write(" may ");
        Console.Write("<bold>");
        Console.Write("gain a Servant from Lost");
        Console.Write("</bold>");
        Console.Write(" (if possible) and ");
        Console.Write("<bold>");
        Console.Write("returns their <sprite=\"Creepy_Icon\" index=0> token to the start of the <sprite=\"Creepy_Icon\" index=0> Track.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Return the ");
        Console.Write("<bold>");
        Console.Write("Heart ");
        Console.Write("<sprite=\"S1_HeartToken\" index=0>");
        Console.Write(" ");
        Console.Write("token");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the scenario box.");
        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
}