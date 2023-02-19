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
        // Sorting, searching objects for use in Program.cs || Global for console output references
        static QuickSort quickSorter= new QuickSort();
        static SelectionSort selectionSorter = new SelectionSort();
        static BinarySearch binarySearcher = new BinarySearch();
        #endregion
        static void Main(string[] args)
        {
            #region Main Variables
            int[][] quickSortJagged = new int[20][], selectSortJagged = new int[20][];  // Jagged arrays to sort
            const string HR = "\n------------------------------------------\n";         // horizontal line for console output
            // Input data from csv file
            string filepath = @"..\..\..\External Resources\inputJagged.csv";
            CsvToJagged csvReader = new CsvToJagged();
            #endregion

            #region Getting CSV Data
            // Read .csv contents to csvJagArray
            csvReader.ReadToJagged(quickSortJagged, filepath);
            csvReader.ReadToJagged(selectSortJagged, filepath);
            #endregion

            #region QuickSort
            if (quickSortJagged.Length > 0) // Ensure that input array isn't empty
            {
                Console.WriteLine($"QuickSort {HR}");

                JaggedQuickSort(quickSortJagged); // Use QuickSort to sort the subarrays

                Console.WriteLine(PrintJaggedArray(quickSortJagged));  // Write each line of CSV to console
                Console.WriteLine($"QuickSort elapsed time: {quickSorter.quickWatch.Elapsed} " +
                    $"using {quickSorter.Iterations} iterations.{HR}");
            }
            #endregion

            #region SelectSort
            if (selectSortJagged.Length > 0) 
            {
                Console.WriteLine($"Selection Sort {HR}");

                JaggedSelectSort(selectSortJagged);

                Console.WriteLine(PrintJaggedArray(selectSortJagged));
                Console.WriteLine($"Selection Sort elapsed time: {selectionSorter.selectWatch.Elapsed} " +
                    $"using {selectionSorter.Iterations} iterations.{HR}");
            }
            #endregion

            #region Binary Search Output
            int searchTarget = 256;
            string result = "";     // container for all lines of binary search output
            Console.WriteLine($"Binary Search: Target {searchTarget}{HR}");

            for (int i = 0; i < quickSortJagged.Length; i++)
            {
                string line = $"Subarray {i.ToString("D2")} : ";                                                   // Each line begins with array label
                string strTargetIndex = binarySearcher.SearchArray(searchTarget,  quickSortJagged[i]).ToString();  // Perform binary search for target
                // Determine if found or not
                if (strTargetIndex == "-1")
                {
                    line += $"{strTargetIndex} : {searchTarget} not found.\n";
                }
                else
                {
                    line += $"{searchTarget} found at index {strTargetIndex}.\n";
                }

                // Write completed line
                result += line;
            }

            Console.Write(result);
            #endregion
        }

        /// <summary>
        /// Driver method to sort the integer subarrays of a jagged array using Quick Sort
        /// </summary>
        /// <param name="arrayToSort">The jagged array to be sorted</param>
        public static void JaggedQuickSort(int[][] arrayToSort)
        {
            // Sorting Loop, iterating over subarrays
            for (int i = 0; i < arrayToSort.Length; i++) 
            {
                quickSorter.SortArray(arrayToSort[i], 0, arrayToSort[i].Length - 1);
            }
        }

        /// <summary>
        /// Driver method to sort the integer subarrays of a jagged array using Selection Sort
        /// </summary>
        /// <param name="arrayToSort">The jagged array to be sorted</param>
        public static void JaggedSelectSort(int[][] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                selectionSorter.SortArray(arrayToSort[i]);
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