//int _TotalPoints = 0;
//string _name = "";
// DateTime date = 

class Goal{
    private static List<Goal> _goals = [];

    private int _TotalPoints;
    private string _name;
    private DateTime _date;
    private int _points;
    private bool _completed;
     private string _type;
    
    

    public Goal(string name,bool completed,DateTime date, string type){
        _name = name;
        _date = date;
        _type = type;
        _completed = completed;
        _goals.Add(this);
    }

    public virtual int GetPoints()
    {
        return _TotalPoints;
    }

    public new string GetType()
    {
        return _type;
    }
    public string GetName()
    {
        return _name;
    }

    public static void Display()
    {
        foreach(Goal goal in _goals)
        {
            string completionDialog;
            if(goal._completed == true){completionDialog = "X";}
            else{completionDialog = " ";}
            Console.WriteLine($"Goal Type: {goal._type}\nPoints awarded: {goal._points}\nStarted on: {goal._date}\nCompleted: [{completionDialog}]\n");
        }
        Console.Write("Press any key to go back...");
        Console.ReadKey();
    }
    public static int DisplayExisting()
    {
        for(int i = 0 ; i < _goals.Count() ; i++){
            if(_goals[i]._completed == false){Console.WriteLine($"{i+1}\nName: {_goals[i]._name}\nType: {_goals[i]._type}\n");}
        }
        return _goals.Count();
    }
    public static Goal FindGoal(int index)
    {
        try{
            Goal goal = _goals[index-1];
            return goal;
        }catch(ArgumentOutOfRangeException){
            return null;
        }
        
    }
    public virtual void CloseGoal()
    {
        UpdateTotal(_TotalPoints);_goals.Remove(this);
    }

    protected void CompleteGoal(string name, int points)
    {
        for(int i=0;i<_goals.Count();i++){
            if(_goals[i]._name == name){
                int index = i;
                _goals[index]._completed = true;
                _goals[index]._points = points;
                break;
            }
        }
    }
    // Update
    protected void UpdatePoints(string name,int points)
    {
        for(int i = 0 ; i < _goals.Count() ; i++)
        {
            if(_goals[i]._name == name){
                int index = i;
                _goals[index]._points = points;
                break;
            }
        }
    }
    protected void UpdateTotal(int points)
    {
        _TotalPoints += points;
    }
    protected void RemoveGoal()
    {
        _goals.Remove(this);
    }

    // Write file
    public static void Write()
    {
        string _filename = "my_goals.txt";
        using StreamWriter streamWrite = new(_filename,false);
        int completeStatus;

        foreach(SimpleGoal simple in SimpleGoal.ExportGoals())
        {
            if(simple.GetComplete() == true)
            {
                completeStatus = 1;
            }
            else
            {
                completeStatus = 0;
            }
            streamWrite.WriteLine($"{"Simple"};{simple._name};{completeStatus};{simple._date};{simple.GetReward()}");

            if(simple._completed == true) {}
        }
        foreach(EternalGoal eternal in EternalGoal.ExportGoals())
        {
            if(eternal.GetComplete() == true)
            {
                completeStatus = 1;
            }
            else
            {
                completeStatus = 0;
            }
            streamWrite.WriteLine($"{"Eternal"};{eternal._name};{completeStatus};{eternal._date};{eternal.GetFactor()};{eternal.GetRunningTotal()}");
        }
        foreach(CheckListGoal checkList in CheckListGoal.ExportGoals())
        {
            if(checkList.GetComplete() == true)
            {
                completeStatus = 1;
                }
            else
            {
                completeStatus = 0;
            }
            streamWrite.WriteLine($"{"CheckList"};{checkList._name};{completeStatus};{checkList._date};{checkList.GetFactor()};{checkList.GetReps()};{checkList.GetReward()};{checkList.GetRunningTotal()}");
        }
    }
    

    // Read file
    public static void Read()
    {
        string _filename = "my_goals.txt";
        if(File.Exists(_filename))
        {
            using StreamReader sr = new StreamReader(_filename);
            string line;
            List<string> names = [];
            while ((line = sr.ReadLine()) != null)
            {
                // Anything not null
                bool exists = false;
                bool complete = false;
                string[] lineElement = line.Split(";");
                if (Convert.ToInt32(lineElement[2]) == 1) 
                { 
                    complete = true; 
                }
                else 
                {
                    complete = false; 
                }

                DateTime date = DateTime.Parse(lineElement[3]);
                foreach(string name in names)
                    {
                        if(lineElement[1].ToLower() == name.ToLower())
                        {
                            exists=true;
                        }
                    }

                names.Add(lineElement[1]);
                
                if(exists == false)
                {
                    switch(lineElement[0]){
                        case "Eternal":
                            EternalGoal eternal = new(lineElement[1], complete, date, Convert.ToInt32(lineElement[4]));
                            eternal._points = Convert.ToInt32(lineElement[5]);
                            eternal.SetRunning(Convert.ToInt32(lineElement[5]));
                            break;
                        case "Simple":
                            SimpleGoal simple = new(lineElement[1], complete, date, Convert.ToInt32(lineElement[4]));
                            if(complete == true){simple._points = Convert.ToInt32(lineElement[4]);}
                            break;
                        case "CheckList":
                            CheckListGoal checkList = new(lineElement[1], complete, date, Convert.ToInt32(lineElement[4]), Convert.ToInt32(lineElement[5]), Convert.ToInt32(lineElement[6]));
                            checkList._points = Convert.ToInt32(lineElement[7]);
                            checkList.SetRunning(Convert.ToInt32(lineElement[7]));
                            break;
                    }
                }     
            }  // If can't find file
        }else{ Console.WriteLine("Error. File not found")  ;  Thread.Sleep(2000)  ; }
    }
}