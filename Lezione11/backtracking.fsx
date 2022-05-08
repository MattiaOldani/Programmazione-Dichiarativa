// L'uso di options, eccezioni e continuazioni permette di cambiare il flusso di controllo di un programma

// Funzione KEK che, data una somma di denaro e dei tagli, ritorna una lista di tagli che sommati danno il totale richiesto
exception NoWallet

let rec kek_change sum coins =
    match (coins, sum) with
    | (_, 0) -> []
    | ([], _) -> raise NoWallet
    | (x::xs, s) ->
        if s < x then
            kek_change s xs
        else
            x :: kek_change s (x::xs)

// Soluzione CHAD che usa il backtracking
let rec chad_change sum coins =
    match (coins, sum) with
    | (_, 0) -> []
    | ([], _) -> raise NoWallet
    | (x::xs, s) ->
        try
            if s < x then
                kek_change s xs
            else
                x :: kek_change s (x::xs)
        with
            | NoWallet -> kek_change s xs