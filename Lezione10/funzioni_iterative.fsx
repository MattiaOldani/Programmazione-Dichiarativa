// Stack contiene le variabili "statiche"

// Heap contiene strutture che variano dinamicamente

// Funzione int -> int che calcola il fattoriale di un numero n >= 0
let rec fact1 n =
    match n with
    | 0 -> 1
    | _ -> n * fact1 (n-1)

// Funzione int -> int che calcola il fattoriale di un numero n >= 0 in maniera iterativa
let fact2 n =
    let rec factA k acc =
        match k with
        | 0 -> acc
        | _ -> factA (k-1) (k * acc)
    factA n 1

// Funzione fold ('a -> 'b -> 'a) -> 'a -> 'b list -> 'a iterativa
let rec fold f e0 lst =
    match lst with
    | [] -> e0
    | x::xs -> fold f (f e0 x) xs

// Funzione foldBack ('a -> 'b -> 'b) -> 'a list -> 'b -> 'b non iterativa
let rec foldBack f lst e0 =
    match lst with
    | [] -> e0
    | x::xs -> f x (foldBack f xs e0)

// Funzione 'a list -> 'a list che fa il reverse di una lista
let rec reverse lst =
    match lst with
    | [] -> []
    | x::xs -> reverse xs @ [x]

// Funzione 'a list -> 'a list che fa il reverse di una lista iterativa
let reverseIt lst =
    let rec reverseAcc lst acc =
        match lst with
        | [] -> acc
        | x::xs -> reverseAcc xs (x::acc)
    reverseAcc lst []

// Funzione int -> int list che crea una lista con n elementi a 1
let rec bigList n =
    match n with
    | 0 -> []
    | _ -> 1 :: bigList (n-1)

// Funzione int -> int list che crea una lista con n elementi a 1 iterativa
let bigListIt n =
    let rec bigList n (acc : int list) =
        match n with
        | 0 -> acc
        | _ -> bigList (n-1) (1::acc)
    bigList n []