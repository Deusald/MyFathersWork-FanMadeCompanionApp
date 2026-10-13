namespace MyFathersWorkWebApp;

public class FearOfTheUnknownVars
{
    public FearOfUnknownHubId HubId { get; set; } = FearOfUnknownHubId.None;

    // Core Scenario State
    public int    Tracker      { get; set; }
    public string RandomName   { get; set; } = string.Empty;
    public string RandomPlayer { get; set; } = string.Empty;
    public string Newspaper    { get; set; } = string.Empty;
    public string Ending       { get; set; } = "FOTU-End1";
    public int    Round        { get; set; } = 1;
    public string TownName     { get; set; } = string.Empty;

    // Generation I: Mania, Family Plots, Fate, Murder & Witch Trial
    public int          Whpg        { get; set; }
    public int          Fp10Vp      { get; set; }
    public int          FpResearch2 { get; set; }
    public int          FpSanity3   { get; set; }
    public int          FpCreepy3   { get; set; }
    public int          OneCount    { get; set; }
    public int          FpFate      { get; set; }
    public string       Fate1       { get; set; } = string.Empty;
    public string       Fate2       { get; set; } = string.Empty;
    public string       Fate3       { get; set; } = string.Empty;
    public string       Fate4       { get; set; } = string.Empty;
    public string       Fate5       { get; set; } = string.Empty;
    public string       Fate6       { get; set; } = string.Empty;
    public string       Kill        { get; set; } = "blacksmith";
    public string       Mobbed      { get; set; } = "no";
    public int          Mog         { get; set; }
    public string       Witch1      { get; set; } = string.Empty;
    public string       Witch2      { get; set; } = string.Empty;
    public string       Witch       { get; set; } = "dead";
    public string       Gen2Fate    { get; set; } = "witch";
    public string       Gen2End     { get; set; } = "asylum";
    public string       TempPlot    { get; set; } = string.Empty;
    public string       TempName    { get; set; } = string.Empty;
    public string       RevPlot     { get; set; } = "fortune";
    public int          RevResolve  { get; set; }

    // Per-Player Arrays & Convenience Properties (0..4 for Players A..E)
    public int[]    Pl          { get; set; } = new int[5];
    public int[]    Confirm     { get; set; } = new int[5];
    public string[] Plot        { get; set; } = { "no", "no", "no", "no", "no" };
    public string[] Wit         { get; set; } = { "", "", "", "", "" };
    public string[] Wit2        { get; set; } = { "", "", "", "", "" };
    public int[]    Smug        { get; set; } = new int[5];
    public string[] IdArr       { get; set; } = { "", "", "", "", "" };
    public int[]    ContArr     { get; set; } = new int[5];
    public int[]    VArr        { get; set; } = new int[5];
    public int[]    Token2Arr   { get; set; } = new int[5];
    public int[]    Agi         { get; set; } = new int[5];
    public int[]    Str         { get; set; } = new int[5];
    public int[]    Hit         { get; set; } = new int[5];
    public string[] Warrior     { get; set; } = { "", "", "", "", "" };
    public string[] Creep       { get; set; } = { "", "", "", "", "" };

    public int PlA { get => Pl[0]; set => Pl[0] = value; }
    public int PlB { get => Pl[1]; set => Pl[1] = value; }
    public int PlC { get => Pl[2]; set => Pl[2] = value; }
    public int PlD { get => Pl[3]; set => Pl[3] = value; }
    public int PlE { get => Pl[4]; set => Pl[4] = value; }

    public int AConfirm { get => Confirm[0]; set => Confirm[0] = value; }
    public int BConfirm { get => Confirm[1]; set => Confirm[1] = value; }
    public int CConfirm { get => Confirm[2]; set => Confirm[2] = value; }
    public int DConfirm { get => Confirm[3]; set => Confirm[3] = value; }
    public int EConfirm { get => Confirm[4]; set => Confirm[4] = value; }

    public string PlotA { get => Plot[0]; set => Plot[0] = value; }
    public string PlotB { get => Plot[1]; set => Plot[1] = value; }
    public string PlotC { get => Plot[2]; set => Plot[2] = value; }
    public string PlotD { get => Plot[3]; set => Plot[3] = value; }
    public string PlotE { get => Plot[4]; set => Plot[4] = value; }

