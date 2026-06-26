// https://tableconvert.com/excel-to-csv

Console.WriteLine("Choose the target:");
Console.WriteLine("1. UI_Localization");
Console.WriteLine("2. TheCostOfDisease_Localization");
Console.WriteLine("3. TheCostOfDisease_Gameplay_Localization");

string targetFileSelection = Console.ReadLine()!;

string filePath = targetFileSelection switch
{
    "1" => "UI_Localization.csv",
    "2" => "TheCostOfDisease_Localization.csv",
    "3" => "TheCostOfDisease_Gameplay_Localization.csv",
    _   => throw new Exception($"Failed to find target {targetFileSelection}")
};

string targetFile = File.ReadAllText(Path.Combine("..", "..", "..", "..", "MyFathersWorkWebApp", "wwwroot", "localization", filePath));

Console.WriteLine("Choose column to merge:");
string columnName = Console.ReadLine()!;

string sourceFile = File.ReadAllText("Source.csv");

string[] targetLines = targetFile.Split(new[] { '\r', '\n' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
string[] sourceLines = sourceFile.Split(new[] { '\r', '\n' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();

int targetColumnId = -1;
int sourceColumnId = -1;

string[] tmp = targetLines[0].Split(";");

for (int x = 0; x < tmp.Length; ++x)
{
    if (tmp[x] != columnName) continue;
    targetColumnId = x;
    break;
}

if (targetColumnId == -1) throw new Exception($"Failed to find target column {columnName}");

tmp = sourceLines[0].Split(";");

for (int x = 0; x < tmp.Length; ++x)
{
    if (tmp[x] != columnName) continue;
    sourceColumnId = x;
    break;
}

if (sourceColumnId == -1) throw new Exception($"Failed to find source column {columnName}");

foreach (string line in sourceLines)
{
    tmp = line.Split(";");
    if (tmp[0] == "Tag") continue;

    string tag      = tmp[0];
    string newValue = tmp[sourceColumnId];

    for (int x = 0; x < targetLines.Length; ++x)
    {
        tmp = targetLines[x].Split(";");

        if (tmp[0] != tag) continue;

        bool spaceAtTheEnd                                 = tmp[1][^1] == ' ';
        if (spaceAtTheEnd && newValue[^1] != ' ') newValue += ' ';

        bool spaceAtTheStart                                = tmp[1][0] == ' ';
        if (spaceAtTheStart && newValue[0] != ' ') newValue = ' ' + newValue;

        tmp[targetColumnId] = newValue;
        targetLines[x]      = string.Join(";", tmp);
        break;
    }
}

File.WriteAllLines(Path.Combine("..", "..", "..", "..", "MyFathersWorkWebApp", "wwwroot", "localization", filePath), targetLines);