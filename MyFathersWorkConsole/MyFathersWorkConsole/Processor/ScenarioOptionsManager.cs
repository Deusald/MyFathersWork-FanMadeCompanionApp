namespace MyFathersWorkConsole;

public class ScenarioOptionsManager
{
    private readonly List<(string, Action)> _options = new();

    public void AddOption(string label, Action action)
    {
        _options.Add((label, action));
    }

    public void PresentOptions()
    {
        if (_options.Count == 0)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            return;
        }
        
        if (_options.Count == 1)
        {
            Console.WriteLine(_options[0].Item1);
            Console.ReadLine();
            _options[0].Item2.Invoke();
            return;
        }
        
        Console.WriteLine("==============================");
        Console.WriteLine("Select an action:");
        
        for (int i = 0; i < _options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_options[i].Item1}");
        }
        
        Console.Write("\n> ");
        int choice = 0;
        while (choice < 1 || choice > _options.Count)
        {
            int.TryParse(Console.ReadLine(), out choice);
        }

        Console.Clear();
        _options[choice - 1].Item2.Invoke();
    }
}