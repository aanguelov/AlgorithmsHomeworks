namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int start = 0;
            int end = collection.Count - 1;
            this.QuickSort(collection, start, end);
        }

        public void QuickSort(List<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    Swap(collection, i, storeIndex);

                    storeIndex++;
                }
            }

            storeIndex--;

            Swap(collection, start, storeIndex);

            this.QuickSort(collection, start, storeIndex);
            this.QuickSort(collection, storeIndex + 1, end);
        }

        private static void Swap(List<T> collection, int i, int storeIndex)
        {
            T temp = collection[i];
            collection[i] = collection[storeIndex];
            collection[storeIndex] = temp;
        }
    }
}
