///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: Class that holds methods in order to use QuickSort algorithm
//              to sort a collection (currently only int array)
//
// Complexity: O(nLog(n))
///////////////////////////////////////////////////////////////////////////////

using System.Diagnostics;

namespace AS_SortJaggedArray
{
    public class QuickSort
    {
        #region QuickSort
        // Sourced from https://www.geeksforgeeks.org/quick-sort/ with modifications for clarity

        // Counter for for iterations within data set
        public int Iterations = 0;
        // Timing of sort
        public Stopwatch quickWatch = new Stopwatch();

        /// <summary>
        /// Recursively partitions array into subarrays to be sorted by QuickSort method
        /// </summary>
        /// <param name="array">Input integer array to be sorted</param>
        /// <param name="start">The starting index of the partition</param>
        /// <param name="end">The last index of the partition</param>
        public void SortArray(int[] array, int start, int end)
        {
            // Check to see if quicksort has finished
            if (start < end)
            {
                quickWatch.Start();
                // partIndex is partitioning index
                int partIndex = SortPartition(array, start, end);

                // Separately sort elements pre- and post- partition
                SortArray(array, start, partIndex - 1);
                SortArray(array, partIndex + 1, end);

                quickWatch.Stop();
            }
        }
        /// <summary>
        /// Uses in-place swapping to push indices around based on pivot in last index.
        /// </summary>
        /// <param name="partitionArray"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int SortPartition(int[] partitionArray, int start, int end)
        {

            // pivot
            int pivot = partitionArray[end];

            // Index of smaller element, array is correct up to this point
            // - 1 to accomodate implementation of increment
            int leftIndex = (start - 1);

            // From start to everything up to the pivot (last index)
            for (int j = start; j <= end - 1; j++)
            {
                Iterations++;
                // If current element is smaller than pivot
                if (partitionArray[j] < pivot)
                {
                    // Increment left index to get correct placement position
                    leftIndex++;
                    // Swap jth element into the leftIndex position
                    ArraySwap(partitionArray, leftIndex, j);
                }
            }
            // Put the pivot in the right spot within the partition
            ArraySwap(partitionArray, leftIndex + 1, end);
            // Return the index where the current pivot is placed into the partition
            return (leftIndex + 1);
        }

        // NOTE: This class is given its own copy of ArraySwap such that it could be freely copied to another project (decoupling).
        /// <summary>
        /// Swaps elements of the given array indices.
        /// </summary>
        /// <param name="array">Input array, passed by reference</param>
        /// <param name="first">The index of the first element to be swapped</param>
        /// <param name="second">The index of the second element to be swapped</param>
        void ArraySwap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
        #endregion
    }
}
