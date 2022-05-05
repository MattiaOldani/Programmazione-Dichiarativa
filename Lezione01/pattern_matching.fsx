// Permette la definizione di espressioni "per casi"

// Funzione int -> int che mappa ogni mese con il numero di giorni
// Si utilizza _ come wildcard
let days1 n =
    match n with
    | 2 -> 28
    | 4|6|8|9|11 -> 30
    | _ -> 31

// Funzione int -> int che mappa ogni mese con il numero di giorni, versione bisestile
// Definizione più compatta lasciando l'argomento implicito
let days2 = function
    | 2 -> 29
    | 4|6|8|9|11 -> 30
    | _ -> 31

// Funzione bool -> bool che calcola "not"
let not = function
    | true -> false
    | false -> true

// Funzione bool -> bool -> bool che calcola "and"
let andd x y =
    match (x,y) with
    | (true, true) -> true
    | _ -> false

// Funzione int -> int che calcola il valore assoluto di un intero
// Valutazione di un'espressione booleana nel match with
let abs1 x =
    match x >= 0 with
    | true -> x
    | false -> -x

// Funzione int -> int che calcola il valore assoluto di un intero
// Uso del costrutto if-then-else
// NON è una struttura di controllo, ma un costrutto per definire espressioni per casi
// Bisogma avere sia ramo then che ramo else, altrimenti è pattern matching incompleto
// Inoltre, il tipo restituito dal ramo then deve essere uguale al tipo restituito nel ramo else
let abs2 x = if x >= 0 then x else -x

// Funzione int -> bool che calcola se un intero è positivo
// Utilizzabile "if x > 0 then true else false" ma ridondante
let isPositive = fun x -> x > 0