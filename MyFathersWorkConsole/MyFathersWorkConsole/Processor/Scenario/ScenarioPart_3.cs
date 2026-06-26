namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodNewMaster1A()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand this Storybook device to ");
        Console.Write(StaticGameState.nameA);
        Console.Write(" ");
        Console.Write("and do not allow any other players to see the screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.trig = 1;
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Once you are ready", passage133_Fragment_4);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage133_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disA = "biology";
        MethodNewMaster2A();
        optionsManager.PresentOptions();
    }

    private static void passage133_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disA = "engineering";
        MethodNewMaster2A();
        optionsManager.PresentOptions();
    }

    private static void passage133_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disA = "chemistry";
        MethodNewMaster2A();
        optionsManager.PresentOptions();
    }

    private static void passage133_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disA = "occult";
        MethodNewMaster2A();
        optionsManager.PresentOptions();
    }

    private static void passage133_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Masterwork of My Own - ");
        Console.Write(StaticGameState.nameA);
        Console.Write(" III");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation is from which scientific discipline?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Biology.", passage133_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Engineering.", passage133_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Chemistry.", passage133_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Occult.", passage133_Fragment_3);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void MethodNewMaster2A()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("What Type of Glorious Creation");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With my unique ");
        Console.Write(StaticGameState.disA);
        Console.Write(" ");
        Console.Write("skills, this creation was already more focused and impressive than ever before. But, what ingenious type of creation would I explore?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation could be described as what type?");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.disA == "biology")
        {
            StaticGameState.costA = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Creature.", passage134_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Superpower.", passage134_Fragment_1);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disA == "engineering")
        {
            StaticGameState.costA = StaticGameState.GetRandom(new[]
            {
                "Biology",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Robot.", passage134_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Weapon.", passage134_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disA == "chemistry")
        {
            StaticGameState.costA = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Medicine.", passage134_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Drug.", passage134_Fragment_5);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else
        {
            StaticGameState.costA = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Demonic Creature.", passage134_Fragment_6);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Ritual.", passage134_Fragment_7);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "creature";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "power";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "robot";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "weapon";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "medicine";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "drug";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_6()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "demon";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }

    private static void passage134_Fragment_7()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeA = "ritual";
        MethodNewMaster3A();
        optionsManager.PresentOptions();
    }


    private static void MethodNewMaster3A()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.costA == "Biology")
        {
            StaticGameState.cost2A = "Animal";
        }

        if (StaticGameState.costA == "Engineering")
        {
            StaticGameState.cost2A = "Gear";
        }

        if (StaticGameState.costA == "Chemistry")
        {
            StaticGameState.cost2A = "Bottle";
        }

        Console.WriteLine("Give your creation a new, majestic name:");
        StaticGameState.creationA = Console.ReadLine()!;

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
        Console.Write(StaticGameState.creationA);
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        MethodMWCreationHubA();
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
        optionsManager.AddOption("NewMaster1B", MethodNewMaster1B);
        optionsManager.PresentOptions();
    }
    
    private static void MethodNewMaster()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Masters of Their Own Destiny");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.gen3pg = 0;
        Console.WriteLine();
        Console.Write("It seemed the pervasive gloom of ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write(
            "had infected the halls of the great estates. For when the cousins explored the musty recesses of their inherited homes, they discovered great underground laboratories left in startling disarray. Volumetric flasks lay shattered amongst the rusted remains of mechanical devices misshapen and strewn across the floor. And most disconcerting, the tattered remains of a most exceptional experiment. Oh the folly of the depressed and aged mind!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "To those of lesser imagination, this may have been the death knell of their ambitions, but their youthful exuberance could not be shackled by the capricious whims of their progenitors! If their family could not continue the generations of hard work, they would create their own legacy!");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("NewMaster1A", MethodNewMaster1A);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
    
    private static void MethodMWCreationHubA()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.typeA == "creature")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Animals, 5 Biology, 1 ");
            Console.Write(StaticGameState.costA);
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
        else if (StaticGameState.typeA == "power")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Animal, 1 ");
            Console.Write(StaticGameState.cost2A);
            Console.Write(", 3 Biology, 3 ");
            Console.Write(StaticGameState.costA);
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
        else if (StaticGameState.typeA == "robot")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Gears, 5 Engineering, 1 ");
            Console.Write(StaticGameState.costA);
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
        else if (StaticGameState.typeA == "weapon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Gear, 1 ");
            Console.Write(StaticGameState.cost2A);
            Console.Write(", 4 Engineering, 2 ");
            Console.Write(StaticGameState.costA);
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
        else if (StaticGameState.typeA == "medicine")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Chemicals, 4 Chemistry, 2 ");
            Console.Write(StaticGameState.costA);
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
        else if (StaticGameState.typeA == "drug")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Bottle, 1 ");
            Console.Write(StaticGameState.cost2A);
            Console.Write(", 3 Chemistry, 3 ");
            Console.Write(StaticGameState.costA);
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
        else if (StaticGameState.typeA == "demon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Bodies, 4 Occult, 1 ");
            Console.Write(StaticGameState.costA);
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
            Console.Write(StaticGameState.creationA);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Body, 1 ");
            Console.Write(StaticGameState.cost2A);
            Console.Write(", 3 Occult, 3 ");
            Console.Write(StaticGameState.costA);
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
    
    private static void MethodMWCompleteHubA()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
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
        Console.Write(StaticGameState.nameA);
        Console.Write(" ");
        Console.Write("- Journal Entry Excerpt");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.typeA == "creature")
        {
            Console.Write("Upon the stroke of midnight, lightning struck metal, sending a terrible electrical current through the machinery. My creation awoke, and with wild eyes gazed upon me, its creator. I had done it! I had created life!");
        }
        else if (StaticGameState.typeA == "power")
        {
            Console.Write("To see my work in the flesh, to see ");
            Console.Write(StaticGameState.creationA);
            Console.Write(" finally realized; the passion of the moment overwhelmed my senses. I had done it. I shook my fist at God and all who doubted me! You were wrong! I am invincible!");
        }
        else if (StaticGameState.typeA == "robot")
        {
            Console.Write("A brief, blinding flash and the work was done. I threw my goggles to the floor to gaze upon my creation with my own eyes - ");
            Console.Write(StaticGameState.creationA);
            Console.Write(". The polished metal surface whirred with interior mechanisms churning - then, glorious motion! Oh wondrous automaton, with you by my side the scientific world will be humbled!");
        }
        else if (StaticGameState.typeA == "weapon")
        {
            Console.Write(
                "I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (StaticGameState.typeA == "medicine")
        {
            Console.Write("I tapped the glass bottle, watching the liquid inside swirl and glow with the purity of the mixture. The ");
            Console.Write(StaticGameState.creationA);
            Console.Write(
                " had been a stunning success and once mass production could be attained, my family's legacy would be secure. I laughed. Then, laughed again. My cacophonous laughter echoed off the stone walls of my estate for years to come.");
        }
        else if (StaticGameState.typeA == "drug")
        {
            Console.Write("I observed the effects as the syringe filled with ");
            Console.Write(StaticGameState.creationA);
            Console.Write(
                " emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (StaticGameState.typeA == "demon")
        {
            Console.Write("The world darkened around me as the ");
            Console.Write(StaticGameState.creationA);
            Console.Write(
                " emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, \"Master.\" I had done it. I was now in control and the world would rue the day they doubted ");
            Console.Write(StaticGameState.nameA);
            Console.Write(" III!");
        }
        else
        {
            Console.Write("The preparations proved tedious, but the resulting wave of spiritual energy as the ritual was completed left me standing in awe of my creation. The ");
            Console.Write(StaticGameState.creationA);
            Console.Write(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }

        optionsManager.PresentOptions();
    }
    
    private static void MethodNewMaster1B()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand this Storybook device to ");
        Console.Write(StaticGameState.nameB);
        Console.Write(" ");
        Console.Write("and do not allow any other players to see the screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.trig = 2;
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Once you are ready", passage139_Fragment_4);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage139_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disB = "biology";
        MethodNewMaster2B();
        optionsManager.PresentOptions();
    }

    private static void passage139_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disB = "engineering";
        MethodNewMaster2B();
        optionsManager.PresentOptions();
    }

    private static void passage139_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disB = "chemistry";
        MethodNewMaster2B();
        optionsManager.PresentOptions();
    }

    private static void passage139_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disB = "occult";
        MethodNewMaster2B();
        optionsManager.PresentOptions();
    }

    private static void passage139_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Masterwork of My Own - ");
        Console.Write(StaticGameState.nameB);
        Console.Write(" III");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation is from which scientific discipline?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Biology.", passage139_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Engineering.", passage139_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Chemistry.", passage139_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Occult.", passage139_Fragment_3);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void MethodMWComplete()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.tempcomp == StaticGameState.nameA)
        {
            MethodMWCompleteHubA();
        }

        if (StaticGameState.tempcomp == StaticGameState.nameB)
        {
            MethodMWCompleteHubB();
        }

        if (StaticGameState.tempcomp == StaticGameState.nameC)
        {
            MethodMWCompleteHubC();
        }

        if (StaticGameState.tempcomp == StaticGameState.nameD)
        {
            MethodMWCompleteHubD();
        }

        if (StaticGameState.tempcomp == StaticGameState.nameE)
        {
            MethodMWCompleteHubE();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Then, collect your ");
        MethodAllMWRewards();
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


    private static void MethodMWCheck()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.tempcheck == StaticGameState.nameA)
        {
            MethodMWCreationHubA();
        }
        else if (StaticGameState.tempcheck == StaticGameState.nameB)
        {
            MethodMWCreationHubB();
        }
        else if (StaticGameState.tempcheck == StaticGameState.nameC)
        {
            MethodMWCreationHubC();
        }
        else if (StaticGameState.tempcheck == StaticGameState.nameD)
        {
            MethodMWCreationHubD();
        }
        else if (StaticGameState.tempcheck == StaticGameState.nameE)
        {
            MethodMWCreationHubE();
        }

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

        optionsManager.PresentOptions();
    }


    private static void MethodMWTemp()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on your name below to view the Masterwork Recipe:");
        Console.Write("</bold>");
        StaticGameState.gen3pg = 1;
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption((string)StaticGameState.nameA + " III", passage142_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption((string)StaticGameState.nameB + " III", passage142_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players > 2)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameC + " III", passage142_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        if (StaticGameState.players > 3)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameD + " III", passage142_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        if (StaticGameState.players > 4)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameE + " III", passage142_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        optionsManager.PresentOptions();
    }

    private static void passage142_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcheck = StaticGameState.nameA;
        MethodMWCheck();
        optionsManager.PresentOptions();
    }

    private static void passage142_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcheck = StaticGameState.nameB;
        MethodMWCheck();
        optionsManager.PresentOptions();
    }

    private static void passage142_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcheck = StaticGameState.nameC;
        MethodMWCheck();
        optionsManager.PresentOptions();
    }

    private static void passage142_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcheck = StaticGameState.nameD;
        MethodMWCheck();
        optionsManager.PresentOptions();
    }

    private static void passage142_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcheck = StaticGameState.nameE;
        MethodMWCheck();
        optionsManager.PresentOptions();
    }


    private static void MethodMWCompleteName()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Click on your name below to view the Masterwork Recipe and confirm that it is complete:");
        Console.Write("</bold>");
        StaticGameState.gen3pg = 1;
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption((string)StaticGameState.nameA + " III", passage143_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption((string)StaticGameState.nameB + " III", passage143_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players > 2)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameC + " III", passage143_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        if (StaticGameState.players > 3)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameD + " III", passage143_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
        }

        if (StaticGameState.players > 4)
        {
            Console.Write("<hook>");
            optionsManager.AddOption((string)StaticGameState.nameE + " III", passage143_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        optionsManager.PresentOptions();
    }

    private static void passage143_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcomp = StaticGameState.nameA;
        StaticGameState.tempcheck = StaticGameState.nameA;
        MethodMWCheckComplete();
        optionsManager.PresentOptions();
    }

    private static void passage143_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcomp = StaticGameState.nameB;
        StaticGameState.tempcheck = StaticGameState.nameB;
        MethodMWCheckComplete();
        optionsManager.PresentOptions();
    }

    private static void passage143_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcomp = StaticGameState.nameC;
        StaticGameState.tempcheck = StaticGameState.nameC;
        MethodMWCheckComplete();
        optionsManager.PresentOptions();
    }

    private static void passage143_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcomp = StaticGameState.nameD;
        StaticGameState.tempcheck = StaticGameState.nameD;
        MethodMWCheckComplete();
        optionsManager.PresentOptions();
    }

    private static void passage143_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.tempcomp = StaticGameState.nameE;
        StaticGameState.tempcheck = StaticGameState.nameE;
        MethodMWCheckComplete();
        optionsManager.PresentOptions();
    }


    private static void MethodAllMWRewards()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.tempcomp == StaticGameState.nameA)
        {
            if (StaticGameState.typeA == "creature")
            {
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
            else if (StaticGameState.typeA == "power")
            {
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
            else if (StaticGameState.typeA == "robot")
            {
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
            else if (StaticGameState.typeA == "weapon")
            {
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
            else if (StaticGameState.typeA == "medicine")
            {
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
            else if (StaticGameState.typeA == "drug")
            {
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
            else if (StaticGameState.typeA == "demon")
            {
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
        }

        if (StaticGameState.tempcomp == StaticGameState.nameB)
        {
            if (StaticGameState.typeB == "creature")
            {
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
            else if (StaticGameState.typeB == "power")
            {
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
            else if (StaticGameState.typeB == "robot")
            {
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
            else if (StaticGameState.typeB == "weapon")
            {
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
            else if (StaticGameState.typeB == "medicine")
            {
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
            else if (StaticGameState.typeB == "drug")
            {
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
            else if (StaticGameState.typeB == "demon")
            {
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
        }

        if (StaticGameState.tempcomp == StaticGameState.nameC)
        {
            if (StaticGameState.typeC == "creature")
            {
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
            else if (StaticGameState.typeC == "power")
            {
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
            else if (StaticGameState.typeC == "robot")
            {
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
            else if (StaticGameState.typeC == "weapon")
            {
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
            else if (StaticGameState.typeC == "medicine")
            {
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
            else if (StaticGameState.typeC == "drug")
            {
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
            else if (StaticGameState.typeC == "demon")
            {
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
        }

        if (StaticGameState.tempcomp == StaticGameState.nameD)
        {
            if (StaticGameState.typeD == "creature")
            {
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
            else if (StaticGameState.typeD == "power")
            {
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
            else if (StaticGameState.typeD == "robot")
            {
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
            else if (StaticGameState.typeD == "weapon")
            {
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
            else if (StaticGameState.typeD == "medicine")
            {
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
            else if (StaticGameState.typeD == "drug")
            {
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
            else if (StaticGameState.typeD == "demon")
            {
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
        }

        if (StaticGameState.tempcomp == StaticGameState.nameE)
        {
            if (StaticGameState.typeE == "creature")
            {
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
        }

        optionsManager.PresentOptions();
    }


    private static void MethodNewMaster2B()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("What Type of Glorious Creation");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With my unique ");
        Console.Write(StaticGameState.disB);
        Console.Write(" ");
        Console.Write("skills, this creation was already more focused and impressive than ever before. But, what ingenious type of creation would I explore?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation could be described as what type?");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.disB == "biology")
        {
            StaticGameState.costB = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Creature.", passage145_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Superpower.", passage145_Fragment_1);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disB == "engineering")
        {
            StaticGameState.costB = StaticGameState.GetRandom(new[]
            {
                "Biology",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Robot.", passage145_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Weapon.", passage145_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disB == "chemistry")
        {
            StaticGameState.costB = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Medicine.", passage145_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Drug.", passage145_Fragment_5);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else
        {
            StaticGameState.costB = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Demonic Creature.", passage145_Fragment_6);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Ritual.", passage145_Fragment_7);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "creature";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "power";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "robot";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "weapon";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "medicine";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "drug";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_6()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "demon";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }

    private static void passage145_Fragment_7()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeB = "ritual";
        MethodNewMaster3B();
        optionsManager.PresentOptions();
    }


    private static void MethodNewMaster3B()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.costB == "Biology")
        {
            StaticGameState.cost2B = "Animal";
        }

        if (StaticGameState.costB == "Engineering")
        {
            StaticGameState.cost2B = "Gear";
        }

        if (StaticGameState.costB == "Chemistry")
        {
            StaticGameState.cost2B = "Bottle";
        }

        Console.WriteLine("Give your creation a new, majestic name:");
        StaticGameState.creationB = Console.ReadLine()!;
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
        Console.Write(StaticGameState.creationB);
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        MethodMWCreationHubB();
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


    private static void MethodMWCreationHubB()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.typeB == "creature")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Animals, 5 Biology, 1 ");
            Console.Write(StaticGameState.costB);
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
        else if (StaticGameState.typeB == "power")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Animal, 1 ");
            Console.Write(StaticGameState.cost2B);
            Console.Write(", 3 Biology, 3 ");
            Console.Write(StaticGameState.costB);
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
        else if (StaticGameState.typeB == "robot")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Gears, 5 Engineering, 1 ");
            Console.Write(StaticGameState.costB);
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
        else if (StaticGameState.typeB == "weapon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Gear, 1 ");
            Console.Write(StaticGameState.cost2B);
            Console.Write(", 4 Engineering, 2 ");
            Console.Write(StaticGameState.costB);
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
        else if (StaticGameState.typeB == "medicine")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Chemicals, 4 Chemistry, 2 ");
            Console.Write(StaticGameState.costB);
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
        else if (StaticGameState.typeB == "drug")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Bottle, 1 ");
            Console.Write(StaticGameState.cost2B);
            Console.Write(", 3 Chemistry, 3 ");
            Console.Write(StaticGameState.costB);
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
        else if (StaticGameState.typeB == "demon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Bodies, 4 Occult, 1 ");
            Console.Write(StaticGameState.costB);
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
            Console.Write(StaticGameState.creationB);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Body, 1 ");
            Console.Write(StaticGameState.cost2B);
            Console.Write(", 3 Occult, 3 ");
            Console.Write(StaticGameState.costB);
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


    private static void MethodMWCompleteHubB()
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
        Console.Write(StaticGameState.nameB);
        Console.Write(" ");
        Console.Write("- Journal Entry Excerpt");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.typeB == "creature")
        {
            Console.Write("Upon the stroke of midnight, lightning struck metal, sending a terrible electrical current through the machinery. My creation awoke, and with wild eyes gazed upon me, its creator. I had done it! I had created life!");
        }
        else if (StaticGameState.typeB == "power")
        {
            Console.Write("To see my work in the flesh, to see ");
            Console.Write(StaticGameState.creationB);
            Console.Write(" finally realized; the passion of the moment overwhelmed my senses. I had done it. I shook my fist at God and all who doubted me! You were wrong! I am invincible!");
        }
        else if (StaticGameState.typeB == "robot")
        {
            Console.Write("A brief, blinding flash and the work was done. I threw my goggles to the floor to gaze upon my creation with my own eyes - ");
            Console.Write(StaticGameState.creationB);
            Console.Write(". The polished metal surface whirred with interior mechanisms churning - then, glorious motion! Oh wondrous automaton, with you by my side the scientific world will be humbled!");
        }
        else if (StaticGameState.typeB == "weapon")
        {
            Console.Write(
                "I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (StaticGameState.typeB == "medicine")
        {
            Console.Write("I tapped the glass bottle, watching the liquid inside swirl and glow with the purity of the mixture. The ");
            Console.Write(StaticGameState.creationB);
            Console.Write(
                " had been a stunning success and once mass production could be attained, my family's legacy would be secure. I laughed. Then, laughed again. My cacophonous laughter echoed off the stone walls of my estate for years to come.");
        }
        else if (StaticGameState.typeB == "drug")
        {
            Console.Write("I observed the effects as the syringe filled with ");
            Console.Write(StaticGameState.creationB);
            Console.Write(
                " emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (StaticGameState.typeB == "demon")
        {
            Console.Write("The world darkened around me as the ");
            Console.Write(StaticGameState.creationB);
            Console.Write(
                " emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, \"Master.\" I had done it. I was now in control and the world would rue the day they doubted ");
            Console.Write(StaticGameState.nameB);
            Console.Write(" III!");
        }
        else
        {
            Console.Write("The preparations proved tedious, but the resulting wave of spiritual energy as the ritual was completed left me standing in awe of my creation. The ");
            Console.Write(StaticGameState.creationB);
            Console.Write(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }

        optionsManager.PresentOptions();
    }


    private static void MethodNewMHub()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.trig == StaticGameState.players)
        {
            MethodNoUni1();
        }
        else if (StaticGameState.trig == 1)
        {
            MethodNewMaster1B();
        }
        else if (StaticGameState.trig == 2)
        {
            MethodNewMaster1C();
        }
        else if (StaticGameState.trig == 3)
        {
            MethodNewMaster1D();
        }
        else if (StaticGameState.trig == 4)
        {
            MethodNewMaster1E();
        }
        else
        {
            MethodNoUni1();
        }

        optionsManager.PresentOptions();
    }


    private static void MethodNewMaster1C()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand this Storybook device to ");
        Console.Write(StaticGameState.nameC);
        Console.Write(" ");
        Console.Write("and do not allow any other players to see the screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.trig = 3;
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Once you are ready", passage150_Fragment_4);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage150_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disC = "biology";
        MethodNewMaster2C();
        optionsManager.PresentOptions();
    }

    private static void passage150_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disC = "engineering";
        MethodNewMaster2C();
        optionsManager.PresentOptions();
    }

    private static void passage150_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disC = "chemistry";
        MethodNewMaster2C();
        optionsManager.PresentOptions();
    }

    private static void passage150_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disC = "occult";
        MethodNewMaster2C();
        optionsManager.PresentOptions();
    }

    private static void passage150_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Masterwork of My Own - ");
        Console.Write(StaticGameState.nameC);
        Console.Write(" III");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation is from which scientific discipline?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Biology.", passage150_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Engineering.", passage150_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Chemistry.", passage150_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Occult.", passage150_Fragment_3);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void MethodNewMaster2C()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("What Type of Glorious Creation");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With my unique ");
        Console.Write(StaticGameState.disC);
        Console.Write(" ");
        Console.Write("skills, this creation was already more focused and impressive than ever before. But, what ingenious type of creation would I explore?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation could be described as what type?");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.disC == "biology")
        {
            StaticGameState.costC = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Creature.", passage151_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Superpower.", passage151_Fragment_1);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disC == "engineering")
        {
            StaticGameState.costC = StaticGameState.GetRandom(new[]
            {
                "Biology",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Robot.", passage151_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Weapon.", passage151_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disC == "chemistry")
        {
            StaticGameState.costC = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Medicine.", passage151_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Drug.", passage151_Fragment_5);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else
        {
            StaticGameState.costC = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Demonic Creature.", passage151_Fragment_6);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Ritual.", passage151_Fragment_7);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "creature";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "power";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "robot";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "weapon";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "medicine";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "drug";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_6()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "demon";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }

    private static void passage151_Fragment_7()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeC = "ritual";
        MethodNewMaster3C();
        optionsManager.PresentOptions();
    }


    private static void MethodNewMaster3C()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.costC == "Biology")
        {
            StaticGameState.cost2C = "Animal";
        }

        if (StaticGameState.costC == "Engineering")
        {
            StaticGameState.cost2C = "Gear";
        }

        if (StaticGameState.costC == "Chemistry")
        {
            StaticGameState.cost2C = "Bottle";
        }

        Console.WriteLine("Give your creation a new, majestic name:");
        StaticGameState.creationC = Console.ReadLine()!;
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
        Console.Write(StaticGameState.creationC);
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        MethodMWCreationHubC();
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


    private static void MethodNewMaster1D()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand this Storybook device to ");
        Console.Write(StaticGameState.nameD);
        Console.Write(" ");
        Console.Write("and do not allow any other players to see the screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.trig = 4;
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Once you are ready", passage153_Fragment_4);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage153_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disD = "biology";
        MethodNewMaster2D();
        optionsManager.PresentOptions();
    }

    private static void passage153_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disD = "engineering";
        MethodNewMaster2D();
        optionsManager.PresentOptions();
    }

    private static void passage153_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disD = "chemistry";
        MethodNewMaster2D();
        optionsManager.PresentOptions();
    }

    private static void passage153_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disD = "occult";
        MethodNewMaster2D();
        optionsManager.PresentOptions();
    }

    private static void passage153_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Masterwork of My Own - ");
        Console.Write(StaticGameState.nameD);
        Console.Write(" III");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation is from which scientific discipline?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Biology.", passage153_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Engineering.", passage153_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Chemistry.", passage153_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Occult.", passage153_Fragment_3);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage153_Fragment_5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Once you are ready", passage153_Fragment_4);
        optionsManager.PresentOptions();
    }


    private static void MethodMWCreationHubC()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.typeC == "creature")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Animals, 5 Biology, 1 ");
            Console.Write(StaticGameState.costC);
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
        else if (StaticGameState.typeC == "power")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Animal, 1 ");
            Console.Write(StaticGameState.cost2C);
            Console.Write(", 3 Biology, 3 ");
            Console.Write(StaticGameState.costC);
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
        else if (StaticGameState.typeC == "robot")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Gears, 5 Engineering, 1 ");
            Console.Write(StaticGameState.costC);
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
        else if (StaticGameState.typeC == "weapon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Gear, 1 ");
            Console.Write(StaticGameState.cost2C);
            Console.Write(", 4 Engineering, 2 ");
            Console.Write(StaticGameState.costC);
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
        else if (StaticGameState.typeC == "medicine")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Chemicals, 4 Chemistry, 2 ");
            Console.Write(StaticGameState.costC);
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
        else if (StaticGameState.typeC == "drug")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Bottle, 1 ");
            Console.Write(StaticGameState.cost2C);
            Console.Write(", 3 Chemistry, 3 ");
            Console.Write(StaticGameState.costC);
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
        else if (StaticGameState.typeC == "demon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Bodies, 4 Occult, 1 ");
            Console.Write(StaticGameState.costC);
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
            Console.Write(StaticGameState.creationC);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Body, 1 ");
            Console.Write(StaticGameState.cost2C);
            Console.Write(", 3 Occult, 3 ");
            Console.Write(StaticGameState.costC);
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
    
    private static void MethodMWCompleteHubC()
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
        Console.Write(StaticGameState.nameC);
        Console.Write(" ");
        Console.Write("- Journal Entry Excerpt");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.typeC == "creature")
        {
            Console.Write("Upon the stroke of midnight, lightning struck metal, sending a terrible electrical current through the machinery. My creation awoke, and with wild eyes gazed upon me, its creator. I had done it! I had created life!");
        }
        else if (StaticGameState.typeC == "power")
        {
            Console.Write("To see my work in the flesh, to see ");
            Console.Write(StaticGameState.creationC);
            Console.Write(" finally realized; the passion of the moment overwhelmed my senses. I had done it. I shook my fist at God and all who doubted me! You were wrong! I am invincible!");
        }
        else if (StaticGameState.typeC == "robot")
        {
            Console.Write("A brief, blinding flash and the work was done. I threw my goggles to the floor to gaze upon my creation with my own eyes  - ");
            Console.Write(StaticGameState.creationC);
            Console.Write(". The polished metal surface whirred with interior mechanisms churning - then, glorious motion! Oh wondrous automaton, with you by my side the scientific world will be humbled!");
        }
        else if (StaticGameState.typeC == "weapon")
        {
            Console.Write(
                "I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (StaticGameState.typeC == "medicine")
        {
            Console.Write("I tapped the glass bottle, watching the liquid inside swirl and glow with the purity of the mixture. The ");
            Console.Write(StaticGameState.creationC);
            Console.Write(
                " had been a stunning success and once mass production could be attained, my family's legacy would be secure. I laughed. Then, laughed again. My cacophonous laughter echoed off the stone walls of my estate for years to come.");
        }
        else if (StaticGameState.typeC == "drug")
        {
            Console.Write("I observed the effects as the syringe filled with ");
            Console.Write(StaticGameState.creationC);
            Console.Write(
                " emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (StaticGameState.typeC == "demon")
        {
            Console.Write("The world darkened around me as the ");
            Console.Write(StaticGameState.creationC);
            Console.Write(
                " emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, \"Master.\" I had done it. I was now in control and the world would rue the day they doubted ");
            Console.Write(StaticGameState.nameC);
            Console.Write(" III!");
        }
        else
        {
            Console.Write("The preparations proved tedious, but the resulting wave of spiritual energy as the ritual was completed left me standing in awe of my creation. The ");
            Console.Write(StaticGameState.creationC);
            Console.Write(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }

        optionsManager.PresentOptions();
    }
    
    private static void MethodNewMaster2D()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("What Type of Glorious Creation");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With my unique ");
        Console.Write(StaticGameState.disD);
        Console.Write(" ");
        Console.Write("skills, this creation was already more focused and impressive than ever before. But, what ingenious type of creation would I explore?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("My creation could be described as what type?");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.disD == "biology")
        {
            StaticGameState.costD = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Creature.", passage156_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Superpower.", passage156_Fragment_1);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disD == "engineering")
        {
            StaticGameState.costD = StaticGameState.GetRandom(new[]
            {
                "Biology",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Robot.", passage156_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Weapon.", passage156_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disD == "chemistry")
        {
            StaticGameState.costD = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Medicine.", passage156_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Drug.", passage156_Fragment_5);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else
        {
            StaticGameState.costD = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Demonic Creature.", passage156_Fragment_6);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Ritual.", passage156_Fragment_7);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "creature";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "power";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "robot";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "weapon";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "medicine";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "drug";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_6()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "demon";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }

    private static void passage156_Fragment_7()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeD = "ritual";
        MethodNewMaster3D();
        optionsManager.PresentOptions();
    }


    private static void MethodNewMaster3D()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.costD == "Biology")
        {
            StaticGameState.cost2D = "Animal";
        }

        if (StaticGameState.costD == "Engineering")
        {
            StaticGameState.cost2D = "Gear";
        }

        if (StaticGameState.costD == "Chemistry")
        {
            StaticGameState.cost2D = "Bottle";
        }

        Console.WriteLine("Give your creation a new, majestic name:");
        StaticGameState.creationD = Console.ReadLine()!;
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
        Console.Write(StaticGameState.creationD);
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        MethodMWCreationHubD();
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
    
    private static void MethodNewMaster1E()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand this Storybook device to ");
        Console.Write(StaticGameState.nameE);
        Console.Write(" ");
        Console.Write("and do not allow any other players to see the screen.");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.trig = 5;
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Once you are ready", passage158_Fragment_4);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage158_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disE = "biology";
        MethodNewMaster2E();
        optionsManager.PresentOptions();
    }

    private static void passage158_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disE = "engineering";
        MethodNewMaster2E();
        optionsManager.PresentOptions();
    }

    private static void passage158_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disE = "chemistry";
        MethodNewMaster2E();
        optionsManager.PresentOptions();
    }

    private static void passage158_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.disE = "occult";
        MethodNewMaster2E();
        optionsManager.PresentOptions();
    }

    private static void passage158_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Masterwork of My Own - ");
        Console.Write(StaticGameState.nameE);
        Console.Write(" III");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "I was no longer constrained by the fickle whims of my ancestors. I could allow my imagination to run wild with possibilities! Within moments, I set to creating something new and magnificent - something that would cause the scientific world to quiver in awestruck wonder.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("My creation is from which scientific discipline?");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Biology.", passage158_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Engineering.", passage158_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Chemistry.", passage158_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Occult.", passage158_Fragment_3);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodNewMaster2E()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("What Type of Glorious Creation");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("With my unique ");
        Console.Write(StaticGameState.disE);
        Console.Write(" ");
        Console.Write("skills, this creation was already more focused and impressive than ever before. But, what ingenious type of creation would I explore?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("My creation could be described as what Type?");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.disE == "biology")
        {
            StaticGameState.costE = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Creature.", passage159_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Superpower.", passage159_Fragment_1);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disE == "engineering")
        {
            StaticGameState.costE = StaticGameState.GetRandom(new[]
            {
                "Biology",
                "Chemistry"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Robot.", passage159_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Weapon.", passage159_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.disE == "chemistry")
        {
            StaticGameState.costE = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Medicine.", passage159_Fragment_4);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Drug.", passage159_Fragment_5);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else
        {
            StaticGameState.costE = StaticGameState.GetRandom(new[]
            {
                "Engineering",
                "Chemistry",
                "Biology"
            });
            Console.Write("<hook>");
            optionsManager.AddOption("Demonic Creature.", passage159_Fragment_6);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Ritual.", passage159_Fragment_7);
            Console.Write("</hook>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "creature";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "power";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "robot";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "weapon";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "medicine";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "drug";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_6()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "demon";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void passage159_Fragment_7()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.typeE = "ritual";
        MethodNewMaster3E();
        optionsManager.PresentOptions();
    }

    private static void MethodMWCreationHubD()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.typeD == "creature")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Animals, 5 Biology, 1 ");
            Console.Write(StaticGameState.costD);
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
        else if (StaticGameState.typeD == "power")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Animal, 1 ");
            Console.Write(StaticGameState.cost2D);
            Console.Write(", 3 Biology, 3 ");
            Console.Write(StaticGameState.costD);
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
        else if (StaticGameState.typeD == "robot")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Gears, 5 Engineering, 1 ");
            Console.Write(StaticGameState.costD);
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
        else if (StaticGameState.typeD == "weapon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Gear, 1 ");
            Console.Write(StaticGameState.cost2D);
            Console.Write(", 4 Engineering, 2 ");
            Console.Write(StaticGameState.costD);
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
        else if (StaticGameState.typeD == "medicine")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Chemicals, 4 Chemistry, 2 ");
            Console.Write(StaticGameState.costD);
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
        else if (StaticGameState.typeD == "drug")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Bottle, 1 ");
            Console.Write(StaticGameState.cost2D);
            Console.Write(", 3 Chemistry, 3 ");
            Console.Write(StaticGameState.costD);
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
        else if (StaticGameState.typeD == "demon")
        {
            Console.Write("<bold>");
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("2 Bodies, 4 Occult, 1 ");
            Console.Write(StaticGameState.costD);
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
            Console.Write(StaticGameState.creationD);
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Cost:");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("1 Body, 1 ");
            Console.Write(StaticGameState.cost2D);
            Console.Write(", 3 Occult, 3 ");
            Console.Write(StaticGameState.costD);
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

    private static void MethodMWCompleteHubD()
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
        Console.Write(StaticGameState.nameD);
        Console.Write(" ");
        Console.Write("- Journal Entry Excerpt");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.typeD == "creature")
        {
            Console.Write("Upon the stroke of midnight, lightning struck metal, sending a terrible electrical current through the machinery. My creation awoke, and with wild eyes gazed upon me, its creator. I had done it! I had created life!");
        }
        else if (StaticGameState.typeD == "power")
        {
            Console.Write("To see my work in the flesh, to see ");
            Console.Write(StaticGameState.creationD);
            Console.Write(" finally realized; the passion of the moment overwhelmed my senses. I had done it. I shook my fist at God and all who doubted me! You were wrong! I am invincible!");
        }
        else if (StaticGameState.typeD == "robot")
        {
            Console.Write("A brief, blinding flash and the work was done. I threw my goggles to the floor to gaze upon my creation with my own eyes - ");
            Console.Write(StaticGameState.creationD);
            Console.Write(". The polished metal surface whirred with interior mechanisms churning - then, glorious motion! Oh wondrous automaton, with you by my side the scientific world will be humbled!");
        }
        else if (StaticGameState.typeD == "weapon")
        {
            Console.Write(
                "I seized the firing mechanism and squeezed the polished metal trigger. When the dust settled and my laboratory wall had been made to crumble into dust, I was unable to contain a sinister grin. The world would remember this day and the weapon I had wrought. My fame would be legendary.");
        }
        else if (StaticGameState.typeD == "medicine")
        {
            Console.Write("I tapped the glass bottle, watching the liquid inside swirl and glow with the purity of the mixture. The ");
            Console.Write(StaticGameState.creationD);
            Console.Write(
                " had been a stunning success and once mass production could be attained, my family's legacy would be secure. I laughed. Then, laughed again. My cacophonous laughter echoed off the stone walls of my estate for years to come.");
        }
        else if (StaticGameState.typeD == "drug")
        {
            Console.Write("I observed the effects as the syringe filled with ");
            Console.Write(StaticGameState.creationD);
            Console.Write(
                " emptied its contents into the unwilling test subject. Just as I had expected, the reaction was immediate and effusive. For so many years, I had toiled away in the solitude of my estate, and now as I wiped the tears from eyes, my beautiful creation was finally complete.");
        }
        else if (StaticGameState.typeD == "demon")
        {
            Console.Write("The world darkened around me as the ");
            Console.Write(StaticGameState.creationD);
            Console.Write(
                " emerged from a void-like rift in time and space. I could feel the immense power of the insidious being, the air hot with the energy of their presence. They turned to me and with a deep growl, they stated, \"Master.\" I had done it. I was now in control and the world would rue the day they doubted ");
            Console.Write(StaticGameState.nameD);
            Console.Write(" III!");
        }
        else
        {
            Console.Write("The preparations proved tedious, but the resulting wave of spiritual energy as the ritual was completed left me standing in awe of my creation. The ");
            Console.Write(StaticGameState.creationD);
            Console.Write(" was a brilliant success. And the powers I now harnessed were unthinkable!");
        }

        optionsManager.PresentOptions();
    }
    
    private static void MethodCreepyStar()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Grudge Towards Intellect");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "As many found solace in drink and the blackening of the liver, this alcoholic inebriety soon devolved into open displays of unfounded accusations against those who displayed even a modest bit of intellect. They took a sense of malformed pride in the depths of their ignorance.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The reputation of a famed scientist, however mild in its influence over the scholars in Budapest, was firmly reviled by the faith-driven townsfolk. It was an easy target to blame their misfortunes upon. They would spit on the ground and whisper curses under their breath as the best known of the family walked by.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage163_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage163_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.life == 0) ? ((StaticGameState.pana == "unleash") ? MethodPanaceaUnleashCons1 : MethodNewMaster) : MethodImmortalNoUni));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The player(s) with the most victory points immediately ");
        Console.Write("<bold>");
        Console.Write("gains 2 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodDetEffectRandom()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.killed == "yes")
        {
            MethodDeteriorationHub();
        }
        else
        {
            Console.Write("<bold>");
            Console.Write("The Effects of Immortality ");
            if (StaticGameState.round == 16)
            {
                Console.Write("- Early Years");
            }

            if (StaticGameState.round == 17)
            {
                Console.Write("- Middle Years");
            }

            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "It cannot be overstated: the dangers of defying God and the natural order of all things. Immortality, the likes of which the scientists craved, could never be sustained forever without some great sacrifice. Their continued existence was like a rolling of the dice, a gamble as precarious ");
            Console.Write(StaticGameState.GetRandom(new[]
            {
                "as a spider held by a thread above an all-consuming flame.",
                "as a candle flame amongst a roaring tempest.",
                "as a pendulous dagger perched above their head."
            }));
            Console.WriteLine();
            Console.WriteLine();
            optionsManager.AddOption("EffectRandomizer", MethodEffectRandomizer);
        }

        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodGloomyHunterIntro()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("GENERATION III:");
        Console.WriteLine();
        Console.Write("The Fraternity of Hunters");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The disease had revealed a much deeper evil than the family could have ever expected: An evil ignorance that dwells within the minds of the people. It had not only left the previous generation in shambles, but imbued the townsfolk with a profound, insatiable fear, even as the town returned to relative stability. During the day, the people watched the forests, glimpsing dark shadows flitting between the trees. At night, they steeled themselves against the wailing howls of unseen terrors, dreading that their children would be stolen away from their beds.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "That was until the Fraternity of Hunters, emboldened by the success of their clandestine operations, emerged from the shadows on the night of a blood red moon. They wore long-tail coats of black, burgundy, and dark leather, a wooden cross hanging either from their necks or dangling from their sides. They clutched crossbows, whips, and daggers freshly glimmering with crimson fluid. Their blood-stained attire and steel-eyed gaze evoked the undaunted presence of ones who had peered into the void and returned forever changed.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Their stated goal: to slay every last beast in the land and return those who had unleashed this foul plague back to the depths of hell from whence they came. The Fraternity turned the fear of the populace to their advantage. They fed the superstitions of the people, blaming the sickness and disease on fiendish creatures from the dark.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "As expected, the family quickly grew to find their presence exhausting, both ideologically and financially. Clearly, the cousins opined, these Hunters' fear-mongering stemmed from a lack of true, scientific knowledge. As defenders against an unknown terror, they stood in direct competition to continued experimentation unfettered by ethical considerations. Yet, the Fraternity's need for additional capital to fuel their frequent \"hunts\" prevented the family from taking more direct action.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Perhaps driven by a sense of limited time or jealousy over the Hunter's ability to frighten the townsfolk even moreso than their own actions, the cousins continued their meticulous labors in earnest. However, they were deeply unaware of just how intertwined their fates would be to the Fraternity.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("EvilConsequences", MethodEvilConsequences);
        Console.WriteLine();
        StaticGameState.huntvp = StaticGameState.GetRandom(new[]
        {
            4,
            5
        });
        optionsManager.PresentOptions();
    }
    
    private static void MethodEvilConsequences()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Consequences of Disobedience");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.society == "Fraternity of Hunters")
        {
            Console.Write(
                "In the evenings, the Fraternity gathered in the former Town Hall and celebrated their political takeover of the small town. Observers could hear their loud revelry echo through the streets late into the night. The townsfolk had no reason to doubt their loyalty as it appeared that their activities kept both sickness and superstitions at bay.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("For the family members that had aided them in their efforts, they wore wide false-smiles and offered toasts to their continued partnership. But, for those that had plotted against them, they remained wary.");
        }
        else
        {
            Console.Write(
                "In the center of town, in the full light of day and without fear of reprisal, a silver-haired beast rose to its hindlegs, almost human in stature. On the steps of the former Town Hall, she held the still-beating heart of a man who had refused to join their numbers. ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "The Order had revealed its true self with an unsettling ease, swiftly taking over the town and demanding alliance in the most vicious of terms. Streaks of dried blood and viscera adorned the windows of local businesses and homes. The family was only spared their wrath through allegiance or a cursed acknowledgement of their continued exploitation.");
        }

        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.society == "Fraternity of Hunters")
        {
            if ((StaticGameState.players > 4)
                    ? (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters" && StaticGameState.allyC == "hunters" && StaticGameState.allyD == "hunters" && StaticGameState.allyE == "hunters")
                    : ((StaticGameState.players > 3)
                        ? (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters" && StaticGameState.allyC == "hunters" && StaticGameState.allyD == "hunters")
                        : ((StaticGameState.players > 2)
                            ? (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters" && StaticGameState.allyC == "hunters")
                            : (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters"))))
            {
                optionsManager.AddOption("EvilMayor", MethodEvilMayor);
            }
            else
            {
                Console.Write("<hook>");
                optionsManager.AddOption("Click to continue...", passage170_Fragment_0);
                Console.Write("</hook>");
            }
        }
        else if ((StaticGameState.players > 4)
                     ? (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves" && StaticGameState.allyC == "wolves" && StaticGameState.allyD == "wolves" && StaticGameState.allyE == "wolves")
                     : ((StaticGameState.players > 3)
                         ? (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves" && StaticGameState.allyC == "wolves" && StaticGameState.allyD == "wolves")
                         : ((StaticGameState.players > 2) ? (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves" && StaticGameState.allyC == "wolves") : (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves"))))
        {
            optionsManager.AddOption("EvilMayor", MethodEvilMayor);
        }
        else
        {
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage170_Fragment_2);
            Console.Write("</hook>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage170_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEvilMayor);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        if (StaticGameState.allyA != "hunters")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        if (StaticGameState.allyB != "hunters")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" III gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        if (StaticGameState.players >= 3)
        {
            if (StaticGameState.allyC != "hunters")
            {
                Console.Write(StaticGameState.nameC);
                Console.Write(" III gains 1 ");
                Console.Write("<sprite=\"Creepy_Icon\" index=0>");
                Console.Write(".");
            }

            Console.WriteLine();
        }

        if (StaticGameState.players >= 4)
        {
            if (StaticGameState.allyD != "hunters")
            {
                Console.Write(StaticGameState.nameD);
                Console.Write(" III gains 1 ");
                Console.Write("<sprite=\"Creepy_Icon\" index=0>");
                Console.Write(".");
            }

            Console.WriteLine();
        }

        if (StaticGameState.players >= 5)
        {
            if (StaticGameState.allyE != "hunters")
            {
                Console.Write(StaticGameState.nameE);
                Console.Write(" III gains 1 ");
                Console.Write("<sprite=\"Creepy_Icon\" index=0>");
                Console.Write(".");
            }

            Console.WriteLine();
        }

        if ((StaticGameState.players > 4)
                ? (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters" && StaticGameState.allyC == "hunters" && StaticGameState.allyD == "hunters" && StaticGameState.allyE == "hunters")
                : ((StaticGameState.players > 3)
                    ? (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters" && StaticGameState.allyC == "hunters" && StaticGameState.allyD == "hunters")
                    : ((StaticGameState.players > 2) ? (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters" && StaticGameState.allyC == "hunters") : (StaticGameState.allyA == "hunters" && StaticGameState.allyB == "hunters"))))
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage170_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEvilMayor);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        if (StaticGameState.allyA != "wolves")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        if (StaticGameState.allyB != "wolves")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" III gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        if (StaticGameState.players >= 3)
        {
            if (StaticGameState.allyC != "wolves")
            {
                Console.Write(StaticGameState.nameC);
                Console.Write(" III gains 1 ");
                Console.Write("<sprite=\"Creepy_Icon\" index=0>");
                Console.Write(".");
            }

            Console.WriteLine();
        }

        if (StaticGameState.players >= 4)
        {
            if (StaticGameState.allyD != "wolves")
            {
                Console.Write(StaticGameState.nameD);
                Console.Write(" III gains 1 ");
                Console.Write("<sprite=\"Creepy_Icon\" index=0>");
                Console.Write(".");
            }

            Console.WriteLine();
        }

        if (StaticGameState.players >= 5)
        {
            if (StaticGameState.allyE != "wolves")
            {
                Console.Write(StaticGameState.nameE);
                Console.Write(" III gains 1 ");
                Console.Write("<sprite=\"Creepy_Icon\" index=0>");
                Console.Write(".");
            }

            Console.WriteLine();
        }

        if ((StaticGameState.players > 4)
                ? (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves" && StaticGameState.allyC == "wolves" && StaticGameState.allyD == "wolves" && StaticGameState.allyE == "wolves")
                : ((StaticGameState.players > 3)
                    ? (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves" && StaticGameState.allyC == "wolves" && StaticGameState.allyD == "wolves")
                    : ((StaticGameState.players > 2) ? (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves" && StaticGameState.allyC == "wolves") : (StaticGameState.allyA == "wolves" && StaticGameState.allyB == "wolves"))))
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III gains 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodGloomyGothic1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Taste of Evil - Early Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 10;
        Console.WriteLine();
        if (StaticGameState.gen3pg == 0 || StaticGameState.gen3pg == "")
        {
            Console.Write("<setupStyle>");
            Console.Write("<bold>");
            Console.Write("SETUP");
            Console.Write("</bold>");
            StaticGameState._SetupImage = "StartPlayerToken";
            Console.WriteLine();
            if (StaticGameState.society == "Fraternity of Hunters")
            {
                Console.Write("<bold>");
                Console.Write("Turn to Page 16 of the Village Chronicle. ");
                Console.Write("</bold>");
                Console.Write("Return the Angry Mob token to 1 space to the left of the Suspicion Marker. ");
                Console.Write("<italic>");
                Console.Write("Pass the Starting Player token as normal. ");
                Console.Write("</italic>");
                if (StaticGameState.players == 3)
                {
                    Console.Write("Then, since this is a 3 player game, pass the starting player marker clockwise 1 additional time.");
                }
            }
            else
            {
                Console.Write("<bold>");
                Console.Write("Turn to Page 18 of the Village Chronicle. ");
                Console.Write("</bold>");
                Console.Write("Retrieve the ");
                Console.Write("<bold>");
                Console.Write("Spawning Pods");
                Console.Write("</bold>");
                Console.Write(" Vanity Estate Upgrade and place it near the game board. Return the Angry Mob token to 1 space to the left of the Suspicion Marker. ");
                Console.Write("<italic>");
                Console.Write("Pass the Starting Player token as normal. ");
                Console.Write("</italic>");
                if (StaticGameState.players == 3)
                {
                    Console.Write("Then, since this is a 3 player game, pass the starting player marker clockwise 1 additional time.");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            if (StaticGameState.exposeA <= 1)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.ba);
                Console.Write(" tile over spot A on the Village Chronicle. ");
                Console.WriteLine();
            }

            if (StaticGameState.exposeB <= 1)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.bb);
                Console.Write(" tile over spot B on the Village Chronicle. ");
                Console.WriteLine();
            }

            if (StaticGameState.exposeC <= 1)
            {
                Console.Write("Place the ");
                Console.Write(StaticGameState.bc);
                Console.Write(" tile over spot C on the Village Chronicle.");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Return all other Building tiles to the scenario box.");
            Console.Write("</setupStyle>");
        }

        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.society == "Fraternity of Hunters")
        {
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("The Hunter's Rest");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("You may only place a Servant/Spouse piece on this building. This action causes you to pay $1 to the supply. Then, ");
            Console.Write("<bold>");
            Console.Write("at the end of the round");
            Console.Write("</bold>");
            Console.Write(", any piece on this building will become Lost.");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Taxation");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of each round, the Fraternity will check to make sure each player has placed a piece on ");
            Console.Write("<bold>");
            Console.Write("The Hunter's Rest");
            Console.Write("</bold>");
            Console.Write(". If a player has not done so, they will be forced to pay a penalty.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage171_Fragment_0);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
        }
        else
        {
            Console.Write("<hubTitle>");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write("<bold>");
            Console.Write(" Masterwork Completion");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When a player completes their Masterwork, ");
            optionsManager.AddOption("MWTokenResolve", MethodMWTokenResolve);
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
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
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("A Gift of Spawning");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of the Generation, the player with the most completed ");
            Console.Write("<bold>");
            Console.Write("Occult");
            Console.Write("</bold>");
            Console.Write(" Experiments will receive the ");
            Console.Write("<bold>");
            Console.Write("Spawning Pods");
            Console.Write("</bold>");
            Console.Write(" Vanity Estate Upgrade.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage171_Fragment_1);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage171_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic1", MethodGloomyPenalty1);
        optionsManager.PresentOptions();
    }

    private static void passage171_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic1", MethodWolvesEvil1);
        optionsManager.PresentOptions();
    }
    
    private static void MethodGloomyGothic2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Taste of Evil - Middle Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 11;
        Console.WriteLine();
        if (StaticGameState.society == "Fraternity of Hunters")
        {
            if (StaticGameState.confront == "yes")
            {
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("The Hunt is On");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("At the end of this round, players will have the option to donate (discard) a completed Experiment card ");
                Console.Write("<italic>");
                Console.Write("(not a Masterwork)");
                Console.Write("</italic>");
                Console.Write(" to The Grand Contest event. If the combined VP total of these Experiments can vanquish the hunters, they will submit to public humiliation. Players cannot pay taxes by visiting The Hunter's Rest.");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Also, the player who contributes the Experiment with the highest VP total will gain ");
                Console.Write("<bold>");
                Console.Write(StaticGameState.huntvp);
                Console.Write("VP. ");
                Console.Write("</bold>");
                Console.Write("<italic>");
                Console.Write("If players are tied, all tied players receive this bonus.");
                Console.Write("</italic>");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<hook>");
                optionsManager.AddOption("Click at the end of the round to continue...", passage172_Fragment_2);
                Console.Write("</hook>");
                Console.Write("</hubDetails>");
            }
            else
            {
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("Safe and Protected");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("We have decided to believe the Fraternity of Hunters and allow them to continue their important work, though it may place significant financial constraints upon us.");
                Console.Write("</hubDetails>");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("The Hunter's Rest");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("You may only place a Servant/Spouse piece on this building. This action causes you to pay $1 to the supply. Then, at the end of the round, any piece on this building will become Lost.");
                Console.Write("</hubDetails>");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("Taxation");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("At the end of each round, the Fraternity will check to make sure each player has placed a piece on ");
                Console.Write("<bold>");
                Console.Write("The Hunter's Rest");
                Console.Write("</bold>");
                Console.Write(". If a player has not done so, they will be forced to pay a penalty.");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<hook>");
                optionsManager.AddOption("Click at the end of the round to continue...", passage172_Fragment_0);
                Console.Write("</hook>");
                Console.Write("</hubDetails>");
            }
        }
        else
        {
            Console.Write("<hubTitle>");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write("<bold>");
            Console.Write(" Masterwork Completion");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When a player completes their Masterwork, ");
            optionsManager.AddOption("MWTokenResolve", MethodMWTokenResolve);
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
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
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("A Gift of Spawning");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of the Generation, the player with the most completed ");
            Console.Write("<bold>");
            Console.Write("Occult");
            Console.Write("</bold>");
            Console.Write(" Experiments will receive the ");
            Console.Write("<bold>");
            Console.Write("Spawning Pods");
            Console.Write("</bold>");
            Console.Write(" Vanity Estate Upgrade.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage172_Fragment_1);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage172_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic2", MethodTaxesEventNoConfrontation);
        optionsManager.PresentOptions();
    }

    private static void passage172_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic2", MethodWolvesVote);
        optionsManager.PresentOptions();
    }

    private static void passage172_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic2", MethodHunterConfrontation);
        optionsManager.PresentOptions();
    }

    private static void MethodGloomyGothic3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Taste of Evil - Late Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 12;
        Console.WriteLine();
        if (StaticGameState.society == "Fraternity of Hunters")
        {
            if (StaticGameState.taxes == "no")
            {
                Console.Write("<setupStyle>");
                Console.Write("<bold>");
                Console.Write("SPECIAL SETUP");
                Console.Write("</bold>");
                StaticGameState._SetupImage = "S1_Suspicious_Building";
                Console.WriteLine();
                Console.Write("Temporarily remove all Building tiles and turn to ");
                Console.Write("<bold>");
                Console.Write("page 15");
                Console.Write("</bold>");
                Console.Write(" of the Village Chronicle. Then, return the Building tiles to their proper locations.");
                Console.WriteLine();
                Console.WriteLine();
                if (StaticGameState.exposeA <= 1)
                {
                    Console.Write("<italic>");
                    Console.Write("Place the ");
                    Console.Write(StaticGameState.ba);
                    Console.Write(" tile over spot A on the Village Chronicle.");
                    Console.Write("</italic>");
                    Console.WriteLine();
                }

                if (StaticGameState.exposeB <= 1)
                {
                    Console.Write("<italic>");
                    Console.Write("Place the ");
                    Console.Write(StaticGameState.bb);
                    Console.Write(" tile over spot B on the Village Chronicle.");
                    Console.Write("</italic>");
                    Console.WriteLine();
                }

                if (StaticGameState.exposeC <= 1)
                {
                    Console.Write("<italic>");
                    Console.Write("Place the ");
                    Console.Write(StaticGameState.bc);
                    Console.Write(" tile over spot C on the Village Chronicle.");
                    Console.Write("</italic>");
                    Console.WriteLine();
                }

                Console.Write("</setupStyle>");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("The Hunter's Haven");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.Write("<hubDetails>");
                Console.Write("Visiting the remodeled Hunter's Lodge allows you to ");
                Console.Write("<bold>");
                Console.Write("pay 1 Occult knowledge cube to Lose 2 ");
                Console.Write(" <sprite=\"Insanity_Icon\" index=0>");
                Console.Write("</bold>");
                Console.Write(".");
                Console.WriteLine();
                Console.WriteLine();
                StaticGameState.ending = MethodENDHuntersEvil1;
                Console.Write("<hook>");
                optionsManager.AddOption("Click at the end of the Generation to continue...", passage173_Fragment_0);
                Console.Write("</hook>");
                Console.WriteLine();
                Console.Write("</hubDetails>");
            }
            else
            {
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("Safe and Protected");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("We have decided to believe the Fraternity of Hunters and allow them to continue their important work. ");
                Console.Write("</hubDetails>");
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("The Hunter's Rest");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("You may only place a Servant/Spouse piece on this building. This action causes you to pay $1 to the supply. Then, at the end of the round, any piece on this building will become Lost.");
                Console.Write("</hubDetails>");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<hubTitle>");
                Console.Write("<bold>");
                Console.Write("Final Taxation");
                Console.Write("</bold>");
                Console.Write("</hubTitle>");
                Console.WriteLine();
                Console.Write("<hubDetails>");
                Console.Write("At the end of this round, the Fraternity will check to make sure each player has placed a piece on ");
                Console.Write("<bold>");
                Console.Write("The Hunter's Rest");
                Console.Write("</bold>");
                Console.Write(". If a player has not done so, they will be forced to pay a penalty.");
                Console.WriteLine();
                Console.WriteLine();
                StaticGameState.ending = MethodENDHuntersEvil2;
                Console.Write("<hook>");
                optionsManager.AddOption("Click at the end of the Generation to continue...", passage173_Fragment_1);
                Console.Write("</hook>");
                Console.WriteLine();
                Console.Write("</hubDetails>");
            }
        }
        else if (StaticGameState.vialuse == "yes")
        {
            Console.Write("<setupStyle>");
            Console.Write("<bold>");
            Console.Write("SPECIAL SETUP");
            Console.Write("</bold>");
            StaticGameState._SetupImage = "S1_Suspicious_Building";
            Console.WriteLine();
            Console.Write("Temporarily remove all Building tiles and turn to ");
            Console.Write("<bold>");
            Console.Write("page 17");
            Console.Write("</bold>");
            Console.Write(" of the Village Chronicle. Then, return the Building tiles to their proper locations.");
            Console.WriteLine();
            Console.WriteLine();
            if (StaticGameState.exposeA <= 1)
            {
                Console.Write("<italic>");
                Console.Write("Place the ");
                Console.Write(StaticGameState.ba);
                Console.Write(" tile over spot A on the Village Chronicle.");
                Console.Write("</italic>");
                Console.WriteLine();
            }

            if (StaticGameState.exposeB <= 1)
            {
                Console.Write("<italic>");
                Console.Write("Place the ");
                Console.Write(StaticGameState.bb);
                Console.Write(" tile over spot B on the Village Chronicle.");
                Console.Write("</italic>");
                Console.WriteLine();
            }

            if (StaticGameState.exposeC <= 1)
            {
                Console.Write("<italic>");
                Console.Write("Place the ");
                Console.Write(StaticGameState.bc);
                Console.Write(" tile over spot C on the Village Chronicle.");
                Console.Write("</italic>");
            }

            Console.Write("</setupStyle>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When visiting this building, ");
            Console.Write("<bold>");
            Console.Write("pay $1 to gain a Caretaker from Lost.");
            Console.Write("</bold>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("A Gift of Spawning");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of the Generation, the player with the most completed ");
            Console.Write("<bold>");
            Console.Write("Occult");
            Console.Write("</bold>");
            Console.Write(" Experiments will receive the ");
            Console.Write("<bold>");
            Console.Write("Spawning Pods");
            Console.Write("</bold>");
            Console.Write(" Vanity Estate Upgrade.");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.ending = MethodENDWolvesEvil1;
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the Generation to continue...", passage173_Fragment_2);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.Write("</hubDetails>");
        }
        else
        {
            Console.Write("<hubTitle>");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write("<bold>");
            Console.Write(" Masterwork Completion");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When a player completes their Masterwork, ");
            optionsManager.AddOption("MWTokenResolve", MethodMWTokenResolve);
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
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
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("A Gift of Spawning");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of the Generation, the player with the most completed ");
            Console.Write("<bold>");
            Console.Write("Occult");
            Console.Write("</bold>");
            Console.Write(" Experiments will receive the ");
            Console.Write("<bold>");
            Console.Write("Spawning Pods");
            Console.Write("</bold>");
            Console.Write(" Vanity Estate Upgrade.");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.ending = MethodENDWolvesEvil2;
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the Generation to continue...", passage173_Fragment_3);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.Write("</hubDetails>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage173_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic3", MethodScoring);
        optionsManager.PresentOptions();
    }

    private static void passage173_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic3", MethodGloomyPenalty3);
        optionsManager.PresentOptions();
    }

    private static void passage173_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic3", MethodAwardSpawningPods);
        optionsManager.PresentOptions();
    }

    private static void passage173_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("GloomyGothic3", MethodAwardSpawningPods);
        optionsManager.PresentOptions();
    }
    
    private static void MethodEvilMayor()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.building == "bank")
        {
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Carefully hand the Storybook to ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" ");
            Console.Write("III.");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Avarice Aplently");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write("The Bank had proven a valuable investment in the town's future, and since its construction was facilitated by the ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" ");
            Console.Write("name, the ");
            Console.Write(StaticGameState.society);
            Console.Write(" ");
            Console.Write("could not help but offer thanks. As a token of their appreciation, they felt it best to help construct an expansion to their Estate.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage174_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            MethodMayorLibraryEvil();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage174_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        optionsManager.AddOption("Continue...", ((StaticGameState.hcount == 0 && StaticGameState.society == "Order of St. Hubertus") ? MethodEvilWolvesEventStart : MethodLosingOrderAid));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MayorCoin";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Curious Supply Room");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Estate Upgrade from the scenario box. ");
        Console.Write("<italic>");
        Console.Write("You may immediately build it in the next empty plot on your Estate board at no additional cost.");
        Console.Write("</italic>");
        Console.Write(" ");
        Console.Write("Then, return the <b>Commemorative Mayoral Coin</b> to the box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodCharityNegCons()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Condescending Patronage");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.gen3pg = 0;
        StaticGameState.conpat = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        Console.WriteLine();
        Console.Write(
            "It should be expected that the townsfolk who had placed their trust in a group of hunters protecting them from real supernatural threats would joke about generations past and the absurd push to build a hospital. It was clear to them that disease was caused by the presence of demons.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III's family legacy of ");
        Console.Write("<bold>");
        Console.Write("charity");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("served to create for them an unwanted hassle in everything from business to social gatherings in town.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage175_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage175_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_HeartToken";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("At the start of the round, ");
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III must ");
        if (StaticGameState.conpat == 1)
        {
            Console.Write("pay $1 to the supply.");
        }

        if (StaticGameState.conpat == 2)
        {
            Console.Write("gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Return the <b>Heart <sprite=\"S1_HeartToken\" index=0> token</b> to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
}