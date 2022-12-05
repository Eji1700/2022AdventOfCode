// This is a mess as I try to elegantly model it and give up and just brute force it.
// This is what insanity looks like.
open System.IO

let inputData = File.ReadAllLines @"input.txt"

type Throw =
    | Rock of int
    | Paper of int 
    | Scissors of int

module Throw =  
    let private fullConvert rockValue paperValue scissorsValue input =
        if input = "A" || input = "X" then Rock rockValue
        elif input = "B" || input = "Y" then Paper paperValue
        elif input = "C" || input = "Z" then Scissors scissorsValue
        else failwith $"bad input {input}"

    let Convert = fullConvert 1 2 3    

type Round =
    {   Opponent:Throw
        Player:Throw }

module Outcome =
    let Calculate (input: Round) =
        // There is some really clever and elegant way to do this
        // This is not it
        // Look upon my failure ye mighty and be aware that I spent
        // WAAAAY too much time trying to do active patterns for this.
        match input.Opponent, input.Player with
        | Rock _, Paper i -> i + 6
        | Rock _, Rock i -> i + 3
        | Rock _, Scissors i -> i + 0
        | Paper _, Scissors i -> i + 6
        | Paper _, Paper i -> i + 3
        | Paper _, Rock i -> i + 0
        | Scissors _, Rock i -> i + 6
        | Scissors _, Scissors i -> i + 3
        | Scissors _, Paper i -> i + 0


let Answer1 =
    inputData
    |> Array.map(fun round->
        let throws = round.Split(" ")
        {   Opponent = Throw.Convert throws.[0]
            Player = Throw.Convert throws.[1] }
    )
    |> Array.map Outcome.Calculate 
    |> Array.sum
    
Answer1 