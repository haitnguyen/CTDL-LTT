using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CTDL_LeThanhTrung
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            int[] sourceArr = readHexNumbers(@"..\..\..\input\hex_numbers.txt");

            //2
            sourceArr = selectionSort(sourceArr);
            Console.WriteLine("Sorted array: ");
            foreach (int i in sourceArr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //3
            Console.WriteLine("Search value...");
            int searchNumber = 102;
            Console.WriteLine("Search number: " + searchNumber);
            int searchPosition = binarySearch(sourceArr, searchNumber);
            Console.WriteLine("Position of search item is: " + searchPosition);
            Console.WriteLine();

            //4
            writeHexNumbers(sourceArr);

            //5
             Console.WriteLine();
            int[] oddArr = getOdd(sourceArr);
            Queue oddQueue = new Queue(oddArr.Length);
            foreach (int i in oddArr)
            {
                oddQueue.push(i);
            }
            writeToFile(oddQueue, "odd_queue.txt");

            Console.WriteLine();
            int[] evenArr = getEven(sourceArr);
            Queue evenQueue = new Queue(evenArr.Length);
            foreach (int i in evenArr)
            {
                evenQueue.push(i);
            }
            writeToFile(evenQueue, "even_queue.txt");

        }

        private static int[] readHexNumbers(String fileUri) 
        {
            int[] arrResult = null;
            try
            {
                using (StreamReader sr = new StreamReader(fileUri))
                {
                    Console.WriteLine("Start read file...");
                    String content = sr.ReadToEnd();
                    Console.WriteLine("File content: ");
                    Console.WriteLine(content);
                    string[] arrContent = Regex.Split(content, @"[ \t\n]").ToArray();
                    arrResult = new int[arrContent.Length];
                    Console.WriteLine("Convert file content into int array: ");
                    for (int i = 0; i < arrContent.Length; i++)
                    {
                        arrResult[i] = Convert.ToInt32(arrContent[i], 16);
                        Console.WriteLine(arrResult[i]);
                    }
                    sr.Close();
                    Console.WriteLine("Complete read file");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return arrResult;
        }

        private static void writeHexNumbers(int[] inputArrs)
        {
            string path = @"..\..\..\output\sorted_numbers.txt";
            StreamWriter sw = new StreamWriter(path);
            Console.WriteLine(@"Start writing data to output\sorted_numbers.txt");
            foreach (int i in inputArrs)
            {

                sw.WriteLine(i.ToString("X"));
                Console.WriteLine("wrote " + i.ToString("X") + " to file");
            }
            sw.Close();
            Console.WriteLine("complete writing data to file");

        }

        private static int[] selectionSort(int[] inputArrs)
        {
            int smallestIndex, index, minIndex, temp;

            for (index = 0; index < inputArrs.Length - 1; index++)
            {
                smallestIndex = index;

                for (minIndex = index; minIndex < inputArrs.Length; minIndex++)
                {
                    if (inputArrs[minIndex] < inputArrs[smallestIndex])
                    {
                        smallestIndex = minIndex;
                    }
                }
                temp = inputArrs[smallestIndex];
                inputArrs[smallestIndex] = inputArrs[index];
                inputArrs[index] = temp;

            }

            return inputArrs;
        }

        private static int binarySearch(int[] arrSearch, int searchElement)
        {
            int low = 0; 
            int high = arrSearch.Length - 1; 
            int middle = (low + high + 1) / 2; 
            int position = -1;

            do 
            {
                if (searchElement == arrSearch[middle])
                {
                    position = middle;
                }
                else if (searchElement < arrSearch[middle])
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }

                middle = (low + high + 1) / 2;
            } while ((low <= high) && (position == -1));

            return position;
        }

        private static int[] getOdd(int[] arr)
        {
            int index = -1;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0 && arr[i] % 2 == 0)
                {
                    count++;
                }

            }

            int[] result = new int[count];
            for (int i = 0; i < arr.Length; i++)
            {
                int number = arr[i];
                if (arr[i] != 0 && number % 2 == 0)
                {
                    result[++index] = number;
                }

            }
            return result;
        }

        private static int[] getEven(int[] arr)
        {
            int index = -1;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0 && arr[i] % 2 != 0)
                {
                    count++;
                }

            }

            int[] result = new int[count];
            for (int i = 0; i < arr.Length; i++)
            {
                int number = arr[i];
                if (arr[i] != 0 && number % 2 != 0)
                {
                    result[++index] = number;
                }

            }
            return result;
        }

        private static void writeToFile(Queue queue, String uri)
        {
            string path = @"..\..\..\output\" + uri;
            StreamWriter sw = new StreamWriter(path);
            Console.WriteLine(@"Start writing data to \output\" + uri);
            int item = 0;
            while (item != -1)
            {
                item = queue.pop();
                if (item != -1)
                {
                    sw.WriteLine(item.ToString("X"));
                    Console.WriteLine(item.ToString("X"));
                }
            }
            sw.Close();
            Console.WriteLine("complete writing data to file");

        }
    }
}
