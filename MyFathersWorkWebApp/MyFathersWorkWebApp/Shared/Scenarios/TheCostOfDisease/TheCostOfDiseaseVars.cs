using System.Security.Cryptography;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace MyFathersWorkWebApp;

public class TheCostOfDiseaseVars
{
    // globalData.TheCostOfDiseaseVars.RandomElement([
    // ], x) Current: 58 // TODO Return to this value after finishing scenario code
    public int[] RandomArray { get; set; } = new int[300 + 1];

    public CostOfDiseaseHubId HubId   { get; set; }
    public Affiliation        Wolves  { get; set; }
    public Affiliation        Hunters { get; set; }
    public int                Tracker { get; set; } // Rename to -> SuspicionMarkerPos

    public bool         Creepy4   { get; set; }
    public string       Gen1Creep { get; set; } = string.Empty;
    public ExtendedBool Seedy     { get; set; } = ExtendedBool.None;

    public bool         Sane3    { get; set; }
    public string       Gen1Sane { get; set; } = string.Empty;
    public ExtendedBool Vacation { get; set; } = ExtendedBool.None;

    public string        Mayor    { get; set; } = string.Empty;
    public BankOrLibrary Building { get; set; } = BankOrLibrary.None;

    public int     CharityTotal { get; set; }
    public string  Charity      { get; set; } = string.Empty;
    public Science Sci3         { get; set; } = Science.None;

    public bool Trigger35         { get; set; }
    public bool ThirtyFiveVpCreep { get; set; }

    public ExtendedBool Cured      { get; set; } // 0 - None, 1 - True, 2 - Complete
    public string       FeverCure  { get; set; } = string.Empty;
    public int          FeverVp    { get; set; }
    public int          FeverMoney { get; set; }
    public ExtendedBool Pub        { get; set; }
    public string       PanaCure   { get; set; } = string.Empty;
    public PanaceaVal   Pana       { get; set; } = PanaceaVal.None;

    public bool         SciAdv  { get; set; }
    public string       Gen2Exp { get; set; } = string.Empty;
    public ExtendedBool Uni     { get; set; }
    public int          Symp    { get; set; }

    public int                      HospCount { get; set; }
    public Dictionary<string, bool> Hosp      { get; set; } = new();

    public bool                     SetInf    { get; set; } // To setup Infinity
    public int                      LifeCount { get; set; } // Originally Life
    public Dictionary<string, bool> Life      { get; set; } = new();
    public bool                     Immort    { get; set; }

    public string[]                    Letter               { get; set; } = new string[6];
    public int                         WCount               { get; set; }
    public int                         HCount               { get; set; }
    public Dictionary<string, Faction> Ally                 { get; set; } = new();
    public BuildingS1A[]               Gen2Buildings        { get; set; } = new BuildingS1A[3]; // originally ba, bb, bc
    public Dictionary<string, int>     BuildingPlay         { get; set; } = new();              // originally playA, playB, etc.
    public Dictionary<string, bool[]>  HelpedExposeBuilding { get; set; } = new();              // originally pAA, pAB, pAC, etc.
    public int[]                       BuildingsExposeValue { get; set; } = new int[3];         // originally exposeA, exposeB, exposeC
    public int                         GoodCount            { get; set; }
    public Society                     Society              { get; set; } = Society.None;

    // Shared / Deterioration / Endings / Scoring
    public bool[]                   DetVisited   { get; set; } = new bool[4];
    public bool                     Killed       { get; set; }
    public bool                     Lycan        { get; set; }
    public bool                     Ultimate     { get; set; }
    public bool                     Peeps        { get; set; }
    public string                   Ending       { get; set; } = string.Empty;
    public Dictionary<string, int>  Scores       { get; set; } = new();
    public List<string>             TiedPlayers  { get; set; } = new();
    public Dictionary<string, bool> TieSelection { get; set; } = new();
    public string                   Winner       { get; set; } = string.Empty;

    // Gen 3 - University
    public int    Mental     { get; set; }
    public string SanePlayer { get; set; } = string.Empty;

    // Gen 3 - GloomyGothic
    public int    HuntVp         { get; set; }
    public bool   Confront       { get; set; }
    public bool   Taxes          { get; set; } = true;
    public bool   VialCleansed   { get; set; }
    public int    VoteYea        { get; set; }
    public int    VoteNay        { get; set; }
    public int    DonatedVpTotal { get; set; }
    public string DonatedLevel   { get; set; } = string.Empty;

    // Gen 3 - Prosperity
    public bool     ReturnToEvil       { get; set; }
    public bool     FarmersMarketCreepy { get; set; }
    public int      HuntCount          { get; set; }
    public int      HuntRound          { get; set; } = 1;
    public string[] HuntRound1Players  { get; set; } = new string[2];
    public string[] HuntRound2Players  { get; set; } = new string[2];
    public string   HuntName           { get; set; } = string.Empty;
    public string   HuntDirection      { get; set; } = string.Empty;
    public string[] HuntMonsters       { get; set; } = new string[4];
    public string[] HuntRewards        { get; set; } = new string[2];
    public int      AngryMobIndex      { get; set; }

