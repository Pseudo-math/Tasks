using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Queue<T>
   { 
      private List<T> elements;
      
      public Queue()
      {
       elements = new List<T>();
      } 

      public void Enqueue(T item)
      {
        elements.Insert(0, item);
      }

      public T Dequeue()
      {
        if (elements.Count != 0)
	{
            T result = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
	    return result;
	}
        return default(T); // если очередь пустая
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
          Queue<int> arr = new Queue<int>();
          for (int i = 0; i < 16; ++i)
          {
              arr.Enqueue(i);
              if (arr.Size() != i+1) return false;
          }
          if (arr.Dequeue() != 0) return false;
          for (int i = 1; i < 16; ++i)
          {
              if (arr.Dequeue() != i) return false;
          }
          if (arr.Size() != 0 && arr.Dequeue() != default(int)) return false;
          return true;
      }
    }
    
    
}
