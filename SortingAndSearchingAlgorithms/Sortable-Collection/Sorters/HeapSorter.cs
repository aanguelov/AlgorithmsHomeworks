namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int heapSize = collection.Count;
            for (int i = (heapSize - 1) / 2; i >= 0; i--)
            {
                this.HeapifyDown(collection, heapSize, i);
            }

            for (int i = collection.Count - 1; i > 0; i--)
            {
                T temp = collection[i];
                collection[i] = collection[0];
                collection[0] = temp;

                heapSize--;
                this.HeapifyDown(collection, heapSize, 0);
            }
        }

        private void HeapifyDown(List<T> collection, int size, int index)
        {
            int left = (2 * index) + 1;
            int right = (2 * index) + 2;
            int largest = index;

            if (left < size && collection[left].CompareTo(collection[largest]) > 0)
            {
                largest = left;
            }

            if (right < size && collection[right].CompareTo(collection[largest]) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                T temp = collection[index];
                collection[index] = collection[largest];
                collection[largest] = temp;

                this.HeapifyDown(collection, size, largest);
            }
        }
    }
}
