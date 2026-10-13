# Scenario Branching Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Break the 34 commits on `main` into 4 clean, independent local branches off `origin/main` (`chore/misc-tooling`, `scenario/the-cost-of-disease`, `scenario/fear-of-the-unknown`, `scenario/a-time-of-war`), each compiling with 0 errors, while keeping `main` fully integrated.

**Architecture:** Each scenario branch branches off `origin/main`, including `Directory.Build.props` (so MSBuild doesn't crash on Git's `reftable` storage) and required UI extensions, followed by organized, logical commits for that scenario's state, chapters, endings, localization, and GlobalData wiring. `chore/misc-tooling` contains standalone tooling (`run.sh`, build properties, csproj updates).

**Tech Stack:** Git, .NET 9.0 SDK, Blazor WebAssembly, C#.

**Spec:** User request: "break the commits into 3 branches, one for each scenario added and potentially a 4th for misc thigns that were added if they dont fit in one specific branch" using independent branches and names `scenario/the-cost-of-disease`, `scenario/fear-of-the-unknown`, `scenario/a-time-of-war`, and `chore/misc-tooling`.

## Global Constraints
- Zero Push: Do NOT push any branch or commit to `origin` / GitHub.
- Every branch MUST compile cleanly with `dotnet build` (0 Errors, 0 Warnings).
- `main` branch must remain intact with all 3 scenarios integrated.

---

### Task 1: Create `chore/misc-tooling` branch

- [ ] **Step 1: Create branch from `origin/main`**
  `git checkout -b chore/misc-tooling origin/main`

- [ ] **Step 2: Commit build and tooling files**
  - Add `MyFathersWorkWebApp/Directory.Build.props`
  - Add `MyFathersWorkWebApp/MyFathersWorkWebApp/MyFathersWorkWebApp.csproj` localization copy targets
  - Add `run.sh`

- [ ] **Step 3: Verify build**
  Run `/usr/local/google/home/roccomanzo/.local/bin/dotnet build MyFathersWorkWebApp/MyFathersWorkWebApp.sln`

---

### Task 2: Create `scenario/the-cost-of-disease` branch

- [ ] **Step 1: Create branch from `origin/main`**
  `git checkout -b scenario/the-cost-of-disease origin/main`

- [ ] **Step 2: Add build infrastructure and state variables**
  Add `Directory.Build.props`, `CostOfDiseaseHubId.cs`, `PanaceaVal.cs`, `TheCostOfDiseaseVars.cs`, `PopUpIcon.cs` additions.

- [ ] **Step 3: Add Gen 3 chapters and shared endings**
  Add `04_TheCostOfDisease_Gen3_GloomyGothic.cs`, `05_TheCostOfDisease_Gen3_Prosperity.cs`, `06_TheCostOfDisease_Gen3_NoUniversity.cs`, `07_TheCostOfDisease_Gen3_University.cs`, `08_TheCostOfDisease_SharedAndEndings.cs`.

- [ ] **Step 4: Add localization and wire into GlobalData**
  Add `TheCostOfDisease_Localization.csv` and `TheCostOfDisease_Gameplay_Localization.csv`. Update `GlobalData.cs` and `GameplayWindow.cs` / `GameplayPopup.cs` overloads.

- [ ] **Step 5: Verify build**
  Run `dotnet build` and ensure 0 errors.

---

### Task 3: Create `scenario/fear-of-the-unknown` branch

- [ ] **Step 1: Create branch from `origin/main`**
  `git checkout -b scenario/fear-of-the-unknown origin/main`

- [ ] **Step 2: Add engine prerequisites and scenario state**
  Add `Directory.Build.props`, `GameplayPopup.cs`, `GameplayWindow.cs`, `GameplayHubSection.cs`, `FearOfUnknownHubId.cs`, `FearOfTheUnknownVars.cs`, and `PopUpIcon.cs` constants.

- [ ] **Step 3: Add Gen 1, Gen 2, Gen 3 chapters and shared endings**
  Add all 8 chapters (`01_` through `08_FearOfTheUnknown_*.cs`).

- [ ] **Step 4: Add localization and wire scenario into GlobalData launcher**
  Add `FearOfTheUnknown_Localization.csv`, `FearOfTheUnknown_Gameplay_Localization.csv`, update `GlobalData.cs` and `PlayersScenarioLanguage.razor`.

- [ ] **Step 5: Verify build**
  Run `dotnet build` and ensure 0 errors.

---

### Task 4: Create `scenario/a-time-of-war` branch

- [ ] **Step 1: Create branch from `origin/main`**
  `git checkout -b scenario/a-time-of-war origin/main`

- [ ] **Step 2: Add engine prerequisites and scenario state**
  Add `Directory.Build.props`, `GameplayPopup.cs`, `GameplayWindow.cs`, `GameplayHubSection.cs`, `TimeOfWarHubId.cs`, `ATimeOfWarVars.cs`, and `PopUpIcon.cs` constants.

- [ ] **Step 3: Add Gen 1, Gen 2, Gen 3 chapters and shared endings**
  Add all 8 chapters (`01_` through `08_ATimeOfWar_*.cs`).

- [ ] **Step 4: Add localization and wire scenario into GlobalData launcher**
  Add `ATimeOfWar_Localization.csv`, `ATimeOfWar_Gameplay_Localization.csv`, update `GlobalData.cs` and `PlayersScenarioLanguage.razor`.

- [ ] **Step 5: Verify build**
  Run `dotnet build` and ensure 0 errors.

---

### Task 5: Return to `main` and verify

- [ ] **Step 1: Switch back to `main`**
  `git checkout main`

- [ ] **Step 2: Verify `dotnet build` on `main`**
  Confirm all 3 scenarios build cleanly with 0 warnings, 0 errors.

- [ ] **Step 3: Verify all 4 local branches exist**
  `git branch -v`
