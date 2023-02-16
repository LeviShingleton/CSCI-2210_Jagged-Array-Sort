///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: Class that holds methods in order to use binary search algorithm
//              to search for a target in a collection
//              (currently only jagged array)
//
///////////////////////////////////////////////////////////////////////////////

namespace AS_SortJaggedArray
{
    public class BinarySearch
    {
        /// <summary>
        /// Performs a binary search for target integer within sorted integer array.
        /// </summary>
        /// <param name="targetValue">Integer value to search for</param>
        /// <param name="searchArray">Sorted integer array to search in</param>
        /// <returns>Integer index where targetValue is found in searchArray</returns>
        public int SearchArray(int targetValue, int[] searchArray)
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
            int leftBound = 0; // Left bound of search iteration; by default, is very start of entire array
            int rightBound = searchArray.Length - 1; // Right bound of search iteration; defaults to end of entire array

            try
            {
                while (searchArray[current] != targetValue && searchArray != null)
                {
                    // If at "very end" of search, return -1 for not found
                    if (current == leftBound || searchArray[current] == rightBound)
                    {
                        return -1;
                    }

                    // Searching to left
                    if (targetValue < searchArray[current])
                    {
                        rightBound = current;  // New right bound is the current step
                        current = (leftBound + current) / 2; // midpoint to left
                    }
                    // Searching to right
                    else if (targetValue > searchArray[current])
                    {
                        leftBound = current;    // New left bound is the current step
                        current = (rightBound + current) / 2; // midpoint to right
                    }
                }
                return current;
            }

            catch (Exception e)
            {
                Console.WriteLine("BinarySearch.cs :: int SearchArray : Failure " + e);
                return -1;
            }
        }
    }
}
