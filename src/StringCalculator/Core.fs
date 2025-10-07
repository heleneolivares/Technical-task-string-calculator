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
            let numbers =
                numberString
                    .Split(delimiters, StringSplitOptions.None)
                |> Array.map (fun s -> s.Trim())
                |> Array.filter (fun s -> s <> "")
                |> Array.map int

            let negatives = numbers |> Array.filter (fun n -> n < 0)

            if negatives.Length > 0 then   
                let message = "negatives not allowed: " + String.Join(", ", negatives)
                raise (ArgumentException(message))
                
            
            numbers
            |> Array.filter(fun n -> n <= 1000)
            |> Array.sum

    