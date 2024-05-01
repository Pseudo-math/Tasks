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
           Console.WriteLine(TestFind());
       }
       public bool TestSeekSlot()
       {
        HashTable hashTable = new HashTable(17, 1);
        // Insert values with potential collisions
        hashTable.Put("apple");
        hashTable.Put("pale"); // Collision with "apple"
        hashTable.Put("banana");

        // Check if SeekSlot returns the expected slot for existing values
        if (hashTable.SeekSlot("apple") != hashTable.Find("apple") ||
            hashTable.SeekSlot("pale") != hashTable.Find("pale") ||
            hashTable.SeekSlot("banana") != hashTable.Find("banana"))
        {
            return false; // Incorrect slot returned
        }

        // Check if SeekSlot handles collisions and finds the next available slot
        hashTable.Put("grape"); // Potential collision depending on table size and step
        int grapeSlot = hashTable.SeekSlot("grape");
        if (grapeSlot == -1 || hashTable.slots[grapeSlot] != null)
        {
            return false; // Failed to find a slot or slot is not empty
        }

        // Check if SeekSlot returns -1 when the table is full
        // ... (Fill the table with values and then try to SeekSlot for a new value)

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
