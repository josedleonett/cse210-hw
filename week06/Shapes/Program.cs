using System;

class Program
{
    static void Main(string[] args)
    {
        Shape square = new Square("Red", 5);
        Shape rectangle = new Rectangle("Blue", 7, 6);
        Shape circle = new Circle("Green", 3);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}