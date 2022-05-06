module IntSet

// Tipo IntSet implementato come un albero binario di ricerca
type IntSet =
    | Leaf
    | Node of int * IntSet * IntSet

// Crea un IntSet vuoto
let empty = Leaf

// Ritorna 'true' se l'insieme è vuoto, 'false' altrimenti
let isEmpty set = (set = Leaf)

// Ritorna 'true' se l'insieme contiene l'intero passato come parametro, 'false' altrimenti
let rec contains n set =
    match set with
    | Leaf -> false
    | Node(v,_,_) when v = n -> true
    | Node(_,sx,dx) -> contains n sx || contains n dx

// Aggiunge l'elemento passato come parametro all'insieme
let rec add n set =
    match set with
    | Leaf -> Node(n, Leaf, Leaf)
    | Node(v,sx,dx) -> if n <= v then Node(v, add n sx, dx) else Node(v, sx, add n dx) 

// Unisce gli elementi del secondo insieme agli elementi del primo insieme
let union set1 set2 =
    let ls2 = toList set2
    let rec addNode lst set =
        match lst with
        | [] -> set
        | x::xs -> addNode xs (add x set)
    addNode ls2 set1

// Crea un insieme data la lista degli elementi
let ofList lst =
    let rec addNode lst set =
        match lst with
        | [] -> set
        | x::xs -> addNode xs (add x set)
    addNode lst empty

// Crea una lista degli elementi contenuti nell'insieme
let rec toList set =
    match set with
    | Leaf -> []
    | Node(v,sx,dx) -> (toList sx) @ [v] @ (toList dx)
