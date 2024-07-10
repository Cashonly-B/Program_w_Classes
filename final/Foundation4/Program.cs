using System;

// NOTE
// ChatGPT helped me write a few lines of the code

public abstract class Activity
{
    public DateTime _date { get; private set; }
    public int _minutes { get; private set; }

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double Distance();
    public abstract double Speed();
    public abstract double Pace();

    public virtual string Summary() { return $"{_date.ToString("MM/dd/yyyy")} - {this.GetType().Name} ({_minutes} min) - Distance: {Distance():F1} miles, Speed: {Speed():F1} mph, Pace: {Pace():F1} min/mile"; }
}

// =========== Running ======================================
public class Running : Activity
{
    public double _distance { get; private set; }

    public Running(DateTime date, int minutes, double distance)
    : base(date, minutes)
    {
        _distance = distance;
    }

    public override double Distance() => _distance;
    public override double Speed() => (_distance / _minutes) * 60;
    public override double Pace() => _minutes / _distance;
}

// =========== Cycling ======================================
public class Cycling : Activity
{
    public double _speed { get; private set; }

    public Cycling(DateTime date, int minutes, double speed)
    : base(date, minutes)
    {
        _speed = speed;
    }

    public override double Distance() => (_speed * _minutes) / 60;
    public override double Speed() => _speed;
    public override double Pace() => 60 / _speed;
}

// =========== Swimming ======================================
public class Swimming : Activity
{
    public int _laps { get; private set; }
    private const double _lengthInMeters = 50;
    private const double _metersToMilesConvert = 0.00062;

    public Swimming(DateTime date, int minutes, int laps)
    : base(date, minutes)
    {
        _laps = laps;
    }

    public override double Distance() => (_laps * _lengthInMeters) * _metersToMilesConvert;
    public override double Speed() => (Distance() / _minutes) * 60;
    public override double Pace() => _minutes / Distance();
}

// =========== Program ======================================
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 10, 7), 20, 2),
            new Cycling(new DateTime(2024, 10, 7), 30, 12),
            new Swimming(new DateTime(2024, 10, 7), 15, 10)
        };

        Console.WriteLine(); // A Space
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.Summary());
        }
    }
}