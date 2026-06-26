using System.Text.RegularExpressions;

namespace MyFathersWorkConsole;

public static class TheStoryProcessor
{
    // optionsManager.AddOption("Click enter to continue...", MethodSpecialGen1);
    // optionsManager.AddOption("Click enter to continue...",  () => StaticGameState.PrintEndOfTheRoundText(1, 1, MethodFeverServe1));

    public static void Run()
    {
        ProcessScenario();
    }

    private static void ProcessScenario()
    {
        Dictionary<string, string> passageIdToMethodName = new();
        Dictionary<string, string> passageNumberToMethodName = new();
        List<List<string>> files = new();
        
        BaseProcess(passageIdToMethodName, passageNumberToMethodName, files);
        ChangeMainMethods(passageNumberToMethodName, ref files);
        ChangeSupportMethods(ref files);
        ChangeVariables(ref files);
        BasicCleaner(ref files);
        ChangeStyleScopes(ref files);
        ChangeLinks(passageIdToMethodName, ref files);
        ChangePassageTrackers(passageIdToMethodName, ref files);
        ChangeRandomMethods(ref files);
        SaveFiles(files);
    }

    private static void BaseProcess(Dictionary<string, string> passageIdToMethodName, Dictionary<string, string> passageNumberToMethodName, List<List<string>> files)
    {
        string path = Path.Combine("..", "..", "..", "Processor", "TheCostofDisease.txt");

        string[] lines = File.ReadAllLines(path);

        bool passageInitMode = false;
        string passageValue = "";
        int passagesCount = 0;
        List<string> currentFile = new();
        Match? match;

        foreach (string line in lines)
        {
            if (!passageInitMode && CheckRegex(line, @"private void passage(\d+)_Init\(\)", out match))
            {
                passageInitMode = true;
                passageValue = match!.Groups[1].Value;
                ++passagesCount;
                
                if (passagesCount % 45 != 0 || files.Count >= 8) continue;
                files.Add(currentFile);
                currentFile = new();
            }
            else if (passageInitMode)
            {
                match = Regex.Match(line, @"base\.Passages\[\s*""([^""]+)""\s*\]");

                if (match.Success)
                {
                    string passageName = match.Groups[1].Value;
                    string methodName = $"Method{Regex.Replace(passageName, @"[^a-zA-Z0-9_]", "")}";
                    passageIdToMethodName[passageName] = methodName;
                    passageNumberToMethodName[passageValue] = methodName;
                }
                else if (line == "}")
                {
                    passageInitMode = false;
                }
            }
            else
            {
                currentFile.Add(line);
            }
        }
        
        files.Add(currentFile);
    }

    private static void ChangeMainMethods(Dictionary<string, string> passageNumberToMethodName, ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();
        Match? match;
        bool skipLine = false;

        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                if (skipLine)
                {
                    skipLine = false;
                    continue;
                }
                
                // private IEnumerable<StoryOutput> passageXX_Main()
                if (CheckRegex(line, @"private IEnumerable<StoryOutput> passage(\d+)_Main\(\)", out match))
                {
                    string methodNumber = match!.Groups[1].Value;
                    newFile.Add($"private static void {passageNumberToMethodName[methodNumber]}()");
                    newFile.Add("{");
                    newFile.Add("Console.Clear();");
                    newFile.Add("ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();");
                    skipLine = true;
                }
                else if (line == "}")
                {
                    newFile.Add("optionsManager.PresentOptions();");
                    newFile.Add("}");
                }
                else
                {
                    newFile.Add(line);
                }
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }

    private static void ChangeSupportMethods(ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();
        bool skipLine = false;
        
        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                if (skipLine)
                {
                    skipLine = false;
                    continue;
                }
                
                if (line.Contains("private IEnumerable<StoryOutput> "))
                {
                    newFile.Add(line.Replace("private IEnumerable<StoryOutput> ", "private static void "));
                    newFile.Add("{");
                    newFile.Add("Console.Clear();");
                    newFile.Add("ScenarioOptionsManager optionsManager = new ScenarioOptionsManager();");
                    skipLine = true;
                }
                else
                {
                    newFile.Add(line);
                }
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }
    
