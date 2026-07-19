namespace Storybook.Engine;

/// <summary>
/// What kind of screen a passage is - the thing the host's five Inspector-populated
/// routing lists (genHubEPassageList, endingPassageList, ...) used to decide, and
/// which the story's HUB / INTRO / END tags shadowed.
///
/// The other Twine tags (ck, revised, NEW, temp, CODINGHELP, ...) were the author's
/// editorial marks. Nothing in the app ever read any tag, so they are not carried over.
/// </summary>
public enum PassageKind
{
    /// <summary>A reading screen: prose and links.</summary>
    Normal,

    /// <summary>Generation or chapter opener.</summary>
    Intro,

    /// <summary>A round hub - collects hub rows and ends with a round-end link.</summary>
    Hub,

    /// <summary>A terminal ending.</summary>
    Ending
}

/// <summary>
/// One story passage. Replaces Cradle's StoryPassage + IStoryThread coroutine:
/// the body writes into the context instead of yielding output commands.
/// </summary>
public sealed class Passage
{
    public string Name { get; }
    public PassageKind Kind { get; }
    public Action<StoryContext> Body { get; }

    public Passage(string name, PassageKind kind, Action<StoryContext> body)
    {
        Name = name;
        Kind = kind;
        Body = body;
    }
}
