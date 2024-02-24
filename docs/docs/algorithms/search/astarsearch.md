# AStarSearch<T> Class

**A* Search algorithm implementation for finding the shortest path in a weighted graph.**

## AStarSearch<T> Class Members

```csharp
SearchAStar(
    Dictionary<T, List<(T, int)>> graph,
    T start,
    T goal,
    Func<T, T, int> heuristic)
```

Performs A* search on a weighted graph to find the shortest path from the start to the goal.

## Parameters

- `graph` (Type: `Dictionary<T, List<(T, int)>>`): The weighted graph represented as a dictionary.
- `start` (Type: `T`): The starting node.
- `goal` (Type: `T`): The goal node.
- `heuristic` (Type: `Func<T, T, int>`): Heuristic function estimating the cost from a node to the goal.

## Returns

- Type: `List<T>`
- Description: The shortest path from the start to the goal.

## Example

```csharp
using NetPlus.Algorithms.Search;

// Example weighted graph represented as a dictionary
var weightedGraph = new Dictionary<int, List<(int, int)>>
{
    { 0, new List<(int, int)> { (1, 5), (2, 3) } },
    { 1, new List<(int, int)> { (3, 7) } },
    { 2, new List<(int, int)> { (4, 2) } },
    { 3, new List<(int, int)> { (5, 1) } },
    { 4, new List<(int, int)> { (5, 5) } },
    { 5, new List<(int, int)> { } }
};

// Heuristic function (Euclidean distance in this case)
Func<int, int, int> euclideanHeuristic = (node, goal) =>
{
    // Implement your heuristic function here
    return Math.Abs(node - goal);
};

// Performing A* search
var shortestPath = AStarSearch<int>.SearchAStar(weightedGraph, 0, 5, euclideanHeuristic);

// Displaying the shortest path
Console.WriteLine(string.Join(" -> ", shortestPath));
```

## Usage

To use the AStarSearch<T> class, simply call the `SearchAStar` method with the appropriate parameters.

```csharp
// Example usage
var shortestPath = AStarSearch<int>.SearchAStar(weightedGraph, startNode, goalNode, heuristicFunction);
```

## Remarks

The `AStarSearch<T>` class uses the A* Search algorithm to find the shortest path in a weighted graph. It requires a heuristic function to estimate the cost from a node to the goal.

```csharp
// Example of a custom heuristic function
Func<int, int, int> customHeuristic = (node, goal) =>
{
    // Implement your custom heuristic function here
    return Math.Abs(node - goal) * 2;
};

// Performing A* search with a custom heuristic function
var customShortestPath = AStarSearch<int>.SearchAStar(weightedGraph, 0, 5, customHeuristic);
```

In the above example, a custom heuristic function is used to perform A* search with a different estimation of the cost from a node to the goal.
