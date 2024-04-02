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
          sublist.head = node;
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
       /*if (node != head && node != tail)
       {
          node.prev.next = node.next;
          node.next.prev = node.prev;
       }
       else
       {
          if (node == head)
          {
             head = head.next;
             if (head != null) head.prev == null;
          }
          if (node == tail)
          {
             tail = tail.prev;
             if (tail != null) tail.next == null;
          }
       */}
       Remove(node);
       return true;
     }

     public void RemoveAll(int _value)
     {
       nodesWillRemove = FindAll(_value);
       for (var i in nodesWillRemove) Remove(i);
       count -= nodesWillRemove.count;
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
       }
       else if (_nodeAfter != null && _nodeAfter.next != null)
       {
          _nodeToInsert.next = _nodeAfter.next;
          _nodeToInsert.prev = _nodeAfter;
          _nodeToInsert.next.prev = _nodeToInsert;
          _nodeAfter.next = _nodeToInsert
       }
       else AddInTail(_nodeToInsert);
       ++count;
     }

    }
}

