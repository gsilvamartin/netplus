namespace NetDevExtensions.Algorithms.Graph;

public class BreadthFirstSearch<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _adjacencyList;

    public BreadthFirstSearch(Dictionary<T, List<T>> graph)
    {
        _adjacencyList = graph;
    }

    public List<T> ExecuteBfs(T start)
    {
        var visitedVertices = new List<T>();
        var visited = new Dictionary<T, bool>();
        var queue = new Queue<T>();

        foreach (var vertex in _adjacencyList.Keys) visited[vertex] = false;

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            visitedVertices.Add(current);

            foreach (var neighbor in _adjacencyList[current].Where(neighbor => !visited[neighbor]))
            {
                queue.Enqueue(neighbor);
                visited[neighbor] = true;
            }
        }

        return visitedVertices;
    }
}