    public string WitA { get => Wit[0]; set => Wit[0] = value; }
    public string WitB { get => Wit[1]; set => Wit[1] = value; }
    public string WitC { get => Wit[2]; set => Wit[2] = value; }
    public string WitD { get => Wit[3]; set => Wit[3] = value; }
    public string WitE { get => Wit[4]; set => Wit[4] = value; }

    public string WitA2 { get => Wit2[0]; set => Wit2[0] = value; }
    public string WitB2 { get => Wit2[1]; set => Wit2[1] = value; }
    public string WitC2 { get => Wit2[2]; set => Wit2[2] = value; }
    public string WitD2 { get => Wit2[3]; set => Wit2[3] = value; }
    public string WitE2 { get => Wit2[4]; set => Wit2[4] = value; }

    public int SmugA { get => Smug[0]; set => Smug[0] = value; }
    public int SmugB { get => Smug[1]; set => Smug[1] = value; }
    public int SmugC { get => Smug[2]; set => Smug[2] = value; }
    public int SmugD { get => Smug[3]; set => Smug[3] = value; }
    public int SmugE { get => Smug[4]; set => Smug[4] = value; }

    public string IdA { get => IdArr[0]; set => IdArr[0] = value; }
    public string IdB { get => IdArr[1]; set => IdArr[1] = value; }
    public string IdC { get => IdArr[2]; set => IdArr[2] = value; }
    public string IdD { get => IdArr[3]; set => IdArr[3] = value; }
    public string IdE { get => IdArr[4]; set => IdArr[4] = value; }

    public int ACont { get => ContArr[0]; set => ContArr[0] = value; }
    public int BCont { get => ContArr[1]; set => ContArr[1] = value; }
    public int CCont { get => ContArr[2]; set => ContArr[2] = value; }
    public int DCont { get => ContArr[3]; set => ContArr[3] = value; }
    public int ECont { get => ContArr[4]; set => ContArr[4] = value; }

    public int Av { get => VArr[0]; set => VArr[0] = value; }
    public int Bv { get => VArr[1]; set => VArr[1] = value; }
    public int Cv { get => VArr[2]; set => VArr[2] = value; }
    public int Dv { get => VArr[3]; set => VArr[3] = value; }
    public int Ev { get => VArr[4]; set => VArr[4] = value; }

    public int Token2A { get => Token2Arr[0]; set => Token2Arr[0] = value; }
    public int Token2B { get => Token2Arr[1]; set => Token2Arr[1] = value; }
    public int Token2C { get => Token2Arr[2]; set => Token2Arr[2] = value; }
    public int Token2D { get => Token2Arr[3]; set => Token2Arr[3] = value; }
    public int Token2E { get => Token2Arr[4]; set => Token2Arr[4] = value; }

    public int AgiA { get => Agi[0]; set => Agi[0] = value; }
    public int AgiB { get => Agi[1]; set => Agi[1] = value; }
    public int AgiC { get => Agi[2]; set => Agi[2] = value; }
    public int AgiD { get => Agi[3]; set => Agi[3] = value; }
    public int AgiE { get => Agi[4]; set => Agi[4] = value; }

    public int StrA { get => Str[0]; set => Str[0] = value; }
    public int StrB { get => Str[1]; set => Str[1] = value; }
    public int StrC { get => Str[2]; set => Str[2] = value; }
    public int StrD { get => Str[3]; set => Str[3] = value; }
    public int StrE { get => Str[4]; set => Str[4] = value; }

    public int HitA { get => Hit[0]; set => Hit[0] = value; }
    public int HitB { get => Hit[1]; set => Hit[1] = value; }
    public int HitC { get => Hit[2]; set => Hit[2] = value; }
    public int HitD { get => Hit[3]; set => Hit[3] = value; }
    public int HitE { get => Hit[4]; set => Hit[4] = value; }

