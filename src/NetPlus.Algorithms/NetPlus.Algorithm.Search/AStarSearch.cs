using System;
using System.Collections.Generic;
using NetPlus.Algorithms.Search.Util;

namespace NetPlus.Algorithms.Search
{
    /// <summary>
    /// A* Search algorithm implementation for finding the shortest path in a weighted graph.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the graph.</typeparam>
    public static class AStarSearch<T> where T : notnull
    {
        /// <summary>
        /// Performs A* search on a weighted graph to find the shortest path from the start to the goal.
        /// </summary>
        /// <param name="graph">The weighted graph represented as a dictionary.</param>
        /// <param name="start">The starting node.</param>
        /// <param name="goal">The goal node.</param>
        /// <param name="heuristic">Heuristic function estimating the cost from a node to the goal.</param>
        /// <returns>The shortest path from the start to the goal.</returns>
        public static List<T> SearchAStar(
            Dictionary<T, List<(T, int)>> graph,
            T start,
            T goal,
            Func<T, T, int> heuristic)
        {
            if (start.Equals(goal)) return new List<T>();

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

            return new List<T>();
        }

        /// <summary>
        /// Initializes the values of gScore and fScore dictionaries.
        /// </summary>
        /// <param name="vertices">The vertices in the graph.</param>
        /// <param name="start">The starting node.</param>
        /// <param name="gScore">The dictionary storing the cost from the start to each node.</param>
        /// <param name="fScore">The dictionary storing the total estimated cost from the start to each node.</param>
        /// <param name="heuristic">Heuristic function estimating the cost from a node to the goal.</param>
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

        /// <summary>
        /// Processes the neighbors of the current node.
        /// </summary>
        /// <param name="graph">The weighted graph represented as a dictionary.</param>
        /// <param name="current">The current node.</param>
        /// <param name="goal">The goal node.</param>
        /// <param name="heuristic">Heuristic function estimating the cost from a node to the goal.</param>
        /// <param name="gScore">The dictionary storing the cost from the start to each node.</param>
        /// <param name="fScore">The dictionary storing the total estimated cost from the start to each node.</param>
        /// <param name="cameFrom">The dictionary storing the previous node in the optimal path.</param>
        /// <param name="openSet">The set of nodes to be evaluated.</param>
        /// <param name="priorityQueue">The priority queue for managing nodes based on their scores.</param>
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

        /// <summary>
        /// Updates the scores and other data based on a more optimal path to a neighbor node.
        /// </summary>
        /// <param name="current">The current node.</param>
        /// <param name="neighbor">The neighbor node.</param>
        /// <param name="tentativeGScore">The tentative cost from the start to the neighbor node.</param>
        /// <param name="goal">The goal node.</param>
        /// <param name="heuristic">Heuristic function estimating the cost from a node to the goal.</param>
        /// <param name="gScore">The dictionary storing the cost from the start to each node.</param>
        /// <param name="fScore">The dictionary storing the total estimated cost from the start to each node.</param>
        /// <param name="cameFrom">The dictionary storing the previous node in the optimal path.</param>
        /// <param name="openSet">The set of nodes to be evaluated.</param>
        /// <param name="priorityQueue">The priority queue for managing nodes based on their scores.</param>
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

        /// <summary>
        /// Reconstructs the path from the start to the current node.
        /// </summary>
        /// <param name="cameFrom">The dictionary storing the previous node in the optimal path.</param>
        /// <param name="current">The current node.</param>
        /// <returns>The reconstructed path.</returns>
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
}