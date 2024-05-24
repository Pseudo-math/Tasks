using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AlgorithmsDataStructures
{

  public class NativeCache<T>
  {
    public int size;
    public string [] slots;
    public T [] values;
    public int [] hits;
    private readonly object locker = new object(); 
    private int slotForFree;

    public NativeCache(int sz)
    {
      size = sz;
      slots = new string[size];
      values = new T[size];
      hits = new int[size];
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
    
    public void FreeSlot()
    {
      slots[slotForFree] = null;
      values[slotForFree] = default(T);
      hits[slotForFree] = 0;
    }
    
    public void Put(string key, T value)
    {
      lock (locker)
      { 
        int slot = SeekSlot(key);
        if (slot == -1) FreeSlot();
        slot = SeekSlot(key);
        slots[slot] = key;
        values[slot] = value;
        ++hits[slot];
        if (hits[slotForFree] > hits[slot]) 
          slotForFree = slot;
      }
    }

    public T Get(string key)
    {
      T result;     
      int slot = HashFun(key);
      for (int i = slot; i < size; ++i)
        if (slots[i] == key)
        {
          slots[i] = null;
          result = values[i];
          values[i] = default(T);
          hits[i] = 0;
          return result;
        }
      for (int i = 0; i < slot; ++i)
        if (slots[i] == key)
        {
          slots[i] = null;
          result = values[i];
          values[i] = default(T);
          hits[i] = 0;
          return result;
        }
      return default(T);    
    }
  }

    public class NativeDictionaryTests
    {
        public static bool TestPutLotNewKey()
        {
            var dict = new NativeCache<int>(10000);
            for (int i = 0; i < 10000; ++i)
            {
                dict.Put("testaefasdfasdfasdfasdfasdf", i);
            }
            return dict.slots.Count(s => s != null) == 10000 &&
                   dict.slots[dict.HashFun("testaefasdfasdfasdfasdfasdf")] == "testaefasdfasdfasdfasdfasdf" &&
                   dict.values[dict.HashFun("testaefasdfasdfasdfasdfasdf")] == 0;
        }
        
        public static bool TestPutNewKey()
        {
            var dict = new NativeCache<int>(10);
            dict.Put("test", 123);
            return dict.slots.Count(s => s != null) == 1 &&
                   dict.slots[dict.HashFun("test")] == "test" &&
                   dict.values[dict.HashFun("test")] == 123;
        }
    
        public static bool TestPutExistingKey()
        {
            var dict = new NativeCache<int>(10);
            dict.Put("test", 123);
            dict.Put("test", 456);
            return dict.slots.Count(s => s != null) == 2  &&
                   dict.slots[dict.HashFun("test")] == "test" &&
                   dict.values[dict.HashFun("test")] == 123;
        }
    
        public static bool TestIsKeyExisting()
        {
            var dict = new NativeCache<int>(10);
            dict.Put("test", 123);
            return dict.IsKey("test");
        }
    
        public static bool TestIsKeyNonexistent()
        {
            var dict = new NativeCache<int>(10);
            dict.Put("test", 123);
            return !dict.IsKey("nonexistent");
        }
    
        public static bool TestGetExistingKey()
        {
            var dict = new NativeCache<int>(10);
            dict.Put("test", 123);
            return dict.Get("test") == 123;
        }
    
        public static bool TestGetNonexistentKey()
        {
            var dict = new NativeCache<int>(10);
            dict.Put("test", 123);
            return dict.Get("nonexistent") == 0; // Default value for int is 0
        }
        public static bool TestGetNonexistentAfterKey()
        {
            bool first;
            var dict = new NativeCache<int>(2);
            dict.Put("test", 123);
            first = dict.Get("test") == 123;
            for (int i = 0; i < 2; ++i)
            {
                dict.Put("testaefasdfasdfasdfasdfasdf", i);
            }
            return first && (dict.Get("test") == 0); // Default value for int is 0
        }
    
        
        public static void Main(string[] args)
        {
            Console.WriteLine(TestPutLotNewKey());
            Console.WriteLine(TestPutNewKey());
            Console.WriteLine(TestPutExistingKey());
            Console.WriteLine(TestIsKeyExisting());
            Console.WriteLine(TestIsKeyNonexistent());
            Console.WriteLine(TestGetExistingKey());
            Console.WriteLine(TestGetNonexistentKey());
            Console.WriteLine(TestGetNonexistentAfterKey());
        }
    }
}
