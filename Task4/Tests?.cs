using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Node
   {
     public int value;
     public Node next, prev;

     public Node(int _value) { 
       value = _value; 
       next = null;
       prev = null;
     }
   }

   public class LinkedList2
   {
     public Node head;
     public Node tail;
     private int count;

     public LinkedList2()
     {
       head = null;
       tail = null;
       count = 0;
     }

     public void AddInTail(Node _item)
     {
       if (head == null) {
        head = _item;
        head.next = null;
        head.prev = null;
       } else {
        tail.next = _item;
        _item.prev = tail;
       }
       tail = _item;
       ++count;
     }

     public Node Find(int _value)
     {
       Node node = head;
       while (node != null)
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
       LinkedList2 sublist = this;
       while (node != null)
       {
          nodes.Add(node);
          sublist.head = node.next;
          node = sublist.Find(_value);
       }
       return nodes;
     }

     public void Remove(Node node)
     {
       if (node.prev != null) node.prev.next = node.next;
       if (node.next != null) node.next.prev = node.prev;
       if (node == head) head = node.next;
       if (node == tail) tail = node.prev;
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
       Node node = head;
       while (node != null)
       { 
         node = node.next;
         head.next = null;
         head.prev = null;
         head = node;
       }
       tail = null;
       count = 0;
     }

     public int Count()
     {
       return count;
     }

     public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
     {
       if (_nodeAfter == null && head != null)
       {
          _nodeToInsert.next = head;
          head.prev = _nodeToInsert;
          head = _nodeToInsert;
          head.prev = null;
          ++count;
       }
       else if (_nodeAfter != null && _nodeAfter.next != null)
       {
          _nodeToInsert.next = _nodeAfter.next;
          _nodeToInsert.prev = _nodeAfter;
          _nodeToInsert.next.prev = _nodeToInsert;
          _nodeAfter.next = _nodeToInsert;
          ++count;
       }
       else AddInTail(_nodeToInsert);
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
                sizedLists[3 * i].InsertAfter(null, new Node(100));
                sizedLists[3 * i + 1].InsertAfter(sizedLists[3 * i + 1].Find(0), new Node(100));
                sizedLists[3 * i + 2].InsertAfter(sizedLists[3 * i + 2].tail, new Node(100));
                if (sizedLists[3 * i].Count() != i + 1 || !CountCheck(sizedLists[3 * i])) return false;
                if (sizedLists[3 * i + 1].Count() != i + 1 || !CountCheck(sizedLists[3 * i + 1])) return false;
                if (sizedLists[3 * i + 2].Count() != i + 1 || !CountCheck(sizedLists[3 * i + 2])) return false;
            }
            return true;

       }          
    }
}
