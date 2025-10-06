namespace StringCalculator.tests

open Xunit
open StringCalculator.Core

module Task2_Tests =

    [<Fact>]
    let ``Multiple sum`` () =
        let result = add "10,20,30,4,5,6,7"
        Assert.Equal(82, result)
