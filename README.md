# CS410-assignment2

Dot product (Emily): Dot product was used in the observer.cs script to replace the method of detecting if a player was near. The detection radius was set to 1, and the detection angle was set to 90 degrees which is how large of an angle the enemy can see from. These measures can be changed in order to make the game more or less difficult. This addition of dot product also makes it so the player can be around or behind the enemy when moving around the maze. The player is only detected if it is in the angle of the enemy. 

Linear Interpolation (Sawyer): Linear Interpolation was used in the PlayerMovement.cs script to modify the movement vector of the player. There is now a movement speed variable, and a linear interpolation factor that both affect how fast the player moves. It does this by calculating a target destination with the movement speed, and then linearly interpolates between the current position and target destination by the interpolation factor, giving a vector that is a mix of the two.

Source used: https://www.youtube.com/watch?v=MB7d3MdVHwU and chat gpt

