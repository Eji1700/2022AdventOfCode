
open System.IO

let inputData = File.ReadAllLines @".\Day5\input.txt"

let board = inputData |> Array.take 9
// let instuctions = inputData |> Array.takeWhile(fun entry -> entry.StartsWith "move")  Why doesn't this work?
let instuctions = inputData |> Array.splitAt 10 |> snd