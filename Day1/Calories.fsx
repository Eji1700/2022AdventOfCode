open System.IO

let inputData =  File.ReadLines "input.txt"
File.WriteAllLines(Directory.GetCurrentDirectory() + "/test.txt", inputData)