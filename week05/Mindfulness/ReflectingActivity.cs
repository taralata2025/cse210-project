using System;
using System.Collections.Generic;
using System.Threading; 

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    // Constructor: Calls the base class constructor with the activity's name and description
    public ReflectingActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }
        public void Run()
    {
        DisplayStartingMessage(); 

        // Display the prompt
        DisplayPrompt(); 

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5); 
        Console.Clear();

        // Loop for reflecting on questions until the specified duration is reached
        while (DateTime.Now < _endTime)
        {
            DisplayQuestion();
            ShowSpinner(8); 
            Console.WriteLine();
            Console.WriteLine(); 
        }

        DisplayEndingMessage(); 
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt(); // Get a random prompt
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine(); // Wait for user to press enter
    }

    
    
    private string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }

    // Helper method to display the question as per diagram
    private void DisplayQuestion()
    {
        string question = GetRandomQuestion(); // Get a random question
        Console.Write($"> {question} ");
        // Note: The diagram lists DisplayQuestion as void, and it only displays.
        // The spinning pause comes after the display, in the Run method.
    }
}