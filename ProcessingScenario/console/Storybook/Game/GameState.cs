namespace Storybook.Game;

/// <summary>
/// The story variables. Replaces Cradle's 261 loosely-typed StoryVars and the
/// GLOBALS static class - both held the same values, GLOBALS being the copy the
/// host UI wrote and Preparations-TCOD read back.
///
/// Only the setup-chapter variables are declared so far. Add each chapter's own
/// variables as it is converted; give every one a real type rather than carrying
/// the "" / 0 / string triple-state of StoryVar forward.
/// </summary>
public sealed class GameState
{
    // ---- Setup --------------------------------------------------------

    /// <summary>Number of players sharing the session, 2-4. The 5th seat is not supported - see CLAUDE.md.</summary>
    public int Players { get; set; }

    /// <summary>Players spelled out - "two".."four". Was `playtxt`.</summary>
    public string PlayTxt => Players switch
    {
        2 => "two",
        3 => "three",
        4 => "four",
        _ => "two"
    };

    /// <summary>Seat names in order. Was nameA..nameD.</summary>
    public List<string> Names { get; } = new();

    public string NameA => SeatName(0);
    public string NameB => SeatName(1);
    public string NameC => SeatName(2);
    public string NameD => SeatName(3);

    public string TownName { get; set; } = string.Empty;

    /// <summary>Which seat the name-entry loop is on. Host state; was ViewPlayerNameEnter.playerIndex.</summary>
    public int SeatIndex { get; set; }

    /// <summary>Seat letter A-D for the current seat index.</summary>
    public string SeatLetter => ((char)('A' + SeatIndex)).ToString();

    /// <summary>Was `tracker` - the story's generic scratch counter.</summary>
    public int Tracker { get; set; }

    /// <summary>Sprite name for the next SETUP card. Was `_SetupImage`.</summary>
    public string SetupImage { get; set; } = "MFWlogo";

    // ---- helpers ------------------------------------------------------

    private string SeatName(int index) => index < Names.Count ? Names[index] : string.Empty;
}
