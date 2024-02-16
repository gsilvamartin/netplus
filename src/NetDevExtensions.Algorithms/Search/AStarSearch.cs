using NetDevExtensions.Algorithms.Search.Util;

namespace NetDevExtensions.Algorithms.Search;

public static class AStarSearch<T> where T : notnull
{
    public static List<T> SearchAStar(
        Dictionary<T, List<(T, int)>> graph,
        T start,
        T goal,
        Func<T, T, int> heuristic)
    {
        if (start.Equals(goal)) return [];

        var openSet = new HashSet<T>();
        var cameFrom = new Dictionary<T, T>();
        var gScore = new Dictionary<T, int>();
        var fScore = new Dictionary<T, int>();

        InitializeValues(graph.Keys, start, gScore, fScore, heuristic);

        var priorityQueue = new PriorityQueue<T>();
        priorityQueue.Enqueue(start, fScore[start]);
        openSet.Add(start);

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue().Item1;
            openSet.Remove(current);

            if (current.Equals(goal))
            {
                return ReconstructPath(cameFrom, current);
            }

            ProcessNeighbors(graph, current, goal, heuristic, gScore, fScore, cameFrom, openSet, priorityQueue);
        }

        return [];
    }

    private static void InitializeValues(
        IEnumerable<T> vertices,
        T start,
        IDictionary<T, int> gScore,
        IDictionary<T, int> fScore,
        Func<T, T, int> heuristic)
    {
        foreach (var vertex in vertices)
        {
            gScore[vertex] = int.MaxValue;
            fScore[vertex] = int.MaxValue;
        }

        gScore[start] = 0;
        fScore[start] = heuristic(start, start);
    }

    private static void ProcessNeighbors(
        IReadOnlyDictionary<T, List<(T, int)>> graph,
        T current,
        T goal,
        Func<T, T, int> heuristic,
        IDictionary<T, int> gScore,
        IDictionary<T, int> fScore,
        IDictionary<T, T> cameFrom,
        ISet<T> openSet,
        PriorityQueue<T> priorityQueue)
    {
        foreach (var (neighbor, cost) in graph[current])
        {
            var tentativeGScore = gScore[current] + cost;

            if (tentativeGScore >= gScore[neighbor])
            {
                continue;
            }

            UpdateScores(current, neighbor, tentativeGScore, goal, heuristic, gScore, fScore, cameFrom, openSet,
                priorityQueue);
        }
    }

    private static void UpdateScores(
        T current,
        T neighbor,
        int tentativeGScore,
        T goal,
        Func<T, T, int> heuristic,
        IDictionary<T, int> gScore,
        IDictionary<T, int> fScore,
        IDictionary<T, T> cameFrom,
        ISet<T> openSet,
        PriorityQueue<T> priorityQueue)
    {
        cameFrom[neighbor] = current;
        gScore[neighbor] = tentativeGScore;
        fScore[neighbor] = gScore[neighbor] + heuristic(neighbor, goal);

        if (openSet.Contains(neighbor)) return;

        priorityQueue.Enqueue(neighbor, fScore[neighbor]);
        openSet.Add(neighbor);
    }

    private static List<T> ReconstructPath(IReadOnlyDictionary<T, T> cameFrom, T current)
    {
        var path = new List<T> { current };

        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Add(current);
        }

        path.Reverse();

        return path;
    }
}