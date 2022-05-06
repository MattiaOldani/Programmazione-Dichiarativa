#r "FsCheck"
open FsCheck

// Proprietà: se da una lista rimuovo tutti gli elementi pari, ciò che rimane è solo dispari
let rec removeEven lst = List.filter (fun x -> x % 2 <> 0) lst

let rec checkOdd lst =
    match lst with
    | [] -> true
    | x::xs -> if (x % 2) = 0 then false else checkOdd xs

let prop_odd lst =
    true ==> checkOdd (removeEven lst)

do Check.Quick prop_odd

// Proprietà: se da una lista rimuovo gli elementi in posizione dispari, la lunghezza è circa la metà
let rec removeOddPosition lst =
    match lst with
    | [] -> []
    | [x] -> [x]
    | x::y::ys -> x :: removeOddPosition ys

let checkLength lst = List.length (removeOddPosition lst) <= (List.length lst + 1) / 2

let prop_length lst =
    true ==> checkLength lst

do Check.Quick prop_length

// Funzione list 'a -> 'a che ritorna il primo elemento della lista
// Gestire anche le eccezioni
let head lst =
    try
        Some (string (List.head lst))
    with
        | :? System.ArgumentException ->
            printfn "Empty list"
            None
        | _ ->
            printfn "Bro è successo qualcosa che non so"
            None