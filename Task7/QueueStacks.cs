using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Queue<T>
   { 
      private Stack<T> elementsFirst;
      private Stack<T> elementsSecond;
      
      public Queue()
      {
       elementsFirst = new Stack<T>();
       elementsSecond = new Stack<T>();
      } 

      public void Enqueue(T item)
      {
        elementsFirst.Push(item);
      }

      public T Dequeue()
      {
        if (elementsSecond.Count != 0) return elementsSecond.Pop();
        for (int i = elementsFirst.Count; i > 0; --i) elementsSecond.Push(elementsFirst.Pop());
        if (elementsSecond.Count != 0) return elementsSecond.Pop();
        return default(T); // если очередь пустая
      }

      public int Size()
      {
        return elementsFirst.Count + elementsSecond.Count; // размер очереди
      }

   }
}
