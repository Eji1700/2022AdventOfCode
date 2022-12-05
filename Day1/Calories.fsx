// Code (or parts of) blatantly stolen from https://github.com/Eliemer/AdventOfCode2022
// I spend waaay to long on simple tasks and often overcomplicate them so I'm walking 
// through this better repo to better understand their much more elegant solution. 
// Even my reading of the input.txt was more of a mess, let alone my proposed split solution.
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
    |> Seq.map
        (Seq.tail 
        >> (Seq.map Int32.Parse)
        >> Seq.sum)
    |> Seq.cache

let Answer1 =
    elfs
    |> Seq.max

let Answer2 =
    elfs
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum

Answer2