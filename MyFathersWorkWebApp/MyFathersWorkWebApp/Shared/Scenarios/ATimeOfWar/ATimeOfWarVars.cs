namespace MyFathersWorkWebApp;

public class ATimeOfWarVars
{
    public TimeOfWarHubId HubId { get; set; } = TimeOfWarHubId.None;

    // Core Scenario State
    public int    Tracker     { get; set; }
    public int    Rumblings   { get; set; }
    public int    War         { get; set; } = 1;
    public string WarWinner   { get; set; } = "Separatists";
    public string WarLoser    { get; set; } = "Unified Monarchists";
    public string Crest       { get; set; } = "Sickle";
    public string Figure      { get; set; } = "Shield";
    public string Quarter     { get; set; } = "no";
    public int    Crazy       { get; set; }
    public string BarracksAct { get; set; } = "mean";
    public string TmMasterwork { get; set; } = "no";
    public string Ending      { get; set; } = "ATOW-End1";
    public int    Round       { get; set; } = 1;

    // Generation I (TakeSides) & Rumors
    public List<int> RumorsRemaining { get; set; } = new();
    public int       Opt1            { get; set; }
    public int       Opt2            { get; set; }
    public bool      Rumor1Visited   { get; set; }
    public bool      Rumor2Visited   { get; set; }
    public bool      Rumor3Visited   { get; set; }
    public bool      Rumor6Visited   { get; set; }
    public int       NoMore          { get; set; }
    public int       GunsBonus       { get; set; }
    public string    Barracks        { get; set; } = "no";
    public string    Mon             { get; set; } = "0";
    public string    Sep             { get; set; } = "0";
    public int       TownHallVisits  { get; set; }
    public string    TakeReact       { get; set; } = string.Empty;
    public List<int> GunsChoice      { get; set; } = new();
    public int       Gun1            { get; set; }
    public int       Gun2            { get; set; }

    // Generation II: Time Travel (`TimeTravel`)
    public int            Late          { get; set; }
    public int            Pg13          { get; set; }
    public int            TtSet         { get; set; }
    public int            Pg14          { get; set; }
    public string         TmRepair      { get; set; } = "no";
    public int            Dox           { get; set; }
    public string         TmNumber      { get; set; } = "zero pieces";
    public int            Military      { get; set; }
    public int            ParaSecret    { get; set; }
    public bool[]         PlayerHasTm   { get; set; } = new bool[5];
    public int[]          BlameCounts   { get; set; } = new int[5];
    public bool[]         SilentVoted   { get; set; } = new bool[5];
    public string         Blame         { get; set; } = "none";
    public int            Counter       { get; set; }
    public int            BarrackPen    { get; set; }
    public List<string>   GenericRewards { get; set; } = new();
    public string         Gen1Reward    { get; set; } = string.Empty;
    public string         Gen2Reward    { get; set; } = string.Empty;
    public string         Ch1Reward     { get; set; } = string.Empty;
    public string         Ch2Reward     { get; set; } = string.Empty;

    // Generation II: Martial Law (`Martial`)
    public int          Martial        { get; set; }
    public int          MartWeapons    { get; set; }
    public int          WeaponLimit    { get; set; }
    public string       WeaponRew      { get; set; } = "0";
    public string       HeatPlayer     { get; set; } = string.Empty;
    public int          SepInc1        { get; set; }
    public int          SepInc2        { get; set; }
    public int          SepInc3        { get; set; }
    public int          MonInc3        { get; set; }
    public int          SepEvent       { get; set; }
    public int          WarDestroy     { get; set; }
    public int          SabPage        { get; set; } = 5;
    public string       Barn           { get; set; } = "no";
    public int          Accolade       { get; set; }
    public int          Iou            { get; set; }
    public int          WarDetermine   { get; set; }
    public string       Sabotagee1     { get; set; } = "none";
    public string       PlayerSabotage1 { get; set; } = "none";
    public List<string> SaboOptions    { get; set; } = new();
    public string       Sab1           { get; set; } = string.Empty;
    public string       Sab2           { get; set; } = string.Empty;
    public int          WarPage2       { get; set; }
    public string       Bribe          { get; set; } = "no";
    public string       TeaOpt         { get; set; } = "Barracks";
    public string       Bldg1          { get; set; } = "0";
    public string       Bldg2          { get; set; } = "0";
    public string       Bldg3          { get; set; } = "0";
    public string       Destroy        { get; set; } = string.Empty;

