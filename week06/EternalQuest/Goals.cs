using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName}: {_description}";
    }

    public virtual string GetDetailsString()
    {
        return GetStringRepresentation();
    }
}