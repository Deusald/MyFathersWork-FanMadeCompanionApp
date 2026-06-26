using System.Security.Cryptography;

namespace MyFathersWorkConsole;

public static class StaticGameState
{
    public static dynamic players = 0;
    public static dynamic tracker = 0;
    public static dynamic round = 0;
    public static dynamic _SetupImage = "";

    public static dynamic nameA = "";
    public static dynamic nameB = "";
    public static dynamic nameC = "";
    public static dynamic nameD = "";
    public static dynamic nameE = "";

    public static dynamic creepy4 = 0;
    public static dynamic sane3 = 0;
    public static dynamic seedy = "";

    public static dynamic building = "";
    public static dynamic cured = 0;
    public static dynamic sciadv = 0;
    public static dynamic sci3 = "";
    public static dynamic trigger35 = 0;
    public static dynamic devpage = 0;

    public static dynamic wolves = "";
    public static dynamic hunters = "";
    public static dynamic mayor = "";
    public static dynamic townname = "";

    public static dynamic heart = 0;
    public static dynamic hearttotal = 0;
    public static dynamic charitytotal = 0;

    public static dynamic hos = 0;
    public static dynamic life = 0;
    public static dynamic fevervp = 0;
    public static dynamic fevermoney = 0;

    public static dynamic lycan = "";
    public static dynamic immort = "";
    public static Action ending;
    public static dynamic theme = "";
    public static dynamic final5 = "";
    public static dynamic bar = "";
    public static dynamic uni = "";

    public static dynamic peeps = 0;
    public static dynamic pana = 0;

    public static dynamic mental = "";
    public static dynamic saneplayer = "";
    public static dynamic barin = "";
    public static dynamic charity = "";

    public static dynamic _icon = "";

    public static List<dynamic> build = new();
    public static dynamic buildA = "";
    public static dynamic buildB = "";
    public static dynamic buildC = "";
    public static dynamic ba = "";
    public static dynamic bb = "";
    public static dynamic bc = "";
    public static dynamic inv = "";
    public static dynamic vial = "";

    public static dynamic playtxt = "";
    public static dynamic ultimate = "";
    public static dynamic meet = "";

    public static dynamic allyA = "";
    public static dynamic allyB = "";
    public static dynamic allyC = "";
    public static dynamic allyD = "";
    public static dynamic allyE = "";

    public static dynamic bar1 = "";
    public static dynamic bar2 = "";
    public static dynamic bar3 = "";
    public static dynamic bar4 = "";
    public static dynamic bar5 = "";

    public static dynamic fevercure = "";
    public static dynamic panacure = "";
    public static dynamic tempjournal = "";

    public static dynamic symp = "";
    public static dynamic pub = "";
    public static dynamic society = "";
    public static dynamic imm = "";
    public static List<dynamic> letter = new();

    public static dynamic pa = "";
    public static dynamic pb = "";
    public static dynamic pc = "";
    public static dynamic pd = "";
    public static dynamic pe = "";

    public static dynamic let1 = "";
    public static dynamic let2 = "";
    public static dynamic let3 = "";
    public static dynamic let4 = "";
    public static dynamic let5 = "";
    public static dynamic let6 = "";

    public static dynamic exposeA = 0;
    public static dynamic goodcount = 0;
    public static dynamic pAA = "";
    public static dynamic pBA = "";
    public static dynamic pCA = "";
    public static dynamic pDA = "";
    public static dynamic pEA = "";

    public static dynamic exposeB = 0;
    public static dynamic pAB = "";
    public static dynamic pBB = "";
    public static dynamic pCB = "";
    public static dynamic pDB = "";
    public static dynamic pEB = "";

    public static dynamic exposeC = 0;
    public static dynamic pAC = "";
    public static dynamic pBC = "";
    public static dynamic pCC = "";
    public static dynamic pDC = "";
    public static dynamic pEC = "";

    public static dynamic prosp = "";
    public static dynamic huntcount = 0;

    public static dynamic letterA = "";
    public static dynamic letterB = "";
    public static dynamic letterC = "";
    public static dynamic letA = "";
    public static dynamic letB = "";
    public static dynamic letC = "";

    public static dynamic refusaltoken = 0;
    public static dynamic sick = "";

    public static dynamic playA = 0;
    public static dynamic playB = 0;

    public static dynamic det1 = "";
    public static dynamic killed = 0;
    public static dynamic det2 = "";
    public static dynamic det3 = "";
    public static dynamic det4 = "";

    public static dynamic tempinf = "";

