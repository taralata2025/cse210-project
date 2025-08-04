using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;
    protected DateTime _startTime;
    protected DateTime _endTime;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number for the duration.");
            Console.Write("How long, in seconds, would you like for your session? ");
            input = Console.ReadLine();
        }

        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(_duration);

        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinnerChars = { '|', '/', '-', '\\' };
        DateTime startTime = DateTime.Now;
        int i = 0;

        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i > 1)
            {
                Console.Write("\b \b");
            }
        }
        Console.WriteLine();
    }
}