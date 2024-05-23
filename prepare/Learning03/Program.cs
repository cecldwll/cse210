using System;

class Program
{
    static void Main(string[] args)
    {
        // Testing constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(6, 7);

        // Testing getters and setters
        Console.WriteLine(fraction1.GetNumerator() + "/" + fraction1.GetDenominator()); // 1/1
        fraction1.SetNumerator(2);
        fraction1.SetDenominator(3);
        Console.WriteLine(fraction1.GetNumerator() + "/" + fraction1.GetDenominator()); // 2/3

        // Testing GetFractionString method
        Console.WriteLine(fraction1.GetFractionString()); // 2/3

        // Testing GetDecimalValue method
        Console.WriteLine(fraction1.GetDecimalValue()); // 0.6666666666666666

        // Creating and displaying a few different fractions
        Fraction fraction4 = new Fraction(3, 4);
        Fraction fraction5 = new Fraction(1, 3);

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Console.WriteLine(fraction5.GetFractionString());
        Console.WriteLine(fraction5.GetDecimalValue());
    }
}
