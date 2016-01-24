namespace FP.Tutorial.Basic
open System
open Unchecked

module Ex5 =
    let f x = x * x
    
    let doSomething() =
        let mutable x = Console.ReadLine()
        while x <> "exit" do
            x |> Int32.Parse |> f |> printfn "%A"
            x <- Console.ReadLine()
    let doSomething1() =
        //ignore white spaces (" 3 " = " 3" = "3 " = "3")
        ()
    let doSomething2() =
        //like doSomething1()
        //+ skip non-integer
        ()
    let doSomething3() =
        //like doSomething2()
        //+ gather all input before start the printing
        ()
    let doSomething4() =
        //like doSomething4()
        //+ use "q" instead of "exit" to exit the loop
        ()