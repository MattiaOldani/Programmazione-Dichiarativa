module Queue

// Tipo parametrico
type Queue<'a>

// Eccezione per la coda vuota
exception EmptyQueue

// Crea una nuova coda
val empty : Queue<'a>

// Aggiunge l'elemento alla coda
val put : 'a -> Queue<'a> -> Queue<'a>

// Rimuove il primo elemento e lo ritorna assieme alla coda nuova
val get : Queue<'a> -> 'a * Queue<'a>