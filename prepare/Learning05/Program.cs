using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        // Create instances of different shapes
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 3, 6));
        shapes.Add(new Circle("Green", 5));

        // Iterate through the list and display the color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}, Area: {shape.GetArea():F2}");
        }
    }
}