    // Gen 3 - NoUniversity
    public Dictionary<string, string> CustomMwDiscipline  { get; set; } = new();
    public Dictionary<string, string> CustomMwType        { get; set; } = new();
    public Dictionary<string, string> CustomMwName        { get; set; } = new();
    public Dictionary<string, int>    CustomMwCode        { get; set; } = new();
    public Dictionary<string, bool>   CustomMwCompleted   { get; set; } = new();
    public int                        CustomMwCompleteCount { get; set; }
    public List<int>                  BarVenturesRemaining { get; set; } = new();
    public string                     CurrentBarPlayer    { get; set; } = string.Empty;

    public const string WOLVES_EVIL_TOWN_NAME  = "Rage";
    public const string HUNTERS_EVIL_TOWN_NAME = "Kraven";

    private GlobalData _GlobalData = null!;

    public bool RandomBool(int index)
    {
        return RandomArray[index] % 2 == 1;
    }

    public T RandomElement<T>(List<T> list, int index)
    {
        return list[RandomArray[index] % list.Count];
    }

    public T RandomElement<T>(List<T> list, string playerName, int startIndex)
    {
        int index                                        = startIndex;
        if (playerName == _GlobalData.PlayerBName) index += 1;
        if (playerName == _GlobalData.PlayerCName) index += 2;
        if (playerName == _GlobalData.PlayerDName) index += 3;

        return list[RandomArray[index] % list.Count];
    }

    public void Reset(GlobalData globalData)
    {
        _GlobalData = globalData;

        Wolves               = Affiliation.Good;
        Hunters              = Affiliation.Evil;
        Tracker              = 0;
        Creepy4              = false;
        Seedy                = ExtendedBool.None;
        Sane3                = false;
        Gen1Creep            = string.Empty;
        Gen1Sane             = string.Empty;
        Vacation             = ExtendedBool.None;
        Mayor                = string.Empty;
        Building             = BankOrLibrary.None;
        CharityTotal         = 0;
        Charity              = string.Empty;
        Sci3                 = Science.None;
        ThirtyFiveVpCreep    = false;
        FeverVp              = 0;
        FeverMoney           = 0;
        Cured                = ExtendedBool.None;
        SciAdv               = false;
        Trigger35            = false;
        Gen2Exp              = string.Empty;
        FeverCure            = string.Empty;
        Uni                  = ExtendedBool.None;
        Pub                  = ExtendedBool.None;
        PanaCure             = string.Empty;
        Pana                 = PanaceaVal.None;
        HospCount            = 0;
        SetInf               = false;
        LifeCount            = 0;
        Immort               = false;
        Symp                 = 0;
        WCount               = 0;
        HCount               = 0;
        Gen2Buildings        = [BuildingS1A.None, BuildingS1A.None, BuildingS1A.None];
        BuildingsExposeValue = [0, 0, 0];
        GoodCount            = 0;
        Society              = Society.None;

        DetVisited           = [false, false, false, false];
        Killed               = false;
        Lycan                = false;
        Ultimate             = false;
        Peeps                = false;
        Ending               = string.Empty;
        TiedPlayers          = new List<string>();
        Winner               = string.Empty;

        Mental               = 0;
        SanePlayer           = string.Empty;

        HuntVp               = 0;
        Confront             = false;
        Taxes                = true;
        VialCleansed         = false;
        VoteYea              = 0;
        VoteNay              = 0;
        DonatedVpTotal       = 0;
        DonatedLevel         = string.Empty;

        ReturnToEvil         = false;
        FarmersMarketCreepy  = false;
        HuntCount            = 0;
        HuntRound            = 1;
        HuntRound1Players    = [string.Empty, string.Empty];
        HuntRound2Players    = [string.Empty, string.Empty];
        HuntName             = string.Empty;
        HuntDirection        = string.Empty;
        HuntMonsters         = [string.Empty, string.Empty, string.Empty, string.Empty];
        HuntRewards          = [string.Empty, string.Empty];
        AngryMobIndex        = 0;

        CustomMwCompleteCount = 0;
        BarVenturesRemaining  = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        CurrentBarPlayer      = string.Empty;

        string[] players = [globalData.PlayerAName, globalData.PlayerBName, globalData.PlayerCName, globalData.PlayerDName];

        foreach (string player in players)
        {
            Hosp[player]                 = false;
            Life[player]                 = false;
            Ally[player]                 = Faction.None;
            BuildingPlay[player]         = 0;
            HelpedExposeBuilding[player] = [false, false, false];
            Scores[player]               = 0;
            TieSelection[player]         = false;
            CustomMwDiscipline[player]   = string.Empty;
            CustomMwType[player]         = string.Empty;
            CustomMwName[player]         = string.Empty;
            CustomMwCode[player]         = 0;
            CustomMwCompleted[player]    = false;
        }

        for (int x = 0; x < 6; ++x) Letter[x] = string.Empty;

        RandomNumberGenerator rng = RandomNumberGenerator.Create();

        for (int x = 0; x < RandomArray.Length; ++x)
        {
            byte[] box = new byte[4];
            rng.GetBytes(box);
            RandomArray[x] = BitConverter.ToInt32(box, 0);
            if (RandomArray[x] < 0) RandomArray[x] *= -1;
        }
    }
}