    public string WarriorA { get => Warrior[0]; set => Warrior[0] = value; }
    public string WarriorB { get => Warrior[1]; set => Warrior[1] = value; }
    public string WarriorC { get => Warrior[2]; set => Warrior[2] = value; }
    public string WarriorD { get => Warrior[3]; set => Warrior[3] = value; }
    public string WarriorE { get => Warrior[4]; set => Warrior[4] = value; }

    public string CreepA { get => Creep[0]; set => Creep[0] = value; }
    public string CreepB { get => Creep[1]; set => Creep[1] = value; }
    public string CreepC { get => Creep[2]; set => Creep[2] = value; }
    public string CreepD { get => Creep[3]; set => Creep[3] = value; }
    public string CreepE { get => Creep[4]; set => Creep[4] = value; }

    // Generation II: Foreign & Caravans & Witchwolves
    public int    Forpg       { get; set; }
    public int    Forpg1      { get; set; }
    public int    Forpg2      { get; set; }
    public int    Forpg3      { get; set; }
    public int    BrickValue  { get; set; }
    public int    Wal         { get; set; }
    public string Wall        { get; set; } = string.Empty;
    public string Walls       { get; set; } = "no";
    public int    Eor         { get; set; }
    public int    CarCount    { get; set; }
    public int    Visit       { get; set; }
    public int    TenseGood   { get; set; }
    public int    TenseBad    { get; set; }
    public int    IsoOff      { get; set; }
    public int    Ten         { get; set; }
    public string Tension     { get; set; } = "good";
    public int    Crossroads  { get; set; }
    public string FalseWitch  { get; set; } = string.Empty;
    public int    Rum         { get; set; }
    public string Cursed      { get; set; } = string.Empty;
    public string Bribe       { get; set; } = "no";
    public int    Collab      { get; set; }
    public string Bribed      { get; set; } = string.Empty;
    public string WSuspect    { get; set; } = string.Empty;
    public string WitAi       { get; set; } = string.Empty;
    public string WitAi2      { get; set; } = string.Empty;
    public string PointAi     { get; set; } = string.Empty;
    public string HexAi       { get; set; } = string.Empty;
    public int    Foreign     { get; set; }

    // Generation II: Creature & Business & Asylum & Count Cure
    public int    Crpg          { get; set; }
    public string Path4         { get; set; } = "no";
    public int    Liber         { get; set; }
    public int    Conse         { get; set; }
    public int    Asupg         { get; set; }
    public string AsylumUp      { get; set; } = string.Empty;
    public int    Did1          { get; set; }
    public int    Jail          { get; set; }
    public int    BusinessCount { get; set; }
    public int    Creature      { get; set; }
    public int    Exped         { get; set; }
    public int    Hunt          { get; set; }
    public string Warden        { get; set; } = "The Bloodsmith";
    public int    JunkPenalty   { get; set; }
    public int    Gen3Pg        { get; set; }
    public int    Revenge       { get; set; }
    public string TempId        { get; set; } = string.Empty;
    public int    Pay           { get; set; }
    public int    Trial         { get; set; }
    public int    TempBs        { get; set; }
    public string TempCheck     { get; set; } = string.Empty;
    public string Ex            { get; set; } = string.Empty;

