using Storybook.Engine;

namespace Storybook.Game.Chapters;

/// <summary>
/// Chapter 01 - Setup. Source: chapters/01-Setup.cs.
///
/// Covers the opening flow only: LOGO -> player count -> per-seat name entry ->
/// village name -> scenario select -> preparations -> preface -> Scenario5Start.
/// Scoring, the eight endings and the dev-note passages remain unconverted.
///
/// Two deliberate departures from the Cradle source, both matching what the
/// shipped app actually did:
///
/// 1. In the original, player count and the names were collected by host screens
///    (ViewGamePlayerCounts / ViewPlayerNameEnter / ViewEnterVillageName) writing
///    into GLOBALS, and Preparations-TCOD read them back. The story-side TITLE
///    SCREEN / NameEntryA-E / NameEntryTownConfirm passages were vestigial - they
///    rendered a literal "ERROR!" heading and their SetCurrentStoryPassage calls
///    were commented out. Here the passages do the collecting themselves, keeping
///    their prose and dropping the ERROR! heading.
///
/// 2. NameEntryA-E were hand-duplicated per seat and each assigned
///    `Vars.players = 1..5`, clobbering the real player count (NameEntryB then
///    tested `players > 2` against the 2 it had just written, so a 4-player game
///    could never reach NameEntryC). Collapsed here into one parameterised
///    NameEntry passage driven by SeatIndex, with the per-seat flavour lines kept.
///    Seat E is dropped entirely - the game is 2-4 players.
/// </summary>
public static class Setup
{
    private static readonly string[] _SeatFarewells =
    [
        "Our warmest regards.",
        "Please enjoy your experience.",
        "May your name live in infamy.",
        "Be sure to leave your mark on the world."
    ];

