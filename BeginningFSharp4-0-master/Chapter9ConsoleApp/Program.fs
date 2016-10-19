module Strangelights.Extensions =
    let fibs =
        (1I,1I) |> Seq.unfold
            (fun (n0, n1) ->
                Some(n0, (n1, n0 + n1)))

    let fib n = Seq.nth n fibs
