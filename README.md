# CS410-assignment2

Dot Product (Emily): Dot product was used in the observer.cs script to replace the method of detecting if a player was near. The detection radius was set to 1, and the detection angle was set to 90 degrees which is how large of an angle the enemy can see from. These measures can be changed in order to make the game more or less difficult. This addition of dot product also makes it so the player can be around or behind the enemy when moving around the maze. The player is only detected if it is in the angle of the enemy. 

Linear Interpolation (Sawyer): Linear Interpolation was used in the PlayerMovement.cs script to modify the movement vector of the player. There is now a movement speed variable, and a linear interpolation factor that both affect how fast the player moves. It does this by calculating a target destination with the movement speed, and then linearly interpolates between the current position and target destination by the interpolation factor, giving a vector that is a mix of the two.

Particle Effect (Eliza): a particle effect was used in PlayerMovement.cs in conjunction with a timer. A timer counts up when the player is not moving, and resets when the player begins to move again. If the timer hits 5 seconds, a red particle effect (mimicking an explosion or a spell) appears and the player disappears, stopping gameplay. This creates a new gameplay rule: that the player must not pause and hide for more than five seconds. 

Sound Effect (Group Effort): an explosion sound was applied to the Observer.cs script, which is attached to the enemy objects. When the player gets within a close radius of a Gargoyle, the sound plays. The functionality to detect the radius is applied from the Dot Product addition in Observer.cs, with a new, wider radius applied for this use. 

Sources used: https://www.youtube.com/watch?v=MB7d3MdVHwU and ChatGPT
