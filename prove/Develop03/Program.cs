using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture reference = new();
        string firstTimothy4 = "For bodily exercise profiteth little: but godliness is profitable unto all things, having promise of the life that now is, and of that which is to come.";
        reference.SetPhrase("script",firstTimothy4);

        reference.Display();
        while(reference.GetLength() > 0){
            Console.ReadKey();
            reference.Advance();
            reference.Display();
        }
    }
}