using System.Text;
using SmartFormat;
using SmartFormat.Core.Settings;

namespace Storybook.Engine;

/// <summary>Kind of block a passage emitted. Replaces the style-group scraping in TwineTMProPlayer.</summary>
public enum BlockKind
{
    Body,
    Title,
    Heading,
    HubTitle,
    HubDetails,
    SetupCard,
    SetupCardEvent
}

public sealed record Block(BlockKind Kind, string Text);

public sealed record Choice(string Label, string? Target, Action? Action);

/// <summary>
/// What a passage asked the host to do before the next passage runs.
/// Replaces the two-pass ispopup idiom: the prompt is declarative, the runner
/// gathers the answer and hands it back through the setter.
/// </summary>
public abstract record Prompt(string Message)
{
    public sealed record String(string Message, Action<string> Set) : Prompt(Message);
    public sealed record Number(string Message, int Min, int Max, Action<int> Set) : Prompt(Message);
}

/// <summary>
/// Collects everything a passage emits. The passage body never touches the console.
/// </summary>
public sealed class StoryContext
{
    /// <summary>
    /// Braces that do not resolve are left alone rather than throwing - player-entered
    /// names and town names flow back through Smart.Format and may contain anything.
    /// </summary>
    private static readonly SmartFormatter _Formatter = Smart.CreateDefaultSmartFormat(new SmartSettings
    {
        Parser    = { ErrorAction = ParseErrorAction.MaintainTokens },
        Formatter = { ErrorAction = FormatErrorAction.MaintainTokens }
    });

    private readonly object _data;
    private readonly List<Block> _blocks = new();
    private readonly List<Choice> _choices = new();
    private readonly StringBuilder _current = new();

    public StoryContext(object data) => _data = data;

    public IReadOnlyList<Block> Blocks => _blocks;
    public IReadOnlyList<Choice> Choices => _choices;

    /// <summary>Set by Goto - an unconditional jump, the old abort(goToPassage:).</summary>
    public string? GotoTarget { get; private set; }

    /// <summary>Set by Ask* - the host must collect input before continuing.</summary>
    public Prompt? PendingPrompt { get; private set; }

    /// <summary>Set when the passage declared itself a terminal ending.</summary>
    public bool IsEnding { get; private set; }

    // ---- output -------------------------------------------------------

    /// <summary>Emit prose. The template is SmartFormat-rendered against the game state.</summary>
    public StoryContext Text(string template)
    {
        _current.Append(_Formatter.Format(template, _data));
        return this;
    }

    /// <summary>End the current line - the old lineBreak(). Two in a row make a paragraph break.</summary>
    public StoryContext Line()
    {
        _blocks.Add(new Block(BlockKind.Body, _current.ToString()));
        _current.Clear();
        return this;
    }

    /// <summary>The passage title - was styleScope("bold") as the first style group.</summary>
    public StoryContext Title(string template) => Emit(BlockKind.Title, template);

    public StoryContext Heading(string template) => Emit(BlockKind.Heading, template);

    /// <summary>Declares a hub row - was styleScope("hubTitle"/"hubDetails").</summary>
    public StoryContext HubRow(string title, string details)
    {
        Emit(BlockKind.HubTitle, title);
        Emit(BlockKind.HubDetails, details);
        return this;
    }

    /// <summary>Physical-component instructions - was styleScope("setupStyle"/"setupStyleEvnt").</summary>
    public StoryContext Setup(string template, bool blocking = false)
        => Emit(blocking ? BlockKind.SetupCardEvent : BlockKind.SetupCard, template);

    // ---- navigation ---------------------------------------------------

    public StoryContext Link(string label, string target)
    {
        _choices.Add(new Choice(_Formatter.Format(label, _data), target, null));
        return this;
    }

    /// <summary>A choice that runs an action and then navigates - was a hook fragment that aborts.</summary>
    public StoryContext Link(string label, string target, Action action)
    {
        _choices.Add(new Choice(_Formatter.Format(label, _data), target, action));
        return this;
    }

    /// <summary>A choice that runs an action in place - was link(label, null, enchantHook(...)).</summary>
    public StoryContext Link(string label, Action action)
    {
        _choices.Add(new Choice(_Formatter.Format(label, _data), null, action));
        return this;
    }

    public void Goto(string target)
    {
        Flush();
        GotoTarget = target;
    }

    public void AskString(string message, Action<string> set)
    {
        Flush();
        PendingPrompt = new Prompt.String(_Formatter.Format(message, _data), set);
    }

    public void AskNumber(string message, int min, int max, Action<int> set)
    {
        Flush();
        PendingPrompt = new Prompt.Number(_Formatter.Format(message, _data), min, max, set);
    }

    public void EndOfStory() => IsEnding = true;

    // ---- internals ----------------------------------------------------

    private StoryContext Emit(BlockKind kind, string template)
    {
        Flush();
        _blocks.Add(new Block(kind, _Formatter.Format(template, _data)));
        return this;
    }

    /// <summary>Close off any half-written line without emitting a spurious blank one.</summary>
    private void Flush()
    {
        if (_current.Length == 0) return;
        _blocks.Add(new Block(BlockKind.Body, _current.ToString()));
        _current.Clear();
    }

    internal void Complete() => Flush();
}
