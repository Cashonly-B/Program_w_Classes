using System;
using System.Collections.Generic;
using System.IO;
 
class Entry(string prompt, string response)
{
    public string _prompt { get; set; } = prompt;
    public string _response { get; set; } = response;
    public DateTime _date { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }
}
 
class JournalApp
{
    private List<Entry> journal = [];
    private List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    private string feelingResponse;

    public void DisplayMenu()
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
                    Write();
                    break;
                case "2":
                    Display();
                    break;
                case "3":
                    Save();
                    break;
                case "4":
                    Load();
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
 
    private void Write()
    {
        // Choose a random prompt from the list
        // random_Prompt
        Random randomPrompt = new();
        string prompt = prompts[randomPrompt.Next(prompts.Count)];

        // Print the line and record response
        // get_entry
        Console.WriteLine($"\n{prompt}");
        Console.Write("Your entry: ");
        string response = Console.ReadLine();
        Entry newEntry = new(prompt, response);

        // Extra 7% 
        Console.Write("How are you feeling today?: ");
        feelingResponse = Console.ReadLine();

        // Add user's entry to the journal
        // write_to_file
        journal.Add(newEntry);
        Console.WriteLine("Entry added successfully.");
    }
 
    private void Display()
    {
        // Displays all journal entries
        // load_file
        Console.WriteLine("\n====================\nJournal Entries\n");
        foreach (var entry in journal)
        {
            // display_file
            Console.Write(entry);
            Console.WriteLine($"Feeling: {feelingResponse}");
            Console.WriteLine("\n====================");
        }
    }
 
    private void Save()
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
                    writer.WriteLine($"{entry._date};{entry._prompt};{entry._response}");
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
 
    private void Load()
    {
        // User types filename and program records response
        Console.Write("Enter a filename to load (with .txt extension): ");
        string filename = Console.ReadLine();
 
        // Program loads the file from the filename
        // get_filename
        try
        {
            // Clears the journal 
            journal.Clear();
 
            using (StreamReader reader = new StreamReader(filename))
            {
                // Reads the file and loads it into vs code ready to display
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    DateTime date = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string response = parts[2];
                    Entry entry = new(prompt, response)
                    {
                        _date = date
                    };
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
        JournalApp app = new();
        app.DisplayMenu();
    }
}