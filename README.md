# NavigationBySvetlinStoychev
# SvetlioMaps

## Instructions:

   1. Open this link: https://replit.com/@SvetlinStoychev/NavigationBySvetlinStoychev
   2. Click on play button
   3. Enjoy


SvetlioMaps is a C# program that allows you to search for the shortest path between cities on a map. It implements Dijkstra's algorithm to find the optimal route and provides distance information between the chosen start and end cities.

## Features

- Creation of a map with cities and distances between them
- Search for the shortest path between two cities
- Display of the shortest path and distance information
- User-friendly interface for inputting start and end points
- Customizable map data through a text file

## Getting Started

To get started with SvetlioMaps, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/SvetlioMaps.git`
2. Open the project in your preferred C# development environment.
3. Build the project to ensure all dependencies are resolved.
4. Run the program and follow the on-screen instructions to search for the shortest path between cities.

## Usage

1. When the program starts, you will be prompted to enter the start and end points for your route. The input should be integers representing the city codes.
2. After entering the start and end points, the program will search for the shortest path and display the results.
3. The results will include the distance between the start and end cities, as well as the cities that the shortest path passes through.

## Customizing Map Data

The map data is read from a text file named "map.txt" in the program's directory. To customize the map data, follow these steps:

1. Open the "map.txt" file in a text editor.
2. Each line represents a connection between two cities, with the format: `startCityCode endCityCode distance`
3. Modify or add lines to represent the desired connections between cities.
4. Save the "map.txt" file.

Note: The city codes and names are predefined in the program and cannot be modified through the text file. If you want to change the city names or codes, you need to modify the code directly in the `CreateTownsNames` method of the `MapsAndSearch` class.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgements

The implementation of Dijkstra's algorithm in this project is inspired by the following resources:

- [Dijkstra's Algorithm - Wikipedia](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm)
- [Dijkstra's Algorithm in C# - GeeksforGeeks](https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/)

## Screenshot
![1](https://github.com/SvetlinStoychev/NavigationBySvetlinStoychev/assets/133974226/82a727c5-0d2e-438e-ae18-5f9e0a7eab9a)
![2](https://github.com/SvetlinStoychev/NavigationBySvetlinStoychev/assets/133974226/4f74a6ad-4fc7-4f8f-8664-dfcd582f99f4)


