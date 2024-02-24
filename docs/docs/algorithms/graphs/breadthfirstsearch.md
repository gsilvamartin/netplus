# DepthFirstSearch Class

**Class for performing Depth-First Search (DFS) on a graph.**

## Class Members

```csharp
DepthFirstSearch(Dictionary<T, List<T>> graph)
```

Initializes a new instance of the DepthFirstSearch class.

### Parameters

- `graph` (Type: `Dictionary<T, List<T>>`): The graph represented as an adjacency list.

```csharp
ExecuteDfs(T start)
```

Executes Depth-First Search (DFS) starting from the specified vertex.

### Parameters

- `start` (Type: `T`): The starting vertex for DFS.

### Returns

- Type: `List<T>`
- Description: A list of vertices visited in DFS order.

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

// Initialize DFS
var dfs = new DepthFirstSearch<string>(graph);

// Execute DFS from vertex A
List<string> visitedVertices = dfs.ExecuteDfs("A");

// Display visited vertices
foreach (var vertex in visitedVertices)
    Console.WriteLine(vertex);
```

### Usage

To use the `DepthFirstSearch` class, initialize it with the graph represented as an adjacency list, then call the `ExecuteDfs` method with the starting vertex.

```csharp
// Example usage
var dfs = new DepthFirstSearch<string>(graph);
List<string> visitedVertices = dfs.ExecuteDfs("A");
```

### Remarks

The `DepthFirstSearch` class performs Depth-First Search (DFS) on a graph represented as an adjacency list. It returns a list of vertices visited in DFS order.
