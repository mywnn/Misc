[<AutoOpen>]
module StateMonad
    type StateMonad() =
        member this.Bind(x, f) = fun s -> x s ||> f
        member this.Return x = fun s -> x, s
        member this.ReturnFrom x = x
        member this.Get s = s, s
        member this.Set s = fun _ -> (), s
    let state = new StateMonad()