    public static void Register(Story story, GameState state)
    {
        // ---- LOGO (passage41) -----------------------------------------
        story.Add("LOGO", ctx =>
        {
            ctx.Title("My Father's Work");
            ctx.Line();
            ctx.Text("A clever game by ").Text("T. C. Petty III.").Line();
            ctx.Line();
            ctx.Link("Click to continue...", "TITLE SCREEN");
        });

        // ---- TITLE SCREEN (passage10) ---------------------------------
        // 2-4, as the original passage offered. The host screen and the story's
        // nameE/NameEntryE path allowed a 5th seat, but the boardgame does not
        // support 5 players; that whole path is dropped from the conversion.
        story.Add("TITLE SCREEN", ctx =>
        {
            ctx.Title("My Father's Work");
            ctx.Line();
            ctx.Text("How many individuals will be sharing this experience today?").Line();
            ctx.Line();
            for (var players = 2; players <= 4; ++players)
            {
                var count = players;
                ctx.Link($"{count} Players.", "PlayerNameIntro", () =>
                {
                    state.Players = count;
                    state.Names.Clear();
                    state.SeatIndex = 0;
                });
            }
        });

        // ---- PlayerNameIntro (passage75) ------------------------------
        story.Add("PlayerNameIntro", ctx =>
        {
            ctx.Text("As siblings of an influential family of Eastern European descent, the {PlayTxt} "
                   + "of us have received a not-insignificant portion of our family's estate.").Line();
            ctx.Line();
            ctx.Text("Before we begin, let us make this historical fiction more engaging by providing our names.").Line();
            ctx.Line();
            ctx.Link("Click to continue...", "NameEntry");
        });

        // ---- NameEntry (was NameEntryA-E, passages 76-80) --------------
        story.Add("NameEntry", ctx =>
        {
            if (state.Names.Count <= state.SeatIndex)
            {
                ctx.Text("Carefully pass the storybook to Player {SeatLetter}.").Line();
                ctx.AskString("Player {SeatLetter} - Please enter your given name:",
                              name => state.Names.Add(name));
                return;
            }

            ctx.Text("Welcome to My Father's Work,").Line();
            ctx.Text(state.Names[state.SeatIndex] + ".").Line();
            ctx.Line();
            ctx.Text(_SeatFarewells[state.SeatIndex]).Line();
            ctx.Line();

            var isLastSeat = state.SeatIndex + 1 >= state.Players;
            ctx.Link("Click to Continue...", isLastSeat ? "TCOD-TownName" : "NameEntry",
                     () => state.SeatIndex++);
        });

        // ---- TCOD-TownName (passage220) -------------------------------
        story.Add("TCOD-TownName", ctx =>
        {
            ctx.Title("The Village");
            ctx.Line();
            ctx.Text("Now that our given names have been established, we must also search our recollection for "
                   + "the name of the village which our vast estates overlook. Considering the myriad of small "
                   + "towns in the Hungarian countryside, it would be unmeritably forward to not allow the group "
                   + "a chance to collectively name the place they will now inhabit.").Line();
            ctx.Line();
            ctx.Link("Click here to name the village...", "NameEntryTownConfirm");
        });

        // ---- NameEntryTownConfirm (passage221) ------------------------
        story.Add("NameEntryTownConfirm", ctx =>
        {
            if (state.TownName.Length == 0)
            {
                ctx.AskString("Please enter the name of your village:", name => state.TownName = name);
                return;
            }

            ctx.Text("Thank you and please do excuse our forgetfulness.").Line();
            ctx.Line();
            ctx.Text("Of course, {TownName} is an appropriate and fitting moniker for a place to conduct "
                   + "important scientific research. In fact, history will remember this name, mark my words.").Line();
            ctx.Line();
            ctx.Link("Click to Continue...", "Start2");
        });

        // ---- Start2 (passage1) ----------------------------------------
        story.Add("Start2", ctx =>
        {
            ctx.Title("My Father's Work");
            ctx.Line();
            ctx.Text("Choose a Scenario for {PlayTxt} players:").Line();
            ctx.Line();
            ctx.Link("A Time of War", "NoLink");
            ctx.Link("Fear and Politics", "NoLink");
            ctx.Link("The Cost of Disease", "Preparations-TCOD");
            ctx.Link("For an explanation of how to use this Storybook, click here.", "StoryBook");
            state.Tracker = 0;
        });

        // ---- StoryBook (passage40) ------------------------------------
        story.Add("StoryBook", ctx =>
        {
            ctx.Title("How to Use the Storybook");
            ctx.Line();
            ctx.Text("My Father's Work is a game of Victorian era mad scientist ambition told over three "
                   + "generations. The Storybook App controls the direction of the Town depending on the "
                   + "decisions made by the players. It will require that players interact with it by clicking "
                   + "on specific passages at certain times.").Line();
            ctx.Line();
            ctx.Heading("End of a round");
            ctx.Text("There are three rounds in each Generation. At the end of each round, you must click the "
                   + "bottom link to resolve any special events and move play to the next round. The screen will "
                   + "then display the current round and changes to gameplay (if any).").Line();
            ctx.Line();
            ctx.Heading("Story Actions");
            ctx.Text("Sometimes, the game will require that a player click a certain link when an action has "
                   + "been performed. This may be taking an action in the Town, your Estate, or completing a "
                   + "specific goal. Be sure to click these links to receive a special story passage.").Line();
            ctx.Line();
            ctx.Link("Click to return...", "Start2");
        });

        // ---- NoLink (passage340) --------------------------------------
        story.Add("NoLink", ctx =>
        {
            ctx.Text("This scenario is not part of the current conversion.").Line();
            ctx.Line();
            ctx.Link("Click to return...", "Start2");
        });

        // ---- Preparations-TCOD (passage222) ---------------------------
        // The original re-read every name from GLOBALS here; state is already
        // authoritative, so only the setup card survives.
        story.Add("Preparations-TCOD", ctx =>
        {
            ctx.Title("Preparations");
            ctx.Line();
            ctx.Setup("Complete the standard setup for {PlayTxt} players as shown in the rulebook. Note that "
                    + "the Angry Mob track and starting player will be set by the Storybook in the coming pages.");
            ctx.Line();
            ctx.Setup("Then, retrieve The Cost of Disease Scenario box, which will contain all components "
                    + "needed for this story. As the Storybook progresses, it will ask you to put items into "
                    + "play from this box. Be sure to keep it nearby.");
            state.SetupImage = "ScenarioBox3D_Disease";
            ctx.Line();
            ctx.Link("Click here to continue...", "Preface-TCOD");
        });

        // ---- Preface-TCOD (passage223) --------------------------------
        story.Add("Preface-TCOD", ctx =>
        {
            ctx.Title("A Foreword");
            ctx.Line();
            ctx.Text("Herein contains a historical account of a peculiar lineage. One that spans multiple "
                   + "generations and by all accounts will continue to fascinate historians for many years to come.").Line();
            ctx.Line();
            ctx.Text("I have endeavored to provide as complete a scholarly history as one could provide given the "
                   + "conflicting accounts and whims of hearsay. While many of the details, haunting to the "
                   + "imagination as they may be, stretch the very limits of our human understanding, it is my "
                   + "hope that this text and the accompanying research materials procured will provide evidence "
                   + "as to their truth. The harrowing and potentially supernatural series of events has the "
                   + "capacity to shake the very foundations of the scientific world as we perceive it.").Line();
            ctx.Line();
            ctx.Text("With deference to the fellowship that commissioned this explicit work, though I have never "
                   + "met with these generous benefactors, I humbly submit this biographical account in its "
                   + "entirety and swear by the veracity of the contents within.").Line();
            ctx.Line();
            ctx.Text("In good health,").Line();
            ctx.Text("Dr. Ensign Benwallis").Line();
            ctx.Line();
            ctx.Link("Click to continue...", "Scenario5Start");
        });

        // ---- chapter boundary -----------------------------------------
        // Scenario5Start (passage5, INTRO) opens chapters/02-Gen1-Fever.cs.
        story.Add("Scenario5Start", PassageKind.Intro, ctx =>
        {
            ctx.Title("Generation I: Yellow Fever");
            ctx.Line();
            ctx.Text("Setup is complete.").Line();
            ctx.Line();
            ctx.Text("Players: {Players} ({PlayTxt})").Line();
            for (var x = 0; x < state.Players; ++x)
                ctx.Text($"  Player {(char)('A' + x)}: {state.Names[x]}").Line();
            ctx.Text("Village: {TownName}").Line();
            ctx.Line();
            ctx.Text("Chapter 02 (Gen1-Fever) is not converted yet.").Line();
            ctx.EndOfStory();
        });
    }
}
