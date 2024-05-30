using System;
using System.Collections.Generic;

class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        SplitText(text);
    }

    private void SplitText(string text)
    {
        words = new List<Word>();
        string[] splitWords = text.Split(' ');
        foreach (var word in splitWords)
        {
            words.Add(new Word(word));
        }
    }

    public string Display()
    {
        string result = $"{reference}\n";
        foreach (var word in words)
        {
            result += word.Display() + " ";
        }
        return result.Trim();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int countToHide = Math.Max(1, words.Count / 4); // Adjust as needed

        for (int i = 0; i < countToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        List<string> wordTexts = new List<string>();
        foreach (var word in words)
        {
            wordTexts.Add(word.GetText());
        }
        return string.Join(" ", wordTexts);
    }
}
