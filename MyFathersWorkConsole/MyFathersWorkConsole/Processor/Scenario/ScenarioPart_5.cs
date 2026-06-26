namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodMWTokenResolve()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Work is Complete");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.gen3pg = 1;
        Console.WriteLine();
        Console.Write(
            "The gathering of clawed monstrosities celebrated with keening wails as the Masterwork was completed in all of its glory. Surely, the legacy of the family would be secured forever. Yet, the watchful, glowing eyes of the crowd did not share this same deference to sentimentality.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "A furious cacophony of growls sounded as the monsters surrounded the experiment. Some scribbled away at notes, copying the formulas and schematics as best as they could while others simply traced every minute detail with their fingers and observed with interest.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It was clear that they would have been much more able to understand and reproduce the results of the experiment if they had been given earlier access to the cousin's work over the years.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage229_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage229_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.round == 10) ? MethodGloomyGothic1 : ((StaticGameState.round == 11) ? MethodGloomyGothic2 : MethodGloomyGothic3)));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "ScoreTrackMarker";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Resolve your Masterwork as normal. Then, for each Experiment under your Masterwork, ");
        Console.Write("<bold>");
        Console.Write("lose 4VP");
        Console.Write("</bold>");
        Console.Write(". Discard all cards under your Masterwork.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodEvilsforgive()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.society == "Order of St. Hubertus")
        {
            Console.Write("<bold>");
            Console.Write("Forgiveness");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "The scientists' doubts were put at ease when a werewolf in a brown sack suit took to the podium to preside over a town meeting. A mixture of lycanthropic beings, horned beasts, and those still holding onto their humanity were in attendance outside the school. The force of the wolf's words caused tears to stream down their cheeks.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "\"We want to shatter those unfortunate stereotypes. We hold no grudges. We want to work with you all, not against you. The child should not be punished for the sins of the father. You are all welcome.\" The werewolf blew their cold nose into their handkerchief as a rumbling cheer rose from the crowd.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("As a token of this myth-shattering event, many handshakes were exchanged that day and a promise was made to press forward into a more modern era; an era where science could improve their lives ten-fold!");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage230_Fragment_0);
            Console.Write("</hook>");
        }
        else if (StaticGameState.hcount == 0)
        {
            MethodEquitableValues();
        }
        else
        {
            Console.Write("<bold>");
            Console.Write("Still Wary");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "In the evenings, the Fraternity gathered in the former Town Hall and celebrated their political takeover of the small town. Observers could hear their loud revelry echo through the streets late into the night. The townsfolk had no reason to doubt their loyalty as it appeared that their activities kept both sickness and superstitions at bay.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("For the family members that had aided them in their efforts, they wore wide false-smiles and offered toasts to their continued partnership. But, for those who had plotted against them, they remained wary.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage230_Fragment_2);
            Console.Write("</hook>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage230_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEquitableValues);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MastersStudy";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Master's Study");
        Console.Write("</bold>");
        Console.Write(" Vanity Estate Upgrade tiles.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Choose:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Starting with the player in last place and continuing in ascending order by point total, each player chooses a ");
        Console.Write("<bold>");
        Console.Write("Master's Study");
        Console.Write("</bold>");
        Console.Write(" tile and adds it to their Estate. No additional cost is paid for a new plot to place this tile. ");
        Console.Write("<italic>");
        Console.Write("(Ties are broken by the player that went later in turn order in the previous round.)");
        Console.Write("</italic>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void passage230_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEquitableValues);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        if (StaticGameState.allyA == "wolves")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyB == "wolves")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyC == "wolves")
        {
            Console.Write(StaticGameState.nameC);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyD == "wolves")
        {
            Console.Write(StaticGameState.nameD);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyE == "wolves")
        {
            Console.Write(StaticGameState.nameE);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
        }

        if (!(StaticGameState.allyA == "wolves") || !(StaticGameState.allyB == "wolves") || !(StaticGameState.allyC == "wolves") || !(StaticGameState.allyD == "wolves") || !(StaticGameState.allyE == "wolves"))
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
        }

        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodPanaceaUnleashCons1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.pana == "unleash")
        {
            Console.Write("<bold>");
            Console.Write("Whispers Abate");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "With the passing of the generation, the hideous and well-founded rumors regarding the grisly demise and otherwise negative treatment of servants in the family's households faded into history. As considerably misguided as it was, the allure of steady employ once again attracted new applicants to the estates once more.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage232_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            MethodNewMaster();
        }

        optionsManager.PresentOptions();
    }

    private static void passage232_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodNewMaster);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Servant";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any players with a Servant in the game box retrieves it from the box and adds it to Lost.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodPanaceaUnleashCons2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.pana == "unleash")
        {
            Console.Write("<bold>");
            Console.Write("Whispers Abate");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "With the passing of the generation, the hideous and well-founded rumors regarding the grisly demise and otherwise negative treatment of servants within the family's households faded into history. As considerably misguided as it would have been, the allure of steady employ once again attracted new applicants to their estates.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage233_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            MethodUniversity1();
        }

        optionsManager.PresentOptions();
    }

    private static void passage233_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodUniversity1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Servant";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any players with a Servant in the game box may retrieve it from the box and place it in Lost.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodNewMaster3E()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.costE == "Biology")
        {
            StaticGameState.cost2E = "Animal";
        }

        if (StaticGameState.costE == "Engineering")
        {
            StaticGameState.cost2E = "Gear";
        }

        if (StaticGameState.costE == "Chemistry")
        {
            StaticGameState.cost2E = "Bottle";
        }

        Console.WriteLine("Give your creation a new, majestic name:");
        StaticGameState.creationE = Console.ReadLine()!;
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("The ");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "Infamous",
            "Transcendent",
            "Monumental",
            "Nefarious",
            "Unspeakable",
            "Legendary",
            "Noble",
            "Phenomenal",
            "Stunning",
            "Masterful",
            "Insidious"
        }));
        Console.Write(" ");
        Console.Write(StaticGameState.creationE);
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        MethodMWCreationHubE();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With my own destiny determined, I resolved to forge a new path into the future and create my Masterwork.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("You may check the cost of completing your new Masterwork at any time by clicking on your name on the main Storybook screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("NewMHub", MethodNewMHub);
        optionsManager.PresentOptions();
    }


    private static void MethodMWCreationHubE()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.typeE == "creature")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Animals, 5 Biology, 1 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 20VP.");
            Console.WriteLine();
            Console.Write("Gain 1 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(", Move the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else if (StaticGameState.typeE == "power")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Animal, 1 ");
            Console.Write(StaticGameState.cost2E);
            Console.Write(", 3 Biology, 3 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 19VP.");
            Console.WriteLine();
            Console.Write("Gain 1 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else if (StaticGameState.typeE == "robot")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Gears, 5 Engineering, 1 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 20VP.");
            Console.WriteLine();
            Console.Write("Gain 1 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else if (StaticGameState.typeE == "weapon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Gear, 1 ");
            Console.Write(StaticGameState.cost2E);
            Console.Write(", 4 Engineering, 2 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 19VP.");
            Console.WriteLine();
            Console.Write("Gain 2 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else if (StaticGameState.typeE == "medicine")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Chemicals, 4 Chemistry, 2 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 21VP.");
            Console.WriteLine();
            Console.Write("Gain 2 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else if (StaticGameState.typeE == "drug")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Bottle, 1 ");
            Console.Write(StaticGameState.cost2E);
            Console.Write(", 3 Chemistry, 3 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 19VP.");
            Console.WriteLine();
            Console.Write("Gain 1 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else if (StaticGameState.typeE == "demon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Bodies, 4 Occult, 1 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 21VP.");
            Console.WriteLine();
            Console.Write("Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }
        else
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationE);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Body, 1 ");
            Console.Write(StaticGameState.cost2E);
            Console.Write(", 3 Occult, 3 ");
            Console.Write(StaticGameState.costE);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Reward:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("Gain 20VP.");
            Console.WriteLine();
            Console.Write("Gain 1 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(", Gain 2 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(", Move the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(".");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<i>Note: This Masterwork still requires 1 A Experiment, 2 B Experiments, and 3 C Experiments to be completed.</i>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodMWCompleteHubE()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            "The Work is Done",
            "I Have Done the Impossible",
            "My Legacy is Ensured",
            "AH HA HA HAAAAA!!!",
            "My Glorious Creation",
            "The Glory is Mine Forever!"
        }));
        Console.Write(" ");
        Console.Write("- ");
        Console.Write(StaticGameState.nameE);
        Console.Write(" ");
        Console.Write("- Journal Entry Excerpt");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.typeE == "creature")
        {
            Console.Write("Upon the stroke of midnight, lightning struck metal, sending a terrible electrical current through the machinery. My creation awoke, and with wild eyes gazed upon me, its creator. I had done it! I had created life!");
        }
        else if (StaticGameState.typeE == "power")
        {
            Console.Write("To see my work in the flesh, to see ");
            Console.Write(StaticGameState.creationE);
            Console.Write(" finally realized; the passion of the moment overwhelmed my senses. I had done it. I shook my fist at God and all who doubted me! You were wrong! I am invincible!");
        }
        else if (StaticGameState.typeE == "robot")
        {
            Console.Write("A brief, blinding flash and the work was done. I threw my goggles to the floor to gaze upon my creation with my own eyes - ");
            Console.Write(StaticGameState.creationE);
            Console.Write(". The polished metal surface whirred with interior mechanisms churning - then, glorious motion! Oh wondrous automaton, with you by my side the scientific world will be humbled!");
        }
        else if (StaticGameState.typeE == "weapon")
        {
            Console.Write(
                "I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (StaticGameState.typeE == "medicine")
        {
            Console.Write("I tapped the glass bottle, watching the liquid inside swirl and glow with the purity of the mixture. The ");
            Console.Write(StaticGameState.creationE);
            Console.Write(
                " had been a stunning success and once mass production could be attained, my family's legacy would be secure. I laughed. Then, laughed again. My cacophonous laughter echoed off the stone walls of my estate for years to come.");
        }
        else if (StaticGameState.typeE == "drug")
        {
            Console.Write("I observed the effects as the syringe filled with ");
            Console.Write(StaticGameState.creationE);
            Console.Write(
                " emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (StaticGameState.typeD == "demon")
        {
            Console.Write("The world darkened around me as the ");
            Console.Write(StaticGameState.creationE);
            Console.Write(
                " emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, \"Master.\" I had done it. I was now in control and the world would rue the day they doubted ");
            Console.Write(StaticGameState.nameE);
            Console.Write(" III!");
        }
        else
        {
            Console.Write("The preparations proved tedious, but the resulting wave of spiritual energy as the ritual was completed left me standing in awe of my creation. The ");
            Console.Write(StaticGameState.creationE);
            Console.Write(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }

        optionsManager.PresentOptions();
    }


    private static void MethodCureNegCons()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Distrust in Medicine");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "With the Hospital slowly falling into disrepair, the church took great measures to warn the populace of the dangers of inoculation, espousing the virtues of alternative homeopathic remedies and pious living. Inevitably, this led to clusters of Yellow Fever once again appearing within the region.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Having no target for their anger, in a befuddled daze, they turned against the scientist responsible for introducing the cure, without whom this self-inflicted moral dilemma would never have existed.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage240_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage240_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodOptiontoKillStart);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "AngryMob_Icon";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Move the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" token 1 space to the left. ");
        Console.Write("</bold>");
        if (StaticGameState.fevercure == "" || StaticGameState.fevercure == 0)
        {
            StaticGameState.fevercure = StaticGameState.nameA;
        }

        Console.Write(StaticGameState.fevercure);
        Console.Write(" immediately ");
        Console.Write("<bold>");
        Console.Write("gains 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" and ");
        Console.Write("<bold>");
        Console.Write("gains 1 ");
        Console.Write("<sprite=\"Insanity_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodUniversity1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SEARCH FOR THE CURE - Early Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 19;
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "AngryMobSetup1";
        Console.WriteLine();
        Console.Write("Turn to page ");
        Console.Write("<bold>");
        Console.Write("10");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("of the Village Chronicle.");
        Console.WriteLine();
        Console.Write("Place the Suspicion Marker on space ");
        Console.Write("<bold>");
        if (StaticGameState.University1 == 0 || StaticGameState.University1 == "")
        {
            StaticGameState.University1 = 1;
            StaticGameState.tracker = int.Parse(StaticGameState.tracker) + 2;
            if (StaticGameState.players == 4)
            {
                StaticGameState.tracker = int.Parse(StaticGameState.tracker) + 1;
            }

            if (StaticGameState.players == 5)
            {
                StaticGameState.tracker = int.Parse(StaticGameState.tracker) + 1;
            }
        }

        Console.Write(StaticGameState.tracker);
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token one space to the left. ");
        if (StaticGameState.players == 3)
        {
            Console.Write("Then, since this is a 3-player game, pass the starting player marker clockwise 1 additional time.");
        }

        Console.Write("</setupStyle>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hubTitle>");
        Console.Write("<bold>");
        Console.Write("Nobel Prize in Medicine");
        Console.Write("</bold>");
        Console.Write("</hubTitle>");
        Console.WriteLine();
        Console.Write("<hubDetails>");
        Console.Write("The scientific world has finally taken notice of ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write("and its ");
        Console.Write(StaticGameState.playtxt);
        Console.Write(" ");
        Console.Write("ingenious scholars. The absurdity of it all! Not only does this hamper their ability to experiment freely, it also gives their work mainstream merit.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("At the End of the Generation, the ");
        Console.Write("<bold>");
        Console.Write("least ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("player will be awarded this prestigious award and ");
        Console.Write("<bold>");
        Console.Write("lose 7VP.");
        Console.Write("</bold>");
        Console.Write("</hubDetails>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hubTitle>");
        Console.Write("<bold>");
        Console.Write("Perfect Mental Balance");
        Console.Write("</bold>");
        Console.Write("</hubTitle>");
        Console.WriteLine();
        Console.Write("<hubDetails>");
        Console.Write("At the end of the Generation, if your piece is on space ");
        Console.Write(StaticGameState.mental);
        Console.Write(" ");
        Console.Write("of the ");
        Console.Write("<sprite=\"Insanity_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("Track, you will ");
        Console.Write("<bold>");
        Console.Write("gain 5VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here at the end of the round to move to the next round...", passage258_Fragment_0);
        Console.Write("</hook>");
        Console.Write("</hubDetails>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage258_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("University1", MethodUniEquity1);
        optionsManager.PresentOptions();
    }

    private static void MethodEvilWolvesEventStart()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Monster Without");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The Order of St. Hubertus' Lodge held a dark secret in the miasmic recesses beneath the edifice above, and after navigating a steep spiraling stone staircase, the cousins found themselves in a large stone room: a makeshift laboratory deep enough beneath the earth that the walls were warm with heat. Glass baubles and pilfered tools were stacked haphazardly around several wooden workspaces with failed experiments and devices thrown into metal waste bins beneath.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The Lodge's caretaker extended a long clawed hand towards the center of the room, where a large circular stone well squatted. When they peered inside, they saw the infernal spawning grounds. Slime-covered beasts wallowed within a murky pit sloshing with the putrid stench of rotten meat. They wailed in unseen torment as the caretakers of the Order snapped coiled whips to frighten the malformed wretches into submission.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The caretaker spoke in a harsh, gravelly tone, \"You are free to use this place as you wish. All that we ask is for a single experiment when we call upon you. Alternatively, our children here are always so very hungry.\"");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It was a dark boon indeed to be offered a place in town to ");
        Console.Write("<bold>");
        Console.Write("perform experiments");
        Console.Write("</bold>");
        Console.Write(", but what would this horrible convenience cost them?");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("VialCharity", MethodVialCharity);
        optionsManager.PresentOptions();
    }
    
    private static void MethodroundEndKnowledge()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Curse of Knowledge");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.round == 16)
        {
            Console.Write("The townsfolk chose to remain ignorant of the technological advances of the age. Not only did they begrudge and mistrust the wealth of knowledge that the cousins had accrued, they hated them for it.");
        }
        else
        {
            Console.Write(
                "The hostility had not abated. If anything, time had proven the townsfolk steadfast in their unsophisticated point of view. The perils of blind faith and excessive drink manifested in the gloom that surrounded the ashen streets.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage261_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage261_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.round == 16) ? MethodCureNegCons : MethodNoUniMayornCreepy));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Each player gains ");
        Console.Write("<bold>");
        Console.Write("1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for ");
        Console.Write("<bold>");
        Console.Write("each");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Knowledge cube in their Quarters.");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodHuntersHUBcode()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.mon =
        [
            "Strigoi",
            "Moon Presence",
            "Manticore",
            "Golem",
            "Wight",
            "Pricolici",
            "Troll",
            "Priest"
        ];
        StaticGameState.mon.Shuffle();
        StaticGameState.monster1 = StaticGameState.mon[0];
        StaticGameState.monster2 = StaticGameState.mon[1];
        StaticGameState.monster3 = StaticGameState.mon[2];
        StaticGameState.monster4 = StaticGameState.mon[3];
        StaticGameState.monster5 = StaticGameState.mon[4];
        StaticGameState.monster3 = StaticGameState.mon[5];
        StaticGameState.monster4 = StaticGameState.mon[6];
        StaticGameState.monster5 = StaticGameState.mon[7];
        StaticGameState.rew =
        [
            "Occult Knowledge",
            "Chemistry Knowledge",
            "Biology Knowledge",
            "Engineering Knowledge",
            "Chemicals",
            "Animals",
            "Gears",
            "$"
        ];
        StaticGameState.rew.Shuffle();
        StaticGameState.reward1 = StaticGameState.rew[0];
        StaticGameState.reward2 = StaticGameState.rew[1];
        StaticGameState.reward3 = StaticGameState.rew[2];
        StaticGameState.reward4 = StaticGameState.rew[3];
        StaticGameState.reward5 = StaticGameState.rew[4];
        StaticGameState.reward6 = StaticGameState.rew[5];
        StaticGameState.reward7 = StaticGameState.rew[6];
        StaticGameState.reward8 = StaticGameState.rew[7];
        if (StaticGameState.players == 3)
        {
            StaticGameState.hunttemp =
            [
                1,
                2,
                3
            ];
            StaticGameState.hunttemp.Shuffle();
            StaticGameState.hunt1a = StaticGameState.hunttemp[0];
            StaticGameState.hunt1b = StaticGameState.hunttemp[1];
            StaticGameState.hunt2a = StaticGameState.hunttemp[2];
            StaticGameState.hunt2b = StaticGameState.hunttemp[1];
        }

        if (StaticGameState.players == 4)
        {
            StaticGameState.hunttemp =
            [
                1,
                2,
                3,
                4
            ];
            StaticGameState.hunttemp.Shuffle();
            StaticGameState.hunt1a = StaticGameState.hunttemp[0];
            StaticGameState.hunt1b = StaticGameState.hunttemp[1];
            StaticGameState.hunt2a = StaticGameState.hunttemp[2];
            StaticGameState.hunt2b = StaticGameState.hunttemp[3];
        }

        if (StaticGameState.players == 5)
        {
            StaticGameState.hunttemp =
            [
                1,
                2,
                3,
                4,
                5
            ];
            StaticGameState.hunttemp.Shuffle();
            StaticGameState.hunt1a = StaticGameState.hunttemp[0];
            StaticGameState.hunt1b = StaticGameState.hunttemp[1];
            StaticGameState.hunt2a = StaticGameState.hunttemp[2];
            StaticGameState.hunt2b = StaticGameState.hunttemp[3];
            StaticGameState.hunt3a = StaticGameState.hunttemp[4];
        }

        if (StaticGameState.hunt1a == 1)
        {
            StaticGameState.h1a = StaticGameState.nameA;
        }

        if (StaticGameState.hunt1a == 2)
        {
            StaticGameState.h1a = StaticGameState.nameB;
        }

        if (StaticGameState.hunt1a == 3)
        {
            StaticGameState.h1a = StaticGameState.nameC;
        }

        if (StaticGameState.hunt1a == 4)
        {
            StaticGameState.h1a = StaticGameState.nameD;
        }

        if (StaticGameState.hunt1a == 5)
        {
            StaticGameState.h1a = StaticGameState.nameE;
        }

        if (StaticGameState.hunt1b == 1)
        {
            StaticGameState.h1b = StaticGameState.nameA;
        }

        if (StaticGameState.hunt1b == 2)
        {
            StaticGameState.h1b = StaticGameState.nameB;
        }

        if (StaticGameState.hunt1b == 3)
        {
            StaticGameState.h1b = StaticGameState.nameC;
        }

        if (StaticGameState.hunt1b == 4)
        {
            StaticGameState.h1b = StaticGameState.nameD;
        }

        if (StaticGameState.hunt1b == 5)
        {
            StaticGameState.h1b = StaticGameState.nameE;
        }

        if (StaticGameState.hunt2a == 1)
        {
            StaticGameState.h2a = StaticGameState.nameA;
        }

        if (StaticGameState.hunt2a == 2)
        {
            StaticGameState.h2a = StaticGameState.nameB;
        }

        if (StaticGameState.hunt2a == 3)
        {
            StaticGameState.h2a = StaticGameState.nameC;
        }

        if (StaticGameState.hunt2a == 4)
        {
            StaticGameState.h2a = StaticGameState.nameD;
        }

        if (StaticGameState.hunt2a == 5)
        {
            StaticGameState.h2a = StaticGameState.nameE;
        }

        if (StaticGameState.hunt2b == 1)
        {
            StaticGameState.h2b = StaticGameState.nameA;
        }

        if (StaticGameState.hunt2b == 2)
        {
            StaticGameState.h2b = StaticGameState.nameB;
        }

        if (StaticGameState.hunt2b == 3)
        {
            StaticGameState.h2b = StaticGameState.nameC;
        }

        if (StaticGameState.hunt2b == 4)
        {
            StaticGameState.h2b = StaticGameState.nameD;
        }

        if (StaticGameState.hunt2b == 5)
        {
            StaticGameState.h2b = StaticGameState.nameE;
        }

        if (StaticGameState.hunt1c == 1)
        {
            StaticGameState.h2c = StaticGameState.nameA;
        }

        if (StaticGameState.hunt1c == 2)
        {
            StaticGameState.h2c = StaticGameState.nameB;
        }

        if (StaticGameState.hunt1c == 3)
        {
            StaticGameState.h2c = StaticGameState.nameC;
        }

        if (StaticGameState.hunt1c == 4)
        {
            StaticGameState.h2c = StaticGameState.nameD;
        }

        if (StaticGameState.hunt1c == 5)
        {
            StaticGameState.h2c = StaticGameState.nameE;
        }

        if (StaticGameState.players == 2)
        {
            StaticGameState.h1a = StaticGameState.nameA;
            StaticGameState.h2a = StaticGameState.nameA;
            StaticGameState.h1b = StaticGameState.nameB;
            StaticGameState.h2b = StaticGameState.nameB;
        }

        Console.WriteLine();
        MethodEvilsforgive();
        optionsManager.PresentOptions();
    }


    private static void MethodTieredRewards1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Reckoning");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("The messenger from the Order thanked the scientists and vowed to return once again after a time.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage263_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage263_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic2);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_WolfToken";
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
        Console.Write(". ");
        Console.Write("<i>If you cannot lose a Servant, lose 3VP instead.</i>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void passage263_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Click to continue...", passage263_Fragment_0);
        optionsManager.PresentOptions();
    }


    private static void MethodCannotParticipate()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("In the Blood");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("However, at their final moment of triumph, an unfortunate occurrence in the family's past could have potentially unraveled their attempt to overthrow the Hunters' dominion over this fair village.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "In the interim evenings before the event could begin, for some, the very thought of confronting the Hunters made them desperately ill. It was as if some occult power had a hold over their senses. This nausea quickly turned to resolve and some even questioned why they had ever doubted the veracity of the Hunters' claims.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("But, how could their parents have envisioned a strong curse would have been placed upon them when they decided to accept the ");
        Console.Write("<bold>");
        Console.Write("cure");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("so many years ago?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage264_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage264_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodHunterConf2);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_DiseaseExperiment";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player with a ");
        Console.Write("<bold>");
        Console.Write("STORED Hereditary Disease Experiment");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("card cannot donate an Experiment to this Event. They immediately ");
        Console.Write("<bold>");
        Console.Write("Lose 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and return the stored ");
        Console.Write("<bold>");
        Console.Write("Hereditary Disease Experiment");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
}