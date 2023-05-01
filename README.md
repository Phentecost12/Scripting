# Scripting
Nuestro juego a diferencia de la base original del fake-ad de torres, nosotros nos basaremos en el sistema de "Dungeon" la cual no implementa torres, si no, cuartos, en los cuales se puede pasar de uno en un radio de 1 casilla. A nivel de armamento nos diferenciamos en que las armadauras tienen elementos que funciona como buffs o debuffs de daño, puesto que hay un tipo de enemgigo que hace daño con elementos, y las armas que se recogen en el caminos son "Stackeables" osea que se pueden tener todas las necesarias y almacenarlas.

## Cambios Con respecto a la primera entrega

1 - Primero se iban a tener las "Torres" que eran Stacks, dentro de una lista se contenían los Stacks que almacenaba a los enemigos. Ahora la forma en la que va a funcionar sería con una matriz de 2 dimensiones en las que se comparan los elementos dentro de la misma matriz.

2 - Se añadio una nueva clase llamada "Grid" la cual va a definir visualmente la matriz dentro del editor de Unity, donde también se podrán ver los datos almacenados.

## Cambios Con respecto a la segunda entrega

1 - Para la implementacion de los menus y el comportamiento de la camara se implementaron nuevas clases encargadas de controlar dichas funciones: las clases que se implementaron son: 

    A). Camera Behavior: Controla el movimiento de la camara relativo al jugador.
    
    B). Win_Lose_Manager: Contiene la implementacion de funciones que controla las pantallas de ganar y perder
    
    C). Main_Menu: Controla la UI del menu principal, tambien controla el cambio de escenas. 
    
    D). PauseMenu: Controla el menu de pausa y pausa el juego
    
    E). SettingMenu: Controla el menu de ajustes y la funcionalidad de cambiar el volumen. 
   
2 - El C# del jugador controla la mecanica de Drag & Drop

3 - Se comenzo a implementar patrones de diseños, sobre todo el singleton en algunos managers del juego. 

---- Bugs y faltantes ----
Se desactivaron los enemigos del tipo "MAGO" ya que ocasionaban un bug en donde el jugador no podia derrotar al enemigo, esto se debe a la implementacion que se realizo con los elementos pero no se ha podido saber donde esta el error. 

Falto implementar alguna clase forma de ilustrar la vida actual del jugador. El comienza con 3 de vida y cada ves que derrota a un angel obtiene 1 mas, cuando es derrotado pierde una. 
