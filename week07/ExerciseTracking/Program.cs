using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Running runningActivity = new Running("12 Aug 2025", 30, 4.8);
        Cycling cyclingActivity = new Cycling("13 Aug 2025", 45, 15.5);
        Swimming swimmingActivity = new Swimming("14 Aug 2025", 60, 20);

        List<Activity> activities = new List<Activity>();
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        foreach (Activity activity in activities)
        {
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
    }
}