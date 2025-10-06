// Red phase test
// Select the location of the file
namespace StringCalculator.Tests

// call the framework
open Xunit

// connect to the core module of my app. (I haven't create it yet. Red phase of TDD first)

open StringCalculator.Core

// Group all the task tests
module Task1_Tests = 
    // First test. If the string is empty... return 0
    // Fact tells xUnit that this is a test
    [<Fact>]
    // This is the function of the test. it can also be written as Empty_string_returns_0 whitout the backticks.
    let ``Empty string returns 0`` () =
        let result = add ""
        Assert.Equal(0, result)

    // tell Xunit that this is another test
    [<Fact>]
    // This is the function. It delcares that two comma separated numbers of a string add themselves. 
    let ``Sum two comma separated numbers`` () =
        let result = add "4,3"
        Assert.Equal(7, result)

    // Assert.Equal its a verification tool of Xunit that basically says check (assert) that the result are equal (Equal). Expected and actual result. 
