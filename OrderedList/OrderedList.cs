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
        // автоматическая вставка value 
        // в нужную позицию
        ++size;
    }

    public Node<T> Find(T val)
    {
        return null; // здесь будет ваш код
    }

    public void Delete(T val)
    {
        // здесь будет ваш код
        --size;
    }

    public void Clear(bool asc)
    {
        _ascending = asc;
        // здесь будет ваш код
    }

    public int Count()
    {
       return size; // здесь будет ваш код подсчёта количества элементов в списке
    }

    List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                           // списка в виде стандартного списка
    {
        List<Node<T>> r = new List<Node<T>>();
        Node<T> node = head;
        while(node != null)
        {
            r.Add(node);
            node = node.next;
        }
        return r;
    }
  }
 
}
