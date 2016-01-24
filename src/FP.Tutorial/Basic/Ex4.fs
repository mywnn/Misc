namespace FP.Tutorial.Basic
open System
open Unchecked

module Ex4 =
    let randomer = Random()

    let f x =
        match randomer.Next(5) with
        | 0 -> failwith "An error has occurred." 
        | r -> x * x
    let g x =
        match randomer.Next(10) with
        | 0 -> failwith "An error has occurred."
        | r -> x + x
    let h x =
        match randomer.Next(20) with
        | 0 -> failwith "An error has occurred."
        | r -> Math.Sqrt(float x) / 2.0
    
    let doSomething() =
        //write custom code to enhance f, g, h
        //- return less number of errors but don't unreasonably take much time to finish.
        ()