using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class NativeDictionary<T>
  {
    public int size;
    private const uint step = 2147483629; // Max prime Int32 number
    public string [] slots;
    public T [] values;

    public NativeDictionary(int sz)
    {
      size = sz;
      slots = new string[size];
      values = new T[size];
    }

    public int HashFun(string key)
    {
      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value);
      int result = 0;
      foreach (var i in bytes)
        result += Convert.ToInt32(i);
      return result % size;
    }
    
    public int SeekSlot(string value)
    {
         uint slot = HashFun(value);
         if (slots[slot] == null) return slot;
         for (int i = (slot + step) % size; i != slot; i = (i + step) % size) // Unsigned????
           if (slots[i] == null) return i;
         return -1;
    }
    
    public bool IsKey(string key)
    {
      // возвращает true если ключ имеется,
      // иначе false
      return false;
    }

    public void Put(string key, T value)
    {
      int slot = SeekSlot(value);
      if (slot != -1)
      {
        slots[slot] = value;
        return slot;
      }
      return -1;
      // гарантированно записываем 
      // значение value по ключу key
    }

    public T Get(string key)
    {
      // возвращает value для key, 
      // или null если ключ не найден
      return default(T);
    }
  } 
}
