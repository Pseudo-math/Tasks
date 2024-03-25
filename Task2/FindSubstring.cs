using System;


public class Algorithms
{
    public static bool IsSubstring(string str, string sub)
    {
        var strLength = str.Length;
        var subLength = sub.Length;
        
        for (var i = 0; i <= (strLength - subLength); ++i)
        {
            for (var j = 0; j < subLength && str[i + j] == sub[j]; ++j)
            {
                if (j == subLength - 1)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}

public class SolutionOfProblem
{
    public static void Main(string[] args)
    {
        string str, sub;
        str = Console.ReadLine();
        sub = Console.ReadLine();
        
        Console.WriteLine(Algorithms.IsSubstring(str, sub));
    }
}
