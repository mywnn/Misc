namespace FP.Tutorial.Basic
open System
open Unchecked

module Ex6 =
    let doSomething() =
        //state triggering series example
        //
        //time  ->  state to be evolved
        //=============================
        //1     ->  1
        //2     ->  1, 2
        //3     ->  2
        //4     ->  4
        //5     ->  2, 3
        //6     ->  1, 3
        //7     ->  none
        //.
        //.
        //.
        //m     ->  1, 2, 3, ..., n

        let mutable state1 = 0
        let mutable state2 = 0
        let mutable state3 = 0
//        let mutable state4 = 0
//        ...
//        let mutable stateN = 0

        let setState1() = state1 <- state1 + 1
        let setState2() = state2 <- state2 + state1 + 1
        let setState3() = state3 <- state3 + state2 + state1 + 1
//        let setState4() = state4 <- state4 + state3 + state2 + state1 + 1
//        ...
//        let setStateN() = stateN <- stateN + ... + state3 + state2 + state1 + 1

        let mutable x = Console.ReadLine()
        while true do
            let x = x |> Int32.Parse
            match x with
            | 1 -> 
                state1 <- state1 + 1
                printfn "state1 %A" state1
            | 2 -> 
                state2 <- state2 + state1 + 1
                printfn "state2 %A" state2
            | 3 -> 
                state3 <- state3 + state2 + state1 + 1
                printfn "state3 %A" state3
//            | 4 ->
//                state4 <- state4 + state3 + state2 + state1 + 1
//                printfn "state4 %A" state4
//            ...
//            | n ->
//                stateN <- stateN + ... + state3 + state2 + state1 + 1
//                printfn "stateN %A" stateN

            | _ -> ()
            
    //state evolution of state1
    let state1Evolution() (*additional parameters may be added*) = ()
    //state evolution of state1, state2
    let state1_2_Evolution() (*additional parameters may be added*) = ()
    //state evolution of state1, state2, state3
    let state1_2_3_Evolution() (*additional parameters may be added*) = ()