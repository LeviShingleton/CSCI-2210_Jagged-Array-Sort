///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: Program that implements a QuickSort/Merge Sort algorithm
//              to sort an integer jagged array.
//
///////////////////////////////////////////////////////////////////////////////

using AS_SortJaggedArray;

namespace AS_Project2
{
    internal class Program
    {
        #region Global Variables
        static QuickSort quickSorter= new QuickSort();
        static BinarySearch binarySearcher = new BinarySearch();
        #endregion
        static void Main(string[] args)
        {
            #region Main Variables
            int[][] csvJagArray = new int[20][];
            string filepath = @"..\..\..\External Resources\inputJagged.csv";
            CsvToJagged reader = new CsvToJagged();
            #endregion

            #region Getting CSV Data
            // Read .csv contents to csvJagArray
            reader.ReadToJagged(csvJagArray, filepath);

            if(csvJagArray.Length != 0) // Ensure that input array isn't empty
            {
                JaggedSort(csvJagArray); // Use QuickSort to sort the subarrays

                Console.WriteLine(PrintJaggedArray( csvJagArray));
            }
            #endregion

            #region Binary Search Output
            int intTarget = 256;
            for (int i = 0; i < csvJagArray.Length; i++)
            {
                string strTargetIndex = binarySearcher.SearchArray(intTarget,  csvJagArray[i]).ToString();  // Perform binary search for 256
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
                quickSorter.SortArray(arrayToSort[i], 0, arrayToSort[i].Length - 1);
            }
        }

        /// <summary>
        /// Returns text block describing the contents of the input jagged array.
        /// </summary>
        /// <param name="array">Input integer array to write to console</param>
        /// <returns>result string as formatted array text block</returns>
        public static string PrintJaggedArray(int[][] array)
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