// Sfruttare la definizione ricorsiva di alcune funzioni
// Uso di "rec" per garantire l'uso della funzione nella funzione stessa

// Funzione fattoriale
let rec fact x =
    match x with
    | 0 -> 1
    | _ -> x * fact (x-1)