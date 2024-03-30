using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Node
   {
     public int value;
     public Node next;
     public Node(int _value) { value = _value; }
   }

   public class LinkedList
   {
     public Node head;
     public Node tail;

     public LinkedList()
     {
       head = null;
       tail = null;
     }

     public void AddInTail(Node _item)
     {
       if (head == null) head = _item;
       else              tail.next = _item;
       tail = _item;
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
       Node start = head;
       while (node != null)
       {
          nodes.Add(node);
          head = node.next;
          node = Find(_value);
       }
       head = start;
       return nodes;
     }
    

     public bool Remove(int _value)
     {
       if (head == null) return false;
       if (head.value == _value)
       {
          if (head == tail) 
          {
             head = null;
             tail = null;
          }
          else head = head.next;
          return true;
       }
       Node nodeFirst = head;
       Node nodeSecond = head.next;
       while (nodeSecond != null)
       {
          if (nodeSecond.value == _value)
          {
               if (nodeSecond == tail) 
               {
                  tail = nodeFirst;
                  tail.next = null;
               }
               else 
               {
                  nodeFirst.next = nodeSecond.next;
                  nodeSecond.next = null;
               }
               return true;
          }
          nodeFirst = nodeSecond;
          nodeSecond = nodeSecond.next;
       }
       return false;
     }

     public void RemoveAll(int _value)
     {
       while (Remove(_value));
     }

     public void Clear()
     {
       Node node = head;
       while (head != tail)  
       {
          head = head.next;
          node.next = null;
          node = head;
       }
       head = null;
       tail = null;
     }

     public int Count()
     {
       var i = 0;
       Node node = head;
       while (node != null) 
       {
          ++i;
          node = node.next;
       }
       return i;
     }

     public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
     {
       if (head == null || _nodeAfter == tail) AddInTail(_nodeToInsert);
       else if (_nodeAfter == null)
       {
           _nodeToInsert.next = head;
           head = _nodeToInsert;
       }
       else
       {
          _nodeToInsert.next = _nodeAfter.next;
          _nodeAfter.next = _nodeToInsert;
       }
     }
   }
   public class Program 
   {
       public static void Main()
       {
           Console.WriteLine(RemoveTest());
           Console.WriteLine(CountTest());
           Console.WriteLine(ClearTest());
           Console.WriteLine(FindAllTest());
           Console.WriteLine(InsertAfterTest());
       }
       public static bool RemoveTest()
       {
            List<LinkedList> sizedLists = new List<LinkedList>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList());
                sizedLists.Add(new LinkedList());
                sizedLists.Add(new LinkedList());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[3 * i].AddInTail(new Node(j));
                    sizedLists[3 * i + 1].AddInTail(new Node(j));
                    sizedLists[3 * i + 2].AddInTail(new Node(j));

                }
                sizedLists[3 * i].Remove(0);
                sizedLists[3 * i + 1].Remove(1);;
                sizedLists[3 * i + 2].Remove(i - 1);;
                if (sizedLists[3 * i].Count() != i - 1 && i >= 1) return false;
                if (sizedLists[3 * i + 1].Count() != i - 1 && i >= 2) return false;
                if (sizedLists[3 * i + 2].Count() != i - 1 && i >= 2) return false;
            }
            return true;

       } 
       public static bool CountTest()
       {
            List<LinkedList> sizedLists = new List<LinkedList>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));
                }
                for (int j = 0; j < i; ++j)
                {
                    if (sizedLists[i].Count() != i) return false;
                }
            }
            return true;

       }
       public static bool ClearTest()
       {
            List<LinkedList> sizedLists = new List<LinkedList>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));
                }
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Clear();
                    if (sizedLists[i].Count() != 0) return false;
                }
            }
            return true;

       }
       public static bool FindAllTest()
       {
            List<LinkedList> sizedLists = new List<LinkedList>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].AddInTail(new Node(j));
                }
                for (int j = 0; j < i; ++j)
                {
                    if (sizedLists[i].FindAll(j).Count != 1) return false;
                }
            }
            return true;

       }  
       public static bool InsertAfterTest()
       {  
            List<LinkedList> sizedLists = new List<LinkedList>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new LinkedList());
                sizedLists.Add(new LinkedList());
                sizedLists.Add(new LinkedList());
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[3 * i].AddInTail(new Node(j));
                    sizedLists[3 * i + 1].AddInTail(new Node(j));
                    sizedLists[3 * i + 2].AddInTail(new Node(j));

                }
                sizedLists[3 * i].InsertAfter(null, new Node(100));
                sizedLists[3 * i + 1].InsertAfter(sizedLists[3 * i + 1].Find(0), new Node(100));
                sizedLists[3 * i + 2].InsertAfter(sizedLists[3 * i + 2].tail, new Node(100));
                if (sizedLists[3 * i].Count() != i + 1) return false;
                if (sizedLists[3 * i + 1].Count() != i + 1) return false;
                if (sizedLists[3 * i + 2].Count() != i + 1) return false;
            }
            return true;

       }          
    }
}
