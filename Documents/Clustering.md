# Clustering

### Этап 1 - Определяем классы по кластерам (предварительно)

![pic](Classes.png)

### Этап 2 - Примеряем Event Storming на систему, чтобы нарисовать модель взаимодействия

![pic](EventStorming)

### Этап 3 - Финализируем кластера

![pic](Clustered.png)

Получились следующие кластеры из множества классов:
1. Tiles Generator (Состав классов: TilesFactory, Tile, TilesQueue)
2. Game Creator (Состав классов: Board, BoardManager)
3. Player's Move (Состав классов: Player, Bonus, ComboList)
4. Tiles Shifter (Состав классов: TileSet)
5. Game Watcher (Состав классов: Game, GameWatcher)
6. Statistics Displaying (Состав классов: Statistics)
