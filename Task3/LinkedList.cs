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
       // здесь будет ваш код поиска всех узлов по заданному значению
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
                  tail.next == null;
               }
               else nodeFirst.next = nodeSecond.next;
               return true;
          }
          nodeFirst = nodeSecond;
          nodeSecond = nodeSecond.next;
       }
       return false;
     }

     public void RemoveAll(int _value)
     {
       // здесь будет ваш код удаления всех узлов по заданному значению
     }

     public void Clear()
     {
       // здесь будет ваш код очистки всего списка
     }

     public int Count()
     {
       return 0; // здесь будет ваш код подсчёта количества элементов в списке
     }

     public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
     {
       // здесь будет ваш код вставки узла после заданного

       // если _nodeAfter = null , 
       // добавьте новый элемент первым в списке 
     }

    }
}
