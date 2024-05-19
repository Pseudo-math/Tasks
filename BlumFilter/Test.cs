using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
      public int filter_len;
      private uint filter;
        
      public BloomFilter(int f_len)
      {
        filter_len = f_len;
        filter  = 0;
      }

      public int Hash1(string str1)
      {
        int code = 0, randomNumber = 17;
        for(int i=0; i<str1.Length; i++)
        {
            code = (code * randomNumber + (int)str1[i]) % filter_len;
        }
        return code;
      }
      public int Hash2(string str1)
      {
        int code = 0, randomNumber = 223;
        for(int i=0; i<str1.Length; i++)
        {
            code = (code * randomNumber + (int)str1[i]) % filter_len;
        }
        return code;
      }

      public void Add(string str1)
      {
        filter = filter | (uint)(1 << Hash1(str1))  | (uint)(1 << Hash2(str1));
      }

      public bool IsValue(string str1)
      {
        if ((filter & (uint)(1 << Hash1(str1))) != 0 && (uint)(filter & (1 << Hash2(str1))) != 0) return true;
        return false;
      }
    }
    
    class Program
        {
            static void Main(string[] args)
            {
                int filterLength = 32;
                int n = 10;
    
                BloomFilter bloomFilter = new BloomFilter(filterLength);
    
                // Добавление строк в фильтр Блума
                for (int i = 0; i < n; i++)
                {
                    string str = string.Format("{0:D10}", i);
                    bloomFilter.Add(str);
                    Console.WriteLine($"Добавлена строка: {str}");
                }
    
                // Проверка наличия строк в фильтре Блума
                for (int i = 0; i < n; i++)
                {
                    string str = string.Format("{0:D10}", i);
                    if (bloomFilter.IsValue(str))
                    {
                        Console.WriteLine($"Строка {str} найдена в фильтре");
                    }
                    else
                    {
                        Console.WriteLine($"Строка {str} не найдена в фильтре (должна быть найдена)");
                    }
                }
    
                // Проверка наличия несуществующих строк
                string nonExistingString1 = "0123456788";
                string nonExistingString2 = "9012345679";
                Console.WriteLine($"Строка {nonExistingString1} не найдена в фильтре (должна быть не найдена): {bloomFilter.IsValue(nonExistingString1)}");
                Console.WriteLine($"Строка {nonExistingString2} не найдена в фильтре (должна быть не найдена): {bloomFilter.IsValue(nonExistingString2)}");
            }
        }
}
