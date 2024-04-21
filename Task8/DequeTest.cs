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
          Console.WriteLine(InsertTest());
      }
      public static bool InsertTest()
      {
          Deque<int> arr = new Deque<int>();
          for (int i = 0; i < 16; ++i)
          {
              arr.AddFront(i);
              if (arr.Size() != i+1) return false;
          }
          if (arr.RemoveTail() != 0) return false;
          for (int i = 1; i < 16; ++i)
          {
              if (arr.RemoveTail() != i) return false;
          }
          if (arr.Size() != 0 && arr.RemoveTail() != default(int)) return false;
          return true;
      }
    }
    
    
}
