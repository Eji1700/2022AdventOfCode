open System
open System.IO

let inputData = File.ReadAllLines @".\Day5\input.txt"

let instuctionsArr = inputData |> Array.where(fun entry -> entry.StartsWith "move")
let boardArr = inputData |> Array.take 8

type Instruction =
    {   Qty: int
        Source: int
        Destination: int }

module Instruction =
    let private isInt (s:string) =
        match Int32.TryParse s with
        | true, v -> Some v
        | false, _ -> None

    let Parse (instructionArr: string []) =
        instructionArr
        |> Array.map(fun instruction ->
            instruction.Split " "
            |> Array.choose isInt
            |> fun arr ->
                {   Qty = arr[0]
                    Source = arr[1]
                    Destination = arr[2] }
        )

let instructions = Instruction.Parse instuctionsArr

let cellParse (cell: char[]) = 
    if cell[0] = '[' then cell[1].ToString() |> Some
    else None

let boardParse boardArr =
    boardArr
    |> Array.map( fun row ->
        row 
        |> Seq.splitInto 9
        |> Seq.toList ) 
    |> List.transpose
    |> List.map(fun lst ->
        lst
        |> List.choose cellParse
    )
let board = boardParse boardArr

let followInstruction inst (board: string list list) =
    let moves, newSource =
        board[inst.Source - 1]
        |> List.splitAt inst.Qty

    let newDest =
        moves
        |> List.rev
        |> fun m -> m @ board[inst.Destination - 1] 

    board
    |> List.mapi(fun i col ->
        if i = inst.Source - 1 then newSource
        elif i = inst.Destination - 1 then newDest
        else col
    )

followInstruction instructions[0] board