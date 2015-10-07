namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 22;
            const int MaxValue = 150;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            Console.WriteLine(collectionToSort);

            var collectionToShuffle = new SortableCollection<int>(1, 2, 3, 4, 5);
            Console.WriteLine("Before shufflin` " + collectionToShuffle);
            collectionToShuffle.Shuffle();
            Console.WriteLine("After shufflin` " + collectionToShuffle);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            // collection.Sort(new Quicksorter<int>());
            collection.Sort(new InsertionSorter<int>());
            Console.WriteLine(collection);
        }
    }
}
