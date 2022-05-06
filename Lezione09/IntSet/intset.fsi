module IntSet

// Nome del tipo di dato astratto
type IntSet

// Crea un IntSet vuoto
val empty : IntSet

// Ritorna 'true' se l'insieme è vuoto, 'false' altrimenti
val isEmpty : IntSet -> bool

// Ritorna 'true' se l'insieme contiene l'intero passato come parametro, 'false' altrimenti
val contains : int -> IntSet -> bool

// Aggiunge l'elemento passato come parametro all'insieme
val add : int -> IntSet -> IntSet

// Unisce gli elementi del secondo insieme agli elementi del primo insieme
val union : IntSet -> IntSet -> IntSet

// Crea un insieme data la lista degli elementi
val ofList : int list -> IntSet

// Crea una lista degli elementi contenuti nell'insieme
val toList : IntSet -> int list