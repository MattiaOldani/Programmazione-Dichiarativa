// Albero binario i cui nodi hanno tipo 'a
// Un albero è l'albero vuoto oppure un nodo con due sotto-alberi binari
type 'a binTree =
    | Leaf
    | Node of 'a * 'a binTree * 'a binTree

// Funzione int binTree -> float binTree che trasforma un albero binario intero in uno float
let rec transform tree =
    match tree with
    | Leaf -> Leaf
    | Node(v, sx, dx) -> Node (float v, transform sx, transform dx)

// Funzione ('a -> 'b) -> 'a binTree -> 'b binTree che mappa ogni elemento dell'albero sulla funzione f
let rec map f tree =
    match tree with
    | Leaf -> Leaf
    | Node(v, sx, dx) -> Node (f v, map f sx, map f dx)

// Funzione int binTree -> int che somma tutti i valori contenuti nei nodi
let rec sum tree =
    match tree with
    | Leaf -> 0
    | Node(v, sx, dx) -> v + sum sx + sum dx

// Funzione 'a binTree -> int che calcola la profondità dell'albero
let depth tree =
    let rec search btree =
        match btree with
        | Leaf -> 0
        | Node(v, sx, dx) -> 1 + max (search sx) (search dx)
    search tree

// Funzione 'a binTree -> unit che effettua la visita in pre ordine
let rec preorder tree =
    match tree with
    | Leaf -> []
    | Node(v, sx, dx) -> v :: preorder sx @ preorder dx

// Funzione 'a binTree -> unit che effettua la visita in ordine
let rec inorder tree =
    match tree with
    | Leaf -> []
    | Node(v, sx, dx) -> inorder sx @ [v] @ inorder dx

// Funzione 'a binTree -> unit che effettua la visita in post ordine
let rec postorder tree =
    match tree with
    | Leaf -> []
    | Node(v, sx, dx) -> postorder sx @ postorder dx @ [v]

// Funzione ('a -> bool) -> 'a binTree -> 'a list che ritorna la lista dei nodi filtrati con f
let rec filter f tree =
    match tree with
    | Leaf -> []
    | Node(v, sx, dx) ->
        if f v then
            filter f sx @ (v :: filter f dx)
        else
            filter f sx @ filter f dx

// Funzione ('a -> bool) -> 'a binTree -> 'a option binTree che ritorna l'albero dei nodi filtrati con f
let rec filterOption f tree =
    match tree with
    | Leaf -> Leaf
    | Node(v, sx, dx) ->
        if f v then
            Node (Some v, filterOption f sx, filterOption f dx)
        else
            Node (None, filterOption f sx, filterOption f dx)

// Si può definire una fold sugli alberi
// Le funzioni che generalizzano fold a strutture ricorsive arbitrarie sono dette catamorfismi
let rec foldTree f tree el =
    match tree with
    | Leaf -> el
    | Node(v, sx, dx) -> f v (foldTree f sx el) (foldTree f dx el)

// Funzione int binTree -> int che somma tutti i valori contenuti nei nodi
let sumFold tree = foldTree (fun x y z -> x + y + z) tree 0

// Funzione 'a binTree -> int che calcola la profondità dell'albero
let rec depthFold tree = foldTree (fun v sx dx -> 1 + max sx dx) tree 0

// Funzione 'a binTree -> unit che effettua la visita in ordine
let inorderFold tree = foldTree (fun v sx dx -> sx @ [v] @ dx) tree []

// Funzione ('a -> bool) -> 'a binTree -> 'a list che ritorna la lista dei nodi filtrati con f
let filterFold f tree = foldTree (fun v sx dx -> if f v then sx @ (v :: dx) else sx @ dx) tree []