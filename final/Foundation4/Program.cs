using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 7, 18), 30, 3.0),
            new Cycling(new DateTime(2024, 7, 18), 30, 9.6),
            new Swimming(new DateTime(2024, 7, 18), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
