
namespace StringCalculator.tests

open Xunit
open StringCalculator.Core

module Task3_Tests =

    [<Fact>]
    let ``newlines and commas`` () =
        let result = add "\n1\n2,\n3,\n5"
        Assert.Equal(11, result)
