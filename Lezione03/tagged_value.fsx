// Usati per raggruppare valori di forma diversa in un unico tipo
// Chiamati anche disjoint unions, sono molto simili ai record

// Tipi enumerativi
// I valori contenuti dentro il tag sono i costruttori
// Eseguendo "Rosso;;" si ottiene un attributo di tipo colore con valore Rosso
type color =
    | Rosso
    | Blu
    | Verde

// Funzione color -> int che associa ad ogni colore un valore
let value c =
    match c with
    | Rosso -> 1
    | Blu -> 2
    | Verde -> 3

// Funzione month -> int che associa ad ogni mese il numero di giorni
type month =
    | January
    | February
    | March
    | April
    | May
    | June
    | July
    | August
    | September
    | October
    | November
    | December

let days = function
    | February -> 28
    | April|June|August|September|November -> 30
    | _ -> 31

// Tipo figura che contiene rettangoli, quadrati e triangoli
// Rettangolo = base e altezza float
// Quadrato = lato float
// Triangolo = base e altezza float
type figure =
    | Rettangolo of float * float
    | Quadrato   of float
    | Triangolo  of float * float

// Funzione area figure -> float che calcola l'area della figura
let area f =
    match f with
    | Rettangolo(b,h) -> b * h
    | Quadrato(l) -> l * l
    | Triangolo(b,h) -> b * h / 2.0

// Tagged value utili per distinguere due tipi che "lavorano" sullo stesso dominio
// Nel primo caso si ha la creazione di un alias
// Viene usato il pattern matching per far capire alla funzione che la coppia è voto2 * matricola2
type voto1 = int
type matricola1 = int

type voto2 = V of int
type matricola2 = M of int

let print (v,m) =
    match (v,m) with
    | (V v1, M m1) -> string (v1) + " in programmazione 2 by " + string (m1)