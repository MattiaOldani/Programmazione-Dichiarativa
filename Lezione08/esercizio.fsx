// Tipo t che codifica un intero o una lista di interi
type t =
    | INT
    | LSTINT

// Tipo exp che codifica espressioni con interi e liste di interi
type exp =
    | K of int
    | Plus of exp * exp
    | Nil
    | Cons of exp * exp
    | Hd of exp
    | Tl of exp

// Type checker con option
let rec tpcko exp =
    match exp with
    | K(n) -> Some(INT)
    | Plus(e1,e2) ->
        match (tpcko e1, tpcko e2) with
        | (Some(INT), Some(INT)) -> Some(INT)
        | _ -> None
    | Nil -> Some(LSTINT)
    | Cons(e1,e2) ->
        match (tpcko e1, tpcko e2) with
        | (Some(INT), Some(LSTINT)) -> Some(LSTINT)
        | _ -> None
    | Hd(e1) ->
        match tpcko e1 with
        | Some(LSTINT) -> Some(INT)
        | _ -> None 
    | Tl(e1) ->
        match tpcko e1 with
        | Some(LSTINT) -> Some(LSTINT)
        | _ -> None

// Type checker con eccezioni
exception NotAInt
exception NotAList
exception IllegalCons

let rec tpcke exp =
    match exp with
    | K(n) -> INT
    | Plus(e1,e2) ->
        match (tpcke e1, tpcke e2) with
        | (INT, INT) -> INT
        | _ -> raise NotAInt
    | Nil -> LSTINT
    | Cons(e1,e2) ->
        match (tpcke e1, tpcke e2) with
        | (INT, LSTINT) -> LSTINT
        | _ -> raise IllegalCons
    | Hd(e1) ->
        match tpcke e1 with
        | LSTINT -> INT
        | _ -> raise NotAList
    | Tl(e1) ->
        match tpcke e1 with
        | LSTINT -> LSTINT
        | _ -> raise NotAList