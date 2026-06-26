using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace MyFathersWorkWebApp;

public class GlobalData
{
    private class UndoData
    {
        public Action<GlobalData>? Callback { get; set; }
        public string              JsonData { get; set; } = string.Empty;
    }

    [JsonIgnore] public Dictionary<string, Dictionary<string, string>> UI_Localization                { get; }      = new();
    [JsonIgnore] public Dictionary<string, string>                     Scenario_Localization          { get; set; } = new();
    [JsonIgnore] public Dictionary<string, string>                     Scenario_Gameplay_Localization { get; set; } = new();
    [JsonIgnore] public List<string>                                   OtherPossibleScenarioLanguages { get; set; } = new();

    public string Language         { get; set; } = "English";
    public string ScenarioLanguage { get; set; } = "English_Source";

    public ScenarioId                 ScenarioId           { get; set; }
    public int                        PlayersNum           { get; set; }
    public string                     PlayerAName          { get; set; } = string.Empty;
    public string                     PlayerBName          { get; set; } = string.Empty;
    public string                     PlayerCName          { get; set; } = string.Empty;
    public string                     PlayerDName          { get; set; } = string.Empty;
    public string                     TownName             { get; set; } = string.Empty;
    public Years                      Years                { get; set; } = Years.Early;
    public Generation                 Generation           { get; set; } = Generation.First;
    public TheCostOfDiseaseVars       TheCostOfDiseaseVars { get; }      = new();
    public Dictionary<string, object> TmpValues            { get; }      = new();

    [JsonIgnore] public GameplayHub?        ActiveHub        { get; set; }
    [JsonIgnore] public GameplayWindow?     ActiveWindow     { get; set; }
    [JsonIgnore] public GameplayPopup?      ActivePopup      { get; set; }
    [JsonIgnore] public GameplayInputPopup? ActiveInputPopup { get; set; }

    [JsonIgnore] private Stack<UndoData> UndoStack { get; } = new();

    [JsonIgnore] public bool IsUndoDisabled => UndoStack.Count <= 1;

    [JsonIgnore] private bool _UndoInProgress;

    public GlobalData()
    {
        TheCostOfDiseaseVars.Reset(this);
    }

    public string GetLocalizedUITag(string tag)
    {
        if (UI_Localization.TryGetValue(Language, out Dictionary<string, string>? value))
        {
            if (value.TryGetValue(tag, out string? translation)) return translation;
            return $"Missing Translation -> {Language}/{tag}";
        }

        return $"Missing Language -> {Language}";
    }

    public string GetScenarioLocalizedTag(string tag)
    {
        if (tag == string.Empty) return string.Empty;
        if (Scenario_Localization.TryGetValue(tag, out string? value)) return value;
        if (Scenario_Gameplay_Localization.TryGetValue(tag, out value)) return value;
        return $"Missing Scenario Translation -> {tag}";
    }

    public T GetTmpValue<T>(string key)
    {
        return (T)TmpValues.GetValueOrDefault(key)!;
    }

