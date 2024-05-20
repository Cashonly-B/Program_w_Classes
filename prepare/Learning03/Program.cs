using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        Person p = new Person();
        p.SetFirstName("John");
        p.SetLastName("Smith");
        p.SetTitle("Walmart");
        Console.WriteLine($"\nHello {p.GetFirstName()} {p.GetLastName()} from {p.GetTitle()}!\n");

    }
}
public class Person 
{
    private string _firstName;
    private string _lastName;
    private string _title;

    public string GetFirstName() { return _firstName; }
    public string GetLastName() { return _lastName; }
    public string GetTitle() { return _title; }


    public void SetFirstName(string firstName) { _firstName = firstName; }
    public void SetLastName(string lastName) { _lastName = lastName; }
    public void SetTitle(string title) { _title = title; }     
}