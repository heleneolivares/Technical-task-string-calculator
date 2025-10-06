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

    // TESTING SOME OPTIONS
    [<Fact>]
    let ``Sum empty string`` () =
        let actual1 = add ",4"
        let actual2 = add "4,"
        Assert.Equal(4,actual1)
        Assert.Equal(4, actual2)

    [<Fact>]
    let ``Sum more than 2 numbers`` () = 
        let actual3 = add "4,5,7,5"
        let actual4 = add "3,0,3"
        Assert.Equal(9,actual3)
        Assert.Equal(3, actual4)

    [<Fact>]
    let ``sum space numbers`` () = 
        let actual5 = add " 1, 5 "
        Assert.Equal(6, actual5)