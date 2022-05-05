// Tipo optione è un tagged value polimorfo
// Vale None oppure Some of 'a
// Utili per le funzioni parziali (prog2 feels)

// Funzione int -> int totale che calcola il fattoriale
// La gestione può avvenire anche con eccezioni ma dispendiosa
let rec fact x =
    match x with
    | 0 -> Some 1
    | _ ->
        if x < 0 then None
        else
            match fact (x-1) with
            | Some n -> Some (x * n)
            | None -> None

// Uso della clausola "when" nei pattern per imporre delle condizioni
// Analogo a if (condizione) then (risultato) else (controlla altri pattern)
let rec otherFatc x =
    match x with
    | 0 -> Some 1
    | _ when x < 0 -> None
    | _ ->
        match fact (x-1) with
        | Some n -> Some (x * n)
        | None -> None