open System.IO

// let data = File.ReadAllLines @".\Day3\input.txt"

let charToPriority (c:char) =
    let charInt = int c
    if charInt >= 65 && charInt <= 90 then
        charInt - 38
    elif charInt >= 97 && charInt <= 122 then 
        charInt - 96
    else
        charInt
charToPriority 'z'
