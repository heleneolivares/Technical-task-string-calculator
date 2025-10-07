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
- **This first task** helped me understand how to start building functionality step by step. I learned to focused on writing a small test first, seeing it fail, and then implementing the minimum code required to make it pass. This rythim helped me stay focused and prevented me from overcomplicating the funcion too early. 
Technically I faced two issues: 

    1. ProjectReference path on macOS: I generated a .fsproj that used windows backslashes (\) in the <ProjectReference> and on macOs the past must be forward slashes (/)
    otherwise the test project can't see the src project. 
    2. Compiler couldn't find StringCalculator.core and add: In phase 2 of MiniTask1 the errors didn't go away because I hadn't include Core.fs in the src/ .fsproj file. 
Fixing these mistakes helped me understand how .fsproj files manage structure and dependencies.
For **Edge cases**, I first followed that the empty string("") should return 0. I used String.IsNullOrWhiteSpaces(numbers) to manage cases where input is null, empty, or just spaces. I algo learned how to trim and how to split prevent common input errors. These small steps made the function more stable.
Building clean and maintainable code is fundamental for understanding the pipeline. Using |> operator made the flow easier to read, lambda helped keep the function concise. Even though the task was quite simple, it tagught me how to think incrementally and anticipate edge cases.
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

## Task 3: 
**REFLECTION:** 
- The main challenge for me was to understand how to deal with different kinds of delimiters in the same string. When I did the test it fails because my app only accepted commas as a delimiters. So, I had to add to the Split the separator of a newline '\n'. To be sure, that this separator worked I try different types of test. "1,\n2,3", "\n1,\n2,\n3,\n4", "\n1,2,\n3", etc and in all of the test it passed. I also tested at the beginning for cases where I knew the test would fail. 

## Task 4: 
- The objective of this task is that I need to support delimiters that start in a format \\ at the beggining, followed by the [delimiter] and then a newline. So what is between the \\ and the newline is the delimiter. I do this adding codnitionals. if-else.
1. I changed the name of the variable numbers to input, because it don't recieve just numbers. 
2. I declared delimiters (stores the symbol that separates the numbers) and numberString (stores the part of the input that contains the numbers). 
3. I declared parts (storage the result of splitting the input in two parts), firstPart (before the newline), secondPart (after the newline). 
4. added condition to check if the input starts with // .
- if it does, I extract the separator using substring(2) which removes // and keeps the delimiter.
- Then I included in the list of delimiters as "separator"
- if it doesn't start with // it use the default delimiters. 

5. I keep using Split, Trim, Filter and Sum.

**Reflection:** 
When I first read the instructions for task 4 I was confused. but then while I was reading the example it made more sense. and I inmediatly thought in conditional logic. But I think the most interesting part was to understand the structure of the string before writing the conditional. I had to start thinking of this as "divide and conquer" I had to think of how to declare the condition, then divide the string in small parts then add a condition to that. So it was quite challenging. but when I divide the string in 2 parts became much easier to manage, to read, and to understand it. 
I also learned that the delimiter must be consistent across the entire string and that the Split function can recieve multiple delimiters at once. 
This task helped me undertand how to manipulate strings in a deeper way and reaffirmed that the best way to solve complex problems is to break them down into simple and logical parts.

## Task 5: 

**Reflection:** 
This task was a bit more complex than the previous ones because it wasn't just about numbers. Here, I had to add logic that checks for negative numbers and generates a clear message instead of calculating a sum result. 
To solve it, I used an if condition to detect the negative numbers after converting the inputs to integers.If any negative values were found. 
I created a message as the task solicitate, that includes all of them and raised an ArgumentEXception with taht message. This helped me understand how to communicate errors in a clear way and how exceptions can control the program's flow. 
What made this task so interesting for me is that it combined string manipulation, logic, and error habndling. I realized that building a function isnt just about producing correct results, but also about handling unexpected inputs. Overall, this task helped me think more like a developer. by this, I mean anticipating problems validating data and making my code more robust.

## Task 6: 

**Reflection:**
To do this task, I handle it by using an array filter that keeps only numbers less than or equal to 1000, ensuring that values like 1001 and above are excluded from the final result while 1000 is still included. 
Implementing this filter helped me understando how to control which data elements participate in a calculation and how a simple logical condition can change the output of a program. It also reinforced the importance of validating inputs and creating clear and explicit rules to manage edge cases. This step made the code more robust and adaptable to new requirementes without affectung the previous funcionalities. 