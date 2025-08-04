using System;
using System.Collections.Generic;
using System.Threading; 

public class ListingActivity : Activity
{
    private int _count; // store the number of items listed by the user
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    //  Calls the base class constructor with the activity's name and description
    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0; 
    }

    public void Run()
    {
        DisplayStartingMessage(); 

        // Get a random prompt and display it
        string prompt = GetRandomPrompt(); 
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine(); 

        // Call the method to get items from the user
        GetListFromUser(); 

        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();

        DisplayEndingMessage(); 
    }

        private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Method to get the list of items from the user
    private void GetListFromUser()
    {
        _count = 0; 

        while (DateTime.Now < _endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                _count++;
            }
        }
    }
}