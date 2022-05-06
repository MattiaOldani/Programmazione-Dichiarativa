// Tipo binTree
type 'a binTree =
    | Leaf
    | Node of 'a * 'a binTree * 'a binTree

// Funzione fold sugli alberi
let rec foldTree f tree el =
    match tree with
    | Leaf -> el
    | Node(v, sx, dx) -> f v (foldTree f sx el) (foldTree f dx el)

// Funzione 'a binTree -> int * int che conta il numero di nodi e il numero di foglie di un albero
let rec count tree =
    match tree with
    | Leaf -> (0,0)
    | Node(v, Leaf, Leaf) -> (0,1)
    | Node(v, sx, dx) ->
        let (nodes_sx, leaves_sx) = count sx
        let (nodes_dx, leaves_dx) = count dx
        (1 + nodes_sx + nodes_sx, leaves_sx + leaves_dx)

// Funzione 'a binTree -> int che conta il numero di nodi di un albero
let rec count_nodes tree = 
    match tree with
    | Leaf -> 0
    | Node(v,sx,dx) -> 1 + count_nodes sx + count_nodes dx

// Funzione 'a binTree -> int che conta il numero di foglie di un albero
let rec count_leaves tree =
    match tree with
    | Leaf -> 0
    | Node(v, Leaf, Leaf) -> 1
    | Node(v, sx, dx) -> count_leaves sx + count_leaves dx

let another_count_leaves tree =
    let f v sx dx =
        match (sx, dx) with
        | (0,0) -> 1
        | _ -> sx + dx
    foldTree f tree 0