    public static dynamic setinf = 0;
    public static dynamic lifeA = 0;
    public static dynamic lifeB = 0;
    public static dynamic lifeC = 0;
    public static dynamic lifeD = 0;
    public static dynamic lifeE = 0;

    public static dynamic password = "";
    public static dynamic disease1 = "";

    public static dynamic playC = 0;
    public static dynamic playD = 0;
    public static dynamic playE = 0;

    public static dynamic most = "";
    public static dynamic thirtyFivevp = "";
    public static dynamic gen2exp = "";

    public static dynamic hospsign = "";
    public static dynamic hospA = 0;
    public static dynamic hospcount = 0;
    public static dynamic hospB = 0;
    public static dynamic hospC = 0;
    public static dynamic hospD = 0;
    public static dynamic hospE = 0;

    public static dynamic hospentry = "";
    public static dynamic trig = 0;

    public static dynamic disA = "";
    public static dynamic costA = "";
    public static dynamic typeA = "";
    public static dynamic cost2A = "";
    public static dynamic creationA = "";

    public static dynamic disB = "";
    public static dynamic tempcomp = "";
    public static dynamic tempcheck = "";

    public static dynamic typeB = "";
    public static dynamic typeC = "";
    public static dynamic typeD = "";
    public static dynamic typeE = "";

    public static dynamic costB = "";
    public static dynamic cost2B = "";
    public static dynamic creationB = "";

    public static dynamic disC = "";
    public static dynamic costC = "";
    public static dynamic cost2C = "";
    public static dynamic creationC = "";

    public static dynamic disD = "";
    public static dynamic costD = "";
    public static dynamic cost2D = "";
    public static dynamic creationD = "";

    public static dynamic disE = "";
    public static dynamic costE = "";

    public static dynamic huntvp = 0;

    public static dynamic confront = "";
    public static dynamic taxes = "";
    public static dynamic vialuse = "";
    public static dynamic conpat = "";

    public static dynamic randomplayer = "";
    public static dynamic randomname = "";

    public static dynamic gen1creep = "";
    public static dynamic gen1sane = "";
    public static dynamic vacation = "";
    public static dynamic sym = "";
    public static dynamic eviltax = "";

    public static dynamic h1a = "";
    public static dynamic h1b = "";
    public static dynamic h2a = "";
    public static dynamic h2b = "";

    public static dynamic huntname = "";
    public static dynamic winner = "";
    public static dynamic tempdisease = "";

    public static dynamic huntnum = "";
    public static dynamic aide = "";

    public static dynamic amtoken = "";
    public static dynamic frenzy = "";
    public static dynamic disease2 = "";

    public static dynamic midquote = "";

    public static dynamic cost2E = "";
    public static dynamic creationE = "";

    public static List<dynamic> mon = new();
    public static dynamic monster1 = "";
    public static dynamic monster2 = "";
    public static dynamic monster3 = "";
    public static dynamic monster4 = "";
    public static dynamic monster5 = "";

    public static List<dynamic> rew = new();
    public static dynamic reward1 = "";
    public static dynamic reward2 = "";
    public static dynamic reward3 = "";
    public static dynamic reward4 = "";
    public static dynamic reward5 = "";
    public static dynamic reward6 = "";
    public static dynamic reward7 = "";
    public static dynamic reward8 = "";

    public static List<dynamic> hunttemp = new();

    public static dynamic hunt1a = "";
    public static dynamic hunt1b = "";
    public static dynamic hunt2a = "";
    public static dynamic hunt2b = "";
    public static dynamic hunt3a = "";
    public static dynamic hunt1c = "";
    public static dynamic h2c = "";

    public static dynamic huntbeast = "";

    public static List<Action> effect = new();
    public static Action tempeffect;

    public static dynamic randrew = 0;
    public static dynamic instemp = 0;
    public static dynamic overrun = "";
    public static dynamic huntresult = "";

    public static dynamic huntreward = 0;
    public static dynamic huntreward1 = 0;
    public static dynamic huntreward2 = 0;

    public static Action direction;

    public static dynamic scoreA = "";
    public static dynamic scoreB = "";
    public static dynamic scoreC = "";
    public static dynamic scoreD = "";
    public static dynamic scoreE = "";

    public static dynamic tcodgen1 = 0;
    public static dynamic gen3pg = 0;
    public static dynamic wcount = 0;
    public static dynamic hcount = 0;
    public static dynamic twopage = 0;

    public static dynamic letterSetRandomize = 0;
    public static dynamic Devastation1 = 0;
    public static dynamic University1 = 0;
    public static dynamic Hospital1 = 0;
    public static dynamic Prosperity1 = 0;

