using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{

  public class NativeDictionary<T>
  {
    public int size;
    public string [] slots;
    public T [] values;
    private readonly object locker = new object(); 

    public NativeDictionary(int sz)
    {
      size = sz;
      slots = new string[size];
      values = new T[size];
    }

    public int HashFun(string key)
    {
      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(key);
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
    
    public bool IsKey(string key)
    {
      int slot = HashFun(key);
      for (int i = slot; i < size; ++i)
        if (slots[i] == key) return true;
      for (int i = 0; i < slot; ++i)
        if (slots[i] == key) return true;
      return false;
    }

    public void Put(string key, T value)
    {
      lock (locker)
      { 
        int slot = SeekSlot(key);
        slots[slot] = key;
        values[slot] = value;
      }
    }

    public T Get(string key)
    {
      int slot = HashFun(key);
      for (int i = slot; i < size; ++i)
        if (slots[i] == key)
        {
          slots[i] = null;
          values[i] = default(T);
          return values[i];
        }
      for (int i = 0; i < slot; ++i)
        if (slots[i] == key)
        {
          slots[i] = null;
          values[i] = default(T);
          return values[i];
        }
      return default(T);    
    }
  }
}





