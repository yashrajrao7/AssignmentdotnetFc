using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)

        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Type Conversion");
                Console.WriteLine("2. String Operations");
                Console.WriteLine("3. File Handling");
                Console.WriteLine("4. Quit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }


                if (choice == 1)
                {
                    TypeConversion();
                }
                else if (choice == 2)
                {
                    StringOperations();
                }
                else if (choice == 3)
                {
                    FileHandling();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please enter a valid option.");
                }
            }
        }

        static void TypeConversion()
        {
            Console.Write("Enter a value to typecast: ");
            string input = Console.ReadLine();

            try
            {
                int intValue = Convert.ToInt32(input);
                Console.WriteLine($"Integer value: {intValue}");
                return;
            }
            catch { }

            try
            {
                double doubleValue = Convert.ToDouble(input);
                Console.WriteLine($"Double value: {doubleValue}");
                return;
            }
            catch { }

            try
            {
                decimal decimalValue = Convert.ToDecimal(input);
                Console.WriteLine($"Decimal value: {decimalValue}");
                return;
            }
            catch { }

            try
            {
                bool boolValue = Convert.ToBoolean(input);
                if (boolValue)
                    Console.WriteLine("Boolean value: True");
                else
                    Console.WriteLine("Boolean value: False");
                return;
            }
            catch { }

            try
            {
                DateTime dateValue = Convert.ToDateTime(input);
                Console.WriteLine($"DateTime value: {dateValue}");
                return;
            }
            catch { }

            Console.WriteLine("Could not determine the type of input.");
        }

        static void StringOperations()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            Console.WriteLine("Uppercase: " + input.ToUpper());
            Console.WriteLine("Lowercase: " + input.ToLower());
            Console.WriteLine("Reversed: " + ReverseString(input));

            int countL = 0;
            string formatted = "*";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'l' || input[i] == 'L')
                    countL++;

                formatted += input[i];

                if (i < input.Length - 1)
                    formatted += "*";
            }

            Console.WriteLine("Formatted Output: " + formatted);
            Console.WriteLine($"'l' appears {countL} times");
        }



        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void FileHandling()
        {
            string filePath = "sample.txt";

            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Append text to file");
            Console.WriteLine("2. Read file contents");
            Console.Write("Enter your choice: ");

            int fileChoice;
            if (!int.TryParse(Console.ReadLine(), out fileChoice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                return;
            }

            if (fileChoice == 1)
            {
                Console.Write("Enter text to append to the file: ");
                string input = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(input);
                }

                Console.WriteLine("Text appended to file successfully.");
            }
            else if (fileChoice == 2)
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine("\nFile Contents:");
                    string fileData = File.ReadAllText(filePath);
                    Console.WriteLine(fileData);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }

    }
}
