using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);

            int n2 = 5;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            displayArray(r5);

            solvePuzzle();
        }

        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                int a;
                string output = "";
                for (a = x; a <= y; a++)
                {
                    // initializing the List to hold digits of a number
                    List<int> digits = new List<int>();
                    // intializing required variables
                    int digit;
                    // intializing remainder to 0;
                    int remainder = 0;
                    int j = a;
                    // Splitting the digits of a number and adding it into a List
                    while (j != 0)
                    {
                        digit = j % 10;
                        digits.Add(digit);
                        j = j / 10;
                    }
                    // Dividing the number by each of its digit
                    if (digits.Count != 0)
                    {
                        // looping through each digit of a number stored in 'digits' list 
                        foreach (int i in digits)
                        {
                            // if the digit 'i' of a number is zero then we should not check for the divisibility . Hence assigning random remainder value 1 to 
                            if (i == 0)
                            {
                                remainder = 1;
                                break;

                            }
                            // else remainder will be calculated by dividing the number 'a' by its digit 'i'
                            else
                            {
                                remainder += (a % i);
                            }
                        }
                        /* finally if the remainder is zero i.e if the number is divisible by all of its digits we declare the number as self divding
                         we will store this number in the output variable */
                        if (remainder == 0)
                        {
                            output = output + ',' + a.ToString();

                        }
                    }

                }
                // Printing the final result of all numbers which are self dividing
                Console.WriteLine("Result for Self Dividing numbers");
                Console.WriteLine(output.TrimStart(','));

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        public static void printSeries(int n)
        {
            try
            {
                // intializing 'digits' list to store the series digits
                List<int> digits = new List<int>();
                // initializing empty output string
                string output = "";
                // nested for loop for creating the series digits for specified number n
                for (int i = 1; i <= n; i++)
                {
                    // printing the series of each digit number of times the value of number
                    for (int j = 1; j <= i; j++)
                    {
                        // adding every digit of a series to list
                        digits.Add(i);
                    }
                }
                // looping through each element of list 'digits' to print out the output
                for (int k = 0; k < n; k++)
                {
                    output = output + digits[k].ToString() + ',';
                }
                Console.WriteLine("Result for Series numbers");
                Console.WriteLine(output.TrimEnd(','));
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                // creating  the traingle using '*' and for loop
                Console.WriteLine("Result for printing a Traingle");
                for (int i = n * 2 - 1; i > 0; i = i - 2)
                {
                    int j = i;
                    while (j > 0)
                    {
                        Console.Write('*');
                        j--;
                    }
                    // Printing the traingle using left padding for shape
                    Console.WriteLine();
                    Console.Write(" ".PadLeft((n) - (i - 1) / 2));
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                // Intializing the count variable to zero
                int count = 0;
                /* now creating nested for loops. It basically takes one element from first array and searches for a match in the second array
                  until all the elements of the second array are finished. If the match is found then it increments the count variable */

                for (int i = 0; i < J.Length; i++)
                {

                    for (int j = 0; j < S.Length; j++)
                    {
                        if (J[i] == S[j])
                        {
                            count = count + 1;
                        }

                    }
                    // returning the count of  stones you have which are also jewels.

                }
                Console.WriteLine("Result for number of jewels in stones");
                return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                /* creating  list common to find the common numbers between two arrays */
                List<int> common = new List<int>();
                /* Sorting two input arrays in ascending order */
                Array.Sort(a);
                Array.Sort(b);
                /* Running Loop to find common elements between two arrays */
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                        {
                            common.Add(a[i]);
                        }
                    }
                }
                /* creating hashset to store common list elements */
                HashSet<int> hs = new HashSet<int>();
                /* adding elements from common list to hs set */
                foreach (int n in common)
                {
                    hs.Add(n);
                }
                /* Creating a dictionary 'map' to store sum key and Contigous array list value */
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                /* Looping through hash set 'hs' to find contigous array */
                foreach (int y in hs)
                {
                    /* storing the current value in hashset 'hs' in 'm' */
                    int m = y;
                    /* initializing the 'sum' of contigous array to zero */
                    int sum = 0;
                    /* Creating new list 'digits' to store contigous array elements temporarily */
                    List<int> digits = new List<int>();
                    /* Checking if the current element has the next consequtive element or not*/
                    if (hs.Contains(m + 1))
                        /* starting the while loop to get contigous array if the first element of contigous array is present */
                        while (hs.Contains(m))
                        {
                            /* adding every element of contigous array to sum */
                            sum = sum + m;
                            /* adding every element of contigous array to 'digits' list */
                            digits.Add(m);
                            /* incrementing the contigous array value by 1 */
                            m++;
                        }
                    // checking if the contigous array 'sum' as a key present in the dictionary 'map' */
                    if (!map.ContainsKey(sum))
                    {
                        /* adding the key 'sum' of contigous array and 'value' contigous array list to dictionary 'map' */
                        map.Add(sum, digits);
                    }
                }
                /* find the highest key value of dictionary 'map' */
                int max_sum = map.Keys.Max();
                /* getting the array list from 'map' where key is 'max_sum'  */
                List<int> final_list = map[max_sum];
                /* convert list to array */
                Console.WriteLine("Result for Largest Contigous array");
                return final_list.ToArray();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            return null; // return the actual array
        }
        public static void displayArray(int[] a)
        {
              foreach(int i in a)
              {
                  Console.WriteLine(i.ToString());
              }
        }
        public static void solvePuzzle()
        {
            try
            {
                Console.WriteLine("Result for Puzzle");
                // ASKING FOR INPUT STRINGS
                Console.WriteLine("Enter the input strings");
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                // ASKING FOR OUTPUT STRINGS
                Console.WriteLine("Enter the output string");
                string output = Console.ReadLine();
                // CREATING THE DICTIONARY TO STORE APLHABET NUMBER ASSIGNMENTS
                Dictionary<char, int> dict = new Dictionary<char, int>
            {
                {'U',1 },
                {'B',2 },
                {'E',7 },
                {'R',4 },
                {'C',9 },
                {'O',6 },
                {'L',3 },
                {'N',0 },


            };
                // CONVERTING INPUT STRINGS TO CHARACTER ARRAYS
                Char[] s1 = input1.ToCharArray();
                Char[] s2 = input2.ToCharArray();
                // CONVERTING OUTPUT STRING TO CHAR ARRAY
                Char[] s3 = output.ToCharArray();
                // CREATING EMPTY STRINGS TO STORE NUMBER VALUES FOR APLHABETS USING DICTIONARY
                string num1 = "";
                string num2 = "";
                string num3 = "";
                // GETTING THE VALUE FOR EACH CHARACTER FROM DICTIONARY AND CONCATENATING THOSE VALUES TO A STRING
                foreach (char c in s1)
                {
                    num1 = num1 + dict[c];
                }
                foreach (char c in s2)
                {
                    num2 = num2 + dict[c];
                }
                foreach (char c in s3)
                {
                    num3 = num3 + dict[c];

                }
                // CONVERTING THE NUMBER VALUE STRINGS OF APLHABETS TO INTEGERS AND ADDING THEM
                int result = int.Parse(num1) + int.Parse(num2);
                // CHECK IF THE SUM OF TWO INPUT STRINGS EQUALS TO THE OUPUT STRING FOR THE ASSIGNED VALUES  OR NOT
                // IF YES PRINT THE ASSIGNED VALUES
                if (result == int.Parse(num3))
                {
                    foreach (KeyValuePair<char, int> Kv in dict)
                    {
                        Console.WriteLine("{0}={1}", Kv.Key, Kv.Value);
                    }
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }
    }
}

