

// keep track of bugs and future features in this file


//////////////*      BUGS        *///////////////////

/*    WASD and Mouse movement
 *   
 *   PROBLEM:
 *   when player uses a combination of mouse and keyboard input
 *   the player movement speed is doubled
 *   
 *   ASSUMED CAUSE:
 *   mouse input and keyboard input are added together then multiplied
 *   to player movement speed and delta time, making the move direction
 *   almost double the intended limit
 *   
 *   FIX:
 *   limit player input vector to 1 in each direction before multiplying
 *   by the player movement speed
 *   
 */