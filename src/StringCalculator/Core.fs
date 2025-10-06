namespace StringCalculator

module Core = 
    open System
    let add (numbers: string) : int = 
        if String.IsNullOrWhiteSpace(numbers) then 
            0
        else 
            numbers.Split([|','; '\n'|], StringSplitOptions.RemoveEmptyEntries)
            |> Array.map (fun s -> s.Trim())
            |> Array.filter (fun s -> s <> "")
            |> Array.map int
            |> Array.sum

    