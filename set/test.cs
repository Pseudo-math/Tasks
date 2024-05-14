using System;
using System.Collections.Generic;
using System.Diagnostics;

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

    class Program
    {
        static void Main(string[] args)
        {
            // Тесты
            PowerSet<string> set1 = new PowerSet<string>();
            PowerSet<string> set2 = new PowerSet<string>();

            // Put, Get
            Console.WriteLine("Put and Get tests:");
            set1.Put("test1");
            Console.WriteLine(set1.Get("test1")); // true
            Console.WriteLine(set1.Get("test2")); // false
            set1.Put("test1");
            Console.WriteLine(set1.Size()); // 1 

            // Remove
            Console.WriteLine("\nRemove tests:");
            Console.WriteLine(set1.Remove("test1")); // true
            Console.WriteLine(set1.Get("test1")); // false
            Console.WriteLine(set1.Remove("test2")); // false

            // Intersection
            Console.WriteLine("\nIntersection tests:");
            set1.Put("test1");
            set1.Put("test2");
            set2.Put("test2");
            set2.Put("test3");
            PowerSet<string> intersection = set1.Intersection(set2);
            Console.WriteLine(intersection.Size()); // 1
            Console.WriteLine(intersection.Get("test2")); // true
            Console.WriteLine(intersection.Get("test1")); // false

            PowerSet<string> emptySet = new PowerSet<string>();
            intersection = set1.Intersection(emptySet);
            Console.WriteLine(intersection.Size()); // 0

            // Union
            Console.WriteLine("\nUnion tests:");
            PowerSet<string> union = set1.Union(set2);
            Console.WriteLine(union.Size()); // 3
            Console.WriteLine(union.Get("test1")); // true
            Console.WriteLine(union.Get("test2")); // true
            Console.WriteLine(union.Get("test3")); // true

            union = set1.Union(emptySet);
            Console.WriteLine(union.Size()); // 2
            Console.WriteLine(union.Get("test1")); // true
            Console.WriteLine(union.Get("test2")); // true

            // Difference
            Console.WriteLine("\nDifference tests:");
            PowerSet<string> difference = set1.Difference(set2);
            Console.WriteLine(difference.Size()); // 1
            Console.WriteLine(difference.Get("test1")); // true
            Console.WriteLine(difference.Get("test2")); // false

            difference = set1.Difference(emptySet);
            Console.WriteLine(difference.Size()); // 2
            Console.WriteLine(difference.Get("test1")); // true
            Console.WriteLine(difference.Get("test2")); // true

            // IsSubset
            Console.WriteLine("\nIsSubset tests:");
            Console.WriteLine(set1.IsSubset(set2)); // false
            Console.WriteLine(set2.IsSubset(set1)); // false
            PowerSet<string> subset = new PowerSet<string>();
            subset.Put("test2");
            Console.WriteLine(set1.IsSubset(subset)); // true

            // Performance test
            Console.WriteLine("\nPerformance test:");
            PowerSet<string> largeSet1 = new PowerSet<string>();
            PowerSet<string> largeSet2 = new PowerSet<string>();

            // Add 10,000 items to each set
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                largeSet1.Put("item" + i);
                largeSet2.Put("item" + (i + 5000));
            }

            // Perform set operations
            PowerSet<string> largeIntersection = largeSet1.Intersection(largeSet2);
            PowerSet<string> largeUnion = largeSet1.Union(largeSet2);
            PowerSet<string> largeDifference = largeSet1.Difference(largeSet2);

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}
