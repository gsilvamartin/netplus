# BreadthFirstSearch Class

**Class for performing Breadth-First Search (BFS) on a graph.**

## Class Members

```csharp
BreadthFirstSearch(Dictionary<T, List<T>> graph)
```

Initializes a new instance of the BreadthFirstSearch class.

### Parameters

- `graph` (Type: `Dictionary<T, List<T>>`): The graph represented as an adjacency list.

```csharp
ExecuteBfs(T start)
```

Executes Breadth-First Search (BFS) starting from the specified vertex.

### Parameters

- `start` (Type: `T`): The starting vertex for BFS.

### Returns

- Type: `List<T>`
- Description: A list of vertices visited in BFS order.

### Example

```csharp
using NetPlus.Algorithms.Graphs;

// Example graph
Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>
{
    { "A", new List<string> { "B", "C" } },
    { "B", new List<string> { "A", "D", "E" } },
    { "C", new List<string> { "A", "F" } },
    { "D", new List<string> { "B" } },
    { "E", new List<string> { "B", "F" } },
    { "F", new List<string> { "C", "E" } }
};

// Initialize BFS
var bfs = new BreadthFirstSearch<string>(graph);

// Execute BFS from vertex A
List<string> visitedVertices = bfs.ExecuteBfs("A");

// Display visited vertices
foreach (var vertex in visitedVertices)
    Console.WriteLine(vertex);
```

### Usage

To use the `BreadthFirstSearch` class, initialize it with the graph represented as an adjacency list, then call the `ExecuteBfs` method with the starting vertex.

```csharp
// Example usage
var bfs = new BreadthFirstSearch<string>(graph);
List<string> visitedVertices = bfs.ExecuteBfs("A");
```

### Remarks

The `BreadthFirstSearch` class performs Breadth-First Search (BFS) on a graph represented as an adjacency list. It returns a list of vertices visited in BFS order.
