using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class Node<T>
  {
    public T value;
    public Node<T> next, prev;

    public Node(T _value)
    {
      value = _value;
      next = null;
      prev = null;
    }
  }

  public class OrderedList<T>
  {
    public Node<T> head, tail;
    private bool _ascending;
    private int size;

    public OrderedList(bool asc)
    {
      head = null;
      tail = null;
      _ascending = asc;
      size = 0;
    }
    public int Compare(T v1, T v2)
    {
      int result = 0;
      if (typeof(T) == typeof(String))
      {
        result = String.Compare(((string)(object)v1).Trim(), ((string)(object)v2).Trim());
        if (result < 0) return -1;
        if (result > 0) return 1;
        return 0;
      }
      else 
      {
        IComparable comparable1 = (IComparable)v1;
        IComparable comparable2 = (IComparable)v2;
        result = comparable1.CompareTo(comparable2);
        if (result < 0) return -1;
        if (result > 0) return 1;
        return 0;
      }
    }

    public void Add(T value)
    {
        Node<T> nodeAfter = null;
        int sign = _ascending ? 1 : -1;
        for (Node<T> node = head; node != null && (Compare(value, node.value) == sign); node = node.next)
            nodeAfter = node;
        InsertAfter(nodeAfter, new Node<T>(value));
    }
    private void AddInTail(Node<T> _item)
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
       ++size;
    }
    private void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
     {
       if (_nodeAfter == null && head != null)
       {
          _nodeToInsert.next = head;
          head.prev = _nodeToInsert;
          head = _nodeToInsert;
          head.prev = null;
          ++size;
       }
       else if (_nodeAfter != null && _nodeAfter.next != null)
       {
          _nodeToInsert.next = _nodeAfter.next;
          _nodeToInsert.prev = _nodeAfter;
          _nodeToInsert.next.prev = _nodeToInsert;
          _nodeAfter.next = _nodeToInsert;
          ++size;
       }
       else AddInTail(_nodeToInsert);
    }

    public Node<T> Find(T val)
    {   
        int sign = _ascending ? 1 : -1;
        for (Node<T> node = head; node != null && (Compare(val, node.value) == sign || Compare(val, node.value) == 0) ; node = node.next)
            if (val.Equals(node.value)) return node;
        return null;
    }
    
    public void Delete(Node<T> node)
    {
       if (node.prev != null) node.prev.next = node.next;
       if (node.next != null) node.next.prev = node.prev;
       if (node == head) head = node.next;
       if (node == tail) tail = node.prev;
       --size;
    }
    
    public void Delete(T val)
    {
       Node<T> node = Find(val);
       if (node != null) Delete(node);
    }

    public void Clear(bool asc)
    {
        for (Node<T> node = head; node != null; node = head)
        {
            head = node.next;
            node.next = null;
            node.prev = null;
        }
        tail = null;
        size = 0;
        _ascending = asc;
    }

    public int Count()
    {
       return size;
    }

    List<Node<T>> GetAll() 
    {
        List<Node<T>> r = new List<Node<T>>();
        for (Node<T> node = head; node != null; node = node.next) r.Add(node);
        return r;
    }
  }
 
} 




