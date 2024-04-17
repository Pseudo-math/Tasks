using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Stack<T>
   {
      private List<T> elements;
      private int size;
      
      
      public Stack()
      {
       elements = new List<T>();
       size = 0;
      } 

      public int Size() 
      {
       return size;
      }

      public T Pop()
      {
       if (size != 0)
       {
           T result = elements[size - 1];
           elements.RemoveAt(size - 1);
           --size;
           return result;
       }
       return default(T); // null, если стек пустой
      }
	  
      public void Push(T val)
      {
       elements.Add(val);
       ++size;
      }

      public T Peek()
      {
       if (size != 0) return elements[size - 1];
       return default(T); // null, если стек пустой
      }
   }

}
