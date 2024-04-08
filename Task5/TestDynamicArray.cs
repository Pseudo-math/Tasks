using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class DynArray<T>
   {
     public T [] array;
     public int count;
     public int capacity;

     public DynArray()
     {
       count = 0;
       MakeArray(16);
     }

     public void MakeArray(int new_capacity)
     {
       T [] arrayNew = new T [new_capacity];
       if (array != null) Array.Copy(array, arrayNew, count);
       array = arrayNew;
       capacity = new_capacity;
     }

     public T GetItem(int index)
     {
       if (index < 0 || index >= count) throw new Exception("Index out of array range.");
       return array[index];
     }

     public void Append(T itm)
     {
       Insert(itm, count);
     }

     public void Insert(T itm, int index)
     {
       if (index < 0 || index > count) throw new Exception("Index out of array range."); 
       else if (count + 1 <= capacity)
       {
           for (var i = count; i > index; --i)
           {
               array[i] = array[i - 1];
           }
           array[index] = itm;
           ++count;
       }
       else
       {
           MakeArray(2 * capacity);
           Insert(itm, index);
       }
     }

     public void Remove(int index)
     {
       if (index < 0 || index >= count) throw new Exception("Index out of array range.");
       else if (count - 1 >= (capacity / 2 + capacity % 2))
       {
           for (var i = index; i < count - 1; ++i)
           {
               array[i] = array[i + 1];
           }
           --count;
       }
       else
       {
           MakeArray((int)(capacity / 1.5));
           Remove(index);
       }
     }
    }
    public class Program
    {
      public static void Main()
      {
          Console.WriteLine(InsertTest());
          Console.WriteLine(RemoveTest());
      }
      public static bool InsertTest()
      {
          DynArray<int> arr = new DynArray<int>();
          for (int i = 0; i < 16; ++i)
          {
              arr.Append(i);
              if (arr.capacity != 16) return false;
          }
          if (arr.count != 16 || arr.capacity != 16) return false;
          for (int i = 0; i < arr.count; ++i)
          {
              if (arr.GetItem(i) != i) return false;
          }
          arr.Insert(100, 5);
          for (int i = 0; i < 17; ++i)
          {
              if (i < 5 && arr.GetItem(i) != i) return false;
              if (i == 5 && arr.GetItem(i) != 100) return false;
              if (i > 5 && arr.GetItem(i) != i - 1) return false;
          }
          if (arr.capacity != 32) return false;
          //arr.Insert(200, 18);
          return true;
      }
      public static bool RemoveTest()
      {
          DynArray<int> arr = new DynArray<int>();
          for (int i = 0; i < 16; ++i)
          {
              arr.Append(i);
              if (arr.capacity != 16) return false;
          }
          if (arr.count != 16 || arr.capacity != 16) return false;
          for (int i = 15; i > 7; --i)
          {
              arr.Remove(i);
              if (arr.count != i || arr.capacity != 16) return false;
          }
          arr.Remove(3);
          for (int i = 0; i < 7; ++i)
          {
              if (i < 3 && arr.GetItem(i) != i) return false;
              //if (i == 5 && arr.GetItem(i) != 100) return false;
              if (i >= 3 && arr.GetItem(i) != i + 1) return false;
          }
          if (arr.capacity != 10) return false;
          arr.Remove(18);
          //return true;
      }
    }
}
