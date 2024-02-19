using NetPlus.Algorithms.Search;

namespace NetStringExtensions.Tests.Algorithms.Search;

public class AStarSearchTests
{
    [Fact]
    public void SearchAStar_ShouldFindPath_WhenPathExistsInGraph()
    {
        var graph = new Dictionary<int, List<(int, int)>>()
        {
            { 1, [(2, 1), (3, 2)] },
            { 2, [(1, 1), (4, 3)] },
            { 3, [(1, 2), (5, 4)] },
            { 4, [(2, 3), (6, 5)] },
            { 5, [(3, 4), (7, 6)] },
            { 6, [(4, 5), (8, 7)] },
            { 7, [(5, 6)] },
            { 8, [(6, 7)] },
        };

        var heuristic = new Func<int, int, int>((current, goal) => Math.Abs(current - goal));

        var path = AStarSearch<int>.SearchAStar(graph, 1, 7, heuristic);

        Assert.NotNull(path);
        Assert.Equal([1, 3, 5, 7], path);
    }

    [Fact]
    public void SearchAStar_ShouldReturnEmptyPath_WhenPathDoesNotExistInGraph()
    {
        var graph = new Dictionary<int, List<(int, int)>>()
        {
            { 1, [(2, 1), (3, 2)] },
            { 2, [(1, 1), (4, 3)] },
            { 3, [(1, 2), (5, 4)] },
            { 4, [(2, 3), (6, 5)] },
            { 5, [(3, 4), (7, 6)] },
            { 6, [(4, 5), (8, 7)] },
            { 7, [(5, 6)] },
            { 8, [(6, 7)] },
        };

        var heuristic = new Func<int, int, int>((current, goal) => Math.Abs(current - goal));

        var path = AStarSearch<int>.SearchAStar(graph, 1, 9, heuristic);

        Assert.Empty(path);
    }

    [Fact]
    public void SearchAStar_ShouldFindPath_WhenPathExistsInMaze()
    {
        var maze = new int[,]
        {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
        };

        var heuristic = new Func<(int, int), (int, int), int>((current, goal) =>
            Math.Abs(current.Item1 - goal.Item1) + Math.Abs(current.Item2 - goal.Item2));

        var path = AStarSearch<(int, int)>.SearchAStar(MazeToGraph(maze), (0, 0), (4, 4), heuristic);

        Assert.NotNull(path);
        Assert.Contains((1, 0), path);
        Assert.Contains((2, 0), path);
        Assert.Contains((3, 0), path);
        Assert.Contains((4, 0), path);
        Assert.Contains((4, 1), path);
        Assert.Contains((4, 2), path);
        Assert.Contains((4, 3), path);
        Assert.Contains((4, 4), path);
    }

    [Fact]
    public void SearchAStar_ShouldReturnEmptyPath_WhenPathDoesNotExistInMaze()
    {
        var maze = new int[,]
        {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
        };

        var heuristic = new Func<(int, int), (int, int), int>((current, goal) =>
            Math.Abs(current.Item1 - goal.Item1) + Math.Abs(current.Item2 - goal.Item2));

        var path = AStarSearch<(int, int)>.SearchAStar(MazeToGraph(maze), (0, 0), (4, 5), heuristic);

        Assert.Empty(path);
    }

    [Fact]
    public void SearchAStar_ShouldReturnEmptyPath_WhenMazeIsEmpty()
    {
        var maze = new int[0, 0];

        var heuristic = new Func<(int, int), (int, int), int>((current, goal) =>
            Math.Abs(current.Item1 - goal.Item1) + Math.Abs(current.Item2 - goal.Item2));

        var path = AStarSearch<(int, int)>.SearchAStar(MazeToGraph(maze), (0, 0), (0, 0), heuristic);

        Assert.Empty(path);
    }

    private static Dictionary<(int, int), List<((int, int), int)>> MazeToGraph(int[,] maze)
    {
        var graph = new Dictionary<(int, int), List<((int, int), int)>>();

        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (maze[i, j] == 0)
                {
                    var neighbors = new List<((int, int), int)>();

                    if (i - 1 >= 0 && maze[i - 1, j] == 0)
                        neighbors.Add(((i - 1, j), 1));

                    if (i + 1 < rows && maze[i + 1, j] == 0)
                        neighbors.Add(((i + 1, j), 1));

                    if (j - 1 >= 0 && maze[i, j - 1] == 0)
                        neighbors.Add(((i, j - 1), 1));

                    if (j + 1 < cols && maze[i, j + 1] == 0)
                        neighbors.Add(((i, j + 1), 1));

                    graph[(i, j)] = neighbors;
                }
            }
        }

        return graph;
    }
}