# Match-3 Console Game

Match-three is a popular puzzle game where players swap and match tiles to create sets of three or more identical elements. 

In that console game players must use their skills to clear the board by matching elements in rows or columns. The goal is to remove as many elements as possible within a given time. 

### How to play

- After the game started you have to provide coords of an adjacment tiles to replace. The replacement will take place only if afterwards there is a match with at least 3 elements in a row or column.
- After match is ocuried the similar in a chain will be eliminated (if you are lucky enough, sometime you will get a bonuses after elimination).
- The game will end, if it is nothing to replace or time is up.
- You can restart or quit at any time you want, just press the command:
  - `-p` (for pause and displaying statistics)
  - `-q` (for quiting the game and displaying statistics)
  - `-r` (for restarting)

### Entities

1. Tile Matrix with elements -> **Board**
   1. Size 8x8
   2. Horizontal annotations: A-H
   3. Vertical annotations: 1-8
   4. 64 tiles in total
2. Board **Tile**, which is the main base class for all board elements
   1. Identifies like A1
   2. Contains tile type info
3. **Player**
   1. Runs and ends a game
   2. Enters a coords of tiles for replacing (eg, 1A 2A)
   3. Displays statistics
   4. Gets and stores bonuses: tricky combos (eg., 4 in a row, 5 in a cross and etc.)
   5. Uses bonuses
4. Game statistics -> **Dashboard**
   1. Collects removed elements info (every element in a row provides 10 points, if row contains more than 3, than more points provided)
   2. Collects info about players moves
5. Tiles **Generator**
   1. On start or restart generates tiles for board
   2. Generates new tiles on request
6. **Board Manager**
   1. Replaces selected tiles on board on player request
   2. Checks the conditions of removing tiles
   3. Shift down elements to the empty tiles
   4. Invokes a generator if void exists on the board top
   5. Every move check the board for conditions
   6. End the game if there is no possible moves left or time is up
7. **Bonus**
   1. Changes the game behaviour when player uses (remove all elements with one type, remove all row or column).
   2. Automaticly applies on next player move
