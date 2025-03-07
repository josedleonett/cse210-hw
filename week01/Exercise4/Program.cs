using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        } while (true);

        int numbersSum = 0;
        foreach (int number in numbers)
        {
            numbersSum += number;
        }
        Console.WriteLine($"The sum is: {numbersSum}");

        if (numbers.Count > 0)
        {
            double average = (double)numbersSum / numbers.Count;
            Console.WriteLine($"The average is: {average}");
        }

        Console.WriteLine($"The largest number is: {numbers.Max()}");

        Console.WriteLine($"The smallest positive number is: {numbers.Where(n => n > 0).Min()}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}