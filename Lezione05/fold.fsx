#r "FsCheck"
open FsCheck

// Funzione higher-order universale
// Può essere utilizzata per definire qualunque funzione su liste la cui definizione richiede la ricorsione

// In generale, si parte da un elemento iniziale "e" e si itera l'applicazione di una funzione binaria
// Si usa una variabile "accumulatore" che contiene i risultati progressivi

// Si usa la funzione List.foldBack, che ha 3 argomenti:
//      funzione binaria f : 'a -> 'b -> 'b
//      una lista di tipo 'a list
//      un valore iniziale di tipo 'b
// Detta anche "right fold" poichè associativa a destra

// Funzione int list -> int che calcola la somma degli elementi della lista
let sumList lst = List.foldBack (fun x y -> x + y) lst 0

// Funzione int list -> int che calcola il prodotto degli elementi della lista
let prodList lst = List.foldBack (fun x y -> x * y) lst 1

// Funzione int list -> int che calcola la lunghezza della lista
let lengthList lst = List.foldBack (fun x y -> 1 + y) lst 0

// Funzione 'a -> 'b -> 'a list -> 'b list che mappa gli elementi di una lista in un'altra applicando una funzione
let mapList f lst = List.foldBack (fun e t -> f e :: t) lst []

// Funzione 'a list -> 'a list -> 'a list
let append lst1 lst2 = List.foldBack (fun a b -> a :: b) lst1 lst2

// Esiste la funzione duale di foldBack, detta fold
// Detta anche "left fold", poichè associa a sinistra

// Funzione int list -> int che calcola la somma degli elementi della lista
let anotherSumList lst = List.fold (fun x y -> x + y) 0 lst

// Funzione 'a -> 'b -> 'a list -> 'b list che mappa gli elementi di una lista in un'altra applicando una funzione
let anotherMapList f lst = List.fold (fun x y -> f x :: y) [] lst

// Funzione 'a list -> 'a list che inverte la lista passata come argomento
let reverseList lst = List.fold (fun x y -> y :: x) [] lst

// Proprietà: l'inverso dell'inveso di una lista è la lista stessa
let check_list lst = reverseList (reverseList lst) = lst

do Check.Quick check_list

// In generale, se una funzione è associativa, fold e foldBack sono la stessa funzione
// Una struttura algebrica con funzione f associativa e neutro e0 è detta monoide