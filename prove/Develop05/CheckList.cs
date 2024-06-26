class CheckListGoal : Goal{
    private static List<CheckListGoal> _checkListGoals = [];
    private string _name;
    private bool _completed = false;
    private int _total = 0;
    private int _reps;
    private int _points;
    private int _reward;
    private static string _self = "CheckList";

    public CheckListGoal(string name, bool completed, DateTime date, int points, int reps, int reward)
    : base(name, completed, date,_self)
    {
        _name = name;
        _completed = completed;
        _reps = reps;
        _points = points;
        _reward = reward;
        _checkListGoals.Add(this);
    }
    
    // Completed
    public int CompleteOnce(){
        _total += _points;
        _reps -=1;
        UpdatePoints(_name,_total);
        return _reps;
    }

    public static CheckListGoal CreateCheckListGoal(){
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Put the reward that should be rewarded every time this goal is completed (number): ");
        int points = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the number of times this goal needs to be completed: ");
        int reps = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter a final reward (default is your reward number multiplied by 50): ");
        string rewardRaw = Console.ReadLine();

        int reward;
        if(rewardRaw != "" && rewardRaw != null)
        {
            reward = Convert.ToInt32(rewardRaw);
        }
        else
        {
            reward = points * 50;
        }

        CheckListGoal checkList = new(name, false, DateTime.Now, points, reps, reward); 
        return checkList;
    }

    public static CheckListGoal FindCheckListGoal(string name = "", bool mute = false){
        foreach(CheckListGoal checkList in _checkListGoals)
        {
            if(checkList.GetName() == name)
            {
                return checkList;
            }
        }
        if(mute == false)
        {
            Console.WriteLine($"No goal found under the name {name}");
        }
        return null;
    }
    public static List<CheckListGoal> ExportGoals()
    {
        return _checkListGoals;
    }

    protected void GetTotalPoints()
    {
        int grandTotal = 0;
        foreach(CheckListGoal checkListGoal in _checkListGoals)
        {
            grandTotal += checkListGoal._total;
        }
        UpdateTotal(grandTotal);
    }

    public void SetRunning(int runningTotal){_total = runningTotal;}

    // Returns
    public int GetFactor(){ return _points; }
    public int GetReward(){ return _reward; }
    public int GetReps(){ return _reps; }
    public int GetRunningTotal(){ return _total; }
    public bool GetComplete(){ return _completed;} 


    // Complete and Close
    public override void CloseGoal()
    {
        UpdateTotal(_total);
        CompleteGoal(_name, _total);
        _completed = true;
        Console.WriteLine($"Closed {_self} goal");
    }
}