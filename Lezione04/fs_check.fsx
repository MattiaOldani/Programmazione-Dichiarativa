#r "FsCheck"
open FsCheck

// Per sapere se una funzione viene eseguita correttamente si scrivono delle proprietà che deve soddisfare
// Le proprietà sono funzioni booleane
// Ad esempio, la funzione che fa il reverse di una lista è involutiva, ovvero f(f(x)) = x

// Funzione int list -> int list che ritorna la lista in ordine contrario
let rec reverse lst =
    match lst with
    | [] -> []
    | x::xs -> reverse xs @ [x]

let prop_revIsInv lst = reverse(reverse lst) = lst

do Check.Quick prop_revIsInv

// Se non si passano i test, o il codice ha un bug, o la proprietà è falsa

// Lo stile usato per testare il codice è quello dell'unit testing
// Si crea uno stato del mondo, si esegue il codice su quel mondo e si controlla se il risultato è quello atteso
// Le unit test sono infinite, quindi è impossibile garantire la correttezza
// Molto più utile usare il PBT: Property-Based Testing
// Si fornisce una specificazione del programma in forma di proprietà e si testano queste ultime
// Importante ricordare che non è una dimostrazione, ma una validazione
// Spesso utile testare rispetto ad un modello di riferimento, detto MBT, Model-Based Testing

// Uso delle properties con la forma <condizione> ==> <proprietà>
let rec ordered lst =
    match lst with
    | [] -> true
    | [x] -> true
    | x::y::ys -> x <= y && ordered (y::ys)

let rec insert (x, xs) =
    match xs with
    | [] -> [x]
    | y::_ when x <= y -> x::xs
    | y::ys -> y :: insert (x,ys)

let prop_insert (x : int) (xs : int list) =
    ordered xs ==> ordered (insert (x, xs))

do Check.Quick prop_insert

// Uso della lazy evaluation per ritardare il check delle condizioni
let prop_min (lst : int list) =
    lst <> [] ==> lazy (List.sort lst |> List.head = List.min lst)

do Check.Quick prop_min

// Lazy evaluation evita il sollevamento di eccezioni non volute
let prop_max (lst : int list) =
    let rec last (lst : int list) =
        match lst with
        | x::xs -> if xs = [] then x else last xs
    lst <> [] ==> lazy (List.sort lst |> last = List.max lst)

do Check.Quick prop_max