using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning02 World!");

        // Person
        Person person = new Person();
        person._firstName = "Fred";
        person._lastName = "Figglehorn";
        person.ShowWesternName();
        person.ShowEasternName();

        //int height = 20;
        //string color = "red";

        // Kitchen
        Blind kitchen = new Blind();
        kitchen._width = 30;
        kitchen._height = 15;
        kitchen._color = "red";
        double materialAmount = kitchen.GetArea();

        Console.WriteLine(kitchen._width);
        Console.WriteLine(kitchen._height);
        Console.WriteLine(kitchen._color);
        Console.WriteLine(kitchen.GetArea());
    }

    public class Person 
    {
        public string _firstName = "";
        public string _lastName = "";

        public Person()
        {

        }

        public void ShowEasternName()
        {
            Console.WriteLine($"{_lastName}, {_firstName}");
        }

        public void ShowWesternName()
        {
            Console.WriteLine($"{_firstName} {_lastName}");
        }
        
    }

    public class Blind
    {
        public double _width;
        public double _height;
        public string _color;

        public double GetArea()
        {
            return _width * _height;
        }
    }
}