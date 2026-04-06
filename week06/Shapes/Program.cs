using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 3, 5);
        Circle circle = new Circle("Green", 2.5);

        Console.WriteLine($"{square.GetColor()} square area: {square.GetArea():F2}");
        Console.WriteLine($"{rectangle.GetColor()} rectangle area: {rectangle.GetArea():F2}");
        Console.WriteLine($"{circle.GetColor()} circle area: {circle.GetArea():F2}");

        List<Shape> shapes = new List<Shape>
        {
            square,
            rectangle,
            circle,
            new Square("Yellow", 6),
            new Rectangle("Purple", 2, 7),
            new Circle("Orange", 1.5)
        };

        Console.WriteLine();
        Console.WriteLine("Areas from the shape list:");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} shape area: {shape.GetArea():F2}");
        }
    }
}
