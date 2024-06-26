using System;
using System.ComponentModel;
using System.Security.Cryptography;

class Program
{
    static int ShowMenu(bool userStart)
    {
        if(userStart == true)
        {
            Console.WriteLine("Welcome to the Goal Setter!\nPlease choose an option below:\n");
        }
        else
        {
            Console.WriteLine("Choose an option to do:\n");
        }
        
        Console.WriteLine("1. Work on an existing goal");
        Console.WriteLine("2. Create a new goal");
        Console.WriteLine("3. Display all goals");
        Console.WriteLine("4. End Program");

        Console.Write("\nPlease choose an option: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());

        if((userChoice % 1) != 0 || userChoice > 4 || userChoice < 1)
        {
            Console.WriteLine("Invalid Option. Select a number 1-4.\n");
            ShowMenu(userStart);
        }
        return userChoice;
    }

    static Goal ChooseExisting(){
        int length = Goal.DisplayExisting();
        if(length ==0)
        {
            return null;
        }
        Console.Write("Please select a goal number: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        
        // Invalid
        if(userChoice > length)
        {
            Console.WriteLine("Invalid goal selection");
            ChooseExisting();
        }
        Goal existing = Goal.FindGoal(userChoice);

        return existing;
    }

    static void ExistingMenu(string name){
        SimpleGoal simple = SimpleGoal.FindSimpleGoal(name,true);
        EternalGoal eternal = EternalGoal.FindEternalGoal(name,true);
        CheckListGoal checkList = CheckListGoal.FindCheckListGoal(name,true);
        string type = "";

        if(eternal != null)
        {
            type = "Eternal";
        }
        else if(simple != null)
        {
            type = "Simple";
        }
        else if(checkList != null)
        {
            type = "CheckList";
        
        }

        Console.WriteLine($"type: {type}");
        Thread.Sleep(500);
        Console.WriteLine("Choose a number of the selected action:\n");
        int userChoice;

        switch(type){
        // Eternal
            case "Eternal":
                Console.WriteLine("1. Add an occurance");
                Console.WriteLine("2. Complete Goal");
                userChoice = Convert.ToInt32(Console.ReadLine());
                if(userChoice == 1)
                {
                    eternal.CompleteOnce();
                    Console.WriteLine("Occurance added");
                }
                if(userChoice == 2)
                {
                    eternal.CloseGoal();
                    Console.WriteLine("Goal Closed");
                }
                break;
        // Simple
            case "Simple":
                Console.WriteLine("1. Complete Goal");
                userChoice = Convert.ToInt32(Console.ReadLine());
                if(userChoice == 1)
                {
                    Console.WriteLine("Goal closed");
                    simple.CloseGoal();
                }
                break;
        // Checklist
            case "CheckList":
                Console.WriteLine("1. Add an occurance");
                Console.WriteLine("2. Check the number of completions remaining");
                userChoice = Convert.ToInt32(Console.ReadLine());
                if(userChoice == 1)
                {
                    int reps = checkList.CompleteOnce();
                    Console.WriteLine($"Occurance added. You have {reps} completions remaining.");
                }
                if(userChoice == 2)
                {
                    int reps = checkList.GetReps();
                    Console.WriteLine($"You have {reps} completions remaining.");
                }
                break;
            default:
                Console.WriteLine("Goal not found. Oops");
                Thread.Sleep(1000);
                break;
        }
    }


    static void NewGoal(){
        Console.WriteLine("Goal Options:\n");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        Console.Write("Please enter goal type number: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());

        switch(userChoice){
            case 1:
                SimpleGoal simple = SimpleGoal.CreateSimpleGoal();
                break;
            case 2:
                EternalGoal eternal = EternalGoal.CreateEternalGoal();
                break;
            case 3:
                CheckListGoal checkList = CheckListGoal.CreateCheckListGoal();
                break;
            default:
                Console.WriteLine($"Type a valid number. {userChoice} is not a vaild number.");
                Thread.Sleep(1000);
                break;
        }
    }

    // SAVE
    static void SaveGoals(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Saving to file...");
        Thread.Sleep(500);
        Goal.Write();
        Console.Write(" Saved successfully\nGoodbye!");
    }

    // LOAD
    static void LoadGoals(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write("Loading from file...");
        Thread.Sleep(500);
        Goal.Read();
        Console.Write("Successfully Loaded\nLoading Menu...");
    }

    static void Main(string[] args)
    {
        LoadGoals();
        bool quit = false;
        bool userStart = true;
        do{
            Console.Clear();
            Console.SetCursorPosition(0,0);
            int userChoice = ShowMenu(userStart);
            switch(userChoice)
            {
                case 1:
                    try
                    {
                        Goal existing = ChooseExisting();
                        ExistingMenu(existing.GetName());
                    }catch(System.NullReferenceException){
                        Console.Clear();
                        Console.SetCursorPosition(0,0);
                        Console.WriteLine("No existing goals. Try again");
                        Thread.Sleep(1000);
                    }      
                    break;
                case 2:
                    NewGoal();
                    break;
                case 3:
                    Goal.Display();
                    break;
                case 4:
                    SaveGoals();
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Option not found. Try again.");
                    Thread.Sleep(1000);
                    break;
            }
            userStart = false;
        }while(quit == false);
    }
}