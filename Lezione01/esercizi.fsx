// Funzione bool -> bool -> bool che calcola "or"
let orr x y =
    match (x,y) with
    | (false,false) -> false
    | _ -> true

// Funzione int -> string che restituisce "pari" se il numero è pari, "dispari" altrimenti
let isPariString x =
    match x % 2 = 0 with
    | true -> "pari"
    | false -> "dispari"

// Funzione int -> string che applicata a un intero, descrive se è pari o dispari
let s = fun x -> string x + " e' un numero " + isPariString x