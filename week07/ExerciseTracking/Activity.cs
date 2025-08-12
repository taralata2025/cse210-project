using System;

public abstract class Activity
{
    private string _date;
    private int _lengthInMinutes;

    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_lengthInMinutes} min): Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}