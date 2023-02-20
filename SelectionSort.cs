///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: Class that holds methods in order to use Selection Sort algorithm
//              to sort a collection (currently only int array)
//
// Complexity: O(n^2)
///////////////////////////////////////////////////////////////////////////////
using System.Diagnostics;
///
namespace AS_SortJaggedArray
{
    public class SelectionSort
    {
        // Pseudocode
        // Need sorted and unsorted part of array - i will delimit
        // Loop through all elements of unsorted to find minimum
        // Swap minimum to i

        /// <summary>
        /// Counter for sort iterations on data set
        /// </summary>
        public int Iterations = 0;
        /// <summary>
        /// Stopwatch that tracks the time to sort completely
        /// </summary>
        public Stopwatch selectWatch = new Stopwatch();
        public void SortArray(int[] array)
        {
            selectWatch.Start();
            // For each element in the array...
            for (int i = 0; i < array.Length; i++)
            {
                Iterations++;
                int min = i;
                // ...then for every other element in the array beyond i...
                for (int j = i + 1; j < array.Length; j++)
                {
                    Iterations++;
                    // If a new minimum is found, set it
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }
                // Perform swap with minimum beyond i into i
                ArraySwap(array, i, min);
            }
            selectWatch.Stop();
        }
        // NOTE: This class is given its own copy of ArraySwap such that it could be freely copied to another project (decoupling).
        /// <summary>
        /// Swaps elements of the given array indices.
        /// </summary>
        /// <param name="array">Input array, passed by reference</param>
        /// <param name="source">The index of the first element to be swapped</param>
        /// <param name="destination">The index of the second element to be swapped</param>
        private void ArraySwap(int[] array, int source, int destination)
        {
            var temp = array[source];
            array[source] = array[destination];
            array[destination] = temp;
        }
    }
}
