namespace StringCalculator

module Core = 
    open System
    let add (numbers: string) : int = 
    //conditional statements for the program to understand what to do in each case.
    // if the string is null or have white space or its empty should return 0.
        if String.IsNullOrWhiteSpace(numbers) then 
            0
        // If the string is not empty or null do this: 
        else 
            // split by comma, skip truly empty entries. 
            numbers.Split([|','|], StringSplitOptions.RemoveEmptyEntries)
            // remove surrounding spaces. for example if " 1" it change it to "1"
            // Array.map takes each element of the array and apply a function an return a new array. 
            // (fun s) is a function that took each s (each element of the array) and as a result ->  s.Trim() take balnk spaces and tabs at the beaginign and end of the text.
            |> Array.map (fun s -> s.Trim())
            // stay with two numbers only
            |> Array.truncate 2
            // convert into intergers
            |> Array.map int
            //sum them
            |> Array.sum