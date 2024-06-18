using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        List<RoundShape> shapeList = new List<RoundShape>();
        shapeList.Add(new Circle(1));
        shapeList.Add(new Cylinder(1, 2));
        shapeList.Add(new Sphere(1));

        foreach (RoundShape Shape in shapeList)
        {
            Console.WriteLine(Shape.Area());
        }
    }
}