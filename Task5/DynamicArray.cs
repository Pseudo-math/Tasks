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
       else if (capacity == 1)
       {
           --count;
           MakeArray(0);
       }
       else
       {
           MakeArray((int)(capacity / 1.5));
           Remove(index);
       }
     }

    }
}

