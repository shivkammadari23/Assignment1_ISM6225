using System;
using System.Collections.Generic;
using System.Linq;



namespace Assignment1_Spring2021
{
    class Program
    {
      
       
            public static void Main()
            {
                // Question 1
                Console.WriteLine("Q1:\n Enter number of rows for triangle:");
                int n = Convert.ToInt32(Console.ReadLine());                            // Reads the input value for number of rows to be printed
                Console.WriteLine();
                PrintTriangle(n);                                                       // Calls the function to execute the triangle
                Console.WriteLine("\n" + "* Triangle Printed" + "\n");

                //Question 2:
                Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
                int n2 = Convert.ToInt32(Console.ReadLine());                                 // Reads the value for number of values to be printed in pell series
                printPellSeries(n2);                                                          // Function to execute the program
                Console.WriteLine();
                Console.WriteLine("\n" + "These are the Pell Numbers" + "\n");

                // Question 3
                Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
                int n3 = Convert.ToInt32(Console.ReadLine());                                             // Reads the value for number to be checked for sum of squares
                bool flag = squareSums(n3);                                                               // Using boolean type to check for sum of squares based on the input received
                if (flag)                                                                                 // Conditional statement which prints output text based on the boolean value returned
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }

                //Question 4:
                int[] arr = { 3, 1, 4, 1, 5 };
                Console.WriteLine("Q4: Enter the absolute difference to check");
                int k = Convert.ToInt32(Console.ReadLine());                                      //Reads input for difference between pairs to be checked
                int n4 = diffPairs(arr, k);                                                       //Calling a function to check for the pairs that satisfy the given difference
                Console.WriteLine("There exists {0} pairs with the given difference", n4);

                // Question 5
                List<string> emails = new List<string>();
                emails.Add("dis.email + bull@usf.com");                             //Input for the emails to be checked 
                emails.Add("dis.e.mail+bob.cathy@usf.com");
                emails.Add("disemail+david@us.f.com");
                int ans5 = UniqueEmails(emails);                                    //Function to check for number of unique emails in the given list
                Console.WriteLine("Q5");
                Console.WriteLine("The number of unique emails is " + ans5);

                // Question 6
                string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };  // Input path to be checked for the destination city
                string destination = DestCity(paths);                                                                          // Function called to check for the destination city
                Console.WriteLine("Q6:\nFinding the destination city:\n");

