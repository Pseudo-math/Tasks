using System;


public class Algorithms
{
    public static int FindSubstring(string str, string sub)
    {
        var strLength = str.Length;
        var subLength = sub.Length;
        var rangeLength = strLength - subLength + 1;
        
        if (subLength > strLength)
        {
            return -1;
        }
        
        for (var i = 0; i < rangeLength; ++i)
        {
            if (str[i] == sub[0])
            {   
                var j = 0;
                
                while (j < subLength && str[i + j] == sub[j])
                {
                    if (j == subLength - 1)
                    {
                        return i;
                    }
                    ++j;
                }
            }
        }
        
        return -1;
    }
}

public class SolutionOfProblem
{
    public static void Main(string[] args)
    {
        string str, sub;
        str = Console.ReadLine();
        sub = Console.ReadLine();
        
        Console.WriteLine(Algorithms.FindSubstring(str, sub));
    }
}
