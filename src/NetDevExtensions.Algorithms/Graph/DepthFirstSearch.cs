namespace NetDevExtensions.Algorithms.Graph;

public class DepthFirstSearch<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _adjacencyList;

    public DepthFirstSearch(Dictionary<T, List<T>> graph)
    {
        _adjacencyList = graph;
    }

    public List<T> ExecuteDfs(T start)
    {
        var visitedVertices = new List<T>();
        var visited = new Dictionary<T, bool>();

        foreach (var vertex in _adjacencyList.Keys) visited[vertex] = false;

        ExecuteDfs(start, visited, visitedVertices);

        return visitedVertices;
    }

    private void ExecuteDfs(T current, Dictionary<T, bool> visited, List<T> visitedVertices)
    {
        visited[current] = true;
        visitedVertices.Add(current);

        foreach (var neighbor in _adjacencyList[current].Where(neighbor => !visited[neighbor]))
            ExecuteDfs(neighbor, visited, visitedVertices);
    }
}