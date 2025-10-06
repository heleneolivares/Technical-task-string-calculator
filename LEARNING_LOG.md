## Initial Setup 

### Step 1: Install .NET 8.0 (LTS) SDK 

** Decision: ** (Long Term Support), The most stable version.
** Challenge: ** Command `dotnet` not found.
** Solution: ** Created symlink to `usr/local/bin`.
** Learning: ** Installation on macOS usually requires PATH adjustments. 
** Source: ** (https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) 

### Step2: Why F# and Test Driven Development

** F# Purpose: ** promotes/encourages thinking in transformation, not steps. Instead of telling the computer how to do something, you define what the transformation should look like.
** TDD Purpose: ** (Test Driven Development) A workflow where you write test before code.
** Refelction: **  Usin TDD with F# feels like the right approach because both encourage planning before coding. Tdd force me to think what I expect and to think about possible errors before I start building. In simple words, they help me write cleaner, safer, and more intentional code. 

### Step 3: Project structure

I decided while searching for standard practices and functional programming principles for this type of project tho divide it into three main parts: 

- ** src/ ** Contains the main app code.
- ** tests/ ** contains the automated tests.
- ** .sln file ** a solution file that connects both projects and tell .NET how they relate

** Benefits: ** this separation makes the structure clean, modular, and professional. It also makes future scaling easier without breaking the structure.
