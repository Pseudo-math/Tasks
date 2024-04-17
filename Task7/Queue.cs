using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Queue<T>
   {
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
            T result = elements(elements.Count - 1);
            elements.RemoveAt(elements.Count);
	    return result;
	}
        return default(T); // если очередь пустая
      }

      public int Size()
      {
        return elements.Count; // размер очереди
      }

   }
}

