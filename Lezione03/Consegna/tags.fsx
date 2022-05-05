// Tipo figure che modella 3 diverse figure geometriche
type figure =
    | Rettangolo of float * float
    | Quadrato   of float
    | Triangolo  of float * float

// Funzione figure -> bool che controlla se una figura è ben formata
let wellFormed f =
    match f with
    | Rettangolo(b,h)|Triangolo(b,h) -> b >= 0 && h >= 0
    | Quadrato(l) -> l >= 0

// Funzione figure -> float che calcola l'area della figura
let area f =
    match f with
    | Rettangolo(b,h) -> b * h
    | Quadrato(l) -> l * l
    | Triangolo(b,h) -> b * h / 2.0

// Funzione figure -> float option che calcola l'area della figura con option
let wellArea f =
    match wellFormed f with
    | true -> Some (area f)
    | false -> None

// Funzione figure -> string che restituisce l'area di una figura sotto forma di stringa
// Se la figura non è ben formata, ritorna un messaggio di errore
let printArea f =
    match wellFormed f with
    | true -> "Area: " + string (area f)
    | false -> "La figura non è ben definita"

// Funzione figure * figure -> float option che restituisce la somma delle aree delle due figure
// Se almeno una non è ben formata, allora ritornare None
let sumArea (f1,f2) =
    match wellFormed f1 && wellFormed f2 with
    | true -> Some (area f1 + area f2)
    | false -> None

// Funzione figure list -> float che calcola la somma di tutte le aree della lista
// Se almeno una non è ben formata, la somma vale 0
let rec sumAreaList f =
    match f with
    | [] -> 0.0
    | y::ys -> if wellFormed y then area y + sumAreaList ys else sumAreaList ys

// Nuovi tipi point e shape
type point =
    | Point of float * float

type shape =
    | Circle    of point * float
    | Rectangle of point * point

// Funzione area shape -> float che calcola l'area dato un tipo shape
let shapeArea s =
    match s with
    | Circle(p,r) -> System.Math.PI * r * r
    | Rectangle(p1, p2) -> 
        let (Point(x1,y1)) = p1
        let (Point(x2,y2)) = p2
        System.Math.Abs (x1-x2) * System.Math.Abs (y1-y2)

// Funzione shape -> point che calcola il centro di una figura
let center s =
    match s with
    | Circle(p,r) -> p
    | Rectangle(Point(x1,y1), Point(x2,y2)) -> Point ((x1+x2) / 2.0, (y1+y2) / 2.0)
