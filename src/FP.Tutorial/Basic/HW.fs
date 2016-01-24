namespace FP.Tutorial.Basic

open System
open Unchecked

type Vertex = string
type Connection = { Origin: Vertex; Destination: Vertex; Distance: int }
type Path = Connection list
type Graph = Map<Vertex, Path>

module HW =
    //dijkstra's algorithm
    let findShortestPath (graph: Graph) (origin: Vertex) (destination: Vertex): Path = defaultof<_>

    let test() =
        let graph = 
            [
                { Origin = "1"; Destination = "2"; Distance = 7 }
                { Origin = "1"; Destination = "3"; Distance = 9 }
                { Origin = "1"; Destination = "6"; Distance = 14 }
                { Origin = "2"; Destination = "3"; Distance = 10 }
                { Origin = "2"; Destination = "4"; Distance = 15 }
                { Origin = "3"; Destination = "4"; Distance = 11 }
                { Origin = "3"; Destination = "6"; Distance = 2 }
                { Origin = "4"; Destination = "5"; Distance = 6 }
                { Origin = "5"; Destination = "6"; Distance = 9 }
            ]
            |> List.groupBy(fun x -> x.Origin)
            |> Map.ofList

        let path = findShortestPath graph "1" "5"

        List.fold (fun s c -> sprintf "%A--%A--%A" s c.Distance c.Destination) (path.Head.Origin) path
        |> printfn "%A"