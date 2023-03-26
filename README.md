# Scripting
Nuestro juego a diferencia de la base original del fake-ad de torres, nosotros nos basaremos en el sistema de "Dungeon" la cual no implementa torres, si no, cuartos, en los cuales se puede pasar de uno en un radio de 1 casilla. A nivel de armamento nos diferenciamos en que las armadauras tienen elementos que funciona como buffs o debuffs de daño, puesto que hay un tipo de enemgigo que hace daño con elementos, y las armas que se recogen en el caminos son "Stackeables" osea que se pueden tener todas las necesarias y almacenarlas.

## Cambios Con respecto a la primera entrega

1 - Primero se iban a tener las "Torres" que eran Stacks, dentro de una lista se contenían los Stacks que almacenaba a los enemigos. Ahora la forma en la que va a funcionar sería con una matriz de 2 dimensiones en las que se comparan los elementos dentro de la misma matriz.

2 - Se añadio una nueva clase llamada "Grid" la cual va a definir visualmente la matriz dentro del editor de Unity, donde también se podrán ver los datos almacenados.
