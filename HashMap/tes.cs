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
           Console.WriteLine(AddTest());
           Console.WriteLine(FindTest());
           Console.WriteLine(RemoveTest());
           Console.WriteLine(ClearTest());
       }
       public static bool AddTest()
       {
            List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Add(j);

                }
                if (sizedLists[i].Count() != i || !CountCheck(sizedLists[i])) return false;
                sizedLists[i].Add(3);
                for (Node<int> node = sizedLists[i].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
                
            }
            return true;
       }
       
       public static bool FindTest()
       {
           List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Add(j);

                }
                if (i == 0 && (sizedLists[i].Find(0) != null || !CountCheck(sizedLists[i])))
                if (i >= 1 && (sizedLists[i].Find(0).value != 0 || !CountCheck(sizedLists[i]))) return false;
                if (i > 1 && sizedLists[i].Find(0).next.value != 1) return false;
                if (sizedLists[i].Find(i) != null) return false;
                
            }
            return true;
       }
       public static bool RemoveTest()
       {
            List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                sizedLists.Add(new OrderedList<int>(true));
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[3 * i].Add(j);
                    sizedLists[3 * i + 1].Add(j);
                    sizedLists[3 * i + 2].Add(j);

                }
                sizedLists[3 * i].Delete(0);
                sizedLists[3 * i + 1].Delete(1);
                sizedLists[3 * i + 2].Delete(i - 1);
                if (sizedLists[3 * i].Count() != i - 1 && i >= 1 || !CountCheck(sizedLists[3 * i])) return false;
                if (sizedLists[3 * i + 1].Count() != i - 1 && i >= 2 || !CountCheck(sizedLists[3 * i + 1])) return false;
                if (sizedLists[3 * i + 2].Count() != i - 1 && i >= 1 || !CountCheck(sizedLists[3 * i + 2])) return false;
                for (Node<int> node = sizedLists[3 * i].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
                for (Node<int> node = sizedLists[3 * i + 1].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
                for (Node<int> node = sizedLists[3 * i + 2].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
            }
            return true;

       }
       public static bool CountCheck(OrderedList<int> list)
       {
            var i = 0;
            Node<int> node = list.head;
            while (node != null) 
            {
                ++i;
                node = node.next;
            }
            var j = 0;
            node = list.tail;
            while (node != null) 
            {
                ++j;
                node = node.prev;
            }
            return (i == list.Count() && i == j);
       }
       public static bool ClearTest()
       {
            List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Add(j);
                }
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Clear(true);
                    if (sizedLists[i].Count() != 0 || !CountCheck(sizedLists[i])) return false;
                }
            }
            return true;

       }
    }
}
