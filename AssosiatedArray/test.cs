using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AlgorithmsDataStructures
{

  public class NativeDictionary<T>
  {
      
    public uint size;
    private const uint step = 2147483629; // Max prime Int32 number
    public string [] slots;
    public T [] values;
    private readonly object locker = new object(); 

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
      lock (locker)
      { 
        int slot = SeekSlot(key);
        slots[slot] = key;
        values[slot] = value;
      }
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



    public class NativeDictionaryTests
    {
        public static bool TestPutLotNewKey()
        {
            var dict = new NativeDictionary<int>(10000);
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
            var dict = new NativeDictionary<int>(10);
            dict.Put("test", 123);
            return dict.slots.Count(s => s != null) == 1 &&
                   dict.slots[dict.HashFun("test")] == "test" &&
                   dict.values[dict.HashFun("test")] == 123;
        }
    
        public static bool TestPutExistingKey()
        {
            var dict = new NativeDictionary<int>(10);
            dict.Put("test", 123);
            dict.Put("test", 456);
            return dict.slots.Count(s => s != null) == 2  &&
                   dict.slots[dict.HashFun("test")] == "test" &&
                   dict.values[dict.HashFun("test")] == 123;
        }
    
        public static bool TestIsKeyExisting()
        {
            var dict = new NativeDictionary<int>(10);
            dict.Put("test", 123);
            return dict.IsKey("test");
        }
    
        public static bool TestIsKeyNonexistent()
        {
            var dict = new NativeDictionary<int>(10);
            dict.Put("test", 123);
            return !dict.IsKey("nonexistent");
        }
    
        public static bool TestGetExistingKey()
        {
            var dict = new NativeDictionary<int>(10);
            dict.Put("test", 123);
            return dict.Get("test") == 123;
        }
    
        public static bool TestGetNonexistentKey()
        {
            var dict = new NativeDictionary<int>(10);
            dict.Put("test", 123);
            return dict.Get("nonexistent") == 0; // Default value for int is 0
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
        }
    }
}