    public int GetPl(int i) => (i >= 0 && i < Pl.Length) ? Pl[i] : 0;
    public void SetPl(int i, int v) { if (i >= 0 && i < Pl.Length) Pl[i] = v; }
    public int GetConfirm(int i) => (i >= 0 && i < Confirm.Length) ? Confirm[i] : 0;
    public void SetConfirm(int i, int v) { if (i >= 0 && i < Confirm.Length) Confirm[i] = v; }
    public string GetPlot(int i) => (i >= 0 && i < Plot.Length) ? Plot[i] : string.Empty;
    public void SetPlot(int i, string v) { if (i >= 0 && i < Plot.Length) Plot[i] = v; }
    public string GetWit(int i) => (i >= 0 && i < Wit.Length) ? Wit[i] : string.Empty;
    public void SetWit(int i, string v) { if (i >= 0 && i < Wit.Length) Wit[i] = v; }
    public void SetFate(int fate, string pName)
    {
        switch (fate)
        {
            case 1: Fate1 = pName; break;
            case 2: Fate2 = pName; break;
            case 3: Fate3 = pName; break;
            case 4: Fate4 = pName; break;
            case 5: Fate5 = pName; break;
            case 6: Fate6 = pName; break;
        }
    }
    public string GetFate(int fate) => fate switch
    {
        1 => Fate1,
        2 => Fate2,
        3 => Fate3,
        4 => Fate4,
        5 => Fate5,
        6 => Fate6,
        _ => string.Empty
    };
    public int    Dev           { get; set; }
    public int    BusVp         { get; set; }
    public int    BTemp         { get; set; }
    public int    Pripg         { get; set; }
    public string MenName       { get; set; } = string.Empty;
    public string MenType       { get; set; } = string.Empty;
    public string Them          { get; set; } = string.Empty;
    public string Pl1           { get; set; } = string.Empty;
    public string Pl2           { get; set; } = string.Empty;
    public string Pl3           { get; set; } = string.Empty;
    public string Pl4           { get; set; } = string.Empty;
    public string Pl5           { get; set; } = string.Empty;
    public int    Counter       { get; set; }
    public int    AsylumCount   { get; set; }
    public int    Control       { get; set; }
    public int    Id            { get; set; }
    public string TempCreep     { get; set; } = string.Empty;
    public int    SaltSp        { get; set; }
    public int    ObsVp         { get; set; }
    public int    CreatureHelp  { get; set; }
    public string BusM          { get; set; } = string.Empty;
    public int    Bnc           { get; set; }
    public string BHome         { get; set; } = string.Empty;
    public string TempAs        { get; set; } = string.Empty;
    public string CureCount     { get; set; } = "no";
    public string CurePlayer    { get; set; } = string.Empty;
    public string CreatureCard  { get; set; } = "no";
    public int    CreatureFlag  { get; set; }
    public int    Privatized    { get; set; }

    // Generation III: Privatized & BattleDome & Liberal & Asylum Questions
    public int    Question       { get; set; }
    public string Goal2nd        { get; set; } = string.Empty;
    public string Active         { get; set; } = string.Empty;
    public string Target         { get; set; } = string.Empty;
    public int    TempStr        { get; set; }
    public int    TempAgi        { get; set; }
    public int    TempHit        { get; set; }
    public int    ElimCount      { get; set; }
    public int    BattleCount    { get; set; }
    public int    CreepCount     { get; set; }
    public string Elim           { get; set; } = string.Empty;
    public string Lib            { get; set; } = string.Empty;
    public int    AsylumQuestion { get; set; }
    public string Asymlump       { get; set; } = string.Empty;
    public int    Token2         { get; set; }
    public string Next           { get; set; } = string.Empty;
    public int    Test           { get; set; }
    public int    Outcome        { get; set; }
    public string Xxxx           { get; set; } = string.Empty;
    public string Quest1         { get; set; } = string.Empty;
    public string Quest2         { get; set; } = string.Empty;
    public string Quest3         { get; set; } = string.Empty;
    public string Quest4         { get; set; } = string.Empty;
    public int    Psych          { get; set; }
    public int    Qu1            { get; set; }
    public int    Qu2            { get; set; }
    public int    Qu3            { get; set; }
    public int    Qu4            { get; set; }

    // Return-Passage Routing Strings
    public string S4IsoBrickNextPsg         { get; set; } = string.Empty;
    public string Liberal2NextPsg           { get; set; } = string.Empty;
    public string ExpoNextPsg               { get; set; } = string.Empty;
    public string Mobbed2NextPsg            { get; set; } = string.Empty;
    public string SmugConsequenceNextPsg    { get; set; } = string.Empty;
    public string SmugEvent2AaNextPsg       { get; set; } = string.Empty;
    public string EssentialConsNextPsg      { get; set; } = string.Empty;
    public string FPFateAssignHubNextPsg    { get; set; } = string.Empty;
    public string BusMeetANextPsg           { get; set; } = string.Empty;
    public string BusMeetBNextPsg           { get; set; } = string.Empty;
    public string BusMeetCNextPsg           { get; set; } = string.Empty;
    public string BusMeetDNextPsg           { get; set; } = string.Empty;
    public string BusMeetENextPsg           { get; set; } = string.Empty;
    public string Payment1HubNextPsg        { get; set; } = string.Empty;
    public string SmugEvent2AContNextPsg    { get; set; } = string.Empty;
    public string EssentialSalts1NextPsg    { get; set; } = string.Empty;
    public string EssentialSalts1NextPsg2   { get; set; } = string.Empty;
    public string EssentialSaltsNoNextPsg   { get; set; } = string.Empty;
    public string LiberalEvent2aNextPsg     { get; set; } = string.Empty;
    public string LiberalEvent2abNextPsg    { get; set; } = string.Empty;
    public string AsylumTestResultsNextPsg  { get; set; } = string.Empty;

