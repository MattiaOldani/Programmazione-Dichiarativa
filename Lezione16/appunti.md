# Altri appunti su argomenti molto noiosi

## Equivalenza tra programmi
Due programmi $\Pi_1$ e $\Pi_2$ sono **equivalenti** se e solo se, per ogni query $Q$ e ogni sostituzione $\sigma$, $Q \sigma$ è provabile in $\Pi_1$ se e solo se $Q \sigma$ è provabile in $\Pi_2$

Partiamo da due programmi $\Pi_1, \Pi_2$ e applichiamo a $\Pi_1$ le seguenti trasformazioni:
* cambio d'ordine delle formule del corpo di una clausola
* cambio d'ordine delle regole

Se $\Pi_2$ si ottiene applicando queste trasformazioni a $\Pi_1$ allora i due programmi sono equivalenti