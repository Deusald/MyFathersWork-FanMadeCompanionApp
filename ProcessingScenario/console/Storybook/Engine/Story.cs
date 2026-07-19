namespace Storybook.Engine;

/// <summary>The passage graph. Chapters register into this at startup.</summary>
public sealed class Story
{
    private readonly Dictionary<string, Passage> _passages = new(StringComparer.Ordinal);

    public IReadOnlyDictionary<string, Passage> Passages => _passages;

    public void Add(string name, PassageKind kind, Action<StoryContext> body)
        => _passages[name] = new Passage(name, kind, body);

    public void Add(string name, Action<StoryContext> body)
        => Add(name, PassageKind.Normal, body);

    public Passage Get(string name)
        => _passages.TryGetValue(name, out var p)
               ? p
               : throw new KeyNotFoundException($"No such passage: '{name}'");

    /// <summary>Every link target that has no passage behind it. The old story had exactly one.</summary>
    public IEnumerable<(string From, string To)> DanglingLinks(object probeData)
    {
        foreach (var passage in _passages.Values)
        {
            var ctx = new StoryContext(probeData);
            try { passage.Body(ctx); }
            catch { continue; }
            foreach (var choice in ctx.Choices)
                if (choice.Target is { } t && !_passages.ContainsKey(t))
                    yield return (passage.Name, t);
        }
    }
}
