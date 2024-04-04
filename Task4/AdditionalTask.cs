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
     public Node() { 
       value = 0; 
       next = null;
       prev = null;
     }
   }
   
   public class DummyNode : Node
   {
   }

   public class LinkedList2
   {
     public Node head;
     public Node tail;
     private int count;

     public LinkedList2()
     {
       head = new DummyNode();
       tail = new DummyNode();
       head.next = tail;
       tail.prev = head;
       count = 0;
     }

     public void AddInTail(Node _item)
     {
       InsertAfter(tail.prev, _item);
     }

     public Node Find(int _value)
     {
       for (Node node = head.next; node is DummyNode == false; node = node.next)
       {
          if (node.value == _value) return node;
       }
       return null;
     }

     public List<Node> FindAll(int _value)
     {
       List<Node> nodes = new List<Node>();
       LinkedList2 sublist = new LinkedList2();
       sublist.head.next = head.next;
       sublist.tail.prev = tail.prev;
       for (Node node = Find(_value); node != null; node = sublist.Find(_value))
       {
          nodes.Add(node);
          sublist.head.next = node.next;
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
       var nodesWillRemove = FindAll(_value);
       foreach (var i in nodesWillRemove) Remove(i);
     }

     public void Clear()
     {
       for (Node node = head.next; node is DummyNode == false; node = head.next)
       {
          head.next = node.next;
          node.next = null;
          node.prev = null;
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
}
