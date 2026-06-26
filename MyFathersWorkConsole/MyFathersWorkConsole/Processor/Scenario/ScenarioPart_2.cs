namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodDeteriorationHub()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.round == 16)
        {
            MethodNoUni2();
        }
        else if (StaticGameState.round == 17)
        {
            MethodNoUni3();
        }
        else if (StaticGameState.round == 19)
        {
            MethodUniversity2();
        }
        else
        {
            MethodUniversity3();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void MethodDetEffect1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Major Deleterious Effect");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "It could not continue. Sick and unable to heal again, stumbling blindly until the bones were brittle enough to snap, their bodies had finally failed them. And when the mind had joined the fragile physical form in its inability to perform the most basic of functions, the struggle ceased.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Death in all its inevitability had finally claimed them.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Unfortunately, their body was in such an advanced state of degradation it could not even be used for further experimentation. This made the grief more substantial.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage91_Fragment_1);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage91_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.det1 = "visited";
        StaticGameState.killed = "yes";
        optionsManager.AddOption("Continue...", MethodDeteriorationHub);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_Immortality";
        Console.WriteLine();
        Console.Write("Any player with an ");
        Console.Write("<bold>");
        Console.Write("Immortality card");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("discards a ");
        Console.Write("<bold>");
        Console.Write("Caretaker");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to Lost.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Discard all ");
        Console.Write("<bold>");
        Console.Write("Immortality cards");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodDetEffect2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Minor Deleterious Effect");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "They feared that their hasty solution had borne upon them irreversible effects. The interior withered, the skin grayed and sagged translucently against the sinewy veins beneath. The ultimate cure had become a curse and life was like a festering wound that cut deeper with each passing day. Still, they continued on in their work, hoping the effects were temporary but fearing the worst. It took more and more resources to quell their pain each day.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage92_Fragment_1);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage92_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.det2 = "visited";
        optionsManager.AddOption("Continue...", MethodDeteriorationHub);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_Immortality";
        Console.WriteLine();
        Console.Write("Any player with an ");
        Console.Write("<bold>");
        Console.Write("Immortality card");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("discards an ");
        Console.Write("<bold>");
        Console.Write("Ingredient");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("<italic>");
        Console.Write("if possible");
        Console.Write("</italic>");
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("draws a Compulsion");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodDetEffect3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Minor Deleterious Effect");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "All and all, the continued effects of their approach to Immortality had fared exceptionally well. While the skin displayed liver spots and an amount of vigor had been lost as the blood cooled with age, the effects were only a distraction. At most, a gangrenous finger had to be excised once every few years, but what was one extraneous extremity compared to the ability to assist in the most important scientific discoveries the world had ever known?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage93_Fragment_1);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage93_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.det3 = "visited";
        optionsManager.AddOption("Continue...", MethodDeteriorationHub);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_Immortality";
        Console.WriteLine();
        Console.Write("Any player with an ");
        Console.Write("<bold>");
        Console.Write("Immortality card");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("loses ");
        Console.Write("<bold>");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            1,
            2
        }));
        Console.Write("VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodDetEffect4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("No Effect");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The unthinkable had been achieved. Whether by sheer providence or remarkable display of intellect, the solution to immortality appeared to have worked! In fact, the effects were so remarkable that many witness accounts of the day observed that the aging process appeared to have reversed. While still aged by all accounts, their individual treatise on Immortality appeared to have succeeded.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("At least, for now.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage94_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage94_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.det4 = "visited";
        MethodDeteriorationHub();
        optionsManager.PresentOptions();
    }

    private static void MethodUniImmortal()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.life == 0)
        {
            MethodUniEquity();
        }
        else
        {
            Console.Write("<bold>");
            Console.Write("Immortality");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "Claiming an inheritance whilst one's parent still lives on; this foreign concept was decidedly unnerving both for the returning youths and their unaware spouses. However, after the initial shock of encountering a surprisingly spry parent tending to the Estate, the additional help did prove useful.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("For those whose parents had chosen a more amenable fate, having no secrets to conceal caused less suspicion during interactions with the local populace.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage97_Fragment_0);
            Console.Write("</hook>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage97_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodUniEquity);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "GainCaretakerFromLost";
        Console.WriteLine();
        if (StaticGameState.lifeA == "yes")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" retrieves a Caretaker piece from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeB == "yes")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" retrieves a Caretaker piece from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeC == "yes")
        {
            Console.Write(StaticGameState.nameC);
            Console.Write(" retrieves a Caretaker piece from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeD == "yes")
        {
            Console.Write(StaticGameState.nameD);
            Console.Write(" retrieves a Caretaker piece from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeE == "yes")
        {
            Console.Write(StaticGameState.nameE);
            Console.Write(" retrieves a Caretaker piece from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeA != "yes" && StaticGameState.lifeB != "yes" && StaticGameState.lifeC != "yes" && StaticGameState.lifeD != "yes" && StaticGameState.lifeE != "yes")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" retrieves a Caretaker piece from lost.");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.Write("Any player who did not receive a Caretaker for Immortality ");
        Console.Write("<bold>");
        Console.Write("Loses 2 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("<italic>");
        Console.Write("(2 spaces to the left)");
        Console.Write("</italic>");
        Console.Write(" ");
        Console.Write("at the start of this Generation.");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodImmortalNoUni()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.life == 0)
        {
            MethodPanaceaUnleashCons1();
        }
        else
        {
            Console.Write("<bold>");
            Console.Write("Immortality");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "Claiming an inheritance whilst one's parent still lives on; this foreign concept was decidedly unnerving both for the returning youths and their unaware spouses. However, after the initial shock of encountering a surprisingly spry parent tending to the Estate, the additional help did prove useful.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("For those whose parents had chosen a more amenable fate, having no secrets to conceal caused less suspicion during interactions with the local populace.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage98_Fragment_0);
            Console.Write("</hook>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage98_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodPanaceaUnleashCons1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        if (StaticGameState.lifeA == "yes")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III retrieves a Caretaker from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeB == "yes")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" III retrieves a Caretaker from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeC == "yes")
        {
            Console.Write(StaticGameState.nameC);
            Console.Write(" III retrieves a Caretaker from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeD == "yes")
        {
            Console.Write(StaticGameState.nameD);
            Console.Write(" III retrieves a Caretaker from lost.");
            Console.WriteLine();
        }

        if (StaticGameState.lifeE == "yes")
        {
            Console.Write(StaticGameState.nameE);
            Console.Write(" III retrieves a Caretaker from lost.");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player who did not receive a Caretaker for Immortality ");
        Console.Write("<bold>");
        Console.Write("Loses 2 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("<italic>");
        Console.Write("(2 spaces to the left)");
        Console.Write("</italic>");
        Console.Write(" ");
        Console.Write("at the start of this Generation.");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodProsperity1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Good Fight - Early Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 13;
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.society == "Order of St. Hubertus")
        {
            if (StaticGameState.gen3pg == 0 || StaticGameState.gen3pg == "")
            {
                Console.Write("<setupStyle>");
                Console.Write("<bold>");
                Console.Write("SETUP");
                Console.Write("</bold>");
                StaticGameState._SetupImage = "AngryMobSetup1";
                Console.Write("Turn to page ");
                Console.Write("<bold>");
                Console.Write("17");
                Console.Write("</bold>");
                Console.Write(" of the Village Chronicle. Place the Suspicion Marker on space ");
                Console.Write("<bold>");
                if (StaticGameState.Prosperity1 == 0 || StaticGameState.Prosperity1 == "")
                {
                    StaticGameState.Prosperity1 = 1;
                    StaticGameState.tracker = int.Parse(StaticGameState.tracker) - 2;
                    if (StaticGameState.players == 4)
                    {
                        StaticGameState.tracker = int.Parse(StaticGameState.tracker) - 1;
                    }

                    if (StaticGameState.players == 5)
                    {
                        StaticGameState.tracker = int.Parse(StaticGameState.tracker) - 1;
                    }
                }

                Console.Write(StaticGameState.tracker);
                Console.Write("</bold>");
                Console.Write(" and the ");
                Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
                Console.Write(" token one space to the left. ");
                Console.Write("<italic>");
                Console.Write("Pass the Starting Player token as normal.");
                Console.Write("</italic>");
                Console.Write(" ");
                if (StaticGameState.players == 3)
                {
                    Console.Write("Then, since this is a 3 player game, pass the starting player marker clockwise 1 additional time.");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Place a ");
                Console.Write("<sprite=\"Storybook\" index=0>");
                Console.Write(" token directly on top of the ");
                Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
                Console.Write(" token.");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("<bold>");
                Console.Write("SPECIAL SETUP");
                Console.Write("</bold>");
                StaticGameState._SetupImage = "S1_Suspicious_Building";
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
                    Console.Write(" tile over spot C on the Village Chronicle. ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.Write("Return all other Exposed Building tiles to the scenario box.");
                Console.Write("</setupStyle>");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Acceptance");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("Caretaker pieces can now take actions in Town as well as in the Estates. ");
            Console.Write("<italic>");
            Console.Write("The same Town placement rules for Servants apply to Caretaker pieces.");
            Console.Write("</italic>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When a player visits the ");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write(", they ");
            Console.Write("<bold>");
            Console.Write("pay $1");
            Console.Write("</bold>");
            Console.Write(" to gain a ");
            Console.Write("<bold>");
            Console.Write("Caretaker");
            Console.Write("</bold>");
            Console.Write(" piece from Lost. ");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Experiments are Feared");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.Write("<hubDetails>");
            Console.Write("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.Write("</hubDetails>");
            Console.Write("<hubTitle>");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write(" ");
            Console.Write("<bold>");
            Console.Write("Angry Mob");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("Any time the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(" token moves, move the Storybook token along with it. If the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(" overtakes a player, complete the current action and then ");
            optionsManager.AddOption("AngryMobStorybook", MethodAngryMobStorybook);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage119_Fragment_0);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
        }
        else
        {
            if (StaticGameState.gen3pg == 0 || StaticGameState.gen3pg == "")
            {
                Console.Write("<setupStyle>");
                Console.Write("<bold>");
                Console.Write("SETUP");
                Console.Write("</bold>");
                StaticGameState._SetupImage = "AngryMobSetup1";
                Console.Write("Turn to page ");
                Console.Write("<bold>");
                Console.Write("15");
                Console.Write("</bold>");
                Console.Write(" of the Village Chronicle. Place the 2 ");
                Console.Write("<bold>");
                Console.Write("Engineering Master's Study");
                Console.Write("</bold>");
                Console.Write(" tiles into play near the other Vanity Estate Upgrades. The Suspicion Marker remains in the same space and the ");
                Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
                Console.Write(" token is reset 1 space to the left. ");
                Console.Write("<italic>");
                Console.Write("Pass the Starting Player token as normal.");
                Console.Write("</italic>");
                Console.Write(" ");
                if (StaticGameState.players == 3)
                {
                    Console.Write("Then, since this is a 3-player game, pass the starting player marker clockwise 1 additional time.");
                }

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
                    Console.Write(" tile over spot C on the Village Chronicle. ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.Write("Return all other Exposed Building tiles to the scenario box.");
                Console.Write("</setupStyle>");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Hunter's Haven");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("For each visit to the Hunter's Haven, pay 1 Occult Knowledge cube to lose 2 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(". ");
            Console.Write("<italic>");
            Console.Write("(You cannot use Journaled Knowledge to pay this cost.)");
            Console.Write("</italic>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Engineering Achievement");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When you gain a Vanity Estate Upgrade, the ");
            Console.Write("<bold>");
            Console.Write("Engineering Master's Study");
            Console.Write("</bold>");
            Console.Write(" is part of the available pool to build as normal.");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Endless Hunt");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of the round, two of the scientists will be chosen to participate in the ");
            Console.Write("<bold>");
            Console.Write("Night of the Hunt.");
            Console.Write("</bold>");
            Console.Write(" This invitation cannot be refused.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage119_Fragment_1);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.Write("</hubDetails>");
            Console.WriteLine();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage119_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("Prosperity1", MethodWolvesEcoFriendly);
        optionsManager.PresentOptions();
    }

    private static void passage119_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("Prosperity1", MethodCharityAwardGood);
        optionsManager.PresentOptions();
    }


    private static void MethodProsperity2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Moving Forward - Middle Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 14;
        Console.WriteLine();
        if (StaticGameState.society == "Order of St. Hubertus")
        {
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Acceptance");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("Caretaker pieces can now take actions in Town as well as in the Estates. ");
            Console.Write("<italic>");
            Console.Write("The same Town placement rules for Servants apply to Caretaker pieces.");
            Console.Write("</italic>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When a player visits the ");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write(", they ");
            Console.Write("<bold>");
            Console.Write("pay $1");
            Console.Write("</bold>");
            Console.Write(" to gain a ");
            Console.Write("<bold>");
            Console.Write("Caretaker");
            Console.Write("</bold>");
            Console.Write(" piece from Lost. ");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Experiments are Feared");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.Write("<hubDetails>");
            Console.Write("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.Write("</hubDetails>");
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Farmer's Market");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.Write("<hubDetails>");
            Console.Write("Due to the associated social stigma, the Farmer's Market now acts as a Creepy location. When you visit the Farmer's Market also ");
            Console.Write("<bold>");
            Console.Write("gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
            Console.Write("</hubDetails>");
            Console.Write("<hubTitle>");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write("<bold>");
            Console.Write(" Angry Mob");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("Any time the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(" token moves, move the ");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write(" token along with it. If the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(" token overtakes a player, complete the current action and then ");
            optionsManager.AddOption("AngryMobStorybook", MethodAngryMobStorybook);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage120_Fragment_0);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
        }
        else
        {
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Hunter's Haven");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("For each visit to the Hunter's Haven, pay 1 Occult Knowledge cube to lose 2 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(". ");
            Console.Write("<italic>");
            Console.Write("(You cannot use Journaled Knowledge to pay this cost.)");
            Console.Write("</italic>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Engineering Achievement");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When you gain a Vanity Estate Upgrade, the ");
            Console.Write("<bold>");
            Console.Write("Engineering Master's Study");
            Console.Write("</bold>");
            Console.Write(" is part of the available pool to build as normal.");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Endless Hunt");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("At the end of the round, two of the scientists will be chosen to participate in the ");
            Console.Write("<bold>");
            Console.Write("Night of the Hunt.");
            Console.Write("</bold>");
            Console.Write(" This invitation cannot be refused.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the round to continue...", passage120_Fragment_1);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage120_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("Prosperity2", MethodGoodFrenzyEvent);
        optionsManager.PresentOptions();
    }

    private static void passage120_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("Prosperity2", MethodCureMoonSick1);
        optionsManager.PresentOptions();
    }


    private static void MethodProsperity3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Moving Forward - Late Years");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.round = 15;
        Console.WriteLine();
        if (StaticGameState.society == "Order of St. Hubertus")
        {
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Acceptance");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("Caretaker pieces can now take actions in Town as well as in the Estates. ");
            Console.Write("<italic>");
            Console.Write("The same Town placement rules for Servants apply to Caretaker pieces.");
            Console.Write("</italic>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When a player visits the ");
            Console.Write("<bold>");
            Console.Write("School for Hybridized Individuals");
            Console.Write("</bold>");
            Console.Write(", they ");
            Console.Write("<bold>");
            Console.Write("pay $1");
            Console.Write("</bold>");
            Console.Write(" to gain a ");
            Console.Write("<bold>");
            Console.Write("Caretaker");
            Console.Write("</bold>");
            Console.Write(" piece from Lost. ");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Experiments are Feared");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.Write("<hubDetails>");
            Console.Write("Anytime a player takes the Perform an Experiment Estate action, they gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write(".");
            Console.Write("</hubDetails>");
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Farmer's Market");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.Write("<hubDetails>");
            Console.Write("Due to the associated social stigma, the Farmer's Market now acts as a Creepy location. When you visit the Farmer's Market also ");
            Console.Write("<bold>");
            Console.Write("gain 1 ");
            Console.Write("<sprite=\"Creepy_Icon\" index=0>");
            Console.Write("</bold>");
            Console.Write(".");
            Console.Write("</hubDetails>");
            Console.Write("<hubTitle>");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write("<bold>");
            Console.Write(" Angry Mob");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("Any time the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(" token moves, move the ");
            Console.Write("<sprite=\"Storybook\" index=0>");
            Console.Write(" token along with it. If the ");
            Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
            Console.Write(" token overtakes a player, complete the current action and then ");
            optionsManager.AddOption("AngryMobStorybook", MethodAngryMobStorybook);
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Scientific Achievement");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When you gain a Vanity Estate Upgrade, all remaining <b>Master's Study</b> tiles are part of the available pool to build as normal <i>(not Occult)</i>.");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.ending = MethodENDWolvesGood1;
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the Generation to continue to Final Scoring...", passage121_Fragment_0);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
        }
        else
        {
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Hunter's Haven");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("For each visit to the Hunter's Haven, pay 1 Occult Knowledge cube to lose 2 ");
            Console.Write("<sprite=\"Insanity_Icon\" index=0>");
            Console.Write(". ");
            Console.Write("<italic>");
            Console.Write("(You cannot use Journaled Knowledge to pay this cost.)");
            Console.Write("</italic>");
            Console.Write("</hubDetails>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hubTitle>");
            Console.Write("<bold>");
            Console.Write("Scientific Achievement");
            Console.Write("</bold>");
            Console.Write("</hubTitle>");
            Console.WriteLine();
            Console.Write("<hubDetails>");
            Console.Write("When you gain a Vanity Estate Upgrade, all remaining <b>Master's Study</b> tiles are part of the available pool to build as normal <i>(not Occult)</i>.");
            Console.WriteLine();
            Console.WriteLine();
            StaticGameState.ending = MethodENDHunterGood1;
            Console.Write("<hook>");
            optionsManager.AddOption("Click at the end of the Generation to continue to Final Scoring...", passage121_Fragment_1);
            Console.Write("</hook>");
            Console.Write("</hubDetails>");
        }

        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage121_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("Prosperity3", MethodScoring);
        optionsManager.PresentOptions();
    }

    private static void passage121_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.PrintEndOfTheRoundText("Prosperity3", MethodScoring);
        optionsManager.PresentOptions();
    }
    
    private static void MethodHUBExample()
    {
        /*if (StaticGameState.round == 1)
        {
            optionsManager.AddOption("Fever1", MethodFever1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 2)
        {
            optionsManager.AddOption("Fever2", MethodFever2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 3)
        {
            optionsManager.AddOption("Fever3", MethodFever3);
        }

        Console.WriteLine();
        if (StaticGameState.round == 4)
        {
            optionsManager.AddOption("Devastation1", MethodDevastation1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 5)
        {
            optionsManager.AddOption("Devastation2", MethodDevastation2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 6)
        {
            optionsManager.AddOption("Devastation3", MethodDevastation3);
        }

        Console.WriteLine();
        if (StaticGameState.round == 7)
        {
            optionsManager.AddOption("Hospital1", MethodHospital1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 8)
        {
            optionsManager.AddOption("Hospital2", MethodHospital2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 9)
        {
            optionsManager.AddOption("Hospital3", MethodHospital3);
        }

        Console.WriteLine();
        if (StaticGameState.round == 10)
        {
            optionsManager.AddOption("GloomyGothic1", MethodGloomyGothic1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 11)
        {
            optionsManager.AddOption("GloomyGothic2", MethodGloomyGothic2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 12)
        {
            optionsManager.AddOption("GloomyGothic3", MethodGloomyGothic3);
        }

        Console.WriteLine();
        if (StaticGameState.round == 13)
        {
            optionsManager.AddOption("Prosperity1", MethodProsperity1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 14)
        {
            optionsManager.AddOption("Prosperity2", MethodProsperity2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 15)
        {
            optionsManager.AddOption("Prosperity3", MethodProsperity3);
        }

        Console.WriteLine();
        if (StaticGameState.round == 16)
        {
            optionsManager.AddOption("NoUni1", MethodNoUni1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 17)
        {
            optionsManager.AddOption("NoUni2", MethodNoUni2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 18)
        {
            optionsManager.AddOption("NoUni3", MethodNoUni3);
        }

        Console.WriteLine();
        if (StaticGameState.round == 19)
        {
            optionsManager.AddOption("University1", MethodUniversity1);
        }

        Console.WriteLine();
        if (StaticGameState.round == 20)
        {
            optionsManager.AddOption("University2", MethodUniversity2);
        }

        Console.WriteLine();
        if (StaticGameState.round == 21)
        {
            optionsManager.AddOption("University3", MethodUniversity3);
        }*/
    }


    private static void MethodSanityChoice()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        StaticGameState.gen3pg = 0;
        Console.Write("<bold>");
        Console.Write("Carefully hand the Storybook to ");
        Console.Write(StaticGameState.saneplayer);
        Console.Write(". This choice is read and made within view of all players.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Journal Entry, ");
        Console.Write(StaticGameState.saneplayer);
        Console.Write(" ");
        Console.Write("- September, 1892");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The fools! The utter fools! In their haste to return to their amateurish attempts at science, my dear, witless cousins have been overlooked by our colleagues at the university. And so it fell to me to advise them on this most important psychological matter!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "My in-depth studies of phrenology and first-hand observation of brain function have allowed me to calculate with flawless accuracy the appropriate level of mental intensity needed to excel in science; the most proper balance of passion and ethical ambiguity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("While, yes, we may ALL benefit from this assessment and yes, they did only consult me out of a sense of pity, it is I alone that will now control the fate of us all!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(StaticGameState.saneplayer);
        Console.Write(" ");
        Console.Write("must now choose a numbered spot below on the ");
        Console.Write("<sprite=\"Insanity_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("Track.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("At the end of the Generation, any player whose piece is on this space will ");
        Console.Write("<bold>");
        Console.Write("gain 5VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("3", passage127_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("4", passage127_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("5", passage127_Fragment_2);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("6", passage127_Fragment_3);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("7", passage127_Fragment_4);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage127_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.mental = 3;
        MethodPanaceaUnleashCons2();
        optionsManager.PresentOptions();
    }

    private static void passage127_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.mental = 4;
        MethodPanaceaUnleashCons2();
        optionsManager.PresentOptions();
    }

    private static void passage127_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.mental = 5;
        MethodPanaceaUnleashCons2();
        optionsManager.PresentOptions();
    }

    private static void passage127_Fragment_3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.mental = 6;
        MethodPanaceaUnleashCons2();
        optionsManager.PresentOptions();
    }

    private static void passage127_Fragment_4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.mental = 7;
        MethodPanaceaUnleashCons2();
        optionsManager.PresentOptions();
    }


    private static void MethodLycanthropicMessage()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Form of the Wolf");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Confirming the existence of individuals with the ability to change into an animal form had remarkable consequences. It is possible that it has even disrupted the studies of one of our kin.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Does any player have the ");
        Console.Write("<bold>");
        Console.Write("Lycanthropic Strength");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Masterwork Experiment?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Yes.", passage128_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("WolvesSetupGen3", MethodWolvesSetupGen3);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage128_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.lycan = "yes";
        MethodLycanEvil();
        optionsManager.PresentOptions();
    }


    private static void MethodLycanEvil()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Strength Can Be Mine");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Their existence was proven. Now, could the catalyst of this truly powerful transformation be replicated? And how could it be further strengthened?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage129_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage129_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodWolvesSetupGen3);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MWUpdateLycanthropic";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Lycanthropic Strength");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Update card from the scenario box and give it to the player working towards this Masterwork.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodWolvesSetupGen3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic1);
        StaticGameState.gen3pg = 0;
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "StorybookToken";
        Console.Write("Each player retrieves a ");
        Console.Write("<bold>");
        Console.Write("Storybook token");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and places it on their Masterwork.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<italic>");
        Console.Write("When a player completes their Masterwork, they will consult the Storybook for a special message from the Order.");
        Console.Write("</italic>");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
}