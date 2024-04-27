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

  public class OrderedList<T> where T : IComparable<T>
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
        result = v1.CompareTo(v2);
        if (result < 0) return -1;
        if (result > 0) return 1;
        return 0;
        // универсальное сравнение
      }
      // -1 если v1 < v2
      // 0 если v1 == v2
      // +1 если v1 > v2
    }

    public void Add(T value)
    {
        Node<T> nodeAfter = null;
        int sign = _ascending ? 1 : -1;
        for (Node<T> node = head; node != null && (Compare(value, node.value) == sign); node = node.next)
            nodeAfter = node;
        InsertAfter(nodeAfter, new Node<T>(value));
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
        for (Node<T> node = head; node != null; node = node.next)
            if (val.Equals(node.value)) return node;
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
    public class Program 
    {
       public static void Main()
       {
           Console.WriteLine(AddTest());
           Console.WriteLine(FindTest());
           Console.WriteLine(RemoveTest());
           Console.WriteLine(ClearTest());
       }
       public static bool AddTest()
       {
            List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Add(j);

                }
                if (sizedLists[i].Count() != i || !CountCheck(sizedLists[i])) return false;
                sizedLists[i].Add(3);
                for (Node<int> node = sizedLists[i].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
                
            }
            return true;
       }
       
       public static bool FindTest()
       {
           List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Add(j);

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
            List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                sizedLists.Add(new OrderedList<int>(true));
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[3 * i].Add(j);
                    sizedLists[3 * i + 1].Add(j);
                    sizedLists[3 * i + 2].Add(j);

                }
                sizedLists[3 * i].Delete(0);
                sizedLists[3 * i + 1].Delete(1);
                sizedLists[3 * i + 2].Delete(i - 1);
                if (sizedLists[3 * i].Count() != i - 1 && i >= 1 || !CountCheck(sizedLists[3 * i])) return false;
                if (sizedLists[3 * i + 1].Count() != i - 1 && i >= 2 || !CountCheck(sizedLists[3 * i + 1])) return false;
                if (sizedLists[3 * i + 2].Count() != i - 1 && i >= 1 || !CountCheck(sizedLists[3 * i + 2])) return false;
                for (Node<int> node = sizedLists[3 * i].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
                for (Node<int> node = sizedLists[3 * i + 1].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
                for (Node<int> node = sizedLists[3 * i + 2].head; node != null && node.next != null; node = node.next)
                    if (node.value > node.next.value) return false;
            }
            return true;

       }
       public static bool CountCheck(OrderedList<int> list)
       {
            var i = 0;
            Node<int> node = list.head;
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
       public static bool ClearTest()
       {
            List<OrderedList<int>> sizedLists = new List<OrderedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                sizedLists.Add(new OrderedList<int>(true));
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Add(j);
                }
                for (int j = 0; j < i; ++j)
                {
                    sizedLists[i].Clear(true);
                    if (sizedLists[i].Count() != 0 || !CountCheck(sizedLists[i])) return false;
                }
            }
            return true;

       }
    }
}
