namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>, IConvertible
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set; }

        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearchProcedure(item, 0, this.Count - 1);
        }

        public int InterpolationSearch(T item)
        {
            int start = 0;
            int end = this.Count - 1;
            int mid;

            if (end < start)
            {
                return -1;
            }

            while (this.Items[start].CompareTo(item) <= 0 && this.Items[end].CompareTo(item) >= 0)
            {
                int intItem = item.ToInt32(CultureInfo.InvariantCulture);
                int startItem = this.Items[start].ToInt32(CultureInfo.InvariantCulture);
                int endItem = this.Items[end].ToInt32(CultureInfo.InvariantCulture);

                mid = start + (((intItem - startItem) * (end - start)) / (endItem - startItem));

                int midItem = this.Items[mid].ToInt32(CultureInfo.InvariantCulture);

                if (midItem < intItem)
                {
                    start = mid + 1;
                }
                else if (midItem > intItem)
                {
                    start = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (this.Items[start].CompareTo(item) == 0)
            {
                return start;
            }

            return -1;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            int n = this.Count;

            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(0, n - i);

                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }

        private int BinarySearchProcedure(T item, int minIndex, int maxIndex)
        {
            if (maxIndex < minIndex)
            {
                return -1;
            }

            int midIndex = minIndex + (maxIndex - minIndex) / 2;

            if (this.Items[midIndex].CompareTo(item) > 0)
            {
                return this.BinarySearchProcedure(item, minIndex, midIndex - 1);
            }

            if (this.Items[midIndex].CompareTo(item) < 0)
            {
                return this.BinarySearchProcedure(item, midIndex + 1, maxIndex);
            }

            return midIndex;
        }
    }
}