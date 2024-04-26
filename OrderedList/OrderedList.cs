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
      if(typeof(T) == typeof(String))
      {
        result = String.Compare(Trim(v1), Trim(v2));
        if (result < 0) return -1;
        if (result > 0) return 1;
        return 0;
      }
      else 
      {
        if (v1 < v2) return -1;
        if (v1 > v2) return 1;
        return 0;
        // универсальное сравнение
      }
      
      return result;
      // -1 если v1 < v2
      // 0 если v1 == v2
      // +1 если v1 > v2
    }

    public void Add(T value)
    {
        Node<T> node;
        for (node = head; node != null && node.next != null && (Compare(value, node.value) == 1); node = node.next)
        InsertAfter(node, new Node(value));
        // автоматическая вставка value 
        // в нужную позицию
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

    public Node<T> Find(T val)
    {
        for (Node<T> node = head; node != null; node = node.next)
            if (node.value == _value) return node;
        return null; // здесь будет ваш код
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
       Node node = Find(_value);
       if (node != null) Remove(node);
    }

    public void Clear(bool asc)
    {
        Node node = head;
        for (Node node = head; node != null; node = head.next;)
        {
            head.next = node.next;
            node.next = null;
            node.prev = null;
        }
        tail = null;
        size = 0;
        _ascending = asc;
    }

    public int Count()
    {
       return size; // здесь будет ваш код подсчёта количества элементов в списке
    }

    List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                           // списка в виде стандартного списка
    {
        List<Node<T>> r = new List<Node<T>>();
        for (Node<T> node = head; node != null; node = node.next) r.Add(node);
        return r;
    }
  }
 
}
