namespace MyFathersWorkConsole;

public static partial class Scenario
{
    private static void MethodMayorLibraryEvil()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.building == "library")
        {
            Console.Write("<bold>");
            Console.Write("Detestable Education");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<bold>");
            Console.Write("Carefully hand the Storybook to ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" ");
            Console.Write("III.");
            Console.Write("</bold>");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("It was impossible for ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" III to convince them otherwise; for the new leaders of ");
            Console.Write(StaticGameState.townname);
            Console.Write(", access to untamed knowledge had poisoned the pure minds of the citizens. They were well aware that it was ");
            Console.Write(StaticGameState.mayor);
            Console.Write("'s ancestry that had brought this blight of terrible cognition to this fair town.");
            Console.WriteLine();
            if (StaticGameState.society == "Fraternity of Hunters")
            {
                Console.Write("For with knowledge came a lack of faith; a propensity to question authority and cause unwanted friction. It made them look upon ");
                Console.Write(StaticGameState.mayor);
                Console.Write(" III the same way they looked upon the beasts they hunted in the wild.");
            }
            else
            {
                Console.Write("For with knowledge came a way to overcome the fears inhabiting the hearts of all men - a fear that could be manipulated. And they bore a deep grudge against anyone that sook to quell that primal urge.");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage355_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else if (StaticGameState.hcount == 0 && StaticGameState.society == "Order of St. Hubertus")
        {
            MethodEvilWolvesEventStart();
        }
        else
        {
            MethodLosingOrderAid();
        }

        optionsManager.PresentOptions();
    }

    private static void passage355_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", ((StaticGameState.hcount == 0 && StaticGameState.society == "Order of St. Hubertus") ? MethodEvilWolvesEventStart : MethodLosingOrderAid));
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_MayorCoin";
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("gains 2 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(". Then, return the ");
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


    private static void MethodWolvesBankMayorGood()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        if (StaticGameState.building == "bank")
        {
            Console.Write("<bold>");
            Console.Write("The Stench of Man's Avarice");
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
            Console.Write(
                "These beastly apparitions may have squashed their hirsute forms into makeshift suits and summer dresses - photographs of which degrade the very silver they were impressed upon - but when the subject of money was discussed, they sneered in disgust.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("For they abhored all forms of numismatic pursuits, only abiding them as a necessity in their brief business dealings with the outside world. ");
            Console.Write(StaticGameState.mayor);
            Console.Write(" III's family lineage bore the golden mark of this shameful greed, and set their noses twitching every time they entered ");
            Console.Write(StaticGameState.townname);
            Console.Write("'s limits.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<hook>");
            optionsManager.AddOption("Click to continue...", passage359_Fragment_0);
            Console.Write("</hook>");
            Console.WriteLine();
        }
        else
        {
            MethodResolveCharityWolves();
        }

        optionsManager.PresentOptions();
    }

    private static void passage359_Fragment_0()
    {
        Console.Clear();
        ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();
        optionsManager.AddOption("Continue...", MethodResolveCharityWolves);
        Console.Write("<setupStyleEvnt>");
        Console.Write("<bold>");
        Console.Write("SPECIAL SETUP");
        Console.Write("</bold>");
        StaticGameState._SetupImage = "S1_EstateUpgradeBACK";
        Console.Write(StaticGameState.mayor);
        Console.Write(" ");
        Console.Write("gains 1 ");
        Console.Write("<sprite=\"Creepy_Icon\" index=0>");
        Console.Write(" ");
        Console.Write("and loses ");
        Console.Write("<bold>");
        Console.Write("2VP");
        Console.Write("</bold>");
        Console.Write(". Then, return the ");
        Console.Write("<bold>");
        Console.Write("Commemorative Mayoral Coin");
        Console.Write("</bold>");
        Console.Write(" ");
        Console.Write("to the scenario box.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("</setupStyleEvnt>");
        optionsManager.PresentOptions();
    }
}