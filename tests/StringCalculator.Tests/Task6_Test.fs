namespace StringCalculator.tests

open Xunit
open StringCalculator.Core
open System

module Task6_Tests =

    [<Fact>]
    let `` numbers over 100`` () = 
        let result = add "2,1001"
        Assert.Equal(2, result)