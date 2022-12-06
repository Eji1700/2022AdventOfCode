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
        |> Seq.map charToPriority // Putting the maps next to each other means i could reduce this to map(x >> y) but don't want to bother right now.
        |> Seq.splitInto 2
        |> Seq.map(fun intSack -> intSack |> Set.ofArray ) // Feel like maybe there's a Seq.function that does this cleaner but I couldn't find it?
        |> Set.intersectMany
        |> Set.maxElement  // uhhh...got to be a better way to do this?
    )
    |> Seq.sum

let Answer2 = // Got this one pretty quickly but I hate it?  Again i could probably find a way to reduce the double map to map(x>>y), but even then I feel like this is...obtuse?
    data
    |> Seq.map(fun ruckSacks ->
        ruckSacks
        |> Seq.map charToPriority
    )
    |> Seq.chunkBySize 3
    |> Seq.map(fun groupSacks ->
        groupSacks |> Array.map Set.ofSeq |> Set.intersectMany |> Set.maxElement
    )
    |> Seq.sum

Answer1
Answer2