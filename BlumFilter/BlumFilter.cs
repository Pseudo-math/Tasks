using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
      public int filter_len;
      private BitArray BitArr;
        
      public BloomFilter(int f_len)
      {
        filter_len = f_len;
        BitArr  = new BitArray(f_len);
      }

      public int Hash1(string str1)
      {
        int code, randomNumber = 17;
        for(int i=0; i<str1.Length; i++)
        {
            code = (code * randomNumber + (int)str1[i]) % filter_len;
        }
        return code;
      }
      public int Hash2(string str1)
      {
        int code, randomNumber = 223;
        for(int i=0; i<str1.Length; i++)
        {
            code = (code * randomNumber + (int)str1[i]) % filter_len;
        }
        return code;
      }

      public void Add(string str1)
      {
        // добавляем строку str1 в фильтр
      }

      public bool IsValue(string str1)
      {
        // проверка, имеется ли строка str1 в фильтре
        return false;
      }
   }
}






