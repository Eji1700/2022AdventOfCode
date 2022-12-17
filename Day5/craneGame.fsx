
open System.IO

let inputData = File.ReadAllLines @".\Day5\input.txt"

let board = inputData |> Array.take 8
let instuctions = inputData |> Array.where(fun entry -> entry.StartsWith "move")
let boardParse =
    board
    |> Array.map( fun row ->
        row 
        |> Seq.splitInto 9
    )
boardParse