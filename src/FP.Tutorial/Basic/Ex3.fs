namespace FP.Tutorial.Basic
open System
open Unchecked
open System.Threading

module Ex3 =

    let f x =
        Thread.Sleep 500
        x * x
    let g x = 
        Thread.Sleep 1000
        x |> Int32.Parse |> float |> FuncConvert.FuncFromTupled Math.Pow 2.0

    //write custom code to make it runs faster
    let doSomething() =
        let I = [ 1..3 ] |> Seq.collect(fun x -> [ 1..x ]) |> Seq.map(fun x -> x, x.ToString())
        for x, y in I do
            printfn "%A" (f x, g y)