using System;
using System.Collections.Generic;
using System.IO;

class GetScripture
{
    public string GetReferenceFromUser()
    {
        Console.Write("Enter the scripture reference (e.g., John 3:16): ");
        return Console.ReadLine();
    }

    public string GetTextFromUser()
    {
        Console.Write("Enter the scripture text: ");
        return Console.ReadLine();
    }

    public void Save(Scripture scripture)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(scripture.GetReference());
            writer.WriteLine(scripture.GetText());
        }
        Console.WriteLine("Scripture saved successfully!");
    }

    public Scripture LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length >= 2)
            {
                string reference = lines[0];
                string text = string.Join(" ", lines, 1, lines.Length - 1);
                return new Scripture(reference, text);
            }
            else
            {
                Console.WriteLine("Invalid file format.");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        return null;
    }
}
