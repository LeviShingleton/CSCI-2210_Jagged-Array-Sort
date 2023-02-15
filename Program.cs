///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: Program that implements a QuickSort/Merge Sort algorithm
//              to sort an integer jagged array.
//
///////////////////////////////////////////////////////////////////////////////

namespace AS_Project2
{
    internal class Program
    {
        // Global Random object for getting pivot in QuickSort
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int[][] csvJagArray = new int[20][];
            string filepath = @"..\..\..\External Resources\inputJagged.csv";
            CsvToJagged reader = new CsvToJagged();

            // Read .csv contents to csvJagArray
            reader.ReadToJagged(ref csvJagArray, filepath);

            if(csvJagArray.Length != 0) // Ensure that input array isn't empty
            {
                JaggedSort(csvJagArray); // Use QuickSort to sort the subarrays

                Console.WriteLine(PrintJaggedArray(ref csvJagArray));
            }

            #region Binary Search Output
            int intTarget = 256;
            for (int i = 0; i < csvJagArray.Length; i++)
            {
                string strTargetIndex = BinarySearch(intTarget, ref csvJagArray[i]).ToString();  // Perform binary search for 256
                if (strTargetIndex == "-1")
                {
                    Console.WriteLine(
                        $"{strTargetIndex}: {intTarget} not found");
                }
                else
                {
                    Console.WriteLine($"{intTarget} found at index {strTargetIndex}.");
                }
            }
            #endregion
        }

        /// <summary>
        /// Driver method to sort the subarrays of an integer jagged array.
        /// </summary>
        /// <param name="arrayToSort">The jagged array to be sorted</param>
        public static void JaggedSort(int[][] arrayToSort)
        {
            // Sorting Loop, iterating over subarrays
            for (int i = 0; i < arrayToSort.Length; i++) 
            {
                QuickSort(arrayToSort[i], 0, arrayToSort[i].Length - 1);
            }
        }

        #region GeeksForGeeks Reference
        // Sourced from https://www.geeksforgeeks.org/quick-sort/

        /// <summary>
        /// Recursively partitions array into subarrays to be sorted by QuickSort method
        /// </summary>
        /// <param name="array">Input integer array to be sorted</param>
        /// <param name="start">The starting index of the partition</param>
        /// <param name="end">The last index of the partition</param>
        static void QuickSort(int[] array, int start, int end)
        {
            // Check to see if quicksort has finished
            if (start < end)
            {
                // partIndex is partitioning index
                int partIndex = SortPartition(array, start, end);

                // Separately sort elements pre- and post- partition
                QuickSort(array, start, partIndex - 1);
                QuickSort(array, partIndex + 1, end);
            }
        }
        /// <summary>
        /// Uses in-place swapping to push indices around based on pivot in last index.
        /// </summary>
        /// <param name="partitionArray"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static int SortPartition(int[] partitionArray, int start, int end)
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
                    ArraySwap(ref partitionArray, leftIndex, j);
                }
            }
            // Put the pivot in the right spot within the partition
            ArraySwap(ref partitionArray, leftIndex + 1, end);
            // Return the index where the current pivot is placed into the partition
            return (leftIndex + 1);
        }

        /// <summary>
        /// Swaps elements of the given array indices.
        /// </summary>
        /// <param name="array">Input array, passed by reference</param>
        /// <param name="source">The index of the first element to be swapped</param>
        /// <param name="destination">The index of the second element to be swapped</param>
        public static void ArraySwap(ref int[] array, int source, int destination)
        {
            var temp = array[source];
            array[source] = array[destination];
            array[destination] = temp;
        }
        #endregion

        /// <summary>
        /// Performs a binary search for target integer within sorted array.
        /// </summary>
        /// <param name="targetValue">Integer value to search for</param>
        /// <param name="searchArray">Sorted integer array to search in</param>
        /// <returns>Integer index where targetValue is found in searchArray</returns>
        public static int BinarySearch(int targetValue, ref int[] searchArray)
        {
            /* Pseudocode
             * Start at middle: current = array.Length / 2
             * If target < array[current] look in left half
             *      set current to midpoint between "start" and current
             *      "end" becomes previous
             * Else, if target > array[current], look in right half
             *      set current to midpoint between current and "end"
             *      "start" becomes current
             * Repeat until target found or all options exhausted
             */

            int current = searchArray.Length / 2; // The current placement of the search, starting at midpoint of array
            int leftBound = 0; // Left bound of search iteration
            int rightBound = searchArray.Length - 1; // Right bound of search iteration

            try
            {
                while (searchArray[current] != targetValue && searchArray != null)
                {
                    if (current == leftBound || searchArray[current] == rightBound)
                    {
                        return -1;
                    }

                    if (targetValue < searchArray[current])
                    {
                        rightBound = current;
                        current = (leftBound + current) / 2; // midpoint to left
                    }
                    else if (targetValue > searchArray[current])
                    {
                        leftBound = current;
                        current = (rightBound + current) / 2; // midpoint to right
                    }
                }
                return current;
            }
            
            catch(Exception e) 
            {
                Console.WriteLine("Binary search failure: " + e);
                return -1;
            }
        }

        /// <summary>
        /// Returns text block describing the contents of the input jagged array.
        /// </summary>
        /// <param name="array">Input integer array to write to console</param>
        /// <returns>result string as formatted array text block</returns>
        public static string PrintJaggedArray(ref int[][] array)
        {
            string result = "";
            // Iterate on line
            for (int i = 0; i < array.Length; i++)
            {
                // Iterate on line contents
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (j == array[i].Length - 1)
                    {
                        result += array[i][j].ToString() + "\n\n";    // Final line of this array's contents
                    }
                    else
                    {
                        result += $"{array[i][j]}, ";
                    }
                }
                
            }
            return result;
        }
    }
}