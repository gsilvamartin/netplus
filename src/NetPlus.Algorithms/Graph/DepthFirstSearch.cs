namespace NetPlus.Algorithms.Graph;

/// <summary>
/// Class for performing Depth-First Search (DFS) on a graph.
/// </summary>
/// <typeparam name="T">Type of the vertices in the graph.</typeparam>
public class DepthFirstSearch<T> where T : notnull
{
    // Adjacency list representation of the graph.
    private readonly Dictionary<T, List<T>> _adjacencyList;

    /// <summary>
    /// Initializes a new instance of the DepthFirstSearch class.
    /// </summary>
    /// <param name="graph">The graph represented as an adjacency list.</param>
    public DepthFirstSearch(Dictionary<T, List<T>> graph)
    {
        _adjacencyList = graph;
    }

    /// <summary>
    /// Executes Depth-First Search (DFS) starting from the specified vertex.
    /// </summary>
    /// <param name="start">The starting vertex for DFS.</param>
    /// <returns>A list of vertices visited in DFS order.</returns>
    public List<T> ExecuteDfs(T start)
    {
        var visitedVertices = new List<T>();
        var visited = new Dictionary<T, bool>();

        // Initialize all vertices as not visited.
        foreach (var vertex in _adjacencyList.Keys)
            visited[vertex] = false;

        // Perform DFS traversal.
        ExecuteDfs(start, visited, visitedVertices);

        return visitedVertices;
    }

    /// <summary>
    /// Recursive method to perform DFS traversal from the current vertex.
    /// </summary>
    /// <param name="current">The current vertex being visited.</param>
    /// <param name="visited">A dictionary to track visited vertices.</param>
    /// <param name="visitedVertices">A list to store visited vertices in DFS order.</param>
    private void ExecuteDfs(T current, Dictionary<T, bool> visited, List<T> visitedVertices)
    {
        visited[current] = true;
        visitedVertices.Add(current);

        // Visit neighbors of the current vertex that are not visited.
        foreach (var neighbor in _adjacencyList[current].Where(neighbor => !visited[neighbor]))
            ExecuteDfs(neighbor, visited, visitedVertices);
    }
}