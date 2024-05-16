using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void WriteNewEntry(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response, DateTime.Now);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.FormatEntry());
            }
        }
    }

    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date:MM/dd/yyyy HH:mm:ss}");
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
                writer.WriteLine();
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadJournalFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string dateLine;
            while ((dateLine = reader.ReadLine()) != null)
            {
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();
                reader.ReadLine(); // Skip the empty line
                DateTime date = DateTime.ParseExact(dateLine, "MM/dd/yyyy HH:mm:ss", null);
                entries.Add(new Entry(prompt, response, date));
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}
