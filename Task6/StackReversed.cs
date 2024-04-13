using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Stack<T>
   {
      private LinkedList<T> elements;
          
      public Stack()
      {
       elements = new LinkedList<T>();
      } 

      public int Size() 
      {
       return elements.Count;
      }

      public T Pop()
      {
       if (elements.First == null) return default(T); // null, если стек пустой
       T result = elements.First.Value;
       elements.RemoveFirst();
       return result;
      }
	  
      public void Push(T val)
      {
       elements.AddFirst(val);
      }

      public T Peek()
      {
       if (elements.First == null) return default(T);
       return elements.First.Value;
      }
   }

}
