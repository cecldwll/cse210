using System;

public class Program
{
    public static void Main()
    {
        Address address1 = new Address("123 Main St", "Anytown", "Anystate", "92507");
        Address address2 = new Address("456 Blaine St", "Othertown", "Otherstate", "92506");
        Address address3 = new Address("789 3rd St", "Sometown", "Somestate", "83440");

        Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in tech", DateTime.Now, "10:00 AM", address1, "John Doe", 100);
        Reception reception = new Reception("Wedding Reception", "Celebrate the wedding of Jane and John", DateTime.Now, "6:00 PM", address2, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic", "A fun day at the park", DateTime.Now, "12:00 PM", address3, "Sunny");

        Console.WriteLine("Lecture Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine("\nLecture Full Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\nLecture Short Description:");
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("\nReception Standard Details:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine("\nReception Full Details:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("\nReception Short Description:");
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("\nOutdoor Gathering Standard Details:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine("\nOutdoor Gathering Full Details:");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine("\nOutdoor Gathering Short Description:");
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
