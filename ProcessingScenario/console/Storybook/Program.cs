using Storybook.Engine;
using Storybook.Game;
using Storybook.Game.Chapters;

var state = new GameState();
var story = new Story();

Setup.Register(story, state);

if (args.Contains("--check"))
{
    var dangling = story.DanglingLinks(state).ToList();
    foreach (var (from, to) in dangling)
        Console.WriteLine($"dangling: {from} -> {to}");
    Console.WriteLine($"{story.Passages.Count} passages, {dangling.Count} dangling link(s).");
    return;
}

Console.OutputEncoding = System.Text.Encoding.UTF8;
new StoryRunner(story, state, new ConsoleRenderer()).Run("LOGO");
