
open System.IO

let inputData = File.ReadAllLines @".\Day4\input.txt"

let getStartandEnd (assignment: string) =
    let arr = assignment.Split("-")
    int arr[0],  int arr[1]

let isBetween a b c =
    b >= a && b <= c 

let findFullyContainedRange (elf1Start, elf1End) (elf2Start, elf2End) =
    if elf1Start <= elf2Start && elf1End >= elf2End then
        Some 1
    elif elf2Start <= elf1Start && elf2End >= elf1End then 
        Some 1
    else
        None 

let findRangeOverlap (elf1Start, elf1End) (elf2Start, elf2End) =
    if isBetween elf1Start elf2Start elf1End then 
        Some 1
     elif isBetween elf2Start elf1Start elf2End then 
        Some 1
    else 
        None

let Answer1 =
    inputData
    |> Array.choose(fun pair ->
        let arr = pair.Split(",")
        let elf1 = getStartandEnd arr[0]
        let elf2 = getStartandEnd arr[1]
        findFullyContainedRange elf1 elf2   
    )
    |> Array.length

let Answer2 = 
    inputData
    |> Array.choose(fun pair ->
        let arr = pair.Split(",")
        let elf1 = getStartandEnd arr[0]
        let elf2 = getStartandEnd arr[1]
        findRangeOverlap elf1 elf2   
    )
    |> Array.length


Answer1
Answer2