    public static dynamic tmmasterwork = "";
    public static dynamic feverheartnextPsg = "";
    public static dynamic S5HospA1nextPsg = "";
    public static dynamic HospitalNegativenextPsg = "";
    public static dynamic TaxesEventNoConfrontationnextPsg = "";
    public static dynamic Diseases2nextPsg = "";
    public static dynamic NoHospitalConsnextPsg = "";
    public static dynamic SymposiumMiddlenextPsg = "";

    public static dynamic HuntNorthnextPsg = "";
    public static dynamic HuntWestnextPsg = "";
    public static dynamic HuntSouthnextPsg = "";
    public static dynamic HuntEastnextPsg = "";

    public static dynamic Gen1CreepyNonextPsg = 0;
    public static dynamic Gen1SanityNonextPsg = 0;
    public static dynamic Gen1Insanity_YesnextPsg = "";
    public static dynamic Gen1Insanity_Yes2nextPsg = "";

    public static T GetRandom<T>(T[] array)
    {
        Random random = new Random();
        return array[random.Next(0, array.Length)];
    }
    
    public static void PrintEndOfTheRoundText(string tag, Action nextState)
    {
        Console.Clear();
        
        string yearsText = tag switch
        {
            "Fever1" or "Mania" or "TakeSides" or "Hospital1" or "Devastation1" or "Foreign" or "Creature" or "TimeTravel" or "Martial1" or "NoUni1" or "Prosperity1" or "GloomyGothic1" or "University1" or "Isolation" or "Tension" or "Privatized" or "Liberal" or "Paradox1" or "MonarchReign1" or "Peace1" or "Warning1" => "Early Years",
            "Fever2" or "Mania2" or "TakeSides2" or "Devastation2" or "Hospital2" or "Foreign2" or "Creature2" or "TimeTravel2" or "Martial2" or "NoUni2" or "University2" or "Prosperity2" or "GloomyGothic2" or "Tension2" or "Isolation2" or "Privatized2" or "Liberal2" or "Paradox2" or "MonarchReign2" or "Peace2" or "Warning2" or "Warning2time" => "Middle Years",
            "Fever3" or "Mania3" or "TakeSides3" or "Devastation3" or "Hospital3" or "Creature3" or "Foreign3" or "TimeTravel3" or "Martial3" or "NoUni3" or "University3" or "Prosperity3" or "GloomyGothic3" or "Isolation3" or "Privatized3" or "Liberal3" or "Tension3" or "Paradox3" or "MonarchReign3" or "Peace3" or "Warning3" or "Warning3time" or "Paradox3b"  => "Late Years",
            _ => "error"
        };

        string genText = tag switch
        {
            "Fever1" or "Mania" or "TakeSides" or "Fever2" or "Mania2" or "TakeSides2" or "Fever3" or "Mania3" or "TakeSides3" => "First Generation",
            "Hospital1" or "Devastation1" or "Foreign" or "Creature" or "TimeTravel" or "Martial1" or "Devastation2" or "Hospital2" or "Foreign2" or "Creature2" or "TimeTravel2" or "Martial2" or "Devastation3" or "Hospital3" or "Creature3" or "Foreign3" or "TimeTravel3" or "Martial3" => "Second Generation",
            "NoUni1" or "Prosperity1" or "GloomyGothic1" or "University1" or "Isolation" or "Tension" or "Privatized" or "Liberal" or "Paradox1" or "MonarchReign1" or "Peace1" or "Warning1" or "NoUni2" or "University2" or "Prosperity2" or "GloomyGothic2" or "Tension2" or "Isolation2" or "Privatized2" or "Liberal2" or "Paradox2" or "MonarchReign2" or "Peace2" or "Warning2" or "Warning2time" or "NoUni3" or "University3" or "Prosperity3" or "GloomyGothic3" or "Isolation3" or "Privatized3" or "Liberal3" or "Tension3" or "Paradox3" or "MonarchReign3" or "Peace3" or "Warning3" or "Warning3time" or "Paradox3b" => "Third Generation",
            _ => "error"
        };
        
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine(" End of the Round");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"The {yearsText} of the {genText} has ended.");
        if (yearsText is "Early Years" or "Middle Years")
        {
            Console.WriteLine("Perform all End of Round actions.");
            Console.WriteLine($"Then, perform all Start of Round actions for the {(yearsText == "Early Years" ? "Middle Years" : "Late Years")} before continuing.");
        }
        else
        {
            Console.WriteLine("Perform all End of Round actions before continuing.");
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        nextState();
    }
    