    // Duels (`Martial`)
    public string DuelType   { get; set; } = "pistols";
    public int    DuelSci    { get; set; }
    public int    DuelShot   { get; set; }
    public string DuelWinner { get; set; } = "tied";
    public string DuelLoser  { get; set; } = "tied";
    public int    DuelResult { get; set; }

    // Generation III: Warning & Paradox
    public int    PgGen3       { get; set; }
    public int    Gen3Pg       { get; set; }
    public string Stasis       { get; set; } = "no";
    public int    Per          { get; set; }
    public int    Search       { get; set; }
    public int    Total        { get; set; }
    public int    Buy          { get; set; }
    public string Master       { get; set; } = "0";
    public int    Release      { get; set; }
    public int    Giants       { get; set; }
    public int    TimeMistake  { get; set; }
    public string Cont         { get; set; } = string.Empty;
    public List<string> TwCode { get; set; } = new();
    public string EndChange    { get; set; } = "no";

    // Generation III: Monarch's Reign (`MonarchReign`)
    public int          DecBon          { get; set; }
    public int          CommTrigger     { get; set; }
    public int          OneStCrown      { get; set; }
    public int          CrownCount      { get; set; }
    public int          RoyalAdvisor    { get; set; }
    public int          AdvisorCount    { get; set; }
    public string       ReignTemp       { get; set; } = string.Empty;
    public string       Reigning        { get; set; } = string.Empty;
    public string       ReignSep        { get; set; } = "0";
    public int          PlaReign        { get; set; }
    public int          Rc              { get; set; }
    public int[]        PlayerReignGood { get; set; } = new int[5];
    public int[]        PlayerReignEvil { get; set; } = new int[5];
    public string       Benevolent      { get; set; } = "good";
    public string       MostBen         { get; set; } = string.Empty;
    public string       SignInComm      { get; set; } = string.Empty;
    public string       AtowStatue      { get; set; } = string.Empty;
    public string       Title           { get; set; } = string.Empty;
    public string       CrownL          { get; set; } = string.Empty;
    public string       CrownR          { get; set; } = string.Empty;
    public bool[]       DecreeVisited   { get; set; } = new bool[17];
    public List<string> AdvisePool      { get; set; } = new();
    public string[]     PlayerDisplayNames { get; set; } = new string[5];

    // Generation III: Peace (`Peace`)
    public int    Pea1       { get; set; }
    public int    Pea2       { get; set; }
    public int    Pea3       { get; set; }
    public int    Peac       { get; set; }
    public int    PeaceCount { get; set; }
    public int    Defense    { get; set; }
    public string Famine     { get; set; } = "none";
    public string NewMeat    { get; set; } = string.Empty;
    public string PageTurn   { get; set; } = "no";

    // Final Scoring & Tie-Breakers
    public int          RandomPlayer      { get; set; }
    public int[]        PlayerScores      { get; set; } = new int[5];
    public int          ScoreEntryIndex   { get; set; }
    public List<int> TiedPlayers     { get; set; } = new();
    public int[]        TieBreakerMoney   { get; set; } = new int[5];
    public int          TieBreakerIndex   { get; set; }
    public string       WinnerName        { get; set; } = string.Empty;

    public string GetPlayerName(GlobalData globalData, int index)
    {
        return GetDisplayPlayerName(globalData, index);
    }

    public string GetDisplayPlayerName(GlobalData globalData, int index)
    {
        if (index >= 0 && index < PlayerDisplayNames.Length && !string.IsNullOrEmpty(PlayerDisplayNames[index]))
        {
            return PlayerDisplayNames[index];
        }
        return globalData.GetPlayerNameByIndex(index);
    }

