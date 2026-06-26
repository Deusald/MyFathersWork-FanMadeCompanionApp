namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodCureMoonSick1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Moon Sickness");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.round == 13)
        {
            Console.Write("What a horrible night to have a curse!");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "They wrote of torn clothing, strange awakenings half-naked in the gardens at the edge of their Estate, of blood speckled about their boots and dried streaks from the corners of their lips. Lingering lucid memories of stalking prey in the woods haunted their dreams yet filled them with a terrible energy!");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "When they discovered the eviscerated body of one of their servants skewered upon the metal fence that lined the grounds, the bestial teeth and claw marks told a new story. They steeled their mind against the distraction, recommitting themselves with deadly focus to the task at hand.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage47_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            Console.Write("They could not dwell on the news of yet another victim within their household for long as more pressing matters of scientific import weighed upon their every waking hour. ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "For theirs was a dismal, macabre occupation. They measured each moment in dark pen strokes, the incision of a sterilized blade, or the ebullition of glowing liquid in a graduated flask. The loss of a servant was unfortunate, not for the life it represented, but for the distinct lapse in efficiency procuring a new servant would cause.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage47_Fragment_2);
            Console.Write("</hook>");
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage47_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodHuntround1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "CompulsionBack";
        Console.WriteLine();
        Console.Write("All players with a ");
        Console.Write("<bold>");
        Console.Write("Disease Experiment");
        Console.Write("</bold>");
        Console.Write(" in their Stored Experiments ");
        Console.Write("<bold>");
        Console.Write("draw a Compulsion and gain a Body.");
        Console.Write("</bold>");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage47_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodMayorResolveHunters);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "CompulsionBack";
        Console.WriteLine();
        Console.Write("All players with a ");
        Console.Write("<bold>");
        Console.Write("Disease Experiment");
        Console.Write("</bold>");
        Console.Write(" in their Stored Experiments ");
        Console.Write("<bold>");
        Console.Write("draw a Compulsion and gain a Body.");
        Console.Write("</bold>");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Methodbar1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write(" -HDG- ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.bar1 = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        Console.WriteLine();
        if (StaticGameState.bar1 == 1)
        {
            Console.Write("After a brief excursion to the local pub, I happened to engage in a spirited conversation with the ");
            Console.Write("<bold>");
            Console.Write("Blacksmith’s");
            Console.Write("</bold>");
            Console.Write(
                " son. Being slightly out of my wits, his slightly improper offer to accompany him home to his chateau for further libations appealed. We engaged in a delightful conversation, so intriguing in fact, that I accepted his generous offer of temporary lodging for the evening. I will spare the details of our respectable and entirely benign conversation.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "We both decided to disrobe as any person would when making nightly preparations for sleep. Regrettably, though I cannot recollect how it occurred, the Blacksmith was unpleased to discover us similarly nude and entwined in this state the next morning, surrounded by several defiled tools from the forge. Our family’s reputation was certainly sullied at the Blacksmith and I resolved to avoid it in the future.");
        }
        else
        {
            Console.Write("After a brief excursion to the local pub, I happened to engage in a spirited conversation with the ");
            Console.Write("<bold>");
            Console.Write("Blacksmith’s");
            Console.Write("</bold>");
            Console.Write(
                " daughter. While I am unable to discern the reasoning behind my actions, I have since apologized for my repeated comments besmirching her virtuous nature; comments which apparently resulted in a minor altercation with a gentlemen or two at the fine establishment.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "It was around midnight that I decided to make a quiet exit, in order to properly avoid any further antagonism. My clothes, soiled and bloodied by the ensuing brawl, were found discarded along the muddy trek to the Blacksmith's forge. While I have no recollection of the ensuing events, multiple witnesses attest that I then proceeded to brand the blacksmith's dog and passed out naked in the slack tub. Our family’s reputation was certainly sullied at the Blacksmith and I resolved to avoid it in the future.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Blacksmith");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Methodbar2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("-HDG-");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.bar2 = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        Console.WriteLine();
        if (StaticGameState.bar2 == 1)
        {
            Console.Write(
                "While many first-hand accounts from the townsfolk may not corroborate my story, I cannot conceal my disgust with the insinuation. The stable hand and I were simply enjoying a midnight ride in the nearby beet fields in the spirit of the season. Due to my enhanced state of inebriation, I may have chosen the incorrect steed for our excursion.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "I awoke in the stables beside my porcine companion, who had been outfitted with a leather riding saddle. The gate to their pen had been left open and the entire pig population of the town was scattered throughout the streets.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "I would also like to note that the charges of public nudity against me are warrantless, as upon discovery of my predicament that morning, I hastily endeavored to hide my shame and purchase new clothing from a local tailor as would be customary in such a situation. Our family’s reputation was certainly sullied at the ");
            Console.Write("<bold>");
            Console.Write("Farmer’s Market");
            Console.Write("</bold>");
            Console.Write(" and I resolved to avoid it in the future.");
        }
        else
        {
            Console.Write(
                "I find the accusations toward my conduct and character most disturbing. To insinuate that I was openly consorting with individuals of ill-repute and offered compensation for illicit activities, why it is as absurd as the other charges against me from that evening.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "While I admit to having a few additional libations, it is most presumptuous to believe that just because I was found near the open door of my carriage in the buff, covered in tomato paste, with lipstick impressions across the entirety of my form, that I would be held responsible for the debasing of a bushel of cherry tomatoes and several other vegetable stocks.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Despite my personal objections, I have summarily reimbursed the stall owner for their produce and discretion in the matter. Our family’s reputation was certainly sullied at the ");
            Console.Write("<bold>");
            Console.Write("Farmer’s Market");
            Console.Write("</bold>");
            Console.Write(" and I resolved to avoid it in the future.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Farmer's Market");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        optionsManager.PresentOptions();
    }


    private static void Methodbar3()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("-HDG-");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.bar3 = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        Console.WriteLine();
        if (StaticGameState.bar3 == 1)
        {
            Console.Write("It was very much in poor taste for a ");
            Console.Write("<bold>");
            Console.Write("fortune teller");
            Console.Write("</bold>");
            Console.Write(
                " to summarily dismiss my romantic advances given my current social status and level of wealth. However, I admit that my inebriated reaction to steal and destroy her Tarot deck was highly juvenile. And the public defiling of said Tarot cards afterwards was certainly not in keeping with the standards of my aristocratic upbringing.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "I have since reimbursed the Fortune Teller for her ruined Tarot cards, and apologized to the Sheriff for my display of public nudity. Our family’s reputation was certainly sullied at the Fortune Teller and I resolved to avoid it in the future.");
        }
        else
        {
            Console.Write(
                "During a spirited conversation at the local pub, I was informed of a fine establishment with premium snuff and tobacco on the outskirts of town. While I cannot recall if I partook, I was made aware that this establishment promoted opium use, which is a vile indulgence indeed. Sadly, I admit poor judgement in not exiting the premises immediately upon this discovery and my subsequent refusal to leave after four hours had elapsed.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "An exchange of bitter words may have occurred, which resulted in myself yelling expletives and unfortunate ethnic slurs which I would dare not repeat. At some point my clothes had vanished, so I was at a distinct physical disadvantage when I was swiftly removed from the area, not without sustaining several bruises from the scuffle (which, to note, I have not pressed charges for). Our family’s reputation was certainly sullied at the ");
            Console.Write("<bold>");
            Console.Write("Fortune Teller");
            Console.Write("</bold>");
            Console.Write(" and I resolved to avoid it in the future.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Fortune Teller");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Methodbar4()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("-HDG-");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.bar4 = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        Console.WriteLine();
        if (StaticGameState.bar4 == 1)
        {
            Console.Write("The celebration had been exceedingly rowdy. I could not recall whose birthday or anniversary was being celebrated, but I could remember my celebratory stilted walk to the ");
            Console.Write("<bold>");
            Console.Write("General Store");
            Console.Write("</bold>");
            Console.Write(" near midnight. In my admittedly intoxicated state, I required sustenance.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "Unfortunately, my hunger pangs may have overtaken my sensibilities. A rock may have been plunged through the front window, and I may have been discovered the next morning by the constabulary, passed out naked on the wooden floor, surrounded by several empty cartons of canned sardines, the contents of which may have been returned to the same general area in a more semi-digested form. Our family’s reputation was certainly sullied at the General Store and I resolved to avoid it in the future.");
        }

        if (StaticGameState.bar4 == 2)
        {
            Console.Write(
                "The proprietors of the General Store, Hagen and Mabel Varga, are respectable, upstanding citizens of whom I have a deep respect. Their fine emporium of quality products is a grand example of successful private business ownership that positively serves the community.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "My unfortunate public statements to the contrary in a loud and admittedly inebriated state were categorically untrue and misinformed. My subsequent scrawling of expletives upon their business' front window - with a crude writing medium that I will not elaborate upon - was brash and reckless.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("I regret that my nude form was discovered curled up at their doorstep by the constabulary. Our family’s reputation was certainly sullied at the General Store and I resolved to avoid it in the future.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("General Store");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Methodbar5()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("-HDG-");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.bar5 = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        Console.WriteLine();
        if (StaticGameState.bar5 == 1)
        {
            Console.Write(
                "I vaguely remember the phrase that began the argument, but the stitches above my left eye from a shattered glass mug jogged my recollection of the ensuing brawl. A quick nightcap turned into an extended stay of tumbled barstools, belligerence, and wild accusations. My injuries must have been extensive as my memory ceased soon after.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "My displeased spouse informed me that I was currently the height of gossip within the town. First-hand accounts - of which I cannot confirm given my state of awareness - described how I spat blood in a nurse’s face, tore off my leggings (and undergarments), tried to punch the vicar thrice, and defiled myself in the lobby. Our family’s reputation was certainly sullied at the ");
            Console.Write("<bold>");
            Console.Write("Hospital");
            Console.Write("</bold>");
            Console.Write(" and I resolved to avoid it in the future.");
        }

        if (StaticGameState.bar5 == 2)
        {
            Console.Write(
                "I should not have attempted to perform a surgical procedure in my state. Nor should I have locked myself in the surgical arena with a patient, barred the door, and undressed, dousing myself in a carbolic acid solution for the purposes of sterilization. However, my honor had been questioned at the pub and I deemed it only necessary to demonstrate my surgical prowess.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "The demonstration of my experimentation capabilities - which are normally formidable, I might add - turned into a series of unfortunate mishaps and misunderstandings. The unfortunate patient has since made a full recovery and has already received a generous stipend in recompense and the hospital a donation with which to cleanse the arena of the admittedly large quantity of blood on the walls, seating, instruments, and ceiling. Our family’s reputation was certainly sullied at the ");
            Console.Write("<bold>");
            Console.Write("Hospital");
            Console.Write("</bold>");
            Console.Write(" and I resolved to avoid it in the future.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Hospital");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Methodbar6()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("-HDG-");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Although witnesses claim that I had carried a makeshift torch several blocks to the destination, my ignition of nearby gasoline reserves was entirely accidental. My intent, of course, was a comical reenactment of the wiles of recent angry mobs; clearly satirical in nature. A vaudevillian parody. However, the French performance art overtones due to my regrettable nudity were not considered with high regard. The resulting blaze that consumed over half of the Laborer’s Union building that night was also not met with the warmest of receptions.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Honestly, the Laborer’s Union building had not been updated for years. It was overdue for renovations. However, our family’s reputation was certainly sullied at the ");
        Console.Write("<bold>");
        Console.Write("Laborer’s Union");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and I resolved to avoid it in the future.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Laborer's Union");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }


    private static void Methodbar7()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("SWORN STATEMENT - Case ");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("-HDG-");
        Console.Write(new Random().Next(1, 999 + 1));
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "While the cemetery has certainly been a crucial source of ingredients for my experiments - acquired by pruning local flora and herbs - calling attention to this fact very loudly while inside the local pub was probably a mistake. Openly inviting all patrons to join me in the cemetery to kick over headstones and then running directly to said location to do so was a clear error of judgement. My alleged indecent exposure whilst doing so, also unfortunate.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("After being treated for a sprained ankle, I spent a night half-remembered in the local police station. Our family’s reputation was certainly sullied at the ");
        Console.Write("<bold>");
        Console.Write("Cemetery");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and I resolved to avoid it in the future.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<setupStyle>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Cemetery");
        Console.Write("</bold>");
        Console.Write(". When a player takes an action at this location, they ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("for every ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on that location.");
        Console.Write("</setupStyle>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
    
    private static void MethodLosingOrderAid()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.society == "Order of St. Hubertus")
        {
            if (StaticGameState.hcount == 0)
            {
                MethodEvilWolvesEventStart();
            }
            else
            {
                Console.Write("<bold>");
                Console.Write("Despite the Hunters' Loss");
                Console.Write("</bold>");
                Console.WriteLine();
                Console.Write(
                    "It was during a period of adjustment to their new surroundings that customary preparations were made to redecorate the west wing of the manor in a more modern style to which they were accustomed. Expecting a delivery of druggets from a Persian carpeter, instead they were greeted by a strapping young man in a burgundy leather coat. He tipped his wide-brimmed hat solemnly.");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(
                    "\"Your family has made a contribution to our Fraternity and we are here to repay that debt through service,\" the young man stated, pulling back his shirt sleeve to reveal a tattoo of a bow and arrow. He then exited to the servant's quarters without further instruction.");
                Console.WriteLine();
                Console.WriteLine();
                if (StaticGameState.allyA != "hunters" && StaticGameState.allyB != "hunters" && StaticGameState.allyC != "hunters" && StaticGameState.allyD != "hunters")
                {
                    optionsManager.AddOption("EvilWolvesEventStart", MethodEvilWolvesEventStart);
                }
                else
                {
                    Console.Write("<hook>");
                    optionsManager.AddOption("Click to continue...", passage64_Fragment_0);
                    Console.Write("</hook>");
                }
            }
        }
        else if (StaticGameState.wcount == 0)
        {
            MethodTaxesEventStart();
        }
        else
        {
            Console.Write("<bold>");
            Console.Write("Despite the wolves' Loss");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "It was during a period of adjustment to their new surroundings that customary preparations were made to redecorate the west wing of the manor in a more modern style to which they were accustomed. Expecting a delivery of druggets from a Turkish carpeter, instead they were greeted by a strapping young man in a gray cloak. He tipped his fur cap solemnly.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "\"Your family has made a contribution to our Order and we are here to repay that debt through service,\" the young man stated, pulling back his shirt sleeve to reveal a tattoo of a wolf's head. He then exited to the servant's quarters without further instruction.");
            Console.WriteLine();
            Console.WriteLine();
            if (StaticGameState.allyA != "wolves" && StaticGameState.allyB != "wolves" && StaticGameState.allyC != "wolves" && StaticGameState.allyD != "wolves")
            {
                optionsManager.AddOption("TaxesEventStart", MethodTaxesEventStart);
            }
            else
            {
                Console.Write("<hook>");
                optionsManager.AddOption("Click to continue...", passage64_Fragment_2);
                Console.Write("</hook>");
            }
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage64_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEvilWolvesEventStart);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "GainServantFromLost";
        Console.WriteLine();
        if (StaticGameState.allyA == "hunters")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyB == "hunters")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyC == "hunters")
        {
            Console.Write(StaticGameState.nameC);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyD == "hunters")
        {
            Console.Write(StaticGameState.nameD);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyE == "hunters")
        {
            Console.Write(StaticGameState.nameE);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyA != "hunters" && StaticGameState.allyB != "hunters" && StaticGameState.allyC != "hunters" && StaticGameState.allyD != "hunters")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void passage64_Fragment_2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodTaxesEventStart);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "GainServantFromLost";
        Console.WriteLine();
        if (StaticGameState.allyA == "wolves")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyB == "wolves")
        {
            Console.Write(StaticGameState.nameB);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyC == "wolves")
        {
            Console.Write(StaticGameState.nameC);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyD == "wolves")
        {
            Console.Write(StaticGameState.nameD);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyE == "wolves")
        {
            Console.Write(StaticGameState.nameE);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        if (StaticGameState.allyA != "wolves" && StaticGameState.allyB != "wolves" && StaticGameState.allyC != "wolves" && StaticGameState.allyD != "wolves")
        {
            Console.Write(StaticGameState.nameA);
            Console.Write(" III ");
            Console.Write("<bold>");
            Console.Write("immediately gains 1 Servant from Lost and $1");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
        }

        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodElecY()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Anger and Resentment");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "At the next town meeting, the townspeople were furious to discover a government official sent to survey a new extension to the electrical grid. The cousins' actions were noted in the minutes from that event where they disclosed their ");
        Console.Write("<bold>");
        Console.Write("support for the installation of electricity");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and the proposed installation of it at zero cost to the town.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "In a mad display of various ignorances, an angry mob began to form in the center of town, forcing the scientists to retreat by carriage. The crowd soon burst into riotous fury, cursing the government and destroying everything in sight. The riot of 1912 is noted within town archives as the most violent in recorded history. The mob's flaming torches set the Hospital ablaze, leaving multiple individuals severely injured or deceased as they continued into the nearby hills.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("While the people's specific grievance had been long forgotten by the time the mob reached the steps of their estates, it was no less malicious in its issuance of flawed justice.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage69_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage69_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.peeps = 0;
        optionsManager.AddOption("Continue...", ((StaticGameState.imm == "none") ? MethodNoUni3 : MethodDetEffectRandom));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "DiscardEstateUpgrade_Icon";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Each player (regardless of their vote) must choose and discard an Estate Upgrade ");
        Console.Write("<italic>");
        Console.Write("(not a Storage Shed).");
        Console.Write("</italic>");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that voted ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("loses 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodElecN()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Celebration and Anger");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The townspeople sifted through the cousins' erudite proposal at the next town meeting and realized that they intended to ");
        Console.Write("<bold>");
        Console.Write("support their ridiculous distrust of modern convenience");
        Console.Write("</bold>");
        Console.Write(". That evening, a celebratory mob congregated in town with various primitive lighting devices - given the lack of electricity - to cheer and chant their approval.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Fueled by alcohol and inspired by ignorant revelry, the gathering quickly devolved into a riotous mass. Chanting loudly in crass language, they tore down the central streets of the village, leaving nothing untouched in their destructive path.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "In the morning, as the misty streets revealed themselves, the devastation and regret became clear as crystal. Newspapers of the time displayed pictures of the aftermath: the Hospital ablaze, the Town Hall left in smoldering ruins. They hastily rebuilt as best they could, but it would never be the same.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage70_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage70_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.peeps = 1;
        optionsManager.AddOption("Continue...", ((StaticGameState.imm == "none") ? MethodNoUni3 : MethodDetEffectRandom));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "AngryMob_Icon";
        Console.WriteLine();
        Console.Write("Return the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token to its starting location.");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players == 2)
        {
            Console.Write("The player that won the vote also receives ");
            Console.Write("<bold>");
            Console.Write("1 Ingredient or Knowledge");
            Console.Write("</bold>");
            Console.Write(" of their choice.");
        }
        else
        {
            Console.Write("Any player that voted ");
            Console.Write("<bold>");
            Console.Write("Yay");
            Console.Write("</bold>");
            Console.Write(" receives ");
            Console.Write("<bold>");
            Console.Write("1 Ingredient or Knowledge");
            Console.Write("</bold>");
            Console.Write(" of their choice.");
        }

        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodNoUni3b()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("One Last Attempt");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Weary with age and weakened by a brief resurgence of Yellow Fever left uncured, the scientists' last days are spent wheezing and frail. Would this final crucial moment be filled with a single triumph that would secure irrefutable proof of their scientific legacy?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player with a token that is not currently overtaken by the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("receives ");
        Console.Write("<bold>");
        Console.Write("one final Perform Experiment action");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("Scoring", MethodScoring);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodProsperityHunterIntro()
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
            "While they did not require monetary compensation in return, what they did ask was much more severe. Their sanguine efforts could not be completed in isolation, so on nights when the blood moon rose high in the evening sky, a handful of townsfolk were chosen to assist the Hunters' party and venture into the unknown. The next morning, the surviving Hunters would return, their garments speckled in the blood of the beasts and holding aloft the severed trophies of monsters slain in the wilderness. It was only a matter of time before they would call upon the family.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Perhaps driven by a sense of limited time or jealousy over the Hunters' ability to frighten the townsfolk even moreso than their own actions, the cousins continued their meticulous labors in earnest. However, they were deeply unaware of just how intertwined their fates would be to the Fraternity.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("HuntersHUBcode", MethodHuntersHUBcode);
        Console.WriteLine();
        Console.WriteLine();
        StaticGameState.prosp = 1;
        StaticGameState.huntcount = 0;
        StaticGameState.gen3pg = 0;
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
}