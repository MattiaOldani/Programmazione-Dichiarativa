// Funzione ricorsiva rmEven 'a list --> 'a list che elimina tutti i numeri pari dalla lista iniziale
let rec rmEven lst =
    match lst with
    | [] -> []
    | x::xs -> if x % 2 <> 0 then x :: rmEven xs else rmEven xs

// Funzione ricorsiva rmOddPos int list -> int list che elimina tutti gli elementi in posizione dispari
let rec rmOddPos lst =
    match lst with
    | [] -> []
    | [x] -> [x]
    | x::y::ys -> x :: rmOddPos ys

// Funzione ricorsiva 'a list -> 'a list * 'a list che costruisce le liste degli elementi in posizione pari e dispari
let rec split lst =
    match lst with
    | [] -> ([], [])
    | [x] -> ([x], [])
    | x::y::ys ->
        let (a,b) = split ys
        (x::a, y::b)

// Funzione ricorsiva 'a list -> 'b list -> int che, date due liste, confronta le lunghezze e restituisce
// -1 se la lunghezza della prima è minore della lunghezza della seconda
//  0 se la lunghezza della prima è uguale della lunghezza della seconda
// -1 se la lunghezza della prima è maggiore della lunghezza della seconda
let rec length lst1 lst2 =
    match (lst1, lst2) with
    | ([], []) -> 0
    | ([], x::xs) -> -1
    | (x::xs, []) -> 1
    | (x::xs, y::ys) -> length xs ys

// Funzione ricorsiva 'a -> 'a list -> 'a list che elimina tutte le occorrenze di 'a nella lista
// Usando questa funzione, definire una funzione ricorsiva 'a -> 'a list che rimuove tutti i duplicati
let rec remove el lst =
    match lst with
    | [] -> []
    | x::xs -> if x = el then remove el xs else x :: remove el xs

let rec removeDuplicates lst =
    match lst with
    | [] -> []
    | x::xs -> x :: removeDuplicates (remove x xs)

// Funzione ricorsiva int -> int list che, dato un intero n, ritorna la lista dei numeri da 0 a n
let rec upTo n =
    match n with
    | 0 -> [0]
    | _ -> upTo (n-1) @ [n]

// Funzione ricorsiva int -> int list che, dato un intero n, ritorna la lista dei numeri da n a 0
let rec downTo0 n =
    match n with
    | 0 -> [0]
    | _ -> n :: downTo0 (n-1)

// Funzione ricorsiva 'a list -> bool che ritorna 'true' se i primi due elementi della lista sono uguali
let rec anotherLength lst =
    match lst with
    | x::y::ys when x = y -> true
    | _ -> false
