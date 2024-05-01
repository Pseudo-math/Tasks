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
         byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value);
         int result = 0;
         foreach (var i in bytes)
           result += Convert.ToInt32(i);
         return result % size;
    }

    public int SeekSlot(string value)
    {
         int slot = HashFun(value);
         if (slots[slot] == null) return slot;
         for (int i = (slot + step) % size; i != slot; i = (i + step) % size)
           if (slots[i] == null) return i;
         return -1;
    }

     public int Put(string value)
     {
         int slot = SeekSlot(value);
         if (slot != -1)
         {
           slots[slot] = value;
           return slot;
         }
         return -1;
     }

     public int Find(string value)
     {
         int slot = HashFun(value);
         if (slots[slot] == value) return slot;
         for (int i = (slot + step) % size; i != slot; i = (i + step) % size)
           if (slots[i] == value) return i;
         return -1;
     }
  }
 

    public class Program 
    {
       public static void Main()
       {
           Console.WriteLine(TestSeekSlot());
           Console.WriteLine(TestPutWithCollisions());
       }
       public bool TestSeekSlot()
       {
        HashTable
        // Insert values with potential collisions
        hashTable.put("apple");
        hashTable.put("pale"); // Collision with "apple"
        hashTable.put("banana");

        // Check if seek_slot returns the correct slot for existing values
        if (hashTable.seek_slot("apple") != hashTable.find("apple") ||
            hashTable.seek_slot("pale") != hashTable.find("pale") ||
            hashTable.seek_slot("banana") != hashTable.find("banana"))
        {
            return false; // Incorrect slot returned
        }

        // Check if seek_slot creates a new slot for non-existent values
        if (hashTable.seek_slot("grape") == null)
        {
            return false; // Slot not created
        }

        return true;
        }

    // Test put functionality with collisions
    public bool TestFind()
    {
        HashTable hashTable = new HashTable(17, 1);
        string[] values = { "apple", "banana", "cherry", "date", "elderberry" };
        foreach (string value in values)
        {
            hashTable.Put(value);
        }

        // Test finding existing values
        foreach (string value in values)
        {
            if (hashTable.Find(value) == -1)
            {
                return false; // Value not found
            }
        }

        // Test finding non-existent values
        if (hashTable.Find("grape") != -1)
        {
            return false; // Found non-existent value
        }

        return true;
    }
    }
}
