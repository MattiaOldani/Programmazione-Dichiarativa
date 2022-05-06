module IntSet

// Tipo IntSet implementato come una lista di interi
type IntSet =
    | S of int list

// Crea un IntSet vuoto
let empty = S []

// Ritorna 'true' se l'insieme è vuoto, 'false' altrimenti
let isEmpty (S lst) = List.isEmpty lst

// Ritorna 'true' se l'insieme contiene l'intero passato come parametro, 'false' altrimenti
let contains n (S lst) = List.contains n lst

// Aggiunge l'elemento passato come parametro all'insieme
let add n (S lst) = if contains n (S lst) then (S lst) else (S (lst @ [n]))

// Unisce gli elementi del secondo insieme agli elementi del primo insieme
let union (S ls1) (S ls2) = (S (ls1 @ ls2))

// Crea un insieme data la lista degli elementi
let ofList lst = (S lst)

// Crea una lista degli elementi contenuti nell'insieme
let toList (S lst) = lst
