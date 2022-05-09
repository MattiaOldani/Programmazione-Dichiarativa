# Programmazione logica

## Struttura di un programma
Possiamo pensare un programma come una serie di clausole

Una **clausola** è formata da $2$ parti:
* **corpo**: serie di formule atomiche $B_1, \, \dots \, , B_n$ chiamate **premesse**
* **testa**: serie di formule atomiche $H_1, \, \dots \, , H_n$ chiamate **conseguenze**

Se valgono $B_1, \, \dots \, , B_n$ allora valgono $H_1, \, \dots \, , H_n$

Esistono delle clausole particolari dette **fatti** o **assiomi**, caratterizzate dall'assenza di premesse

## Sostituzione e applicazione
Dato un programma $\Pi$,  una **sostituzione** $\sigma$ è una lista di assegnamenti $X = t$, dove $X$ è una variabile e $t$ è un termine di $\Pi$; si assume che $X$ non occorra in $\Pi$

Un'**applicazione** di una regola $r$ si ottiene applicando una sostituzione $\sigma$ alle premesse e alle conclusioni di $r$

Per evitare ambiguità con i nomi di solito si effettua una rinomina delle variabili, andando a ottenere una **variante**

Dal punto di vista logico, l'applicazione di una regola rappresenta un passo di inferenza; dal punto di vista computazionale invece rappresenta la ricerca di una prova che validi le premesse e quindi anche le conseguenze

Un **unificatore** tra una formula atomica $G$ e una regola $r$ con conseguenza $H$ è una sostituzione $\sigma$ tale che $G \sigma = H \sigma$; in generale si possono avere più unificatori: in questo caso si sceglie il **most general unifier** (MGU)

## Proof tree
Un **proof tree** $\tau$ è un albero formato dalle formule del programma $\Pi$; se una foglia contiene un fatto, allora è chiamata **foglia chiusa**

Se $\tau$ ha come foglie solo foglie chiuse e $G$ è la formula presente nella radice, allora $\tau$ è detto **derivazione** di $G$ in $\Pi$; inoltre, si dice che $G$ è provabile in $\Pi$ se e solo se esiste una derivazione di $G$ in $\Pi$

## Query
Una **query** $Q$ di un programma $\Pi$ è una formula atomica di $\Pi$ che può contenere delle variabili; una **soluzione** alla query è una sostituzione $\sigma$ definita sulle variabili che occorrono in $Q$ che rende $Q \sigma$ provabile in $\Pi$

Le query possono non avere soluzione oppure averne $1$ o più; un caso particolare sono le **ground query**, ovvero le query che non hanno occorrenze di variabili e che quindi hanno come unica sostituzione possibile quella vuota

## Proof search
La ricerca di una soluzione in Twelf avviene seguendo un approccio goal-oriented, ovvero si parte dalla query $Q$ che si vuole verificare e si espande l'albero di derivazione utilizzando le clausole del programma; se una derivazione porta ad una foglia aperta che non può essere verificata, si effettua il backtracking

Se si ottiene un albero con solo foglie chiuse, allora ho trovato una sostituzione per $Q$

Per mostrare la lista delle clausole applicate, in Twelf si utilizza `%solve name : query.`