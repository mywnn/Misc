namespace TestFS

type Connection = { Origin: Vertex; Destination: Vertex; Distance: int }
and Vertex = string

type Path = Connection seq
and Map = Map<Vertex, Connection seq>

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Path =
    type private Progress = { SubDestinations: Map<Vertex, Path>; Visited: Vertex Set }
    let distance path = Seq.sumBy(fun x -> x.Distance) path
    let rec private findShortestRec (map: Map) destination =
        state {
            let! progress = state.Get
            let subDests = progress.SubDestinations |> Map.toSeq |> Seq.sortBy(fun(_, x) -> distance x) |> Seq.toList

            match subDests with
            | [] -> 
                return None
            | (subDest, path) :: _ when subDest = destination -> 
                return Some path
            | (subDest, path) :: _ ->
                let connections = map.[subDest] |> Seq.where(fun x ->  progress.Visited |> (not << Set.exists(fun v -> x.Destination = v)))
                let subDests = 
                    connections
                    |> Seq.map(fun x -> x.Destination, Seq.append path [x], Map.tryFind (x.Destination) progress.SubDestinations)
                    |> Seq.map(function
                        | x, y, None -> x, y
                        | x, y, Some z when distance y < distance z -> x, y
                        | x, _, Some z -> x, z)
                    |> Seq.fold(fun map (v, p) -> Map.add v p map) (Map.remove subDest progress.SubDestinations)
                do! state.Set { 
                    SubDestinations = subDests
                    Visited = Set.add subDest progress.Visited
                }

                return! findShortestRec map destination
        }
    let findShortest map origin destination =
        if Map.containsKey origin map && Map.containsKey destination map then
            findShortestRec map destination { 
                SubDestinations = [origin, Seq.empty] |> Map.ofList
                Visited = Set.empty
            }
            |> fst
        else
            None