// Le continuazioni sono funzioni che descrivono il resto della computazione che deve essere eseguita
// Utili per la gestione del flusso di controllo
// Permettono l'implementazione della tail recursion

// Fattoriale definito con le continuazioni
let fact n =
    let rec cont f n =
        match n with
        | 0 -> f 1
        | x -> cont (fun t -> f (x * t)) (x-1)
    cont id n