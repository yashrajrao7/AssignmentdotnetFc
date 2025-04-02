using System;

namespace Assignment_2
{
   
    interface ICalculator
    {
        double Sum(double a, double b);
        double Sum(double a, double b, double c);
        double Subtract(double a, double b);
        double Subtract(double a, double b, double c);
        double Multiply(double a, double b);
        double Divide(double a, double b);
        double Percentage(double total, double obtained);
    }

   
    class Calculator : ICalculator
    {
        public double Sum(double a, double b) => a + b;
        public double Sum(double a, double b, double c) => a + b + c;
        public double Subtract(double a, double b) => a - b;
        public double Subtract(double a, double b, double c) => a - b - c;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero");
        public double Percentage(double total, double obtained) => total != 0 ? (obtained / total) * 100 : throw new ArgumentException("Total cannot be zero");
    }

    class Program
    {
        static void DisplayMenu()
        {
            Console.WriteLine("\nSelect an Operation:");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - Division");
            Console.WriteLine("5 - Percentage");
            Console.WriteLine("6 - Exit");
        }

        static double GetValidNumber(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void Main()
        {
            Calculator calc = new Calculator();

            // First, get the numbers
            double num1 = GetValidNumber("Enter First Number: ");
            double num2 = GetValidNumber("Enter Second Number: ");

            double num3 = 0;
            Console.Write("Do you want to enter a third number? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                num3 = GetValidNumber("Enter Third Number: ");
            }

            while (true)
            {
                DisplayMenu();

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 6)
                {
                    if (choice == 6) break; // Exit the loop

                    switch (choice)
                    {
                        case 1: // Addition
                            Console.WriteLine(num3 != 0 ? $"Sum: {calc.Sum(num1, num2, num3)}" : $"Sum: {calc.Sum(num1, num2)}");
                            break;

                        case 2: // Subtraction
                            Console.WriteLine(num3 != 0 ? $"Subtraction: {calc.Subtract(num1, num2, num3)}" : $"Subtraction: {calc.Subtract(num1, num2)}");
                            break;

                        case 3: // Multiplication
                            Console.WriteLine($"Multiplication: {calc.Multiply(num1, num2)}");
                            break;

                        case 4: // Division
                            try
                            {
                                Console.WriteLine($"Division: {calc.Divide(num1, num2)}");
                            }
                            catch (DivideByZeroException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 5: // Percentage
                            try
                            {
                                Console.WriteLine($"Percentage: {calc.Percentage(num1, num2)}%");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");
                }
            }

            Console.WriteLine("Exiting program. Thank you!");
        }
    }
}