    private static void ChangeVariables(ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();

        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                newFile.Add(line.Replace("this.Vars.", "StaticGameState.").Replace("this.ispasscode", "ispasscode").Replace("this.ispopup", "ispopup"));
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }
    
    private static void BasicCleaner(ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();

        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                if (line.Contains("yield break;")) continue;
                if (line.Contains("StyleScope styleScope = null;")) continue;
                if (line.Contains("StyleScope styleScope2 = null;")) continue;
                if (line.Contains("styleScope2 = null;")) continue;
                if (line.Contains("styleScope = null;")) continue;
                if (line.Contains("StyleScope styleScope3 = null;")) continue;
                if (line.Contains("styleScope3 = null;")) continue;
                if (line.Contains("ViewGenerationEnding.instance.EnableDisableContinueBtn(true);")) continue;
                
                if (line.Contains("yield return base.lineBreak();"))
                {
                    newFile.Add(line.Replace("yield return base.lineBreak();", "Console.WriteLine();"));
                    continue;
                }

                if (line.Contains("this.macros1.either(new StoryVar[]"))
                {
                    newFile.Add(line.Replace("this.macros1.either(new StoryVar[]", "StaticGameState.GetRandom(new[]").Replace("yield return base.text(", "Console.Write("));
                    continue;
                }
                
                newFile.Add(line.Replace("yield return base.text(", "Console.Write("));
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }

    private static void ChangeStyleScopes(ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();
        bool skipLine = false;
        Dictionary<string, string> replaceNext = new();
        
        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                if (skipLine)
                {
                    skipLine = false;
                    continue;
                }
                
                if (CheckRegex(line, @"using \(base\.styleScope\(""([^""]+)""", out Match? match))
                {
                    newFile.Add($"Console.Write(\"<{match!.Groups[1].Value}>\");");
                    replaceNext[Regex.Replace(line, @"[^\t]", "") + "}"] = $"Console.Write(\"</{match.Groups[1].Value}>\");";
                    skipLine = true;
                }
                else if (replaceNext.Remove(line, out string? replace))
                {
                    newFile.Add(replace);
                }
                else
                {
                    newFile.Add(line);
                }
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }
    
    private static void ChangeLinks(Dictionary<string, string> passageIdToMethodName, ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();

        Match? match;
        
        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                // yield return base.link("XX", null, () => base.enchantHook("XX", HarloweEnchantCommand.Replace, new Func<IEnumerable<StoryOutput>>(this.XX), false));
                if (line.Contains("yield return base.link(") && line.Contains("HarloweEnchantCommand.Replace, new Func<IEnumerable<StoryOutput>>(this."))
                {
                    string newLine = line.Replace("yield return base.link(", "").Replace("HarloweEnchantCommand.Replace, new Func<IEnumerable<StoryOutput>>(this.", ",")
                        .Replace(")", "");
                    string[] split = newLine.Split(',');
                    newFile.Add($"optionsManager.AddOption({split[0]}, {split.First(s => s.Contains("Fragment"))});");
                }
                // yield return base.link("XX", null, () => base.enchantHook("XX", HarloweEnchantCommand.None, new Func<IEnumerable<StoryOutput>>(this.XX), false));
                else if (line.Contains("yield return base.link(") && line.Contains("HarloweEnchantCommand.None, new Func<IEnumerable<StoryOutput>>(this."))
                {
                    string newLine = line.Replace("yield return base.link(", "").Replace("HarloweEnchantCommand.None, new Func<IEnumerable<StoryOutput>>(this.", ",")
                        .Replace(")", "");
                    string[] split = newLine.Split(',');
                    newFile.Add($"optionsManager.AddOption({split[0]}, {split.First(s => s.Contains("Fragment"))});");
                }
                // yield return base.enchant("XX", null, () => base.enchantHook("XX", HarloweEnchantCommand.Replace, new Func<IEnumerable<StoryOutput>>(this.XX), false));
                else if (line.Contains("yield return base.enchant(") && line.Contains("HarloweEnchantCommand.Replace, new Func<IEnumerable<StoryOutput>>(this."))
                {
                    string newLine = line.Replace("yield return base.enchant(", "").Replace("HarloweEnchantCommand.Replace, new Func<IEnumerable<StoryOutput>>(this.", ",")
                        .Replace(")", "");
                    string[] split = newLine.Split(',');
                    newFile.Add($"optionsManager.AddOption({split[0]}, {split.First(s => s.Contains("Fragment"))});");
                }
                // yield return base.abort("Something");
                else if (CheckRegex(line, @"yield return base\.abort\(""([^""]+)""\)", out match))
                {
                    newFile.Add($"{passageIdToMethodName[match!.Groups[1].Value]}();");
                }
                // yield return base.link("Click to Continue...", "NameEntryC", null);
                else if (CheckRegex(line, @"yield return base\.link\(""([^""]+)"",\s*""([^""]+)""", out match))
                {
                    newFile.Add($"optionsManager.AddOption(\"{match!.Groups[2].Value}\", {passageIdToMethodName[match.Groups[2].Value]});");
                }
                else
                {
                    newFile.Add(line);
                }
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }

