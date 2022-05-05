// Tipi yearType e month
type yearType = 
    | Leap
    | NoLeap

type month =
    | January
    | February
    | March
    | April
    | May
    | June
    | July
    | August
    | September
    | October
    | November
    | December

// Funzione month -> yearType -> int che restituisce il numero di giorni del mese
let days1 m t =
    match t with
    | Leap ->
        match m with
        | February -> 29
        | April|June|August|September|November -> 30
        | _ -> 31
    | NoLeap ->
        match m with
        | February -> 28
        | April|June|August|September|November -> 30
        | _ -> 31

// Funzione int -> yearType che dato un anno restituisce il tipo
let leap x =
    match (x % 400 = 0 || (x % 4 = 0 && not (x % 100 = 0))) with
    | true -> Leap
    | false -> NoLeap

// Funzione month -> int -> int che dato un mese e un anno, restituisce il numero di giorni del mese
let day2 m x = days1 m (leap x)

// Funzione int -> string che restituisce il risultato del fattoriale come stringa
// Se il valore passato è negativo, si stampa un messaggio d'errore
let rec fact x =
    match x with
    | 0 -> Some 1
    | _ ->
        if x < 0 then None
        else
            match fact (x-1) with
            | Some n -> Some (x * n)
            | None -> None

let printFact x =
    match fact x with
    | None -> "The factorial of " + string x + " is not defined"
    | Some n -> string n