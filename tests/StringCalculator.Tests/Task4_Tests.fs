namespace StringCalculator.tests

open Xunit
open StringCalculator.Core

module Task4_Tests =

    [<Fact>]
    let ``new delimiter format`` () =
        let result = add "//;\n1;2"
        Assert.Equal(3, result)
