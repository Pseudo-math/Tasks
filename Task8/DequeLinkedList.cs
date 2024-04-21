using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  class Deque<T>
  {
    private LinkedList<T> elements;
    
    public Deque()
    {
     elements = new LinkedList<T>();
    }

    public void AddFront(T item)
    {
     elements.AddFirst(item);
    }

    public void AddTail(T item)
    {
     elements.AddLast(item);
    }

    public T RemoveFront()
    {
     if (Size() != 0) 
     {
         T result = elements.First.Value;
         elements.RemoveFirst();
         return result;
     }
     return default(T);
    }

    public T RemoveTail()
    {
     if (Size() != 0) 
     {
         T result = elements.First.Value;
         elements.RemoveLast();
         return result;
     }
     return default(T);
    }
        
    public int Size()
    {
     return elements.Count; // размер очереди
    }
  }

}
