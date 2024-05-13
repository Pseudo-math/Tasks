using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
  
  public class PowerSet<T>
  {
   public int size;
   public T [] slots; 
   
   public PowerSet()
   {
     size = 0;
     slots = new T[size];
   }

    public int Size()
    {
        // количество элементов в множестве
        return size;
    }
   public int HashFun(T value)
   {    
         byte[] bytes = System.Text.Encoding.UTF8.GetBytes((string)(object)value);
         int result = 0;
         foreach (var i in bytes)
           result += Convert.ToInt32(i);
         return result % size;
   }
   public int SeekSlot(string value)
    {
      int slot = HashFun(value);
      for (int i = slot; i < size; ++i)
        if (slots[i] == null) return i;
      for (int i = 0; i < slot; ++i)
        if (slots[i] == null) return i;
      return -1;
    }
   public bool IsKey(T key)
    {
      int slot = HashFun(key);
      for (int i = slot; i < size; ++i)
        if (slots[i] == key) return true;
      for (int i = 0; i < slot; ++i)
        if (slots[i] == key) return true;
      return false;
    }
   public void Put(T value)
   {  
      if (IsKey(value)) return;
      int slot = SeekSlot(key);
      slots[slot] = key;
      values[slot] = value;
      ++size; 
     // всегда срабатывает
   }

    public bool Get(T value)
    {
      T result;     
      int slot = HashFun(key);
      for (int i = slot; i < size; ++i)
        if (slots[i] == key)
          return true;      
      for (int i = 0; i < slot; ++i)
        if (slots[i] == key)
          return true;
      return false;
    }

    public bool Remove(T value)
    {
        // возвращает true если value удалено
        // иначе false
        return false;
    }

    public PowerSet<T> Intersection(PowerSet<T> set2)
    {
        // пересечение текущего множества и set2
        return null;
    }

    public PowerSet<T> Union(PowerSet<T> set2)
    {
        // объединение текущего множества и set2
        return null;
    }

    public PowerSet<T> Difference(PowerSet<T> set2)
    {
        // разница текущего множества и set2
        return null;
    }

    public bool IsSubset(PowerSet<T> set2)
    {
        // возвращает true, если set2 есть
        // подмножество текущего множества,
        // иначе false
        return false;
    }
  }
}






