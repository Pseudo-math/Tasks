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
      public void Torsion(int n)
      {
          if (Size() == 0) return;
          for (int i = 0; i < n; ++i)
          {
              Enqueue(Dequeue());
          }
      }

   }


    public class Program
    {
      public static void Main()
      {
          Queue<int> arr = new Queue<int>();
          for (int i = 16; i >= 0; --i)
          {
              arr.Enqueue(i);
          }
          arr.Torsion(5);
          for (int i = 0; i < 17; ++i)
          {
              Console.WriteLine(arr.Dequeue());
          }
      }
    }
    
    
}
