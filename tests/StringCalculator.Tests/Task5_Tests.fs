namespace StringCalculator.tests

open Xunit
open StringCalculator.Core
open System

module Task5_Tests =

    [<Fact>]
    let `` negatives not allowed`` () = 
        let ex = Assert.Throws<ArgumentException>(fun () -> add "1,-2,-3" |> ignore)
        Assert.Equal("negatives not allowed: -2, -3", ex.Message)