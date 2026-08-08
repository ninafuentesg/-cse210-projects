using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual shapes
        Square square = new Square("Red", 5);

        Console.WriteLine("Testing Square:");
        Console.WriteLine($"Color: {square.GetColor()}");
        Console.WriteLine($"Area: {square.GetArea()}");

        Console.WriteLine();

        Rectangle rectangle = new Rectangle("Blue", 6, 4);

        Console.WriteLine("Testing Rectangle:");
        Console.WriteLine($"Color: {rectangle.GetColor()}");
        Console.WriteLine($"Area: {rectangle.GetArea()}");

        Console.WriteLine();

        Circle circle = new Circle("Green", 3);

        Console.WriteLine("Testing Circle:");
        Console.WriteLine($"Color: {circle.GetColor()}");
        Console.WriteLine($"Area: {circle.GetArea()}");

        Console.WriteLine();

        // Polymorphism
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Yellow", 4));
        shapes.Add(new Rectangle("Purple", 5, 3));
        shapes.Add(new Circle("Orange", 2));

        Console.WriteLine("--- Polymorphism Demonstration ---");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(
                $"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}"
            );
        }
    }
}