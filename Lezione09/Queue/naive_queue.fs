module Queue

// Tipo Queue implementato come una lista di 'a'
type Queue<'a> =
    | Q of 'a list

// Eccezione per la coda vuota
exception EmptyQueue

// Crea una nuova coda
let empty = Q []

// Aggiunge l'elemento alla coda
let put el (Q lst) = (Q (lst @ [el]))

// Rimuove il primo elemento e lo ritorna assieme alla coda nuova
let get (Q lst) =
    match lst with
    | [] -> raise EmptyQueue
    | x::xs -> (x, Q xs)
