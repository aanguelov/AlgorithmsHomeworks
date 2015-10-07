namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int start = 0;
            int end = collection.Count - 1;
            T[] tempArr = new T[end - start + 1];

            this.MergeSort(collection, tempArr, start, end);
        }

        private void MergeSort(List<T> array, T[] tempArr, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                this.MergeSort(array, tempArr, start, middle);
                this.MergeSort(array, tempArr, middle + 1, end);

                //tempArr = new T[end - start + 1];

                int leftMinIndex = start;
                int rightMinIndex = middle + 1;
                int tempIndex = 0;

                while (leftMinIndex <= middle && rightMinIndex <= end)
                {
                    if (array[leftMinIndex].CompareTo(array[rightMinIndex]) < 0)
                    {
                        tempArr[tempIndex] = array[leftMinIndex];
                        tempIndex++;
                        leftMinIndex++;
                    }
                    else
                    {
                        tempArr[tempIndex] = array[rightMinIndex];
                        tempIndex++;
                        rightMinIndex++;
                    }
                }

                while (leftMinIndex <= middle)
                {
                    tempArr[tempIndex] = array[leftMinIndex];
                    tempIndex++;
                    leftMinIndex++;
                }

                while (rightMinIndex <= end)
                {
                    tempArr[tempIndex] = array[rightMinIndex];
                    tempIndex++;
                    rightMinIndex++;
                }

                tempIndex = 0;
                leftMinIndex = start;

                while (tempIndex < tempArr.Length && leftMinIndex <= end)
                {
                    array[leftMinIndex] = tempArr[tempIndex];
                    leftMinIndex++;
                    tempIndex++;
                }
            }
        }
    }
}
