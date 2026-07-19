namespace Storybook.Engine;

/// <summary>
/// Walks the passage graph. Re-runs a passage after a prompt is answered, which is
/// how the original two-pass popup idiom stays honest without the ispopup flag.
/// </summary>
public sealed class StoryRunner
{
    private readonly Story _story;
    private readonly object _data;
    private readonly ConsoleRenderer _renderer;

    public StoryRunner(Story story, object data, ConsoleRenderer renderer)
    {
        _story = story;
        _data = data;
        _renderer = renderer;
    }

    public string CurrentPassage { get; private set; } = string.Empty;

    public void Run(string startPassage)
    {
        var next = startPassage;
        while (next is not null)
            next = Step(next);
    }

    private string? Step(string passageName)
    {
        CurrentPassage = passageName;
        var passage = _story.Get(passageName);

        var ctx = new StoryContext(_data);
        passage.Body(ctx);
        ctx.Complete();

        if (ctx.GotoTarget is { } target)
            return target;

        _renderer.Render(passage.Name, ctx.Blocks);

        if (ctx.PendingPrompt is { } prompt)
        {
            switch (prompt)
            {
                case Prompt.String s:
                    s.Set(_renderer.AskString(s.Message));
                    break;
                case Prompt.Number n:
                    n.Set(_renderer.AskNumber(n.Message, n.Min, n.Max));
                    break;
            }
            return passageName;   // re-enter; the passage now sees the answer
        }

        if (ctx.IsEnding || passage.Kind == PassageKind.Ending || ctx.Choices.Count == 0)
        {
            _renderer.Pause("THE END - press Enter to exit.");
            return null;
        }

        var choice = ctx.Choices[_renderer.AskChoice(ctx.Choices)];
        choice.Action?.Invoke();
        return choice.Target ?? passageName;   // no target = a reveal; re-enter the passage
    }
}
