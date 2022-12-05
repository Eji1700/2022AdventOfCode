// Code (or parts of) blatantly stolen from https://github.com/Eliemer/AdventOfCode2022
// I spend waaay to long on simple tasks and often overcomplicate them so I'm walking 
// through this better repo to better understand their much more elegant solution. 
// Even my reading of the input.txt was more of a mess, let alone my proposed split solution.
// Diiiiiid however find and fix a bug in one of their ealier versions.
open System
open System.IO

let inputData =  File.ReadLines @".\Day1\input.txt"

let splitBy (cond: 'a -> bool) (source: 'a seq) =
    let mutable i = 0

    source 
    |> Seq.groupBy(fun x ->
        if cond x then i <- i + 1
        i
    )
    |> Seq.map(fun entry -> snd entry)

let elfs = 
    inputData
    |> splitBy String.IsNullOrWhiteSpace
    |> Seq.map(fun elf ->
        elf
        |> Seq.choose(fun food -> // THe splitBy method above will have a "" entry at the start of every group but the first, so need to bounce those out.
            let res = Int32.TryParse food
            match res with 
            | true, i -> Some i 
            | false, _ -> None )
        |> Seq.sum )
    |> Seq.cache

let Answer1 =
    elfs
    |> Seq.max

let Answer2 =
    elfs
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum

Answer1
Answer2