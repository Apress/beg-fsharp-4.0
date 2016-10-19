module Comments

// this is a single-line comment

(* this is a comment *)

(* this
   is a
   comment
*)

/// This is a doc comment

/// <summary>
/// divides the given parameter by 10
/// </summary>
/// <param name="x">the thing to be divided by 10</param>
let divTen x = x / 10

(*F#
printfn "This will be printed by an F# program"
F#*)

(*IF-OCAML*)
Format.printf "This will be printed by an OCaml program"
(*ENDIF-OCAML*)

