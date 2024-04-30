using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string user_name = PromptUserName();
        int user_number = PromptUserNumber();
        int square = SquareNumber(user_number);
        DisplayResult(user_name, square);
    }

    static void DisplayWelcome() // Diplays welcome message
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName() // Asks for and returns user name (as a string)
    {
        Console.Write("Please enter your name: ");
        string user_name = Console.ReadLine();
        return user_name;
    }
      
    static int PromptUserNumber() // Asks for and returns user number (as an int)
    {
        Console.Write("Please enter your favorite number: ");
        int user_number = int.Parse(Console.ReadLine());
        return user_number;
    }

    static int SquareNumber(int number) // Returns the square of the user number
    {
        int square = number * number; 
        return square;
    }

    static void DisplayResult(string user_name, int square) // Displays result
    {
        Console.WriteLine($"{user_name}, the square of your number is {square}");
    }
}