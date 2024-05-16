using System;

public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public string FormatEntry()
    {
        return $"{Date:MM/dd/yyyy HH:mm:ss}: {Prompt}\n- {Response}";
    }
}
