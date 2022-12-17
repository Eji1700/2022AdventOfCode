
open System.IO

let inputData = File.ReadAllLines @".\Day5\input.txt"

let board = inputData |> Array.take 9
let instuctions = inputData |> Array.where(fun entry -> entry.StartsWith "move")
