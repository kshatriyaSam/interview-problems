<Query Kind="Program" />

// Two robots start at different places on the same linear track.
// What one program can you give to both robots to guarantee that they meet? 
// The the program may consist only of the instructions move_left n, move_right n 
// (where n is the number of spaces to move), if statements while loops, and the boolean values at_own_start and at_other_robots_start
// (note that you can't use other variables or counters)

while(!at_other_robots_start)
{
   move_right 1;
}

while(true)
{
	move_right 2;
}


// Define other methods and classes here
