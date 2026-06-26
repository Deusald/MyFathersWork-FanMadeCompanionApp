namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodLycanGood()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Strength Can Be Mine");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Their existence was proven. Now could the catalyst for this truly powerful transformation be replicated? And how could it be further strengthened?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage181_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage181_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodProsperity1);
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

    private static void MethodGoodConsequences()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Consequences of Being Good");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The sizzle of concentrated electricity, the sounds of agonized screams, the occasional plume of putrid smoke and teeth-rattling explosion; while these sounds were commonplace to hear emanating from the hilltop residences, they were nevertheless an increasing source of tension between the family's important research and the townsfolk. And while their etiquette would never allow them to directly address the issue, the lycanthropic citizens bristled at each frightening experiment all the same.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The town was desperate to move forward and they could not stomach the cousins' ambitions, which only served to dredge up the weight of guilt over their tortured pasts.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage182_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage182_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEvilsforgive);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("tokens");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("from the scenario box. Each player must place a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the Perform Experiment Action in their Estate.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Every time a Perform Experiment Action is taken, that player will move forward 1 space on the ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("Track ");
        Console.Write("<italic>");
        Console.Write("(in addition to any other printed effects)");
        Console.Write("</italic>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodEvilHunter1Event()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Preposterous");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("And how could they be sure of these claims to rid the land of monsters? Could the superstitions of ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write("have influenced their decisions so completely?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "But, perhaps a sense of safety or convenience had overwhelmed the cousins' frugal disposition. Whatever their motivations, several journal entries noted that without the combined efforts of the group, refusal to pay mandated taxes would only cause undue negative attention.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("All players take their Voting token into their hand. Players will secretly choose a side to place face up in their palm. Then, they will close their fist and extend it to the center of the table.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("Challenge the Hunters");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("about their monster hunting claims.");
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to ");
        Console.Write("<bold>");
        Console.Write("Accept their story");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("When all players have chosen, all players reveal their votes. Tally all the votes and the side with the most votes wins. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the last player in turn order.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here to start the vote...", passage186_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage186_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodEvilHunter1Event2);
        optionsManager.PresentOptions();
    }

    private static void MethodWolvesEvil1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Call for Assistance");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Each cousin's recollection of events seems to corroborate the same story during the Summer of 1892. A messenger, obviously meant to intimidate, arrived by carriage unannounced precisely at noon, dressed in a dapper gray suit stained in thick streaks by rivulets of blood that cascaded from his shoulders. He wore a mask of gore, his animalistic features stained a sanguine red that still dripped from the tips of his teeth, his belly distending the buttons as if he had recently enjoyed a horrifying meal.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "\"I come to collect,\" he entreated with a bow and disgusting lick of his lips. \"It is by our pleasure that you and your family remain alive. And we have need of the knowledge of experimentation that you most assuredly can provide. If this cannot be arranged,\" he paused, pointing in the direction of a servant, \"I have slaked my thirst on the blood of lesser individuals than these today, that I guarantee.\"");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Making a deal with demons? It was impossible for the young scientists to expect an entirely trustworthy offer as presented, yet to allow a human to be knowingly sacrificed to the jaws of these grotesque animals would also be unconscionable.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("In turn order, each player decides whether to contribute an Experiment. Donated Experiments are turned face-down and placed under your Masterwork card.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If a player donates, they will receive an immediate bonus based on the level of the Experiment they donate (");
        Console.Write("<italic>");
        Console.Write("higher levels granting higher rewards");
        Console.Write("</italic>");
        Console.Write(").");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If a player chooses not to donate, they will ");
        Console.Write("<bold>");
        Console.Write("lose a Servant");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("TieredRewards1", MethodTieredRewards1);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodTaxesEventNoConfrontation()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Rising Cost of Living");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "While the townsfolk grumbled at the mention of a continuing increase in taxation, they clutched their crosses to their chests and remained thankful for the Hunters' continued vigilance. Because of their previous acquiescence, the family could no longer voice their displeasure and was forced to remunerate the Fraternity for their service if they had not done so already.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage189_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage189_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.TaxesEventNoConfrontationnextPsg == "" || StaticGameState.TaxesEventNoConfrontationnextPsg == 0)
        {
            StaticGameState.TaxesEventNoConfrontationnextPsg = StaticGameState.GetRandom(new[]
            {
                MethodTaxesEventNoConfrontation2,
                MethodGloomyGothic3
            });
        }

        optionsManager.AddOption("Continue...", StaticGameState.TaxesEventNoConfrontationnextPsg);
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
        Console.Write("Alternatively, any player with a Hunter token ");
        Console.Write("<bold>");
        Console.Write("MUST");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("now discard it to the scenario box to invoke their privilege and forgo this payment.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodTaxesEventStart()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Hunt Begins");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The hunter stood upon the steps of the Hunter's Lodge, dressed in a leather trenchcoat and holding a crossbow in his left hand. His garments were speckled in fresh streaks of blood while other members of the Fraternity stood nearby in black raincoats, brandishing handaxes, pistols, and muskets, holding aloft severed trophies from monsters slain in the wilderness. They had returned from the hunt.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The hunter spoke to the crowd of townspeople that had assembled, his eyes barely visible under the wide brim of his hat. \"No longer will this great city be forced to endure this hardship. We, the Fraternity of Hunters, will take the fight to the beasts of the forest. It is the monsters within these very hills that brought with them a pestilence and spread their sinful disease across the land. And with your assistance, we will exterminate these vermin and drive them back to hell once again!\"");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The speech evoked jubilant cheers from the populace and the Fraternity's dominance over the town was secured. Even a modest ");
        Console.Write("<bold>");
        Console.Write("tax");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("from the new local government to help pay for the hunter's excursions into the wilds was met without skepticism.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("CharityNegCons", MethodCharityNegCons);
        optionsManager.PresentOptions();
    }

    private static void MethodEvilHunter1EventYes()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Prepare a Contest");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The family underwent months of travel both by day and the pale light of the moon with barely the whisper of an ill wind or the echo of a beastly wail. It was clear to their scientific minds that these demonic occurrences were nothing more than mere flights of fancy. Without hesitance, they relayed these accusations against the ");
        Console.Write("<bold>");
        Console.Write("Fraternity of Hunters");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "After an exchange of exasperated guffaws, it was decided that the Fraternity would provide guaranteed proof of their supernatural exploits by confronting the cursed beasts of the evening in full view of the townspeople. A great festival was planned around the contest, and under the light of a blood moon they would venture into the cursed hills and return with more trophies than ever before. But, if they were successful, the scientists would owe them a debt, ");
        Console.Write("<bold>");
        Console.Write("with interest");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The cousins agreed to the terms while also devising a most insidious plot. They chortled with undisguised laughter. If the Hunters wanted a true bounty, they would give it to them!");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("GloomyGothic2", MethodGloomyGothic2);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
    
    private static void MethodHunterConfrontation()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Grand Contest - April, 1902");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("After years of apologies and unfortunate delays by the ");
        Console.Write("<bold>");
        Console.Write("Fraternity of Hunters");
        Console.Write("</bold>");
        Console.Write(", the night of the Grand Contest had arrived. The confrontation had been touted extensively within the region and visitors gathered near the ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write(
            "Lodge to witness the spectacle of the hunt. The Hunters were treated to a tickertape parade and glorious feast. But, as the light of the afternoon slowly faded, the sky began to glow with fiery intensity, and the revelry ceased.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The Hunters donned their signature clothes, took up their well-polished arms, and proceeded down the main thoroughfare while the crimson light of the blood moon heralded their exit into the forests beyond.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "That same fire reflected in the eyes of the scientists as they stifled their grim laughter. The night before, the cousins had prepared their chosen Experiments to release into the wild. It was time now for the Hunters to become the prey!");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("CannotParticipate", MethodCannotParticipate);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
    
    private static void MethodOhYesTheyDead()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A \"Hero's\" Welcome");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The cousins enjoyed fresh pastries and coffee as they admired the town's activities with amusement from their folding lawn chairs. When the triumphant return they had expected never came, the gathered crowds became restless and burst into the Hunter's Lodge only to discover stores of freshly slaughtered goat's blood and taxidermy supplies. The Fraternity had played them for fools.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The town gallows had fallen into disrepair over the years, but upon the return of the remaining wild-eyed hunters that somehow survived the vicious experiments, lumber was quickly procured by the decidedly unimpressed townsfolk along with fresh hemp rope, thick and strong. The same crowd that gathered that afternoon for the festivities would be the crowd that watched every last writhing body swing lifeless for their crimes. If any Hunters did survive, they most certainly never returned.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The people would speak of the Grand Contest as one of the crowning events in the history of ");
        Console.Write(StaticGameState.townname);
        Console.Write(". Having rooted out the evil infesting their government, the town entered a period of peace that was especially productive for a group of scientists.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage193_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage193_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic3);
        StaticGameState.taxes = "no";
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "ScoreTrackMarker";
        Console.WriteLine();
        Console.Write("The player(s) who contributed the Experiment worth the highest VP gains ");
        Console.Write("<bold>");
        Console.Write(StaticGameState.huntvp);
        Console.Write("VP");
        Console.Write("</bold>");
        Console.Write(". ");
        Console.Write("<italic>");
        Console.Write("All tied players gain this VP.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Move the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token ");
        Console.Write("<bold>");
        Console.Write("2 spaces");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the right.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("All contributed Experiments are then discarded to the bottom of the appropriate Experiment decks.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodConfrontationFail()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Hero's Welcome");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.taxes = "yes";
        Console.WriteLine();
        Console.Write(
            "The Hunters return relatively unscathed by the proceedings to a resounding cheer from the excited crowd. Covered in blood and oil, with the trophies of their victory held high, they regaled the crowd with their highly embellished and harrowing tale. Each ferocious severed head receiving more applause than the last.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "For a family that until now had never been forced to admit shame, the blow was unmistakable. Disheartened and angry with their current fate, they silently immersed themselves in their labors, resolved to avoid further visits to town at all costs.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Experimental Bonus");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("The player(s) who contributed the Experiment worth the highest VP gains ");
        Console.Write("<bold>");
        Console.Write(StaticGameState.huntvp);
        Console.Write("</bold>");
        Console.Write(". ");
        Console.Write("<italic>");
        Console.Write("All tied players gain this VP.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("All contributed Experiments are discarded.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage194_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage194_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodGloomyGothic3);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "AngryMob_Icon";
        Console.WriteLine();
        Console.Write("Move the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token ");
        Console.Write(StaticGameState.GetRandom(new[]
        {
            2,
            3
        }));
        Console.Write(" ");
        Console.Write("spaces to the left.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("ALL players must choose and perform one penalty:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("Pay $3.");
        Console.WriteLine();
        Console.Write("Return 3 resources to the supply.");
        Console.WriteLine();
        Console.Write("Discard 2 Estate Upgrades.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<italic>");
        Console.Write("If this is not possible, they instead ");
        Console.Write("<bold>");
        Console.Write("lose 5VP");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</italic>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodHunterConf2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("EXPERIMENTS UNLEASHED");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("All remaining eligible players take all the Experiments they have completed ");
        Console.Write("<bold>");
        Console.Write("this Generation");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("into their hands ");
        Console.Write("<italic>");
        Console.Write("(excluding any Masterwork)");
        Console.Write("</italic>");
        Console.Write(". Then, they secretly choose an Experiment card (or no card at all) and keep it hidden under their palm.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Once all players have chosen, all players reveal the card (or no card) they have chosen simultaneously. This card will be discarded after the event is resolved.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Then, players will ");
        Console.Write("<bold>");
        Console.Write("count up the total value of the VP on all donated Experiment cards.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If the value is equal to ");
        if (StaticGameState.players == 2)
        {
            StaticGameState.huntnum = new Random().Next(3, 7 + 1);
        }

        if (StaticGameState.players == 3)
        {
            StaticGameState.huntnum = new Random().Next(8, 12 + 1);
        }

        if (StaticGameState.players == 4)
        {
            StaticGameState.huntnum = new Random().Next(11, 15 + 1);
        }

        if (StaticGameState.players == 5)
        {
            StaticGameState.huntnum = new Random().Next(13, 19 + 1);
        }

        Console.Write(StaticGameState.huntnum);
        Console.Write(" ");
        Console.Write("or higher, the unleashed experiments will succeed.");
        Console.WriteLine();
        Console.Write("If the value is less, the hunters will prevail.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to start the bid.", passage195_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage195_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodHunterConf3);
        optionsManager.PresentOptions();
    }

    private static void MethodTaxesEventNoConfrontation2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Pittance");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("While it amounted to little less than political pandering, the Hunters did, however, offer kind words and assurances to the people of ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write(
            "in response to the family's gentle consent to further taxation. This did nothing to soothe the financial stress it placed upon them, nor did it cool their sneering derision when the deeds of the Hunters were brought up in casual conversations about town.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage196_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage196_Fragment_0()
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
        Console.Write("All players, in turn order, may choose to either ");
        Console.Write("<bold>");
        Console.Write("lose 2 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("or ");
        Console.Write("<bold>");
        Console.Write("gain an ingredient");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("of their choice from the supply.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodUniMayor()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Legacy of Leadership");
        Console.Write("</bold>");
        Console.WriteLine();
        if (StaticGameState.uni == "yes")
        {
            Console.Write("With the continued success of the University");
        }
        else
        {
            Console.Write("To christen the advantageous construction of the new university");
        }

        Console.Write(" ");
        Console.Write("and the return of the eccentric family seemingly responsible for that turn of events, the city of ");
        Console.Write(StaticGameState.townname);
        Console.Write(" ");
        Console.Write("arranged a large parade.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Photographs from the event show a disgruntled individual sitting atop a large float made of crocuses and lilies, powered by a newly procured steam and wheel device. ");
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("III does not mention this event within their journal, however it is noted extensively and with great sardonic enthusiasm for the next several months in the journals of their cousins.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("It was under the leadership of ");
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("that this push for modern sensibilities was first spearheaded and the town could not forget the significance of this event.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage199_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage199_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.life == 0) ? MethodUniEquity : MethodUniImmortal));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MayorCoin";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Retrieve a ");
        Console.Write("<bold>");
        Console.Write("Charity Memorial");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Estate Tile from the scenario box. ");
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("III may build this in their next available plot. They do not have to pay the cost to open a new plot.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Return the Commemorative Mayoral Coin to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodUniCharity()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Charity's Legacy");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.mayor == StaticGameState.charity)
        {
            Console.Write("It seemed the festivities in ");
            Console.Write(StaticGameState.townname);
            Console.Write(" could scarcely cease before another bright and joyous event occurred. Only a few years after a memorial had been erected in the honor of ");
            Console.Write(StaticGameState.mayor);
            Console.Write(
                " III, the Hospital could not contain its admiration as well. It was surprised and overjoyed to discover that the same individual's family was not only responsible for guiding the town politically, but cemented their important legacy of giving.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(StaticGameState.mayor);
            Console.Write(
                " III was visibly agitated by the intrusion into their affairs, but when offered assistance from top researchers in the region, their surly demeanor softened temporarily. Perhaps the minor inconvenience of friendship and celebration would be worth the boon to their inventions.");
        }
        else
        {
            Console.Write("It seemed the festivities in ");
            Console.Write(StaticGameState.townname);
            Console.Write(" ");
            Console.Write("could scarcely cease before another bright and joyous event occurred. Only a few years after a memorial had been erected in the honor of ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" ");
            Console.Write("III, the Hospital could not contain its admiration as well. ");
            Console.Write(StaticGameState.charity);
            Console.Write(" ");
            Console.Write("III was offered the same generosity.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("In honor of ");
            Console.Write(StaticGameState.charity);
            Console.Write("'s legacy of charity, another memorial was revealed at a prestigious ceremony, celebrating the continued medical contributions of ");
            Console.Write(StaticGameState.townname);
            Console.Write(". As a university town, the small village hosted an impressive pedigree of scholars who worked with the most advanced methodology in treatment and disease prevention.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage200_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage200_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodDetEffectRandom);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_HeartToken";
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.mayor == StaticGameState.charity)
        {
            Console.Write("Immediately move ");
            Console.Write("<bold>");
            Console.Write("1 space forward");
            Console.Write("</bold>");
            Console.Write(" on the Journal track of your choice ");
            Console.Write("<italic>");
            Console.Write("for no cost");
            Console.Write("</italic>");
            Console.Write(". Then, lose ");
            Console.Write("<bold>");
            Console.Write("2VP");
            Console.Write("</bold>");
            Console.Write(".");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Return the ");
            Console.Write("<bold>");
            Console.Write("Heart ");
            Console.Write("<sprite=\"S1_HeartToken\" index=0>");
            Console.Write(" token");
            Console.Write("</bold>");
            Console.Write(" to the scenario box.");
        }
        else
        {
            Console.Write("Retrieve a ");
            Console.Write("<bold>");
            Console.Write("Charity Memorial");
            Console.Write("</bold>");
            Console.Write(" ");
            Console.Write("Estate Tile from the scenario box. ");
            Console.Write(StaticGameState.charity);
            Console.Write(" ");
            Console.Write("III may build this in their next available plot. They do not have to pay the cost to open a new plot. \n\nReturn the <b>Heart <sprite=\"S1_HeartToken\" index=0> token</b> to the scenario box.");
        }

        Console.Write("</setupStyleEvnt>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodUniEquity()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Guiding Hand of Science");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "At the behest of the university’s administrators, it was decided to more prominently feature scholarly works produced by local inventors. However, the administration deemed it unwise to promote the works of those who had already solidified their presence in the public eye. The course of action they deemed most appropriate was to provide an “equitable” boost to amplify the standing of lesser-known scientists, to better display the breadth of knowledge and ambition within the humble city of ");
        Console.Write(StaticGameState.townname);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The family was disgusted by this “lopsided” display of unmerited assistance. However, they accepted it nonetheless, leaving the most seasoned cousin to grumble at the injustice of it all.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage201_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage201_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodInsanitySign);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "ScoreTrackMarker";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Starting with the player(s) in last place, each player gains 1VP for each other player's piece that is ahead of them on the VP track. ");
        Console.Write("<italic>");
        Console.Write("For example, if a player is in 3rd place, two other pieces are ahead and they will gain 2VP.");
        Console.Write("</italic>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodUniEquity1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Another Competitive Assessment");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The University insisted upon periodic inspections of the laboratories and experimental apparatus being used by interns apportioned from the student body. While each scientist affected a congenial appearance and made sure to conceal their more sinister workings during these assessments, they made no similar attempts to conceal their agitation afterwards.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("However, the pitiable honorariums provided to those family members with lesser reputations continued.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage202_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage202_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodUniEvent1UltimateDisease);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "ScoreTrackMarker";
        Console.WriteLine();
        Console.Write("Starting with the player(s) in last place, each player gains 1VP for each other player's piece that is ahead of them on the VP track. ");
        Console.Write("<italic>");
        Console.Write("For example, if a player is in 3rd place, two other pieces are ahead and they will gain 2VP.");
        Console.Write("</italic>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodUniEvent1UltimateDisease()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Ignored Amongst the Scientific Elite");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The ");
        Console.Write(StaticGameState.playtxt);
        Console.Write(" ");
        Console.Write(
            "cousins watched with dour hearts as the once morose streets were festooned with bright spring colors. Educated middle-class families strolled along the sidewalks in modest clothing. Children laughed and rode bicycles in the park. They shuddered at the sight. It was all ");
        Console.Write("<bold>");
        Console.Write("too good");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "With the initial festivities over, their estimation had soured in the eyes of the academics. Though they had not been spurned or mistreated, the once generous enthusiasm had waned from repeated ethical infractions, misuse of the medical operating theater, and radical outbursts during local symposiums. And to complicate matters further, it became increasingly obvious that due to the peaceful and progressive values of ");
        Console.Write(StaticGameState.townname);
        Console.Write(", the educated were less troubled with matters of any immediate, existential, or diabolical concern.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The solution to this lack of a problem was obvious. If the world refused to create a new, horrific problem to solve, then they would defy nature and create it themselves. Surely, if they combined their efforts, they could create the ");
        Console.Write("<bold>");
        Console.Write("ultimate disease");
        Console.Write("</bold>");
        Console.Write("! A disease so infectious that they would forever undo this plague of positivity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("This would certainly ");
        Console.Write("<bold>");
        Console.Write("rid them of this unfair and blatant balancing");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("of fortunes.");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("UniCharity", MethodUniCharity);
        optionsManager.PresentOptions();
    }


    private static void MethodUniEvent2UltimateDisease()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The Ultimate Disease");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("As the oppressive sunshine illuminated the study of ");
        if (StaticGameState.players == 2)
        {
            Console.Write(StaticGameState.GetRandom(new[]
            {
                StaticGameState.nameA,
                StaticGameState.nameB
            }));
            Console.Write(" ");
        }
        else if (StaticGameState.players == 3)
        {
            Console.Write(StaticGameState.GetRandom(new[]
            {
                StaticGameState.nameA,
                StaticGameState.nameB,
                StaticGameState.nameC
            }));
            Console.Write(" ");
        }
        else if (StaticGameState.players == 4)
        {
            Console.Write(StaticGameState.GetRandom(new[]
            {
                StaticGameState.nameA,
                StaticGameState.nameB,
                StaticGameState.nameC,
                StaticGameState.nameD
            }));
            Console.Write(" ");
        }
        else if (StaticGameState.players == 5)
        {
            Console.Write(StaticGameState.GetRandom(new[]
            {
                StaticGameState.nameA,
                StaticGameState.nameB,
                StaticGameState.nameC,
                StaticGameState.nameD,
                StaticGameState.nameE
            }));
            Console.Write(" ");
        }
        else
        {
            Console.Write(StaticGameState.GetRandom(new[]
            {
                StaticGameState.nameA,
                StaticGameState.nameB
            }));
            Console.Write(" ");
        }

        Console.Write(
            "III, the cousins assembled to finalize their creation. With a large piece of parchment sprawled across the desk and delightful bean strudels with heavy cream for refreshment, the scientists began to formulate a blueprint using the knowledge they had gained from recent experimentations.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Some, however, were more forthcoming with information than others.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("VOTE");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "Players will now vote to collaborate with their knowledge to create a new disease. All players take their Voting token into their hand. Players will secretly choose a side to place face up in their palm. Then, they will close their fist and extend it to the center of the table.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Yay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to discard ");
        Console.Write("<bold>");
        Console.Write("1 completed Chemistry or Occult Experiment");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.Write("A ");
        Console.Write("<bold>");
        Console.Write("Nay");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("vote is a vote to NOT contribute an experiment.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("When all players have chosen, all players reveal their vote. Tally all votes and the side with the most votes wins. ");
        Console.Write("<bold>");
        Console.Write("<italic>");
        Console.Write("Ties are considered a win for the \"yay\" vote.");
        Console.Write("</italic>");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click here to start the vote...", passage204_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage204_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodUniEvent2UltimateDisease2);
        optionsManager.PresentOptions();
    }

    private static void MethodUniEvent2Success()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Wondrous Success");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "Symptoms: Nausea, fever, vomiting, hypertension, drowsiness, loss of libido, skin lesions, blurred vision, heart palpitations, headache, weight-loss, chronic pain, demonic possession. The prospectus for the ultimate disease included nearly every side-effect known to science. The cousins spent the late-night hours laughing till their throats were hoarse as they concocted the elixir.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The following week, the disease was released at the Farmer's Market, a tincture of the foul liquid smashed against the steps. It proved communicable within seconds and the noxious gases spread from person-to-person with each dry cough.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "However, the effect was not altogether anticipated. This grim amalgamation of deadly diseases, while invoking minor symptoms in some initially exposed, caused antibodies to build up within the region, nullifying their effects and strengthening their systems against infection. By creating a disease that included all known symptoms, they had essentially inoculated the populace against all disease simultaneously.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "It wasn't long before the university traced the source of the marvel to the cousins. Word soon traveled about their research, and the town applauded yet another triumph for science and the world! Clearly, this family of scientists needed no assistance in their heavenly endeavors.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage205_Fragment_1);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
    
    private static void passage205_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.ultimate = "yes";
        optionsManager.AddOption("Continue...", MethodDetEffectRandom);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Any player that voted to contribute discards a ");
        Console.Write("<bold>");
        Console.Write("completed");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Chemistry or Occult Experiment. Each player that contributed ");
        Console.Write("<bold>");
        Console.Write("gains 2 resources");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("of their choice from the supply.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that did not contribute ");
        Console.Write("<bold>");
        Console.Write("gains 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(".");
        Console.Write("</bold>");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodUniEvent2Failure()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Unfortunate Failure");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "With the cousins guarding their knowledge and no consensus on how to move forward, the meeting soon devolved into bickering and one-upmanship. Each cousin pontificated at length their personal achievements and the unexpressed envy the others had towards their work. Many of the pastries were left half-eaten that night.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("As the science was unsuccessful, they each retired to their estates in the late evening to let the familial jibes fester in their minds.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The town remained unaffected by their exchange of harsh words. And as before, they continued to offer assistance to those who they felt were lacking the resources. What a pitiable learning opportunity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage206_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage206_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodDetEffectRandom);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Each player counts the total amount of levels they have gained on their Journal Research Tracks. The ");
        if (StaticGameState.players < 4)
        {
            Console.Write("player with the lowest total ");
            Console.Write("<bold>");
            Console.Write("moves their research marker forward 1 level");
            Console.Write("</bold>");
        }

        if (StaticGameState.players > 3)
        {
            Console.Write("<bold>");
            Console.Write("2");
            Console.Write("</bold>");
            Console.Write(" players with the lowest total ");
            Console.Write("<bold>");
            Console.Write("move their research marker forward 1 level");
            Console.Write("</bold>");
        }

        Console.Write(" ");
        Console.Write("on the track of their choice at no cost. ");
        Console.Write("<italic>");
        Console.Write("If there is a tie, ties are broken by the player with the least VP.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Any player that voted \"yay\" to contribute does not discard an Experiment. But, they ");
        Console.Write("<bold>");
        Console.Write("lose 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodCharityAwardGood()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Carefully hand the Storybook to ");
        Console.Write(StaticGameState.charity);
        Console.Write(". This passage is read out loud in view of all players.");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("Consideration of Righteousness");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The Fraternity was correct to be cautious in their dealings with the eccentric family whose ominous visitings within the city carried a sinister air about them. However, their fears could not completely overshadow their righteous convictions.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(StaticGameState.charity);
        Console.Write(" ");
        Console.Write("III's familial legacy of ");
        Console.Write("<bold>");
        Console.Write("charity");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write(
            "was instrumental in sharing the gift of knowledge. Modern weaponry had transformed the Hunter's ability to fight against the evil forces threatening to overtake the city. And it was this malignant sentiment that forced their hand to offer a token of their appreciation.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage207_Fragment_0);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage207_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodCureMoonSick1);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_EstateUpgradeBACK";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Personal Library");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Estate Upgrade from the scenario box. You may immediately build it in the next empty plot on your Estate board at no additional cost. Then, return the Heart <sprite=\"S1_HeartToken\" index=0> token to the scenario box.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
    
    private static void MethodMayoralAward()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.building == "library")
        {
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Carefully hand the Storybook to ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" ");
            Console.Write("III. This passage is read out loud in view of all players.");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("The Benefit of Knowledge");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "The path to enlightenment is a not without its humble beginnings, and the creatures that now embraced a gentler path could not have done so without an intense pursuit of knowledge. The deviant machinations of a cruel world may have doomed them to these egregious forms, but to find peace with one's self is a struggle all beings face.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The townsfolk appreciated ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" ");
            Console.Write("III's lineage as partly responsible for spearheading the gift of ");
            Console.Write("<bold>");
            Console.Write("knowledge");
            Console.Write("</bold>");
            Console.Write(" ");
            Console.Write("above all else in the generations past. They desire to repay this Librarian lineage with a contribution of their own.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage208_Fragment_0);
            Console.Write("</hook>");
        }
        else
        {
            MethodWolvesBankMayorGood();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage208_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodResolveCharityWolves);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_EstateUpgradeBACK";
        Console.WriteLine();
        Console.Write("Retrieve the ");
        Console.Write("<bold>");
        Console.Write("Personal Library");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Estate Upgrade from the scenario box. You may immediately build it in the next empty plot on your Estate board at no additional cost. Then, return the <b>Commemorative Mayoral Coin</b> to the box.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Whenever you take the Perform Experiment action, the ");
        Console.Write("<bold>");
        Console.Write("Personal Library");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("provides one free Knowledge of your choice from the supply. This Knowledge can be used immediately towards the cost of Performing that Experiment.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodEquitableValues()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Deplorable Equity");
        Console.Write("</bold>");
        StaticGameState.gen3pg = 0;
        Console.WriteLine();
        Console.Write("For the first time in decades, the townsfolk expressed a sense of community, a singular and modern identity. ");
        if (StaticGameState.society == "Order of St. Hubertus")
        {
            Console.Write(
                "The Order of St. Hubertus remained an official moniker, but a new, more democratic society emerged. The secrets that had remained hidden for so long had finally been exposed and the sense of freedom was finally something worth protecting.");
        }
        else
        {
            Console.Write("While members of the Fraternity attended to their dark business, sharpening their skills and weapons on their own, the town remained resolute in their ability to rid the surrounding hills of evil.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Unlike previous generations that were keen to allow an aloof eccentric to isolate themselves amongst the rocky crags at the valley's edge, the townsfolk became determined in their attempts to ingratiate the obstinate cousins into the fold. While the reception was always cold and the iron gates and foreboding wooden doorways were mostly closed to them, they never stopped trying.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("While they would never admit to it, the ones who were most desperate tended to accept the offers more readily.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage212_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage212_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodLycanMessageGood);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The ");
        if (StaticGameState.players <= 3)
        {
            Console.Write("player with the fewest VP gains 1");
        }

        if (StaticGameState.players >= 4)
        {
            Console.Write("<bold>");
            Console.Write("2");
            Console.Write("</bold>");
            Console.Write(" players with the fewest VP gain 1");
        }

        Console.Write(" ");
        Console.Write("of their Servants from Lost. ");
        Console.Write("<italic>");
        Console.Write("Ties are broken by the player who went last in the previous round.");
        Console.Write("</italic>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The player with the most points gains 2 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodLycanMessageGood()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.wolves == "good")
        {
            Console.Write("<bold>");
            Console.Write("The Form of the Wolf");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.Write(
                "Though the sight had now become commonplace, confirming the existence of persons with the ability to change into an animal form had remarkable consequences. It is possible that it even disrupted the studies of one of our kin.");
            Console.WriteLine();
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
            optionsManager.AddOption("Yes.", passage213_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
            Console.WriteLine();
            optionsManager.AddOption("Prosperity1", MethodProsperity1);
            Console.WriteLine();
        }
        else
        {
            MethodProsperity1();
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage213_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.lycan = "yes";
        MethodLycanGood();
        optionsManager.PresentOptions();
    }

    private static void MethodWolvesEcoFriendly()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Message");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "As the new decade began, the motley parade of beastly horrors had turned their claws from weapons of destruction into instruments of cultivation. They embraced modern amenities and fashions, walking the streets with upright strides as the town continued to thrive.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("For most, however, this new sense of peace was tarnished by the persistence of past injustices. As newspaper pressings became even more accessible, pamphlets and signage began to circulate amongst the populace.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("\"Our brethren; abused, slaughtered, and experimented upon. No more! We can bear this injustice no longer.\" One paper stated, \"Meat is murder.\"");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Most had adopted a Pythagorean diet, developing a keen culinary taste for vegetable curries and rich, barley porridge. While it was not strictly forbidden to consume the cooked flesh of domestic animals, when the cousins' town business included a stop by the Farmer's Market, the townsfolk looked away in horror, mothers shielding their furred children's eyes as the implication was too much for them to bear.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Yet still roiling beneath the thin veneer of prim etiquette, a baser nature threatened to reemerge anew.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage214_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage214_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.building == "library") ? MethodMayoralAward : MethodWolvesBankMayorGood));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Put a ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token on the ");
        Console.Write("<bold>");
        Console.Write("Farmer's Market");
        Console.Write("</bold>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodAngryMobStorybook()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Frightful Day");
        Console.Write("</bold>");
        Console.WriteLine();
        StaticGameState.amtoken = StaticGameState.GetRandom(new[]
        {
            1,
            2
        });
        StaticGameState.gen3pg = 1;
        Console.WriteLine();
        if (StaticGameState.amtoken == 1)
        {
            Console.Write("There were moments when the rage amongst the townsfolk would well up and explode in uncontrollably violent outbursts. For the monsters of ");
            Console.Write(StaticGameState.townname);
            Console.Write(", these were no longer represented by torches or pitchforks held high, but by a feverish bloodlust.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("As such, it was a calm Sunday afternoon when a local werewolf doffed his cap and interrupted tea time by holding up a blood-stained and torn piece of fabric.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("He placed the scrap onto the table. \"We would return the body to you for proper burial if it were still possible,\" he shrugged, his ears flattening. \"But, you know how it goes when bones are involved. Sorry.\"");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Another good servant gone. It was somewhat inevitable, yet still an unfortunate loss of life, time and money.");
        }
        else
        {
            Console.Write("To be awakened early morning after a late night's work was agitating, but to awake to a shrill, blood-curdling scream was something else entirely.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "A woman in a modest blue dress crouched near the entrance to the estate, her blood-covered maw held within two clawed hands as she wailed in distress. A few feet away, two wolves clad in sharp business suits huddled over the dead body of a servant, tearing into the flesh with their teeth and claws as fresh blood flowed down the gravel drive.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(
                "A monster stood nearby, clearly resisting the urge to join into the fray. He fixed his tie and wiped away saliva from his chin before speaking in a solemn voice. \"Poor thing couldn't control herself. Took the first bite. Terrible tragedy. Awfully sorry.\"");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Perhaps it was unavoidable that the close proximity of humanity to the beasts would incite such an event.");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage215_Fragment_1);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }

    private static void passage215_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.round == 13) ? MethodProsperity1 : ((StaticGameState.round == 14) ? MethodProsperity2 : MethodProsperity3)));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "Creepy_Icon";
        Console.WriteLine();
        Console.Write("Return a Servant to Lost. ");
        if (StaticGameState.round == 15)
        {
            Console.Write("Then lose ");
            Console.Write("<bold>");
            Console.Write(StaticGameState.GetRandom(new[]
            {
                2,
                3
            }));
            Console.Write("VP");
            Console.Write("</bold>");
            Console.Write(".");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Move your ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token ");
        Console.Write("<bold>");
        Console.Write("2 spaces");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the left. Move the ");
        Console.Write("<sprite=\"AngryMob_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("token ");
        Console.Write("<bold>");
        Console.Write("3 spaces");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the right ");
        Console.Write("<italic>");
        Console.Write("(or as far as possible)");
        Console.Write("</italic>");
        Console.Write(".");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodGoodFrenzyEvent()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Reasoned Proposal");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "While the system of progressive monster reform was altruistic, it was not without its imperfections. Infractions ranging from minor maulings to severe interdental jugular removal were noted over the years, as were the manic episodes associated with these incidents.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "It was clear that humans were marginally upset about the lack of livestock and uptick in missing persons potentially consumed by wolves. It was also clear that each monster would experience near daily urges to indulge in profane behavior that they were forced to suppress.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Perhaps, they suggested, if they could attempt to indulge their darker urges in a safe space where this expression was fully encouraged, then it would pacify those urges at other more domestic times.");
        Console.WriteLine();
        Console.WriteLine();
        if (StaticGameState.players == 2)
        {
            optionsManager.AddOption("2p-FrenzyALT", Method2pFrenzyALT);
        }
        else
        {
            optionsManager.AddOption("GoodFrenzyEvent2", MethodGoodFrenzyEvent2);
        }

        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void MethodYesFrenzy()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("The FRENZY");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write(
            "The townsfolk who chose not to participate locked their doors and boarded their windows, but the first howls of ghoulish delight sent those same individuals clawing at the walls to be released into the wild again. The Frenzy spared no person in ");
        Console.Write(StaticGameState.townname);
        Console.Write(
            ". The unhinged spectacle set the teeth gnashing and a passionate fire blazing both metaphorically and physically, plumes of hot embers erupting upwards from homes set ablaze with wild abandon. When a door burst open or a window shattered, barely a strangled cry could be heard before another victim's fresh blood spilled into the streets.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "Indulging in latent urges proved not to quell the dormant urges of the citizenry, but to stoke it. In the coming weeks, the logical faculties of the changed townfolk were removed. And in its place, a well of anger and a bloodlust so acute it left the landscape to darken and the soil to sour!");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The thin line between civility and savagery had been severed. The monsters were set loose to prowl the region and invoke their hideous reign upon the unsuspecting masses.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage217_Fragment_0);
        Console.Write("</hook>");
        Console.WriteLine();
        optionsManager.PresentOptions();
    }

    private static void passage217_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        StaticGameState.frenzy = "yes";
        MethodProsperity3b();
        optionsManager.PresentOptions();
    }
    
    private static void MethodNoFrenzy()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("A Reasoned Response");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("The recommendation was accepted with gravitas. While many remained wistful, the group's almost immediate adoption of the concept made it clearly a dangerous proposition.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("To further preoccupy their minds and to quell the bloodlust just beneath the surface, they offered further building assistance to reinforce a wider variety of scientific disciplines.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<hook>");
        optionsManager.AddOption("Click to continue...", passage218_Fragment_1);
        Console.Write("</hook>");
        optionsManager.PresentOptions();
    }
    
    private static void passage218_Fragment_1()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodProsperity3);
        StaticGameState.frenzy = "no";
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
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("Engineering Master's Study");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("Vanity Estate Upgrades from the scenario box and place them nearby. Any time you gain a Vanity Estate Upgrade, you may choose to gain 1 of these instead.");
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }

    private static void MethodWolvesEvil2()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        Console.Write("<bold>");
        Console.Write("Once More the Accursed Contribution");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(
            "The messenger did not appear until nightfall, whereupon the lateness of arrival interrupted the cousins' dessert and coffee. The moonlight reflected off his steel gaze as he entered the sitting room without invitation. His fangs had tasted blood that same night.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("The family could delay their offering no longer and the beasts of the Order salivated with anticipation over the knowledge they would soon acquire.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("<bold>");
        Console.Write("CHOOSE:");
        Console.Write("</bold>");
        Console.WriteLine();
        Console.Write("In turn order, each player decides whether to contribute an Experiment. Donated Experiments are turned face-down and placed under your Masterwork card.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If a player donates, they will receive an immediate bonus based on the level of Experiment they donate (");
        Console.Write("<italic>");
        Console.Write("higher levels granting higher rewards");
        Console.Write("</italic>");
        Console.Write(").");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("If a player chooses not to donate, they will ");
        Console.Write("<bold>");
        Console.Write("lose a Servant");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("and ");
        Console.Write("<bold>");
        Console.Write("gain 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write("</bold>");
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        optionsManager.AddOption("TieredRewards2", MethodTieredRewards2);
        Console.WriteLine();
        optionsManager.PresentOptions();
    }
}