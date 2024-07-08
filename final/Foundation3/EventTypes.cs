// NOTE
// ChatGTP helped write some of this code for me and helped me learn

// ==============  Lecture  ==========================================
public class Lecture : Event
{
    private string _speaker { get; }
    private int _capacity { get; }

    public Lecture(string title, string time, string description, Address address, DateTime date, string speaker, int capacity)
    : base(title, time, description, address, date)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string FullDetails() { return $"\nFull Deatils\n--------------- {RegDetails()} \nType: Lecture \nSpeaker: {_speaker} \nCapacity: {_capacity}"; }
}

// ==============  Reception  ==========================================
public class Reception : Event
{
    private string _email { get; }

    public Reception(string title, string time, string description, Address address, DateTime date, string email)
    : base(title, time, description, address, date)
    {
        _email = email;
    }

    public override string FullDetails() { return $"\nFull Deatils\n--------------- {RegDetails()} \nType: Reception \nRSVP Email: {_email}"; }
}

// ==============  Outdoor  ==========================================
public class Outdoor : Event
{
    private string _weather { get; }

    public Outdoor(string title, string time, string description, Address address, DateTime date, string weather)
    : base(title, time, description, address, date)
    {
        _weather = weather;
    }

    public override string FullDetails() { return $"\nFull Deatils\n--------------- {RegDetails()} \nType: Outdoor Gathering \nWeather Forecast: {_weather}"; }
}