module Queue

// Tipo Queue implementato secondo l'implementazione Paulson
type Queue<'a> = {front : 'a list; rear : 'a list}

// Eccezione per la coda vuota
exception EmptyQueue

// Crea una nuova coda
let empty = {front = []; rear = []}

// Aggiunge l'elemento alla coda
let put el {front = f; rear = r} = {front = f; rear = el::r}

// Rimuove il primo elemento e lo ritorna assieme alla coda nuova
let get {front = f; rear = r} =
    match f with
    | [] ->
        match r with
        | [] -> raise EmptyQueue
        | _ ->
            let (x::xs) = List.rev r
            (r, {front = xs; rear = []})
    | x::xs -> (x, {front = xs; rear = r})
