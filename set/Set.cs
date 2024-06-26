using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        public int size;
        private const int sizeInner = 20000;
        public T[] slots;

        public PowerSet()
        {
            size = 0;
            slots = new T[sizeInner];
        }

        public int Size()
        {
            return size;
        }

        public int HashFun(T value)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes((string)(object)value);
            int result = 0;
            foreach (var i in bytes)
                result += Convert.ToInt32(i);
            return result % sizeInner;
        }

        public int SeekSlot(T value)
        {
            int slot = HashFun(value);
            for (int i = slot; i < sizeInner; ++i)
            {
                if (slots[i] == null || slots[i].Equals(default(T))) return i;
            }
            for (int i = 0; i < slot; ++i)
                if (slots[i] == null || slots[i].Equals(default(T))) return i;
            return -1;
        }

        public bool IsKey(T key)
        {
            int slot = HashFun(key);
            for (int i = slot; i < sizeInner; ++i)
                if (slots[i] != null && slots[i].Equals(key)) return true;
            for (int i = 0; i < slot; ++i)
                if (slots[i] != null && slots[i].Equals(key)) return true;
            return false;
        }

        public void Put(T value)
        {
            if (IsKey(value)) return;
            int slot = SeekSlot(value);
            slots[slot] = value;
            ++size;
        }

        public bool Get(T value)
        {
            int slot = HashFun(value);
            for (int i = slot; i < sizeInner; ++i)
                if (slots[i] != null && slots[i].Equals(value))
                    return true;
            for (int i = 0; i < slot; ++i)
                if (slots[i] != null && slots[i].Equals(value))
                    return true;
            return false;
        }

        public bool Remove(T value)
        {
            int slot = HashFun(value);
            for (int i = slot; i < sizeInner; ++i)
            {
                if (slots[i] != null && slots[i].Equals(value))
                {
                    slots[i] = default(T);
                    --size;
                    return true;
                }
            }
            for (int i = 0; i < slot; ++i)
            {
                if (slots[i] != null && slots[i].Equals(value))
                {
                    slots[i] = default(T);
                    --size;
                    return true;
                }
            }
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            PowerSet<T> intersectionSet = new PowerSet<T>();
            foreach (T item in slots)
            {
                if (item != null && set2.IsKey(item))
                    intersectionSet.Put(item);
            }
            return intersectionSet;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            PowerSet<T> unionSet = new PowerSet<T>();
            foreach (T item in slots)
                if (item != null) unionSet.Put(item);
            foreach (T item in set2.slots)
                if (item != null) unionSet.Put(item);
            return unionSet;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            PowerSet<T> differenceSet = new PowerSet<T>();
            foreach (T item in slots)
            {
                if (item != null && !set2.IsKey(item))
                    differenceSet.Put(item);
            }
            return differenceSet;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (T item in set2.slots)
            {
                if (item != null && !IsKey(item))
                    return false;
            }
            return true;
        }
    }
}





