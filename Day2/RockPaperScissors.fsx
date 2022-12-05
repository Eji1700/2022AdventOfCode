// This is a mess as I try to elegantly model it and give up and just brute force it.
// This is what insanity looks like.
// Got a liiiiitle closer to something clever on part 2, but still not there
open System.IO

let inputData = File.ReadAllLines @"input.txt"

type Throw =
    | Rock of int
    | Paper of int 
    | Scissors of int

module Throw =  
    // Unused, realized i needed to do both the win and loss and just brute forced it.
    let Hirearchy throw =
        match throw with 
        | Rock _ -> Paper 2
        | Paper _ -> Scissors 3
        | Scissors _ -> Rock 1

    let private fullConvert rockValue paperValue scissorsValue input =
        if input = "A" || input = "X" then Rock rockValue
        elif input = "B" || input = "Y" then Paper paperValue
        elif input = "C" || input = "Z" then Scissors scissorsValue
        else failwith $"bad input {input}"

    let private fullConvert2 rockValue paperValue scissorsValue input =
        if input = "A" then Rock rockValue
        elif input = "B" then Paper paperValue
        elif input = "C" then Scissors scissorsValue
        else failwith $"bad input {input}"


    let Convert = fullConvert 1 2 3    
    let Convert2 = fullConvert2 1 2 3
type Round =
    {   Opponent:Throw
        Player:Throw }

type Outcome =
    | Loss of int 
    | Draw of int
    | Win of int

module Outcome =
    let Convert input =
        if input = "X" then Loss 0
        elif input = "Y" then Draw 3
        elif input = "Z" then Win 6
        else failwith $"bad input {input}"

type Round2 =
    {   Opponent:Throw
        Outcome: Outcome }

module Round =
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

module Round2 =
    let Calculate round = 
        match round.Opponent, round.Outcome with
        | Rock _, Loss o -> 3 + o
        | Rock t, Draw o -> t + o
        | Rock _, Win o -> 2 + o
        | Paper _, Loss o -> 1 + o
        | Paper t, Draw o -> t + o
        | Paper _, Win o -> 3 + o
        | Scissors _, Loss o -> 2 + o
        | Scissors t, Draw o -> t + o
        | Scissors _, Win o -> 1 + o

let Answer1 =
    inputData
    |> Array.map(fun round->
        let throws = round.Split(" ")
        {   Opponent = Throw.Convert throws.[0]
            Player = Throw.Convert throws.[1] }
    )
    |> Array.map Round.Calculate 
    |> Array.sum
    
let Answer2 =
    inputData
    |> Array.map(fun round2 ->
        let strategy = round2.Split(" ")
        {   Opponent = Throw.Convert2 strategy.[0]
            Outcome = Outcome.Convert strategy.[1] }
    )
    |> Array.map Round2.Calculate
    |> Array.sum
    
Answer1 
Answer2