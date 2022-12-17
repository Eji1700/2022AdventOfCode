
open System.IO

let inputData = File.ReadAllLines @".\Day5\input.txt"

let board = inputData |> Array.take 8
let instuctions = inputData |> Array.where(fun entry -> entry.StartsWith "move")

let cellParse (cell: char[]) = 
    if cell[0] = '[' then cell[1].ToString()
    else " "

let boardParse =
    board
    |> Array.map( fun row ->
        row 
        |> Seq.splitInto 9
        |> Seq.map cellParse 
        |> Seq.toArray
    )
boardParse