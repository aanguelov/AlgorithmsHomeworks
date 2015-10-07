namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int target = i;

                while (target > 0 && collection[i].CompareTo(collection[target - 1]) < 0)
                {
                    target--;
                }

                if (target < i)
                {
                    T item = collection[i];
                    collection.RemoveAt(i);
                    collection.Insert(target, item);
                }
            }
        }
    }
}
