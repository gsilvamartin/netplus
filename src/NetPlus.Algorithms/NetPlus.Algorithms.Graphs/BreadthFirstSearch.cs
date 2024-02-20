using System.Collections.Generic;
using System.Linq;

namespace NetPlus.Algorithms.Graphs
{
    /// <summary>
    /// Class for performing Breadth-First Search (BFS) on a graph.
    /// </summary>
    /// <typeparam name="T">Type of the vertices in the graph.</typeparam>
    public class BreadthFirstSearch<T> where T : notnull
    {
        // Adjacency list representation of the graph.
        private readonly Dictionary<T, List<T>> _adjacencyList;

        /// <summary>
        /// Initializes a new instance of the BreadthFirstSearch class.
        /// </summary>
        /// <param name="graph">The graph represented as an adjacency list.</param>
        public BreadthFirstSearch(Dictionary<T, List<T>> graph)
        {
            _adjacencyList = graph;
        }

        /// <summary>
        /// Executes Breadth-First Search (BFS) starting from the specified vertex.
        /// </summary>
        /// <param name="start">The starting vertex for BFS.</param>
        /// <returns>A list of vertices visited in BFS order.</returns>
        public List<T> ExecuteBfs(T start)
        {
            var visitedVertices = new List<T>();
            var visited = new Dictionary<T, bool>();
            var queue = new Queue<T>();

            foreach (var vertex in _adjacencyList.Keys)
                visited[vertex] = false;

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
}