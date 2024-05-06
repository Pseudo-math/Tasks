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
      for (uint i = (slot + step) % size; i != slot; i = (i + step) % size) // Unsigned????
        if (slots[i] == null) return i;
    }
    
    public bool IsKey(string key)
    {
      uint slot = HashFun(key);
      if (slots[slot] == key) return slot;
      for (uint i = (slot + step) % size; i != slot; i = (i + step) % size)
        if (slots[i] == key) return true;
      return false;
    }

    public void Put(string key, T value)
    {
      int slot = SeekSlot(key);
      slots[slot] = key;
      values[slot] = value;
    }

    public T Get(string key)
    {
      uint slot = HashFun(key);
      if (slots[slot] == key) return slot;
      for (uint i = (slot + step) % size; i != slot; i = (i + step) % size)
        if (slots[i] == key) return values(i);
      return default(T);
    }
  } 
}
