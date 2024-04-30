using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = [];
        int number = -1;
        
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        
        // Sum
        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }
        Console.WriteLine($"Sum: {sum}");
        
        // Average
        float average = ((float) sum) / numbers.Count;
        Console.WriteLine($"Average: {average}");

        // High
        int high = numbers[0];
        foreach (int item in numbers)
        {
            if (item > high)
            {
                high = item;
            }
        }
        Console.WriteLine($"The largest number is: {high}");
    }
}