using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class NativeDictionary<T>
  {
    public uint size;
    private const uint step = 2147483629; // Max prime Int32 number
    public string [] slots;
    public T [] values;

    public NativeDictionary(int sz)
    {
      size = Convert.ToUInt32(sz);
      slots = new string[size];
      values = new T[size];
    }

    public int HashFun(string key)
    {
      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(key);
      int result = 0;
      foreach (var i in bytes)
        result += Convert.ToInt32(i);
      return result % Convert.ToInt32(size);
    }
    
    public int SeekSlot(string value)
    {
      uint slot = Convert.ToUInt32(HashFun(value));
      if (slots[slot] == null) return Convert.ToInt32(slot);
      for (uint i = (slot + step) % size; i != slot; i = (i + step) % size) // Unsigned????
        if (slots[i] == null) return Convert.ToInt32(i);
      return -1;
    }
    
    public bool IsKey(string key)
    {
      uint slot = Convert.ToUInt32(HashFun(key));
      if (slots[slot] == key) return true;
      for (uint i = (slot + step) % size; i != slot; i = (i + step) % size)
        if (slots[i] == key) return true;
      return false;
    }

    public void Put(string key, T value)
    {
      if (IsKey) throw new Exception("key already exist");
      int slot = SeekSlot(key);
      slots[slot] = key;
      values[slot] = value;
    }

    public T Get(string key)
    {
      uint slot = Convert.ToUInt32(HashFun(key));
      if (slots[slot] == key) return values[slot];
      for (uint i = (slot + step) % size; i != slot; i = (i + step) % size)
        if (slots[i] == key) return values[i];
      return default(T);
    }
  } 
}






