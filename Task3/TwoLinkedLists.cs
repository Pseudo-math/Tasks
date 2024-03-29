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
       public static LinkedList SumOfLinkedLists(LinkedList listFirst, LinkedList listSecond)
        {
           LinkedList result = new LinkedList();
           if (listFirst.Count() != listSecond.Count()) return result;
           Node nodeFirst = listFirst.head;
           Node nodeSecond = listSecond.head;
           while (nodeFirst != null)
           {
             result.AddInTail(new Node(nodeFirst.value + nodeSecond.value));
             nodeFirst = nodeFirst.next;
             nodeSecond = nodeSecond.next;
           }
           return result;
        }
       public static void Main()
        {
           LinkedList snakeFirst = new LinkedList();
           LinkedList snakeSecond = new LinkedList();
           for (int i = 0; i < 10; ++i)
            {
                   snakeFirst.AddInTail(new Node(i));
                   snakeSecond.AddInTail(new Node(i));
            }
            Console.WriteLine(Program.SumOfLinkedLists(snakeFirst, snakeSecond).Count());
            snakeSecond.AddInTail(new Node(100));
            Console.WriteLine(Program.SumOfLinkedLists(snakeFirst, snakeSecond).Count());
        }
   }
}