    // Final Scoring & Tie-Breakers
    public int[]          PlayerScores      { get; set; } = new int[5];
    public int            ScoreEntryIndex   { get; set; }
    public List<int> TiedPlayers       { get; set; } = new();
    public int[]          TieBreakerMoney   { get; set; } = new int[5];
    public int            TieBreakerIndex   { get; set; }
    public string         WinnerName        { get; set; } = string.Empty;
    public string         Winner            { get; set; } = string.Empty;
    public string[]       PlayerDisplayNames { get; set; } = new string[5];

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
        HubId       = FearOfUnknownHubId.None;
        Tracker     = 0;
        RandomName  = string.Empty;
        RandomPlayer = string.Empty;
        string[] suffixes = { "Ledger", "Gazette", "Mercury", "Village Voice", "Examiner" };
        Newspaper   = $"The {globalData.TownName} {suffixes[Random.Shared.Next(suffixes.Length)]}";
        Ending      = "FOTU-End1";
        Round       = 1;
        TownName    = globalData.TownName;

        Whpg        = 0;
        Fp10Vp      = 0;
        FpResearch2 = 0;
        FpSanity3   = 0;
        FpCreepy3   = 0;
        OneCount    = 0;
        FpFate      = 0;
        Fate1       = string.Empty;
        Fate2       = string.Empty;
        Fate3       = string.Empty;
        Fate4       = string.Empty;
        Fate5       = string.Empty;
        Fate6       = string.Empty;
        Kill        = "blacksmith";
        Mobbed      = "no";
        Mog         = 0;
        Witch1      = string.Empty;
        Witch2      = string.Empty;
        Witch       = "dead";
        Gen2Fate    = "witch";
        Gen2End     = "asylum";
        TempPlot    = string.Empty;
        TempName    = string.Empty;
        RevPlot     = "fortune";
        RevResolve  = 0;

        Pl          = new int[5];
        Confirm     = new int[5];
        Plot        = new[] { "no", "no", "no", "no", "no" };
        Wit         = new[] { "", "", "", "", "" };
        Wit2        = new[] { "", "", "", "", "" };
        Smug        = new int[5];
        IdArr       = new[] { "", "", "", "", "" };
        ContArr     = new int[5];
        VArr        = new int[5];
        Token2Arr   = new int[5];
        Agi         = new int[5];
        Str         = new int[5];
        Hit         = new int[5];
        Warrior     = new[] { "", "", "", "", "" };
        Creep       = new[] { "", "", "", "", "" };

        Forpg       = 0;
        Forpg1      = 0;
        Forpg2      = 0;
        Forpg3      = 0;
        BrickValue  = 1;
        Wal         = 0;
        Wall        = string.Empty;
        Walls       = "no";
        Eor         = 0;
        CarCount    = 0;
        Visit       = 0;
        TenseGood   = 0;
        TenseBad    = 0;
        IsoOff      = 0;
        Ten         = 0;
        Tension     = "good";
        Crossroads  = 0;
        FalseWitch  = string.Empty;
        Rum         = 0;
        Cursed      = string.Empty;
        Bribe       = "no";
        Collab      = 0;
        Bribed      = string.Empty;
        WSuspect    = string.Empty;
        WitAi       = string.Empty;
        WitAi2      = string.Empty;
        PointAi     = string.Empty;
        HexAi       = string.Empty;
        Foreign     = 0;

