open System
open System.IO

let inputData = File.ReadAllLines @".\Day5\input.txt"

let board = inputData |> Array.take 8
let instuctions = inputData |> Array.where(fun entry -> entry.StartsWith "move")

let cellParse (cell: char[]) = 
    if cell[0] = '[' then cell[1].ToString()
    else " "

let boardParse boardArr =
    boardArr
    |> Array.map( fun row ->
        row 
        |> Seq.splitInto 9
        |> Seq.map cellParse 
        |> Seq.toArray
    ) 
    |> Array.transpose
boardParse board

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

Instruction.Parse instuctions