    public void SaveToUndo([CallerMemberName] string methodName = "")
    {
        if (_UndoInProgress) return;

        switch (ScenarioId)
        {
            case ScenarioId.CostOfDisease:
            {
                MethodInfo         method = typeof(TheCostOfDisease).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)!;
                Action<GlobalData> action = (Action<GlobalData>)Delegate.CreateDelegate(typeof(Action<GlobalData>), method);
                UndoStack.Push(new UndoData
                {
                    Callback = action,
                    JsonData = JsonConvert.SerializeObject(this)
                });
                break;
            }
        }
    }

    public void ResetUndo()
    {
        UndoStack.Clear();
    }

    public int LocalizedPlayerNumberIndex()
    {
        return PlayersNum - 2;
    }

    public string GetPlayerNameByIndex(int index)
    {
        return index switch
        {
            0 => PlayerAName,
            1 => PlayerBName,
            2 => PlayerCName,
            3 => PlayerDName,
            _ => string.Empty
        };
    }

    public void ShowEndOfRoundPopUp(Action<GlobalData> nextCallback)
    {
        ActivePopup = new GameplayPopup(this, PopUpTitle.EndOfRound, PopUpIcon.MFWlogo, PopUpButton.Confirm, _ =>
            {
                Generation prevGeneration = Generation;

                if (Years == Years.Late)
                {
                    Years      =  Years.Early;
                    Generation += 1;
                }
                else
                {
                    Years += 1;
                }

                if (prevGeneration != Generation) ActiveHub = null;
                else ActiveHub!.SetSubtitle(Years);

                nextCallback(this);
            }, GlobalTags.Gameplay_EndOfRound_Content,
            content => content.FormatWithIndex(3, (int)Years + 1)
                              .FormatWithCondition(2, () => Years is Years.Early or Years.Middle)
                              .FormatWithIndex(1, (int)Generation)
                              .FormatWithIndex(0, (int)Years));
    }

    public string[] GetActivePlayers()
    {
        string[] result = new string[PlayersNum];
        result[0] = PlayerAName;
        result[1] = PlayerBName;
        if (PlayersNum >= 3) result[2] = PlayerCName;
        if (PlayersNum >= 4) result[3] = PlayerDName;
        return result;
    }

    public async Task<bool> IsContinueAvailableAsync(IJSRuntime js)
    {
        string? base64 = await js.InvokeAsync<string?>("localStorage.getItem", "continue");
        return !string.IsNullOrEmpty(base64);
    }

    public void Undo()
    {
        if (UndoStack.Count <= 1) return;
        _UndoInProgress = true;
        UndoStack.Pop();
        UndoData prev = UndoStack.Peek();
        ActiveHub        = null;
        ActiveWindow     = null;
        ActivePopup      = null;
        ActiveInputPopup = null;

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Reuse,
            NullValueHandling      = NullValueHandling.Ignore
        };
        JsonConvert.PopulateObject(prev.JsonData, this, settings);
        GetHubMethod()?.Invoke(this);
        prev.Callback?.Invoke(this);
        _UndoInProgress = false;
    }

    public async void SaveGame(IJSRuntime js)
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        await js.InvokeVoidAsync("localStorage.setItem", "continue", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json)));
        Console.WriteLine("Saving game");
        if (_UndoInProgress || (UndoStack.Count != 0 && UndoStack.Peek().Callback == null)) return;
        UndoStack.Push(new UndoData
        {
            JsonData = json,
            Callback = null
        });
    }

    public async Task LoadGameAsync(string data, NavigationManager nav, HttpClient http, IJSRuntime js)
    {
        UndoStack.Clear();
        
        string? base64;

        if (string.IsNullOrEmpty(data))
        {
            base64 = await js.InvokeAsync<string?>("localStorage.getItem", "continue");
        }
        else base64 = data;

        if (string.IsNullOrEmpty(base64))
        {
            nav.NavigateTo("");
            return;
        }

        TheCostOfDiseaseVars.Reset(this);
        ActiveHub        = null;
        ActiveWindow     = null;
        ActivePopup      = null;
        ActiveInputPopup = null;

        string json = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Reuse,
            NullValueHandling      = NullValueHandling.Ignore
        };
        JsonConvert.PopulateObject(json, this, settings);

        Dictionary<string, Dictionary<string, string>> scenarioLocalizations         = new();
        Dictionary<string, Dictionary<string, string>> scenarioGameplayLocalizations = new();

        await LoadScenarioLanguagesOptionsAsync(nav, http, scenarioLocalizations, scenarioGameplayLocalizations);
        Scenario_Localization          = scenarioLocalizations[ScenarioLanguage];
        Scenario_Gameplay_Localization = scenarioGameplayLocalizations[scenarioLocalizations[ScenarioLanguage]["Gameplay_Lang"]];

        Action<GlobalData>? activeHub = GetHubMethod();

        if (activeHub == null)
        {
            nav.NavigateTo("");
            return;
        }

        activeHub(this);
        UndoStack.Push(new UndoData
        {
            JsonData = json,
            Callback = null
        });
    }

    public async Task LoadScenarioLanguagesOptionsAsync(NavigationManager nav, HttpClient http, Dictionary<string, Dictionary<string, string>> scenarioLocalizations,
                                                        Dictionary<string, Dictionary<string, string>> scenarioGameplayLocalizations)
    {
        string scenarioLocalization = ScenarioId switch
        {
            ScenarioId.CostOfDisease => "localization/TheCostOfDisease_Localization.csv",
            _                        => string.Empty
        };

        string scenarioGameplayLocalization = ScenarioId switch
        {
            ScenarioId.CostOfDisease => "localization/TheCostOfDisease_Gameplay_Localization.csv",
            _                        => string.Empty
        };

        if (scenarioLocalization == string.Empty || scenarioGameplayLocalization == string.Empty)
        {
            nav.NavigateTo("");
            return;
        }

        (await http.GetStringAsync(scenarioLocalization)).ProcessLocalizationFile(scenarioLocalizations);
        (await http.GetStringAsync(scenarioGameplayLocalization)).ProcessLocalizationFile(scenarioGameplayLocalizations);

        OtherPossibleScenarioLanguages.Clear();
        OtherPossibleScenarioLanguages.AddRange(scenarioLocalizations.Keys);
    }

    private Action<GlobalData>? GetHubMethod()
    {
        if (ScenarioId == ScenarioId.CostOfDisease)
        {
            return TheCostOfDiseaseVars.HubId switch
            {
                CostOfDiseaseHubId.Fever       => TheCostOfDisease.Fever,
                CostOfDiseaseHubId.Devastation => TheCostOfDisease.Devastation,
                CostOfDiseaseHubId.Hospital    => TheCostOfDisease.Hospital,
                _                              => null
            };
        }

        return null;
    }
}