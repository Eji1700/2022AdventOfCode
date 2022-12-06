open System.IO

let data = File.ReadAllLines @".\Day3\input.txt"

let charToPriority (c:char) = // I know there's some clever way to do this but my life so far has not required it, so hacky it is
    let charInt = int c
    if charInt >= 65 && charInt <= 90 then
        charInt - 38
    elif charInt >= 97 && charInt <= 122 then 
        charInt - 96
    else
        failwith $"Invalid char {c} to int {charInt}"

let Answer1 =
    data
    |> Seq.map(fun ruckSacks ->
        ruckSacks
        |> Seq.map charToPriority
        |> Seq.splitInto 2
        |> Seq.map(fun intSack -> intSack |> Set.ofArray ) // Feel like maybe there's a Seq.function that does this cleaner but I couldn't find it?
        |> Set.intersectMany
        |> Set.maxElement  // uhhh...got to be a better way to do this?
    )
    |> Seq.sum

Answer1