    public void Reset(GlobalData globalData)
    {
        HubId        = TimeOfWarHubId.None;
        Tracker      = 0;
        Rumblings    = 0;
        War          = Random.Shared.Next(2) == 0 ? 1 : 2;
        WarWinner    = Random.Shared.Next(2) == 0 ? "Separatists" : "Unified Monarchists";
        if (WarWinner == "Separatists")
        {
            Crest    = "Sickle";
            WarLoser = "Unified Monarchists";
            Figure   = "Shield";
            Quarter  = Random.Shared.Next(2) == 0 ? "yes" : "no";
        }
        else
        {
            Crest    = "Shield";
            WarLoser = "Separatists";
            Figure   = "Sickle";
            Quarter  = "no";
        }

        Crazy          = 0;
        BarracksAct    = Random.Shared.Next(2) == 0 ? "mean" : "nice";
        TmMasterwork   = "no";
        Ending         = "ATOW-End1";
        Round          = 1;

        RumorsRemaining = new List<int> { 1, 2, 3, 4, 5, 6 };
        Opt1           = 1;
        Opt2           = 2;
        Rumor1Visited  = false;
        Rumor2Visited  = false;
        Rumor3Visited  = false;
        Rumor6Visited  = false;
        NoMore         = 0;
        GunsBonus      = 0;
        Barracks       = "no";
        Mon            = "0";
        Sep            = "0";
        TownHallVisits = 0;
        TakeReact      = string.Empty;
        GunsChoice     = new List<int> { 1, 2, 3 };
        Gun1           = 1;
        Gun2           = 2;

        Late           = 0;
        Pg13           = 0;
        TtSet          = 0;
        Pg14           = 0;
        TmRepair       = "no";
        Dox            = 1;
        TmNumber       = "zero pieces";
        Military       = 1;
        ParaSecret     = 0;
        PlayerHasTm    = new bool[5];
        BlameCounts    = new int[5];
        SilentVoted    = new bool[5];
        Blame          = "none";
        Counter        = 0;
        BarrackPen     = 0;
        GenericRewards = new List<string>
        {
            "Gain $1 and Gain 1 Ingredient.",
            "Gain $1 and Gain 1 Knowledge of your choice.",
            "Gain $3",
            "Gain 1 Knowledge of your choice.",
            "Gain 2 Compulsion cards."
        };
        Gen1Reward     = GenericRewards[0];
        Gen2Reward     = GenericRewards[1];
        Ch1Reward      = GenericRewards[0];
        Ch2Reward      = GenericRewards[1];

        Martial        = 0;
        MartWeapons    = 0;
        WeaponLimit    = 0;
        WeaponRew      = "0";
        HeatPlayer     = string.Empty;
        SepInc1        = 0;
        SepInc2        = 0;
        SepInc3        = 0;
        MonInc3        = 0;
        SepEvent       = 0;
        WarDestroy     = 0;
        SabPage        = 5;
        Barn           = "no";
        Accolade       = 0;
        Iou            = 0;
        WarDetermine   = 0;
        Sabotagee1     = "none";
        PlayerSabotage1 = "none";
        SaboOptions    = new List<string>();
        Sab1           = string.Empty;
        Sab2           = string.Empty;
        WarPage2       = 0;
        Bribe          = "no";
        TeaOpt         = "Barracks";
        Bldg1          = "0";
        Bldg2          = "0";
        Bldg3          = "0";
        Destroy        = string.Empty;

        DuelType       = "pistols";
        DuelSci        = 0;
        DuelShot       = 1;
        DuelWinner     = "tied";
        DuelLoser      = "tied";
        DuelResult     = 1;

        PgGen3         = 0;
        Gen3Pg         = 0;
        Stasis         = "no";
        Per            = 1;
        Search         = 0;
        Total          = 0;
        Buy            = 0;
        Master         = "0";
        Release        = 0;
        Giants         = 0;
        TimeMistake    = 0;
        Cont           = string.Empty;
        TwCode         = new List<string>();
        EndChange      = "no";

        DecBon         = 0;
        CommTrigger    = 0;
        OneStCrown     = 0;
        CrownCount     = 0;
        RoyalAdvisor   = 0;
        AdvisorCount   = 0;
        ReignTemp      = string.Empty;
        Reigning       = string.Empty;
        ReignSep       = "0";
        PlaReign       = 0;
        Rc             = 0;
        PlayerReignGood = new int[5];
        PlayerReignEvil = new int[5];
        Benevolent     = "good";
        MostBen        = string.Empty;
        SignInComm     = string.Empty;
        AtowStatue     = string.Empty;
        Title          = string.Empty;
        CrownL         = string.Empty;
        CrownR         = string.Empty;
        DecreeVisited  = new bool[17];
        AdvisePool     = new List<string>();
        PlayerDisplayNames = new string[5];
        for (int i = 0; i < 4; i++)
        {
            PlayerDisplayNames[i] = globalData.GetPlayerNameByIndex(i);
        }

        Pea1           = 0;
        Pea2           = 0;
        Pea3           = 0;
        Peac           = 1;
        PeaceCount     = 0;
        Defense        = 0;
        Famine         = "none";
        NewMeat        = string.Empty;
        PageTurn       = "no";

        PlayerScores    = new int[5];
        ScoreEntryIndex = 0;
        TiedPlayers     = new List<int>();
        TieBreakerMoney = new int[5];
        TieBreakerIndex = 0;
        WinnerName      = string.Empty;
    }
}
