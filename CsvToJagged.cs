///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Jagged Array Sorting
// Description: This class handles reading integer values from a .csv file
//              into the provided integer jagged array.
//
///////////////////////////////////////////////////////////////////////////////

namespace AS_Project2
{
    public class CsvToJagged
    {   
        /// <summary>
        /// Reads .CSV values into jagArray as integers.
        /// Uses StreamReader class to accomplish this.
        /// </summary>
        /// <param name="jagArray">Reference to jagged array of preset size.</param>
        public void ReadToJagged(ref int[][] jagArray, string filePath)
        {
            // try/catch to properly open, utilize, and close StreamReader
            // sourced from StreamReader doc within Microsoft Learn
            // https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-7.0
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader csvReader = new StreamReader(filePath))
                {
                    // line contains the current line of the CSV
                    string line;
                    // jagX is the index of current subarray that is being filled
                    int jagX = 0;

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = csvReader.ReadLine()) != null)
                    {
                        // Set up jagY for assigning values to jagArray[jagX]
                        // elementValue is parsed int from CSV line
                        int jagY = 0, elementValue = 0;
                        // Get line contents as array, set jagX length as length of line contents
                        string[] lineArray = line.Split(',');
                        jagArray[jagX] = new int[lineArray.Length];

                        // Parse line contents and store at jagArray[jagX][jagY]
                        // Increment jagY to go to next index for jagX
                        foreach (string element in lineArray)
                        {
                            int.TryParse(element, out elementValue);
                            jagArray[jagX][jagY] = elementValue;
                            jagY++;
                        }
                        // Move to fill new jagX for incoming new line.
                        jagX++;
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
