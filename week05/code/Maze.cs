// DO NOT MODIFY THIS FILE

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// A maze is defined as a list of lists.  The outer list
    /// contains a representation of each row in the maze.  You can
    /// assume that the maze will be square (same number of rows
    /// and columns). The inner lists show what is in the maze:
    /// 
    /// 0 = Wall (You can't go through this)
    /// 1 = Open Path (You can go through this)
    /// 2 = End (You want to get to this point to win)
    /// 
    /// See the Prove instructions for graphical representations of
    /// the 2 test mazes defined below.
    /// 
    /// The 'IsEnd' and the 'IsValidMove' functions are
    /// already written for you.  These functions assume that the first
    /// square in the maze is (0,0).  These functions also assume
    /// that you can't leave the boundaries of the maze and that you 
    /// can't visit the same square in the same path (no circles).
    /// 
    /// The 'currPath' variable is a list of (x,y) tuples that 
    /// represent the path we are currently on.  If you add a new position
    /// to the path, make sure that you add the tuple to the list so that the
    /// 'IsValidMove' function works properly.
    /// 
    /// The goal is to implement the 'SolveMaze' function to return
    /// all paths to the end square using recursion.  When you find a path, 
    /// then adding it to the return value list will be as simple as 'results.Add(currPath.AsString())'.
    /// </summary>
    /// <summary>
    /// Helper function to determine if the (x,y) position is at 
    /// the end of the maze.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }


    /// <summary>
    /// Helper function to determine if the (x,y) position is a valid
    /// place to move given the size of the maze, the content of the maze,
    /// and the current path already traversed.
    /// </summary>
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        // Can't go outside of the maze boundary (assume maze is a square)
        if (x > Width - 1 || x < 0)
            return false;
        if (y > Height - 1 || y < 0)
            return false;
        // Can't go through a wall
        if (Data[y * Height + x] == 0)
            return false;
        // Can't go if we have already been there (don't go in circles)
        if (currPath.Contains((x, y)))
            return false;
        // Otherwise, we are good
        return true;
    }


    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
{
    // Initialize current path if first call
    if (currPath == null)
        currPath = new List<(int, int)>();

    // Add current position to the path
    currPath.Add((x, y));

    // If current position is the end, record the path and backtrack
    if (maze.IsEnd(x, y))
    {
        results.Add(currPath.AsString());
        currPath.RemoveAt(currPath.Count - 1);
        return;
    }

    // Define all 4 possible directions
    int[] dx = { 0, 0, 1, -1 }; // right, left, down, up
    int[] dy = { 1, -1, 0, 0 };

    for (int i = 0; i < 4; i++)
    {
        int newX = x + dx[i];
        int newY = y + dy[i];

        if (maze.IsValidMove(currPath, newX, newY))
        {
            SolveMaze(results, maze, newX, newY, currPath);
        }
    }

    // Backtrack
    currPath.RemoveAt(currPath.Count - 1);
}

}