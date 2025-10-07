namespace StringCalculator

module Core = 
    open System
    let add (input: string) : int = 
        if String.IsNullOrWhiteSpace(input) then 
            0
        else
            let delimiters, numberString =
                if input.StartsWith("//") then
                    let parts = input.Split('\n', 2)
                    let firstPart = 
                        if parts.Length > 0 then parts.[0] else ""
                    let secondPart = 
                        if parts.Length > 1 then parts.[1] else ""
                    let separator = firstPart.Substring(2)
                    [| separator; ","; "\n" |], secondPart 
                else 
                [| ","; "\n"|], input
            numberString
                .Split(delimiters, StringSplitOptions.None)
            |> Array.map (fun s -> s.Trim())
            |> Array.filter (fun s -> s <> "")
            |> Array.map int
            |> Array.sum

    