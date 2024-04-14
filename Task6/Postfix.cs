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
      public static int PostfixOperations(string str)
      {
          Stack<string> buffer = new Stack<string>();
          Stack<int> result = new Stack<int>();
          string temp = "";
          char[] operations = {'+', '*', '-', '/', '='};
          for (int i = str.Length - 1; i >= 0; --i)
          {
            if (Char.IsDigit(str[i]))
            {
                temp = str[i] + temp;
                if (i == 0) buffer.Push(temp);
            }
            else if (str[i] == ' ' && temp != "")
            {
                buffer.Push(temp);
                temp = "";
            }
            else foreach (char j in operations)
            {
                if (str[i] == j)
                {
                    buffer.Push(str[i].ToString());
                    break;
                }
            }
          }
          for (int i = buffer.Size(); i > 0; --i)
          {
              temp = buffer.Pop();
              int number;
              if (int.TryParse(temp, out number)) result.Push(number);
              else if (temp == "=") return result.Pop();
              else
              {
                  int numberSecond = result.Pop(), numberFirst = result.Pop();
                  if (temp == "+") result.Push(numberFirst + numberSecond);
                  else if (temp == "*") result.Push(numberFirst * numberSecond);
                  else if (temp == "-") result.Push(numberFirst - numberSecond);
                  else if (temp == "/") result.Push(numberFirst / numberSecond);
              }
          }
          return default(int);
           
	  }
	  
      public static void Main()
      {
          Console.WriteLine(PostfixOperations("8 2 + 5 * 9 + 40 - 3 / ="));
      }
    }
    
}
