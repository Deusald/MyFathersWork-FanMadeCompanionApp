namespace MyFathersWorkWebApp;

public class GameplayElement(string content, Action<GlobalData>? callback = null, bool fromNewLine = false)
{
    public string              Content     { get; } = content;
    public Action<GlobalData>? Callback    { get; } = callback;
    public bool                FromNewLine { get; } = fromNewLine;
}