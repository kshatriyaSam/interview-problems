<Query Kind="Program" />

// Consider three identical airplanes starting at the same airport.
// Each plane has a fuel tank that holds just enough fuel to allow the plane to travel half the distance around the world. 
// These airplanes possess the special ability to transfer fuel between their tanks in mid-flight.
// Devise a scheme that will allow one airplane to travel all the way around the world, landing only at the original airport.
// Define other methods and classes here

2 planes start in clockwise direction. At 1/4 distance, plane 1 transfers its fuel to 2nd plane which is half empty. Then 2nd plane can travel 3/4 distance. 
The 3rd plane starts in anticlockwise direction. On reaching 1/4 distance, it meets plane 2nd and transfers the half fuel to it. As the result 
the 2nd plane completes the remaining travel.