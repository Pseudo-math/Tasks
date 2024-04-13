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


    public class Program
    {
      public static void Main()
      {
          Console.WriteLine(InsertTest());
      }
      public static bool InsertTest()
      {
          Stack<int> arr = new Stack<int>();
          for (int i = 0; i < 16; ++i)
          {
              arr.Push(i);
              if (arr.Size() != i+1) return false;
          }
          if (arr.Peek() != 15) return false;
          for (int i = 15; i >= 0; --i)
          {
              if (arr.Pop() != i) return false;
          }
          if (arr.Size() != 0 && arr.Pop() != default(int)) return false;
          //arr.Insert(200, 18);
          return true;
      }
    }
    
    
}
