using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the Assignment base class
        // Create an Assignment object and print its summary
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        // Test the MathAssignment class
        // Create a MathAssignment object with specific details and print its summary and homework list
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Test the WritingAssignment class
        // Create a WritingAssignment object with specific details and print its summary and writing information
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
