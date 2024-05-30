using System;

class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public string Display()
    {
        return hidden ? new string('-', text.Length) : text;
    }

    public string GetText()
    {
        return text;
    }
}
