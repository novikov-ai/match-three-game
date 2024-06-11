# Defining bounds of a new system

### System's parts

1. Game board / level - the main element, where all interaction happens
2. Level components creation mechanics
3. User interaction with components
4. Components management after player interaction

### Main subsystems

1. Accumulation and displaying game statistics
2. Bonuses system (sum up points after removing tiles)
3. Game boards customization (levels mechanic)
4. Time tracking

### User's metaphors

1. Game board / level
2. Tiles / board components
3. Player (interacts with tiles)
4. Bonuses system (special abilities while interaction with tiles)

### Functionality

1. Player:
   1. Run/Stop the game
   2. Tiles interaction
   3. Bonuses accumulation
   4. Bonuses usage
   5. Displaying statistics
2. Game:
   1. A new level creation
   2. Replacing and removing tiles after user interaction
   3. Game ending if there is no moves left

### Reusable libraries

1. Board rendering with all components (tiles)
2. Tiles generation
3. Displaying game statistics