using System;
using System.IO;

public class Algorithms
{
    private static int Min(int firstNumber, int secondNumber)
    {
        return firstNumber < secondNumber ? firstNumber : secondNumber;
    }
    public static int[] ZFunction(string str) {
        var strLength = str.Length;
        int[] z = new int[strLength] ;
        z[0] = strLength;
        var leftBorder = 0; 
        var rightBorder = 0;
        
        for (var i = 1; i < strLength; ++i) 
        {
            if (i <= rightBorder)
            {
                z[i] = Algorithms.Min(rightBorder - i + 1, z[i - leftBorder]);
            }
            
            while ((i + z[i] < strLength) && (str[i + z[i]] == str[z[i]]))
            {
                ++z[i]; 
            }
            if (rightBorder < i + z[i] - 1)
            {
                leftBorder = i;
                rightBorder = i + z[i] - 1;
            }
        }
        return z;
    }
    public static int CountOfSubstring(string str) 
    {
        var strLength = str.Length;
        var count = (strLength * (strLength + 1)) / 2;
        
        int[] z = new int[strLength];
        for (var i = 0; i < strLength; ++i)
        {
            Array.Copy(Algorithms.ZFunction(str.Substring(i)), z, strLength - i);
            int max = 0;
            for (var j = 1; j < strLength - i; ++j) 
            {
                if (z[j] > max) 
                {
                    count -= (z[j] - max);
                    max = z[j];
                }
            }
        }
        
        return count;
    }
}


public class SolutionOfProblem
{
    public static void Main(string[] args)
    {
        StreamReader sr = new StreamReader("unequal.in");
        StreamWriter sw = new StreamWriter("unequal.out");
        
        string str = sr.ReadLine();
        sw.WriteLine(Algorithms.CountOfSubstring(str));
        
        sr.Close();
        sw.Close();
    }
}