    public static IList<T> Shuffle<T>(this IList<T> list)
    {
        RandomNumberGenerator rng = RandomNumberGenerator.Create();
        int                   n   = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[4];
            rng.GetBytes(box);
            int randomIndex                  = BitConverter.ToInt32(box, 0);
            if (randomIndex < 0) randomIndex *= -1;
            randomIndex %= n;
            n--;
            (list[randomIndex], list[n]) = (list[n], list[randomIndex]);
        }

        return list;
    }

    public static int Max(int[] values)
    {
        int max = values[0];
        for (int x = 1; x < values.Length; ++x) max =  Math.Max(max, values[x]);
        return max;
    }
}

/*
0 
Fever1" or "Mania" or "TakeSides 
The Early Years of the First Generation has ended. Perform all End of Round actions." or "Génération I, Début du cycle : fin. Effectuez toutes les actions de fin de manche. 
Then, perform all Start of Round actions for the Middle Years before continuing." or "Effectuez ensuite toutes les actions de début de manche pour Milieu de cycle avant de continuer. 
1 

1 
Fever2" or "Mania2" or "TakeSides2 
The Middle Years of the First Generation has ended. Perform all End of Round actions." or "Génération I, Milieu de cycle : fin. Effectuez toutes les actions de fin de manche. 
Then, perform all Start of Round actions for the Late Years before continuing." or "Effectuez ensuite toutes les actions de début de manche pour Fin de cycle avant de continuer. 
2 

2 
Fever3" or "Mania3" or "TakeSides3 
The Late Years of the First Generation has ended." or "Génération I, Fin de cycle : fin. 
Perform any End of Round actions before continuing." or "Effectuez toutes les actions de Fin de Manche avant de continuer. 
0 

3 
Hospital1" or "Devastation1" or "Foreign" or "Creature" or "TimeTravel" or "Martial1 
The Early Years of the Second Generation has ended. Perform all End of Round actions." or "Génération II, Début du cycle : fin. Effectuez toutes les actions de fin de manche. 
Then, perform all Start of Round actions for the Middle Years before continuing." or "Effectuez ensuite toutes les actions de début de manche pour Milieu de cycle avant de continuer. 
4 

4 
Devastation2" or "Hospital2" or "Foreign2" or "Creature2" or "TimeTravel2" or "Martial2 
The Middle Years of the Second Generation has ended. Perform all End of Round actions." or "Génération II, Milieu de cycle : fin. Effectuez toutes les actions de fin de manche. 
Then, perform all Start of Round actions for the Late Years before continuing." or "Effectuez ensuite toutes les actions de début de manche pour Fin de cycle avant de continuer. 
5 

5 
Devastation3" or "Hospital3" or "Creature3" or "Foreign3" or "TimeTravel3" or "Martial3 
The Late Years of the Second Generation has ended." or "Génération II, Fin de cycle : fin. 
Perform any End of Round actions before continuing." or "Effectuez toutes les actions de Fin de Manche avant de continuer. 
0 

6 
NoUni1" or "Prosperity1" or "GloomyGothic1" or "University1" or "Isolation" or "Tension" or "Privatized" or "Liberal" or "Paradox1" or "MonarchReign1" or "Peace1" or "Warning1 
The Early Years of the Third Generation has ended. Perform all End of Round actions." or "Génération III, Début du cycle : fin. Effectuez toutes les actions de fin de manche. 
Then, perform all Start of Round actions for the Middle Years before continuing." or "Effectuez ensuite toutes les actions de début de manche pour Milieu de cycle avant de continuer. 
7 

7 
NoUni2" or "University2" or "Prosperity2" or "GloomyGothic2" or "Tension2" or "Isolation2" or "Privatized2" or "Liberal2" or "Paradox2" or "MonarchReign2" or "Peace2" or "Warning2" or "Warning2time 
The Middle Years of the Third Generation has ended. Perform all End of Round actions." or "Génération III, Milieu de cycle : fin. Effectuez toutes les actions de fin de manche. 
Then, perform all Start of Round actions for the Late Years before continuing." or "Effectuez ensuite toutes les actions de début de manche pour Fin de cycle avant de continuer. 
8 

8 
NoUni3" or "University3" or "Prosperity3" or "GloomyGothic3" or "Isolation3" or "Privatized3" or "Liberal3" or "Tension3" or "Paradox3" or "MonarchReign3" or "Peace3" or "Warning3" or "Warning3time" or "Paradox3b 
The Late Years of the Third Generation has ended." or "Génération III, Fin de cycle : fin. 
Perform any End of Round actions before continuing." or "Effectuez toutes les actions de Fin de Manche avant de continuer. 
0 */
