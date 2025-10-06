## Initial Setup 

### Step 1: Install .NET 8.0 (LTS) SDK 

- **Decision:** (Long Term Support), The most stable version.
- **Challenge:** Command `dotnet` not found.
- **Solution:** Created symlink to `usr/local/bin`.
- **Learning:** Installation on macOS usually requires PATH adjustments. 
- **Source:** (https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) 

### Step2: Why F# and Test Driven Development

- **F# Purpose:** promotes/encourages thinking in transformation, not steps. Instead of telling the computer how to do something, define what the transformation should look like.
- **TDD Purpose:** (Test Driven Development) A workflow where you write test before code.
- **Refelction:**  Usin TDD with F# feels like the right approach because both encourage planning before coding. Tdd force me to think what I expect and to think about possible errors before I start building. In simple words, they help me write cleaner, safer, and more intentional code. 

### Step 3: Project structure

I decided while searching for standard practices and functional programming principles for this type of project tho divide it into three main parts: 

- **src/** Contains the main app code.
- **tests/** contains the automated tests.
- **.sln file** a solution file that connects both projects and tell .NET how they relate

- **Benefits:** this separation makes the structure clean, modular, and professional. It also makes future scaling easier without breaking the structure.

## Task 1 

### Step 1: Files / folder structure

- **Folders:** Create folder src/ and tests/ 
- **File:** Create StringCalculator.sln (Terminal) 

### Step 2: Decide testing framework

- **Decision:** Use xUnit for Testing.
- **Reasoning:** microsoft recommmends it in their documentation, it integrates naturally with F# and supports TDD. 
- **Learning:** The testing framework choice affects the workflow significantly. xUnit simplifies it, and keeps the structure clean and mantainable. 

### Step 3: Connect and configure projects

- **Objective:** Link the main app and test modules inside the .sln file so they can interact. 

- **Process:** 
1. Create the main F# console app inside /src. 
2. Create the testing project with xUnit inside /tests. 
3. Add both projects to the solution file. 
4. Connect the test project to the main project.

- **Result:** The solution now contains two connected modules. (app and tests)
- **Challenge:** Understanding how .sln and .fsproj files interact and manage references. 
- **LEarning:** .sln works as a "Container" for multiple projects, and each .fsproj is a separate logical unit that communicate through references.
Organizing the app into small xomponents. Each project is independent in structure but connected in purpose.
- **Source:** [For reasoning in how to organize] (https://fsharpforfunandprofit.com/posts/organizing-functions/)

### Step 4: Add .gitignore

- **Reasoning:** Create the file to prevent temporary and/or system-specific files from beign push into te repository, maintaining a professional project structure. 

### Step 5: Divide and conquer 
1. Divide the big objective into small tasks (MiniTasks). 
    - **MiniTask 1:** Empty string returns 0
    - **MiniTask 2:** Sum two comma separated numbers from a string. 

2. Cover the 3 phases of TDD for **MiniTask 1:** 
    - **Phase 1:** Create the test focusing on the expected result. (an empty string returns 0). Run tests and it fails because the function doesn't exist yet. (RED phase)
    -  **Phase 2:** Create the minimum logic (Core.fs) to pass the test. 
        I create the function **add** and the parameters I put it as (_numbers: string) : int = 0 because I wanted to tell the app that im not using right now the value _numbers. so meanwhile every string should return an interger equal to zero. 
    - **Phase 3:** No changes needed. Code was already clean and complete because the MiniTask was explicit and simple. 

3. Cover the 3 phases of TDD for **MiniTask 2:**
    - **Phase 1:** Create the test focusing in the result expected (two numbers separated by a comma in a string add themselves) Run tests and it fails because **add** still return 0. 
    - **Phase 2:** Create the minimum core logic to pass the new test combining MiniTask1 and MiniTask2. 
        I mix the MiniTask 1 logic with the MiniTask 2 logic  by using conditionals (if-else). We declare the **MiniTask 1** in the **if** statement and the **MiniTask2** in the **else** statement.
        The **else** statement pipeline: 
        1. Split by comma and skip empty entries.
        2. Trim each piece.
        3. Keep at most two values
        4. Parse to integers
        5. Sum

### **Reflection:**

- **What went wrong:** 
    1. ProjectReference path on macOS: I generated a .fsproj that used windows backslashes (\) in the <ProjectReference> and on macOs the past must be forward slashes (/)
    otherwise the test project can't see the src project. 
    2. Compiler couldn't find StringCalculator.core and add: In phase 2 of MiniTask1 the errors didn't go away because I hadn't include Core.fs in the src/ .fsproj file. 
- **What I learned:** 
    1. TDD rhythm: even though I knew the theory of TDD I naver used before. so I applied by writing a failing test, then, adding the minimium code to pass the test nad then, refactor if needed. 
    2. Pipeline operator |>: "Take the result of previous step and pass it to the next function. 
    3. Lambda in F#: a tiny, anonymous function. 
    4. RemoveEmptyEntries versus whitespaces: it only drops empty "", not " ". That's why I added Trim() before parsing. 

## Task 2: 

### Step 1: 
- Create a Task2_Test.fs file inside the tests/StringCalculator.Tests. 

### Step2: 

- Add the basic to the file like namespace, conect Xunit, conect to StringCalcular.Corem and create a [<Fact>]

## Step3: 

- Create the function and add numbers to the string to test the App. This Test fails because the Core has an Arrays.truncate 2 which limite the data to 2.

## Step 4: 
- Delete the Array.truncate 2. Then, test it. 

**REFLECTION:** 
- Task 2 taught me how to evolve a simple function into a more generic one through small steps. Each refactor was guided by failing tests, ensuring stability. I also learned that handling unexpected or messy inputs early in the pipeline keeps the core logic clean and maintainable. This approach is what helped me the most. I only needed to remove a single line of code to complete task 2. 