                Console.WriteLine("Destination city is " + destination);



            }

        //Question 1

        private static void PrintTriangle(int n)                //Opening statement to define access type
        {
            try
            {
                // write your code here
                Console.WriteLine("Q1 : Enter the number of rows for the triangle:");
                int u, v, num = 1;                              //Initial variable declaration
                num = n - 1;
                for (v = 1; v <= n; v++)
                {
                    //Printing region
                    for (u = 1; u <= num; u++)              //For Loop to create printing space and triangle pattern
                        Console.Write(" ");
                    num--;
                    //End Region
                    for (u = 1; u <= 2 * v - 1; u++)        //For Loop to print "*" 
                        Console.Write("*");
                    Console.WriteLine();                    //Go to next line and start a new row
                }
            }
            catch (Exception)
            {

                throw;
            }

        }// -------------------------------------------------------------------------------------------------------//


             
                    //Question 2:
                  

                private static int printPellSeries(int n2)               //Opening statement to define access type
                {
                    try
                    {
                        // write your code here
                        if (n2 < 2)                                  //Conditional statement. If variable n2 is less than 2 then n2 will be returned to the user
                            return n2;
                        int x = 0;
                        int y = 1;                                   //First two values in the Pell series
                        Console.Write(x + " ");
                        Console.Write(" " + y);                      //Printing the first two values of the series
                        int z;                                       // Variable for third value in the series
                        for (int i = 3; i <= n2; i++)                // For loop is initiated here in which a counter is set starting at value 3 and increases by 1 for the next value in the counter
                        {
                            z = 2 * y + x;                           //Formula for "zth" term in the Pell series
                            x = y;                                   //The next two values in the Pell series become reassigned to x and y
                            y = z;
                            Console.Write(" " + y);
                        }
                        return y;
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                }

               // -------------------------------------------------------------------------------------------------------//

                    // Question 3
                   

                private static bool squareSums(int A)                    //Opening statement to define access type
                {
                    try
                    {
                        // write your code here\
                        int u, v;                                    //Initiating variables
                        for (u = 0; u * u <= A; u++)                //For Loop starts checking from 0 until it is reaches a value less than or equal to vaiable n3
                            for (v = 0; v * v <= A; v++)
                                if (u * u + v * v == A)             //Conditional statement to check whether the value input by user is a sum of squares or not
                                {
                                    return true;
                                }
                        return false;

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                //---------------------------------------------------------------------------------------------------------//
                    //Question 4:


                private static int diffPairs(int[] nums, int k)           //Intitial statement to define access type and integer variables
                {
                    try
                    {
                        // write your code here.
                        if (k < 0)                                     //Conditional statement which returns 0 if difference k is less than zero
                            return 0;

                        int final = 0;
                        System.Collections.Hashtable hash = new System.Collections.Hashtable();          //Initiating a hash table called "hash" which stores unique values

                        foreach (var item in nums)                      //Foreach statement allows us to traverse through each item in the table
                            if (!hash.ContainsKey(item))
                                hash.Add(item, 1);
                            else
                                hash[item] = (int)hash[item] + 1;       //Existing pairs are updated in the hash table

                        foreach (var item in hash.Keys)                 //Incremental counter to check every pair such that their difference k is 0
                            if (k == 0)
                            {
                                if ((int)hash[item] > 1)
                                    final++;
                            }
                            else if (hash.ContainsKey((int)item + k))     //Incremental counter to check every pair such that their difference k is greater than 0
                                final++;

                        return final;
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("An error occured: " + e.Message);
                        throw;
                    }

                }

                //-----------------------------------------------------------------------------------------------------------//
                    // Question 5

                /// <summary>
                /// Static method to determine the unique email values for the respective email group
                /// </summary>
                private static int UniqueEmails(List<string> emails)
                {
                    try
                    {
                        List<string> Unique_Emails = new List<string>();

                foreach (string email in emails)                                                // Using foreach to check each email in the list
                {
                    string givenEmail = "";

                    foreach (char c in email)
                    {
                        if (c == '@' || c == '+')                                               // conditional statement which causes everything after + and @ characters to be skipped
                        {
                            break;
                        }
                        if (c == '.')                                                          // conditional statement to ignore "." characters
                        {
                            continue;
                        }
                        givenEmail += c;                                                      
                    }


                    int atIndex = email.IndexOf('@');                                         // combines the domain name part with "@" character
                    givenEmail = givenEmail.Trim();
                    givenEmail += email.Substring(atIndex);
                    
                    if (!Unique_Emails.Contains(givenEmail))                           // Ignores emails added earlier
                    {
                        Unique_Emails.Add(givenEmail);
                    }
                }
                return Unique_Emails.Count;
            }
                    catch (Exception e)
                    {
                        Console.WriteLine("User needs to enter a valid input " + e.Message);
                        throw;
                    }

                }

                //-------------------------------------------------------------------------------------------------------//
                    // Question 6

                private static string DestCity(string[,] paths)                 //Intitial statement to define access type and variable "paths" which the all possible continuous paths
                {
                    try
                    {
                for (int v = 0; v < paths.GetLength(0); v++)
                {
                    int b = 0;
                    for (int u = 0; u < paths.GetLength(0); u++)
                    {
                        if (paths[u, 0] == paths[v, 1])                             // Conditional statements checks for starting and ending point cities in the path and removes them when they are both the same city
                        {
                            b = 1;
                            break;

                        }
                    }
                    if (b == 0)
                    {
                        return paths[v, 1];                                       // Returns the destination city to the user

                    }
                }
                return "";

            }
            catch (Exception)
                    {

                        throw;
                    }

                }

            


    }


}  


