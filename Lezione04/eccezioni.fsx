// Metodo flessibile e informativo per gestire gli errori, ma molto dispendioso
// Segnalano la violazione dinamica degli errori

// Eccezioni pre-definite in F#
// System.DivideByZeroException
let x = 1 / 0

// Funzioni built-in
// failwith string -> a'
// failwith StringFormat -> a'
// invalidArg string -> string -> a' con parametro + messaggio

// La gestione delle eccezioni avviene con un blocco try-with
let divide0 x y =
    try
        string (x / y)
    with
        | :? System.DivideByZeroException -> "Division by zero"
        | _ -> "Something else gone wrong"

let anotherDivide0 x y =
    try
        string (x / y)
    with
        Failure msg -> msg

// Eccezioni user-defined con l'uso di raise
// Eccezioni possono anche "prendere" valori nel costruttore con "exception nome of tipo"
exception NegativeFactorialException

let rec fact n =
    match n < 0 with
    | true -> raise NegativeFactorialException
    | false ->
        match n with
        | 0 -> 1
        | _ -> n * fact (n-1)

// Uso di Result, che vale Ok o Error
type address = {Name : string; Email : string}

let validateAddress a =
    match a.Name with
    | "" -> Error "Name is empty"
    | "Paky" -> Error "Capo della trap, non puoi metterlo qua"
    | _ -> Ok a

// Eccezioni utili per modificare il flusso di controllo