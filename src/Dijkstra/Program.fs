// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System
open TestFS

let inline (?|>) x f = Option.map f x
                
[<EntryPoint>]
let main argv = 
    let findShortestPath = 
        [
            { Origin = "1"; Destination = "2"; Distance = 7 }
            { Origin = "1"; Destination = "3"; Distance = 9 }
            { Origin = "1"; Destination = "6"; Distance = 14 }
            { Origin = "2"; Destination = "4"; Distance = 15 }
            { Origin = "2"; Destination = "3"; Distance = 10 }
            { Origin = "3"; Destination = "4"; Distance = 11 }
            { Origin = "3"; Destination = "6"; Distance = 2 }
            { Origin = "4"; Destination = "5"; Distance = 6 }
            { Origin = "5"; Destination = "6"; Distance = 9 }
        ]
        |> Seq.collect(fun x -> [ x; { x with Origin = x.Destination; Destination = x.Origin } ])
        |> Seq.groupBy(fun x -> x.Origin)
        |> Map.ofSeq
        |> Path.findShortest

    let path = findShortestPath "5" "1"

    path ?|> Seq.toList ?|> Seq.map(fun x -> x.Origin, x.Destination) ?|> Seq.toList |> printfn "%A"
    path ?|> Path.distance |> printfn "%A"
    Console.ReadLine() |> ignore
    0 // return an integer exit code
