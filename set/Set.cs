using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  // наследуйте этот класс от HashTable
  // или расширьте его методами из HashTable
  public class PowerSet<T>
  {

   public PowerSet()
   {
     // ваша реализация хранилища
   }

    public int Size()
    {
        // количество элементов в множестве
        return 0;
    }

   public void Put(T value)
   {
     // всегда срабатывает
   }

    public bool Get(T value)
    {
        // возвращает true если value имеется в множестве,
        // иначе false
        return false;
    }

    public bool Remove(T value)
    {
        // возвращает true если value удалено
        // иначе false
        return false;
    }

    public PowerSet<T> Intersection(PowerSet<T> set2)
    {
        // пересечение текущего множества и set2
        return null;
    }

    public PowerSet<T> Union(PowerSet<T> set2)
    {
        // объединение текущего множества и set2
        return null;
    }

    public PowerSet<T> Difference(PowerSet<T> set2)
    {
        // разница текущего множества и set2
        return null;
    }

    public bool IsSubset(PowerSet<T> set2)
    {
        // возвращает true, если set2 есть
        // подмножество текущего множества,
        // иначе false
        return false;
    }
  }
}