    private static void ChangePassageTrackers(Dictionary<string, string> passageIdToMethodName, ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();

        Match? match;
        
        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                if (CheckRegex(line, @"PassageTracker\.instance\.CheckProgress\(""([^""]+)"",\s*""([^""]+)""\);", out match))
                {
                    newFile.Add($"StaticGameState.PrintEndOfTheRoundText(\"{match!.Groups[1].Value}\", {passageIdToMethodName[match!.Groups[2].Value]});");
                }
                else if (CheckRegex(line, @"ViewItemObtain\.SetupPassagename\s*=\s*""([^""]+)""", out match))
                {
                    newFile.Add($"optionsManager.AddOption(\"Continue...\", {passageIdToMethodName[match!.Groups[1].Value]});");
                }
                else
                {
                    newFile.Add(line);
                }
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }
    
    private static void ChangeRandomMethods(ref List<List<string>> files)
    {
        List<List<string>> newFiles = new();

        Match? match;
        
        foreach (List<string> file in files)
        {
            List<string> newFile = new();

            foreach (string line in file)
            {
                if (CheckRegex(line, @"this\.macros1\.random\(\s*([0-9.]+)\s*,\s*([0-9.]+)\s*\)", out match))
                {
                    newFile.Add(line.Replace($"this.macros1.random({match!.Groups[1].Value}, {match!.Groups[2].Value})", $"new Random().Next({(int)double.Parse(match!.Groups[1].Value)}, {(int)double.Parse(match!.Groups[2].Value)} + 1)"));
                }
                else
                {
                    newFile.Add(line);
                }
            }
            
            newFiles.Add(newFile);
        }

        files = newFiles;
    }
    
    private static void SaveFiles(List<List<string>> files)
    {
        for (int x = 0; x < files.Count; ++x)
        {
            string pathForCSharpFile = Path.Combine("..", "..", "..", "Processor", "Scenario", $"ScenarioPart_{x}.cs");
            if (!File.Exists(pathForCSharpFile))
            {
                FileStream stream = File.Create(pathForCSharpFile);
                stream.Dispose();
            }

            List<string> file = files[x];

            using (StreamWriter cSharpFile = new StreamWriter(pathForCSharpFile))
            {
                cSharpFile.WriteLine("namespace MyFathersWorkConsole;");
                cSharpFile.WriteLine("");
                cSharpFile.WriteLine("public static partial class Scenario");
                cSharpFile.WriteLine("{");

                foreach (string line in file) cSharpFile.WriteLine(line);

                cSharpFile.WriteLine("}");
            }
        }
    }

    private static bool CheckRegex(string line, string pattern, out Match? match)
    {
        match = Regex.Match(line, pattern);
        return match.Success;
    }
}