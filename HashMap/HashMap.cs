using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class HashTable
  {
    public int size;
    public int step;
    public string [] slots; 

    public HashTable(int sz, int stp)
    {
      size = sz;
      step = stp;
      slots = new string[size];
      for(int i=0; i<size; i++) slots[i] = null;
    }

    public int HashFun(string value)
    {    
         // всегда возвращает корректный индекс слота
         return 0;
    }

    public int SeekSlot(string value)
    {
         // находит индекс пустого слота для значения, или -1
         return -1;
    }

     public int Put(string value)
     {
         int slot = SeekSlot(value);
         if (slot != -1)
         {
           slots[slot] = value
           return slot;
         }
         return -1;
     }

     public int Find(string value)
     {
         // находит индекс слота со значением, или -1
         return -1;
     }
  }
 
}







