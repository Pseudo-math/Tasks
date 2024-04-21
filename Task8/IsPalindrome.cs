using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  class Deque<T>
  {
    private List<T> elements;
    
    public Deque()
    {
     elements = new List<T>();
    }

    public void AddFront(T item)
    {
     elements.Insert(0, item);
    }

    public void AddTail(T item)
    {
     elements.Add(item);
    }

    public T RemoveFront()
    {
     if (Size() != 0) 
     {
         T result = elements[0];
         elements.RemoveAt(0);
         return result;
     }
     return default(T);
    }

    public T RemoveTail()
    {
     if (Size() != 0) 
     {
         T result = elements[Size() - 1];
         elements.RemoveAt(Size() - 1);
         return result;
     }
     return default(T);
    }
        
    public int Size()
    {
     return elements.Count; // размер очереди
    }
  }


    public class Program
    {
      public static void Main()
      {
          Console.WriteLine(IsPalindrome("PalindromeemordnilaP"));
      }
      public static bool IsPalindrome(string str)
      {
          Deque<char> strDeque = new Deque<char>();
          foreach (var i in str) strDeque.AddFront(i);
          for (int i = strDeque.Size(); i > 1; --i) 
            if (strDeque.RemoveFront() != strDeque.RemoveTail()) return false;
          return true;
      }
    }
    
    
}
