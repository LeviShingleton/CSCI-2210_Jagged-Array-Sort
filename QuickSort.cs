///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: Class that holds methods in order to use QuickSort algorithm
//              to sort a collection (currently only jagged array)
//
///////////////////////////////////////////////////////////////////////////////

namespace AS_SortJaggedArray
{
    public class QuickSort
    {
        #region QuickSort
        // Sourced from https://www.geeksforgeeks.org/quick-sort/ with modifications for clarity

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
                // partIndex is partitioning index
                int partIndex = SortPartition(array, start, end);

                // Separately sort elements pre- and post- partition
                SortArray(array, start, partIndex - 1);
                SortArray(array, partIndex + 1, end);
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

        /// <summary>
        /// Swaps elements of the given array indices.
        /// </summary>
        /// <param name="array">Input array, passed by reference</param>
        /// <param name="source">The index of the first element to be swapped</param>
        /// <param name="destination">The index of the second element to be swapped</param>
        void ArraySwap(int[] array, int source, int destination)
        {
            var temp = array[source];
            array[source] = array[destination];
            array[destination] = temp;
        }
        #endregion
    }
}
