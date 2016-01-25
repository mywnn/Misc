namespace FP.Tutorial.Basic
open System
open Unchecked

module Ex4 =
    let randomer = Random()

    let f x =
        match randomer.Next(4) with
        | 0 -> failwith "An error has occurred." 
        | r -> x * x
    let g x =
        match randomer.Next(9) with
        | 0 -> failwith "An error has occurred."
        | r -> x + x
    let h x =
        match randomer.Next(19) with
        | 0 -> failwith "An error has occurred."
        | r -> Math.Sqrt(float x) / 2.0
    
    //write retry logic on f, g, h
    let doSomething1() = ()