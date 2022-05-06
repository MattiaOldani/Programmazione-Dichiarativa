#r "FsCheck"
open FsCheck

// Funzione int list -> int list che, data una lista, eleva al quadrato ogni elemento
let rec square1 lst = List.map (fun x -> x * x) lst

// Funzione int -> int list che, dato un intero n, costruisce la lista dei quadrati da 1 a n
let squareList n = List.map (fun x -> x * x) [0 .. n]

// Funzione int -> int list che, dato un intero x, costruisce la lista dei numeri pari da 0 a x
let even x = [0 .. 2 .. x]

// Funzione int -> int -> int list che, dati k e m, costruisce la lista dei multipli di k compresi tra k e m
let mult k m =
    let rec filter x =
        match x with
        | [] -> []
        | y::ys -> if y % k = 0 then y :: filter ys else filter ys
    filter [k .. m]

// Funzione 'a -> 'a list -> bool che, dato un elemento e una lista, ritorna true se l'elemento è contenuto nella lista
let rec contains x xs =
    match xs with
    | [] -> false
    | y::ys -> if x = y then true else contains x ys

let check x xs =
    contains x xs ==> List.contains x xs

do Check.Quick check

// Funzione int -> bool che, preso un intero, ritorna true se è un quadrato perfetto
let pSquare n =
    match n with
    | 0 -> true
    | _ ->
        let rec check x =
            match x with
            | 0 -> false
            | _ -> if x * x = n then true else check (x-1)
        check (n / 2 + 1)

// Proprietà: la lista restituita da squareList è formata solo da quadrati perfetti
let check_square n =
    n >= 0 ==> List.forall pSquare (squareList n)

do Check.Quick check_square