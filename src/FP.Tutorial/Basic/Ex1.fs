namespace FP.Tutorial.Basic

open System
open Unchecked

module Ex1 =
    let rec fib x =
        match x with
        | 0 | 1 -> x
        | x -> fib(x - 1) + fib(x - 2)

    //write more efficient function
    let efficientFib (x: int) (*additional parameters may be added*) =
        defaultof<int>