using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage(); 

        Console.WriteLine("Clear your mind and begin...");
        
        while (DateTime.Now < _endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4); 
            Console.WriteLine();

            if (DateTime.Now >= _endTime) break; 

            Console.Write("Breathe out...");
            ShowCountdown(6); 
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage(); 
    }
}