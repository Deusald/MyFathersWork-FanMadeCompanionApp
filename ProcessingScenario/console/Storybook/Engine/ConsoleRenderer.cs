using System.Text;

namespace Storybook.Engine;

/// <summary>Draws a passage to the terminal and reads the player's answer.</summary>
public sealed class ConsoleRenderer
{
    private const int _WIDTH = 92;

    public void Render(string passageName, IReadOnlyList<Block> blocks)
    {
        Console.Clear();
        WriteDim($"  [{passageName}]");
        Console.WriteLine();

        var blankPending = false;
        foreach (var block in blocks)
        {
            if (block.Kind == BlockKind.Body && block.Text.Length == 0)
            {
                blankPending = true;
                continue;
            }
            if (blankPending)
            {
                Console.WriteLine();
                blankPending = false;
            }
            WriteBlock(block);
        }
        Console.WriteLine();
    }

    public int AskChoice(IReadOnlyList<Choice> choices)
    {
        for (var x = 0; x < choices.Count; ++x)
        {
            WriteColored($"  {x + 1}. ", ConsoleColor.Cyan);
            Console.WriteLine(choices[x].Label);
        }
        Console.WriteLine();

        while (true)
        {
            WriteColored("  > ", ConsoleColor.Cyan);
            var input = Console.ReadLine();
            if (input is null) Environment.Exit(0);
            input = input.Trim();

            if (choices.Count == 1 && input.Length == 0) return 0;
            if (int.TryParse(input, out var pick) && pick >= 1 && pick <= choices.Count) return pick - 1;

            WriteColored($"  Please enter a number from 1 to {choices.Count}.\n", ConsoleColor.DarkYellow);
        }
    }

    public string AskString(string message)
    {
        Console.WriteLine();
        WriteWrapped(message, ConsoleColor.White, indent: "  ");
        while (true)
        {
            WriteColored("  > ", ConsoleColor.Cyan);
            var input = Console.ReadLine();
            if (input is null) Environment.Exit(0);
            input = Collapse(input.Trim());
            if (input.Length > 0) return input;
            WriteColored("  A response is required.\n", ConsoleColor.DarkYellow);
        }
    }

    public int AskNumber(string message, int min, int max)
    {
        Console.WriteLine();
        WriteWrapped(message, ConsoleColor.White, indent: "  ");
        while (true)
        {
            WriteColored("  > ", ConsoleColor.Cyan);
            var input = Console.ReadLine();
            if (input is null) Environment.Exit(0);
            if (int.TryParse(input.Trim(), out var value) && value >= min && value <= max) return value;
            WriteColored($"  Please enter a number from {min} to {max}.\n", ConsoleColor.DarkYellow);
        }
    }

    public void Pause(string message = "Press Enter to continue...")
    {
        Console.WriteLine();
        WriteDim("  " + message);
        Console.ReadLine();
    }

    // ---- internals ----------------------------------------------------

    private static void WriteBlock(Block block)
    {
        switch (block.Kind)
        {
            case BlockKind.Title:
                WriteWrapped(block.Text.ToUpperInvariant(), ConsoleColor.Yellow, indent: "  ");
                WriteColored("  " + new string('=', Math.Min(block.Text.Length, _WIDTH)) + "\n", ConsoleColor.DarkYellow);
                break;
            case BlockKind.Heading:
                WriteWrapped(block.Text, ConsoleColor.Yellow, indent: "  ");
                break;
            case BlockKind.HubTitle:
                WriteWrapped("> " + block.Text, ConsoleColor.Green, indent: "  ");
                break;
            case BlockKind.HubDetails:
                WriteWrapped(block.Text, ConsoleColor.DarkGreen, indent: "     ");
                break;
            case BlockKind.SetupCard:
            case BlockKind.SetupCardEvent:
                WriteColored("  +-- SETUP " + new string('-', _WIDTH - 12) + "\n", ConsoleColor.Magenta);
                WriteWrapped(block.Text, ConsoleColor.Magenta, indent: "  | ");
                WriteColored("  +" + new string('-', _WIDTH - 3) + "\n", ConsoleColor.Magenta);
                break;
            default:
                WriteWrapped(block.Text, ConsoleColor.Gray, indent: "  ");
                break;
        }
    }

    private static void WriteWrapped(string text, ConsoleColor color, string indent)
    {
        foreach (var line in Wrap(text, _WIDTH - indent.Length))
            WriteColored(indent + line + "\n", color);
    }

    private static IEnumerable<string> Wrap(string text, int width)
    {
        var line = new StringBuilder();
        foreach (var word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (line.Length > 0 && line.Length + 1 + word.Length > width)
            {
                yield return line.ToString();
                line.Clear();
            }
            if (line.Length > 0) line.Append(' ');
            line.Append(word);
        }
        yield return line.ToString();
    }

    private static string Collapse(string text) => string.Join(' ', text.Split(' ', StringSplitOptions.RemoveEmptyEntries));

    private static void WriteColored(string text, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previous;
    }

    private static void WriteDim(string text) => WriteColored(text + "\n", ConsoleColor.DarkGray);
}
