// Funzione ricorsiva int list -> int che calcola la somma degli elementi della lista
let rec sum = function
    | [] -> 0
    | y::ys -> y + (sum ys)

// Funzione ricorsiva int list -> int * int che, data una lista, la restituisce come coppia (sum,prod)
// sum -> somma elementi della lista
// prod -> prodotto elementi della lista
let rec sumProd xs =
    match xs with
    | [] -> (0,0)
    | y::ys -> 
        let (sum,prod) = sumProd ys
        (y + sum, y * prod)

// Funzione ricorsiva int list -> int list -> int list che concatena due liste
let rec append (x : int list) (y : int list) =
    match x with
    | [] -> y
    | z::zs -> z :: append zs y

// Funzione ricorsiva 'a list -> int che calcola la lunghezza di una lista
let rec length xs =
    match xs with
    | [] -> 0
    | y::ys -> 1 + length ys

// Funzione ricorsiva 'a list -> 'a list che inverte gli elementi di una lista
let rec reverse xs =
    match xs with
    | [] -> []
    | y::ys -> reverse ys @ [y]

// Funzione ricorsiva float -> int -> float che calcola b^e
let rec exp (b : float) e =
    match e with
    | 0 -> float 1
    | _ -> b * exp b (e-1)

// Funzione ricorsiva int -> string che costruisce la stringa "0 ... n" dato n
let rec makeString x =
    match x with
    | 0 -> "0"
    | _ -> makeString (x-1) + " " + string x

// Funzione ricorsiva int -> int * string che ritorna la tupla (somma da 0 a n, valore della somma in stringa)
let rec makeStringSum x =
    match x with
    | 0 -> (0, "0")
    | x ->
        let (sum, str) = makeStringSum (x-1)
        (sum + x, str + " " + string x)

// Funzione int -> string che ritorna la stringa "0 + ... + n = k"
let anotherStringSum x =
    let rec aux y =
        match y with
        | 0 -> (0, "0")
        | y ->
            let (sum, str) = aux (y-1)
            (sum + y, string str + " + " + string y)
    let (sum, str) = aux x
    str + " = " + string sum