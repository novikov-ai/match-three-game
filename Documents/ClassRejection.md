# Class Rejection

### Reject if

1. It encapsulates an action or a function and doesn't specify data structure with unique operations set (Verbal naming)
2. It answers "what it does?". It has to have equal operations.
3. It continues or starts a new classes hierarchy. 
4. It doesn't have any methods (doesn't implement ADT).
5. It doesn't have it's own fields or just a few.
6. It contains only queries, but not commands. Exceptions: DB drivers and etc., patterns (factory) and preferential inheritance (class with constants set only).
7. It has more than one abstractions. 

### Отбраковываем плохие классы после анализа

Класс `Cell`, который задает ячейку на игровом поле, выглядит подходящим кандидатом на отбраковку. Он ничего не делает кроме выполнения роли ячейки для последующего компонента на уровне (`Tile`). То есть фактически начинает иерархию классов и при этом не предполагает каких-либо методов. 

На текущем этапе анализа класс `Move` как будто не имеет своих методов, так как является совокупностью данных о передвижениях игрока на уровне. Если исключаем данный класс, то класс `MovesList` также становится бесполезным и отбраковывается. 