        Crpg          = 0;
        Path4         = "no";
        Liber         = 0;
        Conse         = 0;
        Asupg         = 0;
        AsylumUp      = string.Empty;
        Did1          = 0;
        Jail          = 0;
        BusinessCount = 0;
        Creature      = 0;
        Exped         = 0;
        Hunt          = 0;
        Warden        = "The Bloodsmith";
        JunkPenalty   = 0;
        Gen3Pg        = 0;
        Revenge       = 0;
        TempId        = string.Empty;
        Pay           = 0;
        Trial         = 0;
        TempBs        = 0;
        Ex            = string.Empty;
        Dev           = 0;
        BusVp         = 0;
        BTemp         = 0;
        Pripg         = 0;
        MenName       = string.Empty;
        MenType       = string.Empty;
        Them          = string.Empty;
        Pl1           = string.Empty;
        Pl2           = string.Empty;
        Pl3           = string.Empty;
        Pl4           = string.Empty;
        Pl5           = string.Empty;
        Counter       = 0;
        AsylumCount   = 0;
        Control       = 0;
        Id            = 0;
        TempCreep     = string.Empty;
        SaltSp        = 0;
        ObsVp         = 0;
        CreatureHelp  = 0;
        BusM          = string.Empty;
        Bnc           = 0;
        BHome         = string.Empty;
        TempAs        = string.Empty;
        CureCount     = "no";
        CurePlayer    = string.Empty;
        CreatureCard  = "no";
        CreatureFlag  = 0;
        Privatized    = 0;

        Question       = 0;
        Goal2nd        = string.Empty;
        Active         = string.Empty;
        Target         = string.Empty;
        TempStr        = 0;
        TempAgi        = 0;
        TempHit        = 0;
        ElimCount      = 0;
        BattleCount    = 0;
        CreepCount     = 0;
        Elim           = string.Empty;
        Lib            = string.Empty;
        AsylumQuestion = 0;
        Asymlump       = string.Empty;
        Token2         = 0;
        Next           = string.Empty;
        Test           = 0;
        Outcome        = 0;
        Xxxx           = string.Empty;
        Quest1         = string.Empty;
        Quest2         = string.Empty;
        Quest3         = string.Empty;
        Quest4         = string.Empty;
        Psych          = 0;
        Qu1            = 0;
        Qu2            = 0;
        Qu3            = 0;
        Qu4            = 0;

        S4IsoBrickNextPsg        = string.Empty;
        Liberal2NextPsg          = string.Empty;
        ExpoNextPsg              = string.Empty;
        Mobbed2NextPsg           = string.Empty;
        SmugConsequenceNextPsg   = string.Empty;
        SmugEvent2AaNextPsg      = string.Empty;
        EssentialConsNextPsg     = string.Empty;
        FPFateAssignHubNextPsg   = string.Empty;
        BusMeetANextPsg          = string.Empty;
        BusMeetBNextPsg          = string.Empty;
        BusMeetCNextPsg          = string.Empty;
        BusMeetDNextPsg          = string.Empty;
        BusMeetENextPsg          = string.Empty;
        Payment1HubNextPsg       = string.Empty;
        SmugEvent2AContNextPsg   = string.Empty;
        EssentialSalts1NextPsg   = string.Empty;
        EssentialSalts1NextPsg2  = string.Empty;
        EssentialSaltsNoNextPsg  = string.Empty;
        LiberalEvent2aNextPsg    = string.Empty;
        LiberalEvent2abNextPsg   = string.Empty;
        AsylumTestResultsNextPsg = string.Empty;

        PlayerScores    = new int[5];
        ScoreEntryIndex = 0;
        TiedPlayers     = new List<int>();
        TieBreakerMoney = new int[5];
        TieBreakerIndex = 0;
        WinnerName      = string.Empty;
        Winner          = string.Empty;
        PlayerDisplayNames = new string[5];
        for (int i = 0; i < 4; i++)
        {
            PlayerDisplayNames[i] = globalData.GetPlayerNameByIndex(i);
        }
    }
}
