using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
      public int filter_len;

      public BloomFilter(int f_len)
      {
        filter_len = f_len;
        // создаём битовый массив длиной f_len ...
      }

      // хэш-функции
      public int Hash1(string str1)
      {
        // 17
        for(int i=0; i<str1.Length; i++)
        {
            int code = (int)str1[i];
        }
        // реализация ...
        return 0;
      }
      public int Hash2(string str1)
      {
        // 223
        // реализация ...
        return 0;
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






