using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Node
   {
     public int value;
     public Node next, prev;
     public bool isDummy;

     public Node(int _value) { 
       value = _value; 
       next = null;
       prev = null;
       isDummy = false;
     }
   }

   public class LinkedList2
   {
     public Node head;
     public Node tail;
     private int count;

     public LinkedList2()
     {
       head = new Node(0);
       tail = new Node(0);
       head.next = tail;
       tail.prev = head;
       head.isDummy = true;
       tail.isDummy = true;
       count = 0;
     }

     public void AddInTail(Node _item)
     {
       InsertAfter(tail.prev, _item);
     }

     public Node Find(int _value)
     {
       Node node = head.next;
       while (node.isDummy != true)
       {
         if (node.value == _value) return node;
         node = node.next;
       }
       return null;
     }

     public List<Node> FindAll(int _value)
     {
       List<Node> nodes = new List<Node>();
       Node node = Find(_value);
       LinkedList2 sublist = new LinkedList2();
       sublist.head = head;
       sublist.tail = tail;
       while (node != null)
       {
          nodes.Add(node);
          sublist.head.next = node.next;
          node = sublist.Find(_value);
       }
       return nodes;
     }

     public void Remove(Node node)
     {
       node.prev.next = node.next;
       node.next.prev = node.prev;
       --count;
     }
   
     public bool Remove(int _value)
     {
       Node node = Find(_value);
       if (node == null) return false;
       Remove(node);
       return true;
     }

     public void RemoveAll(int _value)
     {
       while (Remove(_value));
       //var nodesWillRemove = FindAll(_value);
       //foreach (var i in nodesWillRemove) Remove(i);
     }

     public void Clear()
     {
       Node node = head.next;
       while (node.isDummy != true)
       { 
         node = node.next;
         head.next.next = null;
         head.next.prev = null;
         head.next = node;
       }
       tail.prev = head;
       count = 0;
     }

     public int Count()
     {
       return count;
     }

     public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
     {
       _nodeToInsert.next = _nodeAfter.next;
       _nodeToInsert.prev = _nodeAfter;
       _nodeToInsert.next.prev = _nodeToInsert;
       _nodeAfter.next = _nodeToInsert;
       ++count;
     }

    }
 public class Program 
   {
       public static void Main()
       {
           Console.WriteLine(AddInTailTest());
           Console.WriteLine(FindTest());
           Console.WriteLine(FindAllTest());
           Console.WriteLine(RemoveTest());
           Console.WriteLine(RemoveAllTest());
           Console.WriteLine(ClearTest());
           Console.WriteLine(InsertAfterTest());
       }
       public static bool AddInTailTest()
       {
           List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));

                }
                if (sizedLists[i].Count() != i || !CountCheck(sizedLists[i])) return false;
            }
            return true;
       }
       
       public static bool FindTest()
       {
           List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));

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
            List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                sizedLists.Add(new LinkedList2());
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[3 * i].AddInTail(new Node(j));
                    sizedLists[3 * i + 1].AddInTail(new Node(j));
                    sizedLists[3 * i + 2].AddInTail(new Node(j));

                }
                sizedLists[3 * i].Remove(0);
                sizedLists[3 * i + 1].Remove(1);
                sizedLists[3 * i + 2].Remove(i - 1);
                if (i == 0 && sizedLists[3 * i].Remove(0)) return false;
                if (sizedLists[3 * i].Count() != i - 1 && i >= 1 || !CountCheck(sizedLists[3 * i])) return false;
                if (sizedLists[3 * i + 1].Count() != i - 1 && i >= 2 || !CountCheck(sizedLists[3 * i + 1])) return false;
                if (sizedLists[3 * i + 2].Count() != i - 1 && i >= 1 || !CountCheck(sizedLists[3 * i + 2])) return false;
            }
            return true;

       }
       public static bool RemoveAllTest()
       {
            List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));
                    sizedLists[i].AddInTail(new Node(j));
                    sizedLists[i].AddInTail(new Node(j));

                }
                sizedLists[i].RemoveAll(0);
                sizedLists[i].RemoveAll(1);
                if (i >= 3) sizedLists[i].RemoveAll(i - 1);
                if ((sizedLists[i].Count() != 0 && i == 1) || !CountCheck(sizedLists[i])) return false;
                if ((sizedLists[i].Count() != 0 && i == 2) || !CountCheck(sizedLists[i])) return false;
                if ((sizedLists[i].Count() != 3*(i - 3) && i >= 3) || !CountCheck(sizedLists[i]) ) return false;
            }
            return true;

       }
       public static bool CountCheck(LinkedList2 list)
       {
            var i = 0;
            Node node = list.head.next;
            while (node.isDummy != true) 
            {
                ++i;
                node = node.next;
            }
            var j = 0;
            node = list.tail.prev;
            while (node.isDummy != true)
            {
                ++j;
                node = node.prev;
            }
            return (i == list.Count() && i == j);
       }
       public static int Count2(LinkedList2 list)
       {
            var i = 0;
            Node node = list.head;
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
            return i;
       }
       public static bool ClearTest()
       {
            List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));
                }
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Clear();
                    if (sizedLists[i].Count() != 0 || !CountCheck(sizedLists[i])) return false;
                }
            }
            return true;

       }
       public static bool FindAllTest()
       {
            List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));
                }
                if (i == 0 && sizedLists[i].FindAll(0).Count != 0) return false;
                for (int j = 0; j < i; ++j)
                {
                    if ((sizedLists[i].FindAll(j).Count) != 1) return false;
                }
            }
            return true;

       }  
       public static bool InsertAfterTest()
       {  
            List<LinkedList2> sizedLists = new List<LinkedList2>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList2());
                sizedLists.Add(new LinkedList2());
                sizedLists.Add(new LinkedList2());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[3 * i].AddInTail(new Node(j));
                    sizedLists[3 * i + 1].AddInTail(new Node(j));
                    sizedLists[3 * i + 2].AddInTail(new Node(j));

                }
                sizedLists[3 * i].InsertAfter(sizedLists[3 * i].head, new Node(100));
                sizedLists[3 * i + 1].InsertAfter(sizedLists[3 * i + 1].head, new Node(100));
                sizedLists[3 * i + 2].InsertAfter(sizedLists[3 * i + 2].tail.prev, new Node(100));
                if (sizedLists[3 * i].Count() != i + 1 || !CountCheck(sizedLists[3 * i])) return false;
                if (sizedLists[3 * i + 1].Count() != i + 1 || !CountCheck(sizedLists[3 * i + 1])) return false;
                if (sizedLists[3 * i + 2].Count() != i + 1 || !CountCheck(sizedLists[3 * i + 2])) return false;
            }
            return true;

       }          
    }
}
