class Listing : Activity
{
    private int _length;
    private List<string> _repsonses = [""];
    private static string _self = "Listing";

    public Listing(int length, string datetime, string entryName) : base(datetime,entryName,"Listing",length)
    {
        _length = length;
    }

    public void StartListing()
    {
        float activityLength = _length;
        string prompt;
        int left,top;
        string userResponse = "";

        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        

        Prompt list0 = new();
        list0.SetLists();
        prompt = list0.GetQuestion(_self);
        
        Console.WriteLine($"{prompt}");
        Loading(3);

        (left,top) = Console.GetCursorPosition();


        while(activityLength > 0)
        {
            if(Console.KeyAvailable)
            {
                Console.SetCursorPosition(left, top);
                Console.Write("Enter Here: ");
                userResponse = Console.ReadLine(); 
            }

            Console.SetCursorPosition(left,top);
            Console.Write($"\n{activityLength}");

            if(activityLength > 0)
            {
                Thread.Sleep(500);
                activityLength -= 1;
            } else if(activityLength <= 0)
              {
                break;
              }
        }
        Console.WriteLine($"\nRecored your responses");
    }
}