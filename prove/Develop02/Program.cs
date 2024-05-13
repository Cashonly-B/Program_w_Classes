using System;
using System.Collections.Generic;
using System.IO;
 
class Entry
{
    public string Prompt {get; set;}
    public string Response {get; set;}
    public DateTime Date {get; set;}
 
    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }
 
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
 
class JournalApp
{
    private List<Entry> journal = new List<Entry>();
    private List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
 
    public void displayMenu()
    {
        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
 
            Console.Write("Enter an option: ");
            string userChoice = Console.ReadLine();
 
            switch (userChoice)
            {
                case "1":
                    write();
                    break;
                case "2":
                    display();
                    break;
                case "3":
                    save();
                    break;
                case "4":
                    load();
                    break;
                case "5":
                    Console.WriteLine("Quiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
 
    private void write()
    {
        // Choose a random prompt from the list
        // random_Prompt
        Random randomPrompt = new Random();
        string prompt = prompts[randomPrompt.Next(prompts.Count)];

        // Print the line and record response
        // get_entry
        Console.WriteLine($"\n{prompt}");
        Console.Write("Your entry: ");
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response);

        // Add user's entry to the journal
        // write_to_file
        journal.Add(newEntry);
        Console.WriteLine("Entry added successfully.");
    }
 
    private void display()
    {
        // Displays all journal entries
        // load_file
        Console.WriteLine("\n====================\nJournal Entries\n");
        foreach (var entry in journal)
        {
            // display_file
            Console.WriteLine(entry);
            Console.WriteLine("====================");
        }
    }
 
    private void save()
    {
        // User types a file name and programs records the name
        // get_filename
        Console.Write("Enter a filename to save (with .txt extension): ");
        string filename = Console.ReadLine();
 
        // Program saves the file
        // load_file & write_file
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in journal)
                {
                    writer.WriteLine($"{entry.Date};{entry.Prompt};{entry.Response}");
                }
            }
 
            Console.WriteLine("Journal saved successfully.");
        }
        // Program displays error if failed to save
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }
 
    private void load()
    {
        // User types filename and program records response
        Console.Write("Enter a filename to load (with .txt extension): ");
        string filename = Console.ReadLine();
 
        // Program loads the file from the filename
        // get_filename
        try
        {
            journal.Clear();
 
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    DateTime date = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string response = parts[2];
                    Entry entry = new Entry(prompt, response);
                    entry.Date = date;
                    journal.Add(entry);
                }
            }
 
            Console.WriteLine("Journal loaded successfully.");
        }
        // Program displays error if failed to load
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}
 
 // Runs the program when ran
 class Program
{
    static void Main(string[] args)
    {
        JournalApp app = new JournalApp();
        app.displayMenu();
    }
}