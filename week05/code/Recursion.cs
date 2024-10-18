using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: If n <= 0, return 0
        if (n <= 0)
            return 0;
        
        // Recursive case: n^2 + sum of squares for (n-1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char letter in letters)
        {
            PermutationsChoose(results, letters.Replace(letter.ToString(), ""), size, word + letter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the ways to climb 's' stairs.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize the remember dictionary if it's null
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base Cases
        if (s < 0)
            return 0; // No ways to climb negative stairs
        if (s == 0)
            return 1; // One way to stay at the ground level
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion and memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways; // Store the result in memoization dictionary
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all binary strings for a given pattern with wildcards.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: If there are no wildcards left, add the pattern to results
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: Replace the first '*' with '0' and '1'
        int wildcardIndex = pattern.IndexOf('*');

        // Replace '*' with '0' and recurse
        WildcardBinary(pattern.Substring(0, wildcardIndex) + '0' + pattern.Substring(wildcardIndex + 1), results);
        
        // Replace '*' with '1' and recurse
        WildcardBinary(pattern.Substring(0, wildcardIndex) + '1' + pattern.Substring(wildcardIndex + 1), results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize currPath list if it's the first time running the function
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add the current position to the path
        currPath.Add((x, y));

        // If current position is the end, add the path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Explore the four possible directions
            // Right
            if (maze.IsValidMove(currPath, x + 1, y))
                SolveMaze(results, maze, x + 1, y, currPath);
            
            // Down
            if (maze.IsValidMove(currPath, x, y + 1))
                SolveMaze(results, maze, x, y + 1, currPath);
            
            // Left
            if (maze.IsValidMove(currPath, x - 1, y))
                SolveMaze(results, maze, x - 1, y, currPath);
            
            // Up
            if (maze.IsValidMove(currPath, x, y - 1))
                SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Remove the current position from path before backtracking
        currPath.RemoveAt(currPath.Count - 1);
    }
}